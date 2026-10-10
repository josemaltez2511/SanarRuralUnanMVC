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
            panelLema.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, panelLema.Width - 1, panelLema.Height - 1), Tema.Superficie, Tema.Borde, 8);

            // Microinteracciones de botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;
        }

        private void panelHero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelHero.Width;
            int h = panelHero.Height;

            // Altura del área del paisaje en la parte inferior del Hero
            int altoPaisaje = Math.Max(220, (int)(h * 0.35f));
            int yInicio = h - altoPaisaje;

            // Cielo suave en degradé
            using (LinearGradientBrush brCielo = new LinearGradientBrush(
                new Rectangle(0, yInicio - 30, w, 50),
                Tema.Fondo,
                Color.FromArgb(215, 238, 248),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brCielo, 0, yInicio - 30, w, 50);
            }

            // Colina lejana (azul-verdoso suave)
            using (GraphicsPath pathMontanas = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, yInicio + 25);
                Point p3 = new Point((int)(w * 0.35f), yInicio - 12);
                Point p4 = new Point((int)(w * 0.65f), yInicio + 30);
                Point p5 = new Point(w, yInicio + 5);
                Point p6 = new Point(w, h);

                pathMontanas.AddLine(p1, p2);
                pathMontanas.AddBezier(p2, p3, p4, p5);
                pathMontanas.AddLine(p5, p6);
                pathMontanas.CloseFigure();
                using (SolidBrush brMontanas = new SolidBrush(Color.FromArgb(168, 209, 185)))
                {
                    e.Graphics.FillPath(brMontanas, pathMontanas);
                }
            }

            // Colina media (verde naturaleza)
            using (GraphicsPath pathColinaMedia = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, yInicio + 55);
                Point p3 = new Point((int)(w * 0.40f), yInicio + 20);
                Point p4 = new Point((int)(w * 0.75f), yInicio + 65);
                Point p5 = new Point(w, yInicio + 40);
                Point p6 = new Point(w, h);

                pathColinaMedia.AddLine(p1, p2);
                pathColinaMedia.AddBezier(p2, p3, p4, p5);
                pathColinaMedia.AddLine(p5, p6);
                pathColinaMedia.CloseFigure();
                using (SolidBrush brColinaMedia = new SolidBrush(Tema.Verde))
                {
                    e.Graphics.FillPath(brColinaMedia, pathColinaMedia);
                }
            }

            // Casita / Centro médico rural sobre la colina media
            int xCasa = (int)(w * 0.16f);
            int yCasa = yInicio + 55;
            using (SolidBrush brPared = new SolidBrush(Color.FromArgb(250, 248, 240)))
            using (Pen penPared = new Pen(Color.FromArgb(180, 170, 150), 1f))
            {
                e.Graphics.FillRectangle(brPared, xCasa, yCasa, 26, 17);
                e.Graphics.DrawRectangle(penPared, xCasa, yCasa, 26, 17);
            }
            using (SolidBrush brTecho = new SolidBrush(Color.FromArgb(195, 95, 75)))
            {
                Point[] puntosTecho = new Point[]
                {
                    new Point(xCasa - 2, yCasa),
                    new Point(xCasa + 13, yCasa - 11),
                    new Point(xCasa + 28, yCasa)
                };
                e.Graphics.FillPolygon(brTecho, puntosTecho);
            }
            using (SolidBrush brPuerta = new SolidBrush(Color.FromArgb(140, 75, 45)))
            {
                e.Graphics.FillRectangle(brPuerta, xCasa + 9, yCasa + 6, 7, 11);
            }

            // Arbolitos rurales
            DibujarArbolito(e.Graphics, (int)(w * 0.08f), yInicio + 50, 14, 22);
            DibujarArbolito(e.Graphics, (int)(w * 0.32f), yInicio + 42, 16, 26);
            DibujarArbolito(e.Graphics, (int)(w * 0.68f), yInicio + 54, 18, 28);
            DibujarArbolito(e.Graphics, (int)(w * 0.85f), yInicio + 46, 14, 24);

            // Colina frontal ondulada (verde oscuro)
            using (GraphicsPath pathColinaFrontal = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, yInicio + 95);
                Point p3 = new Point((int)(w * 0.30f), yInicio + 120);
                Point p4 = new Point((int)(w * 0.65f), yInicio + 85);
                Point p5 = new Point(w, yInicio + 105);
                Point p6 = new Point(w, h);

                pathColinaFrontal.AddLine(p1, p2);
                pathColinaFrontal.AddBezier(p2, p3, p4, p5);
                pathColinaFrontal.AddLine(p5, p6);
                pathColinaFrontal.CloseFigure();
                using (SolidBrush brColinaFrontal = new SolidBrush(Tema.VerdeOscuro))
                {
                    e.Graphics.FillPath(brColinaFrontal, pathColinaFrontal);
                }
            }

            // Olas decorativas transparentes en la base inferior
            using (GraphicsPath pathOlaTeal = new GraphicsPath())
            {
                Point p1 = new Point(0, h);
                Point p2 = new Point(0, h - 30);
                Point p3 = new Point((int)(w * 0.35f), h - 10);
                Point p4 = new Point((int)(w * 0.70f), h - 45);
                Point p5 = new Point(w, h - 20);
                Point p6 = new Point(w, h);

                pathOlaTeal.AddLine(p1, p2);
                pathOlaTeal.AddBezier(p2, p3, p4, p5);
                pathOlaTeal.AddLine(p5, p6);
                pathOlaTeal.CloseFigure();
                using (SolidBrush brOlaTeal = new SolidBrush(Color.FromArgb(80, 165, 215, 215)))
                {
                    e.Graphics.FillPath(brOlaTeal, pathOlaTeal);
                }
            }
        }

        private static void DibujarArbolito(Graphics g, int x, int y, int ancho, int alto)
        {
            using (SolidBrush brTronco = new SolidBrush(Color.FromArgb(120, 80, 50)))
            {
                g.FillRectangle(brTronco, x + (ancho / 2) - 2, y + (alto / 2), 4, alto / 2);
            }
            using (SolidBrush brCopa = new SolidBrush(Tema.VerdeOscuro))
            {
                g.FillEllipse(brCopa, x, y, ancho, alto * 3 / 4);
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
