using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Administradores
{
    /// <summary>
    /// Formulario principal del catálogo de Administradores.
    /// Exclusivo para usuarios con rol 'Admin'.
    /// Ofrece listado en tiempo real, KPIs, badges de estado y vinculación de credenciales.
    /// </summary>
    public partial class paginaPrincipalAdministradores : Form
    {
        private readonly administradoresControllers controlador = new administradoresControllers();

        public paginaPrincipalAdministradores()
        {
            InitializeComponent();
        }

        private void paginaPrincipalAdministradores_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisuales();
            ConfigurarGrid();
            AjustarLayout();
            cmbFiltroEstado.SelectedIndex = 0; // "Todos"
            CargarAdministradores();
        }

        private void paginaPrincipalAdministradores_Resize(object sender, EventArgs e)
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

            lblIconoModulo.Visible = true;
            lblIconoModulo.Text = "";
            lblIconoModulo.Paint += (s, ev) =>
            {
                Tema.DibujarFondoCircular(ev.Graphics, lblIconoModulo.ClientRectangle, Color.FromArgb(226, 238, 248));
                Tema.DibujarIconoAdmin(ev.Graphics, lblIconoModulo.ClientRectangle, Tema.AzulPrimario);
            };

            lblIconoBuscar.Text = "";
            lblIconoBuscar.Paint += (s, ev) =>
            {
                Tema.DibujarIconoLupa(ev.Graphics, lblIconoBuscar.ClientRectangle, lblIconoBuscar.ForeColor);
            };

            lblIconoFiltro.Text = "";
            lblIconoFiltro.Paint += (s, ev) =>
            {
                Tema.DibujarIconoFiltro(ev.Graphics, lblIconoFiltro.ClientRectangle, lblIconoFiltro.ForeColor);
            };

            lblIconoTotal.Text = "";
            lblIconoTotal.Paint += (s, ev) =>
            {
                Tema.DibujarFondoCircular(ev.Graphics, lblIconoTotal.ClientRectangle, lblIconoTotal.BackColor);
                Tema.DibujarIconoAdmin(ev.Graphics, lblIconoTotal.ClientRectangle, lblIconoTotal.ForeColor);
            };

            lblIconoActivos.Text = "";
            lblIconoActivos.Paint += (s, ev) =>
            {
                Tema.DibujarFondoCircular(ev.Graphics, lblIconoActivos.ClientRectangle, lblIconoActivos.BackColor);
                Tema.DibujarIconoCheck(ev.Graphics, lblIconoActivos.ClientRectangle, lblIconoActivos.ForeColor);
            };

            lblIconoInactivos.Text = "";
            lblIconoInactivos.Paint += (s, ev) =>
            {
                Tema.DibujarFondoCircular(ev.Graphics, lblIconoInactivos.ClientRectangle, lblIconoInactivos.BackColor);
                Tema.DibujarIconoInactivo(ev.Graphics, lblIconoInactivos.ClientRectangle, lblIconoInactivos.ForeColor);
            };
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
            if (!string.IsNullOrEmpty(lbl.Text))
            {
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var textBrush = new SolidBrush(lbl.ForeColor))
                {
                    e.Graphics.DrawString(lbl.Text, lbl.Font, textBrush, new RectangleF(0, 0, lbl.Width, lbl.Height), sf);
                }
            }
        }

        private void ConfigurarGrid()
        {
            Tema.ConfigurarTabla(dgvAdministradores);
            dgvAdministradores.AccessibleName = "Listado de administradores";
            dgvAdministradores.AccessibleDescription = "Use las flechas para navegar y Enter o clic para ver detalle, editar o modificar estado.";
            dgvAdministradores.RowTemplate.Height = 46;
            dgvAdministradores.ColumnHeadersHeight = 42;

            dgvAdministradores.Columns["colNombre"].FillWeight = 160;
            dgvAdministradores.Columns["colCedula"].FillWeight = 95;
            dgvAdministradores.Columns["colTelefono"].FillWeight = 85;
            dgvAdministradores.Columns["colCorreo"].FillWeight = 140;
            dgvAdministradores.Columns["colCuenta"].FillWeight = 110;
            dgvAdministradores.Columns["colEstado"].FillWeight = 75;
            dgvAdministradores.Columns["colVer"].FillWeight = 55;
            dgvAdministradores.Columns["colEditar"].FillWeight = 55;
            dgvAdministradores.Columns["colBaja"].FillWeight = 80;

            colVer.FlatStyle = FlatStyle.Flat;
            colEditar.FlatStyle = FlatStyle.Flat;
            colBaja.FlatStyle = FlatStyle.Flat;
        }

        public void CargarAdministradores()
        {
            try
            {
                dgvAdministradores.Rows.Clear();
                string filtro = txtBuscar.Text.Trim();
                string estadoFiltro = cmbFiltroEstado.SelectedItem != null
                    ? cmbFiltroEstado.SelectedItem.ToString()
                    : "Todos";

                List<AdministradorItemDto> lista = controlador.ListarAdministradores(filtro, estadoFiltro);
                foreach (var a in lista)
                {
                    string infoCuenta = a.TieneCuenta ? a.NombreUsuario : "○ Sin cuenta";
                    int rowIndex = dgvAdministradores.Rows.Add(
                        a.IdAdministrador,
                        a.NombreCompleto,
                        string.IsNullOrWhiteSpace(a.Cedula) ? "-" : a.Cedula,
                        string.IsNullOrWhiteSpace(a.Telefono) ? "-" : a.Telefono,
                        string.IsNullOrWhiteSpace(a.Correo) ? "-" : a.Correo,
                        infoCuenta,
                        a.Estado ? "● Activo" : "○ Inactivo"
                    );

                    DataGridViewRow fila = dgvAdministradores.Rows[rowIndex];
                    fila.Cells["colVer"].Value = "Ver";
                    fila.Cells["colEditar"].Value = "Editar";
                    fila.Cells["colBaja"].Value = a.Estado ? "Dar de baja" : "Reactivar";
                }

                ActualizarMetricas(lista.Count);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Acceso no autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el listado de administradores:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarMetricas(int filtrados)
        {
            try
            {
                var todos = controlador.ListarAdministradores("", "Todos");
                int total = todos != null ? todos.Count : 0;
                int activos = 0;
                if (todos != null)
                {
                    foreach (var a in todos)
                    {
                        if (a.Estado) activos++;
                    }
                }
                int inactivos = total - activos;

                lblTotalNum.Text = total.ToString();
                lblActivosNum.Text = activos.ToString();
                lblInactivosNum.Text = inactivos.ToString();

                lblConteo.Text = string.Format("Mostrando {0} de {1} administradores", filtrados, total);
            }
            catch
            {
                lblTotalNum.Text = filtrados.ToString();
                lblActivosNum.Text = filtrados.ToString();
                lblInactivosNum.Text = "0";
                lblConteo.Text = string.Format("Mostrando {0} administradores", filtrados);
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

        private void dgvAdministradores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Columna Nombre con Avatar de Iniciales
            if (dgvAdministradores.Columns[e.ColumnIndex].Name == "colNombre")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string nombreCompleto = e.Value?.ToString() ?? "";
                string iniciales = ObtenerIniciales(nombreCompleto);

                int diametro = 28;
                int avatarX = e.CellBounds.X + 12;
                int avatarY = e.CellBounds.Y + ((e.CellBounds.Height - diametro) / 2);

                using (var brushAvatar = new SolidBrush(Color.FromArgb(235, 245, 255)))
                {
                    e.Graphics.FillEllipse(brushAvatar, avatarX, avatarY, diametro, diametro);
                }
                using (var penAvatar = new Pen(Color.FromArgb(195, 220, 245), 1f))
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
                    e.Graphics.DrawString(nombreCompleto, dgvAdministradores.Font, brushNombre, rectTexto, sfTexto);
                }

                e.Handled = true;
                return;
            }

            // 2. Columna Cuenta con Badge estético
            if (dgvAdministradores.Columns[e.ColumnIndex].Name == "colCuenta")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string cuenta = e.Value?.ToString() ?? "○ Sin cuenta";
                bool tieneCuenta = !cuenta.Contains("Sin cuenta");

                Color fondoBadge = tieneCuenta ? Color.FromArgb(238, 247, 254) : Color.FromArgb(246, 246, 248);
                Color bordeBadge = tieneCuenta ? Color.FromArgb(200, 226, 248) : Color.FromArgb(226, 226, 230);
                Color textoColor = tieneCuenta ? Tema.AzulPrimario : Tema.TextoSecundario;

                int badgeH = 24;
                int badgeY = e.CellBounds.Y + ((e.CellBounds.Height - badgeH) / 2);
                int badgeX = e.CellBounds.X + 8;
                int badgeW = Math.Min(e.CellBounds.Width - 16, 120);

                var rectBadge = new Rectangle(badgeX, badgeY, badgeW, badgeH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBadge, fondoBadge, bordeBadge, 5);

                using (var brushTexto = new SolidBrush(textoColor))
                using (var fontBadge = new Font(Tema.FamiliaFuente, 8.2F, FontStyle.Regular))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
                {
                    e.Graphics.DrawString(cuenta, fontBadge, brushTexto, rectBadge, sf);
                }

                e.Handled = true;
                return;
            }

            // 3. Columna Estado con indicador visual
            if (dgvAdministradores.Columns[e.ColumnIndex].Name == "colEstado")
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
                    e.Graphics.DrawString(estado.Replace("●", "").Replace("○", "").Trim(), dgvAdministradores.Font, brushEstado, rectTexto, sf);
                }

                e.Handled = true;
                return;
            }

            // 4. Botón Ver Detalle
            if (dgvAdministradores.Columns[e.ColumnIndex].Name == "colVer")
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
                    e.Graphics.DrawString("Ver", fontBtn, brushVer, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }

            // 5. Botón Editar
            if (dgvAdministradores.Columns[e.ColumnIndex].Name == "colEditar")
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
                    e.Graphics.DrawString("Editar", fontBtn, brushEditar, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }

            // 6. Botón Dar de baja / Reactivar
            if (dgvAdministradores.Columns[e.ColumnIndex].Name == "colBaja")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string textoBoton = e.Value?.ToString() ?? "Dar de baja";
                bool esDarBaja = textoBoton.IndexOf("baja", StringComparison.OrdinalIgnoreCase) >= 0;

                int btnW = Math.Min(96, e.CellBounds.Width - 8);
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
                    e.Graphics.DrawString(textoBoton, fontBtn, brushBaja, rectBtn, sfBtn);
                }

                e.Handled = true;
                return;
            }
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "AD";
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
        }

        private void dgvAdministradores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && (
                e.ColumnIndex == dgvAdministradores.Columns["colVer"].Index ||
                e.ColumnIndex == dgvAdministradores.Columns["colEditar"].Index ||
                e.ColumnIndex == dgvAdministradores.Columns["colBaja"].Index))
            {
                dgvAdministradores.Cursor = Cursors.Hand;
            }
            else
            {
                dgvAdministradores.Cursor = Cursors.Default;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
            CargarAdministradores();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAdministradores();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearAdministrador formulario = new crearAdministrador())
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                {
                    CargarAdministradores();
                }
            }
        }

        private void dgvAdministradores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int idAdministrador = Convert.ToInt32(dgvAdministradores.Rows[e.RowIndex].Cells["colIdAdministrador"].Value);
            string columna = dgvAdministradores.Columns[e.ColumnIndex].Name;

            if (columna == "colVer")
            {
                using (detalleAdministrador detalle = new detalleAdministrador(idAdministrador))
                {
                    detalle.ShowDialog(this);
                }
            }
            else if (columna == "colEditar")
            {
                using (crearAdministrador formulario = new crearAdministrador(idAdministrador))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarAdministradores();
                    }
                }
            }
            else if (columna == "colBaja")
            {
                string nombre = dgvAdministradores.Rows[e.RowIndex].Cells["colNombre"].Value?.ToString() ?? "este administrador";
                string accion = dgvAdministradores.Rows[e.RowIndex].Cells["colBaja"].Value?.ToString() ?? "Dar de baja";

                if (accion == "Dar de baja")
                {
                    var confirmacion = MessageBox.Show(
                        string.Format("¿Está seguro de que desea dar de baja a {0}?\n\nSi tiene una cuenta de usuario vinculada, quedará suspendida para impedir el inicio de sesión.", nombre),
                        "Confirmar baja de administrador",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            controlador.DarDeBaja(idAdministrador);
                            MessageBox.Show("El administrador ha sido dado de baja exitosamente.", "Baja procesada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarAdministradores();
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo dar de baja al administrador:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    var confirmacion = MessageBox.Show(
                        string.Format("¿Desea reactivar el perfil de {0}?\n\nNota: Si poseía una cuenta de usuario, deberá gestionarla de manera explícita en el módulo de Usuarios.", nombre),
                        "Confirmar reactivación de administrador",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            controlador.Reactivar(idAdministrador);
                            MessageBox.Show("El administrador ha sido reactivado exitosamente.", "Reactivación procesada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarAdministradores();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo reactivar al administrador:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
