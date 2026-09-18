using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanarRuralUnan.Models
{
    public class hospitalesModel
    {
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

        //METODO PARA VERIFICAR SI EL HOSPITAL ESTA ACTIVO 

        public bool ExisteHospital(int id)
        {
            return this.Estado;
        }   
        // METODO PARA GUARDAR UN HOSPITAL

        public void GuardarHospital(int id) 
        {
            //CREAR UN OBJETO CON LA ENTIDAD HOSPITALES DE LA BD
            // esto es como un contrato para definir y verificar si recibimos los mismos datos
            // que requerimos para crear un hospital

            Hospital  hospitalnuevo = new Hospital();

            // ASIGNAR LOS VALORES DE LAS PROPIEDADES RECIBIDAS
            // A LAS PROPIEDADES DEL OBJETO HOSPITAL

            hospitalnuevo.IdHospital = IdHospital;
            hospitalnuevo.Nombre = Nombre;
            hospitalnuevo.Ubicacion = Ubicacion;
            this.Estado = false;


            // AGREGAR EL OBJETO HOSPITAL NUEVO A LA TABLA USUARIOS DE LA BD

            db.Hospitales.Add(hospitalnuevo);

            // GUARDAR LOS CAMBIOS EN LA BD
            db.saveChanges();

            // metodo para editar un hospital

            public void EditarHospital(int id)
            {
                //BUSCAR EL HOSPITAL POR SU ID
                Hospital hospitalExistente = db.Hospitales.Find(id);
                //VERIFICAR SI EL HOSPITAL EXISTE
                if (hospitalExistente != null)
                {
                    //ACTUALIZAR LOS VALORES DEL HOSPITAL EXISTENTE
                    hospitalExistente.Nombre = Nombre;
                    hospitalExistente.Ubicacion = Ubicacion;
                    //GUARDAR LOS CAMBIOS EN LA BD
                    db.saveChanges();
                }
        }

        // metodo para listar los hospitales

        public List<hospitalesModel> ListarHospitales()
        {
            //OBTENER LA LISTA DE HOSPITALES DE LA BD
            var hospitales = db.Hospitales.ToList();
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
            Hospital hospitalExistente = db.Hospitales.Find(id);
            //VERIFICAR SI EL HOSPITAL EXISTE
            if (hospitalExistente != null)
            {
                //ELIMINAR EL HOSPITAL DE LA BD
                db.Hospitales.Remove(hospitalExistente);
                //GUARDAR LOS CAMBIOS EN LA BD
                db.saveChanges();
            }
        }

    }
