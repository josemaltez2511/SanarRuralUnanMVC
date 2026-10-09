using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

// Controller de usuarios para la aplicación SanarRuralUnan
// Este controlador maneja la lógica de negocio relacionada con los usuarios,
// Un controller es responsable de recibir las solicitudes del usuario desde la vista,
// procesarlas entre el modelo y la vista, y devolver la respuesta adecuada al usuario.
namespace SanarRuralUnan.Controllers
{
    public class usuariosControllers
    {
        // Método para iniciar sesión con sus parámetros de correo y contraseña
        // para verificar si el usuario existe y si la contraseña es correcta
        // Este método llama al método IniciarSesion del modelo usuarios
        // y retorna un valor entero indicando si el inicio de sesión fue exitoso y su rol
        // Dependiendo del resultado, la vista puede mostrar un mensaje de error
        // o redirigir al usuario a la página principal
        public int IniciarSesion(string correo, string contrasena)
        {
            return new usuariosModels().IniciarSesion(correo, contrasena);
        }

        public void CerrarSesion()
        {
            new usuariosModels().CerrarSesion();
        }

        // Obtiene el identificador del médico asociado al usuario en sesión.
        public int? ObtenerIdDoctorActual()
        {
            return new usuariosModels().ObtenerIdDoctorActual();
        }

        // Obtiene el identificador del paciente asociado al usuario en sesión.
        public int? ObtenerIdPacienteActual()
        {
            return new usuariosModels().ObtenerIdPacienteActual();
        }

        // Método para saber si un correo ya está registrado
        // La Vista llama a este método en vez de consultar la base de datos directamente
        public bool CorreoYaExiste(string correo, int? idUsuarioExcluir = null)
        {
            return new usuariosModels().ExisteCorreo(correo, idUsuarioExcluir);
        }

        public List<Roles> ListarRoles()
        {
            return new usuariosModels().ListarRoles();
        }

        public int ObtenerIdRol(string nombre)
        {
            return new usuariosModels().ObtenerIdRol(nombre);
        }

        public List<Usuarios> ListarUsuarios(string filtro = "")
        {
            return new usuariosModels().ListarUsuarios(filtro);
        }

        public Usuarios ConsultarUsuario(int idUsuario)
        {
            return new usuariosModels().ConsultarUsuario(idUsuario);
        }

        // Método para crear un nuevo usuario
        // Recibe los datos que la Vista recolectó del formulario
        // y le pasa la orden de guardar al Modelo
        public int CrearUsuario(string correo, string contrasena)
        {
            int idRolPaciente = ObtenerIdRol("Paciente");
            return CrearUsuario(idRolPaciente, correo, contrasena);
        }

        public int CrearUsuario(int idRol, string correo, string contrasena)
        {
            usuariosModels modelo = new usuariosModels();
            if (idRol <= 0 || modelo.ExisteCorreo(correo))
                return -1;

            return modelo.Guardar(idRol, correo, contrasena);
        }

        public bool EditarUsuario(int idUsuario, int idRol, string correo, string nuevaContrasena)
        {
            usuariosModels modelo = new usuariosModels();
            if (modelo.ExisteCorreo(correo, idUsuario))
                return false;

            return modelo.Actualizar(idUsuario, idRol, correo, nuevaContrasena);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            return new usuariosModels().DarDeBaja(idUsuario);
        }
    }
}
