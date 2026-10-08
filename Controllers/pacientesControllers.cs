using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    // Controlador del módulo de Pacientes.
    // Orquesta la comunicación entre la capa de Vista y el Modelo respetando el patrón MVC informal.
    public class pacientesControllers
    {
        private readonly pacientesModels modelo = new pacientesModels();

        // ============================================================
        // CONSULTAS GEOGRÁFICAS
        // ============================================================

        public List<UbicacionItemDto> listarDepartamentos()
        {
            return modelo.listarDepartamentos();
        }

        public List<UbicacionItemDto> listarMunicipios(int idDepartamento)
        {
            return modelo.listarMunicipios(idDepartamento);
        }

        public List<UbicacionItemDto> listarComunidades(int idMunicipio)
        {
            return modelo.listarComunidades(idMunicipio);
        }

        // ============================================================
        // LISTADO Y DETALLE DE PACIENTES
        // ============================================================

        public List<PacienteItemDto> listarPacientes(string busqueda = "", string estadoFiltro = "Activos")
        {
            return modelo.listarPacientes(busqueda, estadoFiltro);
        }

        public PacienteDetalleDto obtenerPacienteDetalle(int idPaciente)
        {
            return modelo.obtenerPacienteDetalle(idPaciente);
        }

        public PacienteDetalleDto buscarPacientePorUsuario(int idUsuario)
        {
            return modelo.buscarPacientePorUsuario(idUsuario);
        }

        public bool EsAdministrativo()
        {
            return modelo.EsAdministrativo();
        }

        // ============================================================
        // COMPROBACIONES DE UNICIDAD
        // ============================================================

        public bool existeCedula(string cedula, int? idPacienteExcluir = null)
        {
            return modelo.existeCedula(cedula, idPacienteExcluir);
        }

        public bool existeNumeroINSS(string numeroINSS, int? idPacienteExcluir = null)
        {
            return modelo.existeNumeroINSS(numeroINSS, idPacienteExcluir);
        }

        // ============================================================
        // REGISTRO Y EDICIÓN (ATÓMICO CON CONTACTOS)
        // ============================================================

        public int crearPaciente(
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
            return modelo.guardarPaciente(
                idUsuario, primerNombre, segundoNombre, primerApellido, segundoApellido,
                cedula, numeroINSS, fechaNacimiento, genero, telefono, idComunidad,
                direccion, tipoSangre, alergias, antecedentes, contactos);
        }

        public bool editarPaciente(
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
            return modelo.actualizarPaciente(
                idPaciente, primerNombre, segundoNombre, primerApellido, segundoApellido,
                cedula, numeroINSS, fechaNacimiento, genero, telefono, idComunidad,
                direccion, tipoSangre, alergias, antecedentes, contactos);
        }

        // ============================================================
        // BAJA LÓGICA Y REACTIVACIÓN
        // ============================================================

        public void eliminarPaciente(int idPaciente)
        {
            modelo.eliminarPaciente(idPaciente);
        }

        public void reactivarPaciente(int idPaciente)
        {
            modelo.reactivarPaciente(idPaciente);
        }

        // ============================================================
        // MÉTODOS DE COMPATIBILIDAD HACIA ATRÁS
        // ============================================================

        public Pacientes consultarPacientePorId(int idPaciente)
        {
            return modelo.buscarPacientePorId(idPaciente);
        }

        public Pacientes consultarPaciente(int idUsuario)
        {
            return modelo.buscarPaciente(idUsuario);
        }

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
            modelo.guardarPaciente(
                idUsuario, primerNombre, segundoNombre, primerApellido, segundoApellido,
                cedula, numeroINSS, fechaNacimiento, genero, telefono, idComunidad,
                direccion, tipoSangre, alergias, antecedentes,
                contactoPrimerNombre, contactoSegundoNombre, contactoPrimerApellido,
                contactoSegundoApellido, contactoParentesco, contactoTelefono, contactoCedula);
        }

        public bool editarPaciente(
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
            return modelo.actualizarPaciente(
                idPaciente, primerNombre, segundoNombre, primerApellido, segundoApellido,
                cedula, numeroINSS, fechaNacimiento, genero, telefono, idComunidad,
                direccion, tipoSangre, alergias, antecedentes);
        }
    }
}
