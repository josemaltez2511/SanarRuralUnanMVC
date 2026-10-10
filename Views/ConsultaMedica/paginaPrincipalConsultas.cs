using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    /// <summary>
    /// Vista principal moderna para consulta, supervisión y seguimiento de consultas médicas.
    /// Incorpora tarjetas métricas, búsqueda avanzada y tabla estilizada según la identidad Sanar Rural.
    /// </summary>
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
            ConfigurarDisenoResponsivo();
        }

        // ============================================================
        // INICIALIZACIÓN
        // ============================================================
        private void paginaPrincipalConsultas_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloGrid();
            CargarFiltrosEstado();

            // Los usuarios administradores solo pueden supervisar/leer, no iniciar consultas clínicas.
            if (!idDoctorFiltro.HasValue)
            {
                btnNuevaConsulta.Visible = false;
                lblSubtitulo.Text = "Supervisión de consultas médicas (modo lectura)";
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

        private void ConfigurarDisenoResponsivo()
        {
            panelCardPrincipal.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panelCardPrincipal.Width - 1, panelCardPrincipal.Height - 1);
                }
            };

            panelIconoModulo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelIconoModulo.Width - 1, panelIconoModulo.Height - 1), 12))
                {
                    using (var brush = new SolidBrush(Color.FromArgb(226, 238, 248)))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            };

            ConfigurarBordeControl(panelBuscar);
            ConfigurarBordeControl(panelFiltroFecha);
            ConfigurarBordeControl(panelFiltroEstado);

            ConfigurarTarjetaMetrica(cardTotal, Tema.AzulPrimario);
            ConfigurarTarjetaMetrica(cardEnProceso, Tema.Advertencia);
            ConfigurarTarjetaMetrica(cardFinalizadas, Tema.VerdeOscuro);

            panelMetricas.Resize += (s, e) => OrganizarTarjetasMetricas();
            OrganizarTarjetasMetricas();
        }

        private static void ConfigurarBordeControl(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 8))
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
        }

        private static void ConfigurarTarjetaMetrica(Panel card, Color colorAcento)
        {
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 10))
                {
                    using (var brush = new SolidBrush(Tema.Superficie))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (var pen = new Pen(Tema.Borde, 1f))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                // Línea superior decorativa sutil
                using (var penTop = new Pen(colorAcento, 3f))
                {
                    e.Graphics.DrawLine(penTop, 12, 1, Math.Min(60, card.Width - 12), 1);
                }
            };
        }

        private void OrganizarTarjetasMetricas()
        {
            int anchoTotal = panelMetricas.ClientSize.Width;
            if (anchoTotal <= 0) return;

            int espacio = 16;
            int cantidad = 3;
            int anchoTarjeta = Math.Max(180, (anchoTotal - (espacio * (cantidad - 1))) / cantidad);

            cardTotal.SetBounds(0, 4, anchoTarjeta, 62);
            cardEnProceso.SetBounds(anchoTarjeta + espacio, 4, anchoTarjeta, 62);
            cardFinalizadas.SetBounds((anchoTarjeta + espacio) * 2, 4, anchoTarjeta, 62);
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
            cmbEstadoFiltro.Items.Add("En curso");
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

                var lista = controlador.listarConsultas(busqueda, fecha, estado, idDoctorFiltro) ?? new List<ConsultaItemDto>();
                dgvConsultas.DataSource = lista;

                // Actualizar métricas dinámicas
                int total = lista.Count;
                int enProceso = lista.Count(c => c.EstadoConsulta == "En curso" || c.EstadoConsulta == "EnProceso");
                int finalizadas = lista.Count(c => c.EstadoConsulta == "Finalizada");

                lblTotalNum.Text = total.ToString();
                lblEnProcesoNum.Text = enProceso.ToString();
                lblFinalizadasNum.Text = finalizadas.ToString();
                lblConteo.Text = $"Mostrando {total} consulta{(total == 1 ? "" : "s")} médica{(total == 1 ? "" : "s")} registrada{(total == 1 ? "" : "s")}";

                btnLimpiarBusqueda.Visible = !string.IsNullOrWhiteSpace(busqueda);

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
                    dgvConsultas.Columns["Paciente"].FillWeight = 140;
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
                    dgvConsultas.Columns["EstadoConsulta"].FillWeight = 90;
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
                    FillWeight = 75
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
                    FillWeight = 85
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
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                bool finalizada = (estado == "Finalizada");
                Color colorFondo = finalizada ? Color.FromArgb(235, 247, 238) : Color.FromArgb(254, 249, 237);
                Color colorTexto = finalizada ? Tema.VerdeOscuro : Tema.Advertencia;
                Color colorBorde = finalizada ? Color.FromArgb(190, 230, 202) : Color.FromArgb(248, 225, 172);
                string textoEstado = finalizada ? "✓ Finalizada" : "⏳ En Proceso";

                Rectangle badgeRect = new Rectangle(
                    e.CellBounds.X + 6,
                    e.CellBounds.Y + 9,
                    e.CellBounds.Width - 12,
                    e.CellBounds.Height - 18
                );

                using (var path = Tema.CrearRutaRedondeada(badgeRect, 10))
                {
                    using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                    {
                        e.Graphics.FillPath(brushFondo, path);
                    }

                    using (Pen penBorde = new Pen(colorBorde, 1f))
                    {
                        e.Graphics.DrawPath(penBorde, path);
                    }
                }

                using (Font fuente = Tema.FuentePequena)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        textoEstado,
                        fuente,
                        badgeRect,
                        colorTexto,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
                return;
            }

            // Columna Paciente con avatar circular de iniciales
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

            // Botón VER EXPEDIENTE
            if (nombreColumna == "colVer")
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
                    using (var brush = new SolidBrush(Tema.BotonEditarFondo))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (var pen = new Pen(Tema.BotonEditarBorde, 1f))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    "👁️ Ver",
                    Tema.FuentePequena,
                    btnRect,
                    Tema.AzulPrimario,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
                return;
            }

            // Botón CONTINUAR ATENCIÓN
            if (nombreColumna == "colContinuar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                bool enProceso = (estado == "En curso" || estado == "EnProceso");
                Rectangle btnRect = new Rectangle(
                    e.CellBounds.X + 4,
                    e.CellBounds.Y + 8,
                    e.CellBounds.Width - 8,
                    e.CellBounds.Height - 16
                );

                if (enProceso)
                {
                    using (var path = Tema.CrearRutaRedondeada(btnRect, 10))
                    {
                        using (var brush = new SolidBrush(Tema.AzulPrimario))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }

                    TextRenderer.DrawText(
                        e.Graphics,
                        "🩺 Continuar",
                        Tema.FuentePequena,
                        btnRect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }
                else
                {
                    // Si ya está finalizada, se muestra deshabilitado o tenue
                    using (var path = Tema.CrearRutaRedondeada(btnRect, 10))
                    {
                        using (var brush = new SolidBrush(Tema.FondoSecundario))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }

                    TextRenderer.DrawText(
                        e.Graphics,
                        "✓ Concluida",
                        Tema.FuentePequena,
                        btnRect,
                        Tema.TextoSecundario,
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

        private void dgvConsultas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvConsultas.Columns[e.ColumnIndex].Name;
                string estado = dgvConsultas.Rows[e.RowIndex].Cells["EstadoConsulta"]?.Value?.ToString() ?? "";

                bool esBoton = (nombreColumna == "colVer") ||
                               (nombreColumna == "colContinuar" && (estado == "En curso" || estado == "EnProceso"));

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
                if (estado != "En curso" && estado != "EnProceso")
                {
                    MessageBox.Show("Esta consulta médica ya ha sido finalizada y se encuentra en modo de sólo lectura.", "Consulta Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (atencionConsulta formAtender = new atencionConsulta(idConsulta, idDoctorFiltro))
                {
                    formAtender.ShowDialog(this);
                    CargarConsultas();
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

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
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
