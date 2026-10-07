using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    // Controlador del módulo de Consulta Médica.
    // Coordina la comunicación entre la Vista y el Modelo respetando el patrón MVC informal del proyecto.
    public class consultasControllers
    {
        private readonly consultasModels modelo = new consultasModels();

        // ============================================================
        // CONSULTAS DE LISTADO Y DETALLE
        // ============================================================

        // Lista las consultas médicas aplicando filtros de búsqueda textual, fecha, estado y doctor asignado.
        public List<ConsultaItemDto> listarConsultas(string busqueda = "", DateTime? fecha = null, string estado = "", int? idDoctor = null)
        {
            return modelo.listarConsultas(busqueda, fecha, estado, idDoctor);
        }

        // Lista las citas médicas programadas que son elegibles para iniciar consulta (estados Pendiente/Confirmada sin consulta previa).
        public List<CitaElegibleConsultaDto> listarCitasElegiblesParaConsulta(string busqueda = "", int? idDoctor = null)
        {
            return modelo.listarCitasElegiblesParaConsulta(busqueda, idDoctor);
        }

        // Verifica si una cita médica ya tiene una consulta registrada.
        public bool citaTieneConsulta(int idCita)
        {
            return modelo.citaTieneConsulta(idCita);
        }

        // Obtiene el identificador de la consulta asociada a una cita médica, o null si aún no existe.
        public int? obtenerIdConsultaPorCita(int idCita)
        {
            return modelo.obtenerIdConsultaPorCita(idCita);
        }

        // Obtiene el expediente clínico completo de una consulta médica específica.
        public ConsultaDetalleDto obtenerConsultaDetalle(int idConsulta, int? idDoctorAutenticado = null)
        {
            return modelo.obtenerConsultaDetalle(idConsulta, idDoctorAutenticado);
        }

        // ============================================================
        // OPERACIONES DE ATENCIÓN CLÍNICA
        // ============================================================

        // Inicia formalmente una consulta médica a partir de una cita agendada, asignando estado inicial 'EnProceso'.
        public int iniciarConsulta(int idCita, int? idDoctorAutenticado = null)
        {
            return modelo.iniciarConsulta(idCita, idDoctorAutenticado);
        }

        // Guarda un borrador de la consulta médica manteniendo el estado 'EnProceso' sin cerrar la cita.
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
            modelo.guardarBorradorConsulta(
                idConsulta,
                padecimiento,
                examenFisico,
                observaciones,
                planSeguimiento,
                signos,
                diagnosticos,
                prescripciones,
                idDoctorAutenticado
            );
        }

        // Finaliza formalmente la consulta médica de forma atómica: valida diagnósticos, signos, prescripciones y actualiza la cita a 'Atendida'.
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
            modelo.finalizarConsulta(
                idConsulta,
                padecimiento,
                examenFisico,
                observaciones,
                planSeguimiento,
                signos,
                diagnosticos,
                prescripciones,
                idDoctorAutenticado
            );
        }

        // ============================================================
        // CATÁLOGOS CLÍNICOS Y APOYO
        // ============================================================

        // Retorna el catálogo de medicamentos activos para selección en prescripciones.
        public List<MedicamentoItemDto> listarMedicamentosActivos()
        {
            return modelo.listarMedicamentosActivos();
        }

        // Retorna el catálogo de enfermedades activas para diagnóstico.
        public List<EnfermedadItemDto> listarEnfermedadesActivas()
        {
            return modelo.listarEnfermedadesActivas();
        }

        // Retorna las recomendaciones médicas asociadas a una enfermedad específica.
        public List<RecomendacionItemDto> obtenerRecomendacionesPorEnfermedad(int idEnfermedad)
        {
            return modelo.obtenerRecomendacionesPorEnfermedad(idEnfermedad);
        }
    }
}
