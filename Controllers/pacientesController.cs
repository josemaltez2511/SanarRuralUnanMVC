using System;
using SanarRuralUnan.Models;
// Controller de pacientes para la aplicación SanarRuralUnan
// Este controlador maneja la lógica de negocio relacionada con los pacientes,
// Un controller es responsable de recibir las solicitudes del usuario desde la vista,
// procesarlas entre el modelo y la vista, y devolver la respuesta adecuada al usuario.
// La Vista NUNCA debe hablar directo con "pacientesModel" ni con la base de datos,
// siempre debe pasar primero por aquí, por el Controller.
namespace SanarRuralUnan.Controllers
{
    public class pacientesController
    {
        // Método para crear un paciente nuevo (RF-03)
        // Recibe todos los datos que la Vista recolectó del formulario
        // Este método instancia el Modelo, le llena las propiedades, y le pide que se guarde
        public void crearPaciente(int idUsuario, string nombres, string apellidos, DateTime fechaNacimiento, string genero, string telefono)
        {
            // Instanciamos el objeto del modelo pacientesModel
            // o sea que estamos creando un objeto de la clase pacientesModel
            // que se encuentra en el modelo, para poder utilizar sus métodos y propiedades
            pacientesModel objetoPaciente = new pacientesModel();

            // Le asignamos al objeto los datos que llegaron desde la Vista
            objetoPaciente.IdUsuario = idUsuario;
            objetoPaciente.Nombres = nombres;
            objetoPaciente.Apellidos = apellidos;
            objetoPaciente.FechaNacimiento = fechaNacimiento;
            objetoPaciente.Genero = genero;
            objetoPaciente.Telefono = telefono;

            // Le pedimos al Modelo que guarde este paciente en la base de datos
            objetoPaciente.guardarPaciente();
        }

        // Método para consultar los datos de un paciente (RF-05)
        // Recibe el IdUsuario y retorna el objeto Paciente encontrado (o null si no existe)
        // La Vista usa este dato para mostrarlo en pantalla
        public Pacientes consultarPaciente(int idUsuario)
        {
            pacientesModel objetoPaciente = new pacientesModel();
            return objetoPaciente.buscarPaciente(idUsuario);
        }

        // Método para editar los datos de un paciente (RF-04)
        // Recibe el IdPaciente a modificar y los nuevos valores de cada campo
        public void editarPaciente(int idPaciente, string nombres, string apellidos, string genero, string telefono)
        {
            pacientesModel objetoPaciente = new pacientesModel();
            objetoPaciente.actualizarPaciente(idPaciente, nombres, apellidos, genero, telefono);
        }

        // Método para dar de baja a un paciente sin borrar su historial (RF-06)
        // Es void porque no necesitamos que devuelva nada, solo que haga el cambio
        public void eliminarPaciente(int idPaciente)
        {
            pacientesModel objetoPaciente = new pacientesModel();
            objetoPaciente.eliminarPaciente(idPaciente);
        }
    }
}