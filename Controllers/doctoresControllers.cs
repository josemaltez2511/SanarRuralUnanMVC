using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            bool fotoEliminada,
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
                fotoEliminada,
                idEspecialidades,
                asignaciones
            );
        }

        // ============================================================
        // ELIMINAR DOCTOR
        // RF-10
        // ============================================================
        // Maneja el resultado de la baja lógica del doctor y presenta el mensaje correspondiente.
        public bool eliminarDoctor(int idDoctor)
        {
            try
            {
                new doctoresModels().eliminarDoctor(idDoctor);
                MessageBox.Show(
                    "El doctor ha sido dado de baja correctamente.",
                    "Operación Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Operación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al dar de baja: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}
