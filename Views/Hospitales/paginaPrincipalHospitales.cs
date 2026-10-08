using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    /// <summary>
    /// Catálogo principal de hospitales y centros de salud de Sanar Rural.
    /// Incorpora métricas resumidas, búsqueda ágil y tabla institucional con estilo moderno.
    /// </summary>
    public partial class paginaPrincipalHospitales : Form
    {
        private readonly hospitalesController controlador = new hospitalesController();

        public paginaPrincipalHospitales()
        {
            InitializeComponent();
        }

        private void paginaPrincipalHospitales_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisuales();
            ConfigurarGrid();
            AjustarLayout();
            CargarHospitales();

            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible)
                {
                    CargarHospitales(txtBuscar.Text.Trim());
                }
            };
        }

        private void paginaPrincipalHospitales_Resize(object sender, EventArgs e)
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

            cardDepartamentos.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardDepartamentos.Width - 1, cardDepartamentos.Height - 1), cardDepartamentos.BackColor, Tema.Borde, 8);
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
            lblIconoDepartamentos.Paint += DibujarFondoCircularIcono;
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
            Tema.ConfigurarTabla(dgvHospitales);
            dgvHospitales.RowTemplate.Height = 46;
            dgvHospitales.ColumnHeadersHeight = 42;
            dgvHospitales.AllowUserToResizeRows = false;
            dgvHospitales.AccessibleName = "Listado de hospitales";
            dgvHospitales.AccessibleDescription = "Use las flechas para recorrer sedes y Tab para acceder a las opciones de edición o baja.";

            dgvHospitales.Columns["colNombre"].FillWeight = 145;
            dgvHospitales.Columns["colDepartamento"].FillWeight = 95;
            dgvHospitales.Columns["colMunicipio"].FillWeight = 95;
            dgvHospitales.Columns["colDireccion"].FillWeight = 140;
            dgvHospitales.Columns["colTelefono"].FillWeight = 85;
            dgvHospitales.Columns["colEditar"].FillWeight = 62;
            dgvHospitales.Columns["colBaja"].FillWeight = 78;

            colEditar.FlatStyle = FlatStyle.Flat;
            colBaja.FlatStyle = FlatStyle.Flat;
        }

        private void CargarHospitales(string filtro = "")
        {
            try
            {
                dgvHospitales.Rows.Clear();
                var lista = controlador.listarHospitales(filtro);

                foreach (SanarRuralUnan.Hospitales hospital in lista)
                {
                    dgvHospitales.Rows.Add(
                        hospital.IdHospital,
                        hospital.Nombre,
                        hospital.Municipios?.Departamentos?.Nombre ?? "-",
                        hospital.Municipios?.Nombre ?? "-",
                        hospital.Direccion,
                        string.IsNullOrWhiteSpace(hospital.Telefono) ? "-" : hospital.Telefono);
                }

                CalcularMetricas(lista.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el listado de hospitales:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricas(int filtrados)
        {
            try
            {
                var todos = controlador.listarHospitales("");
                int total = todos != null ? todos.Count : 0;
                int activos = total;
                int deptos = todos != null
                    ? todos.Select(h => h.Municipios?.Departamentos?.Nombre).Where(d => !string.IsNullOrEmpty(d)).Distinct().Count()
                    : 0;

                lblTotalNum.Text = total.ToString();
                lblActivosNum.Text = activos.ToString();
                lblDepartamentosNum.Text = deptos.ToString();

                lblConteo.Text = string.Format("Mostrando {0} de {1} hospitales", filtrados, total);
            }
            catch
            {
                lblTotalNum.Text = filtrados.ToString();
                lblActivosNum.Text = filtrados.ToString();
                lblDepartamentosNum.Text = "1";
                lblConteo.Text = string.Format("Mostrando {0} hospitales", filtrados);
            }
        }

        private void AjustarLayout()
        {
            if (panelMetricas.ClientSize.Width <= 0) return;

            int anchoTotal = panelMetricas.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(180, (anchoTotal - (gap * 2)) / 3);

            cardTotal.SetBounds(0, 6, cardW, 68);
            cardActivos.SetBounds(cardW + gap, 6, cardW, 68);
            cardDepartamentos.SetBounds((cardW + gap) * 2, 6, anchoTotal - ((cardW + gap) * 2), 68);
        }

        private void dgvHospitales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Columna Nombre con Icono de Sede
            if (dgvHospitales.Columns[e.ColumnIndex].Name == "colNombre")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string nombre = e.Value?.ToString() ?? "";
                string iniciales = ObtenerIniciales(nombre);

                int diametro = 28;
                int avatarX = e.CellBounds.X + 12;
                int avatarY = e.CellBounds.Y + ((e.CellBounds.Height - diametro) / 2);

                using (var brushAvatar = new SolidBrush(Color.FromArgb(233, 244, 252)))
                {
                    e.Graphics.FillEllipse(brushAvatar, avatarX, avatarY, diametro, diametro);
                }
                using (var penAvatar = new Pen(Color.FromArgb(200, 226, 246), 1f))
                {
                    e.Graphics.DrawEllipse(penAvatar, avatarX, avatarY, diametro, diametro);
                }

                using (var fontIniciales = new Font(Tema.FamiliaFuente, 8.2F, FontStyle.Bold))
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
                    e.Graphics.DrawString(nombre, dgvHospitales.Font, brushNombre, rectTexto, sfTexto);
                }

                e.Handled = true;
                return;
            }

            // 2. Botón de Editar con estilo pill moderno
            if (dgvHospitales.Columns[e.ColumnIndex].Name == "colEditar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(68, e.CellBounds.Width - 10);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                var rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Tema.BotonEditarFondo, Tema.BotonEditarBorde, 6);

                using (var brushEditar = new SolidBrush(Tema.AzulPrimario))
                using (var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontBtn = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("✏ Editar", fontBtn, brushEditar, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }

            // 3. Botón de Dar de baja con estilo pill moderno
            if (dgvHospitales.Columns[e.ColumnIndex].Name == "colBaja")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(88, e.CellBounds.Width - 10);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                var rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Tema.BotonPeligroFondo, Tema.BotonPeligroBorde, 6);

                using (var brushBaja = new SolidBrush(Tema.Error))
                using (var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontBtn = new Font(Tema.FamiliaFuente, 8.2F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("🚫 Dar de baja", fontBtn, brushBaja, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "HP";
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
        }

        private void dgvHospitales_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && (
                e.ColumnIndex == dgvHospitales.Columns["colEditar"].Index ||
                e.ColumnIndex == dgvHospitales.Columns["colBaja"].Index))
            {
                dgvHospitales.Cursor = Cursors.Hand;
            }
            else
            {
                dgvHospitales.Cursor = Cursors.Default;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
            CargarHospitales(txtBuscar.Text.Trim());
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearHospital formulario = new crearHospital())
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                    CargarHospitales(txtBuscar.Text.Trim());
            }
        }

        private void dgvHospitales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int idHospital = Convert.ToInt32(dgvHospitales.Rows[e.RowIndex].Cells["colIdHospital"].Value);

            if (dgvHospitales.Columns[e.ColumnIndex].Name == "colEditar")
            {
                using (crearHospital formulario = new crearHospital(idHospital))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarHospitales(txtBuscar.Text.Trim());
                }
            }
            else if (dgvHospitales.Columns[e.ColumnIndex].Name == "colBaja")
            {
                string nombre = dgvHospitales.Rows[e.RowIndex].Cells["colNombre"].Value?.ToString() ?? "este hospital";
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea dar de baja a " + nombre + "? Sus referencias históricas se conservarán.",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        controlador.eliminarHospital(idHospital);
                        CargarHospitales(txtBuscar.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo dar de baja el hospital:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
