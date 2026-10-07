using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Views.Pacientes;
using SanarRuralUnan.Views.Citas;
using SanarRuralUnan.Views.ConsultaMedica;

namespace SanarRuralUnan.Views
{
    public partial class menuPrincipalMedicos : MaterialForm
    {
        private Form formularioActual;
        private paginaPrincipalPacientes paginaPacientes;
        private paginaPrincipalCitas paginaCitas;
        private paginaPrincipalConsultas paginaConsultas;
        private readonly int? idDoctorActual;

        public menuPrincipalMedicos()
        {
            InitializeComponent();
            idDoctorActual = new usuariosControllers().ObtenerIdDoctorActual();
            ConfigurarTema();
            CargarLogo();
            FormClosed += menuPrincipalMedicos_FormClosed;
            OrganizarBarra();
            btnPacientes_Click(this, EventArgs.Empty);
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
            btnPacientes.Location = new System.Drawing.Point(x, 7);
            btnCitas.Location = new System.Drawing.Point(btnPacientes.Right + 8, 7);
            btnConsultas.Location = new System.Drawing.Point(btnCitas.Right + 8, 7);
            btnHistorial.Location = new System.Drawing.Point(btnConsultas.Right + 8, 7);
            btnCerrarSesion.Location = new System.Drawing.Point(panelEncabezado.Width - btnCerrarSesion.Width - 20, 18);
            lblRol.Location = new System.Drawing.Point(btnCerrarSesion.Left - lblRol.Width - 18, 26);
        }

        private void MostrarSeccion(string nombre, string mensaje)
        {
            if (formularioActual != null)
                formularioActual.Visible = false;

            formularioActual = null;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(lblSeccion);
            panelContenido.Controls.Add(lblContenido);
            lblSeccion.Text = "Sección actual: " + nombre;
            lblContenido.Text = mensaje;
            btnPacientes.Text = nombre == "Pacientes" ? "✓  Pacientes" : "Pacientes";
            btnPacientes.Type = nombre == "Pacientes" ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Text;
            btnCitas.Type = MaterialButton.MaterialButtonType.Text;
            btnConsultas.Type = MaterialButton.MaterialButtonType.Text;
            btnHistorial.Type = MaterialButton.MaterialButtonType.Text;
        }

        public void CargarFormulario(Form formulario)
        {
            panelContenido.Controls.Clear();
            if (formularioActual != null)
                formularioActual.Visible = false;
            formularioActual = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formulario);
            formulario.Show();
            formulario.BringToFront();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            paginaPacientes = paginaPacientes ?? new paginaPrincipalPacientes();
            CargarFormulario(paginaPacientes);
            lblSeccion.Text = "Sección actual: Pacientes";
            lblContenido.Text = "Listado de pacientes activos.";
            btnPacientes.Text = "✓  Pacientes";
            btnPacientes.Type = MaterialButton.MaterialButtonType.Contained;
            btnCitas.Text = "Citas";
            btnCitas.Type = MaterialButton.MaterialButtonType.Text;
            btnConsultas.Text = "Consultas";
            btnConsultas.Type = MaterialButton.MaterialButtonType.Text;
            btnHistorial.Type = MaterialButton.MaterialButtonType.Text;
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            paginaCitas = paginaCitas ?? new paginaPrincipalCitas(idDoctorActual ?? -1);
            CargarFormulario(paginaCitas);
            lblSeccion.Text = "Sección actual: Citas";
            lblContenido.Text = "Control y seguimiento de citas médicas.";
            btnCitas.Text = "✓  Citas";
            btnCitas.Type = MaterialButton.MaterialButtonType.Contained;
            btnPacientes.Text = "Pacientes";
            btnPacientes.Type = MaterialButton.MaterialButtonType.Text;
            btnConsultas.Text = "Consultas";
            btnConsultas.Type = MaterialButton.MaterialButtonType.Text;
            btnHistorial.Type = MaterialButton.MaterialButtonType.Text;
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            paginaConsultas = paginaConsultas ?? new paginaPrincipalConsultas(idDoctorActual ?? -1);
            CargarFormulario(paginaConsultas);
            lblSeccion.Text = "Sección actual: Consultas";
            lblContenido.Text = "Atención clínica y seguimiento de pacientes.";
            btnConsultas.Text = "✓  Consultas";
            btnConsultas.Type = MaterialButton.MaterialButtonType.Contained;
            btnPacientes.Text = "Pacientes";
            btnPacientes.Type = MaterialButton.MaterialButtonType.Text;
            btnCitas.Text = "Citas";
            btnCitas.Type = MaterialButton.MaterialButtonType.Text;
            btnHistorial.Type = MaterialButton.MaterialButtonType.Text;
        }

        private void btnFuturo_Click(object sender, EventArgs e)
        {
            MaterialButton boton = sender as MaterialButton;
            if (boton != null)
                MostrarSeccion(boton.AccessibleName, "Esta sección se incorporará cuando esté implementado el módulo correspondiente.");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
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
            if (paginaConsultas != null) paginaConsultas.Dispose();
            if (picLogo.Image != null) picLogo.Image.Dispose();
        }
    }
}
