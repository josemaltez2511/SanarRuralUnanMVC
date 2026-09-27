using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    public partial class crearUsuario : Form
    {
        private usuariosControllers controlador = new usuariosControllers();
        private bool esRegistroDoctorFijo = false;

        public crearUsuario()
        {
            InitializeComponent();
        }

        public crearUsuario(bool forzarDoctor) : this()
        {
            this.esRegistroDoctorFijo = forzarDoctor;
        }

        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;

            panelCard.Location = new Point(
                Math.Max(10, x),
                Math.Max(10, y)
            );
        }

        private void crearUsuario_Load(object sender, EventArgs e)
        {
            txtCorreo.Focus();
            CentrarPanelCard();

            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Tema.TextoAyuda;
            lblErrorConfirmar.Text = "";

            rbPaciente.Checked = true;

            btnVerContrasena.Text = "👁";
            btnVerConfirmarContrasena.Text = "👁";

            ConfigurarTarjetaTipoUsuario(panelTarjetaPaciente, rbPaciente, "🧑‍⚕️", "Paciente");
            ConfigurarTarjetaTipoUsuario(panelTarjetaMedico, rbMedico, "👨‍⚕️", "Médico/Personal de salud");

            if (esRegistroDoctorFijo)
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

        private void ConfigurarTarjetaTipoUsuario(Panel panel, RadioButton radioAsociado, string emoji, string texto)
        {
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Tema.FondoTarjeta;
            panel.Cursor = Cursors.Hand;
            panel.Controls.Clear();

            var lbl = new Label
            {
                Text = $"{emoji}  {texto}",
                Font = Tema.FuenteLabelCampo,
                ForeColor = Tema.TextoPrincipal,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            panel.Controls.Add(lbl);

            panel.Click += (s, ev) => radioAsociado.Checked = true;
            lbl.Click += (s, ev) => radioAsociado.Checked = true;

            radioAsociado.CheckedChanged += (s, ev) =>
            {
                if (radioAsociado.Checked)
                {
                    panel.BackColor = Tema.FondoTarjetaSeleccionada;
                    panel.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    panel.BackColor = Tema.FondoTarjeta;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                }
            };
        }

        private void crearUsuario_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            if (txtContrasena.PasswordChar == '●')
            {
                txtContrasena.PasswordChar = '\0';
                btnVerContrasena.Text = "🙈";
            }
            else
            {
                txtContrasena.PasswordChar = '●';
                btnVerContrasena.Text = "👁";
            }

            txtContrasena.Focus();
            txtContrasena.SelectionStart = txtContrasena.Text.Length;
        }

        private void btnVerConfirmarContrasena_Click(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.PasswordChar == '●')
            {
                txtConfirmarContrasena.PasswordChar = '\0';
                btnVerConfirmarContrasena.Text = "🙈";
            }
            else
            {
                txtConfirmarContrasena.PasswordChar = '●';
                btnVerConfirmarContrasena.Text = "👁";
            }

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

            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(correo, patronCorreo))
            {
                lblErrorCorreo.Text = "Formato de correo inválido.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
                return;
            }

            if (controlador.CorreoYaExiste(correo))
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

        private void ValidarCoincidenciaContrasenas()
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden";
                lblErrorConfirmar.ForeColor = Tema.ColorError;
            }
            else
            {
                lblErrorConfirmar.Text = "Las contraseñas coinciden";
                lblErrorConfirmar.ForeColor = Tema.ColorExito;
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string pass = txtContrasena.Text;

            if (pass.Length < 5)
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
            string contrasena = txtContrasena.Text.Trim();
            string confirmar = txtConfirmarContrasena.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasena.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idUsuarioCreado = controlador.CrearUsuario(correo, contrasena);

                if (idUsuarioCreado == -1)
                {
                    MessageBox.Show("El correo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("¡Usuario registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (rbPaciente.Checked)
                {
                    crearPaciente formPaciente = new crearPaciente(idUsuarioCreado);
                    formPaciente.Show();
                    this.Close();
                }
                else if (rbMedico.Checked)
                {
                    crearDoctor formDoctor = new crearDoctor(idUsuarioCreado);
                    formDoctor.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (esRegistroDoctorFijo)
            {
                paginaPrincipalDoctores ventanaDoctores = Application.OpenForms["paginaPrincipalDoctores"] as paginaPrincipalDoctores;
                if (ventanaDoctores != null)
                {
                    ventanaDoctores.Show();
                    ventanaDoctores.BringToFront();
                }
                else
                {
                    paginaPrincipalDoctores formDoctores = new paginaPrincipalDoctores();
                    formDoctores.Show();
                }
                this.Close();
            }
            else
            {
                iniciarSesion login = new iniciarSesion();
                login.Show();
                this.Hide();
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e) { }
        private void lblCorreo_Click(object sender, EventArgs e) { }
        private void panelCard_Paint_1(object sender, PaintEventArgs e) { }
        private void crearUsuario_Load_1(object sender, EventArgs e) { }
    }
}