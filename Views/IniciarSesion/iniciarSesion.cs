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

            // Textos de advertencia iniciales
            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Color.FromArgb(100, 110, 120);
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
                lblErrorCorreo.ForeColor = Color.Red;
            }
            else
            {
                lblErrorCorreo.Text = "Formato correcto.";
                lblErrorCorreo.ForeColor = Color.FromArgb(120, 190, 32);
            }
        }

        // Validación en tiempo real de la Contraseña (Mínimo 5 caracteres) en el Login
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string pass = txtContrasena.Text;

            if (string.IsNullOrEmpty(pass))
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Color.FromArgb(100, 110, 120);
                return;
            }

            if (pass.Length < 5)
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Color.Red;
            }
            else
            {
                lblErrorContrasena.Text = "Longitud de contraseña válida";
                lblErrorContrasena.ForeColor = Color.FromArgb(120, 190, 32);
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

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
            bool accesoValido = controlador.IniciarSesion(correo, contrasena);

            if (accesoValido)
            {
                MessageBox.Show("¡Bienvenido al sistema Sanar Rural!",
                                "Inicio de Sesión Exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // FrmPrincipal principal = new FrmPrincipal();
                // principal.Show();
                // this.Hide();
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
            crearUsuario formCrear = new crearUsuario();
            formCrear.Show();
            this.Hide();
        }

        private void lblSubtitulo_Click(object sender, EventArgs e) { }
        private void panelCard_Paint(object sender, PaintEventArgs e) { }
    }
}