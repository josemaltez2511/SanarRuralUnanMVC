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

            panelCard.Location = new Point(
                Math.Max(10, x),
                Math.Max(10, y)
            );
        }

        private void crearUsuario_Load(object sender, EventArgs e)
        {
            txtCorreo.Focus();
            CentrarPanelCard();

            // Textos de advertencia iniciales para validación en tiempo real
            lblErrorCorreo.Text = "";

            lblErrorContrasena.Text =
                "La contraseña debe ser al menos 5 caracteres";

            lblErrorContrasena.ForeColor =
                Color.FromArgb(100, 110, 120);

            lblErrorConfirmar.Text = "";

            // Dejamos "Paciente" marcado por defecto
            rbPaciente.Checked = true;

            // Estado inicial de los botones para mostrar/ocultar contraseña
            btnVerContrasena.Text = "👁";
            btnVerConfirmarContrasena.Text = "👁";
        }

        private void crearUsuario_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // MOSTRAR / OCULTAR CONTRASEÑA
        

        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            if (txtContrasena.PasswordChar == '●')
            {
                // Mostrar contraseña
                txtContrasena.PasswordChar = '\0';

                // Cambiar icono
                btnVerContrasena.Text = "🙈";
            }
            else
            {
                // Ocultar contraseña
                txtContrasena.PasswordChar = '●';

                // Cambiar icono
                btnVerContrasena.Text = "👁";
            }

            // Volver a colocar el cursor en el campo
            txtContrasena.Focus();

            // Mantener el cursor al final de la contraseña
            txtContrasena.SelectionStart =
                txtContrasena.Text.Length;
        }

        private void btnVerConfirmarContrasena_Click(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.PasswordChar == '●')
            {
                // Mostrar contraseña
                txtConfirmarContrasena.PasswordChar = '\0';

                // Cambiar icono
                btnVerConfirmarContrasena.Text = "🙈";
            }
            else
            {
                // Ocultar contraseña
                txtConfirmarContrasena.PasswordChar = '●';

                // Cambiar icono
                btnVerConfirmarContrasena.Text = "👁";
            }

            // Volver a colocar el cursor en el campo
            txtConfirmarContrasena.Focus();

            // Mantener el cursor al final de la contraseña
            txtConfirmarContrasena.SelectionStart =
                txtConfirmarContrasena.Text.Length;
        }

        
        // VALIDACIÓN DEL CORREO

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                lblErrorCorreo.Text =
                    "El correo no puede estar vacío.";

                lblErrorCorreo.ForeColor =
                    Color.Red;

                return;
            }

            // Validar formato de correo con expresión regular
            string patronCorreo =
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(correo, patronCorreo))
            {
                lblErrorCorreo.Text =
                    "Formato de correo inválido.";

                lblErrorCorreo.ForeColor =
                    Color.Red;

                return;
            }

            // Le preguntamos al Controller si el correo ya existe
            // La Vista no consulta directamente la base de datos
            if (controlador.CorreoYaExiste(correo))
            {
                lblErrorCorreo.Text =
                    "Este correo ya está registrado en la base de datos.";

                lblErrorCorreo.ForeColor =
                    Color.Red;
            }
            else
            {
                lblErrorCorreo.Text =
                    "Correo disponible.";

                lblErrorCorreo.ForeColor =
                    Color.FromArgb(120, 190, 32);
            }
        }

        // VALIDAR COINCIDENCIA DE CONTRASEÑAS

        private void ValidarCoincidenciaContrasenas()
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text =
                    "Las contraseñas no coinciden";

                lblErrorConfirmar.ForeColor =
                    Color.Red;
            }
            else
            {
                lblErrorConfirmar.Text =
                    "Las contraseñas coinciden";

                lblErrorConfirmar.ForeColor =
                    Color.FromArgb(120, 190, 32);
            }
        }

        // VALIDACIÓN DE CONTRASEÑA

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string pass = txtContrasena.Text;

            if (pass.Length < 5)
            {
                lblErrorContrasena.Text =
                    "La contraseña debe ser al menos 5 caracteres";

                lblErrorContrasena.ForeColor =
                    Color.Red;
            }
            else
            {
                lblErrorContrasena.Text =
                    "Contraseña válida";

                lblErrorContrasena.ForeColor =
                    Color.FromArgb(120, 190, 32);
            }

            ValidarCoincidenciaContrasenas();
        }

       // VALIDACIÓN DE CONFIRMACIÓN DE CONTRASEÑA

        private void txtConfirmarContrasena_TextChanged(
            object sender,
            EventArgs e)
        {
            ValidarCoincidenciaContrasenas();
        }

        // BOTÓN GUARDAR

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string confirmar = txtConfirmarContrasena.Text.Trim();

            if (
                string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(confirmar)
            )
            {
                MessageBox.Show(
                    "Por favor, complete todos los campos.",
                    "Campos Vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (contrasena.Length < 5)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 5 caracteres.",
                    "Seguridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (contrasena != confirmar)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // Le pedimos al Controller que cree el usuario
                //
                // CrearUsuario devuelve:
                // - IdUsuario si el usuario fue creado correctamente
                // - -1 si el correo ya existe

                int idUsuarioCreado =
                    controlador.CrearUsuario(
                        correo,
                        contrasena
                    );

                if (idUsuarioCreado == -1)
                {
                    MessageBox.Show(
                        "El correo ya se encuentra registrado.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MessageBox.Show(
                    "¡Usuario registrado con éxito!",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // TIPO DE USUARIO

                if (rbPaciente.Checked)
                {
                    // Abrimos el formulario para completar
                    // el perfil del Paciente

                    crearPaciente formPaciente =
                        new crearPaciente(idUsuarioCreado);

                    formPaciente.Show();

                    this.Hide();
                }
                else if (rbMedico.Checked)
                {
                    // Cuando crearMedico.cs esté listo,
                    // aquí se abrirá ese formulario.

                    // crearMedico formMedico =
                    //     new crearMedico(idUsuarioCreado);
                    //
                    // formMedico.Show();
                    // this.Hide();

                    MessageBox.Show(
                        "El formulario de registro de médico aún está en construcción.",
                        "Pendiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        
        // VOLVER AL LOGIN
        

        private void lnkVolver_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            iniciarSesion login =
                new iniciarSesion();

            login.Show();

            this.Hide();
        }

        // EVENTOS DEL FORMULARIO

        private void panelCard_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblCorreo_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panelCard_Paint_1(
            object sender,
            PaintEventArgs e)
        {
        }

        private void crearUsuario_Load_1(
            object sender,
            EventArgs e)
        {
        }
    }
}