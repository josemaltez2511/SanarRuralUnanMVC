using System.Collections.Generic;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Controllers
{
    public class enfermedadesController
    {
        public bool puedeAdministrarCatalogo()
        {
            return usuariosModels.EsSesionAdministrativa();
        }

        public List<Enfermedades> listarEnfermedades(string busqueda = "")
        {
            return new enfermedadesModels().listarEnfermedades(busqueda);
        }

        public Enfermedades consultarEnfermedad(int idEnfermedad)
        {
            return new enfermedadesModels().buscarEnfermedad(idEnfermedad);
        }

        public void crearEnfermedad(string nombre, string categoria, string descripcion)
        {
            new enfermedadesModels().guardarEnfermedad(nombre, categoria, descripcion);
        }

        public void editarEnfermedad(int idEnfermedad, string nombre, string categoria, string descripcion)
        {
            new enfermedadesModels().actualizarEnfermedad(idEnfermedad, nombre, categoria, descripcion);
        }

        public void darDeBajaEnfermedad(int idEnfermedad)
        {
            new enfermedadesModels().darDeBajaEnfermedad(idEnfermedad);
        }
    }
}
