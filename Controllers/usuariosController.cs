using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        // y retorna un valor booleano indicando si el inicio de sesión fue exitoso o no
        // Dependiendo del resultado, la vista puede mostrar un mensaje de error
        // o redirigir al usuario a la página principal
        public bool IniciarSesion(string correo, string contrasena)
        {
            // Instanciamos el objeto del modelo usuarios
            // o sea que estamos creando un objeto de la clase usuarios
            // que se encuentra en el modelo, para poder utilizar sus métodos y propiedades
            usuariosModel objetoUsuario = new usuariosModel();
            // Retornamos el resultado del método IniciarSesion del modelo
            // que verifica si el correo y la contraseña son correctos
            return objetoUsuario.IniciarSesion(correo, contrasena);
        }

        // Método para cerrar sesión que no requiere parámetros y es void
        // porque simplemente elimina la información de la sesión del usuario, y no retorna nada
        // Este método llama al método CerrarSesion del modelo usuarios
        // y muestra un mensaje de confirmación al usuario indicando que la sesión ha sido cerrada
        // Dependiendo del resultado, la vista puede redirigir al usuario a la página de inicio de sesión
        public void CerrarSesion()
        {
            // Instanciamos el objeto del modelo usuarios
            // o sea que estamos creando un objeto de la clase usuarios 
            // que se encuentra en el modelo, para poder utilizar sus métodos y propiedades
            usuariosModel objetoUsuario = new usuariosModel();

            // Ejecutamos el método CerrarSesion del modelo
            // que elimina la información de la sesión del usuario
            objetoUsuario.CerrarSesion();
        }

        // Método para saber si un correo ya está registrado
        // La Vista llama a este método en vez de consultar la base de datos directamente
        public bool CorreoYaExiste(string correo)
        {
            // creamos nuevo objeto de la clase usuario para acceder a la tabla Usuarios de la base de datos
            usuariosModel objetoUsuario = new usuariosModel();

            // mandamos a llamar a la clase ExisteCorreo del modelo usuarios
            // la cual cumple con la funcion de validar si existe el correo
            // le pasamos como parametro el correo ingresado por el usuario
            return objetoUsuario.ExisteCorreo(correo);
        }

        // Método para crear un nuevo usuario
        // Recibe los datos que la Vista recolectó del formulario
        // y le pasa la orden de guardar al Modelo
        // Retorna true si se pudo crear, false si el correo ya existía
        public bool CrearUsuario(string correo, string contrasena)
        {
            // creamos nuevo objeto de la clase usuario para acceder a la tabla Usuarios de la base de datos
            usuariosModel objetoUsuario = new usuariosModel();

            // Verificamos primero que el correo no esté repetido
            if (objetoUsuario.ExisteCorreo(correo))
            {
                return false;
            }

            // Armamos los datos del nuevo usuario
            objetoUsuario.Correo = correo;
            objetoUsuario.Contrasena = contrasena;
            objetoUsuario.FechaRegistro = DateTime.Now;
            objetoUsuario.Estado = "Activo";

            // Le pedimos al Modelo que lo guarde en la base de datos
            objetoUsuario.Guardar();

            return true;
        }
    }
}