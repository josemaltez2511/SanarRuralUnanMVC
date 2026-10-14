using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    /// Formulario para el registro y edición de pacientes en Sanar Rural.
    /// Reproduce con fidelidad la composición visual aprobada:
    /// cabecera superior con logotipo oficial, indicador de tres pasos,
    /// cuatro tarjetas apiladas (Datos personales, Ubicación y dirección,
    /// Información de salud con chips interactivos y Contactos de emergencia con edición inline).
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
        private int indiceContactoEditando = -1;

        // Listas dinámicas para los chips de salud
        private readonly List<string> chipsAlergias = new List<string>();
        private readonly List<string> chipsCondiciones = new List<string>();

        // Catálogo de países centroamericanos con prefijos oficiales
        private class PaisTelefonoItem
        {
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            public string Bandera { get; set; }
            public int LongitudMinima { get; set; }
            public int LongitudMaxima { get; set; }

            public string TextoMostrar => $"{Bandera} {Codigo}";

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
            DoubleBuffered = true;
            HabilitarDobleBufer(panelFormContenedor);
            HabilitarDobleBufer(cardHeader);
            HabilitarDobleBufer(panelPasos);
            HabilitarDobleBufer(cardPersonal);
            HabilitarDobleBufer(cardUbicacion);
            HabilitarDobleBufer(cardSalud);
            HabilitarDobleBufer(cardEmergencia);
            HabilitarDobleBufer(panelAcciones);
            HabilitarDobleBufer(pnlEditorContacto);
            HabilitarDobleBufer(dgvContactos);
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

            // Cargar logotipo institucional oficial de Sanar Rural sin alterar sus proporciones
            picLogoHeader.Image = Tema.ObtenerLogo();

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
            panelFormContenedor.Resize += (s, ev) => AjustarLayoutPaciente();
            Resize += (s, ev) => AjustarLayoutPaciente();
        }

        private void ConfigurarEstilosVisuales()
        {
            BackColor = Tema.Fondo;

            // Pintado suave con esquinas redondeadas en tarjetas principales
            cardHeader.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardHeader.Width - 1, cardHeader.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardPersonal.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardPersonal.Width - 1, cardPersonal.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardUbicacion.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardUbicacion.Width - 1, cardUbicacion.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardSalud.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardSalud.Width - 1, cardSalud.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardEmergencia.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardEmergencia.Width - 1, cardEmergencia.Height - 1), Tema.Superficie, Tema.Borde, 10);
            pnlEditorContacto.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, pnlEditorContacto.Width - 1, pnlEditorContacto.Height - 1), Color.FromArgb(240, 247, 253), Color.FromArgb(195, 222, 243), 8);

            // Iconos circulares con paleta aprobada de salud y naturaleza
            lblIconoHeader.Paint += (s, ev) => DibujarBadgeCircular(lblIconoHeader, ev, "👤", Tema.AzulPrimario, Color.White);
            lblIconoPersonal.Paint += (s, ev) => DibujarBadgeCircular(lblIconoPersonal, ev, "👤", Tema.VerdeOscuro, Color.White);
            lblIconoUbicacion.Paint += (s, ev) => DibujarBadgeCircular(lblIconoUbicacion, ev, "📍", Tema.AzulPrimario, Color.White);
            lblIconoSalud.Paint += (s, ev) => DibujarBadgeCircular(lblIconoSalud, ev, "💓", Tema.AzulPrimario, Color.White);
            lblIconoEmergencia.Paint += (s, ev) => DibujarBadgeCircular(lblIconoEmergencia, ev, "👥", Tema.VerdeOscuro, Color.White);

            // Paso activo y pasos secundarios del indicador
            lblPaso1Num.Paint += (s, ev) => DibujarCirculoPaso(lblPaso1Num, ev, "1", true);
            lblPaso2Num.Paint += (s, ev) => DibujarCirculoPaso(lblPaso2Num, ev, "2", false);
            lblPaso3Num.Paint += (s, ev) => DibujarCirculoPaso(lblPaso3Num, ev, "3", false);

            // Configuración de tabla de contactos de emergencia
            Tema.ConfigurarTabla(dgvContactos);
            dgvContactos.AutoGenerateColumns = false;
            dgvContactos.RowTemplate.Height = 36;
            dgvContactos.CellPainting += dgvContactos_CellPainting;

            // Microinteracciones en botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;
            btnAgregarContacto.MouseEnter += (s, ev) => btnAgregarContacto.BackColor = Tema.AzulOscuro;
            btnAgregarContacto.MouseLeave += (s, ev) => btnAgregarContacto.BackColor = Tema.AzulPrimario;
            btnGuardarContacto.MouseEnter += (s, ev) => btnGuardarContacto.BackColor = Tema.AzulOscuro;
            btnGuardarContacto.MouseLeave += (s, ev) => btnGuardarContacto.BackColor = Tema.AzulPrimario;
            btnCancelarContacto.MouseEnter += (s, ev) => btnCancelarContacto.BackColor = Tema.FondoSecundario;
            btnCancelarContacto.MouseLeave += (s, ev) => btnCancelarContacto.BackColor = Tema.Superficie;

            // Desplazamiento ágil al hacer clic en los pasos del indicador
            lblPaso1Num.Click += (s, ev) => DesplazarHaciaControl(cardPersonal);
            lblPaso1Texto.Click += (s, ev) => DesplazarHaciaControl(cardPersonal);
            lblPaso2Num.Click += (s, ev) => DesplazarHaciaControl(cardUbicacion);
            lblPaso2Texto.Click += (s, ev) => DesplazarHaciaControl(cardUbicacion);
            lblPaso3Num.Click += (s, ev) => DesplazarHaciaControl(cardEmergencia);
            lblPaso3Texto.Click += (s, ev) => DesplazarHaciaControl(cardEmergencia);
        }

        private void DesplazarHaciaControl(Control destino)
        {
            if (destino == null) return;
            panelFormContenedor.ScrollControlIntoView(destino);
        }

        private static void DibujarBadgeCircular(Control c, PaintEventArgs e, string icono, Color fondo, Color colorIcono)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(c.Parent?.BackColor ?? Tema.Superficie);
            using (Brush br = new SolidBrush(fondo))
            {
                e.Graphics.FillEllipse(br, 1, 1, c.Width - 3, c.Height - 3);
            }
            using (Font f = new Font("Segoe UI Emoji", 11.5F))
            using (Brush brText = new SolidBrush(colorIcono))
            {
                SizeF sf = e.Graphics.MeasureString(icono, f);
                e.Graphics.DrawString(icono, f, brText, (c.Width - sf.Width) / 2 + 1, (c.Height - sf.Height) / 2);
            }
        }

        private static void DibujarCirculoPaso(Control c, PaintEventArgs e, string numero, bool activo)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(c.Parent?.BackColor ?? Tema.Fondo);

            Color colorFondo = activo ? Tema.AzulPrimario : Color.FromArgb(240, 244, 248);
            Color colorBorde = activo ? Tema.AzulPrimario : Tema.Borde;
            Color colorTexto = activo ? Color.White : Tema.TextoSecundario;

            Rectangle rect = new Rectangle(1, 1, c.Width - 3, c.Height - 3);
            using (Brush br = new SolidBrush(colorFondo))
            {
                e.Graphics.FillEllipse(br, rect);
            }
            using (Pen pen = new Pen(colorBorde, 1.2f))
            {
                e.Graphics.DrawEllipse(pen, rect);
            }
            using (Font f = new Font(Tema.FamiliaFuente, 9F, FontStyle.Bold))
            using (Brush brText = new SolidBrush(colorTexto))
            {
                SizeF sf = e.Graphics.MeasureString(numero, f);
                e.Graphics.DrawString(numero, f, brText, (c.Width - sf.Width) / 2 + 0.5f, (c.Height - sf.Height) / 2);
            }
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
            ConfigurarDropDown(cmbContactoParentesco);

            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;
            if (cmbTipoSangre.Items.Count > 0) cmbTipoSangre.SelectedIndex = 0;
            if (cmbContactoParentesco.Items.Count > 0) cmbContactoParentesco.SelectedIndex = 0;

            // Longitudes máximas
            txtDireccion.MaxLength = 500;
            txtReferencia.MaxLength = 500;
            txtCorreo.MaxLength = 150;

            // Placeholders visuales estándar
            AsignarPlaceholder(txtNombres, "Juan");
            AsignarPlaceholder(txtSegundoNombre, "Carlos");
            AsignarPlaceholder(txtApellidos, "López");
            AsignarPlaceholder(txtSegundoApellido, "Martínez");
            AsignarPlaceholder(txtCedula, "001-050982-0001A");
            AsignarPlaceholder(txtNumeroINSS, "1234567890");
            AsignarPlaceholder(txtTelefono, "8765-4321");
            AsignarPlaceholder(txtCorreo, "juan.lopez@email.com");
            AsignarPlaceholder(txtDireccion, "Reparto San Martín, de la agroalfa que está contiguo a Walmart dos cuadras al sur, a mano izquierda, casa esquina color verde.");
            AsignarPlaceholder(txtReferencia, "Casa esquinera, portón negro, muro de piedra, cantera de color gris.");
            AsignarPlaceholder(txtContactoPrimerNombre, "Ej. Ana López");
            AsignarPlaceholder(txtContactoTelefono, "8765-0000");
            AsignarPlaceholder(txtContactoCedula, "001-010180-0001A");
            AsignarPlaceholder(txtNuevaAlergia, "Agregue una alergia y presione Enter...");
            AsignarPlaceholder(txtNuevaCondicion, "Agregue una condición y presione Enter...");

            // Formateo y validación de Cédula
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedula_KeyPress;

            // Eventos para ingreso de chips mediante teclado (Enter)
            txtNuevaAlergia.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ev.SuppressKeyPress = true;
                    AgregarChip(txtNuevaAlergia.Text, chipsAlergias, flpAlergias, txtNuevaAlergia);
                }
            };

            txtNuevaCondicion.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ev.SuppressKeyPress = true;
                    AgregarChip(txtNuevaCondicion.Text, chipsCondiciones, flpCondiciones, txtNuevaCondicion);
                }
            };

            // Eventos del panel de edición de contactos
            btnGuardarContacto.Click += btnGuardarContacto_Click;
            btnCancelarContacto.Click += btnCancelarContacto_Click;

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
            txtTelefono.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtCorreo.Focus(); ev.SuppressKeyPress = true; } };
            txtCorreo.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { cmbDepartamento.Focus(); ev.SuppressKeyPress = true; } };

            CancelButton = btnCancelar;
            lblErrorNombres.Text = string.Empty;
            lblErrorTelefono.Text = string.Empty;
            lblErrorContacto.Text = string.Empty;

            RefrescarChips(chipsAlergias, flpAlergias, txtNuevaAlergia);
            RefrescarChips(chipsCondiciones, flpCondiciones, txtNuevaCondicion);
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
            lblTitulo.Text = "Registrar paciente";
            lblSubtitulo.Text = "Información personal, ubicación y expediente básico";
            btnGuardar.Text = "💾 Guardar paciente";
            btnCancelar.Text = "✕ Cancelar";
        }

        // ============================================================
        // SISTEMA DE CHIPS INTERACTIVOS (SALUD)
        // ============================================================
        private void AgregarChip(string texto, List<string> lista, FlowLayoutPanel flp, TextBox input)
        {
            if (string.IsNullOrWhiteSpace(texto)) return;
            string limpio = texto.Trim();
            if (!lista.Contains(limpio, StringComparer.OrdinalIgnoreCase))
            {
                lista.Add(limpio);
                input.Clear();
                RefrescarChips(lista, flp, input);
            }
            else
            {
                input.Clear();
            }
        }

        private void CargarChipsDesdeTexto(string texto, List<string> lista, FlowLayoutPanel flp, TextBox input)
        {
            lista.Clear();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                string[] partes = texto.Split(new[] { ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string p in partes)
                {
                    string item = p.Trim();
                    if (!string.IsNullOrEmpty(item) && !lista.Contains(item, StringComparer.OrdinalIgnoreCase))
                    {
                        lista.Add(item);
                    }
                }
            }
            RefrescarChips(lista, flp, input);
        }

        private void RefrescarChips(List<string> lista, FlowLayoutPanel flp, TextBox input)
        {
            flp.SuspendLayout();
            flp.Controls.Clear();

            foreach (string item in lista)
            {
                Panel pnlChip = CrearPillChip(item, () =>
                {
                    lista.Remove(item);
                    RefrescarChips(lista, flp, input);
                });
                flp.Controls.Add(pnlChip);
            }

            flp.Controls.Add(input);
            flp.ResumeLayout(true);

            // Sincronizar campos de texto para persistencia transparente
            txtAlergias.Text = string.Join(", ", chipsAlergias);
            txtAntecedentes.Text = string.Join(", ", chipsCondiciones);
        }

        private static Panel CrearPillChip(string texto, Action alQuitar)
        {
            Panel pnl = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                BackColor = Color.FromArgb(232, 244, 253),
                Margin = new Padding(3, 3, 4, 3),
                Padding = new Padding(6, 2, 4, 2)
            };

            pnl.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                using (Pen pen = new Pen(Color.FromArgb(190, 222, 245), 1f))
                using (GraphicsPath path = Tema.CrearRutaRedondeada(r, 6))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };

            Label lblTexto = new Label
            {
                Text = texto,
                Font = new Font(Tema.FamiliaFuente, 9F, FontStyle.Regular),
                ForeColor = Tema.AzulPrimario,
                AutoSize = true,
                Location = new Point(4, 3),
                Cursor = Cursors.Default
            };

            Label lblCerrar = new Label
            {
                Text = "✕",
                Font = new Font(Tema.FamiliaFuente, 8F, FontStyle.Bold),
                ForeColor = Tema.AzulPrimario,
                AutoSize = true,
                Cursor = Cursors.Hand,
                Location = new Point(lblTexto.Right + 2, 4)
            };

            lblCerrar.Click += (s, e) => alQuitar?.Invoke();
            lblCerrar.MouseEnter += (s, e) => lblCerrar.ForeColor = Tema.Error;
            lblCerrar.MouseLeave += (s, e) => lblCerrar.ForeColor = Tema.AzulPrimario;

            pnl.Controls.Add(lblTexto);
            pnl.Controls.Add(lblCerrar);
            lblCerrar.Left = lblTexto.Right + 3;

            return pnl;
        }

        // ============================================================
        // LAYOUT RESPONSIVO DINÁMICO (ADAPTABLE A CUALQUIER RESOLUCIÓN)
        // ============================================================
        private void AjustarLayoutPaciente()
        {
            if (panelFormContenedor.ClientSize.Width <= 0) return;

            panelFormContenedor.SuspendLayout();

            int anchoNeto = panelFormContenedor.ClientSize.Width;
            int margenLateral = 20;
            int anchoCards = Math.Max(780, anchoNeto - (margenLateral * 2));
            int xCard = margenLateral;
            int gap = 14;
            int y = 14;

            // 1. Cabecera superior horizontal
            cardHeader.SetBounds(xCard, y, anchoCards, 68);
            AjustarControlesHeader(anchoCards);
            y += cardHeader.Height + 8;

            // 2. Indicador visual de 3 pasos
            panelPasos.SetBounds(xCard, y, anchoCards, 38);
            AjustarControlesPasos(anchoCards);
            y += panelPasos.Height + 12;

            // 3. Tarjeta «Datos personales» (2 filas x 5 columnas)
            int altoCardPersonal = 176;
            cardPersonal.SetBounds(xCard, y, anchoCards, altoCardPersonal);
            AjustarControlesCardPersonal(anchoCards);
            y += altoCardPersonal + gap;

            // 4. Tarjeta «Ubicación y dirección» (3 combos + 2 textareas)
            int altoCardUbicacion = 205;
            cardUbicacion.SetBounds(xCard, y, anchoCards, altoCardUbicacion);
            AjustarControlesCardUbicacion(anchoCards);
            y += altoCardUbicacion + gap;

            // 5. Tarjeta «Información de salud» (Tipo sangre + Alergias chips, Condiciones chips)
            int altoCardSalud = 185;
            cardSalud.SetBounds(xCard, y, anchoCards, altoCardSalud);
            AjustarControlesCardSalud(anchoCards);
            y += altoCardSalud + gap;

            // 6. Tarjeta «Contactos de emergencia» con tabla e inline editor
            int altoGridContactos = Math.Max(95, Math.Min(180, (Math.Max(1, listaContactos.Count) + 1) * 36 + 28));
            int altoCardEmergencia = 54 + altoGridContactos + 16;
            if (pnlEditorContacto.Visible)
            {
                altoCardEmergencia += pnlEditorContacto.Height + 12;
            }
            cardEmergencia.SetBounds(xCard, y, anchoCards, altoCardEmergencia);
            AjustarControlesCardEmergencia(anchoCards, altoGridContactos);
            y += altoCardEmergencia + gap;

            // 7. Barra de acciones inferior
            panelAcciones.SetBounds(xCard, y, anchoCards, 52);
            btnGuardar.Left = panelAcciones.Width - btnGuardar.Width - 4;
            btnCancelar.Left = btnGuardar.Left - btnCancelar.Width - 12;
            y += panelAcciones.Height + 24;

            panelFormContenedor.ResumeLayout(true);
        }

        private void AjustarControlesHeader(int anchoCard)
        {
            picLogoHeader.SetBounds(16, 9, 160, 50);
            pnlSeparadorHeader.SetBounds(188, 13, 1, 42);
            lblIconoHeader.SetBounds(204, 14, 40, 40);
            lblTitulo.Location = new Point(252, 12);
            lblSubtitulo.Location = new Point(254, 40);
        }

        private void AjustarControlesPasos(int anchoCard)
        {
            int anchoTotalPasos = 640;
            int xInicio = Math.Max(16, (anchoCard - anchoTotalPasos) / 2);

            lblPaso1Num.Location = new Point(xInicio, 7);
            lblPaso1Texto.Location = new Point(lblPaso1Num.Right + 6, 10);
            pnlPasoLinea1.SetBounds(lblPaso1Texto.Right + 12, 18, 60, 1);

            lblPaso2Num.Location = new Point(pnlPasoLinea1.Right + 12, 7);
            lblPaso2Texto.Location = new Point(lblPaso2Num.Right + 6, 10);
            pnlPasoLinea2.SetBounds(lblPaso2Texto.Right + 12, 18, 60, 1);

            lblPaso3Num.Location = new Point(pnlPasoLinea2.Right + 12, 7);
            lblPaso3Texto.Location = new Point(lblPaso3Num.Right + 6, 10);
        }

        private void AjustarControlesCardPersonal(int anchoCard)
        {
            int margen = 16;
            int gapCol = 12;
            int numColumnas = 5;
            int anchoCol = (anchoCard - (margen * 2) - (gapCol * (numColumnas - 1))) / numColumnas;

            int[] xCols = new int[numColumnas];
            for (int i = 0; i < numColumnas; i++)
            {
                xCols[i] = margen + (i * (anchoCol + gapCol));
            }

            // Fila 1: Nombres, Apellidos y Cédula
            lblPrimerNombre.Location = new Point(xCols[0], 52);
            txtNombres.SetBounds(xCols[0], 70, anchoCol, 27);

            lblSegundoNombre.Location = new Point(xCols[1], 52);
            txtSegundoNombre.SetBounds(xCols[1], 70, anchoCol, 27);

            lblPrimerApellido.Location = new Point(xCols[2], 52);
            txtApellidos.SetBounds(xCols[2], 70, anchoCol, 27);

            lblSegundoApellido.Location = new Point(xCols[3], 52);
            txtSegundoApellido.SetBounds(xCols[3], 70, anchoCol, 27);

            int anchoUltimaCol = anchoCard - margen - xCols[4];
            lblCedula.Location = new Point(xCols[4], 52);
            txtCedula.SetBounds(xCols[4], 70, anchoUltimaCol, 27);

            // Fila 2: INSS, Fecha, Género, Teléfono y Correo
            lblNumeroINSS.Location = new Point(xCols[0], 108);
            txtNumeroINSS.SetBounds(xCols[0], 126, anchoCol, 27);

            lblFechaNacimiento.Location = new Point(xCols[1], 108);
            dtpFechaNacimiento.SetBounds(xCols[1], 126, anchoCol, 27);

            lblGenero.Location = new Point(xCols[2], 108);
            cmbGenero.SetBounds(xCols[2], 126, anchoCol, 27);

            // Teléfono con selector de país compacto integrado
            lblTelefono.Location = new Point(xCols[3], 108);
            int anchoPrefijo = Math.Min(78, (int)(anchoCol * 0.42f));
            cmbPaisTelefono.SetBounds(xCols[3], 126, anchoPrefijo, 27);
            txtTelefono.SetBounds(cmbPaisTelefono.Right + 4, 126, anchoCol - anchoPrefijo - 4, 27);

            lblCorreo.Location = new Point(xCols[4], 108);
            txtCorreo.SetBounds(xCols[4], 126, anchoUltimaCol, 27);
        }

        private void AjustarControlesCardUbicacion(int anchoCard)
        {
            int margen = 16;
            int gap = 12;

            // Fila 1: 3 columnas (Departamento, Municipio, Comunidad)
            int anchoCol3 = (anchoCard - (margen * 2) - (gap * 2)) / 3;

            lblDepartamento.Location = new Point(margen, 52);
            cmbDepartamento.SetBounds(margen, 70, anchoCol3, 27);

            lblMunicipio.Location = new Point(margen + anchoCol3 + gap, 52);
            cmbMunicipio.SetBounds(margen + anchoCol3 + gap, 70, anchoCol3, 27);

            int xComunidad = margen + (anchoCol3 * 2) + (gap * 2);
            lblComunidad.Location = new Point(xComunidad, 52);
            cmbComunidad.SetBounds(xComunidad, 70, anchoCard - margen - xComunidad, 27);

            // Fila 2: 2 áreas de texto amplias (Dirección exacta y Referencia adicional)
            int anchoCol2 = (anchoCard - (margen * 2) - gap) / 2;

            lblDireccion.Location = new Point(margen, 108);
            txtDireccion.SetBounds(margen, 126, anchoCol2, 58);

            int xRef = margen + anchoCol2 + gap;
            lblReferencia.Location = new Point(xRef, 108);
            txtReferencia.SetBounds(xRef, 126, anchoCard - margen - xRef, 58);
        }

        private void AjustarControlesCardSalud(int anchoCard)
        {
            int margen = 16;
            int gap = 14;

            // Fila 1: Tipo de sangre (izquierda) y Alergias conocidas (derecha con chips)
            int anchoSangre = 200;
            lblTipoSangre.Location = new Point(margen, 52);
            cmbTipoSangre.SetBounds(margen, 70, anchoSangre, 27);

            int xAlergias = margen + anchoSangre + gap;
            int anchoAlergias = anchoCard - margen - xAlergias;
            lblAlergias.Location = new Point(xAlergias, 52);
            pnlAlergiasChips.SetBounds(xAlergias, 70, anchoAlergias, 34);

            // Fila 2: Condiciones de salud relevantes (ancho completo con chips)
            int anchoCondiciones = anchoCard - (margen * 2);
            lblAntecedentes.Location = new Point(margen, 114);
            pnlCondicionesChips.SetBounds(margen, 134, anchoCondiciones, 34);
        }

        private void AjustarControlesCardEmergencia(int anchoCard, int altoGrid)
        {
            int margen = 16;
            int anchoContenido = anchoCard - (margen * 2);

            btnAgregarContacto.Location = new Point(anchoCard - margen - btnAgregarContacto.Width, 10);

            dgvContactos.SetBounds(margen, 52, anchoContenido, altoGrid);
            lblSinContactos.SetBounds(margen, 52, anchoContenido, altoGrid);

            if (pnlEditorContacto.Visible)
            {
                pnlEditorContacto.SetBounds(margen, dgvContactos.Bottom + 10, anchoContenido, 76);
                AjustarControlesEditorContacto(anchoContenido);
            }
        }

        private void AjustarControlesEditorContacto(int anchoPanel)
        {
            int margen = 12;
            int gap = 10;
            int anchoBotones = 245;
            int anchoCamposTotal = anchoPanel - (margen * 2) - anchoBotones - (gap * 4);

            int wNombre = (int)(anchoCamposTotal * 0.32f);
            int wParentesco = (int)(anchoCamposTotal * 0.22f);
            int wTel = (int)(anchoCamposTotal * 0.22f);
            int wCed = anchoCamposTotal - wNombre - wParentesco - wTel;

            lblContactoPrimerNombre.Location = new Point(margen, 10);
            txtContactoPrimerNombre.SetBounds(margen, 28, wNombre, 27);

            int xPar = txtContactoPrimerNombre.Right + gap;
            lblContactoParentesco.Location = new Point(xPar, 10);
            cmbContactoParentesco.SetBounds(xPar, 28, wParentesco, 27);

            int xTel = cmbContactoParentesco.Right + gap;
            lblContactoTelefono.Location = new Point(xTel, 10);
            txtContactoTelefono.SetBounds(xTel, 28, wTel, 27);

            int xCed = txtContactoTelefono.Right + gap;
            lblContactoCedula.Location = new Point(xCed, 10);
            txtContactoCedula.SetBounds(xCed, 28, wCed, 27);

            int xBtn = txtContactoCedula.Right + gap + 4;
            btnGuardarContacto.SetBounds(xBtn, 26, 135, 31);
            btnCancelarContacto.SetBounds(btnGuardarContacto.Right + 6, 26, 95, 31);
        }

        // ============================================================
        // PINTADO PERSONALIZADO DE LA TABLA DE CONTACTOS
        // ============================================================
        private void dgvContactos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Columna de expansión / indicador
            if (dgvContactos.Columns[e.ColumnIndex].Name == "colExpandir")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                string flecha = (indiceContactoEditando == e.RowIndex && pnlEditorContacto.Visible) ? "▲" : "▼";
                Color colorFlecha = (indiceContactoEditando == e.RowIndex && pnlEditorContacto.Visible)
                    ? Tema.AzulPrimario
                    : Tema.TextoSecundario;

                using (Font font = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                using (Brush brush = new SolidBrush(colorFlecha))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(flecha, font, brush, e.CellBounds, sf);
                }

                e.Handled = true;
                return;
            }

            // 2. Botón Editar
            if (dgvContactos.Columns[e.ColumnIndex].Name == "colContEditar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(78, e.CellBounds.Width - 8);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                Rectangle rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Tema.BotonEditarFondo, Tema.BotonEditarBorde, 6);

                using (Brush brush = new SolidBrush(Tema.AzulPrimario))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (Font font = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("✏ Editar", font, brush, rectBtn, sf);
                }

                e.Handled = true;
                return;
            }

            // 3. Botón Eliminar
            if (dgvContactos.Columns[e.ColumnIndex].Name == "colContEliminar")
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = Math.Min(82, e.CellBounds.Width - 8);
                int btnH = 26;
                int btnX = e.CellBounds.X + ((e.CellBounds.Width - btnW) / 2);
                int btnY = e.CellBounds.Y + ((e.CellBounds.Height - btnH) / 2);

                Rectangle rectBtn = new Rectangle(btnX, btnY, btnW, btnH);
                Tema.DibujarTarjetaRedondeada(e.Graphics, rectBtn, Tema.BotonPeligroFondo, Tema.BotonPeligroBorde, 6);

                using (Brush brush = new SolidBrush(Tema.Error))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (Font font = new Font(Tema.FamiliaFuente, 8.5F, FontStyle.Bold))
                {
                    e.Graphics.DrawString("🗑 Eliminar", font, brush, rectBtn, sf);
                }

                e.Handled = true;
                return;
            }
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

            if (soloCaracteres.Length == 0) return;

            if (EsFormatoCedulaTradicional(soloCaracteres))
            {
                formateandoCedula = true;
                string formateado = FormatearCedulaTradicional(soloCaracteres);
                txtCedula.Text = formateado;
                txtCedula.SelectionStart = Math.Min(posOriginal + 1, formateado.Length);
                formateandoCedula = false;
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

            var pais = cmbPaisTelefono.SelectedItem as PaisTelefonoItem ?? PaisesCentroamerica.First(p => p.Codigo == "+505");

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
                lblTitulo.Text = "Editar paciente";
                lblSubtitulo.Text = string.Format("Editar expediente #{0} | {1}", paciente.IdPaciente, paciente.NombreCompleto);
                btnGuardar.Text = "💾 Guardar cambios";
                btnCancelar.Text = "✕ Cancelar";

                txtNombres.Text = paciente.PrimerNombre;
                txtSegundoNombre.Text = paciente.SegundoNombre;
                txtApellidos.Text = paciente.PrimerApellido;
                txtSegundoApellido.Text = paciente.SegundoApellido;
                txtCedula.Text = paciente.Cedula;
                txtNumeroINSS.Text = paciente.NumeroINSS;
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
                cmbGenero.SelectedItem = paciente.Genero;
                txtCorreo.Text = paciente.Correo ?? string.Empty;

                CargarTelefonoPaciente(paciente.Telefono);

                // Carga de dirección y referencia adicional
                txtDireccion.Text = paciente.Direccion ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(paciente.ReferenciaAdicional))
                {
                    txtReferencia.Text = paciente.ReferenciaAdicional;
                }
                else if (!string.IsNullOrWhiteSpace(paciente.Direccion) && paciente.Direccion.Contains(" (Ref: "))
                {
                    int idx = paciente.Direccion.IndexOf(" (Ref: ");
                    txtDireccion.Text = paciente.Direccion.Substring(0, idx);
                    txtReferencia.Text = paciente.Direccion.Substring(idx + 7).TrimEnd(')');
                }
                else
                {
                    txtReferencia.Text = string.Empty;
                }

                cmbTipoSangre.SelectedItem = string.IsNullOrWhiteSpace(paciente.TipoSangre) ? "No especificado" : paciente.TipoSangre;

                // Carga de alergias y condiciones en chips sin fragmentación ni pérdida de texto
                CargarChipsDesdeTexto(paciente.Alergias, chipsAlergias, flpAlergias, txtNuevaAlergia);
                CargarChipsDesdeTexto(paciente.Antecedentes, chipsCondiciones, flpCondiciones, txtNuevaCondicion);

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
        // GESTIÓN DE CONTACTOS DE EMERGENCIA (CON EDICIÓN INLINE)
        // ============================================================
        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            indiceContactoEditando = -1;
            txtContactoPrimerNombre.Clear();
            txtContactoTelefono.Clear();
            txtContactoCedula.Clear();
            if (cmbContactoParentesco.Items.Count > 0) cmbContactoParentesco.SelectedIndex = 0;
            lblErrorContacto.Text = string.Empty;
            btnGuardarContacto.Text = "💾 Guardar contacto";

            pnlEditorContacto.Visible = true;
            AjustarLayoutPaciente();
            txtContactoPrimerNombre.Focus();
        }

        private void btnCancelarContacto_Click(object sender, EventArgs e)
        {
            pnlEditorContacto.Visible = false;
            indiceContactoEditando = -1;
            lblErrorContacto.Text = string.Empty;
            AjustarLayoutPaciente();
            dgvContactos.Invalidate();
        }

        private void btnGuardarContacto_Click(object sender, EventArgs e)
        {
            string nombreCompleto = txtContactoPrimerNombre.Text.Trim();
            string parentesco = cmbContactoParentesco.Text.Trim();
            string tel = txtContactoTelefono.Text.Trim();
            string ced = txtContactoCedula.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                lblErrorContacto.Text = "El nombre completo del contacto es obligatorio.";
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

            // Separación amigable de nombre y apellido
            string pNombre = nombreCompleto;
            string pApellido = "Familiar";
            string[] partes = nombreCompleto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                pNombre = partes[0];
                pApellido = string.Join(" ", partes.Skip(1));
            }

            if (indiceContactoEditando >= 0 && indiceContactoEditando < listaContactos.Count)
            {
                // Modo edición de contacto existente
                var contactoExistente = listaContactos[indiceContactoEditando];
                contactoExistente.PrimerNombre = pNombre;
                contactoExistente.PrimerApellido = pApellido;
                contactoExistente.Parentesco = parentesco;
                contactoExistente.Telefono = tel;
                contactoExistente.Cedula = ced;
            }
            else
            {
                // Modo adición de nuevo contacto
                var nuevoContacto = new ContactoEmergenciaDto
                {
                    PrimerNombre = pNombre,
                    PrimerApellido = pApellido,
                    Parentesco = parentesco,
                    Telefono = tel,
                    Cedula = ced
                };
                listaContactos.Add(nuevoContacto);
            }

            pnlEditorContacto.Visible = false;
            indiceContactoEditando = -1;
            lblErrorContacto.Text = string.Empty;
            RefrescarGridContactos();
            AjustarLayoutPaciente();
        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columna = dgvContactos.Columns[e.ColumnIndex].Name;

            if (columna == "colContEditar")
            {
                if (e.RowIndex < listaContactos.Count)
                {
                    indiceContactoEditando = e.RowIndex;
                    var c = listaContactos[e.RowIndex];
                    txtContactoPrimerNombre.Text = c.NombreCompleto;
                    cmbContactoParentesco.Text = c.Parentesco;
                    txtContactoTelefono.Text = c.Telefono;
                    txtContactoCedula.Text = c.Cedula;
                    lblErrorContacto.Text = string.Empty;
                    btnGuardarContacto.Text = "💾 Guardar cambios";

                    pnlEditorContacto.Visible = true;
                    AjustarLayoutPaciente();
                    dgvContactos.Invalidate();
                    txtContactoPrimerNombre.Focus();
                }
            }
            else if (columna == "colContEliminar")
            {
                if (e.RowIndex < listaContactos.Count)
                {
                    string contactoDesc = listaContactos[e.RowIndex].NombreCompleto;
                    if (MessageBox.Show("¿Desea eliminar de la lista a " + contactoDesc + "?",
                        "Eliminar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        listaContactos.RemoveAt(e.RowIndex);
                        if (indiceContactoEditando == e.RowIndex)
                        {
                            pnlEditorContacto.Visible = false;
                            indiceContactoEditando = -1;
                        }
                        RefrescarGridContactos();
                        AjustarLayoutPaciente();
                    }
                }
            }
        }

        private void RefrescarGridContactos()
        {
            dgvContactos.Rows.Clear();
            for (int i = 0; i < listaContactos.Count; i++)
            {
                var c = listaContactos[i];
                string indicador = (indiceContactoEditando == i && pnlEditorContacto.Visible) ? "▲" : "▼";
                dgvContactos.Rows.Add(
                    indicador,
                    c.NombreCompleto,
                    c.Parentesco,
                    c.Telefono,
                    string.IsNullOrWhiteSpace(c.Cedula) ? "-" : c.Cedula,
                    "✏ Editar",
                    "🗑 Eliminar");
            }

            bool hayContactos = listaContactos.Count > 0;
            dgvContactos.Visible = hayContactos;
            lblSinContactos.Visible = !hayContactos;
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
            // Incorporar cualquier texto que haya quedado pendiente en las cajas de chips sin haber presionado Enter
            if (!string.IsNullOrWhiteSpace(txtNuevaAlergia.Text))
            {
                string pendiente = txtNuevaAlergia.Text.Trim();
                if (!chipsAlergias.Contains(pendiente, StringComparer.OrdinalIgnoreCase))
                {
                    chipsAlergias.Add(pendiente);
                }
                txtNuevaAlergia.Clear();
            }

            if (!string.IsNullOrWhiteSpace(txtNuevaCondicion.Text))
            {
                string pendiente = txtNuevaCondicion.Text.Trim();
                if (!chipsCondiciones.Contains(pendiente, StringComparer.OrdinalIgnoreCase))
                {
                    chipsCondiciones.Add(pendiente);
                }
                txtNuevaCondicion.Clear();
            }

            // Sincronizar cadenas consolidadas
            txtAlergias.Text = string.Join(", ", chipsAlergias);
            txtAntecedentes.Text = string.Join(", ", chipsCondiciones);

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

            // Comprobar si el usuario escribió datos de un contacto en el panel de edición pero olvidó pulsar 'Guardar cambios'
            if (pnlEditorContacto.Visible && (!string.IsNullOrWhiteSpace(txtContactoPrimerNombre.Text) || !string.IsNullOrWhiteSpace(txtContactoTelefono.Text)))
            {
                var respuesta = MessageBox.Show(
                    "Hay datos ingresados en el formulario de contactos de emergencia que no han sido guardados.\n\n¿Desea guardarlos antes de registrar al paciente?",
                    "Contacto pendiente",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Cancel)
                    return;

                if (respuesta == DialogResult.Yes)
                {
                    btnGuardarContacto_Click(sender, e);
                    if (pnlEditorContacto.Visible)
                        return; // Hubo error en la validación del contacto
                }
            }

            string sNombre = txtSegundoNombre.Text.Trim();
            string sApellido = txtSegundoApellido.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string inss = txtNumeroINSS.Text.Trim();
            DateTime fechaNac = dtpFechaNacimiento.Value.Date;
            string genero = cmbGenero.SelectedItem != null ? cmbGenero.SelectedItem.ToString() : null;

            // Registro de dirección y referencia adicional por separado
            string direccion = txtDireccion.Text.Trim();
            string refAdicional = txtReferencia.Text.Trim();
            string correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim();

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
                        listaContactos,
                        refAdicional,
                        correo);

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
                        listaContactos,
                        refAdicional,
                        correo);

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
