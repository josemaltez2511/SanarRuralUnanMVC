using SanarRuralUnan.Helpers;

namespace SanarRuralUnan
{
    partial class iniciarSesion
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
            this.lblTituloBienvenido = new System.Windows.Forms.Label();
            this.lblSubtituloBienvenido = new System.Windows.Forms.Label();
            this.panelSeparador = new System.Windows.Forms.Panel();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblErrorCorreo = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnVerContrasena = new System.Windows.Forms.Button();
            this.lblErrorContrasena = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.panelLineaInferior = new System.Windows.Forms.Panel();
            this.lnkCrearUsuario = new System.Windows.Forms.LinkLabel();
            this.timerSlides = new System.Windows.Forms.Timer(this.components);
            this.panelHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).BeginInit();
            this.panelSlideCard.SuspendLayout();
            this.panelLema.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.panelCard.SuspendLayout();
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
            this.panelHero.Size = new System.Drawing.Size(650, 700);
            this.panelHero.TabIndex = 0;
            this.panelHero.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHero_Paint);
            //
            // picLogoHero
            //
            this.picLogoHero.AccessibleDescription = "Identidad institucional de Sanar Rural";
            this.picLogoHero.AccessibleName = "Logo Sanar Rural";
            this.picLogoHero.Location = new System.Drawing.Point(60, 45);
            this.picLogoHero.Name = "picLogoHero";
            this.picLogoHero.Size = new System.Drawing.Size(140, 95);
            this.picLogoHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoHero.TabIndex = 0;
            this.picLogoHero.TabStop = false;
            //
            // lblNombreHero
            //
            this.lblNombreHero.AutoSize = true;
            this.lblNombreHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 26F, System.Drawing.FontStyle.Bold);
            this.lblNombreHero.ForeColor = Tema.AzulOscuro;
            this.lblNombreHero.Location = new System.Drawing.Point(55, 148);
            this.lblNombreHero.Name = "lblNombreHero";
            this.lblNombreHero.Size = new System.Drawing.Size(268, 47);
            this.lblNombreHero.TabIndex = 1;
            this.lblNombreHero.Text = "SANAR RURAL";
            //
            // lblSubtituloHero
            //
            this.lblSubtituloHero.AutoSize = true;
            this.lblSubtituloHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 13F, System.Drawing.FontStyle.Regular);
            this.lblSubtituloHero.ForeColor = Tema.AzulPrimario;
            this.lblSubtituloHero.Location = new System.Drawing.Point(58, 200);
            this.lblSubtituloHero.Name = "lblSubtituloHero";
            this.lblSubtituloHero.Size = new System.Drawing.Size(332, 25);
            this.lblSubtituloHero.TabIndex = 2;
            this.lblSubtituloHero.Text = "Sistema de Gestión Médica Comunitaria";
            //
            // lblDescripcionHero
            //
            this.lblDescripcionHero.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Regular);
            this.lblDescripcionHero.ForeColor = Tema.TextoSecundario;
            this.lblDescripcionHero.Location = new System.Drawing.Point(58, 235);
            this.lblDescripcionHero.Name = "lblDescripcionHero";
            this.lblDescripcionHero.Size = new System.Drawing.Size(480, 48);
            this.lblDescripcionHero.TabIndex = 3;
            this.lblDescripcionHero.Text = "Una solución integral para fortalecer la atención en salud en las comunidades rurales, facilitando el trabajo del personal médico.";
            //
            // panelSlideCard
            //
            this.panelSlideCard.BackColor = Tema.Superficie;
            this.panelSlideCard.Controls.Add(this.lblSlideIcono);
            this.panelSlideCard.Controls.Add(this.lblSlideTitulo);
            this.panelSlideCard.Controls.Add(this.lblSlideDescripcion);
            this.panelSlideCard.Location = new System.Drawing.Point(60, 300);
            this.panelSlideCard.Name = "panelSlideCard";
            this.panelSlideCard.Size = new System.Drawing.Size(480, 105);
            this.panelSlideCard.TabIndex = 4;
            this.panelSlideCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSlideCard_Paint);
            //
            // lblSlideIcono
            //
            this.lblSlideIcono.BackColor = Tema.FondoSecundario;
            this.lblSlideIcono.Font = new System.Drawing.Font(Tema.FamiliaFuente, 20F, System.Drawing.FontStyle.Regular);
            this.lblSlideIcono.Location = new System.Drawing.Point(16, 20);
            this.lblSlideIcono.Name = "lblSlideIcono";
            this.lblSlideIcono.Size = new System.Drawing.Size(55, 55);
            this.lblSlideIcono.TabIndex = 0;
            this.lblSlideIcono.Text = "👥";
            this.lblSlideIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSlideTitulo
            //
            this.lblSlideTitulo.AutoSize = true;
            this.lblSlideTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblSlideTitulo.ForeColor = Tema.AzulOscuro;
            this.lblSlideTitulo.Location = new System.Drawing.Point(82, 20);
            this.lblSlideTitulo.Name = "lblSlideTitulo";
            this.lblSlideTitulo.Size = new System.Drawing.Size(170, 21);
            this.lblSlideTitulo.TabIndex = 1;
            this.lblSlideTitulo.Text = "Gestión de Pacientes";
            //
            // lblSlideDescripcion
            //
            this.lblSlideDescripcion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F, System.Drawing.FontStyle.Regular);
            this.lblSlideDescripcion.ForeColor = Tema.TextoSecundario;
            this.lblSlideDescripcion.Location = new System.Drawing.Point(82, 45);
            this.lblSlideDescripcion.Name = "lblSlideDescripcion";
            this.lblSlideDescripcion.Size = new System.Drawing.Size(380, 48);
            this.lblSlideDescripcion.TabIndex = 2;
            this.lblSlideDescripcion.Text = "Registra y administra la información de los pacientes de la comunidad de forma ágil y segura.";
            //
            // panelSlideIndicadores
            //
            this.panelSlideIndicadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelSlideIndicadores.Location = new System.Drawing.Point(60, 415);
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
            this.panelLema.Location = new System.Drawing.Point(60, 455);
            this.panelLema.Name = "panelLema";
            this.panelLema.Size = new System.Drawing.Size(480, 65);
            this.panelLema.TabIndex = 6;
            this.panelLema.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLema_Paint);
            //
            // lblLemaComillas
            //
            this.lblLemaComillas.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold);
            this.lblLemaComillas.ForeColor = Tema.VerdeOscuro;
            this.lblLemaComillas.Location = new System.Drawing.Point(12, 10);
            this.lblLemaComillas.Name = "lblLemaComillas";
            this.lblLemaComillas.Size = new System.Drawing.Size(35, 42);
            this.lblLemaComillas.TabIndex = 0;
            this.lblLemaComillas.Text = "❝";
            this.lblLemaComillas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // lblLemaTexto
            //
            this.lblLemaTexto.AutoSize = true;
            this.lblLemaTexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Bold);
            this.lblLemaTexto.ForeColor = Tema.AzulOscuro;
            this.lblLemaTexto.Location = new System.Drawing.Point(50, 14);
            this.lblLemaTexto.Name = "lblLemaTexto";
            this.lblLemaTexto.Size = new System.Drawing.Size(225, 19);
            this.lblLemaTexto.TabIndex = 1;
            this.lblLemaTexto.Text = "Salud más cerca de nuestra gente";
            //
            // lblLemaSubtexto
            //
            this.lblLemaSubtexto.AutoSize = true;
            this.lblLemaSubtexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Italic);
            this.lblLemaSubtexto.ForeColor = Tema.TextoSecundario;
            this.lblLemaSubtexto.Location = new System.Drawing.Point(50, 36);
            this.lblLemaSubtexto.Name = "lblLemaSubtexto";
            this.lblLemaSubtexto.Size = new System.Drawing.Size(252, 15);
            this.lblLemaSubtexto.TabIndex = 2;
            this.lblLemaSubtexto.Text = "Atención médica integral, solidaria y comunitaria";
            //
            // panelAuth
            //
            this.panelAuth.BackColor = Tema.Fondo;
            this.panelAuth.Controls.Add(this.panelCard);
            this.panelAuth.Location = new System.Drawing.Point(650, 0);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(550, 700);
            this.panelAuth.TabIndex = 1;
            //
            // panelCard
            //
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.lblTituloBienvenido);
            this.panelCard.Controls.Add(this.lblSubtituloBienvenido);
            this.panelCard.Controls.Add(this.panelSeparador);
            this.panelCard.Controls.Add(this.lblCorreo);
            this.panelCard.Controls.Add(this.txtCorreo);
            this.panelCard.Controls.Add(this.lblErrorCorreo);
            this.panelCard.Controls.Add(this.lblContrasena);
            this.panelCard.Controls.Add(this.txtContrasena);
            this.panelCard.Controls.Add(this.btnVerContrasena);
            this.panelCard.Controls.Add(this.lblErrorContrasena);
            this.panelCard.Controls.Add(this.btnIniciarSesion);
            this.panelCard.Controls.Add(this.panelLineaInferior);
            this.panelCard.Controls.Add(this.lnkCrearUsuario);
            this.panelCard.Location = new System.Drawing.Point(50, 80);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(450, 480);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            //
            // lblTituloBienvenido
            //
            this.lblTituloBienvenido.AutoSize = true;
            this.lblTituloBienvenido.Font = new System.Drawing.Font(Tema.FamiliaFuente, 22F, System.Drawing.FontStyle.Bold);
            this.lblTituloBienvenido.ForeColor = Tema.AzulOscuro;
            this.lblTituloBienvenido.Location = new System.Drawing.Point(36, 30);
            this.lblTituloBienvenido.Name = "lblTituloBienvenido";
            this.lblTituloBienvenido.Size = new System.Drawing.Size(175, 40);
            this.lblTituloBienvenido.TabIndex = 0;
            this.lblTituloBienvenido.Text = "Bienvenido";
            //
            // lblSubtituloBienvenido
            //
            this.lblSubtituloBienvenido.AutoSize = true;
            this.lblSubtituloBienvenido.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Regular);
            this.lblSubtituloBienvenido.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloBienvenido.Location = new System.Drawing.Point(38, 72);
            this.lblSubtituloBienvenido.Name = "lblSubtituloBienvenido";
            this.lblSubtituloBienvenido.Size = new System.Drawing.Size(236, 19);
            this.lblSubtituloBienvenido.TabIndex = 1;
            this.lblSubtituloBienvenido.Text = "Inicia sesión para acceder al sistema";
            //
            // panelSeparador
            //
            this.panelSeparador.BackColor = Tema.FondoSecundario;
            this.panelSeparador.Location = new System.Drawing.Point(40, 102);
            this.panelSeparador.Name = "panelSeparador";
            this.panelSeparador.Size = new System.Drawing.Size(370, 2);
            this.panelSeparador.TabIndex = 2;
            //
            // lblCorreo
            //
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(38, 120);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(121, 17);
            this.lblCorreo.TabIndex = 3;
            this.lblCorreo.Text = "Correo Electrónico";
            //
            // txtCorreo
            //
            this.txtCorreo.Font = Tema.FuenteInput;
            this.txtCorreo.Location = new System.Drawing.Point(40, 142);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(370, 27);
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            //
            // lblErrorCorreo
            //
            this.lblErrorCorreo.Font = Tema.FuenteAyuda;
            this.lblErrorCorreo.ForeColor = Tema.Error;
            this.lblErrorCorreo.Location = new System.Drawing.Point(40, 172);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(370, 16);
            this.lblErrorCorreo.TabIndex = 4;
            //
            // lblContrasena
            //
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = Tema.FuenteLabelCampo;
            this.lblContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblContrasena.Location = new System.Drawing.Point(38, 192);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(77, 17);
            this.lblContrasena.TabIndex = 5;
            this.lblContrasena.Text = "Contraseña";
            //
            // txtContrasena
            //
            this.txtContrasena.Font = Tema.FuenteInput;
            this.txtContrasena.Location = new System.Drawing.Point(40, 214);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(325, 27);
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
            this.btnVerContrasena.Location = new System.Drawing.Point(370, 214);
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
            this.lblErrorContrasena.Location = new System.Drawing.Point(40, 244);
            this.lblErrorContrasena.Name = "lblErrorContrasena";
            this.lblErrorContrasena.Size = new System.Drawing.Size(370, 16);
            this.lblErrorContrasena.TabIndex = 6;
            this.lblErrorContrasena.Text = "La contraseña debe tener al menos 5 caracteres";
            //
            // btnIniciarSesion
            //
            this.btnIniciarSesion.BackColor = Tema.AzulPrimario;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = Tema.FuenteBoton;
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location = new System.Drawing.Point(40, 278);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(370, 44);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            //
            // panelLineaInferior
            //
            this.panelLineaInferior.BackColor = Tema.Borde;
            this.panelLineaInferior.Location = new System.Drawing.Point(40, 344);
            this.panelLineaInferior.Name = "panelLineaInferior";
            this.panelLineaInferior.Size = new System.Drawing.Size(370, 1);
            this.panelLineaInferior.TabIndex = 7;
            //
            // lnkCrearUsuario
            //
            this.lnkCrearUsuario.ActiveLinkColor = Tema.AzulOscuro;
            this.lnkCrearUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCrearUsuario.Font = Tema.FuenteCuerpo;
            this.lnkCrearUsuario.LinkColor = Tema.AzulPrimario;
            this.lnkCrearUsuario.Location = new System.Drawing.Point(40, 362);
            this.lnkCrearUsuario.Name = "lnkCrearUsuario";
            this.lnkCrearUsuario.Size = new System.Drawing.Size(370, 24);
            this.lnkCrearUsuario.TabIndex = 4;
            this.lnkCrearUsuario.TabStop = true;
            this.lnkCrearUsuario.Text = "¿No tienes una cuenta? Regístrate aquí";
            this.lnkCrearUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCrearUsuario.VisitedLinkColor = Tema.AzulPrimario;
            this.lnkCrearUsuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCrearUsuario_LinkClicked);
            //
            // timerSlides
            //
            this.timerSlides.Interval = 4500;
            this.timerSlides.Tick += new System.EventHandler(this.timerSlides_Tick);
            //
            // iniciarSesion
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelAuth);
            this.Controls.Add(this.panelHero);
            this.MinimumSize = new System.Drawing.Size(1024, 650);
            this.Name = "iniciarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Portal de Acceso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.iniciarSesion_Load);
            this.Resize += new System.EventHandler(this.iniciarSesion_Resize);
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
        private System.Windows.Forms.Label lblTituloBienvenido;
        private System.Windows.Forms.Label lblSubtituloBienvenido;
        private System.Windows.Forms.Panel panelSeparador;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblErrorCorreo;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnVerContrasena;
        private System.Windows.Forms.Label lblErrorContrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Panel panelLineaInferior;
        private System.Windows.Forms.LinkLabel lnkCrearUsuario;
        private System.Windows.Forms.Timer timerSlides;
    }
}
