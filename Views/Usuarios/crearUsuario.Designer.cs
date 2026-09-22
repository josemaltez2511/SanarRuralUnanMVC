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

            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;

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

            this.panelCard.Location = new System.Drawing.Point(125, 20);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 570);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint_1);

            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor =
                System.Drawing.Color.FromArgb(120, 190, 32);

            this.panelLineaVerde.Location =
                new System.Drawing.Point(40, 20);

            this.panelLineaVerde.Name =
                "panelLineaVerde";

            this.panelLineaVerde.Size =
                new System.Drawing.Size(6, 45);

            this.panelLineaVerde.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0))
                );

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.lblTitulo.Location =
                new System.Drawing.Point(52, 15);

            this.lblTitulo.Name =
                "lblTitulo";

            this.lblTitulo.Size =
                new System.Drawing.Size(181, 32);

            this.lblTitulo.TabIndex = 1;

            this.lblTitulo.Text =
                "SANAR RURAL";

            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0))
                );

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.FromArgb(100, 110, 120);

            this.lblSubtitulo.Location =
                new System.Drawing.Point(55, 45);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Size =
                new System.Drawing.Size(167, 17);

            this.lblSubtitulo.TabIndex = 2;

            this.lblSubtitulo.Text =
                "Registro de Nuevo Usuario";

            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;

            this.lblCorreo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblCorreo.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblCorreo.Location =
                new System.Drawing.Point(37, 110);

            this.lblCorreo.Name =
                "lblCorreo";

            this.lblCorreo.Size =
                new System.Drawing.Size(121, 17);

            this.lblCorreo.TabIndex = 3;

            this.lblCorreo.Text =
                "Correo Electrónico";

            this.lblCorreo.Click +=
                new System.EventHandler(this.lblCorreo_Click);

            // 
            // txtCorreo
            // 
            this.txtCorreo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtCorreo.Location =
                new System.Drawing.Point(40, 130);

            this.txtCorreo.Name =
                "txtCorreo";

            this.txtCorreo.Size =
                new System.Drawing.Size(420, 27);

            this.txtCorreo.TabIndex = 1;

            this.txtCorreo.TextChanged +=
                new System.EventHandler(this.txtCorreo_TextChanged);

            // 
            // lblErrorCorreo
            // 
            this.lblErrorCorreo.AutoSize = true;

            this.lblErrorCorreo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F
                );

            this.lblErrorCorreo.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorCorreo.Location =
                new System.Drawing.Point(40, 160);

            this.lblErrorCorreo.Name =
                "lblErrorCorreo";

            this.lblErrorCorreo.Size =
                new System.Drawing.Size(0, 15);

            this.lblErrorCorreo.TabIndex = 4;

            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;

            this.lblContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblContrasena.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblContrasena.Location =
                new System.Drawing.Point(37, 200);

            this.lblContrasena.Name =
                "lblContrasena";

            this.lblContrasena.Size =
                new System.Drawing.Size(77, 17);

            this.lblContrasena.TabIndex = 5;

            this.lblContrasena.Text =
                "Contraseña";

            // 
            // txtContrasena
            // 
            this.txtContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtContrasena.Location =
                new System.Drawing.Point(40, 220);

            this.txtContrasena.Name =
                "txtContrasena";

            this.txtContrasena.PasswordChar =
                '●';

            this.txtContrasena.Size =
                new System.Drawing.Size(375, 27);

            this.txtContrasena.TabIndex = 2;

            this.txtContrasena.TextChanged +=
                new System.EventHandler(this.txtContrasena_TextChanged);

            // 
            // btnVerContrasena
            // 
            this.btnVerContrasena.BackColor =
                System.Drawing.Color.White;

            this.btnVerContrasena.FlatAppearance.BorderColor =
                System.Drawing.Color.LightGray;

            this.btnVerContrasena.FlatAppearance.BorderSize = 1;

            this.btnVerContrasena.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnVerContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.btnVerContrasena.Location =
                new System.Drawing.Point(420, 220);

            this.btnVerContrasena.Name =
                "btnVerContrasena";

            this.btnVerContrasena.Size =
                new System.Drawing.Size(40, 27);

            this.btnVerContrasena.TabIndex = 3;

            this.btnVerContrasena.Text =
                "👁";

            this.btnVerContrasena.UseVisualStyleBackColor =
                false;

            this.btnVerContrasena.Click +=
                new System.EventHandler(this.btnVerContrasena_Click);

            // 
            // lblErrorContrasena
            // 
            this.lblErrorContrasena.AutoSize = true;

            this.lblErrorContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F
                );

            this.lblErrorContrasena.ForeColor =
                System.Drawing.Color.FromArgb(100, 110, 120);

            this.lblErrorContrasena.Location =
                new System.Drawing.Point(40, 250);

            this.lblErrorContrasena.Name =
                "lblErrorContrasena";

            this.lblErrorContrasena.Size =
                new System.Drawing.Size(243, 15);

            this.lblErrorContrasena.TabIndex = 6;

            this.lblErrorContrasena.Text =
                "La contraseña debe ser al menos 5 caracteres";

            // 
            // lblConfirmarContrasena
            // 
            this.lblConfirmarContrasena.AutoSize = true;

            this.lblConfirmarContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblConfirmarContrasena.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblConfirmarContrasena.Location =
                new System.Drawing.Point(37, 290);

            this.lblConfirmarContrasena.Name =
                "lblConfirmarContrasena";

            this.lblConfirmarContrasena.Size =
                new System.Drawing.Size(143, 17);

            this.lblConfirmarContrasena.TabIndex = 7;

            this.lblConfirmarContrasena.Text =
                "Confirmar Contraseña";

            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtConfirmarContrasena.Location =
                new System.Drawing.Point(40, 310);

            this.txtConfirmarContrasena.Name =
                "txtConfirmarContrasena";

            this.txtConfirmarContrasena.PasswordChar =
                '●';

            this.txtConfirmarContrasena.Size =
                new System.Drawing.Size(375, 27);

            this.txtConfirmarContrasena.TabIndex = 4;

            this.txtConfirmarContrasena.TextChanged +=
                new System.EventHandler(
                    this.txtConfirmarContrasena_TextChanged
                );

            // 
            // btnVerConfirmarContrasena
            // 
            this.btnVerConfirmarContrasena.BackColor =
                System.Drawing.Color.White;

            this.btnVerConfirmarContrasena.FlatAppearance.BorderColor =
                System.Drawing.Color.LightGray;

            this.btnVerConfirmarContrasena.FlatAppearance.BorderSize = 1;

            this.btnVerConfirmarContrasena.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnVerConfirmarContrasena.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.btnVerConfirmarContrasena.Location =
                new System.Drawing.Point(420, 310);

            this.btnVerConfirmarContrasena.Name =
                "btnVerConfirmarContrasena";

            this.btnVerConfirmarContrasena.Size =
                new System.Drawing.Size(40, 27);

            this.btnVerConfirmarContrasena.TabIndex = 5;

            this.btnVerConfirmarContrasena.Text =
                "👁";

            this.btnVerConfirmarContrasena.UseVisualStyleBackColor =
                false;

            this.btnVerConfirmarContrasena.Click +=
                new System.EventHandler(
                    this.btnVerConfirmarContrasena_Click
                );

            // 
            // lblErrorConfirmar
            // 
            this.lblErrorConfirmar.AutoSize = true;

            this.lblErrorConfirmar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F
                );

            this.lblErrorConfirmar.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorConfirmar.Location =
                new System.Drawing.Point(40, 340);

            this.lblErrorConfirmar.Name =
                "lblErrorConfirmar";

            this.lblErrorConfirmar.Size =
                new System.Drawing.Size(0, 15);

            this.lblErrorConfirmar.TabIndex = 8;

            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.AutoSize = true;

            this.lblTipoUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTipoUsuario.ForeColor =
                System.Drawing.Color.FromArgb(50, 60, 70);

            this.lblTipoUsuario.Location =
                new System.Drawing.Point(37, 360);

            this.lblTipoUsuario.Name =
                "lblTipoUsuario";

            this.lblTipoUsuario.Size =
                new System.Drawing.Size(120, 17);

            this.lblTipoUsuario.TabIndex = 9;

            this.lblTipoUsuario.Text =
                "Tipo de usuario";

            // 
            // rbPaciente
            // 
            this.rbPaciente.AutoSize = true;

            this.rbPaciente.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.rbPaciente.Location =
                new System.Drawing.Point(40, 382);

            this.rbPaciente.Name =
                "rbPaciente";

            this.rbPaciente.Size =
                new System.Drawing.Size(90, 24);

            this.rbPaciente.TabIndex = 6;

            this.rbPaciente.TabStop = true;

            this.rbPaciente.Text =
                "Paciente";

            this.rbPaciente.UseVisualStyleBackColor =
                true;

            // 
            // rbMedico
            // 
            this.rbMedico.AutoSize = true;

            this.rbMedico.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F
                );

            this.rbMedico.Location =
                new System.Drawing.Point(200, 382);

            this.rbMedico.Name =
                "rbMedico";

            this.rbMedico.Size =
                new System.Drawing.Size(220, 24);

            this.rbMedico.TabIndex = 7;

            this.rbMedico.Text =
                "Médico / Personal de salud";

            this.rbMedico.UseVisualStyleBackColor =
                true;

            // 
            // btnGuardar
            // 
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
                new System.Drawing.Point(40, 451);

            this.btnGuardar.Name =
                "btnGuardar";

            this.btnGuardar.Size =
                new System.Drawing.Size(420, 40);

            this.btnGuardar.TabIndex = 8;

            this.btnGuardar.Text =
                "Guardar Usuario";

            this.btnGuardar.UseVisualStyleBackColor =
                false;

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            // 
            // lnkVolver
            // 
            this.lnkVolver.AutoSize = true;

            this.lnkVolver.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F
                );

            this.lnkVolver.LinkColor =
                System.Drawing.Color.FromArgb(27, 108, 168);

            this.lnkVolver.Location =
                new System.Drawing.Point(141, 517);

            this.lnkVolver.Name =
                "lnkVolver";

            this.lnkVolver.Size =
                new System.Drawing.Size(193, 17);

            this.lnkVolver.TabIndex = 12;

            this.lnkVolver.TabStop = true;

            this.lnkVolver.Text =
                "¿Ya tienes cuenta? Iniciar Sesión";

            this.lnkVolver.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                    this.lnkVolver_LinkClicked
                );

            // 
            // crearUsuario
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(238, 243, 248);

            this.ClientSize =
                new System.Drawing.Size(750, 620);

            this.Controls.Add(this.panelCard);

            this.Name =
                "crearUsuario";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Sanar Rural - Registro de Usuario";

            this.Load +=
                new System.EventHandler(this.crearUsuario_Load);

            this.Resize +=
                new System.EventHandler(this.crearUsuario_Resize);

            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
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
    }
}