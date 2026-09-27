using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Models;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    public partial class crearDoctor : Form
    {
        // ============================================================
        // CONTROLLERS
        // ============================================================

        // La Vista nunca accede directamente a la base de datos.
        // Instanciamos los controladores para comunicar con el modelo.
        private doctoresControllers controladorDoctores = new doctoresControllers();
        private hospitalesController controladorHospitales = new hospitalesController();


        // ============================================================
        // PROPIEDADES DE ESTADO
        // ============================================================

        private int idUsuario;
        private int idDoctorEdicion = 0;
        private bool esModoEdicion = false;


        // ============================================================
        // CONSTRUCTORES
        // ============================================================

        // Constructor para registro nuevo (recibe el IdUsuario recién creado)
        public crearDoctor(int idUsuarioRecibido)
        {
            InitializeComponent();
            idUsuario = idUsuarioRecibido;
            esModoEdicion = false;
        }

        // Constructor para edición (recibe el IdDoctor a editar)
        public crearDoctor(int idDoctor, bool modoEdicion)
        {
            InitializeComponent();
            idDoctorEdicion = idDoctor;
            esModoEdicion = modoEdicion;
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

        private void crearDoctor_Load(object sender, EventArgs e)
        {
            txtNombres.Focus();
            CentrarPanelCard();

            // Cargar hospitales disponibles en el ComboBox
            CargarHospitales();

            // Limpiar advertencias
            lblErrorNombres.Text = "";
            lblErrorApellidos.Text = "";
            lblErrorLicencia.Text = "";

            // Si entramos en modo edición, cargamos los datos existentes del médico
            if (esModoEdicion)
            {
                lblSubtitulo.Text = "Modificar Datos del Doctor";
                btnGuardar.Text = "Guardar Cambios";

                var doctor = controladorDoctores.consultarDoctorPorId(idDoctorEdicion);
                if (doctor != null)
                {
                    txtNombres.Text = doctor.Nombres;
                    txtApellidos.Text = doctor.Apellidos;
                    txtEspecialidad.Text = doctor.Especialidad;
                    txtNumeroLicencia.Text = doctor.NumeroLicencia;
                    cmbHospital.SelectedValue = doctor.IdHospital;
                }
            }
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
                var listaHospitales = controladorHospitales.listarHospitales();

                cmbHospital.DataSource = listaHospitales;
                cmbHospital.DisplayMember = "Nombre";
                cmbHospital.ValueMember = "IdHospital";

                cmbHospital.DropDownStyle = ComboBoxStyle.DropDown;
                cmbHospital.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbHospital.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (cmbHospital.Items.Count > 0)
                {
                    cmbHospital.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar los hospitales.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
        // VALIDACIÓN DE APELLIDOS
        // ============================================================

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                lblErrorApellidos.Text = "Los apellidos no pueden estar vacíos.";
                lblErrorApellidos.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblErrorApellidos.Text = "";
            }
        }


        // ============================================================
        // VALIDACIÓN DE LICENCIA
        // ============================================================

        private void txtNumeroLicencia_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroLicencia.Text))
            {
                lblErrorLicencia.Text = "La licencia no puede estar vacía.";
                lblErrorLicencia.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblErrorLicencia.Text = "";
            }
        }


        // ============================================================
        // GUARDAR / EDITAR DOCTOR
        // ============================================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string especialidad = txtEspecialidad.Text.Trim();
            string numeroLicencia = txtNumeroLicencia.Text.Trim();

            // Validaciones de campos obligatorios
            if (string.IsNullOrWhiteSpace(nombres))
            {
                MessageBox.Show("Por favor, ingrese los nombres del doctor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show("Por favor, ingrese los apellidos del doctor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(especialidad))
            {
                MessageBox.Show("Por favor, ingrese la especialidad.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEspecialidad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(numeroLicencia))
            {
                MessageBox.Show("Por favor, ingrese el número de licencia.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroLicencia.Focus();
                return;
            }

            if (cmbHospital.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un hospital o centro de salud.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHospital.Focus();
                return;
            }

            int idHospital = Convert.ToInt32(cmbHospital.SelectedValue);

            // --------------------------------------------------------
            // MODO EDICIÓN
            // --------------------------------------------------------
            if (esModoEdicion)
            {
                try
                {
                    controladorDoctores.editarDoctor(
                        idDoctorEdicion,
                        nombres,
                        apellidos,
                        especialidad,
                        numeroLicencia,
                        idHospital
                    );

                    MessageBox.Show(
                        "¡Doctor modificado con éxito!",
                        "Registro Actualizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    RegresarAMenuDoctores();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al actualizar el doctor:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // --------------------------------------------------------
            // MODO CREACIÓN
            // --------------------------------------------------------
            try
            {
                controladorDoctores.crearDoctor(
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

                RegresarAMenuDoctores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar el doctor:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ============================================================
        // VOLVER / CANCELAR
        // ============================================================

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegresarAMenuDoctores();
        }


        // ============================================================
        // NAVEGACIÓN HACIA LA PANTALLA PRINCIPAL DE DOCTORES
        // ============================================================
        private void RegresarAMenuDoctores()
        {
            // Verificamos si la ventana de doctores ya estaba abierta en segundo plano
            paginaPrincipalDoctores ventanaAbierta = Application.OpenForms["paginaPrincipalDoctores"] as paginaPrincipalDoctores;

            if (ventanaAbierta != null)
            {
                ventanaAbierta.Show();
                ventanaAbierta.BringToFront();
            }
            else
            {
                // Si venía desde el registro de usuario, creamos la ventana del catálogo
                paginaPrincipalDoctores formDoctores = new paginaPrincipalDoctores();
                formDoctores.Show();
            }

            this.Close();
        }


        // ============================================================
        // PANEL PAINT
        // ============================================================

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}