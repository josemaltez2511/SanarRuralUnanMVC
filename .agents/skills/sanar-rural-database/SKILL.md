---
name: sanar-rural-database
description: "Guía especializada para persistencia y base de datos en Sanar Rural UNAN: Entity Framework 6.5.2 (Database First / EDMX), SQL Server 2022, gestión de transacciones ACID, navegación de relaciones, protección de entidades autogeneradas y reglas de actualización de esquema."
---

# Habilidad Especializada: Persistencia y Base de Datos en Sanar Rural UNAN

Esta habilidad debe cargarse obligatoriamente al trabajar con modelos de datos, consultas LINQ to Entities, transacciones, modificaciones de esquema en SQL Server o integración con Entity Framework 6.

---

## 1. Stack de Datos y Flujo Database First
- **Motor:** Microsoft SQL Server 2022.
- **ORM:** Entity Framework 6.5.2.
- **Modelo:** `ModelSanarRural.edmx` con generación automática de código mediante plantillas T4 (`ModelSanarRural.tt`).
- **Contexto:** `SanarRuralDBEntities` derivado de `DbContext`.

### Regla de Oro sobre Código Generado:
> ⛔ **NO EDITAR MANUALMENTE:**  
> Archivos como `Doctores.cs`, `Pacientes.cs`, `Citas.cs`, `Consultas.cs`, `SignosVitales.cs`, `Diagnosticos.cs`, `Prescripciones.cs`, `ModelSanarRural.Context.cs` son generados automáticamente. Cualquier modificación manual se perderá si el modelo se regenera desde la base de datos.

---

## 2. Relaciones Complejas y Consultas Eager Loading (`Include`)
Para evitar el problema de N+1 queries o excepciones por Lazy Loading en controles WinForms desconectados, se debe utilizar `Include` explícito:

```csharp
// Consulta de Doctores con especialidades y asignaciones a hospitales:
public Doctores buscarDoctorPorId(int idDoctor)
{
    return db.Doctores
        .Include(d => d.DoctorEspecialidad.Select(de => de.Especialidades))
        .Include(d => d.DoctorEspecialidad.Select(de => de.DoctorHospitalEspecialidad.Select(dhe => dhe.Hospitales)))
        .FirstOrDefault(d => d.IdDoctor == idDoctor && d.Estado);
}
```

---

## 3. Transacciones ACID en Operaciones Compuestas
Cuando una operación de negocio implique insertar o modificar múltiples entidades relacionadas (por ejemplo, guardar una consulta médica junto con sus signos vitales y recetas), debe garantizarse la atomicidad:

```csharp
public void registrarConsultaCompleta(
    int idCita,
    Consultas nuevaConsulta,
    SignosVitales signos,
    List<Diagnosticos> diagnosticos,
    List<Prescripciones> prescripciones)
{
    using (var transaccion = db.Database.BeginTransaction())
    {
        try
        {
            // 1. Agregar y guardar la consulta para generar su Id
            db.Consultas.Add(nuevaConsulta);
            db.SaveChanges();

            // 2. Asociar y guardar signos vitales
            if (signos != null)
            {
                signos.IdConsulta = nuevaConsulta.IdConsulta;
                db.SignosVitales.Add(signos);
            }

            // 3. Asociar diagnósticos
            foreach (var diag in diagnosticos)
            {
                diag.IdConsulta = nuevaConsulta.IdConsulta;
                db.Diagnosticos.Add(diag);
            }

            // 4. Asociar prescripciones
            foreach (var pres in prescripciones)
            {
                pres.IdConsulta = nuevaConsulta.IdConsulta;
                db.Prescripciones.Add(pres);
            }

            // 5. Actualizar estado de la cita a "Atendida"
            var cita = db.Citas.Find(idCita);
            if (cita != null)
            {
                cita.Estado = "Atendida";
            }

            db.SaveChanges();
            transaccion.Commit();
        }
        catch (Exception)
        {
            transaccion.Rollback();
            throw; // Propagar al controlador para notificación amigable en UI
        }
    }
}
```

---

## 4. Borrado Lógico vs. Físico
- Las entidades principales (`Doctores`, `Pacientes`, `Hospitales`, `Usuarios`, `Especialidades`) utilizan borrado lógico mediante la columna booleana `Estado`.
- **Regla:** Al listar registros o buscar para asignaciones, filtrar siempre por `d.Estado == true`.
- Al "eliminar", marcar `entidad.Estado = false` y persistir con `db.SaveChanges()`, preservando el histórico de atenciones clínicas previas.

---

## 5. Reglas para Cambios de Esquema y EDMX
1. **No tocar la BD para problemas visuales:** Si un formulario se ve desalineado, el problema es de WinForms (`Tema.cs`, anclajes, diseño), no de base de datos.
2. **Si cambia el esquema en SQL Server:**
   - Abrir `ModelSanarRural.edmx` en Visual Studio.
   - Ejecutar *"Actualizar modelo desde la base de datos"* (Update Model from Database).
   - Guardar el archivo para que las plantillas `.tt` regeneren las entidades.
3. **Si solo cambian datos semilla (Seeds):**
   - Ejecutar el script SQL de inserción directamente.
   - **No refrescar el EDMX** innecesariamente si no hubo alteraciones en tablas, columnas ni relaciones.
