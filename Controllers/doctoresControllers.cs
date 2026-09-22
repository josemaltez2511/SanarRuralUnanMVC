using System;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    public class doctoresControllers
    {
        // ============================================================
        // CREAR DOCTOR
        // RF-07
        // ============================================================

        public void crearDoctor(
            int idUsuario,
            string nombres,
            string apellidos,
            string especialidad,
            string numeroLicencia,
            int idHospital)
        {
            // Crear objeto del modelo.
            doctoresModels objetoDoctor =
                new doctoresModels();


            // --------------------------------------------------------
            // ENVIAR DATOS AL MODELO
            // --------------------------------------------------------

            objetoDoctor.IdUsuario = idUsuario;
            objetoDoctor.Nombres = nombres;
            objetoDoctor.Apellidos = apellidos;
            objetoDoctor.Especialidad = especialidad;
            objetoDoctor.NumeroLicencia = numeroLicencia;
            objetoDoctor.IdHospital = idHospital;


            // --------------------------------------------------------
            // GUARDAR DOCTOR
            // --------------------------------------------------------

            // El modelo se encarga de establecer:
            // Estado = "Activo"
            // y guardar en la base de datos.

            objetoDoctor.guardarDoctor();
        }


        // ============================================================
        // CONSULTAR DOCTOR
        // RF-09
        // ============================================================

        public Doctores consultarDoctor(int idUsuario)
        {
            // Crear objeto del modelo.
            doctoresModels objetoDoctor =
                new doctoresModels();


            // El modelo buscará el doctor por IdUsuario
            // y únicamente devolverá doctores activos.
            return objetoDoctor.buscarDoctor(idUsuario);
        }


        // ============================================================
        // EDITAR DOCTOR
        // RF-08
        // ============================================================

        public void editarDoctor(
            int idDoctor,
            string nombres,
            string apellidos,
            string especialidad,
            string numeroLicencia,
            int idHospital)
        {
            // Crear objeto del modelo.
            doctoresModels objetoDoctor =
                new doctoresModels();


            // --------------------------------------------------------
            // ACTUALIZAR DATOS
            // --------------------------------------------------------

            // El modelo verificará que el doctor esté activo
            // antes de permitir la edición.

            objetoDoctor.actualizarDoctor(
                idDoctor,
                nombres,
                apellidos,
                especialidad,
                numeroLicencia,
                idHospital
            );
        }


        // ============================================================
        // ELIMINAR DOCTOR
        // RF-10
        // ============================================================

        public void eliminarDoctor(int idDoctor)
        {
            // Crear objeto del modelo.
            doctoresModels objetoDoctor =
                new doctoresModels();


            // --------------------------------------------------------
            // ELIMINACIÓN LÓGICA
            // --------------------------------------------------------

            // El modelo NO elimina físicamente el registro.
            //
            // Cambia:
            //
            // Activo → Inactivo

            objetoDoctor.eliminarDoctor(idDoctor);
        }
    }
}