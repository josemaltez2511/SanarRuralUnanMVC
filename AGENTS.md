# Contrato General para Agentes de Programación: Sanar Rural UNAN

Bienvenido al repositorio **SanarRuralUnan**. Este documento es el contrato general vinculante para **Codex**, **Antigravity** y cualquier otro asistente o agente de inteligencia artificial que colabore en el proyecto junto a **José, Esther y Amarelis**.

---

## 1. Protocolo Obligatorio Antes de Modificar Cualquier Archivo del Proyecto
Cualquier agente (Codex, Antigravity u otro) que participe en este repositorio debe seguir estrictamente este protocolo **ANTES DE MODIFICAR CUALQUIER ARCHIVO DEL PROYECTO**:

1. **Inspeccionar el estado de Git:**
   Ejecutar `git status --short --branch` y `git log -1 --oneline` para conocer la rama de trabajo y los archivos en el worktree.
2. **Leer obligatoriamente los documentos base en este orden estricto:**
   1. `AGENTS.md` (interiorizar este contrato general de colaboración).
   2. `.agents/rules/00-sanar-rural-core.md` (reglas técnicas permanentes, stack, UI/UX, arquitectura y restricciones).
   3. `docs/AI/PROJECT_CONTEXT.md` (contexto estable del proyecto, roles, arquitectura, módulos y reglas de negocio).
3. **Identificar y leer la skill correspondiente a la tarea:**
   Determinar cuál de las skills del repositorio aplica a la tarea y leer el archivo `SKILL.md` correspondiente antes de escribir o modificar una sola línea de código:
   - **UI/UX** ──> `sanar-rural-ui-ux` (`.agents/skills/sanar-rural-ui-ux/SKILL.md`)
   - **Arquitectura / C#** ──> `sanar-rural-architecture` (`.agents/skills/sanar-rural-architecture/SKILL.md`)
   - **BD / SQL / EF / EDMX** ──> `sanar-rural-database` (`.agents/skills/sanar-rural-database/SKILL.md`)
   - **Citas / Consultas / Historial** ──> `sanar-rural-clinical` (`.agents/skills/sanar-rural-clinical/SKILL.md`)
   - **Git / calidad / diffs / build** ──> `sanar-rural-git-quality` (`.agents/skills/sanar-rural-git-quality/SKILL.md`)

---

## 2. Reglas de Carga Obligatoria de Skills
Las skills alojadas en `.agents/skills/` **no son opcionales** cuando la tarea involucre su dominio respectivo:

| Tipo de Tarea | Skill Obligatoria | Ruta del Archivo |
|---|---|---|
| UI/UX (pantallas, controles, colores, responsive, accesibilidad) | `sanar-rural-ui-ux` | `.agents/skills/sanar-rural-ui-ux/SKILL.md` |
| Arquitectura / C# (organización de clases, flujo View-Controller-Model, ciclo de vida) | `sanar-rural-architecture` | `.agents/skills/sanar-rural-architecture/SKILL.md` |
| BD / SQL / EF / EDMX (consultas LINQ, transacciones, Entity Framework 6, tablas, EDMX) | `sanar-rural-database` | `.agents/skills/sanar-rural-database/SKILL.md` |
| Citas / Consultas / Historial (dominio clínico, signos vitales, diagnósticos, prescripciones) | `sanar-rural-clinical` | `.agents/skills/sanar-rural-clinical/SKILL.md` |
| Git / calidad / diffs / build (verificación con `git diff --check`, compilación MSBuild, diffs) | `sanar-rural-git-quality` | `.agents/skills/sanar-rural-git-quality/SKILL.md` |

---

## 3. Mandamientos de Ingeniería del Repositorio

1. **Idioma Oficial:** Todos los comentarios **nuevos** agregados al código fuente y las explicaciones técnicas deben estar en **ESPAÑOL**. No introducir comentarios en inglés.
2. **Principios de Software:**
   - **DRY:** Reutilizar métodos, validadores y constantes. No duplicar lógica existente.
   - **KISS:** Mantener implementaciones simples, limpias y directas. No sobrearquitecturar una aplicación universitaria.
   - **SRP:** Respetar la separación: la Vista presenta e interactúa, el Controlador coordina y el Modelo persiste.
   - **ACID:** Usar transacciones explícitas en operaciones multimodificación que requieran atomicidad.
3. **Diseño Centrado en el Usuario (UCD) e Identidad Visual:**
   - La pantalla debe ser escaneable y comprensible en 3 segundos.
   - **`Helpers/Tema.cs` es la biblia visual:** No crear colores arbitrarios con `Color.FromArgb(...)`.
   - **Fondo general obligatorio:** `Tema.Fondo` (`#EDF7F0`). **Prohibido el fondo blanco plano (`#FFFFFF`)**.
4. **Integridad del Repositorio y Restricciones:**
   - **No tocar entidades autogeneradas:** Archivos generados por `ModelSanarRural.tt` nunca se editan a mano.
   - **No tocar código fuera de alcance:** No modificar módulos no relacionados ni aplicar refactorizaciones fortuitas.
   - **No Commit / No Push no autorizados:** No realizar commits ni push al repositorio remoto salvo instrucción explícita del usuario.
   - **No merge a main:** Todo trabajo se mantiene en su rama funcional correspondiente.
5. **Aislamiento Estricto de Configuración Local (`App.config`):**
   - **`App.config` es de uso exclusivamente local:** Queda terminantemente prohibido editar `App.config` como parte de una tarea rutinaria.
   - **Prohibición en Git:** Queda estrictamente prohibido ejecutar `git add App.config`, `git add -f App.config` o incluir `App.config` en commits.
   - **Preservación de entornos individuales:** Prohibido copiar, asumir o sobrescribir la cadena de conexión o nombre de instancia de otro desarrollador (José, Esther, Amarelis).
   - **Plantilla Oficial:** Cualquier referencia documental, soporte o ejemplo debe basarse única y exclusivamente en `App.config.example`.
