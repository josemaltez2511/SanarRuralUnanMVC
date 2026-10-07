using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    partial class paginaPrincipalConsultas
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
            this.btnNuevaConsulta = new System.Windows.Forms.Button();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.panelCard.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = Tema.FondoTarjeta;
            this.panelCard.Controls.Add(this.panelTabla);
            this.panelCard.Controls.Add(this.panelEncabezado);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(1200, 700);
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
            this.panelEncabezado.Controls.Add(this.btnNuevaConsulta);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 138;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 0;
            // 
            // panelTabla
            // 
            this.panelTabla.BackColor = Tema.Superficie;
            this.panelTabla.Controls.Add(this.dgvConsultas);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(0, 138);
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
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(54, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(320, 19);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "CONSULTAS MÉDICAS — ATENCIÓN Y SEGUIMIENTO";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = Tema.FuenteLabelCampo;
            this.lblBuscar.ForeColor = Tema.AzulOscuro;
            this.lblBuscar.Location = new System.Drawing.Point(40, 78);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(190, 17);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar paciente, diagnóstico:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.Location = new System.Drawing.Point(40, 98);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(260, 27);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = Tema.FuenteLabelCampo;
            this.lblFecha.ForeColor = Tema.AzulOscuro;
            this.lblFecha.Location = new System.Drawing.Point(320, 78);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(120, 17);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha de atención:";
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFiltro.Enabled = false;
            this.dtpFechaFiltro.Font = Tema.FuenteInput;
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(320, 98);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(130, 27);
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
            this.chkTodasFechas.Location = new System.Drawing.Point(458, 103);
            this.chkTodasFechas.Name = "chkTodasFechas";
            this.chkTodasFechas.Size = new System.Drawing.Size(61, 21);
            this.chkTodasFechas.TabIndex = 7;
            this.chkTodasFechas.Text = "Todas";
            this.chkTodasFechas.UseVisualStyleBackColor = true;
            this.chkTodasFechas.CheckedChanged += new System.EventHandler(this.chkTodasFechas_CheckedChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = Tema.FuenteLabelCampo;
            this.lblEstado.ForeColor = Tema.AzulOscuro;
            this.lblEstado.Location = new System.Drawing.Point(540, 78);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(125, 17);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado de consulta:";
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFiltro.Font = Tema.FuenteInput;
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(540, 98);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(160, 27);
            this.cmbEstadoFiltro.TabIndex = 9;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // btnNuevaConsulta
            // 
            this.btnNuevaConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaConsulta.BackColor = Tema.AzulPrimario;
            this.btnNuevaConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaConsulta.FlatAppearance.BorderSize = 0;
            this.btnNuevaConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaConsulta.Font = Tema.FuenteBoton;
            this.btnNuevaConsulta.ForeColor = Tema.Superficie;
            this.btnNuevaConsulta.Location = new System.Drawing.Point(990, 85);
            this.btnNuevaConsulta.Name = "btnNuevaConsulta";
            this.btnNuevaConsulta.Size = new System.Drawing.Size(170, 40);
            this.btnNuevaConsulta.TabIndex = 10;
            this.btnNuevaConsulta.Text = "+ Iniciar Consulta";
            this.btnNuevaConsulta.UseVisualStyleBackColor = false;
            this.btnNuevaConsulta.Click += new System.EventHandler(this.btnNuevaConsulta_Click);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.BackgroundColor = Tema.Superficie;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultas.Location = new System.Drawing.Point(40, 0);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.RowTemplate.Height = 36;
            this.dgvConsultas.Size = new System.Drawing.Size(1120, 527);
            this.dgvConsultas.TabIndex = 0;
            this.dgvConsultas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultas_CellContentClick);
            this.dgvConsultas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConsultas_CellMouseMove);
            this.dgvConsultas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvConsultas_CellPainting);
            // 
            // paginaPrincipalConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelCard);
            this.Font = Tema.FuenteCuerpo;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "paginaPrincipalConsultas";
            this.Text = "Consultas Médicas";
            this.Load += new System.EventHandler(this.paginaPrincipalConsultas_Load);
            this.panelCard.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
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
        private System.Windows.Forms.Button btnNuevaConsulta;
        private System.Windows.Forms.DataGridView dgvConsultas;
    }
}
