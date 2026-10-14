using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    /// <summary>
    /// Controlador del módulo de Personal Administrativo.
    /// Orquesta la comunicación entre la capa de Vista y el Modelo respetando el patrón MVC informal.
    /// Exclusivo para usuarios con rol 'Admin'.
    /// </summary>
    public class personalAdministrativoControllers
    {
        private readonly personalAdministrativoModels modelo = new personalAdministrativoModels();

        public List<PersonalAdministrativoItemDto> ListarPersonal(string busqueda = "", string filtroEstado = "Todos")
        {
            return modelo.ListarPersonal(busqueda, filtroEstado);
        }

        public PersonalAdministrativoDetalleDto ObtenerDetalle(int idPersonal)
        {
            return modelo.ObtenerDetalle(idPersonal);
        }

        public PersonalAdministrativo ObtenerPorId(int idPersonal)
        {
            return modelo.ObtenerPorId(idPersonal);
        }

        public void Guardar(
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo,
            string cargo)
        {
            modelo.Guardar(primerNombre, segundoNombre, primerApellido, segundoApellido, cedula, telefono, correo, cargo);
        }

        public void Actualizar(
            int idPersonal,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo,
            string cargo)
        {
            modelo.Actualizar(idPersonal, primerNombre, segundoNombre, primerApellido, segundoApellido, cedula, telefono, correo, cargo);
        }

        public void DarDeBaja(int idPersonal)
        {
            modelo.CambiarEstado(idPersonal, false);
        }

        public void Reactivar(int idPersonal)
        {
            modelo.CambiarEstado(idPersonal, true);
        }

        public bool ExisteCedula(string cedula, int? idExcluir = null)
        {
            return modelo.ExisteCedula(cedula, idExcluir);
        }

        public bool EsAdmin()
        {
            return usuariosModels.EsSesionAdmin();
        }
    }
}
