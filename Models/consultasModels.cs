using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SanarRuralUnan.Models
{
    // ============================================================
    // DTOS DE CONSULTA MÉDICA
    // ============================================================

    // DTO usado para mostrar el listado general de consultas médicas en la pantalla principal.
    // Solo incluye los datos que la tabla necesita: paciente, médico, sede, fechas, estado y diagnóstico principal.
    // Lo usamos para no enviar a la vista toda la entidad Consultas ni cargar datos clínicos pesados en el listado.
    public class ConsultaItemDto
    {
        public int IdConsulta { get; set; }
        public int IdCita { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public string FechaHoraInicioTexto { get; set; }
        public string FechaHoraFinTexto { get; set; }
        public string EstadoConsulta { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string Cedula { get; set; }
        public int IdDoctor { get; set; }
        public string Doctor { get; set; }
        public string Hospital { get; set; }
        public string Especialidad { get; set; }
        public string DiagnosticoPrincipal { get; set; }
        public string MotivoCita { get; set; }
    }

    // DTO usado en la ventana modal de selección de citas para iniciar una nueva consulta.
    // Contiene únicamente los datos necesarios para que el médico reconozca la cita programada del paciente.
    // Lo usamos para no enviar toda la entidad Citas cuando solo se necesita elegir qué cita atender.
    public class CitaElegibleConsultaDto
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string Cedula { get; set; }
        public int IdDoctor { get; set; }
        public string Doctor { get; set; }
        public string Hospital { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaHoraProgramada { get; set; }
        public string FechaHoraTexto { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }
    }

    // DTO usado para transportar los signos vitales entre la pantalla de atención médica y el modelo.
    // Reúne los valores numéricos de presión, pulso, respiración, temperatura, peso, talla y el cálculo en memoria de IMC.
    // Lo usamos para capturar y editar los signos vitales sin manipular directamente la entidad SignosVitales de la base de datos.
    public class SignosVitalesDto
    {
        public int IdSignosVitales { get; set; }
        public short? PresionSistolica { get; set; }
        public short? PresionDiastolica { get; set; }
        public short? FrecuenciaCardiaca { get; set; }
        public short? FrecuenciaRespiratoria { get; set; }
        public decimal? Temperatura { get; set; }
        public decimal? SaturacionOxigeno { get; set; }
        public decimal? PesoKg { get; set; }
        public decimal? TallaCm { get; set; }

        // Propiedad calculada exclusivamente para orientación visual en UI (no persistida en BD).
        public decimal? IndiceMasaCorporal
        {
            get
            {
                if (PesoKg.HasValue && TallaCm.HasValue && TallaCm.Value > 0)
                {
                    decimal estaturaMetros = TallaCm.Value / 100m;
                    return Math.Round(PesoKg.Value / (estaturaMetros * estaturaMetros), 1);
                }
                return null;
            }
        }
    }

    // DTO usado para representar una línea de diagnóstico clínico dentro de la consulta.
    // Contiene el tipo de diagnóstico, la enfermedad asociada, su descripción y observaciones.
    // Lo usamos para agregar, listar o quitar diagnósticos en la interfaz sin exponer directamente la entidad Diagnosticos.
    public class DiagnosticoItemDto
    {
        public int IdDiagnostico { get; set; }
        public int? IdEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public string TipoDiagnostico { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
    }

    // DTO usado para representar una línea de medicamento recetado en la tabla de prescripciones.
    // Lleva el medicamento, dosis, frecuencia, duración, vía de administración, indicaciones y si permite sustitución.
    // Lo usamos para gestionar la receta médica en la pantalla sin tener que enlazar la entidad Prescripciones directamente.
    public class PrescripcionItemDto
    {
        public int IdPrescripcion { get; set; }
        public int IdMedicamento { get; set; }
        public string NombreMedicamento { get; set; }
        public string PrincipioActivo { get; set; }
        public string Concentracion { get; set; }
        public string Dosis { get; set; }
        public string Frecuencia { get; set; }
        public string Duracion { get; set; }
        public string ViaAdministracion { get; set; }
        public string Indicaciones { get; set; }
        public bool PermiteSustitucion { get; set; }
        public DateTime FechaPrescripcion { get; set; }
    }

    // DTO maestro usado para cargar el expediente clínico completo en la pantalla de atención médica.
    // Reúne en un solo objeto los datos de la cita, paciente, notas de evolución y las listas de signos, diagnósticos y recetas.
    // Lo usamos para enviar a la vista exactamente todo lo que necesita mostrar y editar, sin exponer entidades de Entity Framework.
    public class ConsultaDetalleDto
    {
        public int IdConsulta { get; set; }
        public int IdCita { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public string EstadoConsulta { get; set; }
        public string PadecimientoActual { get; set; }
        public string ExamenFisico { get; set; }
        public string Observaciones { get; set; }
        public string PlanSeguimiento { get; set; }

        // Contexto clínico de la cita vinculada
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public int IdDoctor { get; set; }
        public string Doctor { get; set; }
        public string Hospital { get; set; }
        public string Especialidad { get; set; }
        public string FechaHoraProgramadaTexto { get; set; }
        public string MotivoCita { get; set; }

        public SignosVitalesDto SignosVitales { get; set; }
        public List<DiagnosticoItemDto> Diagnosticos { get; set; } = new List<DiagnosticoItemDto>();
        public List<PrescripcionItemDto> Prescripciones { get; set; } = new List<PrescripcionItemDto>();
    }

    // DTO usado para cargar el combo de medicamentos activos en la sección de prescripción.
    // Contiene el identificador, nombre comercial, principio activo y concentración formateados para el selector.
    // Lo usamos para que el médico seleccione el fármaco fácilmente sin cargar toda la entidad Medicamentos con campos innecesarios.
    public class MedicamentoItemDto
    {
        public int IdMedicamento { get; set; }
        public string NombreMedicamento { get; set; }
        public string PrincipioActivo { get; set; }
        public string Concentracion { get; set; }
        public string FormaFarmaceutica { get; set; }

        public string NombreParaSelector
        {
            get
            {
                string detalle = string.Join(" - ", new[] { PrincipioActivo, Concentracion }.Where(s => !string.IsNullOrWhiteSpace(s)));
                return string.IsNullOrWhiteSpace(detalle) ? NombreMedicamento : $"{NombreMedicamento} ({detalle})";
            }
        }
    }

    // DTO usado para cargar el combo de catálogo de enfermedades en la sección de diagnósticos.
    // Solo pasa el identificador, el nombre de la enfermedad y su categoría clínica.
    // Lo usamos para facilitar la búsqueda y selección de patologías sin enviar toda la entidad Enfermedades a la vista.
    public class EnfermedadItemDto
    {
        public int IdEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public string Categoria { get; set; }
    }

    // DTO usado para consultar y mostrar las recomendaciones clínicas asociadas a una enfermedad seleccionada.
    // Solo transporta el texto de la recomendación y el identificador de la enfermedad vinculada.
    // Lo usamos para alimentar el panel de apoyo médico en la pantalla sin traer toda la entidad RecomendacionesMedicas.
    public class RecomendacionItemDto
    {
        public int IdRecomendacion { get; set; }
        public int IdEnfermedad { get; set; }
        public string Descripcion { get; set; }
    }

    // ============================================================
    // MODELO DE PERSISTENCIA Y REGLAS DE CONSULTA MÉDICA
    // ============================================================
    public class consultasModels
    {
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ------------------------------------------------------------
        // LISTADO GENERAL DE CONSULTAS
        // ------------------------------------------------------------
        public List<ConsultaItemDto> listarConsultas(string busqueda = "", DateTime? fecha = null, string estado = "", int? idDoctor = null)
        {
            // 1. Validar existencia de sesión activa y rol
            if (!usuariosModels.IdRolActual.HasValue)
            {
                throw new InvalidOperationException("No se detectó una sesión activa con un rol válido para consultar el listado de consultas médicas.");
            }

            var rolActual = db.Roles.FirstOrDefault(r => r.IdRol == usuariosModels.IdRolActual.Value);
            if (rolActual == null)
            {
                throw new InvalidOperationException("El rol de la sesión actual no es válido para consultar el listado de consultas médicas.");
            }

            // 2. Si idDoctor es null: únicamente rol Administrativo puede utilizar el listado global
            if (!idDoctor.HasValue)
            {
                if (rolActual.Nombre != "Administrativo")
                {
                    throw new InvalidOperationException("El listado global de consultas médicas está reservado exclusivamente para usuarios con rol administrativo.");
                }
            }
            else
            {
                // 3. Si idDoctor tiene valor: únicamente rol Doctor puede utilizar el listado acotado
                if (rolActual.Nombre != "Doctor")
                {
                    throw new InvalidOperationException("La consulta de atenciones médicas acotada por facultativo solo está permitida para usuarios con rol 'Doctor'.");
                }

                var idDoctorAutenticado = new usuariosModels().ObtenerIdDoctorActual();
                if (!idDoctorAutenticado.HasValue || idDoctor.Value != idDoctorAutenticado.Value)
                {
                    throw new InvalidOperationException("Un médico solo puede consultar las atenciones clínicas asignadas a su propio perfil.");
                }
            }

            var consulta = db.Consultas
                .Include(c => c.Citas)
                .Include(c => c.Citas.Pacientes)
                .Include(c => c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores)
                .Include(c => c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades)
                .Include(c => c.Citas.DoctorHospitalEspecialidad.Hospitales)
                .Include(c => c.Diagnosticos)
                .AsQueryable();

            // Aislamiento por médico autenticado
            if (idDoctor.HasValue)
            {
                consulta = consulta.Where(c => c.Citas.IdDoctor == idDoctor.Value);
            }

            // Filtro por fecha de inicio de la atención
            if (fecha.HasValue)
            {
                DateTime fechaFiltro = fecha.Value.Date;
                consulta = consulta.Where(c => DbFunctions.TruncateTime(c.FechaHoraInicio) == fechaFiltro);
            }

            // Filtro por estado de consulta (EnProceso / Finalizada)
            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                string estadoFiltro = estado.Trim();
                consulta = consulta.Where(c => c.EstadoConsulta == estadoFiltro);
            }

            // Búsqueda textual por paciente, cédula, doctor, hospital o diagnóstico
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string texto = busqueda.Trim();
                consulta = consulta.Where(c =>
                    c.Citas.Pacientes.PrimerNombre.Contains(texto) ||
                    (c.Citas.Pacientes.SegundoNombre != null && c.Citas.Pacientes.SegundoNombre.Contains(texto)) ||
                    c.Citas.Pacientes.PrimerApellido.Contains(texto) ||
                    (c.Citas.Pacientes.SegundoApellido != null && c.Citas.Pacientes.SegundoApellido.Contains(texto)) ||
                    (c.Citas.Pacientes.Cedula != null && c.Citas.Pacientes.Cedula.Contains(texto)) ||
                    c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores.PrimerNombre.Contains(texto) ||
                    c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores.PrimerApellido.Contains(texto) ||
                    c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades.Nombre.Contains(texto) ||
                    c.Citas.DoctorHospitalEspecialidad.Hospitales.Nombre.Contains(texto) ||
                    c.Diagnosticos.Any(d => d.Descripcion.Contains(texto) || (d.Enfermedades != null && d.Enfermedades.NombreEnfermedad.Contains(texto)))
                );
            }

            return consulta
                .OrderByDescending(c => c.FechaHoraInicio)
                .ToList()
                .Select(c =>
                {
                    var p = c.Citas.Pacientes;
                    var doc = c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores;
                    var esp = c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades;
                    var hosp = c.Citas.DoctorHospitalEspecialidad.Hospitales;

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

                    var diagPrincipal = c.Diagnosticos.FirstOrDefault(d => d.TipoDiagnostico == "Principal");
                    string diagTexto = diagPrincipal != null
                        ? (!string.IsNullOrWhiteSpace(diagPrincipal.Descripcion) ? diagPrincipal.Descripcion : (diagPrincipal.Enfermedades != null ? diagPrincipal.Enfermedades.NombreEnfermedad : "Sin descripción"))
                        : "Sin diagnóstico";

                    return new ConsultaItemDto
                    {
                        IdConsulta = c.IdConsulta,
                        IdCita = c.IdCita,
                        FechaHoraInicio = c.FechaHoraInicio,
                        FechaHoraInicioTexto = c.FechaHoraInicio.ToString("dd/MM/yyyy hh:mm tt"),
                        FechaHoraFinTexto = c.FechaHoraFin.HasValue ? c.FechaHoraFin.Value.ToString("dd/MM/yyyy hh:mm tt") : "En curso",
                        EstadoConsulta = c.EstadoConsulta,
                        IdPaciente = c.Citas.IdPaciente,
                        Paciente = nombrePaciente,
                        Cedula = string.IsNullOrWhiteSpace(p.Cedula) ? "Sin cédula" : p.Cedula,
                        IdDoctor = c.Citas.IdDoctor,
                        Doctor = "Dr(a). " + nombreDoctor,
                        Hospital = hosp != null ? hosp.Nombre : "Sin sede",
                        Especialidad = esp != null ? esp.Nombre : "Sin especialidad",
                        DiagnosticoPrincipal = diagTexto,
                        MotivoCita = c.Citas.Motivo
                    };
                })
                .ToList();
        }

        // ------------------------------------------------------------
        // CITAS ELEGIBLES PARA INICIAR CONSULTA
        // ------------------------------------------------------------
        public List<CitaElegibleConsultaDto> listarCitasElegiblesParaConsulta(string busqueda = "", int? idDoctor = null)
        {
            // 1. Validar existencia de sesión activa y rol
            if (!usuariosModels.IdRolActual.HasValue)
            {
                throw new InvalidOperationException("No se detectó una sesión activa con un rol válido para listar citas elegibles para consulta.");
            }

            var rolActual = db.Roles.FirstOrDefault(r => r.IdRol == usuariosModels.IdRolActual.Value);
            if (rolActual == null)
            {
                throw new InvalidOperationException("El rol de la sesión actual no es válido para listar citas elegibles para consulta.");
            }

            // 2. La selección de citas elegibles pertenece exclusivamente al flujo clínico del Doctor
            if (rolActual.Nombre != "Doctor")
            {
                throw new InvalidOperationException("La selección de citas elegibles para iniciar consulta médica está reservada exclusivamente para usuarios con rol 'Doctor'.");
            }

            // 3. idDoctor es obligatorio y debe coincidir con el médico autenticado
            if (!idDoctor.HasValue)
            {
                throw new InvalidOperationException("Se requiere el identificador del facultativo médico autenticado para listar las citas elegibles.");
            }

            var idDoctorAutenticado = new usuariosModels().ObtenerIdDoctorActual();
            if (!idDoctorAutenticado.HasValue || idDoctor.Value != idDoctorAutenticado.Value)
            {
                throw new InvalidOperationException("Un médico solo puede consultar las citas asignadas a su propio perfil.");
            }

            var consulta = db.Citas
                .Include(c => c.Pacientes)
                .Include(c => c.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores)
                .Include(c => c.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades)
                .Include(c => c.DoctorHospitalEspecialidad.Hospitales)
                .Where(c => (c.Estado == "Pendiente" || c.Estado == "Confirmada") &&
                            c.Pacientes.Estado &&
                            !db.Consultas.Any(cons => cons.IdCita == c.IdCita) &&
                            c.IdDoctor == idDoctor.Value);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string texto = busqueda.Trim();
                consulta = consulta.Where(c =>
                    c.Pacientes.PrimerNombre.Contains(texto) ||
                    (c.Pacientes.SegundoNombre != null && c.Pacientes.SegundoNombre.Contains(texto)) ||
                    c.Pacientes.PrimerApellido.Contains(texto) ||
                    (c.Pacientes.SegundoApellido != null && c.Pacientes.SegundoApellido.Contains(texto)) ||
                    (c.Pacientes.Cedula != null && c.Pacientes.Cedula.Contains(texto)) ||
                    c.Motivo.Contains(texto)
                );
            }

            return consulta
                .OrderBy(c => c.FechaHoraProgramada)
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

                    return new CitaElegibleConsultaDto
                    {
                        IdCita = c.IdCita,
                        IdPaciente = c.IdPaciente,
                        Paciente = nombrePaciente,
                        Cedula = string.IsNullOrWhiteSpace(p.Cedula) ? "Sin cédula" : p.Cedula,
                        IdDoctor = c.IdDoctor,
                        Doctor = "Dr(a). " + nombreDoctor,
                        Hospital = hosp != null ? hosp.Nombre : "Sin sede",
                        Especialidad = esp != null ? esp.Nombre : "Sin especialidad",
                        FechaHoraProgramada = c.FechaHoraProgramada,
                        FechaHoraTexto = c.FechaHoraProgramada.ToString("dd/MM/yyyy hh:mm tt"),
                        Estado = c.Estado,
                        Motivo = c.Motivo
                    };
                })
                .ToList();
        }

        // ------------------------------------------------------------
        // COMPROBACIONES DE ESTADO Y CONSULTA PREVIA
        // ------------------------------------------------------------
        // Valida que las comprobaciones sobre citas solo sean ejecutadas por perfiles autorizados (Doctor o Administrativo).
        // Se rechazan de forma estricta el rol Paciente o sesiones no autenticadas.
        private void ValidarPermisosLecturaCita(string operacion)
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

            if (rolActual.Nombre != "Doctor" && rolActual.Nombre != "Administrativo")
            {
                throw new InvalidOperationException($"La operación '{operacion}' solo está permitida para personal médico o administrativo.");
            }
        }

        public bool citaTieneConsulta(int idCita)
        {
            ValidarPermisosLecturaCita("verificar el estado de atención de la cita médica");
            return db.Consultas.Any(c => c.IdCita == idCita);
        }

        public int? obtenerIdConsultaPorCita(int idCita)
        {
            ValidarPermisosLecturaCita("obtener la consulta médica asociada a la cita");
            var consulta = db.Consultas.FirstOrDefault(c => c.IdCita == idCita);
            return consulta != null ? consulta.IdConsulta : (int?)null;
        }

        // ------------------------------------------------------------
        // VALIDACIÓN DE PERMISOS DE ESCRITURA CLÍNICA (MODELO)
        // ------------------------------------------------------------
        // Garantiza que la escritura clínica esté permitida únicamente cuando el rol de sesión sea Doctor,
        // que el facultativo esté autenticado y que coincida con el médico titular de la consulta.
        // Los roles Administrativo, Paciente o sesiones sin rol válido son estrictamente rechazados.
        private void ValidarPermisosEscrituraClinica(int? idDoctorAutenticado, int idDoctorPropietario, string operacion)
        {
            // 1. Sin rol válido -> rechazar
            if (!usuariosModels.IdRolActual.HasValue)
            {
                throw new InvalidOperationException($"No se detectó una sesión activa con un rol válido para {operacion}.");
            }

            var rolActual = db.Roles.FirstOrDefault(r => r.IdRol == usuariosModels.IdRolActual.Value);
            if (rolActual == null)
            {
                throw new InvalidOperationException($"El rol de la sesión actual no es válido para {operacion}.");
            }

            // 2. Administrativo -> rechazar
            if (rolActual.Nombre == "Administrativo")
            {
                throw new InvalidOperationException($"Un usuario con rol administrativo no tiene autorización para {operacion}. Su perfil es estrictamente de solo lectura.");
            }

            // 3. Paciente -> rechazar
            if (rolActual.Nombre == "Paciente")
            {
                throw new InvalidOperationException($"Un usuario con rol paciente no tiene autorización para realizar operaciones clínicas como {operacion}.");
            }

            // 4. Si no es Doctor -> rechazar
            if (rolActual.Nombre != "Doctor")
            {
                throw new InvalidOperationException($"Solo un usuario con rol 'Doctor' está autorizado para {operacion}.");
            }

            // 5. Doctor -> validar correspondencia de sesión y propiedad de la consulta
            if (!idDoctorAutenticado.HasValue)
            {
                throw new InvalidOperationException($"Se requiere la identificación de un facultativo médico autorizado para {operacion}.");
            }

            var idDoctorSesion = new usuariosModels().ObtenerIdDoctorActual();
            if (!idDoctorSesion.HasValue)
            {
                throw new InvalidOperationException($"No se encontró un perfil facultativo activo asociado a la sesión actual para {operacion}.");
            }

            if (idDoctorSesion.Value != idDoctorAutenticado.Value)
            {
                throw new InvalidOperationException("El identificador del facultativo no coincide con el médico autenticado en la sesión.");
            }

            if (idDoctorPropietario != idDoctorAutenticado.Value)
            {
                throw new InvalidOperationException("Un médico solo puede gestionar las atenciones clínicas asignadas a su propio perfil.");
            }
        }

        // ------------------------------------------------------------
        // INICIO FORMAL DE UNA CONSULTA CLÍNICA
        // ------------------------------------------------------------
        public int iniciarConsulta(int idCita, int? idDoctorAutenticado = null)
        {
            var cita = db.Citas
                .Include(c => c.Pacientes)
                .FirstOrDefault(c => c.IdCita == idCita);

            if (cita == null)
            {
                throw new InvalidOperationException("La cita médica especificada no existe.");
            }

            ValidarPermisosEscrituraClinica(idDoctorAutenticado, cita.IdDoctor, "iniciar la atención clínica");

            if (cita.Estado == "Cancelada")
            {
                throw new InvalidOperationException("No se puede iniciar una consulta médica para una cita cancelada.");
            }

            if (cita.Estado == "NoAsistio")
            {
                throw new InvalidOperationException("No se puede iniciar una consulta médica para una cita marcada como no asistida.");
            }

            if (cita.Estado == "Atendida")
            {
                throw new InvalidOperationException("Esta cita ya fue marcada como atendida previamente.");
            }

            if (db.Consultas.Any(c => c.IdCita == idCita))
            {
                throw new InvalidOperationException("Esta cita ya cuenta con una consulta médica registrada en el sistema.");
            }

            Consultas nuevaConsulta = new Consultas
            {
                IdCita = idCita,
                FechaHoraInicio = DateTime.Now,
                FechaHoraFin = null,
                EstadoConsulta = "EnProceso",
                PadecimientoActual = string.Empty,
                ExamenFisico = string.Empty,
                Observaciones = string.Empty,
                PlanSeguimiento = string.Empty
            };

            db.Consultas.Add(nuevaConsulta);
            db.SaveChanges();

            return nuevaConsulta.IdConsulta;
        }

        // ------------------------------------------------------------
        // OBTENER DETALLE COMPLETO DE UNA CONSULTA
        // ------------------------------------------------------------
        public ConsultaDetalleDto obtenerConsultaDetalle(int idConsulta, int? idDoctorAutenticado = null)
        {
            var c = db.Consultas
                .Include(cons => cons.Citas)
                .Include(cons => cons.Citas.Pacientes)
                .Include(cons => cons.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores)
                .Include(cons => cons.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades)
                .Include(cons => cons.Citas.DoctorHospitalEspecialidad.Hospitales)
                .Include(cons => cons.SignosVitales)
                .Include(cons => cons.Diagnosticos.Select(d => d.Enfermedades))
                .Include(cons => cons.Prescripciones.Select(pr => pr.Medicamentos))
                .FirstOrDefault(cons => cons.IdConsulta == idConsulta);

            if (c == null)
            {
                return null;
            }

            // Validación de permisos de lectura según rol y sesión activa
            if (!usuariosModels.IdRolActual.HasValue)
            {
                throw new InvalidOperationException("No se detectó una sesión activa con un rol válido para consultar el expediente clínico.");
            }

            var rolActual = db.Roles.FirstOrDefault(r => r.IdRol == usuariosModels.IdRolActual.Value);
            if (rolActual == null)
            {
                throw new InvalidOperationException("El rol de la sesión actual no es válido para consultar el expediente clínico.");
            }

            if (!idDoctorAutenticado.HasValue)
            {
                // Cuando idDoctorAutenticado es null, solo el rol Administrativo puede consultar globalmente en solo lectura
                if (rolActual.Nombre != "Administrativo")
                {
                    throw new InvalidOperationException("La consulta global del expediente clínico está reservada únicamente para usuarios con rol administrativo.");
                }
            }
            else
            {
                // Cuando idDoctorAutenticado tiene valor, debe ser Doctor y pertenecer al titular de la consulta
                if (rolActual.Nombre != "Doctor")
                {
                    throw new InvalidOperationException("Solo un usuario con rol 'Doctor' puede consultar consultas mediante credenciales de facultativo.");
                }

                var idDoctorSesion = new usuariosModels().ObtenerIdDoctorActual();
                if (!idDoctorSesion.HasValue)
                {
                    throw new InvalidOperationException("No se encontró un perfil facultativo activo asociado a la sesión actual.");
                }

                if (idDoctorSesion.Value != idDoctorAutenticado.Value)
                {
                    throw new InvalidOperationException("El identificador del facultativo no coincide con el médico autenticado en la sesión.");
                }

                if (c.Citas.IdDoctor != idDoctorAutenticado.Value)
                {
                    throw new InvalidOperationException("No tiene permisos para acceder a una consulta médica de otro facultativo.");
                }
            }

            var p = c.Citas.Pacientes;
            var doc = c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Doctores;
            var esp = c.Citas.DoctorHospitalEspecialidad.DoctorEspecialidad.Especialidades;
            var hosp = c.Citas.DoctorHospitalEspecialidad.Hospitales;

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

            var detalle = new ConsultaDetalleDto
            {
                IdConsulta = c.IdConsulta,
                IdCita = c.IdCita,
                FechaHoraInicio = c.FechaHoraInicio,
                FechaHoraFin = c.FechaHoraFin,
                EstadoConsulta = c.EstadoConsulta,
                PadecimientoActual = c.PadecimientoActual ?? string.Empty,
                ExamenFisico = c.ExamenFisico ?? string.Empty,
                Observaciones = c.Observaciones ?? string.Empty,
                PlanSeguimiento = c.PlanSeguimiento ?? string.Empty,

                IdPaciente = c.Citas.IdPaciente,
                Paciente = nombrePaciente,
                Cedula = string.IsNullOrWhiteSpace(p.Cedula) ? "Sin cédula" : p.Cedula,
                FechaNacimiento = p.FechaNacimiento,
                Sexo = p.Genero ?? string.Empty,
                IdDoctor = c.Citas.IdDoctor,
                Doctor = "Dr(a). " + nombreDoctor,
                Hospital = hosp != null ? hosp.Nombre : "Sin sede",
                Especialidad = esp != null ? esp.Nombre : "Sin especialidad",
                FechaHoraProgramadaTexto = c.Citas.FechaHoraProgramada.ToString("dd/MM/yyyy hh:mm tt"),
                MotivoCita = c.Citas.Motivo
            };

            // Signos vitales (0..1)
            var sv = c.SignosVitales.FirstOrDefault();
            if (sv != null)
            {
                detalle.SignosVitales = new SignosVitalesDto
                {
                    IdSignosVitales = sv.IdSignosVitales,
                    PresionSistolica = sv.PresionSistolica,
                    PresionDiastolica = sv.PresionDiastolica,
                    FrecuenciaCardiaca = sv.FrecuenciaCardiaca,
                    FrecuenciaRespiratoria = sv.FrecuenciaRespiratoria,
                    Temperatura = sv.Temperatura,
                    SaturacionOxigeno = sv.SaturacionOxigeno,
                    PesoKg = sv.PesoKg,
                    TallaCm = sv.TallaCm
                };
            }
            else
            {
                detalle.SignosVitales = new SignosVitalesDto();
            }

            // Diagnósticos
            detalle.Diagnosticos = c.Diagnosticos
                .OrderBy(d => d.TipoDiagnostico == "Principal" ? 0 : 1)
                .ThenBy(d => d.IdDiagnostico)
                .Select(d => new DiagnosticoItemDto
                {
                    IdDiagnostico = d.IdDiagnostico,
                    IdEnfermedad = d.IdEnfermedad,
                    NombreEnfermedad = d.Enfermedades != null ? d.Enfermedades.NombreEnfermedad : "Sin catalogar",
                    TipoDiagnostico = d.TipoDiagnostico,
                    Descripcion = d.Descripcion,
                    Observaciones = d.Observaciones ?? string.Empty
                })
                .ToList();

            // Prescripciones
            detalle.Prescripciones = c.Prescripciones
                .OrderBy(pr => pr.IdPrescripcion)
                .Select(pr => new PrescripcionItemDto
                {
                    IdPrescripcion = pr.IdPrescripcion,
                    IdMedicamento = pr.IdMedicamento,
                    NombreMedicamento = pr.Medicamentos != null ? pr.Medicamentos.NombreMedicamento : "Sin especificar",
                    PrincipioActivo = pr.Medicamentos != null ? pr.Medicamentos.PrincipioActivo : string.Empty,
                    Concentracion = pr.Medicamentos != null ? pr.Medicamentos.Concentracion : string.Empty,
                    Dosis = pr.Dosis,
                    Frecuencia = pr.Frecuencia,
                    Duracion = pr.Duracion,
                    ViaAdministracion = pr.ViaAdministracion,
                    Indicaciones = pr.Indicaciones ?? string.Empty,
                    PermiteSustitucion = pr.PermiteSustitucion,
                    FechaPrescripcion = pr.FechaPrescripcion
                })
                .ToList();

            return detalle;
        }

        // ------------------------------------------------------------
        // GUARDAR BORRADOR DE CONSULTA (EN PROCESO)
        // ------------------------------------------------------------
        public void guardarBorradorConsulta(
            int idConsulta,
            string padecimiento,
            string examenFisico,
            string observaciones,
            string planSeguimiento,
            SignosVitalesDto signos,
            List<DiagnosticoItemDto> diagnosticos,
            List<PrescripcionItemDto> prescripciones,
            int? idDoctorAutenticado = null)
        {
            var consulta = db.Consultas
                .Include(c => c.Citas)
                .Include(c => c.SignosVitales)
                .Include(c => c.Diagnosticos)
                .Include(c => c.Prescripciones)
                .FirstOrDefault(c => c.IdConsulta == idConsulta);

            if (consulta == null)
            {
                throw new InvalidOperationException("La consulta médica no fue encontrada.");
            }

            ValidarPermisosEscrituraClinica(idDoctorAutenticado, consulta.Citas.IdDoctor, "modificar el expediente clínico");

            if (consulta.EstadoConsulta != "EnProceso")
            {
                throw new InvalidOperationException("No se puede modificar una consulta médica que ya ha sido finalizada.");
            }

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    // 1. Textos clínicos
                    consulta.PadecimientoActual = (padecimiento ?? string.Empty).Trim();
                    consulta.ExamenFisico = (examenFisico ?? string.Empty).Trim();
                    consulta.Observaciones = (observaciones ?? string.Empty).Trim();
                    consulta.PlanSeguimiento = (planSeguimiento ?? string.Empty).Trim();

                    // 2. Signos vitales (0..1)
                    ActualizarSignosVitales(consulta, signos);

                    // 3. Diagnósticos
                    SincronizarDiagnosticos(consulta, diagnosticos);

                    // 4. Prescripciones
                    SincronizarPrescripciones(consulta, prescripciones);

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

        // ------------------------------------------------------------
        // FINALIZAR FORMALMENTE LA CONSULTA (TRANSACCIÓN ACID)
        // ------------------------------------------------------------
        public void finalizarConsulta(
            int idConsulta,
            string padecimiento,
            string examenFisico,
            string observaciones,
            string planSeguimiento,
            SignosVitalesDto signos,
            List<DiagnosticoItemDto> diagnosticos,
            List<PrescripcionItemDto> prescripciones,
            int? idDoctorAutenticado = null)
        {
            var consulta = db.Consultas
                .Include(c => c.Citas)
                .Include(c => c.SignosVitales)
                .Include(c => c.Diagnosticos)
                .Include(c => c.Prescripciones)
                .FirstOrDefault(c => c.IdConsulta == idConsulta);

            if (consulta == null)
            {
                throw new InvalidOperationException("La consulta médica no fue encontrada.");
            }

            ValidarPermisosEscrituraClinica(idDoctorAutenticado, consulta.Citas.IdDoctor, "finalizar la consulta médica");

            if (consulta.EstadoConsulta != "EnProceso")
            {
                throw new InvalidOperationException("Solo se pueden finalizar consultas médicas que se encuentren en estado 'EnProceso'.");
            }

            // Validaciones estrictas de finalización clínica
            if (diagnosticos == null || !diagnosticos.Any())
            {
                throw new InvalidOperationException("Debe registrar al menos un diagnóstico para poder finalizar la consulta.");
            }

            if (!diagnosticos.Any(d => d.TipoDiagnostico == "Principal"))
            {
                throw new InvalidOperationException("Debe registrar al menos un diagnóstico clasificado como 'Principal' para finalizar la atención.");
            }

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    // 1. Textos y cierre de la Consulta
                    consulta.PadecimientoActual = (padecimiento ?? string.Empty).Trim();
                    consulta.ExamenFisico = (examenFisico ?? string.Empty).Trim();
                    consulta.Observaciones = (observaciones ?? string.Empty).Trim();
                    consulta.PlanSeguimiento = (planSeguimiento ?? string.Empty).Trim();
                    consulta.EstadoConsulta = "Finalizada";
                    consulta.FechaHoraFin = DateTime.Now;

                    // 2. Signos vitales (0..1)
                    ActualizarSignosVitales(consulta, signos);

                    // 3. Diagnósticos
                    SincronizarDiagnosticos(consulta, diagnosticos);

                    // 4. Prescripciones
                    SincronizarPrescripciones(consulta, prescripciones);

                    // 5. Cierre atómico de la Cita asociada
                    var cita = db.Citas.First(ci => ci.IdCita == consulta.IdCita);
                    cita.Estado = "Atendida";

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

        // ------------------------------------------------------------
        // MÉTODOS AUXILIARES DE SINCRONIZACIÓN CLÍNICA
        // ------------------------------------------------------------
        private void ActualizarSignosVitales(Consultas consulta, SignosVitalesDto signos)
        {
            var svExistente = consulta.SignosVitales.FirstOrDefault();

            bool tieneDatos = signos != null && (
                signos.PresionSistolica.HasValue ||
                signos.PresionDiastolica.HasValue ||
                signos.FrecuenciaCardiaca.HasValue ||
                signos.FrecuenciaRespiratoria.HasValue ||
                signos.Temperatura.HasValue ||
                signos.SaturacionOxigeno.HasValue ||
                signos.PesoKg.HasValue ||
                signos.TallaCm.HasValue
            );

            if (tieneDatos)
            {
                if (svExistente == null)
                {
                    var nuevoSv = new SignosVitales
                    {
                        IdConsulta = consulta.IdConsulta,
                        PresionSistolica = signos.PresionSistolica,
                        PresionDiastolica = signos.PresionDiastolica,
                        FrecuenciaCardiaca = signos.FrecuenciaCardiaca,
                        FrecuenciaRespiratoria = signos.FrecuenciaRespiratoria,
                        Temperatura = signos.Temperatura,
                        SaturacionOxigeno = signos.SaturacionOxigeno,
                        PesoKg = signos.PesoKg,
                        TallaCm = signos.TallaCm
                    };
                    db.SignosVitales.Add(nuevoSv);
                }
                else
                {
                    svExistente.PresionSistolica = signos.PresionSistolica;
                    svExistente.PresionDiastolica = signos.PresionDiastolica;
                    svExistente.FrecuenciaCardiaca = signos.FrecuenciaCardiaca;
                    svExistente.FrecuenciaRespiratoria = signos.FrecuenciaRespiratoria;
                    svExistente.Temperatura = signos.Temperatura;
                    svExistente.SaturacionOxigeno = signos.SaturacionOxigeno;
                    svExistente.PesoKg = signos.PesoKg;
                    svExistente.TallaCm = signos.TallaCm;
                }
            }
            else if (svExistente != null)
            {
                db.SignosVitales.Remove(svExistente);
            }
        }

        private void SincronizarDiagnosticos(Consultas consulta, List<DiagnosticoItemDto> diagnosticos)
        {
            // Remover diagnósticos anteriores
            var diagsActuales = consulta.Diagnosticos.ToList();
            foreach (var d in diagsActuales)
            {
                db.Diagnosticos.Remove(d);
            }

            if (diagnosticos != null)
            {
                foreach (var item in diagnosticos)
                {
                    string tipo = item.TipoDiagnostico?.Trim();
                    if (string.IsNullOrWhiteSpace(tipo) ||
                        (tipo != "Principal" && tipo != "Secundario" && tipo != "Presuntivo" && tipo != "Diferencial"))
                    {
                        throw new InvalidOperationException($"El tipo de diagnóstico '{item.TipoDiagnostico}' no es válido. Los tipos oficiales admitidos son: Principal, Secundario, Presuntivo y Diferencial.");
                    }

                    var nuevoDiag = new Diagnosticos
                    {
                        IdConsulta = consulta.IdConsulta,
                        IdEnfermedad = item.IdEnfermedad,
                        TipoDiagnostico = tipo,
                        Descripcion = (item.Descripcion ?? string.Empty).Trim(),
                        Observaciones = string.IsNullOrWhiteSpace(item.Observaciones) ? null : item.Observaciones.Trim()
                    };
                    db.Diagnosticos.Add(nuevoDiag);
                }
            }
        }

        private void SincronizarPrescripciones(Consultas consulta, List<PrescripcionItemDto> prescripciones)
        {
            // Remover prescripciones anteriores
            var prescActuales = consulta.Prescripciones.ToList();
            foreach (var p in prescActuales)
            {
                db.Prescripciones.Remove(p);
            }

            if (prescripciones != null)
            {
                foreach (var item in prescripciones)
                {
                    // Validar que el medicamento exista y se encuentre activo en la base de datos
                    var med = db.Medicamentos.FirstOrDefault(m => m.IdMedicamento == item.IdMedicamento && m.Estado);
                    if (med == null)
                    {
                        throw new InvalidOperationException($"El medicamento con ID {item.IdMedicamento} no existe o no se encuentra activo en el catálogo farmacéutico.");
                    }

                    var nuevaPresc = new Prescripciones
                    {
                        IdConsulta = consulta.IdConsulta,
                        IdMedicamento = item.IdMedicamento,
                        Dosis = (item.Dosis ?? string.Empty).Trim(),
                        Frecuencia = (item.Frecuencia ?? string.Empty).Trim(),
                        Duracion = (item.Duracion ?? string.Empty).Trim(),
                        ViaAdministracion = (item.ViaAdministracion ?? string.Empty).Trim(),
                        Indicaciones = string.IsNullOrWhiteSpace(item.Indicaciones) ? null : item.Indicaciones.Trim(),
                        PermiteSustitucion = item.PermiteSustitucion,
                        FechaPrescripcion = item.FechaPrescripcion != default(DateTime) ? item.FechaPrescripcion : DateTime.Now
                    };
                    db.Prescripciones.Add(nuevaPresc);
                }
            }
        }

        // ------------------------------------------------------------
        // CATÁLOGOS CLÍNICOS PARA APOYO AL DIAGNÓSTICO Y RECETA
        // ------------------------------------------------------------
        public List<MedicamentoItemDto> listarMedicamentosActivos()
        {
            return db.Medicamentos
                .Where(m => m.Estado)
                .OrderBy(m => m.NombreMedicamento)
                .Select(m => new MedicamentoItemDto
                {
                    IdMedicamento = m.IdMedicamento,
                    NombreMedicamento = m.NombreMedicamento,
                    PrincipioActivo = m.PrincipioActivo,
                    Concentracion = m.Concentracion,
                    FormaFarmaceutica = m.FormaFarmaceutica
                })
                .ToList();
        }

        public List<EnfermedadItemDto> listarEnfermedadesActivas()
        {
            return db.Enfermedades
                .Where(e => e.Estado)
                .OrderBy(e => e.NombreEnfermedad)
                .Select(e => new EnfermedadItemDto
                {
                    IdEnfermedad = e.IdEnfermedad,
                    NombreEnfermedad = e.NombreEnfermedad,
                    Categoria = e.Categoria
                })
                .ToList();
        }

        public List<RecomendacionItemDto> obtenerRecomendacionesPorEnfermedad(int idEnfermedad)
        {
            return db.RecomendacionesMedicas
                .Where(r => r.IdEnfermedad == idEnfermedad && r.Estado)
                .OrderBy(r => r.IdRecomendacion)
                .Select(r => new RecomendacionItemDto
                {
                    IdRecomendacion = r.IdRecomendacion,
                    IdEnfermedad = r.IdEnfermedad,
                    Descripcion = r.Descripcion
                })
                .ToList();
        }
    }
}
