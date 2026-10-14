using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Models
{
    // ============================================================
    // DTOs PARA PERSONAL ADMINISTRATIVO
    // ============================================================

    /// <summary>
    /// DTO para la visualización del personal administrativo en la cuadrícula principal.
    /// Desacopla la entidad Entity Framework de la capa visual y previene excepciones de serialización o contexto cerrado.
    /// </summary>
    public class PersonalAdministrativoItemDto
    {
        public int IdPersonalAdministrativo { get; set; }
        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Cargo { get; set; }
        public bool TieneCuenta { get; set; }
        public string NombreUsuario { get; set; }
        public bool Estado { get; set; }
        public string EstadoTexto => Estado ? "✓ Activo" : "✕ Inactivo";
    }

    /// <summary>
    /// DTO con la ficha integral de un miembro del personal administrativo, incluyendo datos de su cuenta de usuario vinculada.
    /// </summary>
    public class PersonalAdministrativoDetalleDto
    {
        public int IdPersonalAdministrativo { get; set; }
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
        public string Cargo { get; set; }
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
    /// Modelo de datos para la gestión del catálogo de Personal Administrativo.
    /// Cumple con el principio de separación estricta entre perfil de persona y credenciales de acceso.
    /// Solo los usuarios con rol 'Admin' pueden interactuar con este modelo.
    /// </summary>
    public class personalAdministrativoModels
    {
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ------------------------------------------------------------
        // LISTADO Y BÚSQUEDA DE PERSONAL ADMINISTRATIVO
        // ------------------------------------------------------------
        public List<PersonalAdministrativoItemDto> ListarPersonal(string busqueda = "", string filtroEstado = "Todos")
        {
            usuariosModels.ExigirRolAdmin(db, "consultar el listado de personal administrativo");

            var consulta = db.PersonalAdministrativo
                .AsNoTracking()
                .Include(p => p.Usuarios)
                .AsQueryable();

            if (filtroEstado == "Activos")
            {
                consulta = consulta.Where(p => p.Estado);
            }
            else if (filtroEstado == "Inactivos")
            {
                consulta = consulta.Where(p => !p.Estado);
            }

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string filtro = busqueda.Trim();
                consulta = consulta.Where(p =>
                    p.PrimerNombre.Contains(filtro) ||
                    (p.SegundoNombre != null && p.SegundoNombre.Contains(filtro)) ||
                    p.PrimerApellido.Contains(filtro) ||
                    (p.SegundoApellido != null && p.SegundoApellido.Contains(filtro)) ||
                    (p.Cedula != null && p.Cedula.Contains(filtro)) ||
                    (p.Telefono != null && p.Telefono.Contains(filtro)) ||
                    (p.Correo != null && p.Correo.Contains(filtro)) ||
                    (p.Cargo != null && p.Cargo.Contains(filtro)) ||
                    (p.Usuarios != null && p.Usuarios.NombreUsuario != null && p.Usuarios.NombreUsuario.Contains(filtro))
                );
            }

            var lista = consulta
                .OrderBy(p => p.PrimerApellido)
                .ThenBy(p => p.PrimerNombre)
                .ToList();

            return lista.Select(p => new PersonalAdministrativoItemDto
            {
                IdPersonalAdministrativo = p.IdPersonalAdministrativo,
                NombreCompleto = Tema.SanearTexto(string.Join(" ", new[]
                {
                    p.PrimerNombre,
                    p.SegundoNombre,
                    p.PrimerApellido,
                    p.SegundoApellido
                }.Where(parte => !string.IsNullOrWhiteSpace(parte)))),
                PrimerNombre = Tema.SanearTexto(p.PrimerNombre),
                SegundoNombre = Tema.SanearTexto(p.SegundoNombre),
                PrimerApellido = Tema.SanearTexto(p.PrimerApellido),
                SegundoApellido = Tema.SanearTexto(p.SegundoApellido),
                Cedula = p.Cedula,
                Telefono = p.Telefono,
                Correo = p.Correo,
                Cargo = Tema.SanearTexto(p.Cargo),
                TieneCuenta = p.IdUsuario.HasValue && p.IdUsuario.Value > 0,
                NombreUsuario = p.Usuarios != null ? p.Usuarios.NombreUsuario : null,
                Estado = p.Estado
            }).ToList();
        }

        // ------------------------------------------------------------
        // CONSULTA INDIVIDUAL POR IDENTIFICADOR
        // ------------------------------------------------------------
        public PersonalAdministrativoDetalleDto ObtenerDetalle(int idPersonal)
        {
            usuariosModels.ExigirRolAdmin(db, "consultar el detalle del personal administrativo");

            var personal = db.PersonalAdministrativo
                .AsNoTracking()
                .Include(p => p.Usuarios)
                .FirstOrDefault(p => p.IdPersonalAdministrativo == idPersonal);

            if (personal == null) return null;

            return new PersonalAdministrativoDetalleDto
            {
                IdPersonalAdministrativo = personal.IdPersonalAdministrativo,
                IdUsuario = personal.IdUsuario,
                PrimerNombre = Tema.SanearTexto(personal.PrimerNombre),
                SegundoNombre = Tema.SanearTexto(personal.SegundoNombre),
                PrimerApellido = Tema.SanearTexto(personal.PrimerApellido),
                SegundoApellido = Tema.SanearTexto(personal.SegundoApellido),
                Cedula = personal.Cedula,
                Telefono = personal.Telefono,
                Correo = personal.Correo,
                Cargo = Tema.SanearTexto(personal.Cargo),
                Estado = personal.Estado,
                NombreUsuario = personal.Usuarios != null ? personal.Usuarios.NombreUsuario : null,
                CorreoUsuario = null,
                EstadoUsuario = personal.Usuarios != null ? (bool?)personal.Usuarios.Estado : null
            };
        }

        public PersonalAdministrativo ObtenerPorId(int idPersonal)
        {
            usuariosModels.ExigirRolAdmin(db, "obtener datos de personal administrativo");
            return db.PersonalAdministrativo.FirstOrDefault(p => p.IdPersonalAdministrativo == idPersonal);
        }

        // ------------------------------------------------------------
        // CREACIÓN DE PERSONAL ADMINISTRATIVO
        // ------------------------------------------------------------
        public void Guardar(
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo,
            string cargo)
        {
            usuariosModels.ExigirRolAdmin(db, "registrar personal administrativo");

            ValidarCampos(primerNombre, primerApellido, cedula, correo, cargo, null);

            var entidad = new PersonalAdministrativo
            {
                PrimerNombre = primerNombre.Trim(),
                SegundoNombre = string.IsNullOrWhiteSpace(segundoNombre) ? null : segundoNombre.Trim(),
                PrimerApellido = primerApellido.Trim(),
                SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim(),
                Cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula.Trim(),
                Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim(),
                Correo = string.IsNullOrWhiteSpace(correo) ? null : correo.Trim(),
                Cargo = string.IsNullOrWhiteSpace(cargo) ? null : cargo.Trim(),
                IdUsuario = null, // La cuenta de acceso se vincula posteriormente desde Asignar Acceso a Perfil
                Estado = true
            };

            db.PersonalAdministrativo.Add(entidad);
            db.SaveChanges();
        }

        // ------------------------------------------------------------
        // ACTUALIZACIÓN DE PERSONAL ADMINISTRATIVO
        // ------------------------------------------------------------
        public void Actualizar(
            int idPersonal,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo,
            string cargo)
        {
            usuariosModels.ExigirRolAdmin(db, "actualizar datos de personal administrativo");

            var personal = db.PersonalAdministrativo.FirstOrDefault(p => p.IdPersonalAdministrativo == idPersonal);
            if (personal == null)
            {
                throw new InvalidOperationException("El registro de personal administrativo especificado no existe.");
            }

            ValidarCampos(primerNombre, primerApellido, cedula, correo, cargo, idPersonal);

            personal.PrimerNombre = primerNombre.Trim();
            personal.SegundoNombre = string.IsNullOrWhiteSpace(segundoNombre) ? null : segundoNombre.Trim();
            personal.PrimerApellido = primerApellido.Trim();
            personal.SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim();
            personal.Cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula.Trim();
            personal.Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim();
            personal.Correo = string.IsNullOrWhiteSpace(correo) ? null : correo.Trim();
            personal.Cargo = string.IsNullOrWhiteSpace(cargo) ? null : cargo.Trim();

            // Se preserva intacto IdUsuario y Estado
            db.SaveChanges();
        }

        // ------------------------------------------------------------
        // GESTIÓN DE ESTADO (BAJA LÓGICA Y REACTIVACIÓN)
        // ------------------------------------------------------------
        public void CambiarEstado(int idPersonal, bool nuevoEstado)
        {
            usuariosModels.ExigirRolAdmin(db, "modificar el estado de personal administrativo");

            var personal = db.PersonalAdministrativo
                .Include(p => p.Usuarios)
                .FirstOrDefault(p => p.IdPersonalAdministrativo == idPersonal);

            if (personal == null)
            {
                throw new InvalidOperationException("El registro de personal administrativo especificado no existe.");
            }

            if (personal.Estado == nuevoEstado)
            {
                return;
            }

            if (!nuevoEstado)
            {
                // Desactivar el perfil
                personal.Estado = false;

                // Si tiene usuario vinculado, se suspende la cuenta de usuario para bloquear el acceso
                if (personal.Usuarios != null)
                {
                    personal.Usuarios.Estado = false;
                }
            }
            else
            {
                // Reactivación del perfil:
                // No reactiva automáticamente la cuenta de usuario vinculada por seguridad
                personal.Estado = true;
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

            return db.PersonalAdministrativo.Any(p =>
                p.Cedula == normalizada &&
                (!idExcluir.HasValue || p.IdPersonalAdministrativo != idExcluir.Value));
        }

        private void ValidarCampos(string primerNombre, string primerApellido, string cedula, string correo, string cargo, int? idExcluir)
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
                    throw new InvalidOperationException("Ya existe otro personal administrativo registrado con el número de cédula proporcionado.");
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

            if (!string.IsNullOrWhiteSpace(cargo) && cargo.Trim().Length > 100)
            {
                throw new ArgumentException("El cargo no puede exceder 100 caracteres.");
            }
        }
    }
}
