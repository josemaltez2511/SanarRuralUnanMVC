using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

// Modelo de hospital para la aplicación SanarRuralUnan.
// La Vista utiliza estos métodos para consultar y guardar hospitales.

namespace SanarRuralUnan.Models
{
    public class hospitalesModels
    {
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // Crea el hospital activo asociado al municipio seleccionado.
        public void guardarHospital(int idMunicipio, string nombre, string direccion, string telefono)
        {
            Hospitales hospital = new Hospitales
            {
                IdMunicipio = idMunicipio,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Estado = true
            };

            db.Hospitales.Add(hospital);
            db.SaveChanges();
        }

        // Devuelve hospitales activos con sus datos de municipio y departamento.
        // El listado también se utiliza para seleccionar hospitales desde Doctores.
        public List<Hospitales> listarHospitales(string busqueda = "")
        {
            IQueryable<Hospitales> consulta = db.Hospitales
                .Include(h => h.Municipios.Departamentos)
                .Where(h => h.Estado);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string filtro = busqueda.Trim();
                consulta = consulta.Where(h =>
                    h.Nombre.Contains(filtro) ||
                    h.Telefono.Contains(filtro) ||
                    h.Municipios.Nombre.Contains(filtro) ||
                    h.Municipios.Departamentos.Nombre.Contains(filtro));
            }

            return consulta.OrderBy(h => h.Nombre).ToList();
        }

        public List<Departamentos> listarDepartamentos()
        {
            return db.Departamentos.OrderBy(d => d.Nombre).ToList();
        }

        public List<Municipios> listarMunicipios(int idDepartamento)
        {
            return db.Municipios
                .Where(m => m.IdDepartamento == idDepartamento)
                .OrderBy(m => m.Nombre)
                .ToList();
        }

        // Busca un hospital activo por su identificador.
        public Hospitales buscarHospital(int idHospital)
        {
            return db.Hospitales
                .Include(h => h.Municipios.Departamentos)
                .FirstOrDefault(h => h.IdHospital == idHospital && h.Estado);
        }

        // Actualiza los datos del hospital sin alterar sus relaciones históricas.
        public void actualizarHospital(int idHospital, int idMunicipio, string nombre, string direccion, string telefono)
        {
            Hospitales hospital = db.Hospitales.FirstOrDefault(h => h.IdHospital == idHospital && h.Estado);

            if (hospital == null) return;

            hospital.IdMunicipio = idMunicipio;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            db.SaveChanges();
        }

        // Baja lógica para conservar las referencias de doctores y citas.
        public void eliminarHospital(int idHospital)
        {
            Hospitales hospital = db.Hospitales.FirstOrDefault(h => h.IdHospital == idHospital && h.Estado);

            if (hospital == null) return;

            hospital.Estado = false;
            db.SaveChanges();
        }
    }
}
