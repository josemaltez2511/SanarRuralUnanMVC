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

        public List<Roles> ListarRoles()
        {
            using (var db = new SanarRuralDBEntities())
            {
                return db.Roles.OrderBy(r => r.Nombre).ToList();
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
            using (var db = new SanarRuralDBEntities())
            {
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario && u.Estado);
                if (usuario == null)
                    return false;

                bool tieneDoctor = db.Doctores.Any(d => d.IdUsuario == idUsuario);
                bool tienePaciente = db.Pacientes.Any(p => p.IdUsuario == idUsuario);
                bool rolCompatible = (!tieneDoctor || idRol == ObtenerIdRolEnContexto(db, "Doctor")) &&
                    (!tienePaciente || idRol == ObtenerIdRolEnContexto(db, "Paciente"));

                if (idRol != usuario.IdRol && !rolCompatible)
                    throw new InvalidOperationException("No se puede cambiar el rol porque el usuario tiene un perfil relacionado.");

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
            using (var db = new SanarRuralDBEntities())
            {
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario && u.Estado);
                if (usuario == null)
                    return false;

                usuario.Estado = false;
                db.SaveChanges();
                if (IdUsuarioActual == idUsuario)
                    CerrarSesion();
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
    }
}
