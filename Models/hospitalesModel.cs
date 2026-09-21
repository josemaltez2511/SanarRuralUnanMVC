using System;
using System.Collections.Generic;
using System.Linq;

namespace SanarRuralUnan.Models
{
    public class hospitalesModel
    {
        private DatabaseContext db; // Replace 'object' with the actual type 'DatabaseContext'

        public int IdHospital { get; set; }

        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

        public bool Estado { get; set; }

        // CONSTRUCTOR VACIO 
        public hospitalesModel() { }

        // CONSTRUCTOR CON PARAMETROS 
        public hospitalesModel(int IdHospital, string Nombre, string Ubicacion)
        {
            this.Estado = true;
            this.Nombre = Nombre;
            this.Ubicacion = Ubicacion;
        }

        // METODO PARA VERIFICAR SI EL HOSPITAL ESTA ACTIVO 
        public bool ExisteHospital(int id)
        {
            return this.Estado;
        }

        // METODO PARA GUARDAR UN HOSPITAL
        public void guardarHospital(string nombre, string ubicacion)
        {
            // CREAR UNA NUEVA INSTANCIA DEL HOSPITAL
            var hospitalnuevo = new hospitalesModel();

            // ASIGNAR LOS VALORES DE LAS PROPIEDADES RECIBIDAS
            hospitalnuevo.Nombre = nombre;
            hospitalnuevo.Ubicacion = ubicacion;
            hospitalnuevo.Estado = true;

            // AGREGAR EL OBJETO HOSPITAL NUEVO A LA TABLA HOSPITALES DE LA BD
            db.HospitalesModel.Add(hospitalnuevo);

            // GUARDAR LOS CAMBIOS EN LA BD
            db.SaveChanges();
        }

        // metodo para editar un hospital
        public void editarHospital(int id)
        {
            //BUSCAR EL HOSPITAL POR SU ID
            hospitalesModel hospitalExistente = db.Hospitales.Find(id);
            //VERIFICAR SI EL HOSPITAL EXISTE
            if (hospitalExistente != null)
            {
                //ACTUALIZAR LOS VALORES DEL HOSPITAL EXISTENTE
                hospitalExistente.Nombre = Nombre;
                hospitalExistente.Ubicacion = Ubicacion;
                //GUARDAR LOS CAMBIOS EN LA BD
                db.SaveChanges();
            }
        }

        // metodo para listar los hospitales
        public List<hospitalesModel> ListarHospitales()
        {
            //OBTENER LA LISTA DE HOSPITALES DE LA BD
            var hospitales = db.HospitalesModel.ToList();
            //CREAR UNA LISTA DE MODELOS DE HOSPITALES
            List<hospitalesModel> listaHospitales = new List<hospitalesModel>();
            //RECORRER CADA HOSPITAL Y AGREGARLO A LA LISTA DE MODELOS
            foreach (var hospital in hospitales)
            {
                listaHospitales.Add(new hospitalesModel
                {
                    IdHospital = hospital.IdHospital,
                    Nombre = hospital.Nombre,
                    Ubicacion = hospital.Ubicacion,
                    Estado = hospital.Estado
                });
            }
            return listaHospitales;
        }

        //metodo para eliminar un hospital
        public void EliminarHospital(int id)
        {
            //BUSCAR EL HOSPITAL POR SU ID
            hospitalesModel hospitalExistente = db.Hospitales.Find(id);

            //VERIFICAR SI EL HOSPITAL EXISTE
            if (hospitalExistente != null)
            {
                //ELIMINAR EL HOSPITAL DE LA BD
                db.Hospitales.Remove(hospitalExistente);
                //GUARDAR LOS CAMBIOS EN LA BD
                db.SaveChanges();
            }
        }
    }

    // Assuming DatabaseContext is the actual type for 'db'
    public class DatabaseContext
    {
        public DbSet<hospitalesModel> HospitalesModel { get; set; }
        public DbSet<hospitalesModel> Hospitales { get; set; }

        public void SaveChanges() { }
    }

    public class DbSet<T>
    {
        public void Add(T entity) { }
        public T Find(int id) => default;
        public void Remove(T entity) { }
        public List<T> ToList() => new List<T>();
    }
}
