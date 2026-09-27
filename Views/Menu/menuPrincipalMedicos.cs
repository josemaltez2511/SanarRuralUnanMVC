using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Views.Doctores;
using SanarRuralUnan.Views.Hospitales;

namespace SanarRuralUnan.Views
{
    public partial class menuPrincipalMedicos : Form
    {
        public menuPrincipalMedicos()
        {
            InitializeComponent();
        }

        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;

            panelCard.Location = new Point(
                Math.Max(10, x),
                Math.Max(10, y)
            );
        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        private void menuPrincipal_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            crearPaciente formPaciente = new crearPaciente(0);
            formPaciente.Show();
            this.Hide();
        }

        private void btnDoctores_Click(object sender, EventArgs e)
        {
            paginaPrincipalDoctores formDoctores = new paginaPrincipalDoctores();
            formDoctores.Show();
            this.Hide();
        }

        private void btnHospitales_Click(object sender, EventArgs e)
        {
            crearHospital formHospital = new crearHospital();
            formHospital.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            usuariosControllers controlador = new usuariosControllers();
            controlador.CerrarSesion();

            iniciarSesion login = new iniciarSesion();
            login.Show();
            this.Close();
        }
    }
}