using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Doctores
{
    /// <summary>
    /// Catálogo principal de médicos de Sanar Rural.
    /// Presenta métricas resumidas, búsqueda ágil, avatares y tabla con estilo institucional moderno.
    /// </summary>
    public partial class paginaPrincipalDoctores : Form
    {
        private readonly doctoresControllers controlador = new doctoresControllers();

        public paginaPrincipalDoctores()
        {
            InitializeComponent();
        }

        private void paginaPrincipalDoctores_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisuales();
            ConfigurarGrid();
            AjustarLayout();
            CargarDoctores();

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

            cardTotal.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardTotal.Width - 1, cardTotal.Height - 1), cardTotal.BackColor, Tema.Borde, 8);
            };

            cardActivos.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardActivos.Width - 1, cardActivos.Height - 1), cardActivos.BackColor, Tema.Borde, 8);
            };

            cardEspecialidades.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardEspecialidades.Width - 1, cardEspecialidades.Height - 1), cardEspecialidades.BackColor, Tema.Borde, 8);
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
            lblIconoActivos.Paint += DibujarFondoCircularIcono;
            lblIconoEspecialidades.Paint += DibujarFondoCircularIcono;
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

        private void ConfigurarGrid()
        {
            Tema.ConfigurarTabla(dgvDoctores);
            dgvDoctores.RowTemplate.Height = 46;
            dgvDoctores.ColumnHeadersHeight = 42;
            dgvDoctores.AllowUserToResizeRows = false;
            dgvDoctores.AccessibleName = "Listado de doctores";
            dgvDoctores.AccessibleDescription = "Use las flechas para recorrer médicos y Tab para acceder a sus acciones.";
        }

        public void CargarDoctores(string filtro = "")
        {
            try
            {
                var resultado = controlador.listarDoctores(filtro);
                dgvDoctores.DataSource = resultado;

                if (dgvDoctores.Columns["IdDoctor"] != null)
                {
                    dgvDoctores.Columns["IdDoctor"].HeaderText = "ID";
                    dgvDoctores.Columns["IdDoctor"].FillWeight = 35;
                }
                if (dgvDoctores.Columns["Nombre"] != null)
                {
                    dgvDoctores.Columns["Nombre"].HeaderText = "Médico";
                    dgvDoctores.Columns["Nombre"].FillWeight = 145;
                }
                if (dgvDoctores.Columns["Especialidades"] != null)
                {
                    dgvDoctores.Columns["Especialidades"].HeaderText = "Especialidades";
                    dgvDoctores.Columns["Especialidades"].FillWeight = 125;
                }
                if (dgvDoctores.Columns["Licencia"] != null)
                {
                    dgvDoctores.Columns["Licencia"].HeaderText = "Licencia";
                    dgvDoctores.Columns["Licencia"].FillWeight = 85;
                }
                if (dgvDoctores.Columns["Hospital"] != null)
                {
                    dgvDoctores.Columns["Hospital"].HeaderText = "Hospital / Sede";
                    dgvDoctores.Columns["Hospital"].FillWeight = 130;
                }
                if (dgvDoctores.Columns["Estado"] != null)
                {
                    dgvDoctores.Columns["Estado"].HeaderText = "Estado";
                    dgvDoctores.Columns["Estado"].FillWeight = 65;
                }

                AgregarColumnasBotones();
                CalcularMetricas(filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de doctores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricas(string filtroActual)
        {
            try
            {
                var todos = controlador.listarDoctores("") as System.Collections.IList;
                int total = todos != null ? todos.Count : 0;
                int activos = total; // listarDoctores ya filtra Where(d => d.Estado)
                int conHospital = 0;

                if (todos != null)
                {
                    foreach (object item in todos)
                    {
                        var prop = item.GetType().GetProperty("Hospital");
                        if (prop != null)
                        {
                            string hosp = prop.GetValue(item, null)?.ToString() ?? "";
                            if (!string.IsNullOrWhiteSpace(hosp) && hosp != "Sin asignar")
                                conHospital++;
                        }
                    }
                }

                lblTotalNum.Text = total.ToString();
                lblActivosNum.Text = activos.ToString();
                lblEspecialidadesNum.Text = conHospital.ToString();

                int mostrados = dgvDoctores.Rows.Count;
                lblConteo.Text = string.Format("Mostrando {0} de {1} doctores", mostrados, total);
            }
            catch
            {
                // Si la reflexión de conteo falla, no bloquear el flujo de la vista
                int mostrados = dgvDoctores.Rows.Count;
                lblTotalNum.Text = mostrados.ToString();
                lblActivosNum.Text = mostrados.ToString();
                lblConteo.Text = string.Format("Mostrando {0} doctores", mostrados);
            }
        }

        private void AgregarColumnasBotones()
        {
            if (!dgvDoctores.Columns.Contains("colEditar"))
            {
                DataGridViewButtonColumn colEditar = new DataGridViewButtonColumn();
                colEditar.Name = "colEditar";
                colEditar.HeaderText = "Acciones";
                colEditar.Text = "✏ Editar";
                colEditar.UseColumnTextForButtonValue = true;
                colEditar.FlatStyle = FlatStyle.Flat;
                colEditar.FillWeight = 65;
                dgvDoctores.Columns.Add(colEditar);
            }

            if (!dgvDoctores.Columns.Contains("colBaja"))
            {
                DataGridViewButtonColumn colBaja = new DataGridViewButtonColumn();
                colBaja.Name = "colBaja";
                colBaja.HeaderText = "";
                colBaja.Text = "🚫 Dar de baja";
                colBaja.UseColumnTextForButtonValue = true;
                colBaja.FlatStyle = FlatStyle.Flat;
                colBaja.FillWeight = 85;
                dgvDoctores.Columns.Add(colBaja);
            }

            dgvDoctores.Columns["colEditar"].DisplayIndex = dgvDoctores.Columns.Count - 2;
            dgvDoctores.Columns["colBaja"].DisplayIndex = dgvDoctores.Columns.Count - 1;
        }

        private void AjustarLayout()
        {
            if (panelMetricas.ClientSize.Width <= 0) return;

            int anchoTotal = panelMetricas.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(180, (anchoTotal - (gap * 2)) / 3);

            cardTotal.SetBounds(0, 6, cardW, 68);
            cardActivos.SetBounds(cardW + gap, 6, cardW, 68);
            cardEspecialidades.SetBounds((cardW + gap) * 2, 6, anchoTotal - ((cardW + gap) * 2), 68);
        }

        private void dgvDoctores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Columna Médico con Avatar de Iniciales
            if (dgvDoctores.Columns[e.ColumnIndex].Name == "Nombre")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string nombreCompleto = e.Value?.ToString() ?? "";
                string iniciales = ObtenerIniciales(nombreCompleto);

                int diametro = 28;
                int avatarX = e.CellBounds.X + 12;
                int avatarY = e.CellBounds.Y + ((e.CellBounds.Height - diametro) / 2);

                using (var brushAvatar = new SolidBrush(Color.FromArgb(228, 239, 250)))
                {
                    e.Graphics.FillEllipse(brushAvatar, avatarX, avatarY, diametro, diametro);
                }
                using (var penAvatar = new Pen(Color.FromArgb(195, 222, 243), 1f))
                {
                    e.Graphics.DrawEllipse(penAvatar, avatarX, avatarY, diametro, diametro);
                }

                using (var fontIniciales = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                using (var brushTexto = new SolidBrush(Tema.AzulPrimario))
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
                    e.Graphics.DrawString(nombreCompleto, dgvDoctores.Font, brushNombre, rectTexto, sfTexto);
                }

                e.Handled = true;
                return;
            }

            // 2. Columna Estado con indicador visual
            if (dgvDoctores.Columns[e.ColumnIndex].Name == "Estado")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string estado = e.Value?.ToString() ?? "Activo";
                bool esActivo = estado.IndexOf("Activo", StringComparison.OrdinalIgnoreCase) >= 0;

                int bulletSize = 7;
                int bulletX = e.CellBounds.X + 12;
                int bulletY = e.CellBounds.Y + ((e.CellBounds.Height - bulletSize) / 2);

                Color colorBullet = esActivo ? Tema.VerdeOscuro : Tema.TextoSecundario;
                using (var brushBullet = new SolidBrush(colorBullet))
                {
                    e.Graphics.FillEllipse(brushBullet, bulletX, bulletY, bulletSize, bulletSize);
                }

                Rectangle rectTexto = new Rectangle(bulletX + bulletSize + 7, e.CellBounds.Y, e.CellBounds.Width - (bulletSize + 22), e.CellBounds.Height);
                using (var brushEstado = new SolidBrush(colorBullet))
                using (var sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(estado, dgvDoctores.Font, brushEstado, rectTexto, sf);
                }

                e.Handled = true;
                return;
            }

            // 3. Botón de Editar con estilo pill moderno
            if (dgvDoctores.Columns[e.ColumnIndex].Name == "colEditar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(68, e.CellBounds.Width - 12);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                var rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Tema.BotonEditarFondo, Tema.BotonEditarBorde, 6);

                using (var brushEditar = new SolidBrush(Tema.AzulPrimario))
                using (var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontBtn = new Font(Tema.FamiliaFuente, 8.8F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("✏ Editar", fontBtn, brushEditar, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }

            // 4. Botón de Dar de baja con estilo pill moderno
            if (dgvDoctores.Columns[e.ColumnIndex].Name == "colBaja")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(88, e.CellBounds.Width - 12);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                var rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Tema.BotonPeligroFondo, Tema.BotonPeligroBorde, 6);

                using (var brushBaja = new SolidBrush(Tema.Error))
                using (var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontBtn = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("🚫 Dar de baja", fontBtn, brushBaja, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "MD";
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
        }

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

        private void dgvDoctores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDoctores.Columns[e.ColumnIndex].Name == "colEditar")
            {
                int idDoctor = Convert.ToInt32(dgvDoctores.Rows[e.RowIndex].Cells["IdDoctor"].Value);
                using (crearDoctor formEditar = new crearDoctor(idDoctor, true))
                {
                    if (formEditar.ShowDialog(this) == DialogResult.OK)
                        CargarDoctores(txtBuscar.Text.Trim());
                }
            }
            else if (dgvDoctores.Columns[e.ColumnIndex].Name == "colBaja")
            {
                int idDoctor = Convert.ToInt32(dgvDoctores.Rows[e.RowIndex].Cells["IdDoctor"].Value);
                string nombreDoctor = dgvDoctores.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString() ?? "este doctor";

                DialogResult confirmacion = MessageBox.Show(
                    string.Format("¿Está seguro de que desea dar de baja al doctor(a) {0}?", nombreDoctor),
                    "Confirmar Inactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    if (controlador.eliminarDoctor(idDoctor))
                    {
                        CargarDoctores(txtBuscar.Text.Trim());
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
            CargarDoctores(txtBuscar.Text.Trim());
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

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
                using (crearUsuario formUsuario = new crearUsuario(true))
                {
                    if (formUsuario.ShowDialog(this) == DialogResult.OK && formUsuario.IdUsuarioCreado.HasValue)
                    {
                        using (crearDoctor formDoctor = new crearDoctor(formUsuario.IdUsuarioCreado.Value))
                        {
                            if (formDoctor.ShowDialog(this) == DialogResult.OK)
                                CargarDoctores(txtBuscar.Text.Trim());
                        }
                    }
                }
            }
            else if (respuesta == DialogResult.No)
            {
                using (crearDoctor formDoctor = new crearDoctor())
                {
                    if (formDoctor.ShowDialog(this) == DialogResult.OK)
                        CargarDoctores(txtBuscar.Text.Trim());
                }
            }
        }
    }
}
