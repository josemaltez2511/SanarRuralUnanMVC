using System;
using System.Collections.Generic;
using SanarRuralUnan.Models;

// Controller de usuarios para la aplicación SanarRuralUnan
// Este controlador maneja la lógica de negocio relacionada con los usuarios,
// Un controller es responsable de recibir las solicitudes del usuario desde la vista,
// procesarlas entre el modelo y la vista, y devolver la respuesta adecuada al usuario.
namespace SanarRuralUnan.Controllers
{
    public class usuariosControllers
    {
        // Método para iniciar sesión con sus parámetros de identificador (nombre de usuario o correo) y contraseña
        // para verificar si el usuario existe y si la contraseña es correcta
        // Retorna IdRol si es exitoso, -1 si las credenciales son inválidas, o -2 si la cuenta está inactiva.
        public int IniciarSesion(string identificador, string contrasena)
        {
            return new usuariosModels().IniciarSesion(identificador, contrasena);
        }

        public void CerrarSesion()
        {
            new usuariosModels().CerrarSesion();
        }

        // Obtiene el identificador del médico asociado al usuario en sesión.
        public int? ObtenerIdDoctorActual()
        {
            return new usuariosModels().ObtenerIdDoctorActual();
        }

        // Obtiene el identificador del paciente asociado al usuario en sesión.
        public int? ObtenerIdPacienteActual()
        {
            return new usuariosModels().ObtenerIdPacienteActual();
        }

        // Método para saber si un nombre de usuario ya está registrado
        public bool NombreUsuarioYaExiste(string nombreUsuario, int? idUsuarioExcluir = null)
        {
            return new usuariosModels().ExisteNombreUsuario(nombreUsuario, idUsuarioExcluir);
        }

        // Método obsoleto: Las cuentas de usuario operan exclusivamente con NombreUsuario
        [Obsolete("Las cuentas de usuario ya no gestionan correo. Utilice NombreUsuarioYaExiste.")]
        public bool CorreoYaExiste(string correo, int? idUsuarioExcluir = null)
        {
            return false;
        }

        public List<Roles> ListarRoles()
        {
            return new usuariosModels().ListarRoles();
        }

        public int ObtenerIdRol(string nombre)
        {
            return new usuariosModels().ObtenerIdRol(nombre);
        }

        public List<Usuarios> ListarUsuarios(string filtro = "")
        {
            return new usuariosModels().ListarUsuarios(filtro);
        }

        public Usuarios ConsultarUsuario(int idUsuario)
        {
            return new usuariosModels().ConsultarUsuario(idUsuario);
        }

        // Método para crear un nuevo usuario con rol Paciente por defecto (registro público)
        public int CrearUsuario(string nombreUsuario, string contrasena)
        {
            int idRolPaciente = ObtenerIdRol("Paciente");
            return CrearUsuario(idRolPaciente, nombreUsuario, contrasena);
        }

        public int CrearUsuario(int idRol, string nombreUsuario, string contrasena)
        {
            usuariosModels modelo = new usuariosModels();
            if (idRol <= 0 || modelo.ExisteNombreUsuario(nombreUsuario))
                return -1;

            return modelo.Guardar(idRol, nombreUsuario, contrasena);
        }

        public bool EditarUsuario(int idUsuario, int idRol, string nombreUsuario, string nuevaContrasena)
        {
            usuariosModels modelo = new usuariosModels();
            if (modelo.ExisteNombreUsuario(nombreUsuario, idUsuario))
                return false;

            return modelo.Actualizar(idUsuario, idRol, nombreUsuario, nuevaContrasena);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            return new usuariosModels().DarDeBaja(idUsuario);
        }

        public bool EsSesionAdmin()
        {
            return usuariosModels.EsSesionAdmin();
        }

        public bool EsSesionPersonalAdministrativo()
        {
            return usuariosModels.EsSesionPersonalAdministrativo();
        }

        public bool PuedeGestionarUsuariosYPersonal()
        {
            return usuariosModels.PuedeGestionarUsuariosYPersonal();
        }

        public bool PuedeCrearAccesoParaRol(string tipoPerfil)
        {
            return new usuariosModels().PuedeCrearAccesoParaRol(tipoPerfil);
        }

        public List<PerfilSinUsuarioDto> ListarPerfilesSinUsuario(string filtroTipo = null, string busqueda = null)
        {
            return new usuariosModels().ListarPerfilesSinUsuario(filtroTipo, busqueda);
        }

        public bool CrearUsuarioVinculadoAPerfil(int idPerfil, string tipoPerfil, string nombreUsuario, string contrasena, out string mensajeError)
        {
            return new usuariosModels().CrearUsuarioVinculadoAPerfil(idPerfil, tipoPerfil, nombreUsuario, contrasena, out mensajeError);
        }

        public PerfilVinculadoDto ObtenerPerfilDeUsuario(int idUsuario)
        {
            return new usuariosModels().ObtenerPerfilDeUsuario(idUsuario);
        }
    }
}
