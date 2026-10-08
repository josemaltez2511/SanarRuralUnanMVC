using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class crearUsuario
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

            this.btnGuardar = new System.Windows.Forms.Button();

            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.btnVerConfirmarContrasena = new System.Windows.Forms.Button();
            this.lblConfirmarContrasena = new System.Windows.Forms.Label();

            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnVerContrasena = new System.Windows.Forms.Button();
            this.lblContrasena = new System.Windows.Forms.Label();

            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();

            this.lnkVolver = new System.Windows.Forms.LinkLabel();

            this.lblErrorCorreo = new System.Windows.Forms.Label();
            this.lblErrorContrasena = new System.Windows.Forms.Label();
            this.lblErrorConfirmar = new System.Windows.Forms.Label();

            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.rbPaciente = new System.Windows.Forms.RadioButton();
            this.rbMedico = new System.Windows.Forms.RadioButton();

            this.panelTarjetaPaciente = new TarjetaRolPanel();
            this.panelTarjetaMedico = new TarjetaRolPanel();
            this.cmbRol = new System.Windows.Forms.ComboBox();

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
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.txtConfirmarContrasena);
            this.panelCard.Controls.Add(this.btnVerConfirmarContrasena);
            this.panelCard.Controls.Add(this.lblConfirmarContrasena);
            this.panelCard.Controls.Add(this.txtContrasena);
            this.panelCard.Controls.Add(this.btnVerContrasena);
            this.panelCard.Controls.Add(this.lblContrasena);
            this.panelCard.Controls.Add(this.txtCorreo);
            this.panelCard.Controls.Add(this.lblCorreo);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Controls.Add(this.lblErrorCorreo);
            this.panelCard.Controls.Add(this.lblErrorContrasena);
            this.panelCard.Controls.Add(this.lblErrorConfirmar);
            this.panelCard.Controls.Add(this.lblTipoUsuario);
            this.panelCard.Controls.Add(this.rbPaciente);
            this.panelCard.Controls.Add(this.rbMedico);
            this.panelCard.Controls.Add(this.panelTarjetaPaciente);
            this.panelCard.Controls.Add(this.panelTarjetaMedico);
            this.panelCard.Controls.Add(this.cmbRol);
            this.panelCard.Location = new System.Drawing.Point(110, 30);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 525);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint_1);

            //
            // picLogo
            //
            this.picLogo.AccessibleDescription = "Identidad visual de Sanar Rural";
            this.picLogo.AccessibleName = "Logo Sanar Rural";
            this.picLogo.Location = new System.Drawing.Point(185, 18);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(130, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 13;
            this.picLogo.TabStop = false;

            //
            // lblTitulo
            //
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(20, 72);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(460, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "SANAR RURAL";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // lblSubtitulo
            //
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 104);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(460, 18);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Registro de Nuevo Usuario";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // panelLineaVerde
            //
            this.panelLineaVerde.BackColor = Tema.FondoSecundario;
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 130);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(420, 2);
            this.panelLineaVerde.TabIndex = 0;

            //
            // lblCorreo
            //
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(38, 142);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(121, 17);
            this.lblCorreo.TabIndex = 3;
            this.lblCorreo.Text = "Correo Electrónico";
            this.lblCorreo.Click += new System.EventHandler(this.lblCorreo_Click);

            //
            // txtCorreo
            //
            this.txtCorreo.Font = Tema.FuenteInput;
            this.txtCorreo.Location = new System.Drawing.Point(40, 162);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(420, 27);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);

            //
            // lblErrorCorreo
            //
            this.lblErrorCorreo.Font = Tema.FuenteAyuda;
            this.lblErrorCorreo.ForeColor = Tema.Error;
            this.lblErrorCorreo.Location = new System.Drawing.Point(40, 191);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(420, 16);
            this.lblErrorCorreo.TabIndex = 4;

            //
            // lblContrasena
            //
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = Tema.FuenteLabelCampo;
            this.lblContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblContrasena.Location = new System.Drawing.Point(38, 209);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(77, 17);
            this.lblContrasena.TabIndex = 5;
            this.lblContrasena.Text = "Contraseña";

            //
            // txtContrasena
            //
            this.txtContrasena.Font = Tema.FuenteInput;
            this.txtContrasena.Location = new System.Drawing.Point(40, 229);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(375, 27);
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
            this.btnVerContrasena.Location = new System.Drawing.Point(420, 229);
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
            this.lblErrorContrasena.Location = new System.Drawing.Point(40, 258);
            this.lblErrorContrasena.Name = "lblErrorContrasena";
            this.lblErrorContrasena.Size = new System.Drawing.Size(420, 16);
            this.lblErrorContrasena.TabIndex = 6;
            this.lblErrorContrasena.Text = "La contraseña debe ser al menos 5 caracteres";

            //
            // lblConfirmarContrasena
            //
            this.lblConfirmarContrasena.AutoSize = true;
            this.lblConfirmarContrasena.Font = Tema.FuenteLabelCampo;
            this.lblConfirmarContrasena.ForeColor = Tema.TextoPrincipal;
            this.lblConfirmarContrasena.Location = new System.Drawing.Point(38, 276);
            this.lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            this.lblConfirmarContrasena.Size = new System.Drawing.Size(143, 17);
            this.lblConfirmarContrasena.TabIndex = 7;
            this.lblConfirmarContrasena.Text = "Confirmar Contraseña";

            //
            // txtConfirmarContrasena
            //
            this.txtConfirmarContrasena.Font = Tema.FuenteInput;
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(40, 296);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '●';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(375, 27);
            this.txtConfirmarContrasena.TabIndex = 4;
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
            this.btnVerConfirmarContrasena.Location = new System.Drawing.Point(420, 296);
            this.btnVerConfirmarContrasena.Name = "btnVerConfirmarContrasena";
            this.btnVerConfirmarContrasena.Size = new System.Drawing.Size(40, 27);
            this.btnVerConfirmarContrasena.TabIndex = 5;
            this.btnVerConfirmarContrasena.Text = "👁";
            this.btnVerConfirmarContrasena.UseVisualStyleBackColor = false;
            this.btnVerConfirmarContrasena.Click += new System.EventHandler(this.btnVerConfirmarContrasena_Click);

            //
            // lblErrorConfirmar
            //
            this.lblErrorConfirmar.Font = Tema.FuenteAyuda;
            this.lblErrorConfirmar.ForeColor = Tema.Error;
            this.lblErrorConfirmar.Location = new System.Drawing.Point(40, 325);
            this.lblErrorConfirmar.Name = "lblErrorConfirmar";
            this.lblErrorConfirmar.Size = new System.Drawing.Size(420, 16);
            this.lblErrorConfirmar.TabIndex = 8;

            //
            // lblTipoUsuario
            //
            this.lblTipoUsuario.AutoSize = true;
            this.lblTipoUsuario.Font = Tema.FuenteLabelCampo;
            this.lblTipoUsuario.ForeColor = Tema.TextoPrincipal;
            this.lblTipoUsuario.Location = new System.Drawing.Point(38, 343);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(120, 17);
            this.lblTipoUsuario.TabIndex = 9;
            this.lblTipoUsuario.Text = "Tipo de usuario";

            //
            // rbPaciente
            //
            this.rbPaciente.AutoSize = true;
            this.rbPaciente.Location = new System.Drawing.Point(40, 365);
            this.rbPaciente.Name = "rbPaciente";
            this.rbPaciente.Size = new System.Drawing.Size(90, 24);
            this.rbPaciente.TabIndex = 20;
            this.rbPaciente.TabStop = false;
            this.rbPaciente.Text = "Paciente";
            this.rbPaciente.UseVisualStyleBackColor = true;
            this.rbPaciente.Visible = false;

            //
            // rbMedico
            //
            this.rbMedico.AutoSize = true;
            this.rbMedico.Location = new System.Drawing.Point(260, 365);
            this.rbMedico.Name = "rbMedico";
            this.rbMedico.Size = new System.Drawing.Size(220, 24);
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
            this.panelTarjetaPaciente.Location = new System.Drawing.Point(40, 365);
            this.panelTarjetaPaciente.Name = "panelTarjetaPaciente";
            this.panelTarjetaPaciente.Size = new System.Drawing.Size(200, 46);
            this.panelTarjetaPaciente.TabIndex = 6;
            this.panelTarjetaPaciente.TabStop = true;

            //
            // panelTarjetaMedico
            //
            this.panelTarjetaMedico.AccessibleDescription = "Seleccionar rol de Médico o Personal de salud";
            this.panelTarjetaMedico.AccessibleName = "Médico o Personal de salud";
            this.panelTarjetaMedico.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.panelTarjetaMedico.Location = new System.Drawing.Point(260, 365);
            this.panelTarjetaMedico.Name = "panelTarjetaMedico";
            this.panelTarjetaMedico.Size = new System.Drawing.Size(200, 46);
            this.panelTarjetaMedico.TabIndex = 7;
            this.panelTarjetaMedico.TabStop = true;

            //
            // cmbRol
            //
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Font = Tema.FuenteInput;
            this.cmbRol.Location = new System.Drawing.Point(40, 365);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(420, 28);
            this.cmbRol.TabIndex = 7;
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
            this.btnGuardar.Location = new System.Drawing.Point(40, 428);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(420, 42);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            //
            // lnkVolver
            //
            this.lnkVolver.ActiveLinkColor = Tema.AzulOscuro;
            this.lnkVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkVolver.Font = Tema.FuenteCuerpo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(20, 485);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(460, 20);
            this.lnkVolver.TabIndex = 12;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "¿Ya tienes cuenta? Iniciar Sesión";
            this.lnkVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkVolver.VisitedLinkColor = Tema.AzulPrimario;
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);

            //
            // crearUsuario
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(600, 580);
            this.Name = "crearUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Sanar Rural - Registro de Usuario";
            this.Load += new System.EventHandler(this.crearUsuario_Load);
            this.Resize += new System.EventHandler(this.crearUsuario_Resize);

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

        private System.Windows.Forms.Button btnGuardar;

        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Button btnVerConfirmarContrasena;
        private System.Windows.Forms.Label lblConfirmarContrasena;

        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnVerContrasena;
        private System.Windows.Forms.Label lblContrasena;

        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;

        private System.Windows.Forms.LinkLabel lnkVolver;

        private System.Windows.Forms.Label lblErrorCorreo;
        private System.Windows.Forms.Label lblErrorContrasena;
        private System.Windows.Forms.Label lblErrorConfirmar;

        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.RadioButton rbPaciente;
        private System.Windows.Forms.RadioButton rbMedico;

        private TarjetaRolPanel panelTarjetaPaciente;
        private TarjetaRolPanel panelTarjetaMedico;
        private System.Windows.Forms.ComboBox cmbRol;
    }
}
