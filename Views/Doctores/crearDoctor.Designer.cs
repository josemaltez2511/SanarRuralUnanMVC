using SanarRuralUnan.Helpers;

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
            this.panelCard.BackColor = Tema.Superficie;

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

            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Name = "panelCard";
            this.panelCard.TabIndex = 0;

            this.panelCard.Paint +=
                new System.Windows.Forms.PaintEventHandler(
                    this.panelCard_Paint
                );

            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor =
                Tema.VerdeAcento;

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
                Tema.FuenteTitulo;

            this.lblTitulo.ForeColor =
                Tema.AzulPrimario;

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
                Tema.FuenteCuerpo;

            this.lblSubtitulo.ForeColor =
                Tema.TextoSecundario;

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
                Tema.FuenteLabelCampo;

            this.lblNombres.ForeColor =
                Tema.TextoPrincipal;

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
                Tema.FuenteInput;

            this.txtNombres.Location =
                new System.Drawing.Point(45, 127);

            this.txtNombres.Name =
                "txtNombres";

            this.txtNombres.Size =
                new System.Drawing.Size(510, 27);

            this.txtNombres.TabIndex = 1;


            // 
            // lblErrorNombres
            // 
            this.lblErrorNombres.AutoSize = true;

            this.lblErrorNombres.Font =
                Tema.FuenteAyuda;

            this.lblErrorNombres.ForeColor =
                Tema.Error;

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
                Tema.FuenteLabelCampo;

            this.lblApellidos.ForeColor =
                Tema.TextoPrincipal;

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
                Tema.FuenteInput;

            this.txtApellidos.Location =
                new System.Drawing.Point(45, 212);

            this.txtApellidos.Name =
                "txtApellidos";

            this.txtApellidos.Size =
                new System.Drawing.Size(510, 27);

            this.txtApellidos.TabIndex = 2;


            // 
            // lblErrorApellidos
            // 
            this.lblErrorApellidos.AutoSize = true;

            this.lblErrorApellidos.Font =
                Tema.FuenteAyuda;

            this.lblErrorApellidos.ForeColor =
                Tema.Error;

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
                Tema.FuenteLabelCampo;

            this.lblEspecialidad.ForeColor =
                Tema.TextoPrincipal;

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
                Tema.FuenteInput;

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
                Tema.FuenteLabelCampo;

            this.lblNumeroLicencia.ForeColor =
                Tema.TextoPrincipal;

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
                Tema.FuenteInput;

            this.txtNumeroLicencia.Location =
                new System.Drawing.Point(45, 372);

            this.txtNumeroLicencia.Name =
                "txtNumeroLicencia";

            this.txtNumeroLicencia.Size =
                new System.Drawing.Size(510, 27);

            this.txtNumeroLicencia.TabIndex = 4;


            // 
            // lblErrorLicencia
            // 
            this.lblErrorLicencia.AutoSize = true;

            this.lblErrorLicencia.Font =
                Tema.FuenteAyuda;

            this.lblErrorLicencia.ForeColor =
                Tema.Error;

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
                Tema.FuenteLabelCampo;

            this.lblHospital.ForeColor =
                Tema.TextoPrincipal;

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
                Tema.FuenteInput;

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
                Tema.AzulPrimario;

            this.btnGuardar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnGuardar.FlatAppearance.BorderSize = 0;

            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnGuardar.Font =
                Tema.FuenteLabelCampo;

            this.btnGuardar.ForeColor =
                Tema.Superficie;

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
                Tema.FuenteCuerpo;

            this.lnkVolver.LinkColor =
                Tema.AzulPrimario;

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
                Tema.Fondo;

            this.ClientSize = new System.Drawing.Size(950, 760);

            this.Controls.Add(
                this.panelCard
            );

            this.MinimumSize = new System.Drawing.Size(820, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name =
                "crearDoctor";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Sanar Rural - Registro de Doctor";

            this.Load +=
                new System.EventHandler(
                    this.crearDoctor_Load
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
