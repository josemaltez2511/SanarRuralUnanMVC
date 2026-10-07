using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views
{
    /// <summary>
    /// Formulario para la creación y edición de pacientes, incluyendo
    /// cascada geográfica y gestión compacta de contactos de emergencia (1:N).
    /// </summary>
    public partial class crearPaciente : Form
    {
        private readonly pacientesControllers controlador = new pacientesControllers();
        private readonly List<ContactoEmergenciaDto> listaContactos = new List<ContactoEmergenciaDto>();

        private int? idUsuario;
        private int? idPacienteEditar;
        private bool cargandoUbicacion;

        public crearPaciente()
        {
            InitializeComponent();
        }

        public crearPaciente(int idUsuarioRecibido) : this()
        {
            idUsuario = idUsuarioRecibido > 0 ? idUsuarioRecibido : (int?)null;
        }

        public crearPaciente(int idPaciente, bool modoEdicion) : this()
        {
            if (modoEdicion)
            {
                idPacienteEditar = idPaciente;
            }
        }

        private void crearPaciente_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            CargarDepartamentos();

            if (idPacienteEditar.HasValue)
            {
                CargarPacienteParaEditar();
            }
            else
            {
                txtNombres.Focus();
            }
        }

        private void ConfigurarFormulario()
        {
            Tema.ConfigurarTabla(dgvContactos);
            dgvContactos.AutoGenerateColumns = false;
            colContQuitar.DefaultCellStyle.ForeColor = Tema.Error;

            dtpFechaNacimiento.MaxDate = DateTime.Today;

            if (cmbGenero.Items.Count > 0)
            {
                cmbGenero.SelectedIndex = 0;
            }

            if (cmbTipoSangre.Items.Count > 0)
            {
                cmbTipoSangre.SelectedIndex = 0;
            }

            lblErrorNombres.Text = string.Empty;
            lblErrorTelefono.Text = string.Empty;
            lblErrorContacto.Text = string.Empty;
        }

        // ============================================================
        // CASCADA GEOGRÁFICA
        // ============================================================

        private void CargarDepartamentos()
        {
            try
            {
                cargandoUbicacion = true;
                cmbDepartamento.DataSource = controlador.listarDepartamentos();
                cmbDepartamento.DisplayMember = "Nombre";
                cmbDepartamento.ValueMember = "Id";
                cmbDepartamento.SelectedIndex = -1;
                cmbMunicipio.DataSource = null;
                cmbComunidad.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los departamentos: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cargandoUbicacion = false;
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion || cmbDepartamento.SelectedValue == null)
                return;

            if (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out int idDepto))
            {
                try
                {
                    cargandoUbicacion = true;
                    cmbMunicipio.DataSource = controlador.listarMunicipios(idDepto);
                    cmbMunicipio.DisplayMember = "Nombre";
                    cmbMunicipio.ValueMember = "Id";
                    cmbMunicipio.SelectedIndex = -1;
                    cmbComunidad.DataSource = null;
                }
                finally
                {
                    cargandoUbicacion = false;
                }
            }
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion || cmbMunicipio.SelectedValue == null)
                return;

            if (int.TryParse(cmbMunicipio.SelectedValue.ToString(), out int idMuni))
            {
                try
                {
                    cargandoUbicacion = true;
                    cmbComunidad.DataSource = controlador.listarComunidades(idMuni);
                    cmbComunidad.DisplayMember = "Nombre";
                    cmbComunidad.ValueMember = "Id";
                    cmbComunidad.SelectedIndex = -1;
                }
                finally
                {
                    cargandoUbicacion = false;
                }
            }
        }

        // ============================================================
        // CARGA EN MODO EDICIÓN
        // ============================================================

        private void CargarPacienteParaEditar()
        {
            try
            {
                PacienteDetalleDto paciente = controlador.obtenerPacienteDetalle(idPacienteEditar.Value);
                if (paciente == null)
                {
                    MessageBox.Show("El paciente no existe o no tiene permisos para consultarlo.", "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                Text = "Sanar Rural - Editar Paciente";
                lblSubtitulo.Text = string.Format("Editar expediente #{0} | {1}", paciente.IdPaciente, paciente.NombreCompleto);
                btnGuardar.Text = "Guardar cambios";
                lnkVolver.Text = "Cancelar";

                txtNombres.Text = paciente.PrimerNombre;
                txtSegundoNombre.Text = paciente.SegundoNombre;
                txtApellidos.Text = paciente.PrimerApellido;
                txtSegundoApellido.Text = paciente.SegundoApellido;
                txtCedula.Text = paciente.Cedula;
                txtNumeroINSS.Text = paciente.NumeroINSS;
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
                cmbGenero.SelectedItem = paciente.Genero;
                txtTelefono.Text = paciente.Telefono;
                txtDireccion.Text = paciente.Direccion;

                cmbTipoSangre.SelectedItem = string.IsNullOrWhiteSpace(paciente.TipoSangre) ? "No especificado" : paciente.TipoSangre;
                txtAlergias.Text = paciente.Alergias;
                txtAntecedentes.Text = paciente.Antecedentes;

                // Cascada de ubicación
                cargandoUbicacion = true;
                cmbDepartamento.SelectedValue = paciente.IdDepartamento;
                cmbMunicipio.DataSource = controlador.listarMunicipios(paciente.IdDepartamento);
                cmbMunicipio.DisplayMember = "Nombre";
                cmbMunicipio.ValueMember = "Id";
                cmbMunicipio.SelectedValue = paciente.IdMunicipio;
                cmbComunidad.DataSource = controlador.listarComunidades(paciente.IdMunicipio);
                cmbComunidad.DisplayMember = "Nombre";
                cmbComunidad.ValueMember = "Id";
                cmbComunidad.SelectedValue = paciente.IdComunidad;
                cargandoUbicacion = false;

                // Contactos de emergencia existentes
                listaContactos.Clear();
                if (paciente.ContactosEmergencia != null)
                {
                    listaContactos.AddRange(paciente.ContactosEmergencia);
                }
                RefrescarGridContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del paciente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        // ============================================================
        // GESTIÓN DE CONTACTOS DE EMERGENCIA (1:N)
        // ============================================================

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            string pNombre = txtContactoPrimerNombre.Text.Trim();
            string sNombre = txtContactoSegundoNombre.Text.Trim();
            string pApellido = txtContactoPrimerApellido.Text.Trim();
            string sApellido = txtContactoSegundoApellido.Text.Trim();
            string parentesco = txtContactoParentesco.Text.Trim();
            string tel = txtContactoTelefono.Text.Trim();
            string ced = txtContactoCedula.Text.Trim();

            if (string.IsNullOrWhiteSpace(pNombre))
            {
                lblErrorContacto.Text = "El primer nombre del contacto es obligatorio.";
                txtContactoPrimerNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(pApellido))
            {
                lblErrorContacto.Text = "El primer apellido del contacto es obligatorio.";
                txtContactoPrimerApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(parentesco))
            {
                lblErrorContacto.Text = "El parentesco del contacto es obligatorio.";
                txtContactoParentesco.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tel))
            {
                lblErrorContacto.Text = "El teléfono del contacto es obligatorio.";
                txtContactoTelefono.Focus();
                return;
            }

            if (!EsTelefonoValido(tel))
            {
                lblErrorContacto.Text = "El teléfono del contacto solo debe contener números (mínimo 8 dígitos).";
                txtContactoTelefono.Focus();
                return;
            }

            var contacto = new ContactoEmergenciaDto
            {
                PrimerNombre = pNombre,
                SegundoNombre = sNombre,
                PrimerApellido = pApellido,
                SegundoApellido = sApellido,
                Parentesco = parentesco,
                Telefono = tel,
                Cedula = ced
            };

            listaContactos.Add(contacto);
            RefrescarGridContactos();
            LimpiarCamposContacto();
            lblErrorContacto.Text = string.Empty;
        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvContactos.Columns[e.ColumnIndex].Name == "colContQuitar")
            {
                if (e.RowIndex < listaContactos.Count)
                {
                    string contactoDesc = listaContactos[e.RowIndex].NombreCompleto;
                    if (MessageBox.Show("¿Desea quitar de la lista a " + contactoDesc + "?",
                        "Quitar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        listaContactos.RemoveAt(e.RowIndex);
                        RefrescarGridContactos();
                    }
                }
            }
        }

        private void RefrescarGridContactos()
        {
            dgvContactos.Rows.Clear();
            foreach (ContactoEmergenciaDto c in listaContactos)
            {
                dgvContactos.Rows.Add(
                    c.NombreCompleto,
                    c.Parentesco,
                    c.Telefono,
                    string.IsNullOrWhiteSpace(c.Cedula) ? "-" : c.Cedula);
            }
        }

        private void LimpiarCamposContacto()
        {
            txtContactoPrimerNombre.Clear();
            txtContactoSegundoNombre.Clear();
            txtContactoPrimerApellido.Clear();
            txtContactoSegundoApellido.Clear();
            txtContactoParentesco.Clear();
            txtContactoTelefono.Clear();
            txtContactoCedula.Clear();
            txtContactoPrimerNombre.Focus();
        }

        // ============================================================
        // VALIDACIONES INLINE
        // ============================================================

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            lblErrorNombres.Text = string.IsNullOrWhiteSpace(txtNombres.Text)
                ? "El primer nombre es obligatorio."
                : string.Empty;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string tel = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(tel) && !EsTelefonoValido(tel))
            {
                lblErrorTelefono.Text = "El teléfono debe contener solo números (mínimo 8 dígitos).";
            }
            else
            {
                lblErrorTelefono.Text = string.Empty;
            }
        }

        private static bool EsTelefonoValido(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel) || tel.Length < 8)
                return false;

            foreach (char c in tel)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        // ============================================================
        // GUARDAR PACIENTE
        // ============================================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de obligatoriedad en UI
            string pNombre = txtNombres.Text.Trim();
            if (string.IsNullOrWhiteSpace(pNombre))
            {
                MessageBox.Show("El primer nombre del paciente es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return;
            }

            string pApellido = txtApellidos.Text.Trim();
            if (string.IsNullOrWhiteSpace(pApellido))
            {
                MessageBox.Show("El primer apellido del paciente es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return;
            }

            if (cmbComunidad.SelectedValue == null || !int.TryParse(cmbComunidad.SelectedValue.ToString(), out int idComunidad))
            {
                MessageBox.Show("Debe seleccionar la comunidad de residencia del paciente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbComunidad.Focus();
                return;
            }

            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono) && !EsTelefonoValido(telefono))
            {
                MessageBox.Show("El teléfono ingresado no es válido. Debe contener solo números y al menos 8 dígitos.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Comprobar si el usuario escribió datos de un contacto en las cajas de texto pero olvidó presionar "+ Agregar"
            if (!string.IsNullOrWhiteSpace(txtContactoPrimerNombre.Text) || !string.IsNullOrWhiteSpace(txtContactoPrimerApellido.Text))
            {
                var respuesta = MessageBox.Show(
                    "Hay datos ingresados en el formulario de contactos de emergencia que no han sido agregados a la lista.\n\n¿Desea agregarlo antes de guardar?",
                    "Contacto pendiente",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Cancel)
                    return;

                if (respuesta == DialogResult.Yes)
                {
                    btnAgregarContacto_Click(sender, e);
                    if (!string.IsNullOrEmpty(lblErrorContacto.Text))
                        return; // Hubo error en el contacto
                }
            }

            string sNombre = txtSegundoNombre.Text.Trim();
            string sApellido = txtSegundoApellido.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string inss = txtNumeroINSS.Text.Trim();
            DateTime fechaNac = dtpFechaNacimiento.Value.Date;
            string genero = cmbGenero.SelectedItem != null ? cmbGenero.SelectedItem.ToString() : null;
            string direccion = txtDireccion.Text.Trim();
            string tipoSangre = cmbTipoSangre.SelectedItem != null ? cmbTipoSangre.SelectedItem.ToString() : null;
            string alergias = txtAlergias.Text.Trim();
            string antecedentes = txtAntecedentes.Text.Trim();

            try
            {
                if (idPacienteEditar.HasValue)
                {
                    controlador.editarPaciente(
                        idPacienteEditar.Value,
                        pNombre,
                        sNombre,
                        pApellido,
                        sApellido,
                        cedula,
                        inss,
                        fechaNac,
                        genero,
                        telefono,
                        idComunidad,
                        direccion,
                        tipoSangre,
                        alergias,
                        antecedentes,
                        listaContactos);

                    MessageBox.Show("Los datos del paciente y sus contactos se actualizaron correctamente.", "Expediente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    controlador.crearPaciente(
                        idUsuario,
                        pNombre,
                        sNombre,
                        pApellido,
                        sApellido,
                        cedula,
                        inss,
                        fechaNac,
                        genero,
                        telefono,
                        idComunidad,
                        direccion,
                        tipoSangre,
                        alergias,
                        antecedentes,
                        listaContactos);

                    MessageBox.Show("¡Paciente y contactos registrados con éxito!", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la información del paciente:\n\n" + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
