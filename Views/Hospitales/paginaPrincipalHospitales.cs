using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    public partial class paginaPrincipalHospitales : Form
    {
        private readonly hospitalesController controlador = new hospitalesController();

        public paginaPrincipalHospitales()
        {
            InitializeComponent();
        }

        private void paginaPrincipalHospitales_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarHospitales();
        }

        private void ConfigurarGrid()
        {
            dgvHospitales.BackgroundColor = Color.White;
            dgvHospitales.BorderStyle = BorderStyle.None;
            dgvHospitales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHospitales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHospitales.MultiSelect = false;
            dgvHospitales.ReadOnly = true;
            dgvHospitales.AllowUserToAddRows = false;
            dgvHospitales.AllowUserToDeleteRows = false;
            dgvHospitales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHospitales.RowHeadersVisible = false;
            dgvHospitales.EnableHeadersVisualStyles = false;
            dgvHospitales.ColumnHeadersDefaultCellStyle.BackColor = Tema.AzulPrimario;
            dgvHospitales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHospitales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHospitales.ColumnHeadersHeight = 36;
            dgvHospitales.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvHospitales.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void CargarHospitales(string filtro = "")
        {
            try
            {
                dgvHospitales.Rows.Clear();
                foreach (SanarRuralUnan.Hospitales hospital in controlador.listarHospitales(filtro))
                {
                    dgvHospitales.Rows.Add(
                        hospital.IdHospital,
                        hospital.Nombre,
                        hospital.Municipios.Departamentos.Nombre,
                        hospital.Municipios.Nombre,
                        hospital.Direccion,
                        hospital.Telefono);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el listado de hospitales:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarHospitales(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearHospital formulario = new crearHospital())
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                    CargarHospitales(txtBuscar.Text.Trim());
            }
        }

        private void dgvHospitales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idHospital = Convert.ToInt32(dgvHospitales.Rows[e.RowIndex].Cells["IdHospital"].Value);

            if (dgvHospitales.Columns[e.ColumnIndex].Name == "colEditar")
            {
                using (crearHospital formulario = new crearHospital(idHospital))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarHospitales(txtBuscar.Text.Trim());
                }
            }
            else if (dgvHospitales.Columns[e.ColumnIndex].Name == "colBaja")
            {
                string nombre = dgvHospitales.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString() ?? "este hospital";
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea dar de baja " + nombre + "? Sus referencias históricas se conservarán.",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        controlador.eliminarHospital(idHospital);
                        CargarHospitales(txtBuscar.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo dar de baja el hospital:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new menuPrincipalMedicos().Show();
            Close();
        }
    }
}
