using System;
using System.ComponentModel;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Enfermedades
{
    public partial class paginaPrincipalEnfermedades : Form
    {
        private readonly enfermedadesController controlador = new enfermedadesController();
        private bool puedeAdministrar;
        private bool permisosInicializados;

        public paginaPrincipalEnfermedades()
        {
            InitializeComponent();
            Load += (s, e) => CargarEnfermedades();
            VisibleChanged += (s, e) =>
            {
                if (Visible) CargarEnfermedades(txtBuscar.Text.Trim());
            };
        }

        private void CargarEnfermedades(string busqueda = "")
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            try
            {
                InicializarPermisos();
                tabla.DataSource = controlador.listarEnfermedades(busqueda);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el catálogo de enfermedades:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarPermisos()
        {
            if (permisosInicializados || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            Tema.ConfigurarTabla(tabla);
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
            btnNuevaEnfermedad.Left = panelEncabezado.ClientSize.Width - btnNuevaEnfermedad.Width;
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
