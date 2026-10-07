using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SanarRuralUnan.Models
{
    // DTO para representar una cita médica formateada en listados y grillas.
    public class CitaItemDto
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string Cedula { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int IdDoctor { get; set; }
        public string Doctor { get; set; }
        public int IdHospital { get; set; }
        public string Hospital { get; set; }
        public DateTime FechaHoraProgramada { get; set; }
        public string FechaHoraTexto { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }
    }

    // DTO para presentar pacientes activos en selectores de citas.
    public class PacienteItemDto
    {
        public int IdPaciente { get; set; }
        public string NombreCompleto { get; set; }
    }

    // DTO para presentar doctores activos en selectores dependientes.
    public class DoctorItemDto
    {
        public int IdDoctor { get; set; }
        public string NombreCompleto { get; set; }
    }

    public class citasModels
    {
        // La instancia del contexto de base de datos reside únicamente en el Modelo.
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ============================================================
        // LISTAR CITAS CON BÚSQUEDA Y FILTROS
        // ============================================================
        public List<CitaItemDto> listarCitas(string busqueda = "", DateTime? fecha = null, string estado = "", int? idDoctor = null)
        {
            var consulta = db.Citas
                .Include(c => c.Pacientes)
                .Include(c => c.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores)
                .Include(c => c.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades)
                .Include(c => c.DoctorHospitalEspecialidad.Hospitales)
                .AsQueryable();

            // Restricción por doctor asignado (para médicos autenticados).
            if (idDoctor.HasValue)
            {
                consulta = consulta.Where(c => c.IdDoctor == idDoctor.Value);
            }

            // Filtro por fecha programada (mismo día calendario).
            if (fecha.HasValue)
            {
                DateTime fechaFiltro = fecha.Value.Date;
                consulta = consulta.Where(c => DbFunctions.TruncateTime(c.FechaHoraProgramada) == fechaFiltro);
            }

            // Filtro por estado oficial.
            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                string estadoFiltro = estado.Trim();
                consulta = consulta.Where(c => c.Estado == estadoFiltro);
            }

            // Búsqueda en tiempo real por paciente, cédula, doctor o motivo.
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string texto = busqueda.Trim();
                consulta = consulta.Where(c =>
                    c.Pacientes.PrimerNombre.Contains(texto) ||
                    (c.Pacientes.SegundoNombre != null && c.Pacientes.SegundoNombre.Contains(texto)) ||
                    c.Pacientes.PrimerApellido.Contains(texto) ||
                    (c.Pacientes.SegundoApellido != null && c.Pacientes.SegundoApellido.Contains(texto)) ||
                    (c.Pacientes.Cedula != null && c.Pacientes.Cedula.Contains(texto)) ||
                    c.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores.PrimerNombre.Contains(texto) ||
                    c.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores.PrimerApellido.Contains(texto) ||
                    c.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades.Nombre.Contains(texto) ||
                    c.DoctorHospitalEspecialidad.Hospitales.Nombre.Contains(texto) ||
                    c.Motivo.Contains(texto)
                );
            }

            return consulta
                .OrderByDescending(c => c.FechaHoraProgramada)
                .ToList()
                .Select(c =>
                {
                    var p = c.Pacientes;
                    var doc = c.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores;
                    var esp = c.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades;
                    var hosp = c.DoctorHospitalEspecialidad.Hospitales;

                    string nombrePaciente = string.Join(" ", new[]
                    {
                        p.PrimerApellido,
                        p.SegundoApellido,
                        p.PrimerNombre,
                        p.SegundoNombre
                    }.Where(parte => !string.IsNullOrWhiteSpace(parte)));

                    string nombreDoctor = string.Join(" ", new[]
                    {
                        doc.PrimerNombre,
                        doc.SegundoNombre,
                        doc.PrimerApellido,
                        doc.SegundoApellido
                    }.Where(parte => !string.IsNullOrWhiteSpace(parte)));

                    return new CitaItemDto
                    {
                        IdCita = c.IdCita,
                        IdPaciente = c.IdPaciente,
                        Paciente = nombrePaciente,
                        Cedula = string.IsNullOrWhiteSpace(p.Cedula) ? "Sin cédula" : p.Cedula,
                        IdEspecialidad = c.IdEspecialidad,
                        Especialidad = esp != null ? esp.Nombre : "Sin especialidad",
                        IdDoctor = c.IdDoctor,
                        Doctor = "Dr(a). " + nombreDoctor,
                        IdHospital = c.IdHospital,
                        Hospital = hosp != null ? hosp.Nombre : "Sin sede",
                        FechaHoraProgramada = c.FechaHoraProgramada,
                        FechaHoraTexto = c.FechaHoraProgramada.ToString("dd/MM/yyyy hh:mm tt"),
                        Estado = c.Estado,
                        Motivo = c.Motivo
                    };
                })
                .ToList();
        }

        // ============================================================
        // OBTENER CITA POR ID
        // ============================================================
        public Citas obtenerCitaPorId(int idCita, int? idDoctor = null)
        {
            return db.Citas
                .Include(c => c.Pacientes)
                .Include(c => c.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores)
                .Include(c => c.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades)
                .Include(c => c.DoctorHospitalEspecialidad.Hospitales)
                .FirstOrDefault(c => c.IdCita == idCita && (!idDoctor.HasValue || c.IdDoctor == idDoctor.Value));
        }

        // ============================================================
        // CATÁLOGOS PARA COMBOS DEPENDIENTES
        // ============================================================

        // Lista pacientes activos formateados para identificación rápida.
        public List<PacienteItemDto> listarPacientesActivos()
        {
            return db.Pacientes
                .Where(p => p.Estado)
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

                    string cedulaTexto = string.IsNullOrWhiteSpace(p.Cedula) ? "Sin cédula" : p.Cedula;

                    return new PacienteItemDto
                    {
                        IdPaciente = p.IdPaciente,
                        NombreCompleto = $"{nombreCompleto} — Cédula: {cedulaTexto}"
                    };
                })
                .ToList();
        }

        // Lista únicamente especialidades activas que tienen al menos una asignación médica registrada.
        public List<Especialidades> listarEspecialidadesConAsignacion(int? idDoctor = null)
        {
            var consulta = db.DoctorHospitalEspecialidad
                .Where(dhe => dhe.DoctorEspecialidad.Doctores.Estado &&
                              dhe.Hospitales.Estado &&
                              dhe.DoctorEspecialidad.Especialidades.Estado);

            if (idDoctor.HasValue)
            {
                consulta = consulta.Where(dhe => dhe.IdDoctor == idDoctor.Value);
            }

            return consulta
                .Select(dhe => dhe.DoctorEspecialidad.Especialidades)
                .Distinct()
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        // Lista doctores activos que atienden la especialidad seleccionada.
        public List<DoctorItemDto> listarDoctoresPorEspecialidad(int idEspecialidad, int? idDoctor = null)
        {
            var consulta = db.DoctorHospitalEspecialidad
                .Where(dhe => dhe.IdEspecialidad == idEspecialidad &&
                              dhe.DoctorEspecialidad.Doctores.Estado &&
                              dhe.Hospitales.Estado);

            if (idDoctor.HasValue)
            {
                consulta = consulta.Where(dhe => dhe.IdDoctor == idDoctor.Value);
            }

            return consulta
                .Select(dhe => dhe.DoctorEspecialidad.Doctores)
                .Distinct()
                .OrderBy(d => d.PrimerApellido)
                .ThenBy(d => d.PrimerNombre)
                .ToList()
                .Select(d =>
                {
                    string nombreCompleto = string.Join(" ", new[]
                    {
                        d.PrimerNombre,
                        d.SegundoNombre,
                        d.PrimerApellido,
                        d.SegundoApellido
                    }.Where(parte => !string.IsNullOrWhiteSpace(parte)));

                    return new DoctorItemDto
                    {
                        IdDoctor = d.IdDoctor,
                        NombreCompleto = "Dr(a). " + nombreCompleto
                    };
                })
                .ToList();
        }

        // Lista hospitales activos donde el doctor seleccionado atiende la especialidad seleccionada.
        public List<Hospitales> listarHospitalesPorDoctorYEspecialidad(int idDoctor, int idEspecialidad)
        {
            return db.DoctorHospitalEspecialidad
                .Where(dhe => dhe.IdDoctor == idDoctor &&
                              dhe.IdEspecialidad == idEspecialidad &&
                              dhe.Hospitales.Estado)
                .Select(dhe => dhe.Hospitales)
                .Distinct()
                .OrderBy(h => h.Nombre)
                .ToList();
        }

        // ============================================================
        // VALIDACIONES DE NEGOCIO Y CONFLICTOS
        // ============================================================

        // Valida que la combinación Doctor + Hospital + Especialidad exista en DoctorHospitalEspecialidad.
        public bool validarAsignacionDoctorHospitalEspecialidad(int idDoctor, int idHospital, int idEspecialidad)
        {
            return db.DoctorHospitalEspecialidad.Any(dhe =>
                dhe.IdDoctor == idDoctor &&
                dhe.IdHospital == idHospital &&
                dhe.IdEspecialidad == idEspecialidad &&
                dhe.DoctorEspecialidad.Doctores.Estado &&
                dhe.Hospitales.Estado
            );
        }

        // Valida si el doctor tiene otra cita activa programada exactamente en la misma fecha y hora.
        public bool existeSolapamientoDoctor(int idDoctor, DateTime fechaHora, int? idCitaExcluir = null)
        {
            return db.Citas.Any(c =>
                c.IdDoctor == idDoctor &&
                c.FechaHoraProgramada == fechaHora &&
                c.Estado != "Cancelada" &&
                (!idCitaExcluir.HasValue || c.IdCita != idCitaExcluir.Value)
            );
        }

        // Valida si el paciente tiene otra cita activa programada exactamente en la misma fecha y hora.
        public bool existeSolapamientoPaciente(int idPaciente, DateTime fechaHora, int? idCitaExcluir = null)
        {
            return db.Citas.Any(c =>
                c.IdPaciente == idPaciente &&
                c.FechaHoraProgramada == fechaHora &&
                c.Estado != "Cancelada" &&
                (!idCitaExcluir.HasValue || c.IdCita != idCitaExcluir.Value)
            );
        }

        // ============================================================
        // GUARDAR CITA (CREACIÓN)
        // ============================================================
        public int guardarCita(
            int idPaciente,
            int idDoctor,
            int idHospital,
            int idEspecialidad,
            DateTime fechaHora,
            string motivo,
            int? idDoctorAutenticado = null)
        {
            // Restricción de alcance: un médico autenticado solo puede registrar citas para sí mismo.
            if (idDoctorAutenticado.HasValue && idDoctor != idDoctorAutenticado.Value)
            {
                throw new InvalidOperationException("Un médico solo puede registrar citas asignadas a su propio perfil.");
            }

            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("El motivo de la cita médica es obligatorio.");
            }

            if (fechaHora < DateTime.Now)
            {
                throw new InvalidOperationException("La cita no puede programarse en una fecha u hora pasada.");
            }

            if (!validarAsignacionDoctorHospitalEspecialidad(idDoctor, idHospital, idEspecialidad))
            {
                throw new InvalidOperationException("La asignación seleccionada de Doctor, Hospital y Especialidad no es válida.");
            }

            if (existeSolapamientoDoctor(idDoctor, fechaHora))
            {
                throw new InvalidOperationException("El doctor seleccionado ya tiene una cita programada en la misma fecha y hora.");
            }

            if (existeSolapamientoPaciente(idPaciente, fechaHora))
            {
                throw new InvalidOperationException("El paciente seleccionado ya tiene una cita médica programada en la misma fecha y hora.");
            }

            Citas nuevaCita = new Citas
            {
                IdPaciente = idPaciente,
                IdDoctor = idDoctor,
                IdHospital = idHospital,
                IdEspecialidad = idEspecialidad,
                FechaHoraProgramada = fechaHora,
                Estado = "Pendiente",
                Motivo = motivo.Trim(),
                FechaCreacion = DateTime.Now
            };

            db.Citas.Add(nuevaCita);
            db.SaveChanges();

            return nuevaCita.IdCita;
        }

        // ============================================================
        // ACTUALIZAR CITA (EDICIÓN / REPROGRAMACIÓN)
        // ============================================================
        public void actualizarCita(
            int idCita,
            int idPaciente,
            int idDoctor,
            int idHospital,
            int idEspecialidad,
            DateTime fechaHora,
            string motivo,
            int? idDoctorAutenticado = null)
        {
            var cita = db.Citas.FirstOrDefault(c => c.IdCita == idCita);
            if (cita == null)
            {
                throw new InvalidOperationException("La cita que intenta editar no fue encontrada.");
            }

            // Restricción de alcance: un médico autenticado solo puede modificar citas propias y no transferirlas a otro doctor.
            if (idDoctorAutenticado.HasValue && (cita.IdDoctor != idDoctorAutenticado.Value || idDoctor != idDoctorAutenticado.Value))
            {
                throw new InvalidOperationException("Un médico solo puede modificar citas asignadas a su propio perfil.");
            }

            if (cita.Estado == "Atendida" || cita.Estado == "Cancelada" || cita.Estado == "NoAsistio")
            {
                throw new InvalidOperationException($"No se puede modificar una cita que se encuentra en estado '{cita.Estado}'.");
            }

            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("El motivo de la cita médica es obligatorio.");
            }

            if (fechaHora < DateTime.Now)
            {
                throw new InvalidOperationException("La fecha y hora de la cita no puede ser anterior al momento actual.");
            }

            if (!validarAsignacionDoctorHospitalEspecialidad(idDoctor, idHospital, idEspecialidad))
            {
                throw new InvalidOperationException("La asignación seleccionada de Doctor, Hospital y Especialidad no es válida.");
            }

            if (existeSolapamientoDoctor(idDoctor, fechaHora, idCita))
            {
                throw new InvalidOperationException("El doctor seleccionado ya tiene otra cita programada en esa misma fecha y hora.");
            }

            if (existeSolapamientoPaciente(idPaciente, fechaHora, idCita))
            {
                throw new InvalidOperationException("El paciente seleccionado ya tiene otra cita médica programada en esa misma fecha y hora.");
            }

            cita.IdPaciente = idPaciente;
            cita.IdDoctor = idDoctor;
            cita.IdHospital = idHospital;
            cita.IdEspecialidad = idEspecialidad;
            cita.FechaHoraProgramada = fechaHora;
            cita.Motivo = motivo.Trim();

            db.SaveChanges();
        }

        // ============================================================
        // CAMBIOS DE ESTADO DE CITA
        // ============================================================
        public void cambiarEstadoCita(int idCita, string nuevoEstado, int? idDoctorAutenticado = null)
        {
            var cita = db.Citas.FirstOrDefault(c => c.IdCita == idCita);
            if (cita == null)
            {
                throw new InvalidOperationException("La cita seleccionada no existe en el sistema.");
            }

            // Restricción de alcance: un médico autenticado solo puede cambiar el estado de sus propias citas.
            if (idDoctorAutenticado.HasValue && cita.IdDoctor != idDoctorAutenticado.Value)
            {
                throw new InvalidOperationException("Un médico solo puede cambiar el estado de citas asignadas a su propio perfil.");
            }

            // Regla 4.6: Este módulo no debe marcar citas como 'Atendida'.
            if (nuevoEstado == "Atendida")
            {
                throw new InvalidOperationException("El estado 'Atendida' solo puede establecerse desde el módulo de Consulta Médica.");
            }

            // Regla de negocio: Una cita solo puede pasar a 'NoAsistio' cuando la fecha y hora programada ya haya pasado.
            if (nuevoEstado == "NoAsistio" && cita.FechaHoraProgramada > DateTime.Now)
            {
                throw new InvalidOperationException("No se puede marcar la cita como no asistida hasta que haya pasado la fecha y hora programada.");
            }

            // Validar transiciones permitidas según el estado actual.
            if (cita.Estado == "Pendiente")
            {
                if (nuevoEstado != "Confirmada" && nuevoEstado != "Cancelada" && nuevoEstado != "NoAsistio")
                {
                    throw new InvalidOperationException($"Transición no permitida de 'Pendiente' a '{nuevoEstado}'.");
                }
            }
            else if (cita.Estado == "Confirmada")
            {
                if (nuevoEstado != "Cancelada" && nuevoEstado != "NoAsistio")
                {
                    throw new InvalidOperationException($"Transición no permitida de 'Confirmada' a '{nuevoEstado}'.");
                }
            }
            else if (cita.Estado == "Atendida" || cita.Estado == "Cancelada" || cita.Estado == "NoAsistio")
            {
                throw new InvalidOperationException($"Una cita en estado '{cita.Estado}' es definitiva y no puede cambiar de estado.");
            }
            else
            {
                throw new InvalidOperationException($"Estado actual '{cita.Estado}' no reconocido para transiciones.");
            }

            cita.Estado = nuevoEstado;
            db.SaveChanges();
        }
    }
}
