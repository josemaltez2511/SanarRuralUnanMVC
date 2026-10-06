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
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = Tema.Superficie;
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
            this.panelCard.Location = new System.Drawing.Point(125, 30);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 460);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor = Tema.VerdeAcento;
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 20);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(6, 45);
            this.panelLineaVerde.TabIndex = 7;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteCuerpo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(55, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(167, 17);
            this.lblSubtitulo.TabIndex = 6;
            this.lblSubtitulo.Text = "Sistema de Gestión Médica";
            this.lblSubtitulo.Click += new System.EventHandler(this.lblSubtitulo_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(52, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 32);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "SANAR RURAL";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = Tema.AzulPrimario;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = Tema.FuenteLabelCampo;
            this.btnIniciarSesion.ForeColor = Tema.Superficie;
            this.btnIniciarSesion.Location = new System.Drawing.Point(40, 350);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(420, 40);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = Tema.FuenteInput;
            this.txtContrasena.Location = new System.Drawing.Point(40, 240);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(375, 27);
            this.txtContrasena.TabIndex = 2;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // btnVerContrasena
            // 
            this.btnVerContrasena.BackColor = Tema.Superficie;
            this.btnVerContrasena.FlatAppearance.BorderColor = Tema.Borde;
            this.btnVerContrasena.FlatAppearance.BorderSize = 1;
            this.btnVerContrasena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerContrasena.Font = Tema.FuenteCuerpo;
            this.btnVerContrasena.Location = new System.Drawing.Point(420, 240);
            this.btnVerContrasena.Name = "btnVerContrasena";
            this.btnVerContrasena.Size = new System.Drawing.Size(40, 27);
            this.btnVerContrasena.TabIndex = 3;
            this.btnVerContrasena.Text = "👁";
            this.btnVerContrasena.UseVisualStyleBackColor = false;
            this.btnVerContrasena.Click += new System.EventHandler(this.btnVerContrasena_Click);
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = Tema.FuenteLabelCampo;
            this.lblContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblContrasena.Location = new System.Drawing.Point(37, 220);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(77, 17);
            this.lblContrasena.TabIndex = 2;
            this.lblContrasena.Text = "Contraseña";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = Tema.FuenteInput;
            this.txtCorreo.Location = new System.Drawing.Point(40, 135);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(420, 27);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(37, 115);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(121, 17);
            this.lblCorreo.TabIndex = 0;
            this.lblCorreo.Text = "Correo Electrónico";
            // 
            // lnkCrearUsuario
            // 
            this.lnkCrearUsuario.AutoSize = true;
            this.lnkCrearUsuario.Font = Tema.FuenteCuerpo;
            this.lnkCrearUsuario.LinkColor = Tema.AzulPrimario;
            this.lnkCrearUsuario.Location = new System.Drawing.Point(145, 410);
            this.lnkCrearUsuario.Name = "lnkCrearUsuario";
            this.lnkCrearUsuario.Size = new System.Drawing.Size(203, 17);
            this.lnkCrearUsuario.TabIndex = 5;
            this.lnkCrearUsuario.TabStop = true;
            this.lnkCrearUsuario.Text = "¿No tienes cuenta? Crear Usuario";
            this.lnkCrearUsuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCrearUsuario_LinkClicked);
            // 
            // lblErrorCorreo
            // 
            this.lblErrorCorreo.AutoSize = true;
            this.lblErrorCorreo.Font = Tema.FuenteAyuda;
            this.lblErrorCorreo.ForeColor = Tema.Error;
            this.lblErrorCorreo.Location = new System.Drawing.Point(40, 165);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(0, 15);
            this.lblErrorCorreo.TabIndex = 8;
            // 
            // lblErrorContrasena
            // 
            this.lblErrorContrasena.AutoSize = true;
            this.lblErrorContrasena.Font = Tema.FuenteAyuda;
            this.lblErrorContrasena.ForeColor = Tema.TextoSecundario;
            this.lblErrorContrasena.Location = new System.Drawing.Point(40, 270);
            this.lblErrorContrasena.Name = "lblErrorContrasena";
            this.lblErrorContrasena.Size = new System.Drawing.Size(230, 15);
            this.lblErrorContrasena.TabIndex = 9;
            this.lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";
            // 
            // iniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(750, 520);
            this.Controls.Add(this.panelCard);
            this.Name = "iniciarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Portal de Acceso";
            this.Load += new System.EventHandler(this.iniciarSesion_Load);
            this.Resize += new System.EventHandler(this.iniciarSesion_Resize);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
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