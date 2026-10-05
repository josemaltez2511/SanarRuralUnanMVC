using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
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

        private void PrepararCampos()
        {
            panelCard.Size = new Size(panelCard.Width, 850);
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
        }

        private TextBox AgregarTexto(Control contenedor, string etiqueta, int x, int yEtiqueta, int ancho, int yTexto)
        {
            Label label = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 60, 70),
                Location = new Point(x, yEtiqueta),
                Text = etiqueta
            };
            TextBox texto = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(x, yTexto),
                Size = new Size(ancho, 25)
            };
            contenedor.Controls.Add(label);
            contenedor.Controls.Add(texto);
            return texto;
        }

        private ComboBox AgregarCombo(Control contenedor, string etiqueta, int x, int yEtiqueta, int ancho, int yCombo)
        {
            Label label = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 60, 70),
                Location = new Point(x, yEtiqueta),
                Text = etiqueta
            };
            ComboBox combo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(x, yCombo),
                Size = new Size(ancho, 25)
            };
            contenedor.Controls.Add(label);
            contenedor.Controls.Add(combo);
            return combo;
        }

        private static void OcultarControl(Control control)
        {
            control.Visible = false;
        }

        // Mantiene la tarjeta centrada cuando cambia el tamaño de la ventana.
        private void CentrarPanelCard()
        {
            int x = (ClientSize.Width - panelCard.Width) / 2;
            int y = (ClientSize.Height - panelCard.Height) / 2;
            panelCard.Location = new Point(Math.Max(10, x), Math.Max(10, y));
        }

        private void crearPaciente_Load(object sender, EventArgs e)
        {
            // Colocar el cursor inicialmente en el primer nombre.
            txtNombres.Focus();

            // Centrar la tarjeta al abrir el formulario.
            CentrarPanelCard();

            // Si el ComboBox tiene opciones, seleccionar la primera.
            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;

            // No permitir una fecha de nacimiento futura.
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            // Mensajes de error iniciales.
            lblErrorNombres.Text = string.Empty;
            lblErrorTelefono.Text = string.Empty;
            CargarDepartamentos();
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
        // RESPONSIVE
        // ============================================================

        private void crearPaciente_Resize(object sender, EventArgs e)
        {
            CentrarPanelCard();
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
                // Enviar los datos del paciente y su contacto opcional al Controller.
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

                // Confirmar el registro y volver al menú principal.
                MessageBox.Show("¡Paciente registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menuPrincipalMedicos menuPaciente = new menuPrincipalMedicos();
                menuPaciente.Show();
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
            menuPrincipalMedicos menu = new menuPrincipalMedicos();
            menu.Show();
            Close();
        }

        private void crearPaciente_Load_1(object sender, EventArgs e) { }

        // Eventos requeridos por los controles del formulario.
        private void panelCard_Paint(object sender, PaintEventArgs e) { }
        private void panelDatosPersonales_Paint(object sender, PaintEventArgs e) { }
    }
}
