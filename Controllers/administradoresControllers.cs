using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    /// <summary>
    /// Controlador del módulo de Administradores.
    /// Orquesta la comunicación entre la capa de Vista y el Modelo respetando el patrón MVC informal.
    /// Exclusivo para usuarios con rol 'Admin'.
    /// </summary>
    public class administradoresControllers
    {
        private readonly administradoresModels modelo = new administradoresModels();

        public List<AdministradorItemDto> ListarAdministradores(string busqueda = "", string filtroEstado = "Todos")
        {
            return modelo.ListarAdministradores(busqueda, filtroEstado);
        }

        public AdministradorDetalleDto ObtenerDetalle(int idAdministrador)
        {
            return modelo.ObtenerDetalle(idAdministrador);
        }

        public Administradores ObtenerPorId(int idAdministrador)
        {
            return modelo.ObtenerPorId(idAdministrador);
        }

        public void Guardar(
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo)
        {
            modelo.Guardar(primerNombre, segundoNombre, primerApellido, segundoApellido, cedula, telefono, correo);
        }

        public void Actualizar(
            int idAdministrador,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string telefono,
            string correo)
        {
            modelo.Actualizar(idAdministrador, primerNombre, segundoNombre, primerApellido, segundoApellido, cedula, telefono, correo);
        }

        public void DarDeBaja(int idAdministrador)
        {
            modelo.CambiarEstado(idAdministrador, false);
        }

        public void Reactivar(int idAdministrador)
        {
            modelo.CambiarEstado(idAdministrador, true);
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
