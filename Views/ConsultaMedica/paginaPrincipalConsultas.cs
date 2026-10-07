using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    // Vista principal para consulta, supervisión y seguimiento de consultas médicas.
    public partial class paginaPrincipalConsultas : Form
    {
        private readonly consultasControllers controlador = new consultasControllers();
        private readonly int? idDoctorFiltro;

        // Constructor para supervisión administrativa (modo solo lectura).
        public paginaPrincipalConsultas() : this(null)
        {
        }

        // Constructor con filtro de facultativo médico autenticado.
        public paginaPrincipalConsultas(int? idDoctor)
        {
            this.idDoctorFiltro = idDoctor;
            InitializeComponent();
        }

        // ============================================================
        // INICIALIZACIÓN
        // ============================================================
        private void paginaPrincipalConsultas_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloGrid();
            CargarFiltrosEstado();

            // Los usuarios administradores solo pueden supervisar/leer, no crear nuevas consultas clínicas.
            if (!idDoctorFiltro.HasValue)
            {
                btnNuevaConsulta.Visible = false;
                lblSubtitulo.Text = "SUPERVISIÓN DE CONSULTAS MÉDICAS (MODO LECTURA)";
            }

            CargarConsultas();

            // Refresca la tabla automáticamente cuando la ventana vuelve a mostrarse en el contenedor.
            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible)
                {
                    CargarConsultas();
                }
            };
        }

        private void ConfigurarEstiloGrid()
        {
            Tema.ConfigurarTabla(dgvConsultas);
            dgvConsultas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvConsultas.AllowUserToResizeRows = false;
            dgvConsultas.AccessibleName = "Listado de consultas médicas";
            dgvConsultas.AccessibleDescription = "Use las flechas para explorar las consultas registradas.";
        }

        private void CargarFiltrosEstado()
        {
            cmbEstadoFiltro.Items.Clear();
            cmbEstadoFiltro.Items.Add("Todos");
            cmbEstadoFiltro.Items.Add("EnProceso");
            cmbEstadoFiltro.Items.Add("Finalizada");
            cmbEstadoFiltro.SelectedIndex = 0;
        }

        // ============================================================
        // CARGA DE DATOS Y COLUMNAS
        // ============================================================
        public void CargarConsultas()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                DateTime? fecha = chkTodasFechas.Checked ? (DateTime?)null : dtpFechaFiltro.Value.Date;
                string estado = cmbEstadoFiltro.SelectedItem?.ToString() ?? "Todos";

                dgvConsultas.DataSource = controlador.listarConsultas(busqueda, fecha, estado, idDoctorFiltro);

                // Configuración de encabezados y visibilidad de columnas
                if (dgvConsultas.Columns["IdConsulta"] != null)
                {
                    dgvConsultas.Columns["IdConsulta"].HeaderText = "ID";
                    dgvConsultas.Columns["IdConsulta"].FillWeight = 35;
                }
                if (dgvConsultas.Columns["FechaHoraInicioTexto"] != null)
                {
                    dgvConsultas.Columns["FechaHoraInicioTexto"].HeaderText = "Inicio";
                    dgvConsultas.Columns["FechaHoraInicioTexto"].FillWeight = 95;
                }
                if (dgvConsultas.Columns["FechaHoraFinTexto"] != null)
                {
                    dgvConsultas.Columns["FechaHoraFinTexto"].HeaderText = "Cierre";
                    dgvConsultas.Columns["FechaHoraFinTexto"].FillWeight = 95;
                }
                if (dgvConsultas.Columns["Paciente"] != null)
                {
                    dgvConsultas.Columns["Paciente"].HeaderText = "Paciente";
                    dgvConsultas.Columns["Paciente"].FillWeight = 135;
                }
                if (dgvConsultas.Columns["Cedula"] != null)
                {
                    dgvConsultas.Columns["Cedula"].HeaderText = "Cédula";
                    dgvConsultas.Columns["Cedula"].FillWeight = 85;
                }
                if (dgvConsultas.Columns["Doctor"] != null)
                {
                    dgvConsultas.Columns["Doctor"].HeaderText = "Médico";
                    dgvConsultas.Columns["Doctor"].FillWeight = 120;
                }
                if (dgvConsultas.Columns["Especialidad"] != null)
                {
                    dgvConsultas.Columns["Especialidad"].HeaderText = "Especialidad";
                    dgvConsultas.Columns["Especialidad"].FillWeight = 95;
                }
                if (dgvConsultas.Columns["Hospital"] != null)
                {
                    dgvConsultas.Columns["Hospital"].HeaderText = "Sede";
                    dgvConsultas.Columns["Hospital"].FillWeight = 95;
                }
                if (dgvConsultas.Columns["DiagnosticoPrincipal"] != null)
                {
                    dgvConsultas.Columns["DiagnosticoPrincipal"].HeaderText = "Diagnóstico Principal";
                    dgvConsultas.Columns["DiagnosticoPrincipal"].FillWeight = 140;
                }
                if (dgvConsultas.Columns["EstadoConsulta"] != null)
                {
                    dgvConsultas.Columns["EstadoConsulta"].HeaderText = "Estado";
                    dgvConsultas.Columns["EstadoConsulta"].FillWeight = 80;
                }
                if (dgvConsultas.Columns["MotivoCita"] != null)
                {
                    dgvConsultas.Columns["MotivoCita"].HeaderText = "Motivo Cita";
                    dgvConsultas.Columns["MotivoCita"].FillWeight = 110;
                }

                // Ocultar IDs técnicos
                OcultarColumnaSiExiste("IdCita");
                OcultarColumnaSiExiste("IdPaciente");
                OcultarColumnaSiExiste("IdDoctor");
                OcultarColumnaSiExiste("FechaHoraInicio");

                AgregarColumnasAcciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las consultas médicas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnaSiExiste(string nombreColumna)
        {
            if (dgvConsultas.Columns[nombreColumna] != null)
            {
                dgvConsultas.Columns[nombreColumna].Visible = false;
            }
        }

        private void AgregarColumnasAcciones()
        {
            if (!dgvConsultas.Columns.Contains("colVer"))
            {
                DataGridViewButtonColumn colVer = new DataGridViewButtonColumn
                {
                    Name = "colVer",
                    HeaderText = "Expediente",
                    Text = "👁️ Ver",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 65
                };
                dgvConsultas.Columns.Add(colVer);
            }

            if (idDoctorFiltro.HasValue && !dgvConsultas.Columns.Contains("colContinuar"))
            {
                DataGridViewButtonColumn colContinuar = new DataGridViewButtonColumn
                {
                    Name = "colContinuar",
                    HeaderText = "Atención",
                    Text = "🩺 Continuar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 80
                };
                dgvConsultas.Columns.Add(colContinuar);
            }

            if (dgvConsultas.Columns.Contains("colVer"))
            {
                dgvConsultas.Columns["colVer"].DisplayIndex = dgvConsultas.Columns.Count - (idDoctorFiltro.HasValue ? 2 : 1);
            }
            if (dgvConsultas.Columns.Contains("colContinuar"))
            {
                dgvConsultas.Columns["colContinuar"].DisplayIndex = dgvConsultas.Columns.Count - 1;
            }
        }

        // ============================================================
        // DIBUJADO PERSONALIZADO DE BOTONES Y ESTADOS
        // ============================================================
        private void dgvConsultas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvConsultas.Columns[e.ColumnIndex].Name;
            string estado = dgvConsultas.Rows[e.RowIndex].Cells["EstadoConsulta"]?.Value?.ToString() ?? "";

            // Indicador temático para el estado
            if (nombreColumna == "EstadoConsulta")
            {
                e.PaintBackground(e.CellBounds, true);

                Color colorFondo = (estado == "Finalizada") ? Tema.FondoSecundario : Tema.FondoSecundario;
                Color colorTexto = (estado == "Finalizada") ? Tema.VerdeOscuro : Tema.Advertencia;

                Rectangle badgeRect = new Rectangle(
                    e.CellBounds.X + 6,
                    e.CellBounds.Y + 6,
                    e.CellBounds.Width - 12,
                    e.CellBounds.Height - 12
                );

                using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                {
                    e.Graphics.FillRectangle(brushFondo, badgeRect);
                }

                using (Pen penBorde = new Pen(colorTexto, 1f))
                {
                    e.Graphics.DrawRectangle(penBorde, badgeRect);
                }

                using (Font fuente = Tema.FuenteBoton)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        estado == "EnProceso" ? "En Proceso" : estado,
                        fuente,
                        badgeRect,
                        colorTexto,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
            }
            else if (nombreColumna == "colVer")
            {
                e.PaintBackground(e.CellBounds, true);

                Rectangle btnRect = new Rectangle(
                    e.CellBounds.X + 4,
                    e.CellBounds.Y + 4,
                    e.CellBounds.Width - 8,
                    e.CellBounds.Height - 8
                );

                using (SolidBrush brush = new SolidBrush(Tema.AzulPrimario))
                {
                    e.Graphics.FillRectangle(brush, btnRect);
                }

                using (Font fuenteBoton = Tema.FuenteBoton)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        "👁️ Ver",
                        fuenteBoton,
                        btnRect,
                        Tema.Superficie,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
            }
            else if (nombreColumna == "colContinuar")
            {
                e.PaintBackground(e.CellBounds, true);

                bool esEnProceso = (estado == "EnProceso");
                if (esEnProceso)
                {
                    Rectangle btnRect = new Rectangle(
                        e.CellBounds.X + 4,
                        e.CellBounds.Y + 4,
                        e.CellBounds.Width - 8,
                        e.CellBounds.Height - 8
                    );

                    using (SolidBrush brush = new SolidBrush(Tema.VerdeOscuro))
                    {
                        e.Graphics.FillRectangle(brush, btnRect);
                    }

                    using (Font fuenteBoton = Tema.FuenteBoton)
                    {
                        TextRenderer.DrawText(
                            e.Graphics,
                            "🩺 Continuar",
                            fuenteBoton,
                            btnRect,
                            Tema.Superficie,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                        );
                    }
                }

                e.Handled = true;
            }
        }

        private void dgvConsultas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvConsultas.Columns[e.ColumnIndex].Name;
                string estado = dgvConsultas.Rows[e.RowIndex].Cells["EstadoConsulta"]?.Value?.ToString() ?? "";

                bool esBoton = (nombreColumna == "colVer") ||
                               (nombreColumna == "colContinuar" && estado == "EnProceso");

                dgvConsultas.Cursor = esBoton ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                dgvConsultas.Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // ACCIONES DE BOTONES
        // ============================================================
        private void dgvConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvConsultas.Columns[e.ColumnIndex].Name;
            int idConsulta = Convert.ToInt32(dgvConsultas.Rows[e.RowIndex].Cells["IdConsulta"].Value);
            string estado = dgvConsultas.Rows[e.RowIndex].Cells["EstadoConsulta"]?.Value?.ToString() ?? "";

            // Acción: VER EXPEDIENTE
            if (nombreColumna == "colVer")
            {
                using (atencionConsulta formVer = new atencionConsulta(idConsulta, idDoctorFiltro))
                {
                    formVer.ShowDialog(this);
                    CargarConsultas();
                }
            }
            // Acción: CONTINUAR ATENCIÓN EN PROCESO
            else if (nombreColumna == "colContinuar")
            {
                if (estado != "EnProceso")
                {
                    MessageBox.Show("Esta consulta médica ya ha sido finalizada y se encuentra en modo de sólo lectura.", "Consulta Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (atencionConsulta formAtender = new atencionConsulta(idConsulta, idDoctorFiltro))
                {
                    if (formAtender.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarConsultas();
                    }
                    else
                    {
                        CargarConsultas();
                    }
                }
            }
        }

        // ============================================================
        // FILTROS Y EVENTOS
        // ============================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarConsultas();
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (!chkTodasFechas.Checked)
            {
                CargarConsultas();
            }
        }

        private void chkTodasFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaFiltro.Enabled = !chkTodasFechas.Checked;
            CargarConsultas();
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarConsultas();
        }

        // ============================================================
        // INICIAR NUEVA CONSULTA (A TRAVÉS DE SELECCIÓN DE CITA)
        // ============================================================
        private void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            using (seleccionarCitaConsulta formSeleccionar = new seleccionarCitaConsulta(idDoctorFiltro))
            {
                if (formSeleccionar.ShowDialog(this) == DialogResult.OK && formSeleccionar.IdConsultaIniciada.HasValue)
                {
                    using (atencionConsulta formAtencion = new atencionConsulta(formSeleccionar.IdConsultaIniciada.Value, idDoctorFiltro))
                    {
                        formAtencion.ShowDialog(this);
                        CargarConsultas();
                    }
                }
            }
        }
    }
}
