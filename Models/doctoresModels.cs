using System;
using System.Linq;
using SanarRuralUnan.Models;

// Modelo de doctores para la aplicación SanarRuralUnan
// Este modelo representa a un doctor y contiene los métodos para
// crear, consultar, editar y eliminar lógicamente un doctor.
//
// La Vista nunca debe acceder directamente a la base de datos.
// La comunicación debe seguir:
//
// Vista → Controller → Modelo → Base de datos

namespace SanarRuralUnan.Models
{
    public class doctoresModels
    {
        // ============================================================
        // CONEXIÓN A LA BASE DE DATOS
        // ============================================================

        // La conexión a la base de datos solo existe en el Modelo.
        SanarRuralDBEntities db = new SanarRuralDBEntities();


        // ============================================================
        // PROPIEDADES DEL DOCTOR
        // ============================================================

        // Identificador único del doctor.
        // Se genera automáticamente en la base de datos.
        public int IdDoctor { get; set; }

        // Identificador del usuario relacionado con el doctor.
        public int IdUsuario { get; set; }

        // Nombre del doctor.
        public string Nombres { get; set; }

        // Apellidos del doctor.
        public string Apellidos { get; set; }

        // Especialidad médica.
        public string Especialidad { get; set; }

        // Número de licencia o código profesional.
        public string NumeroLicencia { get; set; }

        // Hospital o centro de salud donde trabaja.
        public int IdHospital { get; set; }

        // Estado del doctor.
        // Puede ser Activo o Inactivo.
        public bool Estado { get; set; }


        // ============================================================
        // CONSTRUCTOR VACÍO
        // ============================================================

        public doctoresModels()
        {
        }


        // ============================================================
        // CONSTRUCTOR CON PARÁMETROS
        // ============================================================

        public doctoresModels(
            int idUsuario,
            string nombres,
            string apellidos,
            string especialidad,
            string numeroLicencia,
            int idHospital)
        {
            this.IdUsuario = idUsuario;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Especialidad = especialidad;
            this.NumeroLicencia = numeroLicencia;
            this.IdHospital = idHospital;

            // Todo doctor nuevo comienza activo.
            this.Estado = true;
        }


        // ============================================================
        // CREAR / GUARDAR DOCTOR
        // RF-07
        // ============================================================

        // Crea un nuevo doctor y lo guarda en la base de datos.

        public void guardarDoctor()
        {
            // Crear una nueva entidad Doctor.
            Doctores doctorNuevo = new Doctores();


            // --------------------------------------------------------
            // DATOS DEL DOCTOR
            // --------------------------------------------------------

            doctorNuevo.IdUsuario = IdUsuario;
            doctorNuevo.Nombres = Nombres;
            doctorNuevo.Apellidos = Apellidos;
            doctorNuevo.Especialidad = Especialidad;
            doctorNuevo.NumeroLicencia = NumeroLicencia;
            doctorNuevo.IdHospital = IdHospital;

            // Todo doctor nuevo se crea como Activo.
            doctorNuevo.Estado = true;


            // --------------------------------------------------------
            // GUARDAR EN LA BASE DE DATOS
            // --------------------------------------------------------

            db.Doctores.Add(doctorNuevo);

            db.SaveChanges();
        }


        // ============================================================
        // CONSULTAR DOCTOR
        // RF-09
        // ============================================================

        // Busca un doctor utilizando el IdUsuario.
        //
        // Solo devuelve doctores que estén activos.
        // Los doctores eliminados lógicamente no aparecerán
        // en las consultas normales.

        public Doctores buscarDoctor(int idUsuario)
        {
            return db.Doctores.FirstOrDefault(
                d => d.IdUsuario == idUsuario && d.Estado == true
            );
        }


        // ============================================================
        // EDITAR DOCTOR
        // RF-08
        // ============================================================

        // Actualiza los datos de un doctor existente.
        //
        // Solo se pueden editar doctores que estén activos.

        public void actualizarDoctor(
            int idDoctor,
            string nombres,
            string apellidos,
            string especialidad,
            string numeroLicencia,
            int idHospital)
        {
            // Buscar el doctor por su IdDoctor
            // y verificar que esté activo.
            var doctor = db.Doctores.FirstOrDefault(
                d => d.IdDoctor == idDoctor && d.Estado == true
            );


            // Si existe y está activo, actualizar sus datos.
            if (doctor != null)
            {
                doctor.Nombres = nombres;
                doctor.Apellidos = apellidos;
                doctor.Especialidad = especialidad;
                doctor.NumeroLicencia = numeroLicencia;
                doctor.IdHospital = idHospital;

                // El estado se mantiene como Activo.
                doctor.Estado = true;


                // Guardar cambios.
                db.SaveChanges();
            }
        }


        // ============================================================
        // ELIMINAR DOCTOR
        // RF-10
        // ============================================================

        // Este método realiza una eliminación lógica (soft delete).
        //
        // El registro NO se elimina físicamente de la base de datos.
        //
        // Simplemente cambia:
        //
        // Activo → Inactivo
        //
        // Esto permite conservar el historial del doctor.

        public void eliminarDoctor(int idDoctor)
        {
            // Buscar únicamente un doctor que esté activo.
            var doctor = db.Doctores.FirstOrDefault(
               d => d.IdDoctor == idDoctor && d.Estado == true
            );


            // Si el doctor existe y está activo,
            // cambiar su estado a Inactivo.
            if (doctor != null)
            {
                doctor.Estado = false;

                // Guardar el cambio en la base de datos.
                db.SaveChanges();
            }
        }
    }
}