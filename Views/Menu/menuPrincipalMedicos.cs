using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Pacientes;
using SanarRuralUnan.Views.Citas;

namespace SanarRuralUnan.Views
{
    public partial class menuPrincipalMedicos : MaterialForm
    {
        private Form formularioActual;
        private paginaPrincipalPacientes paginaPacientes;
        private paginaPrincipalCitas paginaCitas;
        private readonly int? idDoctorActual;
        private Button botonActivo;
        public bool SesionCerradaVoluntariamente { get; private set; }

        public menuPrincipalMedicos()
        {
            InitializeComponent();
            idDoctorActual = new usuariosControllers().ObtenerIdDoctorActual();
            ConfigurarTema();
            CargarLogo();
            ConfigurarEventosBotones();
            FormClosed += menuPrincipalMedicos_FormClosed;
            OrganizarBarra();
            btnPacientes_Click(this, EventArgs.Empty);
        }

        private void ConfigurarTema()
        {
            MaterialSkinManager skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(
                Primary.Blue700,
                Primary.Blue800,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void CargarLogo()
        {
            Image logo = Tema.ObtenerLogo();
            if (logo != null)
            {
                picLogo.Image = logo;
            }
        }

        private void ConfigurarEventosBotones()
        {
            Button[] botones = { btnPacientes, btnCitas, btnConsultas, btnHistorial };
            foreach (Button b in botones)
            {
                b.MouseEnter += BotonNav_MouseEnter;
                b.MouseLeave += BotonNav_MouseLeave;
            }

            panelPlaceholder.Paint += PanelPlaceholder_Paint;
        }

        private void PanelPlaceholder_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Tema.Borde, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panelPlaceholder.Width - 1, panelPlaceholder.Height - 1);
            }
        }

        private void BotonNav_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null && b != botonActivo)
            {
                b.BackColor = Tema.Fondo;
            }
        }

        private void BotonNav_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null && b != botonActivo)
            {
                b.BackColor = Color.Transparent;
            }
        }

        private void ActualizarPestanaActiva(Button boton)
        {
            botonActivo = boton;
            Button[] botones = { btnPacientes, btnCitas, btnConsultas, btnHistorial };

            foreach (Button b in botones)
            {
                if (b == botonActivo)
                {
                    b.BackColor = Tema.Superficie;
                    b.ForeColor = Tema.AzulPrimario;
                    b.Font = Tema.FuenteBoton;
                }
                else
                {
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Tema.TextoSecundario;
                    b.Font = Tema.FuenteLabelCampo;
                }
            }

            if (botonActivo != null)
            {
                panelIndicador.Left = botonActivo.Left;
                panelIndicador.Width = botonActivo.Width;
                panelIndicador.Visible = true;
            }
        }

        private void OrganizarBarra()
        {
            int ancho = panelEncabezado.Width;
            btnCerrarSesion.Location = new Point(ancho - btnCerrarSesion.Width - 24, 20);
            panelUsuario.Location = new Point(btnCerrarSesion.Left - panelUsuario.Width - 16, 16);

            if (botonActivo != null)
            {
                panelIndicador.Left = botonActivo.Left;
                panelIndicador.Width = botonActivo.Width;
            }

            CentrarPlaceholder();
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

        public void CargarFormulario(Form formulario)
        {
            panelPlaceholder.Visible = false;

            if (formularioActual != null && formularioActual != formulario)
                formularioActual.Visible = false;

            formularioActual = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            if (!panelContenido.Controls.Contains(formulario))
            {
                panelContenido.Controls.Add(formulario);
            }

            formulario.Visible = true;
            formulario.BringToFront();
        }

        private void MostrarSeccionEnPreparacion(string titulo, string descripcion)
        {
            if (formularioActual != null)
            {
                formularioActual.Visible = false;
                formularioActual = null;
            }

            lblSeccion.Text = titulo;
            lblContenido.Text = descripcion;
            panelPlaceholder.Visible = true;
            CentrarPlaceholder();
            panelPlaceholder.BringToFront();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            ActualizarPestanaActiva(btnPacientes);
            paginaPacientes = paginaPacientes ?? new paginaPrincipalPacientes();
            CargarFormulario(paginaPacientes);
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            ActualizarPestanaActiva(btnCitas);
            paginaCitas = paginaCitas ?? new paginaPrincipalCitas(idDoctorActual ?? -1);
            CargarFormulario(paginaCitas);
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            ActualizarPestanaActiva(btnConsultas);
            MostrarSeccionEnPreparacion(
                "Consultas Médicas",
                "El módulo de registro y atención médica directa estará disponible en la próxima entrega del sistema.");
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            ActualizarPestanaActiva(btnHistorial);
            MostrarSeccionEnPreparacion(
                "Historial Clínico",
                "El módulo de trazabilidad y consulta cronológica de atenciones clínicas se incorporará en la siguiente fase de desarrollo.");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionCerradaVoluntariamente = true;
            new usuariosControllers().CerrarSesion();
            Close();
        }

        private void menuPrincipalMedicos_Resize(object sender, EventArgs e)
        {
            OrganizarBarra();
        }

        private void menuPrincipalMedicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (paginaPacientes != null) paginaPacientes.Dispose();
            if (paginaCitas != null) paginaCitas.Dispose();
            if (picLogo.Image != null) picLogo.Image.Dispose();
        }
    }
}
