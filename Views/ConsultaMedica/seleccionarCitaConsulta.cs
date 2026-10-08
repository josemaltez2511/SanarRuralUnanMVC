using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    // Ventana modal moderna para que el facultativo seleccione una cita médica programada e inicie la atención clínica.
    public partial class seleccionarCitaConsulta : Form
    {
        private readonly consultasControllers controlador = new consultasControllers();
        private readonly int? idDoctorAutenticado;

        public int? IdConsultaIniciada { get; private set; }

        public seleccionarCitaConsulta(int? idDoctor)
        {
            this.idDoctorAutenticado = idDoctor;
            InitializeComponent();
            ConfigurarDiseno();
        }

        private void ConfigurarDiseno()
        {
            panelCard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panelCard.Width - 1, panelCard.Height - 1);
                }
            };

            panelIconoModulo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelIconoModulo.Width - 1, panelIconoModulo.Height - 1), 10))
                {
                    using (var brush = new SolidBrush(Color.FromArgb(226, 238, 248)))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            };

            panelBuscar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelBuscar.Width - 1, panelBuscar.Height - 1), 8))
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
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

                btnLimpiarBusqueda.Visible = !string.IsNullOrWhiteSpace(busqueda);
                int cantidad = citas != null ? citas.Count : 0;
                lblConteo.Text = $"Mostrando {cantidad} cita{(cantidad == 1 ? "" : "s")} disponible{(cantidad == 1 ? "" : "s")} para consulta";

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
                    dgvCitas.Columns["Paciente"].FillWeight = 140;
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

            // Columna Paciente con avatar circular
            if (nombreColumna == "Paciente")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string nombrePaciente = e.Value?.ToString() ?? "";
                string iniciales = ObtenerIniciales(nombrePaciente);

                int tamAvatar = 28;
                Rectangle avatarRect = new Rectangle(
                    e.CellBounds.X + 8,
                    e.CellBounds.Y + (e.CellBounds.Height - tamAvatar) / 2,
                    tamAvatar,
                    tamAvatar
                );

                using (var brushAvatar = new SolidBrush(Color.FromArgb(226, 240, 230)))
                {
                    e.Graphics.FillEllipse(brushAvatar, avatarRect);
                }
                using (var penAvatar = new Pen(Color.FromArgb(180, 218, 190), 1f))
                {
                    e.Graphics.DrawEllipse(penAvatar, avatarRect);
                }

                using (var fontAvatar = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                using (var brushTexto = new SolidBrush(Tema.VerdeOscuro))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(iniciales, fontAvatar, brushTexto, avatarRect, sf);
                }

                Rectangle textRect = new Rectangle(
                    avatarRect.Right + 8,
                    e.CellBounds.Y,
                    e.CellBounds.Width - tamAvatar - 20,
                    e.CellBounds.Height
                );

                TextRenderer.DrawText(
                    e.Graphics,
                    nombrePaciente,
                    Tema.FuenteLabelCampo,
                    textRect,
                    Tema.TextoPrincipal,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                );

                e.Handled = true;
                return;
            }

            // Botón Iniciar Consulta
            if (nombreColumna == "colIniciar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle btnRect = new Rectangle(
                    e.CellBounds.X + 4,
                    e.CellBounds.Y + 8,
                    e.CellBounds.Width - 8,
                    e.CellBounds.Height - 16
                );

                using (var path = Tema.CrearRutaRedondeada(btnRect, 10))
                {
                    using (SolidBrush brush = new SolidBrush(Tema.AzulPrimario))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                using (Font fuenteBoton = Tema.FuentePequena)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        "🩺 Iniciar",
                        fuenteBoton,
                        btnRect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
            }
        }

        private static string ObtenerIniciales(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "PA";
            string[] partes = texto.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return texto.Length >= 2 ? texto.Substring(0, 2).ToUpper() : texto.ToUpper();
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

                var confirmar = MessageBox.Show(
                    "¿Desea iniciar la atención de esta cita médica ahora?",
                    "Confirmar Atención",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    try
                    {
                        int idNuevaConsulta = controlador.iniciarConsulta(idCita, idDoctorAutenticado);
                        this.IdConsultaIniciada = idNuevaConsulta;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al iniciar la consulta médica: " + ex.Message, "Error Clínico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCitasElegibles();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
