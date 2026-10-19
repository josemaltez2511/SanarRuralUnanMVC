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
        public static string NombreUsuarioActual { get; private set; }
        public static string CorreoActual { get; private set; }
        public static string NombreRolActual { get; private set; }

        public static bool EsRolAdministrativo(string nombreRol)
        {
            if (string.IsNullOrEmpty(nombreRol)) return false;
            return nombreRol == "Admin" || nombreRol == "Personal_administrativo" || nombreRol == "Administrativo";
        }

        // MÉTODO PARA VERIFICAR SI UN NOMBRE DE USUARIO YA EXISTE EN LA BD
        public bool ExisteNombreUsuario(string nombreUsuario, int? idUsuarioExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return false;
            string usuarioNormalizado = nombreUsuario.Trim();
            using (var db = new SanarRuralDBEntities())
            {
                return db.Usuarios.Any(u => u.NombreUsuario == usuarioNormalizado &&
                    (!idUsuarioExcluir.HasValue || u.IdUsuario != idUsuarioExcluir.Value));
            }
        }

        // MÉTODO OBSOLETO: Las cuentas de usuario operan exclusivamente con NombreUsuario
        [Obsolete("Las cuentas de usuario ya no gestionan correo. Utilice ExisteNombreUsuario.")]
        public bool ExisteCorreo(string correo, int? idUsuarioExcluir = null)
        {
            return false;
        }

        public static bool EsUsuarioSesionActivo(SanarRuralDBEntities db, string rolEsperado = null)
        {
            if (!IdUsuarioActual.HasValue || !IdRolActual.HasValue) return false;
            var usuario = db.Usuarios.Include(u => u.Roles).FirstOrDefault(u => u.IdUsuario == IdUsuarioActual.Value && u.Estado);
            if (usuario == null || usuario.IdRol != IdRolActual.Value || usuario.Roles == null) return false;
            if (!string.IsNullOrEmpty(rolEsperado))
            {
                if (rolEsperado == "Administrativo")
                {
                    return EsRolAdministrativo(usuario.Roles.Nombre);
                }
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

        // Comprueba si la sesión activa corresponde al nuevo rol definitivo 'Admin'
        public static bool EsSesionAdmin()
        {
            return EsUsuarioSesionActivo("Admin");
        }

        public static bool EsSesionAdmin(SanarRuralDBEntities db)
        {
            return EsUsuarioSesionActivo(db, "Admin");
        }

        // Comprueba si la sesión activa corresponde al rol 'Personal_administrativo'
        public static bool EsSesionPersonalAdministrativo()
        {
            return EsUsuarioSesionActivo("Personal_administrativo");
        }

        public static bool EsSesionPersonalAdministrativo(SanarRuralDBEntities db)
        {
            return EsUsuarioSesionActivo(db, "Personal_administrativo");
        }

        // Determina si el usuario en sesión tiene facultades de administración completa de usuarios y personal (Admin o Administrativo histórico)
        public static bool PuedeGestionarUsuariosYPersonal()
        {
            if (!IdUsuarioActual.HasValue || !IdRolActual.HasValue) return false;
            string rol = NombreRolActual;
            return rol == "Admin" || rol == "Administrativo";
        }

        public static bool PuedeGestionarUsuariosYPersonal(SanarRuralDBEntities db)
        {
            if (!IdUsuarioActual.HasValue || !IdRolActual.HasValue) return false;
            var usuario = db.Usuarios.Include(u => u.Roles).FirstOrDefault(u => u.IdUsuario == IdUsuarioActual.Value && u.Estado);
            if (usuario == null || usuario.Roles == null) return false;
            return usuario.Roles.Nombre == "Admin" || usuario.Roles.Nombre == "Administrativo";
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

        public static void ExigirPermisoGestionCompleta(string operacion)
        {
            if (!PuedeGestionarUsuariosYPersonal())
            {
                throw new UnauthorizedAccessException("No tiene permisos para " + operacion + ". Esta operación requiere privilegios de Administrador.");
            }
        }

        public static void ExigirPermisoGestionCompleta(SanarRuralDBEntities db, string operacion)
        {
            if (!PuedeGestionarUsuariosYPersonal(db))
            {
                throw new UnauthorizedAccessException("No tiene permisos para " + operacion + ". Esta operación requiere privilegios de Administrador.");
            }
        }

        public static void ExigirRolAdmin(string operacion)
        {
            if (!EsSesionAdmin())
            {
                throw new UnauthorizedAccessException("Solo el rol 'Admin' tiene autorización para " + operacion + ".");
            }
        }

        public static void ExigirRolAdmin(SanarRuralDBEntities db, string operacion)
        {
            if (!EsSesionAdmin(db))
            {
                throw new UnauthorizedAccessException("Solo el rol 'Admin' tiene autorización para " + operacion + ".");
            }
        }

        public List<Roles> ListarRoles()
        {
            using (var db = new SanarRuralDBEntities())
            {
                if (EsSesionAdministrativa(db))
                {
                    // Si la sesión activa es Admin definitivo, puede gestionar y asignar todos los roles
                    if (EsSesionAdmin(db))
                    {
                        return db.Roles.OrderBy(r => r.Nombre).ToList();
                    }

                    // Para el rol Administrativo histórico, no debe tener acceso a asignar el nuevo rol 'Admin'
                    return db.Roles.Where(r => r.Nombre != "Admin").OrderBy(r => r.Nombre).ToList();
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
                    consulta = consulta.Where(u =>
                        (u.NombreUsuario != null && u.NombreUsuario.Contains(filtro)) ||
                        (u.Roles != null && u.Roles.Nombre.Contains(filtro)));
                }

                return consulta.OrderBy(u => u.NombreUsuario).ToList();
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
        public int Guardar(int idRol, string nombreUsuario, string contrasena, string correo = null)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.", nameof(nombreUsuario));

            nombreUsuario = nombreUsuario.Trim();
            if (nombreUsuario.Length < 3 || nombreUsuario.Length > 50)
                throw new ArgumentException("El nombre de usuario debe tener entre 3 y 50 caracteres.", nameof(nombreUsuario));

            if (ExisteNombreUsuario(nombreUsuario))
                throw new InvalidOperationException("El nombre de usuario ya se encuentra registrado.");

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
                    // 2. Si hay sesión iniciada: Personal_administrativo no puede crear usuarios.
                    if (EsSesionPersonalAdministrativo(db))
                    {
                        throw new UnauthorizedAccessException("El rol Personal_administrativo no tiene autorización para crear cuentas de usuario. Esta operación es exclusiva de administradores.");
                    }

                    // Se exige facultad de administración completa (Admin o Administrativo histórico)
                    ExigirPermisoGestionCompleta(db, "crear cuentas de usuario en el sistema");

                    // 3. Exclusividad de Admin: Solo el rol 'Admin' puede crear o asignar cuentas con rol 'Admin'.
                    int idRolAdmin = ObtenerIdRolEnContexto(db, "Admin");
                    if (idRol == idRolAdmin && !EsSesionAdmin(db))
                    {
                        throw new UnauthorizedAccessException("Solo el rol 'Admin' tiene autorización para crear o asignar cuentas con rol 'Admin'.");
                    }
                }

                Usuarios usuarioNuevo = new Usuarios
                {
                    IdRol = idRol,
                    NombreUsuario = nombreUsuario,
                    ContrasenaHash = CrearHashContrasena(contrasena),
                    FechaRegistro = DateTime.Now,
                    Estado = true
                };

                db.Usuarios.Add(usuarioNuevo);
                db.SaveChanges();
                return usuarioNuevo.IdUsuario;
            }
        }

        public int Guardar(int idRol, string nombreUsuario, string contrasena)
        {
            return Guardar(idRol, nombreUsuario, contrasena, null);
        }

        public bool Actualizar(int idUsuario, int idRol, string nombreUsuario, string nuevaContrasena, string correo = null)
        {
            if (EsSesionPersonalAdministrativo())
            {
                throw new UnauthorizedAccessException("El rol Personal_administrativo no tiene autorización para modificar cuentas de usuario. Esta operación es exclusiva de administradores.");
            }

            ExigirPermisoGestionCompleta("modificar cuentas y roles de usuario");

            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.", nameof(nombreUsuario));

            nombreUsuario = nombreUsuario.Trim();
            if (nombreUsuario.Length < 3 || nombreUsuario.Length > 50)
                throw new ArgumentException("El nombre de usuario debe tener entre 3 y 50 caracteres.", nameof(nombreUsuario));

            if (ExisteNombreUsuario(nombreUsuario, idUsuario))
                throw new InvalidOperationException("El nombre de usuario ya está asignado a otra cuenta.");

            using (var db = new SanarRuralDBEntities())
            {
                // Exclusividad de Admin: Solo el rol 'Admin' puede promover o asignar el rol 'Admin'.
                int idRolAdmin = ObtenerIdRolEnContexto(db, "Admin");
                if (idRol == idRolAdmin && !EsSesionAdmin(db))
                {
                    throw new UnauthorizedAccessException("Solo el rol 'Admin' tiene autorización para asignar el rol 'Admin'.");
                }

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
                usuario.NombreUsuario = nombreUsuario;

                if (!string.IsNullOrEmpty(nuevaContrasena))
                    usuario.ContrasenaHash = CrearHashContrasena(nuevaContrasena);

                db.SaveChanges();

                if (IdUsuarioActual == idUsuario)
                {
                    IdRolActual = idRol;
                    NombreUsuarioActual = nombreUsuario;
                    var rol = db.Roles.FirstOrDefault(r => r.IdRol == idRol);
                    if (rol != null)
                        NombreRolActual = rol.Nombre;
                }
                return true;
            }
        }

        public bool Actualizar(int idUsuario, int idRol, string nombreUsuario, string nuevaContrasena)
        {
            return Actualizar(idUsuario, idRol, nombreUsuario, nuevaContrasena, null);
        }

        private int ObtenerIdRolEnContexto(SanarRuralDBEntities db, string nombre)
        {
            Roles rol = db.Roles.FirstOrDefault(r => r.Nombre == nombre);
            return rol == null ? -1 : rol.IdRol;
        }

        private string ObtenerNombreRolEnContexto(SanarRuralDBEntities db, int idRol)
        {
            Roles rol = db.Roles.FirstOrDefault(r => r.IdRol == idRol);
            return rol != null ? rol.Nombre : string.Empty;
        }

        public bool DarDeBaja(int idUsuario)
        {
            if (EsSesionPersonalAdministrativo())
            {
                throw new UnauthorizedAccessException("El rol Personal_administrativo no tiene autorización para dar de baja cuentas de usuario. Esta operación es exclusiva de administradores.");
            }

            ExigirPermisoGestionCompleta("dar de baja cuentas de usuario");

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
        // Retorna:
        // -1 si las credenciales son incorrectas o no existe el usuario.
        // -2 si las credenciales son válidas pero la cuenta está inactiva (Estado == false).
        // IdRol (> 0) si el inicio de sesión es exitoso.
        public int IniciarSesion(string identificador, string contrasena)
        {
            CerrarSesion();

            if (string.IsNullOrWhiteSpace(identificador) || string.IsNullOrEmpty(contrasena))
                return -1;

            string identNormalizado = identificador.Trim();

            using (var db = new SanarRuralDBEntities())
            {
                Usuarios usuario = db.Usuarios
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.NombreUsuario == identNormalizado);

                if (usuario == null || !VerificarContrasena(contrasena, usuario.ContrasenaHash))
                {
                    CerrarSesion();
                    return -1;
                }

                if (!usuario.Estado)
                {
                    CerrarSesion();
                    return -2;
                }

                IdUsuarioActual = usuario.IdUsuario;
                IdRolActual = usuario.IdRol;
                NombreUsuarioActual = usuario.NombreUsuario;
                CorreoActual = null;
                NombreRolActual = usuario.Roles != null ? usuario.Roles.Nombre : ObtenerNombreRolEnContexto(db, usuario.IdRol);
                return usuario.IdRol;
            }
        }

        // MÉTODO CERRAR SESIÓN
        public void CerrarSesion()
        {
            IdUsuarioActual = null;
            IdRolActual = null;
            NombreUsuarioActual = null;
            CorreoActual = null;
            NombreRolActual = null;
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

        // =========================================================================
        // FLUJO DE ASIGNACIÓN DE ACCESOS VINCULADOS A PERFILES
        // =========================================================================

        public bool PuedeCrearAccesoParaRol(string tipoPerfil)
        {
            if (!PuedeGestionarUsuariosYPersonal()) return false;
            if (tipoPerfil == "Administrador" || tipoPerfil == "Admin")
            {
                return EsSesionAdmin();
            }
            return true;
        }

        public List<PerfilSinUsuarioDto> ListarPerfilesSinUsuario(string filtroTipo = null, string busqueda = null)
        {
            ExigirPermisoGestionCompleta("consultar los perfiles pendientes de asignación de acceso");

            using (var db = new SanarRuralDBEntities())
            {
                var lista = new List<PerfilSinUsuarioDto>();

                // 1. Pacientes activos sin usuario vinculado
                var pacientes = db.Pacientes
                    .Where(p => p.IdUsuario == null && p.Estado)
                    .Select(p => new
                    {
                        p.IdPaciente,
                        p.PrimerNombre,
                        p.SegundoNombre,
                        p.PrimerApellido,
                        p.SegundoApellido,
                        p.Cedula,
                        p.Telefono,
                        Ubicacion = p.Comunidades != null ? p.Comunidades.Nombre : p.Direccion
                    })
                    .ToList();

                foreach (var p in pacientes)
                {
                    string nom = string.Join(" ", new string[] { p.PrimerNombre, p.SegundoNombre, p.PrimerApellido, p.SegundoApellido }.Where(s => !string.IsNullOrWhiteSpace(s)));
                    lista.Add(new PerfilSinUsuarioDto
                    {
                        TipoPerfil = "Paciente",
                        RolAsignar = "Paciente",
                        IdPerfil = p.IdPaciente,
                        NombreCompleto = nom,
                        Identificacion = p.Cedula ?? string.Empty,
                        Telefono = p.Telefono ?? string.Empty,
                        UbicacionCargo = p.Ubicacion ?? string.Empty
                    });
                }

                // 2. Doctores activos sin usuario vinculado
                var doctores = db.Doctores
                    .Where(d => d.IdUsuario == null && d.Estado)
                    .Select(d => new
                    {
                        d.IdDoctor,
                        d.PrimerNombre,
                        d.SegundoNombre,
                        d.PrimerApellido,
                        d.SegundoApellido,
                        d.Cedula,
                        d.Telefono,
                        Hospital = db.DoctorHospitalEspecialidad
                            .Where(dhe => dhe.IdDoctor == d.IdDoctor)
                            .Select(dhe => dhe.Hospitales.Nombre)
                            .FirstOrDefault()
                    })
                    .ToList();

                foreach (var d in doctores)
                {
                    string nom = string.Join(" ", new string[] { d.PrimerNombre, d.SegundoNombre, d.PrimerApellido, d.SegundoApellido }.Where(s => !string.IsNullOrWhiteSpace(s)));
                    lista.Add(new PerfilSinUsuarioDto
                    {
                        TipoPerfil = "Doctor",
                        RolAsignar = "Doctor",
                        IdPerfil = d.IdDoctor,
                        NombreCompleto = "Dr(a). " + nom,
                        Identificacion = d.Cedula ?? string.Empty,
                        Telefono = d.Telefono ?? string.Empty,
                        UbicacionCargo = d.Hospital ?? "Sin hospital asignado"
                    });
                }

                // 3. Personal Administrativo activo sin usuario vinculado (mediante SQL compatible)
                try
                {
                    bool tablaPersonalExiste = db.Database.SqlQuery<int>(
                        "SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PersonalAdministrativo'").FirstOrDefault() > 0;

                    if (tablaPersonalExiste)
                    {
                        var personalSql = db.Database.SqlQuery<PerfilSinUsuarioDto>(@"
                            SELECT
                                'Personal administrativo' AS TipoPerfil,
                                'Personal_administrativo' AS RolAsignar,
                                pa.IdPersonalAdministrativo AS IdPerfil,
                                LTRIM(RTRIM(CONCAT(pa.PrimerNombre, ' ', pa.SegundoNombre, ' ', pa.PrimerApellido, ' ', pa.SegundoApellido))) AS NombreCompleto,
                                ISNULL(pa.Cedula, '') AS Identificacion,
                                ISNULL(pa.Telefono, '') AS Telefono,
                                ISNULL(pa.Cargo, 'Personal administrativo') AS UbicacionCargo
                            FROM PersonalAdministrativo pa
                            WHERE pa.IdUsuario IS NULL AND pa.Estado = 1
                        ").ToList();

                        lista.AddRange(personalSql);
                    }
                }
                catch
                {
                    // Si la tabla no está disponible en este entorno, se omite de forma segura
                }

                // 4. Administradores activos sin usuario vinculado (solo visible para rol 'Admin')
                if (EsSesionAdmin(db))
                {
                    try
                    {
                        bool tablaAdminExiste = db.Database.SqlQuery<int>(
                            "SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Administradores'").FirstOrDefault() > 0;

                        if (tablaAdminExiste)
                        {
                            var adminSql = db.Database.SqlQuery<PerfilSinUsuarioDto>(@"
                                SELECT
                                    'Administrador' AS TipoPerfil,
                                    'Admin' AS RolAsignar,
                                    a.IdAdministrador AS IdPerfil,
                                    LTRIM(RTRIM(CONCAT(a.PrimerNombre, ' ', a.SegundoNombre, ' ', a.PrimerApellido, ' ', a.SegundoApellido))) AS NombreCompleto,
                                    ISNULL(a.Cedula, '') AS Identificacion,
                                    ISNULL(a.Telefono, '') AS Telefono,
                                    'Administración' AS UbicacionCargo
                                FROM Administradores a
                                WHERE a.IdUsuario IS NULL AND a.Estado = 1
                            ").ToList();

                            lista.AddRange(adminSql);
                        }
                    }
                    catch
                    {
                        // Omisión segura si no existe
                    }
                }

                // Filtrado por tipo de perfil
                if (!string.IsNullOrWhiteSpace(filtroTipo) && filtroTipo != "Todos los perfiles sin usuario")
                {
                    lista = lista.Where(p => string.Equals(p.TipoPerfil, filtroTipo.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Filtrado por búsqueda de texto
                if (!string.IsNullOrWhiteSpace(busqueda))
                {
                    string q = busqueda.Trim().ToLowerInvariant();
                    lista = lista.Where(p =>
                        (p.NombreCompleto != null && p.NombreCompleto.ToLowerInvariant().Contains(q)) ||
                        (p.Identificacion != null && p.Identificacion.ToLowerInvariant().Contains(q)) ||
                        (p.Telefono != null && p.Telefono.ToLowerInvariant().Contains(q)) ||
                        (p.UbicacionCargo != null && p.UbicacionCargo.ToLowerInvariant().Contains(q))
                    ).ToList();
                }

                return lista.OrderBy(p => p.TipoPerfil).ThenBy(p => p.NombreCompleto).ToList();
            }
        }

        public bool CrearUsuarioVinculadoAPerfil(int idPerfil, string tipoPerfil, string nombreUsuario, string contrasena, out string mensajeError)
        {
            mensajeError = null;

            if (EsSesionPersonalAdministrativo())
            {
                throw new UnauthorizedAccessException("El rol Personal_administrativo no tiene permisos para crear usuarios ni asignar accesos.");
            }

            ExigirPermisoGestionCompleta("crear y vincular cuentas de usuario a perfiles");

            if (idPerfil <= 0)
            {
                mensajeError = "Identificador de perfil no válido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoPerfil))
            {
                mensajeError = "Debe especificar el tipo de perfil.";
                return false;
            }

            tipoPerfil = tipoPerfil.Trim();

            // Validación estricta de jerarquía: solo 'Admin' puede crear usuarios con perfil 'Administrador'
            if ((tipoPerfil == "Administrador" || tipoPerfil == "Admin") && !EsSesionAdmin())
            {
                throw new UnauthorizedAccessException("Solo el rol 'Admin' tiene autorización para crear y vincular cuentas de Administrador.");
            }

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                mensajeError = "El nombre de usuario es obligatorio.";
                return false;
            }

            nombreUsuario = nombreUsuario.Trim();
            if (nombreUsuario.Length < 3 || nombreUsuario.Length > 50)
            {
                mensajeError = "El nombre de usuario debe tener entre 3 y 50 caracteres.";
                return false;
            }

            if (string.IsNullOrEmpty(contrasena) || contrasena.Length < 6)
            {
                mensajeError = "La contraseña debe tener al menos 6 caracteres.";
                return false;
            }

            string rolEsperado = ObtenerNombreRolPorTipoPerfil(tipoPerfil);
            if (string.IsNullOrEmpty(rolEsperado))
            {
                mensajeError = "El tipo de perfil '" + tipoPerfil + "' no tiene un rol válido asociado.";
                return false;
            }

            using (var db = new SanarRuralDBEntities())
            using (var tx = db.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    // 1. Obtener el rol en base de datos
                    var rol = db.Roles.FirstOrDefault(r => r.Nombre == rolEsperado);
                    if (rol == null)
                    {
                        mensajeError = "No se encontró el rol '" + rolEsperado + "' en el catálogo de roles de la base de datos.";
                        tx.Rollback();
                        return false;
                    }

                    // 2. Validar que el nombre de usuario no esté registrado
                    if (db.Usuarios.Any(u => u.NombreUsuario == nombreUsuario))
                    {
                        mensajeError = "El nombre de usuario '" + nombreUsuario + "' ya se encuentra registrado en el sistema. Elija otro nombre.";
                        tx.Rollback();
                        return false;
                    }

                    // 3. Comprobar que el perfil siga sin usuario y activo en este instante
                    if (!VerificarPerfilDisponible(db, idPerfil, tipoPerfil, out mensajeError))
                    {
                        tx.Rollback();
                        return false;
                    }

                    // 4. Crear el registro de Usuario
                    var nuevoUsuario = new Usuarios
                    {
                        NombreUsuario = nombreUsuario,
                        ContrasenaHash = CrearHashContrasena(contrasena),
                        IdRol = rol.IdRol,
                        FechaRegistro = DateTime.Now,
                        Estado = true
                    };
                    db.Usuarios.Add(nuevoUsuario);
                    db.SaveChanges();

                    if (nuevoUsuario.IdUsuario <= 0)
                    {
                        mensajeError = "No se pudo generar la cuenta de usuario.";
                        tx.Rollback();
                        return false;
                    }

                    // 5. Vincular el perfil seleccionado con el IdUsuario recién generado
                    if (!VincularUsuarioAPerfil(db, idPerfil, tipoPerfil, nuevoUsuario.IdUsuario, out mensajeError))
                    {
                        tx.Rollback();
                        return false;
                    }

                    // 6. Verificación de consistencia: confirmar que el usuario no quedó vinculado a ningún otro perfil
                    if (!VerificarConsistenciaVinculacion(db, idPerfil, tipoPerfil, nuevoUsuario.IdUsuario, out mensajeError))
                    {
                        tx.Rollback();
                        return false;
                    }

                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    mensajeError = "Error al vincular el acceso: " + ex.Message;
                    return false;
                }
            }
        }

        private static string ObtenerNombreRolPorTipoPerfil(string tipoPerfil)
        {
            if (string.Equals(tipoPerfil, "Paciente", StringComparison.OrdinalIgnoreCase))
                return "Paciente";
            if (string.Equals(tipoPerfil, "Doctor", StringComparison.OrdinalIgnoreCase))
                return "Doctor";
            if (string.Equals(tipoPerfil, "Personal administrativo", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(tipoPerfil, "Personal_administrativo", StringComparison.OrdinalIgnoreCase))
                return "Personal_administrativo";
            if (string.Equals(tipoPerfil, "Administrador", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(tipoPerfil, "Admin", StringComparison.OrdinalIgnoreCase))
                return "Admin";

            return null;
        }

        private static bool VerificarPerfilDisponible(SanarRuralDBEntities db, int idPerfil, string tipoPerfil, out string mensajeError)
        {
            mensajeError = null;

            if (tipoPerfil == "Paciente")
            {
                var p = db.Pacientes.FirstOrDefault(x => x.IdPaciente == idPerfil);
                if (p == null || !p.Estado)
                {
                    mensajeError = "El paciente seleccionado no existe o se encuentra inactivo.";
                    return false;
                }
                if (p.IdUsuario.HasValue)
                {
                    mensajeError = "El paciente seleccionado ya cuenta con un usuario de acceso vinculado.";
                    return false;
                }
                return true;
            }

            if (tipoPerfil == "Doctor")
            {
                var d = db.Doctores.FirstOrDefault(x => x.IdDoctor == idPerfil);
                if (d == null || !d.Estado)
                {
                    mensajeError = "El doctor seleccionado no existe o se encuentra inactivo.";
                    return false;
                }
                if (d.IdUsuario.HasValue)
                {
                    mensajeError = "El doctor seleccionado ya cuenta con un usuario de acceso vinculado.";
                    return false;
                }
                return true;
            }

            if (tipoPerfil == "Personal administrativo")
            {
                int count = db.Database.SqlQuery<int>(
                    "SELECT COUNT(1) FROM PersonalAdministrativo WHERE IdPersonalAdministrativo = @p0 AND IdUsuario IS NULL AND Estado = 1",
                    idPerfil).FirstOrDefault();

                if (count == 0)
                {
                    mensajeError = "El perfil de personal administrativo no está disponible, se encuentra inactivo o ya tiene una cuenta asignada.";
                    return false;
                }
                return true;
            }

            if (tipoPerfil == "Administrador")
            {
                int count = db.Database.SqlQuery<int>(
                    "SELECT COUNT(1) FROM Administradores WHERE IdAdministrador = @p0 AND IdUsuario IS NULL AND Estado = 1",
                    idPerfil).FirstOrDefault();

                if (count == 0)
                {
                    mensajeError = "El perfil de administrador no está disponible, se encuentra inactivo o ya tiene una cuenta asignada.";
                    return false;
                }
                return true;
            }

            mensajeError = "Tipo de perfil desconocido: " + tipoPerfil;
            return false;
        }

        private static bool VincularUsuarioAPerfil(SanarRuralDBEntities db, int idPerfil, string tipoPerfil, int idUsuario, out string mensajeError)
        {
            mensajeError = null;

            if (tipoPerfil == "Paciente")
            {
                var p = db.Pacientes.Find(idPerfil);
                if (p == null)
                {
                    mensajeError = "No se localizó el paciente para vincular el usuario.";
                    return false;
                }
                p.IdUsuario = idUsuario;
                db.SaveChanges();
                return true;
            }

            if (tipoPerfil == "Doctor")
            {
                var d = db.Doctores.Find(idPerfil);
                if (d == null)
                {
                    mensajeError = "No se localizó el doctor para vincular el usuario.";
                    return false;
                }
                d.IdUsuario = idUsuario;
                db.SaveChanges();
                return true;
            }

            if (tipoPerfil == "Personal administrativo")
            {
                int filas = db.Database.ExecuteSqlCommand(
                    "UPDATE PersonalAdministrativo SET IdUsuario = @p0 WHERE IdPersonalAdministrativo = @p1 AND IdUsuario IS NULL AND Estado = 1",
                    idUsuario, idPerfil);

                if (filas != 1)
                {
                    mensajeError = "No se pudo vincular el perfil de personal administrativo. Es posible que haya sido modificado concurrentemente.";
                    return false;
                }
                return true;
            }

            if (tipoPerfil == "Administrador")
            {
                int filas = db.Database.ExecuteSqlCommand(
                    "UPDATE Administradores SET IdUsuario = @p0 WHERE IdAdministrador = @p1 AND IdUsuario IS NULL AND Estado = 1",
                    idUsuario, idPerfil);

                if (filas != 1)
                {
                    mensajeError = "No se pudo vincular el perfil de administrador. Es posible que haya sido modificado concurrentemente.";
                    return false;
                }
                return true;
            }

            mensajeError = "Tipo de perfil desconocido.";
            return false;
        }

        private static bool VerificarConsistenciaVinculacion(SanarRuralDBEntities db, int idPerfil, string tipoPerfil, int idUsuario, out string mensajeError)
        {
            mensajeError = null;

            int cuentaPacientes = db.Pacientes.Count(p => p.IdUsuario == idUsuario);
            int cuentaDoctores = db.Doctores.Count(d => d.IdUsuario == idUsuario);

            int cuentaPersonal = 0;
            try
            {
                cuentaPersonal = db.Database.SqlQuery<int>(
                    "SELECT COUNT(1) FROM PersonalAdministrativo WHERE IdUsuario = @p0", idUsuario).FirstOrDefault();
            }
            catch { }

            int cuentaAdmin = 0;
            try
            {
                cuentaAdmin = db.Database.SqlQuery<int>(
                    "SELECT COUNT(1) FROM Administradores WHERE IdUsuario = @p0", idUsuario).FirstOrDefault();
            }
            catch { }

            int totalVinculaciones = cuentaPacientes + cuentaDoctores + cuentaPersonal + cuentaAdmin;
            if (totalVinculaciones != 1)
            {
                mensajeError = "Violación de integridad: la cuenta de usuario quedó asociada a " + totalVinculaciones + " perfiles simultáneamente.";
                return false;
            }

            return true;
        }

        public PerfilVinculadoDto ObtenerPerfilDeUsuario(int idUsuario)
        {
            using (var db = new SanarRuralDBEntities())
            {
                // 1. Paciente
                var paciente = db.Pacientes.FirstOrDefault(p => p.IdUsuario == idUsuario);
                if (paciente != null)
                {
                    string nom = string.Join(" ", new string[] { paciente.PrimerNombre, paciente.SegundoNombre, paciente.PrimerApellido, paciente.SegundoApellido }.Where(s => !string.IsNullOrWhiteSpace(s)));
                    return new PerfilVinculadoDto
                    {
                        TipoPerfil = "Paciente",
                        RolAsignado = "Paciente",
                        IdPerfil = paciente.IdPaciente,
                        NombreCompleto = nom,
                        Identificacion = paciente.Cedula ?? string.Empty,
                        Telefono = paciente.Telefono ?? string.Empty,
                        UbicacionCargo = paciente.Direccion ?? string.Empty
                    };
                }

                // 2. Doctor
                var doctor = db.Doctores.FirstOrDefault(d => d.IdUsuario == idUsuario);
                if (doctor != null)
                {
                    string nom = string.Join(" ", new string[] { doctor.PrimerNombre, doctor.SegundoNombre, doctor.PrimerApellido, doctor.SegundoApellido }.Where(s => !string.IsNullOrWhiteSpace(s)));
                    return new PerfilVinculadoDto
                    {
                        TipoPerfil = "Doctor",
                        RolAsignado = "Doctor",
                        IdPerfil = doctor.IdDoctor,
                        NombreCompleto = "Dr(a). " + nom,
                        Identificacion = doctor.Cedula ?? string.Empty,
                        Telefono = doctor.Telefono ?? string.Empty,
                        UbicacionCargo = doctor.NumeroLicencia ?? string.Empty
                    };
                }

                // 3. Personal Administrativo
                try
                {
                    var personal = db.Database.SqlQuery<PerfilVinculadoDto>(@"
                        SELECT
                            'Personal administrativo' AS TipoPerfil,
                            'Personal_administrativo' AS RolAsignado,
                            pa.IdPersonalAdministrativo AS IdPerfil,
                            LTRIM(RTRIM(CONCAT(pa.PrimerNombre, ' ', pa.SegundoNombre, ' ', pa.PrimerApellido, ' ', pa.SegundoApellido))) AS NombreCompleto,
                            ISNULL(pa.Cedula, '') AS Identificacion,
                            ISNULL(pa.Telefono, '') AS Telefono,
                            ISNULL(pa.Cargo, 'Personal administrativo') AS UbicacionCargo
                        FROM PersonalAdministrativo pa
                        WHERE pa.IdUsuario = @p0
                    ", idUsuario).FirstOrDefault();

                    if (personal != null) return personal;
                }
                catch { }

                // 4. Administrador
                try
                {
                    var admin = db.Database.SqlQuery<PerfilVinculadoDto>(@"
                        SELECT
                            'Administrador' AS TipoPerfil,
                            'Admin' AS RolAsignado,
                            a.IdAdministrador AS IdPerfil,
                            LTRIM(RTRIM(CONCAT(a.PrimerNombre, ' ', a.SegundoNombre, ' ', a.PrimerApellido, ' ', a.SegundoApellido))) AS NombreCompleto,
                            ISNULL(a.Cedula, '') AS Identificacion,
                            ISNULL(a.Telefono, '') AS Telefono,
                            'Administración' AS UbicacionCargo
                        FROM Administradores a
                        WHERE a.IdUsuario = @p0
                    ", idUsuario).FirstOrDefault();

                    if (admin != null) return admin;
                }
                catch { }

                return null;
            }
        }
    }

    public class PerfilSinUsuarioDto
    {
        public string TipoPerfil { get; set; }
        public string RolAsignar { get; set; }
        public int IdPerfil { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string UbicacionCargo { get; set; }
    }

    public class PerfilVinculadoDto
    {
        public string TipoPerfil { get; set; }
        public string RolAsignado { get; set; }
        public int IdPerfil { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string UbicacionCargo { get; set; }
    }
}
