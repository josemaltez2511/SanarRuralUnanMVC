using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;

namespace SanarRuralUnan.Views
{
    public partial class crearDoctor : Form
    {
        // ============================================================
        // CONTROLLER
        // ============================================================

        // La Vista se comunica con el Controller.
        // La Vista nunca accede directamente a la base de datos.
        private doctoresControllers controlador =
            new doctoresControllers();


        // ============================================================
        // ID DEL USUARIO
        // ============================================================

        // Guardamos el IdUsuario de la cuenta que se acaba de crear.
        // Este usuario quedará relacionado con el doctor.
        private int idUsuario;


        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public crearDoctor(int idUsuarioRecibido)
        {
            InitializeComponent();

            idUsuario = idUsuarioRecibido;
        }


        // ============================================================
        // CENTRAR TARJETA
        // ============================================================

        // Centra la tarjeta principal cuando cambia el tamaño
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

        private void crearDoctor_Load(object sender, EventArgs e)
        {
            txtNombres.Focus();

            CentrarPanelCard();

            // Cargar hospitales disponibles.
            CargarHospitales();

            // Limpiar mensajes de error.
            lblErrorNombres.Text = "";
            lblErrorApellidos.Text = "";
            lblErrorLicencia.Text = "";
        }


        // ============================================================
        // RESPONSIVE
        // ============================================================

        private void crearDoctor_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }


        // ============================================================
        // CARGAR HOSPITALES
        // ============================================================

        private void CargarHospitales()
        {
            try
            {
                cmbHospital.DataSource =
                    controlador.obtenerHospitales();

                cmbHospital.DisplayMember = "Nombre";
                cmbHospital.ValueMember = "IdHospital";

                if (cmbHospital.Items.Count > 0)
                {
                    cmbHospital.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar los hospitales.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ============================================================
        // VALIDACIÓN DE NOMBRES
        // ============================================================

        private void txtNombres_TextChanged(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                lblErrorNombres.Text =
                    "El nombre no puede estar vacío.";

                lblErrorNombres.ForeColor =
                    System.Drawing.Color.Red;
            }
            else
            {
                lblErrorNombres.Text = "";
            }
        }


        // ============================================================
        // VALIDACIÓN DE APELLIDOS
        // ============================================================

        private void txtApellidos_TextChanged(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                lblErrorApellidos.Text =
                    "Los apellidos no pueden estar vacíos.";

                lblErrorApellidos.ForeColor =
                    System.Drawing.Color.Red;
            }
            else
            {
                lblErrorApellidos.Text = "";
            }
        }


        // ============================================================
        // VALIDACIÓN DE LICENCIA
        // ============================================================

        private void txtNumeroLicencia_TextChanged(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtNumeroLicencia.Text))
            {
                lblErrorLicencia.Text =
                    "La licencia no puede estar vacía.";

                lblErrorLicencia.ForeColor =
                    System.Drawing.Color.Red;
            }
            else
            {
                lblErrorLicencia.Text = "";
            }
        }


        // ============================================================
        // GUARDAR DOCTOR
        // RF-07
        // ============================================================

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            string nombres =
                txtNombres.Text.Trim();

            string apellidos =
                txtApellidos.Text.Trim();

            string especialidad =
                txtEspecialidad.Text.Trim();

            string numeroLicencia =
                txtNumeroLicencia.Text.Trim();


            // --------------------------------------------------------
            // VALIDACIONES
            // --------------------------------------------------------

            if (string.IsNullOrWhiteSpace(nombres))
            {
                MessageBox.Show(
                    "Por favor, ingrese los nombres del doctor.",
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
                    "Por favor, ingrese los apellidos del doctor.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtApellidos.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(especialidad))
            {
                MessageBox.Show(
                    "Por favor, ingrese la especialidad.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEspecialidad.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(numeroLicencia))
            {
                MessageBox.Show(
                    "Por favor, ingrese el número de licencia.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNumeroLicencia.Focus();
                return;
            }


            if (cmbHospital.SelectedValue == null)
            {
                MessageBox.Show(
                    "Por favor, seleccione un hospital o centro de salud.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbHospital.Focus();
                return;
            }


            // --------------------------------------------------------
            // OBTENER HOSPITAL
            // --------------------------------------------------------

            int idHospital =
                Convert.ToInt32(cmbHospital.SelectedValue);


            // --------------------------------------------------------
            // GUARDAR
            // --------------------------------------------------------

            try
            {
                controlador.crearDoctor(
                    idUsuario,
                    nombres,
                    apellidos,
                    especialidad,
                    numeroLicencia,
                    idHospital
                );


                MessageBox.Show(
                    "¡Doctor registrado con éxito!",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                // Cerramos el formulario.
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el doctor:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ============================================================
        // VOLVER
        // ============================================================

        private void lnkVolver_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }


        // ============================================================
        // PANEL PAINT
        // ============================================================

        private void panelCard_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}