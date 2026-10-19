using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SanarRuralUnan.Models
{
    public class enfermedadesModels
    {
        private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

        public List<Enfermedades> listarEnfermedades(string busqueda = "")
        {
            ValidarPermisoLectura();
            var consulta = db.Enfermedades.Where(enfermedad => enfermedad.Estado);

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string filtro = busqueda.Trim();
                consulta = consulta.Where(enfermedad =>
                    enfermedad.NombreEnfermedad.Contains(filtro) ||
                    (enfermedad.Categoria != null && enfermedad.Categoria.Contains(filtro)) ||
                    (enfermedad.Descripcion != null && enfermedad.Descripcion.Contains(filtro)));
            }

            return consulta.OrderBy(enfermedad => enfermedad.NombreEnfermedad).ToList();
        }

        public Enfermedades buscarEnfermedad(int idEnfermedad)
        {
            ValidarPermisoLectura();
            return db.Enfermedades.FirstOrDefault(enfermedad =>
                enfermedad.IdEnfermedad == idEnfermedad && enfermedad.Estado);
        }

        public void guardarEnfermedad(string nombre, string categoria, string descripcion)
        {
            ValidarPermisoAdministrativo("crear enfermedades");
            ValidarDatos(nombre, categoria, descripcion);

            if (existeNombre(nombre, null))
            {
                throw new InvalidOperationException("Ya existe una enfermedad activa con ese nombre.");
            }

            db.Enfermedades.Add(new Enfermedades
            {
                NombreEnfermedad = nombre.Trim(),
                Categoria = NormalizarOpcional(categoria),
                Descripcion = NormalizarOpcional(descripcion),
                Estado = true
            });

            db.SaveChanges();
        }

        public void actualizarEnfermedad(int idEnfermedad, string nombre, string categoria, string descripcion)
        {
            ValidarPermisoAdministrativo("editar enfermedades");
            ValidarDatos(nombre, categoria, descripcion);

            Enfermedades enfermedad = buscarEnfermedad(idEnfermedad);
            if (enfermedad == null)
            {
                throw new InvalidOperationException("La enfermedad ya no está disponible.");
            }

            if (existeNombre(nombre, idEnfermedad))
            {
                throw new InvalidOperationException("Ya existe una enfermedad activa con ese nombre.");
            }

            enfermedad.NombreEnfermedad = nombre.Trim();
            enfermedad.Categoria = NormalizarOpcional(categoria);
            enfermedad.Descripcion = NormalizarOpcional(descripcion);
            db.SaveChanges();
        }

        public void darDeBajaEnfermedad(int idEnfermedad)
        {
            ValidarPermisoAdministrativo("dar de baja enfermedades");
            Enfermedades enfermedad = buscarEnfermedad(idEnfermedad);
            if (enfermedad == null)
            {
                throw new InvalidOperationException("La enfermedad ya no está disponible.");
            }

            enfermedad.Estado = false;
            db.SaveChanges();
        }

        private bool existeNombre(string nombre, int? idExcluir)
        {
            string nombreNormalizado = nombre.Trim();
            return db.Enfermedades.Any(enfermedad => enfermedad.Estado &&
                enfermedad.NombreEnfermedad == nombreNormalizado &&
                (!idExcluir.HasValue || enfermedad.IdEnfermedad != idExcluir.Value));
        }

        private void ValidarPermisoAdministrativo(string operacion)
        {
            usuariosModels.ExigirRolAdministrativo(db, operacion);
        }

        private void ValidarPermisoLectura()
        {
            if (!usuariosModels.EsUsuarioSesionActivo(db))
            {
                throw new UnauthorizedAccessException("Se requiere una sesión activa para consultar el catálogo de enfermedades.");
            }

            var usuario = db.Usuarios
                .Include(actual => actual.Roles)
                .FirstOrDefault(actual => actual.IdUsuario == usuariosModels.IdUsuarioActual.Value);
            string nombreRol = usuario?.Roles?.Nombre;
            if (nombreRol != "Doctor" && nombreRol != "Paciente" && !usuariosModels.EsRolAdministrativo(nombreRol))
            {
                throw new UnauthorizedAccessException("El rol actual no tiene permiso para consultar el catálogo de enfermedades.");
            }
        }

        private static void ValidarDatos(string nombre, string categoria, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("Ingrese el nombre de la enfermedad.");
            }
            if (nombre.Trim().Length > 150)
            {
                throw new ArgumentException("El nombre no puede superar 150 caracteres.");
            }
            if (categoria != null && categoria.Trim().Length > 100)
            {
                throw new ArgumentException("La categoría no puede superar 100 caracteres.");
            }
            if (descripcion != null && descripcion.Trim().Length > 2000)
            {
                throw new ArgumentException("La descripción no puede superar 2000 caracteres.");
            }
        }

        private static string NormalizarOpcional(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }
    }
}
