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
    public partial class crearUsuario : Form
    {
        private readonly usuariosControllers controlador = new usuariosControllers();
        private bool esRegistroDoctorFijo;
        private bool modoAdministracion;
        private int? idUsuarioEditar;

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
            panelCard.Location = new Point(
                Math.Max(10, (ClientSize.Width - panelCard.Width) / 2),
                Math.Max(10, (ClientSize.Height - panelCard.Height) / 2));
        }

        private void crearUsuario_Load(object sender, EventArgs e)
        {
            CentrarPanelCard();
            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Tema.TextoAyuda;
            lblErrorConfirmar.Text = "";
            btnVerContrasena.Text = "👁";
            btnVerConfirmarContrasena.Text = "👁";

            ConfigurarTarjetaTipoUsuario(panelTarjetaPaciente, rbPaciente, "🧑‍⚕️", "Paciente");
            ConfigurarTarjetaTipoUsuario(panelTarjetaMedico, rbMedico, "👨‍⚕️", "Médico/Personal de salud");
            rbPaciente.Checked = true;

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
                btnGuardar.Text = idUsuarioEditar.HasValue ? "Guardar Cambios" : "Crear Usuario";
                lnkVolver.Text = "Cancelar";
                lnkVolver.Location = new Point(220, 517);

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
                lblTipoUsuario.Visible = false;
                panelTarjetaPaciente.Visible = false;
                panelTarjetaMedico.Visible = false;
                btnGuardar.Location = new Point(40, 375);
                lnkVolver.Location = new Point(175, 430);
                lnkVolver.Text = "Cancelar y Volver";
                panelCard.Height = 480;
            }
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

        private void ConfigurarTarjetaTipoUsuario(Panel panel, RadioButton radioAsociado, string emoji, string texto)
        {
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Tema.FondoTarjeta;
            panel.Cursor = Cursors.Hand;
            panel.Controls.Clear();

            var etiqueta = new Label
            {
                Text = emoji + "  " + texto,
                Font = Tema.FuenteLabelCampo,
                ForeColor = Tema.TextoPrincipal,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            panel.Controls.Add(etiqueta);
            panel.Click += (s, ev) => radioAsociado.Checked = true;
            etiqueta.Click += (s, ev) => radioAsociado.Checked = true;
            radioAsociado.CheckedChanged += (s, ev) =>
            {
                panel.BackColor = radioAsociado.Checked ? Tema.FondoTarjetaSeleccionada : Tema.FondoTarjeta;
                panel.BorderStyle = radioAsociado.Checked ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            };
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
                    bool guardado = editar
                        ? controlador.EditarUsuario(idUsuarioEditar.Value, idRol, correo, contrasena)
                        : controlador.CrearUsuario(idRol, correo, contrasena) > 0;

                    if (!guardado)
                    {
                        MessageBox.Show("El correo ya está registrado o el usuario no está disponible.", "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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

                MessageBox.Show("¡Usuario registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (idRol == controlador.ObtenerIdRol("Paciente"))
                {
                    new crearPaciente(idUsuarioCreado).Show();
                    Close();
                }
                else if (idRol == controlador.ObtenerIdRol("Doctor"))
                {
                    new crearDoctor(idUsuarioCreado).Show();
                    Close();
                }
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
                paginaPrincipalDoctores ventanaDoctores = Application.OpenForms["paginaPrincipalDoctores"] as paginaPrincipalDoctores;
                if (ventanaDoctores == null)
                    new paginaPrincipalDoctores().Show();
                else
                {
                    ventanaDoctores.Show();
                    ventanaDoctores.BringToFront();
                }
                Close();
            }
            else
            {
                new iniciarSesion().Show();
                Hide();
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e) { }
        private void lblCorreo_Click(object sender, EventArgs e) { }
        private void panelCard_Paint_1(object sender, PaintEventArgs e) { }
        private void crearUsuario_Load_1(object sender, EventArgs e) { }
    }
}
