using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Models
{
    // ============================================================
    // DTOs PARA ADMINISTRADORES
    // ============================================================

    /// <summary>
    /// DTO para la visualización de administradores en la tabla principal.
    /// Desacopla la entidad Entity Framework de la capa visual y previene excepciones de serialización o contexto cerrado.
    /// </summary>
    public class AdministradorItemDto
    {
        public int IdAdministrador { get; set; }
        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool TieneCuenta { get; set; }
        public string NombreUsuario { get; set; }
        public bool Estado { get; set; }
        public string EstadoTexto => Estado ? "✓ Activo" : "✕ Inactivo";
    }

    /// <summary>
    /// DTO con la ficha integral de un administrador, incluyendo datos de su cuenta de usuario vinculada.
    /// </summary>
    public class AdministradorDetalleDto
    {
        public int IdAdministrador { get; set; }
        public int? IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCompleto => string.Join(" ", new[]
        {
            PrimerNombre,
            SegundoNombre,
            PrimerApellido,
            SegundoApellido
        }.Where(p => !string.IsNullOrWhiteSpace(p)));

        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public string EstadoTexto => Estado ? "✓ Activo" : "✕ Inactivo";

        public bool TieneCuenta => IdUsuario.HasValue && IdUsuario.Value > 0;
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public bool? EstadoUsuario { get; set; }
        public string EstadoUsuarioTexto
        {
            get
            {
                if (!TieneCuenta) return "Sin cuenta asignada";
                return EstadoUsuario == true ? "Activa" : "Inactiva / Bloqueada";
            }
        }
    }

    /// <summary>
    /// Modelo de datos para la gestión del catálogo de Administradores.
    /// Cumple con el principio de separación estricta entre perfil de persona y credenciales de acceso.
    /// Solo los usuarios con rol 'Admin' pueden interactuar con este modelo.
    /// </summary>
    public class administradoresModels
    {
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ------------------------------------------------------------
        // LISTADO Y BÚSQUEDA DE ADMINISTRADORES
        // ------------------------------------------------------------
        public List<AdministradorItemDto> ListarAdministradores(string busqueda = "", string filtroEstado = "Todos")
        {
            usuariosModels.ExigirRolAdmin(db, "consultar el listado de administradores");

            var consulta = db.Administradores
                .AsNoTracking()
                .Include(a => a.Usuarios)
                .AsQueryable();

            if (filtroEstado == "Activos")
            {
                consulta = consulta.Where(a => a.Estado);
            }
            else if (filtroEstado == "Inactivos")
            {
                consulta = consulta.Where(a => !a.Estado);
            }

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string filtro = busqueda.Trim();
                consulta = consulta.Where(a =>
                    a.PrimerNombre.Contains(filtro) ||
                    (a.SegundoNombre != null && a.SegundoNombre.Contains(filtro)) ||
                    a.PrimerApellido.Contains(filtro) ||
                    (a.SegundoApellido != null && a.SegundoApellido.Contains(filtro)) ||
                    (a.Cedula != null && a.Cedula.Contains(filtro)) ||
                    (a.Telefono != null && a.Telefono.Contains(filtro)) ||
                    (a.Correo != null && a.Correo.Contains(filtro)) ||
                    (a.Usuarios != null && a.Usuarios.NombreUsuario != null && a.Usuarios.NombreUsuario.Contains(filtro))
                );
            }

            var lista = consulta
                .OrderBy(a => a.PrimerApellido)
                .ThenBy(a => a.PrimerNombre)
                .ToList();

            return lista.Select(a => new AdministradorItemDto
            {
                IdAdministrador = a.IdAdministrador,
                NombreCompleto = Tema.SanearTexto(string.Join(" ", new[]
                {
                    a.PrimerNombre,
                    a.SegundoNombre,
                    a.PrimerApellido,
                    a.SegundoApellido
                }.Where(p => !string.IsNullOrWhiteSpace(p)))),
                PrimerNombre = Tema.SanearTexto(a.PrimerNombre),
                SegundoNombre = Tema.SanearTexto(a.SegundoNombre),
                PrimerApellido = Tema.SanearTexto(a.PrimerApellido),
                SegundoApellido = Tema.SanearTexto(a.SegundoApellido),
                Cedula = a.Cedula,
                Telefono = a.Telefono,
                Correo = a.Correo,
                TieneCuenta = a.IdUsuario.HasValue && a.IdUsuario.Value > 0,
                NombreUsuario = a.Usuarios != null ? a.Usuarios.NombreUsuario : null,
                Estado = a.Estado
            }).ToList();
        }

        // ------------------------------------------------------------
        // CONSULTA INDIVIDUAL POR IDENTIFICADOR
        // ------------------------------------------------------------
        public AdministradorDetalleDto ObtenerDetalle(int idAdministrador)
        {
            usuariosModels.ExigirRolAdmin(db, "consultar el detalle de un administrador");

            var admin = db.Administradores
                .AsNoTracking()
                .Include(a => a.Usuarios)
                .FirstOrDefault(a => a.IdAdministrador == idAdministrador);

            if (admin == null) return null;

            return new AdministradorDetalleDto
            {
                IdAdministrador = admin.IdAdministrador,
                IdUsuario = admin.IdUsuario,
                PrimerNombre = Tema.SanearTexto(admin.PrimerNombre),
                SegundoNombre = Tema.SanearTexto(admin.SegundoNombre),
                PrimerApellido = Tema.SanearTexto(admin.PrimerApellido),
                SegundoApellido = Tema.SanearTexto(admin.SegundoApellido),
                Cedula = admin.Cedula,
                Telefono = admin.Telefono,
                Correo = admin.Correo,
                Estado = admin.Estado,
                NombreUsuario = admin.Usuarios != null ? admin.Usuarios.NombreUsuario : null,
                CorreoUsuario = null,
                EstadoUsuario = admin.Usuarios != null ? (bool?)admin.Usuarios.Estado : null
            };
        }

        public Administradores ObtenerPorId(int idAdministrador)
        {
            usuariosModels.ExigirRolAdmin(db, "obtener datos de un administrador");
            return db.Administradores.FirstOrDefault(a => a.IdAdministrador == idAdministrador);
        }

        // ------------------------------------------------------------
        // CREACIÓN DE ADMINISTRADOR
        // ------------------------------------------------------------
        public void Guardar(
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo)
        {
            usuariosModels.ExigirRolAdmin(db, "registrar un nuevo administrador");

            ValidarCampos(primerNombre, primerApellido, cedula, correo, null);

            var entidad = new Administradores
            {
                PrimerNombre = primerNombre.Trim(),
                SegundoNombre = string.IsNullOrWhiteSpace(segundoNombre) ? null : segundoNombre.Trim(),
                PrimerApellido = primerApellido.Trim(),
                SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim(),
                Cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula.Trim(),
                Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim(),
                Correo = string.IsNullOrWhiteSpace(correo) ? null : correo.Trim(),
                IdUsuario = null, // La cuenta de acceso se vincula posteriormente desde Asignar Acceso a Perfil
                Estado = true
            };

            db.Administradores.Add(entidad);
            db.SaveChanges();
        }

        // ------------------------------------------------------------
        // ACTUALIZACIÓN DE ADMINISTRADOR
        // ------------------------------------------------------------
        public void Actualizar(
            int idAdministrador,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo)
        {
            usuariosModels.ExigirRolAdmin(db, "actualizar datos de un administrador");

            var admin = db.Administradores.FirstOrDefault(a => a.IdAdministrador == idAdministrador);
            if (admin == null)
            {
                throw new InvalidOperationException("El administrador especificado no existe.");
            }

            ValidarCampos(primerNombre, primerApellido, cedula, correo, idAdministrador);

            admin.PrimerNombre = primerNombre.Trim();
            admin.SegundoNombre = string.IsNullOrWhiteSpace(segundoNombre) ? null : segundoNombre.Trim();
            admin.PrimerApellido = primerApellido.Trim();
            admin.SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim();
            admin.Cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula.Trim();
            admin.Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim();
            admin.Correo = string.IsNullOrWhiteSpace(correo) ? null : correo.Trim();

            // Se preserva intacto IdUsuario y Estado
            db.SaveChanges();
        }

        // ------------------------------------------------------------
        // GESTIÓN DE ESTADO (BAJA LÓGICA Y REACTIVACIÓN)
        // ------------------------------------------------------------
        public void CambiarEstado(int idAdministrador, bool nuevoEstado)
        {
            usuariosModels.ExigirRolAdmin(db, "modificar el estado de un administrador");

            var admin = db.Administradores
                .Include(a => a.Usuarios)
                .FirstOrDefault(a => a.IdAdministrador == idAdministrador);

            if (admin == null)
            {
                throw new InvalidOperationException("El administrador especificado no existe.");
            }

            if (admin.Estado == nuevoEstado)
            {
                return; // Ya se encuentra en el estado deseado
            }

            if (!nuevoEstado)
            {
                // Regla crítica 1: Salvaguarda contra el último administrador activo
                int adminsActivos = db.Administradores.Count(a => a.Estado);
                if (adminsActivos <= 1)
                {
                    throw new InvalidOperationException("No se puede dar de baja al único administrador activo del sistema.");
                }

                // Regla crítica 2: Salvaguarda de sesión activa (no puede darse de baja a sí mismo)
                if (admin.IdUsuario.HasValue &&
                    usuariosModels.IdUsuarioActual.HasValue &&
                    admin.IdUsuario.Value == usuariosModels.IdUsuarioActual.Value)
                {
                    throw new InvalidOperationException("No puede dar de baja su propio perfil de administrador con la sesión activa actual.");
                }

                // Desactivar el perfil
                admin.Estado = false;

                // Si tiene usuario vinculado, se suspende la cuenta de usuario para bloquear el acceso
                if (admin.Usuarios != null)
                {
                    admin.Usuarios.Estado = false;
                }
            }
            else
            {
                // Reactivación del perfil:
                // No habilita automáticamente la cuenta de usuario asociada por seguridad
                admin.Estado = true;
            }

            db.SaveChanges();
        }

        // ------------------------------------------------------------
        // VALIDACIONES DE NEGOCIO Y UNICIDAD
        // ------------------------------------------------------------
        public bool ExisteCedula(string cedula, int? idExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;
            string normalizada = cedula.Trim();

            return db.Administradores.Any(a =>
                a.Cedula == normalizada &&
                (!idExcluir.HasValue || a.IdAdministrador != idExcluir.Value));
        }

        private void ValidarCampos(string primerNombre, string primerApellido, string cedula, string correo, int? idExcluir)
        {
            if (string.IsNullOrWhiteSpace(primerNombre))
            {
                throw new ArgumentException("El primer nombre es obligatorio.");
            }
            if (primerNombre.Trim().Length > 50)
            {
                throw new ArgumentException("El primer nombre no puede exceder 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(primerApellido))
            {
                throw new ArgumentException("El primer apellido es obligatorio.");
            }
            if (primerApellido.Trim().Length > 50)
            {
                throw new ArgumentException("El primer apellido no puede exceder 50 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(cedula))
            {
                string cedulaTrim = cedula.Trim();
                if (cedulaTrim.Length > 20)
                {
                    throw new ArgumentException("La cédula no puede exceder 20 caracteres.");
                }

                if (ExisteCedula(cedulaTrim, idExcluir))
                {
                    throw new InvalidOperationException("Ya existe otro administrador registrado con el número de cédula proporcionado.");
                }
            }

            if (!string.IsNullOrWhiteSpace(correo))
            {
                string correoTrim = correo.Trim();
                if (correoTrim.Length > 150)
                {
                    throw new ArgumentException("El correo electrónico no puede exceder 150 caracteres.");
                }

                if (!Regex.IsMatch(correoTrim, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("El formato del correo electrónico no es válido.");
                }
            }
        }
    }
}
