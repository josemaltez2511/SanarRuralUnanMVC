using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    // Controlador del módulo de Citas Médicas.
    // Coordina la comunicación entre la Vista y el Modelo respetando el flujo MVC del proyecto.
    public class citasControllers
    {
        private readonly citasModels modelo = new citasModels();

        // ============================================================
        // CONSULTAS DE LISTADO Y DETALLE
        // ============================================================

        // Lista citas aplicando búsqueda textual y filtros opcionales de fecha, estado y doctor.
        public List<CitaItemDto> listarCitas(string busqueda = "", DateTime? fecha = null, string estado = "", int? idDoctor = null)
        {
            return modelo.listarCitas(busqueda, fecha, estado, idDoctor);
        }

        // Obtiene una cita específica con sus datos relacionados para edición, validando el doctor si aplica.
        public Citas obtenerCitaPorId(int idCita, int? idDoctor = null)
        {
            return modelo.obtenerCitaPorId(idCita, idDoctor);
        }

        // ============================================================
        // CATÁLOGOS DEPENDIENTES PARA AGENDAMIENTO
        // ============================================================

        // Lista pacientes activos formateados para selección en citas.
        public List<PacienteItemDto> listarPacientesActivos()
        {
            return modelo.listarPacientesActivos();
        }

        // Lista especialidades activas que tienen doctores y hospitales asignados, opcionalmente filtradas por doctor.
        public List<Especialidades> listarEspecialidadesConAsignacion(int? idDoctor = null)
        {
            return modelo.listarEspecialidadesConAsignacion(idDoctor);
        }

        // Lista doctores activos disponibles para una especialidad seleccionada, opcionalmente filtrados por doctor autenticado.
        public List<DoctorItemDto> listarDoctoresPorEspecialidad(int idEspecialidad, int? idDoctor = null)
        {
            return modelo.listarDoctoresPorEspecialidad(idEspecialidad, idDoctor);
        }

        // Lista hospitales activos donde un doctor atiende una especialidad específica.
        public List<Hospitales> listarHospitalesPorDoctorYEspecialidad(int idDoctor, int idEspecialidad)
        {
            return modelo.listarHospitalesPorDoctorYEspecialidad(idDoctor, idEspecialidad);
        }

        // ============================================================
        // PERSISTENCIA Y CICLO DE VIDA DE CITAS
        // ============================================================

        // Registra una nueva cita médica con estado inicial Pendiente tras validar reglas clínicas y alcance.
        public int guardarCita(
            int idPaciente,
            int idDoctor,
            int idHospital,
            int idEspecialidad,
            DateTime fechaHora,
            string motivo,
            int? idDoctorAutenticado = null)
        {
            return modelo.guardarCita(
                idPaciente,
                idDoctor,
                idHospital,
                idEspecialidad,
                fechaHora,
                motivo,
                idDoctorAutenticado
            );
        }

        // Actualiza los datos de una cita médica existente siempre que su estado y alcance lo permitan.
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
            modelo.actualizarCita(
                idCita,
                idPaciente,
                idDoctor,
                idHospital,
                idEspecialidad,
                fechaHora,
                motivo,
                idDoctorAutenticado
            );
        }

        // Ejecuta la transición de estado de una cita médica validando las reglas permitidas y alcance.
        public void cambiarEstadoCita(int idCita, string nuevoEstado, int? idDoctorAutenticado = null)
        {
            modelo.cambiarEstadoCita(idCita, nuevoEstado, idDoctorAutenticado);
        }
    }
}
