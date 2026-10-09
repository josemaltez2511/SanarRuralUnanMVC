using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Pacientes
{
    /// <summary>
    /// Formulario principal del catálogo de pacientes.
    /// Presenta el listado moderno con búsqueda ágil, badges de estado, avatares y métricas resumidas.
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
            ConfigurarEstilosVisuales();
            ConfigurarGrid();
            ConfigurarSeguridadPorRol();
            AjustarLayout();
            CargarPacientes();
        }

        private void paginaPrincipalPacientes_Resize(object sender, EventArgs e)
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

            panelFiltroEstado.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelFiltroEstado.Width - 1, panelFiltroEstado.Height - 1), Color.White, Tema.Borde, 6);
            };

            cardTotal.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardTotal.Width - 1, cardTotal.Height - 1), cardTotal.BackColor, Tema.Borde, 8);
            };

            cardActivos.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardActivos.Width - 1, cardActivos.Height - 1), cardActivos.BackColor, Tema.Borde, 8);
            };

            cardInactivos.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardInactivos.Width - 1, cardInactivos.Height - 1), cardInactivos.BackColor, Tema.Borde, 8);
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
            lblIconoInactivos.Paint += DibujarFondoCircularIcono;
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
            Tema.ConfigurarTabla(dgvPacientes);
            dgvPacientes.AccessibleName = "Listado de pacientes";
            dgvPacientes.AccessibleDescription = "Use las flechas para recorrer pacientes y Enter o espacio en los botones de acción.";
            dgvPacientes.RowTemplate.Height = 46;
            dgvPacientes.ColumnHeadersHeight = 42;

            dgvPacientes.Columns["colNombre"].FillWeight = 150;
            dgvPacientes.Columns["colCedula"].FillWeight = 85;
            dgvPacientes.Columns["colTelefono"].FillWeight = 80;
            dgvPacientes.Columns["colComunidad"].FillWeight = 95;
            dgvPacientes.Columns["colMunicipio"].FillWeight = 90;
            dgvPacientes.Columns["colDepartamento"].FillWeight = 90;
            dgvPacientes.Columns["colEstado"].FillWeight = 75;
            dgvPacientes.Columns["colVer"].FillWeight = 55;
            dgvPacientes.Columns["colEditar"].FillWeight = 55;
            dgvPacientes.Columns["colBaja"].FillWeight = 75;

            colVer.FlatStyle = FlatStyle.Flat;
            colEditar.FlatStyle = FlatStyle.Flat;
            colBaja.FlatStyle = FlatStyle.Flat;
        }

        private void ConfigurarSeguridadPorRol()
        {
            bool esAdmin = controlador.EsAdministrativo();
            if (esAdmin)
            {
                panelFiltroEstado.Visible = true;
                cmbFiltroEstado.SelectedIndex = 0; // "Activos" por defecto
                dgvPacientes.Columns["colBaja"].Visible = true;
                dgvPacientes.Columns["colEditar"].Visible = true;
            }
            else
            {
                // El rol Doctor únicamente puede consultar y dar de alta pacientes activos
                panelFiltroEstado.Visible = false;
                dgvPacientes.Columns["colBaja"].Visible = false;
                dgvPacientes.Columns["colEditar"].Visible = false;
            }
        }

        private void CargarPacientes()
        {
            try
            {
                dgvPacientes.Rows.Clear();
                string filtro = txtBuscar.Text.Trim();
                string estadoFiltro = panelFiltroEstado.Visible && cmbFiltroEstado.SelectedItem != null
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
                    fila.Cells["colVer"].Value = "👁 Ver";
                    fila.Cells["colEditar"].Value = "✏ Editar";
                    fila.Cells["colBaja"].Value = paciente.Estado ? "Dar de baja" : "Reactivar";
                }

                ActualizarMetricas(pacientes.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el listado de pacientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarMetricas(int filtrados)
        {
            try
            {
                // Obtenemos los totales globales para los KPIs
                var todos = controlador.listarPacientes("", "Todos");
                int total = todos != null ? todos.Count : 0;
                int activos = 0;

                if (todos != null)
                {
                    foreach (var p in todos)
                    {
                        if (p.Estado) activos++;
                    }
                }
                int inactivos = total - activos;

                lblTotalNum.Text = total.ToString();
                lblActivosNum.Text = activos.ToString();
                lblInactivosNum.Text = inactivos.ToString();

                lblConteo.Text = string.Format("Mostrando {0} de {1} pacientes", filtrados, total);
            }
            catch
            {
                lblTotalNum.Text = filtrados.ToString();
                lblActivosNum.Text = filtrados.ToString();
                lblInactivosNum.Text = "0";
                lblConteo.Text = string.Format("Mostrando {0} pacientes", filtrados);
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
            cardInactivos.SetBounds((cardW + gap) * 2, 6, anchoTotal - ((cardW + gap) * 2), 68);
        }

        private void dgvPacientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Columna Nombre con Avatar de Iniciales
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colNombre")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string nombreCompleto = e.Value?.ToString() ?? "";
                string iniciales = ObtenerIniciales(nombreCompleto);

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
                    e.Graphics.DrawString(nombreCompleto, dgvPacientes.Font, brushNombre, rectTexto, sfTexto);
                }

                e.Handled = true;
                return;
            }

            // 2. Columna Estado con indicador visual
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colEstado")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string estado = e.Value?.ToString() ?? "● Activo";
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
                    e.Graphics.DrawString(estado.Replace("●", "").Replace("○", "").Trim(), dgvPacientes.Font, brushEstado, rectTexto, sf);
                }

                e.Handled = true;
                return;
            }

            // 3. Botón de Ver Ficha con estilo pill moderno
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colVer")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(58, e.CellBounds.Width - 8);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                var rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Color.FromArgb(236, 245, 252), Color.FromArgb(190, 220, 244), 6);

                using (var brushVer = new SolidBrush(Tema.AzulPrimario))
                using (var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontBtn = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("👁 Ver", fontBtn, brushVer, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }

            // 4. Botón de Editar con estilo pill moderno
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colEditar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(68, e.CellBounds.Width - 8);
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

            // 5. Botón de Dar de baja / Reactivar con estilo pill moderno
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "colBaja")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string textoBoton = e.Value?.ToString() ?? "Dar de baja";
                bool esDarBaja = textoBoton.IndexOf("baja", StringComparison.OrdinalIgnoreCase) >= 0;

                int btnW = Math.Min(88, e.CellBounds.Width - 8);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                var rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Color fondoBtn = esDarBaja ? Tema.BotonPeligroFondo : Tema.FondoSecundario;
                Color bordeBtn = esDarBaja ? Tema.BotonPeligroBorde : Tema.Borde;
                Color textoColor = esDarBaja ? Tema.Error : Tema.VerdeOscuro;

                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, fondoBtn, bordeBtn, 6);

                using (var brushBaja = new SolidBrush(textoColor))
                using (var sfBtn = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontBtn = new Font(Tema.FamiliaFuente, 8.2F, FontStyle.Bold))
                {
                    string icono = esDarBaja ? "🚫 " : "↻ ";
                    e.Graphics.DrawString(icono + textoBoton, fontBtn, brushBaja, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "PA";
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
        }

        private void dgvPacientes_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && (
                e.ColumnIndex == dgvPacientes.Columns["colVer"].Index ||
                e.ColumnIndex == dgvPacientes.Columns["colEditar"].Index ||
                e.ColumnIndex == dgvPacientes.Columns["colBaja"].Index))
            {
                dgvPacientes.Cursor = Cursors.Hand;
            }
            else
            {
                dgvPacientes.Cursor = Cursors.Default;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
            CargarPacientes();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
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

            int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["colIdPaciente"].Value);
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
                if (!controlador.EsAdministrativo())
                {
                    MessageBox.Show("Solo los usuarios con rol Administrativo pueden editar los datos legales e institucionales del paciente.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                string nombre = dgvPacientes.Rows[e.RowIndex].Cells["colNombre"].Value != null
                    ? dgvPacientes.Rows[e.RowIndex].Cells["colNombre"].Value.ToString()
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
                            MessageBox.Show("No se pudo dar de baja al paciente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    try
                    {
                        controlador.reactivarPaciente(idPaciente);
                        CargarPacientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo reactivar al paciente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
