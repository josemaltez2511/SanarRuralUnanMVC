using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Pacientes
{
    /// <summary>
    /// Formulario principal del catálogo de pacientes.
    /// Presenta el listado moderno con búsqueda ágil, badges de estado y acciones rápidas de ficha y edición.
    /// </summary>
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
            ConfigurarSeguridadPorRol();
            CargarPacientes();
        }

        private void ConfigurarGrid()
        {
            Tema.ConfigurarTabla(dgvPacientes);
            dgvPacientes.AccessibleName = "Listado de pacientes";
            dgvPacientes.AccessibleDescription = "Use las flechas para recorrer pacientes y Enter o espacio en los botones de acción.";
            dgvPacientes.RowTemplate.Height = 44;
            dgvPacientes.ColumnHeadersHeight = 44;

            dgvPacientes.Columns["Nombre"].FillWeight = 150;
            dgvPacientes.Columns["Cedula"].FillWeight = 85;
            dgvPacientes.Columns["Telefono"].FillWeight = 80;
            dgvPacientes.Columns["Comunidad"].FillWeight = 95;
            dgvPacientes.Columns["Municipio"].FillWeight = 90;
            dgvPacientes.Columns["Departamento"].FillWeight = 90;
            dgvPacientes.Columns["Estado"].FillWeight = 75;
            dgvPacientes.Columns["colVer"].FillWeight = 55;
            dgvPacientes.Columns["colEditar"].FillWeight = 55;
            dgvPacientes.Columns["colBaja"].FillWeight = 75;

            colVer.FlatStyle = FlatStyle.Flat;
            colEditar.FlatStyle = FlatStyle.Flat;
            colBaja.FlatStyle = FlatStyle.Flat;

            panelBadgeConteo.Paint += PanelBadgeConteo_Paint;
        }

        private void PanelBadgeConteo_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Tema.Borde, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panelBadgeConteo.Width - 1, panelBadgeConteo.Height - 1);
            }
        }

        private void ConfigurarSeguridadPorRol()
        {
            bool esAdmin = controlador.EsAdministrativo();
            if (esAdmin)
            {
                lblFiltroEstado.Visible = true;
                cmbFiltroEstado.Visible = true;
                cmbFiltroEstado.SelectedIndex = 0; // "Activos" por defecto
                dgvPacientes.Columns["colBaja"].Visible = true;
            }
            else
            {
                // El rol Doctor únicamente puede consultar y dar de alta pacientes activos
                lblFiltroEstado.Visible = false;
                cmbFiltroEstado.Visible = false;
                dgvPacientes.Columns["colBaja"].Visible = false;
            }
        }

        private void CargarPacientes()
        {
            try
            {
                dgvPacientes.Rows.Clear();
                string filtro = txtBuscar.Text.Trim();
                string estadoFiltro = cmbFiltroEstado.Visible && cmbFiltroEstado.SelectedItem != null
                    ? cmbFiltroEstado.SelectedItem.ToString()
                    : "Activos";

                List<PacienteItemDto> pacientes = controlador.listarPacientes(filtro, estadoFiltro);
                foreach (PacienteItemDto paciente in pacientes)
                {
                    int rowIndex = dgvPacientes.Rows.Add(
                        paciente.IdPaciente,
                        paciente.NombreCompleto,
                        string.IsNullOrWhiteSpace(paciente.Cedula) ? "-" : paciente.Cedula,
                        string.IsNullOrWhiteSpace(paciente.Telefono) ? "-" : paciente.Telefono,
                        paciente.Comunidad,
                        paciente.Municipio,
                        paciente.Departamento,
                        paciente.Estado ? "● Activo" : "○ Inactivo");

                    DataGridViewRow fila = dgvPacientes.Rows[rowIndex];
                    fila.Cells["colVer"].Value = "◉ Ver";
                    fila.Cells["colEditar"].Value = "✎ Editar";
                    fila.Cells["colBaja"].Value = paciente.Estado ? "Dar de baja" : "Reactivar";
                }

                string sufijoEstado = estadoFiltro == "Todos" ? "registrado(s)" : (estadoFiltro == "Inactivos" ? "inactivo(s)" : "activo(s)");
                lblCantidad.Text = string.Format("● {0} paciente(s) {1}", pacientes.Count, sufijoEstado);
                lblCantidad.ForeColor = estadoFiltro == "Inactivos" ? Tema.Error : Tema.VerdeOscuro;
            }
            catch (Exception ex)
            {
                lblCantidad.Text = "No se pudo cargar el listado";
                lblCantidad.ForeColor = Tema.Error;
                MessageBox.Show("No se pudo cargar el listado de pacientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearPaciente formulario = new crearPaciente())
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                {
                    CargarPacientes();
                }
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["IdPaciente"].Value);
            string columna = dgvPacientes.Columns[e.ColumnIndex].Name;

            if (columna == "colVer")
            {
                using (fichaPaciente ficha = new fichaPaciente(idPaciente))
                {
                    ficha.ShowDialog(this);
                }
            }
            else if (columna == "colEditar")
            {
                using (crearPaciente formulario = new crearPaciente(idPaciente, true))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarPacientes();
                    }
                }
            }
            else if (columna == "colBaja")
            {
                if (!controlador.EsAdministrativo())
                {
                    MessageBox.Show("Solo los usuarios con rol Administrativo pueden dar de baja o reactivar pacientes.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre = dgvPacientes.Rows[e.RowIndex].Cells["Nombre"].Value != null
                    ? dgvPacientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString()
                    : "este paciente";

                string accion = dgvPacientes.Rows[e.RowIndex].Cells["colBaja"].Value != null
                    ? dgvPacientes.Rows[e.RowIndex].Cells["colBaja"].Value.ToString()
                    : "Dar de baja";

                if (accion == "Dar de baja")
                {
                    if (MessageBox.Show(
                        string.Format("¿Desea dar de baja a {0}? Su expediente e historial clínico se conservarán intactos.", nombre),
                        "Confirmar baja de paciente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            controlador.eliminarPaciente(idPaciente);
                            CargarPacientes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo dar de baja al paciente:\n\n" + ex.Message, "Error al procesar baja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else // Reactivar
                {
                    if (MessageBox.Show(
                        string.Format("¿Desea reactivar a {0} para habilitar nuevamente la programación de citas y consultas?", nombre),
                        "Confirmar reactivación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            controlador.reactivarPaciente(idPaciente);
                            CargarPacientes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo reactivar al paciente:\n\n" + ex.Message, "Error al reactivar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvPacientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columna = dgvPacientes.Columns[e.ColumnIndex].Name;

            if (columna == "Estado" && e.Value != null)
            {
                string estadoStr = e.Value.ToString();
                if (estadoStr.Contains("Activo"))
                {
                    e.CellStyle.ForeColor = Tema.VerdeOscuro;
                    e.CellStyle.Font = Tema.FuenteLabelCampo;
                }
                else
                {
                    e.CellStyle.ForeColor = Tema.TextoSecundario;
                    e.CellStyle.Font = Tema.FuenteCuerpo;
                }
            }
            else if (columna == "colVer")
            {
                e.CellStyle.ForeColor = Tema.AzulPrimario;
                e.CellStyle.BackColor = Tema.FondoSecundario;
                e.CellStyle.SelectionBackColor = Tema.AzulClaro;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Font = Tema.FuenteLabelCampo;
            }
            else if (columna == "colEditar")
            {
                e.CellStyle.ForeColor = Tema.TextoPrincipal;
                e.CellStyle.BackColor = Tema.FondoSecundario;
                e.CellStyle.SelectionBackColor = Tema.FondoSecundario;
                e.CellStyle.SelectionForeColor = Tema.TextoPrincipal;
                e.CellStyle.Font = Tema.FuenteLabelCampo;
            }
            else if (columna == "colBaja" && e.Value != null)
            {
                string accion = e.Value.ToString();
                if (accion == "Reactivar")
                {
                    e.CellStyle.ForeColor = Tema.VerdeOscuro;
                }
                else
                {
                    e.CellStyle.ForeColor = Tema.Error;
                }
                e.CellStyle.BackColor = Tema.Superficie;
                e.CellStyle.Font = Tema.FuenteLabelCampo;
            }
        }
    }
}
