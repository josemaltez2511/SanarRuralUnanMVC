using System.Drawing;
using System.Windows.Forms;
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
            this.panelCardPrincipal = new System.Windows.Forms.Panel();
            this.panelHeaderModulo = new System.Windows.Forms.Panel();
            this.panelIconoModulo = new System.Windows.Forms.Panel();
            this.lblIconoModulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnNuevaConsulta = new System.Windows.Forms.Button();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.lblIconoBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.panelFiltroFecha = new System.Windows.Forms.Panel();
            this.lblIconoFecha = new System.Windows.Forms.Label();
            this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
            this.chkTodasFechas = new System.Windows.Forms.CheckBox();
            this.panelFiltroEstado = new System.Windows.Forms.Panel();
            this.lblIconoFiltro = new System.Windows.Forms.Label();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.panelMetricas = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblIconoTotal = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotalNum = new System.Windows.Forms.Label();
            this.cardEnProceso = new System.Windows.Forms.Panel();
            this.lblIconoEnProceso = new System.Windows.Forms.Label();
            this.lblEnProcesoTitulo = new System.Windows.Forms.Label();
            this.lblEnProcesoNum = new System.Windows.Forms.Label();
            this.cardFinalizadas = new System.Windows.Forms.Panel();
            this.lblIconoFinalizadas = new System.Windows.Forms.Label();
            this.lblFinalizadasTitulo = new System.Windows.Forms.Label();
            this.lblFinalizadasNum = new System.Windows.Forms.Label();
            this.panelGridContenedor = new System.Windows.Forms.Panel();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblConteo = new System.Windows.Forms.Label();
            this.panelCardPrincipal.SuspendLayout();
            this.panelHeaderModulo.SuspendLayout();
            this.panelIconoModulo.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelFiltroFecha.SuspendLayout();
            this.panelFiltroEstado.SuspendLayout();
            this.panelMetricas.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardEnProceso.SuspendLayout();
            this.cardFinalizadas.SuspendLayout();
            this.panelGridContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCardPrincipal
            //
            this.panelCardPrincipal.BackColor = Tema.Superficie;
            this.panelCardPrincipal.Controls.Add(this.panelFooter);
            this.panelCardPrincipal.Controls.Add(this.panelGridContenedor);
            this.panelCardPrincipal.Controls.Add(this.panelMetricas);
            this.panelCardPrincipal.Controls.Add(this.panelToolbar);
            this.panelCardPrincipal.Controls.Add(this.panelHeaderModulo);
            this.panelCardPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelCardPrincipal.Name = "panelCardPrincipal";
            this.panelCardPrincipal.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.panelCardPrincipal.Size = new System.Drawing.Size(1100, 700);
            this.panelCardPrincipal.TabIndex = 0;
            //
            // panelHeaderModulo
            //
            this.panelHeaderModulo.Controls.Add(this.btnNuevaConsulta);
            this.panelHeaderModulo.Controls.Add(this.lblSubtitulo);
            this.panelHeaderModulo.Controls.Add(this.lblTitulo);
            this.panelHeaderModulo.Controls.Add(this.panelIconoModulo);
            this.panelHeaderModulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderModulo.Height = 60;
            this.panelHeaderModulo.Location = new System.Drawing.Point(24, 20);
            this.panelHeaderModulo.Name = "panelHeaderModulo";
            this.panelHeaderModulo.Size = new System.Drawing.Size(1052, 60);
            this.panelHeaderModulo.TabIndex = 0;
            //
            // panelIconoModulo
            //
            this.panelIconoModulo.BackColor = System.Drawing.Color.FromArgb(226, 238, 248);
            this.panelIconoModulo.Controls.Add(this.lblIconoModulo);
            this.panelIconoModulo.Location = new System.Drawing.Point(0, 4);
            this.panelIconoModulo.Name = "panelIconoModulo";
            this.panelIconoModulo.Size = new System.Drawing.Size(46, 46);
            this.panelIconoModulo.TabIndex = 0;
            //
            // lblIconoModulo
            //
            this.lblIconoModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconoModulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblIconoModulo.ForeColor = Tema.AzulPrimario;
            this.lblIconoModulo.Location = new System.Drawing.Point(0, 0);
            this.lblIconoModulo.Name = "lblIconoModulo";
            this.lblIconoModulo.Size = new System.Drawing.Size(46, 46);
            this.lblIconoModulo.TabIndex = 0;
            this.lblIconoModulo.Text = "🩺";
            this.lblIconoModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(54, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(235, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Consultas Médicas";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(56, 36);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(306, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Atención clínica, diagnóstico y prescripciones médicas";
            //
            // btnNuevaConsulta
            //
            this.btnNuevaConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaConsulta.BackColor = Tema.AzulPrimario;
            this.btnNuevaConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaConsulta.FlatAppearance.BorderSize = 0;
            this.btnNuevaConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaConsulta.Font = Tema.FuenteBoton;
            this.btnNuevaConsulta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaConsulta.Location = new System.Drawing.Point(882, 8);
            this.btnNuevaConsulta.Name = "btnNuevaConsulta";
            this.btnNuevaConsulta.Size = new System.Drawing.Size(170, 42);
            this.btnNuevaConsulta.TabIndex = 3;
            this.btnNuevaConsulta.Text = "🩺 + Iniciar consulta";
            this.btnNuevaConsulta.UseVisualStyleBackColor = false;
            this.btnNuevaConsulta.Click += new System.EventHandler(this.btnNuevaConsulta_Click);
            //
            // panelToolbar
            //
            this.panelToolbar.Controls.Add(this.panelFiltroEstado);
            this.panelToolbar.Controls.Add(this.panelFiltroFecha);
            this.panelToolbar.Controls.Add(this.panelBuscar);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Height = 52;
            this.panelToolbar.Location = new System.Drawing.Point(24, 80);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1052, 52);
            this.panelToolbar.TabIndex = 1;
            //
            // panelBuscar
            //
            this.panelBuscar.BackColor = Tema.Superficie;
            this.panelBuscar.Controls.Add(this.btnLimpiarBusqueda);
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Controls.Add(this.lblIconoBuscar);
            this.panelBuscar.Location = new System.Drawing.Point(0, 6);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(320, 38);
            this.panelBuscar.TabIndex = 0;
            //
            // lblIconoBuscar
            //
            this.lblIconoBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoBuscar.ForeColor = Tema.TextoSecundario;
            this.lblIconoBuscar.Location = new System.Drawing.Point(8, 7);
            this.lblIconoBuscar.Name = "lblIconoBuscar";
            this.lblIconoBuscar.Size = new System.Drawing.Size(24, 24);
            this.lblIconoBuscar.TabIndex = 0;
            this.lblIconoBuscar.Text = "🔍";
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F);
            this.txtBuscar.ForeColor = Tema.TextoPrincipal;
            this.txtBuscar.Location = new System.Drawing.Point(36, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(246, 19);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // btnLimpiarBusqueda
            //
            this.btnLimpiarBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarBusqueda.ForeColor = Tema.TextoSecundario;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(288, 6);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(26, 26);
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = false;
            this.btnLimpiarBusqueda.Visible = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            //
            // panelFiltroFecha
            //
            this.panelFiltroFecha.BackColor = Tema.Superficie;
            this.panelFiltroFecha.Controls.Add(this.chkTodasFechas);
            this.panelFiltroFecha.Controls.Add(this.dtpFechaFiltro);
            this.panelFiltroFecha.Controls.Add(this.lblIconoFecha);
            this.panelFiltroFecha.Location = new System.Drawing.Point(334, 6);
            this.panelFiltroFecha.Name = "panelFiltroFecha";
            this.panelFiltroFecha.Size = new System.Drawing.Size(290, 38);
            this.panelFiltroFecha.TabIndex = 1;
            //
            // lblIconoFecha
            //
            this.lblIconoFecha.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoFecha.ForeColor = Tema.TextoSecundario;
            this.lblIconoFecha.Location = new System.Drawing.Point(8, 7);
            this.lblIconoFecha.Name = "lblIconoFecha";
            this.lblIconoFecha.Size = new System.Drawing.Size(24, 24);
            this.lblIconoFecha.TabIndex = 0;
            this.lblIconoFecha.Text = "📅";
            this.lblIconoFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dtpFechaFiltro
            //
            this.dtpFechaFiltro.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFiltro.Enabled = false;
            this.dtpFechaFiltro.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(36, 7);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(140, 25);
            this.dtpFechaFiltro.TabIndex = 1;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            //
            // chkTodasFechas
            //
            this.chkTodasFechas.AutoSize = true;
            this.chkTodasFechas.Checked = true;
            this.chkTodasFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasFechas.Font = Tema.FuenteAyuda;
            this.chkTodasFechas.ForeColor = Tema.TextoSecundario;
            this.chkTodasFechas.Location = new System.Drawing.Point(186, 10);
            this.chkTodasFechas.Name = "chkTodasFechas";
            this.chkTodasFechas.Size = new System.Drawing.Size(61, 19);
            this.chkTodasFechas.TabIndex = 2;
            this.chkTodasFechas.Text = "Todas";
            this.chkTodasFechas.UseVisualStyleBackColor = true;
            this.chkTodasFechas.CheckedChanged += new System.EventHandler(this.chkTodasFechas_CheckedChanged);
            //
            // panelFiltroEstado
            //
            this.panelFiltroEstado.BackColor = Tema.Superficie;
            this.panelFiltroEstado.Controls.Add(this.cmbEstadoFiltro);
            this.panelFiltroEstado.Controls.Add(this.lblIconoFiltro);
            this.panelFiltroEstado.Location = new System.Drawing.Point(638, 6);
            this.panelFiltroEstado.Name = "panelFiltroEstado";
            this.panelFiltroEstado.Size = new System.Drawing.Size(200, 38);
            this.panelFiltroEstado.TabIndex = 2;
            //
            // lblIconoFiltro
            //
            this.lblIconoFiltro.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F);
            this.lblIconoFiltro.ForeColor = Tema.TextoSecundario;
            this.lblIconoFiltro.Location = new System.Drawing.Point(8, 7);
            this.lblIconoFiltro.Name = "lblIconoFiltro";
            this.lblIconoFiltro.Size = new System.Drawing.Size(24, 24);
            this.lblIconoFiltro.TabIndex = 0;
            this.lblIconoFiltro.Text = "⚡";
            this.lblIconoFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cmbEstadoFiltro
            //
            this.cmbEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoFiltro.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9.5F);
            this.cmbEstadoFiltro.ForeColor = Tema.TextoPrincipal;
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(36, 7);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(154, 25);
            this.cmbEstadoFiltro.TabIndex = 1;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            //
            // panelMetricas
            //
            this.panelMetricas.Controls.Add(this.cardFinalizadas);
            this.panelMetricas.Controls.Add(this.cardEnProceso);
            this.panelMetricas.Controls.Add(this.cardTotal);
            this.panelMetricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetricas.Height = 74;
            this.panelMetricas.Location = new System.Drawing.Point(24, 132);
            this.panelMetricas.Name = "panelMetricas";
            this.panelMetricas.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.panelMetricas.Size = new System.Drawing.Size(1052, 74);
            this.panelMetricas.TabIndex = 2;
            //
            // cardTotal
            //
            this.cardTotal.BackColor = Tema.Superficie;
            this.cardTotal.Controls.Add(this.lblTotalNum);
            this.cardTotal.Controls.Add(this.lblTotalTitulo);
            this.cardTotal.Controls.Add(this.lblIconoTotal);
            this.cardTotal.Location = new System.Drawing.Point(0, 4);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.cardTotal.Size = new System.Drawing.Size(260, 60);
            this.cardTotal.TabIndex = 0;
            //
            // lblIconoTotal
            //
            this.lblIconoTotal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblIconoTotal.ForeColor = Tema.AzulPrimario;
            this.lblIconoTotal.Location = new System.Drawing.Point(8, 10);
            this.lblIconoTotal.Name = "lblIconoTotal";
            this.lblIconoTotal.Size = new System.Drawing.Size(36, 36);
            this.lblIconoTotal.TabIndex = 0;
            this.lblIconoTotal.Text = "📋";
            this.lblIconoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTotalTitulo
            //
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = Tema.FuentePequena;
            this.lblTotalTitulo.ForeColor = Tema.TextoSecundario;
            this.lblTotalTitulo.Location = new System.Drawing.Point(50, 10);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(91, 15);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "Total consultas";
            //
            // lblTotalNum
            //
            this.lblTotalNum.AutoSize = true;
            this.lblTotalNum.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalNum.ForeColor = Tema.AzulOscuro;
            this.lblTotalNum.Location = new System.Drawing.Point(50, 27);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size(23, 26);
            this.lblTotalNum.TabIndex = 2;
            this.lblTotalNum.Text = "0";
            //
            // cardEnProceso
            //
            this.cardEnProceso.BackColor = Tema.Superficie;
            this.cardEnProceso.Controls.Add(this.lblEnProcesoNum);
            this.cardEnProceso.Controls.Add(this.lblEnProcesoTitulo);
            this.cardEnProceso.Controls.Add(this.lblIconoEnProceso);
            this.cardEnProceso.Location = new System.Drawing.Point(274, 4);
            this.cardEnProceso.Name = "cardEnProceso";
            this.cardEnProceso.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.cardEnProceso.Size = new System.Drawing.Size(260, 60);
            this.cardEnProceso.TabIndex = 1;
            //
            // lblIconoEnProceso
            //
            this.lblIconoEnProceso.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblIconoEnProceso.ForeColor = Tema.Advertencia;
            this.lblIconoEnProceso.Location = new System.Drawing.Point(8, 10);
            this.lblIconoEnProceso.Name = "lblIconoEnProceso";
            this.lblIconoEnProceso.Size = new System.Drawing.Size(36, 36);
            this.lblIconoEnProceso.TabIndex = 0;
            this.lblIconoEnProceso.Text = "⏳";
            this.lblIconoEnProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEnProcesoTitulo
            //
            this.lblEnProcesoTitulo.AutoSize = true;
            this.lblEnProcesoTitulo.Font = Tema.FuentePequena;
            this.lblEnProcesoTitulo.ForeColor = Tema.TextoSecundario;
            this.lblEnProcesoTitulo.Location = new System.Drawing.Point(50, 10);
            this.lblEnProcesoTitulo.Name = "lblEnProcesoTitulo";
            this.lblEnProcesoTitulo.Size = new System.Drawing.Size(73, 15);
            this.lblEnProcesoTitulo.TabIndex = 1;
            this.lblEnProcesoTitulo.Text = "En proceso";
            //
            // lblEnProcesoNum
            //
            this.lblEnProcesoNum.AutoSize = true;
            this.lblEnProcesoNum.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F, System.Drawing.FontStyle.Bold);
            this.lblEnProcesoNum.ForeColor = Tema.Advertencia;
            this.lblEnProcesoNum.Location = new System.Drawing.Point(50, 27);
            this.lblEnProcesoNum.Name = "lblEnProcesoNum";
            this.lblEnProcesoNum.Size = new System.Drawing.Size(23, 26);
            this.lblEnProcesoNum.TabIndex = 2;
            this.lblEnProcesoNum.Text = "0";
            //
            // cardFinalizadas
            //
            this.cardFinalizadas.BackColor = Tema.Superficie;
            this.cardFinalizadas.Controls.Add(this.lblFinalizadasNum);
            this.cardFinalizadas.Controls.Add(this.lblFinalizadasTitulo);
            this.cardFinalizadas.Controls.Add(this.lblIconoFinalizadas);
            this.cardFinalizadas.Location = new System.Drawing.Point(548, 4);
            this.cardFinalizadas.Name = "cardFinalizadas";
            this.cardFinalizadas.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.cardFinalizadas.Size = new System.Drawing.Size(260, 60);
            this.cardFinalizadas.TabIndex = 2;
            //
            // lblIconoFinalizadas
            //
            this.lblIconoFinalizadas.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblIconoFinalizadas.ForeColor = Tema.VerdeOscuro;
            this.lblIconoFinalizadas.Location = new System.Drawing.Point(8, 10);
            this.lblIconoFinalizadas.Name = "lblIconoFinalizadas";
            this.lblIconoFinalizadas.Size = new System.Drawing.Size(36, 36);
            this.lblIconoFinalizadas.TabIndex = 0;
            this.lblIconoFinalizadas.Text = "✓";
            this.lblIconoFinalizadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFinalizadasTitulo
            //
            this.lblFinalizadasTitulo.AutoSize = true;
            this.lblFinalizadasTitulo.Font = Tema.FuentePequena;
            this.lblFinalizadasTitulo.ForeColor = Tema.TextoSecundario;
            this.lblFinalizadasTitulo.Location = new System.Drawing.Point(50, 10);
            this.lblFinalizadasTitulo.Name = "lblFinalizadasTitulo";
            this.lblFinalizadasTitulo.Size = new System.Drawing.Size(73, 15);
            this.lblFinalizadasTitulo.TabIndex = 1;
            this.lblFinalizadasTitulo.Text = "Finalizadas";
            //
            // lblFinalizadasNum
            //
            this.lblFinalizadasNum.AutoSize = true;
            this.lblFinalizadasNum.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F, System.Drawing.FontStyle.Bold);
            this.lblFinalizadasNum.ForeColor = Tema.VerdeOscuro;
            this.lblFinalizadasNum.Location = new System.Drawing.Point(50, 27);
            this.lblFinalizadasNum.Name = "lblFinalizadasNum";
            this.lblFinalizadasNum.Size = new System.Drawing.Size(23, 26);
            this.lblFinalizadasNum.TabIndex = 2;
            this.lblFinalizadasNum.Text = "0";
            //
            // panelGridContenedor
            //
            this.panelGridContenedor.Controls.Add(this.dgvConsultas);
            this.panelGridContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridContenedor.Location = new System.Drawing.Point(24, 206);
            this.panelGridContenedor.Name = "panelGridContenedor";
            this.panelGridContenedor.Size = new System.Drawing.Size(1052, 434);
            this.panelGridContenedor.TabIndex = 3;
            //
            // dgvConsultas
            //
            this.dgvConsultas.AccessibleDescription = "Use las flechas para explorar las consultas registradas.";
            this.dgvConsultas.AccessibleName = "Listado de consultas médicas";
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AllowUserToDeleteRows = false;
            this.dgvConsultas.AllowUserToResizeRows = false;
            this.dgvConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultas.BackgroundColor = Tema.Superficie;
            this.dgvConsultas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsultas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvConsultas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultas.Location = new System.Drawing.Point(0, 0);
            this.dgvConsultas.MultiSelect = false;
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.RowHeadersVisible = false;
            this.dgvConsultas.RowTemplate.Height = 46;
            this.dgvConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultas.Size = new System.Drawing.Size(1052, 434);
            this.dgvConsultas.TabIndex = 0;
            this.dgvConsultas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultas_CellContentClick);
            this.dgvConsultas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConsultas_CellMouseMove);
            this.dgvConsultas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvConsultas_CellPainting);
            //
            // panelFooter
            //
            this.panelFooter.Controls.Add(this.lblConteo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Height = 40;
            this.panelFooter.Location = new System.Drawing.Point(24, 640);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1052, 40);
            this.panelFooter.TabIndex = 4;
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = Tema.FuenteAyuda;
            this.lblConteo.ForeColor = Tema.TextoSecundario;
            this.lblConteo.Location = new System.Drawing.Point(4, 12);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(195, 15);
            this.lblConteo.TabIndex = 0;
            this.lblConteo.Text = "Mostrando 0 consultas registradas";
            //
            // paginaPrincipalConsultas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelCardPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "paginaPrincipalConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consultas Médicas";
            this.Load += new System.EventHandler(this.paginaPrincipalConsultas_Load);
            this.panelCardPrincipal.ResumeLayout(false);
            this.panelHeaderModulo.ResumeLayout(false);
            this.panelHeaderModulo.PerformLayout();
            this.panelIconoModulo.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelFiltroFecha.ResumeLayout(false);
            this.panelFiltroFecha.PerformLayout();
            this.panelFiltroEstado.ResumeLayout(false);
            this.panelMetricas.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.cardEnProceso.ResumeLayout(false);
            this.cardEnProceso.PerformLayout();
            this.cardFinalizadas.ResumeLayout(false);
            this.cardFinalizadas.PerformLayout();
            this.panelGridContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCardPrincipal;
        private System.Windows.Forms.Panel panelHeaderModulo;
        private System.Windows.Forms.Panel panelIconoModulo;
        private System.Windows.Forms.Label lblIconoModulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNuevaConsulta;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.Label lblIconoBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Panel panelFiltroFecha;
        private System.Windows.Forms.Label lblIconoFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.CheckBox chkTodasFechas;
        private System.Windows.Forms.Panel panelFiltroEstado;
        private System.Windows.Forms.Label lblIconoFiltro;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.Panel panelMetricas;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblIconoTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalNum;
        private System.Windows.Forms.Panel cardEnProceso;
        private System.Windows.Forms.Label lblIconoEnProceso;
        private System.Windows.Forms.Label lblEnProcesoTitulo;
        private System.Windows.Forms.Label lblEnProcesoNum;
        private System.Windows.Forms.Panel cardFinalizadas;
        private System.Windows.Forms.Label lblIconoFinalizadas;
        private System.Windows.Forms.Label lblFinalizadasTitulo;
        private System.Windows.Forms.Label lblFinalizadasNum;
        private System.Windows.Forms.Panel panelGridContenedor;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblConteo;
    }
}
