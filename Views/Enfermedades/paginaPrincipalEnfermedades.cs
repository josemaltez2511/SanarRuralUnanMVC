using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Enfermedades
{
    public partial class paginaPrincipalEnfermedades : Form
    {
        private readonly enfermedadesController controlador = new enfermedadesController();
        private Panel panelIconoModulo;
        private Label lblIconoModulo;
        private Label lblConteo;
        private bool puedeAdministrar;
        private bool permisosInicializados;

        public paginaPrincipalEnfermedades()
        {
            InitializeComponent();
            ConfigurarPresentacion();
            Load += (s, e) => CargarEnfermedades();
            VisibleChanged += (s, e) =>
            {
                if (Visible) CargarEnfermedades(txtBuscar.Text.Trim());
            };
        }

        private void ConfigurarPresentacion()
        {
            DoubleBuffered = true;
            BackColor = Tema.Fondo;
            panelTarjeta.BackColor = Tema.Superficie;
            panelTarjeta.Padding = new Padding(24);
            panelTarjeta.Paint += (s, e) =>
                Tema.DibujarTarjetaRedondeada(e.Graphics,
                    new Rectangle(0, 0, panelTarjeta.Width - 1, panelTarjeta.Height - 1),
                    Tema.Superficie, Tema.Borde, 8);

            panelEncabezado.Height = 64;
            lblTitulo.Font = new Font(Tema.FamiliaFuente, 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Tema.AzulOscuro;
            lblSubtitulo.Font = Tema.FuenteAyuda;
            lblSubtitulo.ForeColor = Tema.TextoSecundario;

            panelIconoModulo = new Panel
            {
                BackColor = Tema.FondoSecundario,
                Location = new Point(0, 7),
                Size = new Size(42, 42),
                AccessibleName = "Módulo de enfermedades"
            };
            lblIconoModulo = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Symbol", 18F, FontStyle.Bold),
                ForeColor = Tema.AzulPrimario,
                Text = "✚",
                TextAlign = ContentAlignment.MiddleCenter,
                AccessibleName = "Símbolo de salud"
            };
            panelIconoModulo.Controls.Add(lblIconoModulo);
            panelEncabezado.Controls.Add(panelIconoModulo);
            panelIconoModulo.BringToFront();

            btnNuevaEnfermedad.Text = "＋  Nueva enfermedad";
            btnNuevaEnfermedad.Font = Tema.FuenteBoton;
            btnNuevaEnfermedad.BackColor = Tema.AzulPrimario;
            btnNuevaEnfermedad.ForeColor = Tema.Superficie;
            btnNuevaEnfermedad.Cursor = Cursors.Hand;
            btnNuevaEnfermedad.AccessibleDescription = "Abre el formulario para registrar una enfermedad.";

            panelBusqueda.BackColor = Tema.Superficie;
            panelBusqueda.Height = 50;
            panelBusqueda.Paint += (s, e) =>
                Tema.DibujarTarjetaRedondeada(e.Graphics,
                    new Rectangle(0, 0, panelBusqueda.Width - 1, panelBusqueda.Height - 1),
                    Tema.Superficie, Tema.Borde, 6);
            txtBuscar.Dock = DockStyle.None;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = Tema.FuenteInput;
            txtBuscar.AccessibleDescription = "Filtra enfermedades por nombre, categoría o descripción.";

            lblConteo = new Label
            {
                AutoSize = false,
                Font = Tema.FuenteAyuda,
                ForeColor = Tema.TextoSecundario,
                TextAlign = ContentAlignment.MiddleRight,
                AccessibleName = "Cantidad de resultados"
            };
            panelBusqueda.Controls.Add(lblConteo);
            panelBusqueda.Resize += (s, e) => AjustarBusqueda();

            btnNuevaEnfermedad.FlatStyle = FlatStyle.Flat;
            btnNuevaEnfermedad.FlatAppearance.BorderSize = 0;
            btnNuevaEnfermedad.Size = new Size(190, 40);
            btnNuevaEnfermedad.AccessibleName = "Registrar una enfermedad";

            tabla.AccessibleName = "Listado de enfermedades activas";
            tabla.AccessibleDescription = "Use las flechas para recorrer los registros y Tab para acceder a sus acciones.";
            tabla.RowTemplate.Height = 46;
            tabla.ColumnHeadersHeight = 42;
            tabla.AllowUserToResizeRows = false;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabla.GridColor = Tema.Borde;
            tabla.DefaultCellStyle.Padding = new Padding(6, 2, 6, 2);

            AjustarBusqueda();
            AjustarEncabezado();
        }

        private void AjustarBusqueda()
        {
            if (panelBusqueda == null || txtBuscar == null || lblConteo == null) return;

            int ancho = panelBusqueda.ClientSize.Width;
            int anchoConteo = Math.Min(190, Math.Max(130, ancho / 3));
            int anchoBusqueda = Math.Max(180, ancho - anchoConteo - 18);
            txtBuscar.SetBounds(0, 7, anchoBusqueda, 32);
            lblConteo.SetBounds(ancho - anchoConteo, 7, anchoConteo, 32);
        }

        private void AjustarEncabezado()
        {
            if (panelEncabezado == null) return;

            lblTitulo.Location = new Point(54, 0);
            lblSubtitulo.Location = new Point(56, 36);
            btnNuevaEnfermedad.Top = 8;
            btnNuevaEnfermedad.Left = Math.Max(260,
                panelEncabezado.ClientSize.Width - btnNuevaEnfermedad.Width);
        }

        private void CargarEnfermedades(string busqueda = "")
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            try
            {
                InicializarPermisos();
                tabla.DataSource = controlador.listarEnfermedades(busqueda);
                lblConteo.Text = tabla.Rows.Count == 1
                    ? "1 enfermedad activa"
                    : string.Format("{0} enfermedades activas", tabla.Rows.Count);
            }
            catch (Exception ex)
            {
                if (lblConteo != null) lblConteo.Text = "No se pudieron cargar los resultados";
                MessageBox.Show("No se pudo cargar el catálogo de enfermedades:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarPermisos()
        {
            if (permisosInicializados || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            Tema.ConfigurarTabla(tabla);
            tabla.RowTemplate.Height = 46;
            puedeAdministrar = controlador.puedeAdministrarCatalogo();
            btnNuevaEnfermedad.Visible = puedeAdministrar;
            colEditar.Visible = puedeAdministrar;
            colBaja.Visible = puedeAdministrar;
            permisosInicializados = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarEnfermedades(txtBuscar.Text.Trim());
        }

        private void btnNuevaEnfermedad_Click(object sender, EventArgs e)
        {
            if (puedeAdministrar) AbrirFormulario(null);
        }

        private void panelEncabezado_Resize(object sender, EventArgs e)
        {
            AjustarEncabezado();
        }

        private void Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int id = Convert.ToInt32(tabla.Rows[e.RowIndex].Cells["colId"].Value);
            if (tabla.Columns[e.ColumnIndex].Name == "colDetalle")
            {
                AbrirDetalle(id);
            }
            else if (tabla.Columns[e.ColumnIndex].Name == "colEditar" && puedeAdministrar)
            {
                AbrirFormulario(id);
            }
            else if (tabla.Columns[e.ColumnIndex].Name == "colBaja" && puedeAdministrar)
            {
                string nombre = Convert.ToString(tabla.Rows[e.RowIndex].Cells["colNombre"].Value);
                if (MessageBox.Show("¿Desea dar de baja a «" + nombre + "»? Sus referencias clínicas se conservarán.",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                try
                {
                    controlador.darDeBajaEnfermedad(id);
                    CargarEnfermedades(txtBuscar.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo dar de baja la enfermedad:\n\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AbrirFormulario(int? idEnfermedad)
        {
            using (var formulario = new formularioEnfermedad(idEnfermedad))
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                    CargarEnfermedades(txtBuscar.Text.Trim());
            }
        }

        private void AbrirDetalle(int idEnfermedad)
        {
            using (var formulario = new formularioEnfermedad(idEnfermedad, true))
            {
                formulario.ShowDialog(this);
            }
        }
    }
}
