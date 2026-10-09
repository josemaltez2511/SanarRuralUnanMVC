using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;
using SanarRuralUnan.Views.ConsultaMedica;

namespace SanarRuralUnan.Views.HistorialClinico
{
    /// <summary>
    /// Vista integral del Historial Clínico para visualización cronológica de atenciones finalizadas.
    /// Soporta perfiles de Doctor (trazabilidad de cualquier paciente), Paciente (su propio expediente)
    /// y Administrativo (supervisión de expedientes).
    /// </summary>
    public partial class paginaPrincipalHistorial : Form
    {
        private readonly consultasControllers controlador = new consultasControllers();
        private readonly int? idDoctorFiltro;
        private readonly int? idPacienteFiltro;

        public paginaPrincipalHistorial() : this(null, null)
        {
        }

        public paginaPrincipalHistorial(int? idDoctor, int? idPaciente = null)
        {
            this.idDoctorFiltro = idDoctor;
            this.idPacienteFiltro = idPaciente;
            InitializeComponent();
            ConfigurarDisenoResponsivo();
        }

        private void paginaPrincipalHistorial_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloGrid();
            ConfigurarTextosPorRol();
            CargarHistorial();

            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible)
                {
                    CargarHistorial();
                }
            };
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private static void AsignarPlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox == null || string.IsNullOrEmpty(placeholder)) return;
            if (textBox.IsHandleCreated)
            {
                SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
            }
            else
            {
                textBox.HandleCreated += (s, e) => SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
            }
        }

        private void ConfigurarTextosPorRol()
        {
            if (idPacienteFiltro.HasValue)
            {
                lblTitulo.Text = "Mi Historial Clínico";
                lblSubtitulo.Text = "Registro de consultas médicas concluidas, diagnósticos y tratamientos prescritos";
                lblTotalTitulo.Text = "Mis Atenciones";
                AsignarPlaceholder(txtBuscar, "Buscar por diagnóstico, médico o motivo...");
            }
            else if (idDoctorFiltro.HasValue)
            {
                lblTitulo.Text = "Historial Clínico Integral";
                lblSubtitulo.Text = "Trazabilidad asistencial de antecedentes y atenciones previas de pacientes";
                AsignarPlaceholder(txtBuscar, "Buscar por paciente, cédula, diagnóstico o doctor...");
            }
            else
            {
                lblTitulo.Text = "Auditoría de Historial Clínico";
                lblSubtitulo.Text = "Supervisión institucional de expedientes médicos y atenciones registradas";
                AsignarPlaceholder(txtBuscar, "Buscar por paciente, cédula, diagnóstico o doctor...");
            }
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
                using (var brush = new SolidBrush(Color.FromArgb(226, 238, 248)))
                {
                    e.Graphics.FillPath(brush, path);
                }
            };

            ConfigurarBordeControl(panelBuscar);
            ConfigurarBordeControl(panelFiltroFecha);

            ConfigurarTarjetaMetrica(cardTotal, Tema.AzulPrimario);
            ConfigurarTarjetaMetrica(cardUltima, Tema.VerdeOscuro);
            ConfigurarTarjetaMetrica(cardDiagnosticos, Tema.AzulOscuro);

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

                // Banda vertical decorativa
                using (var pathBarra = Tema.CrearRutaRedondeada(new Rectangle(0, 0, 6, card.Height - 1), 3))
                using (var brushBarra = new SolidBrush(colorAcento))
                {
                    e.Graphics.FillPath(brushBarra, pathBarra);
                }
            };
        }

        private void OrganizarTarjetasMetricas()
        {
            int anchoTotal = panelMetricas.ClientSize.Width;
            if (anchoTotal <= 0) return;

            int espacio = 16;
            int anchoCard = Math.Max(180, (anchoTotal - (espacio * 2)) / 3);

            cardTotal.Left = 0;
            cardTotal.Width = anchoCard;

            cardUltima.Left = cardTotal.Right + espacio;
            cardUltima.Width = anchoCard;

            cardDiagnosticos.Left = cardUltima.Right + espacio;
            cardDiagnosticos.Width = Math.Max(180, anchoTotal - cardDiagnosticos.Left);
        }

        private void ConfigurarEstiloGrid()
        {
            Tema.ConfigurarTabla(dgvHistorial);
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.Columns.Clear();

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdConsulta",
                DataPropertyName = "IdConsulta",
                Visible = false
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaHoraInicioTexto",
                HeaderText = "Fecha / Hora",
                DataPropertyName = "FechaHoraInicioTexto",
                Width = 145,
                FillWeight = 85
            });

            if (!idPacienteFiltro.HasValue)
            {
                dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Paciente",
                    HeaderText = "Paciente",
                    DataPropertyName = "Paciente",
                    Width = 200,
                    FillWeight = 120
                });

                dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Cedula",
                    HeaderText = "Cédula",
                    DataPropertyName = "Cedula",
                    Width = 140,
                    FillWeight = 80
                });
            }

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Doctor",
                HeaderText = "Médico Tratante",
                DataPropertyName = "Doctor",
                Width = 190,
                FillWeight = 110
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Especialidad",
                HeaderText = "Especialidad",
                DataPropertyName = "Especialidad",
                Width = 140,
                FillWeight = 85
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Hospital",
                HeaderText = "Sede Hospitalaria",
                DataPropertyName = "Hospital",
                Width = 160,
                FillWeight = 95
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiagnosticoPrincipal",
                HeaderText = "Diagnóstico Principal",
                DataPropertyName = "DiagnosticoPrincipal",
                Width = 220,
                FillWeight = 130
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstadoConsulta",
                HeaderText = "Estado",
                DataPropertyName = "EstadoConsulta",
                Width = 110,
                FillWeight = 65
            });

            var colVer = new DataGridViewButtonColumn
            {
                Name = "colVer",
                HeaderText = "Acción",
                Text = "👁️ Ver",
                UseColumnTextForButtonValue = false,
                Width = 90,
                FillWeight = 60
            };
            dgvHistorial.Columns.Add(colVer);
        }

        private void CargarHistorial()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                DateTime? fechaDesde = chkTodasFechas.Checked ? (DateTime?)null : dtpDesde.Value.Date;
                DateTime? fechaHasta = chkTodasFechas.Checked ? (DateTime?)null : dtpHasta.Value.Date;

                var registros = controlador.listarHistorialClinico(
                    idPacienteFiltro,
                    busqueda,
                    fechaDesde,
                    fechaHasta,
                    idDoctorFiltro);

                dgvHistorial.DataSource = registros;

                // Actualizar tarjetas métricas
                lblTotalValor.Text = registros.Count.ToString();
                if (registros.Count > 0)
                {
                    lblUltimaValor.Text = registros.First().FechaHoraInicioTexto;
                    int diagsValidos = registros.Count(r => !string.IsNullOrWhiteSpace(r.DiagnosticoPrincipal) && r.DiagnosticoPrincipal != "Sin diagnóstico");
                    lblDiagValor.Text = diagsValidos.ToString();
                }
                else
                {
                    lblUltimaValor.Text = "Sin registros";
                    lblDiagValor.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial clínico: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvHistorial_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvHistorial.Columns[e.ColumnIndex].Name;

            // Badge de Estado Finalizada
            if (nombreColumna == "EstadoConsulta")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle badgeRect = new Rectangle(
                    e.CellBounds.X + 6,
                    e.CellBounds.Y + 9,
                    e.CellBounds.Width - 12,
                    e.CellBounds.Height - 18
                );

                using (var path = Tema.CrearRutaRedondeada(badgeRect, 10))
                {
                    using (SolidBrush brushFondo = new SolidBrush(Color.FromArgb(235, 247, 238)))
                    {
                        e.Graphics.FillPath(brushFondo, path);
                    }
                    using (Pen penBorde = new Pen(Color.FromArgb(190, 230, 202), 1f))
                    {
                        e.Graphics.DrawPath(penBorde, path);
                    }
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    "✓ Finalizada",
                    Tema.FuentePequena,
                    badgeRect,
                    Tema.VerdeOscuro,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
                return;
            }

            // Paciente con avatar circular
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

        private void dgvHistorial_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvHistorial.Columns[e.ColumnIndex].Name == "colVer")
            {
                dgvHistorial.Cursor = Cursors.Hand;
            }
            else
            {
                dgvHistorial.Cursor = Cursors.Default;
            }
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvHistorial.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colVer")
            {
                int idConsulta = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells["IdConsulta"].Value);
                using (atencionConsulta formVer = new atencionConsulta(idConsulta, idDoctorFiltro, idPacienteFiltro))
                {
                    formVer.ShowDialog(this);
                    CargarHistorial();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!chkTodasFechas.Checked)
            {
                CargarHistorial();
            }
        }

        private void chkTodasFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = !chkTodasFechas.Checked;
            dtpHasta.Enabled = !chkTodasFechas.Checked;
            CargarHistorial();
        }
    }
}
