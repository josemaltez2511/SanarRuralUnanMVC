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

namespace SanarRuralUnan.Views
{
    public partial class crearUsuario : Form
    {
        // Objeto del Controller de usuarios
        // Lo usamos para pedirle validaciones y guardar el usuario,
        // así la Vista nunca habla directo con la base de datos
        private usuariosControllers controlador = new usuariosControllers();

        public crearUsuario()
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

        private void crearUsuario_Load(object sender, EventArgs e)
        {
            txtCorreo.Focus();
            CentrarPanelCard();

            // Textos de advertencia iniciales para validación en tiempo real
            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Color.FromArgb(100, 110, 120);
            lblErrorConfirmar.Text = "";
        }

        private void crearUsuario_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // Validación en tiempo real del Correo (Formato y existencia en Base de Datos)
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                lblErrorCorreo.Text = "El correo no puede estar vacío.";
                lblErrorCorreo.ForeColor = Color.Red;
                return;
            }

            // Validar formato de correo con expresión regular
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(correo, patronCorreo))
            {
                lblErrorCorreo.Text = "Formato de correo inválido.";
                lblErrorCorreo.ForeColor = Color.Red;
                return;
            }

            // Le preguntamos al Controller si el correo ya existe
            // (la Vista ya NO consulta la base de datos directamente, eso lo hace el Modelo)
            if (controlador.CorreoYaExiste(correo))
            {
                lblErrorCorreo.Text = "Este correo ya está registrado en la base de datos.";
                lblErrorCorreo.ForeColor = Color.Red;
            }
            else
            {
                lblErrorCorreo.Text = "Correo disponible.";
                lblErrorCorreo.ForeColor = Color.FromArgb(120, 190, 32);
            }
        }

        // metodo privado para validar que la contraseña ingresada por el usuario sea correcta
        private void ValidarCoincidenciaContrasenas()
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden";
                lblErrorConfirmar.ForeColor = Color.Red;
            }
            else
            {
                lblErrorConfirmar.Text = "Las contraseñas coinciden";
                lblErrorConfirmar.ForeColor = Color.FromArgb(120, 190, 32);
            }
        }


        // Validación en tiempo real de la Contraseña (Mínimo 5 caracteres)
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string pass = txtContrasena.Text;

            if (pass.Length < 5)
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Color.Red;
            }
            else
            {
                lblErrorContrasena.Text = "Contraseña válida";
                lblErrorContrasena.ForeColor = Color.FromArgb(120, 190, 32);
            }

            ValidarCoincidenciaContrasenas();
        }

        // Validación en tiempo real de la confirmación de contraseña
        private void txtConfirmarContrasena_TextChanged(object sender, EventArgs e)
        {
            ValidarCoincidenciaContrasenas();
        }

        // Botón Guardar con validaciones finales antes de registrar
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
                // Le pedimos al Controller que cree el usuario
                // El controller se encarga de preguntarle al Modelo si el correo ya existe y de guardar
                // La Vista ya no sabe nada de la base de datos, solo del Controller
                bool creado = controlador.CrearUsuario(correo, contrasena);

                if (!creado)
                {
                    MessageBox.Show("El correo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("¡Usuario registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                iniciarSesion login = new iniciarSesion();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            iniciarSesion login = new iniciarSesion();
            login.Show();
            this.Hide();
        }

        private void panelCard_Paint(object sender, PaintEventArgs e) { }

        private void lblCorreo_Click(object sender, EventArgs e)
        {

        }

        private void panelCard_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}