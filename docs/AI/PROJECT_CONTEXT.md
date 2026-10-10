# Contexto del Proyecto: Sanar Rural UNAN

## 1. Visión General del Sistema
**Sanar Rural** es una aplicación de escritorio diseñada para la gestión clínica y administrativa de servicios de salud en entornos rurales de Nicaragua. El sistema busca agilizar el registro de pacientes, asignación de doctores por hospital y especialidad, programación de citas médicas, ejecución de consultas clínicas con captura de signos vitales, diagnósticos, prescripciones e historial médico, facilitando la toma de decisiones y garantizando la continuidad de la atención.

Desarrolladores del proyecto: **José, Esther y Amarelis** (UNAN-Managua).

---

## 2. Stack Tecnológico
- **Plataforma:** Aplicación de escritorio Windows (Windows Forms / WinForms).
- **Lenguaje:** C# (.NET Framework 4.7.2).
- **Base de Datos:** Microsoft SQL Server 2022 (base de datos `SanarRuralDB`; la instancia de SQL Server es local e individual para cada desarrollador, ej. `.\SQLEXPRESS`, `localhost\SQLEXPRESS`, etc.).
- **ORM / Acceso a Datos:** Entity Framework 6.5.2 (Enfoque **Database First** mediante `ModelSanarRural.edmx`).
- **Componentes Visuales:** `MaterialSkin 2` (versión 2.3.1).
- **Sistema de Identidad Visual:** `SanarRuralUnan.Helpers.Tema` (`Helpers/Tema.cs`).
- **Control de Versiones:** Git / GitHub.

> **Política Estricta de Configuración Local:**
> - `App.config` es **exclusivamente local** y está ignorado por Git (`.gitignore`). NUNCA debe ser versionado ni incluido en commits.
> - `App.config.example` es la **plantilla versionada oficial**.
> - La instancia de SQL Server puede variar entre las computadoras de José, Esther y Amarelis.
> - **Regla para IA y desarrolladores:** Nunca asumir, copiar ni hardcodear el nombre de máquina o instancia de otro integrante. Toda documentación debe referirse a `App.config.example`.

> **Aclaración Arquitectónica Vital:**
> Este proyecto **NO es ASP.NET MVC**, ni aplicación web. No se debe introducir código Razor (`.cshtml`), controladores web de ASP.NET, rutas HTTP, ni dependencias de ASP.NET Core.

---

## 3. Arquitectura del Código
El sistema sigue un patrón arquitectónico **MVC informal** adaptado a Windows Forms:
```
[ Vistas (Views) ]
       │  (Eventos de UI, captura y presentación de datos)
       ▼
[ Controladores (Controllers) ]
       │  (Coordinación, orquestación y validaciones de flujo)
       ▼
[ Modelos (Models) ]
       │  (Consultas LINQ a EF, reglas de persistencia, transacciones)
       ▼
[ Entity Framework 6 (SanarRuralDBEntities) ]
       │
       ▼
[ Base de Datos SQL Server ]
```

### Reglas de separación por capas:
1. **Views (`Views/`):**
   - Formularios (`Form`, `MaterialForm`) y controles visuales.
   - Manejan interacción, selección de archivos, validación visual y navegación.
   - **Prohibido:** Instanciar `SanarRuralDBEntities` o ejecutar consultas LINQ a la base de datos directamente desde las vistas.
2. **Controllers (`Controllers/`):**
   - Clases terminadas en `Controller` o `Controllers` (ej. `doctoresControllers`, `pacientesControllers`).
   - Conectan la vista con el modelo sin acoplar la UI a la capa de persistencia.
3. **Models (`Models/`):**
   - Clases terminadas en `Models` (ej. `doctoresModels`, `pacientesModels`).
   - Encapsulan las operaciones CRUD, transacciones atómicas y lógica de consulta a `SanarRuralDBEntities`.
4. **Entidades Autogeneradas (`*.cs` en la raíz dependientes de `ModelSanarRural.tt`):**
   - Clases POCO generadas por el archivo de plantilla T4 (`Doctores.cs`, `Pacientes.cs`, `Citas.cs`, `Consultas.cs`, etc.).
   - **Prohibido:** Modificar manualmente estos archivos, ya que se sobrescriben al regenerar el EDMX.

---

## 4. Estructura de Carpetas del Repositorio
```
SanarRuralUnan/
├── Controllers/                 # Controladores del sistema
│   ├── citasControllers.cs
│   ├── consultasControllers.cs
│   ├── doctoresControllers.cs
│   ├── hospitalesController.cs
│   ├── pacientesControllers.cs
│   └── usuariosController.cs
├── Models/                      # Lógica de acceso a datos y persistencia
│   ├── citasModels.cs
│   ├── consultasModels.cs
│   ├── doctoresModels.cs
│   ├── hospitalesModels.cs
│   ├── pacientesModels.cs
│   └── usuariosModels.cs
├── Views/                       # Formularios organizados por módulo
│   ├── Citas/                   # crearCita, fichaCita, paginaPrincipalCitas
│   ├── ConsultaMedica/          # atencionConsulta, paginaPrincipalConsultas, seleccionarCitaConsulta
│   ├── Doctores/                # crearDoctor, paginaPrincipalDoctores
│   ├── HistorialClinico/        # paginaPrincipalHistorial
│   ├── Hospitales/              # crearHospital, paginaPrincipalHospitales
│   ├── IniciarSesion/           # iniciarSesion
│   ├── Menu/                    # menuPrincipalAdministrativo, menuPrincipalMedicos, menuPrincipalPacientes
│   ├── Pacientes/               # crearPaciente, fichaPaciente, paginaPrincipalPacientes, perfilPaciente
│   └── Usuarios/                # crearUsuario, paginaPrincipalUsuarios
├── Helpers/                     # Utilidades transversales
│   └── Tema.cs                  # Identidad visual centralizada (colores, fuentes, medidas)
├── Properties/                  # Recursos, ensamblados y configuraciones
├── ModelSanarRural.edmx         # Diagrama y mapeo Entity Framework Database First
├── ModelSanarRural.Context.cs   # DbContext generado (SanarRuralDBEntities)
├── App.config.example           # Plantilla versionada de configuracion y cadenas de conexion
├── App.config                   # Configuracion local y personal (IGNORADO por Git, NO versionar)
├── SanarRuralUnan.csproj        # Definición del proyecto .NET Framework 4.7.2
├── .agents/                     # Reglas, skills y workflows para agentes de IA
│   ├── rules/
│   ├── skills/
│   └── workflows/
└── docs/AI/                     # Documentación de contexto para IA
    ├── IMPLEMENTATION_STATUS.md
    └── PROJECT_CONTEXT.md
```

---

## 5. Roles del Sistema y Shells de Navegación
El acceso al sistema se realiza a través de `iniciarSesion.cs` (`Program.cs` inicia en esta pantalla). Según el rol autenticado:

1. **Administrativo (Rol Id = `ObtenerIdRol("Administrativo")`):**
   - **Shell Principal:** `Views/Menu/menuPrincipalAdministrativo.cs` (`MaterialForm`).
   - **Módulos accesibles:** Usuarios, Doctores, Pacientes, Hospitales, Citas.
   - Navegación embebida: El shell conmuta los formularios secundarios (`paginaPrincipalUsuarios`, `paginaPrincipalDoctores`, `paginaPrincipalHospitales`, `paginaPrincipalPacientes`, `paginaPrincipalCitas`) dentro de su contenedor `panelContenido`.
2. **Doctor / Médico (Rol Id = `ObtenerIdRol("Doctor")`):**
   - **Shell Principal:** `Views/Menu/menuPrincipalMedicos.cs` (`MaterialForm`).
   - **Módulos:** Pacientes (consulta y alta), Citas (asignadas a su perfil), Consultas (atención médica), Historial Clínico Integral.
3. **Paciente (Rol Id = `ObtenerIdRol("Paciente")`):**
   - **Shell Principal:** `Views/Menu/menuPrincipalPacientes.cs` (`MaterialForm`).
   - **Módulos:** Mi Perfil (`perfilPaciente.cs` - autogestión de datos demográficos y contactos), Mis Citas (solicitud y cancelación), Mi Historial Clínico (consultas finalizadas en modo solo lectura).

---

## 6. Módulos del Sistema y Estado Actual
- **Autenticación (`Views/IniciarSesion`):** Implementado y verificado con PBKDF2-SHA256, sal aleatoria y enrutamiento por rol.
- **Usuarios (`Views/Usuarios`):** Implementado y verificado. Auto-registro público restringido a Paciente; gestión de cuentas protegida por rol Administrativo.
- **Hospitales (`Views/Hospitales`):** Implementado y verificado. Gestión de sedes protegida por rol Administrativo con cascada geográfica.
- **Doctores (`Views/Doctores`):** Implementado y verificado. Gestión de facultativos protegida por rol Administrativo con transacciones explícitas.
- **Pacientes (`Views/Pacientes`):** Implementado y verificado. Gestión clínica/maestra para Administrativo; consulta para Doctor; autogestión demográfica para Paciente.
- **Citas (`Views/Citas`):** Implementado y verificado. Resolución de identidad por sesión en el modelo, solapamiento horario, transiciones seguras y prohibición de paso a `Atendida` fuera del módulo clínico.
- **Consultas (`Views/ConsultaMedica`):** Implementado y verificado. Atención clínica con concurrencia controlada (`UQ_Consultas_IdCita`), borradores recurrentes, diagnóstico principal obligatorio y cierre atómico ACID.
- **Historial Clínico (`Views/HistorialClinico`):** Implementado y verificado. Visualización integral para Doctor, auditoría para Administrativo y vista acotada a atenciones finalizadas para Paciente.

---

## 7. Reglas Clínicas Fundamentales
1. **Diferenciación Cita vs. Consulta:**
   - La **Cita** representa una reserva programada (`FechaHoraProgramada`, `Estado`, `Motivo`).
   - La **Consulta** representa el acto médico presencial (`FechaHoraInicio`, `FechaHoraFin`, `PadecimientoActual`, `ExamenFisico`, `Observaciones`, `PlanSeguimiento`).
   - Una Cita puede dar origen a una Consulta, pero **no son la misma entidad ni deben fusionarse**.
2. **Integridad del Expediente Clínico:**
   - Toda atención médica debe preservar el registro histórico. No se deben sobrescribir o eliminar consultas ya efectuadas salvo reglas explícitas de anulación auditada.
   - Los diagnósticos y prescripciones pertenecen a una consulta concreta (`IdConsulta`).
   - El sistema no inventa diagnósticos automáticos; registra estrictamente lo indicado por el profesional de salud.

---

## 8. Identidad Visual y Diseño Centrado en el Usuario (UCD)
- **Concepto rector:** Salud, Tecnología, Confianza y Naturaleza.
- **Biblia visual:** `Helpers/Tema.cs`. Todo color, fuente o espaciado debe provenir de esta clase.
- **Fondo General de Ventana:** `#EDF7F0` (Verde claro suave). **Prohibido usar blanco puro (`#FFFFFF`) como fondo de ventana**.
- **Superficies y Tarjetas:** `#F9FCFA`.
- **Acentos:** Azul Primario `#2378B7`, Verde Acento `#78B86A`, Texto Principal `#173342`.
- **Componentes:** Combinación armónica de `MaterialSkin 2` con controles estándar WinForms estilizados con `Tema.cs`.
- **Responsive:** Controles anclados con `Anchor`, contenedores `TableLayoutPanel` o recalculados en eventos `Resize` para adaptarse fluidamente a diferentes resoluciones.
