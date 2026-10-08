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
            this.lblLemaSubtexto = new System.Windows.Forms.Label();
            this.panelFormContenedor = new System.Windows.Forms.Panel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblIconoDoctor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelSeparadorCabecera = new System.Windows.Forms.Panel();
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
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblNumeroLicencia = new System.Windows.Forms.Label();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.lblFotoTitulo = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.btnSeleccionarFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.lblFotoAyuda = new System.Windows.Forms.Label();
            this.lblEspecialidadesTitulo = new System.Windows.Forms.Label();
            this.lstEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.lblHospitalTitulo = new System.Windows.Forms.Label();
            this.cmbHospitalAsignacion = new System.Windows.Forms.ComboBox();
            this.lblEspecialidadHospTitulo = new System.Windows.Forms.Label();
            this.cmbEspecialidadHospital = new System.Windows.Forms.ComboBox();
            this.btnAgregarAsignacion = new System.Windows.Forms.Button();
            this.lblAsignacionesTitulo = new System.Windows.Forms.Label();
            this.lstAsignaciones = new System.Windows.Forms.ListBox();
            this.btnQuitarAsignacion = new System.Windows.Forms.Button();
            this.panelSeparadorInferior = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).BeginInit();
            this.panelHeroBloque1.SuspendLayout();
            this.panelHeroBloque2.SuspendLayout();
            this.panelHeroBloque3.SuspendLayout();
            this.panelLema.SuspendLayout();
            this.panelFormContenedor.SuspendLayout();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
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
            this.panelHero.Size = new System.Drawing.Size(420, 760);
            this.panelHero.TabIndex = 0;
            this.panelHero.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHero_Paint);
            //
            // picLogoHero
            //
            this.picLogoHero.AccessibleDescription = "Identidad institucional de Sanar Rural";
            this.picLogoHero.AccessibleName = "Logo Sanar Rural";
            this.picLogoHero.Location = new System.Drawing.Point(45, 25);
            this.picLogoHero.Name = "picLogoHero";
            this.picLogoHero.Size = new System.Drawing.Size(130, 85);
            this.picLogoHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoHero.TabIndex = 0;
            this.picLogoHero.TabStop = false;
            //
            // lblNombreHero
            //
            this.lblNombreHero.AutoSize = true;
            this.lblNombreHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 23F, System.Drawing.FontStyle.Bold);
            this.lblNombreHero.ForeColor = Tema.AzulOscuro;
            this.lblNombreHero.Location = new System.Drawing.Point(40, 118);
            this.lblNombreHero.Name = "lblNombreHero";
            this.lblNombreHero.Size = new System.Drawing.Size(236, 42);
            this.lblNombreHero.TabIndex = 1;
            this.lblNombreHero.Text = "SANAR RURAL";
            //
            // lblSubtituloHero
            //
            this.lblSubtituloHero.AutoSize = true;
            this.lblSubtituloHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Regular);
            this.lblSubtituloHero.ForeColor = Tema.AzulPrimario;
            this.lblSubtituloHero.Location = new System.Drawing.Point(43, 164);
            this.lblSubtituloHero.Name = "lblSubtituloHero";
            this.lblSubtituloHero.Size = new System.Drawing.Size(287, 21);
            this.lblSubtituloHero.TabIndex = 2;
            this.lblSubtituloHero.Text = "Sistema de Gestión Médica Comunitaria";
            //
            // lblRegistroTituloHero
            //
            this.lblRegistroTituloHero.AutoSize = true;
            this.lblRegistroTituloHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblRegistroTituloHero.ForeColor = Tema.AzulOscuro;
            this.lblRegistroTituloHero.Location = new System.Drawing.Point(42, 202);
            this.lblRegistroTituloHero.Name = "lblRegistroTituloHero";
            this.lblRegistroTituloHero.Size = new System.Drawing.Size(209, 30);
            this.lblRegistroTituloHero.TabIndex = 3;
            this.lblRegistroTituloHero.Text = "Registro de Doctor";
            //
            // lblDescripcionHero
            //
            this.lblDescripcionHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDescripcionHero.ForeColor = Tema.TextoSecundario;
            this.lblDescripcionHero.Location = new System.Drawing.Point(43, 236);
            this.lblDescripcionHero.Name = "lblDescripcionHero";
            this.lblDescripcionHero.Size = new System.Drawing.Size(335, 48);
            this.lblDescripcionHero.TabIndex = 4;
            this.lblDescripcionHero.Text = "Registra tus datos profesionales para formar parte del equipo médico y brindar atención a nuestras comunidades rurales.";
            //
            // panelHeroBloque1
            //
            this.panelHeroBloque1.BackColor = Tema.Superficie;
            this.panelHeroBloque1.Controls.Add(this.lblHeroIcono1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroTitulo1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroDesc1);
            this.panelHeroBloque1.Location = new System.Drawing.Point(45, 298);
            this.panelHeroBloque1.Name = "panelHeroBloque1";
            this.panelHeroBloque1.Size = new System.Drawing.Size(330, 68);
            this.panelHeroBloque1.TabIndex = 5;
            this.panelHeroBloque1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeroBloque_Paint);
            //
            // lblHeroIcono1
            //
            this.lblHeroIcono1.BackColor = Tema.FondoSecundario;
            this.lblHeroIcono1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblHeroIcono1.Location = new System.Drawing.Point(12, 12);
            this.lblHeroIcono1.Name = "lblHeroIcono1";
            this.lblHeroIcono1.Size = new System.Drawing.Size(44, 44);
            this.lblHeroIcono1.TabIndex = 0;
            this.lblHeroIcono1.Text = "👤";
            this.lblHeroIcono1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo1
            //
            this.lblHeroTitulo1.AutoSize = true;
            this.lblHeroTitulo1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo1.ForeColor = Tema.AzulOscuro;
            this.lblHeroTitulo1.Location = new System.Drawing.Point(64, 12);
            this.lblHeroTitulo1.Name = "lblHeroTitulo1";
            this.lblHeroTitulo1.Size = new System.Drawing.Size(117, 19);
            this.lblHeroTitulo1.TabIndex = 1;
            this.lblHeroTitulo1.Text = "Perfil profesional";
            //
            // lblHeroDesc1
            //
            this.lblHeroDesc1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblHeroDesc1.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc1.Location = new System.Drawing.Point(64, 33);
            this.lblHeroDesc1.Name = "lblHeroDesc1";
            this.lblHeroDesc1.Size = new System.Drawing.Size(255, 30);
            this.lblHeroDesc1.TabIndex = 2;
            this.lblHeroDesc1.Text = "Completa tu información personal y profesional.";
            //
            // panelHeroBloque2
            //
            this.panelHeroBloque2.BackColor = Tema.Superficie;
            this.panelHeroBloque2.Controls.Add(this.lblHeroIcono2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroTitulo2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroDesc2);
            this.panelHeroBloque2.Location = new System.Drawing.Point(45, 376);
            this.panelHeroBloque2.Name = "panelHeroBloque2";
            this.panelHeroBloque2.Size = new System.Drawing.Size(330, 68);
            this.panelHeroBloque2.TabIndex = 6;
            this.panelHeroBloque2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeroBloque_Paint);
            //
            // lblHeroIcono2
            //
            this.lblHeroIcono2.BackColor = Tema.FondoSecundario;
            this.lblHeroIcono2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblHeroIcono2.Location = new System.Drawing.Point(12, 12);
            this.lblHeroIcono2.Name = "lblHeroIcono2";
            this.lblHeroIcono2.Size = new System.Drawing.Size(44, 44);
            this.lblHeroIcono2.TabIndex = 0;
            this.lblHeroIcono2.Text = "🛡️";
            this.lblHeroIcono2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo2
            //
            this.lblHeroTitulo2.AutoSize = true;
            this.lblHeroTitulo2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo2.ForeColor = Tema.AzulOscuro;
            this.lblHeroTitulo2.Location = new System.Drawing.Point(64, 12);
            this.lblHeroTitulo2.Name = "lblHeroTitulo2";
            this.lblHeroTitulo2.Size = new System.Drawing.Size(104, 19);
            this.lblHeroTitulo2.TabIndex = 1;
            this.lblHeroTitulo2.Text = "Especialidades";
            //
            // lblHeroDesc2
            //
            this.lblHeroDesc2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblHeroDesc2.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc2.Location = new System.Drawing.Point(64, 33);
            this.lblHeroDesc2.Name = "lblHeroDesc2";
            this.lblHeroDesc2.Size = new System.Drawing.Size(255, 30);
            this.lblHeroDesc2.TabIndex = 2;
            this.lblHeroDesc2.Text = "Selecciona tus áreas de especialidad.";
            //
            // panelHeroBloque3
            //
            this.panelHeroBloque3.BackColor = Tema.Superficie;
            this.panelHeroBloque3.Controls.Add(this.lblHeroIcono3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroTitulo3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroDesc3);
            this.panelHeroBloque3.Location = new System.Drawing.Point(45, 454);
            this.panelHeroBloque3.Name = "panelHeroBloque3";
            this.panelHeroBloque3.Size = new System.Drawing.Size(330, 68);
            this.panelHeroBloque3.TabIndex = 7;
            this.panelHeroBloque3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeroBloque_Paint);
            //
            // lblHeroIcono3
            //
            this.lblHeroIcono3.BackColor = Tema.FondoSecundario;
            this.lblHeroIcono3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblHeroIcono3.Location = new System.Drawing.Point(12, 12);
            this.lblHeroIcono3.Name = "lblHeroIcono3";
            this.lblHeroIcono3.Size = new System.Drawing.Size(44, 44);
            this.lblHeroIcono3.TabIndex = 0;
            this.lblHeroIcono3.Text = "🏥";
            this.lblHeroIcono3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo3
            //
            this.lblHeroTitulo3.AutoSize = true;
            this.lblHeroTitulo3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo3.ForeColor = Tema.AzulOscuro;
            this.lblHeroTitulo3.Location = new System.Drawing.Point(64, 12);
            this.lblHeroTitulo3.Name = "lblHeroTitulo3";
            this.lblHeroTitulo3.Size = new System.Drawing.Size(161, 19);
            this.lblHeroTitulo3.TabIndex = 1;
            this.lblHeroTitulo3.Text = "Información institucional";
            //
            // lblHeroDesc3
            //
            this.lblHeroDesc3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F);
            this.lblHeroDesc3.ForeColor = Tema.TextoSecundario;
            this.lblHeroDesc3.Location = new System.Drawing.Point(64, 33);
            this.lblHeroDesc3.Name = "lblHeroDesc3";
            this.lblHeroDesc3.Size = new System.Drawing.Size(255, 30);
            this.lblHeroDesc3.TabIndex = 2;
            this.lblHeroDesc3.Text = "Asigna tu hospital y comunidad.";
            //
            // panelLema
            //
            this.panelLema.BackColor = Tema.FondoSecundario;
            this.panelLema.Controls.Add(this.lblLemaComillas);
            this.panelLema.Controls.Add(this.lblLemaTexto);
            this.panelLema.Controls.Add(this.lblLemaSubtexto);
            this.panelLema.Location = new System.Drawing.Point(45, 538);
            this.panelLema.Name = "panelLema";
            this.panelLema.Size = new System.Drawing.Size(330, 62);
            this.panelLema.TabIndex = 8;
            this.panelLema.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLema_Paint);
            //
            // lblLemaComillas
            //
            this.lblLemaComillas.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillas.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillas.Location = new System.Drawing.Point(8, 8);
            this.lblLemaComillas.Name = "lblLemaComillas";
            this.lblLemaComillas.Size = new System.Drawing.Size(32, 40);
            this.lblLemaComillas.TabIndex = 0;
            this.lblLemaComillas.Text = "❝";
            //
            // lblLemaTexto
            //
            this.lblLemaTexto.AutoSize = true;
            this.lblLemaTexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLemaTexto.ForeColor = Tema.AzulOscuro;
            this.lblLemaTexto.Location = new System.Drawing.Point(42, 12);
            this.lblLemaTexto.Name = "lblLemaTexto";
            this.lblLemaTexto.Size = new System.Drawing.Size(225, 17);
            this.lblLemaTexto.TabIndex = 1;
            this.lblLemaTexto.Text = "Salud más cerca de nuestra gente";
            //
            // lblLemaSubtexto
            //
            this.lblLemaSubtexto.AutoSize = true;
            this.lblLemaSubtexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8F, System.Drawing.FontStyle.Italic);
            this.lblLemaSubtexto.ForeColor = Tema.TextoSecundario;
            this.lblLemaSubtexto.Location = new System.Drawing.Point(42, 33);
            this.lblLemaSubtexto.Name = "lblLemaSubtexto";
            this.lblLemaSubtexto.Size = new System.Drawing.Size(236, 13);
            this.lblLemaSubtexto.TabIndex = 2;
            this.lblLemaSubtexto.Text = "Atención médica integral, solidaria y comunitaria";
            //
            // panelFormContenedor
            //
            this.panelFormContenedor.AutoScroll = true;
            this.panelFormContenedor.BackColor = Tema.Fondo;
            this.panelFormContenedor.Controls.Add(this.panelCard);
            this.panelFormContenedor.Location = new System.Drawing.Point(420, 0);
            this.panelFormContenedor.Name = "panelFormContenedor";
            this.panelFormContenedor.Size = new System.Drawing.Size(730, 760);
            this.panelFormContenedor.TabIndex = 1;
            //
            // panelCard
            //
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.lblIconoDoctor);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.panelSeparadorCabecera);
            this.panelCard.Controls.Add(this.lblPrimerNombre);
            this.panelCard.Controls.Add(this.txtPrimerNombre);
            this.panelCard.Controls.Add(this.lblSegundoNombre);
            this.panelCard.Controls.Add(this.txtSegundoNombre);
            this.panelCard.Controls.Add(this.lblPrimerApellido);
            this.panelCard.Controls.Add(this.txtPrimerApellido);
            this.panelCard.Controls.Add(this.lblSegundoApellido);
            this.panelCard.Controls.Add(this.txtSegundoApellido);
            this.panelCard.Controls.Add(this.lblCedula);
            this.panelCard.Controls.Add(this.txtCedula);
            this.panelCard.Controls.Add(this.lblTelefono);
            this.panelCard.Controls.Add(this.txtTelefono);
            this.panelCard.Controls.Add(this.lblNumeroLicencia);
            this.panelCard.Controls.Add(this.txtLicencia);
            this.panelCard.Controls.Add(this.lblFotoTitulo);
            this.panelCard.Controls.Add(this.picPreview);
            this.panelCard.Controls.Add(this.lblFoto);
            this.panelCard.Controls.Add(this.btnSeleccionarFoto);
            this.panelCard.Controls.Add(this.btnQuitarFoto);
            this.panelCard.Controls.Add(this.lblFotoAyuda);
            this.panelCard.Controls.Add(this.lblEspecialidadesTitulo);
            this.panelCard.Controls.Add(this.lstEspecialidades);
            this.panelCard.Controls.Add(this.lblHospitalTitulo);
            this.panelCard.Controls.Add(this.cmbHospitalAsignacion);
            this.panelCard.Controls.Add(this.lblEspecialidadHospTitulo);
            this.panelCard.Controls.Add(this.cmbEspecialidadHospital);
            this.panelCard.Controls.Add(this.btnAgregarAsignacion);
            this.panelCard.Controls.Add(this.lblAsignacionesTitulo);
            this.panelCard.Controls.Add(this.lstAsignaciones);
            this.panelCard.Controls.Add(this.btnQuitarAsignacion);
            this.panelCard.Controls.Add(this.panelSeparadorInferior);
            this.panelCard.Controls.Add(this.btnCancelar);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Location = new System.Drawing.Point(20, 20);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(680, 715);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            //
            // lblIconoDoctor
            //
            this.lblIconoDoctor.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblIconoDoctor.ForeColor = Tema.AzulPrimario;
            this.lblIconoDoctor.Location = new System.Drawing.Point(28, 16);
            this.lblIconoDoctor.Name = "lblIconoDoctor";
            this.lblIconoDoctor.Size = new System.Drawing.Size(42, 42);
            this.lblIconoDoctor.TabIndex = 0;
            this.lblIconoDoctor.Text = "👨‍⚕️";
            this.lblIconoDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(74, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Datos del Doctor";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(76, 44);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(202, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Completa la información requerida";
            //
            // panelSeparadorCabecera
            //
            this.panelSeparadorCabecera.BackColor = Tema.FondoSecundario;
            this.panelSeparadorCabecera.Location = new System.Drawing.Point(30, 70);
            this.panelSeparadorCabecera.Name = "panelSeparadorCabecera";
            this.panelSeparadorCabecera.Size = new System.Drawing.Size(620, 2);
            this.panelSeparadorCabecera.TabIndex = 3;
            //
            // lblPrimerNombre
            //
            this.lblPrimerNombre.AutoSize = true;
            this.lblPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerNombre.Location = new System.Drawing.Point(30, 84);
            this.lblPrimerNombre.Name = "lblPrimerNombre";
            this.lblPrimerNombre.Size = new System.Drawing.Size(107, 17);
            this.lblPrimerNombre.TabIndex = 4;
            this.lblPrimerNombre.Text = "Primer nombre *";
            //
            // txtPrimerNombre
            //
            this.txtPrimerNombre.Font = Tema.FuenteInput;
            this.txtPrimerNombre.Location = new System.Drawing.Point(30, 104);
            this.txtPrimerNombre.MaxLength = 50;
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Size = new System.Drawing.Size(295, 27);
            this.txtPrimerNombre.TabIndex = 1;
            //
            // lblSegundoNombre
            //
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Font = Tema.FuenteLabelCampo;
            this.lblSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoNombre.Location = new System.Drawing.Point(350, 84);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(116, 17);
            this.lblSegundoNombre.TabIndex = 5;
            this.lblSegundoNombre.Text = "Segundo nombre";
            //
            // txtSegundoNombre
            //
            this.txtSegundoNombre.Font = Tema.FuenteInput;
            this.txtSegundoNombre.Location = new System.Drawing.Point(350, 104);
            this.txtSegundoNombre.MaxLength = 50;
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(300, 27);
            this.txtSegundoNombre.TabIndex = 2;
            //
            // lblPrimerApellido
            //
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = Tema.FuenteLabelCampo;
            this.lblPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerApellido.Location = new System.Drawing.Point(30, 142);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(108, 17);
            this.lblPrimerApellido.TabIndex = 6;
            this.lblPrimerApellido.Text = "Primer apellido *";
            //
            // txtPrimerApellido
            //
            this.txtPrimerApellido.Font = Tema.FuenteInput;
            this.txtPrimerApellido.Location = new System.Drawing.Point(30, 162);
            this.txtPrimerApellido.MaxLength = 50;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(295, 27);
            this.txtPrimerApellido.TabIndex = 3;
            //
            // lblSegundoApellido
            //
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = Tema.FuenteLabelCampo;
            this.lblSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoApellido.Location = new System.Drawing.Point(350, 142);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(117, 17);
            this.lblSegundoApellido.TabIndex = 7;
            this.lblSegundoApellido.Text = "Segundo apellido";
            //
            // txtSegundoApellido
            //
            this.txtSegundoApellido.Font = Tema.FuenteInput;
            this.txtSegundoApellido.Location = new System.Drawing.Point(350, 162);
            this.txtSegundoApellido.MaxLength = 50;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(300, 27);
            this.txtSegundoApellido.TabIndex = 4;
            //
            // lblCedula
            //
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = Tema.FuenteLabelCampo;
            this.lblCedula.ForeColor = Tema.TextoPrincipal;
            this.lblCedula.Location = new System.Drawing.Point(30, 200);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(58, 17);
            this.lblCedula.TabIndex = 8;
            this.lblCedula.Text = "Cédula *";
            //
            // txtCedula
            //
            this.txtCedula.Font = Tema.FuenteInput;
            this.txtCedula.Location = new System.Drawing.Point(30, 220);
            this.txtCedula.MaxLength = 20;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(295, 27);
            this.txtCedula.TabIndex = 5;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(350, 200);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 17);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Teléfono";
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(350, 220);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(300, 27);
            this.txtTelefono.TabIndex = 6;
            //
            // lblNumeroLicencia
            //
            this.lblNumeroLicencia.AutoSize = true;
            this.lblNumeroLicencia.Font = Tema.FuenteLabelCampo;
            this.lblNumeroLicencia.ForeColor = Tema.TextoPrincipal;
            this.lblNumeroLicencia.Location = new System.Drawing.Point(30, 258);
            this.lblNumeroLicencia.Name = "lblNumeroLicencia";
            this.lblNumeroLicencia.Size = new System.Drawing.Size(139, 17);
            this.lblNumeroLicencia.TabIndex = 10;
            this.lblNumeroLicencia.Text = "Número de licencia *";
            //
            // txtLicencia
            //
            this.txtLicencia.Font = Tema.FuenteInput;
            this.txtLicencia.Location = new System.Drawing.Point(30, 278);
            this.txtLicencia.MaxLength = 50;
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(295, 27);
            this.txtLicencia.TabIndex = 7;
            //
            // lblFotoTitulo
            //
            this.lblFotoTitulo.AutoSize = true;
            this.lblFotoTitulo.Font = Tema.FuenteLabelCampo;
            this.lblFotoTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblFotoTitulo.Location = new System.Drawing.Point(350, 258);
            this.lblFotoTitulo.Name = "lblFotoTitulo";
            this.lblFotoTitulo.Size = new System.Drawing.Size(107, 17);
            this.lblFotoTitulo.TabIndex = 11;
            this.lblFotoTitulo.Text = "Foto del doctor";
            //
            // picPreview
            //
            this.picPreview.AccessibleName = "Vista previa de la foto del doctor";
            this.picPreview.BackColor = Tema.FondoSecundario;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(350, 278);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(85, 85);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 12;
            this.picPreview.TabStop = false;
            //
            // lblFoto
            //
            this.lblFoto.AutoEllipsis = true;
            this.lblFoto.Font = Tema.FuenteAyuda;
            this.lblFoto.ForeColor = Tema.TextoSecundario;
            this.lblFoto.Location = new System.Drawing.Point(445, 278);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(205, 18);
            this.lblFoto.TabIndex = 13;
            this.lblFoto.Text = "Sin foto seleccionada";
            //
            // btnSeleccionarFoto
            //
            this.btnSeleccionarFoto.BackColor = Tema.AzulPrimario;
            this.btnSeleccionarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarFoto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFoto.Font = Tema.FuenteBoton;
            this.btnSeleccionarFoto.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(445, 302);
            this.btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            this.btnSeleccionarFoto.Size = new System.Drawing.Size(130, 30);
            this.btnSeleccionarFoto.TabIndex = 8;
            this.btnSeleccionarFoto.Text = "Seleccionar foto";
            this.btnSeleccionarFoto.UseVisualStyleBackColor = false;
            this.btnSeleccionarFoto.Click += new System.EventHandler(this.btnSeleccionarFoto_Click);
            //
            // btnQuitarFoto
            //
            this.btnQuitarFoto.BackColor = Tema.Error;
            this.btnQuitarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFoto.FlatAppearance.BorderSize = 0;
            this.btnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.Font = Tema.FuenteBoton;
            this.btnQuitarFoto.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFoto.Location = new System.Drawing.Point(580, 302);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Size = new System.Drawing.Size(70, 30);
            this.btnQuitarFoto.TabIndex = 9;
            this.btnQuitarFoto.Text = "Quitar";
            this.btnQuitarFoto.UseVisualStyleBackColor = false;
            this.btnQuitarFoto.Visible = false;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            //
            // lblFotoAyuda
            //
            this.lblFotoAyuda.AutoSize = true;
            this.lblFotoAyuda.Font = Tema.FuenteAyuda;
            this.lblFotoAyuda.ForeColor = Tema.TextoSecundario;
            this.lblFotoAyuda.Location = new System.Drawing.Point(445, 340);
            this.lblFotoAyuda.Name = "lblFotoAyuda";
            this.lblFotoAyuda.Size = new System.Drawing.Size(126, 15);
            this.lblFotoAyuda.TabIndex = 14;
            this.lblFotoAyuda.Text = "JPG, PNG (máx. 2 MB)";
            //
            // lblEspecialidadesTitulo
            //
            this.lblEspecialidadesTitulo.AutoSize = true;
            this.lblEspecialidadesTitulo.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidadesTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidadesTitulo.Location = new System.Drawing.Point(30, 375);
            this.lblEspecialidadesTitulo.Name = "lblEspecialidadesTitulo";
            this.lblEspecialidadesTitulo.Size = new System.Drawing.Size(251, 17);
            this.lblEspecialidadesTitulo.TabIndex = 15;
            this.lblEspecialidadesTitulo.Text = "Especialidades * (puede elegir varias)";
            //
            // lstEspecialidades
            //
            this.lstEspecialidades.CheckOnClick = true;
            this.lstEspecialidades.Font = Tema.FuenteCuerpo;
            this.lstEspecialidades.FormattingEnabled = true;
            this.lstEspecialidades.Location = new System.Drawing.Point(30, 397);
            this.lstEspecialidades.Name = "lstEspecialidades";
            this.lstEspecialidades.Size = new System.Drawing.Size(295, 172);
            this.lstEspecialidades.TabIndex = 10;
            //
            // lblHospitalTitulo
            //
            this.lblHospitalTitulo.AutoSize = true;
            this.lblHospitalTitulo.Font = Tema.FuenteLabelCampo;
            this.lblHospitalTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblHospitalTitulo.Location = new System.Drawing.Point(350, 375);
            this.lblHospitalTitulo.Name = "lblHospitalTitulo";
            this.lblHospitalTitulo.Size = new System.Drawing.Size(68, 17);
            this.lblHospitalTitulo.TabIndex = 16;
            this.lblHospitalTitulo.Text = "Hospital *";
            //
            // cmbHospitalAsignacion
            //
            this.cmbHospitalAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHospitalAsignacion.Font = Tema.FuenteInput;
            this.cmbHospitalAsignacion.FormattingEnabled = true;
            this.cmbHospitalAsignacion.Location = new System.Drawing.Point(350, 397);
            this.cmbHospitalAsignacion.Name = "cmbHospitalAsignacion";
            this.cmbHospitalAsignacion.Size = new System.Drawing.Size(142, 27);
            this.cmbHospitalAsignacion.TabIndex = 11;
            //
            // lblEspecialidadHospTitulo
            //
            this.lblEspecialidadHospTitulo.AutoSize = true;
            this.lblEspecialidadHospTitulo.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidadHospTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidadHospTitulo.Location = new System.Drawing.Point(502, 375);
            this.lblEspecialidadHospTitulo.Name = "lblEspecialidadHospTitulo";
            this.lblEspecialidadHospTitulo.Size = new System.Drawing.Size(148, 17);
            this.lblEspecialidadHospTitulo.TabIndex = 17;
            this.lblEspecialidadHospTitulo.Text = "Especialidad ejercida *";
            //
            // cmbEspecialidadHospital
            //
            this.cmbEspecialidadHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidadHospital.Font = Tema.FuenteInput;
            this.cmbEspecialidadHospital.FormattingEnabled = true;
            this.cmbEspecialidadHospital.Location = new System.Drawing.Point(502, 397);
            this.cmbEspecialidadHospital.Name = "cmbEspecialidadHospital";
            this.cmbEspecialidadHospital.Size = new System.Drawing.Size(148, 27);
            this.cmbEspecialidadHospital.TabIndex = 12;
            //
            // btnAgregarAsignacion
            //
            this.btnAgregarAsignacion.BackColor = Tema.AzulPrimario;
            this.btnAgregarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAsignacion.FlatAppearance.BorderSize = 0;
            this.btnAgregarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAsignacion.Font = Tema.FuenteBoton;
            this.btnAgregarAsignacion.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAsignacion.Location = new System.Drawing.Point(350, 432);
            this.btnAgregarAsignacion.Name = "btnAgregarAsignacion";
            this.btnAgregarAsignacion.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarAsignacion.TabIndex = 13;
            this.btnAgregarAsignacion.Text = "+ Agregar";
            this.btnAgregarAsignacion.UseVisualStyleBackColor = false;
            this.btnAgregarAsignacion.Click += new System.EventHandler(this.btnAgregarAsignacion_Click);
            //
            // lblAsignacionesTitulo
            //
            this.lblAsignacionesTitulo.AutoSize = true;
            this.lblAsignacionesTitulo.Font = Tema.FuenteLabelCampo;
            this.lblAsignacionesTitulo.ForeColor = Tema.TextoPrincipal;
            this.lblAsignacionesTitulo.Location = new System.Drawing.Point(350, 470);
            this.lblAsignacionesTitulo.Name = "lblAsignacionesTitulo";
            this.lblAsignacionesTitulo.Size = new System.Drawing.Size(262, 17);
            this.lblAsignacionesTitulo.TabIndex = 18;
            this.lblAsignacionesTitulo.Text = "Hospitales y especialidades asignados";
            //
            // lstAsignaciones
            //
            this.lstAsignaciones.Font = Tema.FuenteCuerpo;
            this.lstAsignaciones.FormattingEnabled = true;
            this.lstAsignaciones.ItemHeight = 17;
            this.lstAsignaciones.Location = new System.Drawing.Point(350, 492);
            this.lstAsignaciones.Name = "lstAsignaciones";
            this.lstAsignaciones.Size = new System.Drawing.Size(300, 55);
            this.lstAsignaciones.TabIndex = 14;
            //
            // btnQuitarAsignacion
            //
            this.btnQuitarAsignacion.BackColor = Tema.Superficie;
            this.btnQuitarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarAsignacion.FlatAppearance.BorderColor = Tema.Borde;
            this.btnQuitarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarAsignacion.Font = Tema.FuenteAyuda;
            this.btnQuitarAsignacion.ForeColor = Tema.TextoPrincipal;
            this.btnQuitarAsignacion.Location = new System.Drawing.Point(350, 552);
            this.btnQuitarAsignacion.Name = "btnQuitarAsignacion";
            this.btnQuitarAsignacion.Size = new System.Drawing.Size(150, 26);
            this.btnQuitarAsignacion.TabIndex = 15;
            this.btnQuitarAsignacion.Text = "Quitar seleccionado";
            this.btnQuitarAsignacion.UseVisualStyleBackColor = false;
            this.btnQuitarAsignacion.Click += new System.EventHandler(this.btnQuitarAsignacion_Click);
            //
            // panelSeparadorInferior
            //
            this.panelSeparadorInferior.BackColor = Tema.Borde;
            this.panelSeparadorInferior.Location = new System.Drawing.Point(30, 595);
            this.panelSeparadorInferior.Name = "panelSeparadorInferior";
            this.panelSeparadorInferior.Size = new System.Drawing.Size(620, 1);
            this.panelSeparadorInferior.TabIndex = 19;
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = Tema.Superficie;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteBoton;
            this.btnCancelar.ForeColor = Tema.TextoPrincipal;
            this.btnCancelar.Location = new System.Drawing.Point(260, 615);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 42);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "↩ Cancelar";
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
            this.btnGuardar.Location = new System.Drawing.Point(430, 615);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 42);
            this.btnGuardar.TabIndex = 17;
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
            this.panelLema.PerformLayout();
            this.panelFormContenedor.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
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
        private System.Windows.Forms.Label lblLemaSubtexto;
        private System.Windows.Forms.Panel panelFormContenedor;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblIconoDoctor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelSeparadorCabecera;
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
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblNumeroLicencia;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label lblFotoTitulo;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Button btnSeleccionarFoto;
        private System.Windows.Forms.Button btnQuitarFoto;
        private System.Windows.Forms.Label lblFotoAyuda;
        private System.Windows.Forms.Label lblEspecialidadesTitulo;
        private System.Windows.Forms.CheckedListBox lstEspecialidades;
        private System.Windows.Forms.Label lblHospitalTitulo;
        private System.Windows.Forms.ComboBox cmbHospitalAsignacion;
        private System.Windows.Forms.Label lblEspecialidadHospTitulo;
        private System.Windows.Forms.ComboBox cmbEspecialidadHospital;
        private System.Windows.Forms.Button btnAgregarAsignacion;
        private System.Windows.Forms.Label lblAsignacionesTitulo;
        private System.Windows.Forms.ListBox lstAsignaciones;
        private System.Windows.Forms.Button btnQuitarAsignacion;
        private System.Windows.Forms.Panel panelSeparadorInferior;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
