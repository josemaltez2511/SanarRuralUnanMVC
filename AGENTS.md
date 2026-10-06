# Contrato General para Agentes de Programación: Sanar Rural UNAN

Bienvenido al repositorio **SanarRuralUnan**. Este documento es el contrato general vinculante para **Codex**, **Antigravity** y cualquier otro asistente o agente de inteligencia artificial que colabore en el proyecto junto a **José, Esther y Amarelis**.

---

## 1. Protocolo Obligatorio Antes de Modificar Código
Cualquier agente que participe en este repositorio debe seguir estrictamente este orden antes de realizar la primera modificación:

1. **Inspeccionar el estado de Git:**
   Ejecutar `git status --short --branch` y `git log -1 --oneline` para conocer la rama de trabajo y los archivos en el worktree.
2. **Leer `AGENTS.md` completo:**
   Interiorizar este contrato general de colaboración.
3. **Leer `.agents/rules/00-sanar-rural-core.md` completo:**
   Conocer las reglas de stack, restricciones de no-ASP.NET y directrices técnicas permanentes.
4. **Leer `docs/AI/PROJECT_CONTEXT.md`:**
   Obligatorio cuando la tarea requiera comprender la arquitectura global, roles de usuario, módulos existentes o flujo clínico.
5. **Identificar y cargar la habilidad especializada (Skill):**
   Determinar cuál de las skills del repositorio aplica a la tarea y leer el archivo `SKILL.md` correspondiente antes de escribir una sola línea de código.

---

## 2. Reglas de Carga Obligatoria de Skills
Las skills alojadas en `.agents/skills/` **no son opcionales** cuando la tarea involucre su dominio respectivo:

| Tipo de Tarea | Skill Obligatoria | Ruta del Archivo |
|---|---|---|
| Modificación o creación de pantallas, controles, colores, responsive, accesibilidad | `sanar-rural-ui-ux` | `.agents/skills/sanar-rural-ui-ux/SKILL.md` |
| Organización de clases, flujo View-Controller-Model, ciclo de vida o nuevas pantallas | `sanar-rural-architecture` | `.agents/skills/sanar-rural-architecture/SKILL.md` |
| Consultas LINQ, transacciones, Entity Framework 6, tablas, EDMX o scripts SQL | `sanar-rural-database` | `.agents/skills/sanar-rural-database/SKILL.md` |
| Citas, Consultas médicas, Signos Vitales, Diagnósticos, Prescripciones o Historial | `sanar-rural-clinical` | `.agents/skills/sanar-rural-clinical/SKILL.md` |
| Formateo, verificación con `git diff --check`, compilación MSBuild, commits o diffs | `sanar-rural-git-quality` | `.agents/skills/sanar-rural-git-quality/SKILL.md` |

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
