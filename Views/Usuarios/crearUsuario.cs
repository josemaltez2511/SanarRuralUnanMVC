using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    /// <summary>
    /// Tarjeta de rol seleccionable mediante teclado, ratón y tecnologías de asistencia.
    /// </summary>
    public class TarjetaRolPanel : Panel
    {
        public bool Checked { get; set; }

        public TarjetaRolPanel()
        {
            SetStyle(ControlStyles.Selectable, true);
            TabStop = true;
            AccessibleRole = AccessibleRole.RadioButton;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Space ||
                keyData == Keys.Left || keyData == Keys.Right ||
                keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;
            }
            return base.IsInputKey(keyData);
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new TarjetaRolAccessibleObject(this);
        }

        private class TarjetaRolAccessibleObject : ControlAccessibleObject
        {
            private readonly TarjetaRolPanel _panel;
            public TarjetaRolAccessibleObject(TarjetaRolPanel panel) : base(panel)
            {
                _panel = panel;
            }

            public override AccessibleRole Role => AccessibleRole.RadioButton;

            public override AccessibleStates State
            {
                get
                {
                    AccessibleStates state = base.State | AccessibleStates.Focusable;
                    if (_panel.Focused) state |= AccessibleStates.Focused;
                    if (_panel.Checked) state |= AccessibleStates.Checked;
                    return state;
                }
            }
        }
    }

    public partial class crearUsuario : Form
    {
        private readonly usuariosControllers controlador = new usuariosControllers();
        private bool esRegistroDoctorFijo;
        private bool modoAdministracion;
        private int? idUsuarioEditar;
        public int? IdUsuarioCreado { get; private set; }

        public crearUsuario()
        {
            InitializeComponent();
        }

        public crearUsuario(bool forzarDoctor) : this()
        {
            esRegistroDoctorFijo = forzarDoctor;
        }

        public crearUsuario(bool forzarDoctor, bool modoAdministracion) : this(forzarDoctor)
        {
            this.modoAdministracion = modoAdministracion;
        }

        public crearUsuario(int idUsuario) : this(false, true)
        {
            idUsuarioEditar = idUsuario;
        }

        private void CentrarPanelCard()
        {
            int cardHeight = 525;
            if (esRegistroDoctorFijo)
            {
                cardHeight = 450;
            }
            else if (modoAdministracion)
            {
                cardHeight = 510;
            }

            panelCard.Width = 500;
            panelCard.Height = cardHeight;

            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;
            panelCard.Location = new Point(Math.Max(10, x), Math.Max(10, y));
        }

        private void crearUsuario_Load(object sender, EventArgs e)
        {
            // Comportamiento de pantalla principal ocupando el tamaño completo disponible
            WindowState = FormWindowState.Maximized;

            // Cargar el logotipo institucional desde los recursos del sistema
            picLogo.Image = Tema.ObtenerLogo();

            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe tener al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Tema.TextoSecundario;
            lblErrorConfirmar.Text = "";
            btnVerContrasena.Text = "👁";
            btnVerConfirmarContrasena.Text = "👁";

            // Microinteracciones de hover para botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnVerContrasena.MouseEnter += (s, ev) => btnVerContrasena.BackColor = Tema.FondoSecundario;
            btnVerContrasena.MouseLeave += (s, ev) => btnVerContrasena.BackColor = Tema.Superficie;
            btnVerConfirmarContrasena.MouseEnter += (s, ev) => btnVerConfirmarContrasena.BackColor = Tema.FondoSecundario;
            btnVerConfirmarContrasena.MouseLeave += (s, ev) => btnVerConfirmarContrasena.BackColor = Tema.Superficie;

            ConfigurarTarjetaTipoUsuario(panelTarjetaPaciente, rbPaciente, "🧑‍⚕️", "Paciente");
            ConfigurarTarjetaTipoUsuario(panelTarjetaMedico, rbMedico, "👨‍⚕️", "Médico / Personal");
            rbPaciente.Checked = true;
            panelTarjetaPaciente.Checked = true;
            panelTarjetaMedico.Checked = false;

            if (modoAdministracion)
            {
                var roles = controlador.ListarRoles();
                cmbRol.DataSource = roles;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "IdRol";
                cmbRol.Visible = true;
                lblTipoUsuario.Visible = true;
                lblTipoUsuario.Text = "Rol";
                panelTarjetaPaciente.Visible = false;
                panelTarjetaMedico.Visible = false;
                panelTarjetaPaciente.TabStop = false;
                panelTarjetaMedico.TabStop = false;
                rbPaciente.Visible = false;
                rbMedico.Visible = false;
                btnGuardar.Text = idUsuarioEditar.HasValue ? "Guardar Cambios" : "Crear Usuario";
                lnkVolver.Text = "Cancelar";
                btnGuardar.Location = new Point(40, 415);
                lnkVolver.Location = new Point(20, 472);

                if (idUsuarioEditar.HasValue)
                {
                    CargarUsuarioParaEditar();
                    lblSubtitulo.Text = "Editar Usuario";
                    lblContrasena.Text = "Nueva contraseña (opcional)";
                }
                else
                {
                    lblSubtitulo.Text = "Crear Usuario";
                    lblContrasena.Text = "Contraseña";
                }
            }
            else if (esRegistroDoctorFijo)
            {
                rbMedico.Checked = true;
                rbPaciente.Checked = false;
                panelTarjetaMedico.Checked = true;
                panelTarjetaPaciente.Checked = false;
                lblTipoUsuario.Visible = false;
                panelTarjetaPaciente.Visible = false;
                panelTarjetaMedico.Visible = false;
                panelTarjetaPaciente.TabStop = false;
                panelTarjetaMedico.TabStop = false;
                rbPaciente.Visible = false;
                rbMedico.Visible = false;
                cmbRol.Visible = false;
                btnGuardar.Location = new Point(40, 355);
                lnkVolver.Location = new Point(20, 412);
                lnkVolver.Text = "Cancelar y Volver";
            }
            else
            {
                panelTarjetaPaciente.Visible = true;
                panelTarjetaMedico.Visible = true;
                panelTarjetaPaciente.TabStop = true;
                panelTarjetaMedico.TabStop = true;
                btnGuardar.Location = new Point(40, 428);
                lnkVolver.Location = new Point(20, 485);
            }

            CentrarPanelCard();
        }

        private void CargarUsuarioParaEditar()
        {
            var usuario = controlador.ConsultarUsuario(idUsuarioEditar.Value);
            if (usuario == null)
            {
                MessageBox.Show("El usuario ya no está disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtCorreo.Text = usuario.Correo;
            cmbRol.SelectedValue = usuario.IdRol;
            lblErrorCorreo.Text = "";
        }

        private void ConfigurarTarjetaTipoUsuario(TarjetaRolPanel panel, RadioButton radioAsociado, string emoji, string texto)
        {
            panel.BorderStyle = BorderStyle.None;
            panel.Cursor = Cursors.Hand;
            panel.Controls.Clear();

            bool mouseSobre = false;

            var etiqueta = new Label
            {
                Text = emoji + "  " + texto,
                Font = Tema.FuenteLabelCampo,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                AccessibleRole = AccessibleRole.None
            };
            panel.Controls.Add(etiqueta);

            Action actualizarEstadoVisual = () =>
            {
                panel.Checked = radioAsociado.Checked;
                if (panel.Checked)
                {
                    panel.BackColor = Tema.FondoSecundario;
                    etiqueta.ForeColor = Tema.AzulOscuro;
                    etiqueta.Font = new Font(Tema.FamiliaFuente, Tema.TamanoEtiqueta, FontStyle.Bold);
                }
                else if (mouseSobre)
                {
                    panel.BackColor = Tema.Fondo;
                    etiqueta.ForeColor = Tema.TextoPrincipal;
                    etiqueta.Font = new Font(Tema.FamiliaFuente, Tema.TamanoEtiqueta, FontStyle.Regular);
                }
                else
                {
                    panel.BackColor = Tema.Superficie;
                    etiqueta.ForeColor = Tema.TextoSecundario;
                    etiqueta.Font = new Font(Tema.FamiliaFuente, Tema.TamanoEtiqueta, FontStyle.Regular);
                }
                panel.Invalidate();
            };

            panel.Paint += (s, e) =>
            {
                bool enfocado = panel.Focused;
                Color colorBorde = (panel.Checked || enfocado) ? Tema.AzulPrimario : (mouseSobre ? Tema.AzulClaro : Tema.Borde);
                int grosor = (panel.Checked || enfocado) ? 2 : 1;
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    int offset = grosor > 1 ? 1 : 0;
                    e.Graphics.DrawRectangle(pen, offset, offset, panel.ClientSize.Width - 1 - offset * 2, panel.ClientSize.Height - 1 - offset * 2);
                }

                if (enfocado)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(3, 3, panel.ClientSize.Width - 6, panel.ClientSize.Height - 6));
                }
            };

            panel.MouseEnter += (s, ev) => { mouseSobre = true; actualizarEstadoVisual(); };
            panel.MouseLeave += (s, ev) => { mouseSobre = false; actualizarEstadoVisual(); };
            etiqueta.MouseEnter += (s, ev) => { mouseSobre = true; actualizarEstadoVisual(); };
            etiqueta.MouseLeave += (s, ev) => { mouseSobre = false; actualizarEstadoVisual(); };

            Action seleccionarEstaTarjeta = () =>
            {
                panel.Focus();
                if (!radioAsociado.Checked)
                {
                    radioAsociado.Checked = true;
                }
                else
                {
                    actualizarEstadoVisual();
                }
            };

            panel.Click += (s, ev) => seleccionarEstaTarjeta();
            etiqueta.Click += (s, ev) => seleccionarEstaTarjeta();

            panel.GotFocus += (s, ev) => actualizarEstadoVisual();
            panel.LostFocus += (s, ev) => actualizarEstadoVisual();

            panel.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    seleccionarEstaTarjeta();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
                {
                    if (panel == panelTarjetaPaciente)
                    {
                        panelTarjetaMedico.Focus();
                        rbMedico.Checked = true;
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
                {
                    if (panel == panelTarjetaMedico)
                    {
                        panelTarjetaPaciente.Focus();
                        rbPaciente.Checked = true;
                        e.Handled = true;
                    }
                }
            };

            radioAsociado.CheckedChanged += (s, ev) => actualizarEstadoVisual();

            actualizarEstadoVisual();
        }

        private void crearUsuario_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = txtContrasena.PasswordChar == '●' ? '\0' : '●';
            btnVerContrasena.Text = txtContrasena.PasswordChar == '●' ? "👁" : "🙈";
            txtContrasena.Focus();
            txtContrasena.SelectionStart = txtContrasena.Text.Length;
        }

        private void btnVerConfirmarContrasena_Click(object sender, EventArgs e)
        {
            txtConfirmarContrasena.PasswordChar = txtConfirmarContrasena.PasswordChar == '●' ? '\0' : '●';
            btnVerConfirmarContrasena.Text = txtConfirmarContrasena.PasswordChar == '●' ? "👁" : "🙈";
            txtConfirmarContrasena.Focus();
            txtConfirmarContrasena.SelectionStart = txtConfirmarContrasena.Text.Length;
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            if (string.IsNullOrEmpty(correo))
            {
                lblErrorCorreo.Text = "El correo no puede estar vacío.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblErrorCorreo.Text = "Formato de correo inválido.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
                return;
            }

            try
            {
                if (controlador.CorreoYaExiste(correo, idUsuarioEditar))
                {
                    lblErrorCorreo.Text = "Este correo ya está registrado en la base de datos.";
                    lblErrorCorreo.ForeColor = Tema.ColorError;
                }
                else
                {
                    lblErrorCorreo.Text = "Correo disponible.";
                    lblErrorCorreo.ForeColor = Tema.ColorExito;
                }
            }
            catch
            {
                lblErrorCorreo.Text = "No se pudo validar el correo. Verifique la conexión a la base de datos.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
            }
        }

        private void ValidarCoincidenciaContrasenas()
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden";
                lblErrorConfirmar.ForeColor = Tema.ColorError;
            }
            else if (!string.IsNullOrEmpty(txtContrasena.Text))
            {
                lblErrorConfirmar.Text = "Las contraseñas coinciden";
                lblErrorConfirmar.ForeColor = Tema.ColorExito;
            }
            else
            {
                lblErrorConfirmar.Text = "";
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string contrasena = txtContrasena.Text;
            if (idUsuarioEditar.HasValue && string.IsNullOrEmpty(contrasena))
            {
                lblErrorContrasena.Text = "Deje vacío para conservar la contraseña actual.";
                lblErrorContrasena.ForeColor = Tema.TextoAyuda;
            }
            else if (contrasena.Length < 5)
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Tema.ColorError;
            }
            else
            {
                lblErrorContrasena.Text = "Contraseña válida";
                lblErrorContrasena.ForeColor = Tema.ColorExito;
            }
            ValidarCoincidenciaContrasenas();
        }

        private void txtConfirmarContrasena_TextChanged(object sender, EventArgs e)
        {
            ValidarCoincidenciaContrasenas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;
            bool editar = idUsuarioEditar.HasValue;

            if (string.IsNullOrWhiteSpace(correo) || !Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((!editar || !string.IsNullOrEmpty(contrasena)) && contrasena.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((!editar || !string.IsNullOrEmpty(contrasena)) && contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (editar && string.IsNullOrEmpty(contrasena) && !string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Deje ambos campos de contraseña vacíos o escriba la nueva contraseña en los dos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRol;
            if (modoAdministracion)
            {
                if (cmbRol.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idRol = Convert.ToInt32(cmbRol.SelectedValue);
            }
            else
            {
                idRol = controlador.ObtenerIdRol(esRegistroDoctorFijo || rbMedico.Checked ? "Doctor" : "Paciente");
            }

            if (idRol <= 0)
            {
                MessageBox.Show("No se encontró el rol seleccionado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (modoAdministracion)
                {
                    int idCreado = editar ? 0 : controlador.CrearUsuario(idRol, correo, contrasena);
                    bool guardado = editar
                        ? controlador.EditarUsuario(idUsuarioEditar.Value, idRol, correo, contrasena)
                        : idCreado > 0;

                    if (!guardado)
                    {
                        MessageBox.Show("El correo ya está registrado o el usuario no está disponible.", "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!editar)
                        IdUsuarioCreado = idCreado;

                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                int idUsuarioCreado = controlador.CrearUsuario(idRol, correo, contrasena);
                if (idUsuarioCreado == -1)
                {
                    MessageBox.Show("El correo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IdUsuarioCreado = idUsuarioCreado;

                if (esRegistroDoctorFijo)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("¡Usuario registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (idRol == controlador.ObtenerIdRol("Paciente"))
                {
                    using (crearPaciente formularioPaciente = new crearPaciente(idUsuarioCreado))
                        formularioPaciente.ShowDialog(this);
                }
                else if (idRol == controlador.ObtenerIdRol("Doctor"))
                {
                    using (crearDoctor formularioDoctor = new crearDoctor(idUsuarioCreado))
                        formularioDoctor.ShowDialog(this);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo actualizar el rol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (modoAdministracion)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (esRegistroDoctorFijo)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            // Borde sutil y limpio para la tarjeta de elevación visual
            using (Pen penBorde = new Pen(Tema.Borde, 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelCard.ClientSize.Width - 1, panelCard.ClientSize.Height - 1);
            }
        }

        private void lblCorreo_Click(object sender, EventArgs e) { }

        private void panelCard_Paint_1(object sender, PaintEventArgs e)
        {
            panelCard_Paint(sender, e);
        }

        private void crearUsuario_Load_1(object sender, EventArgs e) { }
    }
}
