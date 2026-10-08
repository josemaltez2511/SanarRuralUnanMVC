# Reglas Core de Ingeniería: Sanar Rural UNAN

Este documento establece las directrices técnicas obligatorias para cualquier intervención en el repositorio **SanarRuralUnan**. Aplica de forma vinculante para **Antigravity**, **Codex** y cualquier agente o desarrollador (José, Esther, Amarelis).

---

## 1. Stack Tecnológico y Restricciones de Plataforma
- **Plataforma:** Windows Forms (.NET Framework 4.7.2) en C#.
- **Base de Datos:** Microsoft SQL Server 2022.
- **ORM:** Entity Framework 6.5.2 (Database First, `ModelSanarRural.edmx`).
- **Librería de Componentes:** MaterialSkin 2 (versión 2.3.1).
- **Sistema de Identidad Visual:** `Helpers/Tema.cs`.

> ⛔ **PROHIBICIÓN ESTRICTA: NO ES ASP.NET**
> Este proyecto es una aplicación de escritorio WinForms tradicional. Está terminantemente prohibido incorporar Razor (`.cshtml`), controladores MVC web de ASP.NET, inyección de dependencias web, o dependencias de ASP.NET Core.

> ⛔ **CÓDIGO GENERADO POR ENTITY FRAMEWORK**
> Los archivos generados por `ModelSanarRural.tt` (clases POCO como `Doctores.cs`, `Pacientes.cs`, `Citas.cs`, `Consultas.cs`, etc.) y `ModelSanarRural.Context.cs` son código autogenerado. **Nunca deben editarse manualmente**. Toda extensión debe realizarse mediante clases parciales en archivos separados si fuera indispensable.

---

## 2. Arquitectura de Software: MVC Informal
La separación de responsabilidades debe respetarse rigurosamente en cada pantalla:
```
Vistas (Views) ──> Controladores (Controllers) ──> Modelos (Models) ──> EF6 / BD
```
1. **Vistas (`Views/`):**
   - Responsables exclusivas de la interfaz de usuario, captura de entradas, controles WinForms, selección de archivos y respuesta a eventos.
   - **Regla:** La Vista **NUNCA** interactúa de forma directa con `SanarRuralDBEntities` ni ejecuta sentencias SQL. Siempre delega en el Controlador.
2. **Controladores (`Controllers/`):**
   - Orquestan la comunicación entre la Vista y el Modelo.
   - Aplican validaciones de flujo de trabajo y transforman los parámetros necesarios.
3. **Modelos (`Models/`):**
   - Centralizan las consultas a Entity Framework, persistencia, validaciones de integridad referencial y transacciones.
   - Retornan entidades, DTOs o listas preparadas para su presentación.

---

## 3. Principios Obligatorios de Ingeniería
- **DRY (Don't Repeat Yourself):** Reutilizar helpers (`Tema.cs`), métodos existentes y estilos compartidos. No duplicar lógica de formateo, validación o mapeo.
- **KISS (Keep It Simple, Stupid):** Preferir soluciones directas, comprensibles y fáciles de depurar. No introducir sobrearquitectura, patrones abstractos innecesarios ni bibliotecas no acordadas para un proyecto universitario.
- **SRP (Single Responsibility Principle):** Cada clase y método debe tener un único propósito bien delimitado.
- **ACID (Atomicidad, Consistencia, Aislamiento, Durabilidad):**
  - Toda operación de negocio que involucre escrituras múltiples relacionadas (por ejemplo: crear una consulta con sus signos vitales, diagnósticos y prescripciones en un solo paso) debe ejecutarse bajo una transacción explícita (`using (var tx = db.Database.BeginTransaction())`) para evitar registros huérfanos o estados parciales.
  - No emplear transacciones innecesarias para operaciones unitarias simples.
- **Aislamiento del Scope:** No modificar código no relacionado con la tarea asignada ni aplicar refactorizaciones oportunistas en otros módulos.

---

## 4. Idioma del Código y Documentación
- **Comentarios Nuevos:** Todos los comentarios que se agreguen al código fuente deben estar redactados en **ESPAÑOL**.
- **Textos de UI y Validación:** Todos los mensajes para el usuario (`MessageBox`, etiquetas de ayuda, validaciones) deben estar en **ESPAÑOL**.
- **Claridad y Brevedad:** Evitar comentarios redundantes que describan lo obvio (ej. no escribir `// Asigna el texto` sobre `lbl.Text = "x"`). Conservar comentarios útiles que expliquen el *por qué* de la decisión técnica.
- **Identificadores:** No renombrar clases, métodos ni variables existentes si ello genera riesgo de ruptura o discrepancia con el esquema de base de datos.

---

## 5. UI/UX: Diseño Centrado en el Usuario (UCD)
La calidad visual y de usabilidad es prioridad de primer nivel:
1. **Scanabilidad Inmediata:** Al ver cualquier pantalla, el usuario debe identificar en segundos:
   - Dónde se encuentra (título claro y contexto).
   - Qué información relevante está disponible.
   - Cuáles son las acciones principales y secundarias.
2. **Sensación Visual:**
   - **Salud + Tecnología + Confianza + Naturaleza.**
   - **Evitar:** Estética de hospital frío, formularios grises genéricos, exceso de blanco clínico deslumbrante o interfaces saturadas.
3. **Fondo de Ventana Obligatorio:**
   - Usar `Tema.Fondo` (`#EDF7F0`). **Queda prohibido el blanco puro (`#FFFFFF`) como fondo general de ventanas o paneles contenedores**.
   - El color casi blanco `Tema.Superficie` (`#F9FCFA`) se reserva para tarjetas, paneles de contenido y áreas de trabajo activas.
4. **Paleta Oficial (`Helpers/Tema.cs`):**
   - Fondo: `#EDF7F0` | Fondo Secundario: `#E4F1E8` | Superficie: `#F9FCFA`
   - Azul Primario: `#2378B7` | Azul Oscuro: `#174A6B` | Azul Claro: `#58A9D2`
   - Verde: `#78B86A` | Verde Oscuro: `#4D8E56`
   - Texto Principal: `#173342` | Texto Secundario: `#597078` | Borde: `#CFE1D5`
   - Error: `#C65353` | Advertencia: `#D69A3A` | Éxito: `Tema.ColorExito` (`#4D8E56`)
5. **Tema.cs es la Biblia Visual:**
   - No instanciar `Color.FromArgb(...)` ni usar `Color.Red`, `Color.Blue`, etc. en los formularios si existe un valor equivalente en `Tema`.
   - MaterialSkin proporciona controles base; `Tema.cs` define la identidad visual integral.
6. **Jerarquía de Botones y Acciones:**
   - La acción principal debe ser la más destacada visualmente (ej. fondo `Tema.AzulPrimario`).
   - Las acciones secundarias deben ser discretas (texto plano o enlaces como `lnkVolver`).
   - Textos concisos: `+ Nuevo`, `Editar`, `Dar de baja`, `Volver`, `Guardar`, `Cancelar`.
   - Si se usan iconos, no deben ser la única señal: incorporar siempre `ToolTip` o texto descriptivo.
7. **Estados Visuales y Accesibilidad:**
   - Comunicar estados con icono/texto + color (ej. `✓ Activo`, `⚠ Pendiente`, `✕ Error`). Nunca depender exclusivamente del color.
   - Soportar navegación por teclado (`Tab`, `Enter`, `Escape`). Mantener orden lógico de `TabIndex`.
   - Asignar `AccessibleName` y `AccessibleDescription` en controles interactivos clave.
8. **Animaciones y Tiempos de Respuesta:**
   - Duración máxima recomendada: 150–200 ms. Sutiles y fluidas.
   - Si una operación toma tiempo (consultas pesadas), proveer retroalimentación visual clara (ej. "Cargando datos...").

---

## 6. Navegación entre Módulos
- El flujo de la aplicación se estructura a través de shells contenedores (`menuPrincipalAdministrativo`, `menuPrincipalMedicos`).
- Las páginas de listado se cargan dentro del panel de contenido del shell.
- Evitar secuencias desordenadas de `Hide()`, `Show()`, `Close()`.
- Los formularios de creación/edición deben abrirse como modales (`ShowDialog(this)`) retornando `DialogResult.OK` al completar la acción satisfactoriamente.

---

## 7. Protocolo de Calidad y Control de Versiones
1. **Lectura previa obligatoria en orden estricto antes de modificar cualquier archivo del proyecto:**
   - **1.** `AGENTS.md` (contrato general de desarrollo).
   - **2.** `.agents/rules/00-sanar-rural-core.md` (reglas permanentes de stack, arquitectura y UI/UX).
   - **3.** `docs/AI/PROJECT_CONTEXT.md` (contexto estable de roles, módulos y negocio).
   - **4.** La skill correspondiente al dominio de la tarea (`sanar-rural-ui-ux`, `sanar-rural-architecture`, `sanar-rural-database`, `sanar-rural-clinical` o `sanar-rural-git-quality`).
2. **Inspección de Git:** Ejecutar `git status --short --branch` y `git log -1 --oneline`.
3. **Durante la edición:** Aplicar cambios quirúrgicos enfocados en la tarea solicitada.
4. **Validación post-edición:**
   - Ejecutar `git diff --check` (cero errores de formato/espaciado).
   - Compilar el proyecto con MSBuild y verificar **cero errores de compilación**.
5. **Restricción de Git:** No realizar `commit`, `push` ni cambio de rama a menos que el usuario lo solicite de manera explícita en su instrucción.
6. **Protección Absoluta de Configuración Local (`App.config`):**
   - `App.config` es un archivo de uso local exclusivo y está ignorado por Git.
   - Queda estrictamente prohibido a los agentes de IA modificar `App.config` en tareas rutinarias, ejecutar `git add App.config` o `git add -f App.config`, incluirlo en commits o alterar las credenciales locales de los desarrolladores.
   - Para documentación y soporte, utilizar exclusivamente la plantilla `App.config.example`.
