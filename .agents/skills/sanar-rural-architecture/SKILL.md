---
name: sanar-rural-architecture
description: "Guía arquitectónica para Sanar Rural UNAN: arquitectura MVC informal adaptada a Windows Forms (.NET Framework 4.7.2), flujo de comunicación View -> Controller -> Model -> EF, responsabilidades estrictas por capa, ciclo de vida de formularios y gestión de recursos GDI+."
---

# Habilidad Especializada: Arquitectura de Software en Sanar Rural UNAN

Esta habilidad debe cargarse obligatoriamente al estructurar nuevo código C#, crear módulos, enlazar vistas con controladores o diseñar flujos de comunicación entre capas.

---

## 1. El Patrón MVC Informal en Windows Forms
Sanar Rural implementa un MVC informal pragmático, diseñado para mantener el código desacoplado, legible y mantenible sin añadir sobreingeniería:

```
[ Views/ ]              [ Controllers/ ]           [ Models/ ]             [ EF6 / BD ]
Formulario WinForms ──> Controlador C#     ──> Modelo C#         ──> SanarRuralDBEntities
(UI, Eventos,           (Orquestación,         (Consultas LINQ,      (SQL Server 2022)
 Validaciones visuales)  Parámetros de flujo)   Persistencia, ACID)
```

---

## 2. Responsabilidades por Capa

### A. Capa de Vista (`Views/`)
- **Propósito:** Interacción con el usuario, captura de inputs, selección de archivos (`OpenFileDialog`), mensajes emergentes (`MessageBox`) y actualización de controles visuales.
- **Regla Estricta:** La vista **nunca** debe instanciar `SanarRuralDBEntities` ni invocar directamente métodos de `System.Data.Entity`.
- **Ejemplo de invocación desde la vista:**
  ```csharp
  // En crearDoctor.cs (Vista)
  private readonly doctoresControllers controladorDoctores = new doctoresControllers();

  private void btnGuardar_Click(object sender, EventArgs e)
  {
      // 1. Validaciones puramente visuales / campos vacíos
      if (string.IsNullOrWhiteSpace(txtPrimerNombre.Text)) { ... return; }

      // 2. Delegación en el controlador
      controladorDoctores.crearDoctor(
          idUsuario,
          txtPrimerNombre.Text.Trim(),
          txtSegundoNombre.Text.Trim(),
          ...
      );

      this.DialogResult = DialogResult.OK;
      this.Close();
  }
  ```

### B. Capa de Controlador (`Controllers/`)
- **Propósito:** Actuar como puente entre la Vista y el Modelo. Recibe tipos primitivos, DTOs o colecciones desde la Vista y los traslada al Modelo correspondiente.
- **Convención de Nombres:** Clases terminadas en `Controller` o `Controllers` dentro del namespace `SanarRuralUnan.Controllers`.
- **Ejemplo:**
  ```csharp
  // En doctoresControllers.cs (Controller)
  public class doctoresControllers
  {
      public void crearDoctor(int? idUsuario, string primerNombre, ...)
      {
          new doctoresModels().guardarDoctor(idUsuario, primerNombre, ...);
      }

      public List<Especialidades> listarEspecialidades()
      {
          return new doctoresModels().listarEspecialidades();
      }
  }
  ```

### C. Capa de Modelo (`Models/`)
- **Propósito:** Alojar la instancia de `SanarRuralDBEntities`, construir las consultas LINQ, aplicar reglas de negocio sobre los datos (ej. solo doctores con `Estado == true`), manejar inserciones/actualizaciones y coordinar transacciones.
- **Convención de Nombres:** Clases terminadas en `Models` dentro del namespace `SanarRuralUnan.Models`.
- **Ejemplo:**
  ```csharp
  // En doctoresModels.cs (Model)
  public class doctoresModels
  {
      private readonly SanarRuralDBEntities db = new SanarRuralDBEntities();

      public Doctores buscarDoctorPorId(int idDoctor)
      {
          return db.Doctores
              .Include(d => d.DoctorEspecialidad.Select(de => de.Especialidades))
              .FirstOrDefault(d => d.IdDoctor == idDoctor && d.Estado);
      }
  }
  ```

---

## 3. Principio Anti-Sobreingeniería (KISS y Pragmatismo)
- **No introducir ASP.NET:** No usar controllers web, routing HTTP ni middleware web.
- **No introducir Repository/UnitOfWork innecesarios:** `DbContext` de Entity Framework ya es un Unit of Work y `DbSet` ya es un Repository. Añadir abstracciones genéricas excesivas sobre EF6 genera complejidad vacía en este proyecto.
- **Mantener métodos directos y bien nombrados:** Nombres en infinitivo o imperativo claro (`guardarDoctor`, `actualizarPaciente`, `listarHospitales`, `buscarDoctorPorId`).

---

## 4. Gestión de Memoria y Ciclo de Vida en WinForms
1. **Recursos Gráficos y GDI+:**
   - Todo control `PictureBox` con imágenes asignadas dinámicamente debe liberar el objeto `Image` anterior con `Dispose()` antes de asignar uno nuevo o al cerrar el formulario.
   - En lecturas de archivo (`File.ReadAllBytes`), utilizar `MemoryStream` y generar una copia `new Bitmap(temporal)` para no retener bloqueos sobre el archivo original en disco:
     ```csharp
     using (var stream = new MemoryStream(bytes))
     using (var temp = Image.FromStream(stream))
     {
         picPreview.Image = new Bitmap(temp);
     }
     ```
2. **Formularios Modales:**
   - Instanciar siempre dentro de un bloque `using` cuando sea posible o asegurar su `Dispose()` al cerrar:
     ```csharp
     using (var form = new crearPaciente())
     {
         if (form.ShowDialog(this) == DialogResult.OK)
         {
             CargarTablaPacientes();
         }
     }
     ```
3. **Formularios Embebidos en Shells:**
   - Limpiar `panelContenido.Controls.Clear()` y ocultar el formulario anterior (`formularioActual.Visible = false`) antes de mostrar el nuevo, evitando recrear instancias pesadas si se pueden cachear.
