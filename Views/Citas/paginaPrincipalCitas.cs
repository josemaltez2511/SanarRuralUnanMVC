using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Citas
{
    // Vista principal para consulta, filtrado y ciclo de vida de citas médicas.
    // Presenta métricas resumidas, búsqueda ágil, badges de estado y acciones contextuales.
    public partial class paginaPrincipalCitas : Form
    {
        private readonly citasControllers controlador = new citasControllers();
        private readonly int? idDoctorFiltro;

        // Constructor para modo administrativo (visualiza y gestiona todas las citas).
        public paginaPrincipalCitas() : this(null)
        {
        }

        // Constructor con filtro opcional de doctor (para cuando inicia sesión un médico).
        public paginaPrincipalCitas(int? idDoctor)
        {
            this.idDoctorFiltro = idDoctor;
            InitializeComponent();
        }

        // ============================================================
        // INICIALIZACIÓN
        // ============================================================
        private void paginaPrincipalCitas_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisuales();
            ConfigurarEstiloGrid();
            CargarFiltrosEstado();
            AjustarLayout();
            CargarCitas();

            // Refresca la tabla automáticamente cuando la ventana vuelve a mostrarse en el contenedor.
            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible)
                {
                    CargarCitas();
                }
            };
        }

        private void paginaPrincipalCitas_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        private void ConfigurarEstilosVisuales()
        {
            panelCardPrincipal.Paint += (s, ev) =>
            {
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    ev.Graphics.DrawRectangle(pen, 0, 0, panelCardPrincipal.Width - 1, panelCardPrincipal.Height - 1);
                }
            };

            panelBuscar.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelBuscar.Width - 1, panelBuscar.Height - 1), Color.White, Tema.Borde, 6);
            };

            panelFiltroFecha.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelFiltroFecha.Width - 1, panelFiltroFecha.Height - 1), Color.White, Tema.Borde, 6);
            };

            panelFiltroEstado.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelFiltroEstado.Width - 1, panelFiltroEstado.Height - 1), Color.White, Tema.Borde, 6);
            };

            cardTotal.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardTotal.Width - 1, cardTotal.Height - 1), cardTotal.BackColor, Tema.Borde, 8);
            };

            cardAtendidas.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardAtendidas.Width - 1, cardAtendidas.Height - 1), cardAtendidas.BackColor, Tema.Borde, 8);
            };

            cardPendientes.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardPendientes.Width - 1, cardPendientes.Height - 1), cardPendientes.BackColor, Tema.Borde, 8);
            };

            panelIconoModulo.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(226, 238, 248)))
                {
                    ev.Graphics.FillEllipse(brush, 1, 1, panelIconoModulo.Width - 3, panelIconoModulo.Height - 3);
                }
            };

            lblIconoTotal.Paint += DibujarFondoCircularIcono;
            lblIconoAtendidas.Paint += DibujarFondoCircularIcono;
            lblIconoPendientes.Paint += DibujarFondoCircularIcono;
        }

        private static void DibujarFondoCircularIcono(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(lbl.BackColor))
            {
                e.Graphics.FillEllipse(brush, 1, 1, lbl.Width - 3, lbl.Height - 3);
            }
        }

        private void ConfigurarEstiloGrid()
        {
            Tema.ConfigurarTabla(dgvCitas);
            dgvCitas.RowTemplate.Height = 46;
            dgvCitas.ColumnHeadersHeight = 42;
            dgvCitas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCitas.AllowUserToResizeRows = false;
            dgvCitas.AccessibleName = "Listado de citas médicas";
            dgvCitas.AccessibleDescription = "Use las flechas para recorrer las citas programadas y acceder a sus acciones.";
        }

        private void CargarFiltrosEstado()
        {
            cmbEstadoFiltro.Items.Clear();
            cmbEstadoFiltro.Items.Add("Todos");
            cmbEstadoFiltro.Items.Add("Pendiente");
            cmbEstadoFiltro.Items.Add("Confirmada");
            cmbEstadoFiltro.Items.Add("Atendida");
            cmbEstadoFiltro.Items.Add("Cancelada");
            cmbEstadoFiltro.Items.Add("NoAsistio");
            cmbEstadoFiltro.SelectedIndex = 0;
        }

        // ============================================================
        // CARGA DE DATOS Y COLUMNAS
        // ============================================================
        public void CargarCitas()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                DateTime? fecha = chkTodasFechas.Checked ? (DateTime?)null : dtpFechaFiltro.Value.Date;
                string estado = cmbEstadoFiltro.SelectedItem?.ToString() ?? "Todos";

                dgvCitas.DataSource = controlador.listarCitas(busqueda, fecha, estado, idDoctorFiltro);

                // Configuración de encabezados y visibilidad de columnas de datos.
                if (dgvCitas.Columns["IdCita"] != null)
                {
                    dgvCitas.Columns["IdCita"].HeaderText = "ID";
                    dgvCitas.Columns["IdCita"].FillWeight = 35;
                }
                if (dgvCitas.Columns["FechaHoraTexto"] != null)
                {
                    dgvCitas.Columns["FechaHoraTexto"].HeaderText = "Fecha / Hora";
                    dgvCitas.Columns["FechaHoraTexto"].FillWeight = 110;
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
                if (dgvCitas.Columns["Especialidad"] != null)
                {
                    dgvCitas.Columns["Especialidad"].HeaderText = "Especialidad";
                    dgvCitas.Columns["Especialidad"].FillWeight = 100;
                }
                if (dgvCitas.Columns["Doctor"] != null)
                {
                    dgvCitas.Columns["Doctor"].HeaderText = "Médico";
                    dgvCitas.Columns["Doctor"].FillWeight = 130;
                }
                if (dgvCitas.Columns["Hospital"] != null)
                {
                    dgvCitas.Columns["Hospital"].HeaderText = "Hospital / Sede";
                    dgvCitas.Columns["Hospital"].FillWeight = 110;
                }
                if (dgvCitas.Columns["Estado"] != null)
                {
                    dgvCitas.Columns["Estado"].HeaderText = "Estado";
                    dgvCitas.Columns["Estado"].FillWeight = 80;
                }
                if (dgvCitas.Columns["Motivo"] != null)
                {
                    dgvCitas.Columns["Motivo"].HeaderText = "Motivo";
                    dgvCitas.Columns["Motivo"].FillWeight = 120;
                }

                // Ocultar identificadores técnicos que no deben ser visibles al usuario.
                OcultarColumnaSiExiste("IdPaciente");
                OcultarColumnaSiExiste("IdDoctor");
                OcultarColumnaSiExiste("IdHospital");
                OcultarColumnaSiExiste("IdEspecialidad");
                OcultarColumnaSiExiste("FechaHoraProgramada");

                AgregarColumnasAcciones();
                CalcularMetricas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el listado de citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricas()
        {
            try
            {
                var todas = controlador.listarCitas("", null, "Todos", idDoctorFiltro) as System.Collections.IList;
                int total = todas != null ? todas.Count : 0;
                int atendidasConfirmadas = 0;
                int pendientes = 0;

                if (todas != null)
                {
                    foreach (object item in todas)
                    {
                        var prop = item.GetType().GetProperty("Estado");
                        if (prop != null)
                        {
                            string est = prop.GetValue(item, null)?.ToString() ?? "";
                            if (est == "Atendida" || est == "Confirmada")
                                atendidasConfirmadas++;
                            else if (est == "Pendiente")
                                pendientes++;
                        }
                    }
                }

                lblTotalNum.Text = total.ToString();
                lblAtendidasNum.Text = atendidasConfirmadas.ToString();
                lblPendientesNum.Text = pendientes.ToString();

                int mostradas = dgvCitas.Rows.Count;
                lblConteo.Text = string.Format("Mostrando {0} de {1} citas", mostradas, total);
            }
            catch
            {
                int mostradas = dgvCitas.Rows.Count;
                lblTotalNum.Text = mostradas.ToString();
                lblAtendidasNum.Text = "0";
                lblPendientesNum.Text = "0";
                lblConteo.Text = string.Format("Mostrando {0} citas", mostradas);
            }
        }

        private void OcultarColumnaSiExiste(string nombreColumna)
        {
            if (dgvCitas.Columns[nombreColumna] != null)
            {
                dgvCitas.Columns[nombreColumna].Visible = false;
            }
        }

        private void AgregarColumnasAcciones()
        {
            if (!dgvCitas.Columns.Contains("colConfirmar"))
            {
                var colConfirmar = new DataGridViewButtonColumn
                {
                    Name = "colConfirmar",
                    HeaderText = "Confirmar",
                    Text = "✓ Confirmar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 78
                };
                dgvCitas.Columns.Add(colConfirmar);
            }

            if (!dgvCitas.Columns.Contains("colEditar"))
            {
                var colEditar = new DataGridViewButtonColumn
                {
                    Name = "colEditar",
                    HeaderText = "Editar",
                    Text = "✏ Editar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 62
                };
                dgvCitas.Columns.Add(colEditar);
            }

            if (!dgvCitas.Columns.Contains("colCancelar"))
            {
                var colCancelar = new DataGridViewButtonColumn
                {
                    Name = "colCancelar",
                    HeaderText = "Cancelar",
                    Text = "✕ Cancelar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 72
                };
                dgvCitas.Columns.Add(colCancelar);
            }

            if (!dgvCitas.Columns.Contains("colNoAsistio"))
            {
                var colNoAsistio = new DataGridViewButtonColumn
                {
                    Name = "colNoAsistio",
                    HeaderText = "Asistencia",
                    Text = "⊘ Inasistencia",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 82
                };
                dgvCitas.Columns.Add(colNoAsistio);
            }

            // Ubicar las columnas de acción al final de la tabla.
            dgvCitas.Columns["colConfirmar"].DisplayIndex = dgvCitas.Columns.Count - 4;
            dgvCitas.Columns["colEditar"].DisplayIndex = dgvCitas.Columns.Count - 3;
            dgvCitas.Columns["colCancelar"].DisplayIndex = dgvCitas.Columns.Count - 2;
            dgvCitas.Columns["colNoAsistio"].DisplayIndex = dgvCitas.Columns.Count - 1;
        }

        private void AjustarLayout()
        {
            if (panelMetricas.ClientSize.Width <= 0) return;

            int anchoTotal = panelMetricas.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(180, (anchoTotal - (gap * 2)) / 3);

            cardTotal.SetBounds(0, 6, cardW, 68);
            cardAtendidas.SetBounds(cardW + gap, 6, cardW, 68);
            cardPendientes.SetBounds((cardW + gap) * 2, 6, anchoTotal - ((cardW + gap) * 2), 68);
        }

        // ============================================================
        // DIBUJADO PERSONALIZADO DE BOTONES Y ESTADOS
        // ============================================================
        private void dgvCitas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
            string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "";

            // 1. Columna Paciente con Avatar
            if (nombreColumna == "Paciente")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string paciente = e.Value?.ToString() ?? "";
                string iniciales = ObtenerIniciales(paciente);

                int diametro = 28;
                int avatarX = e.CellBounds.X + 12;
                int avatarY = e.CellBounds.Y + ((e.CellBounds.Height - diametro) / 2);

                using (var brushAvatar = new SolidBrush(Color.FromArgb(235, 248, 238)))
                {
                    e.Graphics.FillEllipse(brushAvatar, avatarX, avatarY, diametro, diametro);
                }
                using (var penAvatar = new Pen(Color.FromArgb(207, 235, 214), 1f))
                {
                    e.Graphics.DrawEllipse(penAvatar, avatarX, avatarY, diametro, diametro);
                }

                using (var fontIniciales = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                using (var brushTexto = new SolidBrush(Tema.VerdeOscuro))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(iniciales, fontIniciales, brushTexto, new Rectangle(avatarX, avatarY, diametro, diametro), sf);
                }

                int textoX = avatarX + diametro + 10;
                int textoW = e.CellBounds.Width - (diametro + 24);
                Rectangle rectTexto = new Rectangle(textoX, e.CellBounds.Y, textoW, e.CellBounds.Height);

                using (var brushNombre = new SolidBrush(Tema.TextoPrincipal))
                using (var sfTexto = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
                {
                    e.Graphics.DrawString(paciente, dgvCitas.Font, brushNombre, rectTexto, sfTexto);
                }

                e.Handled = true;
                return;
            }

            // 2. Chip badge moderno para la columna Estado.
            if (nombreColumna == "Estado")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Color colorFondo = Tema.Superficie;
                Color colorBorde = Tema.Borde;
                Color colorTexto = Tema.TextoPrincipal;

                if (estado == "Pendiente")
                {
                    colorFondo = Color.FromArgb(254, 249, 237);
                    colorBorde = Color.FromArgb(248, 225, 172);
                    colorTexto = Tema.Advertencia;
                }
                else if (estado == "Confirmada")
                {
                    colorFondo = Color.FromArgb(235, 247, 238);
                    colorBorde = Color.FromArgb(190, 230, 202);
                    colorTexto = Tema.VerdeOscuro;
                }
                else if (estado == "Atendida")
                {
                    colorFondo = Color.FromArgb(228, 239, 250);
                    colorBorde = Color.FromArgb(185, 218, 242);
                    colorTexto = Tema.AzulPrimario;
                }
                else if (estado == "Cancelada")
                {
                    colorFondo = Color.FromArgb(254, 242, 242);
                    colorBorde = Color.FromArgb(245, 198, 198);
                    colorTexto = Tema.Error;
                }
                else if (estado == "NoAsistio")
                {
                    colorFondo = Color.FromArgb(243, 245, 247);
                    colorBorde = Color.FromArgb(220, 224, 228);
                    colorTexto = Tema.TextoSecundario;
                }

                int chipW = Math.Min(80, e.CellBounds.Width - 10);
                int chipH = 24;
                int chipX = e.CellBounds.X + ((e.CellBounds.Width - chipW) / 2);
                int chipY = e.CellBounds.Y + ((e.CellBounds.Height - chipH) / 2);

                Rectangle chipRect = new Rectangle(chipX, chipY, chipW, chipH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, chipRect, colorFondo, colorBorde, 6);

                using (Font fuenteEstado = new Font(Tema.FamiliaFuente, 8.2F, FontStyle.Bold))
                using (var brushTexto = new SolidBrush(colorTexto))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    string textoAMostrar = estado == "NoAsistio" ? "No asistió" : estado;
                    e.Graphics.DrawString(textoAMostrar, fuenteEstado, brushTexto, chipRect, sf);
                }

                e.Handled = true;
                return;
            }

            // 3. Dibujado contextual de botones de acción según el estado de la cita.
            if (nombreColumna == "colConfirmar" ||
                nombreColumna == "colEditar" ||
                nombreColumna == "colCancelar" ||
                nombreColumna == "colNoAsistio")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                DateTime fechaProg = DateTime.MaxValue;
                if (dgvCitas.Rows[e.RowIndex].Cells["FechaHoraProgramada"]?.Value is DateTime dtProg)
                {
                    fechaProg = dtProg;
                }
                bool citaYaPaso = fechaProg <= DateTime.Now;

                bool habilitado = false;
                Color colorFondo = Tema.Superficie;
                Color colorBorde = Tema.Borde;
                Color colorTexto = Tema.AzulPrimario;
                string textoBoton = "";

                if (nombreColumna == "colConfirmar")
                {
                    habilitado = (estado == "Pendiente");
                    colorFondo = Color.FromArgb(235, 247, 238);
                    colorBorde = Color.FromArgb(190, 230, 202);
                    colorTexto = Tema.VerdeOscuro;
                    textoBoton = "✓ Confirmar";
                }
                else if (nombreColumna == "colEditar")
                {
                    habilitado = (estado == "Pendiente" || estado == "Confirmada");
                    colorFondo = Tema.BotonEditarFondo;
                    colorBorde = Tema.BotonEditarBorde;
                    colorTexto = Tema.AzulPrimario;
                    textoBoton = "✏ Editar";
                }
                else if (nombreColumna == "colCancelar")
                {
                    habilitado = (estado == "Pendiente" || estado == "Confirmada");
                    colorFondo = Tema.BotonPeligroFondo;
                    colorBorde = Tema.BotonPeligroBorde;
                    colorTexto = Tema.Error;
                    textoBoton = "✕ Cancelar";
                }
                else if (nombreColumna == "colNoAsistio")
                {
                    habilitado = (estado == "Pendiente" || estado == "Confirmada") && citaYaPaso;
                    colorFondo = Color.FromArgb(243, 245, 247);
                    colorBorde = Color.FromArgb(220, 224, 228);
                    colorTexto = Tema.TextoSecundario;
                    textoBoton = "⊘ No asistió";
                }

                if (habilitado)
                {
                    int btnW = Math.Min(e.CellBounds.Width - 8, nombreColumna == "colNoAsistio" ? 82 : (nombreColumna == "colConfirmar" ? 78 : (nombreColumna == "colCancelar" ? 72 : 62)));
                    int btnH = 26;
                    int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                    int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                    var btnRect = new Rectangle(btnX, btnY, btnW, btnH);
                    Tema.DibujarTarjetaRedondeada(e.Graphics, btnRect, colorFondo, colorBorde, 6);

                    using (Font fuenteBoton = new Font(Tema.FamiliaFuente, 8.2F, FontStyle.Bold))
                    using (var brushTexto = new SolidBrush(colorTexto))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(textoBoton, fuenteBoton, brushTexto, btnRect, sf);
                    }
                }

                e.Handled = true;
            }
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "CT";
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
        }

        // ============================================================
        // CAMBIAR CURSOR AL PASAR POR BOTONES DISPONIBLES
        // ============================================================
        private void dgvCitas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
                string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "";

                DateTime fechaProg = DateTime.MaxValue;
                if (dgvCitas.Rows[e.RowIndex].Cells["FechaHoraProgramada"]?.Value is DateTime dtProg)
                {
                    fechaProg = dtProg;
                }
                bool citaYaPaso = fechaProg <= DateTime.Now;

                bool esBotonAccion =
                    (nombreColumna == "colConfirmar" && estado == "Pendiente") ||
                    (nombreColumna == "colEditar" && (estado == "Pendiente" || estado == "Confirmada")) ||
                    (nombreColumna == "colCancelar" && (estado == "Pendiente" || estado == "Confirmada")) ||
                    (nombreColumna == "colNoAsistio" && (estado == "Pendiente" || estado == "Confirmada") && citaYaPaso);

                dgvCitas.Cursor = esBotonAccion ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                dgvCitas.Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // ACCIONES DE BOTONES EN CADA FILA
        // ============================================================
        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
            int idCita = Convert.ToInt32(dgvCitas.Rows[e.RowIndex].Cells["IdCita"].Value);
            string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "";
            string paciente = dgvCitas.Rows[e.RowIndex].Cells["Paciente"]?.Value?.ToString() ?? "el paciente";
            string doctor = dgvCitas.Rows[e.RowIndex].Cells["Doctor"]?.Value?.ToString() ?? "el médico";
            string fechaHora = dgvCitas.Rows[e.RowIndex].Cells["FechaHoraTexto"]?.Value?.ToString() ?? "";

            // Acción: CONFIRMAR CITA (Pendiente -> Confirmada)
            if (nombreColumna == "colConfirmar")
            {
                if (estado != "Pendiente")
                {
                    MessageBox.Show("Solo se pueden confirmar citas que se encuentren en estado 'Pendiente'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    string.Format("¿Desea confirmar la cita médica de {0} con {1} para el {2}?", paciente, doctor, fechaHora),
                    "Confirmar Cita",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        controlador.cambiarEstadoCita(idCita, "Confirmada", idDoctorFiltro);
                        MessageBox.Show("La cita ha sido confirmada exitosamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al confirmar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Acción: EDITAR / REPROGRAMAR CITA
            else if (nombreColumna == "colEditar")
            {
                if (estado == "Atendida" || estado == "Cancelada" || estado == "NoAsistio")
                {
                    MessageBox.Show(string.Format("No se puede editar ni reprogramar una cita en estado '{0}'.", estado), "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (crearCita formEditar = new crearCita(idCita, idDoctorFiltro))
                {
                    if (formEditar.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarCitas();
                    }
                }
            }
            // Acción: CANCELAR CITA
            else if (nombreColumna == "colCancelar")
            {
                if (estado != "Pendiente" && estado != "Confirmada")
                {
                    MessageBox.Show(string.Format("No se puede cancelar una cita en estado '{0}'.", estado), "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    string.Format("¿Está seguro de que desea cancelar la cita médica de {0} con {1}?", paciente, doctor),
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        controlador.cambiarEstadoCita(idCita, "Cancelada", idDoctorFiltro);
                        MessageBox.Show("La cita ha sido cancelada correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Acción: MARCAR NO ASISTIÓ
            else if (nombreColumna == "colNoAsistio")
            {
                if (estado != "Pendiente" && estado != "Confirmada")
                {
                    MessageBox.Show(string.Format("No se puede registrar inasistencia para una cita en estado '{0}'.", estado), "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaProg = DateTime.MaxValue;
                if (dgvCitas.Rows[e.RowIndex].Cells["FechaHoraProgramada"]?.Value is DateTime dtProg)
                {
                    fechaProg = dtProg;
                }

                if (fechaProg > DateTime.Now)
                {
                    MessageBox.Show("No se puede marcar la cita como no asistida hasta que haya pasado la fecha y hora programada.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    string.Format("¿Confirmar que el paciente {0} no se presentó a la cita programada?\n\nEsta acción es definitiva.", paciente),
                    "Registrar Inasistencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        controlador.cambiarEstadoCita(idCita, "NoAsistio", idDoctorFiltro);
                        MessageBox.Show("Se ha registrado la inasistencia del paciente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================================
        // EVENTOS DE BÚSQUEDA Y FILTROS
        // ============================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
            CargarCitas();
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
                CargarCitas();
            }
        }

        private void chkTodasFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaFiltro.Enabled = !chkTodasFechas.Checked;
            CargarCitas();
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        // ============================================================
        // BOTÓN: AGENDAR NUEVA CITA
        // ============================================================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearCita formCrear = new crearCita(idDoctorFiltro))
            {
                if (formCrear.ShowDialog(this) == DialogResult.OK)
                {
                    CargarCitas();
                }
            }
        }
    }
}
