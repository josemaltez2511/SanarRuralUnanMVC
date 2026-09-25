using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

// Controller de hospitales para la aplicación SanarRuralUnan
// Este controlador comunica la Vista con el Modelo.
// La Vista no accede directamente a la base de datos.

namespace SanarRuralUnan.Controllers
{
    public class hospitalesController
    {
        // ============================================================
        // CREAR HOSPITAL
        // ============================================================
        // Recibe los datos enviados desde la Vista (Nombre y Ubicación)
        // y los pasa al Modelo para registrarlos en la base de datos.

        public void crearHospital(string nombre, string ubicacion)
        {
            // Crear objeto del modelo.
            hospitalesModels objetoHospital = new hospitalesModels();

            // Asignar los datos personales del hospital.
            objetoHospital.Nombre = nombre;
            objetoHospital.Ubicacion = ubicacion;

            // Pedir al Modelo que guarde el hospital.
            objetoHospital.guardarHospital();
        }


        // ============================================================
        // LISTAR HOSPITALES
        // ============================================================
        // Obtiene la lista completa de todos los hospitales activos.
        // Sirve para cargar la tabla principal o llenar el combo desplegable
        // que Abraham necesita en el módulo de Doctores.

        public List<Hospitales> listarHospitales()
        {
            // Crear objeto del modelo.
            hospitalesModels objetoHospital = new hospitalesModels();

            // Pedir al Modelo la lista de todos los hospitales activos.
            return objetoHospital.listarHospitales();
        }


        // ============================================================
        // CONSULTAR HOSPITAL
        // ============================================================
        // Busca un hospital específico utilizando su IdHospital.
        // Devuelve los datos del hospital si está activo.

        public Hospitales consultarHospital(int idHospital)
        {
            // Crear objeto del modelo.
            hospitalesModels objetoHospital = new hospitalesModels();

            // Pedir al Modelo que busque la información de un hospital individual.
            return objetoHospital.buscarHospital(idHospital);
        }


        // ============================================================
        // EDITAR HOSPITAL
        // ============================================================
        // Recibe el IdHospital y los nuevos datos modificados
        // y los envía al Modelo para actualizar el registro.

        public void editarHospital(int idHospital, string nombre, string ubicacion)
        {
            // Crear objeto del modelo.
            hospitalesModels objetoHospital = new hospitalesModels();

            // Enviar todos los datos al Modelo para guardar la actualización.
            objetoHospital.actualizarHospital(idHospital, nombre, ubicacion);
        }


        // ============================================================
        // ELIMINAR HOSPITAL
        // ============================================================
        // Realiza un soft delete.
        // El registro NO se elimina físicamente de la BD;
        // únicamente se cambia su estado de activo a inactivo.

        public void eliminarHospital(int idHospital)
        {
            // Crear objeto del modelo.
            hospitalesModels objetoHospital = new hospitalesModels();

            // Pedir al Modelo que cambie el estado del hospital.
            objetoHospital.eliminarHospital(idHospital);
        }
    }
}

