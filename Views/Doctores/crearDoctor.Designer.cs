namespace SanarRuralUnan.Views
{
    partial class crearDoctor
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

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblErrorNombres = new System.Windows.Forms.Label();

            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblErrorApellidos = new System.Windows.Forms.Label();

            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();

            this.lblNumeroLicencia = new System.Windows.Forms.Label();
            this.txtNumeroLicencia = new System.Windows.Forms.TextBox();
            this.lblErrorLicencia = new System.Windows.Forms.Label();

            this.lblHospital = new System.Windows.Forms.Label();
            this.cmbHospital = new System.Windows.Forms.ComboBox();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();

            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;

            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);

            this.panelCard.Controls.Add(this.lblNombres);
            this.panelCard.Controls.Add(this.txtNombres);
            this.panelCard.Controls.Add(this.lblErrorNombres);

            this.panelCard.Controls.Add(this.lblApellidos);
            this.panelCard.Controls.Add(this.txtApellidos);
            this.panelCard.Controls.Add(this.lblErrorApellidos);

            this.panelCard.Controls.Add(this.lblEspecialidad);
            this.panelCard.Controls.Add(this.txtEspecialidad);

            this.panelCard.Controls.Add(this.lblNumeroLicencia);
            this.panelCard.Controls.Add(this.txtNumeroLicencia);
            this.panelCard.Controls.Add(this.lblErrorLicencia);

            this.panelCard.Controls.Add(this.lblHospital);
            this.panelCard.Controls.Add(this.cmbHospital);

            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);

            this.panelCard.Location = new System.Drawing.Point(275, 80);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(600, 620);
            this.panelCard.TabIndex = 0;

            this.panelCard.Paint +=
                new System.Windows.Forms.PaintEventHandler(
                    this.panelCard_Paint
                );

            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(120)))),
                    ((int)(((byte)(190)))),
                    ((int)(((byte)(32))))
                );

            this.panelLineaVerde.Location =
                new System.Drawing.Point(45, 25);

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
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(27)))),
                    ((int)(((byte)(108)))),
                    ((int)(((byte)(168))))
                );

            this.lblTitulo.Location =
                new System.Drawing.Point(58, 20);

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
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(100)))),
                    ((int)(((byte)(110)))),
                    ((int)(((byte)(120))))
                );

            this.lblSubtitulo.Location =
                new System.Drawing.Point(61, 50);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Size =
                new System.Drawing.Size(196, 17);

            this.lblSubtitulo.TabIndex = 2;

            this.lblSubtitulo.Text =
                "Registro de Datos del Doctor";

            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;

            this.lblNombres.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblNombres.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(50)))),
                    ((int)(((byte)(60)))),
                    ((int)(((byte)(70))))
                );

            this.lblNombres.Location =
                new System.Drawing.Point(42, 105);

            this.lblNombres.Name =
                "lblNombres";

            this.lblNombres.Size =
                new System.Drawing.Size(64, 17);

            this.lblNombres.TabIndex = 3;

            this.lblNombres.Text =
                "Nombres";

            // 
            // txtNombres
            // 
            this.txtNombres.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtNombres.Location =
                new System.Drawing.Point(45, 127);

            this.txtNombres.Name =
                "txtNombres";

            this.txtNombres.Size =
                new System.Drawing.Size(510, 27);

            this.txtNombres.TabIndex = 1;

            this.txtNombres.TextChanged +=
                new System.EventHandler(
                    this.txtNombres_TextChanged
                );

            // 
            // lblErrorNombres
            // 
            this.lblErrorNombres.AutoSize = true;

            this.lblErrorNombres.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F
                );

            this.lblErrorNombres.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorNombres.Location =
                new System.Drawing.Point(45, 157);

            this.lblErrorNombres.Name =
                "lblErrorNombres";

            this.lblErrorNombres.Size =
                new System.Drawing.Size(0, 15);

            this.lblErrorNombres.TabIndex = 4;

            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;

            this.lblApellidos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblApellidos.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(50)))),
                    ((int)(((byte)(60)))),
                    ((int)(((byte)(70))))
                );

            this.lblApellidos.Location =
                new System.Drawing.Point(42, 190);

            this.lblApellidos.Name =
                "lblApellidos";

            this.lblApellidos.Size =
                new System.Drawing.Size(66, 17);

            this.lblApellidos.TabIndex = 5;

            this.lblApellidos.Text =
                "Apellidos";

            // 
            // txtApellidos
            // 
            this.txtApellidos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtApellidos.Location =
                new System.Drawing.Point(45, 212);

            this.txtApellidos.Name =
                "txtApellidos";

            this.txtApellidos.Size =
                new System.Drawing.Size(510, 27);

            this.txtApellidos.TabIndex = 2;

            this.txtApellidos.TextChanged +=
                new System.EventHandler(
                    this.txtApellidos_TextChanged
                );

            // 
            // lblErrorApellidos
            // 
            this.lblErrorApellidos.AutoSize = true;

            this.lblErrorApellidos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F
                );

            this.lblErrorApellidos.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorApellidos.Location =
                new System.Drawing.Point(45, 242);

            this.lblErrorApellidos.Name =
                "lblErrorApellidos";

            this.lblErrorApellidos.Size =
                new System.Drawing.Size(0, 15);

            this.lblErrorApellidos.TabIndex = 6;

            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;

            this.lblEspecialidad.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblEspecialidad.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(50)))),
                    ((int)(((byte)(60)))),
                    ((int)(((byte)(70))))
                );

            this.lblEspecialidad.Location =
                new System.Drawing.Point(42, 275);

            this.lblEspecialidad.Name =
                "lblEspecialidad";

            this.lblEspecialidad.Size =
                new System.Drawing.Size(83, 17);

            this.lblEspecialidad.TabIndex = 7;

            this.lblEspecialidad.Text =
                "Especialidad";

            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtEspecialidad.Location =
                new System.Drawing.Point(45, 297);

            this.txtEspecialidad.Name =
                "txtEspecialidad";

            this.txtEspecialidad.Size =
                new System.Drawing.Size(510, 27);

            this.txtEspecialidad.TabIndex = 3;

            // 
            // lblNumeroLicencia
            // 
            this.lblNumeroLicencia.AutoSize = true;

            this.lblNumeroLicencia.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblNumeroLicencia.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(50)))),
                    ((int)(((byte)(60)))),
                    ((int)(((byte)(70))))
                );

            this.lblNumeroLicencia.Location =
                new System.Drawing.Point(42, 350);

            this.lblNumeroLicencia.Name =
                "lblNumeroLicencia";

            this.lblNumeroLicencia.Size =
                new System.Drawing.Size(139, 17);

            this.lblNumeroLicencia.TabIndex = 8;

            this.lblNumeroLicencia.Text =
                "Número de licencia";

            // 
            // txtNumeroLicencia
            // 
            this.txtNumeroLicencia.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F
                );

            this.txtNumeroLicencia.Location =
                new System.Drawing.Point(45, 372);

            this.txtNumeroLicencia.Name =
                "txtNumeroLicencia";

            this.txtNumeroLicencia.Size =
                new System.Drawing.Size(510, 27);

            this.txtNumeroLicencia.TabIndex = 4;

            this.txtNumeroLicencia.TextChanged +=
                new System.EventHandler(
                    this.txtNumeroLicencia_TextChanged
                );

            // 
            // lblErrorLicencia
            // 
            this.lblErrorLicencia.AutoSize = true;

            this.lblErrorLicencia.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F
                );

            this.lblErrorLicencia.ForeColor =
                System.Drawing.Color.Red;

            this.lblErrorLicencia.Location =
                new System.Drawing.Point(45, 402);

            this.lblErrorLicencia.Name =
                "lblErrorLicencia";

            this.lblErrorLicencia.Size =
                new System.Drawing.Size(0, 15);

            this.lblErrorLicencia.TabIndex = 9;

            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = true;

            this.lblHospital.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblHospital.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(50)))),
                    ((int)(((byte)(60)))),
                    ((int)(((byte)(70))))
                );

            this.lblHospital.Location =
                new System.Drawing.Point(42, 435);

            this.lblHospital.Name =
                "lblHospital";

            this.lblHospital.Size =
                new System.Drawing.Size(174, 17);

            this.lblHospital.TabIndex = 10;

            this.lblHospital.Text =
                "Hospital / Centro de salud";

            // 
            // cmbHospital
            // 
            this.cmbHospital.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbHospital.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10.5F
                );

            this.cmbHospital.FormattingEnabled = true;

            this.cmbHospital.Location =
                new System.Drawing.Point(45, 457);

            this.cmbHospital.Name =
                "cmbHospital";

            this.cmbHospital.Size =
                new System.Drawing.Size(510, 27);

            this.cmbHospital.TabIndex = 5;

            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(27)))),
                    ((int)(((byte)(108)))),
                    ((int)(((byte)(168))))
                );

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
                new System.Drawing.Point(45, 510);

            this.btnGuardar.Name =
                "btnGuardar";

            this.btnGuardar.Size =
                new System.Drawing.Size(510, 40);

            this.btnGuardar.TabIndex = 6;

            this.btnGuardar.Text =
                "Guardar Doctor";

            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnGuardar.Click +=
                new System.EventHandler(
                    this.btnGuardar_Click
                );

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
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(27)))),
                    ((int)(((byte)(108)))),
                    ((int)(((byte)(168))))
                );

            this.lnkVolver.Location =
                new System.Drawing.Point(210, 570);

            this.lnkVolver.Name =
                "lnkVolver";

            this.lnkVolver.Size =
                new System.Drawing.Size(171, 17);

            this.lnkVolver.TabIndex = 7;

            this.lnkVolver.TabStop = true;

            this.lnkVolver.Text =
                "Completar después / Volver";

            this.lnkVolver.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                    this.lnkVolver_LinkClicked
                );

            // 
            // crearDoctor
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    6F,
                    13F
                );

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(238)))),
                    ((int)(((byte)(243)))),
                    ((int)(((byte)(248))))
                );

            this.ClientSize =
                new System.Drawing.Size(
                    1150,
                    780
                );

            this.Controls.Add(
                this.panelCard
            );

            this.MinimumSize =
                new System.Drawing.Size(
                    850,
                    650
                );

            this.Name =
                "crearDoctor";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Sanar Rural - Registro de Doctor";

            this.Load +=
                new System.EventHandler(
                    this.crearDoctor_Load
                );

            this.Resize +=
                new System.EventHandler(
                    this.crearDoctor_Resize
                );

            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelLineaVerde;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblErrorNombres;

        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblErrorApellidos;

        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtEspecialidad;

        private System.Windows.Forms.Label lblNumeroLicencia;
        private System.Windows.Forms.TextBox txtNumeroLicencia;
        private System.Windows.Forms.Label lblErrorLicencia;

        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.ComboBox cmbHospital;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}