using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Doctores
{
    partial class paginaPrincipalDoctores
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
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.panelLineaVerde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvDoctores = new System.Windows.Forms.DataGridView();
            this.panelCard.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = Tema.FondoTarjeta;
            this.panelCard.Controls.Add(this.panelTabla);
            this.panelCard.Controls.Add(this.panelEncabezado);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Name = "panelCard";
            this.panelCard.TabIndex = 0;
            this.panelCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 132;
            this.panelEncabezado.BackColor = Tema.Superficie;
            this.panelEncabezado.Controls.Add(this.panelLineaVerde);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Controls.Add(this.lblBuscar);
            this.panelEncabezado.Controls.Add(this.txtBuscar);
            this.panelEncabezado.Controls.Add(this.btnNuevo);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.BackColor = Tema.Superficie;
            this.panelTabla.Padding = new System.Windows.Forms.Padding(40, 0, 40, 35);
            this.panelTabla.Controls.Add(this.dgvDoctores);
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
            this.lblSubtitulo.Size = new System.Drawing.Size(192, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Catálogo y Gestión de Médicos";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = Tema.FuenteLabelCampo;
            this.lblBuscar.ForeColor = Tema.TextoPrincipal;
            this.lblBuscar.Location = new System.Drawing.Point(40, 95);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(99, 17);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar Doctor:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Location = new System.Drawing.Point(145, 92);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(430, 27);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = Tema.Superficie;
            this.btnNuevo.Location = new System.Drawing.Point(740, 88);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(170, 35);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "➕ Registrar Doctor";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvDoctores
            // 
            this.dgvDoctores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoctores.Name = "dgvDoctores";
            this.dgvDoctores.TabIndex = 6;
            this.dgvDoctores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctores_CellContentClick);
            this.dgvDoctores.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDoctores_CellPainting);
            this.dgvDoctores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoctores_CellMouseMove);
            // 
            // paginaPrincipalDoctores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.FondoVentana;
            this.ClientSize = new System.Drawing.Size(1030, 660);
            this.Controls.Add(this.panelCard);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "paginaPrincipalDoctores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Gestión de Doctores";
            this.Load += new System.EventHandler(this.paginaPrincipalDoctores_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctores)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvDoctores;
    }
}
