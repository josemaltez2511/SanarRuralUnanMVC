using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class crearDoctor
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
            this.panelLema = new System.Windows.Forms.Panel();
            this.lblLemaComillas = new System.Windows.Forms.Label();
            this.lblLemaTexto = new System.Windows.Forms.Label();
            this.lblLemaComillasCierre = new System.Windows.Forms.Label();
            this.panelFormContenedor = new System.Windows.Forms.Panel();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.lblIconoDoctor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.cardPersonal = new System.Windows.Forms.Panel();
            this.lblIconoPersonal = new System.Windows.Forms.Label();
            this.lblTituloPersonal = new System.Windows.Forms.Label();
            this.lblSubtituloPersonal = new System.Windows.Forms.Label();
            this.lblPrimerNombre = new System.Windows.Forms.Label();
            this.txtPrimerNombre = new System.Windows.Forms.TextBox();
            this.lblSegundoNombre = new System.Windows.Forms.Label();
            this.txtSegundoNombre = new System.Windows.Forms.TextBox();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedulaAyuda = new System.Windows.Forms.Label();
            this.pnlCedulaInfo = new System.Windows.Forms.Panel();
            this.lblCedulaInfo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cmbPaisTelefono = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefonoAyuda = new System.Windows.Forms.Label();
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
            this.cardProfesional = new System.Windows.Forms.Panel();
            this.lblIconoProfesional = new System.Windows.Forms.Label();
            this.lblTituloProfesional = new System.Windows.Forms.Label();
            this.lblSubtituloProfesional = new System.Windows.Forms.Label();
            this.lblNumeroLicencia = new System.Windows.Forms.Label();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.lblLicenciaAyuda = new System.Windows.Forms.Label();
            this.pnlLicenciaInfo = new System.Windows.Forms.Panel();
            this.lblLicenciaInfo = new System.Windows.Forms.Label();
            this.lblEspecialidadesTitulo = new System.Windows.Forms.Label();
            this.lstEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.cardAsignaciones = new System.Windows.Forms.Panel();
            this.lblIconoAsignaciones = new System.Windows.Forms.Label();
            this.lblTituloAsignaciones = new System.Windows.Forms.Label();
            this.lblSubtituloAsignaciones = new System.Windows.Forms.Label();
            this.lblHospitalTitulo = new System.Windows.Forms.Label();
            this.cmbHospitalAsignacion = new System.Windows.Forms.ComboBox();
            this.lblEspecialidadHospTitulo = new System.Windows.Forms.Label();
            this.cmbEspecialidadHospital = new System.Windows.Forms.ComboBox();
            this.btnAgregarAsignacion = new System.Windows.Forms.Button();
            this.lblAsignacionesTitulo = new System.Windows.Forms.Label();
            this.lstAsignaciones = new System.Windows.Forms.ListBox();
            this.btnQuitarAsignacion = new System.Windows.Forms.Button();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).BeginInit();
            this.panelHeroBloque1.SuspendLayout();
            this.panelHeroBloque2.SuspendLayout();
            this.panelHeroBloque3.SuspendLayout();
            this.panelLema.SuspendLayout();
            this.panelFormContenedor.SuspendLayout();
            this.cardHeader.SuspendLayout();
            this.cardPersonal.SuspendLayout();
            this.pnlCedulaInfo.SuspendLayout();
            this.cardFoto.SuspendLayout();
            this.pnlFotoInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.cardProfesional.SuspendLayout();
            this.pnlLicenciaInfo.SuspendLayout();
            this.cardAsignaciones.SuspendLayout();
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
            this.panelHero.Controls.Add(this.panelLema);
            this.panelHero.Location = new System.Drawing.Point(0, 0);
            this.panelHero.Name = "panelHero";
            this.panelHero.Size = new System.Drawing.Size(350, 760);
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
            this.lblRegistroTituloHero.Size = new System.Drawing.Size(185, 28);
            this.lblRegistroTituloHero.TabIndex = 3;
            this.lblRegistroTituloHero.Text = "Registro de Doctor";
            //
            // lblDescripcionHero
            //
            this.lblDescripcionHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F, System.Drawing.FontStyle.Regular);
            this.lblDescripcionHero.ForeColor = Tema.TextoSecundario;
            this.lblDescripcionHero.Location = new System.Drawing.Point(28, 202);
            this.lblDescripcionHero.Name = "lblDescripcionHero";
            this.lblDescripcionHero.Size = new System.Drawing.Size(290, 48);
            this.lblDescripcionHero.TabIndex = 4;
            this.lblDescripcionHero.Text = "Registra los datos profesionales para formar parte del equipo médico y brindar atención a nuestras comunidades rurales.";
            //
            // panelHeroBloque1
            //
            this.panelHeroBloque1.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroBloque1.Controls.Add(this.lblHeroIcono1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroTitulo1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroDesc1);
            this.panelHeroBloque1.Location = new System.Drawing.Point(28, 258);
            this.panelHeroBloque1.Name = "panelHeroBloque1";
            this.panelHeroBloque1.Size = new System.Drawing.Size(290, 52);
            this.panelHeroBloque1.TabIndex = 5;
            //
            // lblHeroIcono1
            //
            this.lblHeroIcono1.BackColor = System.Drawing.Color.Transparent;
            this.lblHeroIcono1.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblHeroIcono1.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono1.Location = new System.Drawing.Point(4, 6);
            this.lblHeroIcono1.Name = "lblHeroIcono1";
            this.lblHeroIcono1.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono1.TabIndex = 0;
            this.lblHeroIcono1.Text = "👤";
            this.lblHeroIcono1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo1
            //
            this.lblHeroTitulo1.AutoSize = true;
            this.lblHeroTitulo1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo1.ForeColor = Tema.AzulOscuro;
            this.lblHeroTitulo1.Location = new System.Drawing.Point(46, 6);
            this.lblHeroTitulo1.Name = "lblHeroTitulo1";
            this.lblHeroTitulo1.Size = new System.Drawing.Size(123, 19);
            this.lblHeroTitulo1.TabIndex = 1;
            this.lblHeroTitulo1.Text = "Perfil profesional";
            //
            // lblHeroDesc1
            //
            this.lblHeroDesc1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblHeroDesc1.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc1.Location = new System.Drawing.Point(46, 26);
            this.lblHeroDesc1.Name = "lblHeroDesc1";
            this.lblHeroDesc1.Size = new System.Drawing.Size(235, 24);
            this.lblHeroDesc1.TabIndex = 2;
            this.lblHeroDesc1.Text = "Completa tu información personal y profesional.";
            //
            // panelHeroBloque2
            //
            this.panelHeroBloque2.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroBloque2.Controls.Add(this.lblHeroIcono2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroTitulo2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroDesc2);
            this.panelHeroBloque2.Location = new System.Drawing.Point(28, 316);
            this.panelHeroBloque2.Name = "panelHeroBloque2";
            this.panelHeroBloque2.Size = new System.Drawing.Size(290, 52);
            this.panelHeroBloque2.TabIndex = 6;
            //
            // lblHeroIcono2
            //
            this.lblHeroIcono2.BackColor = System.Drawing.Color.Transparent;
            this.lblHeroIcono2.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblHeroIcono2.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono2.Location = new System.Drawing.Point(4, 6);
            this.lblHeroIcono2.Name = "lblHeroIcono2";
            this.lblHeroIcono2.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono2.TabIndex = 0;
            this.lblHeroIcono2.Text = "🩺";
            this.lblHeroIcono2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo2
            //
            this.lblHeroTitulo2.AutoSize = true;
            this.lblHeroTitulo2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo2.ForeColor = Tema.AzulOscuro;
            this.lblHeroTitulo2.Location = new System.Drawing.Point(46, 6);
            this.lblHeroTitulo2.Name = "lblHeroTitulo2";
            this.lblHeroTitulo2.Size = new System.Drawing.Size(104, 19);
            this.lblHeroTitulo2.TabIndex = 1;
            this.lblHeroTitulo2.Text = "Especialidades";
            //
            // lblHeroDesc2
            //
            this.lblHeroDesc2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblHeroDesc2.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc2.Location = new System.Drawing.Point(46, 26);
            this.lblHeroDesc2.Name = "lblHeroDesc2";
            this.lblHeroDesc2.Size = new System.Drawing.Size(235, 24);
            this.lblHeroDesc2.TabIndex = 2;
            this.lblHeroDesc2.Text = "Selecciona las áreas de especialidad del profesional.";
            //
            // panelHeroBloque3
            //
            this.panelHeroBloque3.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroBloque3.Controls.Add(this.lblHeroIcono3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroTitulo3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroDesc3);
            this.panelHeroBloque3.Location = new System.Drawing.Point(28, 374);
            this.panelHeroBloque3.Name = "panelHeroBloque3";
            this.panelHeroBloque3.Size = new System.Drawing.Size(290, 52);
            this.panelHeroBloque3.TabIndex = 7;
            //
            // lblHeroIcono3
            //
            this.lblHeroIcono3.BackColor = System.Drawing.Color.Transparent;
            this.lblHeroIcono3.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblHeroIcono3.ForeColor = Tema.AzulPrimario;
            this.lblHeroIcono3.Location = new System.Drawing.Point(4, 6);
            this.lblHeroIcono3.Name = "lblHeroIcono3";
            this.lblHeroIcono3.Size = new System.Drawing.Size(36, 36);
            this.lblHeroIcono3.TabIndex = 0;
            this.lblHeroIcono3.Text = "🏥";
            this.lblHeroIcono3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo3
            //
            this.lblHeroTitulo3.AutoSize = true;
            this.lblHeroTitulo3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo3.ForeColor = Tema.AzulOscuro;
            this.lblHeroTitulo3.Location = new System.Drawing.Point(46, 6);
            this.lblHeroTitulo3.Name = "lblHeroTitulo3";
            this.lblHeroTitulo3.Size = new System.Drawing.Size(95, 19);
            this.lblHeroTitulo3.TabIndex = 1;
            this.lblHeroTitulo3.Text = "Asignaciones";
            //
            // lblHeroDesc3
            //
            this.lblHeroDesc3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblHeroDesc3.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc3.Location = new System.Drawing.Point(46, 26);
            this.lblHeroDesc3.Name = "lblHeroDesc3";
            this.lblHeroDesc3.Size = new System.Drawing.Size(235, 24);
            this.lblHeroDesc3.TabIndex = 2;
            this.lblHeroDesc3.Text = "Relaciona los hospitales y especialidades donde ejerce.";
            //
            // panelLema
            //
            this.panelLema.BackColor = Tema.Superficie;
            this.panelLema.Controls.Add(this.lblLemaComillas);
            this.panelLema.Controls.Add(this.lblLemaTexto);
            this.panelLema.Controls.Add(this.lblLemaComillasCierre);
            this.panelLema.Location = new System.Drawing.Point(28, 680);
            this.panelLema.Name = "panelLema";
            this.panelLema.Size = new System.Drawing.Size(290, 56);
            this.panelLema.TabIndex = 8;
            //
            // lblLemaComillas
            //
            this.lblLemaComillas.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillas.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillas.Location = new System.Drawing.Point(6, 6);
            this.lblLemaComillas.Name = "lblLemaComillas";
            this.lblLemaComillas.Size = new System.Drawing.Size(28, 40);
            this.lblLemaComillas.TabIndex = 0;
            this.lblLemaComillas.Text = "“";
            this.lblLemaComillas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblLemaTexto
            //
            this.lblLemaTexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLemaTexto.ForeColor = Tema.AzulOscuro;
            this.lblLemaTexto.Location = new System.Drawing.Point(36, 8);
            this.lblLemaTexto.Name = "lblLemaTexto";
            this.lblLemaTexto.Size = new System.Drawing.Size(218, 40);
            this.lblLemaTexto.TabIndex = 1;
            this.lblLemaTexto.Text = "Salud más cerca de nuestra gente";
            this.lblLemaTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblLemaComillasCierre
            //
            this.lblLemaComillasCierre.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillasCierre.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillasCierre.Location = new System.Drawing.Point(256, 12);
            this.lblLemaComillasCierre.Name = "lblLemaComillasCierre";
            this.lblLemaComillasCierre.Size = new System.Drawing.Size(28, 40);
            this.lblLemaComillasCierre.TabIndex = 2;
            this.lblLemaComillasCierre.Text = "”";
            this.lblLemaComillasCierre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelFormContenedor
            //
            this.panelFormContenedor.AutoScroll = true;
            this.panelFormContenedor.BackColor = Tema.Fondo;
            this.panelFormContenedor.Controls.Add(this.cardHeader);
            this.panelFormContenedor.Controls.Add(this.cardPersonal);
            this.panelFormContenedor.Controls.Add(this.cardFoto);
            this.panelFormContenedor.Controls.Add(this.cardProfesional);
            this.panelFormContenedor.Controls.Add(this.cardAsignaciones);
            this.panelFormContenedor.Controls.Add(this.panelAcciones);
            this.panelFormContenedor.Location = new System.Drawing.Point(350, 0);
            this.panelFormContenedor.Name = "panelFormContenedor";
            this.panelFormContenedor.Size = new System.Drawing.Size(800, 760);
            this.panelFormContenedor.TabIndex = 1;
            //
            // cardHeader
            //
            this.cardHeader.BackColor = Tema.Superficie;
            this.cardHeader.Controls.Add(this.lblIconoDoctor);
            this.cardHeader.Controls.Add(this.lblTitulo);
            this.cardHeader.Controls.Add(this.lblSubtitulo);
            this.cardHeader.Location = new System.Drawing.Point(20, 16);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Size = new System.Drawing.Size(750, 66);
            this.cardHeader.TabIndex = 0;
            //
            // lblIconoDoctor
            //
            this.lblIconoDoctor.BackColor = Tema.AzulPrimario;
            this.lblIconoDoctor.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblIconoDoctor.ForeColor = System.Drawing.Color.White;
            this.lblIconoDoctor.Location = new System.Drawing.Point(16, 13);
            this.lblIconoDoctor.Name = "lblIconoDoctor";
            this.lblIconoDoctor.Size = new System.Drawing.Size(40, 40);
            this.lblIconoDoctor.TabIndex = 0;
            this.lblIconoDoctor.Text = "👨‍⚕️";
            this.lblIconoDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(64, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(183, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Datos del Doctor";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(66, 37);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(202, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Completa la información requerida";
            //
            // cardPersonal
            //
            this.cardPersonal.BackColor = Tema.Superficie;
            this.cardPersonal.Controls.Add(this.lblIconoPersonal);
            this.cardPersonal.Controls.Add(this.lblTituloPersonal);
            this.cardPersonal.Controls.Add(this.lblSubtituloPersonal);
            this.cardPersonal.Controls.Add(this.lblPrimerNombre);
            this.cardPersonal.Controls.Add(this.txtPrimerNombre);
            this.cardPersonal.Controls.Add(this.lblSegundoNombre);
            this.cardPersonal.Controls.Add(this.txtSegundoNombre);
            this.cardPersonal.Controls.Add(this.lblPrimerApellido);
            this.cardPersonal.Controls.Add(this.txtPrimerApellido);
            this.cardPersonal.Controls.Add(this.lblSegundoApellido);
            this.cardPersonal.Controls.Add(this.txtSegundoApellido);
            this.cardPersonal.Controls.Add(this.lblCedula);
            this.cardPersonal.Controls.Add(this.txtCedula);
            this.cardPersonal.Controls.Add(this.lblCedulaAyuda);
            this.cardPersonal.Controls.Add(this.pnlCedulaInfo);
            this.cardPersonal.Controls.Add(this.lblTelefono);
            this.cardPersonal.Controls.Add(this.cmbPaisTelefono);
            this.cardPersonal.Controls.Add(this.txtTelefono);
            this.cardPersonal.Controls.Add(this.lblTelefonoAyuda);
            this.cardPersonal.Location = new System.Drawing.Point(20, 94);
            this.cardPersonal.Name = "cardPersonal";
            this.cardPersonal.Size = new System.Drawing.Size(500, 290);
            this.cardPersonal.TabIndex = 1;
            //
            // lblIconoPersonal
            //
            this.lblIconoPersonal.BackColor = Tema.AzulPrimario;
            this.lblIconoPersonal.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblIconoPersonal.ForeColor = System.Drawing.Color.White;
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
            this.lblTituloPersonal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloPersonal.ForeColor = Tema.AzulOscuro;
            this.lblTituloPersonal.Location = new System.Drawing.Point(54, 10);
            this.lblTituloPersonal.Name = "lblTituloPersonal";
            this.lblTituloPersonal.Size = new System.Drawing.Size(163, 21);
            this.lblTituloPersonal.TabIndex = 1;
            this.lblTituloPersonal.Text = "Información personal";
            //
            // lblSubtituloPersonal
            //
            this.lblSubtituloPersonal.AutoSize = true;
            this.lblSubtituloPersonal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloPersonal.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloPersonal.Location = new System.Drawing.Point(56, 30);
            this.lblSubtituloPersonal.Name = "lblSubtituloPersonal";
            this.lblSubtituloPersonal.Size = new System.Drawing.Size(248, 15);
            this.lblSubtituloPersonal.TabIndex = 2;
            this.lblSubtituloPersonal.Text = "Datos de identificación y contacto del profesional.";
            //
            // lblPrimerNombre
            //
            this.lblPrimerNombre.AutoSize = true;
            this.lblPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerNombre.Location = new System.Drawing.Point(16, 56);
            this.lblPrimerNombre.Name = "lblPrimerNombre";
            this.lblPrimerNombre.Size = new System.Drawing.Size(107, 17);
            this.lblPrimerNombre.TabIndex = 3;
            this.lblPrimerNombre.Text = "Primer nombre *";
            //
            // txtPrimerNombre
            //
            this.txtPrimerNombre.Font = Tema.FuenteInput;
            this.txtPrimerNombre.Location = new System.Drawing.Point(16, 74);
            this.txtPrimerNombre.MaxLength = 50;
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Size = new System.Drawing.Size(220, 27);
            this.txtPrimerNombre.TabIndex = 1;
            //
            // lblSegundoNombre
            //
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Font = Tema.FuenteLabelCampo;
            this.lblSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoNombre.Location = new System.Drawing.Point(250, 56);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(116, 17);
            this.lblSegundoNombre.TabIndex = 4;
            this.lblSegundoNombre.Text = "Segundo nombre";
            //
            // txtSegundoNombre
            //
            this.txtSegundoNombre.Font = Tema.FuenteInput;
            this.txtSegundoNombre.Location = new System.Drawing.Point(250, 74);
            this.txtSegundoNombre.MaxLength = 50;
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(220, 27);
            this.txtSegundoNombre.TabIndex = 2;
            //
            // lblPrimerApellido
            //
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = Tema.FuenteLabelCampo;
            this.lblPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerApellido.Location = new System.Drawing.Point(16, 108);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(108, 17);
            this.lblPrimerApellido.TabIndex = 5;
            this.lblPrimerApellido.Text = "Primer apellido *";
            //
            // txtPrimerApellido
            //
            this.txtPrimerApellido.Font = Tema.FuenteInput;
            this.txtPrimerApellido.Location = new System.Drawing.Point(16, 126);
            this.txtPrimerApellido.MaxLength = 50;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(220, 27);
            this.txtPrimerApellido.TabIndex = 3;
            //
            // lblSegundoApellido
            //
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = Tema.FuenteLabelCampo;
            this.lblSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoApellido.Location = new System.Drawing.Point(250, 108);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(117, 17);
            this.lblSegundoApellido.TabIndex = 6;
            this.lblSegundoApellido.Text = "Segundo apellido";
            //
            // txtSegundoApellido
            //
            this.txtSegundoApellido.Font = Tema.FuenteInput;
            this.txtSegundoApellido.Location = new System.Drawing.Point(250, 126);
            this.txtSegundoApellido.MaxLength = 50;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(220, 27);
            this.txtSegundoApellido.TabIndex = 4;
            //
            // lblCedula
            //
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = Tema.FuenteLabelCampo;
            this.lblCedula.ForeColor = Tema.TextoPrincipal;
            this.lblCedula.Location = new System.Drawing.Point(16, 160);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(58, 17);
            this.lblCedula.TabIndex = 7;
            this.lblCedula.Text = "Cédula *";
            //
            // txtCedula
            //
            this.txtCedula.AccessibleDescription = "Cédula de identidad en formato tradicional o formato oficial";
            this.txtCedula.AccessibleName = "Cédula del doctor";
            this.txtCedula.Font = Tema.FuenteInput;
            this.txtCedula.Location = new System.Drawing.Point(16, 178);
            this.txtCedula.MaxLength = 20;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(220, 27);
            this.txtCedula.TabIndex = 5;
            //
            // lblCedulaAyuda
            //
            this.lblCedulaAyuda.AutoSize = true;
            this.lblCedulaAyuda.Font = Tema.FuenteAyuda;
            this.lblCedulaAyuda.ForeColor = Tema.TextoSecundario;
            this.lblCedulaAyuda.Location = new System.Drawing.Point(16, 208);
            this.lblCedulaAyuda.Name = "lblCedulaAyuda";
            this.lblCedulaAyuda.Size = new System.Drawing.Size(155, 15);
            this.lblCedulaAyuda.TabIndex = 8;
            this.lblCedulaAyuda.Text = "Ejemplo: 001-091101-1042V";
            //
            // pnlCedulaInfo
            //
            this.pnlCedulaInfo.BackColor = System.Drawing.Color.FromArgb(235, 245, 252);
            this.pnlCedulaInfo.Controls.Add(this.lblCedulaInfo);
            this.pnlCedulaInfo.Location = new System.Drawing.Point(16, 226);
            this.pnlCedulaInfo.Name = "pnlCedulaInfo";
            this.pnlCedulaInfo.Size = new System.Drawing.Size(220, 48);
            this.pnlCedulaInfo.TabIndex = 9;
            //
            // lblCedulaInfo
            //
            this.lblCedulaInfo.Font = Tema.FuenteAyuda;
            this.lblCedulaInfo.ForeColor = Tema.AzulOscuro;
            this.lblCedulaInfo.Location = new System.Drawing.Point(6, 4);
            this.lblCedulaInfo.Name = "lblCedulaInfo";
            this.lblCedulaInfo.Size = new System.Drawing.Size(208, 40);
            this.lblCedulaInfo.TabIndex = 0;
            this.lblCedulaInfo.Text = "ℹ Puedes escribir la cédula con o sin guiones. El formato se ajustará automáticamente.";
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(250, 160);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(69, 17);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono *";
            //
            // cmbPaisTelefono
            //
            this.cmbPaisTelefono.AccessibleDescription = "Prefijo internacional de países centroamericanos";
            this.cmbPaisTelefono.AccessibleName = "Selector de código de país";
            this.cmbPaisTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaisTelefono.Font = Tema.FuenteInput;
            this.cmbPaisTelefono.FormattingEnabled = true;
            this.cmbPaisTelefono.Location = new System.Drawing.Point(250, 178);
            this.cmbPaisTelefono.Name = "cmbPaisTelefono";
            this.cmbPaisTelefono.Size = new System.Drawing.Size(120, 27);
            this.cmbPaisTelefono.TabIndex = 6;
            //
            // txtTelefono
            //
            this.txtTelefono.AccessibleDescription = "Número de teléfono nacional";
            this.txtTelefono.AccessibleName = "Número de teléfono";
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(375, 178);
            this.txtTelefono.MaxLength = 15;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(95, 27);
            this.txtTelefono.TabIndex = 7;
            //
            // lblTelefonoAyuda
            //
            this.lblTelefonoAyuda.Font = Tema.FuenteAyuda;
            this.lblTelefonoAyuda.ForeColor = Tema.TextoSecundario;
            this.lblTelefonoAyuda.Location = new System.Drawing.Point(250, 208);
            this.lblTelefonoAyuda.Name = "lblTelefonoAyuda";
            this.lblTelefonoAyuda.Size = new System.Drawing.Size(220, 66);
            this.lblTelefonoAyuda.TabIndex = 11;
            this.lblTelefonoAyuda.Text = "Ingresa solo el número de teléfono (sin el código de país). Ejemplo: 8888-2222";
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
            this.cardFoto.Location = new System.Drawing.Point(530, 94);
            this.cardFoto.Name = "cardFoto";
            this.cardFoto.Size = new System.Drawing.Size(240, 290);
            this.cardFoto.TabIndex = 2;
            //
            // lblIconoFoto
            //
            this.lblIconoFoto.BackColor = Tema.AzulPrimario;
            this.lblIconoFoto.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblIconoFoto.ForeColor = System.Drawing.Color.White;
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
            this.lblTituloFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloFoto.ForeColor = Tema.AzulOscuro;
            this.lblTituloFoto.Location = new System.Drawing.Point(54, 10);
            this.lblTituloFoto.Name = "lblTituloFoto";
            this.lblTituloFoto.Size = new System.Drawing.Size(117, 21);
            this.lblTituloFoto.TabIndex = 1;
            this.lblTituloFoto.Text = "Foto del doctor";
            //
            // lblSubtituloFoto
            //
            this.lblSubtituloFoto.AutoSize = true;
            this.lblSubtituloFoto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloFoto.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloFoto.Location = new System.Drawing.Point(56, 30);
            this.lblSubtituloFoto.Name = "lblSubtituloFoto";
            this.lblSubtituloFoto.Size = new System.Drawing.Size(125, 15);
            this.lblSubtituloFoto.TabIndex = 2;
            this.lblSubtituloFoto.Text = "Foto de perfil (opcional).";
            //
            // picPreview
            //
            this.picPreview.AccessibleName = "Vista previa de la foto del doctor";
            this.picPreview.BackColor = System.Drawing.Color.Transparent;
            this.picPreview.Location = new System.Drawing.Point(16, 56);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(82, 82);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 3;
            this.picPreview.TabStop = false;
            //
            // btnSeleccionarFoto
            //
            this.btnSeleccionarFoto.BackColor = Tema.AzulPrimario;
            this.btnSeleccionarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarFoto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFoto.Font = Tema.FuenteBoton;
            this.btnSeleccionarFoto.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(108, 56);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(120, 30);
            this.btnSeleccionarFoto.TabIndex = 8;
            this.btnSeleccionarFoto.Text = "Seleccionar foto";
            this.btnSeleccionarFoto.UseVisualStyleBackColor = false;
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);
            //
            // btnQuitarFoto
            //
            this.btnQuitarFoto.BackColor = Tema.BotonPeligroFondo;
            this.btnQuitarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFoto.FlatAppearance.BorderColor = Tema.BotonPeligroBorde;
            this.btnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.Font = Tema.FuenteAyuda;
            this.btnQuitarFoto.ForeColor = Tema.Error;
            this.btnQuitarFoto.Location = new System.Drawing.Point(108, 90);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Size = new System.Drawing.Size(65, 26);
            this.btnQuitarFoto.TabIndex = 9;
            this.btnQuitarFoto.Text = "Quitar";
            this.btnQuitarFoto.UseVisualStyleBackColor = false;
            this.btnQuitarFoto.Visible = false;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            //
            // lblFoto
            //
            this.lblFoto.AutoEllipsis = true;
            this.lblFoto.Font = Tema.FuenteAyuda;
            this.lblFoto.ForeColor = Tema.TextoSecundario;
            this.lblFoto.Location = new System.Drawing.Point(108, 120);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(120, 16);
            this.lblFoto.TabIndex = 4;
            this.lblFoto.Text = "Sin foto seleccionada";
            //
            // lblFotoAyuda
            //
            this.lblFotoAyuda.AutoSize = true;
            this.lblFotoAyuda.Font = Tema.FuenteAyuda;
            this.lblFotoAyuda.ForeColor = Tema.TextoSecundario;
            this.lblFotoAyuda.Location = new System.Drawing.Point(108, 140);
            this.lblFotoAyuda.Name = "lblFotoAyuda";
            this.lblFotoAyuda.Size = new System.Drawing.Size(126, 15);
            this.lblFotoAyuda.TabIndex = 5;
            this.lblFotoAyuda.Text = "JPG, PNG (máx. 2 MB)";
            //
            // pnlFotoInfo
            //
            this.pnlFotoInfo.BackColor = System.Drawing.Color.FromArgb(235, 245, 252);
            this.pnlFotoInfo.Controls.Add(this.lblFotoInfo);
            this.pnlFotoInfo.Location = new System.Drawing.Point(16, 226);
            this.pnlFotoInfo.Name = "pnlFotoInfo";
            this.pnlFotoInfo.Size = new System.Drawing.Size(208, 48);
            this.pnlFotoInfo.TabIndex = 6;
            //
            // lblFotoInfo
            //
            this.lblFotoInfo.Font = Tema.FuenteAyuda;
            this.lblFotoInfo.ForeColor = Tema.AzulOscuro;
            this.lblFotoInfo.Location = new System.Drawing.Point(6, 4);
            this.lblFotoInfo.Name = "lblFotoInfo";
            this.lblFotoInfo.Size = new System.Drawing.Size(196, 40);
            this.lblFotoInfo.TabIndex = 0;
            this.lblFotoInfo.Text = "ℹ La foto ayuda a identificar al profesional en el sistema.";
            //
            // cardProfesional
            //
            this.cardProfesional.BackColor = Tema.Superficie;
            this.cardProfesional.Controls.Add(this.lblIconoProfesional);
            this.cardProfesional.Controls.Add(this.lblTituloProfesional);
            this.cardProfesional.Controls.Add(this.lblSubtituloProfesional);
            this.cardProfesional.Controls.Add(this.lblNumeroLicencia);
            this.cardProfesional.Controls.Add(this.txtLicencia);
            this.cardProfesional.Controls.Add(this.lblLicenciaAyuda);
            this.cardProfesional.Controls.Add(this.pnlLicenciaInfo);
            this.cardProfesional.Controls.Add(this.lblEspecialidadesTitulo);
            this.cardProfesional.Controls.Add(this.lstEspecialidades);
            this.cardProfesional.Location = new System.Drawing.Point(20, 396);
            this.cardProfesional.Name = "cardProfesional";
            this.cardProfesional.Size = new System.Drawing.Size(750, 215);
            this.cardProfesional.TabIndex = 3;
            //
            // lblIconoProfesional
            //
            this.lblIconoProfesional.BackColor = Tema.AzulPrimario;
            this.lblIconoProfesional.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblIconoProfesional.ForeColor = System.Drawing.Color.White;
            this.lblIconoProfesional.Location = new System.Drawing.Point(14, 12);
            this.lblIconoProfesional.Name = "lblIconoProfesional";
            this.lblIconoProfesional.Size = new System.Drawing.Size(34, 34);
            this.lblIconoProfesional.TabIndex = 0;
            this.lblIconoProfesional.Text = "📄";
            this.lblIconoProfesional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloProfesional
            //
            this.lblTituloProfesional.AutoSize = true;
            this.lblTituloProfesional.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloProfesional.ForeColor = Tema.AzulOscuro;
            this.lblTituloProfesional.Location = new System.Drawing.Point(54, 10);
            this.lblTituloProfesional.Name = "lblTituloProfesional";
            this.lblTituloProfesional.Size = new System.Drawing.Size(183, 21);
            this.lblTituloProfesional.TabIndex = 1;
            this.lblTituloProfesional.Text = "Información profesional";
            //
            // lblSubtituloProfesional
            //
            this.lblSubtituloProfesional.AutoSize = true;
            this.lblSubtituloProfesional.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloProfesional.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloProfesional.Location = new System.Drawing.Point(56, 30);
            this.lblSubtituloProfesional.Name = "lblSubtituloProfesional";
            this.lblSubtituloProfesional.Size = new System.Drawing.Size(183, 15);
            this.lblSubtituloProfesional.TabIndex = 2;
            this.lblSubtituloProfesional.Text = "Datos de licencia y especialidades.";
            //
            // lblNumeroLicencia
            //
            this.lblNumeroLicencia.AutoSize = true;
            this.lblNumeroLicencia.Font = Tema.FuenteLabelCampo;
            this.lblNumeroLicencia.ForeColor = Tema.TextoPrincipal;
            this.lblNumeroLicencia.Location = new System.Drawing.Point(16, 56);
            this.lblNumeroLicencia.Name = "lblNumeroLicencia";
            this.lblNumeroLicencia.Size = new System.Drawing.Size(232, 17);
            this.lblNumeroLicencia.TabIndex = 3;
            this.lblNumeroLicencia.Text = "Código sanitario / registro MINSA *";
            //
            // txtLicencia
            //
            this.txtLicencia.AccessibleDescription = "Código sanitario o número de registro profesional otorgado por el MINSA";
            this.txtLicencia.AccessibleName = "Código sanitario o registro MINSA";
            this.txtLicencia.Font = Tema.FuenteInput;
            this.txtLicencia.Location = new System.Drawing.Point(16, 74);
            this.txtLicencia.MaxLength = 50;
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(320, 27);
            this.txtLicencia.TabIndex = 10;
            //
            // lblLicenciaAyuda
            //
            this.lblLicenciaAyuda.Font = Tema.FuenteAyuda;
            this.lblLicenciaAyuda.ForeColor = Tema.TextoSecundario;
            this.lblLicenciaAyuda.Location = new System.Drawing.Point(16, 104);
            this.lblLicenciaAyuda.Name = "lblLicenciaAyuda";
            this.lblLicenciaAyuda.Size = new System.Drawing.Size(320, 32);
            this.lblLicenciaAyuda.TabIndex = 4;
            this.lblLicenciaAyuda.Text = "Escribe el código tal como aparece en tu carnet o constancia oficial del MINSA.";
            //
            // pnlLicenciaInfo
            //
            this.pnlLicenciaInfo.BackColor = System.Drawing.Color.FromArgb(235, 245, 252);
            this.pnlLicenciaInfo.Controls.Add(this.lblLicenciaInfo);
            this.pnlLicenciaInfo.Location = new System.Drawing.Point(16, 142);
            this.pnlLicenciaInfo.Name = "pnlLicenciaInfo";
            this.pnlLicenciaInfo.Size = new System.Drawing.Size(320, 48);
            this.pnlLicenciaInfo.TabIndex = 5;
            //
            // lblLicenciaInfo
            //
            this.lblLicenciaInfo.Font = Tema.FuenteAyuda;
            this.lblLicenciaInfo.ForeColor = Tema.AzulOscuro;
            this.lblLicenciaInfo.Location = new System.Drawing.Point(6, 4);
            this.lblLicenciaInfo.Name = "lblLicenciaInfo";
            this.lblLicenciaInfo.Size = new System.Drawing.Size(308, 40);
            this.lblLicenciaInfo.TabIndex = 0;
            this.lblLicenciaInfo.Text = "ℹ Utiliza el código oficial asignado al profesional de la salud por el MINSA.";
            //
            // lblEspecialidadesTitulo
            //
            this.lblEspecialidadesTitulo.AutoSize = true;
            this.lblEspecialidadesTitulo.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidadesTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidadesTitulo.Location = new System.Drawing.Point(360, 56);
            this.lblEspecialidadesTitulo.Name = "lblEspecialidadesTitulo";
            this.lblEspecialidadesTitulo.Size = new System.Drawing.Size(251, 17);
            this.lblEspecialidadesTitulo.TabIndex = 6;
            this.lblEspecialidadesTitulo.Text = "Especialidades * (puede elegir varias)";
            //
            // lstEspecialidades
            //
            this.lstEspecialidades.CheckOnClick = true;
            this.lstEspecialidades.Font = Tema.FuenteCuerpo;
            this.lstEspecialidades.FormattingEnabled = true;
            this.lstEspecialidades.Location = new System.Drawing.Point(360, 74);
            this.lstEspecialidades.Name = "lstEspecialidades";
            this.lstEspecialidades.Size = new System.Drawing.Size(370, 126);
            this.lstEspecialidades.TabIndex = 11;
            //
            // cardAsignaciones
            //
            this.cardAsignaciones.BackColor = Tema.Superficie;
            this.cardAsignaciones.Controls.Add(this.lblIconoAsignaciones);
            this.cardAsignaciones.Controls.Add(this.lblTituloAsignaciones);
            this.cardAsignaciones.Controls.Add(this.lblSubtituloAsignaciones);
            this.cardAsignaciones.Controls.Add(this.lblHospitalTitulo);
            this.cardAsignaciones.Controls.Add(this.cmbHospitalAsignacion);
            this.cardAsignaciones.Controls.Add(this.lblEspecialidadHospTitulo);
            this.cardAsignaciones.Controls.Add(this.cmbEspecialidadHospital);
            this.cardAsignaciones.Controls.Add(this.btnAgregarAsignacion);
            this.cardAsignaciones.Controls.Add(this.lblAsignacionesTitulo);
            this.cardAsignaciones.Controls.Add(this.lstAsignaciones);
            this.cardAsignaciones.Controls.Add(this.btnQuitarAsignacion);
            this.cardAsignaciones.Location = new System.Drawing.Point(20, 620);
            this.cardAsignaciones.Name = "cardAsignaciones";
            this.cardAsignaciones.Size = new System.Drawing.Size(750, 230);
            this.cardAsignaciones.TabIndex = 4;
            //
            // lblIconoAsignaciones
            //
            this.lblIconoAsignaciones.BackColor = Tema.AzulPrimario;
            this.lblIconoAsignaciones.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblIconoAsignaciones.ForeColor = System.Drawing.Color.White;
            this.lblIconoAsignaciones.Location = new System.Drawing.Point(14, 12);
            this.lblIconoAsignaciones.Name = "lblIconoAsignaciones";
            this.lblIconoAsignaciones.Size = new System.Drawing.Size(34, 34);
            this.lblIconoAsignaciones.TabIndex = 0;
            this.lblIconoAsignaciones.Text = "🏥";
            this.lblIconoAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloAsignaciones
            //
            this.lblTituloAsignaciones.AutoSize = true;
            this.lblTituloAsignaciones.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloAsignaciones.ForeColor = Tema.AzulOscuro;
            this.lblTituloAsignaciones.Location = new System.Drawing.Point(54, 10);
            this.lblTituloAsignaciones.Name = "lblTituloAsignaciones";
            this.lblTituloAsignaciones.Size = new System.Drawing.Size(201, 21);
            this.lblTituloAsignaciones.TabIndex = 1;
            this.lblTituloAsignaciones.Text = "Asignaciones hospitalarias";
            //
            // lblSubtituloAsignaciones
            //
            this.lblSubtituloAsignaciones.AutoSize = true;
            this.lblSubtituloAsignaciones.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblSubtituloAsignaciones.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloAsignaciones.Location = new System.Drawing.Point(56, 30);
            this.lblSubtituloAsignaciones.Name = "lblSubtituloAsignaciones";
            this.lblSubtituloAsignaciones.Size = new System.Drawing.Size(360, 15);
            this.lblSubtituloAsignaciones.TabIndex = 2;
            this.lblSubtituloAsignaciones.Text = "Añade los hospitales donde ejerce y la especialidad correspondiente.";
            //
            // lblHospitalTitulo
            //
            this.lblHospitalTitulo.AutoSize = true;
            this.lblHospitalTitulo.Font = Tema.FuenteLabelCampo;
            this.lblHospitalTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblHospitalTitulo.Location = new System.Drawing.Point(16, 56);
            this.lblHospitalTitulo.Name = "lblHospitalTitulo";
            this.lblHospitalTitulo.Size = new System.Drawing.Size(68, 17);
            this.lblHospitalTitulo.TabIndex = 3;
            this.lblHospitalTitulo.Text = "Hospital *";
            //
            // cmbHospitalAsignacion
            //
            this.cmbHospitalAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHospitalAsignacion.Font = Tema.FuenteInput;
            this.cmbHospitalAsignacion.FormattingEnabled = true;
            this.cmbHospitalAsignacion.IntegralHeight = false;
            this.cmbHospitalAsignacion.MaxDropDownItems = 8;
            this.cmbHospitalAsignacion.Location = new System.Drawing.Point(16, 74);
            this.cmbHospitalAsignacion.Name = "cmbHospitalAsignacion";
            this.cmbHospitalAsignacion.Size = new System.Drawing.Size(290, 27);
            this.cmbHospitalAsignacion.TabIndex = 12;
            //
            // lblEspecialidadHospTitulo
            //
            this.lblEspecialidadHospTitulo.AutoSize = true;
            this.lblEspecialidadHospTitulo.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidadHospTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidadHospTitulo.Location = new System.Drawing.Point(320, 56);
            this.lblEspecialidadHospTitulo.Name = "lblEspecialidadHospTitulo";
            this.lblEspecialidadHospTitulo.Size = new System.Drawing.Size(148, 17);
            this.lblEspecialidadHospTitulo.TabIndex = 4;
            this.lblEspecialidadHospTitulo.Text = "Especialidad ejercida *";
            //
            // cmbEspecialidadHospital
            //
            this.cmbEspecialidadHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidadHospital.Font = Tema.FuenteInput;
            this.cmbEspecialidadHospital.FormattingEnabled = true;
            this.cmbEspecialidadHospital.IntegralHeight = false;
            this.cmbEspecialidadHospital.MaxDropDownItems = 8;
            this.cmbEspecialidadHospital.Location = new System.Drawing.Point(320, 74);
            this.cmbEspecialidadHospital.Name = "cmbEspecialidadHospital";
            this.cmbEspecialidadHospital.Size = new System.Drawing.Size(290, 27);
            this.cmbEspecialidadHospital.TabIndex = 13;
            //
            // btnAgregarAsignacion
            //
            this.btnAgregarAsignacion.BackColor = Tema.AzulPrimario;
            this.btnAgregarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAsignacion.FlatAppearance.BorderSize = 0;
            this.btnAgregarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAsignacion.Font = Tema.FuenteBoton;
            this.btnAgregarAsignacion.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAsignacion.Location = new System.Drawing.Point(625, 73);
            this.btnAgregarAsignacion.Name = "btnAgregarAsignacion";
            this.btnAgregarAsignacion.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarAsignacion.TabIndex = 14;
            this.btnAgregarAsignacion.Text = "+ Agregar";
            this.btnAgregarAsignacion.UseVisualStyleBackColor = false;
            this.btnAgregarAsignacion.Click += new System.EventHandler(this.btnAgregarAsignacion_Click);
            //
            // lblAsignacionesTitulo
            //
            this.lblAsignacionesTitulo.AutoSize = true;
            this.lblAsignacionesTitulo.Font = Tema.FuenteLabelCampo;
            this.lblAsignacionesTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblAsignacionesTitulo.Location = new System.Drawing.Point(16, 110);
            this.lblAsignacionesTitulo.Name = "lblAsignacionesTitulo";
            this.lblAsignacionesTitulo.Size = new System.Drawing.Size(262, 17);
            this.lblAsignacionesTitulo.TabIndex = 5;
            this.lblAsignacionesTitulo.Text = "Hospitales y especialidades asignados";
            //
            // lstAsignaciones
            //
            this.lstAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAsignaciones.Font = Tema.FuenteCuerpo;
            this.lstAsignaciones.FormattingEnabled = true;
            this.lstAsignaciones.ItemHeight = 17;
            this.lstAsignaciones.Location = new System.Drawing.Point(16, 132);
            this.lstAsignaciones.Name = "lstAsignaciones";
            this.lstAsignaciones.Size = new System.Drawing.Size(600, 75);
            this.lstAsignaciones.TabIndex = 15;
            //
            // btnQuitarAsignacion
            //
            this.btnQuitarAsignacion.BackColor = Tema.BotonPeligroFondo;
            this.btnQuitarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarAsignacion.FlatAppearance.BorderColor = Tema.BotonPeligroBorde;
            this.btnQuitarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarAsignacion.Font = Tema.FuenteBoton;
            this.btnQuitarAsignacion.ForeColor = Tema.Error;
            this.btnQuitarAsignacion.Location = new System.Drawing.Point(625, 132);
            this.btnQuitarAsignacion.Name = "btnQuitarAsignacion";
            this.btnQuitarAsignacion.Size = new System.Drawing.Size(100, 32);
            this.btnQuitarAsignacion.TabIndex = 16;
            this.btnQuitarAsignacion.Text = "🗑 Quitar";
            this.btnQuitarAsignacion.UseVisualStyleBackColor = false;
            this.btnQuitarAsignacion.Click += new System.EventHandler(this.btnQuitarAsignacion_Click);
            //
            // panelAcciones
            //
            this.panelAcciones.BackColor = System.Drawing.Color.Transparent;
            this.panelAcciones.Controls.Add(this.btnCancelar);
            this.panelAcciones.Controls.Add(this.btnGuardar);
            this.panelAcciones.Location = new System.Drawing.Point(20, 860);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(750, 46);
            this.panelAcciones.TabIndex = 5;
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = Tema.Superficie;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteBoton;
            this.btnCancelar.ForeColor = Tema.TextoPrincipal;
            this.btnCancelar.Location = new System.Drawing.Point(400, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "✕ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(545, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(190, 40);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "💾 Guardar Doctor";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // crearDoctor
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1150, 760);
            this.Controls.Add(this.panelFormContenedor);
            this.Controls.Add(this.panelHero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "crearDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Registro de Doctor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.crearDoctor_Load);
            this.Resize += new System.EventHandler(this.crearDoctor_Resize);
            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).EndInit();
            this.panelHeroBloque1.ResumeLayout(false);
            this.panelHeroBloque1.PerformLayout();
            this.panelHeroBloque2.ResumeLayout(false);
            this.panelHeroBloque2.PerformLayout();
            this.panelHeroBloque3.ResumeLayout(false);
            this.panelHeroBloque3.PerformLayout();
            this.panelLema.ResumeLayout(false);
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
            this.cardProfesional.ResumeLayout(false);
            this.cardProfesional.PerformLayout();
            this.pnlLicenciaInfo.ResumeLayout(false);
            this.cardAsignaciones.ResumeLayout(false);
            this.cardAsignaciones.PerformLayout();
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
        private System.Windows.Forms.Panel panelLema;
        private System.Windows.Forms.Label lblLemaComillas;
        private System.Windows.Forms.Label lblLemaTexto;
        private System.Windows.Forms.Label lblLemaComillasCierre;
        private System.Windows.Forms.Panel panelFormContenedor;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.Label lblIconoDoctor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel cardPersonal;
        private System.Windows.Forms.Label lblIconoPersonal;
        private System.Windows.Forms.Label lblTituloPersonal;
        private System.Windows.Forms.Label lblSubtituloPersonal;
        private System.Windows.Forms.Label lblPrimerNombre;
        private System.Windows.Forms.TextBox txtPrimerNombre;
        private System.Windows.Forms.Label lblSegundoNombre;
        private System.Windows.Forms.TextBox txtSegundoNombre;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblCedulaAyuda;
        private System.Windows.Forms.Panel pnlCedulaInfo;
        private System.Windows.Forms.Label lblCedulaInfo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.ComboBox cmbPaisTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefonoAyuda;
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
        private System.Windows.Forms.Panel cardProfesional;
        private System.Windows.Forms.Label lblIconoProfesional;
        private System.Windows.Forms.Label lblTituloProfesional;
        private System.Windows.Forms.Label lblSubtituloProfesional;
        private System.Windows.Forms.Label lblNumeroLicencia;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label lblLicenciaAyuda;
        private System.Windows.Forms.Panel pnlLicenciaInfo;
        private System.Windows.Forms.Label lblLicenciaInfo;
        private System.Windows.Forms.Label lblEspecialidadesTitulo;
        private System.Windows.Forms.CheckedListBox lstEspecialidades;
        private System.Windows.Forms.Panel cardAsignaciones;
        private System.Windows.Forms.Label lblIconoAsignaciones;
        private System.Windows.Forms.Label lblTituloAsignaciones;
        private System.Windows.Forms.Label lblSubtituloAsignaciones;
        private System.Windows.Forms.Label lblHospitalTitulo;
        private System.Windows.Forms.ComboBox cmbHospitalAsignacion;
        private System.Windows.Forms.Label lblEspecialidadHospTitulo;
        private System.Windows.Forms.ComboBox cmbEspecialidadHospital;
        private System.Windows.Forms.Button btnAgregarAsignacion;
        private System.Windows.Forms.Label lblAsignacionesTitulo;
        private System.Windows.Forms.ListBox lstAsignaciones;
        private System.Windows.Forms.Button btnQuitarAsignacion;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
