---
name: sanar-rural-clinical
description: "Guía de dominio médico y reglas clínicas para Sanar Rural UNAN: separación conceptual Cita vs. Consulta, estructura del expediente médico, signos vitales, diagnósticos, prescripciones, ética de datos y preservación de la integridad histórica del paciente."
---

# Habilidad Especializada: Dominio Clínico en Sanar Rural UNAN

Esta habilidad debe cargarse obligatoriamente al trabajar en pantallas, modelos, controladores o lógica de negocio vinculados a **Citas**, **Consultas**, **Signos Vitales**, **Diagnósticos**, **Prescripciones** o **Historial Médico**.

---

## 1. Distinción Vital: Cita vs. Consulta
En Sanar Rural, **Cita y Consulta son dos entidades conceptual y técnicamente diferentes**:

| Dimensión | Cita (`Citas.cs`) | Consulta (`Consultas.cs`) |
|---|---|---|
| **Propósito** | Planificación temporal y logística del encuentro médico. | Registro del acto médico presencial y evolución clínica. |
| **Momento** | Se crea días o semanas antes de la atención. | Se crea en el instante en que el médico atiende al paciente. |
| **Campos clave** | `FechaHoraProgramada`, `Estado` (Pendiente, Confirmada, Atendida, Cancelada, NoAsistio), `Motivo`. | `FechaHoraInicio`, `FechaHoraFin`, `PadecimientoActual`, `ExamenFisico`, `Observaciones`, `PlanSeguimiento`. |
| **Cardinalidad** | 1 Cita puede generar 1 Consulta médica. | 1 Consulta pertenece estrictamente a 1 Cita (`IdCita`). |

> ⚠️ **REGLA ESTRICTA:**  
> **Nunca fusionar la Cita con la Consulta**. La Cita no debe almacenar signos vitales ni diagnósticos; esos datos pertenecen exclusivamente a `Consultas`.

---

## 2. Estructura de la Consulta Clínica
Una consulta formal en Sanar Rural actúa como el nodo contenedor de tres componentes clínicos:

```
[ Consultas ]
    ├── 0..1 ──> [ SignosVitales ]    (Presión sistólica/diastólica, FC, FR, Temp, SpO2, Peso, Talla)
    ├── 1:N  ──> [ Diagnosticos ]     (Tipo: Principal, Secundario, Presuntivo, Diferencial)
    └── 1:N  ──> [ Prescripciones ]   (IdMedicamento, Dosis, Frecuencia, Duración, Vía)
```

1. **Signos Vitales (`SignosVitales.cs`):**
   - Cardinalidad 0..1: Cada consulta clínica registra a lo sumo una toma de signos vitales asociada al encuentro.
   - Rango numérico y unidades clínicas estándar:
     - Presión arterial: Sistólica / Diastólica (mmHg).
     - Frecuencia Cardíaca: lpm.
     - Frecuencia Respiratoria: rpm.
     - Temperatura: °C (decimal).
     - Saturación de Oxígeno (SpO2): porcentaje (0–100%).
     - Peso (Kg) y Talla (cm).
   - Validar coherencia física en la UI antes del guardado.
2. **Diagnósticos (`Diagnosticos.cs`):**
   - Todo diagnóstico se relaciona opcionalmente con un catálogo de `Enfermedades` y clasifica el `TipoDiagnostico` con uno de los valores oficiales: `Principal`, `Secundario`, `Presuntivo` o `Diferencial`.
   - **Regla Ética:** El sistema **NO genera diagnósticos automáticos**. Registra fidedignamente la conclusión del médico responsable.
3. **Prescripciones (`Prescripciones.cs`):**
   - Requiere medicamento (`IdMedicamento`), posología (`Dosis`, `Frecuencia`, `Duración`, `ViaAdministracion`) y flag de sustitución (`PermiteSustitucion`).

---

## 3. Integridad Histórica del Expediente
- Las consultas médicas completadas constituyen un documento legal y ético de atención en salud.
- **Inmutabilidad tras cierre:** Una vez que `FechaHoraFin` se registra y la consulta pasa a estado finalizado, los diagnósticos y signos vitales no deben ser alterados arbitrariamente.
- Si se requiere una rectificación clínica, el diseño contempla notas médicas adicionales u observaciones en consultas posteriores, no la sobreescritura destructiva de registros pasados.

---

## 4. Flujo Clínico Operativo Recomendado
1. **Recepción:** El paciente llega con una cita programada en estado `Pendiente`.
2. **Preclínica / Triage:** Registro preliminar de signos vitales.
3. **Atención Médica:** El doctor abre el formulario clínico desde `menuPrincipalMedicos`.
4. **Captura:** Anamnesis (`PadecimientoActual`), examen físico, revisión de signos vitales, definición de diagnósticos y emisión de recetas.
5. **Cierre Atómico:** Guardar la consulta completa en una transacción (ver `sanar-rural-database`), marcando la cita como `Atendida`.
