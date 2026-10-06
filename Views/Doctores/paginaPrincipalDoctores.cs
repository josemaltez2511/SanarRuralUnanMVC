using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Doctores
{
    public partial class paginaPrincipalDoctores : Form
    {
        // ============================================================
        // CONTROLADOR
        // ============================================================
        private doctoresControllers controlador = new doctoresControllers();

        public paginaPrincipalDoctores()
        {
            InitializeComponent();
        }

        // ============================================================
        // CENTRAR TARJETA PRINCIPAL
        // ============================================================
        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;

            panelCard.Location = new Point(
                Math.Max(10, x),
                Math.Max(10, y)
            );
        }

        // ============================================================
        // LOAD
        // ============================================================
        private void paginaPrincipalDoctores_Load(object sender, EventArgs e)
        {
            CentrarPanelCard();
            ConfigurarEstiloGrid();
            CargarDoctores();

            // Refresca la tabla automáticamente cada vez que esta ventana vuelve a mostrarse
            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible)
                {
                    CargarDoctores(txtBuscar.Text.Trim());
                }
            };
        }

        private void paginaPrincipalDoctores_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // ============================================================
        // CONFIGURACIÓN VISUAL DEL DATAGRIDVIEW
        // ============================================================
        private void ConfigurarEstiloGrid()
        {
            dgvDoctores.BackgroundColor = Color.White;
            dgvDoctores.BorderStyle = BorderStyle.None;
            dgvDoctores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDoctores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDoctores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctores.MultiSelect = false;
            dgvDoctores.ReadOnly = true;
            dgvDoctores.AllowUserToAddRows = false;
            dgvDoctores.AllowUserToDeleteRows = false;
            dgvDoctores.AllowUserToResizeRows = false;
            dgvDoctores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctores.RowHeadersVisible = false;

            // Encabezado
            dgvDoctores.EnableHeadersVisualStyles = false;
            dgvDoctores.ColumnHeadersDefaultCellStyle.BackColor = Tema.AzulPrimario;
            dgvDoctores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoctores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDoctores.ColumnHeadersHeight = 36;

            // Filas
            dgvDoctores.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvDoctores.DefaultCellStyle.ForeColor = Tema.TextoPrincipal;
            dgvDoctores.DefaultCellStyle.SelectionBackColor = Tema.FondoTarjetaSeleccionada;
            dgvDoctores.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDoctores.RowTemplate.Height = 36;
            dgvDoctores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        }

        // ============================================================
        // CARGAR DATOS
        // ============================================================
        public void CargarDoctores(string filtro = "")
        {
            try
            {
                dgvDoctores.DataSource = controlador.listarDoctores(filtro);

                if (dgvDoctores.Columns["IdDoctor"] != null)
                {
                    dgvDoctores.Columns["IdDoctor"].HeaderText = "ID";
                    dgvDoctores.Columns["IdDoctor"].FillWeight = 35;
                }
                if (dgvDoctores.Columns["Nombre"] != null)
                {
                    dgvDoctores.Columns["Nombre"].HeaderText = "Médico";
                    dgvDoctores.Columns["Nombre"].FillWeight = 140;
                }
                if (dgvDoctores.Columns["Especialidades"] != null)
                {
                    dgvDoctores.Columns["Especialidades"].HeaderText = "Especialidades";
                    dgvDoctores.Columns["Especialidades"].FillWeight = 125;
                }
                if (dgvDoctores.Columns["Licencia"] != null)
                {
                    dgvDoctores.Columns["Licencia"].FillWeight = 85;
                }
                if (dgvDoctores.Columns["Hospital"] != null)
                {
                    dgvDoctores.Columns["Hospital"].FillWeight = 130;
                }
                if (dgvDoctores.Columns["Estado"] != null)
                {
                    dgvDoctores.Columns["Estado"].FillWeight = 55;
                }

                AgregarColumnasBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // AGREGAR BOTONES DENTRO DE CADA FILA
        // ============================================================
        private void AgregarColumnasBotones()
        {
            if (!dgvDoctores.Columns.Contains("colEditar"))
            {
                DataGridViewButtonColumn colEditar = new DataGridViewButtonColumn();
                colEditar.Name = "colEditar";
                colEditar.HeaderText = "Editar";
                colEditar.Text = "✏️ Editar";
                colEditar.UseColumnTextForButtonValue = true;
                colEditar.FlatStyle = FlatStyle.Flat;
                colEditar.FillWeight = 65;
                dgvDoctores.Columns.Add(colEditar);
            }

            if (!dgvDoctores.Columns.Contains("colBaja"))
            {
                DataGridViewButtonColumn colBaja = new DataGridViewButtonColumn();
                colBaja.Name = "colBaja";
                colBaja.HeaderText = "Dar de baja";
                colBaja.Text = "🚫 Dar de baja";
                colBaja.UseColumnTextForButtonValue = true;
                colBaja.FlatStyle = FlatStyle.Flat;
                colBaja.FillWeight = 85;
                dgvDoctores.Columns.Add(colBaja);
            }

            dgvDoctores.Columns["colEditar"].DisplayIndex = dgvDoctores.Columns.Count - 2;
            dgvDoctores.Columns["colBaja"].DisplayIndex = dgvDoctores.Columns.Count - 1;
        }

        // ============================================================
        // DIBUJADO PERSONALIZADO DE LOS BOTONES EN LA FILA
        // ============================================================
        private void dgvDoctores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDoctores.Columns[e.ColumnIndex].Name == "colEditar" || dgvDoctores.Columns[e.ColumnIndex].Name == "colBaja")
            {
                e.PaintBackground(e.CellBounds, true);

                bool esEditar = dgvDoctores.Columns[e.ColumnIndex].Name == "colEditar";
                Color colorFondo = esEditar ? Tema.AzulPrimario : Tema.ColorError;
                string textoBoton = esEditar ? "✏️ Editar" : "🚫 Dar de baja";

                Rectangle btnRect = new Rectangle(
                    e.CellBounds.X + 4,
                    e.CellBounds.Y + 4,
                    e.CellBounds.Width - 8,
                    e.CellBounds.Height - 8
                );

                using (SolidBrush brush = new SolidBrush(colorFondo))
                {
                    e.Graphics.FillRectangle(brush, btnRect);
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    textoBoton,
                    new Font("Segoe UI", 9F, FontStyle.Bold),
                    btnRect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

        // ============================================================
        // CAMBIAR CURSOR AL PASAR SOBRE LOS BOTONES
        // ============================================================
        private void dgvDoctores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && (dgvDoctores.Columns[e.ColumnIndex].Name == "colEditar" || dgvDoctores.Columns[e.ColumnIndex].Name == "colBaja"))
            {
                dgvDoctores.Cursor = Cursors.Hand;
            }
            else
            {
                dgvDoctores.Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // CLIC EN LOS BOTONES DE CADA FILA
        // ============================================================
        private void dgvDoctores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Acción: EDITAR
            if (dgvDoctores.Columns[e.ColumnIndex].Name == "colEditar")
            {
                int idDoctor = Convert.ToInt32(dgvDoctores.Rows[e.RowIndex].Cells["IdDoctor"].Value);
                crearDoctor formEditar = new crearDoctor(idDoctor, true);
                formEditar.Show();
                this.Hide();
            }
            // Acción: DAR DE BAJA
            else if (dgvDoctores.Columns[e.ColumnIndex].Name == "colBaja")
            {
                int idDoctor = Convert.ToInt32(dgvDoctores.Rows[e.RowIndex].Cells["IdDoctor"].Value);
                string nombreDoctor = dgvDoctores.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString() ?? "este doctor";

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea dar de baja al doctor(a) {nombreDoctor}?",
                    "Confirmar Inactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        controlador.eliminarDoctor(idDoctor);
                        MessageBox.Show("El doctor ha sido dado de baja correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDoctores(txtBuscar.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al dar de baja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================================
        // BÚSQUEDA EN TIEMPO REAL
        // ============================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarDoctores(txtBuscar.Text.Trim());
        }

        // ============================================================
        // BOTÓN: REGISTRAR NUEVO DOCTOR
        // ============================================================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea crear una cuenta de usuario para este doctor?",
                "Registro de doctor",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                crearUsuario formUsuario = new crearUsuario(true);
                formUsuario.Show();
                this.Hide();
            }
            else if (respuesta == DialogResult.No)
            {
                crearDoctor formDoctor = new crearDoctor();
                formDoctor.Show();
                this.Hide();
            }
        }

        // ============================================================
        // VOLVER AL MENÚ PRINCIPAL
        // ============================================================
        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menuPrincipalMedicos menu = new menuPrincipalMedicos();
            menu.Show();
            this.Close();
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
