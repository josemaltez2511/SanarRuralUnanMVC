using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Enfermedades
{
    partial class formularioEnfermedad
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTarjeta;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCategoria;
        private TextBox txtCategoria;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTarjeta = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelTarjeta.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTarjeta
            //
            this.panelTarjeta.BackColor = Tema.Superficie;
            this.panelTarjeta.Controls.Add(this.lblTitulo);
            this.panelTarjeta.Controls.Add(this.lblNombre);
            this.panelTarjeta.Controls.Add(this.txtNombre);
            this.panelTarjeta.Controls.Add(this.lblCategoria);
            this.panelTarjeta.Controls.Add(this.txtCategoria);
            this.panelTarjeta.Controls.Add(this.lblDescripcion);
            this.panelTarjeta.Controls.Add(this.txtDescripcion);
            this.panelTarjeta.Controls.Add(this.btnGuardar);
            this.panelTarjeta.Controls.Add(this.btnCancelar);
            this.panelTarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTarjeta.Padding = new System.Windows.Forms.Padding(36);
            this.panelTarjeta.Name = "panelTarjeta";
            this.panelTarjeta.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(36, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar enfermedad";
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = Tema.FuenteLabelCampo;
            this.lblNombre.ForeColor = Tema.TextoPrincipal;
            this.lblNombre.Location = new System.Drawing.Point(36, 62);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre de la enfermedad *";
            //
            // txtNombre
            //
            this.txtNombre.AccessibleDescription = "Máximo 150 caracteres.";
            this.txtNombre.AccessibleName = "Nombre de la enfermedad";
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = Tema.FuenteInput;
            this.txtNombre.Location = new System.Drawing.Point(36, 86);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(648, 23);
            this.txtNombre.TabIndex = 2;
            //
            // lblCategoria
            //
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = Tema.FuenteLabelCampo;
            this.lblCategoria.ForeColor = Tema.TextoPrincipal;
            this.lblCategoria.Location = new System.Drawing.Point(36, 150);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Categoría";
            //
            // txtCategoria
            //
            this.txtCategoria.AccessibleDescription = "Máximo 100 caracteres.";
            this.txtCategoria.AccessibleName = "Categoría";
            this.txtCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoria.Font = Tema.FuenteInput;
            this.txtCategoria.Location = new System.Drawing.Point(36, 174);
            this.txtCategoria.MaxLength = 100;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(648, 23);
            this.txtCategoria.TabIndex = 4;
            //
            // lblDescripcion
            //
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = Tema.FuenteLabelCampo;
            this.lblDescripcion.ForeColor = Tema.TextoPrincipal;
            this.lblDescripcion.Location = new System.Drawing.Point(36, 238);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción";
            //
            // txtDescripcion
            //
            this.txtDescripcion.AccessibleDescription = "Máximo 2000 caracteres.";
            this.txtDescripcion.AccessibleName = "Descripción";
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Font = Tema.FuenteInput;
            this.txtDescripcion.Location = new System.Drawing.Point(36, 262);
            this.txtDescripcion.MaxLength = 2000;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(648, 150);
            this.txtDescripcion.TabIndex = 6;
            //
            // btnGuardar
            //
            this.btnGuardar.AccessibleName = "Guardar enfermedad";
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = Tema.Superficie;
            this.btnGuardar.Location = new System.Drawing.Point(36, 468);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 42);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar enfermedad";
            this.btnGuardar.UseVisualStyleBackColor = false;
            //
            // btnCancelar
            //
            this.btnCancelar.AccessibleName = "Cancelar y volver al catálogo";
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteSubtitulo;
            this.btnCancelar.ForeColor = Tema.AzulPrimario;
            this.btnCancelar.Location = new System.Drawing.Point(604, 474);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            //
            // formularioEnfermedad
            //
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(720, 560);
            this.Controls.Add(this.panelTarjeta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "formularioEnfermedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar enfermedad";
            this.panelTarjeta.ResumeLayout(false);
            this.panelTarjeta.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
