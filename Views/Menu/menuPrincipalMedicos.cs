using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Views.Hospitales;

namespace SanarRuralUnan.Views
{
    public partial class menuPrincipalMedicos : Form
    {
        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        // El Menú Principal se abre siempre después de iniciar sesión
        // o de registrarse con éxito.

        public menuPrincipalMedicos()
        {
            InitializeComponent();
        }

        // ============================================================
        // CENTRAR TARJETA
        // ============================================================
        private void CentrarPanelCard()
        {
            int x = (this.ClientSize.Width - panelCard.Width) / 2;
            int y = (this.ClientSize.Height - panelCard.Height) / 2;

            panelCard.Location = new System.Drawing.Point(
                Math.Max(10, x),
                Math.Max(10, y)
            );
        }

        // ============================================================
        // LOAD
        // ============================================================
        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        private void menuPrincipal_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
        }

        // ============================================================
        // MÓDULO DE PACIENTES
        // ============================================================
        // NOTA: crearPaciente pide un idUsuario en su constructor
        // (porque normalmente se abre justo después de crear la cuenta).
        // Como aquí entramos desde el Menú y no tenemos un usuario nuevo
        // recién creado, mandamos 0 para indicar "sin usuario asociado".
        // Cuando se arme la pantalla de LISTADO de pacientes, esta será
        // la que reemplace esta llamada directa.

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            crearPaciente formPaciente = new crearPaciente(0);
            formPaciente.Show();
            this.Hide();
        }

        // ============================================================
        // MÓDULO DE DOCTORES
        // ============================================================
        // Mismo caso que Pacientes: se manda 0 porque no viene
        // de un registro de usuario recién creado.

        private void btnDoctores_Click(object sender, EventArgs e)
        {
            crearDoctor formDoctor = new crearDoctor(0);
            formDoctor.Show();
            this.Hide();
        }

        // ============================================================
        // MÓDULO DE HOSPITALES
        // ============================================================

        private void btnHospitales_Click(object sender, EventArgs e)
        {
            crearHospital formHospital = new crearHospital();
            formHospital.Show();
            this.Hide();
        }

        // ============================================================
        // CERRAR SESIÓN
        // ============================================================
        // Usamos el Controller de usuarios para limpiar la sesión actual
        // (usuariosControllers.CerrarSesion), y luego mandamos
        // de regreso a la pantalla de Iniciar Sesión.

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            usuariosControllers controlador = new usuariosControllers();
            controlador.CerrarSesion();

            iniciarSesion login = new iniciarSesion();
            login.Show();
            this.Close();
        }

        private void panelCard_Paint(object sender, PaintEventArgs e) { }
    }
}