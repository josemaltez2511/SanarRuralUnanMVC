using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class crearPaciente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (picLogoHeader != null && picLogoHeader.Image != null)
                {
                    var img = picLogoHeader.Image;
                    picLogoHeader.Image = null;
                    img.Dispose();
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelFormContenedor = new System.Windows.Forms.Panel();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.picLogoHeader = new System.Windows.Forms.PictureBox();
            this.pnlSeparadorHeader = new System.Windows.Forms.Panel();
            this.lblIconoHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelPasos = new System.Windows.Forms.Panel();
            this.lblPaso1Num = new System.Windows.Forms.Label();
            this.lblPaso1Texto = new System.Windows.Forms.Label();
            this.pnlPasoLinea1 = new System.Windows.Forms.Panel();
            this.lblPaso2Num = new System.Windows.Forms.Label();
            this.lblPaso2Texto = new System.Windows.Forms.Label();
            this.pnlPasoLinea2 = new System.Windows.Forms.Panel();
            this.lblPaso3Num = new System.Windows.Forms.Label();
            this.lblPaso3Texto = new System.Windows.Forms.Label();
            this.cardPersonal = new System.Windows.Forms.Panel();
            this.lblIconoPersonal = new System.Windows.Forms.Label();
            this.lblTituloPersonal = new System.Windows.Forms.Label();
            this.lblSubtituloPersonal = new System.Windows.Forms.Label();
            this.lblPrimerNombre = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblErrorNombres = new System.Windows.Forms.Label();
            this.lblSegundoNombre = new System.Windows.Forms.Label();
            this.txtSegundoNombre = new System.Windows.Forms.TextBox();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
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
            this.cmbPaisTelefono = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.cardUbicacion = new System.Windows.Forms.Panel();
            this.lblIconoUbicacion = new System.Windows.Forms.Label();
            this.lblTituloUbicacion = new System.Windows.Forms.Label();
            this.lblSubtituloUbicacion = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.lblComunidad = new System.Windows.Forms.Label();
            this.cmbComunidad = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.cardSalud = new System.Windows.Forms.Panel();
            this.lblIconoSalud = new System.Windows.Forms.Label();
            this.lblTituloSalud = new System.Windows.Forms.Label();
            this.lblSubtituloSalud = new System.Windows.Forms.Label();
            this.lblTipoSangre = new System.Windows.Forms.Label();
            this.cmbTipoSangre = new System.Windows.Forms.ComboBox();
            this.lblAlergias = new System.Windows.Forms.Label();
            this.pnlAlergiasChips = new System.Windows.Forms.Panel();
            this.flpAlergias = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNuevaAlergia = new System.Windows.Forms.TextBox();
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.lblAntecedentes = new System.Windows.Forms.Label();
            this.pnlCondicionesChips = new System.Windows.Forms.Panel();
            this.flpCondiciones = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNuevaCondicion = new System.Windows.Forms.TextBox();
            this.txtAntecedentes = new System.Windows.Forms.TextBox();
            this.cardEmergencia = new System.Windows.Forms.Panel();
            this.lblIconoEmergencia = new System.Windows.Forms.Label();
            this.lblTituloEmergencia = new System.Windows.Forms.Label();
            this.lblSubtituloEmergencia = new System.Windows.Forms.Label();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.colExpandir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colContEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblSinContactos = new System.Windows.Forms.Label();
            this.pnlEditorContacto = new System.Windows.Forms.Panel();
            this.lblContactoPrimerNombre = new System.Windows.Forms.Label();
            this.txtContactoPrimerNombre = new System.Windows.Forms.TextBox();
            this.lblContactoParentesco = new System.Windows.Forms.Label();
            this.cmbContactoParentesco = new System.Windows.Forms.ComboBox();
            this.lblContactoTelefono = new System.Windows.Forms.Label();
            this.txtContactoTelefono = new System.Windows.Forms.TextBox();
            this.lblContactoCedula = new System.Windows.Forms.Label();
            this.txtContactoCedula = new System.Windows.Forms.TextBox();
            this.btnGuardarContacto = new System.Windows.Forms.Button();
            this.btnCancelarContacto = new System.Windows.Forms.Button();
            this.lblErrorContacto = new System.Windows.Forms.Label();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelFormContenedor.SuspendLayout();
            this.cardHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHeader)).BeginInit();
            this.panelPasos.SuspendLayout();
            this.cardPersonal.SuspendLayout();
            this.cardUbicacion.SuspendLayout();
            this.cardSalud.SuspendLayout();
            this.pnlAlergiasChips.SuspendLayout();
            this.pnlCondicionesChips.SuspendLayout();
            this.cardEmergencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.pnlEditorContacto.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelFormContenedor
            //
            this.panelFormContenedor.AutoScroll = true;
            this.panelFormContenedor.BackColor = Tema.Fondo;
            this.panelFormContenedor.Controls.Add(this.cardHeader);
            this.panelFormContenedor.Controls.Add(this.panelPasos);
            this.panelFormContenedor.Controls.Add(this.cardPersonal);
            this.panelFormContenedor.Controls.Add(this.cardUbicacion);
            this.panelFormContenedor.Controls.Add(this.cardSalud);
            this.panelFormContenedor.Controls.Add(this.cardEmergencia);
            this.panelFormContenedor.Controls.Add(this.panelAcciones);
            this.panelFormContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelFormContenedor.Name = "panelFormContenedor";
            this.panelFormContenedor.Size = new System.Drawing.Size(1260, 800);
            this.panelFormContenedor.TabIndex = 0;
            //
            // cardHeader
            //
            this.cardHeader.BackColor = Tema.Superficie;
            this.cardHeader.Controls.Add(this.picLogoHeader);
            this.cardHeader.Controls.Add(this.pnlSeparadorHeader);
            this.cardHeader.Controls.Add(this.lblIconoHeader);
            this.cardHeader.Controls.Add(this.lblTitulo);
            this.cardHeader.Controls.Add(this.lblSubtitulo);
            this.cardHeader.Location = new System.Drawing.Point(20, 14);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Size = new System.Drawing.Size(1220, 68);
            this.cardHeader.TabIndex = 0;
            //
            // picLogoHeader
            //
            this.picLogoHeader.AccessibleDescription = "Identidad institucional de Sanar Rural";
            this.picLogoHeader.AccessibleName = "Logo Sanar Rural";
            this.picLogoHeader.Location = new System.Drawing.Point(16, 9);
            this.picLogoHeader.Name = "picLogoHeader";
            this.picLogoHeader.Size = new System.Drawing.Size(160, 50);
            this.picLogoHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoHeader.TabIndex = 0;
            this.picLogoHeader.TabStop = false;
            //
            // pnlSeparadorHeader
            //
            this.pnlSeparadorHeader.BackColor = Tema.Borde;
            this.pnlSeparadorHeader.Location = new System.Drawing.Point(190, 13);
            this.pnlSeparadorHeader.Name = "pnlSeparadorHeader";
            this.pnlSeparadorHeader.Size = new System.Drawing.Size(1, 42);
            this.pnlSeparadorHeader.TabIndex = 1;
            //
            // lblIconoHeader
            //
            this.lblIconoHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoHeader.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblIconoHeader.ForeColor = Tema.AzulPrimario;
            this.lblIconoHeader.Location = new System.Drawing.Point(206, 14);
            this.lblIconoHeader.Name = "lblIconoHeader";
            this.lblIconoHeader.Size = new System.Drawing.Size(40, 40);
            this.lblIconoHeader.TabIndex = 2;
            this.lblIconoHeader.Text = "";
            this.lblIconoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 15.5F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblTitulo.Location = new System.Drawing.Point(254, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(185, 30);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Registrar paciente";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(256, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(315, 17);
            this.lblSubtitulo.TabIndex = 4;
            this.lblSubtitulo.Text = "Información personal, ubicación y expediente básico";
            //
            // panelPasos
            //
            this.panelPasos.BackColor = Tema.Fondo;
            this.panelPasos.Controls.Add(this.lblPaso1Num);
            this.panelPasos.Controls.Add(this.lblPaso1Texto);
            this.panelPasos.Controls.Add(this.pnlPasoLinea1);
            this.panelPasos.Controls.Add(this.lblPaso2Num);
            this.panelPasos.Controls.Add(this.lblPaso2Texto);
            this.panelPasos.Controls.Add(this.pnlPasoLinea2);
            this.panelPasos.Controls.Add(this.lblPaso3Num);
            this.panelPasos.Controls.Add(this.lblPaso3Texto);
            this.panelPasos.Location = new System.Drawing.Point(20, 88);
            this.panelPasos.Name = "panelPasos";
            this.panelPasos.Size = new System.Drawing.Size(1220, 38);
            this.panelPasos.TabIndex = 1;
            //
            // lblPaso1Num
            //
            this.lblPaso1Num.BackColor = Tema.AzulPrimario;
            this.lblPaso1Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaso1Num.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblPaso1Num.ForeColor = System.Drawing.Color.White;
            this.lblPaso1Num.Location = new System.Drawing.Point(270, 7);
            this.lblPaso1Num.Name = "lblPaso1Num";
            this.lblPaso1Num.Size = new System.Drawing.Size(24, 24);
            this.lblPaso1Num.TabIndex = 0;
            this.lblPaso1Num.Text = "1";
            this.lblPaso1Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPaso1Texto
            //
            this.lblPaso1Texto.AutoSize = true;
            this.lblPaso1Texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaso1Texto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPaso1Texto.ForeColor = Tema.AzulPrimario;
            this.lblPaso1Texto.Location = new System.Drawing.Point(300, 10);
            this.lblPaso1Texto.Name = "lblPaso1Texto";
            this.lblPaso1Texto.Size = new System.Drawing.Size(125, 17);
            this.lblPaso1Texto.TabIndex = 1;
            this.lblPaso1Texto.Text = "1. Datos personales";
            //
            // pnlPasoLinea1
            //
            this.pnlPasoLinea1.BackColor = Tema.Borde;
            this.pnlPasoLinea1.Location = new System.Drawing.Point(434, 18);
            this.pnlPasoLinea1.Name = "pnlPasoLinea1";
            this.pnlPasoLinea1.Size = new System.Drawing.Size(70, 1);
            this.pnlPasoLinea1.TabIndex = 2;
            //
            // lblPaso2Num
            //
            this.lblPaso2Num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.lblPaso2Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPaso2Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaso2Num.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblPaso2Num.ForeColor = Tema.TextoSecundario;
            this.lblPaso2Num.Location = new System.Drawing.Point(514, 7);
            this.lblPaso2Num.Name = "lblPaso2Num";
            this.lblPaso2Num.Size = new System.Drawing.Size(24, 24);
            this.lblPaso2Num.TabIndex = 3;
            this.lblPaso2Num.Text = "2";
            this.lblPaso2Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPaso2Texto
            //
            this.lblPaso2Texto.AutoSize = true;
            this.lblPaso2Texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaso2Texto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.lblPaso2Texto.ForeColor = Tema.TextoSecundario;
            this.lblPaso2Texto.Location = new System.Drawing.Point(544, 10);
            this.lblPaso2Texto.Name = "lblPaso2Texto";
            this.lblPaso2Texto.Size = new System.Drawing.Size(124, 17);
            this.lblPaso2Texto.TabIndex = 4;
            this.lblPaso2Texto.Text = "2. Ubicación y salud";
            //
            // pnlPasoLinea2
            //
            this.pnlPasoLinea2.BackColor = Tema.Borde;
            this.pnlPasoLinea2.Location = new System.Drawing.Point(678, 18);
            this.pnlPasoLinea2.Name = "pnlPasoLinea2";
            this.pnlPasoLinea2.Size = new System.Drawing.Size(70, 1);
            this.pnlPasoLinea2.TabIndex = 5;
            //
            // lblPaso3Num
            //
            this.lblPaso3Num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.lblPaso3Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPaso3Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaso3Num.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblPaso3Num.ForeColor = Tema.TextoSecundario;
            this.lblPaso3Num.Location = new System.Drawing.Point(758, 7);
            this.lblPaso3Num.Name = "lblPaso3Num";
            this.lblPaso3Num.Size = new System.Drawing.Size(24, 24);
            this.lblPaso3Num.TabIndex = 6;
            this.lblPaso3Num.Text = "3";
            this.lblPaso3Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPaso3Texto
            //
            this.lblPaso3Texto.AutoSize = true;
            this.lblPaso3Texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaso3Texto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.lblPaso3Texto.ForeColor = Tema.TextoSecundario;
            this.lblPaso3Texto.Location = new System.Drawing.Point(788, 10);
            this.lblPaso3Texto.Name = "lblPaso3Texto";
            this.lblPaso3Texto.Size = new System.Drawing.Size(175, 17);
            this.lblPaso3Texto.TabIndex = 7;
            this.lblPaso3Texto.Text = "3. Contactos de emergencia";
            //
            // cardPersonal
            //
            this.cardPersonal.BackColor = Tema.Superficie;
            this.cardPersonal.Controls.Add(this.lblIconoPersonal);
            this.cardPersonal.Controls.Add(this.lblTituloPersonal);
            this.cardPersonal.Controls.Add(this.lblSubtituloPersonal);
            this.cardPersonal.Controls.Add(this.lblPrimerNombre);
            this.cardPersonal.Controls.Add(this.txtNombres);
            this.cardPersonal.Controls.Add(this.lblErrorNombres);
            this.cardPersonal.Controls.Add(this.lblSegundoNombre);
            this.cardPersonal.Controls.Add(this.txtSegundoNombre);
            this.cardPersonal.Controls.Add(this.lblPrimerApellido);
            this.cardPersonal.Controls.Add(this.txtApellidos);
            this.cardPersonal.Controls.Add(this.lblSegundoApellido);
            this.cardPersonal.Controls.Add(this.txtSegundoApellido);
            this.cardPersonal.Controls.Add(this.lblCedula);
            this.cardPersonal.Controls.Add(this.txtCedula);
            this.cardPersonal.Controls.Add(this.lblNumeroINSS);
            this.cardPersonal.Controls.Add(this.txtNumeroINSS);
            this.cardPersonal.Controls.Add(this.lblFechaNacimiento);
            this.cardPersonal.Controls.Add(this.dtpFechaNacimiento);
            this.cardPersonal.Controls.Add(this.lblGenero);
            this.cardPersonal.Controls.Add(this.cmbGenero);
            this.cardPersonal.Controls.Add(this.lblTelefono);
            this.cardPersonal.Controls.Add(this.cmbPaisTelefono);
            this.cardPersonal.Controls.Add(this.txtTelefono);
            this.cardPersonal.Controls.Add(this.lblErrorTelefono);
            this.cardPersonal.Controls.Add(this.lblCorreo);
            this.cardPersonal.Controls.Add(this.txtCorreo);
            this.cardPersonal.Location = new System.Drawing.Point(20, 134);
            this.cardPersonal.Name = "cardPersonal";
            this.cardPersonal.Size = new System.Drawing.Size(1220, 176);
            this.cardPersonal.TabIndex = 2;
            //
            // lblIconoPersonal
            //
            this.lblIconoPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            this.lblIconoPersonal.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoPersonal.ForeColor = Tema.VerdeOscuro;
            this.lblIconoPersonal.Location = new System.Drawing.Point(14, 10);
            this.lblIconoPersonal.Name = "lblIconoPersonal";
            this.lblIconoPersonal.Size = new System.Drawing.Size(32, 32);
            this.lblIconoPersonal.TabIndex = 0;
            this.lblIconoPersonal.Text = "";
            this.lblIconoPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloPersonal
            //
            this.lblTituloPersonal.AutoSize = true;
            this.lblTituloPersonal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloPersonal.ForeColor = Tema.AzulOscuro;
            this.lblTituloPersonal.Location = new System.Drawing.Point(52, 9);
            this.lblTituloPersonal.Name = "lblTituloPersonal";
            this.lblTituloPersonal.Size = new System.Drawing.Size(133, 21);
            this.lblTituloPersonal.TabIndex = 1;
            this.lblTituloPersonal.Text = "Datos personales";
            //
            // lblSubtituloPersonal
            //
            this.lblSubtituloPersonal.AutoSize = true;
            this.lblSubtituloPersonal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloPersonal.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloPersonal.Location = new System.Drawing.Point(54, 30);
            this.lblSubtituloPersonal.Name = "lblSubtituloPersonal";
            this.lblSubtituloPersonal.Size = new System.Drawing.Size(175, 15);
            this.lblSubtituloPersonal.TabIndex = 2;
            this.lblSubtituloPersonal.Text = "Información básica del paciente.";
            //
            // lblPrimerNombre
            //
            this.lblPrimerNombre.AutoSize = true;
            this.lblPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerNombre.Location = new System.Drawing.Point(16, 52);
            this.lblPrimerNombre.Name = "lblPrimerNombre";
            this.lblPrimerNombre.Size = new System.Drawing.Size(107, 15);
            this.lblPrimerNombre.TabIndex = 3;
            this.lblPrimerNombre.Text = "Primer nombre *";
            //
            // txtNombres
            //
            this.txtNombres.Font = Tema.FuenteInput;
            this.txtNombres.Location = new System.Drawing.Point(16, 70);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(220, 27);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            //
            // lblErrorNombres
            //
            this.lblErrorNombres.AutoSize = true;
            this.lblErrorNombres.Font = Tema.FuenteAyuda;
            this.lblErrorNombres.ForeColor = Tema.Error;
            this.lblErrorNombres.Location = new System.Drawing.Point(16, 99);
            this.lblErrorNombres.Name = "lblErrorNombres";
            this.lblErrorNombres.Size = new System.Drawing.Size(0, 13);
            this.lblErrorNombres.TabIndex = 5;
            //
            // lblSegundoNombre
            //
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Font = Tema.FuenteLabelCampo;
            this.lblSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoNombre.Location = new System.Drawing.Point(250, 52);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(103, 15);
            this.lblSegundoNombre.TabIndex = 6;
            this.lblSegundoNombre.Text = "Segundo nombre";
            //
            // txtSegundoNombre
            //
            this.txtSegundoNombre.Font = Tema.FuenteInput;
            this.txtSegundoNombre.Location = new System.Drawing.Point(250, 70);
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(220, 27);
            this.txtSegundoNombre.TabIndex = 7;
            //
            // lblPrimerApellido
            //
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = Tema.FuenteLabelCampo;
            this.lblPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerApellido.Location = new System.Drawing.Point(484, 52);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(108, 15);
            this.lblPrimerApellido.TabIndex = 8;
            this.lblPrimerApellido.Text = "Primer apellido *";
            //
            // txtApellidos
            //
            this.txtApellidos.Font = Tema.FuenteInput;
            this.txtApellidos.Location = new System.Drawing.Point(484, 70);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(220, 27);
            this.txtApellidos.TabIndex = 9;
            //
            // lblSegundoApellido
            //
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = Tema.FuenteLabelCampo;
            this.lblSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoApellido.Location = new System.Drawing.Point(718, 52);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(104, 15);
            this.lblSegundoApellido.TabIndex = 10;
            this.lblSegundoApellido.Text = "Segundo apellido";
            //
            // txtSegundoApellido
            //
            this.txtSegundoApellido.Font = Tema.FuenteInput;
            this.txtSegundoApellido.Location = new System.Drawing.Point(718, 70);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(220, 27);
            this.txtSegundoApellido.TabIndex = 11;
            //
            // lblCedula
            //
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = Tema.FuenteLabelCampo;
            this.lblCedula.ForeColor = Tema.TextoPrincipal;
            this.lblCedula.Location = new System.Drawing.Point(952, 52);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(56, 15);
            this.lblCedula.TabIndex = 12;
            this.lblCedula.Text = "Cédula *";
            //
            // txtCedula
            //
            this.txtCedula.Font = Tema.FuenteInput;
            this.txtCedula.Location = new System.Drawing.Point(952, 70);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(250, 27);
            this.txtCedula.TabIndex = 13;
            //
            // lblNumeroINSS
            //
            this.lblNumeroINSS.AutoSize = true;
            this.lblNumeroINSS.Font = Tema.FuenteLabelCampo;
            this.lblNumeroINSS.ForeColor = Tema.TextoPrincipal;
            this.lblNumeroINSS.Location = new System.Drawing.Point(16, 108);
            this.lblNumeroINSS.Name = "lblNumeroINSS";
            this.lblNumeroINSS.Size = new System.Drawing.Size(139, 15);
            this.lblNumeroINSS.TabIndex = 14;
            this.lblNumeroINSS.Text = "Número INSS (opcional)";
            //
            // txtNumeroINSS
            //
            this.txtNumeroINSS.Font = Tema.FuenteInput;
            this.txtNumeroINSS.Location = new System.Drawing.Point(16, 126);
            this.txtNumeroINSS.Name = "txtNumeroINSS";
            this.txtNumeroINSS.Size = new System.Drawing.Size(220, 27);
            this.txtNumeroINSS.TabIndex = 15;
            //
            // lblFechaNacimiento
            //
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = Tema.FuenteLabelCampo;
            this.lblFechaNacimiento.ForeColor = Tema.TextoPrincipal;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(250, 108);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(134, 15);
            this.lblFechaNacimiento.TabIndex = 16;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento *";
            //
            // dtpFechaNacimiento
            //
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Font = Tema.FuenteInput;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(250, 126);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(220, 27);
            this.dtpFechaNacimiento.TabIndex = 17;
            //
            // lblGenero
            //
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = Tema.FuenteLabelCampo;
            this.lblGenero.ForeColor = Tema.TextoPrincipal;
            this.lblGenero.Location = new System.Drawing.Point(484, 108);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(58, 15);
            this.lblGenero.TabIndex = 18;
            this.lblGenero.Text = "Género *";
            //
            // cmbGenero
            //
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = Tema.FuenteInput;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino",
            "Otro",
            "Prefiere no indicar"});
            this.cmbGenero.Location = new System.Drawing.Point(484, 126);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(220, 27);
            this.cmbGenero.TabIndex = 19;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(718, 108);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 15);
            this.lblTelefono.TabIndex = 20;
            this.lblTelefono.Text = "Teléfono *";
            //
            // cmbPaisTelefono
            //
            this.cmbPaisTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaisTelefono.Font = Tema.FuenteInput;
            this.cmbPaisTelefono.FormattingEnabled = true;
            this.cmbPaisTelefono.Location = new System.Drawing.Point(718, 126);
            this.cmbPaisTelefono.Name = "cmbPaisTelefono";
            this.cmbPaisTelefono.Size = new System.Drawing.Size(85, 27);
            this.cmbPaisTelefono.TabIndex = 21;
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(807, 126);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(131, 27);
            this.txtTelefono.TabIndex = 22;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            //
            // lblErrorTelefono
            //
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.Font = Tema.FuenteAyuda;
            this.lblErrorTelefono.ForeColor = Tema.Error;
            this.lblErrorTelefono.Location = new System.Drawing.Point(718, 155);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(0, 13);
            this.lblErrorTelefono.TabIndex = 23;
            //
            // lblCorreo
            //
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(952, 108);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(176, 15);
            this.lblCorreo.TabIndex = 24;
            this.lblCorreo.Text = "Correo electrónico (opcional)";
            //
            // txtCorreo
            //
            this.txtCorreo.Font = Tema.FuenteInput;
            this.txtCorreo.Location = new System.Drawing.Point(952, 126);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(250, 27);
            this.txtCorreo.TabIndex = 25;
            //
            // cardUbicacion
            //
            this.cardUbicacion.BackColor = Tema.Superficie;
            this.cardUbicacion.Controls.Add(this.lblIconoUbicacion);
            this.cardUbicacion.Controls.Add(this.lblTituloUbicacion);
            this.cardUbicacion.Controls.Add(this.lblSubtituloUbicacion);
            this.cardUbicacion.Controls.Add(this.lblDepartamento);
            this.cardUbicacion.Controls.Add(this.cmbDepartamento);
            this.cardUbicacion.Controls.Add(this.lblMunicipio);
            this.cardUbicacion.Controls.Add(this.cmbMunicipio);
            this.cardUbicacion.Controls.Add(this.lblComunidad);
            this.cardUbicacion.Controls.Add(this.cmbComunidad);
            this.cardUbicacion.Controls.Add(this.lblDireccion);
            this.cardUbicacion.Controls.Add(this.txtDireccion);
            this.cardUbicacion.Controls.Add(this.lblReferencia);
            this.cardUbicacion.Controls.Add(this.txtReferencia);
            this.cardUbicacion.Location = new System.Drawing.Point(20, 324);
            this.cardUbicacion.Name = "cardUbicacion";
            this.cardUbicacion.Size = new System.Drawing.Size(1220, 205);
            this.cardUbicacion.TabIndex = 3;
            //
            // lblIconoUbicacion
            //
            this.lblIconoUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoUbicacion.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoUbicacion.ForeColor = Tema.AzulPrimario;
            this.lblIconoUbicacion.Location = new System.Drawing.Point(14, 10);
            this.lblIconoUbicacion.Name = "lblIconoUbicacion";
            this.lblIconoUbicacion.Size = new System.Drawing.Size(32, 32);
            this.lblIconoUbicacion.TabIndex = 0;
            this.lblIconoUbicacion.Text = "";
            this.lblIconoUbicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloUbicacion
            //
            this.lblTituloUbicacion.AutoSize = true;
            this.lblTituloUbicacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloUbicacion.ForeColor = Tema.AzulOscuro;
            this.lblTituloUbicacion.Location = new System.Drawing.Point(52, 9);
            this.lblTituloUbicacion.Name = "lblTituloUbicacion";
            this.lblTituloUbicacion.Size = new System.Drawing.Size(173, 21);
            this.lblTituloUbicacion.TabIndex = 1;
            this.lblTituloUbicacion.Text = "Ubicación y dirección";
            //
            // lblSubtituloUbicacion
            //
            this.lblSubtituloUbicacion.AutoSize = true;
            this.lblSubtituloUbicacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloUbicacion.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloUbicacion.Location = new System.Drawing.Point(54, 30);
            this.lblSubtituloUbicacion.Name = "lblSubtituloUbicacion";
            this.lblSubtituloUbicacion.Size = new System.Drawing.Size(183, 15);
            this.lblSubtituloUbicacion.TabIndex = 2;
            this.lblSubtituloUbicacion.Text = "Datos de residencia del paciente.";
            //
            // lblDepartamento
            //
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = Tema.FuenteLabelCampo;
            this.lblDepartamento.ForeColor = Tema.TextoPrincipal;
            this.lblDepartamento.Location = new System.Drawing.Point(16, 52);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(96, 15);
            this.lblDepartamento.TabIndex = 3;
            this.lblDepartamento.Text = "Departamento *";
            //
            // cmbDepartamento
            //
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = Tema.FuenteInput;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(16, 70);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(380, 27);
            this.cmbDepartamento.TabIndex = 4;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            //
            // lblMunicipio
            //
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = Tema.FuenteLabelCampo;
            this.lblMunicipio.ForeColor = Tema.TextoPrincipal;
            this.lblMunicipio.Location = new System.Drawing.Point(414, 52);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(70, 15);
            this.lblMunicipio.TabIndex = 5;
            this.lblMunicipio.Text = "Municipio *";
            //
            // cmbMunicipio
            //
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Font = Tema.FuenteInput;
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(414, 70);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(380, 27);
            this.cmbMunicipio.TabIndex = 6;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            //
            // lblComunidad
            //
            this.lblComunidad.AutoSize = true;
            this.lblComunidad.Font = Tema.FuenteLabelCampo;
            this.lblComunidad.ForeColor = Tema.TextoPrincipal;
            this.lblComunidad.Location = new System.Drawing.Point(812, 52);
            this.lblComunidad.Name = "lblComunidad";
            this.lblComunidad.Size = new System.Drawing.Size(81, 15);
            this.lblComunidad.TabIndex = 7;
            this.lblComunidad.Text = "Comunidad *";
            //
            // cmbComunidad
            //
            this.cmbComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComunidad.Font = Tema.FuenteInput;
            this.cmbComunidad.FormattingEnabled = true;
            this.cmbComunidad.Location = new System.Drawing.Point(812, 70);
            this.cmbComunidad.Name = "cmbComunidad";
            this.cmbComunidad.Size = new System.Drawing.Size(390, 27);
            this.cmbComunidad.TabIndex = 8;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = Tema.FuenteLabelCampo;
            this.lblDireccion.ForeColor = Tema.TextoPrincipal;
            this.lblDireccion.Location = new System.Drawing.Point(16, 108);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(107, 15);
            this.lblDireccion.TabIndex = 9;
            this.lblDireccion.Text = "Dirección exacta *";
            //
            // txtDireccion
            //
            this.txtDireccion.Font = Tema.FuenteInput;
            this.txtDireccion.Location = new System.Drawing.Point(16, 126);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(585, 58);
            this.txtDireccion.TabIndex = 10;
            //
            // lblReferencia
            //
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = Tema.FuenteLabelCampo;
            this.lblReferencia.ForeColor = Tema.TextoPrincipal;
            this.lblReferencia.Location = new System.Drawing.Point(617, 108);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(117, 15);
            this.lblReferencia.TabIndex = 11;
            this.lblReferencia.Text = "Referencia adicional";
            //
            // txtReferencia
            //
            this.txtReferencia.Font = Tema.FuenteInput;
            this.txtReferencia.Location = new System.Drawing.Point(617, 126);
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferencia.Size = new System.Drawing.Size(585, 58);
            this.txtReferencia.TabIndex = 12;
            //
            // cardSalud
            //
            this.cardSalud.BackColor = Tema.Superficie;
            this.cardSalud.Controls.Add(this.lblIconoSalud);
            this.cardSalud.Controls.Add(this.lblTituloSalud);
            this.cardSalud.Controls.Add(this.lblSubtituloSalud);
            this.cardSalud.Controls.Add(this.lblTipoSangre);
            this.cardSalud.Controls.Add(this.cmbTipoSangre);
            this.cardSalud.Controls.Add(this.lblAlergias);
            this.cardSalud.Controls.Add(this.pnlAlergiasChips);
            this.cardSalud.Controls.Add(this.txtAlergias);
            this.cardSalud.Controls.Add(this.lblAntecedentes);
            this.cardSalud.Controls.Add(this.pnlCondicionesChips);
            this.cardSalud.Controls.Add(this.txtAntecedentes);
            this.cardSalud.Location = new System.Drawing.Point(20, 543);
            this.cardSalud.Name = "cardSalud";
            this.cardSalud.Size = new System.Drawing.Size(1220, 185);
            this.cardSalud.TabIndex = 4;
            //
            // lblIconoSalud
            //
            this.lblIconoSalud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoSalud.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoSalud.ForeColor = Tema.AzulPrimario;
            this.lblIconoSalud.Location = new System.Drawing.Point(14, 10);
            this.lblIconoSalud.Name = "lblIconoSalud";
            this.lblIconoSalud.Size = new System.Drawing.Size(32, 32);
            this.lblIconoSalud.TabIndex = 0;
            this.lblIconoSalud.Text = "";
            this.lblIconoSalud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloSalud
            //
            this.lblTituloSalud.AutoSize = true;
            this.lblTituloSalud.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloSalud.ForeColor = Tema.AzulOscuro;
            this.lblTituloSalud.Location = new System.Drawing.Point(52, 9);
            this.lblTituloSalud.Name = "lblTituloSalud";
            this.lblTituloSalud.Size = new System.Drawing.Size(167, 21);
            this.lblTituloSalud.TabIndex = 1;
            this.lblTituloSalud.Text = "Información de salud";
            //
            // lblSubtituloSalud
            //
            this.lblSubtituloSalud.AutoSize = true;
            this.lblSubtituloSalud.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloSalud.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloSalud.Location = new System.Drawing.Point(54, 30);
            this.lblSubtituloSalud.Name = "lblSubtituloSalud";
            this.lblSubtituloSalud.Size = new System.Drawing.Size(201, 15);
            this.lblSubtituloSalud.TabIndex = 2;
            this.lblSubtituloSalud.Text = "Datos clínicos básicos del paciente.";
            //
            // lblTipoSangre
            //
            this.lblTipoSangre.AutoSize = true;
            this.lblTipoSangre.Font = Tema.FuenteLabelCampo;
            this.lblTipoSangre.ForeColor = Tema.TextoPrincipal;
            this.lblTipoSangre.Location = new System.Drawing.Point(16, 52);
            this.lblTipoSangre.Name = "lblTipoSangre";
            this.lblTipoSangre.Size = new System.Drawing.Size(91, 15);
            this.lblTipoSangre.TabIndex = 3;
            this.lblTipoSangre.Text = "Tipo de sangre";
            //
            // cmbTipoSangre
            //
            this.cmbTipoSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSangre.Font = Tema.FuenteInput;
            this.cmbTipoSangre.FormattingEnabled = true;
            this.cmbTipoSangre.Items.AddRange(new object[] {
            "No especificado",
            "O+",
            "O-",
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-"});
            this.cmbTipoSangre.Location = new System.Drawing.Point(16, 70);
            this.cmbTipoSangre.Name = "cmbTipoSangre";
            this.cmbTipoSangre.Size = new System.Drawing.Size(220, 27);
            this.cmbTipoSangre.TabIndex = 4;
            //
            // lblAlergias
            //
            this.lblAlergias.AutoSize = true;
            this.lblAlergias.Font = Tema.FuenteLabelCampo;
            this.lblAlergias.ForeColor = Tema.TextoPrincipal;
            this.lblAlergias.Location = new System.Drawing.Point(254, 52);
            this.lblAlergias.Name = "lblAlergias";
            this.lblAlergias.Size = new System.Drawing.Size(117, 15);
            this.lblAlergias.TabIndex = 5;
            this.lblAlergias.Text = "Alergias conocidas";
            //
            // pnlAlergiasChips
            //
            this.pnlAlergiasChips.BackColor = Tema.Superficie;
            this.pnlAlergiasChips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlergiasChips.Controls.Add(this.flpAlergias);
            this.pnlAlergiasChips.Location = new System.Drawing.Point(254, 70);
            this.pnlAlergiasChips.Name = "pnlAlergiasChips";
            this.pnlAlergiasChips.Size = new System.Drawing.Size(948, 34);
            this.pnlAlergiasChips.TabIndex = 6;
            //
            // flpAlergias
            //
            this.flpAlergias.AutoScroll = true;
            this.flpAlergias.BackColor = Tema.Superficie;
            this.flpAlergias.Controls.Add(this.txtNuevaAlergia);
            this.flpAlergias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAlergias.Location = new System.Drawing.Point(0, 0);
            this.flpAlergias.Name = "flpAlergias";
            this.flpAlergias.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpAlergias.Size = new System.Drawing.Size(946, 32);
            this.flpAlergias.TabIndex = 0;
            this.flpAlergias.WrapContents = false;
            //
            // txtNuevaAlergia
            //
            this.txtNuevaAlergia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaAlergia.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.txtNuevaAlergia.ForeColor = Tema.TextoPrincipal;
            this.txtNuevaAlergia.Location = new System.Drawing.Point(6, 6);
            this.txtNuevaAlergia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtNuevaAlergia.Name = "txtNuevaAlergia";
            this.txtNuevaAlergia.Size = new System.Drawing.Size(260, 17);
            this.txtNuevaAlergia.TabIndex = 0;
            //
            // txtAlergias
            //
            this.txtAlergias.Location = new System.Drawing.Point(0, 0);
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.Size = new System.Drawing.Size(0, 20);
            this.txtAlergias.TabIndex = 7;
            this.txtAlergias.Visible = false;
            //
            // lblAntecedentes
            //
            this.lblAntecedentes.AutoSize = true;
            this.lblAntecedentes.Font = Tema.FuenteLabelCampo;
            this.lblAntecedentes.ForeColor = Tema.TextoPrincipal;
            this.lblAntecedentes.Location = new System.Drawing.Point(16, 114);
            this.lblAntecedentes.Name = "lblAntecedentes";
            this.lblAntecedentes.Size = new System.Drawing.Size(188, 15);
            this.lblAntecedentes.TabIndex = 8;
            this.lblAntecedentes.Text = "Condiciones de salud relevantes";
            //
            // pnlCondicionesChips
            //
            this.pnlCondicionesChips.BackColor = Tema.Superficie;
            this.pnlCondicionesChips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCondicionesChips.Controls.Add(this.flpCondiciones);
            this.pnlCondicionesChips.Location = new System.Drawing.Point(16, 134);
            this.pnlCondicionesChips.Name = "pnlCondicionesChips";
            this.pnlCondicionesChips.Size = new System.Drawing.Size(1186, 34);
            this.pnlCondicionesChips.TabIndex = 9;
            //
            // flpCondiciones
            //
            this.flpCondiciones.AutoScroll = true;
            this.flpCondiciones.BackColor = Tema.Superficie;
            this.flpCondiciones.Controls.Add(this.txtNuevaCondicion);
            this.flpCondiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCondiciones.Location = new System.Drawing.Point(0, 0);
            this.flpCondiciones.Name = "flpCondiciones";
            this.flpCondiciones.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpCondiciones.Size = new System.Drawing.Size(1184, 32);
            this.flpCondiciones.TabIndex = 0;
            this.flpCondiciones.WrapContents = false;
            //
            // txtNuevaCondicion
            //
            this.txtNuevaCondicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaCondicion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.txtNuevaCondicion.ForeColor = Tema.TextoPrincipal;
            this.txtNuevaCondicion.Location = new System.Drawing.Point(6, 6);
            this.txtNuevaCondicion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtNuevaCondicion.Name = "txtNuevaCondicion";
            this.txtNuevaCondicion.Size = new System.Drawing.Size(280, 17);
            this.txtNuevaCondicion.TabIndex = 0;
            //
            // txtAntecedentes
            //
            this.txtAntecedentes.Location = new System.Drawing.Point(0, 0);
            this.txtAntecedentes.Name = "txtAntecedentes";
            this.txtAntecedentes.Size = new System.Drawing.Size(0, 20);
            this.txtAntecedentes.TabIndex = 10;
            this.txtAntecedentes.Visible = false;
            //
            // cardEmergencia
            //
            this.cardEmergencia.BackColor = Tema.Superficie;
            this.cardEmergencia.Controls.Add(this.lblIconoEmergencia);
            this.cardEmergencia.Controls.Add(this.lblTituloEmergencia);
            this.cardEmergencia.Controls.Add(this.lblSubtituloEmergencia);
            this.cardEmergencia.Controls.Add(this.btnAgregarContacto);
            this.cardEmergencia.Controls.Add(this.dgvContactos);
            this.cardEmergencia.Controls.Add(this.lblSinContactos);
            this.cardEmergencia.Controls.Add(this.pnlEditorContacto);
            this.cardEmergencia.Location = new System.Drawing.Point(20, 742);
            this.cardEmergencia.Name = "cardEmergencia";
            this.cardEmergencia.Size = new System.Drawing.Size(1220, 260);
            this.cardEmergencia.TabIndex = 5;
            //
            // lblIconoEmergencia
            //
            this.lblIconoEmergencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            this.lblIconoEmergencia.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoEmergencia.ForeColor = Tema.VerdeOscuro;
            this.lblIconoEmergencia.Location = new System.Drawing.Point(14, 10);
            this.lblIconoEmergencia.Name = "lblIconoEmergencia";
            this.lblIconoEmergencia.Size = new System.Drawing.Size(32, 32);
            this.lblIconoEmergencia.TabIndex = 0;
            this.lblIconoEmergencia.Text = "";
            this.lblIconoEmergencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloEmergencia
            //
            this.lblTituloEmergencia.AutoSize = true;
            this.lblTituloEmergencia.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloEmergencia.ForeColor = Tema.AzulOscuro;
            this.lblTituloEmergencia.Location = new System.Drawing.Point(52, 9);
            this.lblTituloEmergencia.Name = "lblTituloEmergencia";
            this.lblTituloEmergencia.Size = new System.Drawing.Size(189, 21);
            this.lblTituloEmergencia.TabIndex = 1;
            this.lblTituloEmergencia.Text = "Contactos de emergencia";
            //
            // lblSubtituloEmergencia
            //
            this.lblSubtituloEmergencia.AutoSize = true;
            this.lblSubtituloEmergencia.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloEmergencia.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloEmergencia.Location = new System.Drawing.Point(54, 30);
            this.lblSubtituloEmergencia.Name = "lblSubtituloEmergencia";
            this.lblSubtituloEmergencia.Size = new System.Drawing.Size(235, 15);
            this.lblSubtituloEmergencia.TabIndex = 2;
            this.lblSubtituloEmergencia.Text = "Personas de contacto en caso de emergencia.";
            //
            // btnAgregarContacto
            //
            this.btnAgregarContacto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarContacto.BackColor = Tema.AzulPrimario;
            this.btnAgregarContacto.FlatAppearance.BorderSize = 0;
            this.btnAgregarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContacto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarContacto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarContacto.Location = new System.Drawing.Point(1045, 10);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(155, 32);
            this.btnAgregarContacto.TabIndex = 3;
            this.btnAgregarContacto.Text = "+ Agregar contacto";
            this.btnAgregarContacto.UseVisualStyleBackColor = false;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            //
            // dgvContactos
            //
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.BackgroundColor = Tema.Superficie;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExpandir,
            this.colContNombre,
            this.colContParentesco,
            this.colContTelefono,
            this.colContCedula,
            this.colContEditar,
            this.colContEliminar});
            this.dgvContactos.Location = new System.Drawing.Point(16, 52);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.Size = new System.Drawing.Size(1186, 110);
            this.dgvContactos.TabIndex = 4;
            this.dgvContactos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactos_CellContentClick);
            //
            // colExpandir
            //
            this.colExpandir.HeaderText = "";
            this.colExpandir.Name = "colExpandir";
            this.colExpandir.ReadOnly = true;
            this.colExpandir.Width = 32;
            //
            // colContNombre
            //
            this.colContNombre.HeaderText = "Nombre completo";
            this.colContNombre.Name = "colContNombre";
            this.colContNombre.ReadOnly = true;
            this.colContNombre.Width = 240;
            //
            // colContParentesco
            //
            this.colContParentesco.HeaderText = "Parentesco";
            this.colContParentesco.Name = "colContParentesco";
            this.colContParentesco.ReadOnly = true;
            this.colContParentesco.Width = 140;
            //
            // colContTelefono
            //
            this.colContTelefono.HeaderText = "Teléfono";
            this.colContTelefono.Name = "colContTelefono";
            this.colContTelefono.ReadOnly = true;
            this.colContTelefono.Width = 140;
            //
            // colContCedula
            //
            this.colContCedula.HeaderText = "Cédula";
            this.colContCedula.Name = "colContCedula";
            this.colContCedula.ReadOnly = true;
            this.colContCedula.Width = 160;
            //
            // colContEditar
            //
            this.colContEditar.HeaderText = "Acciones";
            this.colContEditar.Name = "colContEditar";
            this.colContEditar.ReadOnly = true;
            this.colContEditar.Text = "Editar";
            this.colContEditar.UseColumnTextForButtonValue = true;
            this.colContEditar.Width = 85;
            //
            // colContEliminar
            //
            this.colContEliminar.HeaderText = "";
            this.colContEliminar.Name = "colContEliminar";
            this.colContEliminar.ReadOnly = true;
            this.colContEliminar.Text = "Eliminar";
            this.colContEliminar.UseColumnTextForButtonValue = true;
            this.colContEliminar.Width = 85;
            //
            // lblSinContactos
            //
            this.lblSinContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.lblSinContactos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.lblSinContactos.ForeColor = Tema.TextoSecundario;
            this.lblSinContactos.Location = new System.Drawing.Point(16, 52);
            this.lblSinContactos.Name = "lblSinContactos";
            this.lblSinContactos.Size = new System.Drawing.Size(1186, 100);
            this.lblSinContactos.TabIndex = 5;
            this.lblSinContactos.Text = "No hay contactos de emergencia registrados aún.\r\nHaz clic en \'+ Agregar contacto\'" +
    " para registrar personas de contacto.";
            this.lblSinContactos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pnlEditorContacto
            //
            this.pnlEditorContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            this.pnlEditorContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditorContacto.Controls.Add(this.lblContactoPrimerNombre);
            this.pnlEditorContacto.Controls.Add(this.txtContactoPrimerNombre);
            this.pnlEditorContacto.Controls.Add(this.lblContactoParentesco);
            this.pnlEditorContacto.Controls.Add(this.cmbContactoParentesco);
            this.pnlEditorContacto.Controls.Add(this.lblContactoTelefono);
            this.pnlEditorContacto.Controls.Add(this.txtContactoTelefono);
            this.pnlEditorContacto.Controls.Add(this.lblContactoCedula);
            this.pnlEditorContacto.Controls.Add(this.txtContactoCedula);
            this.pnlEditorContacto.Controls.Add(this.btnGuardarContacto);
            this.pnlEditorContacto.Controls.Add(this.btnCancelarContacto);
            this.pnlEditorContacto.Controls.Add(this.lblErrorContacto);
            this.pnlEditorContacto.Location = new System.Drawing.Point(16, 170);
            this.pnlEditorContacto.Name = "pnlEditorContacto";
            this.pnlEditorContacto.Size = new System.Drawing.Size(1186, 76);
            this.pnlEditorContacto.TabIndex = 6;
            this.pnlEditorContacto.Visible = false;
            //
            // lblContactoPrimerNombre
            //
            this.lblContactoPrimerNombre.AutoSize = true;
            this.lblContactoPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblContactoPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblContactoPrimerNombre.Location = new System.Drawing.Point(12, 10);
            this.lblContactoPrimerNombre.Name = "lblContactoPrimerNombre";
            this.lblContactoPrimerNombre.Size = new System.Drawing.Size(117, 15);
            this.lblContactoPrimerNombre.TabIndex = 0;
            this.lblContactoPrimerNombre.Text = "Nombre completo *";
            //
            // txtContactoPrimerNombre
            //
            this.txtContactoPrimerNombre.Font = Tema.FuenteInput;
            this.txtContactoPrimerNombre.Location = new System.Drawing.Point(12, 28);
            this.txtContactoPrimerNombre.Name = "txtContactoPrimerNombre";
            this.txtContactoPrimerNombre.Size = new System.Drawing.Size(210, 27);
            this.txtContactoPrimerNombre.TabIndex = 1;
            //
            // lblContactoParentesco
            //
            this.lblContactoParentesco.AutoSize = true;
            this.lblContactoParentesco.Font = Tema.FuenteLabelCampo;
            this.lblContactoParentesco.ForeColor = Tema.TextoPrincipal;
            this.lblContactoParentesco.Location = new System.Drawing.Point(234, 10);
            this.lblContactoParentesco.Name = "lblContactoParentesco";
            this.lblContactoParentesco.Size = new System.Drawing.Size(76, 15);
            this.lblContactoParentesco.TabIndex = 2;
            this.lblContactoParentesco.Text = "Parentesco *";
            //
            // cmbContactoParentesco
            //
            this.cmbContactoParentesco.Font = Tema.FuenteInput;
            this.cmbContactoParentesco.FormattingEnabled = true;
            this.cmbContactoParentesco.Items.AddRange(new object[] {
            "Madre",
            "Padre",
            "Cónyuge",
            "Hijo/a",
            "Hermano/a",
            "Familiar",
            "Tutor",
            "Amigo/a",
            "Vecino/a",
            "Otro"});
            this.cmbContactoParentesco.Location = new System.Drawing.Point(234, 28);
            this.cmbContactoParentesco.Name = "cmbContactoParentesco";
            this.cmbContactoParentesco.Size = new System.Drawing.Size(160, 27);
            this.cmbContactoParentesco.TabIndex = 3;
            //
            // lblContactoTelefono
            //
            this.lblContactoTelefono.AutoSize = true;
            this.lblContactoTelefono.Font = Tema.FuenteLabelCampo;
            this.lblContactoTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblContactoTelefono.Location = new System.Drawing.Point(406, 10);
            this.lblContactoTelefono.Name = "lblContactoTelefono";
            this.lblContactoTelefono.Size = new System.Drawing.Size(66, 15);
            this.lblContactoTelefono.TabIndex = 4;
            this.lblContactoTelefono.Text = "Teléfono *";
            //
            // txtContactoTelefono
            //
            this.txtContactoTelefono.Font = Tema.FuenteInput;
            this.txtContactoTelefono.Location = new System.Drawing.Point(406, 28);
            this.txtContactoTelefono.Name = "txtContactoTelefono";
            this.txtContactoTelefono.Size = new System.Drawing.Size(160, 27);
            this.txtContactoTelefono.TabIndex = 5;
            //
            // lblContactoCedula
            //
            this.lblContactoCedula.AutoSize = true;
            this.lblContactoCedula.Font = Tema.FuenteLabelCampo;
            this.lblContactoCedula.ForeColor = Tema.TextoPrincipal;
            this.lblContactoCedula.Location = new System.Drawing.Point(578, 10);
            this.lblContactoCedula.Name = "lblContactoCedula";
            this.lblContactoCedula.Size = new System.Drawing.Size(107, 15);
            this.lblContactoCedula.TabIndex = 6;
            this.lblContactoCedula.Text = "Cédula (opcional)";
            //
            // txtContactoCedula
            //
            this.txtContactoCedula.Font = Tema.FuenteInput;
            this.txtContactoCedula.Location = new System.Drawing.Point(578, 28);
            this.txtContactoCedula.Name = "txtContactoCedula";
            this.txtContactoCedula.Size = new System.Drawing.Size(180, 27);
            this.txtContactoCedula.TabIndex = 7;
            //
            // btnGuardarContacto
            //
            this.btnGuardarContacto.BackColor = Tema.AzulPrimario;
            this.btnGuardarContacto.FlatAppearance.BorderSize = 0;
            this.btnGuardarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarContacto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarContacto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarContacto.Location = new System.Drawing.Point(772, 26);
            this.btnGuardarContacto.Name = "btnGuardarContacto";
            this.btnGuardarContacto.Size = new System.Drawing.Size(140, 31);
            this.btnGuardarContacto.TabIndex = 8;
            this.btnGuardarContacto.Text = "Guardar cambios";
            this.btnGuardarContacto.UseVisualStyleBackColor = false;
            //
            // btnCancelarContacto
            //
            this.btnCancelarContacto.BackColor = Tema.Superficie;
            this.btnCancelarContacto.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarContacto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.btnCancelarContacto.ForeColor = Tema.TextoPrincipal;
            this.btnCancelarContacto.Location = new System.Drawing.Point(920, 26);
            this.btnCancelarContacto.Name = "btnCancelarContacto";
            this.btnCancelarContacto.Size = new System.Drawing.Size(95, 31);
            this.btnCancelarContacto.TabIndex = 9;
            this.btnCancelarContacto.Text = "Cancelar";
            this.btnCancelarContacto.UseVisualStyleBackColor = false;
            //
            // lblErrorContacto
            //
            this.lblErrorContacto.AutoSize = true;
            this.lblErrorContacto.Font = Tema.FuenteAyuda;
            this.lblErrorContacto.ForeColor = Tema.Error;
            this.lblErrorContacto.Location = new System.Drawing.Point(12, 58);
            this.lblErrorContacto.Name = "lblErrorContacto";
            this.lblErrorContacto.Size = new System.Drawing.Size(0, 13);
            this.lblErrorContacto.TabIndex = 10;
            //
            // panelAcciones
            //
            this.panelAcciones.Controls.Add(this.btnCancelar);
            this.panelAcciones.Controls.Add(this.btnGuardar);
            this.panelAcciones.Location = new System.Drawing.Point(20, 1010);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(1220, 52);
            this.panelAcciones.TabIndex = 6;
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = Tema.Superficie;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteBoton;
            this.btnCancelar.ForeColor = Tema.TextoPrincipal;
            this.btnCancelar.Location = new System.Drawing.Point(880, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.lnkVolver_LinkClicked);
            //
            // btnGuardar
            //
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(1022, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(190, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar paciente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // crearPaciente
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1260, 800);
            this.Controls.Add(this.panelFormContenedor);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "crearPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Registro de Paciente";
            this.Load += new System.EventHandler(this.crearPaciente_Load);
            this.panelFormContenedor.ResumeLayout(false);
            this.cardHeader.ResumeLayout(false);
            this.cardHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHeader)).EndInit();
            this.panelPasos.ResumeLayout(false);
            this.panelPasos.PerformLayout();
            this.cardPersonal.ResumeLayout(false);
            this.cardPersonal.PerformLayout();
            this.cardUbicacion.ResumeLayout(false);
            this.cardUbicacion.PerformLayout();
            this.cardSalud.ResumeLayout(false);
            this.cardSalud.PerformLayout();
            this.pnlAlergiasChips.ResumeLayout(false);
            this.pnlCondicionesChips.ResumeLayout(false);
            this.cardEmergencia.ResumeLayout(false);
            this.cardEmergencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.pnlEditorContacto.ResumeLayout(false);
            this.pnlEditorContacto.PerformLayout();
            this.panelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormContenedor;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.PictureBox picLogoHeader;
        private System.Windows.Forms.Panel pnlSeparadorHeader;
        private System.Windows.Forms.Label lblIconoHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Panel panelPasos;
        private System.Windows.Forms.Label lblPaso1Num;
        private System.Windows.Forms.Label lblPaso1Texto;
        private System.Windows.Forms.Panel pnlPasoLinea1;
        private System.Windows.Forms.Label lblPaso2Num;
        private System.Windows.Forms.Label lblPaso2Texto;
        private System.Windows.Forms.Panel pnlPasoLinea2;
        private System.Windows.Forms.Label lblPaso3Num;
        private System.Windows.Forms.Label lblPaso3Texto;

        private System.Windows.Forms.Panel cardPersonal;
        private System.Windows.Forms.Label lblIconoPersonal;
        private System.Windows.Forms.Label lblTituloPersonal;
        private System.Windows.Forms.Label lblSubtituloPersonal;
        private System.Windows.Forms.Label lblPrimerNombre;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblErrorNombres;
        private System.Windows.Forms.Label lblSegundoNombre;
        private System.Windows.Forms.TextBox txtSegundoNombre;
        private System.Windows.Forms.Label lblPrimerApellido;
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
        private System.Windows.Forms.ComboBox cmbPaisTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblErrorTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;

        private System.Windows.Forms.Panel cardUbicacion;
        private System.Windows.Forms.Label lblIconoUbicacion;
        private System.Windows.Forms.Label lblTituloUbicacion;
        private System.Windows.Forms.Label lblSubtituloUbicacion;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.Label lblComunidad;
        private System.Windows.Forms.ComboBox cmbComunidad;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;

        private System.Windows.Forms.Panel cardSalud;
        private System.Windows.Forms.Label lblIconoSalud;
        private System.Windows.Forms.Label lblTituloSalud;
        private System.Windows.Forms.Label lblSubtituloSalud;
        private System.Windows.Forms.Label lblTipoSangre;
        private System.Windows.Forms.ComboBox cmbTipoSangre;
        private System.Windows.Forms.Label lblAlergias;
        private System.Windows.Forms.Panel pnlAlergiasChips;
        private System.Windows.Forms.FlowLayoutPanel flpAlergias;
        private System.Windows.Forms.TextBox txtNuevaAlergia;
        private System.Windows.Forms.TextBox txtAlergias;
        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.Panel pnlCondicionesChips;
        private System.Windows.Forms.FlowLayoutPanel flpCondiciones;
        private System.Windows.Forms.TextBox txtNuevaCondicion;
        private System.Windows.Forms.TextBox txtAntecedentes;

        private System.Windows.Forms.Panel cardEmergencia;
        private System.Windows.Forms.Label lblIconoEmergencia;
        private System.Windows.Forms.Label lblTituloEmergencia;
        private System.Windows.Forms.Label lblSubtituloEmergencia;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpandir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContCedula;
        private System.Windows.Forms.DataGridViewButtonColumn colContEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colContEliminar;
        private System.Windows.Forms.Label lblSinContactos;

        private System.Windows.Forms.Panel pnlEditorContacto;
        private System.Windows.Forms.Label lblContactoPrimerNombre;
        private System.Windows.Forms.TextBox txtContactoPrimerNombre;
        private System.Windows.Forms.Label lblContactoParentesco;
        private System.Windows.Forms.ComboBox cmbContactoParentesco;
        private System.Windows.Forms.Label lblContactoTelefono;
        private System.Windows.Forms.TextBox txtContactoTelefono;
        private System.Windows.Forms.Label lblContactoCedula;
        private System.Windows.Forms.TextBox txtContactoCedula;
        private System.Windows.Forms.Button btnGuardarContacto;
        private System.Windows.Forms.Button btnCancelarContacto;
        private System.Windows.Forms.Label lblErrorContacto;

        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
