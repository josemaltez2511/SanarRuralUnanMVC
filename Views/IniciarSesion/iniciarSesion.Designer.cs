using SanarRuralUnan.Helpers;

namespace SanarRuralUnan
{
    partial class iniciarSesion
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelLineaVerde = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnVerContrasena = new System.Windows.Forms.Button();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lnkCrearUsuario = new System.Windows.Forms.LinkLabel();
            this.lblErrorCorreo = new System.Windows.Forms.Label();
            this.lblErrorContrasena = new System.Windows.Forms.Label();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            //
            // panelCard
            //
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.picLogo);
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.btnIniciarSesion);
            this.panelCard.Controls.Add(this.txtContrasena);
            this.panelCard.Controls.Add(this.btnVerContrasena);
            this.panelCard.Controls.Add(this.lblContrasena);
            this.panelCard.Controls.Add(this.txtCorreo);
            this.panelCard.Controls.Add(this.lblCorreo);
            this.panelCard.Controls.Add(this.lnkCrearUsuario);
            this.panelCard.Controls.Add(this.lblErrorCorreo);
            this.panelCard.Controls.Add(this.lblErrorContrasena);
            this.panelCard.Location = new System.Drawing.Point(120, 50);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(460, 420);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            //
            // picLogo
            //
            this.picLogo.AccessibleDescription = "Identidad visual de Sanar Rural";
            this.picLogo.AccessibleName = "Logo Sanar Rural";
            this.picLogo.Location = new System.Drawing.Point(165, 18);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(130, 52);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            //
            // lblTitulo
            //
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(30, 74);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "SANAR RURAL";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(30, 108);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 18);
            this.lblSubtitulo.TabIndex = 6;
            this.lblSubtitulo.Text = "Sistema de Gestión Médica Comunitaria";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.Click += new System.EventHandler(this.lblSubtitulo_Click);
            //
            // panelLineaVerde
            //
            this.panelLineaVerde.BackColor = Tema.FondoSecundario;
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 134);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(380, 2);
            this.panelLineaVerde.TabIndex = 7;
            //
            // lblCorreo
            //
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(38, 148);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(121, 17);
            this.lblCorreo.TabIndex = 0;
            this.lblCorreo.Text = "Correo Electrónico";
            //
            // txtCorreo
            //
            this.txtCorreo.Font = Tema.FuenteInput;
            this.txtCorreo.Location = new System.Drawing.Point(40, 170);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(380, 27);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            //
            // lblErrorCorreo
            //
            this.lblErrorCorreo.Font = Tema.FuenteAyuda;
            this.lblErrorCorreo.ForeColor = Tema.Error;
            this.lblErrorCorreo.Location = new System.Drawing.Point(40, 200);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(380, 16);
            this.lblErrorCorreo.TabIndex = 8;
            //
            // lblContrasena
            //
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = Tema.FuenteLabelCampo;
            this.lblContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblContrasena.Location = new System.Drawing.Point(38, 220);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(77, 17);
            this.lblContrasena.TabIndex = 2;
            this.lblContrasena.Text = "Contraseña";
            //
            // txtContrasena
            //
            this.txtContrasena.Font = Tema.FuenteInput;
            this.txtContrasena.Location = new System.Drawing.Point(40, 242);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(335, 27);
            this.txtContrasena.TabIndex = 2;
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
            this.btnVerContrasena.Location = new System.Drawing.Point(380, 242);
            this.btnVerContrasena.Name = "btnVerContrasena";
            this.btnVerContrasena.Size = new System.Drawing.Size(40, 27);
            this.btnVerContrasena.TabIndex = 3;
            this.btnVerContrasena.Text = "👁";
            this.btnVerContrasena.UseVisualStyleBackColor = false;
            this.btnVerContrasena.Click += new System.EventHandler(this.btnVerContrasena_Click);
            //
            // lblErrorContrasena
            //
            this.lblErrorContrasena.Font = Tema.FuenteAyuda;
            this.lblErrorContrasena.ForeColor = Tema.TextoSecundario;
            this.lblErrorContrasena.Location = new System.Drawing.Point(40, 272);
            this.lblErrorContrasena.Name = "lblErrorContrasena";
            this.lblErrorContrasena.Size = new System.Drawing.Size(380, 16);
            this.lblErrorContrasena.TabIndex = 9;
            this.lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
            //
            // btnIniciarSesion
            //
            this.btnIniciarSesion.BackColor = Tema.AzulPrimario;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = Tema.FuenteBoton;
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location = new System.Drawing.Point(40, 310);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(380, 42);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            //
            // lnkCrearUsuario
            //
            this.lnkCrearUsuario.ActiveLinkColor = Tema.AzulOscuro;
            this.lnkCrearUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCrearUsuario.Font = Tema.FuenteCuerpo;
            this.lnkCrearUsuario.LinkColor = Tema.AzulPrimario;
            this.lnkCrearUsuario.Location = new System.Drawing.Point(30, 365);
            this.lnkCrearUsuario.Name = "lnkCrearUsuario";
            this.lnkCrearUsuario.Size = new System.Drawing.Size(400, 20);
            this.lnkCrearUsuario.TabIndex = 5;
            this.lnkCrearUsuario.TabStop = true;
            this.lnkCrearUsuario.Text = "¿No tienes una cuenta? Regístrate aquí";
            this.lnkCrearUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCrearUsuario.VisitedLinkColor = Tema.AzulPrimario;
            this.lnkCrearUsuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCrearUsuario_LinkClicked);
            //
            // iniciarSesion
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.Controls.Add(this.panelCard);
            this.MinimumSize = new System.Drawing.Size(520, 480);
            this.Name = "iniciarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Portal de Acceso";
            this.Load += new System.EventHandler(this.iniciarSesion_Load);
            this.Resize += new System.EventHandler(this.iniciarSesion_Resize);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnVerContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.LinkLabel lnkCrearUsuario;
        private System.Windows.Forms.Label lblErrorCorreo;
        private System.Windows.Forms.Label lblErrorContrasena;
    }
}
