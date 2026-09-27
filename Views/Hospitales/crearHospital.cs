using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views;

namespace SanarRuralUnan.Views.Hospitales
{
    public partial class crearHospital : Form
    {
        // ============================================================
        // CONTROLLER
        // ============================================================
        // La Vista utiliza el Controller para comunicarse con el Modelo.
        // La Vista nunca accede directamente a la base de datos.
        private hospitalesController controlador = new hospitalesController();

        public crearHospital()
        {
            InitializeComponent();
        }

        // ============================================================
        // CENTRAR TARJETA
        // ============================================================
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
        private void crearHospital_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            CentrarPanelCard();

            lblErrorNombre.Text = "";
            lblErrorUbicacion.Text = "";
        }

        private void crearHospital_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // ============================================================
        // VALIDACIÓN DE NOMBRE
        // ============================================================
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblErrorNombre.Text = "El nombre no puede estar vacío.";
                lblErrorNombre.ForeColor = Tema.ColorError;
            }
            else
            {
                lblErrorNombre.Text = "";
            }
        }

        // ============================================================
        // VALIDACIÓN DE UBICACIÓN
        // ============================================================
        private void txtUbicacion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                lblErrorUbicacion.Text = "La ubicación no puede estar vacía.";
                lblErrorUbicacion.ForeColor = Tema.ColorError;
            }
            else
            {
                lblErrorUbicacion.Text = "";
            }
        }

        // ============================================================
        // GUARDAR HOSPITAL
        // RF nuevo: Crear Hospital (identificado a partir del diagrama E-R)
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string ubicacion = txtUbicacion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Por favor, ingrese el nombre del hospital.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ubicacion))
            {
                MessageBox.Show(
                    "Por favor, ingrese la ubicación del hospital.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtUbicacion.Focus();
                return;
            }

            try
            {
                // Le pedimos al Controller que cree el hospital.
                // El controller a su vez le pide al Modelo que lo guarde
                // (y que le asigne Estado = true por defecto).
                controlador.crearHospital(nombre, ubicacion);

                MessageBox.Show(
                    "¡Hospital registrado con éxito!",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el hospital:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CERRAR / CANCELAR
        // ============================================================
        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SanarRuralUnan.Views.menuPrincipalMedicos menu = new SanarRuralUnan.Views.menuPrincipalMedicos();
            menu.Show();
            this.Close();
        }

        private void panelCard_Paint(object sender, PaintEventArgs e) { }
    }
}