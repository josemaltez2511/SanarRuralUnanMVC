using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    public partial class crearHospital : Form
    {
        // La Vista utiliza el Controller para comunicarse con el Modelo.
        // La Vista nunca accede directamente a la base de datos.
        private readonly hospitalesController controlador = new hospitalesController();
        private readonly int? idHospital;
        private bool cargandoCatalogos;

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

        public crearHospital()
        {
            InitializeComponent();
            ConfigurarOptimizacionesVisuales();
        }

        public crearHospital(int idHospital) : this()
        {
            this.idHospital = idHospital;
        }

        private void ConfigurarOptimizacionesVisuales()
        {
            DoubleBuffered = true;
            HabilitarDobleBufer(panelHero);
            HabilitarDobleBufer(panelFormContenedor);
            HabilitarDobleBufer(panelScroll);
            HabilitarDobleBufer(cardHeader);
            HabilitarDobleBufer(cardUbicacion);
            HabilitarDobleBufer(cardDatos);
            HabilitarDobleBufer(panelAcciones);
            HabilitarDobleBufer(panelLema);
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

        // Carga los departamentos y, al editar, selecciona el municipio del hospital.
        private void crearHospital_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar logotipo institucional de Sanar Rural
                picLogoHero.Image = Tema.ObtenerLogo();

                ConfigurarEstilosVisuales();
                ConfigurarPlaceholders();
                CargarDepartamentos();

                if (idHospital.HasValue)
                {
                    SanarRuralUnan.Hospitales hospital = controlador.consultarHospital(idHospital.Value);
                    if (hospital == null)
                    {
                        MessageBox.Show("El hospital ya no está disponible.", "Hospital no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                        return;
                    }

                    txtNombre.Text = hospital.Nombre;
                    txtDireccion.Text = hospital.Direccion;
                    txtTelefono.Text = hospital.Telefono;

                    cargandoCatalogos = true;
                    cmbDepartamento.SelectedValue = hospital.Municipios.IdDepartamento;
                    CargarMunicipios(hospital.Municipios.IdDepartamento);
                    cmbMunicipio.SelectedValue = hospital.IdMunicipio;
                    cargandoCatalogos = false;

                    Text = "Sanar Rural - Editar Hospital";
                    lblTitulo.Text = "Editar Sede Hospitalaria";
                    lblSubtitulo.Text = "Modifique la información y cobertura territorial de la instalación médica.";
                    btnGuardar.Text = "Guardar Cambios";
                }

                AjustarLayoutResponsive();
                Resize += (s, ev) => AjustarLayoutResponsive();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos del hospital:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void ConfigurarEstilosVisuales()
        {
            // Dibujado de tarjetas redondeadas con bordes suaves
            panelHero.Paint += panelHero_Paint;
            cardHeader.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardHeader.Width - 1, cardHeader.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardUbicacion.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardUbicacion.Width - 1, cardUbicacion.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardDatos.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardDatos.Width - 1, cardDatos.Height - 1), Tema.Superficie, Tema.Borde, 10);
            panelLema.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelLema.Width - 1, panelLema.Height - 1), Color.FromArgb(25, 255, 255, 255), Color.FromArgb(60, 255, 255, 255), 10);

            // Microinteracciones de botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;
        }

        private void panelHero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (LinearGradientBrush brush = new LinearGradientBrush(panelHero.ClientRectangle, Tema.AzulOscuro, Color.FromArgb(20, 50, 85), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panelHero.ClientRectangle);
            }
        }

        private void ConfigurarPlaceholders()
        {
            AsignarPlaceholder(txtNombre, "Ej. Hospital Primario San Juan de Dios");
            AsignarPlaceholder(txtTelefono, "Ej. 2222-3344 / 8888-9999");
            AsignarPlaceholder(txtDireccion, "Ej. Del parque central 2 c. al norte, comunidad rural");
        }

        private void AjustarLayoutResponsive()
        {
            if (panelScroll == null) return;
            int anchoDisponible = panelScroll.ClientSize.Width - 48;
            if (anchoDisponible < 400) anchoDisponible = 400;

            cardHeader.Width = anchoDisponible;
            cardUbicacion.Width = anchoDisponible;
            cardDatos.Width = anchoDisponible;
            panelAcciones.Width = anchoDisponible;

            // Ajustar anchos relativos de los combos en cardUbicacion
            int anchoCombo = (anchoDisponible - 40 - 20) / 2;
            if (anchoCombo > 100)
            {
                cmbDepartamento.Width = anchoCombo;
                lblMunicipio.Left = cmbDepartamento.Right + 20;
                cmbMunicipio.Left = cmbDepartamento.Right + 20;
                cmbMunicipio.Width = anchoCombo;
            }
        }

        private void CargarDepartamentos()
        {
            cargandoCatalogos = true;
            cmbDepartamento.DisplayMember = "Nombre";
            cmbDepartamento.ValueMember = "IdDepartamento";
            cmbDepartamento.DataSource = controlador.listarDepartamentos();
            cmbDepartamento.SelectedIndex = -1;
            cmbMunicipio.DataSource = null;
            cargandoCatalogos = false;
        }

        private void CargarMunicipios(int idDepartamento)
        {
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "IdMunicipio";
            cmbMunicipio.DataSource = controlador.listarMunicipios(idDepartamento);
            cmbMunicipio.SelectedIndex = -1;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCatalogos) return;

            Departamentos departamento = cmbDepartamento.SelectedItem as Departamentos;
            cargandoCatalogos = true;
            cmbMunicipio.DataSource = null;
            if (departamento != null)
            {
                CargarMunicipios(departamento.IdDepartamento);
            }
            cargandoCatalogos = false;
        }

        // Valida los campos obligatorios y guarda el hospital.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(cmbDepartamento.SelectedItem is Departamentos departamento))
            {
                MessageBox.Show("Seleccione un departamento.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartamento.Focus();
                return;
            }

            if (!(cmbMunicipio.SelectedItem is Municipios municipio) || municipio.IdDepartamento != departamento.IdDepartamento)
            {
                MessageBox.Show("Seleccione un municipio del departamento indicado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMunicipio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del hospital.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                string nombre = txtNombre.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (idHospital.HasValue)
                {
                    controlador.editarHospital(idHospital.Value, municipio.IdMunicipio, nombre, direccion, telefono);
                }
                else
                {
                    controlador.crearHospital(municipio.IdMunicipio, nombre, direccion, telefono);
                }

                MessageBox.Show("Los datos del hospital se guardaron correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el hospital:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cierra el formulario y regresa al listado.
        private void lnkVolver_LinkClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
