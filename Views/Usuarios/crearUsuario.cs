using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    public partial class crearUsuario : Form
    {
        // Estructura interna para almacenar las diapositivas informativas de la zona hero
        private class SlideInfo
        {
            public string Icono { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
        }

        // Colección de diapositivas con el valor y propósito del registro en Sanar Rural
        private readonly SlideInfo[] _slides = new SlideInfo[]
        {
            new SlideInfo
            {
                Icono = "👥",
                Titulo = "Gestión organizada",
                Descripcion = "Centraliza la información necesaria para una atención comunitaria más eficiente."
            },
            new SlideInfo
            {
                Icono = "📅",
                Titulo = "Atención médica",
                Descripcion = "Facilita el registro y seguimiento de la atención de los pacientes."
            },
            new SlideInfo
            {
                Icono = "📋",
                Titulo = "Historial clínico",
                Descripcion = "Contribuye a mantener información clínica organizada y accesible."
            },
            new SlideInfo
            {
                Icono = "🤝",
                Titulo = "Trabajo comunitario",
                Descripcion = "Apoya la gestión de los servicios de salud de nuestra comunidad."
            }
        };

        private int _indiceSlideActual = 0;
        private readonly usuariosControllers controlador = new usuariosControllers();
        private bool esRegistroDoctorFijo;
        private bool modoAdministracion;
        private int? idUsuarioEditar;
        public int? IdUsuarioCreado { get; private set; }
        public string CorreoRegistrado { get; private set; }

        public crearUsuario()
        {
            InitializeComponent();

            // Configuración de doble búfer para evitar parpadeos visuales al maximizar o redimensionar
            this.DoubleBuffered = true;
            HabilitarDobleBufer(panelHero);
            HabilitarDobleBufer(panelAuth);
            HabilitarDobleBufer(panelCard);
            HabilitarDobleBufer(panelSlideCard);
            HabilitarDobleBufer(panelSlideIndicadores);
            HabilitarDobleBufer(panelLema);
        }

        public crearUsuario(bool forzarDoctor) : this()
        {
            esRegistroDoctorFijo = forzarDoctor;
        }

        public crearUsuario(bool forzarDoctor, bool modoAdministracion) : this(forzarDoctor)
        {
            this.modoAdministracion = modoAdministracion;
        }

        public crearUsuario(int idUsuario) : this(false, true)
        {
            idUsuarioEditar = idUsuario;
        }

        // Habilita el doble búfer en paneles contenedores mediante reflexión
        private static void HabilitarDobleBufer(Control control)
        {
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
                // Si la reflexión no está disponible, continuar con la representación por defecto
            }
        }

        private void crearUsuario_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            // Cargar logotipo institucional desde los recursos del sistema
            Image logo = Tema.ObtenerLogo();
            picLogo.Image = logo;
            picLogoHero.Image = logo;

            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe tener al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Tema.TextoSecundario;
            lblErrorConfirmar.Text = "";
            btnVerContrasena.Text = "👁";
            btnVerConfirmarContrasena.Text = "👁";

            // Microinteracciones de hover para botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnVerContrasena.MouseEnter += (s, ev) => btnVerContrasena.BackColor = Tema.FondoSecundario;
            btnVerContrasena.MouseLeave += (s, ev) => btnVerContrasena.BackColor = Tema.Superficie;
            btnVerConfirmarContrasena.MouseEnter += (s, ev) => btnVerConfirmarContrasena.BackColor = Tema.FondoSecundario;
            btnVerConfirmarContrasena.MouseLeave += (s, ev) => btnVerConfirmarContrasena.BackColor = Tema.Superficie;

            // Navegación ágil por teclado (Enter)
            txtCorreo.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    txtContrasena.Focus();
                    ev.Handled = true;
                    ev.SuppressKeyPress = true;
                }
            };

            txtContrasena.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    txtConfirmarContrasena.Focus();
                    ev.Handled = true;
                    ev.SuppressKeyPress = true;
                }
            };

            txtConfirmarContrasena.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    if (panelTarjetaPaciente.Visible)
                    {
                        panelTarjetaPaciente.Focus();
                    }
                    else if (cmbRol.Visible)
                    {
                        cmbRol.Focus();
                    }
                    else
                    {
                        btnGuardar_Click(btnGuardar, EventArgs.Empty);
                    }
                    ev.Handled = true;
                    ev.SuppressKeyPress = true;
                }
            };

            // Configurar accesibilidad y estilos en las tarjetas de roles
            ConfigurarTarjetaTipoUsuario(panelTarjetaPaciente, rbPaciente, "🧑‍⚕️", "Paciente");
            ConfigurarTarjetaTipoUsuario(panelTarjetaMedico, rbMedico, "👨‍⚕️", "Médico / Personal");
            rbPaciente.Checked = true;
            panelTarjetaPaciente.Checked = true;
            panelTarjetaMedico.Checked = false;

            ConfigurarModoVisual();

            ActualizarSlide();
            timerSlides.Start();

            AjustarLayout();
            txtCorreo.Focus();
        }

        // Configuración de visibilidad y textos según el modo operativo del formulario
        private void ConfigurarModoVisual()
        {
            if (modoAdministracion)
            {
                var roles = controlador.ListarRoles();
                cmbRol.DataSource = roles;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "IdRol";
                cmbRol.Visible = true;
                lblTipoUsuario.Visible = true;
                lblTipoUsuario.Text = "Rol del usuario";
                panelTarjetaPaciente.Visible = false;
                panelTarjetaMedico.Visible = false;
                panelTarjetaPaciente.TabStop = false;
                panelTarjetaMedico.TabStop = false;
                rbPaciente.Visible = false;
                rbMedico.Visible = false;

                lblTipoUsuario.Location = new Point(35, 289);
                cmbRol.Location = new Point(35, 311);
                btnGuardar.Location = new Point(35, 355);
                panelSeparadorInferior.Location = new Point(35, 412);
                lnkVolver.Location = new Point(35, 424);

                btnGuardar.Text = idUsuarioEditar.HasValue ? "Guardar Cambios" : "Crear Usuario";
                lnkVolver.Text = "Cancelar";

                if (idUsuarioEditar.HasValue)
                {
                    CargarUsuarioParaEditar();
                    lblTitulo.Text = "Editar Usuario";
                    lblSubtitulo.Text = "Modifique las credenciales y rol del usuario";
                    lblContrasena.Text = "Nueva contraseña (opcional)";
                }
                else
                {
                    lblTitulo.Text = "Crear Usuario";
                    lblSubtitulo.Text = "Asigne credenciales y rol para el nuevo acceso";
                    lblContrasena.Text = "Contraseña";
                }
            }
            else if (esRegistroDoctorFijo)
            {
                rbMedico.Checked = true;
                rbPaciente.Checked = false;
                panelTarjetaMedico.Checked = true;
                panelTarjetaPaciente.Checked = false;
                lblTipoUsuario.Visible = false;
                panelTarjetaPaciente.Visible = false;
                panelTarjetaMedico.Visible = false;
                panelTarjetaPaciente.TabStop = false;
                panelTarjetaMedico.TabStop = false;
                rbPaciente.Visible = false;
                rbMedico.Visible = false;
                cmbRol.Visible = false;

                btnGuardar.Location = new Point(35, 295);
                panelSeparadorInferior.Location = new Point(35, 352);
                lnkVolver.Location = new Point(35, 364);

                btnGuardar.Text = "Guardar Usuario";
                lnkVolver.Text = "Cancelar y Volver";
                lblTitulo.Text = "Registro de Doctor";
                lblSubtitulo.Text = "Credenciales de acceso para el profesional médico";
            }
            else
            {
                lblTipoUsuario.Visible = true;
                lblTipoUsuario.Text = "Tipo de usuario";
                panelTarjetaPaciente.Visible = true;
                panelTarjetaMedico.Visible = true;
                panelTarjetaPaciente.TabStop = true;
                panelTarjetaMedico.TabStop = true;
                cmbRol.Visible = false;

                panelTarjetaPaciente.Location = new Point(35, 311);
                panelTarjetaMedico.Location = new Point(240, 311);
                btnGuardar.Location = new Point(35, 375);
                panelSeparadorInferior.Location = new Point(35, 435);
                lnkVolver.Location = new Point(35, 448);

                btnGuardar.Text = "Guardar Usuario";
                lnkVolver.Text = "¿Ya tienes una cuenta? Iniciar Sesión";
                lblTitulo.Text = "Crear una cuenta";
                lblSubtitulo.Text = "Regístrate para acceder a Sanar Rural";
            }
        }

        private void crearUsuario_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        // Distribución responsiva y armónica de los paneles Hero y Registro
        private void AjustarLayout()
        {
            int anchoTotal = this.ClientSize.Width;
            int altoTotal = this.ClientSize.Height;

            if (anchoTotal <= 0 || altoTotal <= 0)
                return;

            // Proporción balanceada: 52% Zona Hero visual y 48% Zona Registro
            int anchoHero = (int)(anchoTotal * 0.52f);
            if (anchoHero < 460)
                anchoHero = Math.Min(460, anchoTotal / 2);

            int anchoAuth = anchoTotal - anchoHero;

            panelHero.SetBounds(0, 0, anchoHero, altoTotal);
            panelAuth.SetBounds(anchoHero, 0, anchoAuth, altoTotal);

            // Ajuste interno de elementos en panelHero
            int margenHero = Math.Max(35, (anchoHero - 480) / 2);
            int anchoContenidoHero = Math.Min(460, anchoHero - (margenHero * 2));
            if (anchoContenidoHero < 330)
                anchoContenidoHero = anchoHero - 30;

            int topHero = Math.Max(25, (int)(altoTotal * 0.04f));
            picLogoHero.Location = new Point(margenHero, topHero);

            lblNombreHero.Location = new Point(margenHero - 3, picLogoHero.Bottom + 10);
            lblSubtituloHero.Location = new Point(margenHero, lblNombreHero.Bottom + 6);

            lblDescripcionHero.Location = new Point(margenHero, lblSubtituloHero.Bottom + 10);
            lblDescripcionHero.Width = anchoContenidoHero;

            panelSlideCard.Location = new Point(margenHero, lblDescripcionHero.Bottom + 16);
            panelSlideCard.Width = anchoContenidoHero;
            lblSlideDescripcion.Width = panelSlideCard.Width - lblSlideDescripcion.Left - 16;

            panelSlideIndicadores.Location = new Point(margenHero, panelSlideCard.Bottom + 10);
            panelSlideIndicadores.Width = anchoContenidoHero;

            // Ocultar lema si la altura es menor a 650px para evitar solapamientos
            if (altoTotal >= 650)
            {
                panelLema.Visible = true;
                panelLema.Location = new Point(margenHero, panelSlideIndicadores.Bottom + 16);
                panelLema.Width = anchoContenidoHero;
            }
            else
            {
                panelLema.Visible = false;
            }

            // Altura adaptada para panelCard según el modo activo
            int cardHeight = 490;
            if (modoAdministracion)
            {
                cardHeight = 460;
            }
            else if (esRegistroDoctorFijo)
            {
                cardHeight = 405;
            }

            panelCard.Height = cardHeight;

            // Centrado dinámico de la tarjeta de registro en panelAuth
            int cardX = (panelAuth.ClientSize.Width - panelCard.Width) / 2;
            int cardY = (panelAuth.ClientSize.Height - panelCard.Height) / 2;
            panelCard.Location = new Point(Math.Max(15, cardX), Math.Max(15, cardY));
        }

        // Actualiza los textos e ícono de la tarjeta de diapositiva
        private void ActualizarSlide()
        {
            if (_slides == null || _slides.Length == 0)
                return;

            var slide = _slides[_indiceSlideActual];
            lblSlideIcono.Text = slide.Icono;
            lblSlideTitulo.Text = slide.Titulo;
            lblSlideDescripcion.Text = slide.Descripcion;
            panelSlideIndicadores.Invalidate();
        }

        // Rotación automática de diapositivas
        private void timerSlides_Tick(object sender, EventArgs e)
        {
            _indiceSlideActual = (_indiceSlideActual + 1) % _slides.Length;
            ActualizarSlide();
        }

        // Dibujo de ondas y curvas orgánicas en el panel Hero
        private void panelHero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelHero.Width;
            int h = panelHero.Height;

            using (Pen penOnda1 = new Pen(Color.FromArgb(24, Tema.AzulClaro), 42f))
            using (Pen penOnda2 = new Pen(Color.FromArgb(20, Tema.Verde), 32f))
            {
                penOnda1.StartCap = LineCap.Round;
                penOnda1.EndCap = LineCap.Round;
                penOnda2.StartCap = LineCap.Round;
                penOnda2.EndCap = LineCap.Round;

                Point[] puntos1 = new Point[]
                {
                    new Point((int)(w * 0.45f), -20),
                    new Point((int)(w * 0.72f), (int)(h * 0.28f)),
                    new Point((int)(w * 0.85f), (int)(h * 0.58f)),
                    new Point(w + 30, (int)(h * 0.78f))
                };
                e.Graphics.DrawCurve(penOnda1, puntos1, 0.5f);

                Point[] puntos2 = new Point[]
                {
                    new Point(-20, (int)(h * 0.62f)),
                    new Point((int)(w * 0.32f), (int)(h * 0.76f)),
                    new Point((int)(w * 0.68f), (int)(h * 0.70f)),
                    new Point(w + 30, (int)(h * 0.86f))
                };
                e.Graphics.DrawCurve(penOnda2, puntos2, 0.5f);
            }
        }

        // Borde estilizado para la tarjeta de funcionalidad (slide)
        private void panelSlideCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelSlideCard.Width - 1, panelSlideCard.Height - 1);
            }
        }

        // Indicadores (dots) de la diapositiva actual
        private void panelSlideIndicadores_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int posX = 4;
            int posY = (panelSlideIndicadores.Height - 7) / 2;

            for (int i = 0; i < _slides.Length; i++)
            {
                if (i == _indiceSlideActual)
                {
                    using (Brush brushActivo = new SolidBrush(Tema.AzulPrimario))
                    {
                        e.Graphics.FillRectangle(brushActivo, posX, posY, 22, 7);
                    }
                    posX += 28;
                }
                else
                {
                    using (Brush brushInactivo = new SolidBrush(Tema.Borde))
                    {
                        e.Graphics.FillEllipse(brushInactivo, posX, posY, 7, 7);
                    }
                    posX += 15;
                }
            }
        }

        // Selección manual de diapositiva mediante clic en los indicadores
        private void panelSlideIndicadores_MouseClick(object sender, MouseEventArgs e)
        {
            int posX = 4;
            for (int i = 0; i < _slides.Length; i++)
            {
                int anchoItem = (i == _indiceSlideActual) ? 22 : 7;
                Rectangle areaItem = new Rectangle(posX - 4, 0, anchoItem + 8, panelSlideIndicadores.Height);

                if (areaItem.Contains(e.Location))
                {
                    _indiceSlideActual = i;
                    ActualizarSlide();

                    timerSlides.Stop();
                    timerSlides.Start();
                    break;
                }

                posX += (i == _indiceSlideActual) ? 28 : 15;
            }
        }

        // Decoración de la tarjeta con el lema institucional
        private void panelLema_Paint(object sender, PaintEventArgs e)
        {
            using (Brush brushAcento = new SolidBrush(Tema.VerdeOscuro))
            {
                e.Graphics.FillRectangle(brushAcento, 0, 0, 4, panelLema.Height);
            }

            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelLema.Width - 1, panelLema.Height - 1);
            }
        }

        // Carga los datos de un usuario existente para edición
        private void CargarUsuarioParaEditar()
        {
            var usuario = controlador.ConsultarUsuario(idUsuarioEditar.Value);
            if (usuario == null)
            {
                MessageBox.Show("El usuario ya no está disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtCorreo.Text = usuario.Correo;
            cmbRol.SelectedValue = usuario.IdRol;
            lblErrorCorreo.Text = "";
        }

        // Configura el comportamiento visual, interactivo y accesible de las tarjetas de rol
        private void ConfigurarTarjetaTipoUsuario(TarjetaRolPanel panel, RadioButton radioAsociado, string emoji, string texto)
        {
            panel.BorderStyle = BorderStyle.None;
            panel.Cursor = Cursors.Hand;
            panel.Controls.Clear();

            bool mouseSobre = false;

            var etiqueta = new Label
            {
                Text = emoji + "  " + texto,
                Font = Tema.FuenteLabelCampo,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                AccessibleRole = AccessibleRole.None
            };
            panel.Controls.Add(etiqueta);

            Action actualizarEstadoVisual = () =>
            {
                panel.Checked = radioAsociado.Checked;
                if (panel.Checked)
                {
                    panel.BackColor = Tema.FondoSecundario;
                    etiqueta.ForeColor = Tema.AzulOscuro;
                    etiqueta.Font = new Font(Tema.FamiliaFuente, Tema.TamanoEtiqueta, FontStyle.Bold);
                }
                else if (mouseSobre)
                {
                    panel.BackColor = Tema.Fondo;
                    etiqueta.ForeColor = Tema.TextoPrincipal;
                    etiqueta.Font = new Font(Tema.FamiliaFuente, Tema.TamanoEtiqueta, FontStyle.Regular);
                }
                else
                {
                    panel.BackColor = Tema.Superficie;
                    etiqueta.ForeColor = Tema.TextoSecundario;
                    etiqueta.Font = new Font(Tema.FamiliaFuente, Tema.TamanoEtiqueta, FontStyle.Regular);
                }
                panel.Invalidate();
            };

            panel.Paint += (s, e) =>
            {
                bool enfocado = panel.Focused;
                Color colorBorde = (panel.Checked || enfocado) ? Tema.AzulPrimario : (mouseSobre ? Tema.AzulClaro : Tema.Borde);
                int grosor = (panel.Checked || enfocado) ? 2 : 1;
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    int offset = grosor > 1 ? 1 : 0;
                    e.Graphics.DrawRectangle(pen, offset, offset, panel.ClientSize.Width - 1 - offset * 2, panel.ClientSize.Height - 1 - offset * 2);
                }

                if (enfocado)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(3, 3, panel.ClientSize.Width - 6, panel.ClientSize.Height - 6));
                }
            };

            panel.MouseEnter += (s, ev) => { mouseSobre = true; actualizarEstadoVisual(); };
            panel.MouseLeave += (s, ev) => { mouseSobre = false; actualizarEstadoVisual(); };
            etiqueta.MouseEnter += (s, ev) => { mouseSobre = true; actualizarEstadoVisual(); };
            etiqueta.MouseLeave += (s, ev) => { mouseSobre = false; actualizarEstadoVisual(); };

            Action seleccionarEstaTarjeta = () =>
            {
                panel.Focus();
                if (!radioAsociado.Checked)
                {
                    radioAsociado.Checked = true;
                }
                else
                {
                    actualizarEstadoVisual();
                }
            };

            panel.Click += (s, ev) => seleccionarEstaTarjeta();
            etiqueta.Click += (s, ev) => seleccionarEstaTarjeta();

            panel.GotFocus += (s, ev) => actualizarEstadoVisual();
            panel.LostFocus += (s, ev) => actualizarEstadoVisual();

            panel.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    seleccionarEstaTarjeta();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
                {
                    if (panel == panelTarjetaPaciente)
                    {
                        panelTarjetaMedico.Focus();
                        rbMedico.Checked = true;
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
                {
                    if (panel == panelTarjetaMedico)
                    {
                        panelTarjetaPaciente.Focus();
                        rbPaciente.Checked = true;
                        e.Handled = true;
                    }
                }
            };

            radioAsociado.CheckedChanged += (s, ev) => actualizarEstadoVisual();

            actualizarEstadoVisual();
        }

        // Alternar visualización de contraseña
        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = txtContrasena.PasswordChar == '●' ? '\0' : '●';
            btnVerContrasena.Text = txtContrasena.PasswordChar == '●' ? "👁" : "🙈";
            txtContrasena.Focus();
            txtContrasena.SelectionStart = txtContrasena.Text.Length;
        }

        // Alternar visualización de confirmación de contraseña
        private void btnVerConfirmarContrasena_Click(object sender, EventArgs e)
        {
            txtConfirmarContrasena.PasswordChar = txtConfirmarContrasena.PasswordChar == '●' ? '\0' : '●';
            btnVerConfirmarContrasena.Text = txtConfirmarContrasena.PasswordChar == '●' ? "👁" : "🙈";
            txtConfirmarContrasena.Focus();
            txtConfirmarContrasena.SelectionStart = txtConfirmarContrasena.Text.Length;
        }

        // Validación en tiempo real del formato y disponibilidad de correo
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            if (string.IsNullOrEmpty(correo))
            {
                lblErrorCorreo.Text = "El correo no puede estar vacío.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
                return;
            }

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblErrorCorreo.Text = "Formato de correo inválido.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
                return;
            }

            try
            {
                if (controlador.CorreoYaExiste(correo, idUsuarioEditar))
                {
                    lblErrorCorreo.Text = "Este correo ya está registrado en la base de datos.";
                    lblErrorCorreo.ForeColor = Tema.ColorError;
                }
                else
                {
                    lblErrorCorreo.Text = "Correo disponible.";
                    lblErrorCorreo.ForeColor = Tema.ColorExito;
                }
            }
            catch
            {
                lblErrorCorreo.Text = "No se pudo validar el correo. Verifique la conexión a la base de datos.";
                lblErrorCorreo.ForeColor = Tema.ColorError;
            }
        }

        // Comprobación de coincidencia entre contraseña y confirmación
        private void ValidarCoincidenciaContrasenas()
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden";
                lblErrorConfirmar.ForeColor = Tema.ColorError;
            }
            else if (!string.IsNullOrEmpty(txtContrasena.Text))
            {
                lblErrorConfirmar.Text = "Las contraseñas coinciden";
                lblErrorConfirmar.ForeColor = Tema.ColorExito;
            }
            else
            {
                lblErrorConfirmar.Text = "";
            }
        }

        // Validación en tiempo real de la longitud de contraseña
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string contrasena = txtContrasena.Text;
            if (idUsuarioEditar.HasValue && string.IsNullOrEmpty(contrasena))
            {
                lblErrorContrasena.Text = "Deje vacío para conservar la contraseña actual.";
                lblErrorContrasena.ForeColor = Tema.TextoAyuda;
            }
            else if (contrasena.Length < 5)
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Tema.ColorError;
            }
            else
            {
                lblErrorContrasena.Text = "Contraseña válida";
                lblErrorContrasena.ForeColor = Tema.ColorExito;
            }
            ValidarCoincidenciaContrasenas();
        }

        // Validación en tiempo real de la confirmación de contraseña
        private void txtConfirmarContrasena_TextChanged(object sender, EventArgs e)
        {
            ValidarCoincidenciaContrasenas();
        }

        // Proceso principal de guardado o actualización de usuario
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;
            bool editar = idUsuarioEditar.HasValue;

            if (string.IsNullOrWhiteSpace(correo) || !Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((!editar || !string.IsNullOrEmpty(contrasena)) && contrasena.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((!editar || !string.IsNullOrEmpty(contrasena)) && contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (editar && string.IsNullOrEmpty(contrasena) && !string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Deje ambos campos de contraseña vacíos o escriba la nueva contraseña en los dos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRol;
            if (modoAdministracion)
            {
                if (cmbRol.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idRol = Convert.ToInt32(cmbRol.SelectedValue);
            }
            else
            {
                idRol = controlador.ObtenerIdRol(esRegistroDoctorFijo || rbMedico.Checked ? "Doctor" : "Paciente");
            }

            if (idRol <= 0)
            {
                MessageBox.Show("No se encontró el rol seleccionado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (modoAdministracion)
                {
                    int idCreado = editar ? 0 : controlador.CrearUsuario(idRol, correo, contrasena);
                    bool guardado = editar
                        ? controlador.EditarUsuario(idUsuarioEditar.Value, idRol, correo, contrasena)
                        : idCreado > 0;

                    if (!guardado)
                    {
                        MessageBox.Show("El correo ya está registrado o el usuario no está disponible.", "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!editar)
                        IdUsuarioCreado = idCreado;

                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                int idUsuarioCreado = controlador.CrearUsuario(idRol, correo, contrasena);
                if (idUsuarioCreado == -1)
                {
                    MessageBox.Show("El correo ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IdUsuarioCreado = idUsuarioCreado;
                CorreoRegistrado = correo;

                if (esRegistroDoctorFijo)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                MessageBox.Show("¡Usuario registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (idRol == controlador.ObtenerIdRol("Paciente"))
                {
                    this.Hide();
                    try
                    {
                        using (crearPaciente formularioPaciente = new crearPaciente(idUsuarioCreado))
                            formularioPaciente.ShowDialog();
                    }
                    finally
                    {
                    }
                }
                else if (idRol == controlador.ObtenerIdRol("Doctor"))
                {
                    this.Hide();
                    try
                    {
                        using (crearDoctor formularioDoctor = new crearDoctor(idUsuarioCreado))
                            formularioDoctor.ShowDialog();
                    }
                    finally
                    {
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo actualizar el rol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navegación de retorno o cancelación
        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Borde estilizado para la tarjeta de registro
        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelCard.ClientSize.Width - 1, panelCard.ClientSize.Height - 1);
            }
        }
    }

    /// <summary>
    /// Tarjeta de rol seleccionable mediante teclado, ratón y tecnologías de asistencia.
    /// </summary>
    public class TarjetaRolPanel : Panel
    {
        public bool Checked { get; set; }

        public TarjetaRolPanel()
        {
            SetStyle(ControlStyles.Selectable, true);
            TabStop = true;
            AccessibleRole = AccessibleRole.RadioButton;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Space ||
                keyData == Keys.Left || keyData == Keys.Right ||
                keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;
            }
            return base.IsInputKey(keyData);
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new TarjetaRolAccessibleObject(this);
        }

        private class TarjetaRolAccessibleObject : ControlAccessibleObject
        {
            private readonly TarjetaRolPanel _panel;
            public TarjetaRolAccessibleObject(TarjetaRolPanel panel) : base(panel)
            {
                _panel = panel;
            }

            public override AccessibleRole Role => AccessibleRole.RadioButton;

            public override AccessibleStates State
            {
                get
                {
                    AccessibleStates state = base.State | AccessibleStates.Focusable;
                    if (_panel.Focused) state |= AccessibleStates.Focused;
                    if (_panel.Checked) state |= AccessibleStates.Checked;
                    return state;
                }
            }
        }
    }
}
