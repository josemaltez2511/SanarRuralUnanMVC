---
name: sanar-rural-ui-ux
description: "Guía especializada de diseño de interfaz de usuario y experiencia de usuario (UI/UX) para Sanar Rural UNAN: principios de User-Centered Design (UCD), aplicación estricta de Tema.cs, paleta de colores de salud/naturaleza, integración con MaterialSkin 2, diseño responsivo en WinForms, accesibilidad y microinteracciones."
---

# Habilidad Especializada: UI/UX en Sanar Rural UNAN

Esta habilidad debe cargarse obligatoriamente al diseñar, crear o modificar cualquier formulario, componente o pantalla en **Sanar Rural UNAN**.

---

## 1. Filosofía UCD (User-Centered Design)
En entornos de salud rural, los usuarios (médicos, enfermeros y personal administrativo) atienden pacientes bajo presión de tiempo y con recursos informáticos variables. La interfaz debe priorizar:
1. **Claridad sobre ornamentación:** La pantalla debe ser comprensible en un escaneo visual de 3 segundos:
   - ¿En qué módulo estoy?
   - ¿Qué registros u opciones tengo enfrente?
   - ¿Cuál es la acción principal recomendada?
2. **Eficiencia de flujo:** Reducir la cantidad de clics requeridos para completar tareas repetitivas (ej. agendar una cita o registrar signos vitales).
3. **Prevención y manejo de errores:** Mensajes de validación claros y contextuales junto al campo correspondiente, en español y con indicaciones constructivas.

---

## 2. Aplicación de `Helpers/Tema.cs` y Paleta Oficial
`Tema.cs` es la autoridad visual del proyecto. No se deben definir colores `Color.FromArgb(...)` directos en formularios.

```csharp
// CORRECTO:
this.BackColor = Tema.Fondo; // #EDF7F0
panelCard.BackColor = Tema.Superficie; // #F9FCFA
lblTitulo.ForeColor = Tema.AzulPrimario; // #2378B7
lblSubtitulo.ForeColor = Tema.TextoSecundario; // #597078
btnGuardar.BackColor = Tema.AzulPrimario;
lblError.ForeColor = Tema.Error; // #C65353

// INCORRECTO:
this.BackColor = Color.White; // ¡PROHIBIDO fondo blanco plano!
btnGuardar.BackColor = Color.FromArgb(35, 120, 183); // Duplicación de Tema
```

### Tabla de correspondencia visual:
| Rol Visual | Color en `Tema.cs` | Valor Hex | Uso Aprobado |
|---|---|---|---|
| Fondo General | `Tema.Fondo` | `#EDF7F0` | Fondo de ventanas principales y formularios modales |
| Fondo Secundario | `Tema.FondoSecundario` | `#E4F1E8` | Encabezados de DataGridView, cajas inactivas, preview vacíos |
| Superficie | `Tema.Superficie` | `#F9FCFA` | Tarjetas contenedoras (`panelCard`), paneles de contenido |
| Acción Primaria | `Tema.AzulPrimario` | `#2378B7` | Botón de guardado, confirmación o navegación activa |
| Acento / Éxito | `Tema.Verde` / `VerdeOscuro` | `#78B86A` / `#4D8E56` | Indicadores de estado activo, barras decorativas |
| Texto Principal | `Tema.TextoPrincipal` | `#173342` | Etiquetas de campos, valores de tablas, títulos |
| Texto Secundario | `Tema.TextoSecundario` | `#597078` | Subtítulos, textos de ayuda, placeholders |
| Borde | `Tema.Borde` | `#CFE1D5` | Separadores, líneas de tablas, contornos sutiles |
| Alerta / Error | `Tema.Error` | `#C65353` | Validaciones fallidas, botones de quitar/eliminar |
| Advertencia | `Tema.Advertencia` | `#D69A3A` | Estados pendientes o confirmaciones delicadas |

---

## 3. Integración con MaterialSkin 2
- Los shells (`menuPrincipalAdministrativo`, `menuPrincipalMedicos`) heredan de `MaterialForm`.
- Configurar esquema de colores corporativo en el constructor del shell:
  ```csharp
  MaterialSkinManager skin = MaterialSkinManager.Instance;
  skin.AddFormToManage(this);
  skin.Theme = MaterialSkinManager.Themes.LIGHT;
  skin.ColorScheme = new ColorScheme(
      Primary.Blue700, Primary.Blue800, Primary.Blue500,
      Accent.LightBlue200, TextShade.WHITE
  );
  ```
- Para controles embebidos en tarjetas (campos de texto, selects, botones en modales), utilizar los controles estilizados con `Tema.cs` para mantener consistencia y flexibilidad responsiva.

---

## 4. Patrones de Diseño Responsivo en WinForms
1. **Contenedor Principal (`panelCard`):**
   - En pantallas centradas (ej. login): centrar dinámicamente en evento `Resize` calculando `(ClientSize.Width - panelCard.Width) / 2`.
   - En formularios modales con scroll: asignar `panelCard.AutoScroll = true` y utilizar manejador de evento `panelCard.Resize` para recalcular anchos de columnas:
     ```csharp
     int margen = 28;
     int espacio = 24;
     int anchoContenido = Math.Max(0, panelCard.ClientSize.Width - margen * 2);
     int anchoColumna = Math.Max(0, (anchoContenido - espacio) / 2);
     ```
2. **Anclajes (`Anchor` y `Dock`):**
   - Columna izquierda: `AnchorStyles.Top | AnchorStyles.Left`
   - Columna derecha: `AnchorStyles.Top | AnchorStyles.Right`
   - Tablas y paneles de sección en shells: `DockStyle.Fill`
3. **Mínimos de pantalla:**
   - Establecer siempre `MinimumSize` en los formularios para evitar que los controles se solapen o colapsen.

---

## 5. Jerarquía de Botones y Acciones
1. **Botón Primario Único:** Solo debe existir **un** botón primario prominente por formulario (ej. `Guardar Doctor`, `Registrar Paciente`).
2. **Botones Secundarios:**
   - Botones de acción contextual: tamaño compacto (alto 32–36 px), ubicados cerca del control que afectan (ej. `Seleccionar foto`, `Agregar asignación`).
   - Botón de peligro/quitar: color `Tema.Error`, visible solo cuando exista un elemento a eliminar o limpiar.
3. **Acciones de Cancelación o Retorno:**
   - Preferir `LinkLabel` discreto con texto descriptivo: `lnkVolver.Text = "Completar después / Volver"`.

---

## 6. Estados Visuales y Accesibilidad
1. **Comunicación Multicanal:** Nunca depender únicamente del color para comunicar estados.
   - Estado activo: `✓ Activo` (color verde).
   - Estado pendiente: `⚠ Pendiente` (color naranja).
   - Estado error/inactivo: `✕ Inactivo` (color rojo).
2. **Navegación por Teclado:**
   - Configurar `TabIndex` continuo y ordenado de arriba hacia abajo y de izquierda a derecha.
   - Los formularios deben permitir cancelar con `CancelButton = btnCancelar` o tecla `Escape`.
3. **Propiedades Accesibles:**
   - Asignar `AccessibleName` a todo combo, botón con icono y caja de búsqueda.
   - Asociar `ToolTip` a botones que utilicen iconos o abreviaturas.

---

## 7. Microinteracciones y Tiempos de Respuesta
1. **Animaciones:** Duración de 150 a 180 ms (ver constantes `Tema.AnimacionRapida` y `Tema.AnimacionNormal`). Utilizar timers con intervalos de 16 ms (~60 fps) para desplazamientos suaves de indicadores.
2. **Feedback Inmediato:** Cuando una operación demore más de 300 ms, cambiar el cursor a `Cursors.WaitCursor` y presentar un mensaje temporal como `"Cargando información..."`.
