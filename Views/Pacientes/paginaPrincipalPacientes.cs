using System;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Pacientes
{
    public partial class paginaPrincipalPacientes : Form
    {
        private readonly pacientesControllers controlador = new pacientesControllers();

        public paginaPrincipalPacientes()
        {
            InitializeComponent();
        }

        private void paginaPrincipalPacientes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarPacientes();
        }

        private void ConfigurarGrid()
        {
            Tema.ConfigurarTabla(dgvPacientes);
            dgvPacientes.AccessibleName = "Listado de pacientes activos";
            dgvPacientes.AccessibleDescription = "Use las flechas para recorrer pacientes y Tab para acceder a sus acciones.";
            dgvPacientes.Columns["Nombre"].FillWeight = 150;
            dgvPacientes.Columns["Comunidad"].FillWeight = 105;
            dgvPacientes.Columns["Municipio"].FillWeight = 90;
            dgvPacientes.Columns["Departamento"].FillWeight = 95;
            dgvPacientes.Columns["colEditar"].FillWeight = 58;
            dgvPacientes.Columns["colBaja"].FillWeight = 76;
            dgvPacientes.Columns["colEditar"].DefaultCellStyle.ForeColor = Tema.AzulPrimario;
            dgvPacientes.Columns["colBaja"].DefaultCellStyle.ForeColor = Tema.Error;
        }

        private void CargarPacientes(string filtro = "")
        {
            try
            {
                dgvPacientes.Rows.Clear();
                var pacientes = controlador.listarPacientes(filtro);
                foreach (SanarRuralUnan.Pacientes paciente in pacientes)
                {
                    string nombre = string.Join(" ", new[]
                    {
                        paciente.PrimerNombre,
                        paciente.SegundoNombre,
                        paciente.PrimerApellido,
                        paciente.SegundoApellido
                    }.Where(parte => !string.IsNullOrWhiteSpace(parte)));

                    dgvPacientes.Rows.Add(
                        paciente.IdPaciente,
                        nombre,
                        paciente.Cedula,
                        paciente.Telefono,
                        paciente.Comunidades.Nombre,
                        paciente.Comunidades.Municipios.Nombre,
                        paciente.Comunidades.Municipios.Departamentos.Nombre,
                        paciente.Estado ? "✓ Activo" : "Inactivo");
                }

                lblCantidad.Text = pacientes.Count + (pacientes.Count == 1 ? " paciente activo" : " pacientes activos");
            }
            catch (Exception ex)
            {
                lblCantidad.Text = "No se pudo cargar el listado";
                MessageBox.Show("No se pudo cargar el listado de pacientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPacientes(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearPaciente formulario = new crearPaciente())
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                    CargarPacientes(txtBuscar.Text.Trim());
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["IdPaciente"].Value);
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colEditar")
            {
                using (crearPaciente formulario = new crearPaciente(idPaciente, true))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarPacientes(txtBuscar.Text.Trim());
                }
            }
            else if (dgvPacientes.Columns[e.ColumnIndex].Name == "colBaja")
            {
                string nombre = dgvPacientes.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString() ?? "este paciente";
                if (MessageBox.Show("¿Desea dar de baja a " + nombre + "? Su historial se conservará.",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        controlador.eliminarPaciente(idPaciente);
                        CargarPacientes(txtBuscar.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo dar de baja al paciente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvPacientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPacientes.Columns[e.ColumnIndex].Name == "Estado")
            {
                e.CellStyle.ForeColor = Tema.VerdeOscuro;
            }
        }
    }
}
