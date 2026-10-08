using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views
{
    /// <summary>
    /// Vista principal moderna del módulo de administración de usuarios.
    /// Presenta métricas resumidas, filtros integrados, avatares y tabla de acciones directas.
    /// </summary>
    public partial class paginaPrincipalUsuarios : Form
    {
        private readonly usuariosControllers controlador = new usuariosControllers();
        private readonly ToolTip toolTipAcciones = new ToolTip();

        public paginaPrincipalUsuarios()
        {
            InitializeComponent();
        }

        private void paginaPrincipalUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisuales();
            ConfigurarGridUsuarios();

            if (!VerificarAccesoAdministrativo())
                return;

            cmbFiltroRol.SelectedIndex = 0;
            AjustarLayout();
            CargarUsuarios();
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

            panelFiltroRol.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelFiltroRol.Width - 1, panelFiltroRol.Height - 1), Color.White, Tema.Borde, 6);
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

            toolTipAcciones.SetToolTip(btnNuevo, "Crear una nueva cuenta de usuario en el sistema");
            toolTipAcciones.SetToolTip(txtBuscar, "Buscar por correo electrónico o rol");
            toolTipAcciones.SetToolTip(cmbFiltroRol, "Filtrar por rol específico");
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

        private void ConfigurarGridUsuarios()
        {
            Tema.ConfigurarTabla(dgvUsuarios);
            dgvUsuarios.RowTemplate.Height = 46;
            dgvUsuarios.ColumnHeadersHeight = 42;

            dgvUsuarios.Columns["Correo"].FillWeight = 160;
            dgvUsuarios.Columns["Rol"].FillWeight = 110;
            dgvUsuarios.Columns["FechaRegistro"].FillWeight = 110;
            dgvUsuarios.Columns["Estado"].FillWeight = 90;
            dgvUsuarios.Columns["colEditar"].FillWeight = 75;
            dgvUsuarios.Columns["colBaja"].FillWeight = 85;

            dgvUsuarios.CellPainting += DgvUsuarios_CellPainting;
            dgvUsuarios.CellMouseMove += DgvUsuarios_CellMouseMove;
        }

        private void DgvUsuarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvUsuarios.Columns["colEditar"].Index || e.ColumnIndex == dgvUsuarios.Columns["colBaja"].Index))
            {
                dgvUsuarios.Cursor = Cursors.Hand;
            }
            else
            {
                dgvUsuarios.Cursor = Cursors.Default;
            }
        }

        private void DgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Columna de Correo con Avatar de Iniciales
            if (e.ColumnIndex == dgvUsuarios.Columns["Correo"].Index)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string correo = e.Value != null ? e.Value.ToString() : "";
                string iniciales = ObtenerIniciales(correo);
                Color colorAvatar = ObtenerColorAvatar(correo);

                // Dibujar círculo de avatar
                int diametro = 28;
                int avatarX = e.CellBounds.X + 12;
                int avatarY = e.CellBounds.Y + ((e.CellBounds.Height - diametro) / 2);

                using (var brushAvatar = new SolidBrush(colorAvatar))
                {
                    e.Graphics.FillEllipse(brushAvatar, avatarX, avatarY, diametro, diametro);
                }

                // Dibujar texto de iniciales centrado
                using (var fontIniciales = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(iniciales, fontIniciales, Brushes.White, new Rectangle(avatarX, avatarY, diametro, diametro), sf);
                }

                // Dibujar correo electrónico
                int textoX = avatarX + diametro + 10;
                var rectTexto = new Rectangle(textoX, e.CellBounds.Y, e.CellBounds.Width - (textoX - e.CellBounds.X) - 4, e.CellBounds.Height);
                using (var sfTexto = new StringFormat { LineAlignment = StringAlignment.Center })
                using (var brushTexto = new SolidBrush(Tema.TextoPrincipal))
                {
                    e.Graphics.DrawString(correo, Tema.FuenteCuerpo, brushTexto, rectTexto, sfTexto);
                }

                e.Handled = true;
            }
            // 2. Columna de Rol con Badge tipo Pill
            else if (e.ColumnIndex == dgvUsuarios.Columns["Rol"].Index)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string rol = e.Value != null ? e.Value.ToString() : "";
                Color fondoBadge = Tema.BadgeRolAdminFondo;
                Color textoBadge = Tema.AzulPrimario;
                string icono = "⚙ ";

                if (rol == "Doctor")
                {
                    fondoBadge = Tema.BadgeRolDoctorFondo;
                    textoBadge = Color.FromArgb(14, 118, 136);
                    icono = "🩺 ";
                }
                else if (rol == "Paciente")
                {
                    fondoBadge = Tema.BadgeRolPacienteFondo;
                    textoBadge = Tema.VerdeOscuro;
                    icono = "👤 ";
                }

                int badgeH = 26;
                int badgeW = Math.Min(115, e.CellBounds.Width - 20);
                int badgeX = e.CellBounds.X + 8;
                int badgeY = e.CellBounds.Y + ((e.CellBounds.Height - badgeH) / 2);

                var rectBadge = new Rectangle(badgeX, badgeY, badgeW, badgeH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBadge, fondoBadge, Color.Transparent, 13);

                using (var brushRol = new SolidBrush(textoBadge))
                using (var sfRol = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fontRol = new Font(Tema.FamiliaFuente, 8.8F, FontStyle.Bold))
                {
                    e.Graphics.DrawString(icono + rol, fontRol, brushRol, rectBadge, sfRol);
                }

                e.Handled = true;
            }
            // 3. Columna de Estado con Bullet estilizado
            else if (e.ColumnIndex == dgvUsuarios.Columns["Estado"].Index)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string estado = e.Value != null ? e.Value.ToString() : "";
                bool esActivo = estado.Contains("Activo");

                Color colorBullet = esActivo ? Tema.VerdeOscuro : Tema.TextoSecundario;
                int bulletSize = 8;
                int bulletX = e.CellBounds.X + 12;
                int bulletY = e.CellBounds.Y + ((e.CellBounds.Height - bulletSize) / 2);

                using (var brushBullet = new SolidBrush(colorBullet))
                {
                    e.Graphics.FillEllipse(brushBullet, bulletX, bulletY, bulletSize, bulletSize);
                }

                int textoX = bulletX + bulletSize + 8;
                var rectEstado = new Rectangle(textoX, e.CellBounds.Y, e.CellBounds.Width - 24, e.CellBounds.Height);
                using (var sfEstado = new StringFormat { LineAlignment = StringAlignment.Center })
                using (var brushEstado = new SolidBrush(colorBullet))
                using (var fontEstado = new Font(Tema.FamiliaFuente, 9F, FontStyle.Bold))
                {
                    e.Graphics.DrawString(esActivo ? "Activo" : "Inactivo", fontEstado, brushEstado, rectEstado, sfEstado);
                }

                e.Handled = true;
            }
            // 4. Botón de Editar con estilo pill moderno
            else if (e.ColumnIndex == dgvUsuarios.Columns["colEditar"].Index)
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
            }
            // 5. Botón de Dar de baja con estilo pill moderno
            else if (e.ColumnIndex == dgvUsuarios.Columns["colBaja"].Index)
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
            }
        }

        private static string ObtenerIniciales(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return "U";
            string usuario = correo.Split('@')[0];

            if (usuario.Contains("."))
            {
                var partes = usuario.Split('.');
                if (partes.Length >= 2 && partes[0].Length > 0 && partes[1].Length > 0)
                    return ("" + partes[0][0] + partes[1][0]).ToUpper();
            }

            if (usuario.Length >= 2)
                return usuario.Substring(0, 2).ToUpper();

            return usuario.ToUpper();
        }

        private static Color ObtenerColorAvatar(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return Tema.AzulPrimario;
            int hash = Math.Abs(correo.GetHashCode());
            Color[] paleta = new Color[]
            {
                Color.FromArgb(35, 120, 183),  // Azul Primario
                Color.FromArgb(29, 154, 148),  // Verde Azulado / Teal
                Color.FromArgb(214, 116, 58),  // Naranja Cálido
                Color.FromArgb(124, 92, 183)   // Púrpura Elegante
            };
            return paleta[hash % paleta.Length];
        }

        private bool VerificarAccesoAdministrativo()
        {
            if (usuariosModels.IdRolActual.HasValue &&
                usuariosModels.IdRolActual.Value == controlador.ObtenerIdRol("Administrativo"))
                return true;

            MessageBox.Show("Esta sección está disponible para usuarios administrativos.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void CargarUsuarios()
        {
            if (!VerificarAccesoAdministrativo())
                return;

            try
            {
                string terminoBusqueda = txtBuscar.Text.Trim();
                List<Usuarios> listaTotal = controlador.ListarUsuarios("");
                List<Usuarios> listaFiltrada = controlador.ListarUsuarios(terminoBusqueda);

                // Filtro por rol en memoria para mantener interfaz responsiva
                if (cmbFiltroRol.SelectedIndex > 0)
                {
                    string rolSeleccionado = cmbFiltroRol.SelectedItem.ToString();
                    listaFiltrada = listaFiltrada.Where(u => u.Roles != null && u.Roles.Nombre == rolSeleccionado).ToList();
                }

                // Cargar datos en la tabla
                dgvUsuarios.Rows.Clear();
                foreach (Usuarios usuario in listaFiltrada)
                {
                    string nombreRol = usuario.Roles != null ? usuario.Roles.Nombre : "Sin rol";
                    dgvUsuarios.Rows.Add(
                        usuario.IdUsuario,
                        usuario.Correo,
                        nombreRol,
                        usuario.FechaRegistro.ToString("g"),
                        usuario.Estado ? "✓ Activo" : "Inactivo");
                }

                // Actualizar métricas resumidas
                int total = listaTotal.Count;
                int activos = listaTotal.Count(u => u.Estado);
                int inactivos = total - activos;

                lblTotalNum.Text = total.ToString();
                lblActivosNum.Text = activos.ToString();
                lblInactivosNum.Text = inactivos.ToString();

                // Actualizar texto del pie de tabla
                lblConteo.Text = string.Format("Mostrando {0} de {1} usuarios", listaFiltrada.Count, total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el listado de usuarios:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
            CargarUsuarios();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void cmbFiltroRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var formulario = new crearUsuario(false, true))
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                    CargarUsuarios();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int idUsuario = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value);

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "colEditar")
            {
                using (var formulario = new crearUsuario(idUsuario))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarUsuarios();
                }
            }
            else if (dgvUsuarios.Columns[e.ColumnIndex].Name == "colBaja")
            {
                string correo = dgvUsuarios.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                if (MessageBox.Show("¿Desea dar de baja a " + correo + "? Sus perfiles y referencias históricas se conservarán.",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        controlador.EliminarUsuario(idUsuario);
                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo dar de baja el usuario:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void paginaPrincipalUsuarios_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
        }
    }
}
