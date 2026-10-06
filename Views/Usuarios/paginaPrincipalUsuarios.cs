using System;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views
{
    public partial class paginaPrincipalUsuarios : Form
    {
        private readonly usuariosControllers controlador = new usuariosControllers();

        public paginaPrincipalUsuarios()
        {
            InitializeComponent();
        }

        private void paginaPrincipalUsuarios_Load(object sender, EventArgs e)
        {
            Tema.ConfigurarTabla(dgvUsuarios);
            dgvUsuarios.Columns["Correo"].FillWeight = 150;
            dgvUsuarios.Columns["colEditar"].FillWeight = 65;
            dgvUsuarios.Columns["colBaja"].FillWeight = 75;
            dgvUsuarios.Columns["colBaja"].DefaultCellStyle.ForeColor = Tema.Error;

            if (!VerificarAccesoAdministrativo())
                return;

            CargarUsuarios();
        }

        private bool VerificarAccesoAdministrativo()
        {
            if (usuariosModels.IdRolActual.HasValue &&
                usuariosModels.IdRolActual.Value == controlador.ObtenerIdRol("Administrativo"))
                return true;

            MessageBox.Show("Esta sección está disponible para usuarios administrativos.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void CargarUsuarios()
        {
            if (!VerificarAccesoAdministrativo())
                return;

            try
            {
                dgvUsuarios.Rows.Clear();
                foreach (Usuarios usuario in controlador.ListarUsuarios(txtBuscar.Text.Trim()))
                {
                    dgvUsuarios.Rows.Add(
                        usuario.IdUsuario,
                        usuario.Correo,
                        usuario.Roles.Nombre,
                        usuario.FechaRegistro.ToString("g"),
                        usuario.Estado ? "✓ Activo" : "Inactivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el listado de usuarios:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var formulario = new crearUsuario(false, true))
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                    CargarUsuarios();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int idUsuario = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value);
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "colEditar")
            {
                using (var formulario = new crearUsuario(idUsuario))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                        CargarUsuarios();
                }
            }
            else if (dgvUsuarios.Columns[e.ColumnIndex].Name == "colBaja")
            {
                string correo = dgvUsuarios.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                if (MessageBox.Show("¿Desea dar de baja " + correo + "? Sus perfiles y referencias históricas se conservarán.",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        controlador.EliminarUsuario(idUsuario);
                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo dar de baja el usuario:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
