using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;

namespace SanarRuralUnan.Views.Enfermedades
{
    public partial class formularioEnfermedad : Form
    {
        private readonly enfermedadesController controlador = new enfermedadesController();
        private readonly int? idEnfermedad;
        private readonly bool soloLectura;

        public formularioEnfermedad() : this(null, false)
        {
        }

        public formularioEnfermedad(int? idEnfermedad, bool soloLectura = false)
        {
            this.idEnfermedad = idEnfermedad;
            this.soloLectura = soloLectura;
            InitializeComponent();
            Text = soloLectura ? "Detalle de enfermedad" : idEnfermedad.HasValue ? "Editar enfermedad" : "Nueva enfermedad";
            lblTitulo.Text = soloLectura ? "Detalle de enfermedad" : idEnfermedad.HasValue ? "Editar enfermedad" : "Registrar enfermedad";
            btnGuardar.Text = idEnfermedad.HasValue ? "Guardar cambios" : "Guardar enfermedad";
            btnGuardar.Visible = !soloLectura;
            txtNombre.ReadOnly = soloLectura;
            txtCategoria.ReadOnly = soloLectura;
            txtDescripcion.ReadOnly = soloLectura;
            btnCancelar.Text = soloLectura ? "Cerrar" : "Cancelar";
            Load += FormularioEnfermedad_Load;
            if (!soloLectura) btnGuardar.Click += BtnGuardar_Click;
            panelTarjeta.Resize += panelTarjeta_Resize;
            CancelButton = btnCancelar;
            AcceptButton = soloLectura ? null : btnGuardar;
        }

        private void panelTarjeta_Resize(object sender, System.EventArgs e)
        {
            btnGuardar.Top = panelTarjeta.ClientSize.Height - 36 - btnGuardar.Height;
            btnCancelar.Left = panelTarjeta.ClientSize.Width - 36 - btnCancelar.Width;
            btnCancelar.Top = panelTarjeta.ClientSize.Height - 36 - btnCancelar.Height;
            txtNombre.Width = txtCategoria.Width = txtDescripcion.Width = Math.Max(0, panelTarjeta.ClientSize.Width - 72);
        }

        private void FormularioEnfermedad_Load(object sender, EventArgs e)
        {
            if (!idEnfermedad.HasValue) return;

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
