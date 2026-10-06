using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    partial class crearHospital
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCard
            //
            this.panelCard.BackColor = Tema.FondoTarjeta;
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblDepartamento);
            this.panelCard.Controls.Add(this.cmbDepartamento);
            this.panelCard.Controls.Add(this.lblMunicipio);
            this.panelCard.Controls.Add(this.cmbMunicipio);
            this.panelCard.Controls.Add(this.lblNombre);
            this.panelCard.Controls.Add(this.txtNombre);
            this.panelCard.Controls.Add(this.lblDireccion);
            this.panelCard.Controls.Add(this.txtDireccion);
            this.panelCard.Controls.Add(this.lblTelefono);
            this.panelCard.Controls.Add(this.txtTelefono);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Location = new System.Drawing.Point(70, 25);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(560, 500);
            this.panelCard.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(145, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Hospital";
            //
            // lblDepartamento
            //
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = Tema.FuenteLabelCampo;
            this.lblDepartamento.Location = new System.Drawing.Point(40, 90);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(116, 17);
            this.lblDepartamento.TabIndex = 1;
            this.lblDepartamento.Text = "Departamento *";
            //
            // cmbDepartamento
            //
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = Tema.FuenteInput;
            this.cmbDepartamento.Location = new System.Drawing.Point(40, 112);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(480, 25);
            this.cmbDepartamento.TabIndex = 1;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            //
            // lblMunicipio
            //
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = Tema.FuenteLabelCampo;
            this.lblMunicipio.Location = new System.Drawing.Point(40, 155);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(79, 17);
            this.lblMunicipio.TabIndex = 2;
            this.lblMunicipio.Text = "Municipio *";
            //
            // cmbMunicipio
            //
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Font = Tema.FuenteInput;
            this.cmbMunicipio.Location = new System.Drawing.Point(40, 177);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(480, 25);
            this.cmbMunicipio.TabIndex = 2;
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = Tema.FuenteLabelCampo;
            this.lblNombre.Location = new System.Drawing.Point(40, 220);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 17);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre *";
            //
            // txtNombre
            //
            this.txtNombre.Font = Tema.FuenteInput;
            this.txtNombre.Location = new System.Drawing.Point(40, 242);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(480, 25);
            this.txtNombre.TabIndex = 3;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = Tema.FuenteLabelCampo;
            this.lblDireccion.Location = new System.Drawing.Point(40, 285);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(68, 17);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección";
            //
            // txtDireccion
            //
            this.txtDireccion.Font = Tema.FuenteInput;
            this.txtDireccion.Location = new System.Drawing.Point(40, 307);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(480, 52);
            this.txtDireccion.TabIndex = 4;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.Location = new System.Drawing.Point(40, 377);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(60, 17);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono";
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(40, 399);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(480, 25);
            this.txtTelefono.TabIndex = 5;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(40, 440);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(300, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Hospital";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // lnkVolver
            //
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = Tema.FuenteSubtitulo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(390, 452);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(130, 17);
            this.lnkVolver.TabIndex = 7;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "Cancelar / Volver";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            //
            // crearHospital
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.FondoVentana;
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.Controls.Add(this.panelCard);
            this.Name = "crearHospital";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Hospital";
            this.Load += new System.EventHandler(this.crearHospital_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}
