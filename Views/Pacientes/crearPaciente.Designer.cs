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
            this.panelDatosPersonales = new System.Windows.Forms.Panel();
            this.lblSeccionPersonal = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblErrorNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lblComunidad = new System.Windows.Forms.Label();
            this.txtComunidad = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.panelRegistroSalud = new System.Windows.Forms.Panel();
            this.lblSeccionSalud = new System.Windows.Forms.Label();
            this.lblMensajeSalud = new System.Windows.Forms.Label();
            this.lblContactoEmergencia = new System.Windows.Forms.Label();
            this.txtContactoEmergencia = new System.Windows.Forms.TextBox();
            this.lblTipoSangre = new System.Windows.Forms.Label();
            this.cmbTipoSangre = new System.Windows.Forms.ComboBox();
            this.lblAlergias = new System.Windows.Forms.Label();
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.lblAntecedentes = new System.Windows.Forms.Label();
            this.txtAntecedentes = new System.Windows.Forms.TextBox();
            this.panelLineaVerde = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.panelCard.SuspendLayout();
            this.panelDatosPersonales.SuspendLayout();
            this.panelRegistroSalud.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.AutoScroll = true;
            this.panelCard.BackColor = Tema.FondoTarjeta;
            this.panelCard.Controls.Add(this.panelDatosPersonales);
            this.panelCard.Controls.Add(this.panelRegistroSalud);
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(1070, 720);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            // 
            // panelDatosPersonales
            // 
            this.panelDatosPersonales.BackColor = Tema.FondoTarjeta;
            this.panelDatosPersonales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatosPersonales.Controls.Add(this.lblSeccionPersonal);
            this.panelDatosPersonales.Controls.Add(this.lblUbicacion);
            this.panelDatosPersonales.Controls.Add(this.lblNombres);
            this.panelDatosPersonales.Controls.Add(this.txtNombres);
            this.panelDatosPersonales.Controls.Add(this.lblErrorNombres);
            this.panelDatosPersonales.Controls.Add(this.lblApellidos);
            this.panelDatosPersonales.Controls.Add(this.txtApellidos);
            this.panelDatosPersonales.Controls.Add(this.lblFechaNacimiento);
            this.panelDatosPersonales.Controls.Add(this.dtpFechaNacimiento);
            this.panelDatosPersonales.Controls.Add(this.lblGenero);
            this.panelDatosPersonales.Controls.Add(this.cmbGenero);
            this.panelDatosPersonales.Controls.Add(this.lblTelefono);
            this.panelDatosPersonales.Controls.Add(this.txtTelefono);
            this.panelDatosPersonales.Controls.Add(this.lblErrorTelefono);
            this.panelDatosPersonales.Controls.Add(this.lblDepartamento);
            this.panelDatosPersonales.Controls.Add(this.txtDepartamento);
            this.panelDatosPersonales.Controls.Add(this.lblMunicipio);
            this.panelDatosPersonales.Controls.Add(this.txtMunicipio);
            this.panelDatosPersonales.Controls.Add(this.lblComunidad);
            this.panelDatosPersonales.Controls.Add(this.txtComunidad);
            this.panelDatosPersonales.Controls.Add(this.lblDireccion);
            this.panelDatosPersonales.Controls.Add(this.txtDireccion);
            this.panelDatosPersonales.Location = new System.Drawing.Point(30, 90);
            this.panelDatosPersonales.Name = "panelDatosPersonales";
            this.panelDatosPersonales.Size = new System.Drawing.Size(495, 555);
            this.panelDatosPersonales.TabIndex = 0;
            this.panelDatosPersonales.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDatosPersonales_Paint);
            // 
            // lblSeccionPersonal
            // 
            this.lblSeccionPersonal.AutoSize = true;
            this.lblSeccionPersonal.Font = Tema.FuenteLabelCampo;
            this.lblSeccionPersonal.ForeColor = Tema.AzulPrimario;
            this.lblSeccionPersonal.Location = new System.Drawing.Point(20, 18);
            this.lblSeccionPersonal.Name = "lblSeccionPersonal";
            this.lblSeccionPersonal.Size = new System.Drawing.Size(157, 25);
            this.lblSeccionPersonal.TabIndex = 0;
            this.lblSeccionPersonal.Text = "Datos personales";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = Tema.FuenteLabelCampo;
            this.lblUbicacion.ForeColor = Tema.TextoSecundario;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 320);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(75, 19);
            this.lblUbicacion.TabIndex = 11;
            this.lblUbicacion.Text = "Ubicación";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = Tema.FuenteLabelCampo;
            this.lblNombres.ForeColor = Tema.TextoPrincipal;
            this.lblNombres.Location = new System.Drawing.Point(20, 58);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(66, 15);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.Text = "Nombres *";
            // 
            // txtNombres
            // 
            this.txtNombres.Font = Tema.FuenteCuerpo;
            this.txtNombres.Location = new System.Drawing.Point(20, 77);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(450, 25);
            this.txtNombres.TabIndex = 2;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            // 
            // lblErrorNombres
            // 
            this.lblErrorNombres.AutoSize = true;
            this.lblErrorNombres.Font = Tema.FuenteAyuda;
            this.lblErrorNombres.ForeColor = Tema.Error;
            this.lblErrorNombres.Location = new System.Drawing.Point(20, 105);
            this.lblErrorNombres.Name = "lblErrorNombres";
            this.lblErrorNombres.Size = new System.Drawing.Size(0, 13);
            this.lblErrorNombres.TabIndex = 12;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = Tema.FuenteLabelCampo;
            this.lblApellidos.ForeColor = Tema.TextoPrincipal;
            this.lblApellidos.Location = new System.Drawing.Point(20, 125);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(65, 15);
            this.lblApellidos.TabIndex = 3;
            this.lblApellidos.Text = "Apellidos *";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = Tema.FuenteCuerpo;
            this.txtApellidos.Location = new System.Drawing.Point(20, 144);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(450, 25);
            this.txtApellidos.TabIndex = 4;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = Tema.FuenteLabelCampo;
            this.lblFechaNacimiento.ForeColor = Tema.TextoPrincipal;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(20, 185);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(129, 15);
            this.lblFechaNacimiento.TabIndex = 5;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento *";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = Tema.FuenteCuerpo;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(20, 204);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(215, 25);
            this.dtpFechaNacimiento.TabIndex = 6;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = Tema.FuenteLabelCampo;
            this.lblGenero.ForeColor = Tema.TextoPrincipal;
            this.lblGenero.Location = new System.Drawing.Point(260, 185);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(49, 15);
            this.lblGenero.TabIndex = 7;
            this.lblGenero.Text = "Género";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = Tema.FuenteCuerpo;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(260, 204);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(210, 25);
            this.cmbGenero.TabIndex = 8;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(20, 245);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(56, 15);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = Tema.FuenteCuerpo;
            this.txtTelefono.Location = new System.Drawing.Point(20, 264);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(450, 25);
            this.txtTelefono.TabIndex = 10;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.Font = Tema.FuenteAyuda;
            this.lblErrorTelefono.ForeColor = Tema.Error;
            this.lblErrorTelefono.Location = new System.Drawing.Point(20, 292);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(0, 13);
            this.lblErrorTelefono.TabIndex = 13;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = Tema.FuenteAyuda;
            this.lblDepartamento.Location = new System.Drawing.Point(20, 350);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(89, 15);
            this.lblDepartamento.TabIndex = 12;
            this.lblDepartamento.Text = "Departamento";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Font = Tema.FuenteCuerpo;
            this.txtDepartamento.Location = new System.Drawing.Point(20, 369);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(210, 24);
            this.txtDepartamento.TabIndex = 13;
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = Tema.FuenteAyuda;
            this.lblMunicipio.Location = new System.Drawing.Point(260, 350);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(61, 15);
            this.lblMunicipio.TabIndex = 14;
            this.lblMunicipio.Text = "Municipio";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Font = Tema.FuenteCuerpo;
            this.txtMunicipio.Location = new System.Drawing.Point(260, 369);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(210, 24);
            this.txtMunicipio.TabIndex = 15;
            // 
            // lblComunidad
            // 
            this.lblComunidad.AutoSize = true;
            this.lblComunidad.Font = Tema.FuenteAyuda;
            this.lblComunidad.Location = new System.Drawing.Point(20, 405);
            this.lblComunidad.Name = "lblComunidad";
            this.lblComunidad.Size = new System.Drawing.Size(69, 15);
            this.lblComunidad.TabIndex = 16;
            this.lblComunidad.Text = "Comunidad";
            // 
            // txtComunidad
            // 
            this.txtComunidad.Font = Tema.FuenteCuerpo;
            this.txtComunidad.Location = new System.Drawing.Point(20, 424);
            this.txtComunidad.Name = "txtComunidad";
            this.txtComunidad.Size = new System.Drawing.Size(210, 24);
            this.txtComunidad.TabIndex = 17;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = Tema.FuenteAyuda;
            this.lblDireccion.Location = new System.Drawing.Point(260, 405);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(60, 15);
            this.lblDireccion.TabIndex = 18;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = Tema.FuenteCuerpo;
            this.txtDireccion.Location = new System.Drawing.Point(260, 424);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(210, 55);
            this.txtDireccion.TabIndex = 19;
            // 
            // panelRegistroSalud
            // 
            this.panelRegistroSalud.BackColor = Tema.FondoTarjeta;
            this.panelRegistroSalud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRegistroSalud.Controls.Add(this.lblSeccionSalud);
            this.panelRegistroSalud.Controls.Add(this.lblMensajeSalud);
            this.panelRegistroSalud.Controls.Add(this.lblContactoEmergencia);
            this.panelRegistroSalud.Controls.Add(this.txtContactoEmergencia);
            this.panelRegistroSalud.Controls.Add(this.lblTipoSangre);
            this.panelRegistroSalud.Controls.Add(this.cmbTipoSangre);
            this.panelRegistroSalud.Controls.Add(this.lblAlergias);
            this.panelRegistroSalud.Controls.Add(this.txtAlergias);
            this.panelRegistroSalud.Controls.Add(this.lblAntecedentes);
            this.panelRegistroSalud.Controls.Add(this.txtAntecedentes);
            this.panelRegistroSalud.Location = new System.Drawing.Point(545, 90);
            this.panelRegistroSalud.Name = "panelRegistroSalud";
            this.panelRegistroSalud.Size = new System.Drawing.Size(495, 555);
            this.panelRegistroSalud.TabIndex = 1;
            // 
            // lblSeccionSalud
            // 
            this.lblSeccionSalud.AutoSize = true;
            this.lblSeccionSalud.Font = Tema.FuenteLabelCampo;
            this.lblSeccionSalud.ForeColor = Tema.AzulPrimario;
            this.lblSeccionSalud.Location = new System.Drawing.Point(20, 18);
            this.lblSeccionSalud.Name = "lblSeccionSalud";
            this.lblSeccionSalud.Size = new System.Drawing.Size(159, 25);
            this.lblSeccionSalud.TabIndex = 0;
            this.lblSeccionSalud.Text = "Registro de salud";
            // 
            // lblMensajeSalud
            // 
            this.lblMensajeSalud.Font = Tema.FuenteAyuda;
            this.lblMensajeSalud.ForeColor = Tema.TextoSecundario;
            this.lblMensajeSalud.Location = new System.Drawing.Point(20, 55);
            this.lblMensajeSalud.Name = "lblMensajeSalud";
            this.lblMensajeSalud.Size = new System.Drawing.Size(450, 55);
            this.lblMensajeSalud.TabIndex = 1;
            this.lblMensajeSalud.Text = "Agregue información médica importante del paciente. Estos datos son opcionales y " +
    "pueden completarse o actualizarse posteriormente.";
            // 
            // lblContactoEmergencia
            // 
            this.lblContactoEmergencia.AutoSize = true;
            this.lblContactoEmergencia.Font = Tema.FuenteLabelCampo;
            this.lblContactoEmergencia.ForeColor = Tema.TextoPrincipal;
            this.lblContactoEmergencia.Location = new System.Drawing.Point(20, 125);
            this.lblContactoEmergencia.Name = "lblContactoEmergencia";
            this.lblContactoEmergencia.Size = new System.Drawing.Size(143, 15);
            this.lblContactoEmergencia.TabIndex = 2;
            this.lblContactoEmergencia.Text = "Contacto de emergencia";
            // 
            // txtContactoEmergencia
            // 
            this.txtContactoEmergencia.Font = Tema.FuenteCuerpo;
            this.txtContactoEmergencia.Location = new System.Drawing.Point(20, 145);
            this.txtContactoEmergencia.Name = "txtContactoEmergencia";
            this.txtContactoEmergencia.Size = new System.Drawing.Size(450, 25);
            this.txtContactoEmergencia.TabIndex = 20;
            // 
            // lblTipoSangre
            // 
            this.lblTipoSangre.AutoSize = true;
            this.lblTipoSangre.Font = Tema.FuenteLabelCampo;
            this.lblTipoSangre.ForeColor = Tema.TextoPrincipal;
            this.lblTipoSangre.Location = new System.Drawing.Point(20, 185);
            this.lblTipoSangre.Name = "lblTipoSangre";
            this.lblTipoSangre.Size = new System.Drawing.Size(88, 15);
            this.lblTipoSangre.TabIndex = 3;
            this.lblTipoSangre.Text = "Tipo de sangre";
            // 
            // cmbTipoSangre
            // 
            this.cmbTipoSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSangre.Font = Tema.FuenteCuerpo;
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
            this.cmbTipoSangre.Location = new System.Drawing.Point(20, 205);
            this.cmbTipoSangre.Name = "cmbTipoSangre";
            this.cmbTipoSangre.Size = new System.Drawing.Size(210, 25);
            this.cmbTipoSangre.TabIndex = 21;
            // 
            // lblAlergias
            // 
            this.lblAlergias.AutoSize = true;
            this.lblAlergias.Font = Tema.FuenteLabelCampo;
            this.lblAlergias.ForeColor = Tema.TextoPrincipal;
            this.lblAlergias.Location = new System.Drawing.Point(20, 245);
            this.lblAlergias.Name = "lblAlergias";
            this.lblAlergias.Size = new System.Drawing.Size(51, 15);
            this.lblAlergias.TabIndex = 4;
            this.lblAlergias.Text = "Alergias";
            // 
            // txtAlergias
            // 
            this.txtAlergias.Font = Tema.FuenteCuerpo;
            this.txtAlergias.Location = new System.Drawing.Point(20, 265);
            this.txtAlergias.Multiline = true;
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlergias.Size = new System.Drawing.Size(450, 65);
            this.txtAlergias.TabIndex = 22;
            // 
            // lblAntecedentes
            // 
            this.lblAntecedentes.AutoSize = true;
            this.lblAntecedentes.Font = Tema.FuenteLabelCampo;
            this.lblAntecedentes.ForeColor = Tema.TextoPrincipal;
            this.lblAntecedentes.Location = new System.Drawing.Point(20, 350);
            this.lblAntecedentes.Name = "lblAntecedentes";
            this.lblAntecedentes.Size = new System.Drawing.Size(85, 15);
            this.lblAntecedentes.TabIndex = 5;
            this.lblAntecedentes.Text = "Antecedentes";
            // 
            // txtAntecedentes
            // 
            this.txtAntecedentes.Font = Tema.FuenteCuerpo;
            this.txtAntecedentes.Location = new System.Drawing.Point(20, 370);
            this.txtAntecedentes.Multiline = true;
            this.txtAntecedentes.Name = "txtAntecedentes";
            this.txtAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntecedentes.Size = new System.Drawing.Size(450, 100);
            this.txtAntecedentes.TabIndex = 23;
            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor = Tema.VerdeAcento;
            this.panelLineaVerde.Location = new System.Drawing.Point(30, 20);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(6, 45);
            this.panelLineaVerde.TabIndex = 2;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteCuerpo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(45, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(188, 17);
            this.lblSubtitulo.TabIndex = 24;
            this.lblSubtitulo.Text = "Registro de Datos del Paciente";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(42, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 32);
            this.lblTitulo.TabIndex = 25;
            this.lblTitulo.Text = "SANAR RURAL";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteLabelCampo;
            this.btnGuardar.ForeColor = Tema.Superficie;
            this.btnGuardar.Location = new System.Drawing.Point(30, 660);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(1010, 38);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar Paciente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lnkVolver
            // 
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = Tema.FuenteCuerpo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(450, 700);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(171, 17);
            this.lnkVolver.TabIndex = 27;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "Completar después / Volver";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            // 
            // crearPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(950, 760);
            this.Controls.Add(this.panelCard);
            this.MinimumSize = new System.Drawing.Size(820, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "crearPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Registro de Paciente";
            this.Load += new System.EventHandler(this.crearPaciente_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelDatosPersonales.ResumeLayout(false);
            this.panelDatosPersonales.PerformLayout();
            this.panelRegistroSalud.ResumeLayout(false);
            this.panelRegistroSalud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        // ============================================================
        // CONTROLES PRINCIPALES
        // ============================================================

        private System.Windows.Forms.Panel panelCard;

        private System.Windows.Forms.Panel panelDatosPersonales;

        private System.Windows.Forms.Panel panelRegistroSalud;

        private System.Windows.Forms.Panel panelLineaVerde;

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblSubtitulo;


        // ============================================================
        // DATOS PERSONALES
        // ============================================================

        private System.Windows.Forms.Label lblSeccionPersonal;

        private System.Windows.Forms.Label lblNombres;

        private System.Windows.Forms.TextBox txtNombres;

        private System.Windows.Forms.Label lblErrorNombres;

        private System.Windows.Forms.Label lblApellidos;

        private System.Windows.Forms.TextBox txtApellidos;

        private System.Windows.Forms.Label lblFechaNacimiento;

        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;

        private System.Windows.Forms.Label lblGenero;

        private System.Windows.Forms.ComboBox cmbGenero;

        private System.Windows.Forms.Label lblTelefono;

        private System.Windows.Forms.TextBox txtTelefono;

        private System.Windows.Forms.Label lblErrorTelefono;


        // ============================================================
        // UBICACION
        // ============================================================

        private System.Windows.Forms.Label lblUbicacion;

        private System.Windows.Forms.Label lblDepartamento;

        private System.Windows.Forms.TextBox txtDepartamento;

        private System.Windows.Forms.Label lblMunicipio;

        private System.Windows.Forms.TextBox txtMunicipio;

        private System.Windows.Forms.Label lblComunidad;

        private System.Windows.Forms.TextBox txtComunidad;

        private System.Windows.Forms.Label lblDireccion;

        private System.Windows.Forms.TextBox txtDireccion;


        // ============================================================
        // REGISTRO DE SALUD
        // ============================================================

        private System.Windows.Forms.Label lblSeccionSalud;

        private System.Windows.Forms.Label lblMensajeSalud;

        private System.Windows.Forms.Label lblContactoEmergencia;

        private System.Windows.Forms.TextBox txtContactoEmergencia;

        private System.Windows.Forms.Label lblTipoSangre;

        private System.Windows.Forms.ComboBox cmbTipoSangre;

        private System.Windows.Forms.Label lblAlergias;

        private System.Windows.Forms.TextBox txtAlergias;

        private System.Windows.Forms.Label lblAntecedentes;

        private System.Windows.Forms.TextBox txtAntecedentes;


        // ============================================================
        // BOTONES
        // ============================================================

        private System.Windows.Forms.Button btnGuardar;

        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}
