using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;

namespace SanarRuralUnan.Views.Hospitales
{
    public partial class crearHospital : Form
    {
        // La Vista utiliza el Controller para comunicarse con el Modelo.
        // La Vista nunca accede directamente a la base de datos.
        private readonly hospitalesController controlador = new hospitalesController();
        private readonly int? idHospital;
        private bool cargandoCatalogos;

        public crearHospital()
        {
            InitializeComponent();
        }

        public crearHospital(int idHospital) : this()
        {
            this.idHospital = idHospital;
        }

        // Carga los departamentos y, al editar, selecciona el municipio del hospital.
        private void crearHospital_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDepartamentos();

                if (idHospital.HasValue)
                {
                    SanarRuralUnan.Hospitales hospital = controlador.consultarHospital(idHospital.Value);
                    if (hospital == null)
                    {
                        MessageBox.Show("El hospital ya no está disponible.", "Hospital no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                        return;
                    }

                    txtNombre.Text = hospital.Nombre;
                    txtDireccion.Text = hospital.Direccion;
                    txtTelefono.Text = hospital.Telefono;

                    cargandoCatalogos = true;
                    cmbDepartamento.SelectedValue = hospital.Municipios.IdDepartamento;
                    CargarMunicipios(hospital.Municipios.IdDepartamento);
                    cmbMunicipio.SelectedValue = hospital.IdMunicipio;
                    cargandoCatalogos = false;
                    Text = "Editar Hospital";
                    lblTitulo.Text = "Editar Hospital";
                    btnGuardar.Text = "Guardar Cambios";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos del hospital:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void CargarDepartamentos()
        {
            cargandoCatalogos = true;
            cmbDepartamento.DisplayMember = "Nombre";
            cmbDepartamento.ValueMember = "IdDepartamento";
            cmbDepartamento.DataSource = controlador.listarDepartamentos();
            cmbDepartamento.SelectedIndex = -1;
            cmbMunicipio.DataSource = null;
            cargandoCatalogos = false;
        }

        private void CargarMunicipios(int idDepartamento)
        {
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "IdMunicipio";
            cmbMunicipio.DataSource = controlador.listarMunicipios(idDepartamento);
            cmbMunicipio.SelectedIndex = -1;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCatalogos) return;

            Departamentos departamento = cmbDepartamento.SelectedItem as Departamentos;
            cargandoCatalogos = true;
            cmbMunicipio.DataSource = null;
            if (departamento != null)
            {
                CargarMunicipios(departamento.IdDepartamento);
            }
            cargandoCatalogos = false;
        }

        // Valida los campos obligatorios y guarda el hospital.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(cmbDepartamento.SelectedItem is Departamentos departamento))
            {
                MessageBox.Show("Seleccione un departamento.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartamento.Focus();
                return;
            }

            if (!(cmbMunicipio.SelectedItem is Municipios municipio) || municipio.IdDepartamento != departamento.IdDepartamento)
            {
                MessageBox.Show("Seleccione un municipio del departamento indicado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMunicipio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del hospital.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                string nombre = txtNombre.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (idHospital.HasValue)
                {
                    controlador.editarHospital(idHospital.Value, municipio.IdMunicipio, nombre, direccion, telefono);
                }
                else
                {
                    controlador.crearHospital(municipio.IdMunicipio, nombre, direccion, telefono);
                }

                MessageBox.Show("Los datos del hospital se guardaron correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el hospital:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cierra el formulario y regresa al listado.
        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }
    }
}
