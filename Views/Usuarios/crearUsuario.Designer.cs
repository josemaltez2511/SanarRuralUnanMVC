using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class crearUsuario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (timerSlides != null)
                {
                    timerSlides.Stop();
                    timerSlides.Dispose();
                    timerSlides = null;
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
            this.components = new System.ComponentModel.Container();
            this.panelHero = new System.Windows.Forms.Panel();
            this.picLogoHero = new System.Windows.Forms.PictureBox();
            this.lblNombreHero = new System.Windows.Forms.Label();
            this.lblSubtituloHero = new System.Windows.Forms.Label();
            this.lblDescripcionHero = new System.Windows.Forms.Label();
            this.panelSlideCard = new System.Windows.Forms.Panel();
            this.lblSlideIcono = new System.Windows.Forms.Label();
            this.lblSlideTitulo = new System.Windows.Forms.Label();
            this.lblSlideDescripcion = new System.Windows.Forms.Label();
            this.panelSlideIndicadores = new System.Windows.Forms.Panel();
            this.panelLema = new System.Windows.Forms.Panel();
            this.lblLemaComillas = new System.Windows.Forms.Label();
            this.lblLemaTexto = new System.Windows.Forms.Label();
            this.lblLemaSubtexto = new System.Windows.Forms.Label();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblIconoCard = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelLineaVerde = new System.Windows.Forms.Panel();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblErrorCorreo = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnVerContrasena = new System.Windows.Forms.Button();
            this.lblErrorContrasena = new System.Windows.Forms.Label();
            this.lblConfirmarContrasena = new System.Windows.Forms.Label();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.btnVerConfirmarContrasena = new System.Windows.Forms.Button();
            this.lblErrorConfirmar = new System.Windows.Forms.Label();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.rbPaciente = new System.Windows.Forms.RadioButton();
            this.rbMedico = new System.Windows.Forms.RadioButton();
            this.panelTarjetaPaciente = new SanarRuralUnan.Views.TarjetaRolPanel();
            this.panelTarjetaMedico = new SanarRuralUnan.Views.TarjetaRolPanel();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelSeparadorInferior = new System.Windows.Forms.Panel();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.timerSlides = new System.Windows.Forms.Timer(this.components);
            this.panelHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).BeginInit();
            this.panelSlideCard.SuspendLayout();
            this.panelLema.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            //
            // panelHero
            //
            this.panelHero.BackColor = Tema.Fondo;
            this.panelHero.Controls.Add(this.picLogoHero);
            this.panelHero.Controls.Add(this.lblNombreHero);
            this.panelHero.Controls.Add(this.lblSubtituloHero);
            this.panelHero.Controls.Add(this.lblDescripcionHero);
            this.panelHero.Controls.Add(this.panelSlideCard);
            this.panelHero.Controls.Add(this.panelSlideIndicadores);
            this.panelHero.Controls.Add(this.panelLema);
            this.panelHero.Location = new System.Drawing.Point(0, 0);
            this.panelHero.Name = "panelHero";
            this.panelHero.Size = new System.Drawing.Size(600, 700);
            this.panelHero.TabIndex = 0;
            this.panelHero.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHero_Paint);
            //
            // picLogoHero
            //
            this.picLogoHero.AccessibleDescription = "Identidad institucional de Sanar Rural";
            this.picLogoHero.AccessibleName = "Logo Sanar Rural";
            this.picLogoHero.Location = new System.Drawing.Point(55, 35);
            this.picLogoHero.Name = "picLogoHero";
            this.picLogoHero.Size = new System.Drawing.Size(140, 95);
            this.picLogoHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoHero.TabIndex = 0;
            this.picLogoHero.TabStop = false;
            //
            // lblNombreHero
            //
            this.lblNombreHero.AutoSize = true;
            this.lblNombreHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 25F, System.Drawing.FontStyle.Bold);
            this.lblNombreHero.ForeColor = Tema.AzulOscuro;
            this.lblNombreHero.Location = new System.Drawing.Point(50, 138);
            this.lblNombreHero.Name = "lblNombreHero";
            this.lblNombreHero.Size = new System.Drawing.Size(258, 46);
            this.lblNombreHero.TabIndex = 1;
            this.lblNombreHero.Text = "SANAR RURAL";
            //
            // lblSubtituloHero
            //
            this.lblSubtituloHero.AutoSize = true;
            this.lblSubtituloHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12.5F, System.Drawing.FontStyle.Regular);
            this.lblSubtituloHero.ForeColor = Tema.AzulPrimario;
            this.lblSubtituloHero.Location = new System.Drawing.Point(53, 190);
            this.lblSubtituloHero.Name = "lblSubtituloHero";
            this.lblSubtituloHero.Size = new System.Drawing.Size(318, 23);
            this.lblSubtituloHero.TabIndex = 2;
            this.lblSubtituloHero.Text = "Sistema de Gestión Médica Comunitaria";
            //
            // lblDescripcionHero
            //
            this.lblDescripcionHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Regular);
            this.lblDescripcionHero.ForeColor = Tema.TextoSecundario;
            this.lblDescripcionHero.Location = new System.Drawing.Point(53, 224);
            this.lblDescripcionHero.Name = "lblDescripcionHero";
            this.lblDescripcionHero.Size = new System.Drawing.Size(460, 48);
            this.lblDescripcionHero.TabIndex = 3;
            this.lblDescripcionHero.Text = "Únete a Sanar Rural y forma parte de la gestión de atención médica comunitaria, contribuyendo a una mejor salud para nuestras comunidades.";
            //
            // panelSlideCard
            //
            this.panelSlideCard.BackColor = Tema.Superficie;
            this.panelSlideCard.Controls.Add(this.lblSlideIcono);
            this.panelSlideCard.Controls.Add(this.lblSlideTitulo);
            this.panelSlideCard.Controls.Add(this.lblSlideDescripcion);
            this.panelSlideCard.Location = new System.Drawing.Point(55, 288);
            this.panelSlideCard.Name = "panelSlideCard";
            this.panelSlideCard.Size = new System.Drawing.Size(460, 100);
            this.panelSlideCard.TabIndex = 4;
            this.panelSlideCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSlideCard_Paint);
            //
            // lblSlideIcono
            //
            this.lblSlideIcono.BackColor = Tema.FondoSecundario;
            this.lblSlideIcono.Font = new System.Drawing.Font(Tema.FamiliaFuente, 20F, System.Drawing.FontStyle.Regular);
            this.lblSlideIcono.Location = new System.Drawing.Point(16, 18);
            this.lblSlideIcono.Name = "lblSlideIcono";
            this.lblSlideIcono.Size = new System.Drawing.Size(52, 52);
            this.lblSlideIcono.TabIndex = 0;
            this.lblSlideIcono.Text = "👥";
            this.lblSlideIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSlideTitulo
            //
            this.lblSlideTitulo.AutoSize = true;
            this.lblSlideTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11.5F, System.Drawing.FontStyle.Bold);
            this.lblSlideTitulo.ForeColor = Tema.AzulOscuro;
            this.lblSlideTitulo.Location = new System.Drawing.Point(78, 18);
            this.lblSlideTitulo.Name = "lblSlideTitulo";
            this.lblSlideTitulo.Size = new System.Drawing.Size(157, 21);
            this.lblSlideTitulo.TabIndex = 1;
            this.lblSlideTitulo.Text = "Gestión organizada";
            //
            // lblSlideDescripcion
            //
            this.lblSlideDescripcion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Regular);
            this.lblSlideDescripcion.ForeColor = Tema.TextoSecundario;
            this.lblSlideDescripcion.Location = new System.Drawing.Point(78, 43);
            this.lblSlideDescripcion.Name = "lblSlideDescripcion";
            this.lblSlideDescripcion.Size = new System.Drawing.Size(365, 45);
            this.lblSlideDescripcion.TabIndex = 2;
            this.lblSlideDescripcion.Text = "Centraliza la información necesaria para una atención comunitaria más eficiente.";
            //
            // panelSlideIndicadores
            //
            this.panelSlideIndicadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelSlideIndicadores.Location = new System.Drawing.Point(55, 400);
            this.panelSlideIndicadores.Name = "panelSlideIndicadores";
            this.panelSlideIndicadores.Size = new System.Drawing.Size(200, 22);
            this.panelSlideIndicadores.TabIndex = 5;
            this.panelSlideIndicadores.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSlideIndicadores_Paint);
            this.panelSlideIndicadores.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelSlideIndicadores_MouseClick);
            //
            // panelLema
            //
            this.panelLema.BackColor = Tema.FondoSecundario;
            this.panelLema.Controls.Add(this.lblLemaComillas);
            this.panelLema.Controls.Add(this.lblLemaTexto);
            this.panelLema.Controls.Add(this.lblLemaSubtexto);
            this.panelLema.Location = new System.Drawing.Point(55, 438);
            this.panelLema.Name = "panelLema";
            this.panelLema.Size = new System.Drawing.Size(460, 62);
            this.panelLema.TabIndex = 6;
            this.panelLema.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLema_Paint);
            //
            // lblLemaComillas
            //
            this.lblLemaComillas.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillas.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillas.Location = new System.Drawing.Point(10, 8);
            this.lblLemaComillas.Name = "lblLemaComillas";
            this.lblLemaComillas.Size = new System.Drawing.Size(35, 42);
            this.lblLemaComillas.TabIndex = 0;
            this.lblLemaComillas.Text = "❝";
            this.lblLemaComillas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // lblLemaTexto
            //
            this.lblLemaTexto.AutoSize = true;
            this.lblLemaTexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblLemaTexto.ForeColor = Tema.AzulOscuro;
            this.lblLemaTexto.Location = new System.Drawing.Point(48, 12);
            this.lblLemaTexto.Name = "lblLemaTexto";
            this.lblLemaTexto.Size = new System.Drawing.Size(225, 19);
            this.lblLemaTexto.TabIndex = 1;
            this.lblLemaTexto.Text = "Salud más cerca de nuestra gente";
            //
            // lblLemaSubtexto
            //
            this.lblLemaSubtexto.AutoSize = true;
            this.lblLemaSubtexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F, System.Drawing.FontStyle.Italic);
            this.lblLemaSubtexto.ForeColor = Tema.TextoSecundario;
            this.lblLemaSubtexto.Location = new System.Drawing.Point(48, 34);
            this.lblLemaSubtexto.Name = "lblLemaSubtexto";
            this.lblLemaSubtexto.Size = new System.Drawing.Size(252, 15);
            this.lblLemaSubtexto.TabIndex = 2;
            this.lblLemaSubtexto.Text = "Atención médica integral, solidaria y comunitaria";
            //
            // panelAuth
            //
            this.panelAuth.AutoScroll = true;
            this.panelAuth.BackColor = Tema.Fondo;
            this.panelAuth.Controls.Add(this.panelCard);
            this.panelAuth.Location = new System.Drawing.Point(600, 0);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(550, 700);
            this.panelAuth.TabIndex = 1;
            //
            // panelCard
            //
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.picLogo);
            this.panelCard.Controls.Add(this.lblIconoCard);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblCorreo);
            this.panelCard.Controls.Add(this.txtCorreo);
            this.panelCard.Controls.Add(this.lblErrorCorreo);
            this.panelCard.Controls.Add(this.lblContrasena);
            this.panelCard.Controls.Add(this.txtContrasena);
            this.panelCard.Controls.Add(this.btnVerContrasena);
            this.panelCard.Controls.Add(this.lblErrorContrasena);
            this.panelCard.Controls.Add(this.lblConfirmarContrasena);
            this.panelCard.Controls.Add(this.txtConfirmarContrasena);
            this.panelCard.Controls.Add(this.btnVerConfirmarContrasena);
            this.panelCard.Controls.Add(this.lblErrorConfirmar);
            this.panelCard.Controls.Add(this.lblTipoUsuario);
            this.panelCard.Controls.Add(this.rbPaciente);
            this.panelCard.Controls.Add(this.rbMedico);
            this.panelCard.Controls.Add(this.panelTarjetaPaciente);
            this.panelCard.Controls.Add(this.panelTarjetaMedico);
            this.panelCard.Controls.Add(this.cmbRol);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.panelSeparadorInferior);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Location = new System.Drawing.Point(40, 20);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(470, 575);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            //
            // picLogo
            //
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(1, 1);
            this.picLogo.TabIndex = 22;
            this.picLogo.TabStop = false;
            this.picLogo.Visible = false;
            //
            // lblIconoCard
            //
            this.lblIconoCard.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblIconoCard.ForeColor = Tema.AzulPrimario;
            this.lblIconoCard.Location = new System.Drawing.Point(34, 18);
            this.lblIconoCard.Name = "lblIconoCard";
            this.lblIconoCard.Size = new System.Drawing.Size(42, 42);
            this.lblIconoCard.TabIndex = 0;
            this.lblIconoCard.Text = "👤⁺";
            this.lblIconoCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(82, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Crear una cuenta";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Regular);
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(84, 48);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(222, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Regístrate para acceder a Sanar Rural";
            //
            // panelLineaVerde
            //
            this.panelLineaVerde.BackColor = Tema.FondoSecundario;
            this.panelLineaVerde.Location = new System.Drawing.Point(35, 74);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(400, 2);
            this.panelLineaVerde.TabIndex = 3;
            //
            // lblCorreo
            //
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(35, 88);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(121, 17);
            this.lblCorreo.TabIndex = 4;
            this.lblCorreo.Text = "Correo Electrónico";
            //
            // txtCorreo
            //
            this.txtCorreo.Font = Tema.FuenteInput;
            this.txtCorreo.Location = new System.Drawing.Point(35, 108);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(400, 27);
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            //
            // lblErrorCorreo
            //
            this.lblErrorCorreo.Font = Tema.FuenteAyuda;
            this.lblErrorCorreo.ForeColor = Tema.Error;
            this.lblErrorCorreo.Location = new System.Drawing.Point(35, 137);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(400, 16);
            this.lblErrorCorreo.TabIndex = 5;
            //
            // lblContrasena
            //
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = Tema.FuenteLabelCampo;
            this.lblContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblContrasena.Location = new System.Drawing.Point(35, 155);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(77, 17);
            this.lblContrasena.TabIndex = 6;
            this.lblContrasena.Text = "Contraseña";
            //
            // txtContrasena
            //
            this.txtContrasena.Font = Tema.FuenteInput;
            this.txtContrasena.Location = new System.Drawing.Point(35, 175);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(355, 27);
            this.txtContrasena.TabIndex = 1;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            //
            // btnVerContrasena
            //
            this.btnVerContrasena.BackColor = Tema.Superficie;
            this.btnVerContrasena.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerContrasena.FlatAppearance.BorderColor = Tema.Borde;
            this.btnVerContrasena.FlatAppearance.BorderSize = 1;
            this.btnVerContrasena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerContrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVerContrasena.Location = new System.Drawing.Point(395, 175);
            this.btnVerContrasena.Name = "btnVerContrasena";
            this.btnVerContrasena.Size = new System.Drawing.Size(40, 27);
            this.btnVerContrasena.TabIndex = 2;
            this.btnVerContrasena.Text = "👁";
            this.btnVerContrasena.UseVisualStyleBackColor = false;
            this.btnVerContrasena.Click += new System.EventHandler(this.btnVerContrasena_Click);
            //
            // lblErrorContrasena
            //
            this.lblErrorContrasena.Font = Tema.FuenteAyuda;
            this.lblErrorContrasena.ForeColor = Tema.TextoSecundario;
            this.lblErrorContrasena.Location = new System.Drawing.Point(35, 204);
            this.lblErrorContrasena.Name = "lblErrorContrasena";
            this.lblErrorContrasena.Size = new System.Drawing.Size(400, 16);
            this.lblErrorContrasena.TabIndex = 7;
            this.lblErrorContrasena.Text = "La contraseña debe tener al menos 5 caracteres";
            //
            // lblConfirmarContrasena
            //
            this.lblConfirmarContrasena.AutoSize = true;
            this.lblConfirmarContrasena.Font = Tema.FuenteLabelCampo;
            this.lblConfirmarContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblConfirmarContrasena.Location = new System.Drawing.Point(35, 222);
            this.lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            this.lblConfirmarContrasena.Size = new System.Drawing.Size(143, 17);
            this.lblConfirmarContrasena.TabIndex = 8;
            this.lblConfirmarContrasena.Text = "Confirmar Contraseña";
            //
            // txtConfirmarContrasena
            //
            this.txtConfirmarContrasena.Font = Tema.FuenteInput;
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(35, 242);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '●';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(355, 27);
            this.txtConfirmarContrasena.TabIndex = 3;
            this.txtConfirmarContrasena.TextChanged += new System.EventHandler(this.txtConfirmarContrasena_TextChanged);
            //
            // btnVerConfirmarContrasena
            //
            this.btnVerConfirmarContrasena.BackColor = Tema.Superficie;
            this.btnVerConfirmarContrasena.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerConfirmarContrasena.FlatAppearance.BorderColor = Tema.Borde;
            this.btnVerConfirmarContrasena.FlatAppearance.BorderSize = 1;
            this.btnVerConfirmarContrasena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVerConfirmarContrasena.Location = new System.Drawing.Point(395, 242);
            this.btnVerConfirmarContrasena.Name = "btnVerConfirmarContrasena";
            this.btnVerConfirmarContrasena.Size = new System.Drawing.Size(40, 27);
            this.btnVerConfirmarContrasena.TabIndex = 4;
            this.btnVerConfirmarContrasena.Text = "👁";
            this.btnVerConfirmarContrasena.UseVisualStyleBackColor = false;
            this.btnVerConfirmarContrasena.Click += new System.EventHandler(this.btnVerConfirmarContrasena_Click);
            //
            // lblErrorConfirmar
            //
            this.lblErrorConfirmar.Font = Tema.FuenteAyuda;
            this.lblErrorConfirmar.ForeColor = Tema.Error;
            this.lblErrorConfirmar.Location = new System.Drawing.Point(35, 271);
            this.lblErrorConfirmar.Name = "lblErrorConfirmar";
            this.lblErrorConfirmar.Size = new System.Drawing.Size(400, 16);
            this.lblErrorConfirmar.TabIndex = 9;
            //
            // lblTipoUsuario
            //
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.Font = Tema.FuenteLabelCampo;
            this.lblTipoUsuario.ForeColor = Tema.TextoPrincipal;
            this.lblTipoUsuario.Location = new System.Drawing.Point(35, 289);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(104, 17);
            this.lblTipoUsuario.TabIndex = 10;
            this.lblTipoUsuario.Text = "Tipo de usuario";
            //
            // rbPaciente
            //
            this.rbPaciente.AutoSize = true;
            this.rbPaciente.Location = new System.Drawing.Point(35, 310);
            this.rbPaciente.Name = "rbPaciente";
            this.rbPaciente.Size = new System.Drawing.Size(67, 17);
            this.rbPaciente.TabIndex = 20;
            this.rbPaciente.TabStop = false;
            this.rbPaciente.Text = "Paciente";
            this.rbPaciente.UseVisualStyleBackColor = true;
            this.rbPaciente.Visible = false;
            //
            // rbMedico
            //
            this.rbMedico.AutoSize = true;
            this.rbMedico.Location = new System.Drawing.Point(240, 310);
            this.rbMedico.Name = "rbMedico";
            this.rbMedico.Size = new System.Drawing.Size(155, 17);
            this.rbMedico.TabIndex = 21;
            this.rbMedico.TabStop = false;
            this.rbMedico.Text = "Médico / Personal de salud";
            this.rbMedico.UseVisualStyleBackColor = true;
            this.rbMedico.Visible = false;
            //
            // panelTarjetaPaciente
            //
            this.panelTarjetaPaciente.AccessibleDescription = "Seleccionar rol de Paciente";
            this.panelTarjetaPaciente.AccessibleName = "Paciente";
            this.panelTarjetaPaciente.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.panelTarjetaPaciente.Checked = false;
            this.panelTarjetaPaciente.Location = new System.Drawing.Point(35, 311);
            this.panelTarjetaPaciente.Name = "panelTarjetaPaciente";
            this.panelTarjetaPaciente.Size = new System.Drawing.Size(195, 48);
            this.panelTarjetaPaciente.TabIndex = 5;
            this.panelTarjetaPaciente.TabStop = true;
            //
            // panelTarjetaMedico
            //
            this.panelTarjetaMedico.AccessibleDescription = "Seleccionar rol de Médico o Personal de salud";
            this.panelTarjetaMedico.AccessibleName = "Médico o Personal de salud";
            this.panelTarjetaMedico.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.panelTarjetaMedico.Checked = false;
            this.panelTarjetaMedico.Location = new System.Drawing.Point(240, 311);
            this.panelTarjetaMedico.Name = "panelTarjetaMedico";
            this.panelTarjetaMedico.Size = new System.Drawing.Size(195, 48);
            this.panelTarjetaMedico.TabIndex = 6;
            this.panelTarjetaMedico.TabStop = true;
            //
            // cmbRol
            //
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Font = Tema.FuenteInput;
            this.cmbRol.Location = new System.Drawing.Point(35, 311);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(400, 28);
            this.cmbRol.TabIndex = 6;
            this.cmbRol.Visible = false;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(35, 375);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(400, 44);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // panelSeparadorInferior
            //
            this.panelSeparadorInferior.BackColor = Tema.Borde;
            this.panelSeparadorInferior.Location = new System.Drawing.Point(35, 435);
            this.panelSeparadorInferior.Name = "panelSeparadorInferior";
            this.panelSeparadorInferior.Size = new System.Drawing.Size(400, 1);
            this.panelSeparadorInferior.TabIndex = 11;
            //
            // lnkVolver
            //
            this.lnkVolver.ActiveLinkColor = Tema.AzulOscuro;
            this.lnkVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkVolver.Font = Tema.FuenteCuerpo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(35, 448);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(400, 24);
            this.lnkVolver.TabIndex = 8;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "¿Ya tienes una cuenta? Iniciar Sesión";
            this.lnkVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkVolver.VisitedLinkColor = Tema.AzulPrimario;
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            //
            // timerSlides
            //
            this.timerSlides.Interval = 4500;
            this.timerSlides.Tick += new System.EventHandler(this.timerSlides_Tick);
            //
            // crearUsuario
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.panelAuth);
            this.Controls.Add(this.panelHero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "crearUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Registro de Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.crearUsuario_Load);
            this.Resize += new System.EventHandler(this.crearUsuario_Resize);
            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).EndInit();
            this.panelSlideCard.ResumeLayout(false);
            this.panelSlideCard.PerformLayout();
            this.panelLema.ResumeLayout(false);
            this.panelLema.PerformLayout();
            this.panelAuth.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHero;
        private System.Windows.Forms.PictureBox picLogoHero;
        private System.Windows.Forms.Label lblNombreHero;
        private System.Windows.Forms.Label lblSubtituloHero;
        private System.Windows.Forms.Label lblDescripcionHero;
        private System.Windows.Forms.Panel panelSlideCard;
        private System.Windows.Forms.Label lblSlideIcono;
        private System.Windows.Forms.Label lblSlideTitulo;
        private System.Windows.Forms.Label lblSlideDescripcion;
        private System.Windows.Forms.Panel panelSlideIndicadores;
        private System.Windows.Forms.Panel panelLema;
        private System.Windows.Forms.Label lblLemaComillas;
        private System.Windows.Forms.Label lblLemaTexto;
        private System.Windows.Forms.Label lblLemaSubtexto;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblIconoCard;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblErrorCorreo;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnVerContrasena;
        private System.Windows.Forms.Label lblErrorContrasena;
        private System.Windows.Forms.Label lblConfirmarContrasena;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Button btnVerConfirmarContrasena;
        private System.Windows.Forms.Label lblErrorConfirmar;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.RadioButton rbPaciente;
        private System.Windows.Forms.RadioButton rbMedico;
        private SanarRuralUnan.Views.TarjetaRolPanel panelTarjetaPaciente;
        private SanarRuralUnan.Views.TarjetaRolPanel panelTarjetaMedico;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelSeparadorInferior;
        private System.Windows.Forms.LinkLabel lnkVolver;
        private System.Windows.Forms.Timer timerSlides;
    }
}
