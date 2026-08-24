using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Modelo de usuario para la aplicación SanarRuralUnan
// Este modelo representa un usuario en la aplicación y contiene métodos para guardar un usuario,
// El modelo es para manejar la lógica de negocio relacionada con los usuarios,
// como guardar un nuevo usuario en la base de datos

namespace SanarRuralUnan.Models
{
    public class usuarios
    {
        // INICIALIZAR OBJETO DE CONEXIÓN A LA BD
        SanarRuralDBEntities db = new SanarRuralDBEntities();

        // DECLARACIÓN DE LAS PROPIEDADES (CORREO, CONTRASENA, ESTADO)
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; } 
        public string usuarioActual { get; private set; }

        // CONSTRUCTOR VACÍO
        public usuarios() { }

        // CONSTRUCTOR CON PARÁMETROS
        public usuarios(string correo, string contrasena, DateTime fechaRegistro, string estado)
        {
            this.Correo = correo;
            this.Contrasena = contrasena;
            this.FechaRegistro = fechaRegistro;
            this.Estado = estado;
        }

        // MÉTODO PARA GUARDAR UN USUARIO
        public void Guardar()
        {
            // CREAR OBJETO CON LA ENTIDAD USUARIO DE LA BD
            Usuario usuarioNuevo = new Usuario();

            // ASIGNAR LOS VALORES DE LAS PROPIEDADES RECIBIDAS
            // A LAS PROPIEDADES DEL OBJETO USUARIO
            usuarioNuevo.Correo = Correo;
            usuarioNuevo.Contrasena = Contrasena;
            usuarioNuevo.FechaRegistro = FechaRegistro; // Asignamos la fecha y hora actual del sistema
            usuarioNuevo.Estado = Estado;

            // AGREGAR EL OBJETO USUARIO NUEVO A LA TABLA USUARIOS DE LA BD
            db.Usuarios.Add(usuarioNuevo);

            // GUARDAR LOS CAMBIOS EN LA BD
            db.SaveChanges();
        }

        // MÉTODO PARA INICIAR SESIÓN
        public bool IniciarSesion(string correo, string contrasena)
        {
            // BUSCAR EL USUARIO EN LA BD CON EL CORREO Y CONTRASEÑA PROPORCIONADOS
            // USAMOS CONSULTA DE LINQ PARA OBTENER EL PRIMER USUARIO QUE COINCIDA CON LOS DATOS INGRESADOS
            var consultarUsuario = db.Usuarios.FirstOrDefault(u => u.Correo == correo && u.Contrasena == contrasena);

            //FirstOrDefault es una consulta de LINQ, significa que si no encuentra ningún usuario
            //que coincida con los datos ingresados, devolverá null.
            //Por lo tanto, si la variable "consultarUsuario" es null, significa que no se encontró
            //ningún usuario con esos datos y la función devuelve false.
            //Si se encuentra un usuario, se asigna el correo del usuario actual y se devuelve true.

            // Verificamos el resultado de la consulta 
            // Si no se encuentra ningún usuario, retornamos false
            if (consultarUsuario == null)
                return false;

            // Si se encuentra un usuario,
            // asignamos el correo del usuario actual
            // y retornamos true
            usuarioActual = correo;

            //  O sea que si el usuario existe,
            //  se asigna el correo del usuario a la sesion actual
            //  y se devuelve true.
            return true;
        }

        // MÉTODO CERRAR SESIÓN
        public void CerrarSesion()
        {
            usuarioActual = null;
        }
    }
}