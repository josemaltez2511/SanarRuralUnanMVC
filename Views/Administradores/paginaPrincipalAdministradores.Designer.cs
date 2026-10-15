using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Administradores
{
    partial class paginaPrincipalAdministradores
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
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblConteo = new System.Windows.Forms.Label();
            this.panelGridContenedor = new System.Windows.Forms.Panel();
            this.dgvAdministradores = new System.Windows.Forms.DataGridView();
            this.colIdAdministrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelMetricas = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblIconoTotal = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotalNum = new System.Windows.Forms.Label();
            this.cardActivos = new System.Windows.Forms.Panel();
            this.lblIconoActivos = new System.Windows.Forms.Label();
            this.lblActivosTitulo = new System.Windows.Forms.Label();
            this.lblActivosNum = new System.Windows.Forms.Label();
            this.cardInactivos = new System.Windows.Forms.Panel();
            this.lblIconoInactivos = new System.Windows.Forms.Label();
            this.lblInactivosTitulo = new System.Windows.Forms.Label();
            this.lblInactivosNum = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panelFiltroEstado = new System.Windows.Forms.Panel();
            this.lblIconoFiltro = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblIconoBuscar = new System.Windows.Forms.Label();
            this.panelHeaderModulo = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelIconoModulo = new System.Windows.Forms.Panel();
            this.lblIconoModulo = new System.Windows.Forms.Label();
            this.panelCardPrincipal.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelGridContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdministradores)).BeginInit();
            this.panelMetricas.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardActivos.SuspendLayout();
            this.cardInactivos.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelFiltroEstado.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelHeaderModulo.SuspendLayout();
            this.panelIconoModulo.SuspendLayout();
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
            // panelFooter
            //
            this.panelFooter.Controls.Add(this.lblConteo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Height = 36;
            this.panelFooter.Location = new System.Drawing.Point(24, 662);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1037, 36);
            this.panelFooter.TabIndex = 4;
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = Tema.FuenteAyuda;
            this.lblConteo.ForeColor = Tema.TextoSecundario;
            this.lblConteo.Location = new System.Drawing.Point(6, 10);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(170, 15);
            this.lblConteo.TabIndex = 0;
            this.lblConteo.Text = "Mostrando 0 administradores";
            //
            // panelGridContenedor
            //
            this.panelGridContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGridContenedor.Controls.Add(this.dgvAdministradores);
            this.panelGridContenedor.Location = new System.Drawing.Point(24, 214);
            this.panelGridContenedor.Name = "panelGridContenedor";
            this.panelGridContenedor.Size = new System.Drawing.Size(1037, 442);
            this.panelGridContenedor.TabIndex = 3;
            //
            // dgvAdministradores
            //
            this.dgvAdministradores.AllowUserToAddRows = false;
            this.dgvAdministradores.AllowUserToDeleteRows = false;
            this.dgvAdministradores.AllowUserToResizeRows = false;
            this.dgvAdministradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdministradores.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdministradores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdministradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAdministradores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdAdministrador,
            this.colNombre,
            this.colCedula,
            this.colTelefono,
            this.colCorreo,
            this.colCuenta,
            this.colEstado,
            this.colVer,
            this.colEditar,
            this.colBaja});
            this.dgvAdministradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdministradores.Location = new System.Drawing.Point(0, 0);
            this.dgvAdministradores.MultiSelect = false;
            this.dgvAdministradores.Name = "dgvAdministradores";
            this.dgvAdministradores.ReadOnly = true;
            this.dgvAdministradores.RowHeadersVisible = false;
            this.dgvAdministradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdministradores.Size = new System.Drawing.Size(1037, 442);
            this.dgvAdministradores.TabIndex = 0;
            this.dgvAdministradores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdministradores_CellContentClick);
            this.dgvAdministradores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAdministradores_CellMouseMove);
            this.dgvAdministradores.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAdministradores_CellPainting);
            //
            // colIdAdministrador
            //
            this.colIdAdministrador.HeaderText = "ID";
            this.colIdAdministrador.Name = "colIdAdministrador";
            this.colIdAdministrador.ReadOnly = true;
            this.colIdAdministrador.Visible = false;
            //
            // colNombre
            //
            this.colNombre.HeaderText = "Administrador";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            //
            // colCedula
            //
            this.colCedula.HeaderText = "Cédula";
            this.colCedula.Name = "colCedula";
            this.colCedula.ReadOnly = true;
            //
            // colTelefono
            //
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            //
            // colCorreo
            //
            this.colCorreo.HeaderText = "Correo electrónico";
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            //
            // colCuenta
            //
            this.colCuenta.HeaderText = "Cuenta de acceso";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            //
            // colEstado
            //
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            //
            // colVer
            //
            this.colVer.HeaderText = "Detalle";
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            //
            // colEditar
            //
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            //
            // colBaja
            //
            this.colBaja.HeaderText = "Acción";
            this.colBaja.Name = "colBaja";
            this.colBaja.ReadOnly = true;
            this.colBaja.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            //
            // panelMetricas
            //
            this.panelMetricas.Controls.Add(this.cardTotal);
            this.panelMetricas.Controls.Add(this.cardActivos);
            this.panelMetricas.Controls.Add(this.cardInactivos);
            this.panelMetricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetricas.Height = 78;
            this.panelMetricas.Location = new System.Drawing.Point(24, 132);
            this.panelMetricas.Name = "panelMetricas";
            this.panelMetricas.Size = new System.Drawing.Size(1037, 78);
            this.panelMetricas.TabIndex = 2;
            //
            // cardTotal
            //
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(244, 248, 252);
            this.cardTotal.Controls.Add(this.lblIconoTotal);
            this.cardTotal.Controls.Add(this.lblTotalTitulo);
            this.cardTotal.Controls.Add(this.lblTotalNum);
            this.cardTotal.Location = new System.Drawing.Point(0, 6);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(320, 68);
            this.cardTotal.TabIndex = 0;
            //
            // lblIconoTotal
            //
            this.lblIconoTotal.BackColor = System.Drawing.Color.FromArgb(215, 235, 248);
            this.lblIconoTotal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 13F);
            this.lblIconoTotal.ForeColor = Tema.AzulPrimario;
            this.lblIconoTotal.Location = new System.Drawing.Point(14, 14);
            this.lblIconoTotal.Name = "lblIconoTotal";
            this.lblIconoTotal.Size = new System.Drawing.Size(40, 40);
            this.lblIconoTotal.TabIndex = 0;
            this.lblIconoTotal.Text = "";
            this.lblIconoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTotalTitulo
            //
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = Tema.FuentePequena;
            this.lblTotalTitulo.ForeColor = Tema.TextoSecundario;
            this.lblTotalTitulo.Location = new System.Drawing.Point(62, 14);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(125, 15);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "Total administradores";
            //
            // lblTotalNum
            //
            this.lblTotalNum.AutoSize = true;
            this.lblTotalNum.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalNum.ForeColor = Tema.AzulOscuro;
            this.lblTotalNum.Location = new System.Drawing.Point(62, 30);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size(26, 30);
            this.lblTotalNum.TabIndex = 2;
            this.lblTotalNum.Text = "0";
            //
            // cardActivos
            //
            this.cardActivos.BackColor = System.Drawing.Color.FromArgb(242, 250, 244);
            this.cardActivos.Controls.Add(this.lblIconoActivos);
            this.cardActivos.Controls.Add(this.lblActivosTitulo);
            this.cardActivos.Controls.Add(this.lblActivosNum);
            this.cardActivos.Location = new System.Drawing.Point(334, 6);
            this.cardActivos.Name = "cardActivos";
            this.cardActivos.Size = new System.Drawing.Size(320, 68);
            this.cardActivos.TabIndex = 1;
            //
            // lblIconoActivos
            //
            this.lblIconoActivos.BackColor = System.Drawing.Color.FromArgb(215, 244, 222);
            this.lblIconoActivos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 13F);
            this.lblIconoActivos.ForeColor = Tema.VerdeOscuro;
            this.lblIconoActivos.Location = new System.Drawing.Point(14, 14);
            this.lblIconoActivos.Name = "lblIconoActivos";
            this.lblIconoActivos.Size = new System.Drawing.Size(40, 40);
            this.lblIconoActivos.TabIndex = 0;
            this.lblIconoActivos.Text = "";
            this.lblIconoActivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblActivosTitulo
            //
            this.lblActivosTitulo.AutoSize = true;
            this.lblActivosTitulo.Font = Tema.FuentePequena;
            this.lblActivosTitulo.ForeColor = Tema.TextoSecundario;
            this.lblActivosTitulo.Location = new System.Drawing.Point(62, 14);
            this.lblActivosTitulo.Name = "lblActivosTitulo";
            this.lblActivosTitulo.Size = new System.Drawing.Size(89, 15);
            this.lblActivosTitulo.TabIndex = 1;
            this.lblActivosTitulo.Text = "Perfiles activos";
            //
            // lblActivosNum
            //
            this.lblActivosNum.AutoSize = true;
            this.lblActivosNum.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblActivosNum.ForeColor = Tema.VerdeOscuro;
            this.lblActivosNum.Location = new System.Drawing.Point(62, 30);
            this.lblActivosNum.Name = "lblActivosNum";
            this.lblActivosNum.Size = new System.Drawing.Size(26, 30);
            this.lblActivosNum.TabIndex = 2;
            this.lblActivosNum.Text = "0";
            //
            // cardInactivos
            //
            this.cardInactivos.BackColor = System.Drawing.Color.FromArgb(248, 248, 250);
            this.cardInactivos.Controls.Add(this.lblIconoInactivos);
            this.cardInactivos.Controls.Add(this.lblInactivosTitulo);
            this.cardInactivos.Controls.Add(this.lblInactivosNum);
            this.cardInactivos.Location = new System.Drawing.Point(668, 6);
            this.cardInactivos.Name = "cardInactivos";
            this.cardInactivos.Size = new System.Drawing.Size(320, 68);
            this.cardInactivos.TabIndex = 2;
            //
            // lblIconoInactivos
            //
            this.lblIconoInactivos.BackColor = System.Drawing.Color.FromArgb(235, 237, 240);
            this.lblIconoInactivos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 13F);
            this.lblIconoInactivos.ForeColor = Tema.TextoSecundario;
            this.lblIconoInactivos.Location = new System.Drawing.Point(14, 14);
            this.lblIconoInactivos.Name = "lblIconoInactivos";
            this.lblIconoInactivos.Size = new System.Drawing.Size(40, 40);
            this.lblIconoInactivos.TabIndex = 0;
            this.lblIconoInactivos.Text = "";
            this.lblIconoInactivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblInactivosTitulo
            //
            this.lblInactivosTitulo.AutoSize = true;
            this.lblInactivosTitulo.Font = Tema.FuentePequena;
            this.lblInactivosTitulo.ForeColor = Tema.TextoSecundario;
            this.lblInactivosTitulo.Location = new System.Drawing.Point(62, 14);
            this.lblInactivosTitulo.Name = "lblInactivosTitulo";
            this.lblInactivosTitulo.Size = new System.Drawing.Size(98, 15);
            this.lblInactivosTitulo.TabIndex = 1;
            this.lblInactivosTitulo.Text = "Perfiles inactivos";
            //
            // lblInactivosNum
            //
            this.lblInactivosNum.AutoSize = true;
            this.lblInactivosNum.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblInactivosNum.ForeColor = Tema.TextoSecundario;
            this.lblInactivosNum.Location = new System.Drawing.Point(62, 30);
            this.lblInactivosNum.Name = "lblInactivosNum";
            this.lblInactivosNum.Size = new System.Drawing.Size(26, 30);
            this.lblInactivosNum.TabIndex = 2;
            this.lblInactivosNum.Text = "0";
            //
            // panelToolbar
            //
            this.panelToolbar.Controls.Add(this.panelFiltroEstado);
            this.panelToolbar.Controls.Add(this.panelBuscar);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Height = 52;
            this.panelToolbar.Location = new System.Drawing.Point(24, 80);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1037, 52);
            this.panelToolbar.TabIndex = 1;
            //
            // panelFiltroEstado
            //
            this.panelFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltroEstado.BackColor = System.Drawing.Color.White;
            this.panelFiltroEstado.Controls.Add(this.lblIconoFiltro);
            this.panelFiltroEstado.Controls.Add(this.cmbFiltroEstado);
            this.panelFiltroEstado.Location = new System.Drawing.Point(837, 6);
            this.panelFiltroEstado.Name = "panelFiltroEstado";
            this.panelFiltroEstado.Size = new System.Drawing.Size(200, 40);
            this.panelFiltroEstado.TabIndex = 1;
            //
            // lblIconoFiltro
            //
            this.lblIconoFiltro.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoFiltro.ForeColor = Tema.TextoSecundario;
            this.lblIconoFiltro.Location = new System.Drawing.Point(6, 6);
            this.lblIconoFiltro.Name = "lblIconoFiltro";
            this.lblIconoFiltro.Size = new System.Drawing.Size(26, 26);
            this.lblIconoFiltro.TabIndex = 0;
            this.lblIconoFiltro.Text = "";
            this.lblIconoFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cmbFiltroEstado
            //
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEstado.Font = Tema.FuenteCuerpo;
            this.cmbFiltroEstado.ForeColor = Tema.TextoPrincipal;
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Activos",
            "Inactivos"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(36, 8);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(156, 24);
            this.cmbFiltroEstado.TabIndex = 1;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);
            //
            // panelBuscar
            //
            this.panelBuscar.BackColor = System.Drawing.Color.White;
            this.panelBuscar.Controls.Add(this.btnLimpiarBusqueda);
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Controls.Add(this.lblIconoBuscar);
            this.panelBuscar.Location = new System.Drawing.Point(0, 6);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(460, 40);
            this.panelBuscar.TabIndex = 0;
            //
            // btnLimpiarBusqueda
            //
            this.btnLimpiarBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.btnLimpiarBusqueda.ForeColor = Tema.TextoSecundario;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(426, 6);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(28, 28);
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Visible = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F);
            this.txtBuscar.ForeColor = Tema.TextoPrincipal;
            this.txtBuscar.Location = new System.Drawing.Point(38, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(384, 19);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // lblIconoBuscar
            //
            this.lblIconoBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoBuscar.ForeColor = Tema.TextoSecundario;
            this.lblIconoBuscar.Location = new System.Drawing.Point(8, 6);
            this.lblIconoBuscar.Name = "lblIconoBuscar";
            this.lblIconoBuscar.Size = new System.Drawing.Size(26, 26);
            this.lblIconoBuscar.TabIndex = 0;
            this.lblIconoBuscar.Text = "";
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // btnNuevo
            //
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(847, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(190, 42);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "＋  Nuevo administrador";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(56, 35);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(360, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Gestión de perfiles con acceso administrativo total al sistema.";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(54, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Administradores";
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
            this.lblIconoModulo.Text = "";
            this.lblIconoModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // paginaPrincipalAdministradores
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1085, 718);
            this.Controls.Add(this.panelCardPrincipal);
            this.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "paginaPrincipalAdministradores";
            this.Text = "Administradores";
            this.Load += new System.EventHandler(this.paginaPrincipalAdministradores_Load);
            this.Resize += new System.EventHandler(this.paginaPrincipalAdministradores_Resize);
            this.panelCardPrincipal.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelGridContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdministradores)).EndInit();
            this.panelMetricas.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.cardActivos.ResumeLayout(false);
            this.cardActivos.PerformLayout();
            this.cardInactivos.ResumeLayout(false);
            this.cardInactivos.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelFiltroEstado.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelHeaderModulo.ResumeLayout(false);
            this.panelHeaderModulo.PerformLayout();
            this.panelIconoModulo.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelFiltroEstado;
        private System.Windows.Forms.Label lblIconoFiltro;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Panel panelMetricas;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblIconoTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalNum;
        private System.Windows.Forms.Panel cardActivos;
        private System.Windows.Forms.Label lblIconoActivos;
        private System.Windows.Forms.Label lblActivosTitulo;
        private System.Windows.Forms.Label lblActivosNum;
        private System.Windows.Forms.Panel cardInactivos;
        private System.Windows.Forms.Label lblIconoInactivos;
        private System.Windows.Forms.Label lblInactivosTitulo;
        private System.Windows.Forms.Label lblInactivosNum;
        private System.Windows.Forms.Panel panelGridContenedor;
        private System.Windows.Forms.DataGridView dgvAdministradores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAdministrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colVer;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colBaja;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblConteo;
    }
}
