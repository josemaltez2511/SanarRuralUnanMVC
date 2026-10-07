using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    // Ventana modal para que el facultativo seleccione una cita médica programada e inicie la atención clínica.
    public partial class seleccionarCitaConsulta : Form
    {
        private readonly consultasControllers controlador = new consultasControllers();
        private readonly int? idDoctorAutenticado;

        public int? IdConsultaIniciada { get; private set; }

        public seleccionarCitaConsulta(int? idDoctor)
        {
            this.idDoctorAutenticado = idDoctor;
            InitializeComponent();
        }

        private void seleccionarCitaConsulta_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloGrid();
            CargarCitasElegibles();
        }

        private void ConfigurarEstiloGrid()
        {
            Tema.ConfigurarTabla(dgvCitas);
            dgvCitas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCitas.AllowUserToResizeRows = false;
        }

        private void CargarCitasElegibles()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                var citas = controlador.listarCitasElegiblesParaConsulta(busqueda, idDoctorAutenticado);

                dgvCitas.DataSource = citas;

                if (dgvCitas.Columns["IdCita"] != null)
                {
                    dgvCitas.Columns["IdCita"].HeaderText = "ID";
                    dgvCitas.Columns["IdCita"].FillWeight = 35;
                }
                if (dgvCitas.Columns["FechaHoraTexto"] != null)
                {
                    dgvCitas.Columns["FechaHoraTexto"].HeaderText = "Fecha / Hora";
                    dgvCitas.Columns["FechaHoraTexto"].FillWeight = 95;
                }
                if (dgvCitas.Columns["Paciente"] != null)
                {
                    dgvCitas.Columns["Paciente"].HeaderText = "Paciente";
                    dgvCitas.Columns["Paciente"].FillWeight = 130;
                }
                if (dgvCitas.Columns["Cedula"] != null)
                {
                    dgvCitas.Columns["Cedula"].HeaderText = "Cédula";
                    dgvCitas.Columns["Cedula"].FillWeight = 85;
                }
                if (dgvCitas.Columns["Doctor"] != null)
                {
                    dgvCitas.Columns["Doctor"].HeaderText = "Médico";
                    dgvCitas.Columns["Doctor"].FillWeight = 110;
                }
                if (dgvCitas.Columns["Hospital"] != null)
                {
                    dgvCitas.Columns["Hospital"].HeaderText = "Sede";
                    dgvCitas.Columns["Hospital"].FillWeight = 90;
                }
                if (dgvCitas.Columns["Motivo"] != null)
                {
                    dgvCitas.Columns["Motivo"].HeaderText = "Motivo de Cita";
                    dgvCitas.Columns["Motivo"].FillWeight = 120;
                }

                // Ocultar IDs técnicos
                OcultarColumnaSiExiste("IdPaciente");
                OcultarColumnaSiExiste("IdDoctor");
                OcultarColumnaSiExiste("Especialidad");
                OcultarColumnaSiExiste("FechaHoraProgramada");
                OcultarColumnaSiExiste("Estado");

                // Columna de acción
                if (!dgvCitas.Columns.Contains("colIniciar"))
                {
                    DataGridViewButtonColumn colIniciar = new DataGridViewButtonColumn
                    {
                        Name = "colIniciar",
                        HeaderText = "Acción",
                        Text = "🩺 Iniciar",
                        UseColumnTextForButtonValue = true,
                        FlatStyle = FlatStyle.Flat,
                        FillWeight = 80
                    };
                    dgvCitas.Columns.Add(colIniciar);
                }

                dgvCitas.Columns["colIniciar"].DisplayIndex = dgvCitas.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas elegibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnaSiExiste(string nombreColumna)
        {
            if (dgvCitas.Columns[nombreColumna] != null)
            {
                dgvCitas.Columns[nombreColumna].Visible = false;
            }
        }

        private void dgvCitas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colIniciar")
            {
                e.PaintBackground(e.CellBounds, true);

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
                        "🩺 Iniciar",
                        fuenteBoton,
                        btnRect,
                        Tema.Superficie,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
            }
        }

        private void dgvCitas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
                dgvCitas.Cursor = (nombreColumna == "colIniciar") ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                dgvCitas.Cursor = Cursors.Default;
            }
        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colIniciar")
            {
                int idCita = Convert.ToInt32(dgvCitas.Rows[e.RowIndex].Cells["IdCita"].Value);
                string paciente = dgvCitas.Rows[e.RowIndex].Cells["Paciente"]?.Value?.ToString() ?? "el paciente";

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea iniciar la atención de la consulta médica para {paciente}?",
                    "Iniciar Consulta Médica",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        // Si ya tuviera consulta creada por concurrencia la recuperamos, sino la iniciamos.
                        int idConsulta;
                        int? idExistente = controlador.obtenerIdConsultaPorCita(idCita);
                        if (idExistente.HasValue)
                        {
                            idConsulta = idExistente.Value;
                        }
                        else
                        {
                            idConsulta = controlador.iniciarConsulta(idCita, idDoctorAutenticado);
                        }

                        this.IdConsultaIniciada = idConsulta;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al iniciar consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCitasElegibles();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
