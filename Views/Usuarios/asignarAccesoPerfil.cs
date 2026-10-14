using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views
{
    /// <summary>
    /// Formulario especializado para asignar credenciales de acceso a personas con perfil activo que aún no tienen cuenta.
    /// Garantiza la coherencia e integridad de la relación 1 a 1 entre Usuario, Rol y Perfil sin selectores arbitrarios de rol.
    /// </summary>
    public partial class asignarAccesoPerfil : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private readonly usuariosControllers controlador = new usuariosControllers();
        private List<PerfilSinUsuarioDto> perfilesDisponibles = new List<PerfilSinUsuarioDto>();
        private PerfilSinUsuarioDto perfilSeleccionado = null;
        private bool contrasenaVisible = false;
        private bool confirmarVisible = false;

        public int? IdUsuarioCreado { get; private set; }
        public string NombreUsuarioCreado { get; private set; }

        public asignarAccesoPerfil()
        {
            InitializeComponent();
            ConfigurarEstilosVisuales();
            ConfigurarEventos();
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.Fondo;

            // Tarjetas redondeadas estilizadas según Tema.cs
            pnlIzquierdo.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, pnlIzquierdo.Width - 1, pnlIzquierdo.Height - 1), Color.White, Tema.Borde, 8);
            };

            cardPerfil.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardPerfil.Width - 1, cardPerfil.Height - 1), Color.White, Tema.Borde, 8);
            };

            cardCredenciales.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardCredenciales.Width - 1, cardCredenciales.Height - 1), Color.White, Tema.Borde, 8);
            };

            pnlBuscarInput.Paint += DibujarBuscador;
            lblLupa.Visible = false;

            pnlIconoHeader.Paint += DibujarIconoHeader;
            lblIconoHeader.Visible = false;

            badgePerfil.Text = "";
            badgePerfil.Paint += DibujarBadgePerfil;

            badgeCredenciales.Text = "";
            badgeCredenciales.Paint += DibujarBadgeCredenciales;

            lblIconoTipoGrande.Text = "";
            lblIconoTipoGrande.Paint += DibujarIconoTipoGrande;

            panelBannerRol.Paint += DibujarBannerRol;
            lblIconoInfoBanner.Visible = false;

            btnVerContrasena.Text = "";
            btnVerContrasena.Paint += DibujarIconoOjo;

            btnVerConfirmar.Text = "";
            btnVerConfirmar.Paint += DibujarIconoOjo;

            // Placeholder nativo para la barra de búsqueda
            try
            {
                SendMessage(txtBuscar.Handle, 0x1501, 1, "Ingrese un criterio de búsqueda...");
            }
            catch { }

            // Configurar tabla con estándares de Sanar Rural
            Tema.ConfigurarTabla(dgvPerfiles);
            dgvPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPerfiles.ScrollBars = ScrollBars.Vertical;
            dgvPerfiles.RowTemplate.Height = 54;
            dgvPerfiles.ColumnHeadersHeight = 42;

            dgvPerfiles.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colTipo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colNombre.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colUbicacionCargo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colIdentificacion.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            colTelefono.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            colTipo.Width = 122;
            colNombre.Width = 150;
            colIdentificacion.Width = 128;
            colTelefono.Width = 88;
            colUbicacionCargo.Width = 165;
            colAccion.Width = 106;

            btnCrearAcceso.Text = "       Crear acceso";
            btnCrearAcceso.Paint += DibujarIconoBotonCrear;

            dgvPerfiles.Resize += (s, ev) => AjustarColumnasTabla();
            dgvPerfiles.CellPainting += DgvPerfiles_CellPainting;
            dgvPerfiles.CellClick += DgvPerfiles_CellClick;
            dgvPerfiles.CellContentClick += DgvPerfiles_CellClick;
            dgvPerfiles.SelectionChanged += DgvPerfiles_SelectionChanged;

            // Microinteracciones de hover
            btnCrearAcceso.MouseEnter += (s, ev) => { if (btnCrearAcceso.Enabled) btnCrearAcceso.BackColor = Tema.AzulOscuro; };
            btnCrearAcceso.MouseLeave += (s, ev) => { if (btnCrearAcceso.Enabled) btnCrearAcceso.BackColor = Tema.AzulPrimario; };

            btnCancelar.MouseEnter += (s, ev) => { btnCancelar.BackColor = Tema.FondoSecundario; };
            btnCancelar.MouseLeave += (s, ev) => { btnCancelar.BackColor = Color.White; };

            btnVerContrasena.MouseEnter += (s, ev) => { btnVerContrasena.BackColor = Tema.FondoSecundario; btnVerContrasena.Invalidate(); };
            btnVerContrasena.MouseLeave += (s, ev) => { btnVerContrasena.BackColor = Color.White; btnVerContrasena.Invalidate(); };

            btnVerConfirmar.MouseEnter += (s, ev) => { btnVerConfirmar.BackColor = Tema.FondoSecundario; btnVerConfirmar.Invalidate(); };
            btnVerConfirmar.MouseLeave += (s, ev) => { btnVerConfirmar.BackColor = Color.White; btnVerConfirmar.Invalidate(); };
        }

        private void DibujarIconoBotonCrear(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color colorIcono = btnCrearAcceso.Enabled ? Color.White : Color.FromArgb(200, 210, 220);

            using (var pen = new Pen(colorIcono, 1.5f))
            using (var brush = new SolidBrush(colorIcono))
            {
                int ix = 16;
                int iy = (btnCrearAcceso.Height - 14) / 2;
                e.Graphics.DrawRectangle(pen, ix, iy, 15, 12);
                e.Graphics.FillEllipse(brush, ix + 3, iy + 3, 3, 3);
                e.Graphics.DrawLine(pen, ix + 8, iy + 4, ix + 12, iy + 4);
                e.Graphics.DrawLine(pen, ix + 8, iy + 7, ix + 12, iy + 7);
                e.Graphics.DrawLine(pen, ix + 3, iy + 9, ix + 12, iy + 9);
            }
        }

        private void DibujarIconoHeader(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, pnlIconoHeader.Width - 1, pnlIconoHeader.Height - 1);
            Tema.DibujarTarjetaRedondeada(e.Graphics, rect, Color.FromArgb(226, 238, 248), Color.FromArgb(190, 215, 235), 8);

            using (var brush = new SolidBrush(Color.FromArgb(15, 76, 129)))
            using (var pen = new Pen(Color.FromArgb(15, 76, 129), 2f))
            {
                e.Graphics.FillEllipse(brush, 14, 11, 14, 14);
                e.Graphics.FillPie(brush, 7, 24, 22, 16, 180, 180);

                e.Graphics.DrawLine(pen, 30, 15, 38, 15);
                e.Graphics.DrawLine(pen, 34, 11, 34, 19);
            }
        }

        private void DibujarBuscador(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, pnlBuscarInput.Width - 1, pnlBuscarInput.Height - 1);
            Tema.DibujarTarjetaRedondeada(e.Graphics, rect, Color.White, Tema.Borde, 6);

            using (var pen = new Pen(Color.FromArgb(148, 163, 184), 1.8f))
            {
                e.Graphics.DrawEllipse(pen, 9, 7, 10, 10);
                e.Graphics.DrawLine(pen, 17, 15, 22, 20);
            }
        }

        private void DibujarBadgePerfil(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(1, 1, badgePerfil.Width - 3, badgePerfil.Height - 3);
            using (var brushFondo = new SolidBrush(Color.FromArgb(232, 245, 233)))
            using (var brushIcono = new SolidBrush(Color.FromArgb(46, 125, 50)))
            {
                e.Graphics.FillEllipse(brushFondo, rect);
                e.Graphics.FillEllipse(brushIcono, 9, 6, 10, 10);
                e.Graphics.FillPie(brushIcono, 4, 15, 20, 14, 180, 180);
            }
        }

        private void DibujarBadgeCredenciales(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(1, 1, badgeCredenciales.Width - 3, badgeCredenciales.Height - 3);
            using (var brushFondo = new SolidBrush(Color.FromArgb(232, 245, 233)))
            using (var brushIcono = new SolidBrush(Color.FromArgb(46, 125, 50)))
            using (var penArco = new Pen(Color.FromArgb(46, 125, 50), 1.8f))
            {
                e.Graphics.FillEllipse(brushFondo, rect);
                e.Graphics.DrawArc(penArco, 9, 6, 10, 10, 180, 180);
                e.Graphics.FillRectangle(brushIcono, 8, 11, 12, 10);
            }
        }

        private static string SanearTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return texto
                .Replace("Ã¡", "á")
                .Replace("Ã©", "é")
                .Replace("Ã­", "í")
                .Replace("Ã³", "ó")
                .Replace("Ãº", "ú")
                .Replace("Ã±", "ñ")
                .Replace("Ã", "Á")
                .Replace("Ã‰", "É")
                .Replace("Ã", "Í")
                .Replace("Ã“", "Ó")
                .Replace("Ãš", "Ú")
                .Replace("Ã‘", "Ñ");
        }

        private void DibujarIconoOjo(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            bool esVisible = (btn == btnVerContrasena) ? contrasenaVisible : confirmarVisible;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int cx = btn.Width / 2;
            int cy = btn.Height / 2;

            Color colIcono = Color.FromArgb(100, 116, 139);
            using (var pen = new Pen(colIcono, 1.6f))
            using (var brush = new SolidBrush(colIcono))
            {
                e.Graphics.DrawArc(pen, cx - 8, cy - 6, 16, 12, 20, 140);
                e.Graphics.DrawArc(pen, cx - 8, cy - 6, 16, 12, 200, 140);
                e.Graphics.FillEllipse(brush, cx - 3, cy - 3, 6, 6);

                if (!esVisible)
                {
                    using (var penTachado = new Pen(colIcono, 1.6f))
                    {
                        e.Graphics.DrawLine(penTachado, cx - 8, cy - 7, cx + 8, cy + 7);
                    }
                }
            }
        }

        private void DibujarBannerRol(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panelBannerRol.Width - 1, panelBannerRol.Height - 1);
            Tema.DibujarTarjetaRedondeada(e.Graphics, rect, Color.FromArgb(235, 247, 238), Color.FromArgb(200, 230, 201), 6);

            // Icono (i) informativo en verde
            using (var brushCirculo = new SolidBrush(Color.FromArgb(46, 125, 50)))
            using (var brushTexto = new SolidBrush(Color.White))
            using (var font = new Font(Tema.FamiliaFuente, 8F, FontStyle.Bold))
            {
                e.Graphics.FillEllipse(brushCirculo, 10, 13, 18, 18);
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString("i", font, brushTexto, new Rectangle(10, 13, 18, 18), sf);
            }
        }

        private void DibujarIconoTipoGrande(object sender, PaintEventArgs e)
        {
            if (perfilSeleccionado == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color fondo = Color.FromArgb(227, 242, 253);
            Color icono = Color.FromArgb(15, 76, 129);

            switch (perfilSeleccionado.TipoPerfil)
            {
                case "Doctor":
                    fondo = Color.FromArgb(227, 242, 253);
                    icono = Color.FromArgb(15, 76, 129);
                    break;
                case "Paciente":
                    fondo = Color.FromArgb(232, 245, 233);
                    icono = Color.FromArgb(46, 125, 50);
                    break;
                case "Personal administrativo":
                    fondo = Color.FromArgb(255, 243, 224);
                    icono = Color.FromArgb(230, 81, 0);
                    break;
                case "Administrador":
                    fondo = Color.FromArgb(243, 229, 245);
                    icono = Color.FromArgb(106, 27, 154);
                    break;
            }

            Rectangle rect = new Rectangle(1, 1, lblIconoTipoGrande.Width - 3, lblIconoTipoGrande.Height - 3);
            using (var brushFondo = new SolidBrush(fondo))
            using (var brushIcono = new SolidBrush(icono))
            {
                e.Graphics.FillEllipse(brushFondo, rect);

                int cx = lblIconoTipoGrande.Width / 2;
                int cy = lblIconoTipoGrande.Height / 2;

                if (perfilSeleccionado.TipoPerfil == "Doctor")
                {
                    using (var penSteth = new Pen(icono, 2.2f))
                    {
                        penSteth.StartCap = LineCap.Round;
                        penSteth.EndCap = LineCap.Round;
                        e.Graphics.DrawArc(penSteth, cx - 10, cy - 12, 20, 14, 0, 180);
                        e.Graphics.FillEllipse(brushIcono, cx - 11, cy - 13, 4, 4);
                        e.Graphics.FillEllipse(brushIcono, cx + 7, cy - 13, 4, 4);
                        e.Graphics.DrawLine(penSteth, cx, cy + 2, cx, cy + 8);
                    }
                    e.Graphics.FillEllipse(brushIcono, cx - 5, cy + 7, 10, 10);
                }
                else if (perfilSeleccionado.TipoPerfil == "Paciente")
                {
                    e.Graphics.FillEllipse(brushIcono, cx - 6, cy - 12, 12, 12);
                    e.Graphics.FillPie(brushIcono, cx - 11, cy - 1, 22, 18, 180, 180);
                }
                else if (perfilSeleccionado.TipoPerfil == "Personal administrativo")
                {
                    e.Graphics.FillEllipse(brushIcono, cx - 9, cy - 10, 8, 8);
                    e.Graphics.FillPie(brushIcono, cx - 13, cy - 1, 15, 14, 180, 180);
                    e.Graphics.FillEllipse(brushIcono, cx + 1, cy - 10, 8, 8);
                    e.Graphics.FillPie(brushIcono, cx - 2, cy - 1, 15, 14, 180, 180);
                }
                else // Administrador
                {
                    Point[] escudo = new Point[]
                    {
                        new Point(cx - 9, cy - 10),
                        new Point(cx + 9, cy - 10),
                        new Point(cx + 9, cy - 1),
                        new Point(cx, cy + 11),
                        new Point(cx - 9, cy - 1)
                    };
                    e.Graphics.FillPolygon(brushIcono, escudo);
                }
            }
        }

        private void ConfigurarEventos()
        {
            this.Load += AsignarAccesoPerfil_Load;
            this.Resize += (s, ev) => AjustarLayout();
            this.VisibleChanged += (s, ev) => { if (this.Visible) AjustarLayout(); };
            this.ParentChanged += (s, ev) => AjustarLayout();

            cmbFiltroTipo.SelectedIndexChanged += (s, ev) => FiltrarPerfiles();
            txtBuscar.TextChanged += (s, ev) =>
            {
                btnLimpiarBusqueda.Visible = !string.IsNullOrEmpty(txtBuscar.Text);
                FiltrarPerfiles();
            };

            btnLimpiarBusqueda.Click += (s, ev) =>
            {
                txtBuscar.Clear();
                txtBuscar.Focus();
            };

            btnVerContrasena.Click += (s, ev) =>
            {
                contrasenaVisible = !contrasenaVisible;
                txtContrasena.PasswordChar = contrasenaVisible ? '\0' : '●';
                btnVerContrasena.Text = "";
                btnVerContrasena.Invalidate();
            };

            btnVerConfirmar.Click += (s, ev) =>
            {
                confirmarVisible = !confirmarVisible;
                txtConfirmarContrasena.PasswordChar = confirmarVisible ? '\0' : '●';
                btnVerConfirmar.Text = "";
                btnVerConfirmar.Invalidate();
            };

            txtNombreUsuario.TextChanged += (s, ev) => ValidarFormularioEnTiempoReal();
            txtContrasena.TextChanged += (s, ev) => ValidarFormularioEnTiempoReal();
            txtConfirmarContrasena.TextChanged += (s, ev) => ValidarFormularioEnTiempoReal();

            btnCancelar.Click += BtnCancelar_Click;
            btnCrearAcceso.Click += BtnCrearAcceso_Click;
        }

        private void AsignarAccesoPerfil_Load(object sender, EventArgs e)
        {
            PoblarComboFiltro();
            CargarPerfiles();
            AjustarLayout();
            ActualizarPanelLateral();
        }

        private void PoblarComboFiltro()
        {
            cmbFiltroTipo.Items.Clear();
            cmbFiltroTipo.Items.Add("Todos los perfiles sin usuario");
            cmbFiltroTipo.Items.Add("Paciente");
            cmbFiltroTipo.Items.Add("Doctor");
            cmbFiltroTipo.Items.Add("Personal administrativo");

            // Solo el administrador general puede ver y asignar perfiles de administradores
            if (controlador.EsSesionAdmin())
            {
                cmbFiltroTipo.Items.Add("Administrador");
            }

            cmbFiltroTipo.SelectedIndex = 0;
        }

        private void CargarPerfiles()
        {
            try
            {
                perfilesDisponibles = controlador.ListarPerfilesSinUsuario(null, null);
                FiltrarPerfiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron consultar los perfiles sin usuario:\n\n" + ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarPerfiles()
        {
            string tipo = cmbFiltroTipo.SelectedItem != null ? cmbFiltroTipo.SelectedItem.ToString() : null;
            string termino = txtBuscar.Text.Trim().ToLowerInvariant();

            var filtrados = perfilesDisponibles.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(tipo) && tipo != "Todos los perfiles sin usuario")
            {
                filtrados = filtrados.Where(p => string.Equals(p.TipoPerfil, tipo, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(termino))
            {
                filtrados = filtrados.Where(p =>
                    (p.NombreCompleto != null && p.NombreCompleto.ToLowerInvariant().Contains(termino)) ||
                    (p.Identificacion != null && p.Identificacion.ToLowerInvariant().Contains(termino)) ||
                    (p.Telefono != null && p.Telefono.ToLowerInvariant().Contains(termino)) ||
                    (p.UbicacionCargo != null && p.UbicacionCargo.ToLowerInvariant().Contains(termino))
                );
            }

            var listaFinal = filtrados.ToList();

            dgvPerfiles.Rows.Clear();
            foreach (var p in listaFinal)
            {
                int rowIndex = dgvPerfiles.Rows.Add(
                    p.TipoPerfil,
                    SanearTexto(p.NombreCompleto),
                    !string.IsNullOrWhiteSpace(p.Identificacion) ? p.Identificacion : "—",
                    !string.IsNullOrWhiteSpace(p.Telefono) ? p.Telefono : "—",
                    !string.IsNullOrWhiteSpace(p.UbicacionCargo) ? SanearTexto(p.UbicacionCargo) : "—",
                    (perfilSeleccionado != null && perfilSeleccionado.IdPerfil == p.IdPerfil && perfilSeleccionado.TipoPerfil == p.TipoPerfil)
                        ? "✓ Seleccionado"
                        : "+ Seleccionar"
                );
                dgvPerfiles.Rows[rowIndex].Tag = p;
            }

            // Actualizar pie de tabla
            lblConteo.Text = string.Format("Mostrando {0} de {1} perfiles sin usuario", listaFinal.Count, perfilesDisponibles.Count);

            // Re-sincronizar fila seleccionada si corresponde
            ResincronizarFilaSeleccionada();
        }

        private void ResincronizarFilaSeleccionada()
        {
            if (perfilSeleccionado == null) return;

            foreach (DataGridViewRow row in dgvPerfiles.Rows)
            {
                var dto = row.Tag as PerfilSinUsuarioDto;
                if (dto != null && dto.IdPerfil == perfilSeleccionado.IdPerfil && dto.TipoPerfil == perfilSeleccionado.TipoPerfil)
                {
                    row.Selected = true;
                    row.Cells["colAccion"].Value = "✓ Seleccionado";
                    row.DefaultCellStyle.BackColor = Color.FromArgb(235, 245, 251);
                }
                else
                {
                    row.Cells["colAccion"].Value = "+ Seleccionar";
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void DgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPerfiles.Rows.Count) return;

            var dto = dgvPerfiles.Rows[e.RowIndex].Tag as PerfilSinUsuarioDto;
            if (dto == null) return;

            SeleccionarPerfil(dto);
        }

        private void DgvPerfiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPerfiles.SelectedRows.Count > 0)
            {
                var dto = dgvPerfiles.SelectedRows[0].Tag as PerfilSinUsuarioDto;
                if (dto != null && (perfilSeleccionado == null || perfilSeleccionado.IdPerfil != dto.IdPerfil || perfilSeleccionado.TipoPerfil != dto.TipoPerfil))
                {
                    SeleccionarPerfil(dto);
                }
            }
        }

        public void SeleccionarPerfil(PerfilSinUsuarioDto dto)
        {
            perfilSeleccionado = dto;
            ResincronizarFilaSeleccionada();
            ActualizarPanelLateral();
            dgvPerfiles.Invalidate();
        }

        public void SeleccionarPerfilPorId(int idPerfil, string tipoPerfil)
        {
            var dto = perfilesDisponibles.FirstOrDefault(p => p.IdPerfil == idPerfil && p.TipoPerfil == tipoPerfil);
            if (dto != null)
            {
                SeleccionarPerfil(dto);
            }
        }

        private void ActualizarPanelLateral()
        {
            bool haySeleccion = (perfilSeleccionado != null);

            lblSinSeleccion.Visible = !haySeleccion;
            lblIconoTipoGrande.Visible = haySeleccion;
            lblNombrePerfil.Visible = haySeleccion;
            lblTipoPerfil.Visible = haySeleccion;
            lblIdentificacionPerfil.Visible = haySeleccion;
            lblTelefonoPerfil.Visible = haySeleccion;
            lblUbicacionPerfil.Visible = haySeleccion;

            txtNombreUsuario.Enabled = haySeleccion;
            txtContrasena.Enabled = haySeleccion;
            txtConfirmarContrasena.Enabled = haySeleccion;
            btnCrearAcceso.Enabled = haySeleccion;

            if (haySeleccion)
            {
                lblNombrePerfil.Text = SanearTexto(perfilSeleccionado.NombreCompleto);
                lblTipoPerfil.Text = "Tipo de perfil: " + perfilSeleccionado.TipoPerfil;
                lblIdentificacionPerfil.Text = "Identificación: " + (!string.IsNullOrWhiteSpace(perfilSeleccionado.Identificacion) ? perfilSeleccionado.Identificacion : "No especificada");
                lblTelefonoPerfil.Text = "Teléfono: " + (!string.IsNullOrWhiteSpace(perfilSeleccionado.Telefono) ? perfilSeleccionado.Telefono : "No registrado");

                string etiquetaUbicacion = perfilSeleccionado.TipoPerfil == "Personal administrativo" ? "Cargo: " : "Ubicación: ";
                lblUbicacionPerfil.Text = etiquetaUbicacion + (!string.IsNullOrWhiteSpace(perfilSeleccionado.UbicacionCargo) ? SanearTexto(perfilSeleccionado.UbicacionCargo) : "Comunidad");

                lblIconoTipoGrande.Text = "";
                lblIconoTipoGrande.Invalidate();

                int anchoTexto = pnlDetallePerfil.ClientSize.Width - 52;
                if (anchoTexto > 100)
                {
                    lblNombrePerfil.Width = anchoTexto;
                    lblUbicacionPerfil.Width = anchoTexto;
                }

                btnCrearAcceso.BackColor = Tema.AzulPrimario;

                // Sugerir nombre de usuario limpio basado en el nombre de la persona si está vacío
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                {
                    txtNombreUsuario.Text = GenerarSugerenciaUsuario(perfilSeleccionado.NombreCompleto);
                }
            }
            else
            {
                btnCrearAcceso.BackColor = Color.FromArgb(148, 163, 184);
                txtNombreUsuario.Clear();
                txtContrasena.Clear();
                txtConfirmarContrasena.Clear();
                lblErrorUsuario.Text = "";
                lblErrorConfirmar.Text = "";
            }

            ValidarFormularioEnTiempoReal();
        }

        private static string GenerarSugerenciaUsuario(string nombreCompleto)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto)) return "";
            string limpio = nombreCompleto.Replace("Dr(a).", "").Replace("Dr.", "").Replace("Dra.", "").Trim();
            string[] partes = limpio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0] + "_" + partes[partes.Length - 1]).ToLowerInvariant();
            }
            if (partes.Length == 1)
            {
                return partes[0].ToLowerInvariant();
            }
            return "";
        }

        private void ValidarFormularioEnTiempoReal()
        {
            if (perfilSeleccionado == null)
            {
                lblErrorUsuario.Text = "";
                lblErrorConfirmar.Text = "";
                btnCrearAcceso.Enabled = false;
                return;
            }

            string user = txtNombreUsuario.Text.Trim();
            string pass = txtContrasena.Text;
            string confirm = txtConfirmarContrasena.Text;

            bool usuarioValido = true;
            if (user.Length > 0 && (user.Length < 3 || user.Length > 50))
            {
                lblErrorUsuario.Text = "El usuario debe tener entre 3 y 50 caracteres.";
                lblErrorUsuario.ForeColor = Tema.Error;
                usuarioValido = false;
            }
            else if (user.Length >= 3 && controlador.NombreUsuarioYaExiste(user))
            {
                lblErrorUsuario.Text = "El nombre de usuario ya está registrado.";
                lblErrorUsuario.ForeColor = Tema.Error;
                usuarioValido = false;
            }
            else
            {
                lblErrorUsuario.Text = "";
            }

            bool contrasenaValida = true;
            if (pass.Length > 0 && pass.Length < 6)
            {
                lblAyudaContrasena.ForeColor = Tema.Error;
                contrasenaValida = false;
            }
            else
            {
                lblAyudaContrasena.ForeColor = Tema.TextoSecundario;
            }

            bool coincidenciaValida = true;
            if (confirm.Length > 0 && pass != confirm)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden.";
                lblErrorConfirmar.ForeColor = Tema.Error;
                coincidenciaValida = false;
            }
            else
            {
                lblErrorConfirmar.Text = "";
            }

            btnCrearAcceso.Enabled = usuarioValido && contrasenaValida && coincidenciaValida &&
                user.Length >= 3 && pass.Length >= 6 && pass == confirm;

            btnCrearAcceso.BackColor = btnCrearAcceso.Enabled ? Tema.AzulPrimario : Color.FromArgb(148, 163, 184);
        }

        private void DgvPerfiles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Personalización de la columna TipoPerfil con icono circular nítido y texto alineado
            if (e.ColumnIndex == dgvPerfiles.Columns["colTipo"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                string tipo = e.Value != null ? e.Value.ToString() : "";
                Color colorCirculo = Color.FromArgb(77, 142, 86); // Paciente por defecto

                switch (tipo)
                {
                    case "Paciente":
                        colorCirculo = Color.FromArgb(77, 142, 86);
                        break;
                    case "Doctor":
                        colorCirculo = Color.FromArgb(35, 120, 183);
                        break;
                    case "Personal administrativo":
                        colorCirculo = Color.FromArgb(230, 81, 0);
                        break;
                    case "Administrador":
                        colorCirculo = Color.FromArgb(106, 27, 154);
                        break;
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Dibujar círculo suave con el icono vectorial representativo
                int diametro = 20;
                int circuloX = e.CellBounds.X + 5;
                int circuloY = e.CellBounds.Y + (e.CellBounds.Height - diametro) / 2;
                Rectangle rectCirculo = new Rectangle(circuloX, circuloY, diametro, diametro);

                using (var brushFondo = new SolidBrush(colorCirculo))
                {
                    e.Graphics.FillEllipse(brushFondo, rectCirculo);
                }

                // Dibujar icono blanco nítido centrado dentro del círculo
                int cx = circuloX + (diametro / 2);
                int cy = circuloY + (diametro / 2);

                using (var brushBlanco = new SolidBrush(Color.White))
                using (var penBlanco = new Pen(Color.White, 1.5f))
                {
                    if (tipo == "Paciente")
                    {
                        e.Graphics.FillEllipse(brushBlanco, cx - 4, cy - 6, 8, 7);
                        e.Graphics.FillPie(brushBlanco, cx - 6, cy - 1, 12, 10, 180, 180);
                    }
                    else if (tipo == "Doctor")
                    {
                        // Estetoscopio vectorial
                        e.Graphics.DrawArc(penBlanco, cx - 5, cy - 6, 10, 7, 0, 180);
                        e.Graphics.FillEllipse(brushBlanco, cx - 6, cy - 7, 3, 3);
                        e.Graphics.FillEllipse(brushBlanco, cx + 3, cy - 7, 3, 3);
                        e.Graphics.DrawLine(penBlanco, cx, cy + 1, cx, cy + 4);
                        e.Graphics.FillEllipse(brushBlanco, cx - 3, cy + 3, 6, 6);
                    }
                    else if (tipo == "Personal administrativo")
                    {
                        // Dos personas (grupo)
                        e.Graphics.FillEllipse(brushBlanco, cx - 5, cy - 5, 5, 5);
                        e.Graphics.FillPie(brushBlanco, cx - 8, cy - 1, 9, 8, 180, 180);
                        e.Graphics.FillEllipse(brushBlanco, cx + 1, cy - 5, 5, 5);
                        e.Graphics.FillPie(brushBlanco, cx - 2, cy - 1, 9, 8, 180, 180);
                    }
                    else // Administrador
                    {
                        Point[] escudo = new Point[]
                        {
                            new Point(cx - 5, cy - 6),
                            new Point(cx + 5, cy - 6),
                            new Point(cx + 5, cy),
                            new Point(cx, cy + 6),
                            new Point(cx - 5, cy)
                        };
                        e.Graphics.FillPolygon(brushBlanco, escudo);
                    }
                }

                // Dibujar texto a la derecha del círculo sin elipsis ni recortes forzados
                int textoX = circuloX + diametro + 5;
                int textoY = e.CellBounds.Y + 4;
                int textoW = e.CellBounds.Width - (textoX - e.CellBounds.X) - 2;
                int textoH = e.CellBounds.Height - 8;
                Rectangle rectTexto = new Rectangle(textoX, textoY, textoW, textoH);

                using (var brushTexto = new SolidBrush(Tema.TextoPrincipal))
                {
                    if (tipo == "Personal administrativo")
                    {
                        using (var font = new Font(Tema.FamiliaFuente, 8.0F, FontStyle.Regular))
                        {
                            StringFormat sf = new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Center,
                                Trimming = StringTrimming.Word
                            };
                            e.Graphics.DrawString("Personal\nadministrativo", font, brushTexto, rectTexto, sf);
                        }
                    }
                    else
                    {
                        using (var font = new Font(Tema.FamiliaFuente, 8.25F, FontStyle.Regular))
                        {
                            StringFormat sf = new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                LineAlignment = StringAlignment.Center,
                                FormatFlags = StringFormatFlags.NoWrap,
                                Trimming = StringTrimming.EllipsisCharacter
                            };
                            e.Graphics.DrawString(tipo, font, brushTexto, rectTexto, sf);
                        }
                    }
                }

                e.Handled = true;
            }

            // 2. Personalización de la columna Acción (Botón + Seleccionar / ✓ Seleccionado)
            if (e.ColumnIndex == dgvPerfiles.Columns["colAccion"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                var dto = dgvPerfiles.Rows[e.RowIndex].Tag as PerfilSinUsuarioDto;
                bool estaSeleccionado = (perfilSeleccionado != null && dto != null &&
                    perfilSeleccionado.IdPerfil == dto.IdPerfil && perfilSeleccionado.TipoPerfil == dto.TipoPerfil);

                int btnAlto = 30;
                int btnAncho = e.CellBounds.Width - 8;
                int btnX = e.CellBounds.X + 4;
                int btnY = e.CellBounds.Y + (e.CellBounds.Height - btnAlto) / 2;

                Rectangle rectBoton = new Rectangle(btnX, btnY, btnAncho, btnAlto);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Color fondoBoton = estaSeleccionado ? Color.FromArgb(15, 76, 129) : Color.White;
                Color bordeBoton = estaSeleccionado ? Color.FromArgb(15, 76, 129) : Color.FromArgb(35, 120, 183);
                Color textoBoton = estaSeleccionado ? Color.White : Color.FromArgb(35, 120, 183);
                string texto = estaSeleccionado ? "✓ Seleccionado" : "+ Seleccionar";

                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBoton, fondoBoton, bordeBoton, 6);

                using (var brushTexto = new SolidBrush(textoBoton))
                using (var font = new Font(Tema.FamiliaFuente, 8.0F, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.NoWrap
                    };
                    e.Graphics.DrawString(texto, font, brushTexto, rectBoton, sf);
                }

                e.Handled = true;
            }
        }

        public void AjustarLayout()
        {
            if (this.ClientSize.Width <= 0 || this.ClientSize.Height <= 0) return;

            int margen = 12;
            int gap = 14;

            int anchoTotal = pnlMain.ClientSize.Width - (margen * 2);
            int altoTotal = pnlMain.ClientSize.Height - (margen * 2);

            if (anchoTotal <= 0 || altoTotal <= 0) return;

            // Proporción exacta según la referencia: panel derecho de ancho ergonómico (~325px), panel izquierdo aprovecha todo el espacio restante
            int anchoDerecho = Math.Min(335, Math.Max(315, (int)(anchoTotal * 0.29f)));
            int anchoIzquierdo = anchoTotal - anchoDerecho - gap;

            pnlIzquierdo.SetBounds(margen, margen, anchoIzquierdo, altoTotal);
            pnlDerecho.SetBounds(pnlIzquierdo.Right + gap, margen, anchoDerecho, altoTotal);

            // Ajustar columnas de la tabla dentro del espacio del panel izquierdo
            AjustarColumnasTabla();

            // En el panel derecho:
            // 1. cardPerfil: tarjeta de 160px para acomodar nombres y ubicaciones largas en 2 líneas completas
            int altoCardPerfil = 160;
            cardPerfil.SetBounds(0, 0, anchoDerecho, altoCardPerfil);

            // Ajustar ancho de labels dentro de pnlDetallePerfil
            int anchoTextoDetalle = pnlDetallePerfil.ClientSize.Width - 52;
            if (anchoTextoDetalle > 100)
            {
                lblNombrePerfil.Width = anchoTextoDetalle;
                lblUbicacionPerfil.Width = anchoTextoDetalle;
            }

            // 2. panelBannerRol: situado entre las dos tarjetas (~42px)
            int altoBanner = 42;
            int topBanner = cardPerfil.Bottom + 10;
            panelBannerRol.SetBounds(0, topBanner, anchoDerecho, altoBanner);

            // Ajustar ancho de texto en el banner informativo
            int anchoTextoBanner = panelBannerRol.ClientSize.Width - 44;
            if (anchoTextoBanner > 50)
            {
                lblTextoInfoBanner.Width = anchoTextoBanner;
            }

            // 3. cardCredenciales: ocupa el espacio restante con botones anclados al fondo
            int topCredenciales = panelBannerRol.Bottom + 10;
            int altoCredenciales = altoTotal - topCredenciales;
            cardCredenciales.SetBounds(0, topCredenciales, anchoDerecho, altoCredenciales);

            // Ajustar anchos responsivos dentro de cardCredenciales
            int anchoCampos = cardCredenciales.ClientSize.Width - 32;
            if (anchoCampos > 80)
            {
                txtNombreUsuario.Width = anchoCampos;
                pnlContrasena.Width = anchoCampos;
                pnlConfirmarContrasena.Width = anchoCampos;
                lblErrorUsuario.Width = anchoCampos;
                lblAyudaContrasena.Width = anchoCampos;
                lblErrorConfirmar.Width = anchoCampos;
            }

            // Ajustar posición del botón Crear acceso dentro de pnlBotonesAccion
            int anchoBotones = pnlBotonesAccion.ClientSize.Width;
            if (anchoBotones > 200)
            {
                btnCrearAcceso.Left = anchoBotones - btnCrearAcceso.Width;
            }
        }

        private void AjustarColumnasTabla()
        {
            if (dgvPerfiles.ClientSize.Width <= 0) return;

            int anchoDisponible = dgvPerfiles.ClientSize.Width;

            // Anchos generosos calibrados para evitar cualquier elipsis en Tipo, Identificación, Teléfono y Acción
            int anchoTipo = 114;
            int anchoIdentificacion = 134;
            int anchoTelefono = 101;
            int anchoAccion = 99;

            int anchoFijo = anchoTipo + anchoIdentificacion + anchoTelefono + anchoAccion; // 448px
            int anchoRestante = anchoDisponible - anchoFijo;

            if (anchoRestante < 240)
            {
                anchoRestante = 240;
            }

            // Distribuir equilibradamente: ~46% a Nombre y ~54% a Ubicación/Cargo
            int anchoNombre = (int)Math.Round(anchoRestante * 0.46f);

            colTipo.Width = anchoTipo;
            colIdentificacion.Width = anchoIdentificacion;
            colTelefono.Width = anchoTelefono;
            colAccion.Width = anchoAccion;

            colNombre.Width = Math.Max(145, anchoNombre);
            colUbicacionCargo.MinimumWidth = 125;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Si está alojado dentro del shell administrativo, retornar suavemente a la sección de usuarios
            var shell = this.FindForm() as menuPrincipalAdministrativo ?? this.ParentForm as menuPrincipalAdministrativo;
            if (shell != null)
            {
                shell.VolverAUsuarios();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void BtnCrearAcceso_Click(object sender, EventArgs e)
        {
            if (perfilSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar primero un perfil de la tabla.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string user = txtNombreUsuario.Text.Trim();
            string pass = txtContrasena.Text;
            string confirm = txtConfirmarContrasena.Text;

            if (user.Length < 3 || user.Length > 50)
            {
                MessageBox.Show("El nombre de usuario debe tener entre 3 y 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            if (pass.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres por seguridad.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifíquelas e intente nuevamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarContrasena.Focus();
                return;
            }

            // Ejecución de la transacción ACID de creación y vinculación en controlador y modelo
            string error;
            bool exito = controlador.CrearUsuarioVinculadoAPerfil(
                perfilSeleccionado.IdPerfil,
                perfilSeleccionado.TipoPerfil,
                user,
                pass,
                out error);

            if (!exito)
            {
                MessageBox.Show("No se pudo completar la creación del acceso:\n\n" + error, "Error de Vinculación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Refrescar tabla por si el perfil fue modificado por otro usuario
                CargarPerfiles();
                return;
            }

            IdUsuarioCreado = 1; // Registro exitoso
            NombreUsuarioCreado = user;

            MessageBox.Show(
                "¡Acceso creado con éxito!\n\n" +
                "Se ha creado la cuenta de acceso '" + user + "' y se ha vinculado correctamente al perfil de " +
                perfilSeleccionado.NombreCompleto + " con el rol asignado '" + perfilSeleccionado.RolAsignar + "'.",
                "Acceso Vinculado Exitosamente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var shell = this.FindForm() as menuPrincipalAdministrativo ?? this.ParentForm as menuPrincipalAdministrativo;
            if (shell != null)
            {
                shell.VolverAUsuarios();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
