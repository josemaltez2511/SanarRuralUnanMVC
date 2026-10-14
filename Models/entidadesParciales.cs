using System;
using System.Data.Entity;

namespace SanarRuralUnan
{
    // =========================================================================
    // EXTENSIÓN DE CLASES PARCIALES DE ENTITY FRAMEWORK (ESQUEMA V2)
    // =========================================================================
    // Según las reglas del proyecto (00-sanar-rural-core.md y AGENTS.md), los
    // archivos generados automáticamente por ModelSanarRural.tt nunca deben
    // editarse a mano.
    // Toda extensión de propiedades mapeadas en ModelSanarRural.edmx se realiza
    // mediante clases parciales en archivos separados.
    // =========================================================================

    public partial class SanarRuralDBEntities
    {
        // Constructor para inicialización con cadena de conexión explícita (útil en pruebas y diagnósticos).
        public SanarRuralDBEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<PersonalAdministrativo> PersonalAdministrativo { get; set; }
    }

    public partial class Pacientes
    {
        // Nueva columna para referencias domiciliarias desglosadas (Fase 2).
        public string ReferenciaAdicional { get; set; }

        // Correo electrónico directo del paciente (opcional).
        public string Correo { get; set; }
    }

    public partial class Doctores
    {
        // Correo de contacto profesional del médico.
        public string Correo { get; set; }
    }

    public partial class Usuarios
    {
        // Identificador textual único para inicio de sesión unificado.
        public string NombreUsuario { get; set; }

        public virtual System.Collections.Generic.ICollection<Administradores> Administradores { get; set; }
        public virtual System.Collections.Generic.ICollection<PersonalAdministrativo> PersonalAdministrativo { get; set; }
    }

    public partial class Administradores
    {
        public int IdAdministrador { get; set; }
        public int? IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }

    public partial class PersonalAdministrativo
    {
        public int IdPersonalAdministrativo { get; set; }
        public int? IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Cargo { get; set; }
        public bool Estado { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
