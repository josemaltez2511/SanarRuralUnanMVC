namespace SanarRuralUnan.Views
{
    partial class crearPaciente
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
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.lblErrorNombres = new System.Windows.Forms.Label();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
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
            this.panelCard.Controls.Add(this.txtTelefono);
            this.panelCard.Controls.Add(this.lblTelefono);
            this.panelCard.Controls.Add(this.cmbGenero);
            this.panelCard.Controls.Add(this.lblGenero);
            this.panelCard.Controls.Add(this.dtpFechaNacimiento);
            this.panelCard.Controls.Add(this.lblFechaNacimiento);
            this.panelCard.Controls.Add(this.txtApellidos);
            this.panelCard.Controls.Add(this.lblApellidos);
            this.panelCard.Controls.Add(this.txtNombres);
            this.panelCard.Controls.Add(this.lblNombres);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Controls.Add(this.lblErrorNombres);
            this.panelCard.Controls.Add(this.lblErrorTelefono);
            this.panelCard.Location = new System.Drawing.Point(125, 35);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 550);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(32)))));
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 20);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(6, 45);
            this.panelLineaVerde.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(55, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(188, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Registro de Datos del Paciente";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.lblTitulo.Location = new System.Drawing.Point(52, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 32);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "SANAR RURAL";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(40, 450);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(420, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Paciente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTelefono.Location = new System.Drawing.Point(40, 395);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(420, 27);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.lblTelefono.Location = new System.Drawing.Point(37, 375);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 17);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(40, 330);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(420, 27);
            this.cmbGenero.TabIndex = 4;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGenero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.lblGenero.Location = new System.Drawing.Point(37, 310);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(52, 17);
            this.lblGenero.TabIndex = 7;
            this.lblGenero.Text = "Género";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(40, 265);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(420, 26);
            this.dtpFechaNacimiento.TabIndex = 3;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaNacimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.lblFechaNacimiento.Location = new System.Drawing.Point(37, 245);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(135, 17);
            this.lblFechaNacimiento.TabIndex = 6;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtApellidos.Location = new System.Drawing.Point(40, 190);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(420, 27);
            this.txtApellidos.TabIndex = 2;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.lblApellidos.Location = new System.Drawing.Point(37, 170);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(66, 17);
            this.lblApellidos.TabIndex = 5;
            this.lblApellidos.Text = "Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombres.Location = new System.Drawing.Point(40, 115);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(420, 27);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.lblNombres.Location = new System.Drawing.Point(37, 95);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(64, 17);
            this.lblNombres.TabIndex = 3;
            this.lblNombres.Text = "Nombres";
            // 
            // lnkVolver
            // 
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkVolver.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.lnkVolver.Location = new System.Drawing.Point(159, 507);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(171, 17);
            this.lnkVolver.TabIndex = 7;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "Completar después / Volver";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            // 
            // lblErrorNombres
            // 
            this.lblErrorNombres.AutoSize = true;
            this.lblErrorNombres.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblErrorNombres.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombres.Location = new System.Drawing.Point(40, 145);
            this.lblErrorNombres.Name = "lblErrorNombres";
            this.lblErrorNombres.Size = new System.Drawing.Size(0, 15);
            this.lblErrorNombres.TabIndex = 4;
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblErrorTelefono.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTelefono.Location = new System.Drawing.Point(40, 425);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(0, 15);
            this.lblErrorTelefono.TabIndex = 9;
            // 
            // crearPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(750, 620);
            this.Controls.Add(this.panelCard);
            this.Name = "crearPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Registro de Paciente";
            this.Load += new System.EventHandler(this.crearPaciente_Load);
            this.Resize += new System.EventHandler(this.crearPaciente_Resize);
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

        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;

        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lblGenero;

        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNacimiento;

        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblApellidos;

        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblNombres;

        private System.Windows.Forms.LinkLabel lnkVolver;

        private System.Windows.Forms.Label lblErrorNombres;
        private System.Windows.Forms.Label lblErrorTelefono;
    }
}