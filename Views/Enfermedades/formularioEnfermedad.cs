using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Enfermedades
{
    public partial class formularioEnfermedad : Form
    {
        private readonly enfermedadesController controlador = new enfermedadesController();
        private readonly int? idEnfermedad;
        private readonly bool soloLectura;
        private Label lblSubtitulo;
        private ToolTip ayudaCampos;

        public formularioEnfermedad() : this(null, false)
        {
        }

        public formularioEnfermedad(int? idEnfermedad, bool soloLectura = false)
        {
            this.idEnfermedad = idEnfermedad;
            this.soloLectura = soloLectura;
            InitializeComponent();
            ConfigurarPresentacion();

            Text = soloLectura ? "Detalle de enfermedad" : idEnfermedad.HasValue ? "Editar enfermedad" : "Nueva enfermedad";
            lblTitulo.Text = soloLectura ? "Detalle de enfermedad" : idEnfermedad.HasValue ? "Editar enfermedad" : "Registrar enfermedad";
            lblSubtitulo.Text = soloLectura
                ? "Consulta la información registrada en el catálogo."
                : "Completa los datos básicos. El nombre de la enfermedad es obligatorio.";
            btnGuardar.Text = idEnfermedad.HasValue ? "Guardar cambios" : "Guardar enfermedad";
            btnGuardar.Visible = !soloLectura;
            txtNombre.ReadOnly = soloLectura;
            txtCategoria.ReadOnly = soloLectura;
            txtDescripcion.ReadOnly = soloLectura;
            txtNombre.TabStop = !soloLectura;
            txtCategoria.TabStop = !soloLectura;
            txtDescripcion.TabStop = !soloLectura;
            btnCancelar.Text = soloLectura ? "Cerrar" : "Cancelar";
            Load += FormularioEnfermedad_Load;
            if (!soloLectura) btnGuardar.Click += BtnGuardar_Click;
            panelTarjeta.Resize += panelTarjeta_Resize;
            CancelButton = btnCancelar;
            AcceptButton = soloLectura ? null : btnGuardar;
            AjustarLayout();
        }

        private void ConfigurarPresentacion()
        {
            DoubleBuffered = true;
            BackColor = Tema.Fondo;
            ClientSize = new Size(760, 640);
            MinimumSize = new Size(680, 590);
            MaximizeBox = false;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;

            panelTarjeta.BackColor = Tema.Superficie;
            panelTarjeta.Padding = new Padding(30);
            panelTarjeta.Paint += (s, e) =>
                Tema.DibujarTarjetaRedondeada(e.Graphics,
                    new Rectangle(0, 0, panelTarjeta.Width - 1, panelTarjeta.Height - 1),
                    Tema.Superficie, Tema.Borde, 8);

            lblTitulo.Font = new Font(Tema.FamiliaFuente, 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Tema.AzulOscuro;
            lblSubtitulo = new Label
            {
                AutoSize = false,
                Font = Tema.FuenteAyuda,
                ForeColor = Tema.TextoSecundario,
                TextAlign = ContentAlignment.MiddleLeft,
                AccessibleName = "Ayuda del formulario"
            };
            panelTarjeta.Controls.Add(lblSubtitulo);
            lblSubtitulo.BringToFront();

            EstilizarCampo(txtNombre, "Nombre de la enfermedad", "Campo obligatorio. Máximo 150 caracteres.");
            EstilizarCampo(txtCategoria, "Categoría", "Campo opcional. Máximo 100 caracteres.");
            EstilizarCampo(txtDescripcion, "Descripción", "Campo opcional. Máximo 2000 caracteres.");
            txtDescripcion.ScrollBars = ScrollBars.Vertical;

            lblNombre.Font = lblCategoria.Font = lblDescripcion.Font = Tema.FuenteLabelCampo;
            lblNombre.ForeColor = lblCategoria.ForeColor = lblDescripcion.ForeColor = Tema.TextoPrincipal;

            btnGuardar.BackColor = Tema.AzulPrimario;
            btnGuardar.ForeColor = Tema.Superficie;
            btnGuardar.Font = Tema.FuenteBoton;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.AccessibleName = "Guardar enfermedad";

            btnCancelar.BackColor = Tema.Superficie;
            btnCancelar.ForeColor = Tema.AzulPrimario;
            btnCancelar.Font = Tema.FuenteBoton;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            btnCancelar.AccessibleName = "Cancelar y volver al catálogo";

            ayudaCampos = new ToolTip(components)
            {
                AutoPopDelay = 6000,
                InitialDelay = 400,
                ReshowDelay = 100
            };
            ayudaCampos.SetToolTip(txtNombre, "Nombre obligatorio, hasta 150 caracteres.");
            ayudaCampos.SetToolTip(txtCategoria, "Categoría opcional, hasta 100 caracteres.");
            ayudaCampos.SetToolTip(txtDescripcion, "Descripción opcional, hasta 2000 caracteres.");
        }

        private static void EstilizarCampo(TextBox campo, string nombreAccesible, string descripcion)
        {
            campo.Font = Tema.FuenteInput;
            campo.ForeColor = Tema.TextoPrincipal;
            campo.BackColor = Tema.Superficie;
            campo.BorderStyle = BorderStyle.FixedSingle;
            campo.AccessibleName = nombreAccesible;
            campo.AccessibleDescription = descripcion;
        }

        private void AjustarLayout()
        {
            if (panelTarjeta == null || lblSubtitulo == null) return;

            int margen = 30;
            int ancho = Math.Max(220, panelTarjeta.ClientSize.Width - margen * 2);
            int altoBotones = 42;
            int yBotones = panelTarjeta.ClientSize.Height - margen - altoBotones;

            lblTitulo.SetBounds(margen, 18, ancho, 34);
            lblSubtitulo.SetBounds(margen, 55, ancho, 36);

            lblNombre.SetBounds(margen, 112, ancho, 22);
            txtNombre.SetBounds(margen, 138, ancho, 32);
            lblCategoria.SetBounds(margen, 190, ancho, 22);
            txtCategoria.SetBounds(margen, 216, ancho, 32);
            lblDescripcion.SetBounds(margen, 268, ancho, 22);
            txtDescripcion.SetBounds(margen, 294, ancho, Math.Max(90, yBotones - 318));

            btnGuardar.SetBounds(margen, yBotones, 190, altoBotones);
            btnCancelar.SetBounds(panelTarjeta.ClientSize.Width - margen - 116, yBotones, 116, altoBotones);
        }

        private void panelTarjeta_Resize(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        private void FormularioEnfermedad_Load(object sender, EventArgs e)
        {
            if (!idEnfermedad.HasValue)
            {
                if (!soloLectura) txtNombre.Focus();
                return;
            }

            try
            {
                var enfermedad = controlador.consultarEnfermedad(idEnfermedad.Value);
                if (enfermedad == null)
                {
                    MessageBox.Show("La enfermedad ya no está disponible.", "Registro no encontrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtNombre.Text = enfermedad.NombreEnfermedad;
                txtCategoria.Text = enfermedad.Categoria;
                txtDescripcion.Text = enfermedad.Descripcion;
                if (soloLectura)
                {
                    txtNombre.BackColor = txtCategoria.BackColor = txtDescripcion.BackColor = Tema.FondoSecundario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de la enfermedad:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la enfermedad.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                if (idEnfermedad.HasValue)
                    controlador.editarEnfermedad(idEnfermedad.Value, txtNombre.Text, txtCategoria.Text, txtDescripcion.Text);
                else
                    controlador.crearEnfermedad(txtNombre.Text, txtCategoria.Text, txtDescripcion.Text);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la enfermedad:\n\n" + ex.Message,
                    "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
