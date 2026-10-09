namespace SanarRuralUnan.Views.HistorialClinico
{
    partial class paginaPrincipalHistorial
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

        private void InitializeComponent()
        {
            this.panelCardPrincipal = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.panelFiltroFecha = new System.Windows.Forms.Panel();
            this.chkTodasFechas = new System.Windows.Forms.CheckBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.panelMetricas = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.cardUltima = new System.Windows.Forms.Panel();
            this.lblUltimaValor = new System.Windows.Forms.Label();
            this.lblUltimaTitulo = new System.Windows.Forms.Label();
            this.cardDiagnosticos = new System.Windows.Forms.Panel();
            this.lblDiagValor = new System.Windows.Forms.Label();
            this.lblDiagTitulo = new System.Windows.Forms.Label();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.panelIconoModulo = new System.Windows.Forms.Panel();
            this.lblIconoModulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelCardPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelFiltroFecha.SuspendLayout();
            this.panelMetricas.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardUltima.SuspendLayout();
            this.cardDiagnosticos.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.panelIconoModulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCardPrincipal
            // 
            this.panelCardPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.panelCardPrincipal.Controls.Add(this.dgvHistorial);
            this.panelCardPrincipal.Controls.Add(this.panelFiltros);
            this.panelCardPrincipal.Controls.Add(this.panelMetricas);
            this.panelCardPrincipal.Controls.Add(this.panelEncabezado);
            this.panelCardPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardPrincipal.Location = new System.Drawing.Point(20, 20);
            this.panelCardPrincipal.Name = "panelCardPrincipal";
            this.panelCardPrincipal.Padding = new System.Windows.Forms.Padding(24);
            this.panelCardPrincipal.Size = new System.Drawing.Size(1160, 680);
            this.panelCardPrincipal.TabIndex = 0;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(24, 230);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowTemplate.Height = 44;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1112, 426);
            this.dgvHistorial.TabIndex = 3;
            this.dgvHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellContentClick);
            this.dgvHistorial.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHistorial_CellMouseMove);
            this.dgvHistorial.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHistorial_CellPainting);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.panelBuscar);
            this.panelFiltros.Controls.Add(this.panelFiltroFecha);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(24, 174);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1112, 56);
            this.panelFiltros.TabIndex = 2;
            // 
            // panelBuscar
            // 
            this.panelBuscar.BackColor = System.Drawing.Color.White;
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Controls.Add(this.btnLimpiarBusqueda);
            this.panelBuscar.Location = new System.Drawing.Point(0, 8);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Padding = new System.Windows.Forms.Padding(10, 8, 8, 8);
            this.panelBuscar.Size = new System.Drawing.Size(460, 40);
            this.panelBuscar.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(10, 8);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(410, 18);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBusqueda.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(420, 8);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(32, 24);
            this.btnLimpiarBusqueda.TabIndex = 1;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // panelFiltroFecha
            // 
            this.panelFiltroFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltroFecha.BackColor = System.Drawing.Color.White;
            this.panelFiltroFecha.Controls.Add(this.chkTodasFechas);
            this.panelFiltroFecha.Controls.Add(this.lblHasta);
            this.panelFiltroFecha.Controls.Add(this.dtpHasta);
            this.panelFiltroFecha.Controls.Add(this.lblDesde);
            this.panelFiltroFecha.Controls.Add(this.dtpDesde);
            this.panelFiltroFecha.Location = new System.Drawing.Point(540, 8);
            this.panelFiltroFecha.Name = "panelFiltroFecha";
            this.panelFiltroFecha.Size = new System.Drawing.Size(572, 40);
            this.panelFiltroFecha.TabIndex = 1;
            // 
            // chkTodasFechas
            // 
            this.chkTodasFechas.AutoSize = true;
            this.chkTodasFechas.Checked = true;
            this.chkTodasFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasFechas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTodasFechas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.chkTodasFechas.Location = new System.Drawing.Point(448, 11);
            this.chkTodasFechas.Name = "chkTodasFechas";
            this.chkTodasFechas.Size = new System.Drawing.Size(107, 19);
            this.chkTodasFechas.TabIndex = 4;
            this.chkTodasFechas.Text = "Todo el historial";
            this.chkTodasFechas.UseVisualStyleBackColor = true;
            this.chkTodasFechas.CheckedChanged += new System.EventHandler(this.chkTodasFechas_CheckedChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.lblHasta.Location = new System.Drawing.Point(230, 12);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(276, 8);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(140, 23);
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.lblDesde.Location = new System.Drawing.Point(12, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(140, 23);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // panelMetricas
            // 
            this.panelMetricas.Controls.Add(this.cardTotal);
            this.panelMetricas.Controls.Add(this.cardUltima);
            this.panelMetricas.Controls.Add(this.cardDiagnosticos);
            this.panelMetricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetricas.Location = new System.Drawing.Point(24, 94);
            this.panelMetricas.Name = "panelMetricas";
            this.panelMetricas.Size = new System.Drawing.Size(1112, 80);
            this.panelMetricas.TabIndex = 1;
            // 
            // cardTotal
            // 
            this.cardTotal.BackColor = System.Drawing.Color.White;
            this.cardTotal.Controls.Add(this.lblTotalValor);
            this.cardTotal.Controls.Add(this.lblTotalTitulo);
            this.cardTotal.Location = new System.Drawing.Point(0, 4);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.cardTotal.Size = new System.Drawing.Size(350, 68);
            this.cardTotal.TabIndex = 0;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(120)))), ((int)(((byte)(183)))));
            this.lblTotalValor.Location = new System.Drawing.Point(14, 28);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(26, 30);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "0";
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.lblTotalTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(115, 15);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "Total de Atenciones";
            // 
            // cardUltima
            // 
            this.cardUltima.BackColor = System.Drawing.Color.White;
            this.cardUltima.Controls.Add(this.lblUltimaValor);
            this.cardUltima.Controls.Add(this.lblUltimaTitulo);
            this.cardUltima.Location = new System.Drawing.Point(380, 4);
            this.cardUltima.Name = "cardUltima";
            this.cardUltima.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.cardUltima.Size = new System.Drawing.Size(350, 68);
            this.cardUltima.TabIndex = 1;
            // 
            // lblUltimaValor
            // 
            this.lblUltimaValor.AutoSize = true;
            this.lblUltimaValor.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblUltimaValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(142)))), ((int)(((byte)(86)))));
            this.lblUltimaValor.Location = new System.Drawing.Point(14, 30);
            this.lblUltimaValor.Name = "lblUltimaValor";
            this.lblUltimaValor.Size = new System.Drawing.Size(126, 25);
            this.lblUltimaValor.TabIndex = 1;
            this.lblUltimaValor.Text = "Sin registros";
            // 
            // lblUltimaTitulo
            // 
            this.lblUltimaTitulo.AutoSize = true;
            this.lblUltimaTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUltimaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.lblUltimaTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblUltimaTitulo.Name = "lblUltimaTitulo";
            this.lblUltimaTitulo.Size = new System.Drawing.Size(91, 15);
            this.lblUltimaTitulo.TabIndex = 0;
            this.lblUltimaTitulo.Text = "Última Consulta";
            // 
            // cardDiagnosticos
            // 
            this.cardDiagnosticos.BackColor = System.Drawing.Color.White;
            this.cardDiagnosticos.Controls.Add(this.lblDiagValor);
            this.cardDiagnosticos.Controls.Add(this.lblDiagTitulo);
            this.cardDiagnosticos.Location = new System.Drawing.Point(760, 4);
            this.cardDiagnosticos.Name = "cardDiagnosticos";
            this.cardDiagnosticos.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.cardDiagnosticos.Size = new System.Drawing.Size(350, 68);
            this.cardDiagnosticos.TabIndex = 2;
            // 
            // lblDiagValor
            // 
            this.lblDiagValor.AutoSize = true;
            this.lblDiagValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiagValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(74)))), ((int)(((byte)(107)))));
            this.lblDiagValor.Location = new System.Drawing.Point(14, 28);
            this.lblDiagValor.Name = "lblDiagValor";
            this.lblDiagValor.Size = new System.Drawing.Size(26, 30);
            this.lblDiagValor.TabIndex = 1;
            this.lblDiagValor.Text = "0";
            // 
            // lblDiagTitulo
            // 
            this.lblDiagTitulo.AutoSize = true;
            this.lblDiagTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDiagTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.lblDiagTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblDiagTitulo.Name = "lblDiagTitulo";
            this.lblDiagTitulo.Size = new System.Drawing.Size(142, 15);
            this.lblDiagTitulo.TabIndex = 0;
            this.lblDiagTitulo.Text = "Diagnósticos Registrados";
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.panelIconoModulo);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(24, 24);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(1112, 70);
            this.panelEncabezado.TabIndex = 0;
            // 
            // panelIconoModulo
            // 
            this.panelIconoModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.panelIconoModulo.Controls.Add(this.lblIconoModulo);
            this.panelIconoModulo.Location = new System.Drawing.Point(0, 8);
            this.panelIconoModulo.Name = "panelIconoModulo";
            this.panelIconoModulo.Size = new System.Drawing.Size(48, 48);
            this.panelIconoModulo.TabIndex = 0;
            // 
            // lblIconoModulo
            // 
            this.lblIconoModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconoModulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblIconoModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(120)))), ((int)(((byte)(183)))));
            this.lblIconoModulo.Location = new System.Drawing.Point(0, 0);
            this.lblIconoModulo.Name = "lblIconoModulo";
            this.lblIconoModulo.Size = new System.Drawing.Size(48, 48);
            this.lblIconoModulo.TabIndex = 0;
            this.lblIconoModulo.Text = "📋";
            this.lblIconoModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(51)))), ((int)(((byte)(66)))));
            this.lblTitulo.Location = new System.Drawing.Point(58, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(273, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Historial Clínico Integral";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(112)))), ((int)(((byte)(120)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(60, 38);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(384, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Trazabilidad cronológica de atenciones, diagnósticos y evolución";
            // 
            // paginaPrincipalHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelCardPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "paginaPrincipalHistorial";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Historial Clínico";
            this.Load += new System.EventHandler(this.paginaPrincipalHistorial_Load);
            this.panelCardPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelFiltroFecha.ResumeLayout(false);
            this.panelFiltroFecha.PerformLayout();
            this.panelMetricas.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.cardUltima.ResumeLayout(false);
            this.cardUltima.PerformLayout();
            this.cardDiagnosticos.ResumeLayout(false);
            this.cardDiagnosticos.PerformLayout();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelIconoModulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelCardPrincipal;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Panel panelIconoModulo;
        private System.Windows.Forms.Label lblIconoModulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelMetricas;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Panel cardUltima;
        private System.Windows.Forms.Label lblUltimaTitulo;
        private System.Windows.Forms.Label lblUltimaValor;
        private System.Windows.Forms.Panel cardDiagnosticos;
        private System.Windows.Forms.Label lblDiagTitulo;
        private System.Windows.Forms.Label lblDiagValor;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Panel panelFiltroFecha;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.CheckBox chkTodasFechas;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}
