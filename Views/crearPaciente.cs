using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;

namespace SanarRuralUnan.Views
{
    public partial class crearPaciente : Form
    {
        // ============================================================
        // CONTROLLER
        // ============================================================
        // La Vista utiliza el Controller para comunicarse con el Modelo.
        // La Vista nunca accede directamente a la base de datos.

        private pacientesController controlador = new pacientesController();


        // ============================================================
        // ID DEL USUARIO
        // ============================================================
        // El paciente queda relacionado con la cuenta de usuario
        // que fue creada previamente.

        private int idUsuario;


        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public crearPaciente(int idUsuarioRecibido)
        {
            InitializeComponent();

            idUsuario = idUsuarioRecibido;
        }


        // ============================================================
        // CENTRAR PANEL PRINCIPAL
        // ============================================================
        // Mantiene la tarjeta centrada cuando cambia el tamaño
        // de la ventana.

        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;

            panelCard.Location = new System.Drawing.Point(
                Math.Max(10, x),
                Math.Max(10, y)
            );
        }


        // ============================================================
        // LOAD
        // ============================================================

        private void crearPaciente_Load(object sender, EventArgs e)
        {
            // Colocar el cursor inicialmente en nombres.
            txtNombres.Focus();

            // Centrar la tarjeta.
            CentrarPanelCard();


            // --------------------------------------------------------
            // GÉNERO
            // --------------------------------------------------------
            // Si el ComboBox tiene opciones, seleccionar la primera.

            if (cmbGenero.Items.Count > 0)
            {
                cmbGenero.SelectedIndex = 0;
            }


            // --------------------------------------------------------
            // FECHA DE NACIMIENTO
            // --------------------------------------------------------
            // No permitimos seleccionar una fecha futura.

            dtpFechaNacimiento.MaxDate = DateTime.Today;


            // --------------------------------------------------------
            // MENSAJES DE ERROR
            // --------------------------------------------------------

            lblErrorNombres.Text = "";
            lblErrorTelefono.Text = "";
        }


        // ============================================================
        // RESPONSIVE
        // ============================================================

        private void crearPaciente_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }


        // ============================================================
        // VALIDACIÓN DE NOMBRES
        // ============================================================

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


        // ============================================================
        // VALIDACIÓN DE TELÉFONO
        // ============================================================
        // El teléfono es opcional.
        // Si se escribe, solamente permitimos números.

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();


            // Si está vacío, no mostramos error porque es opcional.
            if (string.IsNullOrEmpty(telefono))
            {
                lblErrorTelefono.Text = "";
                return;
            }


            // Comprobar que todos los caracteres sean números.
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
                lblErrorTelefono.Text =
                    "El teléfono solo debe contener números.";

                lblErrorTelefono.ForeColor =
                    System.Drawing.Color.Red;
            }
            else
            {
                lblErrorTelefono.Text = "";
            }
        }


        // ============================================================
        // GUARDAR PACIENTE
        // RF-03
        // ============================================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // ========================================================
            // DATOS PERSONALES
            // ========================================================

            string nombres = txtNombres.Text.Trim();

            string apellidos = txtApellidos.Text.Trim();

            DateTime fechaNacimiento =
                dtpFechaNacimiento.Value;

            string genero =
                cmbGenero.SelectedItem != null
                    ? cmbGenero.SelectedItem.ToString()
                    : "";

            string telefono =
                txtTelefono.Text.Trim();


            // ========================================================
            // DATOS DE UBICACIÓN
            // ========================================================

            string departamento =
                txtDepartamento.Text.Trim();

            string municipio =
                txtMunicipio.Text.Trim();

            string comunidad =
                txtComunidad.Text.Trim();

            string direccion =
                txtDireccion.Text.Trim();


            // ========================================================
            // INFORMACIÓN DE SALUD
            // ========================================================

            string contactoEmergencia =
                txtContactoEmergencia.Text.Trim();

            string tipoSangre =
                cmbTipoSangre.SelectedItem != null
                    ? cmbTipoSangre.SelectedItem.ToString()
                    : "";

            string alergias =
                txtAlergias.Text.Trim();

            string antecedentes =
                txtAntecedentes.Text.Trim();


            // ========================================================
            // VALIDACIONES OBLIGATORIAS
            // ========================================================
            // Solamente estos datos son obligatorios:
            // - Nombres
            // - Apellidos
            // - Fecha de nacimiento

            if (string.IsNullOrWhiteSpace(nombres))
            {
                MessageBox.Show(
                    "Por favor, ingrese los nombres del paciente.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombres.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show(
                    "Por favor, ingrese los apellidos del paciente.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtApellidos.Focus();
                return;
            }


            // ========================================================
            // VALIDACIÓN DEL TELÉFONO
            // ========================================================

            if (!string.IsNullOrEmpty(telefono))
            {
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
                    MessageBox.Show(
                        "El teléfono solo debe contener números.",
                        "Teléfono inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtTelefono.Focus();
                    return;
                }
            }


            // ========================================================
            // GUARDAR
            // ========================================================

            try
            {
                // Enviamos todos los datos al Controller.
                controlador.crearPaciente(
                    idUsuario,
                    nombres,
                    apellidos,
                    fechaNacimiento,
                    genero,
                    telefono,
                    departamento,
                    municipio,
                    comunidad,
                    direccion,
                    contactoEmergencia,
                    tipoSangre,
                    alergias,
                    antecedentes
                );


                // Confirmación al usuario.
                MessageBox.Show(
                    "¡Paciente registrado con éxito!",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                // Cerrar formulario.
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el paciente:\n\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ============================================================
        // VOLVER / OMITIR
        // ============================================================
        // Permite cerrar el formulario sin completar información
        // adicional del paciente.

        private void lnkVolver_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }


        // ============================================================
        // EVENTOS EXISTENTES DEL FORMULARIO
        // ============================================================

        private void crearPaciente_Load_1(
            object sender,
            EventArgs e)
        {
        }


        private void panelCard_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}