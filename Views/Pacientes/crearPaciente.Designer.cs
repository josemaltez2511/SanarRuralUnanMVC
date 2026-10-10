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
                if (picPreview != null && picPreview.Image != null)
                {
                    var img = picPreview.Image;
                    picPreview.Image = null;
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
            this.panelHero = new System.Windows.Forms.Panel();
            this.picLogoHero = new System.Windows.Forms.PictureBox();
            this.lblNombreHero = new System.Windows.Forms.Label();
            this.lblSubtituloHero = new System.Windows.Forms.Label();
            this.lblRegistroTituloHero = new System.Windows.Forms.Label();
            this.lblDescripcionHero = new System.Windows.Forms.Label();
            this.panelHeroBloque1 = new System.Windows.Forms.Panel();
            this.lblHeroIcono1 = new System.Windows.Forms.Label();
            this.lblHeroTitulo1 = new System.Windows.Forms.Label();
            this.lblHeroDesc1 = new System.Windows.Forms.Label();
            this.panelHeroBloque2 = new System.Windows.Forms.Panel();
            this.lblHeroIcono2 = new System.Windows.Forms.Label();
            this.lblHeroTitulo2 = new System.Windows.Forms.Label();
            this.lblHeroDesc2 = new System.Windows.Forms.Label();
            this.panelHeroBloque3 = new System.Windows.Forms.Panel();
            this.lblHeroIcono3 = new System.Windows.Forms.Label();
            this.lblHeroTitulo3 = new System.Windows.Forms.Label();
            this.lblHeroDesc3 = new System.Windows.Forms.Label();
            this.panelHeroBloque4 = new System.Windows.Forms.Panel();
            this.lblHeroIcono4 = new System.Windows.Forms.Label();
            this.lblHeroTitulo4 = new System.Windows.Forms.Label();
            this.lblHeroDesc4 = new System.Windows.Forms.Label();
            this.panelLema = new System.Windows.Forms.Panel();
            this.lblLemaComillas = new System.Windows.Forms.Label();
            this.lblLemaTexto = new System.Windows.Forms.Label();
            this.lblLemaComillasCierre = new System.Windows.Forms.Label();
            this.panelFormContenedor = new System.Windows.Forms.Panel();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.lblIconoPaciente = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblBadgeModo = new System.Windows.Forms.Label();
            this.btnModoEditar = new System.Windows.Forms.Label();
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
            this.lblCedulaAyuda = new System.Windows.Forms.Label();
            this.pnlCedulaInfo = new System.Windows.Forms.Panel();
            this.lblCedulaInfo = new System.Windows.Forms.Label();
            this.lblNumeroINSS = new System.Windows.Forms.Label();
            this.txtNumeroINSS = new System.Windows.Forms.TextBox();
            this.lblINSSAyuda = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cmbPaisTelefono = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefonoAyuda = new System.Windows.Forms.Label();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
            this.cardFoto = new System.Windows.Forms.Panel();
            this.lblIconoFoto = new System.Windows.Forms.Label();
            this.lblTituloFoto = new System.Windows.Forms.Label();
            this.lblSubtituloFoto = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblFotoAyuda = new System.Windows.Forms.Label();
            this.pnlFotoInfo = new System.Windows.Forms.Panel();
            this.lblFotoInfo = new System.Windows.Forms.Label();
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
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.lblAlergiasAyuda = new System.Windows.Forms.Label();
            this.lblAntecedentes = new System.Windows.Forms.Label();
            this.txtAntecedentes = new System.Windows.Forms.TextBox();
            this.lblAntecedentesAyuda = new System.Windows.Forms.Label();
            this.cardEmergencia = new System.Windows.Forms.Panel();
            this.lblIconoEmergencia = new System.Windows.Forms.Label();
            this.lblTituloEmergencia = new System.Windows.Forms.Label();
            this.lblSubtituloEmergencia = new System.Windows.Forms.Label();
            this.lblContactoPrimerNombre = new System.Windows.Forms.Label();
            this.txtContactoPrimerNombre = new System.Windows.Forms.TextBox();
            this.txtContactoSegundoNombre = new System.Windows.Forms.TextBox();
            this.lblContactoPrimerApellido = new System.Windows.Forms.Label();
            this.txtContactoPrimerApellido = new System.Windows.Forms.TextBox();
            this.txtContactoSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblContactoParentesco = new System.Windows.Forms.Label();
            this.cmbContactoParentesco = new System.Windows.Forms.ComboBox();
            this.lblContactoTelefono = new System.Windows.Forms.Label();
            this.txtContactoTelefono = new System.Windows.Forms.TextBox();
            this.lblContactoCedula = new System.Windows.Forms.Label();
            this.txtContactoCedula = new System.Windows.Forms.TextBox();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.lblErrorContacto = new System.Windows.Forms.Label();
            this.lblSubtituloListaContactos = new System.Windows.Forms.Label();
            this.lblSinContactos = new System.Windows.Forms.Label();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.colContNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.panelHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).BeginInit();
            this.panelHeroBloque1.SuspendLayout();
            this.panelHeroBloque2.SuspendLayout();
            this.panelHeroBloque3.SuspendLayout();
            this.panelHeroBloque4.SuspendLayout();
            this.panelLema.SuspendLayout();
            this.panelFormContenedor.SuspendLayout();
            this.cardHeader.SuspendLayout();
            this.cardPersonal.SuspendLayout();
            this.pnlCedulaInfo.SuspendLayout();
            this.cardFoto.SuspendLayout();
            this.pnlFotoInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.cardUbicacion.SuspendLayout();
            this.cardSalud.SuspendLayout();
            this.cardEmergencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHero
            //
            this.panelHero.BackColor = Tema.Fondo;
            this.panelHero.Controls.Add(this.picLogoHero);
            this.panelHero.Controls.Add(this.lblNombreHero);
            this.panelHero.Controls.Add(this.lblSubtituloHero);
            this.panelHero.Controls.Add(this.lblRegistroTituloHero);
            this.panelHero.Controls.Add(this.lblDescripcionHero);
            this.panelHero.Controls.Add(this.panelHeroBloque1);
            this.panelHero.Controls.Add(this.panelHeroBloque2);
            this.panelHero.Controls.Add(this.panelHeroBloque3);
            this.panelHero.Controls.Add(this.panelHeroBloque4);
            this.panelHero.Controls.Add(this.panelLema);
            this.panelHero.Location = new System.Drawing.Point(0, 0);
            this.panelHero.Name = "panelHero";
            this.panelHero.Size = new System.Drawing.Size(350, 800);
            this.panelHero.TabIndex = 0;
            //
            // picLogoHero
            //
            this.picLogoHero.AccessibleDescription = "Identidad institucional de Sanar Rural";
            this.picLogoHero.AccessibleName = "Logo Sanar Rural";
            this.picLogoHero.Location = new System.Drawing.Point(28, 20);
            this.picLogoHero.Name = "picLogoHero";
            this.picLogoHero.Size = new System.Drawing.Size(100, 70);
            this.picLogoHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoHero.TabIndex = 0;
            this.picLogoHero.TabStop = false;
            //
            // lblNombreHero
            //
            this.lblNombreHero.AutoSize = true;
            this.lblNombreHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 20F, System.Drawing.FontStyle.Bold);
            this.lblNombreHero.ForeColor = Tema.AzulOscuro;
            this.lblNombreHero.Location = new System.Drawing.Point(26, 96);
            this.lblNombreHero.Name = "lblNombreHero";
            this.lblNombreHero.Size = new System.Drawing.Size(206, 37);
            this.lblNombreHero.TabIndex = 1;
            this.lblNombreHero.Text = "SANAR RURAL";
            //
            // lblSubtituloHero
            //
            this.lblSubtituloHero.AutoSize = true;
            this.lblSubtituloHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Regular);
            this.lblSubtituloHero.ForeColor = Tema.AzulPrimario;
            this.lblSubtituloHero.Location = new System.Drawing.Point(28, 136);
            this.lblSubtituloHero.Name = "lblSubtituloHero";
            this.lblSubtituloHero.Size = new System.Drawing.Size(250, 19);
            this.lblSubtituloHero.TabIndex = 2;
            this.lblSubtituloHero.Text = "Sistema de Gestión Médica Comunitaria";
            //
            // lblRegistroTituloHero
            //
            this.lblRegistroTituloHero.AutoSize = true;
            this.lblRegistroTituloHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 15F, System.Drawing.FontStyle.Bold);
            this.lblRegistroTituloHero.ForeColor = Tema.AzulOscuro;
            this.lblRegistroTituloHero.Location = new System.Drawing.Point(26, 170);
            this.lblRegistroTituloHero.Name = "lblRegistroTituloHero";
            this.lblRegistroTituloHero.Size = new System.Drawing.Size(205, 28);
            this.lblRegistroTituloHero.TabIndex = 3;
            this.lblRegistroTituloHero.Text = "Registro de Paciente";
            //
            // lblDescripcionHero
            //
            this.lblDescripcionHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F, System.Drawing.FontStyle.Regular);
            this.lblDescripcionHero.ForeColor = Tema.TextoSecundario;
            this.lblDescripcionHero.Location = new System.Drawing.Point(28, 204);
            this.lblDescripcionHero.Name = "lblDescripcionHero";
            this.lblDescripcionHero.Size = new System.Drawing.Size(294, 48);
            this.lblDescripcionHero.TabIndex = 4;
            this.lblDescripcionHero.Text = "Registra la información personal y de salud para facilitar una atención médica comunitaria organizada.";
            //
            // panelHeroBloque1
            //
            this.panelHeroBloque1.Controls.Add(this.lblHeroIcono1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroTitulo1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroDesc1);
            this.panelHeroBloque1.Location = new System.Drawing.Point(28, 260);
            this.panelHeroBloque1.Name = "panelHeroBloque1";
            this.panelHeroBloque1.Size = new System.Drawing.Size(294, 52);
            this.panelHeroBloque1.TabIndex = 5;
            //
            // lblHeroIcono1
            //
            this.lblHeroIcono1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblHeroIcono1.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblHeroIcono1.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono1.Location = new System.Drawing.Point(0, 4);
            this.lblHeroIcono1.Name = "lblHeroIcono1";
            this.lblHeroIcono1.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono1.TabIndex = 0;
            this.lblHeroIcono1.Text = "👤";
            this.lblHeroIcono1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo1
            //
            this.lblHeroTitulo1.AutoSize = true;
            this.lblHeroTitulo1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo1.ForeColor = Tema.TextoPrincipal;
            this.lblHeroTitulo1.Location = new System.Drawing.Point(44, 4);
            this.lblHeroTitulo1.Name = "lblHeroTitulo1";
            this.lblHeroTitulo1.Size = new System.Drawing.Size(141, 17);
            this.lblHeroTitulo1.TabIndex = 1;
            this.lblHeroTitulo1.Text = "Información personal";
            //
            // lblHeroDesc1
            //
            this.lblHeroDesc1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblHeroDesc1.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc1.Location = new System.Drawing.Point(44, 23);
            this.lblHeroDesc1.Name = "lblHeroDesc1";
            this.lblHeroDesc1.Size = new System.Drawing.Size(245, 26);
            this.lblHeroDesc1.TabIndex = 2;
            this.lblHeroDesc1.Text = "Datos de identificación y contacto del paciente.";
            //
            // panelHeroBloque2
            //
            this.panelHeroBloque2.Controls.Add(this.lblHeroIcono2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroTitulo2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroDesc2);
            this.panelHeroBloque2.Location = new System.Drawing.Point(28, 318);
            this.panelHeroBloque2.Name = "panelHeroBloque2";
            this.panelHeroBloque2.Size = new System.Drawing.Size(294, 52);
            this.panelHeroBloque2.TabIndex = 6;
            //
            // lblHeroIcono2
            //
            this.lblHeroIcono2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblHeroIcono2.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblHeroIcono2.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono2.Location = new System.Drawing.Point(0, 4);
            this.lblHeroIcono2.Name = "lblHeroIcono2";
            this.lblHeroIcono2.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono2.TabIndex = 0;
            this.lblHeroIcono2.Text = "📍";
            this.lblHeroIcono2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo2
            //
            this.lblHeroTitulo2.AutoSize = true;
            this.lblHeroTitulo2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo2.ForeColor = Tema.TextoPrincipal;
            this.lblHeroTitulo2.Location = new System.Drawing.Point(44, 4);
            this.lblHeroTitulo2.Name = "lblHeroTitulo2";
            this.lblHeroTitulo2.Size = new System.Drawing.Size(69, 17);
            this.lblHeroTitulo2.TabIndex = 1;
            this.lblHeroTitulo2.Text = "Ubicación";
            //
            // lblHeroDesc2
            //
            this.lblHeroDesc2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblHeroDesc2.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc2.Location = new System.Drawing.Point(44, 23);
            this.lblHeroDesc2.Name = "lblHeroDesc2";
            this.lblHeroDesc2.Size = new System.Drawing.Size(245, 26);
            this.lblHeroDesc2.TabIndex = 2;
            this.lblHeroDesc2.Text = "Organiza la información geográfica y la dirección.";
            //
            // panelHeroBloque3
            //
            this.panelHeroBloque3.Controls.Add(this.lblHeroIcono3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroTitulo3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroDesc3);
            this.panelHeroBloque3.Location = new System.Drawing.Point(28, 376);
            this.panelHeroBloque3.Name = "panelHeroBloque3";
            this.panelHeroBloque3.Size = new System.Drawing.Size(294, 52);
            this.panelHeroBloque3.TabIndex = 7;
            //
            // lblHeroIcono3
            //
            this.lblHeroIcono3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblHeroIcono3.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblHeroIcono3.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono3.Location = new System.Drawing.Point(0, 4);
            this.lblHeroIcono3.Name = "lblHeroIcono3";
            this.lblHeroIcono3.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono3.TabIndex = 0;
            this.lblHeroIcono3.Text = "💓";
            this.lblHeroIcono3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo3
            //
            this.lblHeroTitulo3.AutoSize = true;
            this.lblHeroTitulo3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo3.ForeColor = Tema.TextoPrincipal;
            this.lblHeroTitulo3.Location = new System.Drawing.Point(44, 4);
            this.lblHeroTitulo3.Name = "lblHeroTitulo3";
            this.lblHeroTitulo3.Size = new System.Drawing.Size(143, 17);
            this.lblHeroTitulo3.TabIndex = 1;
            this.lblHeroTitulo3.Text = "Información de salud";
            //
            // lblHeroDesc3
            //
            this.lblHeroDesc3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblHeroDesc3.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc3.Location = new System.Drawing.Point(44, 23);
            this.lblHeroDesc3.Name = "lblHeroDesc3";
            this.lblHeroDesc3.Size = new System.Drawing.Size(245, 26);
            this.lblHeroDesc3.TabIndex = 2;
            this.lblHeroDesc3.Text = "Registra los datos clínicos iniciales disponibles.";
            //
            // panelHeroBloque4
            //
            this.panelHeroBloque4.Controls.Add(this.lblHeroIcono4);
            this.panelHeroBloque4.Controls.Add(this.lblHeroTitulo4);
            this.panelHeroBloque4.Controls.Add(this.lblHeroDesc4);
            this.panelHeroBloque4.Location = new System.Drawing.Point(28, 434);
            this.panelHeroBloque4.Name = "panelHeroBloque4";
            this.panelHeroBloque4.Size = new System.Drawing.Size(294, 52);
            this.panelHeroBloque4.TabIndex = 8;
            //
            // lblHeroIcono4
            //
            this.lblHeroIcono4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblHeroIcono4.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblHeroIcono4.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono4.Location = new System.Drawing.Point(0, 4);
            this.lblHeroIcono4.Name = "lblHeroIcono4";
            this.lblHeroIcono4.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono4.TabIndex = 0;
            this.lblHeroIcono4.Text = "👥";
            this.lblHeroIcono4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo4
            //
            this.lblHeroTitulo4.AutoSize = true;
            this.lblHeroTitulo4.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo4.ForeColor = Tema.TextoPrincipal;
            this.lblHeroTitulo4.Location = new System.Drawing.Point(44, 4);
            this.lblHeroTitulo4.Name = "lblHeroTitulo4";
            this.lblHeroTitulo4.Size = new System.Drawing.Size(157, 17);
            this.lblHeroTitulo4.TabIndex = 1;
            this.lblHeroTitulo4.Text = "Contacto de emergencia";
            //
            // lblHeroDesc4
            //
            this.lblHeroDesc4.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblHeroDesc4.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc4.Location = new System.Drawing.Point(44, 23);
            this.lblHeroDesc4.Name = "lblHeroDesc4";
            this.lblHeroDesc4.Size = new System.Drawing.Size(245, 26);
            this.lblHeroDesc4.TabIndex = 2;
            this.lblHeroDesc4.Text = "Facilita la identificación de personas de urgencia.";
            //
            // panelLema
            //
            this.panelLema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(242)))));
            this.panelLema.Controls.Add(this.lblLemaComillas);
            this.panelLema.Controls.Add(this.lblLemaTexto);
            this.panelLema.Controls.Add(this.lblLemaComillasCierre);
            this.panelLema.Location = new System.Drawing.Point(28, 690);
            this.panelLema.Name = "panelLema";
            this.panelLema.Size = new System.Drawing.Size(294, 76);
            this.panelLema.TabIndex = 9;
            //
            // lblLemaComillas
            //
            this.lblLemaComillas.AutoSize = true;
            this.lblLemaComillas.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillas.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillas.Location = new System.Drawing.Point(10, 8);
            this.lblLemaComillas.Name = "lblLemaComillas";
            this.lblLemaComillas.Size = new System.Drawing.Size(43, 38);
            this.lblLemaComillas.TabIndex = 0;
            this.lblLemaComillas.Text = "“";
            //
            // lblLemaTexto
            //
            this.lblLemaTexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblLemaTexto.ForeColor = Tema.VerdeOscuro;
            this.lblLemaTexto.Location = new System.Drawing.Point(46, 16);
            this.lblLemaTexto.Name = "lblLemaTexto";
            this.lblLemaTexto.Size = new System.Drawing.Size(210, 44);
            this.lblLemaTexto.TabIndex = 1;
            this.lblLemaTexto.Text = "Salud más cerca\r\nde nuestra gente";
            //
            // lblLemaComillasCierre
            //
            this.lblLemaComillasCierre.AutoSize = true;
            this.lblLemaComillasCierre.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillasCierre.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillasCierre.Location = new System.Drawing.Point(252, 28);
            this.lblLemaComillasCierre.Name = "lblLemaComillasCierre";
            this.lblLemaComillasCierre.Size = new System.Drawing.Size(43, 38);
            this.lblLemaComillasCierre.TabIndex = 2;
            this.lblLemaComillasCierre.Text = "”";
            //
            // panelFormContenedor
            //
            this.panelFormContenedor.AutoScroll = true;
            this.panelFormContenedor.BackColor = Tema.Fondo;
            this.panelFormContenedor.Controls.Add(this.cardHeader);
            this.panelFormContenedor.Controls.Add(this.cardPersonal);
            this.panelFormContenedor.Controls.Add(this.cardFoto);
            this.panelFormContenedor.Controls.Add(this.cardUbicacion);
            this.panelFormContenedor.Controls.Add(this.cardSalud);
            this.panelFormContenedor.Controls.Add(this.cardEmergencia);
            this.panelFormContenedor.Controls.Add(this.panelAcciones);
            this.panelFormContenedor.Location = new System.Drawing.Point(350, 0);
            this.panelFormContenedor.Name = "panelFormContenedor";
            this.panelFormContenedor.Size = new System.Drawing.Size(950, 800);
            this.panelFormContenedor.TabIndex = 1;
            //
            // cardHeader
            //
            this.cardHeader.BackColor = Tema.Superficie;
            this.cardHeader.Controls.Add(this.lblIconoPaciente);
            this.cardHeader.Controls.Add(this.lblTitulo);
            this.cardHeader.Controls.Add(this.lblSubtitulo);
            this.cardHeader.Controls.Add(this.lblBadgeModo);
            this.cardHeader.Location = new System.Drawing.Point(20, 16);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Size = new System.Drawing.Size(900, 66);
            this.cardHeader.TabIndex = 0;
            //
            // lblIconoPaciente
            //
            this.lblIconoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoPaciente.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblIconoPaciente.ForeColor = Tema.AzulPrimario;
            this.lblIconoPaciente.Location = new System.Drawing.Point(16, 13);
            this.lblIconoPaciente.Name = "lblIconoPaciente";
            this.lblIconoPaciente.Size = new System.Drawing.Size(40, 40);
            this.lblIconoPaciente.TabIndex = 0;
            this.lblIconoPaciente.Text = "👤";
            this.lblIconoPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(64, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(199, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Datos del Paciente";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(66, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(193, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Completa la información requerida";
            //
            // btnModoCrear
            //
            this.lblBadgeModo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeModo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            this.lblBadgeModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBadgeModo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblBadgeModo.ForeColor = Tema.VerdeOscuro;
            this.lblBadgeModo.Location = new System.Drawing.Point(735, 18);
            this.lblBadgeModo.Name = "lblBadgeModo";
            this.lblBadgeModo.Size = new System.Drawing.Size(145, 28);
            this.lblBadgeModo.TabIndex = 3;
            this.lblBadgeModo.Text = "+ Nuevo Paciente";
            this.lblBadgeModo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnModoEditar
            //
            this.btnModoEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModoEditar.BackColor = Tema.Superficie;
            this.btnModoEditar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnModoEditar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Regular);
            this.btnModoEditar.ForeColor = Tema.TextoSecundario;
            this.btnModoEditar.Location = new System.Drawing.Point(756, 18);
            this.btnModoEditar.Visible = false;
            this.btnModoEditar.Size = new System.Drawing.Size(130, 32);
            this.btnModoEditar.TabIndex = 4;
            this.btnModoEditar.Text = "✏️ Editar Paciente";
            this.btnModoEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cardPersonal.Controls.Add(this.lblCedulaAyuda);
            this.cardPersonal.Controls.Add(this.pnlCedulaInfo);
            this.cardPersonal.Controls.Add(this.lblNumeroINSS);
            this.cardPersonal.Controls.Add(this.txtNumeroINSS);
            this.cardPersonal.Controls.Add(this.lblINSSAyuda);
            this.cardPersonal.Controls.Add(this.lblFechaNacimiento);
            this.cardPersonal.Controls.Add(this.dtpFechaNacimiento);
            this.cardPersonal.Controls.Add(this.lblGenero);
            this.cardPersonal.Controls.Add(this.cmbGenero);
            this.cardPersonal.Controls.Add(this.lblTelefono);
            this.cardPersonal.Controls.Add(this.cmbPaisTelefono);
            this.cardPersonal.Controls.Add(this.txtTelefono);
            this.cardPersonal.Controls.Add(this.lblTelefonoAyuda);
            this.cardPersonal.Controls.Add(this.lblErrorTelefono);
            this.cardPersonal.Location = new System.Drawing.Point(20, 94);
            this.cardPersonal.Name = "cardPersonal";
            this.cardPersonal.Size = new System.Drawing.Size(600, 360);
            this.cardPersonal.TabIndex = 1;
            //
            // lblIconoPersonal
            //
            this.lblIconoPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoPersonal.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoPersonal.ForeColor = Tema.AzulPrimario;
            this.lblIconoPersonal.Location = new System.Drawing.Point(14, 12);
            this.lblIconoPersonal.Name = "lblIconoPersonal";
            this.lblIconoPersonal.Size = new System.Drawing.Size(34, 34);
            this.lblIconoPersonal.TabIndex = 0;
            this.lblIconoPersonal.Text = "👤";
            this.lblIconoPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloPersonal
            //
            this.lblTituloPersonal.AutoSize = true;
            this.lblTituloPersonal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloPersonal.ForeColor = Tema.AzulOscuro;
            this.lblTituloPersonal.Location = new System.Drawing.Point(54, 10);
            this.lblTituloPersonal.Name = "lblTituloPersonal";
            this.lblTituloPersonal.Size = new System.Drawing.Size(168, 21);
            this.lblTituloPersonal.TabIndex = 1;
            this.lblTituloPersonal.Text = "Información personal";
            //
            // lblSubtituloPersonal
            //
            this.lblSubtituloPersonal.AutoSize = true;
            this.lblSubtituloPersonal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloPersonal.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloPersonal.Location = new System.Drawing.Point(56, 32);
            this.lblSubtituloPersonal.Name = "lblSubtituloPersonal";
            this.lblSubtituloPersonal.Size = new System.Drawing.Size(252, 15);
            this.lblSubtituloPersonal.TabIndex = 2;
            this.lblSubtituloPersonal.Text = "Datos de identificación y contacto del paciente.";
            //
            // lblPrimerNombre
            //
            this.lblPrimerNombre.AutoSize = true;
            this.lblPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerNombre.Location = new System.Drawing.Point(16, 56);
            this.lblPrimerNombre.Name = "lblPrimerNombre";
            this.lblPrimerNombre.Size = new System.Drawing.Size(107, 15);
            this.lblPrimerNombre.TabIndex = 3;
            this.lblPrimerNombre.Text = "Primer nombre *";
            //
            // txtNombres
            //
            this.txtNombres.Font = Tema.FuenteInput;
            this.txtNombres.Location = new System.Drawing.Point(16, 74);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(270, 27);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            //
            // lblErrorNombres
            //
            this.lblErrorNombres.AutoSize = true;
            this.lblErrorNombres.Font = Tema.FuenteAyuda;
            this.lblErrorNombres.ForeColor = Tema.Error;
            this.lblErrorNombres.Location = new System.Drawing.Point(16, 103);
            this.lblErrorNombres.Name = "lblErrorNombres";
            this.lblErrorNombres.Size = new System.Drawing.Size(0, 13);
            this.lblErrorNombres.TabIndex = 5;
            //
            // lblSegundoNombre
            //
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Font = Tema.FuenteLabelCampo;
            this.lblSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoNombre.Location = new System.Drawing.Point(300, 56);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(103, 15);
            this.lblSegundoNombre.TabIndex = 6;
            this.lblSegundoNombre.Text = "Segundo nombre";
            //
            // txtSegundoNombre
            //
            this.txtSegundoNombre.Font = Tema.FuenteInput;
            this.txtSegundoNombre.Location = new System.Drawing.Point(300, 74);
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(270, 27);
            this.txtSegundoNombre.TabIndex = 7;
            //
            // lblPrimerApellido
            //
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = Tema.FuenteLabelCampo;
            this.lblPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerApellido.Location = new System.Drawing.Point(16, 108);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(108, 15);
            this.lblPrimerApellido.TabIndex = 8;
            this.lblPrimerApellido.Text = "Primer apellido *";
            //
            // txtApellidos
            //
            this.txtApellidos.Font = Tema.FuenteInput;
            this.txtApellidos.Location = new System.Drawing.Point(16, 126);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(270, 27);
            this.txtApellidos.TabIndex = 9;
            //
            // lblSegundoApellido
            //
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = Tema.FuenteLabelCampo;
            this.lblSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoApellido.Location = new System.Drawing.Point(300, 108);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(104, 15);
            this.lblSegundoApellido.TabIndex = 10;
            this.lblSegundoApellido.Text = "Segundo apellido";
            //
            // txtSegundoApellido
            //
            this.txtSegundoApellido.Font = Tema.FuenteInput;
            this.txtSegundoApellido.Location = new System.Drawing.Point(300, 126);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(270, 27);
            this.txtSegundoApellido.TabIndex = 11;
            //
            // lblCedula
            //
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = Tema.FuenteLabelCampo;
            this.lblCedula.ForeColor = Tema.TextoPrincipal;
            this.lblCedula.Location = new System.Drawing.Point(16, 160);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(56, 15);
            this.lblCedula.TabIndex = 12;
            this.lblCedula.Text = "Cédula *";
            //
            // txtCedula
            //
            this.txtCedula.Font = Tema.FuenteInput;
            this.txtCedula.Location = new System.Drawing.Point(16, 178);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(270, 27);
            this.txtCedula.TabIndex = 13;
            //
            // lblCedulaAyuda
            //
            this.lblCedulaAyuda.Font = Tema.FuenteAyuda;
            this.lblCedulaAyuda.ForeColor = Tema.TextoSecundario;
            this.lblCedulaAyuda.Location = new System.Drawing.Point(16, 208);
            this.lblCedulaAyuda.Name = "lblCedulaAyuda";
            this.lblCedulaAyuda.Size = new System.Drawing.Size(270, 28);
            this.lblCedulaAyuda.TabIndex = 14;
            this.lblCedulaAyuda.Text = "Ejemplo: 001-091101-1042V\r\nPuedes escribirla con o sin guiones.";
            //
            // pnlCedulaInfo
            //
            this.pnlCedulaInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            this.pnlCedulaInfo.Controls.Add(this.lblCedulaInfo);
            this.pnlCedulaInfo.Location = new System.Drawing.Point(16, 238);
            this.pnlCedulaInfo.Name = "pnlCedulaInfo";
            this.pnlCedulaInfo.Size = new System.Drawing.Size(270, 36);
            this.pnlCedulaInfo.TabIndex = 15;
            //
            // lblCedulaInfo
            //
            this.lblCedulaInfo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblCedulaInfo.ForeColor = Tema.AzulOscuro;
            this.lblCedulaInfo.Location = new System.Drawing.Point(6, 4);
            this.lblCedulaInfo.Name = "lblCedulaInfo";
            this.lblCedulaInfo.Size = new System.Drawing.Size(258, 28);
            this.lblCedulaInfo.TabIndex = 0;
            this.lblCedulaInfo.Text = "Formato tradicional nicaragüense con formato estándar.";
            //
            // lblNumeroINSS
            //
            this.lblNumeroINSS.AutoSize = true;
            this.lblNumeroINSS.Font = Tema.FuenteLabelCampo;
            this.lblNumeroINSS.ForeColor = Tema.TextoPrincipal;
            this.lblNumeroINSS.Location = new System.Drawing.Point(16, 278);
            this.lblNumeroINSS.Name = "lblNumeroINSS";
            this.lblNumeroINSS.Size = new System.Drawing.Size(81, 15);
            this.lblNumeroINSS.TabIndex = 16;
            this.lblNumeroINSS.Text = "Número INSS";
            //
            // txtNumeroINSS
            //
            this.txtNumeroINSS.Font = Tema.FuenteInput;
            this.txtNumeroINSS.Location = new System.Drawing.Point(16, 296);
            this.txtNumeroINSS.Name = "txtNumeroINSS";
            this.txtNumeroINSS.Size = new System.Drawing.Size(270, 27);
            this.txtNumeroINSS.TabIndex = 17;
            //
            // lblINSSAyuda
            //
            this.lblINSSAyuda.AutoSize = true;
            this.lblINSSAyuda.Font = Tema.FuenteAyuda;
            this.lblINSSAyuda.ForeColor = Tema.TextoSecundario;
            this.lblINSSAyuda.Location = new System.Drawing.Point(16, 326);
            this.lblINSSAyuda.Name = "lblINSSAyuda";
            this.lblINSSAyuda.Size = new System.Drawing.Size(164, 13);
            this.lblINSSAyuda.TabIndex = 18;
            this.lblINSSAyuda.Text = "Si el paciente tiene número de INSS.";
            //
            // lblFechaNacimiento
            //
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = Tema.FuenteLabelCampo;
            this.lblFechaNacimiento.ForeColor = Tema.TextoPrincipal;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(300, 160);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(134, 15);
            this.lblFechaNacimiento.TabIndex = 19;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento *";
            //
            // dtpFechaNacimiento
            //
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Font = Tema.FuenteInput;
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(300, 178);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(130, 27);
            this.dtpFechaNacimiento.TabIndex = 20;
            //
            // lblGenero
            //
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = Tema.FuenteLabelCampo;
            this.lblGenero.ForeColor = Tema.TextoPrincipal;
            this.lblGenero.Location = new System.Drawing.Point(440, 160);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(58, 15);
            this.lblGenero.TabIndex = 21;
            this.lblGenero.Text = "Género *";
            //
            // cmbGenero
            //
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = Tema.FuenteInput;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Femenino",
            "Masculino"});
            this.cmbGenero.Location = new System.Drawing.Point(440, 178);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(130, 27);
            this.cmbGenero.TabIndex = 22;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(300, 212);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 15);
            this.lblTelefono.TabIndex = 23;
            this.lblTelefono.Text = "Teléfono *";
            //
            // cmbPaisTelefono
            //
            this.cmbPaisTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaisTelefono.Font = Tema.FuenteInput;
            this.cmbPaisTelefono.FormattingEnabled = true;
            this.cmbPaisTelefono.Location = new System.Drawing.Point(300, 230);
            this.cmbPaisTelefono.Name = "cmbPaisTelefono";
            this.cmbPaisTelefono.Size = new System.Drawing.Size(155, 27);
            this.cmbPaisTelefono.TabIndex = 24;
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(463, 230);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(107, 27);
            this.txtTelefono.TabIndex = 25;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            //
            // lblTelefonoAyuda
            //
            this.lblTelefonoAyuda.Font = Tema.FuenteAyuda;
            this.lblTelefonoAyuda.ForeColor = Tema.TextoSecundario;
            this.lblTelefonoAyuda.Location = new System.Drawing.Point(300, 260);
            this.lblTelefonoAyuda.Name = "lblTelefonoAyuda";
            this.lblTelefonoAyuda.Size = new System.Drawing.Size(270, 36);
            this.lblTelefonoAyuda.TabIndex = 26;
            this.lblTelefonoAyuda.Text = "Ingresa solo el número de teléfono (sin el código de país).\r\nEjemplo: 8888-2222";
            //
            // lblErrorTelefono
            //
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.Font = Tema.FuenteAyuda;
            this.lblErrorTelefono.ForeColor = Tema.Error;
            this.lblErrorTelefono.Location = new System.Drawing.Point(300, 298);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(0, 13);
            this.lblErrorTelefono.TabIndex = 27;
            //
            // cardFoto
            //
            this.cardFoto.BackColor = Tema.Superficie;
            this.cardFoto.Controls.Add(this.lblIconoFoto);
            this.cardFoto.Controls.Add(this.lblTituloFoto);
            this.cardFoto.Controls.Add(this.lblSubtituloFoto);
            this.cardFoto.Controls.Add(this.picPreview);
            this.cardFoto.Controls.Add(this.btnSeleccionarFoto);
            this.cardFoto.Controls.Add(this.btnQuitarFoto);
            this.cardFoto.Controls.Add(this.lblFoto);
            this.cardFoto.Controls.Add(this.lblFotoAyuda);
            this.cardFoto.Controls.Add(this.pnlFotoInfo);
            this.cardFoto.Location = new System.Drawing.Point(630, 94);
            this.cardFoto.Name = "cardFoto";
            this.cardFoto.Size = new System.Drawing.Size(290, 360);
            this.cardFoto.TabIndex = 2;
            //
            // lblIconoFoto
            //
            this.lblIconoFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoFoto.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoFoto.ForeColor = Tema.AzulPrimario;
            this.lblIconoFoto.Location = new System.Drawing.Point(14, 12);
            this.lblIconoFoto.Name = "lblIconoFoto";
            this.lblIconoFoto.Size = new System.Drawing.Size(34, 34);
            this.lblIconoFoto.TabIndex = 0;
            this.lblIconoFoto.Text = "📷";
            this.lblIconoFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloFoto
            //
            this.lblTituloFoto.AutoSize = true;
            this.lblTituloFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloFoto.ForeColor = Tema.AzulOscuro;
            this.lblTituloFoto.Location = new System.Drawing.Point(54, 10);
            this.lblTituloFoto.Name = "lblTituloFoto";
            this.lblTituloFoto.Size = new System.Drawing.Size(142, 21);
            this.lblTituloFoto.TabIndex = 1;
            this.lblTituloFoto.Text = "Foto del paciente";
            //
            // lblSubtituloFoto
            //
            this.lblSubtituloFoto.AutoSize = true;
            this.lblSubtituloFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloFoto.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloFoto.Location = new System.Drawing.Point(56, 32);
            this.lblSubtituloFoto.Name = "lblSubtituloFoto";
            this.lblSubtituloFoto.Size = new System.Drawing.Size(126, 15);
            this.lblSubtituloFoto.TabIndex = 2;
            this.lblSubtituloFoto.Text = "Foto de perfil (opcional).";
            //
            // picPreview
            //
            this.picPreview.BackColor = Tema.FondoSecundario;
            this.picPreview.Location = new System.Drawing.Point(16, 56);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(90, 90);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 3;
            this.picPreview.TabStop = false;
            //
            // btnSeleccionarFoto
            //
            this.btnSeleccionarFoto.BackColor = Tema.AzulPrimario;
            this.btnSeleccionarFoto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarFoto.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(118, 56);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(155, 34);
            this.btnSeleccionarFoto.TabIndex = 4;
            this.btnSeleccionarFoto.Text = "📷 Seleccionar foto";
            this.btnSeleccionarFoto.UseVisualStyleBackColor = false;
            //
            // btnQuitarFoto
            //
            this.btnQuitarFoto.BackColor = Tema.Superficie;
            this.btnQuitarFoto.FlatAppearance.BorderColor = Tema.Borde;
            this.btnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.btnQuitarFoto.ForeColor = Tema.Error;
            this.btnQuitarFoto.Location = new System.Drawing.Point(118, 96);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Size = new System.Drawing.Size(155, 26);
            this.btnQuitarFoto.TabIndex = 5;
            this.btnQuitarFoto.Text = "✕ Quitar foto";
            this.btnQuitarFoto.UseVisualStyleBackColor = false;
            this.btnQuitarFoto.Visible = false;
            //
            // lblFoto
            //
            this.lblFoto.AutoSize = true;
            this.lblFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblFoto.ForeColor = Tema.TextoPrincipal;
            this.lblFoto.Location = new System.Drawing.Point(118, 126);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(124, 15);
            this.lblFoto.TabIndex = 6;
            this.lblFoto.Text = "Sin foto seleccionada";
            //
            // lblFotoAyuda
            //
            this.lblFotoAyuda.AutoSize = true;
            this.lblFotoAyuda.Font = Tema.FuenteAyuda;
            this.lblFotoAyuda.ForeColor = Tema.TextoSecundario;
            this.lblFotoAyuda.Location = new System.Drawing.Point(118, 144);
            this.lblFotoAyuda.Name = "lblFotoAyuda";
            this.lblFotoAyuda.Size = new System.Drawing.Size(117, 13);
            this.lblFotoAyuda.TabIndex = 7;
            this.lblFotoAyuda.Text = "JPG, PNG (máx. 2 MB)";
            //
            // pnlFotoInfo
            //
            this.pnlFotoInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(253)))));
            this.pnlFotoInfo.Controls.Add(this.lblFotoInfo);
            this.pnlFotoInfo.Location = new System.Drawing.Point(16, 238);
            this.pnlFotoInfo.Name = "pnlFotoInfo";
            this.pnlFotoInfo.Size = new System.Drawing.Size(257, 56);
            this.pnlFotoInfo.TabIndex = 8;
            //
            // lblFotoInfo
            //
            this.lblFotoInfo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblFotoInfo.ForeColor = Tema.AzulOscuro;
            this.lblFotoInfo.Location = new System.Drawing.Point(8, 8);
            this.lblFotoInfo.Name = "lblFotoInfo";
            this.lblFotoInfo.Size = new System.Drawing.Size(240, 40);
            this.lblFotoInfo.TabIndex = 0;
            this.lblFotoInfo.Text = "ℹ La foto ayuda a identificar al paciente en el sistema.";
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
            this.cardUbicacion.Location = new System.Drawing.Point(20, 464);
            this.cardUbicacion.Name = "cardUbicacion";
            this.cardUbicacion.Size = new System.Drawing.Size(900, 180);
            this.cardUbicacion.TabIndex = 3;
            //
            // lblIconoUbicacion
            //
            this.lblIconoUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoUbicacion.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoUbicacion.ForeColor = Tema.AzulPrimario;
            this.lblIconoUbicacion.Location = new System.Drawing.Point(14, 12);
            this.lblIconoUbicacion.Name = "lblIconoUbicacion";
            this.lblIconoUbicacion.Size = new System.Drawing.Size(34, 34);
            this.lblIconoUbicacion.TabIndex = 0;
            this.lblIconoUbicacion.Text = "📍";
            this.lblIconoUbicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloUbicacion
            //
            this.lblTituloUbicacion.AutoSize = true;
            this.lblTituloUbicacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloUbicacion.ForeColor = Tema.AzulOscuro;
            this.lblTituloUbicacion.Location = new System.Drawing.Point(54, 10);
            this.lblTituloUbicacion.Name = "lblTituloUbicacion";
            this.lblTituloUbicacion.Size = new System.Drawing.Size(167, 21);
            this.lblTituloUbicacion.TabIndex = 1;
            this.lblTituloUbicacion.Text = "Ubicación y dirección";
            //
            // lblSubtituloUbicacion
            //
            this.lblSubtituloUbicacion.AutoSize = true;
            this.lblSubtituloUbicacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloUbicacion.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloUbicacion.Location = new System.Drawing.Point(56, 32);
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
            this.lblDepartamento.Location = new System.Drawing.Point(16, 56);
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
            this.cmbDepartamento.Location = new System.Drawing.Point(16, 74);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(270, 27);
            this.cmbDepartamento.TabIndex = 4;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            //
            // lblMunicipio
            //
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = Tema.FuenteLabelCampo;
            this.lblMunicipio.ForeColor = Tema.TextoPrincipal;
            this.lblMunicipio.Location = new System.Drawing.Point(300, 56);
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
            this.cmbMunicipio.Location = new System.Drawing.Point(300, 74);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(270, 27);
            this.cmbMunicipio.TabIndex = 6;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            //
            // lblComunidad
            //
            this.lblComunidad.AutoSize = true;
            this.lblComunidad.Font = Tema.FuenteLabelCampo;
            this.lblComunidad.ForeColor = Tema.TextoPrincipal;
            this.lblComunidad.Location = new System.Drawing.Point(584, 56);
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
            this.cmbComunidad.Location = new System.Drawing.Point(584, 74);
            this.cmbComunidad.Name = "cmbComunidad";
            this.cmbComunidad.Size = new System.Drawing.Size(300, 27);
            this.cmbComunidad.TabIndex = 8;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = Tema.FuenteLabelCampo;
            this.lblDireccion.ForeColor = Tema.TextoPrincipal;
            this.lblDireccion.Location = new System.Drawing.Point(16, 114);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(107, 15);
            this.lblDireccion.TabIndex = 9;
            this.lblDireccion.Text = "Dirección exacta *";
            //
            // txtDireccion
            //
            this.txtDireccion.Font = Tema.FuenteInput;
            this.txtDireccion.Location = new System.Drawing.Point(16, 132);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(554, 27);
            this.txtDireccion.TabIndex = 10;
            //
            // lblReferencia
            //
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = Tema.FuenteLabelCampo;
            this.lblReferencia.ForeColor = Tema.TextoPrincipal;
            this.lblReferencia.Location = new System.Drawing.Point(584, 114);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(117, 15);
            this.lblReferencia.TabIndex = 11;
            this.lblReferencia.Text = "Referencia adicional";
            //
            // txtReferencia
            //
            this.txtReferencia.Font = Tema.FuenteInput;
            this.txtReferencia.Location = new System.Drawing.Point(584, 132);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(300, 27);
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
            this.cardSalud.Controls.Add(this.txtAlergias);
            this.cardSalud.Controls.Add(this.lblAlergiasAyuda);
            this.cardSalud.Controls.Add(this.lblAntecedentes);
            this.cardSalud.Controls.Add(this.txtAntecedentes);
            this.cardSalud.Controls.Add(this.lblAntecedentesAyuda);
            this.cardSalud.Location = new System.Drawing.Point(20, 654);
            this.cardSalud.Name = "cardSalud";
            this.cardSalud.Size = new System.Drawing.Size(440, 330);
            this.cardSalud.TabIndex = 4;
            //
            // lblIconoSalud
            //
            this.lblIconoSalud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoSalud.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoSalud.ForeColor = Tema.AzulPrimario;
            this.lblIconoSalud.Location = new System.Drawing.Point(14, 12);
            this.lblIconoSalud.Name = "lblIconoSalud";
            this.lblIconoSalud.Size = new System.Drawing.Size(34, 34);
            this.lblIconoSalud.TabIndex = 0;
            this.lblIconoSalud.Text = "💓";
            this.lblIconoSalud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloSalud
            //
            this.lblTituloSalud.AutoSize = true;
            this.lblTituloSalud.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloSalud.ForeColor = Tema.AzulOscuro;
            this.lblTituloSalud.Location = new System.Drawing.Point(54, 10);
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
            this.lblSubtituloSalud.Location = new System.Drawing.Point(56, 32);
            this.lblSubtituloSalud.Name = "lblSubtituloSalud";
            this.lblSubtituloSalud.Size = new System.Drawing.Size(211, 15);
            this.lblSubtituloSalud.TabIndex = 2;
            this.lblSubtituloSalud.Text = "Datos clínicos básicos del paciente.";
            //
            // lblTipoSangre
            //
            this.lblTipoSangre.AutoSize = true;
            this.lblTipoSangre.Font = Tema.FuenteLabelCampo;
            this.lblTipoSangre.ForeColor = Tema.TextoPrincipal;
            this.lblTipoSangre.Location = new System.Drawing.Point(16, 56);
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
            this.cmbTipoSangre.Location = new System.Drawing.Point(16, 74);
            this.cmbTipoSangre.Name = "cmbTipoSangre";
            this.cmbTipoSangre.Size = new System.Drawing.Size(180, 27);
            this.cmbTipoSangre.TabIndex = 4;
            //
            // lblAlergias
            //
            this.lblAlergias.AutoSize = true;
            this.lblAlergias.Font = Tema.FuenteLabelCampo;
            this.lblAlergias.ForeColor = Tema.TextoPrincipal;
            this.lblAlergias.Location = new System.Drawing.Point(210, 56);
            this.lblAlergias.Name = "lblAlergias";
            this.lblAlergias.Size = new System.Drawing.Size(117, 15);
            this.lblAlergias.TabIndex = 5;
            this.lblAlergias.Text = "Alergias conocidas";
            //
            // txtAlergias
            //
            this.txtAlergias.Font = Tema.FuenteInput;
            this.txtAlergias.Location = new System.Drawing.Point(210, 74);
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.Size = new System.Drawing.Size(214, 27);
            this.txtAlergias.TabIndex = 6;
            //
            // lblAlergiasAyuda
            //
            this.lblAlergiasAyuda.AutoSize = true;
            this.lblAlergiasAyuda.Font = Tema.FuenteAyuda;
            this.lblAlergiasAyuda.ForeColor = Tema.TextoSecundario;
            this.lblAlergiasAyuda.Location = new System.Drawing.Point(210, 104);
            this.lblAlergiasAyuda.Name = "lblAlergiasAyuda";
            this.lblAlergiasAyuda.Size = new System.Drawing.Size(161, 13);
            this.lblAlergiasAyuda.TabIndex = 7;
            this.lblAlergiasAyuda.Text = "Ej. Medicamentos, alimentos, etc.";
            //
            // lblAntecedentes
            //
            this.lblAntecedentes.AutoSize = true;
            this.lblAntecedentes.Font = Tema.FuenteLabelCampo;
            this.lblAntecedentes.ForeColor = Tema.TextoPrincipal;
            this.lblAntecedentes.Location = new System.Drawing.Point(16, 126);
            this.lblAntecedentes.Name = "lblAntecedentes";
            this.lblAntecedentes.Size = new System.Drawing.Size(206, 15);
            this.lblAntecedentes.TabIndex = 8;
            this.lblAntecedentes.Text = "Condiciones de salud relevantes";
            //
            // txtAntecedentes
            //
            this.txtAntecedentes.Font = Tema.FuenteInput;
            this.txtAntecedentes.Location = new System.Drawing.Point(16, 146);
            this.txtAntecedentes.Multiline = true;
            this.txtAntecedentes.Name = "txtAntecedentes";
            this.txtAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntecedentes.Size = new System.Drawing.Size(408, 140);
            this.txtAntecedentes.TabIndex = 9;
            //
            // lblAntecedentesAyuda
            //
            this.lblAntecedentesAyuda.AutoSize = true;
            this.lblAntecedentesAyuda.Font = Tema.FuenteAyuda;
            this.lblAntecedentesAyuda.ForeColor = Tema.TextoSecundario;
            this.lblAntecedentesAyuda.Location = new System.Drawing.Point(16, 292);
            this.lblAntecedentesAyuda.Name = "lblAntecedentesAyuda";
            this.lblAntecedentesAyuda.Size = new System.Drawing.Size(185, 13);
            this.lblAntecedentesAyuda.TabIndex = 10;
            this.lblAntecedentesAyuda.Text = "Ej. Hipertensión, diabetes, asma, etc.";
            //
            // cardEmergencia
            //
            this.cardEmergencia.BackColor = Tema.Superficie;
            this.cardEmergencia.Controls.Add(this.lblIconoEmergencia);
            this.cardEmergencia.Controls.Add(this.lblTituloEmergencia);
            this.cardEmergencia.Controls.Add(this.lblSubtituloEmergencia);
            this.cardEmergencia.Controls.Add(this.lblContactoPrimerNombre);
            this.cardEmergencia.Controls.Add(this.txtContactoPrimerNombre);
            this.cardEmergencia.Controls.Add(this.txtContactoSegundoNombre);
            this.cardEmergencia.Controls.Add(this.lblContactoPrimerApellido);
            this.cardEmergencia.Controls.Add(this.txtContactoPrimerApellido);
            this.cardEmergencia.Controls.Add(this.txtContactoSegundoApellido);
            this.cardEmergencia.Controls.Add(this.lblContactoParentesco);
            this.cardEmergencia.Controls.Add(this.cmbContactoParentesco);
            this.cardEmergencia.Controls.Add(this.lblContactoTelefono);
            this.cardEmergencia.Controls.Add(this.txtContactoTelefono);
            this.cardEmergencia.Controls.Add(this.lblContactoCedula);
            this.cardEmergencia.Controls.Add(this.txtContactoCedula);
            this.cardEmergencia.Controls.Add(this.btnAgregarContacto);
            this.cardEmergencia.Controls.Add(this.lblErrorContacto);
            this.cardEmergencia.Controls.Add(this.lblSubtituloListaContactos);
            this.cardEmergencia.Controls.Add(this.lblSinContactos);
            this.cardEmergencia.Controls.Add(this.dgvContactos);
            this.cardEmergencia.Location = new System.Drawing.Point(470, 654);
            this.cardEmergencia.Name = "cardEmergencia";
            this.cardEmergencia.Size = new System.Drawing.Size(450, 330);
            this.cardEmergencia.TabIndex = 5;
            //
            // lblIconoEmergencia
            //
            this.lblIconoEmergencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.lblIconoEmergencia.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.lblIconoEmergencia.ForeColor = Tema.AzulPrimario;
            this.lblIconoEmergencia.Location = new System.Drawing.Point(14, 12);
            this.lblIconoEmergencia.Name = "lblIconoEmergencia";
            this.lblIconoEmergencia.Size = new System.Drawing.Size(34, 34);
            this.lblIconoEmergencia.TabIndex = 0;
            this.lblIconoEmergencia.Text = "👥";
            this.lblIconoEmergencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloEmergencia
            //
            this.lblTituloEmergencia.AutoSize = true;
            this.lblTituloEmergencia.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloEmergencia.ForeColor = Tema.AzulOscuro;
            this.lblTituloEmergencia.Location = new System.Drawing.Point(54, 10);
            this.lblTituloEmergencia.Name = "lblTituloEmergencia";
            this.lblTituloEmergencia.Size = new System.Drawing.Size(189, 21);
            this.lblTituloEmergencia.TabIndex = 1;
            this.lblTituloEmergencia.Text = "Contacto de emergencia";
            //
            // lblSubtituloEmergencia
            //
            this.lblSubtituloEmergencia.AutoSize = true;
            this.lblSubtituloEmergencia.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloEmergencia.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloEmergencia.Location = new System.Drawing.Point(56, 32);
            this.lblSubtituloEmergencia.Name = "lblSubtituloEmergencia";
            this.lblSubtituloEmergencia.Size = new System.Drawing.Size(248, 15);
            this.lblSubtituloEmergencia.TabIndex = 2;
            this.lblSubtituloEmergencia.Text = "Persona de contacto en caso de emergencia.";
            //
            // lblContactoPrimerNombre
            //
            this.lblContactoPrimerNombre.AutoSize = true;
            this.lblContactoPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblContactoPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblContactoPrimerNombre.Location = new System.Drawing.Point(16, 56);
            this.lblContactoPrimerNombre.Name = "lblContactoPrimerNombre";
            this.lblContactoPrimerNombre.Size = new System.Drawing.Size(117, 15);
            this.lblContactoPrimerNombre.TabIndex = 3;
            this.lblContactoPrimerNombre.Text = "Nombre completo *";
            //
            // txtContactoPrimerNombre
            //
            this.txtContactoPrimerNombre.Font = Tema.FuenteInput;
            this.txtContactoPrimerNombre.Location = new System.Drawing.Point(16, 74);
            this.txtContactoPrimerNombre.Name = "txtContactoPrimerNombre";
            this.txtContactoPrimerNombre.Size = new System.Drawing.Size(195, 27);
            this.txtContactoPrimerNombre.TabIndex = 4;
            //
            // txtContactoSegundoNombre
            //
            this.txtContactoSegundoNombre.Location = new System.Drawing.Point(0, 0);
            this.txtContactoSegundoNombre.Name = "txtContactoSegundoNombre";
            this.txtContactoSegundoNombre.Size = new System.Drawing.Size(0, 20);
            this.txtContactoSegundoNombre.TabIndex = 5;
            this.txtContactoSegundoNombre.Visible = false;
            //
            // lblContactoPrimerApellido
            //
            this.lblContactoPrimerApellido.AutoSize = true;
            this.lblContactoPrimerApellido.Font = Tema.FuenteLabelCampo;
            this.lblContactoPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblContactoPrimerApellido.Location = new System.Drawing.Point(220, 56);
            this.lblContactoPrimerApellido.Name = "lblContactoPrimerApellido";
            this.lblContactoPrimerApellido.Size = new System.Drawing.Size(84, 15);
            this.lblContactoPrimerApellido.TabIndex = 6;
            this.lblContactoPrimerApellido.Text = "Parentesco *";
            //
            // txtContactoPrimerApellido
            //
            this.txtContactoPrimerApellido.Location = new System.Drawing.Point(0, 0);
            this.txtContactoPrimerApellido.Name = "txtContactoPrimerApellido";
            this.txtContactoPrimerApellido.Size = new System.Drawing.Size(0, 20);
            this.txtContactoPrimerApellido.TabIndex = 7;
            this.txtContactoPrimerApellido.Visible = false;
            //
            // txtContactoSegundoApellido
            //
            this.txtContactoSegundoApellido.Location = new System.Drawing.Point(0, 0);
            this.txtContactoSegundoApellido.Name = "txtContactoSegundoApellido";
            this.txtContactoSegundoApellido.Size = new System.Drawing.Size(0, 20);
            this.txtContactoSegundoApellido.TabIndex = 8;
            this.txtContactoSegundoApellido.Visible = false;
            //
            // lblContactoParentesco
            //
            this.lblContactoParentesco.Location = new System.Drawing.Point(0, 0);
            this.lblContactoParentesco.Name = "lblContactoParentesco";
            this.lblContactoParentesco.Size = new System.Drawing.Size(0, 0);
            this.lblContactoParentesco.TabIndex = 9;
            this.lblContactoParentesco.Visible = false;
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
            this.cmbContactoParentesco.Location = new System.Drawing.Point(220, 74);
            this.cmbContactoParentesco.Name = "cmbContactoParentesco";
            this.cmbContactoParentesco.Size = new System.Drawing.Size(214, 27);
            this.cmbContactoParentesco.TabIndex = 10;
            //
            // lblContactoTelefono
            //
            this.lblContactoTelefono.AutoSize = true;
            this.lblContactoTelefono.Font = Tema.FuenteLabelCampo;
            this.lblContactoTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblContactoTelefono.Location = new System.Drawing.Point(16, 108);
            this.lblContactoTelefono.Name = "lblContactoTelefono";
            this.lblContactoTelefono.Size = new System.Drawing.Size(66, 15);
            this.lblContactoTelefono.TabIndex = 11;
            this.lblContactoTelefono.Text = "Teléfono *";
            //
            // txtContactoTelefono
            //
            this.txtContactoTelefono.Font = Tema.FuenteInput;
            this.txtContactoTelefono.Location = new System.Drawing.Point(16, 126);
            this.txtContactoTelefono.Name = "txtContactoTelefono";
            this.txtContactoTelefono.Size = new System.Drawing.Size(195, 27);
            this.txtContactoTelefono.TabIndex = 12;
            //
            // lblContactoCedula
            //
            this.lblContactoCedula.AutoSize = true;
            this.lblContactoCedula.Font = Tema.FuenteLabelCampo;
            this.lblContactoCedula.ForeColor = Tema.TextoPrincipal;
            this.lblContactoCedula.Location = new System.Drawing.Point(220, 108);
            this.lblContactoCedula.Name = "lblContactoCedula";
            this.lblContactoCedula.Size = new System.Drawing.Size(107, 15);
            this.lblContactoCedula.TabIndex = 13;
            this.lblContactoCedula.Text = "Cédula (opcional)";
            //
            // txtContactoCedula
            //
            this.txtContactoCedula.Font = Tema.FuenteInput;
            this.txtContactoCedula.Location = new System.Drawing.Point(220, 126);
            this.txtContactoCedula.Name = "txtContactoCedula";
            this.txtContactoCedula.Size = new System.Drawing.Size(110, 27);
            this.txtContactoCedula.TabIndex = 14;
            //
            // btnAgregarContacto
            //
            this.btnAgregarContacto.BackColor = Tema.AzulPrimario;
            this.btnAgregarContacto.FlatAppearance.BorderSize = 0;
            this.btnAgregarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContacto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarContacto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarContacto.Location = new System.Drawing.Point(336, 126);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(98, 28);
            this.btnAgregarContacto.TabIndex = 15;
            this.btnAgregarContacto.Text = "+ Agregar";
            this.btnAgregarContacto.UseVisualStyleBackColor = false;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            //
            // lblErrorContacto
            //
            this.lblErrorContacto.AutoSize = true;
            this.lblErrorContacto.Font = Tema.FuenteAyuda;
            this.lblErrorContacto.ForeColor = Tema.Error;
            this.lblErrorContacto.Location = new System.Drawing.Point(16, 156);
            this.lblErrorContacto.Name = "lblErrorContacto";
            this.lblErrorContacto.Size = new System.Drawing.Size(0, 13);
            this.lblErrorContacto.TabIndex = 16;
            //
            // lblSubtituloListaContactos
            //
            this.lblSubtituloListaContactos.AutoSize = true;
            this.lblSubtituloListaContactos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblSubtituloListaContactos.ForeColor = Tema.TextoPrincipal;
            this.lblSubtituloListaContactos.Location = new System.Drawing.Point(16, 172);
            this.lblSubtituloListaContactos.Name = "lblSubtituloListaContactos";
            this.lblSubtituloListaContactos.Size = new System.Drawing.Size(127, 15);
            this.lblSubtituloListaContactos.TabIndex = 17;
            this.lblSubtituloListaContactos.Text = "Contactos agregados:";
            //
            // lblSinContactos
            //
            this.lblSinContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.lblSinContactos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSinContactos.ForeColor = Tema.TextoSecundario;
            this.lblSinContactos.Location = new System.Drawing.Point(16, 192);
            this.lblSinContactos.Name = "lblSinContactos";
            this.lblSinContactos.Size = new System.Drawing.Size(418, 120);
            this.lblSinContactos.TabIndex = 18;
            this.lblSinContactos.Text = "No hay contactos registrados aún.\r\nCompleta los campos arriba y haz clic en \'+ Agregar\'.";
            this.lblSinContactos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dgvContactos.Location = new System.Drawing.Point(16, 192);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.Size = new System.Drawing.Size(418, 120);
            this.dgvContactos.TabIndex = 19;
            this.dgvContactos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactos_CellContentClick);
            //
            // colContNombre
            //
            this.colContNombre.HeaderText = "Nombre";
            this.colContNombre.Name = "colContNombre";
            this.colContNombre.ReadOnly = true;
            this.colContNombre.Width = 120;
            //
            // colContParentesco
            //
            this.colContParentesco.HeaderText = "Parentesco";
            this.colContParentesco.Name = "colContParentesco";
            this.colContParentesco.ReadOnly = true;
            this.colContParentesco.Width = 80;
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
            this.colContCedula.Width = 80;
            //
            // colContQuitar
            //
            this.colContQuitar.HeaderText = "Acción";
            this.colContQuitar.Name = "colContQuitar";
            this.colContQuitar.ReadOnly = true;
            this.colContQuitar.Text = "🗑 Quitar";
            this.colContQuitar.UseColumnTextForButtonValue = true;
            this.colContQuitar.Width = 60;
            //
            // panelAcciones
            //
            this.panelAcciones.Controls.Add(this.btnCancelar);
            this.panelAcciones.Controls.Add(this.btnGuardar);
            this.panelAcciones.Controls.Add(this.lnkVolver);
            this.panelAcciones.Location = new System.Drawing.Point(20, 1000);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(900, 60);
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
            this.btnCancelar.Location = new System.Drawing.Point(540, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 40);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "✕ Cancelar";
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
            this.btnGuardar.Location = new System.Drawing.Point(692, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(194, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "💾 Guardar Paciente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // lnkVolver
            //
            this.lnkVolver.Location = new System.Drawing.Point(0, 0);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(0, 0);
            this.lnkVolver.TabIndex = 2;
            this.lnkVolver.Visible = false;
            //
            // crearPaciente
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.panelFormContenedor);
            this.Controls.Add(this.panelHero);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "crearPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Registro de Paciente";
            this.Load += new System.EventHandler(this.crearPaciente_Load);
            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).EndInit();
            this.panelHeroBloque1.ResumeLayout(false);
            this.panelHeroBloque1.PerformLayout();
            this.panelHeroBloque2.ResumeLayout(false);
            this.panelHeroBloque2.PerformLayout();
            this.panelHeroBloque3.ResumeLayout(false);
            this.panelHeroBloque3.PerformLayout();
            this.panelHeroBloque4.ResumeLayout(false);
            this.panelHeroBloque4.PerformLayout();
            this.panelLema.ResumeLayout(false);
            this.panelLema.PerformLayout();
            this.panelFormContenedor.ResumeLayout(false);
            this.cardHeader.ResumeLayout(false);
            this.cardHeader.PerformLayout();
            this.cardPersonal.ResumeLayout(false);
            this.cardPersonal.PerformLayout();
            this.pnlCedulaInfo.ResumeLayout(false);
            this.cardFoto.ResumeLayout(false);
            this.cardFoto.PerformLayout();
            this.pnlFotoInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.cardUbicacion.ResumeLayout(false);
            this.cardUbicacion.PerformLayout();
            this.cardSalud.ResumeLayout(false);
            this.cardSalud.PerformLayout();
            this.cardEmergencia.ResumeLayout(false);
            this.cardEmergencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.panelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHero;
        private System.Windows.Forms.PictureBox picLogoHero;
        private System.Windows.Forms.Label lblNombreHero;
        private System.Windows.Forms.Label lblSubtituloHero;
        private System.Windows.Forms.Label lblRegistroTituloHero;
        private System.Windows.Forms.Label lblDescripcionHero;
        private System.Windows.Forms.Panel panelHeroBloque1;
        private System.Windows.Forms.Label lblHeroIcono1;
        private System.Windows.Forms.Label lblHeroTitulo1;
        private System.Windows.Forms.Label lblHeroDesc1;
        private System.Windows.Forms.Panel panelHeroBloque2;
        private System.Windows.Forms.Label lblHeroIcono2;
        private System.Windows.Forms.Label lblHeroTitulo2;
        private System.Windows.Forms.Label lblHeroDesc2;
        private System.Windows.Forms.Panel panelHeroBloque3;
        private System.Windows.Forms.Label lblHeroIcono3;
        private System.Windows.Forms.Label lblHeroTitulo3;
        private System.Windows.Forms.Label lblHeroDesc3;
        private System.Windows.Forms.Panel panelHeroBloque4;
        private System.Windows.Forms.Label lblHeroIcono4;
        private System.Windows.Forms.Label lblHeroTitulo4;
        private System.Windows.Forms.Label lblHeroDesc4;
        private System.Windows.Forms.Panel panelLema;
        private System.Windows.Forms.Label lblLemaComillas;
        private System.Windows.Forms.Label lblLemaTexto;
        private System.Windows.Forms.Label lblLemaComillasCierre;

        private System.Windows.Forms.Panel panelFormContenedor;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.Label lblIconoPaciente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBadgeModo;
        private System.Windows.Forms.Label btnModoEditar;

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
        private System.Windows.Forms.Label lblCedulaAyuda;
        private System.Windows.Forms.Panel pnlCedulaInfo;
        private System.Windows.Forms.Label lblCedulaInfo;
        private System.Windows.Forms.Label lblNumeroINSS;
        private System.Windows.Forms.TextBox txtNumeroINSS;
        private System.Windows.Forms.Label lblINSSAyuda;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.ComboBox cmbPaisTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefonoAyuda;
        private System.Windows.Forms.Label lblErrorTelefono;

        private System.Windows.Forms.Panel cardFoto;
        private System.Windows.Forms.Label lblIconoFoto;
        private System.Windows.Forms.Label lblTituloFoto;
        private System.Windows.Forms.Label lblSubtituloFoto;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnQuitarFoto;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Label lblFotoAyuda;
        private System.Windows.Forms.Panel pnlFotoInfo;
        private System.Windows.Forms.Label lblFotoInfo;

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
        private System.Windows.Forms.TextBox txtAlergias;
        private System.Windows.Forms.Label lblAlergiasAyuda;
        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.TextBox txtAntecedentes;
        private System.Windows.Forms.Label lblAntecedentesAyuda;

        private System.Windows.Forms.Panel cardEmergencia;
        private System.Windows.Forms.Label lblIconoEmergencia;
        private System.Windows.Forms.Label lblTituloEmergencia;
        private System.Windows.Forms.Label lblSubtituloEmergencia;
        private System.Windows.Forms.Label lblContactoPrimerNombre;
        private System.Windows.Forms.TextBox txtContactoPrimerNombre;
        private System.Windows.Forms.TextBox txtContactoSegundoNombre;
        private System.Windows.Forms.Label lblContactoPrimerApellido;
        private System.Windows.Forms.TextBox txtContactoPrimerApellido;
        private System.Windows.Forms.TextBox txtContactoSegundoApellido;
        private System.Windows.Forms.Label lblContactoParentesco;
        private System.Windows.Forms.ComboBox cmbContactoParentesco;
        private System.Windows.Forms.Label lblContactoTelefono;
        private System.Windows.Forms.TextBox txtContactoTelefono;
        private System.Windows.Forms.Label lblContactoCedula;
        private System.Windows.Forms.TextBox txtContactoCedula;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.Label lblErrorContacto;
        private System.Windows.Forms.Label lblSubtituloListaContactos;
        private System.Windows.Forms.Label lblSinContactos;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContCedula;
        private System.Windows.Forms.DataGridViewButtonColumn colContQuitar;

        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}
