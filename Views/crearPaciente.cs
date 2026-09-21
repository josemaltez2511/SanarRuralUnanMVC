using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;

namespace SanarRuralUnan.Views
{
    public partial class crearPaciente : Form
    {
        // Objeto del Controller de pacientes
        // Lo usamos para pedirle que guarde el paciente,
        // así la Vista nunca habla directo con la base de datos
        private pacientesController controlador = new pacientesController();

        // Guardamos el IdUsuario de la cuenta que se acaba de crear en RF-01,
        // porque el paciente necesita quedar ligado a esa cuenta
        private int idUsuario;

        // Constructor que recibe el IdUsuario desde la pantalla de crearUsuario
        // Así este formulario ya sabe a qué cuenta pertenece el paciente que se va a registrar
        public crearPaciente(int idUsuarioRecibido)
        {
            InitializeComponent();
            idUsuario = idUsuarioRecibido;
        }

        // Método para centrar dinámicamente la tarjeta principal de manera responsiva
        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;
            panelCard.Location = new System.Drawing.Point(Math.Max(10, x), Math.Max(10, y));
        }

        private void crearPaciente_Load(object sender, EventArgs e)
        {
            txtNombres.Focus();
            CentrarPanelCard();

            // Dejamos el ComboBox de Género con una opción seleccionada por defecto
            if (cmbGenero.Items.Count > 0)
                cmbGenero.SelectedIndex = 0;

            // La fecha de nacimiento no puede ser en el futuro,
            // así que limitamos el DateTimePicker hasta el día de hoy
            dtpFechaNacimiento.MaxDate = DateTime.Now;

            lblErrorNombres.Text = "";
            lblErrorTelefono.Text = "";
        }

        private void crearPaciente_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // Validación en tiempo real de Nombres (no puede quedar vacío)
        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                lblErrorNombres.Text = "El nombre no puede estar vacío.";
                lblErrorNombres.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblErrorNombres.Text = "";
            }
        }

        // Validación en tiempo real de Teléfono (solo números, largo razonable)
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrEmpty(telefono))
            {
                lblErrorTelefono.Text = "";
                return;
            }

            bool esSoloNumeros = true;
            foreach (char c in telefono)
            {
                if (!char.IsDigit(c))
                {
                    esSoloNumeros = false;
                    break;
                }
            }

            if (!esSoloNumeros)
            {
                lblErrorTelefono.Text = "El teléfono solo debe contener números.";
                lblErrorTelefono.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblErrorTelefono.Text = "";
            }
        }

        // Botón Guardar con validaciones finales antes de registrar el paciente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string genero = cmbGenero.SelectedItem != null ? cmbGenero.SelectedItem.ToString() : "";
            string telefono = txtTelefono.Text.Trim();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;

            if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos))
            {
                MessageBox.Show("Por favor, complete al menos el nombre y los apellidos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Le pedimos al Controller que cree el paciente
                // Él se encarga de hablar con el Modelo y guardar en la base de datos
                // La Vista nunca toca la base de datos directamente
                controlador.CrearPaciente(idUsuario, nombres, apellidos, fechaNacimiento, genero, telefono);

                MessageBox.Show("¡Paciente registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Permite continuar sin completar el perfil de paciente en este momento
        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void crearPaciente_Load_1(object sender, EventArgs e)
        {

        }
    }
}