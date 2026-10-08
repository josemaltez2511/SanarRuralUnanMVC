using System.Drawing;
using System.Windows.Forms;
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
            this.panelCardPrincipal = new System.Windows.Forms.Panel();
            this.panelHeaderModulo = new System.Windows.Forms.Panel();
            this.panelIconoModulo = new System.Windows.Forms.Panel();
            this.lblIconoModulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
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
            this.cardAtendidas = new System.Windows.Forms.Panel();
            this.lblIconoAtendidas = new System.Windows.Forms.Label();
            this.lblAtendidasTitulo = new System.Windows.Forms.Label();
            this.lblAtendidasNum = new System.Windows.Forms.Label();
            this.cardPendientes = new System.Windows.Forms.Panel();
            this.lblIconoPendientes = new System.Windows.Forms.Label();
            this.lblPendientesTitulo = new System.Windows.Forms.Label();
            this.lblPendientesNum = new System.Windows.Forms.Label();
            this.panelGridContenedor = new System.Windows.Forms.Panel();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblConteo = new System.Windows.Forms.Label();
            this.btnPaginaAnt = new System.Windows.Forms.Button();
            this.btnPaginaActual = new System.Windows.Forms.Button();
            this.btnPaginaSig = new System.Windows.Forms.Button();
            this.panelCardPrincipal.SuspendLayout();
            this.panelHeaderModulo.SuspendLayout();
            this.panelIconoModulo.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelFiltroFecha.SuspendLayout();
            this.panelFiltroEstado.SuspendLayout();
            this.panelMetricas.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardAtendidas.SuspendLayout();
            this.cardPendientes.SuspendLayout();
            this.panelGridContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
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
            this.panelCardPrincipal.Size = new System.Drawing.Size(1085, 718);
            this.panelCardPrincipal.TabIndex = 0;
            //
            // panelHeaderModulo
            //
            this.panelHeaderModulo.Controls.Add(this.btnNuevo);
            this.panelHeaderModulo.Controls.Add(this.lblSubtitulo);
            this.panelHeaderModulo.Controls.Add(this.lblTitulo);
            this.panelHeaderModulo.Controls.Add(this.panelIconoModulo);
            this.panelHeaderModulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderModulo.Height = 60;
            this.panelHeaderModulo.Location = new System.Drawing.Point(24, 20);
            this.panelHeaderModulo.Name = "panelHeaderModulo";
            this.panelHeaderModulo.Size = new System.Drawing.Size(1037, 60);
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
            this.lblIconoModulo.Text = "📅";
            this.lblIconoModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(54, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(168, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Citas Médicas";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(56, 35);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(335, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Programación, seguimiento y confirmación de consultas médicas.";
            //
            // btnNuevo
            //
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(877, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(160, 42);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "＋  Nueva cita";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.panelToolbar.Size = new System.Drawing.Size(1037, 52);
            this.panelToolbar.TabIndex = 1;
            //
            // panelBuscar
            //
            this.panelBuscar.BackColor = System.Drawing.Color.White;
            this.panelBuscar.Controls.Add(this.btnLimpiarBusqueda);
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Controls.Add(this.lblIconoBuscar);
            this.panelBuscar.Location = new System.Drawing.Point(0, 6);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(360, 40);
            this.panelBuscar.TabIndex = 0;
            //
            // lblIconoBuscar
            //
            this.lblIconoBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoBuscar.ForeColor = Tema.TextoSecundario;
            this.lblIconoBuscar.Location = new System.Drawing.Point(8, 6);
            this.lblIconoBuscar.Name = "lblIconoBuscar";
            this.lblIconoBuscar.Size = new System.Drawing.Size(26, 26);
            this.lblIconoBuscar.TabIndex = 0;
            this.lblIconoBuscar.Text = "🔍";
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F);
            this.txtBuscar.ForeColor = Tema.TextoPrincipal;
            this.txtBuscar.Location = new System.Drawing.Point(38, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(284, 19);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // btnLimpiarBusqueda
            //
            this.btnLimpiarBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.btnLimpiarBusqueda.ForeColor = Tema.TextoSecundario;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(326, 6);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(28, 28);
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Visible = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            //
            // panelFiltroFecha
            //
            this.panelFiltroFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltroFecha.BackColor = System.Drawing.Color.White;
            this.panelFiltroFecha.Controls.Add(this.chkTodasFechas);
            this.panelFiltroFecha.Controls.Add(this.dtpFechaFiltro);
            this.panelFiltroFecha.Controls.Add(this.lblIconoFecha);
            this.panelFiltroFecha.Location = new System.Drawing.Point(595, 6);
            this.panelFiltroFecha.Name = "panelFiltroFecha";
            this.panelFiltroFecha.Size = new System.Drawing.Size(240, 40);
            this.panelFiltroFecha.TabIndex = 1;
            //
            // lblIconoFecha
            //
            this.lblIconoFecha.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoFecha.ForeColor = Tema.TextoSecundario;
            this.lblIconoFecha.Location = new System.Drawing.Point(6, 6);
            this.lblIconoFecha.Name = "lblIconoFecha";
            this.lblIconoFecha.Size = new System.Drawing.Size(26, 26);
            this.lblIconoFecha.TabIndex = 0;
            this.lblIconoFecha.Text = "📅";
            this.lblIconoFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dtpFechaFiltro
            //
            this.dtpFechaFiltro.Enabled = false;
            this.dtpFechaFiltro.Font = Tema.FuentePequena;
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(34, 8);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(120, 24);
            this.dtpFechaFiltro.TabIndex = 1;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            //
            // chkTodasFechas
            //
            this.chkTodasFechas.AutoSize = true;
            this.chkTodasFechas.Checked = true;
            this.chkTodasFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasFechas.Font = Tema.FuentePequena;
            this.chkTodasFechas.ForeColor = Tema.TextoSecundario;
            this.chkTodasFechas.Location = new System.Drawing.Point(162, 10);
            this.chkTodasFechas.Name = "chkTodasFechas";
            this.chkTodasFechas.Size = new System.Drawing.Size(63, 19);
            this.chkTodasFechas.TabIndex = 2;
            this.chkTodasFechas.Text = "Todas";
            this.chkTodasFechas.UseVisualStyleBackColor = true;
            this.chkTodasFechas.CheckedChanged += new System.EventHandler(this.chkTodasFechas_CheckedChanged);
            //
            // panelFiltroEstado
            //
            this.panelFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltroEstado.BackColor = System.Drawing.Color.White;
            this.panelFiltroEstado.Controls.Add(this.cmbEstadoFiltro);
            this.panelFiltroEstado.Controls.Add(this.lblIconoFiltro);
            this.panelFiltroEstado.Location = new System.Drawing.Point(847, 6);
            this.panelFiltroEstado.Name = "panelFiltroEstado";
            this.panelFiltroEstado.Size = new System.Drawing.Size(190, 40);
            this.panelFiltroEstado.TabIndex = 2;
            //
            // lblIconoFiltro
            //
            this.lblIconoFiltro.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoFiltro.ForeColor = Tema.TextoSecundario;
            this.lblIconoFiltro.Location = new System.Drawing.Point(6, 6);
            this.lblIconoFiltro.Name = "lblIconoFiltro";
            this.lblIconoFiltro.Size = new System.Drawing.Size(26, 26);
            this.lblIconoFiltro.TabIndex = 0;
            this.lblIconoFiltro.Text = "🏷";
            this.lblIconoFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cmbEstadoFiltro
            //
            this.cmbEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoFiltro.Font = Tema.FuenteCuerpo;
            this.cmbEstadoFiltro.ForeColor = Tema.TextoPrincipal;
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(34, 8);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(148, 24);
            this.cmbEstadoFiltro.TabIndex = 1;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            //
            // panelMetricas
            //
            this.panelMetricas.Controls.Add(this.cardPendientes);
            this.panelMetricas.Controls.Add(this.cardAtendidas);
            this.panelMetricas.Controls.Add(this.cardTotal);
            this.panelMetricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetricas.Height = 84;
            this.panelMetricas.Location = new System.Drawing.Point(24, 132);
            this.panelMetricas.Name = "panelMetricas";
            this.panelMetricas.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelMetricas.Size = new System.Drawing.Size(1037, 84);
            this.panelMetricas.TabIndex = 2;
            //
            // cardTotal
            //
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(237, 245, 250);
            this.cardTotal.Controls.Add(this.lblTotalNum);
            this.cardTotal.Controls.Add(this.lblTotalTitulo);
            this.cardTotal.Controls.Add(this.lblIconoTotal);
            this.cardTotal.Location = new System.Drawing.Point(0, 6);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(330, 68);
            this.cardTotal.TabIndex = 0;
            //
            // lblIconoTotal
            //
            this.lblIconoTotal.BackColor = System.Drawing.Color.FromArgb(216, 235, 247);
            this.lblIconoTotal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoTotal.ForeColor = Tema.AzulPrimario;
            this.lblIconoTotal.Location = new System.Drawing.Point(12, 14);
            this.lblIconoTotal.Name = "lblIconoTotal";
            this.lblIconoTotal.Size = new System.Drawing.Size(40, 40);
            this.lblIconoTotal.TabIndex = 0;
            this.lblIconoTotal.Text = "📅";
            this.lblIconoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTotalTitulo
            //
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = Tema.FuenteMetricaLabel;
            this.lblTotalTitulo.ForeColor = Tema.TextoSecundario;
            this.lblTotalTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(126, 17);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "Citas programadas";
            //
            // lblTotalNum
            //
            this.lblTotalNum.AutoSize = true;
            this.lblTotalNum.Font = Tema.FuenteMetricaNumero;
            this.lblTotalNum.ForeColor = Tema.AzulOscuro;
            this.lblTotalNum.Location = new System.Drawing.Point(60, 28);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size(33, 37);
            this.lblTotalNum.TabIndex = 2;
            this.lblTotalNum.Text = "0";
            //
            // cardAtendidas
            //
            this.cardAtendidas.BackColor = System.Drawing.Color.FromArgb(238, 248, 240);
            this.cardAtendidas.Controls.Add(this.lblAtendidasNum);
            this.cardAtendidas.Controls.Add(this.lblAtendidasTitulo);
            this.cardAtendidas.Controls.Add(this.lblIconoAtendidas);
            this.cardAtendidas.Location = new System.Drawing.Point(350, 6);
            this.cardAtendidas.Name = "cardAtendidas";
            this.cardAtendidas.Size = new System.Drawing.Size(330, 68);
            this.cardAtendidas.TabIndex = 1;
            //
            // lblIconoAtendidas
            //
            this.lblIconoAtendidas.BackColor = System.Drawing.Color.FromArgb(219, 241, 223);
            this.lblIconoAtendidas.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoAtendidas.ForeColor = Tema.VerdeOscuro;
            this.lblIconoAtendidas.Location = new System.Drawing.Point(12, 14);
            this.lblIconoAtendidas.Name = "lblIconoAtendidas";
            this.lblIconoAtendidas.Size = new System.Drawing.Size(40, 40);
            this.lblIconoAtendidas.TabIndex = 0;
            this.lblIconoAtendidas.Text = "✓";
            this.lblIconoAtendidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblAtendidasTitulo
            //
            this.lblAtendidasTitulo.AutoSize = true;
            this.lblAtendidasTitulo.Font = Tema.FuenteMetricaLabel;
            this.lblAtendidasTitulo.ForeColor = Tema.TextoSecundario;
            this.lblAtendidasTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblAtendidasTitulo.Name = "lblAtendidasTitulo";
            this.lblAtendidasTitulo.Size = new System.Drawing.Size(155, 17);
            this.lblAtendidasTitulo.TabIndex = 1;
            this.lblAtendidasTitulo.Text = "Atendidas / Confirmadas";
            //
            // lblAtendidasNum
            //
            this.lblAtendidasNum.AutoSize = true;
            this.lblAtendidasNum.Font = Tema.FuenteMetricaNumero;
            this.lblAtendidasNum.ForeColor = Tema.VerdeOscuro;
            this.lblAtendidasNum.Location = new System.Drawing.Point(60, 28);
            this.lblAtendidasNum.Name = "lblAtendidasNum";
            this.lblAtendidasNum.Size = new System.Drawing.Size(33, 37);
            this.lblAtendidasNum.TabIndex = 2;
            this.lblAtendidasNum.Text = "0";
            //
            // cardPendientes
            //
            this.cardPendientes.BackColor = System.Drawing.Color.FromArgb(254, 249, 237);
            this.cardPendientes.Controls.Add(this.lblPendientesNum);
            this.cardPendientes.Controls.Add(this.lblPendientesTitulo);
            this.cardPendientes.Controls.Add(this.lblIconoPendientes);
            this.cardPendientes.Location = new System.Drawing.Point(700, 6);
            this.cardPendientes.Name = "cardPendientes";
            this.cardPendientes.Size = new System.Drawing.Size(330, 68);
            this.cardPendientes.TabIndex = 2;
            //
            // lblIconoPendientes
            //
            this.lblIconoPendientes.BackColor = System.Drawing.Color.FromArgb(253, 238, 203);
            this.lblIconoPendientes.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoPendientes.ForeColor = Tema.Advertencia;
            this.lblIconoPendientes.Location = new System.Drawing.Point(12, 14);
            this.lblIconoPendientes.Name = "lblIconoPendientes";
            this.lblIconoPendientes.Size = new System.Drawing.Size(40, 40);
            this.lblIconoPendientes.TabIndex = 0;
            this.lblIconoPendientes.Text = "⏳";
            this.lblIconoPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPendientesTitulo
            //
            this.lblPendientesTitulo.AutoSize = true;
            this.lblPendientesTitulo.Font = Tema.FuenteMetricaLabel;
            this.lblPendientesTitulo.ForeColor = Tema.TextoSecundario;
            this.lblPendientesTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblPendientesTitulo.Name = "lblPendientesTitulo";
            this.lblPendientesTitulo.Size = new System.Drawing.Size(145, 17);
            this.lblPendientesTitulo.TabIndex = 1;
            this.lblPendientesTitulo.Text = "Pendientes por atender";
            //
            // lblPendientesNum
            //
            this.lblPendientesNum.AutoSize = true;
            this.lblPendientesNum.Font = Tema.FuenteMetricaNumero;
            this.lblPendientesNum.ForeColor = Tema.Advertencia;
            this.lblPendientesNum.Location = new System.Drawing.Point(60, 28);
            this.lblPendientesNum.Name = "lblPendientesNum";
            this.lblPendientesNum.Size = new System.Drawing.Size(33, 37);
            this.lblPendientesNum.TabIndex = 2;
            this.lblPendientesNum.Text = "0";
            //
            // panelGridContenedor
            //
            this.panelGridContenedor.Controls.Add(this.dgvCitas);
            this.panelGridContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridContenedor.Location = new System.Drawing.Point(24, 216);
            this.panelGridContenedor.Name = "panelGridContenedor";
            this.panelGridContenedor.Padding = new System.Windows.Forms.Padding(0, 10, 0, 8);
            this.panelGridContenedor.Size = new System.Drawing.Size(1037, 444);
            this.panelGridContenedor.TabIndex = 3;
            //
            // dgvCitas
            //
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.TabIndex = 0;
            this.dgvCitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellContentClick);
            this.dgvCitas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCitas_CellMouseMove);
            this.dgvCitas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCitas_CellPainting);
            //
            // panelFooter
            //
            this.panelFooter.Controls.Add(this.btnPaginaSig);
            this.panelFooter.Controls.Add(this.btnPaginaActual);
            this.panelFooter.Controls.Add(this.btnPaginaAnt);
            this.panelFooter.Controls.Add(this.lblConteo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Height = 38;
            this.panelFooter.Location = new System.Drawing.Point(24, 660);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1037, 38);
            this.panelFooter.TabIndex = 4;
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = Tema.FuentePequena;
            this.lblConteo.ForeColor = Tema.TextoSecundario;
            this.lblConteo.Location = new System.Drawing.Point(0, 12);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(150, 15);
            this.lblConteo.TabIndex = 0;
            this.lblConteo.Text = "Mostrando 0 de 0 citas";
            //
            // btnPaginaAnt
            //
            this.btnPaginaAnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginaAnt.BackColor = System.Drawing.Color.White;
            this.btnPaginaAnt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnt.FlatAppearance.BorderColor = Tema.Borde;
            this.btnPaginaAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaAnt.Font = Tema.FuentePequena;
            this.btnPaginaAnt.ForeColor = Tema.TextoSecundario;
            this.btnPaginaAnt.Location = new System.Drawing.Point(925, 4);
            this.btnPaginaAnt.Name = "btnPaginaAnt";
            this.btnPaginaAnt.Size = new System.Drawing.Size(32, 30);
            this.btnPaginaAnt.TabIndex = 1;
            this.btnPaginaAnt.Text = "‹";
            this.btnPaginaAnt.UseVisualStyleBackColor = false;
            //
            // btnPaginaActual
            //
            this.btnPaginaActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginaActual.BackColor = Tema.AzulPrimario;
            this.btnPaginaActual.FlatAppearance.BorderSize = 0;
            this.btnPaginaActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaActual.Font = Tema.FuentePequena;
            this.btnPaginaActual.ForeColor = System.Drawing.Color.White;
            this.btnPaginaActual.Location = new System.Drawing.Point(963, 4);
            this.btnPaginaActual.Name = "btnPaginaActual";
            this.btnPaginaActual.Size = new System.Drawing.Size(32, 30);
            this.btnPaginaActual.TabIndex = 2;
            this.btnPaginaActual.Text = "1";
            this.btnPaginaActual.UseVisualStyleBackColor = false;
            //
            // btnPaginaSig
            //
            this.btnPaginaSig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginaSig.BackColor = System.Drawing.Color.White;
            this.btnPaginaSig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSig.FlatAppearance.BorderColor = Tema.Borde;
            this.btnPaginaSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaSig.Font = Tema.FuentePequena;
            this.btnPaginaSig.ForeColor = Tema.TextoSecundario;
            this.btnPaginaSig.Location = new System.Drawing.Point(1001, 4);
            this.btnPaginaSig.Name = "btnPaginaSig";
            this.btnPaginaSig.Size = new System.Drawing.Size(32, 30);
            this.btnPaginaSig.TabIndex = 3;
            this.btnPaginaSig.Text = "›";
            this.btnPaginaSig.UseVisualStyleBackColor = false;
            //
            // paginaPrincipalCitas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1085, 718);
            this.Controls.Add(this.panelCardPrincipal);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "paginaPrincipalCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Gestión de Citas Médicas";
            this.Load += new System.EventHandler(this.paginaPrincipalCitas_Load);
            this.Resize += new System.EventHandler(this.paginaPrincipalCitas_Resize);
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
            this.cardAtendidas.ResumeLayout(false);
            this.cardAtendidas.PerformLayout();
            this.cardPendientes.ResumeLayout(false);
            this.cardPendientes.PerformLayout();
            this.panelGridContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
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
        private System.Windows.Forms.Button btnNuevo;
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
        private System.Windows.Forms.Panel cardAtendidas;
        private System.Windows.Forms.Label lblIconoAtendidas;
        private System.Windows.Forms.Label lblAtendidasTitulo;
        private System.Windows.Forms.Label lblAtendidasNum;
        private System.Windows.Forms.Panel cardPendientes;
        private System.Windows.Forms.Label lblIconoPendientes;
        private System.Windows.Forms.Label lblPendientesTitulo;
        private System.Windows.Forms.Label lblPendientesNum;
        private System.Windows.Forms.Panel panelGridContenedor;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Button btnPaginaAnt;
        private System.Windows.Forms.Button btnPaginaActual;
        private System.Windows.Forms.Button btnPaginaSig;
    }
}
