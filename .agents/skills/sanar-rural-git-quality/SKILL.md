---
name: sanar-rural-git-quality
description: "Guía de control de calidad, gestión de Git y estándares de entrega para Sanar Rural UNAN: inspección del estado de trabajo, verificación de whitespace con git diff --check, compilación limpia con MSBuild, commits atómicos en español/convencionales y políticas de no-commit/no-push sin autorización explícita."
---

# Habilidad Especializada: Calidad de Código y Git en Sanar Rural UNAN

Esta habilidad debe cargarse obligatoriamente antes de proponer cambios, validar entregas, generar reportes de diferencias (diff) o interactuar con el repositorio Git.

---

## 1. El Ciclo Obligatorio de Verificación

```
[ 1. Inspeccionar ] ──> [ 2. Modificar ] ──> [ 3. Verificar Formato ] ──> [ 4. Compilar ] ──> [ 5. Reportar ]
git status --short       Edición quirúrgica   git diff --check              MSBuild.exe        Diff raw
git log -1 --oneline     en scope asignado    (0 errores whitespace)        (0 errores C#)     completo
```

---

## 2. Inspección Previa al Trabajo
Antes de tocar cualquier archivo del proyecto:
1. Comprobar la rama activa y el estado del worktree:
   ```powershell
   git status --short --branch
   git log -1 --oneline
   ```
2. Si existen cambios previos sin commitear en el worktree, **preservarlos intactos** y no revertirlos a menos que el usuario lo solicite expresamente.

---

## 3. Verificación de Formato y Espaciado (`git diff --check`)
- Toda edición debe cumplir con estándares limpios de codificación sin trailing whitespace ni inconsistencias de fin de línea (CRLF/LF):
  ```powershell
  git diff --check
  ```
- Si `git diff --check` arroja alguna salida, debe corregirse de inmediato antes de dar por completada la tarea.

---

## 4. Compilación y Construcción del Proyecto
La validez del código en C# se certifica compilando el archivo de proyecto `.csproj` con MSBuild:
```powershell
& "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" SanarRuralUnan.csproj /t:Build /p:Configuration=Debug /verbosity:minimal
```
- **Criterio de Entrega:** **0 errores**.
- Si el build falla, el agente debe diagnosticar y corregir el error antes de presentar la solución al usuario.

---

## 5. Políticas de Git y Commits
1. **Regla de No-Commit / No-Push por Defecto:**
   - No ejecutar `git commit`, `git push`, `git checkout` a otra rama ni `git merge` salvo que la instrucción del usuario indique explícitamente hacerlo.
2. **Convención de Commits (cuando se autorice):**
   - Utilizar mensajes en español siguiendo el formato Conventional Commits:
     - `feat: descripción de nueva característica`
     - `fix: corrección de fallo identificado`
     - `chore: tareas de mantenimiento, configuración o reglas`
     - `docs: adición o ajuste de documentación`
3. **Commits Selectivos:**
   - Evitar `git add .` masivo si hay modificaciones paralelas en el worktree que no forman parte de la tarea en curso.
   - Agregar individualmente los archivos de la entrega: `git add ruta/archivo1 ruta/archivo2`.
4. **Protección de Ramas:**
   - No hacer merge directo a `main` desde el entorno local sin revisión o aprobación previa del equipo (José, Esther, Amarelis).

---

## 6. Estándar de Reporte de Diff
Cuando el usuario solicite los diffs, se deben proveer:
1. **DIFF RAW DE LA EJECUCIÓN:** Solo las modificaciones generadas en el turno actual.
2. **DIFF RAW COMPLETO DEL WORKTREE:** Todas las diferencias acumuladas respecto a `HEAD`, incluyendo cualquier archivo pendiente o untracked.
