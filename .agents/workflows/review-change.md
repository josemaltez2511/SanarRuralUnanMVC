# Workflow de Revisión de Cambios: Sanar Rural UNAN

Este flujo de trabajo estandarizado debe ejecutarse al auditar, revisar o finalizar cualquier bloque de trabajo antes de presentarlo al equipo de desarrollo (José, Esther, Amarelis).

---

## Pasos del Proceso de Revisión

### Paso 1: Inspeccionar Estado del Repositorio
Verificar la rama activa y el listado de archivos modificados o sin seguimiento:
```powershell
git status --short --branch
git log -1 --oneline
```

### Paso 2: Revisar Diff Cuantitativo y Cualitativo
Examinar las líneas agregadas, modificadas y eliminadas:
```powershell
git diff --stat
git diff
```
Confirmar que no se hayan introducido cambios accidentales o no relacionados con la tarea asignada.

### Paso 3: Revisar Arquitectura y Separación de Capas
- ¿La Vista (`Views/`) contiene consultas directas a base de datos o referencias a `SanarRuralDBEntities`? (Si es sí: corregir de inmediato moviéndolas al Modelo a través del Controlador).
- ¿El Controlador orquesta adecuadamente sin acumular lógica pesada de persistencia?
- ¿El Modelo encapsula las operaciones con Entity Framework 6?

### Paso 4: Revisar Principios DRY / KISS / SRP
- **DRY:** ¿Se reutilizan métodos existentes y constantes de `Helpers/Tema.cs` en lugar de duplicar lógica?
- **KISS:** ¿La solución es la más simple y directa posible? ¿Se evitaron abstracciones o dependencias superfluas?
- **SRP:** ¿Cada clase y método modificado cumple un único propósito claro?

### Paso 5: Revisar Impacto en Base de Datos y Persistencia
- ¿Se respetó el principio ACID? En escrituras de múltiples entidades dependientes, ¿se empleó una transacción?
- ¿Se protegieron las entidades autogeneradas (`ModelSanarRural.tt`) sin editarlas a mano?
- ¿Se mantuvo el filtrado por borrado lógico (`Estado == true`) en consultas a entidades principales?

### Paso 6: Revisar UI/UX y Dirección Visual (si aplica)
- ¿Se respetó el fondo de ventana obligatorio `Tema.Fondo` (`#EDF7F0`), evitando blanco plano (`#FFFFFF`)?
- ¿La paleta se apega estrictamente a `Helpers/Tema.cs`?
- ¿La pantalla es escaneable en 3 segundos (dónde está el usuario, qué información ve, cuál es la acción principal)?
- ¿Se implementó un diseño responsivo con `Anchor`, `Dock` o cálculo en `Resize`?

### Paso 7: Revisar Accesibilidad (si aplica)
- ¿Los controles interactivos cuentan con `TabIndex` lógico para navegación por teclado?
- ¿Se asignaron `AccessibleName` y `AccessibleDescription` en campos y combos relevantes?
- ¿Los estados visuales combinan color con texto o iconos descriptivos (`✓ Activo`, `⚠ Pendiente`, `✕ Error`)?

### Paso 8: Ejecutar Verificación de Formato y Espaciado
Comprobar que no existan errores de whitespace o fines de línea incorrectos:
```powershell
git diff --check
```
El resultado debe ser estrictamente limpio (salida vacía, código de salida 0).

### Paso 9: Compilar y Validar Integridad de la Solución
Ejecutar el build con MSBuild sobre `SanarRuralUnan.csproj`:
```powershell
& "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" SanarRuralUnan.csproj /t:Build /p:Configuration=Debug /verbosity:minimal
```
Confirmar que el resultado finalice con **0 errores y 0 advertencias**.

### Paso 10: Generar Resumen del Cambio
Redactar una explicación técnica clara en español explicando:
- Qué problema o requerimiento se resolvió.
- Cómo interactúan las capas modificadas.
- Confirmación de no afectación a otros módulos.

### Paso 11: Generar DIFF RAW DE LA EJECUCIÓN
Extraer el diff específico de los archivos tocados durante la sesión actual.

### Paso 12: Generar DIFF RAW COMPLETO DEL WORKTREE
Extraer todas las diferencias acumuladas del worktree respecto al último commit (`HEAD`), incluyendo archivos untracked si corresponde.
