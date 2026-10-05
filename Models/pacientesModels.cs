using System;
using System.Collections.Generic;
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
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ============================================================
        // PROPIEDADES DEL PACIENTE
        // ============================================================

        // Identificador único del paciente.
        // Se genera automáticamente en la base de datos.
        public int IdPaciente { get; set; }

        // Identificador opcional del usuario relacionado con este paciente.
        public int? IdUsuario { get; set; }

        // ============================================================
        // DATOS PERSONALES
        // ============================================================

        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string NumeroINSS { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        // ============================================================
        // DATOS DE UBICACIÓN
        // ============================================================

        public int IdComunidad { get; set; }
        public string Direccion { get; set; }

        // ============================================================
        // INFORMACIÓN DE SALUD
        // ============================================================

        public string TipoSangre { get; set; }
        public string Alergias { get; set; }
        public string Antecedentes { get; set; }

        // ============================================================
        // ESTADO DEL PACIENTE
        // ============================================================

        // true  -> Activo
        // false -> Inactivo
        // Se utiliza para realizar el soft delete.
        public bool Estado { get; set; }

        // ============================================================
        // CONSULTAS DE UBICACIÓN
        // ============================================================

        // Devuelve las ubicaciones disponibles para los ComboBox del formulario.
        public List<Departamentos> listarDepartamentos()
        {
            return db.Departamentos.OrderBy(d => d.Nombre).ToList();
        }

        public List<Municipios> listarMunicipios(int idDepartamento)
        {
            return db.Municipios
                .Where(m => m.IdDepartamento == idDepartamento)
                .OrderBy(m => m.Nombre)
                .ToList();
        }

        public List<Comunidades> listarComunidades(int idMunicipio)
        {
            return db.Comunidades
                .Where(c => c.IdMunicipio == idMunicipio)
                .OrderBy(c => c.Nombre)
                .ToList();
        }

        // ============================================================
        // CREAR / GUARDAR PACIENTE
        // RF-03
        // ============================================================

        // Crea un paciente y agrega el contacto opcional mediante su relación.
        public void guardarPaciente(
            int? idUsuario,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroINSS,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int idComunidad,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes,
            string contactoPrimerNombre,
            string contactoSegundoNombre,
            string contactoPrimerApellido,
            string contactoSegundoApellido,
            string contactoParentesco,
            string contactoTelefono,
            string contactoCedula)
        {
            // Crear una nueva entidad Pacientes.
            Pacientes paciente = new Pacientes
            {
                // Datos personales.
                IdUsuario = idUsuario,
                PrimerNombre = primerNombre,
                SegundoNombre = segundoNombre,
                PrimerApellido = primerApellido,
                SegundoApellido = segundoApellido,
                Cedula = cedula,
                NumeroINSS = numeroINSS,
                FechaNacimiento = fechaNacimiento,
                Genero = genero,
                Telefono = telefono,
                // Datos de ubicación.
                IdComunidad = idComunidad,
                Direccion = direccion,
                // Información de salud.
                TipoSangre = tipoSangre,
                Alergias = alergias,
                Antecedentes = antecedentes,
                Estado = true
            };

            if (!string.IsNullOrWhiteSpace(contactoPrimerNombre))
            {
                ContactosEmergencia contacto = new ContactosEmergencia
                {
                    PrimerNombre = contactoPrimerNombre,
                    SegundoNombre = contactoSegundoNombre,
                    PrimerApellido = contactoPrimerApellido,
                    SegundoApellido = contactoSegundoApellido,
                    Parentesco = contactoParentesco,
                    Telefono = contactoTelefono,
                    Cedula = contactoCedula,
                    Pacientes = paciente
                };

                paciente.ContactosEmergencia.Add(contacto);
            }

            // Guardar paciente y contacto relacionado en una sola operación.
            db.Pacientes.Add(paciente);
            db.SaveChanges();
        }

        // ============================================================
        // CONSULTAR PACIENTE
        // RF-05
        // ============================================================

        // Busca un paciente mediante el IdUsuario.
        // Solo devuelve pacientes activos.
        // Los pacientes eliminados lógicamente permanecen en la base de datos,
        // pero no aparecen en las consultas normales.
        public Pacientes buscarPaciente(int idUsuario)
        {
            return db.Pacientes.FirstOrDefault(
                p => p.IdUsuario == idUsuario && p.Estado);
        }

        // ============================================================
        // EDITAR PACIENTE
        // RF-04
        // ============================================================

        // Actualiza los datos editables del paciente.
        public void actualizarPaciente(
            int idPaciente,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroINSS,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int idComunidad,
            string direccion,
            string tipoSangre,
            string alergias,
            string antecedentes)
        {
            Pacientes paciente = db.Pacientes.FirstOrDefault(
                p => p.IdPaciente == idPaciente && p.Estado);

            // Si el paciente no existe o está inactivo, no hay cambios que guardar.
            if (paciente == null)
            {
                return;
            }

            paciente.PrimerNombre = primerNombre;
            paciente.SegundoNombre = segundoNombre;
            paciente.PrimerApellido = primerApellido;
            paciente.SegundoApellido = segundoApellido;
            paciente.Cedula = cedula;
            paciente.NumeroINSS = numeroINSS;
            paciente.FechaNacimiento = fechaNacimiento;
            paciente.Genero = genero;
            paciente.Telefono = telefono;
            paciente.IdComunidad = idComunidad;
            paciente.Direccion = direccion;
            paciente.TipoSangre = tipoSangre;
            paciente.Alergias = alergias;
            paciente.Antecedentes = antecedentes;

            db.SaveChanges();
        }

        // ============================================================
        // ELIMINAR PACIENTE
        // RF-06
        // ============================================================

        // Soft delete.
        // No elimina físicamente el paciente de la base de datos.
        // Activo → Inactivo
        // De esta manera se conserva el historial del paciente.
        public void eliminarPaciente(int idPaciente)
        {
            Pacientes paciente = db.Pacientes.FirstOrDefault(
                p => p.IdPaciente == idPaciente && p.Estado);

            if (paciente != null)
            {
                paciente.Estado = false;
                db.SaveChanges();
            }
        }
    }
}
