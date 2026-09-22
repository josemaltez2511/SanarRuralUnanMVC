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

            // ============================================================
            // PANEL CARD PRINCIPAL
            // ============================================================

            this.panelCard.BackColor = System.Drawing.Color.White;

            this.panelCard.AutoScroll = true;
            this.panelCard.HorizontalScroll.Enabled = true;
            this.panelCard.HorizontalScroll.Visible = true;
            this.panelCard.VerticalScroll.Enabled = true;
            this.panelCard.VerticalScroll.Visible = true;

            this.panelCard.Controls.Add(this.panelDatosPersonales);
            this.panelCard.Controls.Add(this.panelRegistroSalud);
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);

            this.panelCard.Location =
                new System.Drawing.Point(40, 25);

            this.panelCard.Name =
                "panelCard";

            this.panelCard.Size =
                new System.Drawing.Size(1070, 720);

            this.panelCard.TabIndex = 0;

            this.panelCard.Paint +=
                new System.Windows.Forms.PaintEventHandler(
                    this.panelCard_Paint
                );


            // ============================================================
            // PANEL DATOS PERSONALES
            // ============================================================

            this.panelDatosPersonales.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            this.panelDatosPersonales.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelDatosPersonales.Controls.Add(
                this.lblSeccionPersonal
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblUbicacion
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblNombres
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtNombres
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblErrorNombres
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblApellidos
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtApellidos
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblFechaNacimiento
            );

            this.panelDatosPersonales.Controls.Add(
                this.dtpFechaNacimiento
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblGenero
            );

            this.panelDatosPersonales.Controls.Add(
                this.cmbGenero
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblTelefono
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtTelefono
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblErrorTelefono
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblDepartamento
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtDepartamento
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblMunicipio
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtMunicipio
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblComunidad
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtComunidad
            );

            this.panelDatosPersonales.Controls.Add(
                this.lblDireccion
            );

            this.panelDatosPersonales.Controls.Add(
                this.txtDireccion
            );

            this.panelDatosPersonales.Location =
                new System.Drawing.Point(30, 90);

            this.panelDatosPersonales.Name =
                "panelDatosPersonales";

            this.panelDatosPersonales.Size =
                new System.Drawing.Size(495, 555);

            this.panelDatosPersonales.TabIndex = 0;


            // ============================================================
            // TITULO DATOS PERSONALES
            // ============================================================

            this.lblSeccionPersonal.AutoSize = true;

            this.lblSeccionPersonal.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblSeccionPersonal.ForeColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.lblSeccionPersonal.Location =
                new System.Drawing.Point(20, 18);

            this.lblSeccionPersonal.Name =
                "lblSeccionPersonal";

            this.lblSeccionPersonal.Size =
                new System.Drawing.Size(142, 25);

            this.lblSeccionPersonal.TabIndex = 0;

            this.lblSeccionPersonal.Text =
                "Datos personales";


            // ============================================================
            // NOMBRES
            // ============================================================

            this.lblNombres.AutoSize = true;

            this.lblNombres.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblNombres.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblNombres.Location =
                new System.Drawing.Point(20, 58);

            this.lblNombres.Name =
                "lblNombres";

            this.lblNombres.Size =
                new System.Drawing.Size(59, 15);

            this.lblNombres.TabIndex = 1;

            this.lblNombres.Text =
                "Nombres *";


            this.txtNombres.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtNombres.Location =
                new System.Drawing.Point(20, 77);

            this.txtNombres.Name =
                "txtNombres";

            this.txtNombres.Size =
                new System.Drawing.Size(450, 25);

            this.txtNombres.TabIndex = 2;

            this.txtNombres.TextChanged +=
                new System.EventHandler(
                    this.txtNombres_TextChanged
                );


            this.lblErrorNombres.AutoSize = true;

            this.lblErrorNombres.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8F
                );

            this.lblErrorNombres.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorNombres.Location =
                new System.Drawing.Point(20, 105);

            this.lblErrorNombres.Name =
                "lblErrorNombres";

            this.lblErrorNombres.Size =
                new System.Drawing.Size(0, 13);

            this.lblErrorNombres.Text =
                "";


            // ============================================================
            // APELLIDOS
            // ============================================================

            this.lblApellidos.AutoSize = true;

            this.lblApellidos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblApellidos.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblApellidos.Location =
                new System.Drawing.Point(20, 125);

            this.lblApellidos.Name =
                "lblApellidos";

            this.lblApellidos.Size =
                new System.Drawing.Size(63, 15);

            this.lblApellidos.TabIndex = 3;

            this.lblApellidos.Text =
                "Apellidos *";


            this.txtApellidos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtApellidos.Location =
                new System.Drawing.Point(20, 144);

            this.txtApellidos.Name =
                "txtApellidos";

            this.txtApellidos.Size =
                new System.Drawing.Size(450, 25);

            this.txtApellidos.TabIndex = 4;


            // ============================================================
            // FECHA DE NACIMIENTO
            // ============================================================

            this.lblFechaNacimiento.AutoSize = true;

            this.lblFechaNacimiento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblFechaNacimiento.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblFechaNacimiento.Location =
                new System.Drawing.Point(20, 185);

            this.lblFechaNacimiento.Name =
                "lblFechaNacimiento";

            this.lblFechaNacimiento.Size =
                new System.Drawing.Size(121, 15);

            this.lblFechaNacimiento.TabIndex = 5;

            this.lblFechaNacimiento.Text =
                "Fecha de nacimiento *";


            this.dtpFechaNacimiento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.dtpFechaNacimiento.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtpFechaNacimiento.Location =
                new System.Drawing.Point(20, 204);

            this.dtpFechaNacimiento.Name =
                "dtpFechaNacimiento";

            this.dtpFechaNacimiento.Size =
                new System.Drawing.Size(215, 25);

            this.dtpFechaNacimiento.TabIndex = 6;


            // ============================================================
            // GENERO
            // ============================================================

            this.lblGenero.AutoSize = true;

            this.lblGenero.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblGenero.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblGenero.Location =
                new System.Drawing.Point(260, 185);

            this.lblGenero.Name =
                "lblGenero";

            this.lblGenero.Size =
                new System.Drawing.Size(46, 15);

            this.lblGenero.TabIndex = 7;

            this.lblGenero.Text =
                "Género";


            this.cmbGenero.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbGenero.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.cmbGenero.FormattingEnabled = true;

            this.cmbGenero.Items.AddRange(
                new object[]
                {
                    "Masculino",
                    "Femenino"
                }
            );

            this.cmbGenero.Location =
                new System.Drawing.Point(260, 204);

            this.cmbGenero.Name =
                "cmbGenero";

            this.cmbGenero.Size =
                new System.Drawing.Size(210, 25);

            this.cmbGenero.TabIndex = 8;


            // ============================================================
            // TELEFONO
            // ============================================================

            this.lblTelefono.AutoSize = true;

            this.lblTelefono.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTelefono.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblTelefono.Location =
                new System.Drawing.Point(20, 245);

            this.lblTelefono.Name =
                "lblTelefono";

            this.lblTelefono.Size =
                new System.Drawing.Size(58, 15);

            this.lblTelefono.TabIndex = 9;

            this.lblTelefono.Text =
                "Teléfono";


            this.txtTelefono.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtTelefono.Location =
                new System.Drawing.Point(20, 264);

            this.txtTelefono.Name =
                "txtTelefono";

            this.txtTelefono.Size =
                new System.Drawing.Size(450, 25);

            this.txtTelefono.TabIndex = 10;

            this.txtTelefono.TextChanged +=
                new System.EventHandler(
                    this.txtTelefono_TextChanged
                );


            this.lblErrorTelefono.AutoSize = true;

            this.lblErrorTelefono.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8F
                );

            this.lblErrorTelefono.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorTelefono.Location =
                new System.Drawing.Point(20, 292);

            this.lblErrorTelefono.Name =
                "lblErrorTelefono";

            this.lblErrorTelefono.Size =
                new System.Drawing.Size(0, 13);

            this.lblErrorTelefono.Text =
                "";


            // ============================================================
            // UBICACION
            // ============================================================

            this.lblUbicacion.AutoSize = true;

            this.lblUbicacion.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblUbicacion.ForeColor =
                System.Drawing.Color.FromArgb(70, 80, 90);

            this.lblUbicacion.Location =
                new System.Drawing.Point(20, 320);

            this.lblUbicacion.Name =
                "lblUbicacion";

            this.lblUbicacion.Size =
                new System.Drawing.Size(72, 19);

            this.lblUbicacion.TabIndex = 11;

            this.lblUbicacion.Text =
                "Ubicación";


            // ============================================================
            // DEPARTAMENTO
            // ============================================================

            this.lblDepartamento.AutoSize = true;

            this.lblDepartamento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblDepartamento.Location =
                new System.Drawing.Point(20, 350);

            this.lblDepartamento.Name =
                "lblDepartamento";

            this.lblDepartamento.Size =
                new System.Drawing.Size(84, 15);

            this.lblDepartamento.TabIndex = 12;

            this.lblDepartamento.Text =
                "Departamento";


            this.txtDepartamento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F
                );

            this.txtDepartamento.Location =
                new System.Drawing.Point(20, 369);

            this.txtDepartamento.Name =
                "txtDepartamento";

            this.txtDepartamento.Size =
                new System.Drawing.Size(210, 24);

            this.txtDepartamento.TabIndex = 13;


            // ============================================================
            // MUNICIPIO
            // ============================================================

            this.lblMunicipio.AutoSize = true;

            this.lblMunicipio.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblMunicipio.Location =
                new System.Drawing.Point(260, 350);

            this.lblMunicipio.Name =
                "lblMunicipio";

            this.lblMunicipio.Size =
                new System.Drawing.Size(63, 15);

            this.lblMunicipio.TabIndex = 14;

            this.lblMunicipio.Text =
                "Municipio";


            this.txtMunicipio.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F
                );

            this.txtMunicipio.Location =
                new System.Drawing.Point(260, 369);

            this.txtMunicipio.Name =
                "txtMunicipio";

            this.txtMunicipio.Size =
                new System.Drawing.Size(210, 24);

            this.txtMunicipio.TabIndex = 15;


            // ============================================================
            // COMUNIDAD
            // ============================================================

            this.lblComunidad.AutoSize = true;

            this.lblComunidad.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblComunidad.Location =
                new System.Drawing.Point(20, 405);

            this.lblComunidad.Name =
                "lblComunidad";

            this.lblComunidad.Size =
                new System.Drawing.Size(70, 15);

            this.lblComunidad.TabIndex = 16;

            this.lblComunidad.Text =
                "Comunidad";


            this.txtComunidad.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F
                );

            this.txtComunidad.Location =
                new System.Drawing.Point(20, 424);

            this.txtComunidad.Name =
                "txtComunidad";

            this.txtComunidad.Size =
                new System.Drawing.Size(210, 24);

            this.txtComunidad.TabIndex = 17;


            // ============================================================
            // DIRECCION
            // ============================================================

            this.lblDireccion.AutoSize = true;

            this.lblDireccion.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblDireccion.Location =
                new System.Drawing.Point(260, 405);

            this.lblDireccion.Name =
                "lblDireccion";

            this.lblDireccion.Size =
                new System.Drawing.Size(58, 15);

            this.lblDireccion.TabIndex = 18;

            this.lblDireccion.Text =
                "Dirección";


            this.txtDireccion.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F
                );

            this.txtDireccion.Location =
                new System.Drawing.Point(260, 424);

            this.txtDireccion.Multiline = true;

            this.txtDireccion.Name =
                "txtDireccion";

            this.txtDireccion.Size =
                new System.Drawing.Size(210, 55);

            this.txtDireccion.TabIndex = 19;


            // ============================================================
            // PANEL REGISTRO DE SALUD
            // ============================================================

            this.panelRegistroSalud.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 252);

            this.panelRegistroSalud.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelRegistroSalud.Controls.Add(
                this.lblSeccionSalud
            );

            this.panelRegistroSalud.Controls.Add(
                this.lblMensajeSalud
            );

            this.panelRegistroSalud.Controls.Add(
                this.lblContactoEmergencia
            );

            this.panelRegistroSalud.Controls.Add(
                this.txtContactoEmergencia
            );

            this.panelRegistroSalud.Controls.Add(
                this.lblTipoSangre
            );

            this.panelRegistroSalud.Controls.Add(
                this.cmbTipoSangre
            );

            this.panelRegistroSalud.Controls.Add(
                this.lblAlergias
            );

            this.panelRegistroSalud.Controls.Add(
                this.txtAlergias
            );

            this.panelRegistroSalud.Controls.Add(
                this.lblAntecedentes
            );

            this.panelRegistroSalud.Controls.Add(
                this.txtAntecedentes
            );

            this.panelRegistroSalud.Location =
                new System.Drawing.Point(545, 90);

            this.panelRegistroSalud.Name =
                "panelRegistroSalud";

            this.panelRegistroSalud.Size =
                new System.Drawing.Size(495, 555);

            this.panelRegistroSalud.TabIndex = 1;


            // ============================================================
            // TITULO REGISTRO DE SALUD
            // ============================================================

            this.lblSeccionSalud.AutoSize = true;

            this.lblSeccionSalud.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblSeccionSalud.ForeColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.lblSeccionSalud.Location =
                new System.Drawing.Point(20, 18);

            this.lblSeccionSalud.Name =
                "lblSeccionSalud";

            this.lblSeccionSalud.Size =
                new System.Drawing.Size(151, 25);

            this.lblSeccionSalud.TabIndex = 0;

            this.lblSeccionSalud.Text =
                "Registro de salud";


            // ============================================================
            // MENSAJE SALUD
            // ============================================================

            this.lblMensajeSalud.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular
                );

            this.lblMensajeSalud.ForeColor =
                System.Drawing.Color.FromArgb(100, 110, 120);

            this.lblMensajeSalud.Location =
                new System.Drawing.Point(20, 55);

            this.lblMensajeSalud.Name =
                "lblMensajeSalud";

            this.lblMensajeSalud.Size =
                new System.Drawing.Size(450, 55);

            this.lblMensajeSalud.TabIndex = 1;

            this.lblMensajeSalud.Text =
                "Agregue información médica importante " +
                "del paciente. Estos datos son opcionales " +
                "y pueden completarse o actualizarse " +
                "posteriormente.";


            // ============================================================
            // CONTACTO DE EMERGENCIA
            // ============================================================

            this.lblContactoEmergencia.AutoSize = true;

            this.lblContactoEmergencia.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblContactoEmergencia.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblContactoEmergencia.Location =
                new System.Drawing.Point(20, 125);

            this.lblContactoEmergencia.Name =
                "lblContactoEmergencia";

            this.lblContactoEmergencia.Size =
                new System.Drawing.Size(153, 15);

            this.lblContactoEmergencia.TabIndex = 2;

            this.lblContactoEmergencia.Text =
                "Contacto de emergencia";


            this.txtContactoEmergencia.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtContactoEmergencia.Location =
                new System.Drawing.Point(20, 145);

            this.txtContactoEmergencia.Name =
                "txtContactoEmergencia";

            this.txtContactoEmergencia.Size =
                new System.Drawing.Size(450, 25);

            this.txtContactoEmergencia.TabIndex = 20;


            // ============================================================
            // TIPO DE SANGRE
            // ============================================================

            this.lblTipoSangre.AutoSize = true;

            this.lblTipoSangre.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTipoSangre.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblTipoSangre.Location =
                new System.Drawing.Point(20, 185);

            this.lblTipoSangre.Name =
                "lblTipoSangre";

            this.lblTipoSangre.Size =
                new System.Drawing.Size(82, 15);

            this.lblTipoSangre.TabIndex = 3;

            this.lblTipoSangre.Text =
                "Tipo de sangre";


            this.cmbTipoSangre.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbTipoSangre.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.cmbTipoSangre.FormattingEnabled = true;

            this.cmbTipoSangre.Items.AddRange(
                new object[]
                {
                    "No especificado",
                    "A+",
                    "A-",
                    "B+",
                    "B-",
                    "AB+",
                    "AB-",
                    "O+",
                    "O-"
                }
            );

            this.cmbTipoSangre.Location =
                new System.Drawing.Point(20, 205);

            this.cmbTipoSangre.Name =
                "cmbTipoSangre";

            this.cmbTipoSangre.Size =
                new System.Drawing.Size(210, 25);

            this.cmbTipoSangre.TabIndex = 21;


            // ============================================================
            // ALERGIAS
            // ============================================================

            this.lblAlergias.AutoSize = true;

            this.lblAlergias.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblAlergias.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblAlergias.Location =
                new System.Drawing.Point(20, 245);

            this.lblAlergias.Name =
                "lblAlergias";

            this.lblAlergias.Size =
                new System.Drawing.Size(52, 15);

            this.lblAlergias.TabIndex = 4;

            this.lblAlergias.Text =
                "Alergias";


            this.txtAlergias.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtAlergias.Location =
                new System.Drawing.Point(20, 265);

            this.txtAlergias.Multiline = true;

            this.txtAlergias.Name =
                "txtAlergias";

            this.txtAlergias.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtAlergias.Size =
                new System.Drawing.Size(450, 65);

            this.txtAlergias.TabIndex = 22;


            // ============================================================
            // ANTECEDENTES
            // ============================================================

            this.lblAntecedentes.AutoSize = true;

            this.lblAntecedentes.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblAntecedentes.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblAntecedentes.Location =
                new System.Drawing.Point(20, 350);

            this.lblAntecedentes.Name =
                "lblAntecedentes";

            this.lblAntecedentes.Size =
                new System.Drawing.Size(81, 15);

            this.lblAntecedentes.TabIndex = 5;

            this.lblAntecedentes.Text =
                "Antecedentes";


            this.txtAntecedentes.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.txtAntecedentes.Location =
                new System.Drawing.Point(20, 370);

            this.txtAntecedentes.Multiline = true;

            this.txtAntecedentes.Name =
                "txtAntecedentes";

            this.txtAntecedentes.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtAntecedentes.Size =
                new System.Drawing.Size(450, 100);

            this.txtAntecedentes.TabIndex = 23;


            // ============================================================
            // LINEA VERDE
            // ============================================================

            this.panelLineaVerde.BackColor =
                System.Drawing.Color.FromArgb(120, 190, 32);

            this.panelLineaVerde.Location =
                new System.Drawing.Point(30, 20);

            this.panelLineaVerde.Name =
                "panelLineaVerde";

            this.panelLineaVerde.Size =
                new System.Drawing.Size(6, 45);

            this.panelLineaVerde.TabIndex = 2;


            // ============================================================
            // SUBTITULO
            // ============================================================

            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Regular
                );

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.FromArgb(100, 110, 120);

            this.lblSubtitulo.Location =
                new System.Drawing.Point(45, 45);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Size =
                new System.Drawing.Size(188, 17);

            this.lblSubtitulo.TabIndex = 24;

            this.lblSubtitulo.Text =
                "Registro de Datos del Paciente";


            // ============================================================
            // TITULO
            // ============================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.lblTitulo.Location =
                new System.Drawing.Point(42, 15);

            this.lblTitulo.Name =
                "lblTitulo";

            this.lblTitulo.Size =
                new System.Drawing.Size(181, 32);

            this.lblTitulo.TabIndex = 25;

            this.lblTitulo.Text =
                "SANAR RURAL";


            // ============================================================
            // BOTON GUARDAR
            // ============================================================

            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.btnGuardar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnGuardar.FlatAppearance.BorderSize = 0;

            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnGuardar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold
                );

            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;

            this.btnGuardar.Location =
                new System.Drawing.Point(30, 660);

            this.btnGuardar.Name =
                "btnGuardar";

            this.btnGuardar.Size =
                new System.Drawing.Size(1010, 38);

            this.btnGuardar.TabIndex = 26;

            this.btnGuardar.Text =
                "Guardar Paciente";

            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnGuardar.Click +=
                new System.EventHandler(
                    this.btnGuardar_Click
                );


            // ============================================================
            // LINK VOLVER
            // ============================================================

            this.lnkVolver.AutoSize = true;

            this.lnkVolver.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F
                );

            this.lnkVolver.LinkColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.lnkVolver.Location =
                new System.Drawing.Point(450, 700);

            this.lnkVolver.Name =
                "lnkVolver";

            this.lnkVolver.Size =
                new System.Drawing.Size(171, 17);

            this.lnkVolver.TabIndex = 27;

            this.lnkVolver.TabStop = true;

            this.lnkVolver.Text =
                "Completar después / Volver";

            this.lnkVolver.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                    this.lnkVolver_LinkClicked
                );


            // ============================================================
            // FORMULARIO
            // ============================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    6F,
                    13F
                );

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    238,
                    243,
                    248
                );

            // IMPORTANTE:
            // El formulario completo tendrá scroll si la pantalla
            // disponible es menor que el contenido.

            this.AutoScroll = true;

            this.AutoScrollMinSize =
                new System.Drawing.Size(
                    1110,
                    770
                );

            this.ClientSize =
                new System.Drawing.Size(
                    1150,
                    790
                );

            this.MinimumSize =
                new System.Drawing.Size(
                    850,
                    600
                );

            this.Controls.Add(
                this.panelCard
            );

            this.Name =
                "crearPaciente";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Sanar Rural - Registro de Paciente";

            this.Load +=
                new System.EventHandler(
                    this.crearPaciente_Load
                );

            this.Resize +=
                new System.EventHandler(
                    this.crearPaciente_Resize
                );

            this.panelRegistroSalud.ResumeLayout(false);
            this.panelRegistroSalud.PerformLayout();

            this.panelDatosPersonales.ResumeLayout(false);
            this.panelDatosPersonales.PerformLayout();

            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();

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