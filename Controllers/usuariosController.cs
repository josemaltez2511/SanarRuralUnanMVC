using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanarRuralUnan.Models;

// Controller de usuarios para la aplicación SanarRuralUnan
// Este controlador maneja la lógica de negocio relacionada con los usuarios,
// Un controller es responsable de recibir las solicitudes del usuario,
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
            usuarios objetoUsuario = new usuarios();

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
            usuarios objetoUsuario = new usuarios();

            // Ejecutamos el método CerrarSesion del modelo
            // que elimina la información de la sesión del usuario
            objetoUsuario.CerrarSesion();
        }
    }
}