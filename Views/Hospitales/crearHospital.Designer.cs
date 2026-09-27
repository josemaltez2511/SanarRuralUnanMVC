using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    partial class crearHospital
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

            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();

            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.lblErrorUbicacion = new System.Windows.Forms.Label();

            this.btnGuardar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();

            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelCard
            // 
            this.panelCard.BackColor = Tema.FondoTarjeta;
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.lblNombre);
            this.panelCard.Controls.Add(this.txtNombre);
            this.panelCard.Controls.Add(this.lblErrorNombre);
            this.panelCard.Controls.Add(this.lblUbicacion);
            this.panelCard.Controls.Add(this.txtUbicacion);
            this.panelCard.Controls.Add(this.lblErrorUbicacion);
            this.panelCard.Controls.Add(this.btnGuardar);
            this.panelCard.Controls.Add(this.lnkVolver);
            this.panelCard.Location = new System.Drawing.Point(125, 30);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 400);
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);

            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor = Tema.VerdeAcento;
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 20);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(6, 45);
            this.panelLineaVerde.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(52, 15);
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
            this.lblSubtitulo.Location = new System.Drawing.Point(55, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(167, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Registro de Hospital / Centro de Salud";

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = Tema.FuenteLabelCampo;
            this.lblNombre.ForeColor = Tema.TextoPrincipal;
            this.lblNombre.Location = new System.Drawing.Point(37, 110);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(160, 17);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre del Hospital";

            // 
            // txtNombre
            // 
            this.txtNombre.Font = Tema.FuenteInput;
            this.txtNombre.Location = new System.Drawing.Point(40, 130);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(420, 32);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);

            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Font = Tema.FuenteAyuda;
            this.lblErrorNombre.ForeColor = Tema.ColorError;
            this.lblErrorNombre.Location = new System.Drawing.Point(40, 165);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(0, 15);
            this.lblErrorNombre.TabIndex = 4;

            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = Tema.FuenteLabelCampo;
            this.lblUbicacion.ForeColor = Tema.TextoPrincipal;
            this.lblUbicacion.Location = new System.Drawing.Point(37, 195);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(80, 17);
            this.lblUbicacion.TabIndex = 5;
            this.lblUbicacion.Text = "Ubicación";

            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Font = Tema.FuenteInput;
            this.txtUbicacion.Location = new System.Drawing.Point(40, 215);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(420, 32);
            this.txtUbicacion.TabIndex = 2;
            this.txtUbicacion.TextChanged += new System.EventHandler(this.txtUbicacion_TextChanged);

            // 
            // lblErrorUbicacion
            // 
            this.lblErrorUbicacion.AutoSize = true;
            this.lblErrorUbicacion.Font = Tema.FuenteAyuda;
            this.lblErrorUbicacion.ForeColor = Tema.ColorError;
            this.lblErrorUbicacion.Location = new System.Drawing.Point(40, 250);
            this.lblErrorUbicacion.Name = "lblErrorUbicacion";
            this.lblErrorUbicacion.Size = new System.Drawing.Size(0, 15);
            this.lblErrorUbicacion.TabIndex = 6;

            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(40, 290);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(420, 44);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar Hospital";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // lnkVolver
            // 
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = Tema.FuenteSubtitulo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(195, 350);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(110, 17);
            this.lnkVolver.TabIndex = 4;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "⬅ Volver al Menú";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);

            // 
            // crearHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.FondoVentana;
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.panelCard);
            this.Name = "crearHospital";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Registro de Hospital";
            this.Load += new System.EventHandler(this.crearHospital_Load);
            this.Resize += new System.EventHandler(this.crearHospital_Resize);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblErrorNombre;

        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblErrorUbicacion;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}