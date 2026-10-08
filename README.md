# Sanar Rural UNAN

Sistema de gestión médica y administrativa para servicios de salud comunitaria y rural en Nicaragua. Desarrollado por **José, Esther y Amarelis** (UNAN-Managua).

---

## Stack Tecnológico

- **Plataforma:** Windows Forms (.NET Framework 4.7.2).
- **Lenguaje:** C# 7.3.
- **Base de Datos:** Microsoft SQL Server 2022.
- **ORM:** Entity Framework 6.5.2 (Database First, `ModelSanarRural.edmx`).
- **Librería de Componentes:** MaterialSkin 2 (versión 2.3.1).
- **Sistema de Identidad Visual:** `Helpers/Tema.cs`.

---

## Guía de Configuración Inicial para Nuevos Desarrolladores

Para evitar conflictos de conexión entre los equipos de desarrollo, el archivo de configuración `App.config` es **estrictamente local** y **no está versionado en Git**. En su lugar, el repositorio proporciona la plantilla segura `App.config.example`.

Siga estos pasos al clonar el proyecto por primera vez:

### 1. Clonar el Repositorio
```powershell
git clone https://github.com/josemaltez2511/SanarRuralUnanMVC.git
cd SanarRuralUnanMVC
```

### 2. Crear `App.config` a partir de la Plantilla
Copie el archivo de ejemplo en la raíz del proyecto:
```powershell
Copy-Item App.config.example App.config
```

### 3. Configurar la Instancia Local de SQL Server
Abra su archivo local `App.config` y modifique **únicamente** el parámetro `Data Source` en las cadenas de conexión para que coincida con su instancia local (por ejemplo: `.\SQLEXPRESS`, `localhost\SQLEXPRESS`, etc.):

```xml
<connectionStrings>
  <!-- Conexion ADO.NET directa -->
  <add name="SanarRuralDB"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=SanarRuralDB;Integrated Security=True;"
       providerName="System.Data.SqlClient" />

  <!-- Conexion Entity Framework 6 -->
  <add name="SanarRuralDBEntities"
       connectionString="metadata=res://*/ModelSanarRural.csdl|res://*/ModelSanarRural.ssdl|res://*/ModelSanarRural.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\SQLEXPRESS;initial catalog=SanarRuralDB;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
```

> **Reglas Obligatorias de Conexión:**
> - Mantener siempre `Initial Catalog=SanarRuralDB`.
> - Mantener siempre `Integrated Security=True`.
> - Modificar únicamente el nombre de la instancia en `Data Source`.

### 4. Verificar que `App.config` esté Ignorado por Git
Ejecute el siguiente comando en la terminal para confirmar que `App.config` no es rastreado por Git:
```powershell
git status
```
`App.config` **NO debe aparecer** en la lista de archivos para commit ni como archivo sin seguimiento (untracked). Si desea verificar la regla de exclusión directamente:
```powershell
git check-ignore -v App.config
# Debe retornar: .gitignore:13:[Aa][Pp][Pp].[Cc][Oo][Nn][Ff][Ii][Gg]	App.config
```

### 5. Prohibición Estricta sobre el Control de Versiones
- **NUNCA** ejecute `git add App.config` ni `git add -f App.config`.
- **NUNCA** incluya su `App.config` en commits ni pull requests.
- Si necesita documentar o actualizar la estructura base de configuración, modifique exclusivamente `App.config.example`.

---

## Verificación de Protección de Configuración

El proyecto incluye un script de validación que previene que `App.config` sea agregado accidentalmente al índice de Git:
```powershell
.\scripts\validar-configuracion.ps1
```

---

## Compilación y Ejecución

1. Abrir `SanarRuralUnan.sln` en **Visual Studio 2022**.
2. Restaurar los paquetes NuGet (automático al compilar).
3. Compilar la solución en modo `Debug` o `Release`.
4. Ejecutar el proyecto (`F5` o `Ctrl + F5`).
