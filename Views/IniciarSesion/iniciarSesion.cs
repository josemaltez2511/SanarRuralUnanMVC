using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; // Necesario para validar el formato del correo
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views;

namespace SanarRuralUnan
{
    public partial class iniciarSesion : Form
    {
        public iniciarSesion()
        {
            InitializeComponent();
        }

        // Método para centrar dinámicamente la tarjeta principal de manera responsiva
        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;
            panelCard.Location = new Point(Math.Max(10, x), Math.Max(10, y));
        }

        private void iniciarSesion_Load(object sender, EventArgs e)
        {
            txtCorreo.Focus();
            CentrarPanelCard();

            // Cargar el logotipo institucional desde los recursos del sistema
            picLogo.Image = Tema.ObtenerLogo();

            btnVerContrasena.Text = "👁";

            // Microinteracciones de hover para botones
            btnIniciarSesion.MouseEnter += (s, ev) => btnIniciarSesion.BackColor = Tema.AzulOscuro;
            btnIniciarSesion.MouseLeave += (s, ev) => btnIniciarSesion.BackColor = Tema.AzulPrimario;
            btnVerContrasena.MouseEnter += (s, ev) => btnVerContrasena.BackColor = Tema.FondoSecundario;
            btnVerContrasena.MouseLeave += (s, ev) => btnVerContrasena.BackColor = Tema.Superficie;

            // Textos de advertencia iniciales
            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe tener al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Tema.TextoSecundario;
        }

        private void iniciarSesion_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // Validación en tiempo real del Formato de Correo en el Login
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                lblErrorCorreo.Text = "";
                return;
            }

            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(correo, patronCorreo))
            {
                lblErrorCorreo.Text = "Formato de correo inválido.";
                lblErrorCorreo.ForeColor = Tema.Error;
            }
            else
            {
                lblErrorCorreo.Text = "Formato correcto.";
                lblErrorCorreo.ForeColor = Tema.VerdeAcento;
            }
        }

        // Validación en tiempo real de la Contraseña (Mínimo 5 caracteres) en el Login
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string pass = txtContrasena.Text;

            if (string.IsNullOrEmpty(pass))
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Tema.TextoSecundario;
                return;
            }

            if (pass.Length < 5)
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Tema.Error;
            }
            else
            {
                lblErrorContrasena.Text = "Longitud de contraseña válida";
                lblErrorContrasena.ForeColor = Tema.VerdeAcento;
            }
        }

        // MOSTRAR / OCULTAR CONTRASEÑA
        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            if (txtContrasena.PasswordChar == '●')
            {
                // Mostrar texto plano
                txtContrasena.PasswordChar = '\0';
                btnVerContrasena.Text = "🙈";
            }
            else
            {
                // Ocultar con viñeta
                txtContrasena.PasswordChar = '●';
                btnVerContrasena.Text = "👁";
            }

            // Mantener el foco y cursor al final del campo
            txtContrasena.Focus();
            txtContrasena.SelectionStart = txtContrasena.Text.Length;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su correo y contraseña para continuar.",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (contrasena.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usuariosControllers controlador = new usuariosControllers();
            int tipoUsuario = controlador.IniciarSesion(correo, contrasena);

            if (tipoUsuario != -1)
            {
                MessageBox.Show("¡Bienvenido al sistema Sanar Rural!",
                                "Inicio de Sesión Exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Enrutamiento según el rol
                if (tipoUsuario == controlador.ObtenerIdRol("Doctor"))
                {
                    // Es Doctor
                    using (menuPrincipalMedicos menuMedico = new menuPrincipalMedicos())
                        menuMedico.ShowDialog(this);
                }
                else if (tipoUsuario == controlador.ObtenerIdRol("Administrativo"))
                {
                    using (var menu = new SanarRuralUnan.Views.menuPrincipalAdministrativo())
                        menu.ShowDialog(this);
                }
                else if (tipoUsuario == controlador.ObtenerIdRol("Paciente"))
                {
                    MessageBox.Show("Aún no se ha creado el menú principal para Pacientes.", "Aviso");
                    controlador.CerrarSesion();
                }
                else
                {
                    MessageBox.Show("El rol de esta cuenta no está disponible en la aplicación.", "Aviso");
                    controlador.CerrarSesion();
                }
            }
            else
            {
                MessageBox.Show("El correo o la contraseña son incorrectos. Verifique sus datos.",
                                "Error de Autenticación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                txtContrasena.Clear();
                txtCorreo.Focus();
            }
        }

        private void lnkCrearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (crearUsuario formCrear = new crearUsuario())
                formCrear.ShowDialog(this);
        }

        private void lblSubtitulo_Click(object sender, EventArgs e) { }
        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            // Borde sutil y limpio para la tarjeta de elevación visual
            using (Pen penBorde = new Pen(Tema.Borde, 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelCard.ClientSize.Width - 1, panelCard.ClientSize.Height - 1);
            }
        }

        private void iniciarSesion_Load_1(object sender, EventArgs e)
        {

        }
    }
}
