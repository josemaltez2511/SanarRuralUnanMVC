using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Citas
{
    partial class crearCita
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
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblErrorPaciente = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblErrorEspecialidad = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblErrorDoctor = new System.Windows.Forms.Label();
            this.lblHospital = new System.Windows.Forms.Label();
            this.cmbHospital = new System.Windows.Forms.ComboBox();
            this.lblErrorHospital = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblErrorFechaHora = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblErrorMotivo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.lblPaciente);
            this.panelCard.Controls.Add(this.cmbPaciente);
            this.panelCard.Controls.Add(this.lblErrorPaciente);
            this.panelCard.Controls.Add(this.lblEspecialidad);
            this.panelCard.Controls.Add(this.cmbEspecialidad);
            this.panelCard.Controls.Add(this.lblErrorEspecialidad);
            this.panelCard.Controls.Add(this.lblDoctor);
            this.panelCard.Controls.Add(this.cmbDoctor);
            this.panelCard.Controls.Add(this.lblErrorDoctor);
            this.panelCard.Controls.Add(this.lblHospital);
            this.panelCard.Controls.Add(this.cmbHospital);
            this.panelCard.Controls.Add(this.lblErrorHospital);
            this.panelCard.Controls.Add(this.lblFecha);
            this.panelCard.Controls.Add(this.dtpFecha);
            this.panelCard.Controls.Add(this.lblHora);
            this.panelCard.Controls.Add(this.dtpHora);
            this.panelCard.Controls.Add(this.lblErrorFechaHora);
            this.panelCard.Controls.Add(this.lblMotivo);
            this.panelCard.Controls.Add(this.txtMotivo);
            this.panelCard.Controls.Add(this.lblErrorMotivo);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(560, 645);
            this.panelCard.TabIndex = 0;
            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor = Tema.VerdeAcento;
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 25);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(6, 45);
            this.panelLineaVerde.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(52, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "SANAR RURAL";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoAyuda;
            this.lblSubtitulo.Location = new System.Drawing.Point(55, 50);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(200, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Programación de Cita Médica";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = Tema.FuenteLabelCampo;
            this.lblPaciente.ForeColor = Tema.TextoPrincipal;
            this.lblPaciente.Location = new System.Drawing.Point(40, 85);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(91, 17);
            this.lblPaciente.TabIndex = 3;
            this.lblPaciente.Text = "Paciente (*):";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Font = Tema.FuenteInput;
            this.cmbPaciente.Location = new System.Drawing.Point(40, 107);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(480, 28);
            this.cmbPaciente.TabIndex = 4;
            // 
            // lblErrorPaciente
            // 
            this.lblErrorPaciente.AutoSize = true;
            this.lblErrorPaciente.Font = Tema.FuenteAyuda;
            this.lblErrorPaciente.ForeColor = Tema.ColorError;
            this.lblErrorPaciente.Location = new System.Drawing.Point(40, 137);
            this.lblErrorPaciente.Name = "lblErrorPaciente";
            this.lblErrorPaciente.Size = new System.Drawing.Size(0, 15);
            this.lblErrorPaciente.TabIndex = 5;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidad.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidad.Location = new System.Drawing.Point(40, 155);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(161, 17);
            this.lblEspecialidad.TabIndex = 6;
            this.lblEspecialidad.Text = "Especialidad Médica (*):";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.Font = Tema.FuenteInput;
            this.cmbEspecialidad.Location = new System.Drawing.Point(40, 177);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(480, 28);
            this.cmbEspecialidad.TabIndex = 7;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            // 
            // lblErrorEspecialidad
            // 
            this.lblErrorEspecialidad.AutoSize = true;
            this.lblErrorEspecialidad.Font = Tema.FuenteAyuda;
            this.lblErrorEspecialidad.ForeColor = Tema.ColorError;
            this.lblErrorEspecialidad.Location = new System.Drawing.Point(40, 207);
            this.lblErrorEspecialidad.Name = "lblErrorEspecialidad";
            this.lblErrorEspecialidad.Size = new System.Drawing.Size(0, 15);
            this.lblErrorEspecialidad.TabIndex = 8;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = Tema.FuenteLabelCampo;
            this.lblDoctor.ForeColor = Tema.TextoPrincipal;
            this.lblDoctor.Location = new System.Drawing.Point(40, 225);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(142, 17);
            this.lblDoctor.TabIndex = 9;
            this.lblDoctor.Text = "Médico Tratante (*):";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.Enabled = false;
            this.cmbDoctor.Font = Tema.FuenteInput;
            this.cmbDoctor.Location = new System.Drawing.Point(40, 247);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(480, 28);
            this.cmbDoctor.TabIndex = 10;
            this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.cmbDoctor_SelectedIndexChanged);
            // 
            // lblErrorDoctor
            // 
            this.lblErrorDoctor.AutoSize = true;
            this.lblErrorDoctor.Font = Tema.FuenteAyuda;
            this.lblErrorDoctor.ForeColor = Tema.ColorError;
            this.lblErrorDoctor.Location = new System.Drawing.Point(40, 277);
            this.lblErrorDoctor.Name = "lblErrorDoctor";
            this.lblErrorDoctor.Size = new System.Drawing.Size(0, 15);
            this.lblErrorDoctor.TabIndex = 11;
            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = true;
            this.lblHospital.Font = Tema.FuenteLabelCampo;
            this.lblHospital.ForeColor = Tema.TextoPrincipal;
            this.lblHospital.Location = new System.Drawing.Point(40, 295);
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(130, 17);
            this.lblHospital.TabIndex = 12;
            this.lblHospital.Text = "Hospital / Sede (*):";
            // 
            // cmbHospital
            // 
            this.cmbHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHospital.Enabled = false;
            this.cmbHospital.Font = Tema.FuenteInput;
            this.cmbHospital.Location = new System.Drawing.Point(40, 317);
            this.cmbHospital.Name = "cmbHospital";
            this.cmbHospital.Size = new System.Drawing.Size(480, 28);
            this.cmbHospital.TabIndex = 13;
            // 
            // lblErrorHospital
            // 
            this.lblErrorHospital.AutoSize = true;
            this.lblErrorHospital.Font = Tema.FuenteAyuda;
            this.lblErrorHospital.ForeColor = Tema.ColorError;
            this.lblErrorHospital.Location = new System.Drawing.Point(40, 347);
            this.lblErrorHospital.Name = "lblErrorHospital";
            this.lblErrorHospital.Size = new System.Drawing.Size(0, 15);
            this.lblErrorHospital.TabIndex = 14;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = Tema.FuenteLabelCampo;
            this.lblFecha.ForeColor = Tema.TextoPrincipal;
            this.lblFecha.Location = new System.Drawing.Point(40, 365);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(155, 17);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha Programada (*):";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = Tema.FuenteInput;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(40, 387);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(230, 27);
            this.dtpFecha.TabIndex = 16;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = Tema.FuenteLabelCampo;
            this.lblHora.ForeColor = Tema.TextoPrincipal;
            this.lblHora.Location = new System.Drawing.Point(290, 365);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(68, 17);
            this.lblHora.TabIndex = 17;
            this.lblHora.Text = "Hora (*):";
            // 
            // dtpHora
            // 
            this.dtpHora.CustomFormat = "hh:mm tt";
            this.dtpHora.Font = Tema.FuenteInput;
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(290, 387);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(230, 27);
            this.dtpHora.TabIndex = 18;
            // 
            // lblErrorFechaHora
            // 
            this.lblErrorFechaHora.AutoSize = true;
            this.lblErrorFechaHora.Font = Tema.FuenteAyuda;
            this.lblErrorFechaHora.ForeColor = Tema.ColorError;
            this.lblErrorFechaHora.Location = new System.Drawing.Point(40, 417);
            this.lblErrorFechaHora.Name = "lblErrorFechaHora";
            this.lblErrorFechaHora.Size = new System.Drawing.Size(0, 15);
            this.lblErrorFechaHora.TabIndex = 19;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = Tema.FuenteLabelCampo;
            this.lblMotivo.ForeColor = Tema.TextoPrincipal;
            this.lblMotivo.Location = new System.Drawing.Point(40, 435);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(155, 17);
            this.lblMotivo.TabIndex = 20;
            this.lblMotivo.Text = "Motivo de la Cita (*):";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = Tema.FuenteInput;
            this.txtMotivo.Location = new System.Drawing.Point(40, 457);
            this.txtMotivo.MaxLength = 500;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(480, 70);
            this.txtMotivo.TabIndex = 21;
            // 
            // lblErrorMotivo
            // 
            this.lblErrorMotivo.AutoSize = true;
            this.lblErrorMotivo.Font = Tema.FuenteAyuda;
            this.lblErrorMotivo.ForeColor = Tema.ColorError;
            this.lblErrorMotivo.Location = new System.Drawing.Point(40, 530);
            this.lblErrorMotivo.Name = "lblErrorMotivo";
            this.lblErrorMotivo.Size = new System.Drawing.Size(0, 15);
            this.lblErrorMotivo.TabIndex = 22;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = Tema.Superficie;
            this.btnGuardar.Location = new System.Drawing.Point(40, 550);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(480, 42);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "💾 Agendar Cita";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lnkVolver
            // 
            this.lnkVolver.Font = Tema.FuenteAyuda;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(40, 600);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(480, 22);
            this.lnkVolver.TabIndex = 24;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "← Volver al listado de citas";
            this.lnkVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            // 
            // crearCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.FondoVentana;
            this.ClientSize = new System.Drawing.Size(560, 645);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "crearCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Programar Cita Médica";
            this.Load += new System.EventHandler(this.crearCita_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblErrorPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label lblErrorEspecialidad;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblErrorDoctor;
        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.ComboBox cmbHospital;
        private System.Windows.Forms.Label lblErrorHospital;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblErrorFechaHora;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblErrorMotivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}
