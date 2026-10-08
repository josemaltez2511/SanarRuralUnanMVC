using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;
using SanarRuralUnan.Views.Hospitales;
using SanarRuralUnan.Views.Pacientes;
using SanarRuralUnan.Views.Citas;

namespace SanarRuralUnan.Views
{
    public partial class menuPrincipalAdministrativo : MaterialForm
    {
        private Form formularioActual;
        private paginaPrincipalUsuarios paginaUsuarios;
        private paginaPrincipalDoctores paginaDoctores;
        private paginaPrincipalHospitales paginaHospitales;
        private paginaPrincipalPacientes paginaPacientes;
        private paginaPrincipalCitas paginaCitas;
        private readonly Timer timerIndicador = new Timer();
        private MaterialButton botonActivo;
        private int inicioIndicador;
        private int destinoIndicador;
        private int tiempoIndicador;
        public bool SesionCerradaVoluntariamente { get; private set; }

        public menuPrincipalAdministrativo()
        {
            InitializeComponent();
            ConfigurarTema();
            CargarLogo();
            timerIndicador.Interval = 16;
            timerIndicador.Tick += timerIndicador_Tick;
            FormClosed += menuPrincipalAdministrativo_FormClosed;
            MostrarSeccion("Usuarios");
            OrganizarBarra();
        }

        private void ConfigurarTema()
        {
            MaterialSkinManager skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue800, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void CargarLogo()
        {
            byte[] datos = Properties.Resources.ResourceManager.GetObject("SanarRuralLogo") as byte[];
            if (datos == null)
                return;

            using (var flujo = new MemoryStream(datos))
            using (var imagen = Image.FromStream(flujo))
            {
                picLogo.Image = new Bitmap(imagen);
            }
        }

        private void OrganizarBarra()
        {
            int x = 24;
            btnUsuarios.Location = new System.Drawing.Point(x, 7);
            btnDoctores.Location = new System.Drawing.Point(btnUsuarios.Right + 8, 7);
            btnPacientes.Location = new System.Drawing.Point(btnDoctores.Right + 8, 7);
            btnHospitales.Location = new System.Drawing.Point(btnPacientes.Right + 8, 7);
            btnCitas.Location = new System.Drawing.Point(btnHospitales.Right + 8, 7);
            btnCerrarSesion.Location = new System.Drawing.Point(panelEncabezado.Width - btnCerrarSesion.Width - 20, 18);
            lblRol.Location = new System.Drawing.Point(btnCerrarSesion.Left - lblRol.Width - 18, 26);
            if (botonActivo != null)
            {
                timerIndicador.Stop();
                panelIndicador.Left = botonActivo.Left;
            }
        }

        private void MostrarSeccion(string nombre)
        {
            Form formulario = null;
            if (nombre == "Usuarios")
                formulario = paginaUsuarios ?? (paginaUsuarios = new paginaPrincipalUsuarios());
            else if (nombre == "Doctores")
                formulario = paginaDoctores ?? (paginaDoctores = new paginaPrincipalDoctores());
            else if (nombre == "Hospitales")
                formulario = paginaHospitales ?? (paginaHospitales = new paginaPrincipalHospitales());
            else if (nombre == "Pacientes")
                formulario = paginaPacientes ?? (paginaPacientes = new paginaPrincipalPacientes());
            else if (nombre == "Citas")
                formulario = paginaCitas ?? (paginaCitas = new paginaPrincipalCitas());

            if (formularioActual != formulario && formularioActual != null)
                formularioActual.Visible = false;

            panelContenido.Controls.Clear();
            if (formulario != null)
                MostrarFormulario(formulario);
            btnUsuarios.Text = nombre == "Usuarios" ? "✓  Usuarios" : "Usuarios";
            btnDoctores.Text = nombre == "Doctores" ? "✓  Doctores" : "Doctores";
            btnPacientes.Text = nombre == "Pacientes" ? "✓  Pacientes" : "Pacientes";
            btnHospitales.Text = nombre == "Hospitales" ? "✓  Hospitales" : "Hospitales";
            btnCitas.Text = nombre == "Citas" ? "✓  Citas" : "Citas";
            btnUsuarios.Type = nombre == "Usuarios" ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Text;
            btnDoctores.Type = nombre == "Doctores" ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Text;
            btnPacientes.Type = nombre == "Pacientes" ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Text;
            btnHospitales.Type = nombre == "Hospitales" ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Text;
            btnCitas.Type = nombre == "Citas" ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Text;
            lblSeccion.Text = "Sección actual: " + nombre;
            botonActivo = nombre == "Usuarios" ? btnUsuarios :
                nombre == "Doctores" ? btnDoctores :
                nombre == "Pacientes" ? btnPacientes :
                nombre == "Hospitales" ? btnHospitales : btnCitas;
            AnimarIndicador(botonActivo.Left);
        }

        private void AnimarIndicador(int destino)
        {
            inicioIndicador = panelIndicador.Left;
            destinoIndicador = destino;
            tiempoIndicador = 0;
            timerIndicador.Start();
        }

        private void timerIndicador_Tick(object sender, EventArgs e)
        {
            tiempoIndicador += timerIndicador.Interval;
            double progreso = Math.Min(1.0, tiempoIndicador / (double)Tema.AnimacionNormal);
            double suavizado = 1 - Math.Pow(1 - progreso, 2);
            panelIndicador.Left = inicioIndicador + (int)Math.Round((destinoIndicador - inicioIndicador) * suavizado);

            if (progreso >= 1.0)
            {
                panelIndicador.Left = destinoIndicador;
                timerIndicador.Stop();
            }
        }

        public void CargarFormulario(Form formulario)
        {
            panelContenido.Controls.Clear();
            MostrarFormulario(formulario);
        }

        private void MostrarFormulario(Form formulario)
        {
            formularioActual = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formulario);
            formulario.Show();
            formulario.BringToFront();
        }

        private void btnUsuarios_Click(object sender, EventArgs e) { MostrarSeccion("Usuarios"); }
        private void btnDoctores_Click(object sender, EventArgs e) { MostrarSeccion("Doctores"); }
        private void btnPacientes_Click(object sender, EventArgs e) { MostrarSeccion("Pacientes"); }
        private void btnHospitales_Click(object sender, EventArgs e) { MostrarSeccion("Hospitales"); }
        private void btnCitas_Click(object sender, EventArgs e) { MostrarSeccion("Citas"); }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionCerradaVoluntariamente = true;
            new usuariosControllers().CerrarSesion();
            Close();
        }

        private void menuPrincipalAdministrativo_Resize(object sender, EventArgs e)
        {
            OrganizarBarra();
        }

        private void menuPrincipalAdministrativo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (paginaUsuarios != null) paginaUsuarios.Dispose();
            if (paginaDoctores != null) paginaDoctores.Dispose();
            if (paginaHospitales != null) paginaHospitales.Dispose();
            if (paginaPacientes != null) paginaPacientes.Dispose();
            if (paginaCitas != null) paginaCitas.Dispose();
            if (picLogo.Image != null) picLogo.Image.Dispose();
            timerIndicador.Dispose();
        }
    }
}
