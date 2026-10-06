using System.Collections.Generic;
using SanarRuralUnan.Models;

// Controller de hospitales para la aplicación SanarRuralUnan.
// Comunica las vistas con el modelo.

namespace SanarRuralUnan.Controllers
{
    public class hospitalesController
    {
        // Recibe los datos del formulario y solicita al modelo guardar el hospital.
        public void crearHospital(int idMunicipio, string nombre, string direccion, string telefono)
        {
            new hospitalesModels().guardarHospital(idMunicipio, nombre, direccion, telefono);
        }

        // Lista hospitales activos para la vista principal y el selector de Doctores.
        public List<Hospitales> listarHospitales(string busqueda = "")
        {
            return new hospitalesModels().listarHospitales(busqueda);
        }

        public List<Departamentos> listarDepartamentos()
        {
            return new hospitalesModels().listarDepartamentos();
        }

        public List<Municipios> listarMunicipios(int idDepartamento)
        {
            return new hospitalesModels().listarMunicipios(idDepartamento);
        }

        // Busca un hospital activo por su identificador.
        public Hospitales consultarHospital(int idHospital)
        {
            return new hospitalesModels().buscarHospital(idHospital);
        }

        // Actualiza los datos del hospital seleccionado.
        public void editarHospital(int idHospital, int idMunicipio, string nombre, string direccion, string telefono)
        {
            new hospitalesModels().actualizarHospital(idHospital, idMunicipio, nombre, direccion, telefono);
        }

        // Solicita la baja lógica del hospital.
        public void eliminarHospital(int idHospital)
        {
            new hospitalesModels().eliminarHospital(idHospital);
        }
    }
}
