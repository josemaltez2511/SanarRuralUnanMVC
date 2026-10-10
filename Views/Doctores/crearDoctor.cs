using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    public partial class crearDoctor : Form
    {
        // ============================================================
        // CONTROLADORES Y ESTADO DE NEGOCIO
        // ============================================================
        private readonly doctoresControllers controladorDoctores = new doctoresControllers();
        private int? idUsuario;
        private int idDoctorEdicion;
        private bool esModoEdicion;
        private byte[] foto;
        private string fotoNombre;
        private string fotoMimeType;
        private bool fotoEliminadaExplicita;

        private readonly List<Tuple<int, int>> asignaciones = new List<Tuple<int, int>>();
        private List<Especialidades> especialidadesDisponibles = new List<Especialidades>();
        private List<SanarRuralUnan.Hospitales> hospitalesDisponibles = new List<SanarRuralUnan.Hospitales>();
        private bool formateandoCedula = false;

        // Catálogo de países centroamericanos con prefijos oficiales
        private class PaisTelefonoItem
        {
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            public string Bandera { get; set; }
            public int LongitudMinima { get; set; }
            public int LongitudMaxima { get; set; }

            public string TextoMostrar => $"{Bandera} {Nombre} ({Codigo})";

            public override string ToString() => TextoMostrar;
        }

        private static readonly List<PaisTelefonoItem> PaisesCentroamerica = new List<PaisTelefonoItem>
        {
            new PaisTelefonoItem { Nombre = "Nicaragua", Codigo = "+505", Bandera = "🇳🇮", LongitudMinima = 8, LongitudMaxima = 8 },
            new PaisTelefonoItem { Nombre = "Costa Rica", Codigo = "+506", Bandera = "🇨🇷", LongitudMinima = 8, LongitudMaxima = 8 },
            new PaisTelefonoItem { Nombre = "El Salvador", Codigo = "+503", Bandera = "🇸🇻", LongitudMinima = 8, LongitudMaxima = 8 },
            new PaisTelefonoItem { Nombre = "Guatemala", Codigo = "+502", Bandera = "🇬🇹", LongitudMinima = 8, LongitudMaxima = 8 },
            new PaisTelefonoItem { Nombre = "Honduras", Codigo = "+504", Bandera = "🇭🇳", LongitudMinima = 8, LongitudMaxima = 8 },
            new PaisTelefonoItem { Nombre = "Panamá", Codigo = "+507", Bandera = "🇵🇦", LongitudMinima = 7, LongitudMaxima = 8 },
            new PaisTelefonoItem { Nombre = "Belice", Codigo = "+501", Bandera = "🇧🇿", LongitudMinima = 7, LongitudMaxima = 8 }
        };

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

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

        // ============================================================
        // CONSTRUCTORES
        // ============================================================
        public crearDoctor()
        {
            InitializeComponent();
            ConfigurarOptimizacionesVisuales();
        }

        public crearDoctor(int idUsuarioRecibido) : this()
        {
            idUsuario = idUsuarioRecibido > 0 ? idUsuarioRecibido : (int?)null;
        }

        public crearDoctor(int idDoctor, bool modoEdicion) : this()
        {
            idDoctorEdicion = idDoctor;
            esModoEdicion = modoEdicion;
        }

        // Configuración de doble búfer para evitar parpadeos visuales al maximizar o redimensionar
        private void ConfigurarOptimizacionesVisuales()
        {
            this.DoubleBuffered = true;
            HabilitarDobleBufer(panelHero);
            HabilitarDobleBufer(panelFormContenedor);
            HabilitarDobleBufer(cardHeader);
            HabilitarDobleBufer(cardPersonal);
            HabilitarDobleBufer(cardFoto);
            HabilitarDobleBufer(cardProfesional);
            HabilitarDobleBufer(cardAsignaciones);
            HabilitarDobleBufer(panelAcciones);
            HabilitarDobleBufer(pnlCedulaInfo);
            HabilitarDobleBufer(pnlFotoInfo);
            HabilitarDobleBufer(pnlLicenciaInfo);
            HabilitarDobleBufer(panelLema);
            lstEspecialidades.IntegralHeight = false;
            lstAsignaciones.IntegralHeight = false;
        }

        private static void HabilitarDobleBufer(Control control)
        {
            if (control == null) return;
            try
            {
                typeof(Control).InvokeMember(
                    "DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    control,
                    new object[] { true }
                );
            }
            catch
            {
                // Si la reflexión falla, continuar normalmente
            }
        }

        // ============================================================
        // LOAD Y CONFIGURACIÓN INICIAL
        // ============================================================
        private void crearDoctor_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            // Cargar logotipo institucional desde los recursos del sistema
            picLogoHero.Image = Tema.ObtenerLogo();

            // Microinteracciones de hover
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;
            btnSeleccionarFoto.MouseEnter += (s, ev) => btnSeleccionarFoto.BackColor = Tema.AzulOscuro;
            btnSeleccionarFoto.MouseLeave += (s, ev) => btnSeleccionarFoto.BackColor = Tema.AzulPrimario;
            btnAgregarAsignacion.MouseEnter += (s, ev) => btnAgregarAsignacion.BackColor = Tema.AzulOscuro;
            btnAgregarAsignacion.MouseLeave += (s, ev) => btnAgregarAsignacion.BackColor = Tema.AzulPrimario;

            // Navegación ágil por teclado (Enter)
            txtPrimerNombre.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtSegundoNombre.Focus(); ev.SuppressKeyPress = true; } };
            txtSegundoNombre.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtPrimerApellido.Focus(); ev.SuppressKeyPress = true; } };
            txtPrimerApellido.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtSegundoApellido.Focus(); ev.SuppressKeyPress = true; } };
            txtSegundoApellido.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtCedula.Focus(); ev.SuppressKeyPress = true; } };
            txtCedula.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { cmbPaisTelefono.Focus(); ev.SuppressKeyPress = true; } };
            cmbPaisTelefono.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtTelefono.Focus(); ev.SuppressKeyPress = true; } };
            txtTelefono.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtLicencia.Focus(); ev.SuppressKeyPress = true; } };
            txtLicencia.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { lstEspecialidades.Focus(); ev.SuppressKeyPress = true; } };

            this.CancelButton = btnCancelar;

            // Configurar selector de países centroamericanos
            cmbPaisTelefono.DataSource = PaisesCentroamerica;
            cmbPaisTelefono.DisplayMember = "TextoMostrar";
            cmbPaisTelefono.ValueMember = "Codigo";
            cmbPaisTelefono.SelectedItem = PaisesCentroamerica.First(p => p.Codigo == "+505");

            // Configurar placeholders y textos descriptivos
            AsignarPlaceholder(txtPrimerNombre, "Ej. Raul");
            AsignarPlaceholder(txtSegundoNombre, "Ej. Santiago");
            AsignarPlaceholder(txtPrimerApellido, "Ej. Rodriguez");
            AsignarPlaceholder(txtSegundoApellido, "Ej. Salazar");
            AsignarPlaceholder(txtCedula, "001-091101-1042V");
            AsignarPlaceholder(txtTelefono, "8888-2222");
            AsignarPlaceholder(txtLicencia, "Código asignado al profesional");

            // Textos de etiquetas y ayudas actualizados
            lblNumeroLicencia.Text = "Código sanitario / registro MINSA *";
            lblCedulaAyuda.Text = "Ejemplo: 001-091101-1042V";
            lblTelefonoAyuda.Text = "Ingresa solo el número de teléfono (sin el código de país). Ejemplo: 8888-2222";
            lblLicenciaAyuda.Text = "Escribe el código tal como aparece en tu carnet o constancia oficial del MINSA.";

            // Eventos de formateo reactivo y restricciones de entrada
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedula_KeyPress;
            txtCedula.Leave += txtCedula_Leave;

            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;

            cmbHospitalAsignacion.DropDown += (s, ev) => AjustarAnchoDropDown(cmbHospitalAsignacion);
            cmbEspecialidadHospital.DropDown += (s, ev) => AjustarAnchoDropDown(cmbEspecialidadHospital);

            btnQuitarAsignacion.Enabled = false;
            lstAsignaciones.SelectedIndexChanged += (s, ev) => btnQuitarAsignacion.Enabled = lstAsignaciones.SelectedIndex >= 0;

            // Pintado decorativo de tarjetas y banners
            cardHeader.Paint += DibujarBordeTarjeta;
            cardPersonal.Paint += DibujarBordeTarjeta;
            cardFoto.Paint += DibujarBordeTarjeta;
            cardProfesional.Paint += DibujarBordeTarjeta;
            cardAsignaciones.Paint += DibujarBordeTarjeta;

            pnlCedulaInfo.Paint += DibujarBannerInformativo;
            pnlFotoInfo.Paint += DibujarBannerInformativo;
            pnlLicenciaInfo.Paint += DibujarBannerInformativo;

            lblIconoDoctor.Paint += (s, ev) => DibujarIconoCircular(s, ev, "👨‍⚕️");
            lblIconoPersonal.Paint += (s, ev) => DibujarIconoCircular(s, ev, "👤");
            lblIconoFoto.Paint += (s, ev) => DibujarIconoCircular(s, ev, "📷");
            lblIconoProfesional.Paint += (s, ev) => DibujarIconoCircular(s, ev, "📄");
            lblIconoAsignaciones.Paint += (s, ev) => DibujarIconoCircular(s, ev, "🏥");

            picPreview.Paint += picPreview_Paint;
            panelHero.Paint += panelHero_Paint;
            panelLema.Paint += panelLema_Paint;

            try
            {
                CargarCatalogos();

                if (esModoEdicion)
                {
                    this.Text = "Sanar Rural - Modificar Doctor";
                    lblTitulo.Text = "Modificar Datos del Doctor";
                    lblSubtitulo.Text = "Actualice los datos profesionales y asignaciones del médico";
                    lblRegistroTituloHero.Text = "Modificar Doctor";
                    btnGuardar.Text = "💾 Guardar Cambios";
                    CargarDoctor();
                }
                else
                {
                    this.Text = "Sanar Rural - Registro de Doctor";
                    lblTitulo.Text = "Datos del Doctor";
                    lblSubtitulo.Text = "Completa la información requerida";
                    lblRegistroTituloHero.Text = "Registro de Doctor";
                    btnGuardar.Text = "💾 Guardar Doctor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar los datos del doctor.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                btnGuardar.Enabled = false;
            }

            AjustarLayoutDoctor();
            txtPrimerNombre.Focus();
        }

        private void crearDoctor_Resize(object sender, EventArgs e)
        {
            AjustarLayoutDoctor();
        }

        // ============================================================
        // LAYOUT RESPONSIVO DINÁMICO
        // ============================================================
        private void AjustarLayoutDoctor()
        {
            int anchoTotal = this.ClientSize.Width;
            int altoTotal = this.ClientSize.Height;

            if (anchoTotal <= 0 || altoTotal <= 0)
                return;

            // Proporción estricta del Hero: 25% del ancho total (en el rango 24-27%)
            int anchoHero = (int)(anchoTotal * 0.25f);
            if (anchoHero < 310) anchoHero = 310;
            if (anchoHero > 500) anchoHero = 500;

            int anchoForm = anchoTotal - anchoHero;

            panelHero.SetBounds(0, 0, anchoHero, altoTotal);
            panelFormContenedor.SetBounds(anchoHero, 0, anchoForm, altoTotal);

            // Ajuste interno del panel Hero
            int margenHero = Math.Max(20, (anchoHero - 300) / 2);
            int anchoContenidoHero = Math.Min(320, anchoHero - (margenHero * 2));

            picLogoHero.Location = new Point(margenHero, Math.Max(18, (int)(altoTotal * 0.025f)));
            lblNombreHero.Location = new Point(margenHero - 2, picLogoHero.Bottom + 6);
            lblSubtituloHero.Location = new Point(margenHero, lblNombreHero.Bottom + 3);
            lblRegistroTituloHero.Location = new Point(margenHero, lblSubtituloHero.Bottom + 12);
            lblDescripcionHero.Location = new Point(margenHero, lblRegistroTituloHero.Bottom + 6);
            lblDescripcionHero.Width = anchoContenidoHero;

            panelHeroBloque1.Location = new Point(margenHero, lblDescripcionHero.Bottom + 12);
            panelHeroBloque1.Width = anchoContenidoHero;
            lblHeroDesc1.Width = panelHeroBloque1.Width - lblHeroDesc1.Left - 5;

            panelHeroBloque2.Location = new Point(margenHero, panelHeroBloque1.Bottom + 8);
            panelHeroBloque2.Width = anchoContenidoHero;
            lblHeroDesc2.Width = panelHeroBloque2.Width - lblHeroDesc2.Left - 5;

            panelHeroBloque3.Location = new Point(margenHero, panelHeroBloque2.Bottom + 8);
            panelHeroBloque3.Width = anchoContenidoHero;
            lblHeroDesc3.Width = panelHeroBloque3.Width - lblHeroDesc3.Left - 5;

            if (altoTotal >= 640)
            {
                panelLema.Visible = true;
                panelLema.Location = new Point(margenHero, altoTotal - panelLema.Height - 20);
                panelLema.Width = anchoContenidoHero;
                lblLemaTexto.Width = panelLema.Width - lblLemaTexto.Left - 36;
                lblLemaComillasCierre.Left = panelLema.Width - 32;
            }
            else
            {
                panelLema.Visible = false;
            }

            // ============================================================
            // AJUSTE DE TARJETAS EN EL FORMULARIO DERECHO
            // ============================================================
            int margenLateral = 20;
            int scrollWidth = SystemInformation.VerticalScrollBarWidth;
            int anchoNeto = panelFormContenedor.ClientSize.Width;
            int anchoCards = Math.Max(660, anchoNeto - (margenLateral * 2) - scrollWidth);

            int xCard = margenLateral;
            int gap = 12;
            int y = 16;

            // 1. Tarjeta Encabezado
            cardHeader.SetBounds(xCard, y, anchoCards, 66);
            lblIconoDoctor.SetBounds(16, 13, 40, 40);
            lblTitulo.Location = new Point(64, 11);
            lblSubtitulo.Location = new Point(66, 37);
            y += cardHeader.Height + gap;

            // 2. Fila 1: Información personal (68%) y Foto (32%)
            int anchoPersonal = (int)((anchoCards - gap) * 0.68f);
            int anchoFoto = anchoCards - gap - anchoPersonal;
            int altoRow1 = 290;

            cardPersonal.SetBounds(xCard, y, anchoPersonal, altoRow1);
            cardFoto.SetBounds(cardPersonal.Right + gap, y, anchoFoto, altoRow1);

            // Controles dentro de cardPersonal
            lblIconoPersonal.SetBounds(14, 12, 34, 34);
            lblTituloPersonal.Location = new Point(54, 10);
            lblSubtituloPersonal.Location = new Point(56, 30);

            int margenP = 16;
            int gapColP = 14;
            int anchoColP = (cardPersonal.Width - (margenP * 2) - gapColP) / 2;
            int xP1 = margenP;
            int xP2 = margenP + anchoColP + gapColP;

            // Fila 1: Primer nombre | Segundo nombre
            lblPrimerNombre.Location = new Point(xP1, 56);
            txtPrimerNombre.SetBounds(xP1, 74, anchoColP, 27);
            lblSegundoNombre.Location = new Point(xP2, 56);
            txtSegundoNombre.SetBounds(xP2, 74, anchoColP, 27);

            // Fila 2: Primer apellido | Segundo apellido
            lblPrimerApellido.Location = new Point(xP1, 108);
            txtPrimerApellido.SetBounds(xP1, 126, anchoColP, 27);
            lblSegundoApellido.Location = new Point(xP2, 108);
            txtSegundoApellido.SetBounds(xP2, 126, anchoColP, 27);

            // Fila 3: Cédula | Teléfono
            lblCedula.Location = new Point(xP1, 160);
            txtCedula.SetBounds(xP1, 178, anchoColP, 27);

            lblTelefono.Location = new Point(xP2, 160);
            int anchoComboP = Math.Min(170, Math.Max(140, (int)(anchoColP * 0.50f)));
            int anchoNumeroP = anchoColP - anchoComboP - 8;
            cmbPaisTelefono.SetBounds(xP2, 178, anchoComboP, 27);
            txtTelefono.SetBounds(cmbPaisTelefono.Right + 8, 178, anchoNumeroP, 27);

            // Fila 4: Ayudas y banner informativo
            lblCedulaAyuda.Location = new Point(xP1, 208);
            pnlCedulaInfo.SetBounds(xP1, 226, anchoColP, 48);
            lblCedulaInfo.SetBounds(6, 4, pnlCedulaInfo.Width - 12, 40);

            lblTelefonoAyuda.SetBounds(xP2, 208, anchoColP, 66);

            // Controles dentro de cardFoto
            lblIconoFoto.SetBounds(14, 12, 34, 34);
            lblTituloFoto.Location = new Point(54, 10);
            lblSubtituloFoto.Location = new Point(56, 30);

            int sAvatar = 82;
            picPreview.SetBounds(16, 56, sAvatar, sAvatar);

            int xInfoFoto = picPreview.Right + 12;
            int anchoInfoFoto = cardFoto.Width - xInfoFoto - 14;
            int anchoBtnSelFoto = Math.Min(140, anchoInfoFoto);
            btnSeleccionarFoto.SetBounds(xInfoFoto, 56, anchoBtnSelFoto, 30);
            btnQuitarFoto.SetBounds(btnSeleccionarFoto.Right + 6, 56, Math.Min(65, anchoInfoFoto - anchoBtnSelFoto - 6), 30);

            lblFoto.SetBounds(xInfoFoto, 92, anchoInfoFoto, 16);
            lblFotoAyuda.SetBounds(xInfoFoto, 112, anchoInfoFoto, 16);

            pnlFotoInfo.SetBounds(16, 226, cardFoto.Width - 32, 48);
            lblFotoInfo.SetBounds(6, 4, pnlFotoInfo.Width - 12, 40);

            y += altoRow1 + gap;

            // 3. Fila 2: Información profesional
            int altoRow2 = 215;
            cardProfesional.SetBounds(xCard, y, anchoCards, altoRow2);

            lblIconoProfesional.SetBounds(14, 12, 34, 34);
            lblTituloProfesional.Location = new Point(54, 10);
            lblSubtituloProfesional.Location = new Point(56, 30);

            int margenProf = 16;
            int gapProf = 16;
            int anchoColProf1 = (int)((cardProfesional.Width - (margenProf * 2) - gapProf) * 0.44f);
            int anchoColProf2 = cardProfesional.Width - (margenProf * 2) - gapProf - anchoColProf1;
            int xProf1 = margenProf;
            int xProf2 = margenProf + anchoColProf1 + gapProf;

            lblNumeroLicencia.Location = new Point(xProf1, 56);
            txtLicencia.SetBounds(xProf1, 74, anchoColProf1, 27);
            lblLicenciaAyuda.SetBounds(xProf1, 104, anchoColProf1, 32);
            pnlLicenciaInfo.SetBounds(xProf1, 142, anchoColProf1, 48);
            lblLicenciaInfo.SetBounds(6, 4, pnlLicenciaInfo.Width - 12, 40);

            lblEspecialidadesTitulo.Location = new Point(xProf2, 56);
            lstEspecialidades.SetBounds(xProf2, 74, anchoColProf2, 126);

            y += altoRow2 + gap;

            // 4. Fila 3: Asignaciones hospitalarias
            int altoRow3 = 230;
            cardAsignaciones.SetBounds(xCard, y, anchoCards, altoRow3);

            lblIconoAsignaciones.SetBounds(14, 12, 34, 34);
            lblTituloAsignaciones.Location = new Point(54, 10);
            lblSubtituloAsignaciones.Location = new Point(56, 30);

            int margenAsign = 16;
            int gapAsign = 12;
            int anchoBtnAgregar = 100;
            int anchoCombos = (cardAsignaciones.Width - (margenAsign * 2) - (gapAsign * 2) - anchoBtnAgregar) / 2;
            int xHosp = margenAsign;
            int xEsp = xHosp + anchoCombos + gapAsign;
            int xBtn = xEsp + anchoCombos + gapAsign;

            lblHospitalTitulo.Location = new Point(xHosp, 56);
            cmbHospitalAsignacion.SetBounds(xHosp, 74, anchoCombos, 28);

            lblEspecialidadHospTitulo.Location = new Point(xEsp, 56);
            cmbEspecialidadHospital.SetBounds(xEsp, 74, anchoCombos, 28);

            btnAgregarAsignacion.SetBounds(xBtn, 73, anchoBtnAgregar, 30);

            lblAsignacionesTitulo.Location = new Point(margenAsign, 110);
            int anchoBtnQuitar = 95;
            int anchoListaAsign = cardAsignaciones.Width - (margenAsign * 2) - gapAsign - anchoBtnQuitar;
            lstAsignaciones.SetBounds(margenAsign, 132, anchoListaAsign, 80);
            btnQuitarAsignacion.SetBounds(lstAsignaciones.Right + gapAsign, 132, anchoBtnQuitar, 32);

            AjustarAnchoDropDown(cmbHospitalAsignacion);
            AjustarAnchoDropDown(cmbEspecialidadHospital);

            y += altoRow3 + gap;

            // 5. Fila 4: Botones de Acción (Cancelar y Guardar)
            panelAcciones.SetBounds(xCard, y, anchoCards, 46);
            btnGuardar.SetBounds(panelAcciones.Width - 190, 3, 190, 40);
            btnCancelar.SetBounds(btnGuardar.Left - 12 - 130, 3, 130, 40);
        }

        // ============================================================
        // PINTADO ESTÉTICO GDI+
        // ============================================================
        private void DibujarBordeTarjeta(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            if (c == null) return;
            Tema.DibujarTarjetaRedondeada(e.Graphics, new Rectangle(0, 0, c.Width - 1, c.Height - 1), Tema.Superficie, Tema.Borde, 8);
        }

        private void DibujarBannerInformativo(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            if (c == null) return;
            Tema.DibujarTarjetaRedondeada(e.Graphics, new Rectangle(0, 0, c.Width - 1, c.Height - 1), Color.FromArgb(235, 245, 252), Color.FromArgb(205, 227, 245), 6);
        }

        private void DibujarIconoCircular(object sender, PaintEventArgs e, string icono)
        {
            Control c = sender as Control;
            if (c == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(c.Parent?.BackColor ?? Tema.Superficie);
            using (Brush br = new SolidBrush(Tema.AzulPrimario))
            {
                e.Graphics.FillEllipse(br, 1, 1, c.Width - 3, c.Height - 3);
            }
            using (Font f = new Font("Segoe UI Emoji", 11.5F))
            using (Brush brText = new SolidBrush(Color.White))
            {
                SizeF sf = e.Graphics.MeasureString(icono, f);
                e.Graphics.DrawString(icono, f, brText, (c.Width - sf.Width) / 2 + 1, (c.Height - sf.Height) / 2);
            }
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int s = Math.Min(picPreview.Width, picPreview.Height) - 4;
            int x = (picPreview.Width - s) / 2;
            int y = (picPreview.Height - s) / 2;
            Rectangle rectCirculo = new Rectangle(x, y, s, s);

            if (picPreview.Image == null)
            {
                using (Brush br = new SolidBrush(Tema.FondoSecundario))
                {
                    e.Graphics.FillEllipse(br, rectCirculo);
                }
                using (Brush brIcon = new SolidBrush(Color.FromArgb(160, 185, 198)))
                {
                    int rHead = s / 3;
                    e.Graphics.FillEllipse(brIcon, x + (s - rHead) / 2, y + (int)(s * 0.18f), rHead, rHead);
                    int wBody = (int)(s * 0.65f);
                    int hBody = (int)(s * 0.40f);
                    e.Graphics.FillPie(brIcon, x + (s - wBody) / 2, y + (int)(s * 0.48f), wBody, hBody * 2, 180, 180);
                }
                int badgeSize = 24;
                int bx = x + s - badgeSize - 2;
                int by = y + s - badgeSize - 2;
                using (Brush brBadge = new SolidBrush(Tema.AzulPrimario))
                {
                    e.Graphics.FillEllipse(brBadge, bx, by, badgeSize, badgeSize);
                }
                using (Font fCamera = new Font("Segoe UI Emoji", 9F))
                using (Brush brWhite = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString("📷", fCamera, brWhite, bx + 3, by + 3);
                }
            }
            else
            {
                using (GraphicsPath clip = new GraphicsPath())
                {
                    clip.AddEllipse(rectCirculo);
                    e.Graphics.SetClip(clip);
                    e.Graphics.DrawImage(picPreview.Image, rectCirculo);
                    e.Graphics.ResetClip();
                }
                using (Pen pen = new Pen(Tema.Borde, 2f))
                {
                    e.Graphics.DrawEllipse(pen, rectCirculo);
                }
            }
        }

        private void panelHero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelHero.Width;
            int h = panelHero.Height;

            // Altura del área del paisaje en la parte inferior del Hero
            int altoPaisaje = Math.Max(220, (int)(h * 0.35f));
            int yInicio = h - altoPaisaje;

            // Cielo suave en degradé
            using (LinearGradientBrush brCielo = new LinearGradientBrush(
                new Rectangle(0, yInicio - 30, w, 50),
                Tema.Fondo,
                Color.FromArgb(215, 238, 248),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brCielo, 0, yInicio - 30, w, 50);
            }

            // Colina lejana (azul-verdoso suave)
            using (GraphicsPath pathMontanas = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, yInicio + 25);
                Point p3 = new Point((int)(w * 0.35f), yInicio - 12);
                Point p4 = new Point((int)(w * 0.65f), yInicio + 30);
                Point p5 = new Point(w, yInicio + 5);
                Point p6 = new Point(w, h);

                pathMontanas.AddLine(p1, p2);
                pathMontanas.AddBezier(p2, p3, p4, p5);
                pathMontanas.AddLine(p5, p6);
                pathMontanas.CloseFigure();
                using (SolidBrush brMontanas = new SolidBrush(Color.FromArgb(168, 209, 185)))
                {
                    e.Graphics.FillPath(brMontanas, pathMontanas);
                }
            }

            // Colina media (verde naturaleza)
            using (GraphicsPath pathColinaMedia = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, yInicio + 55);
                Point p3 = new Point((int)(w * 0.40f), yInicio + 20);
                Point p4 = new Point((int)(w * 0.75f), yInicio + 65);
                Point p5 = new Point(w, yInicio + 40);
                Point p6 = new Point(w, h);

                pathColinaMedia.AddLine(p1, p2);
                pathColinaMedia.AddBezier(p2, p3, p4, p5);
                pathColinaMedia.AddLine(p5, p6);
                pathColinaMedia.CloseFigure();
                using (SolidBrush brColinaMedia = new SolidBrush(Tema.Verde))
                {
                    e.Graphics.FillPath(brColinaMedia, pathColinaMedia);
                }
            }

            // Casita rural sobre la colina media
            int xCasa = (int)(w * 0.16f);
            int yCasa = yInicio + 55;
            using (SolidBrush brPared = new SolidBrush(Color.FromArgb(250, 248, 240)))
            using (Pen penPared = new Pen(Color.FromArgb(180, 170, 150), 1f))
            {
                e.Graphics.FillRectangle(brPared, xCasa, yCasa, 26, 17);
                e.Graphics.DrawRectangle(penPared, xCasa, yCasa, 26, 17);
            }
            using (SolidBrush brTecho = new SolidBrush(Color.FromArgb(195, 95, 75)))
            {
                Point[] puntosTecho = new Point[]
                {
                    new Point(xCasa - 2, yCasa),
                    new Point(xCasa + 13, yCasa - 11),
                    new Point(xCasa + 28, yCasa)
                };
                e.Graphics.FillPolygon(brTecho, puntosTecho);
            }
            using (SolidBrush brPuerta = new SolidBrush(Color.FromArgb(140, 75, 45)))
            {
                e.Graphics.FillRectangle(brPuerta, xCasa + 9, yCasa + 6, 7, 11);
            }

            // Arbolitos rurales
            DibujarArbolito(e.Graphics, (int)(w * 0.08f), yInicio + 50, 14, 22);
            DibujarArbolito(e.Graphics, (int)(w * 0.32f), yInicio + 42, 16, 26);
            DibujarArbolito(e.Graphics, (int)(w * 0.68f), yInicio + 54, 18, 28);
            DibujarArbolito(e.Graphics, (int)(w * 0.85f), yInicio + 46, 14, 24);

            // Colina frontal ondulada (verde oscuro)
            using (GraphicsPath pathColinaFrontal = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, yInicio + 95);
                Point p3 = new Point((int)(w * 0.30f), yInicio + 120);
                Point p4 = new Point((int)(w * 0.65f), yInicio + 85);
                Point p5 = new Point(w, yInicio + 105);
                Point p6 = new Point(w, h);

                pathColinaFrontal.AddLine(p1, p2);
                pathColinaFrontal.AddBezier(p2, p3, p4, p5);
                pathColinaFrontal.AddLine(p5, p6);
                pathColinaFrontal.CloseFigure();
                using (SolidBrush brColinaFrontal = new SolidBrush(Tema.VerdeOscuro))
                {
                    e.Graphics.FillPath(brColinaFrontal, pathColinaFrontal);
                }
            }

            // Olas decorativas transparentes en la base inferior
            using (GraphicsPath pathOlaTeal = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, h - 30);
                Point p3 = new Point((int)(w * 0.35f), h - 10);
                Point p4 = new Point((int)(w * 0.70f), h - 45);
                Point p5 = new Point(w, h - 20);
                Point p6 = new Point(w, h);

                pathOlaTeal.AddLine(p1, p2);
                pathOlaTeal.AddBezier(p2, p3, p4, p5);
                pathOlaTeal.AddLine(p5, p6);
                pathOlaTeal.CloseFigure();
                using (SolidBrush brOlaTeal = new SolidBrush(Color.FromArgb(80, 165, 215, 215)))
                {
                    e.Graphics.FillPath(brOlaTeal, pathOlaTeal);
                }
            }
        }

        private static void DibujarArbolito(Graphics g, int x, int y, int ancho, int alto)
        {
            using (SolidBrush brTronco = new SolidBrush(Color.FromArgb(120, 80, 50)))
            {
                g.FillRectangle(brTronco, x + (ancho / 2) - 2, y + (alto / 2), 4, alto / 2);
            }
            using (SolidBrush brCopa = new SolidBrush(Tema.VerdeOscuro))
            {
                g.FillEllipse(brCopa, x, y, ancho, alto * 3 / 4);
            }
        }

        private void panelLema_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Tema.DibujarTarjetaRedondeada(e.Graphics, new Rectangle(0, 0, panelLema.Width - 1, panelLema.Height - 1), Tema.Superficie, Tema.Borde, 8);
        }

        // ============================================================
        // CARGA DE CATÁLOGOS Y DATOS
        // ============================================================
        private void CargarCatalogos()
        {
            especialidadesDisponibles = controladorDoctores.listarEspecialidades();
            hospitalesDisponibles = controladorDoctores.listarHospitales();

            lstEspecialidades.DataSource = especialidadesDisponibles;
            lstEspecialidades.DisplayMember = "Nombre";
            lstEspecialidades.ValueMember = "IdEspecialidad";

            cmbHospitalAsignacion.DataSource = hospitalesDisponibles;
            cmbHospitalAsignacion.DisplayMember = "Nombre";
            cmbHospitalAsignacion.ValueMember = "IdHospital";
            cmbHospitalAsignacion.SelectedIndex = -1;

            cmbEspecialidadHospital.DataSource = especialidadesDisponibles.ToList();
            cmbEspecialidadHospital.DisplayMember = "Nombre";
            cmbEspecialidadHospital.ValueMember = "IdEspecialidad";
            cmbEspecialidadHospital.SelectedIndex = -1;

            AjustarAnchoDropDown(cmbHospitalAsignacion);
            AjustarAnchoDropDown(cmbEspecialidadHospital);
        }

        private void CargarDoctor()
        {
            var doctor = controladorDoctores.consultarDoctorPorId(idDoctorEdicion);
            if (doctor == null)
            {
                MessageBox.Show("No se encontró el doctor seleccionado.", "Doctor no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtPrimerNombre.Text = doctor.PrimerNombre;
            txtSegundoNombre.Text = doctor.SegundoNombre;
            txtPrimerApellido.Text = doctor.PrimerApellido;
            txtSegundoApellido.Text = doctor.SegundoApellido;

            // Formatear cédula si corresponde al estándar tradicional, preservando el valor original
            if (EsCedulaTradicional(doctor.Cedula, out string cedulaFormateada))
            {
                txtCedula.Text = cedulaFormateada;
            }
            else
            {
                txtCedula.Text = doctor.Cedula;
            }

            // Identificar prefijo internacional de país y asignar número nacional separado
            CargarTelefonoDoctor(doctor.Telefono);

            // Cargar código sanitario o registro MINSA tal como está registrado
            txtLicencia.Text = doctor.NumeroLicencia;

            foreach (var doctorEspecialidad in doctor.DoctorEspecialidad)
            {
                int indice = especialidadesDisponibles.FindIndex(e => e.IdEspecialidad == doctorEspecialidad.IdEspecialidad);
                if (indice >= 0)
                {
                    lstEspecialidades.SetItemChecked(indice, true);
                }

                foreach (var asignacion in doctorEspecialidad.DoctorHospitalEspecialidad)
                {
                    AgregarAsignacion(asignacion.IdHospital, asignacion.IdEspecialidad);
                }
            }

            foto = doctor.Foto;
            fotoNombre = doctor.FotoNombre;
            fotoMimeType = doctor.FotoMimeType;

            if (foto != null && foto.Length > 0)
            {
                MostrarPreviewDesdeBytes(foto);
                lblFoto.Text = fotoNombre ?? "Foto cargada";
                btnQuitarFoto.Visible = true;
            }
            else
            {
                lblFoto.Text = "Sin foto seleccionada";
                btnQuitarFoto.Visible = false;
            }
            picPreview.Invalidate();
        }

        // ============================================================
        // GESTIÓN DE FOTOGRAFÍA
        // ============================================================
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (var selector = new OpenFileDialog())
            {
                selector.Title = "Seleccionar foto del doctor";
                selector.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (selector.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var infoArchivo = new FileInfo(selector.FileName);
                if (infoArchivo.Length > 2 * 1024 * 1024)
                {
                    MessageBox.Show(
                        "El archivo seleccionado excede el tamaño máximo permitido de 2 MB.\nPor favor, seleccione una imagen más liviana.",
                        "Tamaño excedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                byte[] bytesArchivo;
                try
                {
                    bytesArchivo = File.ReadAllBytes(selector.FileName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        "No se pudo leer el archivo seleccionado.\n\n" + ex.Message,
                        "Error de lectura",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                Image imagenCargada;
                try
                {
                    using (var stream = new MemoryStream(bytesArchivo))
                    {
                        using (var temporal = Image.FromStream(stream))
                        {
                            imagenCargada = new Bitmap(temporal);
                        }
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(
                        "El archivo seleccionado no es una imagen válida.\nFormatos permitidos: JPG, PNG, BMP.",
                        "Imagen no válida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                LimpiarPreview();

                foto = bytesArchivo;
                fotoNombre = Path.GetFileName(selector.FileName);
                fotoMimeType = GetMimeType(selector.FileName);
                fotoEliminadaExplicita = false;

                picPreview.Image = imagenCargada;
                lblFoto.Text = fotoNombre;
                btnQuitarFoto.Visible = true;
                picPreview.Invalidate();
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            LimpiarPreview();
            foto = null;
            fotoNombre = null;
            fotoMimeType = null;
            fotoEliminadaExplicita = true;
            lblFoto.Text = "Sin foto seleccionada";
            btnQuitarFoto.Visible = false;
            picPreview.Invalidate();
        }

        private void MostrarPreviewDesdeBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return;

            try
            {
                Image imagenNueva;
                using (var stream = new MemoryStream(bytes))
                {
                    using (var temporal = Image.FromStream(stream))
                    {
                        imagenNueva = new Bitmap(temporal);
                    }
                }

                LimpiarPreview();
                picPreview.Image = imagenNueva;
                picPreview.Invalidate();
            }
            catch (ArgumentException)
            {
                // Silencioso si los bytes no corresponden a un formato válido
            }
        }

        private void LimpiarPreview()
        {
            if (picPreview.Image != null)
            {
                var imagenAnterior = picPreview.Image;
                picPreview.Image = null;
                imagenAnterior.Dispose();
            }
        }

        private string GetMimeType(string ruta)
        {
            switch (Path.GetExtension(ruta).ToLowerInvariant())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream";
            }
        }

        // ============================================================
        // ASIGNACIONES HOSPITALARIAS
        // ============================================================
        private void btnAgregarAsignacion_Click(object sender, EventArgs e)
        {
            if (cmbHospitalAsignacion.SelectedValue == null || cmbEspecialidadHospital.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un hospital y una especialidad.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspecialidad = Convert.ToInt32(cmbEspecialidadHospital.SelectedValue);
            bool especialidadSeleccionada = lstEspecialidades.CheckedItems
                .Cast<Especialidades>()
                .Any(especialidad => especialidad.IdEspecialidad == idEspecialidad);

            if (!especialidadSeleccionada)
            {
                MessageBox.Show("Marque primero esa especialidad en la lista de especialidades del doctor.", "Especialidad no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarAsignacion(Convert.ToInt32(cmbHospitalAsignacion.SelectedValue), idEspecialidad);
        }

        private void AgregarAsignacion(int idHospital, int idEspecialidad)
        {
            if (asignaciones.Any(a => a.Item1 == idHospital && a.Item2 == idEspecialidad))
                return;

            asignaciones.Add(Tuple.Create(idHospital, idEspecialidad));
            lstAsignaciones.Items.Add(FormatearAsignacion(idHospital, idEspecialidad));
        }

        private string FormatearAsignacion(int idHospital, int idEspecialidad)
        {
            string hospital = hospitalesDisponibles.FirstOrDefault(h => h.IdHospital == idHospital)?.Nombre ?? "Hospital";
            string especialidad = especialidadesDisponibles.FirstOrDefault(e => e.IdEspecialidad == idEspecialidad)?.Nombre ?? "Especialidad";
            return hospital + " — " + especialidad;
        }

        private void btnQuitarAsignacion_Click(object sender, EventArgs e)
        {
            int indice = lstAsignaciones.SelectedIndex;
            if (indice >= 0)
            {
                asignaciones.RemoveAt(indice);
                lstAsignaciones.Items.RemoveAt(indice);
                btnQuitarAsignacion.Enabled = lstAsignaciones.SelectedIndex >= 0;
            }
        }

        // ============================================================
        // MÉTODOS AUXILIARES: CÉDULA NICARAGÜENSE
        // ============================================================
        private static bool EsCedulaTradicional(string texto, out string cedulaFormateada)
        {
            cedulaFormateada = null;
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            string limpio = texto.Replace("-", "").Replace(" ", "").Trim();

            // Formato tradicional nicaragüense: 13 dígitos y 1 letra final
            if (limpio.Length == 14 && Regex.IsMatch(limpio, @"^\d{13}[a-zA-Z]$"))
            {
                string dpto = limpio.Substring(0, 3);
                string fecha = limpio.Substring(3, 6);
                string consecutivo = limpio.Substring(9, 4);
                char letra = char.ToUpperInvariant(limpio[13]);
                cedulaFormateada = $"{dpto}-{fecha}-{consecutivo}{letra}";
                return true;
            }

            return false;
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (formateandoCedula) return;

            string actual = txtCedula.Text;
            if (string.IsNullOrEmpty(actual)) return;

            // Formatear inmediatamente si se completaron los 14 caracteres tradicionales o al pegar
            if (EsCedulaTradicional(actual, out string formateada))
            {
                if (actual != formateada)
                {
                    formateandoCedula = true;
                    txtCedula.Text = formateada;
                    txtCedula.SelectionStart = formateada.Length;
                    formateandoCedula = false;
                }
                return;
            }

            // Convertir letra minúscula a mayúscula al final sin desplazar el cursor incómodamente
            if (actual.Length > 0 && char.IsLower(actual[actual.Length - 1]))
            {
                formateandoCedula = true;
                int posicion = txtCedula.SelectionStart;
                txtCedula.Text = actual.Substring(0, actual.Length - 1) + char.ToUpperInvariant(actual[actual.Length - 1]);
                txtCedula.SelectionStart = posicion;
                formateandoCedula = false;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '-' && txtCedula.Text.EndsWith("-"))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            string texto = txtCedula.Text.Trim();
            if (EsCedulaTradicional(texto, out string formateada))
            {
                txtCedula.Text = formateada;
            }
        }

        private static bool ValidarIdentificadorCedula(string cedula, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (string.IsNullOrWhiteSpace(cedula))
            {
                mensajeError = "Ingrese el número de cédula del doctor.";
                return false;
            }

            string limpio = cedula.Replace("-", "").Replace(" ", "").Trim();

            // Si coincide con la longitud tradicional de 14 caracteres
            if (limpio.Length == 14)
            {
                if (!Regex.IsMatch(limpio, @"^\d{13}[a-zA-Z]$"))
                {
                    mensajeError = "La cédula en formato tradicional debe contener 13 dígitos y una letra final (Ejemplo: 001-091101-1042V).";
                    return false;
                }
                return true;
            }

            // Si es emitido bajo otro formato válido (p. ej. nuevo formato CSE 2026 o alfanumérico)
            if (cedula.Length < 6 || cedula.Length > 20 || !Regex.IsMatch(cedula, @"^[a-zA-Z0-9\-]+$"))
            {
                mensajeError = "El número de cédula ingresado no es válido. Debe tener entre 6 y 20 caracteres alfanuméricos.";
                return false;
            }

            return true;
        }

        // ============================================================
        // MÉTODOS AUXILIARES: TELÉFONO Y PREFIJOS INTERNACIONALES
        // ============================================================
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string texto = txtTelefono.Text;
            if (string.IsNullOrWhiteSpace(texto)) return;

            string textoLimpio = texto.Trim();

            foreach (var pais in PaisesCentroamerica)
            {
                if (textoLimpio.StartsWith(pais.Codigo))
                {
                    cmbPaisTelefono.SelectedItem = pais;
                    string restante = textoLimpio.Substring(pais.Codigo.Length).Trim();
                    txtTelefono.Text = restante;
                    txtTelefono.SelectionStart = txtTelefono.Text.Length;
                    return;
                }

                string codigoSinMas = pais.Codigo.Replace("+", "");
                if (textoLimpio.StartsWith(codigoSinMas) && textoLimpio.Length > codigoSinMas.Length + 4)
                {
                    cmbPaisTelefono.SelectedItem = pais;
                    string restante = textoLimpio.Substring(codigoSinMas.Length).Trim();
                    txtTelefono.Text = restante;
                    txtTelefono.SelectionStart = txtTelefono.Text.Length;
                    return;
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void CargarTelefonoDoctor(string telefonoGuardado)
        {
            if (string.IsNullOrWhiteSpace(telefonoGuardado))
            {
                cmbPaisTelefono.SelectedItem = PaisesCentroamerica.FirstOrDefault(p => p.Codigo == "+505");
                txtTelefono.Clear();
                return;
            }

            string t = telefonoGuardado.Trim();
            bool identificado = false;

            foreach (var pais in PaisesCentroamerica)
            {
                if (t.StartsWith(pais.Codigo))
                {
                    cmbPaisTelefono.SelectedItem = pais;
                    txtTelefono.Text = t.Substring(pais.Codigo.Length).Trim();
                    identificado = true;
                    break;
                }

                string codigoSinMas = pais.Codigo.Replace("+", "");
                if (t.StartsWith(codigoSinMas) && t.Length > codigoSinMas.Length + 4)
                {
                    cmbPaisTelefono.SelectedItem = pais;
                    txtTelefono.Text = t.Substring(codigoSinMas.Length).Trim();
                    identificado = true;
                    break;
                }
            }

            if (!identificado)
            {
                // Si el formato histórico no coincide con certeza, no descartar información:
                // mostrar el valor completo para permitir su corrección explícita.
                cmbPaisTelefono.SelectedItem = PaisesCentroamerica.FirstOrDefault(p => p.Codigo == "+505");
                txtTelefono.Text = t;
            }
        }

        private bool ObtenerTelefonoCombinado(out string telefonoResultado, out string mensajeError)
        {
            telefonoResultado = null;
            mensajeError = string.Empty;

            string numeroNacional = txtTelefono.Text.Trim();
            if (string.IsNullOrEmpty(numeroNacional))
            {
                telefonoResultado = string.Empty;
                return true;
            }

            var pais = cmbPaisTelefono.SelectedItem as PaisTelefonoItem;
            if (pais == null)
            {
                pais = PaisesCentroamerica.First(p => p.Codigo == "+505");
            }

            string soloDigitos = Regex.Replace(numeroNacional, @"\D", "");
            if (soloDigitos.Length < pais.LongitudMinima || soloDigitos.Length > pais.LongitudMaxima)
            {
                string rango = pais.LongitudMinima == pais.LongitudMaxima
                    ? $"{pais.LongitudMinima} dígitos"
                    : $"{pais.LongitudMinima} a {pais.LongitudMaxima} dígitos";
                mensajeError = $"El número de teléfono para {pais.Nombre} debe contener {rango} (sin incluir el prefijo {pais.Codigo}).";
                return false;
            }

            string nacionalFormateado;
            if (soloDigitos.Length == 8)
            {
                nacionalFormateado = $"{soloDigitos.Substring(0, 4)}-{soloDigitos.Substring(4, 4)}";
            }
            else if (soloDigitos.Length == 7)
            {
                nacionalFormateado = $"{soloDigitos.Substring(0, 3)}-{soloDigitos.Substring(3, 4)}";
            }
            else
            {
                nacionalFormateado = soloDigitos;
            }

            telefonoResultado = $"{pais.Codigo} {nacionalFormateado}";
            return true;
        }

        // ============================================================
        // MÉTODOS AUXILIARES: COMBOBOX AUTO-DIMENSIONADO
        // ============================================================
        private static void AjustarAnchoDropDown(ComboBox combo)
        {
            if (combo == null || combo.Items.Count == 0) return;

            int maxAncho = combo.Width;
            using (Graphics g = combo.CreateGraphics())
            {
                int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
                foreach (var item in combo.Items)
                {
                    string texto = combo.GetItemText(item);
                    int anchoItem = (int)g.MeasureString(texto, combo.Font).Width + scrollbarWidth + 24;
                    if (anchoItem > maxAncho)
                        maxAncho = anchoItem;
                }
            }
            combo.DropDownWidth = maxAncho;
        }

        // ============================================================
        // GUARDAR / EDITAR DOCTOR
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string primerNombre = txtPrimerNombre.Text.Trim();
            string primerApellido = txtPrimerApellido.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string numeroLicencia = txtLicencia.Text.Trim();
            var idEspecialidades = lstEspecialidades.CheckedItems
                .Cast<Especialidades>()
                .Select(especialidad => especialidad.IdEspecialidad)
                .ToList();
            var asignacionesSeleccionadas = asignaciones
                .Where(asignacion => idEspecialidades.Contains(asignacion.Item2))
                .ToList();

            if (string.IsNullOrWhiteSpace(primerNombre) || string.IsNullOrWhiteSpace(primerApellido))
            {
                MessageBox.Show("Complete el primer nombre y el primer apellido.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrWhiteSpace(primerNombre)) txtPrimerNombre.Focus(); else txtPrimerApellido.Focus();
                return;
            }

            if (!ValidarIdentificadorCedula(cedula, out string mensajeErrorCedula))
            {
                MessageBox.Show(mensajeErrorCedula, "Cédula no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            // Si es formato tradicional, asegurar presentación normalizada con guiones
            if (EsCedulaTradicional(cedula, out string cedulaNormalizada))
            {
                cedula = cedulaNormalizada;
                txtCedula.Text = cedulaNormalizada;
            }

            if (string.IsNullOrWhiteSpace(numeroLicencia))
            {
                MessageBox.Show("Complete el código sanitario / registro MINSA.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicencia.Focus();
                return;
            }

            if (!ObtenerTelefonoCombinado(out string telefonoFinal, out string mensajeErrorTelefono))
            {
                MessageBox.Show(mensajeErrorTelefono, "Teléfono no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (idEspecialidades.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una especialidad para el doctor.", "Especialidad requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstEspecialidades.Focus();
                return;
            }

            if (asignacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("Asigne el doctor al menos a un hospital.", "Hospital requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHospitalAsignacion.Focus();
                return;
            }

            if (controladorDoctores.existeCedula(cedula, esModoEdicion ? (int?)idDoctorEdicion : null))
            {
                MessageBox.Show("Ya existe un doctor registrado con el número de cédula ingresado.", "Cédula duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            if (controladorDoctores.existeNumeroLicencia(numeroLicencia, esModoEdicion ? (int?)idDoctorEdicion : null))
            {
                MessageBox.Show("Ya existe un doctor registrado con el código sanitario / registro MINSA ingresado.", "Registro duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicencia.Focus();
                return;
            }

            try
            {
                if (esModoEdicion)
                {
                    controladorDoctores.editarDoctor(
                        idDoctorEdicion,
                        primerNombre,
                        txtSegundoNombre.Text.Trim(),
                        primerApellido,
                        txtSegundoApellido.Text.Trim(),
                        cedula,
                        numeroLicencia,
                        telefonoFinal,
                        foto,
                        fotoNombre,
                        fotoMimeType,
                        fotoEliminadaExplicita,
                        idEspecialidades,
                        asignacionesSeleccionadas
                    );
                }
                else
                {
                    controladorDoctores.crearDoctor(
                        idUsuario,
                        primerNombre,
                        txtSegundoNombre.Text.Trim(),
                        primerApellido,
                        txtSegundoApellido.Text.Trim(),
                        cedula,
                        numeroLicencia,
                        telefonoFinal,
                        foto,
                        fotoNombre,
                        fotoMimeType,
                        idEspecialidades,
                        asignacionesSeleccionadas
                    );
                }

                MessageBox.Show(
                    esModoEdicion ? "¡Doctor modificado con éxito!" : "¡Doctor registrado con éxito!",
                    esModoEdicion ? "Registro Actualizado" : "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al guardar doctor: " + ex);
                MessageBox.Show(
                    "Ocurrió un error al procesar el guardado del doctor. Por favor, intente nuevamente o contacte al administrador si el problema persiste.",
                    "Error al Guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CANCELAR Y RETORNO
        // ============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
