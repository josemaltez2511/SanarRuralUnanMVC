# Matriz de Trazabilidad y Estado de Implementación: Sanar Rural UNAN

**Repositorio:** SanarRuralUnan / SanarRuralUnanMVC  
**Rama:** `main`  
**Fecha de corte:** 9 de octubre de 2026  
**Auditoría:** Auditoría Final Independiente y Validación Integral en Entorno Local  
**Stack tecnológico:** Windows Forms (.NET Framework 4.7.2, C# 7.3), Microsoft SQL Server 2022 (`localhost\SQLEXPRESS02`), Entity Framework 6.5.2 Database First (`ModelSanarRural.edmx`), MaterialSkin 2, `Helpers/Tema.cs`.

---

## 1. Resumen Ejecutivo del Estado del Sistema

| Módulo / Capacidad | Roles Autorizados | Vistas / Formularios | Controladores | Modelos | Tablas de BD | Estado | Cobertura / Pruebas |
|---|---|---|---|---|---|---|---|
| **Autenticación y Sesión** | Todos (Administrativo, Doctor, Paciente) | `Views/IniciarSesion/iniciarSesion.cs` | `usuariosControllers.cs` | `usuariosModels.cs` | `Usuarios`, `Roles` | **Verificado (100%)** | PBKDF2-SHA256, sal aleatoria, enrutamiento condicional y cierre de sesión limpio. |
| **Gestión de Usuarios** | Administrativo | `Views/Usuarios/paginaPrincipalUsuarios.cs`, `crearUsuario.cs` | `usuariosControllers.cs` | `usuariosModels.cs` | `Usuarios`, `Roles` | **Verificado (100%)** | CRUD de cuentas, validación de correo único, hash criptográfico y asignación de rol. |
| **Gestión de Hospitales / Sedes** | Administrativo | `Views/Hospitales/paginaPrincipalHospitales.cs`, `crearHospital.cs` | `hospitalesController.cs` | `hospitalesModels.cs` | `Hospitales`, `Municipios`, `Departamentos` | **Verificado (100%)** | Listado con badges de estado, alta/edición, cascada de departamentos y municipios. |
| **Gestión de Doctores** | Administrativo | `Views/Doctores/paginaPrincipalDoctores.cs`, `crearDoctor.cs` | `doctoresControllers.cs` | `doctoresModels.cs` | `Doctores`, `Especialidades`, `DoctorEspecialidad`, `DoctorHospitalEspecialidad` | **Verificado (100%)** | Aprobado visualmente. Multiespecialidad, asignación hospitalaria, foto y cédula. |
| **Gestión de Pacientes** | Administrativo, Doctor (Lectura y Alta) | `Views/Pacientes/paginaPrincipalPacientes.cs`, `crearPaciente.cs`, `fichaPaciente.cs` | `pacientesControllers.cs` | `pacientesModels.cs` | `Pacientes`, `Comunidades`, `Municipios`, `Departamentos`, `ContactosEmergencia` | **Verificado (100%)** | Aprobado visualmente. Contactos 1:N atómicos, cascada geográfica, cédula nicaragüense e INSS. |
| **Perfil del Paciente (Autogestión)** | Paciente | `Views/Pacientes/perfilPaciente.cs` | `pacientesControllers.cs` | `pacientesModels.cs` | `Pacientes`, `ContactosEmergencia`, `Comunidades` | **Verificado (100%)** | Edición restringida a datos demográficos y contactos. Bloqueo estricto de antecedentes y datos legales. |
| **Programación y Ciclo de Citas** | Administrativo, Doctor, Paciente | `Views/Citas/paginaPrincipalCitas.cs`, `crearCita.cs`, `fichaCita.cs` | `citasControllers.cs` | `citasModels.cs` | `Citas`, `Pacientes`, `DoctorHospitalEspecialidad`, `Doctores`, `Hospitales`, `Especialidades` | **Verificado (100%)** | Estados `Pendiente`, `Confirmada`, `Atendida`, `Cancelada`, `NoAsistio`. Validación de solapamiento horario. |
| **Atención de Consultas Clínicas** | Doctor | `Views/ConsultaMedica/paginaPrincipalConsultas.cs`, `seleccionarCitaConsulta.cs`, `atencionConsulta.cs` | `consultasControllers.cs` | `consultasModels.cs` | `Consultas`, `SignosVitales`, `Diagnosticos`, `Prescripciones`, `Medicamentos`, `Enfermedades` | **Verificado (100%)** | Borradores en proceso, cierre atómico con transacción ACID, diagnóstico principal obligatorio y paso de cita a `Atendida`. |
| **Historial Clínico Integral** | Doctor, Paciente, Administrativo (Auditoría) | `Views/HistorialClinico/paginaPrincipalHistorial.cs`, `atencionConsulta.cs` (Lectura) | `consultasControllers.cs` | `consultasModels.cs` | `Consultas`, `Citas`, `Pacientes`, `Diagnosticos`, `SignosVitales`, `Prescripciones` | **Verificado (100%)** | Visualización cronológica, búsqueda por paciente o vista acotada al paciente autenticado. Modal en modo lectura. |
| **Shell Menú Administrativo** | Administrativo | `Views/Menu/menuPrincipalAdministrativo.cs` | Varios | Varios | Varias | **Verificado (100%)** | Navegación embebida: Usuarios, Doctores, Pacientes, Hospitales, Citas. |
| **Shell Menú Médicos** | Doctor | `Views/Menu/menuPrincipalMedicos.cs` | Varios | Varios | Varias | **Verificado (100%)** | Navegación embebida: Pacientes, Citas, Consultas, Historial Clínico Integral (sin placeholders). |
| **Shell Menú Pacientes** | Paciente | `Views/Menu/menuPrincipalPacientes.cs` | Varios | Varios | Varias | **Verificado (100%)** | Navegación embebida: Mi Perfil, Mis Citas, Mi Historial Clínico. |

---

## 2. Detalle de Módulos y Evidencia Técnica de la Auditoría

### 2.1 Autenticación y Enrutamiento por Rol (`Views/IniciarSesion`)
- **Archivos:** `Views/IniciarSesion/iniciarSesion.cs`, `iniciarSesion.Designer.cs`, `Controllers/usuariosController.cs`, `Models/usuariosModels.cs`.
- **Comportamiento verificado:**
  - Criptografía: Algoritmo `PBKDF2-SHA256` con sal aleatoria de 16 bytes y 600,000 iteraciones (`VersionHash = PBKDF2-SHA256$1`).
  - Al autenticar rol `Doctor`, instancia `menuPrincipalMedicos.cs` con el identificador del facultativo resuelto.
  - Al autenticar rol `Administrativo`, instancia `menuPrincipalAdministrativo.cs`.
  - Al autenticar rol `Paciente`, resuelve el identificador del paciente vía `IdUsuario` e instancia `menuPrincipalPacientes.cs`.
  - Cierre de sesión voluntario: reinicia sesión en memoria y regresa a la pantalla de login limpia.

### 2.2 Portal del Paciente y Autogestión Demográfica (`Views/Menu/menuPrincipalPacientes`, `perfilPaciente`)
- **Archivos:**
  - `Views/Menu/menuPrincipalPacientes.cs`, `menuPrincipalPacientes.Designer.cs`, `menuPrincipalPacientes.resx`
  - `Views/Pacientes/perfilPaciente.cs`, `perfilPaciente.Designer.cs`, `perfilPaciente.resx`
- **Reglas de autorización y seguridad:**
  - El paciente únicamente puede consultar y modificar su propia ficha demográfica.
  - Campos editables por el paciente: Teléfono, Comunidad (con cascada de departamento y municipio), Dirección física y Contactos de Emergencia (1:N).
  - Campos bloqueados de solo lectura: Nombres, Apellidos, Cédula de Identidad, Número INSS, Fecha de Nacimiento, Género, Tipo de Sangre, Alergias y Antecedentes Clínicos.
  - Toda modificación se realiza de forma atómica en base de datos.
  - Blindaje contra falsificación: el método `actualizarPerfilDemograficoPaciente` rechaza llamadas con identificadores ajenos y rechaza al rol Doctor.
  - El método general `actualizarPaciente` rechaza explícitamente al rol Paciente y al rol Doctor.

### 2.3 Historial Clínico Integral (`Views/HistorialClinico`)
- **Archivos:**
  - `Views/HistorialClinico/paginaPrincipalHistorial.cs`, `paginaPrincipalHistorial.Designer.cs`, `paginaPrincipalHistorial.resx`
  - `Controllers/consultasControllers.cs`, `Models/consultasModels.cs`
- **Comportamiento por rol:**
  - **Doctor:** Permite buscar pacientes por nombre o cédula y consultar su historial cronológico completo de atenciones realizadas en cualquier sede o facultativo, garantizando continuidad asistencial.
  - **Paciente:** Bloquea selector de pacientes y exhibe estrictamente las atenciones clínicas finalizadas del paciente en sesión.
  - **Administrativo:** Modo de consulta y supervisión de expedientes clínicos históricos.
  - **Visualización:** Al hacer clic en "👁️ Ver", despliega `atencionConsulta` en modo estricto de solo lectura, con signos vitales, evolución, diagnósticos CIE y recetas farmacológicas emitidas.

### 2.4 Ciclo de Vida de Citas Médicas (`Views/Citas`)
- **Archivos:** `Views/Citas/paginaPrincipalCitas.cs`, `crearCita.cs`, `fichaCita.cs`, `Controllers/citasControllers.cs`, `Models/citasModels.cs`.
- **Transiciones soportadas:**
  - `Pendiente` ➔ `Confirmada` (Doctor / Administrativo).
  - `Pendiente` ➔ `Cancelada` (Paciente sobre su propia cita, Doctor sobre su cita, Administrativo).
  - `Confirmada` ➔ `Cancelada` (Doctor sobre su cita, Administrativo).
  - `Pendiente` o `Confirmada` ➔ `NoAsistio` (Únicamente cuando `FechaHoraProgramada < DateTime.Now`).
  - `Pendiente` o `Confirmada` ➔ `Atendida` (Exclusivamente tras la finalización atómica de la consulta médica correspondiente).
  - Los estados `Atendida`, `Cancelada` y `NoAsistio` son terminales e inmutables.
- **Validaciones:** Se previene solapamiento horario de citas simultáneas tanto a nivel del médico como del paciente.

### 2.5 Ciclo de Vida de Consultas Clínicas (`Views/ConsultaMedica`)
- **Archivos:** `Views/ConsultaMedica/paginaPrincipalConsultas.cs`, `seleccionarCitaConsulta.cs`, `atencionConsulta.cs`, `Controllers/consultasControllers.cs`, `Models/consultasModels.cs`.
- **Operaciones:**
  1. Selección de cita elegible (estado `Pendiente` o `Confirmada`, sin consulta previa).
  2. Inicio de consulta médica: asignación de `FechaHoraInicio` y estado `EnProceso`. Bloqueo de duplicados para la misma cita.
  3. Guardado recurrente de borradores: notas clínicas, signos vitales preliminares (preservando nulos sin ceros engañosos), diagnósticos provisionales y recetas.
  4. Finalización formal:
     - Validación obligatoria de al menos un diagnóstico principal.
     - Transacción explícita ACID que persiste la consulta, signos vitales, diagnósticos y recetas, asigna `FechaHoraFin`, marca la consulta como `Finalizada` y actualiza la cita a `Atendida`.
     - Inmutabilidad posterior del acto médico concluido (los borradores posteriores son rechazados).

---

## 3. Matriz de Pruebas Ejecutadas contra SQL Server

Todas las pruebas fueron ejecutadas contra la base de datos real `SanarRuralDB` en la instancia local `localhost\SQLEXPRESS02`.

| ID | Caso de Prueba | Rol Ejecutor | Acción / Validación | Resultado Obtenido | Estado |
|---|---|---|---|---|---|
| **CP-01** | Autenticación Paciente | Paciente (`amarelis@paciente.com`) | Iniciar sesión y obtener rol | Rol = Paciente (`IdRol = 1`), sesión activa | **PASS** |
| **CP-02** | Resolución Perfil Paciente | Paciente | Resolver `IdPaciente` por `IdUsuario` en sesión | `IdPaciente = 1` resuelto correctamente | **PASS** |
| **CP-03** | Consulta Expediente Propio | Paciente | Leer ficha médica propia | Datos completos de Jose Antonio García López | **PASS** |
| **CP-04** | Actualización Demográfica Válida | Paciente | Actualizar teléfono y dirección de residencia | Persistencia exitosa en SQL Server | **PASS** |
| **CP-05** | Rechazo Forja de Identidad | Paciente | Intentar actualizar demográficos de paciente ajeno (`IdPaciente = 999`) | `InvalidOperationException` lanzada: autorización denegada | **PASS** |
| **CP-06** | Bloqueo Edición Civil por Paciente | Paciente | Intentar llamar a `actualizarPaciente` (expediente legal/maestro) | `InvalidOperationException` lanzada: rol Paciente no autorizado | **PASS** |
| **CP-07** | Consulta Citas Propias | Paciente | Listar citas acotadas al paciente | Devuelve 1 cita programada del paciente | **PASS** |
| **CP-08** | Consulta Historial Finalizado | Paciente | Listar atenciones clínicas finalizadas | Devuelve 1 consulta finalizada en solo lectura | **PASS** |
| **CP-09** | Bloqueo Acción Médica por Paciente | Paciente | Intentar llamar a `iniciarConsulta` | `InvalidOperationException` lanzada: no autorizado | **PASS** |
| **CP-10** | Autenticación Doctor | Doctor (`abraham@maltez.com`) | Iniciar sesión y obtener rol | Rol = Doctor (`IdRol = 2`), sesión activa | **PASS** |
| **CP-11** | Resolución Perfil Facultativo | Doctor | Resolver `IdDoctor` por `IdUsuario` en sesión | `IdDoctor = 1` resuelto correctamente | **PASS** |
| **CP-12** | Bloqueo Edición Civil por Doctor | Doctor | Intentar llamar a `actualizarPaciente` (expediente maestro) | `InvalidOperationException` lanzada: edición civil exclusiva de Administrativo | **PASS** |
| **CP-13** | Bloqueo Demográfico Personal por Doctor | Doctor | Intentar llamar a `actualizarPerfilDemograficoPaciente` | `InvalidOperationException` lanzada: Doctor no autorizado | **PASS** |
| **CP-14** | Citas Elegibles de Doctor | Doctor | Listar citas asignadas al facultativo | Listado de citas asignadas obtenido sin errores | **PASS** |
| **CP-15** | Autenticación Administrativo | Administrativo (`abraham@admin.com`) | Iniciar sesión y obtener rol | Rol = Administrativo (`IdRol = 3`), sesión activa | **PASS** |
| **CP-16** | Bloqueo Inicio Consulta por Admin | Administrativo | Intentar llamar a `iniciarConsulta` | `InvalidOperationException` lanzada: no autorizado | **PASS** |
| **CP-17** | Bloqueo Borrador Clínico por Admin | Administrativo | Intentar llamar a `guardarBorradorConsulta` | `InvalidOperationException` lanzada: perfil estrictamente solo lectura | **PASS** |
| **CP-18** | Bloqueo Finalización Clínica por Admin | Administrativo | Intentar llamar a `finalizarConsulta` | `InvalidOperationException` lanzada: perfil estrictamente solo lectura | **PASS** |
| **CP-19** | Supervisión Solo Lectura de Admin | Administrativo | Consultar detalle de consulta finalizada | Acceso de supervisión concedido con `EstadoConsulta = Finalizada` | **PASS** |
| **CP-20** | Inmutabilidad Consulta Finalizada | Doctor | Intentar modificar borrador de consulta finalizada | `InvalidOperationException` lanzada: consulta finalizada inmutable | **PASS** |
| **CP-21** | Prevención Cita Duplicada en Consulta | Doctor | Intentar iniciar consulta sobre cita ya atendida/registrada | `InvalidOperationException` lanzada: cita ya cuenta con consulta | **PASS** |
| **CP-22** | Preservación de Nulos en Signos Vitales | Doctor | Leer signos vitales de consulta sin datos numéricos falsos | Nulos preservados sin ceros engañosos | **PASS** |

**Total de Pruebas Automatizadas:** 22  
**Pruebas Exitosas:** 22 (100 %)  
**Pruebas Fallidas:** 0  

---

## 4. Deficiencias Detectadas y Corregidas durante la Auditoría

1. **Separación Estricta de Roles en `Models/pacientesModels.cs` (`actualizarPaciente`):**
   - *Deficiencia:* Anteriormente solo se comprobaba si el rol era `Paciente`. El rol `Doctor` podía invocar la actualización civil/maestra de pacientes.
   - *Corrección:* Se implementó validación exhaustiva de los tres roles: se permite únicamente `Administrativo`, y se rechaza explícitamente al rol `Doctor` ("El rol Doctor no tiene autorización para modificar el expediente maestro civil o institucional del paciente...") y al rol `Paciente`.
2. **Protección de `actualizarPerfilDemograficoPaciente` contra Rol Doctor:**
   - *Deficiencia:* No se discriminaba si el solicitante era un médico intentando invocar la autogestión demográfica.
   - *Corrección:* Rechazo inmediato si el rol de sesión es `Doctor`. Se exige rol `Administrativo` o rol `Paciente` con coincidencia exacta de `IdUsuario`.
3. **Control de Perfiles Duplicados en `guardarPaciente`:**
   - *Deficiencia:* No se verificaba si el `IdUsuario` ya estaba vinculado a otro paciente activo.
   - *Corrección:* Se agregó comprobación `if (idUsuario.HasValue && db.Pacientes.Any(p => p.IdUsuario == idUsuario.Value && p.Estado))` lanzando excepción descriptiva.
4. **Defensa en Profundidad en Interfaz Gráfica (`paginaPrincipalPacientes.cs`):**
   - *Deficiencia:* La columna `colEditar` permanecía visible y activa para usuarios médicos.
   - *Corrección:* Se ocultó la columna `colEditar` para roles no administrativos en `ConfigurarSeguridadPorRol()` y se protegió el manejador de clics en celda con validación `controlador.EsAdministrativo()`.
5. **Compatibilidad con .NET Framework 4.7.2 (Placeholders WinForms):**
   - *Deficiencia:* Uso inicial de `TextBox.PlaceholderText` (característica de .NET Core/.NET 5+).
   - *Corrección:* Implementación de API nativa Win32 `EM_SETCUEBANNER` (`SendMessage`) garantizando compatibilidad 100% nativa con .NET Framework 4.7.2.
6. **Paridad Visual y Ergonómica de `Views/Hospitales/crearHospital` (P5):**
   - *Deficiencia:* El formulario de alta y edición de hospitales presentaba un diseño plano simple que no se ajustaba al estándar institucional aprobado en `crearDoctor` y `crearPaciente`.
   - *Corrección:* Rediseño completo con panel Hero izquierdo de 275px (logotipo, lema, bloques informativos), tarjetas redondeadas independientes para ubicación geográfica y datos de la sede, doble búfer contra parpadeos, placeholders nativos y layout responsivo.
7. **Homogeneización de Filtros y Autorización en `fichaCita`:**
   - *Deficiencia:* Algunas acciones modales en `fichaCita` no propagaban `idPacienteFiltro` hacia el controlador.
   - *Corrección:* Propagación consistente de `idPacienteFiltro` en todas las acciones de ciclo de vida (`cambiarEstadoCita`, `crearCita`), garantizando aislamiento multi-rol en modales.

---

## 5. Verificación Técnica y Calidad de Código

- **Compilación MSBuild Debug:** 0 Errores, 0 Advertencias (`Build succeeded`).
- **Compilación MSBuild Release:** 0 Errores, 0 Advertencias (`Build succeeded`).
- **Control de Formato y Espaciado:** `git diff --check` ejecutado con 0 errores de whitespace o indentación.
- **Validación de Entorno Local:** Script `scripts/validar-configuracion.ps1` ejecutado con resultado `[OK]`. `App.config` excluido de Git y preservado localmente.
- **Protección de Base de Datos:** Ningún archivo autogenerado por Entity Framework (`ModelSanarRural.tt`, `ModelSanarRural.Context.cs`) fue alterado.
- **Identidad Visual:** 100% de cumplimiento con `Helpers/Tema.cs` y paleta `#EDF7F0` (prohibición estricta de fondos `#FFFFFF` planos).
