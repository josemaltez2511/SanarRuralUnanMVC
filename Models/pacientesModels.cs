using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SanarRuralUnan.Models
{
    // ============================================================
    // DTOs DEL MÓDULO PACIENTES
    // ============================================================

    // DTO para representar cada fila en el listado principal de pacientes.
    // Transporta los datos esenciales para la visualización en la tabla (identificación, nombres concatenados,
    // cédula, teléfono, desglose de comunidad, municipio, departamento y estado legible).
    // Evita transferir la entidad completa de Entity Framework con grafos pesados de navegación a la vista,
    // previniendo excepciones por Lazy Loading fuera de contexto y manteniendo la cuadrícula ágil y desacoplada.
    public class PacienteItemDto
    {
        public int IdPaciente { get; set; }
        public string NombreCompleto { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string NumeroINSS { get; set; }
        public string Telefono { get; set; }
        public int IdComunidad { get; set; }
        public string Comunidad { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public bool Estado { get; set; }
        public string EstadoTexto => Estado ? "✓ Activo" : "✕ Inactivo";
    }

    // DTO que representa un contacto de emergencia asociado al paciente.
    // Transporta los datos de parentesco, nombres, teléfono y cédula de una persona de referencia en caso de urgencia.
    // Se utiliza para desacoplar la entidad ContactosEmergencia de la interfaz de usuario, permitiendo
    // agregar, editar o remover múltiples contactos en memoria antes de persistirlos de forma atómica en la base de datos.
    public class ContactoEmergenciaDto
    {
        public int? IdContactoEmergencia { get; set; }
        public int? IdPaciente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Parentesco { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }

        public string NombreCompleto => string.Join(" ", new[]
        {
            PrimerNombre,
            SegundoNombre,
            PrimerApellido,
            SegundoApellido
        }.Where(parte => !string.IsNullOrWhiteSpace(parte)));
    }

    // DTO para la ficha integral y detallada de un paciente.
    // Contiene toda la información demográfica, ubicación geográfica desglosada, antecedentes de salud,
    // alergias, tipo de sangre y su colección de contactos de emergencia (0..N).
    // Se utiliza para alimentar la pantalla de consulta de expediente (ficha clínica demográfica) o cargar
    // el formulario de edición con un objeto desacoplado de Entity Framework que no comprometa el contexto.
    public class PacienteDetalleDto
    {
        public int IdPaciente { get; set; }
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
        }.Where(parte => !string.IsNullOrWhiteSpace(parte)));

        public string Cedula { get; set; }
        public string NumeroINSS { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                var edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return Math.Max(0, edad);
            }
        }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public int IdComunidad { get; set; }
        public string Comunidad { get; set; }
        public int IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public string TipoSangre { get; set; }
        public string Alergias { get; set; }
        public string Antecedentes { get; set; }
        public bool Estado { get; set; }
        public string EstadoTexto => Estado ? "✓ Activo" : "✕ Inactivo";
        public List<ContactoEmergenciaDto> ContactosEmergencia { get; set; } = new List<ContactoEmergenciaDto>();
    }

    // DTO genérico para alimentar los selectores de ubicación (Departamentos, Municipios y Comunidades).
    // Proporciona únicamente el identificador numérico y el nombre textual para enlazar con controles ComboBox.
    // Evita transferir entidades pesadas de base de datos a la capa visual cuando únicamente se necesita un par clave-valor.
    public class UbicacionItemDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    // ============================================================
    // MODELO DE PERSISTENCIA Y REGLAS DE NEGOCIO DE PACIENTES
    // ============================================================
    public class pacientesModels
    {
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ------------------------------------------------------------
        // VALIDACIÓN DE SESIÓN Y ROLES
        // ------------------------------------------------------------
        private Roles ValidarSesion(string operacion)
        {
            if (!usuariosModels.IdRolActual.HasValue)
            {
                throw new InvalidOperationException($"No se detectó una sesión activa con un rol válido para {operacion}.");
            }

            var rolActual = db.Roles.FirstOrDefault(r => r.IdRol == usuariosModels.IdRolActual.Value);
            if (rolActual == null)
            {
                throw new InvalidOperationException($"El rol de la sesión actual no es válido para {operacion}.");
            }

            if (rolActual.Nombre == "Paciente")
            {
                throw new InvalidOperationException($"Un usuario con rol paciente no tiene autorización para {operacion}.");
            }

            return rolActual;
        }

        public bool EsAdministrativo()
        {
            if (!usuariosModels.IdRolActual.HasValue) return false;
            var rol = db.Roles.FirstOrDefault(r => r.IdRol == usuariosModels.IdRolActual.Value);
            return rol != null && rol.Nombre == "Administrativo";
        }

        // ------------------------------------------------------------
        // CONSULTAS DE UBICACIÓN GEOGRÁFICA
        // ------------------------------------------------------------
        public List<UbicacionItemDto> listarDepartamentos()
        {
            return db.Departamentos
                .OrderBy(d => d.Nombre)
                .Select(d => new UbicacionItemDto
                {
                    Id = d.IdDepartamento,
                    Nombre = d.Nombre
                })
                .ToList();
        }

        public List<UbicacionItemDto> listarMunicipios(int idDepartamento)
        {
            return db.Municipios
                .Where(m => m.IdDepartamento == idDepartamento)
                .OrderBy(m => m.Nombre)
                .Select(m => new UbicacionItemDto
                {
                    Id = m.IdMunicipio,
                    Nombre = m.Nombre
                })
                .ToList();
        }

        public List<UbicacionItemDto> listarComunidades(int idMunicipio)
        {
            return db.Comunidades
                .Where(c => c.IdMunicipio == idMunicipio)
                .OrderBy(c => c.Nombre)
                .Select(c => new UbicacionItemDto
                {
                    Id = c.IdComunidad,
                    Nombre = c.Nombre
                })
                .ToList();
        }

        // ------------------------------------------------------------
        // LISTADO GENERAL DE PACIENTES
        // ------------------------------------------------------------
        public List<PacienteItemDto> listarPacientes(string busqueda = "", string estadoFiltro = "Activos")
        {
            var rol = ValidarSesion("consultar el listado de pacientes");

            var consulta = db.Pacientes
                .Include(p => p.Comunidades.Municipios.Departamentos)
                .AsQueryable();

            // Filtrado por estado: Doctor solo puede consultar pacientes activos
            if (rol.Nombre == "Doctor" || estadoFiltro == "Activos")
            {
                consulta = consulta.Where(p => p.Estado);
            }
            else if (estadoFiltro == "Inactivos")
            {
                consulta = consulta.Where(p => !p.Estado);
            }
            // Si estadoFiltro es "Todos" y rol es Administrativo, no se filtra por Estado

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string filtro = busqueda.Trim();
                consulta = consulta.Where(p =>
                    p.PrimerNombre.Contains(filtro) ||
                    (p.SegundoNombre != null && p.SegundoNombre.Contains(filtro)) ||
                    p.PrimerApellido.Contains(filtro) ||
                    (p.SegundoApellido != null && p.SegundoApellido.Contains(filtro)) ||
                    (p.Cedula != null && p.Cedula.Contains(filtro)) ||
                    (p.NumeroINSS != null && p.NumeroINSS.Contains(filtro)) ||
                    (p.Telefono != null && p.Telefono.Contains(filtro)) ||
                    p.Comunidades.Nombre.Contains(filtro) ||
                    p.Comunidades.Municipios.Nombre.Contains(filtro) ||
                    p.Comunidades.Municipios.Departamentos.Nombre.Contains(filtro));
            }

            return consulta
                .OrderBy(p => p.PrimerApellido)
                .ThenBy(p => p.PrimerNombre)
                .ToList()
                .Select(p =>
                {
                    string nombreCompleto = string.Join(" ", new[]
                    {
                        p.PrimerApellido,
                        p.SegundoApellido,
                        p.PrimerNombre,
                        p.SegundoNombre
                    }.Where(parte => !string.IsNullOrWhiteSpace(parte)));

                    return new PacienteItemDto
                    {
                        IdPaciente = p.IdPaciente,
                        NombreCompleto = nombreCompleto,
                        PrimerNombre = p.PrimerNombre,
                        SegundoNombre = p.SegundoNombre,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Cedula = string.IsNullOrWhiteSpace(p.Cedula) ? "Sin cédula" : p.Cedula,
                        NumeroINSS = string.IsNullOrWhiteSpace(p.NumeroINSS) ? "Sin INSS" : p.NumeroINSS,
                        Telefono = string.IsNullOrWhiteSpace(p.Telefono) ? "Sin teléfono" : p.Telefono,
                        IdComunidad = p.IdComunidad,
                        Comunidad = p.Comunidades != null ? p.Comunidades.Nombre : "Sin comunidad",
                        Municipio = (p.Comunidades != null && p.Comunidades.Municipios != null) ? p.Comunidades.Municipios.Nombre : "Sin municipio",
                        Departamento = (p.Comunidades != null && p.Comunidades.Municipios != null && p.Comunidades.Municipios.Departamentos != null) ? p.Comunidades.Municipios.Departamentos.Nombre : "Sin departamento",
                        Estado = p.Estado
                    };
                })
                .ToList();
        }

        // ------------------------------------------------------------
        // CONSULTA DE EXPEDIENTE / DETALLE DEL PACIENTE
        // ------------------------------------------------------------
        public PacienteDetalleDto obtenerPacienteDetalle(int idPaciente)
        {
            var rol = ValidarSesion("consultar la ficha del paciente");

            var p = db.Pacientes
                .Include(pac => pac.Comunidades.Municipios.Departamentos)
                .Include(pac => pac.ContactosEmergencia)
                .FirstOrDefault(pac => pac.IdPaciente == idPaciente);

            if (p == null)
            {
                return null;
            }

            // Si es doctor y el paciente está inactivo, no permitir acceso
            if (rol.Nombre == "Doctor" && !p.Estado)
            {
                throw new InvalidOperationException("No tiene permisos para consultar el expediente de un paciente inactivo.");
            }

            var detalle = new PacienteDetalleDto
            {
                IdPaciente = p.IdPaciente,
                IdUsuario = p.IdUsuario,
                PrimerNombre = p.PrimerNombre,
                SegundoNombre = p.SegundoNombre ?? string.Empty,
                PrimerApellido = p.PrimerApellido,
                SegundoApellido = p.SegundoApellido ?? string.Empty,
                Cedula = p.Cedula ?? string.Empty,
                NumeroINSS = p.NumeroINSS ?? string.Empty,
                FechaNacimiento = p.FechaNacimiento,
                Genero = p.Genero ?? string.Empty,
                Telefono = p.Telefono ?? string.Empty,
                IdComunidad = p.IdComunidad,
                Comunidad = p.Comunidades != null ? p.Comunidades.Nombre : "Sin comunidad",
                IdMunicipio = p.Comunidades != null ? p.Comunidades.IdMunicipio : 0,
                Municipio = (p.Comunidades != null && p.Comunidades.Municipios != null) ? p.Comunidades.Municipios.Nombre : "Sin municipio",
                IdDepartamento = (p.Comunidades != null && p.Comunidades.Municipios != null) ? p.Comunidades.Municipios.IdDepartamento : 0,
                Departamento = (p.Comunidades != null && p.Comunidades.Municipios != null && p.Comunidades.Municipios.Departamentos != null) ? p.Comunidades.Municipios.Departamentos.Nombre : "Sin departamento",
                Direccion = p.Direccion ?? string.Empty,
                TipoSangre = p.TipoSangre ?? string.Empty,
                Alergias = p.Alergias ?? string.Empty,
                Antecedentes = p.Antecedentes ?? string.Empty,
                Estado = p.Estado,
                ContactosEmergencia = p.ContactosEmergencia
                    .OrderBy(ce => ce.IdContactoEmergencia)
                    .Select(ce => new ContactoEmergenciaDto
                    {
                        IdContactoEmergencia = ce.IdContactoEmergencia,
                        IdPaciente = ce.IdPaciente,
                        PrimerNombre = ce.PrimerNombre,
                        SegundoNombre = ce.SegundoNombre ?? string.Empty,
                        PrimerApellido = ce.PrimerApellido,
                        SegundoApellido = ce.SegundoApellido ?? string.Empty,
                        Parentesco = ce.Parentesco,
                        Telefono = ce.Telefono,
                        Cedula = ce.Cedula ?? string.Empty
                    })
                    .ToList()
            };

            return detalle;
        }

        public PacienteDetalleDto buscarPacientePorUsuario(int idUsuario)
        {
            var paciente = db.Pacientes.FirstOrDefault(p => p.IdUsuario == idUsuario && p.Estado);
            return paciente != null ? obtenerPacienteDetalle(paciente.IdPaciente) : null;
        }

        // ------------------------------------------------------------
        // COMPROBACIONES DE UNICIDAD Y VALIDACIONES
        // ------------------------------------------------------------
        public bool existeCedula(string cedula, int? idPacienteExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;
            string texto = cedula.Trim();
            return db.Pacientes.Any(p => p.Estado && p.Cedula == texto && (!idPacienteExcluir.HasValue || p.IdPaciente != idPacienteExcluir.Value));
        }

        public bool existeNumeroINSS(string numeroINSS, int? idPacienteExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(numeroINSS)) return false;
            string texto = numeroINSS.Trim();
            return db.Pacientes.Any(p => p.Estado && p.NumeroINSS == texto && (!idPacienteExcluir.HasValue || p.IdPaciente != idPacienteExcluir.Value));
        }

        private void ValidarDatosPaciente(
            string primerNombre,
            string primerApellido,
            DateTime fechaNacimiento,
            int idComunidad,
            string cedula,
            string numeroINSS,
            string telefono,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes,
            int? idPacienteExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(primerNombre))
            {
                throw new InvalidOperationException("El primer nombre del paciente es obligatorio.");
            }
            if (primerNombre.Trim().Length > 50)
            {
                throw new InvalidOperationException("El primer nombre no puede exceder los 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(primerApellido))
            {
                throw new InvalidOperationException("El primer apellido del paciente es obligatorio.");
            }
            if (primerApellido.Trim().Length > 50)
            {
                throw new InvalidOperationException("El primer apellido no puede exceder los 50 caracteres.");
            }

            if (fechaNacimiento.Date > DateTime.Today)
            {
                throw new InvalidOperationException("La fecha de nacimiento no puede ser una fecha futura.");
            }

            if (!db.Comunidades.Any(c => c.IdComunidad == idComunidad))
            {
                throw new InvalidOperationException("La comunidad seleccionada no es válida o no existe en la base de datos.");
            }

            if (!string.IsNullOrWhiteSpace(cedula))
            {
                string cedulaTrim = cedula.Trim();
                if (cedulaTrim.Length > 20)
                {
                    throw new InvalidOperationException("La cédula no puede exceder los 20 caracteres.");
                }
                if (existeCedula(cedulaTrim, idPacienteExcluir))
                {
                    throw new InvalidOperationException($"Ya existe un paciente activo registrado con la cédula '{cedulaTrim}'.");
                }
            }

            if (!string.IsNullOrWhiteSpace(numeroINSS))
            {
                string inssTrim = numeroINSS.Trim();
                if (inssTrim.Length > 30)
                {
                    throw new InvalidOperationException("El número INSS no puede exceder los 30 caracteres.");
                }
                if (existeNumeroINSS(inssTrim, idPacienteExcluir))
                {
                    throw new InvalidOperationException($"Ya existe un paciente activo registrado con el número INSS '{inssTrim}'.");
                }
            }

            if (!string.IsNullOrWhiteSpace(telefono) && telefono.Trim().Length > 30)
            {
                throw new InvalidOperationException("El teléfono no puede exceder los 30 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(direccion) && direccion.Trim().Length > 300)
            {
                throw new InvalidOperationException("La dirección no puede exceder los 300 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(tipoSangre))
            {
                string ts = tipoSangre.Trim();
                string[] tiposValidos = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
                if (!tiposValidos.Contains(ts))
                {
                    throw new InvalidOperationException($"El tipo de sangre '{ts}' no es válido. Los tipos admitidos son: A+, A-, B+, B-, AB+, AB-, O+, O-.");
                }
            }

            if (!string.IsNullOrWhiteSpace(alergias) && alergias.Trim().Length > 1000)
            {
                throw new InvalidOperationException("El campo de alergias no puede exceder los 1000 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(antecedentes) && antecedentes.Trim().Length > 2000)
            {
                throw new InvalidOperationException("El campo de antecedentes no puede exceder los 2000 caracteres.");
            }
        }

        private void ValidarContactoEmergencia(ContactoEmergenciaDto contacto)
        {
            if (contacto == null) return;

            if (string.IsNullOrWhiteSpace(contacto.PrimerNombre))
            {
                throw new InvalidOperationException("El primer nombre del contacto de emergencia es obligatorio.");
            }
            if (contacto.PrimerNombre.Trim().Length > 50)
            {
                throw new InvalidOperationException("El primer nombre del contacto no puede exceder los 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(contacto.PrimerApellido))
            {
                throw new InvalidOperationException("El primer apellido del contacto de emergencia es obligatorio.");
            }
            if (contacto.PrimerApellido.Trim().Length > 50)
            {
                throw new InvalidOperationException("El primer apellido del contacto no puede exceder los 50 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(contacto.Parentesco))
            {
                throw new InvalidOperationException("El parentesco del contacto de emergencia es obligatorio.");
            }
            if (contacto.Parentesco.Trim().Length > 80)
            {
                throw new InvalidOperationException("El parentesco del contacto no puede exceder los 80 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(contacto.Telefono))
            {
                throw new InvalidOperationException("El teléfono del contacto de emergencia es obligatorio.");
            }
            if (contacto.Telefono.Trim().Length > 30)
            {
                throw new InvalidOperationException("El teléfono del contacto no puede exceder los 30 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(contacto.SegundoNombre) && contacto.SegundoNombre.Trim().Length > 50)
            {
                throw new InvalidOperationException("El segundo nombre del contacto no puede exceder los 50 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(contacto.SegundoApellido) && contacto.SegundoApellido.Trim().Length > 50)
            {
                throw new InvalidOperationException("El segundo apellido del contacto no puede exceder los 50 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(contacto.Cedula) && contacto.Cedula.Trim().Length > 20)
            {
                throw new InvalidOperationException("La cédula del contacto no puede exceder los 20 caracteres.");
            }
        }

        // ------------------------------------------------------------
        // CREACIÓN ATÓMICA DE PACIENTE CON CONTACTOS (ACID)
        // ------------------------------------------------------------
        public int guardarPaciente(
            int? idUsuario,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroINSS,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int idComunidad,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes,
            List<ContactoEmergenciaDto> contactos = null)
        {
            ValidarSesion("registrar pacientes");

            ValidarDatosPaciente(
                primerNombre, primerApellido, fechaNacimiento, idComunidad,
                cedula, numeroINSS, telefono, direccion, tipoSangre, alergias, antecedentes);

            if (contactos != null)
            {
                foreach (var c in contactos)
                {
                    ValidarContactoEmergencia(c);
                }
            }

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var paciente = new Pacientes
                    {
                        IdUsuario = idUsuario,
                        PrimerNombre = primerNombre.Trim(),
                        SegundoNombre = string.IsNullOrWhiteSpace(segundoNombre) ? null : segundoNombre.Trim(),
                        PrimerApellido = primerApellido.Trim(),
                        SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim(),
                        Cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula.Trim(),
                        NumeroINSS = string.IsNullOrWhiteSpace(numeroINSS) ? null : numeroINSS.Trim(),
                        FechaNacimiento = fechaNacimiento,
                        Genero = string.IsNullOrWhiteSpace(genero) ? null : genero.Trim(),
                        Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim(),
                        IdComunidad = idComunidad,
                        Direccion = string.IsNullOrWhiteSpace(direccion) ? null : direccion.Trim(),
                        TipoSangre = string.IsNullOrWhiteSpace(tipoSangre) ? null : tipoSangre.Trim(),
                        Alergias = string.IsNullOrWhiteSpace(alergias) ? null : alergias.Trim(),
                        Antecedentes = string.IsNullOrWhiteSpace(antecedentes) ? null : antecedentes.Trim(),
                        Estado = true
                    };

                    db.Pacientes.Add(paciente);
                    db.SaveChanges(); // Genera IdPaciente

                    if (contactos != null && contactos.Count > 0)
                    {
                        foreach (var c in contactos)
                        {
                            var nuevoContacto = new ContactosEmergencia
                            {
                                IdPaciente = paciente.IdPaciente,
                                PrimerNombre = c.PrimerNombre.Trim(),
                                SegundoNombre = string.IsNullOrWhiteSpace(c.SegundoNombre) ? null : c.SegundoNombre.Trim(),
                                PrimerApellido = c.PrimerApellido.Trim(),
                                SegundoApellido = string.IsNullOrWhiteSpace(c.SegundoApellido) ? null : c.SegundoApellido.Trim(),
                                Parentesco = c.Parentesco.Trim(),
                                Telefono = c.Telefono.Trim(),
                                Cedula = string.IsNullOrWhiteSpace(c.Cedula) ? null : c.Cedula.Trim()
                            };
                            db.ContactosEmergencia.Add(nuevoContacto);
                        }
                        db.SaveChanges();
                    }

                    tx.Commit();
                    return paciente.IdPaciente;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // Sobrecarga de compatibilidad
        public void guardarPaciente(
            int? idUsuario,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroINSS,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int idComunidad,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes,
            string contactoPrimerNombre,
            string contactoSegundoNombre,
            string contactoPrimerApellido,
            string contactoSegundoApellido,
            string contactoParentesco,
            string contactoTelefono,
            string contactoCedula)
        {
            var contactos = new List<ContactoEmergenciaDto>();
            if (!string.IsNullOrWhiteSpace(contactoPrimerNombre))
            {
                contactos.Add(new ContactoEmergenciaDto
                {
                    PrimerNombre = contactoPrimerNombre,
                    SegundoNombre = contactoSegundoNombre,
                    PrimerApellido = contactoPrimerApellido,
                    SegundoApellido = contactoSegundoApellido,
                    Parentesco = contactoParentesco,
                    Telefono = contactoTelefono,
                    Cedula = contactoCedula
                });
            }

            guardarPaciente(
                idUsuario, primerNombre, segundoNombre, primerApellido, segundoApellido,
                cedula, numeroINSS, fechaNacimiento, genero, telefono, idComunidad,
                direccion, tipoSangre, alergias, antecedentes, contactos);
        }

        // ------------------------------------------------------------
        // ACTUALIZACIÓN ATÓMICA DE PACIENTE Y CONTACTOS (ACID)
        // ------------------------------------------------------------
        public void actualizarPaciente(
            int idPaciente,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroINSS,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int idComunidad,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes,
            List<ContactoEmergenciaDto> contactos = null)
        {
            ValidarSesion("editar pacientes");

            var paciente = db.Pacientes
                .Include(p => p.ContactosEmergencia)
                .FirstOrDefault(p => p.IdPaciente == idPaciente && p.Estado);

            if (paciente == null)
            {
                throw new InvalidOperationException("El paciente no existe o se encuentra inactivo.");
            }

            ValidarDatosPaciente(
                primerNombre, primerApellido, fechaNacimiento, idComunidad,
                cedula, numeroINSS, telefono, direccion, tipoSangre, alergias, antecedentes, idPaciente);

            if (contactos != null)
            {
                foreach (var c in contactos)
                {
                    ValidarContactoEmergencia(c);
                }
            }

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    paciente.PrimerNombre = primerNombre.Trim();
                    paciente.SegundoNombre = string.IsNullOrWhiteSpace(segundoNombre) ? null : segundoNombre.Trim();
                    paciente.PrimerApellido = primerApellido.Trim();
                    paciente.SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim();
                    paciente.Cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula.Trim();
                    paciente.NumeroINSS = string.IsNullOrWhiteSpace(numeroINSS) ? null : numeroINSS.Trim();
                    paciente.FechaNacimiento = fechaNacimiento;
                    paciente.Genero = string.IsNullOrWhiteSpace(genero) ? null : genero.Trim();
                    paciente.Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim();
                    paciente.IdComunidad = idComunidad;
                    paciente.Direccion = string.IsNullOrWhiteSpace(direccion) ? null : direccion.Trim();
                    paciente.TipoSangre = string.IsNullOrWhiteSpace(tipoSangre) ? null : tipoSangre.Trim();
                    paciente.Alergias = string.IsNullOrWhiteSpace(alergias) ? null : alergias.Trim();
                    paciente.Antecedentes = string.IsNullOrWhiteSpace(antecedentes) ? null : antecedentes.Trim();

                    // Sincronización completa de Contactos de Emergencia (1:N)
                    var contactosActuales = paciente.ContactosEmergencia.ToList();
                    db.ContactosEmergencia.RemoveRange(contactosActuales);

                    if (contactos != null && contactos.Count > 0)
                    {
                        foreach (var c in contactos)
                        {
                            var nuevoContacto = new ContactosEmergencia
                            {
                                IdPaciente = idPaciente,
                                PrimerNombre = c.PrimerNombre.Trim(),
                                SegundoNombre = string.IsNullOrWhiteSpace(c.SegundoNombre) ? null : c.SegundoNombre.Trim(),
                                PrimerApellido = c.PrimerApellido.Trim(),
                                SegundoApellido = string.IsNullOrWhiteSpace(c.SegundoApellido) ? null : c.SegundoApellido.Trim(),
                                Parentesco = c.Parentesco.Trim(),
                                Telefono = c.Telefono.Trim(),
                                Cedula = string.IsNullOrWhiteSpace(c.Cedula) ? null : c.Cedula.Trim()
                            };
                            db.ContactosEmergencia.Add(nuevoContacto);
                        }
                    }

                    db.SaveChanges();
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // Sobrecarga de compatibilidad
        public void actualizarPaciente(
            int idPaciente,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroINSS,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int idComunidad,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes)
        {
            // Mantiene los contactos existentes sin alterarlos
            var paciente = db.Pacientes.Include(p => p.ContactosEmergencia).FirstOrDefault(p => p.IdPaciente == idPaciente && p.Estado);
            List<ContactoEmergenciaDto> contactosActuales = null;
            if (paciente != null)
            {
                contactosActuales = paciente.ContactosEmergencia.Select(ce => new ContactoEmergenciaDto
                {
                    IdContactoEmergencia = ce.IdContactoEmergencia,
                    IdPaciente = ce.IdPaciente,
                    PrimerNombre = ce.PrimerNombre,
                    SegundoNombre = ce.SegundoNombre,
                    PrimerApellido = ce.PrimerApellido,
                    SegundoApellido = ce.SegundoApellido,
                    Parentesco = ce.Parentesco,
                    Telefono = ce.Telefono,
                    Cedula = ce.Cedula
                }).ToList();
            }

            actualizarPaciente(
                idPaciente, primerNombre, segundoNombre, primerApellido, segundoApellido,
                cedula, numeroINSS, fechaNacimiento, genero, telefono, idComunidad,
                direccion, tipoSangre, alergias, antecedentes, contactosActuales);
        }

        // ------------------------------------------------------------
        // BAJA LÓGICA CON PRESERVACIÓN HISTÓRICA Y PROTECCIÓN CLÍNICA
        // ------------------------------------------------------------
        public void eliminarPaciente(int idPaciente)
        {
            var rol = ValidarSesion("dar de baja a pacientes");
            if (rol.Nombre != "Administrativo")
            {
                throw new InvalidOperationException("Solo un usuario con rol 'Administrativo' tiene autorización para dar de baja a un paciente.");
            }

            var paciente = db.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente && p.Estado);
            if (paciente == null)
            {
                throw new InvalidOperationException("El paciente no existe o ya se encuentra inactivo.");
            }

            // Validar que no tenga citas médicas pendientes o confirmadas
            bool tieneCitasActivas = db.Citas.Any(c => c.IdPaciente == idPaciente && (c.Estado == "Pendiente" || c.Estado == "Confirmada"));
            if (tieneCitasActivas)
            {
                throw new InvalidOperationException("No se puede dar de baja al paciente porque tiene citas médicas activas (Pendientes o Confirmadas). Debe atender o cancelar las citas antes de proceder.");
            }

            // Validar que no tenga consultas clínicas en proceso de atención
            bool tieneConsultasEnProceso = db.Consultas.Any(cons => cons.Citas.IdPaciente == idPaciente && cons.EstadoConsulta == "EnProceso");
            if (tieneConsultasEnProceso)
            {
                throw new InvalidOperationException("No se puede dar de baja al paciente porque tiene una consulta médica en proceso de atención. Debe finalizar la consulta antes de darlo de baja.");
            }

            paciente.Estado = false;
            db.SaveChanges();
        }

        // ------------------------------------------------------------
        // REACTIVACIÓN DE PACIENTE INACTIVO
        // ------------------------------------------------------------
        public void reactivarPaciente(int idPaciente)
        {
            var rol = ValidarSesion("reactivar pacientes");
            if (rol.Nombre != "Administrativo")
            {
                throw new InvalidOperationException("Solo un usuario con rol 'Administrativo' tiene autorización para reactivar a un paciente.");
            }

            var paciente = db.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente && !p.Estado);
            if (paciente == null)
            {
                throw new InvalidOperationException("El paciente no existe o ya se encuentra activo.");
            }

            // Comprobar que no colisione con otro paciente activo en cédula o INSS
            if (!string.IsNullOrWhiteSpace(paciente.Cedula) && existeCedula(paciente.Cedula, idPaciente))
            {
                throw new InvalidOperationException($"No se puede reactivar al paciente porque la cédula '{paciente.Cedula}' ya está en uso por otro paciente activo.");
            }

            if (!string.IsNullOrWhiteSpace(paciente.NumeroINSS) && existeNumeroINSS(paciente.NumeroINSS, idPaciente))
            {
                throw new InvalidOperationException($"No se puede reactivar al paciente porque el número INSS '{paciente.NumeroINSS}' ya está en uso por otro paciente activo.");
            }

            paciente.Estado = true;
            db.SaveChanges();
        }

        // Compatibilidad hacia atrás
        public Pacientes buscarPacientePorId(int idPaciente)
        {
            return db.Pacientes
                .Include(p => p.Comunidades.Municipios.Departamentos)
                .Include(p => p.ContactosEmergencia)
                .FirstOrDefault(p => p.IdPaciente == idPaciente && p.Estado);
        }

        public Pacientes buscarPaciente(int idUsuario)
        {
            return db.Pacientes.FirstOrDefault(p => p.IdUsuario == idUsuario && p.Estado);
        }
    }

    // Clase de compatibilidad con código anterior que invoque pacientesModel
    public class pacientesModel : pacientesModels
    {
    }
}
