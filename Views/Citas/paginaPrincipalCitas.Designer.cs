using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Citas
{
    partial class paginaPrincipalCitas
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
            this.chkTodasFechas = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.panelCard.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
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
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = Tema.Superficie;
            this.panelEncabezado.Controls.Add(this.panelLineaVerde);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Controls.Add(this.lblBuscar);
            this.panelEncabezado.Controls.Add(this.txtBuscar);
            this.panelEncabezado.Controls.Add(this.lblFecha);
            this.panelEncabezado.Controls.Add(this.dtpFechaFiltro);
            this.panelEncabezado.Controls.Add(this.chkTodasFechas);
            this.panelEncabezado.Controls.Add(this.lblEstado);
            this.panelEncabezado.Controls.Add(this.cmbEstadoFiltro);
            this.panelEncabezado.Controls.Add(this.btnNuevo);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 138;
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 0;
            // 
            // panelTabla
            // 
            this.panelTabla.BackColor = Tema.Superficie;
            this.panelTabla.Controls.Add(this.dgvCitas);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Padding = new System.Windows.Forms.Padding(40, 0, 40, 35);
            this.panelTabla.TabIndex = 1;
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
            this.lblSubtitulo.Size = new System.Drawing.Size(250, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Control y Seguimiento de Citas Médicas";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = Tema.FuenteLabelCampo;
            this.lblBuscar.ForeColor = Tema.TextoPrincipal;
            this.lblBuscar.Location = new System.Drawing.Point(40, 95);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(85, 17);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar Cita:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.Location = new System.Drawing.Point(128, 92);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 27);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = Tema.FuenteLabelCampo;
            this.lblFecha.ForeColor = Tema.TextoPrincipal;
            this.lblFecha.Location = new System.Drawing.Point(360, 95);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 17);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.Enabled = false;
            this.dtpFechaFiltro.Font = Tema.FuenteInput;
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(410, 92);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(115, 27);
            this.dtpFechaFiltro.TabIndex = 6;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            // 
            // chkTodasFechas
            // 
            this.chkTodasFechas.AutoSize = true;
            this.chkTodasFechas.Checked = true;
            this.chkTodasFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasFechas.Font = Tema.FuenteAyuda;
            this.chkTodasFechas.ForeColor = Tema.TextoSecundario;
            this.chkTodasFechas.Location = new System.Drawing.Point(532, 95);
            this.chkTodasFechas.Name = "chkTodasFechas";
            this.chkTodasFechas.Size = new System.Drawing.Size(60, 19);
            this.chkTodasFechas.TabIndex = 7;
            this.chkTodasFechas.Text = "Todas";
            this.chkTodasFechas.UseVisualStyleBackColor = true;
            this.chkTodasFechas.CheckedChanged += new System.EventHandler(this.chkTodasFechas_CheckedChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = Tema.FuenteLabelCampo;
            this.lblEstado.ForeColor = Tema.TextoPrincipal;
            this.lblEstado.Location = new System.Drawing.Point(602, 95);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(54, 17);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFiltro.Font = Tema.FuenteInput;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(660, 92);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(130, 28);
            this.cmbEstadoFiltro.TabIndex = 9;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = Tema.Superficie;
            this.btnNuevo.Location = new System.Drawing.Point(885, 88);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(155, 35);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "➕ Agendar Cita";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvCitas
            // 
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.TabIndex = 0;
            this.dgvCitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellContentClick);
            this.dgvCitas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCitas_CellPainting);
            this.dgvCitas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCitas_CellMouseMove);
            // 
            // paginaPrincipalCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.FondoVentana;
            this.ClientSize = new System.Drawing.Size(1080, 660);
            this.Controls.Add(this.panelCard);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "paginaPrincipalCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Gestión de Citas Médicas";
            this.Load += new System.EventHandler(this.paginaPrincipalCitas_Load);
            this.panelCard.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
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
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.CheckBox chkTodasFechas;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvCitas;
    }
}
