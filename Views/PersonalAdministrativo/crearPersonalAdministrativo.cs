using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.PersonalAdministrativo
{
    /// <summary>
    /// Formulario modal para la creación y edición de perfiles de Personal Administrativo.
    /// Respeta la separación estricta entre perfil de persona y credenciales de usuario.
    /// Exclusivo para el rol 'Admin'.
    /// </summary>
    public partial class crearPersonalAdministrativo : Form
    {
        private readonly personalAdministrativoControllers controlador = new personalAdministrativoControllers();
        private readonly int? idPersonalEditar;
        private PersonalAdministrativoDetalleDto detalleExistente;

        public crearPersonalAdministrativo()
        {
            InitializeComponent();
            ConfigurarEstilosVisuales();
        }

        public crearPersonalAdministrativo(int idPersonal) : this()
        {
            idPersonalEditar = idPersonal;
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.Fondo;

            cardHeader.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardHeader.Width - 1, cardHeader.Height - 1), Color.White, Tema.Borde, 8);
            };

            cardForm.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardForm.Width - 1, cardForm.Height - 1), Color.White, Tema.Borde, 8);
            };

            pnlInfoCredenciales.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, pnlInfoCredenciales.Width - 1, pnlInfoCredenciales.Height - 1), Color.FromArgb(243, 248, 253), Color.FromArgb(200, 224, 246), 6);
            };

            lblIconoHeader.Text = "";
            lblIconoHeader.Paint += (s, ev) =>
            {
                Tema.DibujarFondoCircular(ev.Graphics, lblIconoHeader.ClientRectangle, Color.FromArgb(226, 238, 248));
                Tema.DibujarIconoPersonal(ev.Graphics, lblIconoHeader.ClientRectangle, Tema.AzulPrimario);
            };
        }

        private void crearPersonalAdministrativo_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (idPersonalEditar.HasValue)
            {
                lblTitulo.Text = "Editar Personal Administrativo";
                lblSubtitulo.Text = "Modifique los datos personales del colaborador.";
                btnGuardar.Text = "Guardar cambios";

                CargarDatosParaEdicion(idPersonalEditar.Value);
            }
            else
            {
                lblTitulo.Text = "Nuevo Personal Administrativo";
                lblSubtitulo.Text = "Complete los datos del colaborador de apoyo institucional.";
                btnGuardar.Text = "Guardar";
                lblInfoCredenciales.Text = "• Este formulario registra el perfil de la persona. Para asignarle un nombre de usuario y contraseña, utilice la opción 'Asignar acceso a perfil' una vez guardado.";
            }
        }

        private void CargarDatosParaEdicion(int idPersonal)
        {
            try
            {
                detalleExistente = controlador.ObtenerDetalle(idPersonal);
                if (detalleExistente == null)
                {
                    MessageBox.Show("No se encontró el colaborador especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                txtPrimerNombre.Text = detalleExistente.PrimerNombre;
                txtSegundoNombre.Text = detalleExistente.SegundoNombre ?? "";
                txtPrimerApellido.Text = detalleExistente.PrimerApellido;
                txtSegundoApellido.Text = detalleExistente.SegundoApellido ?? "";
                txtCedula.Text = detalleExistente.Cedula ?? "";
                txtTelefono.Text = detalleExistente.Telefono ?? "";
                txtCorreo.Text = detalleExistente.Correo ?? "";
                txtCargo.Text = detalleExistente.Cargo ?? "";

                if (detalleExistente.TieneCuenta)
                {
                    string estadoStr = detalleExistente.EstadoUsuario == true ? "Activa" : "Inactiva / Bloqueada";
                    lblInfoCredenciales.Text = string.Format("● Cuenta de acceso vinculada: {0} ({1}). El usuario se preserva intacto.", detalleExistente.NombreUsuario, estadoStr);
                }
                else
                {
                    lblInfoCredenciales.Text = "○ Este colaborador aún no tiene cuenta de acceso. Podrá asignarle credenciales desde 'Asignar acceso a perfil'.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos del personal:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string primerNombre = txtPrimerNombre.Text.Trim();
            string segundoNombre = txtSegundoNombre.Text.Trim();
            string primerApellido = txtPrimerApellido.Text.Trim();
            string segundoApellido = txtSegundoApellido.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string cargo = txtCargo.Text.Trim();

            // Validaciones locales inmediatas
            if (string.IsNullOrWhiteSpace(primerNombre))
            {
                MostrarError("El primer nombre es obligatorio.");
                txtPrimerNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(primerApellido))
            {
                MostrarError("El primer apellido es obligatorio.");
                txtPrimerApellido.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(correo) && !Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MostrarError("El formato del correo electrónico no es válido.");
                txtCorreo.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(cedula) && controlador.ExisteCedula(cedula, idPersonalEditar))
            {
                MostrarError("Ya existe otro colaborador registrado con esa misma cédula.");
                txtCedula.Focus();
                return;
            }

            try
            {
                if (idPersonalEditar.HasValue)
                {
                    controlador.Actualizar(
                        idPersonalEditar.Value,
                        primerNombre,
                        segundoNombre,
                        primerApellido,
                        segundoApellido,
                        cedula,
                        telefono,
                        correo,
                        cargo
                    );

                    MessageBox.Show("Colaborador actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    controlador.Guardar(
                        primerNombre,
                        segundoNombre,
                        primerApellido,
                        segundoApellido,
                        cedula,
                        telefono,
                        correo,
                        cargo
                    );

                    MessageBox.Show("Colaborador registrado exitosamente.\n\nPuede vincularle una cuenta de usuario desde 'Asignar acceso a perfil'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el colaborador:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnCerrarTop_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
