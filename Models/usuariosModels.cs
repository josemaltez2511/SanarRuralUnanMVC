using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;

// Modelo de usuario para la aplicación SanarRuralUnan
// Este modelo representa un usuario en la aplicación y contiene métodos para guardar un usuario,
// El modelo es para manejar la lógica de negocio relacionada con los usuarios,
// como guardar un nuevo usuario en la base de datos
namespace SanarRuralUnan.Models
{
    public class usuariosModels
    {
        private const int IteracionesHash = 600000;
        private const int LongitudHash = 32;
        private const string VersionHash = "PBKDF2-SHA256$1";

        public static int? IdUsuarioActual { get; private set; }
        public static int? IdRolActual { get; private set; }
        public static string CorreoActual { get; private set; }

        // MÉTODO PARA VERIFICAR SI UN CORREO YA EXISTE EN LA BD
        // esto lo usa el Controller para validar antes de crear o mientras el usuario escribe
        // devuelve true si el correo ya está registrado, false si está libre
        public bool ExisteCorreo(string correo, int? idUsuarioExcluir = null)
        {
            using (var db = new SanarRuralDBEntities())
            {
                return db.Usuarios.Any(u => u.Correo == correo &&
                    (!idUsuarioExcluir.HasValue || u.IdUsuario != idUsuarioExcluir.Value));
            }
        }

        public static bool EsUsuarioSesionActivo(SanarRuralDBEntities db, string rolEsperado = null)
        {
            if (!IdUsuarioActual.HasValue || !IdRolActual.HasValue) return false;
            var usuario = db.Usuarios.Include(u => u.Roles).FirstOrDefault(u => u.IdUsuario == IdUsuarioActual.Value && u.Estado);
            if (usuario == null || usuario.IdRol != IdRolActual.Value || usuario.Roles == null) return false;
            if (!string.IsNullOrEmpty(rolEsperado))
            {
                return usuario.Roles.Nombre == rolEsperado;
            }
            return true;
        }

        public static bool EsUsuarioSesionActivo(string rolEsperado = null)
        {
            using (var db = new SanarRuralDBEntities())
            {
                return EsUsuarioSesionActivo(db, rolEsperado);
            }
        }

        public static bool EsSesionAdministrativa()
        {
            return EsUsuarioSesionActivo("Administrativo");
        }

        public static bool EsSesionAdministrativa(SanarRuralDBEntities db)
        {
            return EsUsuarioSesionActivo(db, "Administrativo");
        }

        public static void ExigirRolAdministrativo(string operacion)
        {
            if (!EsSesionAdministrativa())
            {
                throw new UnauthorizedAccessException("Se requiere rol Administrativo para " + operacion + ".");
            }
        }

        public static void ExigirRolAdministrativo(SanarRuralDBEntities db, string operacion)
        {
            if (!EsSesionAdministrativa(db))
            {
                throw new UnauthorizedAccessException("Se requiere rol Administrativo para " + operacion + ".");
            }
        }

        public List<Roles> ListarRoles()
        {
            using (var db = new SanarRuralDBEntities())
            {
                if (EsSesionAdministrativa())
                {
                    return db.Roles.OrderBy(r => r.Nombre).ToList();
                }

                return db.Roles.Where(r => r.Nombre == "Paciente").ToList();
            }
        }

        public int ObtenerIdRol(string nombre)
        {
            using (var db = new SanarRuralDBEntities())
            {
                Roles rol = db.Roles.FirstOrDefault(r => r.Nombre == nombre);
                return rol == null ? -1 : rol.IdRol;
            }
        }

        public List<Usuarios> ListarUsuarios(string filtro)
        {
            ExigirRolAdministrativo("listar los usuarios del sistema");

            using (var db = new SanarRuralDBEntities())
            {
                var consulta = db.Usuarios.Include(u => u.Roles).Where(u => u.Estado);
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.Trim();
                    consulta = consulta.Where(u => u.Correo.Contains(filtro) || u.Roles.Nombre.Contains(filtro));
                }

                return consulta.OrderBy(u => u.Correo).ToList();
            }
        }

        public Usuarios ConsultarUsuario(int idUsuario)
        {
            if (!EsSesionAdministrativa() && (!IdUsuarioActual.HasValue || IdUsuarioActual.Value != idUsuario))
            {
                throw new UnauthorizedAccessException("No tiene autorización para consultar los datos de esta cuenta de usuario.");
            }

            using (var db = new SanarRuralDBEntities())
            {
                return db.Usuarios.Include(u => u.Roles)
                    .FirstOrDefault(u => u.IdUsuario == idUsuario && u.Estado);
            }
        }

        // MÉTODO PARA GUARDAR UN USUARIO
        // Devuelve el IdUsuario generado para asociar el perfil correspondiente.
        public int Guardar(int idRol, string correo, string contrasena)
        {
            using (var db = new SanarRuralDBEntities())
            {
                int idRolPaciente = ObtenerIdRolEnContexto(db, "Paciente");

                // Distinción estricta de flujos:
                // 1. Si no hay sesión iniciada (registro público): ÚNICAMENTE se permite registrar cuentas de Paciente.
                if (!IdUsuarioActual.HasValue)
                {
                    if (idRol != idRolPaciente)
                    {
                        throw new UnauthorizedAccessException("El registro público de cuentas solo permite el rol 'Paciente'. Para registrar usuarios con otros roles debe iniciar sesión un administrador.");
                    }
                }
                else
                {
                    // 2. Si hay sesión iniciada: SOLO el rol Administrativo puede crear cuentas en el sistema.
                    ExigirRolAdministrativo("crear cuentas de usuario en el sistema");
                }

                Usuarios usuarioNuevo = new Usuarios
                {
                    IdRol = idRol,
                    Correo = correo,
                    ContrasenaHash = CrearHashContrasena(contrasena),
                    FechaRegistro = DateTime.Now,
                    Estado = true
                };

                db.Usuarios.Add(usuarioNuevo);
                db.SaveChanges();
                return usuarioNuevo.IdUsuario;
            }
        }

        public bool Actualizar(int idUsuario, int idRol, string correo, string nuevaContrasena)
        {
            ExigirRolAdministrativo("modificar cuentas y roles de usuario");

            using (var db = new SanarRuralDBEntities())
            {
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario && u.Estado);
                if (usuario == null)
                    return false;

                // Impedir cambiar el rol de la cuenta administrativa activa en la sesión actual
                if (IdUsuarioActual.HasValue && IdUsuarioActual.Value == idUsuario && idRol != usuario.IdRol)
                {
                    throw new InvalidOperationException("No se permite cambiar el rol de la propia cuenta administrativa activa en la sesión actual.");
                }

                bool tieneDoctor = db.Doctores.Any(d => d.IdUsuario == idUsuario);
                bool tienePaciente = db.Pacientes.Any(p => p.IdUsuario == idUsuario);
                bool rolCompatible = (!tieneDoctor || idRol == ObtenerIdRolEnContexto(db, "Doctor")) &&
                    (!tienePaciente || idRol == ObtenerIdRolEnContexto(db, "Paciente"));

                if (idRol != usuario.IdRol && !rolCompatible)
                    throw new InvalidOperationException("No se puede cambiar el rol porque el usuario tiene un perfil clínico o institucional incompatible.");

                usuario.IdRol = idRol;
                usuario.Correo = correo;
                if (!string.IsNullOrEmpty(nuevaContrasena))
                    usuario.ContrasenaHash = CrearHashContrasena(nuevaContrasena);

                db.SaveChanges();

                if (IdUsuarioActual == idUsuario)
                {
                    IdRolActual = idRol;
                    CorreoActual = correo;
                }
                return true;
            }
        }

        private int ObtenerIdRolEnContexto(SanarRuralDBEntities db, string nombre)
        {
            Roles rol = db.Roles.FirstOrDefault(r => r.Nombre == nombre);
            return rol == null ? -1 : rol.IdRol;
        }

        public bool DarDeBaja(int idUsuario)
        {
            ExigirRolAdministrativo("dar de baja cuentas de usuario");

            if (IdUsuarioActual.HasValue && IdUsuarioActual.Value == idUsuario)
            {
                throw new InvalidOperationException("No se permite dar de baja a la cuenta de usuario actualmente activa en la sesión.");
            }

            using (var db = new SanarRuralDBEntities())
            {
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario && u.Estado);
                if (usuario == null)
                    return false;

                usuario.Estado = false;
                db.SaveChanges();
                return true;
            }
        }

        public bool VerificarContrasena(string contrasena, string hashGuardado)
        {
            if (string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(hashGuardado))
                return false;

            try
            {
                string[] partes = hashGuardado.Split('$');
                if (partes.Length != 5 || partes[0] != "PBKDF2-SHA256" || partes[1] != "1")
                    return false;

                int iteraciones;
                if (!int.TryParse(partes[2], out iteraciones) || iteraciones < 100000 || iteraciones > 2000000)
                    return false;

                byte[] sal = Convert.FromBase64String(partes[3]);
                byte[] hashEsperado = Convert.FromBase64String(partes[4]);
                if (sal.Length != 16 || hashEsperado.Length != LongitudHash)
                    return false;

                byte[] hashCalculado;
                using (var derivador = new Rfc2898DeriveBytes(contrasena, sal, iteraciones, HashAlgorithmName.SHA256))
                    hashCalculado = derivador.GetBytes(LongitudHash);

                int diferencia = 0;
                for (int i = 0; i < hashEsperado.Length; i++)
                    diferencia |= hashEsperado[i] ^ hashCalculado[i];

                return diferencia == 0;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private string CrearHashContrasena(string contrasena)
        {
            byte[] sal = new byte[16];
            using (var generador = RandomNumberGenerator.Create())
                generador.GetBytes(sal);

            byte[] hash;
            using (var derivador = new Rfc2898DeriveBytes(contrasena, sal, IteracionesHash, HashAlgorithmName.SHA256))
                hash = derivador.GetBytes(LongitudHash);

            return VersionHash + "$" + IteracionesHash + "$" +
                Convert.ToBase64String(sal) + "$" + Convert.ToBase64String(hash);
        }

        // MÉTODO PARA INICIAR SESIÓN
        // Retorna -1 si las credenciales son incorrectas o el IdRol de la cuenta activa.
        public int IniciarSesion(string correo, string contrasena)
        {
            using (var db = new SanarRuralDBEntities())
            {
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.Correo == correo && u.Estado);
                if (usuario == null || !VerificarContrasena(contrasena, usuario.ContrasenaHash))
                {
                    CerrarSesion();
                    return -1;
                }

                IdUsuarioActual = usuario.IdUsuario;
                IdRolActual = usuario.IdRol;
                CorreoActual = usuario.Correo;
                return usuario.IdRol;
            }
        }

        // MÉTODO CERRAR SESIÓN
        public void CerrarSesion()
        {
            IdUsuarioActual = null;
            IdRolActual = null;
            CorreoActual = null;
        }

        // Resuelve el IdDoctor asociado al usuario autenticado actualmente en la sesión.
        public int? ObtenerIdDoctorActual()
        {
            using (var db = new SanarRuralDBEntities())
            {
                return ObtenerIdDoctorActual(db);
            }
        }

        public int? ObtenerIdDoctorActual(SanarRuralDBEntities db)
        {
            if (!IdUsuarioActual.HasValue) return null;
            if (!EsUsuarioSesionActivo(db, "Doctor")) return null;
            var doctor = db.Doctores.FirstOrDefault(d => d.IdUsuario == IdUsuarioActual.Value && d.Estado);
            return doctor != null ? doctor.IdDoctor : (int?)null;
        }

        // Resuelve el IdPaciente asociado al usuario autenticado actualmente en la sesión.
        public int? ObtenerIdPacienteActual()
        {
            using (var db = new SanarRuralDBEntities())
            {
                return ObtenerIdPacienteActual(db);
            }
        }

        public int? ObtenerIdPacienteActual(SanarRuralDBEntities db)
        {
            if (!IdUsuarioActual.HasValue) return null;
            if (!EsUsuarioSesionActivo(db, "Paciente")) return null;
            var paciente = db.Pacientes.FirstOrDefault(p => p.IdUsuario == IdUsuarioActual.Value && p.Estado);
            return paciente != null ? paciente.IdPaciente : (int?)null;
        }
    }
}
