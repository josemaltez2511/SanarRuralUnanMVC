using System;
using System.Linq;

// Modelo de paciente para la aplicación SanarRuralUnan
// Este modelo representa a un paciente en la aplicación y contiene los métodos para
// crear, consultar, editar y "eliminar" (de forma lógica) un paciente en la base de datos.
// El modelo maneja la lógica de negocio relacionada con los pacientes.
// La Vista nunca debe hablar directamente con la base de datos; solo el Modelo.

namespace SanarRuralUnan.Models
{
    public class pacientesModel
    {
        // ============================================================
        // CONEXIÓN A LA BASE DE DATOS
        // ============================================================

        // La conexión a la BD solo existe en el Modelo.
        SanarRuralDBEntities db = new SanarRuralDBEntities();


        // ============================================================
        // PROPIEDADES DEL PACIENTE
        // ============================================================

        // Identificador único del paciente.
        // Se genera automáticamente en la base de datos.
        public int IdPaciente { get; set; }

        // Identificador del usuario relacionado con este paciente.
        public int IdUsuario { get; set; }


        // ============================================================
        // DATOS PERSONALES
        // ============================================================

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string Telefono { get; set; }


        // ============================================================
        // DATOS DE UBICACIÓN
        // ============================================================

        public string Departamento { get; set; }

        public string Municipio { get; set; }

        public string Comunidad { get; set; }

        public string Direccion { get; set; }


        // ============================================================
        // INFORMACIÓN DE SALUD
        // ============================================================

        public string ContactoEmergencia { get; set; }

        public string TipoSangre { get; set; }

        public string Alergias { get; set; }

        public string Antecedentes { get; set; }


        // ============================================================
        // ESTADO DEL PACIENTE
        // ============================================================

        // Ejemplo:
        // "Activo"
        // "Inactivo"
        //
        // Se utiliza para realizar el soft delete.
        public string Estado { get; set; }


        // ============================================================
        // CONSTRUCTOR VACÍO
        // ============================================================

        // Permite crear un objeto y llenar sus propiedades
        // individualmente.

        public pacientesModel()
        {
        }


        // ============================================================
        // CONSTRUCTOR CON PARÁMETROS
        // ============================================================

        // Permite crear un paciente con todos sus datos.

        public pacientesModel(
            int idUsuario,
            string nombres,
            string apellidos,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            string departamento,
            string municipio,
            string comunidad,
            string direccion,
            string contactoEmergencia,
            string tipoSangre,
            string alergias,
            string antecedentes)
        {
            this.IdUsuario = idUsuario;

            // Datos personales
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Telefono = telefono;

            // Ubicación
            this.Departamento = departamento;
            this.Municipio = municipio;
            this.Comunidad = comunidad;
            this.Direccion = direccion;

            // Información de salud
            this.ContactoEmergencia = contactoEmergencia;
            this.TipoSangre = tipoSangre;
            this.Alergias = alergias;
            this.Antecedentes = antecedentes;
        }


        // ============================================================
        // CREAR / GUARDAR PACIENTE
        // RF-03
        // ============================================================

        // Crea un nuevo paciente y lo guarda en la base de datos.

        public void guardarPaciente()
        {
            // Crear una nueva entidad Pacientes.
            Pacientes pacienteNuevo = new Pacientes();


            // --------------------------------------------------------
            // DATOS PERSONALES
            // --------------------------------------------------------

            pacienteNuevo.IdUsuario = IdUsuario;
            pacienteNuevo.Nombres = Nombres;
            pacienteNuevo.Apellidos = Apellidos;
            pacienteNuevo.FechaNacimiento = FechaNacimiento;
            pacienteNuevo.Genero = Genero;
            pacienteNuevo.Telefono = Telefono;


            // --------------------------------------------------------
            // DATOS DE UBICACIÓN
            // --------------------------------------------------------

            pacienteNuevo.Departamento = Departamento;
            pacienteNuevo.Municipio = Municipio;
            pacienteNuevo.Comunidad = Comunidad;
            pacienteNuevo.Direccion = Direccion;


            // --------------------------------------------------------
            // INFORMACIÓN DE SALUD
            // --------------------------------------------------------

            pacienteNuevo.ContactoEmergencia = ContactoEmergencia;
            pacienteNuevo.TipoSangre = TipoSangre;
            pacienteNuevo.Alergias = Alergias;
            pacienteNuevo.Antecedentes = Antecedentes;


            // --------------------------------------------------------
            // ESTADO INICIAL
            // --------------------------------------------------------

            // Todo paciente nuevo comienza como Activo.
            pacienteNuevo.Estado = "Activo";


            // --------------------------------------------------------
            // GUARDAR EN LA BASE DE DATOS
            // --------------------------------------------------------

            db.Pacientes.Add(pacienteNuevo);

            db.SaveChanges();
        }


        // ============================================================
        // CONSULTAR PACIENTE
        // RF-05
        // ============================================================

        // Busca un paciente mediante el IdUsuario.
        //
        // Solo devuelve pacientes activos.
        //
        // Los pacientes eliminados lógicamente permanecen
        // en la base de datos, pero no aparecen en las
        // consultas normales.

        public Pacientes buscarPaciente(int idUsuario)
        {
            return db.Pacientes.FirstOrDefault(
                p => p.IdUsuario == idUsuario &&
                     p.Estado == "Activo"
            );
        }


        // ============================================================
        // EDITAR PACIENTE
        // RF-04
        // ============================================================

        // Actualiza todos los datos del paciente.

        public void actualizarPaciente(
            int idPaciente,
            string nombres,
            string apellidos,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            string departamento,
            string municipio,
            string comunidad,
            string direccion,
            string contactoEmergencia,
            string tipoSangre,
            string alergias,
            string antecedentes)
        {
            // Buscar el paciente mediante su IdPaciente.
            var paciente = db.Pacientes.FirstOrDefault(
                p => p.IdPaciente == idPaciente
            );


            // Si el paciente existe, actualizar sus datos.
            if (paciente != null)
            {
                // ----------------------------------------------------
                // DATOS PERSONALES
                // ----------------------------------------------------

                paciente.Nombres = nombres;
                paciente.Apellidos = apellidos;
                paciente.FechaNacimiento = fechaNacimiento;
                paciente.Genero = genero;
                paciente.Telefono = telefono;


                // ----------------------------------------------------
                // DATOS DE UBICACIÓN
                // ----------------------------------------------------

                paciente.Departamento = departamento;
                paciente.Municipio = municipio;
                paciente.Comunidad = comunidad;
                paciente.Direccion = direccion;


                // ----------------------------------------------------
                // INFORMACIÓN DE SALUD
                // ----------------------------------------------------

                paciente.ContactoEmergencia = contactoEmergencia;
                paciente.TipoSangre = tipoSangre;
                paciente.Alergias = alergias;
                paciente.Antecedentes = antecedentes;


                // ----------------------------------------------------
                // GUARDAR CAMBIOS
                // ----------------------------------------------------

                db.SaveChanges();
            }
        }


        // ============================================================
        // ELIMINAR PACIENTE
        // RF-06
        // ============================================================

        // Soft delete.
        //
        // NO elimina físicamente el paciente de la base de datos.
        //
        // Solamente cambia:
        //
        // Activo → Inactivo
        //
        // De esta manera se conserva el historial del paciente.

        public void eliminarPaciente(int idPaciente)
        {
            // Buscar el paciente.
            var paciente = db.Pacientes.FirstOrDefault(
                p => p.IdPaciente == idPaciente
            );


            // Si el paciente existe...
            if (paciente != null)
            {
                // Marcar como inactivo.
                paciente.Estado = "Inactivo";


                // Guardar cambios.
                db.SaveChanges();
            }
        }
    }
}