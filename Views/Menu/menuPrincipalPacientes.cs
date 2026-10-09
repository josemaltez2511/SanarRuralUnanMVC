using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;
using SanarRuralUnan.Views.Citas;
using SanarRuralUnan.Views.HistorialClinico;
using SanarRuralUnan.Views.Pacientes;

namespace SanarRuralUnan.Views
{
    /// <summary>
    /// Shell principal moderno para pacientes de Sanar Rural.
    /// Incorpora cabecera panorámica con paisaje rural, navegación lateral y acceso directo
    /// a su perfil, citas médicas e historial clínico de forma segura y accesible.
    /// </summary>
    public partial class menuPrincipalPacientes : Form
    {
        private Form formularioActual;
        private perfilPaciente paginaPerfil;
        private paginaPrincipalCitas paginaCitas;
        private paginaPrincipalHistorial paginaHistorial;

        private readonly int? idPacienteActual;
        private Button botonActivo;
        private readonly Timer timerTransicion = new Timer();
        private int pasoAnimacion = 0;
        private Form formularioEntrante = null;

        public bool SesionCerradaVoluntariamente { get; private set; }

        public menuPrincipalPacientes()
        {
            InitializeComponent();
            idPacienteActual = new usuariosControllers().ObtenerIdPacienteActual();
            ConfigurarEstilos();
            CargarLogo();
            CargarDatosUsuario();

            timerTransicion.Interval = 20;
            timerTransicion.Tick += timerTransicion_Tick;

            MostrarSeccion("Perfil");
        }

        private void ConfigurarEstilos()
        {
            panelEncabezado.Paint += PanelEncabezado_Paint;
            panelEncabezado.Layout += (s, e) =>
            {
                lblDescripcion.Top = Math.Max(48, lblMarca.Bottom + 2);
            };
            panelBannerPaisaje.Paint += PanelBannerPaisaje_Paint;
            panelUsuario.Paint += PanelUsuario_Paint;
            lblAvatar.Paint += LblAvatar_Paint;
            panelSidebarLema.Paint += PanelSidebarLema_Paint;
            panelPlaceholder.Paint += PanelPlaceholder_Paint;

            ConfigurarBotonNavegacion(btnPerfil, "Perfil");
            ConfigurarBotonNavegacion(btnCitas, "Citas");
            ConfigurarBotonNavegacion(btnHistorial, "Historial");

            btnCerrarSesion.MouseEnter += (s, e) =>
            {
                btnCerrarSesion.BackColor = Tema.BotonPeligroFondo;
                btnCerrarSesion.FlatAppearance.BorderColor = Tema.BotonPeligroBorde;
                btnCerrarSesion.ForeColor = Tema.Error;
            };
            btnCerrarSesion.MouseLeave += (s, e) =>
            {
                btnCerrarSesion.BackColor = Tema.Superficie;
                btnCerrarSesion.FlatAppearance.BorderColor = Tema.Borde;
                btnCerrarSesion.ForeColor = Tema.TextoPrincipal;
            };
        }

        private void ConfigurarBotonNavegacion(Button boton, string seccion)
        {
            boton.MouseEnter += (s, e) =>
            {
                if (boton != botonActivo)
                {
                    boton.BackColor = Tema.FondoSecundario;
                    boton.ForeColor = Tema.AzulPrimario;
                }
            };

            boton.MouseLeave += (s, e) =>
            {
                if (boton != botonActivo)
                {
                    boton.BackColor = Color.Transparent;
                    boton.ForeColor = Tema.AzulOscuro;
                }
            };
        }

        private void CargarLogo()
        {
            Image logo = Tema.ObtenerLogo();
            if (logo != null)
            {
                picLogo.Image = logo;
            }
        }

        private void CargarDatosUsuario()
        {
            string nombreMostrar = "Paciente";
            string iniciales = "PA";

            try
            {
                if (idPacienteActual.HasValue && idPacienteActual.Value > 0)
                {
                    var pac = new pacientesControllers().obtenerPacienteDetalle(idPacienteActual.Value);
                    if (pac != null)
                    {
                        nombreMostrar = pac.PrimerNombre + " " + pac.PrimerApellido;
                        string i1 = !string.IsNullOrEmpty(pac.PrimerNombre) ? pac.PrimerNombre.Substring(0, 1) : "P";
                        string i2 = !string.IsNullOrEmpty(pac.PrimerApellido) ? pac.PrimerApellido.Substring(0, 1) : "A";
                        iniciales = (i1 + i2).ToUpper();
                    }
                }

                if (nombreMostrar == "Paciente" && !string.IsNullOrWhiteSpace(usuariosModels.CorreoActual))
                {
                    string nombre = usuariosModels.CorreoActual.Split('@')[0];
                    if (nombre.Length > 0)
                    {
                        nombreMostrar = char.ToUpper(nombre[0]) + nombre.Substring(1);
                        iniciales = nombre.Length >= 2 ? nombre.Substring(0, 2).ToUpper() : nombre.ToUpper();
                    }
                }
            }
            catch
            {
                nombreMostrar = "Paciente";
                iniciales = "PA";
            }

            lblUsuarioNombre.Text = nombreMostrar;
            lblAvatar.Text = iniciales;
            lblUsuarioRol.Text = "Paciente Registrado";
        }

        private void MostrarSeccion(string nombre)
        {
            Button nuevoBoton = null;
            Form formulario = null;

            if (nombre == "Perfil")
            {
                formulario = paginaPerfil ?? (paginaPerfil = new perfilPaciente(idPacienteActual));
                nuevoBoton = btnPerfil;
            }
            else if (nombre == "Citas")
            {
                formulario = paginaCitas ?? (paginaCitas = new paginaPrincipalCitas(null, idPacienteActual));
                nuevoBoton = btnCitas;
            }
            else if (nombre == "Historial")
            {
                formulario = paginaHistorial ?? (paginaHistorial = new paginaPrincipalHistorial(null, idPacienteActual));
                nuevoBoton = btnHistorial;
            }

            ActualizarEstadoBotones(nuevoBoton);

            if (formulario != null)
            {
                panelPlaceholder.Visible = false;
                if (formulario != formularioActual)
                {
                    EjecutarTransicion(formulario);
                }
            }
        }

        private void ActualizarEstadoBotones(Button activo)
        {
            botonActivo = activo;
            Button[] todos = { btnPerfil, btnCitas, btnHistorial };

            foreach (var b in todos)
            {
                if (b == botonActivo)
                {
                    b.BackColor = Tema.AzulPrimario;
                    b.ForeColor = Color.White;
                    b.Font = Tema.FuenteBoton;
                }
                else
                {
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Tema.AzulOscuro;
                    b.Font = Tema.FuenteBoton;
                }
            }
        }

        private void EjecutarTransicion(Form nuevoFormulario)
        {
            if (formularioActual == null)
            {
                formularioActual = nuevoFormulario;
                formularioActual.TopLevel = false;
                formularioActual.FormBorderStyle = FormBorderStyle.None;
                formularioActual.Dock = DockStyle.Fill;
                panelContenido.Controls.Add(formularioActual);
                formularioActual.Show();
                return;
            }

            formularioEntrante = nuevoFormulario;
            formularioEntrante.TopLevel = false;
            formularioEntrante.FormBorderStyle = FormBorderStyle.None;
            formularioEntrante.Dock = DockStyle.Fill;
            formularioEntrante.Visible = false;
            panelContenido.Controls.Add(formularioEntrante);

            pasoAnimacion = 0;
            timerTransicion.Start();
        }

        private void timerTransicion_Tick(object sender, EventArgs e)
        {
            pasoAnimacion++;
            if (pasoAnimacion >= 5)
            {
                timerTransicion.Stop();
                if (formularioActual != null)
                {
                    panelContenido.Controls.Remove(formularioActual);
                }
                formularioActual = formularioEntrante;
                if (formularioActual != null)
                {
                    formularioActual.Visible = true;
                    formularioActual.BringToFront();
                }
                formularioEntrante = null;
            }
        }

        private void CentrarPlaceholder()
        {
            if (panelPlaceholder.Visible && panelContenido.Width > 0 && panelContenido.Height > 0)
            {
                int x = Math.Max(20, (panelContenido.ClientSize.Width - panelPlaceholder.Width) / 2);
                int y = Math.Max(20, (panelContenido.ClientSize.Height - panelPlaceholder.Height) / 2);
                panelPlaceholder.Location = new Point(x, y);
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e) { MostrarSeccion("Perfil"); }
        private void btnCitas_Click(object sender, EventArgs e) { MostrarSeccion("Citas"); }
        private void btnHistorial_Click(object sender, EventArgs e) { MostrarSeccion("Historial"); }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionCerradaVoluntariamente = true;
            new usuariosControllers().CerrarSesion();
            Close();
        }

        private void menuPrincipalPacientes_Resize(object sender, EventArgs e)
        {
            CentrarPlaceholder();
        }

        private void menuPrincipalPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerTransicion.Dispose();
            if (paginaPerfil != null) paginaPerfil.Dispose();
            if (paginaCitas != null) paginaCitas.Dispose();
            if (paginaHistorial != null) paginaHistorial.Dispose();
            if (picLogo.Image != null) picLogo.Image.Dispose();
        }

        // ===== PINTADO GDI+ DECORATIVO DE IDENTIDAD VISUAL =====

        private void PanelEncabezado_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawLine(pen, 0, panelEncabezado.Height - 1, panelEncabezado.Width, panelEncabezado.Height - 1);
            }
        }

        private void PanelBannerPaisaje_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelBannerPaisaje.Width;
            int h = panelBannerPaisaje.Height;
            if (w <= 80 || h <= 20) return;

            // Cielo con degradado suave hacia la superficie
            using (var skyBrush = new LinearGradientBrush(
                new Point(0, 0), new Point(0, h),
                Color.FromArgb(243, 250, 246),
                Tema.Superficie))
            {
                g.FillRectangle(skyBrush, 0, 0, w, h);
            }

            // Cordillera lejana en tono azul-cielo
            using (var pathMtn = new GraphicsPath())
            {
                pathMtn.AddLine(0, h, 0, (int)(h * 0.48f));
                pathMtn.AddCurve(new Point[]
                {
                    new Point(0, (int)(h * 0.48f)),
                    new Point((int)(w * 0.16f), (int)(h * 0.38f)),
                    new Point((int)(w * 0.32f), (int)(h * 0.22f)),
                    new Point((int)(w * 0.50f), (int)(h * 0.14f)),
                    new Point((int)(w * 0.68f), (int)(h * 0.24f)),
                    new Point((int)(w * 0.84f), (int)(h * 0.36f)),
                    new Point(w, (int)(h * 0.46f))
                }, 0.5f);
                pathMtn.AddLine(w, (int)(h * 0.46f), w, h);
                pathMtn.CloseFigure();

                using (var brushMtn = new LinearGradientBrush(
                    new Point(0, 0), new Point(0, h),
                    Color.FromArgb(178, 214, 235),
                    Color.FromArgb(220, 238, 246)))
                {
                    g.FillPath(brushMtn, pathMtn);
                }
            }

            // Colinas intermedias en verde pastel
            using (var pathHills = new GraphicsPath())
            {
                pathHills.AddLine(0, h, 0, (int)(h * 0.64f));
                pathHills.AddCurve(new Point[]
                {
                    new Point(0, (int)(h * 0.64f)),
                    new Point((int)(w * 0.22f), (int)(h * 0.50f)),
                    new Point((int)(w * 0.44f), (int)(h * 0.38f)),
                    new Point((int)(w * 0.62f), (int)(h * 0.46f)),
                    new Point((int)(w * 0.82f), (int)(h * 0.40f)),
                    new Point(w, (int)(h * 0.58f))
                }, 0.5f);
                pathHills.AddLine(w, (int)(h * 0.58f), w, h);
                pathHills.CloseFigure();

                using (var brushHills = new LinearGradientBrush(
                    new Point(0, 0), new Point(0, h),
                    Color.FromArgb(148, 202, 160),
                    Color.FromArgb(205, 235, 214)))
                {
                    g.FillPath(brushHills, pathHills);
                }
            }

            // Colinas frontales en verde naturaleza
            using (var pathFront = new GraphicsPath())
            {
                pathFront.AddLine(0, h, 0, (int)(h * 0.80f));
                pathFront.AddCurve(new Point[]
                {
                    new Point(0, (int)(h * 0.80f)),
                    new Point((int)(w * 0.18f), (int)(h * 0.66f)),
                    new Point((int)(w * 0.38f), (int)(h * 0.72f)),
                    new Point((int)(w * 0.58f), (int)(h * 0.60f)),
                    new Point((int)(w * 0.78f), (int)(h * 0.68f)),
                    new Point(w, (int)(h * 0.76f))
                }, 0.5f);
                pathFront.AddLine(w, (int)(h * 0.76f), w, h);
                pathFront.CloseFigure();

                using (var brushFront = new LinearGradientBrush(
                    new Point(0, 0), new Point(0, h),
                    Color.FromArgb(105, 175, 120),
                    Color.FromArgb(145, 200, 155)))
                {
                    g.FillPath(brushFront, pathFront);
                }
            }

            // Siluetas de árboles estilizados
            DibujarArbol(g, (int)(w * 0.28f), (int)(h * 0.54f), 10, 16, Color.FromArgb(70, 138, 85));
            DibujarArbol(g, (int)(w * 0.33f), (int)(h * 0.58f), 8, 13, Color.FromArgb(60, 128, 75));
            DibujarArbol(g, (int)(w * 0.72f), (int)(h * 0.48f), 12, 18, Color.FromArgb(65, 130, 80));
            DibujarArbol(g, (int)(w * 0.77f), (int)(h * 0.52f), 9, 14, Color.FromArgb(75, 142, 90));

            // Difuminado lateral para fundir con la superficie
            int anchoFade = Math.Min(120, (int)(w * 0.22f));
            if (anchoFade > 10)
            {
                using (var fadeLeft = new LinearGradientBrush(
                    new Rectangle(0, 0, anchoFade, h),
                    Tema.Superficie, Color.FromArgb(0, Tema.Superficie),
                    LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(fadeLeft, 0, 0, anchoFade, h);
                }

                using (var fadeRight = new LinearGradientBrush(
                    new Rectangle(w - anchoFade, 0, anchoFade, h),
                    Color.FromArgb(0, Tema.Superficie), Tema.Superficie,
                    LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(fadeRight, w - anchoFade, 0, anchoFade, h);
                }
            }
        }

        private static void DibujarArbol(Graphics g, int x, int y, int ancho, int alto, Color color)
        {
            using (var brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, x - (ancho / 2), y - (alto / 2), ancho, alto);
                using (var troncoBrush = new SolidBrush(Color.FromArgb(110, 80, 50)))
                {
                    g.FillRectangle(troncoBrush, x - 1, y + (alto / 2) - 2, 2, 4);
                }
            }
        }

        private void PanelUsuario_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelUsuario.Width - 1, panelUsuario.Height - 1), 22))
            {
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void LblAvatar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Fondo circular suave para el avatar del paciente
            using (var brush = new SolidBrush(Color.FromArgb(235, 248, 238)))
            {
                g.FillEllipse(brush, 1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
            }

            // Borde circular sutil
            using (var pen = new Pen(Color.FromArgb(207, 235, 214), 1f))
            {
                g.DrawEllipse(pen, 1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
            }

            // Iniciales centradas con color verde oscuro
            using (var brushTexto = new SolidBrush(lblAvatar.ForeColor))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(lblAvatar.Text, lblAvatar.Font, brushTexto, new RectangleF(0, 0, lblAvatar.Width, lblAvatar.Height), sf);
            }
        }

        private void PanelSidebarLema_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = panelSidebarLema.Width;
            int h = panelSidebarLema.Height;

            // Siluetas orgánicas de hojas en la esquina inferior
            using (var leafBrush = new SolidBrush(Color.FromArgb(45, Tema.Verde)))
            {
                g.FillEllipse(leafBrush, -15, h - 55, 65, 38);
                g.FillEllipse(leafBrush, 18, h - 38, 55, 32);
            }

            // Comillas institucionales
            using (var quoteBrush = new SolidBrush(Tema.VerdeOscuro))
            using (var fontQuotes = new Font(Tema.FamiliaFuente, 18F, FontStyle.Bold))
            {
                g.DrawString("“", fontQuotes, quoteBrush, 6f, 8f);
                g.DrawString("”", fontQuotes, quoteBrush, (float)(w - 24), (float)(h - 36));
            }

            // Lema centrado
            using (var textBrush = new SolidBrush(Tema.TextoSecundario))
            using (var fontLema = new Font(Tema.FamiliaFuente, 9.2F, FontStyle.Italic))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                var textRect = new Rectangle(14, 16, w - 28, h - 36);
                g.DrawString("\"Salud\nmás cerca\nde nuestra\ngente\"", fontLema, textBrush, textRect, sf);
            }
        }

        private void PanelPlaceholder_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelPlaceholder.Width - 1, panelPlaceholder.Height - 1), 16))
            {
                using (var pen = new Pen(Tema.Borde, 1.2f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
