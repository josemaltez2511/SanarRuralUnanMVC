using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views;

namespace SanarRuralUnan
{
    public partial class iniciarSesion : Form
    {
        // Estructura interna para almacenar las diapositivas informativas de la zona hero
        private class SlideInfo
        {
            public string Icono { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
        }

        // Colección de diapositivas que explican las funcionalidades clave de Sanar Rural
        private readonly SlideInfo[] _slides = new SlideInfo[]
        {
            new SlideInfo
            {
                Icono = "👥",
                Titulo = "Gestión de Pacientes",
                Descripcion = "Registra y administra la información de los pacientes de la comunidad de forma ágil y segura."
            },
            new SlideInfo
            {
                Icono = "📅",
                Titulo = "Control de Citas",
                Descripcion = "Programa y organiza citas médicas evitando cruces de horarios y tiempos muertos."
            },
            new SlideInfo
            {
                Icono = "🩺",
                Titulo = "Consultas Médicas",
                Descripcion = "Registra signos vitales, diagnósticos y prescripciones durante la atención integral."
            },
            new SlideInfo
            {
                Icono = "📋",
                Titulo = "Historial Clínico",
                Descripcion = "Consulta antecedentes y atenciones previas para un seguimiento continuo y de calidad."
            }
        };

        private int _indiceSlideActual = 0;

        public iniciarSesion()
        {
            InitializeComponent();

            // Optimización de renderizado para evitar parpadeos visuales al maximizar o redimensionar
            this.DoubleBuffered = true;
            HabilitarDobleBufer(panelHero);
            HabilitarDobleBufer(panelAuth);
            HabilitarDobleBufer(panelCard);
            HabilitarDobleBufer(panelSlideCard);
            HabilitarDobleBufer(panelSlideIndicadores);
            HabilitarDobleBufer(panelLema);
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
                // Si la reflexión falla en tiempo de ejecución, se continúa con el renderizado normal
            }
        }

        private void iniciarSesion_Load(object sender, EventArgs e)
        {
            txtCorreo.Focus();

            // Cargar logotipo institucional desde los recursos del sistema
            picLogoHero.Image = Tema.ObtenerLogo();

            btnVerContrasena.Text = "👁";

            // Microinteracciones de hover en botones
            btnIniciarSesion.MouseEnter += (s, ev) => btnIniciarSesion.BackColor = Tema.AzulOscuro;
            btnIniciarSesion.MouseLeave += (s, ev) => btnIniciarSesion.BackColor = Tema.AzulPrimario;
            btnVerContrasena.MouseEnter += (s, ev) => btnVerContrasena.BackColor = Tema.FondoSecundario;
            btnVerContrasena.MouseLeave += (s, ev) => btnVerContrasena.BackColor = Tema.Superficie;

            // Navegación ágil mediante teclado (Enter)
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
                    btnIniciarSesion_Click(btnIniciarSesion, EventArgs.Empty);
                    ev.Handled = true;
                    ev.SuppressKeyPress = true;
                }
            };

            // Estados de texto iniciales
            lblErrorCorreo.Text = "";
            lblErrorContrasena.Text = "La contraseña debe tener al menos 5 caracteres";
            lblErrorContrasena.ForeColor = Tema.TextoSecundario;

            // Inicializar diapositiva y arrancar temporizador de rotación
            ActualizarSlide();
            timerSlides.Start();

            // Distribuir paneles según la resolución inicial
            AjustarLayout();
        }

        private void iniciarSesion_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        // Distribución responsiva y armónica de los paneles Hero y Autenticación
        private void AjustarLayout()
        {
            int anchoTotal = this.ClientSize.Width;
            int altoTotal = this.ClientSize.Height;

            if (anchoTotal <= 0 || altoTotal <= 0)
                return;

            // Proporción aproximada: 58% Zona Hero visual y 42% Zona Autenticación
            int anchoHero = (int)(anchoTotal * 0.58f);
            if (anchoHero < 460)
                anchoHero = Math.Min(460, anchoTotal / 2);

            int anchoAuth = anchoTotal - anchoHero;

            panelHero.SetBounds(0, 0, anchoHero, altoTotal);
            panelAuth.SetBounds(anchoHero, 0, anchoAuth, altoTotal);

            // Ajuste interno de elementos en panelHero
            int margenIzquierdo = Math.Max(40, (anchoHero - 500) / 2);
            int anchoContenidoHero = Math.Min(480, anchoHero - (margenIzquierdo * 2));
            if (anchoContenidoHero < 340)
                anchoContenidoHero = anchoHero - 40;

            int topActual = Math.Max(25, (int)(altoTotal * 0.05f));
            picLogoHero.Location = new Point(margenIzquierdo, topActual);

            lblNombreHero.Location = new Point(margenIzquierdo - 3, picLogoHero.Bottom + 10);
            lblSubtituloHero.Location = new Point(margenIzquierdo, lblNombreHero.Bottom + 6);

            lblDescripcionHero.Location = new Point(margenIzquierdo, lblSubtituloHero.Bottom + 10);
            lblDescripcionHero.Width = anchoContenidoHero;

            panelSlideCard.Location = new Point(margenIzquierdo, lblDescripcionHero.Bottom + 16);
            panelSlideCard.Width = anchoContenidoHero;
            lblSlideDescripcion.Width = panelSlideCard.Width - lblSlideDescripcion.Left - 16;

            panelSlideIndicadores.Location = new Point(margenIzquierdo, panelSlideCard.Bottom + 10);
            panelSlideIndicadores.Width = anchoContenidoHero;

            // Ocultar lema si la altura es muy reducida para evitar solapamientos visuales
            if (altoTotal >= 650)
            {
                panelLema.Visible = true;
                panelLema.Location = new Point(margenIzquierdo, panelSlideIndicadores.Bottom + 16);
                panelLema.Width = anchoContenidoHero;
            }
            else
            {
                panelLema.Visible = false;
            }

            // Centrado dinámico de la tarjeta de login en panelAuth
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

        // Dibujo de ondas y formas orgánicas de fondo en el Hero
        private void panelHero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelHero.Width;
            int h = panelHero.Height;

            // Ondas sutiles que aportan dinamismo sin distraer la lectura
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

                    // Reiniciar el temporizador para otorgar tiempo de lectura completo
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
            // Franja lateral verde de acento
            using (Brush brushAcento = new SolidBrush(Tema.VerdeOscuro))
            {
                e.Graphics.FillRectangle(brushAcento, 0, 0, 4, panelLema.Height);
            }

            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelLema.Width - 1, panelLema.Height - 1);
            }
        }

        // Borde visual sutil para la tarjeta de autenticación
        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelCard.ClientSize.Width - 1, panelCard.ClientSize.Height - 1);
            }
        }

        // Validación en tiempo real del formato de correo
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                lblErrorCorreo.Text = "";
                return;
            }

            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(correo, patronCorreo))
            {
                lblErrorCorreo.Text = "Formato de correo inválido.";
                lblErrorCorreo.ForeColor = Tema.Error;
            }
            else
            {
                lblErrorCorreo.Text = "Formato correcto.";
                lblErrorCorreo.ForeColor = Tema.VerdeAcento;
            }
        }

        // Validación en tiempo real de la longitud de contraseña
        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            string pass = txtContrasena.Text;

            if (string.IsNullOrEmpty(pass))
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Tema.TextoSecundario;
                return;
            }

            if (pass.Length < 5)
            {
                lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
                lblErrorContrasena.ForeColor = Tema.Error;
            }
            else
            {
                lblErrorContrasena.Text = "Longitud de contraseña válida";
                lblErrorContrasena.ForeColor = Tema.VerdeAcento;
            }
        }

        // Alternar visualización de contraseña (mostrar/ocultar)
        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            if (txtContrasena.PasswordChar == '●')
            {
                txtContrasena.PasswordChar = '\0';
                btnVerContrasena.Text = "🙈";
            }
            else
            {
                txtContrasena.PasswordChar = '●';
                btnVerContrasena.Text = "👁";
            }

            txtContrasena.Focus();
            txtContrasena.SelectionStart = txtContrasena.Text.Length;
        }

        // Proceso de inicio de sesión y enrutamiento por roles
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su correo y contraseña para continuar.",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (contrasena.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.",
                                "Seguridad",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            usuariosControllers controlador = new usuariosControllers();
            int tipoUsuario = controlador.IniciarSesion(correo, contrasena);

            if (tipoUsuario != -1)
            {
                MessageBox.Show("¡Bienvenido al sistema Sanar Rural!",
                                "Inicio de Sesión Exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Enrutamiento según el rol asignado, ocultando la pantalla de inicio de sesión
                this.Hide();
                bool volverAlLogin = false;

                try
                {
                    if (tipoUsuario == controlador.ObtenerIdRol("Doctor"))
                    {
                        using (menuPrincipalMedicos menuMedico = new menuPrincipalMedicos())
                        {
                            menuMedico.ShowDialog();
                            volverAlLogin = menuMedico.SesionCerradaVoluntariamente;
                        }
                    }
                    else if (tipoUsuario == controlador.ObtenerIdRol("Administrativo"))
                    {
                        using (var menuAdmin = new SanarRuralUnan.Views.menuPrincipalAdministrativo())
                        {
                            menuAdmin.ShowDialog();
                            volverAlLogin = menuAdmin.SesionCerradaVoluntariamente;
                        }
                    }
                    else if (tipoUsuario == controlador.ObtenerIdRol("Paciente"))
                    {
                        MessageBox.Show("Aún no se ha creado el menú principal para Pacientes.", "Aviso");
                        controlador.CerrarSesion();
                        volverAlLogin = true;
                    }
                    else
                    {
                        MessageBox.Show("El rol de esta cuenta no está disponible en la aplicación.", "Aviso");
                        controlador.CerrarSesion();
                        volverAlLogin = true;
                    }
                }
                finally
                {
                    if (volverAlLogin)
                    {
                        txtContrasena.Clear();
                        txtCorreo.Focus();
                        this.Show();
                        this.WindowState = FormWindowState.Maximized;
                        this.BringToFront();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("El correo o la contraseña son incorrectos. Verifique sus datos.",
                                "Error de Autenticación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                txtContrasena.Clear();
                txtCorreo.Focus();
            }
        }

        // Navegación al registro de nuevo usuario
        private void lnkCrearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timerSlides.Stop();
            this.Hide();

            try
            {
                using (crearUsuario formCrear = new crearUsuario())
                {
                    formCrear.ShowDialog();

                    if (formCrear.DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(formCrear.CorreoRegistrado))
                    {
                        txtCorreo.Text = formCrear.CorreoRegistrado;
                        txtContrasena.Clear();
                        txtContrasena.Focus();
                    }
                    else
                    {
                        txtContrasena.Clear();
                        txtCorreo.Focus();
                    }
                }
            }
            finally
            {
                timerSlides.Start();
                this.Show();
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
            }
        }
    }
}
