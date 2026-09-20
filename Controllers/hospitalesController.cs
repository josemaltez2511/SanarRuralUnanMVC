using SanarRuralUnan.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Controller de hospitales para la aplicación SanarRuralUnan
// Este controlador maneja la lógica de negocio relacionada con los hospitales.
// Un controller es responsable de recibir las solicitudes del usuario desde la vista,
// procesarlas entre el modelo y la vista, y devolver la respuesta adecuada al usuario
namespace SanarRuralUnan.Controllers
{


    public class hospitalesController
    {
        // Método para obtener la lista de todos los hospitales registrados en la base de datos
        // Este método llama al método ListarHospitales del modelo hospitalesModel
        // y retorna una lista de objetos hospitalesModel con los registros obtenidos
        // Dependiendo del resultado, la vista puede mostrar los datos en una tabla o lista

        public List<Models.hospitalesModel> ListarHospitales()
        {
            // Instanciamos el objeto del modelo hospitalesModel
            // o sea que estamos creando un objeto de la clase hospitalesModel
            // que se encuentra en el modelo, para poder utilizar sus métodos y propiedades

            Models.hospitalesModel objetoHospital = new Models.hospitalesModel();

            //Retornamos el resultado del método ListarHospitales del modelo
            // que consulta la base de datos y arma la lista de modelos de hospitales

            return objetoHospital.ListarHospitales();
        }

        // Método para verificar si un hospital existe o está activo mediante su Id
        // La Vista llama a este método en vez de consultar la base de datos directamente
        public bool hospitalExiste(int idHospital)
        {
            // Instanciamos el objeto del modelo hospitalesModel
            Models.hospitalesModel objetoHospital = new Models. hospitalesModel();
            // Mandamos a llamar al método ExisteHospital del modelo hospitalesModel
            // que verifica si el hospital con el Id proporcionado existe y está activo
            return objetoHospital.ExisteHospital(idHospital);
        }

        // Método para crear y guardar un nuevo hospital
        // Recibe los datos que la Vista recolectó del formulario (Nombre y Ubicación)
        // y le pasa la orden de guardar al Modelo

        public void GuardarHospital(string nombre, string ubicacion)
        {
            // Instanciamos el objeto del modelo hospitalesModel
            Models.hospitalesModel objetoHospital = new Models.hospitalesModel();
            // Asignamos los valores recibidos a las propiedades del objeto hospital
            objetoHospital.Nombre = nombre;
            objetoHospital.Ubicacion = ubicacion;
            // Ejecutamos el método GuardarHospital del modelo hospitalesModel
            // que crea un nuevo registro en la base de datos con los datos proporcionados


            //asignamos los valores de nombre y ubicacion a la instancia del modelo hospitalesModel
            // le pedimos al modelo que ejecute el método GuardarHospital para guardar el nuevo hospital en la base de datos

            objetoHospital.Nombre = nombre;
            objetoHospital.Ubicacion = ubicacion;

            

        }

            //Metodo para eliminar un hospital de la base de datos, recibe el id del hospital a eliminar y se la pasa al modelo para que ejecute la eliminación

            public void EliminarHospital(int id)
            {
                // Instanciamos el objeto del modelo hospitalesModel
                Models.hospitalesModel objetoHospital = new Models.hospitalesModel();
                // Ejecutamos el método EliminarHospital del modelo hospitalesModel
                // que elimina el registro del hospital con el Id proporcionado de la base de datos
                objetoHospital.EliminarHospital(id);

            // creamos un objeto  de la clase hospitalesModel para acceder a la tabla Hospitales de la base de datos

            hospitalesModel objetohospital = new hospitalesModel();

            // mandamos a llamar al método EliminarHospital del modelo hospitalesModel

            objetohospital.EliminarHospital(id);
        }
    }
}
    
    
    
    
    
       


    




    





    

