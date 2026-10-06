using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    public class doctoresControllers
    {
        // ============================================================
        // CONSULTAR CATÁLOGOS
        // ============================================================
        public List<Especialidades> listarEspecialidades()
        {
            return new doctoresModels().listarEspecialidades();
        }

        public List<Hospitales> listarHospitales()
        {
            return new doctoresModels().listarHospitales();
        }

        // ============================================================
        // CREAR DOCTOR
        // RF-07
        // ============================================================
        public void crearDoctor(
            int? idUsuario,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroLicencia,
            string telefono,
            byte[] foto,
            string fotoNombre,
            string fotoMimeType,
            IList<int> idEspecialidades,
            IList<Tuple<int, int>> asignaciones)
        {
            // El modelo guarda el doctor con sus relaciones y lo marca como activo.
            new doctoresModels().guardarDoctor(
                idUsuario,
                primerNombre,
                segundoNombre,
                primerApellido,
                segundoApellido,
                cedula,
                numeroLicencia,
                telefono,
                foto,
                fotoNombre,
                fotoMimeType,
                idEspecialidades,
                asignaciones
            );
        }

        // ============================================================
        // LISTAR DOCTORES
        // ============================================================
        public object listarDoctores(string busqueda = "")
        {
            return new doctoresModels().listarDoctores(busqueda);
        }

        // ============================================================
        // CONSULTAR DOCTOR POR ID
        // ============================================================
        public Doctores consultarDoctorPorId(int idDoctor)
        {
            return new doctoresModels().buscarDoctorPorId(idDoctor);
        }

        // ============================================================
        // EDITAR DOCTOR
        // RF-08
        // ============================================================
        public void editarDoctor(
            int idDoctor,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroLicencia,
            string telefono,
            byte[] foto,
            string fotoNombre,
            string fotoMimeType,
            IList<int> idEspecialidades,
            IList<Tuple<int, int>> asignaciones)
        {
            // El modelo verifica que el doctor esté activo antes de actualizarlo.
            new doctoresModels().actualizarDoctor(
                idDoctor,
                primerNombre,
                segundoNombre,
                primerApellido,
                segundoApellido,
                cedula,
                numeroLicencia,
                telefono,
                foto,
                fotoNombre,
                fotoMimeType,
                idEspecialidades,
                asignaciones
            );
        }

        // ============================================================
        // ELIMINAR DOCTOR
        // RF-10
        // ============================================================
        public void eliminarDoctor(int idDoctor)
        {
            // El modelo cambia el estado sin eliminar el registro.
            new doctoresModels().eliminarDoctor(idDoctor);
        }
    }
}
