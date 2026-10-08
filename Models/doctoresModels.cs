using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        // La conexión a la base de datos solo existe en el Modelo.
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        // ============================================================
        // LISTAR ESPECIALIDADES Y HOSPITALES
        // ============================================================
        public List<Especialidades> listarEspecialidades()
        {
            return db.Especialidades
                .Where(e => e.Estado)
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        public List<Hospitales> listarHospitales()
        {
            return db.Hospitales
                .Where(h => h.Estado)
                .OrderBy(h => h.Nombre)
                .ToList();
        }

        // ============================================================
        // CREAR / GUARDAR DOCTOR
        // RF-07
        // ============================================================
        public void guardarDoctor(
            int? idUsuario,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroLicencia,
            string telefono,
            byte[] foto,
            string fotoNombre,
            string fotoMimeType,
            IList<int> idEspecialidades,
            IList<Tuple<int, int>> asignaciones)
        {
            // Crear una nueva entidad Doctor con sus relaciones.
            var especialidades = (idEspecialidades ?? new List<int>()).Distinct().ToList();
            var relaciones = (asignaciones ?? new List<Tuple<int, int>>())
                .Where(a => especialidades.Contains(a.Item2))
                .Distinct()
                .ToList();

            var doctor = new Doctores
            {
                IdUsuario = idUsuario.GetValueOrDefault() > 0 ? idUsuario : null,
                PrimerNombre = primerNombre,
                SegundoNombre = segundoNombre,
                PrimerApellido = primerApellido,
                SegundoApellido = segundoApellido,
                Cedula = cedula,
                NumeroLicencia = numeroLicencia,
                Telefono = telefono,
                Foto = foto,
                FotoNombre = fotoNombre,
                FotoMimeType = fotoMimeType,
                // Todo doctor nuevo se crea como Activo.
                Estado = true
            };

            foreach (int idEspecialidad in especialidades)
            {
                var doctorEspecialidad = new DoctorEspecialidad
                {
                    IdEspecialidad = idEspecialidad
                };

                foreach (var asignacion in relaciones.Where(a => a.Item2 == idEspecialidad))
                {
                    doctorEspecialidad.DoctorHospitalEspecialidad.Add(
                        new DoctorHospitalEspecialidad
                        {
                            IdHospital = asignacion.Item1,
                            IdEspecialidad = idEspecialidad
                        }
                    );
                }

                doctor.DoctorEspecialidad.Add(doctorEspecialidad);
            }

            db.Doctores.Add(doctor);
            db.SaveChanges();
        }

        // ============================================================
        // LISTAR DOCTORES CON BÚSQUEDA
        // ============================================================
        public object listarDoctores(string busqueda = "")
        {
            var consulta = db.Doctores
                .Include(d => d.DoctorEspecialidad.Select(de => de.Especialidades))
                .Include(d => d.DoctorEspecialidad.Select(de => de.DoctorHospitalEspecialidad.Select(dhe => dhe.Hospitales)))
                .Where(d => d.Estado);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string filtro = busqueda.Trim();
                consulta = consulta.Where(d =>
                    d.PrimerNombre.Contains(filtro) ||
                    (d.SegundoNombre != null && d.SegundoNombre.Contains(filtro)) ||
                    d.PrimerApellido.Contains(filtro) ||
                    (d.SegundoApellido != null && d.SegundoApellido.Contains(filtro)) ||
                    d.Cedula.Contains(filtro) ||
                    d.NumeroLicencia.Contains(filtro) ||
                    d.DoctorEspecialidad.Any(de => de.Especialidades.Nombre.Contains(filtro)) ||
                    d.DoctorEspecialidad.Any(de => de.DoctorHospitalEspecialidad
                        .Any(dhe => dhe.Hospitales.Nombre.Contains(filtro)))
                );
            }

            return consulta.ToList().Select(d => new
            {
                d.IdDoctor,
                Nombre = string.Join(" ", new[]
                {
                    d.PrimerNombre,
                    d.SegundoNombre,
                    d.PrimerApellido,
                    d.SegundoApellido
                }.Where(nombre => !string.IsNullOrWhiteSpace(nombre))),
                Especialidades = string.Join(", ", d.DoctorEspecialidad
                    .Select(de => de.Especialidades.Nombre)
                    .Distinct()),
                Licencia = d.NumeroLicencia,
                Hospital = string.Join(", ", d.DoctorEspecialidad
                    .SelectMany(de => de.DoctorHospitalEspecialidad)
                    .Select(dhe => dhe.Hospitales.Nombre)
                    .Distinct()
                    .DefaultIfEmpty("Sin asignar")),
                Estado = d.Estado ? "Activo" : "Inactivo"
            }).ToList();
        }

        // ============================================================
        // BUSCAR DOCTOR POR ID DOCTOR
        // ============================================================
        public Doctores buscarDoctorPorId(int idDoctor)
        {
            return db.Doctores
                .Include(d => d.DoctorEspecialidad.Select(de => de.Especialidades))
                .Include(d => d.DoctorEspecialidad.Select(de => de.DoctorHospitalEspecialidad.Select(dhe => dhe.Hospitales)))
                .FirstOrDefault(d => d.IdDoctor == idDoctor && d.Estado);
        }

        // ============================================================
        // EDITAR DOCTOR
        // RF-08
        // ============================================================
        public void actualizarDoctor(
            int idDoctor,
            string primerNombre,
            string segundoNombre,
            string primerApellido,
            string segundoApellido,
            string cedula,
            string numeroLicencia,
            string telefono,
            byte[] foto,
            string fotoNombre,
            string fotoMimeType,
            bool fotoEliminada,
            IList<int> idEspecialidades,
            IList<Tuple<int, int>> asignaciones)
        {
            // Solo se pueden editar doctores que estén activos.
            var doctor = db.Doctores
                .Include(d => d.DoctorEspecialidad.Select(de => de.DoctorHospitalEspecialidad))
                .FirstOrDefault(d => d.IdDoctor == idDoctor && d.Estado);

            if (doctor == null)
            {
                return;
            }

            var especialidades = (idEspecialidades ?? new List<int>()).Distinct().ToList();
            var relaciones = (asignaciones ?? new List<Tuple<int, int>>())
                .Where(a => especialidades.Contains(a.Item2))
                .Distinct()
                .ToList();

            doctor.PrimerNombre = primerNombre;
            doctor.SegundoNombre = segundoNombre;
            doctor.PrimerApellido = primerApellido;
            doctor.SegundoApellido = segundoApellido;
            doctor.Cedula = cedula;
            doctor.NumeroLicencia = numeroLicencia;
            doctor.Telefono = telefono;
            if (foto != null)
            {
                // Si se seleccionó una nueva foto, se actualizan los datos de imagen.
                doctor.Foto = foto;
                doctor.FotoNombre = fotoNombre;
                doctor.FotoMimeType = fotoMimeType;
            }
            else if (fotoEliminada)
            {
                // Si el usuario quitó la foto explícitamente, se limpian los campos.
                doctor.Foto = null;
                doctor.FotoNombre = null;
                doctor.FotoMimeType = null;
            }

            foreach (var existente in doctor.DoctorEspecialidad.ToList())
            {
                foreach (var asignacionExistente in existente.DoctorHospitalEspecialidad.ToList())
                {
                    bool seleccionada = relaciones.Any(a =>
                        a.Item1 == asignacionExistente.IdHospital &&
                        a.Item2 == asignacionExistente.IdEspecialidad);

                    bool tieneCitas = db.Citas.Any(c =>
                        c.IdDoctor == asignacionExistente.IdDoctor &&
                        c.IdHospital == asignacionExistente.IdHospital &&
                        c.IdEspecialidad == asignacionExistente.IdEspecialidad);

                    if (!seleccionada && !tieneCitas)
                    {
                        db.DoctorHospitalEspecialidad.Remove(asignacionExistente);
                    }
                }

                bool conservaAsignacion = existente.DoctorHospitalEspecialidad.Any(a =>
                    db.Entry(a).State != EntityState.Deleted);

                if (!especialidades.Contains(existente.IdEspecialidad) && !conservaAsignacion)
                {
                    db.DoctorEspecialidad.Remove(existente);
                }
            }

            foreach (int idEspecialidad in especialidades)
            {
                var doctorEspecialidad = doctor.DoctorEspecialidad
                    .FirstOrDefault(de => de.IdEspecialidad == idEspecialidad);

                if (doctorEspecialidad == null)
                {
                    doctorEspecialidad = new DoctorEspecialidad { IdEspecialidad = idEspecialidad };
                    doctor.DoctorEspecialidad.Add(doctorEspecialidad);
                }

                foreach (var asignacion in relaciones.Where(a => a.Item2 == idEspecialidad))
                {
                    bool existe = doctorEspecialidad.DoctorHospitalEspecialidad.Any(dhe =>
                        dhe.IdHospital == asignacion.Item1 &&
                        db.Entry(dhe).State != EntityState.Deleted);

                    if (!existe)
                    {
                        doctorEspecialidad.DoctorHospitalEspecialidad.Add(
                            new DoctorHospitalEspecialidad
                            {
                                IdDoctor = idDoctor,
                                IdHospital = asignacion.Item1,
                                IdEspecialidad = idEspecialidad
                            }
                        );
                    }
                }
            }

            db.SaveChanges();
        }

        // ============================================================
        // ELIMINAR DOCTOR
        // RF-10
        // ============================================================
        // Este método realiza una eliminación lógica para conservar
        // el historial del doctor únicamente si nunca ha tenido citas.
        public void eliminarDoctor(int idDoctor)
        {
            // Buscar únicamente un doctor que esté activo.
            var doctor = db.Doctores.FirstOrDefault(
                d => d.IdDoctor == idDoctor && d.Estado
            );

            if (doctor == null)
            {
                return;
            }

            // Regla de negocio: Un doctor solo puede darse de baja si NUNCA ha tenido registros clínicos en Citas.
            if (db.Citas.Any(c => c.IdDoctor == idDoctor))
            {
                throw new InvalidOperationException("No se puede dar de baja al doctor porque posee historial de citas.");
            }

            doctor.Estado = false;
            db.SaveChanges();
        }

        // ============================================================
        // COMPROBACIONES DE UNICIDAD
        // ============================================================
        public bool existeCedula(string cedula, int? idDoctorExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                return false;
            }

            string normalizada = cedula.Trim();
            return db.Doctores.Any(d => d.Cedula == normalizada && (!idDoctorExcluir.HasValue || d.IdDoctor != idDoctorExcluir.Value));
        }

        public bool existeNumeroLicencia(string numeroLicencia, int? idDoctorExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(numeroLicencia))
            {
                return false;
            }

            string normalizada = numeroLicencia.Trim();
            return db.Doctores.Any(d => d.NumeroLicencia == normalizada && (!idDoctorExcluir.HasValue || d.IdDoctor != idDoctorExcluir.Value));
        }
    }
}
