using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

// Controller de pacientes para la aplicación SanarRuralUnan
// Este controlador comunica la Vista con el Modelo.
// La Vista no accede directamente a la base de datos.

namespace SanarRuralUnan.Controllers
{
    public class pacientesControllers
    {
        // ============================================================
        // CONSULTAS DE UBICACIÓN
        // ============================================================

        // Carga las listas dependientes del formulario de paciente.
        public List<Departamentos> listarDepartamentos()
        {
            return new pacientesModel().listarDepartamentos();
        }

        public List<Municipios> listarMunicipios(int idDepartamento)
        {
            return new pacientesModel().listarMunicipios(idDepartamento);
        }

        public List<Comunidades> listarComunidades(int idMunicipio)
        {
            return new pacientesModel().listarComunidades(idMunicipio);
        }

        public List<Pacientes> listarPacientes(string busqueda = "")
        {
            return new pacientesModel().listarPacientes(busqueda);
        }

        public Pacientes consultarPacientePorId(int idPaciente)
        {
            return new pacientesModel().buscarPacientePorId(idPaciente);
        }

        // ============================================================
        // CREAR PACIENTE
        // RF-03
        // ============================================================
        // Recibe los datos enviados desde la Vista y los pasa al Modelo.
        public void crearPaciente(
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
            new pacientesModel().guardarPaciente(
                idUsuario,
                primerNombre,
                segundoNombre,
                primerApellido,
                segundoApellido,
                cedula,
                numeroINSS,
                fechaNacimiento,
                genero,
                telefono,
                idComunidad,
                direccion,
                tipoSangre,
                alergias,
                antecedentes,
                contactoPrimerNombre,
                contactoSegundoNombre,
                contactoPrimerApellido,
                contactoSegundoApellido,
                contactoParentesco,
                contactoTelefono,
                contactoCedula);
        }

        // ============================================================
        // CONSULTAR PACIENTE
        // RF-05
        // ============================================================
        // Busca un paciente utilizando el IdUsuario.
        public Pacientes consultarPaciente(int idUsuario)
        {
            return new pacientesModel().buscarPaciente(idUsuario);
        }

        // ============================================================
        // EDITAR PACIENTE
        // RF-04
        // ============================================================
        // Recibe los datos editables y los envía al Modelo.
        public void editarPaciente(
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
            new pacientesModel().actualizarPaciente(
                idPaciente,
                primerNombre,
                segundoNombre,
                primerApellido,
                segundoApellido,
                cedula,
                numeroINSS,
                fechaNacimiento,
                genero,
                telefono,
                idComunidad,
                direccion,
                tipoSangre,
                alergias,
                antecedentes);
        }

        // ============================================================
        // ELIMINAR PACIENTE
        // RF-06
        // ============================================================
        // Realiza una baja lógica y conserva el registro en la BD.
        public void eliminarPaciente(int idPaciente)
        {
            new pacientesModel().eliminarPaciente(idPaciente);
        }
    }
}
