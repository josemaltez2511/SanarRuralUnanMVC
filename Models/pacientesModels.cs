using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Modelo de paciente para la aplicación SanarRuralUnan
// Este modelo representa a un paciente en la aplicación y contiene los métodos para
// crear, consultar, editar y "eliminar" (de forma lógica) un paciente en la base de datos.
// El modelo es para manejar la lógica de negocio relacionada con los pacientes,
// nunca la Vista debe hablar directo con la base de datos, solo el Modelo.
namespace SanarRuralUnan.Models
{
    public class pacientesModel
    {
        // INICIALIZAR OBJETO DE CONEXIÓN A LA BD
        // (la conexión a la base de datos SOLO debe existir aquí, en el Modelo, nunca en la Vista)
        SanarRuralDBEntities db = new SanarRuralDBEntities();

        // DECLARACIÓN DE LAS PROPIEDADES
        // Estas propiedades son las mismas columnas que tiene la tabla Pacientes en la BD
        // IdPaciente es el identificador único del paciente (se genera solo, no lo llenamos nosotros)
        public int IdPaciente { get; set; }

        // IdUsuario es la llave que conecta este paciente con su cuenta de usuario
        // (la cuenta se crea primero en RF-01, y luego se completa el perfil de paciente aquí)
        public int IdUsuario { get; set; }

        // Nombres y Apellidos del paciente
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        // Fecha de nacimiento del paciente, se usa para calcular la edad si hace falta
        public DateTime FechaNacimiento { get; set; }

        // Genero del paciente (por ejemplo: Masculino, Femenino)
        public string Genero { get; set; }

        // Numero de telefono de contacto del paciente
        public string Telefono { get; set; }

        // Estado del paciente (por ejemplo: Activo, Inactivo)
        public string Estado { get; set; }

        // CONSTRUCTOR VACÍO
        // Se usa cuando queremos crear el objeto e ir llenando las propiedades una por una
        public pacientesModel() { }

        // CONSTRUCTOR CON PARÁMETROS
        // Se usa cuando ya tenemos todos los datos y queremos crear el objeto de una sola vez
        public pacientesModel(int idUsuario, string nombres, string apellidos, DateTime fechaNacimiento, string genero, string telefono)
        {
            this.IdUsuario = idUsuario;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Telefono = telefono;
        }

        // MÉTODO PARA GUARDAR UN PACIENTE NUEVO (esto cumple el RF-03)
        // Este método se llama justo después de haber creado la cuenta de usuario (RF-01),
        // porque el paciente necesita un IdUsuario ya existente para poder registrarse
        public void Guardar()
        {
            // CREAR OBJETO CON LA ENTIDAD PACIENTE DE LA BD
            // esto es como un contrato para definir y verificar si recibimos los mismos datos
            // que requerimos para crear un paciente
            Pacientes pacienteNuevo = new Pacientes();

            // ASIGNAR LOS VALORES DE LAS PROPIEDADES RECIBIDAS
            // A LAS PROPIEDADES DEL OBJETO PACIENTE
            pacienteNuevo.IdUsuario = IdUsuario;
            pacienteNuevo.Nombres = Nombres;
            pacienteNuevo.Apellidos = Apellidos;
            pacienteNuevo.FechaNacimiento = FechaNacimiento;
            pacienteNuevo.Genero = Genero;
            pacienteNuevo.Telefono = Telefono;
            pacienteNuevo.Estado = "Activo";

            // AGREGAR EL OBJETO PACIENTE NUEVO A LA TABLA PACIENTES DE LA BD
            db.Pacientes.Add(pacienteNuevo);

            // GUARDAR LOS CAMBIOS EN LA BD.
            db.SaveChanges();
        }

        // MÉTODO PARA CONSULTAR UN PACIENTE (esto cumple el RF-05)
        // Recibe el IdUsuario (el de la cuenta que inició sesión) y busca su perfil de paciente
        // Usamos FirstOrDefault de LINQ: si encuentra un paciente con ese IdUsuario, lo devuelve;
        // si no encuentra nada, devuelve null (vacío) en vez de dar error
        public Pacientes BuscarPorUsuario(int idUsuario)
        {
            return db.Pacientes.FirstOrDefault(p => p.IdUsuario == idUsuario);
        }

        // MÉTODO PARA EDITAR UN PACIENTE YA EXISTENTE (esto cumple el RF-04)
        // Recibe el IdPaciente de quien se quiere editar, y los nuevos datos que se van a guardar
        public void Actualizar(int idPaciente, string nombres, string apellidos, string genero, string telefono)
        {
            // Buscamos primero el registro del paciente en la BD
            var paciente = db.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);

            // Si lo encontramos, actualizamos sus datos con los valores nuevos
            // Si "paciente" es null (no existe), no hacemos nada, para evitar un error
            if (paciente != null)
            {
                paciente.Nombres = nombres;
                paciente.Apellidos = apellidos;
                paciente.Genero = genero;
                paciente.Telefono = telefono;

                // Guardamos los cambios hechos en el paciente encontrado
                db.SaveChanges();
            }
        }

        // MÉTODO PARA "ELIMINAR" UN PACIENTE SIN BORRARLO DE VERDAD (esto cumple el RF-06, soft delete)
        // "Soft delete" significa que no borramos el registro de la base de datos,
        // solo lo marcamos como "Inactivo" para que deje de aparecer en las consultas normales,
        // pero su información y su historial siguen existiendo por si se necesitan después
        public void EliminarLogico(int idPaciente)
        {
            var paciente = db.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);

            if (paciente != null)
            {
                // IMPORTANTE: esta línea necesita que la tabla Pacientes ya tenga la columna "Estado"
                // (agregada con: ALTER TABLE Pacientes ADD Estado VARCHAR(20) NOT NULL DEFAULT 'Activo')
                paciente.Estado = "Inactivo";

                db.SaveChanges();
            }
        }
    }
}