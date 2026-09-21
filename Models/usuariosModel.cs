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
    public class usuariosModel
    {
        // ESTE COMENTARIO LO HIZO ETHER 
        // El modelo de usuario es una clase que representa un usuario en la aplicación
        // INICIALIZAR OBJETO DE CONEXIÓN A LA BD
        // (la conexión a la base de datos SOLO debe existir aquí, en el Modelo, nunca en la Vista)

        SanarRuralDBEntities db = new SanarRuralDBEntities();

        // DECLARACIÓN DE LAS PROPIEDADES (CORREO, CONTRASENA, ESTADO)

        // Hola, cambio realizado por Esther
        // estamos aprendiendo a usar github



        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string usuarioActual { get; private set; }

        // CONSTRUCTOR VACÍO
        public usuariosModel() { }

        // CONSTRUCTOR CON PARÁMETROS
        public usuariosModel(string correo, string contrasena, DateTime fechaRegistro, string estado)
        {
            this.Correo = correo;
            this.Contrasena = contrasena;
            this.FechaRegistro = fechaRegistro;
            this.Estado = estado;
        }

        // MÉTODO PARA VERIFICAR SI UN CORREO YA EXISTE EN LA BD
        // esto lo usa el Controller para validar antes de crear o mientras el usuario escribe
        // devuelve true si el correo ya está registrado, false si está libre
        public bool ExisteCorreo(string correo)
        {

            try
            {
                return db.Usuarios.Any(u => u.Correo == correo);
            }
            catch
            {
                // si algo falla al consultar la BD, asumimos que no podemos confirmar
                // y devolvemos false para no bloquear al usuario por un error de conexión
                return false;
            }
        }

        // MÉTODO PARA GUARDAR UN USUARIO
        // CAMBIO: antes este método era "void" (no devolvía nada).
        // Ahora es "int" y devuelve el IdUsuario que la base de datos generó automáticamente,
        // porque lo necesitamos para poder crear después el Paciente o el Doctor
        // asociado a esta misma cuenta (RF-02, RF-03, RF-07).
        public int Guardar()
        {

            // CREAR OBJETO CON LA ENTIDAD USUARIO DE LA BD
            // esto es como un contrato para definir y verificar si recibimos los mismos datos
            // que requerimos para crear un usuario 
            Usuarios usuarioNuevo = new Usuarios();


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

            // IMPORTANTE: después de db.SaveChanges(), Entity Framework ya conoce
            // el IdUsuario que la base de datos generó automáticamente (autoincremental)
            // y lo escribe de vuelta en el objeto "usuarioNuevo". Por eso ya lo podemos leer aquí.
            return usuarioNuevo.IdUsuario;
        }


        // MÉTODO PARA INICIAR SESIÓN
        // este metodo (funcion) es de tipo Bool (verdadero o falso)
        // porque solo necesitamos verificar si es verdadero que el usuario ya existe en la base de datos
        // o si es falso y no tenemos registros
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