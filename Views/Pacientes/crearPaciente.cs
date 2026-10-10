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
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views
{
    /// <summary>
    /// Formulario para el registro y edición de pacientes.
    /// Incorpora diseño modular por tarjetas independientes, panel Hero institucional,
    /// cascada geográfica, formateo ágil de cédula nicaragüense, teléfono internacional
    /// y gestión completa de contactos de emergencia.
    /// </summary>
    public partial class crearPaciente : Form
    {
        // ============================================================
        // CONTROLADORES Y ESTADO DE NEGOCIO
        // ============================================================
        private readonly pacientesControllers controlador = new pacientesControllers();
        private readonly List<ContactoEmergenciaDto> listaContactos = new List<ContactoEmergenciaDto>();

        private int? idUsuario;
        private int? idPacienteEditar;
        private bool esModoEdicion;
        private bool cargandoUbicacion;
        private bool formateandoCedula;

        private byte[] fotoBytes;
        private string fotoNombreArchivo;

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
        public crearPaciente()
        {
            InitializeComponent();
            ConfigurarOptimizacionesVisuales();
        }

        public crearPaciente(int idUsuarioRecibido) : this()
        {
            idUsuario = idUsuarioRecibido > 0 ? idUsuarioRecibido : (int?)null;
        }

        public crearPaciente(int idPaciente, bool modoEdicion) : this()
        {
            if (modoEdicion)
            {
                idPacienteEditar = idPaciente;
                esModoEdicion = true;
            }
        }

        private void ConfigurarOptimizacionesVisuales()
        {
            this.DoubleBuffered = true;
            HabilitarDobleBufer(panelHero);
            HabilitarDobleBufer(panelFormContenedor);
            HabilitarDobleBufer(cardHeader);
            HabilitarDobleBufer(cardPersonal);
            HabilitarDobleBufer(cardFoto);
            HabilitarDobleBufer(cardUbicacion);
            HabilitarDobleBufer(cardSalud);
            HabilitarDobleBufer(cardEmergencia);
            HabilitarDobleBufer(panelAcciones);
            HabilitarDobleBufer(panelLema);
            HabilitarDobleBufer(pnlCedulaInfo);
            HabilitarDobleBufer(pnlFotoInfo);
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
        private void crearPaciente_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            // Cargar logotipo institucional de Sanar Rural
            picLogoHero.Image = Tema.ObtenerLogo();

            ConfigurarEstilosVisuales();
            ConfigurarComportamientoControles();
            CargarDepartamentos();

            if (idPacienteEditar.HasValue || esModoEdicion)
            {
                CargarPacienteParaEditar();
            }
            else
            {
                ConfigurarModoCreacion();
                txtNombres.Focus();
            }

            AjustarLayoutPaciente();
            this.Resize += (s, ev) => AjustarLayoutPaciente();
        }

        private void ConfigurarEstilosVisuales()
        {
            // Dibujado de tarjetas redondeadas con bordes suaves
            panelHero.Paint += panelHero_Paint;
            cardHeader.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardHeader.Width - 1, cardHeader.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardPersonal.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardPersonal.Width - 1, cardPersonal.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardFoto.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardFoto.Width - 1, cardFoto.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardUbicacion.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardUbicacion.Width - 1, cardUbicacion.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardSalud.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardSalud.Width - 1, cardSalud.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardEmergencia.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardEmergencia.Width - 1, cardEmergencia.Height - 1), Tema.Superficie, Tema.Borde, 10);
            panelLema.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelLema.Width - 1, panelLema.Height - 1), Color.FromArgb(240, 249, 242), Color.FromArgb(190, 225, 202), 10);

            // Iconos circulares de encabezado
            lblIconoPaciente.Paint += (s, ev) => DibujarBadgeCircular(lblIconoPaciente, ev, "👤");
            lblIconoPersonal.Paint += (s, ev) => DibujarBadgeCircular(lblIconoPersonal, ev, "👤");
            lblIconoFoto.Paint += (s, ev) => DibujarBadgeCircular(lblIconoFoto, ev, "📷");
            lblIconoUbicacion.Paint += (s, ev) => DibujarBadgeCircular(lblIconoUbicacion, ev, "📍");
            lblIconoSalud.Paint += (s, ev) => DibujarBadgeCircular(lblIconoSalud, ev, "💓");
            lblIconoEmergencia.Paint += (s, ev) => DibujarBadgeCircular(lblIconoEmergencia, ev, "👥");

            // Avatar circular con previsualización GDI+
            picPreview.Paint += picPreview_Paint;

            // Tabla de contactos
            Tema.ConfigurarTabla(dgvContactos);
            dgvContactos.AutoGenerateColumns = false;
            colContQuitar.DefaultCellStyle.ForeColor = Tema.Error;

            // Microinteracciones de botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;
            btnSeleccionarFoto.MouseEnter += (s, ev) => btnSeleccionarFoto.BackColor = Tema.AzulOscuro;
            btnSeleccionarFoto.MouseLeave += (s, ev) => btnSeleccionarFoto.BackColor = Tema.AzulPrimario;
            btnAgregarContacto.MouseEnter += (s, ev) => btnAgregarContacto.BackColor = Tema.AzulOscuro;
            btnAgregarContacto.MouseLeave += (s, ev) => btnAgregarContacto.BackColor = Tema.AzulPrimario;
        }

        private void ConfigurarComportamientoControles()
        {
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            // Catálogo de países centroamericanos
            cmbPaisTelefono.DataSource = PaisesCentroamerica;
            cmbPaisTelefono.DisplayMember = "TextoMostrar";
            cmbPaisTelefono.ValueMember = "Codigo";
            cmbPaisTelefono.SelectedItem = PaisesCentroamerica.First(p => p.Codigo == "+505");

            // Configurar desplegables
            ConfigurarDropDown(cmbGenero);
            ConfigurarDropDown(cmbTipoSangre);
            ConfigurarDropDown(cmbDepartamento);
            ConfigurarDropDown(cmbMunicipio);
            ConfigurarDropDown(cmbComunidad);

            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;
            if (cmbTipoSangre.Items.Count > 0) cmbTipoSangre.SelectedIndex = 0;
            if (cmbContactoParentesco.Items.Count > 0) cmbContactoParentesco.SelectedIndex = 0;

            // Placeholders visuales
            AsignarPlaceholder(txtNombres, "Ej. María");
            AsignarPlaceholder(txtSegundoNombre, "Ej. José");
            AsignarPlaceholder(txtApellidos, "Ej. López");
            AsignarPlaceholder(txtSegundoApellido, "Ej. García");
            AsignarPlaceholder(txtCedula, "001-091101-1042V");
            AsignarPlaceholder(txtNumeroINSS, "1234567890123");
            AsignarPlaceholder(txtTelefono, "8765-4321");
            AsignarPlaceholder(txtDireccion, "Del parque central 2 cuadras al sur");
            AsignarPlaceholder(txtReferencia, "Ej. Casa color azul, frente a la escuela...");
            AsignarPlaceholder(txtAlergias, "Ninguna / Ej. Penicilina, mariscos, etc.");
            AsignarPlaceholder(txtAntecedentes, "Ej. Hipertensión, diabetes, asma, etc.");
            AsignarPlaceholder(txtContactoPrimerNombre, "Ej. Ana");
            AsignarPlaceholder(txtContactoPrimerApellido, "Ej. López");
            AsignarPlaceholder(txtContactoTelefono, "8765-0000");
            AsignarPlaceholder(txtContactoCedula, "001-010180-0001A");

            // Eventos de foto
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            btnQuitarFoto.Click += btnQuitarFoto_Click;

            // Formateo y validación de Cédula
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedula_KeyPress;

            // Navegación por teclado
            txtNombres.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtSegundoNombre.Focus(); ev.SuppressKeyPress = true; } };
            txtSegundoNombre.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtApellidos.Focus(); ev.SuppressKeyPress = true; } };
            txtApellidos.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtSegundoApellido.Focus(); ev.SuppressKeyPress = true; } };
            txtSegundoApellido.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtCedula.Focus(); ev.SuppressKeyPress = true; } };
            txtCedula.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtNumeroINSS.Focus(); ev.SuppressKeyPress = true; } };
            txtNumeroINSS.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { dtpFechaNacimiento.Focus(); ev.SuppressKeyPress = true; } };
            dtpFechaNacimiento.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { cmbGenero.Focus(); ev.SuppressKeyPress = true; } };
            cmbGenero.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { cmbPaisTelefono.Focus(); ev.SuppressKeyPress = true; } };
            cmbPaisTelefono.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtTelefono.Focus(); ev.SuppressKeyPress = true; } };
            txtTelefono.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { cmbDepartamento.Focus(); ev.SuppressKeyPress = true; } };

            this.CancelButton = btnCancelar;

            lblErrorNombres.Text = string.Empty;
            lblErrorTelefono.Text = string.Empty;
            lblErrorContacto.Text = string.Empty;

            RefrescarGridContactos();
        }

        private static void ConfigurarDropDown(ComboBox combo)
        {
            if (combo == null) return;
            combo.MaxDropDownItems = 8;
            combo.IntegralHeight = false;
        }

        private void ConfigurarModoCreacion()
        {
            Text = "Sanar Rural - Registro de Paciente";
            lblRegistroTituloHero.Text = "Registro de Paciente";
            lblTitulo.Text = "Datos del Paciente";
            lblSubtitulo.Text = "Completa la información requerida";
            btnGuardar.Text = "💾 Guardar Paciente";
            btnCancelar.Text = "✕ Cancelar";

            lblBadgeModo.Text = "+ Nuevo Paciente";
            lblBadgeModo.BackColor = Color.FromArgb(236, 248, 238);
            lblBadgeModo.ForeColor = Tema.VerdeOscuro;
            lblBadgeModo.Visible = true;
        }

        // ============================================================
        // LAYOUT RESPONSIVO Y DESCOMPRESIÓN VISUAL
        // ============================================================
        private void AjustarLayoutPaciente()
        {
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;

            int anchoTotal = ClientSize.Width;
            int altoTotal = ClientSize.Height;

            // 1. Proporción estricta: Hero 25% (280-360px), Formulario 75%
            int anchoHero = Math.Max(280, Math.Min(360, (int)(anchoTotal * 0.25f)));
            panelHero.SetBounds(0, 0, anchoHero, altoTotal);
            panelFormContenedor.SetBounds(anchoHero, 0, anchoTotal - anchoHero, altoTotal);

            // 2. Elementos del Hero
            int margenHero = 24;
            int anchoContenidoHero = anchoHero - (margenHero * 2);

            lblNombreHero.Width = anchoContenidoHero;
            lblSubtituloHero.Width = anchoContenidoHero;
            lblRegistroTituloHero.Width = anchoContenidoHero;
            lblDescripcionHero.Width = anchoContenidoHero;

            panelHeroBloque1.Width = anchoContenidoHero;
            lblHeroDesc1.Width = panelHeroBloque1.Width - lblHeroDesc1.Left - 5;
            panelHeroBloque2.Width = anchoContenidoHero;
            lblHeroDesc2.Width = panelHeroBloque2.Width - lblHeroDesc2.Left - 5;
            panelHeroBloque3.Width = anchoContenidoHero;
            lblHeroDesc3.Width = panelHeroBloque3.Width - lblHeroDesc3.Left - 5;
            panelHeroBloque4.Width = anchoContenidoHero;
            lblHeroDesc4.Width = panelHeroBloque4.Width - lblHeroDesc4.Left - 5;

            if (altoTotal >= 680)
            {
                panelLema.Visible = true;
                panelLema.Location = new Point(margenHero, altoTotal - panelLema.Height - 18);
                panelLema.Width = anchoContenidoHero;
                lblLemaTexto.Width = panelLema.Width - lblLemaTexto.Left - 36;
                lblLemaComillasCierre.Left = panelLema.Width - 32;
            }
            else
            {
                panelLema.Visible = false;
            }

            // 3. Tarjetas en el Formulario Derecho
            int margenLateral = 20;
            int scrollWidth = SystemInformation.VerticalScrollBarWidth;
            int anchoNeto = panelFormContenedor.ClientSize.Width;
            int anchoCards = Math.Max(660, anchoNeto - (margenLateral * 2) - scrollWidth);

            int xCard = margenLateral;
            int gap = 14;
            int y = 16;

            // Encabezado
            cardHeader.SetBounds(xCard, y, anchoCards, 66);
            lblIconoPaciente.SetBounds(16, 13, 40, 40);
            lblTitulo.Location = new Point(64, 11);
            lblSubtitulo.Location = new Point(66, 38);
            lblBadgeModo.Location = new Point(cardHeader.Width - lblBadgeModo.Width - 18, 18);
            y += cardHeader.Height + gap;

            // Fila 1: Información personal (100% de ancho disponible)
            int altoRow1 = 360;
            cardPersonal.SetBounds(xCard, y, anchoCards, altoRow1);
            cardFoto.Visible = false;

            AjustarControlesCardPersonal(cardPersonal.Width);
            y += altoRow1 + gap;

            // Fila 2: Ubicación y dirección (100%)
            int altoRow2 = 180;
            cardUbicacion.SetBounds(xCard, y, anchoCards, altoRow2);
            AjustarControlesCardUbicacion(cardUbicacion.Width);
            y += altoRow2 + gap;

            // Fila 3: Información de salud (49%) y Contactos de emergencia (51%)
            int anchoSalud = (int)((anchoCards - gap) * 0.49f);
            int anchoEmergencia = anchoCards - gap - anchoSalud;
            int altoRow3 = 330;

            cardSalud.SetBounds(xCard, y, anchoSalud, altoRow3);
            cardEmergencia.SetBounds(cardSalud.Right + gap, y, anchoEmergencia, altoRow3);

            AjustarControlesCardSalud(cardSalud.Width);
            AjustarControlesCardEmergencia(cardEmergencia.Width);
            y += altoRow3 + gap;

            // Barra de Acciones Inferior
            panelAcciones.SetBounds(xCard, y, anchoCards, 60);
            btnGuardar.Left = panelAcciones.Width - btnGuardar.Width - 8;
            btnCancelar.Left = btnGuardar.Left - btnCancelar.Width - 12;
        }

        private void AjustarControlesCardPersonal(int anchoCard)
        {
            int margenP = 16;
            int gapColP = 14;
            int anchoColP = (anchoCard - (margenP * 2) - gapColP) / 2;
            int xP1 = margenP;
            int xP2 = margenP + anchoColP + gapColP;

            // Fila 1: Nombres
            lblPrimerNombre.Location = new Point(xP1, 56);
            txtNombres.SetBounds(xP1, 74, anchoColP, 27);
            lblSegundoNombre.Location = new Point(xP2, 56);
            txtSegundoNombre.SetBounds(xP2, 74, anchoColP, 27);

            // Fila 2: Apellidos
            lblPrimerApellido.Location = new Point(xP1, 108);
            txtApellidos.SetBounds(xP1, 126, anchoColP, 27);
            lblSegundoApellido.Location = new Point(xP2, 108);
            txtSegundoApellido.SetBounds(xP2, 126, anchoColP, 27);

            // Fila 3: Cédula & INSS (Columna 1) vs Fecha & Género & Teléfono (Columna 2)
            lblCedula.Location = new Point(xP1, 160);
            txtCedula.SetBounds(xP1, 178, anchoColP, 27);
            lblCedulaAyuda.SetBounds(xP1, 208, anchoColP, 28);
            pnlCedulaInfo.SetBounds(xP1, 238, anchoColP, 36);
            lblCedulaInfo.SetBounds(6, 4, pnlCedulaInfo.Width - 12, 28);

            lblNumeroINSS.Location = new Point(xP1, 278);
            txtNumeroINSS.SetBounds(xP1, 296, anchoColP, 27);
            lblINSSAyuda.Location = new Point(xP1, 326);

            // Columna 2: Fecha y Género
            int anchoFecha = (anchoColP - 10) / 2;
            int anchoGenero = anchoColP - anchoFecha - 10;
            lblFechaNacimiento.Location = new Point(xP2, 160);
            dtpFechaNacimiento.SetBounds(xP2, 178, anchoFecha, 27);
            lblGenero.Location = new Point(xP2 + anchoFecha + 10, 160);
            cmbGenero.SetBounds(xP2 + anchoFecha + 10, 178, anchoGenero, 27);

            // Teléfono con selector de país
            lblTelefono.Location = new Point(xP2, 212);
            int anchoComboTel = Math.Min(165, Math.Max(140, (int)(anchoColP * 0.52f)));
            int anchoNumTel = anchoColP - anchoComboTel - 8;
            cmbPaisTelefono.SetBounds(xP2, 230, anchoComboTel, 27);
            txtTelefono.SetBounds(cmbPaisTelefono.Right + 8, 230, anchoNumTel, 27);
            lblTelefonoAyuda.SetBounds(xP2, 260, anchoColP, 36);
        }

        private void AjustarControlesCardFoto(int anchoCard)
        {
            int sAvatar = 88;
            picPreview.SetBounds(16, 56, sAvatar, sAvatar);

            int xFotoCtrl = picPreview.Right + 12;
            int anchoFotoCtrl = anchoCard - xFotoCtrl - 14;
            int anchoBtn = Math.Min(155, anchoFotoCtrl);

            btnSeleccionarFoto.SetBounds(xFotoCtrl, 56, anchoBtn, 34);
            btnQuitarFoto.SetBounds(xFotoCtrl, 94, anchoBtn, 26);
            lblFoto.Location = new Point(xFotoCtrl, 126);
            lblFotoAyuda.Location = new Point(xFotoCtrl, 144);

            pnlFotoInfo.SetBounds(16, 238, anchoCard - 32, 56);
            lblFotoInfo.SetBounds(8, 8, pnlFotoInfo.Width - 16, 40);
        }

        private void AjustarControlesCardUbicacion(int anchoCard)
        {
            int margenU = 16;
            int gapU = 12;
            int anchoCombo = (anchoCard - (margenU * 2) - (gapU * 2)) / 3;

            // Fila 1: Departamento, Municipio, Comunidad
            lblDepartamento.Location = new Point(margenU, 56);
            cmbDepartamento.SetBounds(margenU, 74, anchoCombo, 27);

            lblMunicipio.Location = new Point(margenU + anchoCombo + gapU, 56);
            cmbMunicipio.SetBounds(margenU + anchoCombo + gapU, 74, anchoCombo, 27);

            lblComunidad.Location = new Point(margenU + (anchoCombo * 2) + (gapU * 2), 56);
            cmbComunidad.SetBounds(margenU + (anchoCombo * 2) + (gapU * 2), 74, anchoCard - (margenU + (anchoCombo * 2) + (gapU * 2)) - margenU, 27);

            // Fila 2: Dirección exacta y Referencia adicional
            int anchoDir = (int)((anchoCard - (margenU * 2) - gapU) * 0.60f);
            int anchoRef = anchoCard - (margenU * 2) - gapU - anchoDir;

            lblDireccion.Location = new Point(margenU, 114);
            txtDireccion.SetBounds(margenU, 132, anchoDir, 27);

            lblReferencia.Location = new Point(margenU + anchoDir + gapU, 114);
            txtReferencia.SetBounds(margenU + anchoDir + gapU, 132, anchoRef, 27);
        }

        private void AjustarControlesCardSalud(int anchoCard)
        {
            int margenS = 16;
            int gapS = 12;
            int anchoColS = (anchoCard - (margenS * 2) - gapS) / 2;

            lblTipoSangre.Location = new Point(margenS, 56);
            cmbTipoSangre.SetBounds(margenS, 74, anchoColS, 27);

            lblAlergias.Location = new Point(margenS + anchoColS + gapS, 56);
            txtAlergias.SetBounds(margenS + anchoColS + gapS, 74, anchoCard - (margenS + anchoColS + gapS) - margenS, 27);
            lblAlergiasAyuda.Location = new Point(margenS + anchoColS + gapS, 104);

            lblAntecedentes.Location = new Point(margenS, 126);
            txtAntecedentes.SetBounds(margenS, 146, anchoCard - (margenS * 2), 140);
            lblAntecedentesAyuda.Location = new Point(margenS, 292);
        }

        private void AjustarControlesCardEmergencia(int anchoCard)
        {
            int margenE = 16;
            int gapE = 12;
            int anchoColE = (anchoCard - (margenE * 2) - gapE) / 2;

            // Fila 1: Nombre completo & Parentesco
            lblContactoPrimerNombre.Location = new Point(margenE, 56);
            txtContactoPrimerNombre.SetBounds(margenE, 74, anchoColE, 27);

            lblContactoPrimerApellido.Location = new Point(margenE + anchoColE + gapE, 56);
            cmbContactoParentesco.SetBounds(margenE + anchoColE + gapE, 74, anchoCard - (margenE + anchoColE + gapE) - margenE, 27);

            // Fila 2: Teléfono & Cédula & Botón Agregar
            lblContactoTelefono.Location = new Point(margenE, 108);
            txtContactoTelefono.SetBounds(margenE, 126, anchoColE, 27);

            int xCol2 = margenE + anchoColE + gapE;
            int anchoDisponibleCol2 = anchoCard - xCol2 - margenE;
            int anchoBtnAgregar = 98;
            int anchoCedula = anchoDisponibleCol2 - anchoBtnAgregar - 8;

            lblContactoCedula.Location = new Point(xCol2, 108);
            txtContactoCedula.SetBounds(xCol2, 126, anchoCedula, 27);
            btnAgregarContacto.SetBounds(xCol2 + anchoCedula + 8, 125, anchoBtnAgregar, 29);

            // Fila 3: Lista de contactos agregados / Estado sin contactos
            lblSubtituloListaContactos.Location = new Point(margenE, 170);
            int anchoGrid = anchoCard - (margenE * 2);
            int altoGrid = 120;
            dgvContactos.SetBounds(margenE, 192, anchoGrid, altoGrid);
            lblSinContactos.SetBounds(margenE, 192, anchoGrid, altoGrid);
        }

        // ============================================================
        // DIBUJADO DE ELEMENTOS GDI+ (ILUSTRACIÓN RURAL Y BADGES)
        // ============================================================
        private static void DibujarBadgeCircular(Control c, PaintEventArgs e, string icono)
        {
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

            // Colina de fondo (verde suave)
            using (GraphicsPath pathFondo = new GraphicsPath())
            {
                pathFondo.AddLine(0, yInicio + 70, 0, h);
                pathFondo.AddLine(0, h, w, h);
                pathFondo.AddLine(w, h, w, yInicio + 25);
                pathFondo.AddBezier(w, yInicio + 25, (int)(w * 0.65f), yInicio - 10, (int)(w * 0.35f), yInicio + 80, 0, yInicio + 70);
                using (Brush brColinaFondo = new SolidBrush(Color.FromArgb(168, 212, 160)))
                {
                    e.Graphics.FillPath(brColinaFondo, pathFondo);
                }
            }

            // Colina media (verde Sanar Rural)
            using (GraphicsPath pathMedia = new GraphicsPath())
            {
                pathMedia.AddLine(0, yInicio + 95, 0, h);
                pathMedia.AddLine(0, h, w, h);
                pathMedia.AddLine(w, h, w, yInicio + 80);
                pathMedia.AddBezier(w, yInicio + 80, (int)(w * 0.60f), yInicio + 50, (int)(w * 0.25f), yInicio + 130, 0, yInicio + 95);
                using (Brush brColinaMedia = new SolidBrush(Tema.Verde))
                {
                    e.Graphics.FillPath(brColinaMedia, pathMedia);
                }
            }

            // Casita rural nicaragüense
            int casaX = (int)(w * 0.18f);
            int casaY = yInicio + 105;
            using (Brush brPared = new SolidBrush(Color.FromArgb(245, 235, 220)))
            using (Brush brTecho = new SolidBrush(Color.FromArgb(195, 95, 75)))
            using (Brush brPuerta = new SolidBrush(Color.FromArgb(120, 75, 45)))
            {
                e.Graphics.FillRectangle(brPared, casaX, casaY, 26, 18);
                Point[] techo = { new Point(casaX - 4, casaY), new Point(casaX + 13, casaY - 12), new Point(casaX + 30, casaY) };
                e.Graphics.FillPolygon(brTecho, techo);
                e.Graphics.FillRectangle(brPuerta, casaX + 9, casaY + 6, 8, 12);
            }

            // Árboles rurales
            DibujarArbolito(e.Graphics, casaX - 18, casaY + 2);
            DibujarArbolito(e.Graphics, casaX + 36, casaY - 4);
            DibujarArbolito(e.Graphics, (int)(w * 0.75f), yInicio + 78);
            DibujarArbolito(e.Graphics, (int)(w * 0.84f), yInicio + 85);

            // Colina frontal (verde oscuro)
            using (GraphicsPath pathFrontal = new GraphicsPath())
            {
                pathFrontal.AddLine(0, yInicio + 155, 0, h);
                pathFrontal.AddLine(0, h, w, h);
                pathFrontal.AddLine(w, h, w, yInicio + 160);
                pathFrontal.AddBezier(w, yInicio + 160, (int)(w * 0.70f), yInicio + 135, (int)(w * 0.40f), yInicio + 195, 0, yInicio + 155);
                using (Brush brColinaFrontal = new SolidBrush(Tema.VerdeOscuro))
                {
                    e.Graphics.FillPath(brColinaFrontal, pathFrontal);
                }
            }

            // Olas decorativas de transición
            using (GraphicsPath pathOlas = new GraphicsPath())
            {
                pathOlas.AddLine(0, h - 28, 0, h);
                pathOlas.AddLine(0, h, w, h);
                pathOlas.AddLine(w, h, w, h - 18);
                pathOlas.AddBezier(w, h - 18, (int)(w * 0.65f), h - 45, (int)(w * 0.35f), h, 0, h - 28);
                using (Brush brOlas = new SolidBrush(Color.FromArgb(170, Tema.Fondo.R, Tema.Fondo.G, Tema.Fondo.B)))
                {
                    e.Graphics.FillPath(brOlas, pathOlas);
                }
            }
        }

        private static void DibujarArbolito(Graphics g, int x, int y)
        {
            using (Brush brTronco = new SolidBrush(Color.FromArgb(115, 80, 50)))
            using (Brush brCopa = new SolidBrush(Color.FromArgb(60, 125, 70)))
            {
                g.FillRectangle(brTronco, x + 5, y + 10, 4, 10);
                g.FillEllipse(brCopa, x, y, 14, 14);
            }
        }

        // ============================================================
        // GESTIÓN DE FOTOGRAFÍA (OPCIONAL)
        // ============================================================
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Seleccionar fotografía del paciente";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(ofd.FileName);
                        if (fi.Length > 2 * 1024 * 1024)
                        {
                            MessageBox.Show("El archivo excede el tamaño máximo permitido de 2 MB.", "Archivo muy pesado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        using (var imgTemp = Image.FromFile(ofd.FileName))
                        {
                            picPreview.Image?.Dispose();
                            picPreview.Image = new Bitmap(imgTemp);
                        }

                        fotoBytes = File.ReadAllBytes(ofd.FileName);
                        fotoNombreArchivo = fi.Name;

                        lblFoto.Text = fi.Name.Length > 22 ? fi.Name.Substring(0, 19) + "..." : fi.Name;
                        btnQuitarFoto.Visible = true;
                        picPreview.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen seleccionada:\n\n" + ex.Message, "Error al cargar foto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            picPreview.Image?.Dispose();
            picPreview.Image = null;
            fotoBytes = null;
            fotoNombreArchivo = null;

            lblFoto.Text = "Sin foto seleccionada";
            btnQuitarFoto.Visible = false;
            picPreview.Invalidate();
        }

        // ============================================================
        // FORMATEO Y VALIDACIÓN DE CÉDULA NICARAGÜENSE
        // ============================================================
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (formateandoCedula) return;

            string textoOriginal = txtCedula.Text;
            int posOriginal = txtCedula.SelectionStart;

            string soloCaracteres = Regex.Replace(textoOriginal, @"[\s-]", "").ToUpperInvariant();

            if (soloCaracteres.Length == 0)
            {
                pnlCedulaInfo.BackColor = Color.FromArgb(240, 247, 253);
                lblCedulaInfo.Text = "Formato tradicional nicaragüense con formato estándar.";
                lblCedulaInfo.ForeColor = Tema.AzulOscuro;
                return;
            }

            if (EsFormatoCedulaTradicional(soloCaracteres))
            {
                formateandoCedula = true;
                string formateado = FormatearCedulaTradicional(soloCaracteres);
                txtCedula.Text = formateado;
                txtCedula.SelectionStart = Math.Min(posOriginal + 1, formateado.Length);
                formateandoCedula = false;

                pnlCedulaInfo.BackColor = Color.FromArgb(235, 247, 238);
                lblCedulaInfo.Text = "✓ Formato tradicional nicaragüense reconocido.";
                lblCedulaInfo.ForeColor = Tema.VerdeOscuro;
            }
            else
            {
                pnlCedulaInfo.BackColor = Color.FromArgb(240, 247, 253);
                lblCedulaInfo.Text = "Documento de identidad en edición. Formato tradicional o nuevo.";
                lblCedulaInfo.ForeColor = Tema.AzulOscuro;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpperInvariant(e.KeyChar);
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private static bool EsFormatoCedulaTradicional(string textoLimpio)
        {
            if (string.IsNullOrWhiteSpace(textoLimpio)) return false;
            return Regex.IsMatch(textoLimpio, @"^\d{3}\d{6}\d{4}[A-Z]$");
        }

        private static string FormatearCedulaTradicional(string textoLimpio)
        {
            if (textoLimpio.Length == 14)
            {
                return $"{textoLimpio.Substring(0, 3)}-{textoLimpio.Substring(3, 6)}-{textoLimpio.Substring(9, 4)}{textoLimpio.Substring(13, 1)}";
            }
            return textoLimpio;
        }

        // ============================================================
        // TELÉFONO INTERNACIONAL
        // ============================================================
        private void CargarTelefonoPaciente(string telefonoGuardado)
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
        // CASCADA GEOGRÁFICA
        // ============================================================
        private void CargarDepartamentos()
        {
            try
            {
                cargandoUbicacion = true;
                cmbDepartamento.DataSource = controlador.listarDepartamentos();
                cmbDepartamento.DisplayMember = "Nombre";
                cmbDepartamento.ValueMember = "Id";
                cmbDepartamento.SelectedIndex = -1;
                cmbMunicipio.DataSource = null;
                cmbComunidad.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los departamentos: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cargandoUbicacion = false;
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion || cmbDepartamento.SelectedValue == null)
                return;

            if (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out int idDepto))
            {
                try
                {
                    cargandoUbicacion = true;
                    cmbMunicipio.DataSource = controlador.listarMunicipios(idDepto);
                    cmbMunicipio.DisplayMember = "Nombre";
                    cmbMunicipio.ValueMember = "Id";
                    cmbMunicipio.SelectedIndex = -1;
                    cmbComunidad.DataSource = null;
                }
                finally
                {
                    cargandoUbicacion = false;
                }
            }
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion || cmbMunicipio.SelectedValue == null)
                return;

            if (int.TryParse(cmbMunicipio.SelectedValue.ToString(), out int idMuni))
            {
                try
                {
                    cargandoUbicacion = true;
                    cmbComunidad.DataSource = controlador.listarComunidades(idMuni);
                    cmbComunidad.DisplayMember = "Nombre";
                    cmbComunidad.ValueMember = "Id";
                    cmbComunidad.SelectedIndex = -1;
                }
                finally
                {
                    cargandoUbicacion = false;
                }
            }
        }

        // ============================================================
        // CARGA EN MODO EDICIÓN
        // ============================================================
        private void CargarPacienteParaEditar()
        {
            try
            {
                PacienteDetalleDto paciente = controlador.obtenerPacienteDetalle(idPacienteEditar.Value);
                if (paciente == null)
                {
                    MessageBox.Show("El paciente no existe o no tiene permisos para consultarlo.", "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                Text = "Sanar Rural - Editar Paciente";
                lblRegistroTituloHero.Text = "Edición de Paciente";
                lblTitulo.Text = "Datos del Paciente";
                lblSubtitulo.Text = string.Format("Editar expediente #{0} | {1}", paciente.IdPaciente, paciente.NombreCompleto);
                btnGuardar.Text = "💾 Guardar cambios";
                btnCancelar.Text = "✕ Cancelar";

                lblBadgeModo.Text = "✎ Modo Edición";
                lblBadgeModo.BackColor = Color.FromArgb(235, 245, 252);
                lblBadgeModo.ForeColor = Tema.AzulPrimario;
                lblBadgeModo.Visible = true;

                txtNombres.Text = paciente.PrimerNombre;
                txtSegundoNombre.Text = paciente.SegundoNombre;
                txtApellidos.Text = paciente.PrimerApellido;
                txtSegundoApellido.Text = paciente.SegundoApellido;
                txtCedula.Text = paciente.Cedula;
                txtNumeroINSS.Text = paciente.NumeroINSS;
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
                cmbGenero.SelectedItem = paciente.Genero;

                CargarTelefonoPaciente(paciente.Telefono);

                // Desglose de dirección y referencia si existía
                if (!string.IsNullOrWhiteSpace(paciente.Direccion) && paciente.Direccion.Contains(" (Ref: "))
                {
                    int idx = paciente.Direccion.IndexOf(" (Ref: ");
                    txtDireccion.Text = paciente.Direccion.Substring(0, idx);
                    txtReferencia.Text = paciente.Direccion.Substring(idx + 7).TrimEnd(')');
                }
                else
                {
                    txtDireccion.Text = paciente.Direccion;
                    txtReferencia.Text = string.Empty;
                }

                cmbTipoSangre.SelectedItem = string.IsNullOrWhiteSpace(paciente.TipoSangre) ? "No especificado" : paciente.TipoSangre;
                txtAlergias.Text = paciente.Alergias;
                txtAntecedentes.Text = paciente.Antecedentes;

                // Cascada de ubicación
                cargandoUbicacion = true;
                cmbDepartamento.SelectedValue = paciente.IdDepartamento;
                cmbMunicipio.DataSource = controlador.listarMunicipios(paciente.IdDepartamento);
                cmbMunicipio.DisplayMember = "Nombre";
                cmbMunicipio.ValueMember = "Id";
                cmbMunicipio.SelectedValue = paciente.IdMunicipio;
                cmbComunidad.DataSource = controlador.listarComunidades(paciente.IdMunicipio);
                cmbComunidad.DisplayMember = "Nombre";
                cmbComunidad.ValueMember = "Id";
                cmbComunidad.SelectedValue = paciente.IdComunidad;
                cargandoUbicacion = false;

                // Contactos de emergencia existentes
                listaContactos.Clear();
                if (paciente.ContactosEmergencia != null)
                {
                    listaContactos.AddRange(paciente.ContactosEmergencia);
                }
                RefrescarGridContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del paciente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        // ============================================================
        // GESTIÓN DE CONTACTOS DE EMERGENCIA
        // ============================================================
        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            string pNombre = txtContactoPrimerNombre.Text.Trim();
            string pApellido = txtContactoPrimerApellido.Text.Trim();
            string parentesco = cmbContactoParentesco.Text.Trim();
            string tel = txtContactoTelefono.Text.Trim();
            string ced = txtContactoCedula.Text.Trim();

            if (string.IsNullOrWhiteSpace(pNombre))
            {
                lblErrorContacto.Text = "El nombre del contacto es obligatorio.";
                txtContactoPrimerNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(parentesco))
            {
                lblErrorContacto.Text = "El parentesco es obligatorio.";
                cmbContactoParentesco.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tel))
            {
                lblErrorContacto.Text = "El teléfono del contacto es obligatorio.";
                txtContactoTelefono.Focus();
                return;
            }

            if (!EsTelefonoContactoValido(tel))
            {
                lblErrorContacto.Text = "El teléfono del contacto debe contener al menos 8 dígitos.";
                txtContactoTelefono.Focus();
                return;
            }

            // Separación amigable de nombre y apellido si se introdujo completo en el primer campo
            string segundoNombre = string.Empty;
            string segundoApellido = string.Empty;

            if (string.IsNullOrWhiteSpace(pApellido))
            {
                string[] partes = pNombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length >= 2)
                {
                    pNombre = partes[0];
                    pApellido = string.Join(" ", partes.Skip(1));
                }
                else
                {
                    pApellido = "Familiar"; // Valor por defecto amigable para mantener integridad
                }
            }

            var contacto = new ContactoEmergenciaDto
            {
                PrimerNombre = pNombre,
                SegundoNombre = segundoNombre,
                PrimerApellido = pApellido,
                SegundoApellido = segundoApellido,
                Parentesco = parentesco,
                Telefono = tel,
                Cedula = ced
            };

            listaContactos.Add(contacto);
            RefrescarGridContactos();
            LimpiarCamposContacto();
            lblErrorContacto.Text = string.Empty;
        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvContactos.Columns[e.ColumnIndex].Name == "colContQuitar")
            {
                if (e.RowIndex < listaContactos.Count)
                {
                    string contactoDesc = listaContactos[e.RowIndex].NombreCompleto;
                    if (MessageBox.Show("¿Desea quitar de la lista a " + contactoDesc + "?",
                        "Quitar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        listaContactos.RemoveAt(e.RowIndex);
                        RefrescarGridContactos();
                    }
                }
            }
        }

        private void RefrescarGridContactos()
        {
            dgvContactos.Rows.Clear();
            foreach (ContactoEmergenciaDto c in listaContactos)
            {
                dgvContactos.Rows.Add(
                    c.NombreCompleto,
                    c.Parentesco,
                    c.Telefono,
                    string.IsNullOrWhiteSpace(c.Cedula) ? "-" : c.Cedula);
            }

            bool hayContactos = listaContactos.Count > 0;
            dgvContactos.Visible = hayContactos;
            lblSinContactos.Visible = !hayContactos;
        }

        private void LimpiarCamposContacto()
        {
            txtContactoPrimerNombre.Clear();
            txtContactoSegundoNombre.Clear();
            txtContactoPrimerApellido.Clear();
            txtContactoSegundoApellido.Clear();
            if (cmbContactoParentesco.Items.Count > 0) cmbContactoParentesco.SelectedIndex = 0;
            txtContactoTelefono.Clear();
            txtContactoCedula.Clear();
            txtContactoPrimerNombre.Focus();
        }

        // ============================================================
        // VALIDACIONES INLINE
        // ============================================================
        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            lblErrorNombres.Text = string.IsNullOrWhiteSpace(txtNombres.Text)
                ? "El primer nombre es obligatorio."
                : string.Empty;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string tel = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(tel))
            {
                string soloDigitos = Regex.Replace(tel, @"\D", "");
                var pais = cmbPaisTelefono.SelectedItem as PaisTelefonoItem ?? PaisesCentroamerica.First();
                if (soloDigitos.Length < pais.LongitudMinima || soloDigitos.Length > pais.LongitudMaxima)
                {
                    lblErrorTelefono.Text = $"Debe tener {pais.LongitudMinima} dígitos.";
                    return;
                }
            }
            lblErrorTelefono.Text = string.Empty;
        }

        private static bool EsTelefonoContactoValido(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel)) return false;
            string digitos = Regex.Replace(tel, @"\D", "");
            return digitos.Length >= 8;
        }

        // ============================================================
        // GUARDAR PACIENTE
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string pNombre = txtNombres.Text.Trim();
            if (string.IsNullOrWhiteSpace(pNombre))
            {
                MessageBox.Show("El primer nombre del paciente es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return;
            }

            string pApellido = txtApellidos.Text.Trim();
            if (string.IsNullOrWhiteSpace(pApellido))
            {
                MessageBox.Show("El primer apellido del paciente es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return;
            }

            if (cmbComunidad.SelectedValue == null || !int.TryParse(cmbComunidad.SelectedValue.ToString(), out int idComunidad))
            {
                MessageBox.Show("Debe seleccionar la comunidad de residencia del paciente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbComunidad.Focus();
                return;
            }

            // Validación de teléfono con selector de país
            if (!ObtenerTelefonoCombinado(out string telefonoGuardar, out string errorTelefono))
            {
                MessageBox.Show(errorTelefono, "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Comprobar si el usuario escribió datos de un contacto en las cajas de texto pero olvidó presionar "+ Agregar"
            if (!string.IsNullOrWhiteSpace(txtContactoPrimerNombre.Text) || !string.IsNullOrWhiteSpace(txtContactoTelefono.Text))
            {
                var respuesta = MessageBox.Show(
                    "Hay datos ingresados en el formulario de contactos de emergencia que no han sido agregados a la lista.\n\n¿Desea agregarlo antes de guardar?",
                    "Contacto pendiente",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Cancel)
                    return;

                if (respuesta == DialogResult.Yes)
                {
                    btnAgregarContacto_Click(sender, e);
                    if (!string.IsNullOrEmpty(lblErrorContacto.Text))
                        return; // Hubo error en el contacto
                }
            }

            string sNombre = txtSegundoNombre.Text.Trim();
            string sApellido = txtSegundoApellido.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string inss = txtNumeroINSS.Text.Trim();
            DateTime fechaNac = dtpFechaNacimiento.Value.Date;
            string genero = cmbGenero.SelectedItem != null ? cmbGenero.SelectedItem.ToString() : null;

            // Dirección combinada con referencia opcional
            string direccionBase = txtDireccion.Text.Trim();
            string refAdicional = txtReferencia.Text.Trim();
            string direccion = !string.IsNullOrWhiteSpace(refAdicional)
                ? string.Format("{0} (Ref: {1})", direccionBase, refAdicional)
                : direccionBase;

            string tipoSangre = cmbTipoSangre.SelectedItem != null ? cmbTipoSangre.SelectedItem.ToString() : null;
            string alergias = txtAlergias.Text.Trim();
            string antecedentes = txtAntecedentes.Text.Trim();

            try
            {
                if (idPacienteEditar.HasValue)
                {
                    bool actualizado = controlador.editarPaciente(
                        idPacienteEditar.Value,
                        pNombre,
                        sNombre,
                        pApellido,
                        sApellido,
                        cedula,
                        inss,
                        fechaNac,
                        genero,
                        telefonoGuardar,
                        idComunidad,
                        direccion,
                        tipoSangre,
                        alergias,
                        antecedentes,
                        listaContactos);

                    if (!actualizado)
                    {
                        MessageBox.Show("No se pudo actualizar el paciente porque el registro no fue encontrado o se encuentra inactivo.", "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del paciente se actualizaron correctamente.", "Expediente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    controlador.crearPaciente(
                        idUsuario,
                        pNombre,
                        sNombre,
                        pApellido,
                        sApellido,
                        cedula,
                        inss,
                        fechaNac,
                        genero,
                        telefonoGuardar,
                        idComunidad,
                        direccion,
                        tipoSangre,
                        alergias,
                        antecedentes,
                        listaContactos);

                    MessageBox.Show("¡Paciente y contactos registrados con éxito!", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la información del paciente:\n\n" + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
