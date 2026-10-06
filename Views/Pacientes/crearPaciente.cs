using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views
{
    public partial class crearPaciente : Form
    {
        // La Vista utiliza el Controller para comunicarse con el Modelo.
        // La Vista nunca accede directamente a la base de datos.
        private readonly pacientesControllers controlador = new pacientesControllers();

        // El paciente puede asociarse a una cuenta existente o guardarse sin usuario.
        private int? idUsuario;
        private int? idPacienteEditar;


        // ============================================================
        // CONTROLES DEL FORMULARIO
        // ============================================================
        private ComboBox cmbDepartamento;
        private ComboBox cmbMunicipio;
        private ComboBox cmbComunidad;
        private TextBox txtSegundoNombre;
        private TextBox txtSegundoApellido;
        private TextBox txtCedula;
        private TextBox txtNumeroINSS;
        private TextBox txtContactoPrimerNombre;
        private TextBox txtContactoSegundoNombre;
        private TextBox txtContactoPrimerApellido;
        private TextBox txtContactoSegundoApellido;
        private TextBox txtContactoParentesco;
        private TextBox txtContactoTelefono;
        private TextBox txtContactoCedula;
        private bool cargandoUbicacion;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public crearPaciente()
        {
            InitializeComponent();
            PrepararCampos();
        }

        public crearPaciente(int idUsuarioRecibido) : this()
        {
            // El menú usa cero cuando no hay una cuenta relacionada.
            idUsuario = idUsuarioRecibido > 0 ? idUsuarioRecibido : (int?)null;
        }

        public crearPaciente(int idPaciente, bool modoEdicion) : this()
        {
            if (modoEdicion)
                idPacienteEditar = idPaciente;
        }

        private void PrepararCampos()
        {
            panelCard.AutoScrollMinSize = Size.Empty;
            panelDatosPersonales.Size = new Size(panelDatosPersonales.Width, 660);
            panelRegistroSalud.Size = new Size(panelRegistroSalud.Width, 660);
            btnGuardar.Location = new Point(btnGuardar.Left, 780);
            lnkVolver.Location = new Point(450, 825);

            lblNombres.Text = "Primer nombre *";
            lblApellidos.Text = "Primer apellido *";
            lblUbicacion.Location = new Point(20, 395);
            lblDepartamento.Location = new Point(20, 425);
            lblMunicipio.Location = new Point(260, 425);
            lblComunidad.Location = new Point(20, 485);
            OcultarControl(lblDepartamento);
            OcultarControl(lblMunicipio);
            OcultarControl(lblComunidad);
            lblDireccion.Location = new Point(20, 545);

            txtNombres.Location = new Point(20, 77);
            txtNombres.Size = new Size(210, 25);
            txtApellidos.Location = new Point(20, 144);
            txtApellidos.Size = new Size(210, 25);
            txtDireccion.Location = new Point(20, 564);
            txtDireccion.Size = new Size(450, 55);

            lblFechaNacimiento.Location = new Point(20, 259);
            dtpFechaNacimiento.Location = new Point(20, 278);
            lblGenero.Location = new Point(260, 259);
            cmbGenero.Location = new Point(260, 278);
            lblTelefono.Location = new Point(20, 326);
            txtTelefono.Location = new Point(20, 345);
            lblErrorTelefono.Location = new Point(20, 373);
            lblErrorNombres.Location = new Point(20, 105);

            OcultarControl(txtDepartamento);
            OcultarControl(txtMunicipio);
            OcultarControl(txtComunidad);
            OcultarControl(txtContactoEmergencia);

            txtSegundoNombre = AgregarTexto(panelDatosPersonales, "Segundo nombre", 260, 58, 210, 77);
            txtSegundoApellido = AgregarTexto(panelDatosPersonales, "Segundo apellido", 260, 125, 210, 144);
            txtCedula = AgregarTexto(panelDatosPersonales, "Cédula", 20, 192, 210, 211);
            txtNumeroINSS = AgregarTexto(panelDatosPersonales, "Número INSS", 260, 192, 210, 211);

            cmbDepartamento = AgregarCombo(panelDatosPersonales, "Departamento *", 20, 425, 210, 444);
            cmbMunicipio = AgregarCombo(panelDatosPersonales, "Municipio *", 260, 425, 210, 444);
            cmbComunidad = AgregarCombo(panelDatosPersonales, "Comunidad *", 20, 485, 450, 504);
            cmbDepartamento.SelectedIndexChanged += cmbDepartamento_SelectedIndexChanged;
            cmbMunicipio.SelectedIndexChanged += cmbMunicipio_SelectedIndexChanged;

            lblContactoEmergencia.Text = "Contacto de emergencia (opcional)";
            lblContactoEmergencia.Location = new Point(20, 125);
            lblTipoSangre.Location = new Point(20, 370);
            cmbTipoSangre.Location = new Point(20, 390);
            lblAlergias.Location = new Point(20, 425);
            txtAlergias.Location = new Point(20, 445);
            txtAlergias.Size = new Size(450, 60);
            lblAntecedentes.Location = new Point(20, 515);
            txtAntecedentes.Location = new Point(20, 535);
            txtAntecedentes.Size = new Size(450, 90);

            txtContactoPrimerNombre = AgregarTexto(panelRegistroSalud, "Primer nombre *", 20, 145, 210, 164);
            txtContactoSegundoNombre = AgregarTexto(panelRegistroSalud, "Segundo nombre", 260, 145, 210, 164);
            txtContactoPrimerApellido = AgregarTexto(panelRegistroSalud, "Primer apellido *", 20, 205, 210, 224);
            txtContactoSegundoApellido = AgregarTexto(panelRegistroSalud, "Segundo apellido", 260, 205, 210, 224);
            txtContactoParentesco = AgregarTexto(panelRegistroSalud, "Parentesco *", 20, 265, 210, 284);
            txtContactoTelefono = AgregarTexto(panelRegistroSalud, "Teléfono *", 260, 265, 210, 284);
            txtContactoCedula = AgregarTexto(panelRegistroSalud, "Cédula", 20, 325, 210, 344);

            panelCard.Resize += panelCard_Resize;
            AjustarLayoutPaciente();
        }

        private TextBox AgregarTexto(Control contenedor, string etiqueta, int x, int yEtiqueta, int ancho, int yTexto)
        {
            Label label = new Label
            {
                AutoSize = true,
                Font = Tema.FuenteLabelCampo,
                ForeColor = Tema.TextoPrincipal,
                Location = new Point(x, yEtiqueta),
                Tag = new Point(x, ancho),
                Text = etiqueta
            };
            TextBox texto = new TextBox
            {
                Font = Tema.FuenteInput,
                Location = new Point(x, yTexto),
                Size = new Size(ancho, 25)
            };
            texto.Tag = new Point(x, ancho);
            contenedor.Controls.Add(label);
            contenedor.Controls.Add(texto);
            return texto;
        }

        private ComboBox AgregarCombo(Control contenedor, string etiqueta, int x, int yEtiqueta, int ancho, int yCombo)
        {
            Label label = new Label
            {
                AutoSize = true,
                Font = Tema.FuenteLabelCampo,
                ForeColor = Tema.TextoPrincipal,
                Location = new Point(x, yEtiqueta),
                Tag = new Point(x, ancho),
                Text = etiqueta
            };
            ComboBox combo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = Tema.FuenteInput,
                Location = new Point(x, yCombo),
                Size = new Size(ancho, 25)
            };
            combo.Tag = new Point(x, ancho);
            contenedor.Controls.Add(label);
            contenedor.Controls.Add(combo);
            return combo;
        }

        private static void OcultarControl(Control control)
        {
            control.Visible = false;
        }

        private void panelCard_Resize(object sender, EventArgs e)
        {
            AjustarLayoutPaciente();
        }

        private void AjustarLayoutPaciente()
        {
            int anchoColumna = Math.Max(0, (panelCard.ClientSize.Width - 80) / 2);
            int anchoCompleto = Math.Max(0, panelCard.ClientSize.Width - 80);

            panelDatosPersonales.Width = anchoColumna;
            panelRegistroSalud.Width = anchoColumna;
            panelDatosPersonales.Location = new Point(20, 90);
            panelRegistroSalud.Location = new Point(anchoColumna + 40, 90);

            AjustarCampos(panelDatosPersonales);
            AjustarCampos(panelRegistroSalud);

            btnGuardar.Location = new Point(40, btnGuardar.Top);
            btnGuardar.Width = anchoCompleto;
            lnkVolver.Location = new Point((panelCard.ClientSize.Width - lnkVolver.Width) / 2, lnkVolver.Top);
        }

        private static void AjustarCampos(Panel panel)
        {
            int anchoColumna = Math.Max(0, (panel.ClientSize.Width - 50) / 2);
            int xDerecha = anchoColumna + 30;

            foreach (Control control in panel.Controls)
            {
                Point dimensiones = control.Tag is Point
                    ? (Point)control.Tag
                    : new Point(control.Left, control.Width);
                control.Tag = dimensiones;

                bool esColumnaDerecha = dimensiones.X >= 240 && dimensiones.X < 400;
                int x = esColumnaDerecha ? xDerecha : 20;
                control.Left = x;

                if (!(control is Label))
                {
                    control.Width = dimensiones.Y >= 400
                        ? Math.Max(0, panel.ClientSize.Width - 40)
                        : anchoColumna;
                }
            }
        }

        private void crearPaciente_Load(object sender, EventArgs e)
        {
            // Colocar el cursor inicialmente en el primer nombre.
            txtNombres.Focus();

            // Si el ComboBox tiene opciones, seleccionar la primera.
            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;

            // No permitir una fecha de nacimiento futura.
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            // Mensajes de error iniciales.
            lblErrorNombres.Text = string.Empty;
            lblErrorTelefono.Text = string.Empty;
            CargarDepartamentos();

            if (idPacienteEditar.HasValue)
                CargarPacienteParaEditar();
        }

        private void CargarPacienteParaEditar()
        {
            SanarRuralUnan.Pacientes paciente = controlador.consultarPacientePorId(idPacienteEditar.Value);
            if (paciente == null)
            {
                MessageBox.Show("El paciente ya no está disponible.", "Paciente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            Text = "Sanar Rural - Editar Paciente";
            lblSubtitulo.Text = "Editar datos del paciente";
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
            cmbTipoSangre.SelectedItem = paciente.TipoSangre;
            txtAlergias.Text = paciente.Alergias;
            txtAntecedentes.Text = paciente.Antecedentes;

            cargandoUbicacion = true;
            cmbDepartamento.SelectedValue = paciente.Comunidades.Municipios.IdDepartamento;
            cmbMunicipio.DataSource = controlador.listarMunicipios(paciente.Comunidades.Municipios.IdDepartamento);
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "IdMunicipio";
            cmbMunicipio.SelectedValue = paciente.Comunidades.IdMunicipio;
            cmbComunidad.DataSource = controlador.listarComunidades(paciente.Comunidades.IdMunicipio);
            cmbComunidad.DisplayMember = "Nombre";
            cmbComunidad.ValueMember = "IdComunidad";
            cmbComunidad.SelectedValue = paciente.IdComunidad;
            cargandoUbicacion = false;

            ContactosEmergencia contacto = paciente.ContactosEmergencia.FirstOrDefault();
            if (contacto != null)
            {
                txtContactoPrimerNombre.Text = contacto.PrimerNombre;
                txtContactoSegundoNombre.Text = contacto.SegundoNombre;
                txtContactoPrimerApellido.Text = contacto.PrimerApellido;
                txtContactoSegundoApellido.Text = contacto.SegundoApellido;
                txtContactoParentesco.Text = contacto.Parentesco;
                txtContactoTelefono.Text = contacto.Telefono;
                txtContactoCedula.Text = contacto.Cedula;
            }

            txtContactoPrimerNombre.ReadOnly = true;
            txtContactoSegundoNombre.ReadOnly = true;
            txtContactoPrimerApellido.ReadOnly = true;
            txtContactoSegundoApellido.ReadOnly = true;
            txtContactoParentesco.ReadOnly = true;
            txtContactoTelefono.ReadOnly = true;
            txtContactoCedula.ReadOnly = true;
        }

        // ============================================================
        // UBICACIÓN DEPENDIENTE
        // ============================================================

        private void CargarDepartamentos()
        {
            cargandoUbicacion = true;
            cmbDepartamento.DataSource = controlador.listarDepartamentos();
            cmbDepartamento.DisplayMember = "Nombre";
            cmbDepartamento.ValueMember = "IdDepartamento";
            cmbDepartamento.SelectedIndex = -1;
            cmbMunicipio.DataSource = null;
            cmbComunidad.DataSource = null;
            cargandoUbicacion = false;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion) return;

            Departamentos departamento = cmbDepartamento.SelectedItem as Departamentos;
            cargandoUbicacion = true;
            cmbMunicipio.DataSource = departamento == null
                ? null
                : controlador.listarMunicipios(departamento.IdDepartamento);
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "IdMunicipio";
            cmbMunicipio.SelectedIndex = -1;
            cmbComunidad.DataSource = null;
            cargandoUbicacion = false;
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion) return;

            Municipios municipio = cmbMunicipio.SelectedItem as Municipios;
            cargandoUbicacion = true;
            cmbComunidad.DataSource = municipio == null
                ? null
                : controlador.listarComunidades(municipio.IdMunicipio);
            cmbComunidad.DisplayMember = "Nombre";
            cmbComunidad.ValueMember = "IdComunidad";
            cmbComunidad.SelectedIndex = -1;
            cargandoUbicacion = false;
        }

        // ============================================================
        // VALIDACIÓN DE NOMBRES
        // ============================================================

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            lblErrorNombres.Text = string.IsNullOrWhiteSpace(txtNombres.Text)
                ? "El nombre no puede estar vacío."
                : string.Empty;
        }

        // ============================================================
        // VALIDACIÓN DE TELÉFONO
        // ============================================================
        // El teléfono es opcional. Si se escribe, solamente permitimos números.

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();
            lblErrorTelefono.Text = !string.IsNullOrEmpty(telefono) && !EsTelefonoValido(telefono)
                ? "El teléfono solo debe contener números."
                : string.Empty;
        }

        private static bool EsTelefonoValido(string telefono)
        {
            foreach (char caracter in telefono)
            {
                if (!char.IsDigit(caracter)) return false;
            }
            return true;
        }

        // ============================================================
        // GUARDAR PACIENTE
        // RF-03
        // ============================================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Datos obligatorios para crear el paciente.
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Por favor, ingrese el primer nombre del paciente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, ingrese el primer apellido del paciente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return;
            }
            if (cmbComunidad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la comunidad del paciente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbComunidad.Focus();
                return;
            }

            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono) && !EsTelefonoValido(telefono))
            {
                MessageBox.Show("El teléfono solo debe contener números.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            string contactoNombre = txtContactoPrimerNombre.Text.Trim();
            string contactoApellido = txtContactoPrimerApellido.Text.Trim();
            string contactoParentesco = txtContactoParentesco.Text.Trim();
            string contactoTelefono = txtContactoTelefono.Text.Trim();
            // Si se empieza a registrar un contacto, sus datos obligatorios deben completarse.
            bool ingresoContacto = !string.IsNullOrWhiteSpace(contactoNombre)
                || !string.IsNullOrWhiteSpace(txtContactoSegundoNombre.Text)
                || !string.IsNullOrWhiteSpace(contactoApellido)
                || !string.IsNullOrWhiteSpace(txtContactoSegundoApellido.Text)
                || !string.IsNullOrWhiteSpace(contactoParentesco)
                || !string.IsNullOrWhiteSpace(contactoTelefono)
                || !string.IsNullOrWhiteSpace(txtContactoCedula.Text);

            if (ingresoContacto && (string.IsNullOrWhiteSpace(contactoNombre)
                || string.IsNullOrWhiteSpace(contactoApellido)
                || string.IsNullOrWhiteSpace(contactoParentesco)
                || string.IsNullOrWhiteSpace(contactoTelefono)))
            {
                MessageBox.Show("Complete el primer nombre, primer apellido, parentesco y teléfono del contacto de emergencia.", "Contacto incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ingresoContacto && !EsTelefonoValido(contactoTelefono))
            {
                MessageBox.Show("El teléfono del contacto solo debe contener números.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactoTelefono.Focus();
                return;
            }

            try
            {
                if (idPacienteEditar.HasValue)
                {
                    controlador.editarPaciente(
                        idPacienteEditar.Value,
                        txtNombres.Text.Trim(),
                        txtSegundoNombre.Text.Trim(),
                        txtApellidos.Text.Trim(),
                        txtSegundoApellido.Text.Trim(),
                        txtCedula.Text.Trim(),
                        txtNumeroINSS.Text.Trim(),
                        dtpFechaNacimiento.Value,
                        cmbGenero.SelectedItem == null ? null : cmbGenero.SelectedItem.ToString(),
                        telefono,
                        ((Comunidades)cmbComunidad.SelectedItem).IdComunidad,
                        txtDireccion.Text.Trim(),
                        cmbTipoSangre.SelectedItem == null ? null : cmbTipoSangre.SelectedItem.ToString(),
                        txtAlergias.Text.Trim(),
                        txtAntecedentes.Text.Trim());
                }
                else
                {
                    controlador.crearPaciente(
                        idUsuario,
                        txtNombres.Text.Trim(),
                        txtSegundoNombre.Text.Trim(),
                        txtApellidos.Text.Trim(),
                        txtSegundoApellido.Text.Trim(),
                        txtCedula.Text.Trim(),
                        txtNumeroINSS.Text.Trim(),
                        dtpFechaNacimiento.Value,
                        cmbGenero.SelectedItem == null ? null : cmbGenero.SelectedItem.ToString(),
                        telefono,
                        ((Comunidades)cmbComunidad.SelectedItem).IdComunidad,
                        txtDireccion.Text.Trim(),
                        cmbTipoSangre.SelectedItem == null ? null : cmbTipoSangre.SelectedItem.ToString(),
                        txtAlergias.Text.Trim(),
                        txtAntecedentes.Text.Trim(),
                        contactoNombre,
                        txtContactoSegundoNombre.Text.Trim(),
                        contactoApellido,
                        txtContactoSegundoApellido.Text.Trim(),
                        contactoParentesco,
                        contactoTelefono,
                        txtContactoCedula.Text.Trim());
                }

                MessageBox.Show(idPacienteEditar.HasValue ? "Los datos del paciente se actualizaron correctamente." : "¡Paciente registrado con éxito!",
                    "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // Mostrar el error recibido durante la persistencia.
                MessageBox.Show("Ocurrió un error al guardar el paciente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // VOLVER / OMITIR
        // ============================================================
        // Permite cerrar el formulario sin completar información adicional.

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void crearPaciente_Load_1(object sender, EventArgs e) { }

        // Eventos requeridos por los controles del formulario.
        private void panelCard_Paint(object sender, PaintEventArgs e) { }
        private void panelDatosPersonales_Paint(object sender, PaintEventArgs e) { }
    }
}
