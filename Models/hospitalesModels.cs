using System;
using System.Collections.Generic;
using System.Linq;

// Modelo de hospital para la aplicación SanarRuralUnan
// Este modelo representa a un hospital en la aplicación y contiene los métodos para
// crear, consultar, listar, editar y "eliminar" (de forma lógica) un hospital en la base de datos.
// El modelo maneja la lógica de negocio relacionada con los hospitales.
// La Vista nunca debe hablar directamente con la base de datos; solo el Modelo.

namespace SanarRuralUnan.Models
{
    public class hospitalesModels
    {
        // ============================================================
        // CONEXIÓN A LA BASE DE DATOS
        // ============================================================

        // La conexión a la BD solo existe en el Modelo.
        SanarRuralDBEntities db = new SanarRuralDBEntities();


        // ============================================================
        // PROPIEDADES DEL HOSPITAL
        // ============================================================

        // Identificador único del hospital.
        // Se genera automáticamente en la base de datos.
        public int IdHospital { get; set; }

        // Nombre del hospital o centro de salud.
        public string Nombre { get; set; }

        // Ubicación física o dirección del hospital.
        public string Ubicacion { get; set; }


        // ============================================================
        // ESTADO DEL HOSPITAL
        // ============================================================

        // Manejo de Soft Delete mediante un valor booleano:
        // true  = Activo (visible en la aplicación)
        // false = Inactivo (eliminación lógica, conservado en la BD)
        public bool Estado { get; set; }


        // ============================================================
        // CONSTRUCTOR VACÍO
        // ============================================================

        // Permite crear un objeto y llenar sus propiedades
        // individualmente.

        public hospitalesModels()
        {
        }


        // ============================================================
        // CONSTRUCTOR CON PARÁMETROS
        // ============================================================

        // Permite crear un hospital con sus datos principales.
        //
        // ¿POR QUÉ NO LLEVA EL PARÁMETRO "ESTADO"?
        // Todo hospital nuevo que se registra en el sistema nace como "Activo" por defecto.
        // No es necesario pedirle al usuario que elija el estado al momento del registro.
        // La asignación del estado inicial (true) se realiza automáticamente dentro de
        // la lógica de negocio en el método guardarHospital().

        public hospitalesModels(string nombre, string ubicacion)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
        }


        // ============================================================
        // CREAR / GUARDAR HOSPITAL
        // ============================================================

        // Crea un nuevo hospital y lo guarda en la base de datos.

        public void guardarHospital()
        {
            // Crear una nueva entidad Hospitales.
            Hospitales hospitalNuevo = new Hospitales();


            // --------------------------------------------------------
            // DATOS DEL HOSPITAL
            // --------------------------------------------------------

            hospitalNuevo.Nombre = Nombre;
            hospitalNuevo.Ubicacion = Ubicacion;


            // --------------------------------------------------------
            // ESTADO INICIAL
            // --------------------------------------------------------

            // Todo hospital nuevo comienza como Activo (true).
            hospitalNuevo.Estado = true;


            // --------------------------------------------------------
            // GUARDAR EN LA BASE DE DATOS
            // --------------------------------------------------------

            db.Hospitales.Add(hospitalNuevo);

            db.SaveChanges();
        }


        // ============================================================
        // LISTAR HOSPITALES (LISTADO GENERAL)
        // ============================================================

        // *** DIFERENCIA ENTRE LISTAR Y CONSULTAR/BUSCAR ***
        //
        // 1. LISTAR HOSPITALES (listarHospitales):
        //    - Retorna una COLECCIÓN O LISTA COMPLETA (List<Hospitales>) de múltiples registros.
        //    - Sirve para llenar controles colectivos como Tablas de administración 
        //      o la Lista Desplegable (DropDownList / Select) del módulo de Doctores.
        //    - ¿Para qué lo necesitamos?: Abraham usará este método en su pantalla para que
        //      el usuario elija a qué hospital pertenece el doctor que está registrando.

        public List<Hospitales> listarHospitales()
        {
            // Retorna únicamente los hospitales que están activos (Estado == true)
            return db.Hospitales.Where(h => h.Estado == true).ToList();
        }


        // ============================================================
        // CONSULTAR / BUSCAR HOSPITAL INDIVIDUAL
        // ============================================================

        // *** DIFERENCIA ENTRE LISTAR Y CONSULTAR/BUSCAR ***
        //
        // 2. CONSULTAR / BUSCAR HOSPITAL (buscarHospital):
        //    - Retorna UN SOLO REGISTRO ESPECÍFICO (Objeto Hospitales) filtrado por su IdHospital.
        //    - Sirve para obtener los detalles de un único hospital en particular.
        //    - ¿Para qué lo necesitamos?: Cuando das clic al botón "Editar" en una fila de tu tabla, 
        //      necesitas este método para traer los datos del Hospital #3 y rellenar las cajas de texto.

        public Hospitales buscarHospital(int idHospital)
        {
            return db.Hospitales.FirstOrDefault(
                h => h.IdHospital == idHospital &&
                     h.Estado == true
            );
        }


        // ============================================================
        // EDITAR HOSPITAL
        // ============================================================

        // Actualiza el nombre y la ubicación del hospital.

        public void actualizarHospital(int idHospital, string nombre, string ubicacion)
        {
            // Buscar el hospital mediante su IdHospital.
            var hospital = db.Hospitales.FirstOrDefault(
                h => h.IdHospital == idHospital
            );


            // Si el hospital existe, actualizar sus datos.
            if (hospital != null)
            {
                // ----------------------------------------------------
                // DATOS A ACTUALIZAR
                // ----------------------------------------------------

                hospital.Nombre = nombre;
                hospital.Ubicacion = ubicacion;


                // ----------------------------------------------------
                // GUARDAR CAMBIOS
                // ----------------------------------------------------

                db.SaveChanges();
            }
        }


        // ============================================================
        // ELIMINAR HOSPITAL
        // ============================================================

        // Soft delete.
        //
        // NO elimina físicamente el hospital de la base de datos.
        //
        // Solamente cambia:
        //
        // Activo (true) → Inactivo (false)
        //
        // De esta manera se conserva la integridad referencial
        // con los doctores y citas en el historial.

        public void eliminarHospital(int idHospital)
        {
            // Buscar el hospital mediante su IdHospital.
            var hospital = db.Hospitales.FirstOrDefault(
                h => h.IdHospital == idHospital
            );


            // Si el hospital existe...
            if (hospital != null)
            {
                // Marcar como inactivo (false).
                hospital.Estado = false;


                // Guardar cambios.
                db.SaveChanges();
            }
        }
    }
}