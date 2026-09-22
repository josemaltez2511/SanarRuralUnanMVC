using System;
using SanarRuralUnan.Models;

// Controller de pacientes para la aplicación SanarRuralUnan
// Este controlador comunica la Vista con el Modelo.
// La Vista no accede directamente a la base de datos.

namespace SanarRuralUnan.Controllers
{
    public class pacientesController
    {
        // ============================================================
        // CREAR PACIENTE
        // RF-03
        // ============================================================
        // Recibe todos los datos enviados desde la Vista
        // y los pasa al Modelo.

        public void crearPaciente(
            int idUsuario,
            string nombres,
            string apellidos,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            string departamento,
            string municipio,
            string comunidad,
            string direccion,
            string contactoEmergencia,
            string tipoSangre,
            string alergias,
            string antecedentes)
        {
            // Crear objeto del modelo.
            pacientesModel objetoPaciente = new pacientesModel();

            // Datos personales
            objetoPaciente.IdUsuario = idUsuario;
            objetoPaciente.Nombres = nombres;
            objetoPaciente.Apellidos = apellidos;
            objetoPaciente.FechaNacimiento = fechaNacimiento;
            objetoPaciente.Genero = genero;
            objetoPaciente.Telefono = telefono;

            // Datos de ubicación
            objetoPaciente.Departamento = departamento;
            objetoPaciente.Municipio = municipio;
            objetoPaciente.Comunidad = comunidad;
            objetoPaciente.Direccion = direccion;

            // Información de salud
            objetoPaciente.ContactoEmergencia = contactoEmergencia;
            objetoPaciente.TipoSangre = tipoSangre;
            objetoPaciente.Alergias = alergias;
            objetoPaciente.Antecedentes = antecedentes;

            // Pedir al Modelo que guarde el paciente.
            objetoPaciente.guardarPaciente();
        }


        // ============================================================
        // CONSULTAR PACIENTE
        // RF-05
        // ============================================================
        // Busca un paciente utilizando el IdUsuario.

        public Pacientes consultarPaciente(int idUsuario)
        {
            pacientesModel objetoPaciente = new pacientesModel();

            return objetoPaciente.buscarPaciente(idUsuario);
        }


        // ============================================================
        // EDITAR PACIENTE
        // RF-04
        // ============================================================
        // Recibe todos los datos que pueden modificarse
        // y los envía al Modelo.

        public void editarPaciente(
            int idPaciente,
            string nombres,
            string apellidos,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            string departamento,
            string municipio,
            string comunidad,
            string direccion,
            string contactoEmergencia,
            string tipoSangre,
            string alergias,
            string antecedentes)
        {
            // Crear objeto del modelo.
            pacientesModel objetoPaciente = new pacientesModel();

            // Enviar todos los datos al Modelo.
            objetoPaciente.actualizarPaciente(
                idPaciente,
                nombres,
                apellidos,
                fechaNacimiento,
                genero,
                telefono,
                departamento,
                municipio,
                comunidad,
                direccion,
                contactoEmergencia,
                tipoSangre,
                alergias,
                antecedentes
            );
        }


        // ============================================================
        // ELIMINAR PACIENTE
        // RF-06
        // ============================================================
        // Realiza un soft delete.
        // El registro NO se elimina físicamente de la BD.

        public void eliminarPaciente(int idPaciente)
        {
            pacientesModel objetoPaciente = new pacientesModel();

            objetoPaciente.eliminarPaciente(idPaciente);
        }
    }
}