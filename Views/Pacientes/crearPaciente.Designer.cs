using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class crearPaciente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelCard = new System.Windows.Forms.Panel();
            this.panelLineaVerde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelDatosPersonales = new System.Windows.Forms.Panel();
            this.lblSeccionPersonal = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblErrorNombres = new System.Windows.Forms.Label();
            this.lblSegundoNombre = new System.Windows.Forms.Label();
            this.txtSegundoNombre = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblNumeroINSS = new System.Windows.Forms.Label();
            this.txtNumeroINSS = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.lblComunidad = new System.Windows.Forms.Label();
            this.cmbComunidad = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.panelRegistroSalud = new System.Windows.Forms.Panel();
            this.lblSeccionSalud = new System.Windows.Forms.Label();
            this.lblTipoSangre = new System.Windows.Forms.Label();
            this.cmbTipoSangre = new System.Windows.Forms.ComboBox();
            this.lblAlergias = new System.Windows.Forms.Label();
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.lblAntecedentes = new System.Windows.Forms.Label();
            this.txtAntecedentes = new System.Windows.Forms.TextBox();
            this.lblSeccionContactos = new System.Windows.Forms.Label();
            this.lblContactosAyuda = new System.Windows.Forms.Label();
            this.lblContactoPrimerNombre = new System.Windows.Forms.Label();
            this.txtContactoPrimerNombre = new System.Windows.Forms.TextBox();
            this.lblContactoSegundoNombre = new System.Windows.Forms.Label();
            this.txtContactoSegundoNombre = new System.Windows.Forms.TextBox();
            this.lblContactoPrimerApellido = new System.Windows.Forms.Label();
            this.txtContactoPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblContactoSegundoApellido = new System.Windows.Forms.Label();
            this.txtContactoSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblContactoParentesco = new System.Windows.Forms.Label();
            this.txtContactoParentesco = new System.Windows.Forms.TextBox();
            this.lblContactoTelefono = new System.Windows.Forms.Label();
            this.txtContactoTelefono = new System.Windows.Forms.TextBox();
            this.lblContactoCedula = new System.Windows.Forms.Label();
            this.txtContactoCedula = new System.Windows.Forms.TextBox();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.lblErrorContacto = new System.Windows.Forms.Label();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.colContNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.panelCard.SuspendLayout();
            this.panelDatosPersonales.SuspendLayout();
            this.panelRegistroSalud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            //
            // panelCard
            //
            this.panelCard.AutoScroll = true;
            this.panelCard.BackColor = Tema.FondoTarjeta;
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.panelDatosPersonales);
            this.panelCard.Controls.Add(this.panelRegistroSalud);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(1100, 750);
            this.panelCard.TabIndex = 0;
            //
            // panelLineaVerde
            //
            this.panelLineaVerde.BackColor = Tema.VerdeAcento;
            this.panelLineaVerde.Location = new System.Drawing.Point(25, 20);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(5, 45);
            this.panelLineaVerde.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(36, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "SANAR RURAL";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteCuerpo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(38, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(188, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Registro de Datos del Paciente";
            //
            // panelDatosPersonales
            //
            this.panelDatosPersonales.BackColor = Tema.Superficie;
            this.panelDatosPersonales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatosPersonales.Controls.Add(this.lblSeccionPersonal);
            this.panelDatosPersonales.Controls.Add(this.lblNombres);
            this.panelDatosPersonales.Controls.Add(this.txtNombres);
            this.panelDatosPersonales.Controls.Add(this.lblErrorNombres);
            this.panelDatosPersonales.Controls.Add(this.lblSegundoNombre);
            this.panelDatosPersonales.Controls.Add(this.txtSegundoNombre);
            this.panelDatosPersonales.Controls.Add(this.lblApellidos);
            this.panelDatosPersonales.Controls.Add(this.txtApellidos);
            this.panelDatosPersonales.Controls.Add(this.lblSegundoApellido);
            this.panelDatosPersonales.Controls.Add(this.txtSegundoApellido);
            this.panelDatosPersonales.Controls.Add(this.lblCedula);
            this.panelDatosPersonales.Controls.Add(this.txtCedula);
            this.panelDatosPersonales.Controls.Add(this.lblNumeroINSS);
            this.panelDatosPersonales.Controls.Add(this.txtNumeroINSS);
            this.panelDatosPersonales.Controls.Add(this.lblFechaNacimiento);
            this.panelDatosPersonales.Controls.Add(this.dtpFechaNacimiento);
            this.panelDatosPersonales.Controls.Add(this.lblGenero);
            this.panelDatosPersonales.Controls.Add(this.cmbGenero);
            this.panelDatosPersonales.Controls.Add(this.lblTelefono);
            this.panelDatosPersonales.Controls.Add(this.txtTelefono);
            this.panelDatosPersonales.Controls.Add(this.lblErrorTelefono);
            this.panelDatosPersonales.Controls.Add(this.lblUbicacion);
            this.panelDatosPersonales.Controls.Add(this.lblDepartamento);
            this.panelDatosPersonales.Controls.Add(this.cmbDepartamento);
            this.panelDatosPersonales.Controls.Add(this.lblMunicipio);
            this.panelDatosPersonales.Controls.Add(this.cmbMunicipio);
            this.panelDatosPersonales.Controls.Add(this.lblComunidad);
            this.panelDatosPersonales.Controls.Add(this.cmbComunidad);
            this.panelDatosPersonales.Controls.Add(this.lblDireccion);
            this.panelDatosPersonales.Controls.Add(this.txtDireccion);
            this.panelDatosPersonales.Location = new System.Drawing.Point(25, 78);
            this.panelDatosPersonales.Name = "panelDatosPersonales";
            this.panelDatosPersonales.Size = new System.Drawing.Size(515, 600);
            this.panelDatosPersonales.TabIndex = 3;
            //
            // lblSeccionPersonal
            //
            this.lblSeccionPersonal.AutoSize = true;
            this.lblSeccionPersonal.Font = Tema.FuenteSubtitulo;
            this.lblSeccionPersonal.ForeColor = Tema.AzulPrimario;
            this.lblSeccionPersonal.Location = new System.Drawing.Point(18, 12);
            this.lblSeccionPersonal.Name = "lblSeccionPersonal";
            this.lblSeccionPersonal.Size = new System.Drawing.Size(125, 20);
            this.lblSeccionPersonal.TabIndex = 0;
            this.lblSeccionPersonal.Text = "Datos personales";
            //
            // lblNombres
            //
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = Tema.FuenteLabelCampo;
            this.lblNombres.ForeColor = Tema.TextoPrincipal;
            this.lblNombres.Location = new System.Drawing.Point(18, 42);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(107, 15);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.Text = "Primer nombre *";
            //
            // txtNombres
            //
            this.txtNombres.Font = Tema.FuenteInput;
            this.txtNombres.Location = new System.Drawing.Point(18, 60);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(225, 25);
            this.txtNombres.TabIndex = 2;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            //
            // lblErrorNombres
            //
            this.lblErrorNombres.AutoSize = true;
            this.lblErrorNombres.Font = Tema.FuenteAyuda;
            this.lblErrorNombres.ForeColor = Tema.Error;
            this.lblErrorNombres.Location = new System.Drawing.Point(18, 86);
            this.lblErrorNombres.Name = "lblErrorNombres";
            this.lblErrorNombres.Size = new System.Drawing.Size(0, 13);
            this.lblErrorNombres.TabIndex = 3;
            //
            // lblSegundoNombre
            //
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Font = Tema.FuenteLabelCampo;
            this.lblSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoNombre.Location = new System.Drawing.Point(265, 42);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(103, 15);
            this.lblSegundoNombre.TabIndex = 4;
            this.lblSegundoNombre.Text = "Segundo nombre";
            //
            // txtSegundoNombre
            //
            this.txtSegundoNombre.Font = Tema.FuenteInput;
            this.txtSegundoNombre.Location = new System.Drawing.Point(265, 60);
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(225, 25);
            this.txtSegundoNombre.TabIndex = 5;
            //
            // lblApellidos
            //
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = Tema.FuenteLabelCampo;
            this.lblApellidos.ForeColor = Tema.TextoPrincipal;
            this.lblApellidos.Location = new System.Drawing.Point(18, 102);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(108, 15);
            this.lblApellidos.TabIndex = 6;
            this.lblApellidos.Text = "Primer apellido *";
            //
            // txtApellidos
            //
            this.txtApellidos.Font = Tema.FuenteInput;
            this.txtApellidos.Location = new System.Drawing.Point(18, 120);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(225, 25);
            this.txtApellidos.TabIndex = 7;
            //
            // lblSegundoApellido
            //
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = Tema.FuenteLabelCampo;
            this.lblSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoApellido.Location = new System.Drawing.Point(265, 102);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(104, 15);
            this.lblSegundoApellido.TabIndex = 8;
            this.lblSegundoApellido.Text = "Segundo apellido";
            //
            // txtSegundoApellido
            //
            this.txtSegundoApellido.Font = Tema.FuenteInput;
            this.txtSegundoApellido.Location = new System.Drawing.Point(265, 120);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(225, 25);
            this.txtSegundoApellido.TabIndex = 9;
            //
            // lblCedula
            //
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = Tema.FuenteLabelCampo;
            this.lblCedula.ForeColor = Tema.TextoPrincipal;
            this.lblCedula.Location = new System.Drawing.Point(18, 154);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(46, 15);
            this.lblCedula.TabIndex = 10;
            this.lblCedula.Text = "Cédula";
            //
            // txtCedula
            //
            this.txtCedula.Font = Tema.FuenteInput;
            this.txtCedula.Location = new System.Drawing.Point(18, 172);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(225, 25);
            this.txtCedula.TabIndex = 11;
            //
            // lblNumeroINSS
            //
            this.lblNumeroINSS.AutoSize = true;
            this.lblNumeroINSS.Font = Tema.FuenteLabelCampo;
            this.lblNumeroINSS.ForeColor = Tema.TextoPrincipal;
            this.lblNumeroINSS.Location = new System.Drawing.Point(265, 154);
            this.lblNumeroINSS.Name = "lblNumeroINSS";
            this.lblNumeroINSS.Size = new System.Drawing.Size(81, 15);
            this.lblNumeroINSS.TabIndex = 12;
            this.lblNumeroINSS.Text = "Número INSS";
            //
            // txtNumeroINSS
            //
            this.txtNumeroINSS.Font = Tema.FuenteInput;
            this.txtNumeroINSS.Location = new System.Drawing.Point(265, 172);
            this.txtNumeroINSS.Name = "txtNumeroINSS";
            this.txtNumeroINSS.Size = new System.Drawing.Size(225, 25);
            this.txtNumeroINSS.TabIndex = 13;
            //
            // lblFechaNacimiento
            //
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = Tema.FuenteLabelCampo;
            this.lblFechaNacimiento.ForeColor = Tema.TextoPrincipal;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(18, 206);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(134, 15);
            this.lblFechaNacimiento.TabIndex = 14;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento *";
            //
            // dtpFechaNacimiento
            //
            this.dtpFechaNacimiento.Font = Tema.FuenteInput;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(18, 224);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(225, 25);
            this.dtpFechaNacimiento.TabIndex = 15;
            //
            // lblGenero
            //
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = Tema.FuenteLabelCampo;
            this.lblGenero.ForeColor = Tema.TextoPrincipal;
            this.lblGenero.Location = new System.Drawing.Point(265, 206);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(48, 15);
            this.lblGenero.TabIndex = 16;
            this.lblGenero.Text = "Género";
            //
            // cmbGenero
            //
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = Tema.FuenteInput;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(265, 224);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(225, 25);
            this.cmbGenero.TabIndex = 17;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(18, 258);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(56, 15);
            this.lblTelefono.TabIndex = 18;
            this.lblTelefono.Text = "Teléfono";
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(18, 276);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(225, 25);
            this.txtTelefono.TabIndex = 19;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            //
            // lblErrorTelefono
            //
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.Font = Tema.FuenteAyuda;
            this.lblErrorTelefono.ForeColor = Tema.Error;
            this.lblErrorTelefono.Location = new System.Drawing.Point(18, 302);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(0, 13);
            this.lblErrorTelefono.TabIndex = 20;
            //
            // lblUbicacion
            //
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = Tema.FuenteSubtitulo;
            this.lblUbicacion.ForeColor = Tema.AzulPrimario;
            this.lblUbicacion.Location = new System.Drawing.Point(18, 324);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(161, 20);
            this.lblUbicacion.TabIndex = 21;
            this.lblUbicacion.Text = "Ubicación geográfica";
            //
            // lblDepartamento
            //
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = Tema.FuenteLabelCampo;
            this.lblDepartamento.ForeColor = Tema.TextoPrincipal;
            this.lblDepartamento.Location = new System.Drawing.Point(18, 354);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(96, 15);
            this.lblDepartamento.TabIndex = 22;
            this.lblDepartamento.Text = "Departamento *";
            //
            // cmbDepartamento
            //
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = Tema.FuenteInput;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(18, 372);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(225, 25);
            this.cmbDepartamento.TabIndex = 23;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            //
            // lblMunicipio
            //
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = Tema.FuenteLabelCampo;
            this.lblMunicipio.ForeColor = Tema.TextoPrincipal;
            this.lblMunicipio.Location = new System.Drawing.Point(265, 354);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(70, 15);
            this.lblMunicipio.TabIndex = 24;
            this.lblMunicipio.Text = "Municipio *";
            //
            // cmbMunicipio
            //
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Font = Tema.FuenteInput;
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(265, 372);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(225, 25);
            this.cmbMunicipio.TabIndex = 25;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            //
            // lblComunidad
            //
            this.lblComunidad.AutoSize = true;
            this.lblComunidad.Font = Tema.FuenteLabelCampo;
            this.lblComunidad.ForeColor = Tema.TextoPrincipal;
            this.lblComunidad.Location = new System.Drawing.Point(18, 406);
            this.lblComunidad.Name = "lblComunidad";
            this.lblComunidad.Size = new System.Drawing.Size(81, 15);
            this.lblComunidad.TabIndex = 26;
            this.lblComunidad.Text = "Comunidad *";
            //
            // cmbComunidad
            //
            this.cmbComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComunidad.Font = Tema.FuenteInput;
            this.cmbComunidad.FormattingEnabled = true;
            this.cmbComunidad.Location = new System.Drawing.Point(18, 424);
            this.cmbComunidad.Name = "cmbComunidad";
            this.cmbComunidad.Size = new System.Drawing.Size(472, 25);
            this.cmbComunidad.TabIndex = 27;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = Tema.FuenteLabelCampo;
            this.lblDireccion.ForeColor = Tema.TextoPrincipal;
            this.lblDireccion.Location = new System.Drawing.Point(18, 458);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(117, 15);
            this.lblDireccion.TabIndex = 28;
            this.lblDireccion.Text = "Dirección domiciliar";
            //
            // txtDireccion
            //
            this.txtDireccion.Font = Tema.FuenteInput;
            this.txtDireccion.Location = new System.Drawing.Point(18, 476);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(472, 85);
            this.txtDireccion.TabIndex = 29;
            //
            // panelRegistroSalud
            //
            this.panelRegistroSalud.BackColor = Tema.Superficie;
            this.panelRegistroSalud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRegistroSalud.Controls.Add(this.lblSeccionSalud);
            this.panelRegistroSalud.Controls.Add(this.lblTipoSangre);
            this.panelRegistroSalud.Controls.Add(this.cmbTipoSangre);
            this.panelRegistroSalud.Controls.Add(this.lblAlergias);
            this.panelRegistroSalud.Controls.Add(this.txtAlergias);
            this.panelRegistroSalud.Controls.Add(this.lblAntecedentes);
            this.panelRegistroSalud.Controls.Add(this.txtAntecedentes);
            this.panelRegistroSalud.Controls.Add(this.lblSeccionContactos);
            this.panelRegistroSalud.Controls.Add(this.lblContactosAyuda);
            this.panelRegistroSalud.Controls.Add(this.lblContactoPrimerNombre);
            this.panelRegistroSalud.Controls.Add(this.txtContactoPrimerNombre);
            this.panelRegistroSalud.Controls.Add(this.lblContactoSegundoNombre);
            this.panelRegistroSalud.Controls.Add(this.txtContactoSegundoNombre);
            this.panelRegistroSalud.Controls.Add(this.lblContactoPrimerApellido);
            this.panelRegistroSalud.Controls.Add(this.txtContactoPrimerApellido);
            this.panelRegistroSalud.Controls.Add(this.lblContactoSegundoApellido);
            this.panelRegistroSalud.Controls.Add(this.txtContactoSegundoApellido);
            this.panelRegistroSalud.Controls.Add(this.lblContactoParentesco);
            this.panelRegistroSalud.Controls.Add(this.txtContactoParentesco);
            this.panelRegistroSalud.Controls.Add(this.lblContactoTelefono);
            this.panelRegistroSalud.Controls.Add(this.txtContactoTelefono);
            this.panelRegistroSalud.Controls.Add(this.lblContactoCedula);
            this.panelRegistroSalud.Controls.Add(this.txtContactoCedula);
            this.panelRegistroSalud.Controls.Add(this.btnAgregarContacto);
            this.panelRegistroSalud.Controls.Add(this.lblErrorContacto);
            this.panelRegistroSalud.Controls.Add(this.dgvContactos);
            this.panelRegistroSalud.Location = new System.Drawing.Point(555, 78);
            this.panelRegistroSalud.Name = "panelRegistroSalud";
            this.panelRegistroSalud.Size = new System.Drawing.Size(520, 600);
            this.panelRegistroSalud.TabIndex = 4;
            //
            // lblSeccionSalud
            //
            this.lblSeccionSalud.AutoSize = true;
            this.lblSeccionSalud.Font = Tema.FuenteSubtitulo;
            this.lblSeccionSalud.ForeColor = Tema.AzulPrimario;
            this.lblSeccionSalud.Location = new System.Drawing.Point(18, 12);
            this.lblSeccionSalud.Name = "lblSeccionSalud";
            this.lblSeccionSalud.Size = new System.Drawing.Size(227, 20);
            this.lblSeccionSalud.TabIndex = 0;
            this.lblSeccionSalud.Text = "Registro de salud y contactos";
            //
            // lblTipoSangre
            //
            this.lblTipoSangre.AutoSize = true;
            this.lblTipoSangre.Font = Tema.FuenteLabelCampo;
            this.lblTipoSangre.ForeColor = Tema.TextoPrincipal;
            this.lblTipoSangre.Location = new System.Drawing.Point(18, 38);
            this.lblTipoSangre.Name = "lblTipoSangre";
            this.lblTipoSangre.Size = new System.Drawing.Size(91, 15);
            this.lblTipoSangre.TabIndex = 1;
            this.lblTipoSangre.Text = "Tipo de sangre";
            //
            // cmbTipoSangre
            //
            this.cmbTipoSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSangre.Font = Tema.FuenteInput;
            this.cmbTipoSangre.FormattingEnabled = true;
            this.cmbTipoSangre.Items.AddRange(new object[] {
            "No especificado",
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cmbTipoSangre.Location = new System.Drawing.Point(18, 56);
            this.cmbTipoSangre.Name = "cmbTipoSangre";
            this.cmbTipoSangre.Size = new System.Drawing.Size(215, 25);
            this.cmbTipoSangre.TabIndex = 2;
            //
            // lblAlergias
            //
            this.lblAlergias.AutoSize = true;
            this.lblAlergias.Font = Tema.FuenteLabelCampo;
            this.lblAlergias.ForeColor = Tema.TextoPrincipal;
            this.lblAlergias.Location = new System.Drawing.Point(18, 88);
            this.lblAlergias.Name = "lblAlergias";
            this.lblAlergias.Size = new System.Drawing.Size(117, 15);
            this.lblAlergias.TabIndex = 3;
            this.lblAlergias.Text = "Alergias conocidas";
            //
            // txtAlergias
            //
            this.txtAlergias.Font = Tema.FuenteInput;
            this.txtAlergias.Location = new System.Drawing.Point(18, 106);
            this.txtAlergias.Multiline = true;
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlergias.Size = new System.Drawing.Size(484, 40);
            this.txtAlergias.TabIndex = 4;
            //
            // lblAntecedentes
            //
            this.lblAntecedentes.AutoSize = true;
            this.lblAntecedentes.Font = Tema.FuenteLabelCampo;
            this.lblAntecedentes.ForeColor = Tema.TextoPrincipal;
            this.lblAntecedentes.Location = new System.Drawing.Point(18, 152);
            this.lblAntecedentes.Name = "lblAntecedentes";
            this.lblAntecedentes.Size = new System.Drawing.Size(130, 15);
            this.lblAntecedentes.TabIndex = 5;
            this.lblAntecedentes.Text = "Antecedentes médicos";
            //
            // txtAntecedentes
            //
            this.txtAntecedentes.Font = Tema.FuenteInput;
            this.txtAntecedentes.Location = new System.Drawing.Point(18, 170);
            this.txtAntecedentes.Multiline = true;
            this.txtAntecedentes.Name = "txtAntecedentes";
            this.txtAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntecedentes.Size = new System.Drawing.Size(484, 40);
            this.txtAntecedentes.TabIndex = 6;
            //
            // lblSeccionContactos
            //
            this.lblSeccionContactos.AutoSize = true;
            this.lblSeccionContactos.Font = Tema.FuenteSubtitulo;
            this.lblSeccionContactos.ForeColor = Tema.AzulOscuro;
            this.lblSeccionContactos.Location = new System.Drawing.Point(18, 220);
            this.lblSeccionContactos.Name = "lblSeccionContactos";
            this.lblSeccionContactos.Size = new System.Drawing.Size(242, 20);
            this.lblSeccionContactos.TabIndex = 7;
            this.lblSeccionContactos.Text = "Contactos de emergencia (1:N)";
            //
            // lblContactosAyuda
            //
            this.lblContactosAyuda.AutoSize = true;
            this.lblContactosAyuda.Font = Tema.FuenteAyuda;
            this.lblContactosAyuda.ForeColor = Tema.TextoSecundario;
            this.lblContactosAyuda.Location = new System.Drawing.Point(18, 243);
            this.lblContactosAyuda.Name = "lblContactosAyuda";
            this.lblContactosAyuda.Size = new System.Drawing.Size(350, 13);
            this.lblContactosAyuda.TabIndex = 8;
            this.lblContactosAyuda.Text = "Agregue familiares o allegados a la lista antes de guardar el expediente.";
            //
            // lblContactoPrimerNombre
            //
            this.lblContactoPrimerNombre.AutoSize = true;
            this.lblContactoPrimerNombre.Font = Tema.FuenteAyuda;
            this.lblContactoPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblContactoPrimerNombre.Location = new System.Drawing.Point(18, 263);
            this.lblContactoPrimerNombre.Name = "lblContactoPrimerNombre";
            this.lblContactoPrimerNombre.Size = new System.Drawing.Size(69, 13);
            this.lblContactoPrimerNombre.TabIndex = 9;
            this.lblContactoPrimerNombre.Text = "1er Nombre *";
            //
            // txtContactoPrimerNombre
            //
            this.txtContactoPrimerNombre.Font = Tema.FuenteAyuda;
            this.txtContactoPrimerNombre.Location = new System.Drawing.Point(18, 279);
            this.txtContactoPrimerNombre.Name = "txtContactoPrimerNombre";
            this.txtContactoPrimerNombre.Size = new System.Drawing.Size(115, 20);
            this.txtContactoPrimerNombre.TabIndex = 10;
            //
            // lblContactoSegundoNombre
            //
            this.lblContactoSegundoNombre.AutoSize = true;
            this.lblContactoSegundoNombre.Font = Tema.FuenteAyuda;
            this.lblContactoSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblContactoSegundoNombre.Location = new System.Drawing.Point(140, 263);
            this.lblContactoSegundoNombre.Name = "lblContactoSegundoNombre";
            this.lblContactoSegundoNombre.Size = new System.Drawing.Size(65, 13);
            this.lblContactoSegundoNombre.TabIndex = 11;
            this.lblContactoSegundoNombre.Text = "2do Nombre";
            //
            // txtContactoSegundoNombre
            //
            this.txtContactoSegundoNombre.Font = Tema.FuenteAyuda;
            this.txtContactoSegundoNombre.Location = new System.Drawing.Point(140, 279);
            this.txtContactoSegundoNombre.Name = "txtContactoSegundoNombre";
            this.txtContactoSegundoNombre.Size = new System.Drawing.Size(115, 20);
            this.txtContactoSegundoNombre.TabIndex = 12;
            //
            // lblContactoPrimerApellido
            //
            this.lblContactoPrimerApellido.AutoSize = true;
            this.lblContactoPrimerApellido.Font = Tema.FuenteAyuda;
            this.lblContactoPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblContactoPrimerApellido.Location = new System.Drawing.Point(262, 263);
            this.lblContactoPrimerApellido.Name = "lblContactoPrimerApellido";
            this.lblContactoPrimerApellido.Size = new System.Drawing.Size(68, 13);
            this.lblContactoPrimerApellido.TabIndex = 13;
            this.lblContactoPrimerApellido.Text = "1er Apellido *";
            //
            // txtContactoPrimerApellido
            //
            this.txtContactoPrimerApellido.Font = Tema.FuenteAyuda;
            this.txtContactoPrimerApellido.Location = new System.Drawing.Point(262, 279);
            this.txtContactoPrimerApellido.Name = "txtContactoPrimerApellido";
            this.txtContactoPrimerApellido.Size = new System.Drawing.Size(115, 20);
            this.txtContactoPrimerApellido.TabIndex = 14;
            //
            // lblContactoSegundoApellido
            //
            this.lblContactoSegundoApellido.AutoSize = true;
            this.lblContactoSegundoApellido.Font = Tema.FuenteAyuda;
            this.lblContactoSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblContactoSegundoApellido.Location = new System.Drawing.Point(384, 263);
            this.lblContactoSegundoApellido.Name = "lblContactoSegundoApellido";
            this.lblContactoSegundoApellido.Size = new System.Drawing.Size(64, 13);
            this.lblContactoSegundoApellido.TabIndex = 15;
            this.lblContactoSegundoApellido.Text = "2do Apellido";
            //
            // txtContactoSegundoApellido
            //
            this.txtContactoSegundoApellido.Font = Tema.FuenteAyuda;
            this.txtContactoSegundoApellido.Location = new System.Drawing.Point(384, 279);
            this.txtContactoSegundoApellido.Name = "txtContactoSegundoApellido";
            this.txtContactoSegundoApellido.Size = new System.Drawing.Size(118, 20);
            this.txtContactoSegundoApellido.TabIndex = 16;
            //
            // lblContactoParentesco
            //
            this.lblContactoParentesco.AutoSize = true;
            this.lblContactoParentesco.Font = Tema.FuenteAyuda;
            this.lblContactoParentesco.ForeColor = Tema.TextoPrincipal;
            this.lblContactoParentesco.Location = new System.Drawing.Point(18, 307);
            this.lblContactoParentesco.Name = "lblContactoParentesco";
            this.lblContactoParentesco.Size = new System.Drawing.Size(68, 13);
            this.lblContactoParentesco.TabIndex = 17;
            this.lblContactoParentesco.Text = "Parentesco *";
            //
            // txtContactoParentesco
            //
            this.txtContactoParentesco.Font = Tema.FuenteAyuda;
            this.txtContactoParentesco.Location = new System.Drawing.Point(18, 323);
            this.txtContactoParentesco.Name = "txtContactoParentesco";
            this.txtContactoParentesco.Size = new System.Drawing.Size(115, 20);
            this.txtContactoParentesco.TabIndex = 18;
            //
            // lblContactoTelefono
            //
            this.lblContactoTelefono.AutoSize = true;
            this.lblContactoTelefono.Font = Tema.FuenteAyuda;
            this.lblContactoTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblContactoTelefono.Location = new System.Drawing.Point(140, 307);
            this.lblContactoTelefono.Name = "lblContactoTelefono";
            this.lblContactoTelefono.Size = new System.Drawing.Size(56, 13);
            this.lblContactoTelefono.TabIndex = 19;
            this.lblContactoTelefono.Text = "Teléfono *";
            //
            // txtContactoTelefono
            //
            this.txtContactoTelefono.Font = Tema.FuenteAyuda;
            this.txtContactoTelefono.Location = new System.Drawing.Point(140, 323);
            this.txtContactoTelefono.Name = "txtContactoTelefono";
            this.txtContactoTelefono.Size = new System.Drawing.Size(115, 20);
            this.txtContactoTelefono.TabIndex = 20;
            //
            // lblContactoCedula
            //
            this.lblContactoCedula.AutoSize = true;
            this.lblContactoCedula.Font = Tema.FuenteAyuda;
            this.lblContactoCedula.ForeColor = Tema.TextoPrincipal;
            this.lblContactoCedula.Location = new System.Drawing.Point(262, 307);
            this.lblContactoCedula.Name = "lblContactoCedula";
            this.lblContactoCedula.Size = new System.Drawing.Size(40, 13);
            this.lblContactoCedula.TabIndex = 21;
            this.lblContactoCedula.Text = "Cédula";
            //
            // txtContactoCedula
            //
            this.txtContactoCedula.Font = Tema.FuenteAyuda;
            this.txtContactoCedula.Location = new System.Drawing.Point(262, 323);
            this.txtContactoCedula.Name = "txtContactoCedula";
            this.txtContactoCedula.Size = new System.Drawing.Size(115, 20);
            this.txtContactoCedula.TabIndex = 22;
            //
            // btnAgregarContacto
            //
            this.btnAgregarContacto.BackColor = Tema.VerdeAcento;
            this.btnAgregarContacto.FlatAppearance.BorderSize = 0;
            this.btnAgregarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContacto.Font = Tema.FuenteAyuda;
            this.btnAgregarContacto.ForeColor = Tema.Superficie;
            this.btnAgregarContacto.Location = new System.Drawing.Point(384, 318);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(118, 28);
            this.btnAgregarContacto.TabIndex = 23;
            this.btnAgregarContacto.Text = "+ Agregar";
            this.btnAgregarContacto.UseVisualStyleBackColor = false;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            //
            // lblErrorContacto
            //
            this.lblErrorContacto.AutoSize = true;
            this.lblErrorContacto.Font = Tema.FuenteAyuda;
            this.lblErrorContacto.ForeColor = Tema.Error;
            this.lblErrorContacto.Location = new System.Drawing.Point(18, 349);
            this.lblErrorContacto.Name = "lblErrorContacto";
            this.lblErrorContacto.Size = new System.Drawing.Size(0, 13);
            this.lblErrorContacto.TabIndex = 24;
            //
            // dgvContactos
            //
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.BackgroundColor = Tema.Superficie;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContNombre,
            this.colContParentesco,
            this.colContTelefono,
            this.colContCedula,
            this.colContQuitar});
            this.dgvContactos.Location = new System.Drawing.Point(18, 368);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.Size = new System.Drawing.Size(484, 215);
            this.dgvContactos.TabIndex = 25;
            this.dgvContactos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactos_CellContentClick);
            //
            // colContNombre
            //
            this.colContNombre.HeaderText = "Nombre";
            this.colContNombre.Name = "colContNombre";
            this.colContNombre.ReadOnly = true;
            this.colContNombre.Width = 135;
            //
            // colContParentesco
            //
            this.colContParentesco.HeaderText = "Parentesco";
            this.colContParentesco.Name = "colContParentesco";
            this.colContParentesco.ReadOnly = true;
            this.colContParentesco.Width = 85;
            //
            // colContTelefono
            //
            this.colContTelefono.HeaderText = "Teléfono";
            this.colContTelefono.Name = "colContTelefono";
            this.colContTelefono.ReadOnly = true;
            this.colContTelefono.Width = 85;
            //
            // colContCedula
            //
            this.colContCedula.HeaderText = "Cédula";
            this.colContCedula.Name = "colContCedula";
            this.colContCedula.ReadOnly = true;
            this.colContCedula.Width = 95;
            //
            // colContQuitar
            //
            this.colContQuitar.HeaderText = "Acción";
            this.colContQuitar.Name = "colContQuitar";
            this.colContQuitar.ReadOnly = true;
            this.colContQuitar.Text = "✕ Quitar";
            this.colContQuitar.UseColumnTextForButtonValue = true;
            this.colContQuitar.Width = 65;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = Tema.Superficie;
            this.btnGuardar.Location = new System.Drawing.Point(25, 690);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(1050, 42);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar paciente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // lnkVolver
            //
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = Tema.FuenteCuerpo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(490, 738);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(120, 17);
            this.lnkVolver.TabIndex = 6;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "Volver al listado";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            //
            // crearPaciente
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1100, 770);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "crearPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Paciente";
            this.Load += new System.EventHandler(this.crearPaciente_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelDatosPersonales.ResumeLayout(false);
            this.panelDatosPersonales.PerformLayout();
            this.panelRegistroSalud.ResumeLayout(false);
            this.panelRegistroSalud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelDatosPersonales;
        private System.Windows.Forms.Label lblSeccionPersonal;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblErrorNombres;
        private System.Windows.Forms.Label lblSegundoNombre;
        private System.Windows.Forms.TextBox txtSegundoNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblNumeroINSS;
        private System.Windows.Forms.TextBox txtNumeroINSS;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblErrorTelefono;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.Label lblComunidad;
        private System.Windows.Forms.ComboBox cmbComunidad;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Panel panelRegistroSalud;
        private System.Windows.Forms.Label lblSeccionSalud;
        private System.Windows.Forms.Label lblTipoSangre;
        private System.Windows.Forms.ComboBox cmbTipoSangre;
        private System.Windows.Forms.Label lblAlergias;
        private System.Windows.Forms.TextBox txtAlergias;
        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.TextBox txtAntecedentes;
        private System.Windows.Forms.Label lblSeccionContactos;
        private System.Windows.Forms.Label lblContactosAyuda;
        private System.Windows.Forms.Label lblContactoPrimerNombre;
        private System.Windows.Forms.TextBox txtContactoPrimerNombre;
        private System.Windows.Forms.Label lblContactoSegundoNombre;
        private System.Windows.Forms.TextBox txtContactoSegundoNombre;
        private System.Windows.Forms.Label lblContactoPrimerApellido;
        private System.Windows.Forms.TextBox txtContactoPrimerApellido;
        private System.Windows.Forms.Label lblContactoSegundoApellido;
        private System.Windows.Forms.TextBox txtContactoSegundoApellido;
        private System.Windows.Forms.Label lblContactoParentesco;
        private System.Windows.Forms.TextBox txtContactoParentesco;
        private System.Windows.Forms.Label lblContactoTelefono;
        private System.Windows.Forms.TextBox txtContactoTelefono;
        private System.Windows.Forms.Label lblContactoCedula;
        private System.Windows.Forms.TextBox txtContactoCedula;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.Label lblErrorContacto;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContCedula;
        private System.Windows.Forms.DataGridViewButtonColumn colContQuitar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}
