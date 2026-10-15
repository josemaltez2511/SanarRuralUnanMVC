namespace SanarRuralUnan.Views
{
    partial class asignarAccesoPerfil
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbicacionCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblConteo = new System.Windows.Forms.Label();
            this.btnPaginacionAnt = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnPaginacionSig = new System.Windows.Forms.Button();
            this.pnlBarraFiltros = new System.Windows.Forms.Panel();
            this.lblFiltroTipo = new System.Windows.Forms.Label();
            this.cmbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlBuscarInput = new System.Windows.Forms.Panel();
            this.lblLupa = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.pnlHeaderIzquierdo = new System.Windows.Forms.Panel();
            this.pnlIconoHeader = new System.Windows.Forms.Panel();
            this.lblIconoHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.cardPerfil = new System.Windows.Forms.Panel();
            this.pnlHeaderCardPerfil = new System.Windows.Forms.Panel();
            this.badgePerfil = new System.Windows.Forms.Label();
            this.lblTituloCardPerfil = new System.Windows.Forms.Label();
            this.pnlDetallePerfil = new System.Windows.Forms.Panel();
            this.lblSinSeleccion = new System.Windows.Forms.Label();
            this.lblIconoTipoGrande = new System.Windows.Forms.Label();
            this.lblNombrePerfil = new System.Windows.Forms.Label();
            this.lblTipoPerfil = new System.Windows.Forms.Label();
            this.lblIdentificacionPerfil = new System.Windows.Forms.Label();
            this.lblTelefonoPerfil = new System.Windows.Forms.Label();
            this.lblUbicacionPerfil = new System.Windows.Forms.Label();
            this.panelBannerRol = new System.Windows.Forms.Panel();
            this.lblIconoInfoBanner = new System.Windows.Forms.Label();
            this.lblTextoInfoBanner = new System.Windows.Forms.Label();
            this.cardCredenciales = new System.Windows.Forms.Panel();
            this.pnlHeaderCardCredenciales = new System.Windows.Forms.Panel();
            this.badgeCredenciales = new System.Windows.Forms.Label();
            this.lblTituloCardCredenciales = new System.Windows.Forms.Label();
            this.lblSubtituloCredenciales = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblErrorUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.pnlContrasena = new System.Windows.Forms.Panel();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnVerContrasena = new System.Windows.Forms.Button();
            this.lblAyudaContrasena = new System.Windows.Forms.Label();
            this.lblConfirmarContrasena = new System.Windows.Forms.Label();
            this.pnlConfirmarContrasena = new System.Windows.Forms.Panel();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.btnVerConfirmar = new System.Windows.Forms.Button();
            this.lblErrorConfirmar = new System.Windows.Forms.Label();
            this.pnlBotonesAccion = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCrearAcceso = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlBarraFiltros.SuspendLayout();
            this.pnlBuscarInput.SuspendLayout();
            this.pnlHeaderIzquierdo.SuspendLayout();
            this.pnlIconoHeader.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.cardPerfil.SuspendLayout();
            this.pnlHeaderCardPerfil.SuspendLayout();
            this.pnlDetallePerfil.SuspendLayout();
            this.panelBannerRol.SuspendLayout();
            this.cardCredenciales.SuspendLayout();
            this.pnlHeaderCardCredenciales.SuspendLayout();
            this.pnlContrasena.SuspendLayout();
            this.pnlConfirmarContrasena.SuspendLayout();
            this.pnlBotonesAccion.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlMain
            //
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlIzquierdo);
            this.pnlMain.Controls.Add(this.pnlDerecho);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0);
            this.pnlMain.Size = new System.Drawing.Size(1264, 701);
            this.pnlMain.TabIndex = 0;
            //
            // pnlIzquierdo
            //
            this.pnlIzquierdo.BackColor = System.Drawing.Color.White;
            this.pnlIzquierdo.Controls.Add(this.dgvPerfiles);
            this.pnlIzquierdo.Controls.Add(this.pnlFooter);
            this.pnlIzquierdo.Controls.Add(this.pnlBarraFiltros);
            this.pnlIzquierdo.Controls.Add(this.pnlHeaderIzquierdo);
            this.pnlIzquierdo.Location = new System.Drawing.Point(14, 14);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Padding = new System.Windows.Forms.Padding(16, 14, 16, 12);
            this.pnlIzquierdo.Size = new System.Drawing.Size(770, 673);
            this.pnlIzquierdo.TabIndex = 0;
            //
            // dgvPerfiles
            //
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.AllowUserToResizeRows = false;
            this.dgvPerfiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPerfiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPerfiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerfiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPerfiles.ColumnHeadersHeight = 42;
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPerfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipo,
            this.colNombre,
            this.colIdentificacion,
            this.colTelefono,
            this.colUbicacionCargo,
            this.colAccion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerfiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPerfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerfiles.EnableHeadersVisualStyles = false;
            this.dgvPerfiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvPerfiles.Location = new System.Drawing.Point(16, 142);
            this.dgvPerfiles.MultiSelect = false;
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.RowHeadersVisible = false;
            this.dgvPerfiles.RowTemplate.Height = 54;
            this.dgvPerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerfiles.Size = new System.Drawing.Size(738, 481);
            this.dgvPerfiles.TabIndex = 2;
            //
            // colTipo
            //
            this.colTipo.FillWeight = 15F;
            this.colTipo.HeaderText = "Tipo de perfil";
            this.colTipo.MinimumWidth = 110;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 114;
            //
            // colNombre
            //
            this.colNombre.FillWeight = 32F;
            this.colNombre.HeaderText = "Nombre completo";
            this.colNombre.MinimumWidth = 145;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 150;
            //
            // colIdentificacion
            //
            this.colIdentificacion.FillWeight = 17F;
            this.colIdentificacion.HeaderText = "Identificación";
            this.colIdentificacion.MinimumWidth = 130;
            this.colIdentificacion.Name = "colIdentificacion";
            this.colIdentificacion.ReadOnly = true;
            this.colIdentificacion.Width = 134;
            //
            // colTelefono
            //
            this.colTelefono.FillWeight = 12F;
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.MinimumWidth = 96;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 101;
            //
            // colUbicacionCargo
            //
            this.colUbicacionCargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUbicacionCargo.FillWeight = 24F;
            this.colUbicacionCargo.HeaderText = "Ubicación / cargo";
            this.colUbicacionCargo.MinimumWidth = 130;
            this.colUbicacionCargo.Name = "colUbicacionCargo";
            this.colUbicacionCargo.ReadOnly = true;
            //
            // colAccion
            //
            this.colAccion.FillWeight = 12F;
            this.colAccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAccion.HeaderText = "Acción";
            this.colAccion.MinimumWidth = 95;
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            this.colAccion.Text = "+ Seleccionar";
            this.colAccion.UseColumnTextForButtonValue = false;
            this.colAccion.Width = 99;
            //
            // pnlFooter
            //
            this.pnlFooter.Controls.Add(this.lblConteo);
            this.pnlFooter.Controls.Add(this.btnPaginacionAnt);
            this.pnlFooter.Controls.Add(this.lblPagina);
            this.pnlFooter.Controls.Add(this.btnPaginacionSig);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(16, 623);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlFooter.Size = new System.Drawing.Size(738, 38);
            this.pnlFooter.TabIndex = 3;
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConteo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblConteo.Location = new System.Drawing.Point(0, 10);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(182, 15);
            this.lblConteo.TabIndex = 0;
            this.lblConteo.Text = "Mostrando 0 de 0 perfiles sin usuario";
            //
            // btnPaginacionAnt
            //
            this.btnPaginacionAnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginacionAnt.BackColor = System.Drawing.Color.White;
            this.btnPaginacionAnt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnPaginacionAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginacionAnt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginacionAnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnPaginacionAnt.Location = new System.Drawing.Point(658, 4);
            this.btnPaginacionAnt.Name = "btnPaginacionAnt";
            this.btnPaginacionAnt.Size = new System.Drawing.Size(26, 26);
            this.btnPaginacionAnt.TabIndex = 1;
            this.btnPaginacionAnt.Text = "«";
            this.btnPaginacionAnt.UseVisualStyleBackColor = false;
            //
            // lblPagina
            //
            this.lblPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblPagina.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.White;
            this.lblPagina.Location = new System.Drawing.Point(688, 4);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(26, 26);
            this.lblPagina.TabIndex = 2;
            this.lblPagina.Text = "1";
            this.lblPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnPaginacionSig
            //
            this.btnPaginacionSig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginacionSig.BackColor = System.Drawing.Color.White;
            this.btnPaginacionSig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnPaginacionSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginacionSig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginacionSig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnPaginacionSig.Location = new System.Drawing.Point(718, 4);
            this.btnPaginacionSig.Name = "btnPaginacionSig";
            this.btnPaginacionSig.Size = new System.Drawing.Size(26, 26);
            this.btnPaginacionSig.TabIndex = 3;
            this.btnPaginacionSig.Text = "»";
            this.btnPaginacionSig.UseVisualStyleBackColor = false;
            //
            // pnlBarraFiltros
            //
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroTipo);
            this.pnlBarraFiltros.Controls.Add(this.cmbFiltroTipo);
            this.pnlBarraFiltros.Controls.Add(this.lblBuscar);
            this.pnlBarraFiltros.Controls.Add(this.pnlBuscarInput);
            this.pnlBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraFiltros.Location = new System.Drawing.Point(16, 76);
            this.pnlBarraFiltros.Name = "pnlBarraFiltros";
            this.pnlBarraFiltros.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.pnlBarraFiltros.Size = new System.Drawing.Size(738, 66);
            this.pnlBarraFiltros.TabIndex = 1;
            //
            // lblFiltroTipo
            //
            this.lblFiltroTipo.AutoSize = true;
            this.lblFiltroTipo.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblFiltroTipo.Location = new System.Drawing.Point(0, 6);
            this.lblFiltroTipo.Name = "lblFiltroTipo";
            this.lblFiltroTipo.Size = new System.Drawing.Size(81, 15);
            this.lblFiltroTipo.TabIndex = 0;
            this.lblFiltroTipo.Text = "Tipo de perfil";
            //
            // cmbFiltroTipo
            //
            this.cmbFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltroTipo.FormattingEnabled = true;
            this.cmbFiltroTipo.Location = new System.Drawing.Point(3, 26);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(250, 25);
            this.cmbFiltroTipo.TabIndex = 1;
            //
            // lblBuscar
            //
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblBuscar.Location = new System.Drawing.Point(270, 6);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(217, 15);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar por nombre, cédula o teléfono";
            //
            // pnlBuscarInput
            //
            this.pnlBuscarInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuscarInput.BackColor = System.Drawing.Color.White;
            this.pnlBuscarInput.Controls.Add(this.lblLupa);
            this.pnlBuscarInput.Controls.Add(this.txtBuscar);
            this.pnlBuscarInput.Controls.Add(this.btnLimpiarBusqueda);
            this.pnlBuscarInput.Location = new System.Drawing.Point(273, 25);
            this.pnlBuscarInput.Name = "pnlBuscarInput";
            this.pnlBuscarInput.Size = new System.Drawing.Size(465, 29);
            this.pnlBuscarInput.TabIndex = 3;
            //
            // lblLupa
            //
            this.lblLupa.AutoSize = true;
            this.lblLupa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLupa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLupa.Location = new System.Drawing.Point(6, 6);
            this.lblLupa.Name = "lblLupa";
            this.lblLupa.Size = new System.Drawing.Size(20, 17);
            this.lblLupa.TabIndex = 0;
            this.lblLupa.Text = "";
            //
            // txtBuscar
            //
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtBuscar.Location = new System.Drawing.Point(32, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(405, 17);
            this.txtBuscar.TabIndex = 1;
            //
            // btnLimpiarBusqueda
            //
            this.btnLimpiarBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(440, 2);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(22, 24);
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = false;
            this.btnLimpiarBusqueda.Visible = false;
            //
            // pnlHeaderIzquierdo
            //
            this.pnlHeaderIzquierdo.Controls.Add(this.pnlIconoHeader);
            this.pnlHeaderIzquierdo.Controls.Add(this.lblTitulo);
            this.pnlHeaderIzquierdo.Controls.Add(this.lblSubtitulo);
            this.pnlHeaderIzquierdo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderIzquierdo.Location = new System.Drawing.Point(16, 14);
            this.pnlHeaderIzquierdo.Name = "pnlHeaderIzquierdo";
            this.pnlHeaderIzquierdo.Size = new System.Drawing.Size(738, 62);
            this.pnlHeaderIzquierdo.TabIndex = 0;
            //
            // pnlIconoHeader
            //
            this.pnlIconoHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.pnlIconoHeader.Controls.Add(this.lblIconoHeader);
            this.pnlIconoHeader.Location = new System.Drawing.Point(2, 6);
            this.pnlIconoHeader.Name = "pnlIconoHeader";
            this.pnlIconoHeader.Size = new System.Drawing.Size(46, 46);
            this.pnlIconoHeader.TabIndex = 0;
            //
            // lblIconoHeader
            //
            this.lblIconoHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconoHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblIconoHeader.Location = new System.Drawing.Point(0, 0);
            this.lblIconoHeader.Name = "lblIconoHeader";
            this.lblIconoHeader.Size = new System.Drawing.Size(46, 46);
            this.lblIconoHeader.TabIndex = 0;
            this.lblIconoHeader.Text = "";
            this.lblIconoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblTitulo.Location = new System.Drawing.Point(58, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(252, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Asignar acceso a perfil";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(60, 36);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(342, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Selecciona una persona sin cuenta para crear sus credenciales.";
            //
            // pnlDerecho
            //
            this.pnlDerecho.BackColor = System.Drawing.Color.Transparent;
            this.pnlDerecho.Controls.Add(this.cardPerfil);
            this.pnlDerecho.Controls.Add(this.panelBannerRol);
            this.pnlDerecho.Controls.Add(this.cardCredenciales);
            this.pnlDerecho.Location = new System.Drawing.Point(798, 14);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(340, 673);
            this.pnlDerecho.TabIndex = 1;
            //
            // cardPerfil
            //
            this.cardPerfil.BackColor = System.Drawing.Color.White;
            this.cardPerfil.Controls.Add(this.pnlDetallePerfil);
            this.cardPerfil.Controls.Add(this.pnlHeaderCardPerfil);
            this.cardPerfil.Location = new System.Drawing.Point(0, 0);
            this.cardPerfil.Name = "cardPerfil";
            this.cardPerfil.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.cardPerfil.Size = new System.Drawing.Size(340, 160);
            this.cardPerfil.TabIndex = 0;
            //
            // pnlHeaderCardPerfil
            //
            this.pnlHeaderCardPerfil.Controls.Add(this.badgePerfil);
            this.pnlHeaderCardPerfil.Controls.Add(this.lblTituloCardPerfil);
            this.pnlHeaderCardPerfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderCardPerfil.Location = new System.Drawing.Point(16, 10);
            this.pnlHeaderCardPerfil.Name = "pnlHeaderCardPerfil";
            this.pnlHeaderCardPerfil.Size = new System.Drawing.Size(308, 30);
            this.pnlHeaderCardPerfil.TabIndex = 0;
            //
            // badgePerfil
            //
            this.badgePerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.badgePerfil.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.badgePerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.badgePerfil.Location = new System.Drawing.Point(2, 2);
            this.badgePerfil.Name = "badgePerfil";
            this.badgePerfil.Size = new System.Drawing.Size(26, 26);
            this.badgePerfil.TabIndex = 0;
            this.badgePerfil.Text = "";
            this.badgePerfil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloCardPerfil
            //
            this.lblTituloCardPerfil.AutoSize = true;
            this.lblTituloCardPerfil.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCardPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblTituloCardPerfil.Location = new System.Drawing.Point(34, 4);
            this.lblTituloCardPerfil.Name = "lblTituloCardPerfil";
            this.lblTituloCardPerfil.Size = new System.Drawing.Size(142, 20);
            this.lblTituloCardPerfil.TabIndex = 1;
            this.lblTituloCardPerfil.Text = "Perfil seleccionado";
            //
            // pnlDetallePerfil
            //
            this.pnlDetallePerfil.Controls.Add(this.lblSinSeleccion);
            this.pnlDetallePerfil.Controls.Add(this.lblIconoTipoGrande);
            this.pnlDetallePerfil.Controls.Add(this.lblNombrePerfil);
            this.pnlDetallePerfil.Controls.Add(this.lblTipoPerfil);
            this.pnlDetallePerfil.Controls.Add(this.lblIdentificacionPerfil);
            this.pnlDetallePerfil.Controls.Add(this.lblTelefonoPerfil);
            this.pnlDetallePerfil.Controls.Add(this.lblUbicacionPerfil);
            this.pnlDetallePerfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetallePerfil.Location = new System.Drawing.Point(16, 40);
            this.pnlDetallePerfil.Name = "pnlDetallePerfil";
            this.pnlDetallePerfil.Size = new System.Drawing.Size(308, 110);
            this.pnlDetallePerfil.TabIndex = 1;
            //
            // lblSinSeleccion
            //
            this.lblSinSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinSeleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSinSeleccion.Location = new System.Drawing.Point(8, 8);
            this.lblSinSeleccion.Name = "lblSinSeleccion";
            this.lblSinSeleccion.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblSinSeleccion.Size = new System.Drawing.Size(292, 85);
            this.lblSinSeleccion.TabIndex = 0;
            this.lblSinSeleccion.Text = "Selecciona una persona de la tabla para ver sus detalles y habilitar la creación de credenciales.";
            this.lblSinSeleccion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // lblIconoTipoGrande
            //
            this.lblIconoTipoGrande.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoTipoGrande.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblIconoTipoGrande.Location = new System.Drawing.Point(2, 4);
            this.lblIconoTipoGrande.Name = "lblIconoTipoGrande";
            this.lblIconoTipoGrande.Size = new System.Drawing.Size(42, 42);
            this.lblIconoTipoGrande.TabIndex = 1;
            this.lblIconoTipoGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIconoTipoGrande.Visible = false;
            //
            // lblNombrePerfil
            //
            this.lblNombrePerfil.AutoEllipsis = false;
            this.lblNombrePerfil.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblNombrePerfil.Location = new System.Drawing.Point(48, 0);
            this.lblNombrePerfil.Name = "lblNombrePerfil";
            this.lblNombrePerfil.Size = new System.Drawing.Size(255, 32);
            this.lblNombrePerfil.TabIndex = 2;
            this.lblNombrePerfil.Text = "Nombre Completo";
            this.lblNombrePerfil.Visible = false;
            //
            // lblTipoPerfil
            //
            this.lblTipoPerfil.AutoSize = true;
            this.lblTipoPerfil.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTipoPerfil.Location = new System.Drawing.Point(48, 34);
            this.lblTipoPerfil.Name = "lblTipoPerfil";
            this.lblTipoPerfil.Size = new System.Drawing.Size(117, 15);
            this.lblTipoPerfil.TabIndex = 3;
            this.lblTipoPerfil.Text = "Tipo de perfil: Doctor";
            this.lblTipoPerfil.Visible = false;
            //
            // lblIdentificacionPerfil
            //
            this.lblIdentificacionPerfil.AutoSize = true;
            this.lblIdentificacionPerfil.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificacionPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblIdentificacionPerfil.Location = new System.Drawing.Point(48, 50);
            this.lblIdentificacionPerfil.Name = "lblIdentificacionPerfil";
            this.lblIdentificacionPerfil.Size = new System.Drawing.Size(161, 15);
            this.lblIdentificacionPerfil.TabIndex = 4;
            this.lblIdentificacionPerfil.Text = "Identificación: DEMO-DOC-002";
            this.lblIdentificacionPerfil.Visible = false;
            //
            // lblTelefonoPerfil
            //
            this.lblTelefonoPerfil.AutoSize = true;
            this.lblTelefonoPerfil.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTelefonoPerfil.Location = new System.Drawing.Point(48, 66);
            this.lblTelefonoPerfil.Name = "lblTelefonoPerfil";
            this.lblTelefonoPerfil.Size = new System.Drawing.Size(114, 15);
            this.lblTelefonoPerfil.TabIndex = 5;
            this.lblTelefonoPerfil.Text = "Teléfono: 8888-2244";
            this.lblTelefonoPerfil.Visible = false;
            //
            // lblUbicacionPerfil
            //
            this.lblUbicacionPerfil.AutoEllipsis = false;
            this.lblUbicacionPerfil.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacionPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblUbicacionPerfil.Location = new System.Drawing.Point(48, 82);
            this.lblUbicacionPerfil.Name = "lblUbicacionPerfil";
            this.lblUbicacionPerfil.Size = new System.Drawing.Size(255, 30);
            this.lblUbicacionPerfil.TabIndex = 6;
            this.lblUbicacionPerfil.Text = "Ubicación: Hospital Primario Tisma";
            this.lblUbicacionPerfil.Visible = false;
            //
            // panelBannerRol
            //
            this.panelBannerRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.panelBannerRol.Controls.Add(this.lblIconoInfoBanner);
            this.panelBannerRol.Controls.Add(this.lblTextoInfoBanner);
            this.panelBannerRol.Location = new System.Drawing.Point(0, 170);
            this.panelBannerRol.Name = "panelBannerRol";
            this.panelBannerRol.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.panelBannerRol.Size = new System.Drawing.Size(340, 42);
            this.panelBannerRol.TabIndex = 2;
            //
            // lblIconoInfoBanner
            //
            this.lblIconoInfoBanner.AutoSize = true;
            this.lblIconoInfoBanner.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoInfoBanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblIconoInfoBanner.Location = new System.Drawing.Point(8, 9);
            this.lblIconoInfoBanner.Name = "lblIconoInfoBanner";
            this.lblIconoInfoBanner.Size = new System.Drawing.Size(24, 21);
            this.lblIconoInfoBanner.TabIndex = 0;
            this.lblIconoInfoBanner.Text = "ⓘ";
            //
            // lblTextoInfoBanner
            //
            this.lblTextoInfoBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextoInfoBanner.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoInfoBanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblTextoInfoBanner.Location = new System.Drawing.Point(34, 4);
            this.lblTextoInfoBanner.Name = "lblTextoInfoBanner";
            this.lblTextoInfoBanner.Size = new System.Drawing.Size(296, 34);
            this.lblTextoInfoBanner.TabIndex = 1;
            this.lblTextoInfoBanner.Text = "El rol se asignará automáticamente según el perfil. No se puede elegir un rol dif" +
    "erente.";
            //
            // cardCredenciales
            //
            this.cardCredenciales.BackColor = System.Drawing.Color.White;
            this.cardCredenciales.Controls.Add(this.pnlHeaderCardCredenciales);
            this.cardCredenciales.Controls.Add(this.lblNombreUsuario);
            this.cardCredenciales.Controls.Add(this.txtNombreUsuario);
            this.cardCredenciales.Controls.Add(this.lblErrorUsuario);
            this.cardCredenciales.Controls.Add(this.lblContrasena);
            this.cardCredenciales.Controls.Add(this.pnlContrasena);
            this.cardCredenciales.Controls.Add(this.lblAyudaContrasena);
            this.cardCredenciales.Controls.Add(this.lblConfirmarContrasena);
            this.cardCredenciales.Controls.Add(this.pnlConfirmarContrasena);
            this.cardCredenciales.Controls.Add(this.lblErrorConfirmar);
            this.cardCredenciales.Controls.Add(this.pnlBotonesAccion);
            this.cardCredenciales.Location = new System.Drawing.Point(0, 222);
            this.cardCredenciales.Name = "cardCredenciales";
            this.cardCredenciales.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.cardCredenciales.Size = new System.Drawing.Size(340, 390);
            this.cardCredenciales.TabIndex = 1;
            //
            // pnlHeaderCardCredenciales
            //
            this.pnlHeaderCardCredenciales.Controls.Add(this.badgeCredenciales);
            this.pnlHeaderCardCredenciales.Controls.Add(this.lblTituloCardCredenciales);
            this.pnlHeaderCardCredenciales.Controls.Add(this.lblSubtituloCredenciales);
            this.pnlHeaderCardCredenciales.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderCardCredenciales.Location = new System.Drawing.Point(16, 12);
            this.pnlHeaderCardCredenciales.Name = "pnlHeaderCardCredenciales";
            this.pnlHeaderCardCredenciales.Size = new System.Drawing.Size(308, 44);
            this.pnlHeaderCardCredenciales.TabIndex = 0;
            //
            // badgeCredenciales
            //
            this.badgeCredenciales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.badgeCredenciales.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.badgeCredenciales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.badgeCredenciales.Location = new System.Drawing.Point(2, 2);
            this.badgeCredenciales.Name = "badgeCredenciales";
            this.badgeCredenciales.Size = new System.Drawing.Size(26, 26);
            this.badgeCredenciales.TabIndex = 0;
            this.badgeCredenciales.Text = "";
            this.badgeCredenciales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloCardCredenciales
            //
            this.lblTituloCardCredenciales.AutoSize = true;
            this.lblTituloCardCredenciales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCardCredenciales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblTituloCardCredenciales.Location = new System.Drawing.Point(34, 2);
            this.lblTituloCardCredenciales.Name = "lblTituloCardCredenciales";
            this.lblTituloCardCredenciales.Size = new System.Drawing.Size(135, 20);
            this.lblTituloCardCredenciales.TabIndex = 1;
            this.lblTituloCardCredenciales.Text = "Crear credenciales";
            //
            // lblSubtituloCredenciales
            //
            this.lblSubtituloCredenciales.AutoSize = true;
            this.lblSubtituloCredenciales.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtituloCredenciales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtituloCredenciales.Location = new System.Drawing.Point(34, 24);
            this.lblSubtituloCredenciales.Name = "lblSubtituloCredenciales";
            this.lblSubtituloCredenciales.Size = new System.Drawing.Size(227, 15);
            this.lblSubtituloCredenciales.TabIndex = 2;
            this.lblSubtituloCredenciales.Text = "El acceso quedará vinculado a este perfil.";
            //
            // lblNombreUsuario
            //
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNombreUsuario.Location = new System.Drawing.Point(16, 58);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(125, 15);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre de usuario *";
            //
            // txtNombreUsuario
            //
            this.txtNombreUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreUsuario.Enabled = false;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNombreUsuario.Location = new System.Drawing.Point(16, 76);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(308, 24);
            this.txtNombreUsuario.TabIndex = 2;
            //
            // lblErrorUsuario
            //
            this.lblErrorUsuario.AutoSize = true;
            this.lblErrorUsuario.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblErrorUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblErrorUsuario.Location = new System.Drawing.Point(16, 102);
            this.lblErrorUsuario.Name = "lblErrorUsuario";
            this.lblErrorUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblErrorUsuario.TabIndex = 3;
            //
            // lblContrasena
            //
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblContrasena.Location = new System.Drawing.Point(16, 116);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(80, 15);
            this.lblContrasena.TabIndex = 4;
            this.lblContrasena.Text = "Contraseña *";
            //
            // pnlContrasena
            //
            this.pnlContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContrasena.Controls.Add(this.txtContrasena);
            this.pnlContrasena.Controls.Add(this.btnVerContrasena);
            this.pnlContrasena.Location = new System.Drawing.Point(16, 134);
            this.pnlContrasena.Name = "pnlContrasena";
            this.pnlContrasena.Size = new System.Drawing.Size(308, 26);
            this.pnlContrasena.TabIndex = 5;
            //
            // txtContrasena
            //
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContrasena.Enabled = false;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtContrasena.Location = new System.Drawing.Point(0, 0);
            this.txtContrasena.MaxLength = 100;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(280, 17);
            this.txtContrasena.TabIndex = 0;
            //
            // btnVerContrasena
            //
            this.btnVerContrasena.BackColor = System.Drawing.Color.White;
            this.btnVerContrasena.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVerContrasena.FlatAppearance.BorderSize = 0;
            this.btnVerContrasena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerContrasena.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnVerContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnVerContrasena.Location = new System.Drawing.Point(280, 0);
            this.btnVerContrasena.Name = "btnVerContrasena";
            this.btnVerContrasena.Size = new System.Drawing.Size(26, 24);
            this.btnVerContrasena.TabIndex = 1;
            this.btnVerContrasena.Text = "";
            this.btnVerContrasena.UseVisualStyleBackColor = false;
            //
            // lblAyudaContrasena
            //
            this.lblAyudaContrasena.AutoSize = true;
            this.lblAyudaContrasena.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAyudaContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAyudaContrasena.Location = new System.Drawing.Point(16, 162);
            this.lblAyudaContrasena.Name = "lblAyudaContrasena";
            this.lblAyudaContrasena.Size = new System.Drawing.Size(214, 13);
            this.lblAyudaContrasena.TabIndex = 6;
            this.lblAyudaContrasena.Text = "La contraseña debe tener al menos 6 caracteres.";
            //
            // lblConfirmarContrasena
            //
            this.lblConfirmarContrasena.AutoSize = true;
            this.lblConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblConfirmarContrasena.Location = new System.Drawing.Point(16, 178);
            this.lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            this.lblConfirmarContrasena.Size = new System.Drawing.Size(139, 15);
            this.lblConfirmarContrasena.TabIndex = 7;
            this.lblConfirmarContrasena.Text = "Confirmar contraseña *";
            //
            // pnlConfirmarContrasena
            //
            this.pnlConfirmarContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConfirmarContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfirmarContrasena.Controls.Add(this.txtConfirmarContrasena);
            this.pnlConfirmarContrasena.Controls.Add(this.btnVerConfirmar);
            this.pnlConfirmarContrasena.Location = new System.Drawing.Point(16, 196);
            this.pnlConfirmarContrasena.Name = "pnlConfirmarContrasena";
            this.pnlConfirmarContrasena.Size = new System.Drawing.Size(308, 26);
            this.pnlConfirmarContrasena.TabIndex = 8;
            //
            // txtConfirmarContrasena
            //
            this.txtConfirmarContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmarContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmarContrasena.Enabled = false;
            this.txtConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConfirmarContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(0, 0);
            this.txtConfirmarContrasena.MaxLength = 100;
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '●';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(280, 17);
            this.txtConfirmarContrasena.TabIndex = 0;
            //
            // btnVerConfirmar
            //
            this.btnVerConfirmar.BackColor = System.Drawing.Color.White;
            this.btnVerConfirmar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVerConfirmar.FlatAppearance.BorderSize = 0;
            this.btnVerConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerConfirmar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnVerConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnVerConfirmar.Location = new System.Drawing.Point(280, 0);
            this.btnVerConfirmar.Name = "btnVerConfirmar";
            this.btnVerConfirmar.Size = new System.Drawing.Size(26, 24);
            this.btnVerConfirmar.TabIndex = 1;
            this.btnVerConfirmar.Text = "";
            this.btnVerConfirmar.UseVisualStyleBackColor = false;
            //
            // lblErrorConfirmar
            //
            this.lblErrorConfirmar.AutoSize = true;
            this.lblErrorConfirmar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblErrorConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblErrorConfirmar.Location = new System.Drawing.Point(16, 224);
            this.lblErrorConfirmar.Name = "lblErrorConfirmar";
            this.lblErrorConfirmar.Size = new System.Drawing.Size(0, 13);
            this.lblErrorConfirmar.TabIndex = 9;
            //
            // pnlBotonesAccion
            //
            this.pnlBotonesAccion.Controls.Add(this.btnCancelar);
            this.pnlBotonesAccion.Controls.Add(this.btnCrearAcceso);
            this.pnlBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotonesAccion.Location = new System.Drawing.Point(16, 344);
            this.pnlBotonesAccion.Name = "pnlBotonesAccion";
            this.pnlBotonesAccion.Size = new System.Drawing.Size(308, 44);
            this.pnlBotonesAccion.TabIndex = 10;
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnCancelar.Location = new System.Drawing.Point(0, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "✕  Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnCrearAcceso
            //
            this.btnCrearAcceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.btnCrearAcceso.Enabled = false;
            this.btnCrearAcceso.FlatAppearance.BorderSize = 0;
            this.btnCrearAcceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearAcceso.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrearAcceso.ForeColor = System.Drawing.Color.White;
            this.btnCrearAcceso.Location = new System.Drawing.Point(152, 4);
            this.btnCrearAcceso.Name = "btnCrearAcceso";
            this.btnCrearAcceso.Size = new System.Drawing.Size(156, 36);
            this.btnCrearAcceso.TabIndex = 1;
            this.btnCrearAcceso.Text = "       Crear acceso";
            this.btnCrearAcceso.UseVisualStyleBackColor = false;
            //
            // asignarAccesoPerfil
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1264, 701);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(950, 480);
            this.Name = "asignarAccesoPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Asignación de accesos";
            this.pnlMain.ResumeLayout(false);
            this.pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBarraFiltros.ResumeLayout(false);
            this.pnlBarraFiltros.PerformLayout();
            this.pnlBuscarInput.ResumeLayout(false);
            this.pnlBuscarInput.PerformLayout();
            this.pnlHeaderIzquierdo.ResumeLayout(false);
            this.pnlHeaderIzquierdo.PerformLayout();
            this.pnlIconoHeader.ResumeLayout(false);
            this.pnlDerecho.ResumeLayout(false);
            this.cardPerfil.ResumeLayout(false);
            this.pnlHeaderCardPerfil.ResumeLayout(false);
            this.pnlHeaderCardPerfil.PerformLayout();
            this.pnlDetallePerfil.ResumeLayout(false);
            this.pnlDetallePerfil.PerformLayout();
            this.panelBannerRol.ResumeLayout(false);
            this.panelBannerRol.PerformLayout();
            this.cardCredenciales.ResumeLayout(false);
            this.cardCredenciales.PerformLayout();
            this.pnlHeaderCardCredenciales.ResumeLayout(false);
            this.pnlHeaderCardCredenciales.PerformLayout();
            this.pnlContrasena.ResumeLayout(false);
            this.pnlContrasena.PerformLayout();
            this.pnlConfirmarContrasena.ResumeLayout(false);
            this.pnlConfirmarContrasena.PerformLayout();
            this.pnlBotonesAccion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Panel pnlHeaderIzquierdo;
        private System.Windows.Forms.Panel pnlIconoHeader;
        private System.Windows.Forms.Label lblIconoHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlBarraFiltros;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.ComboBox cmbFiltroTipo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel pnlBuscarInput;
        private System.Windows.Forms.Label lblLupa;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.DataGridView dgvPerfiles;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Button btnPaginacionAnt;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnPaginacionSig;
        private System.Windows.Forms.Panel cardPerfil;
        private System.Windows.Forms.Panel pnlHeaderCardPerfil;
        private System.Windows.Forms.Label badgePerfil;
        private System.Windows.Forms.Label lblTituloCardPerfil;
        private System.Windows.Forms.Panel pnlDetallePerfil;
        private System.Windows.Forms.Label lblSinSeleccion;
        private System.Windows.Forms.Label lblIconoTipoGrande;
        private System.Windows.Forms.Label lblNombrePerfil;
        private System.Windows.Forms.Label lblTipoPerfil;
        private System.Windows.Forms.Label lblIdentificacionPerfil;
        private System.Windows.Forms.Label lblTelefonoPerfil;
        private System.Windows.Forms.Label lblUbicacionPerfil;
        private System.Windows.Forms.Panel panelBannerRol;
        private System.Windows.Forms.Label lblIconoInfoBanner;
        private System.Windows.Forms.Label lblTextoInfoBanner;
        private System.Windows.Forms.Panel cardCredenciales;
        private System.Windows.Forms.Panel pnlHeaderCardCredenciales;
        private System.Windows.Forms.Label badgeCredenciales;
        private System.Windows.Forms.Label lblTituloCardCredenciales;
        private System.Windows.Forms.Label lblSubtituloCredenciales;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblErrorUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Panel pnlContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnVerContrasena;
        private System.Windows.Forms.Label lblAyudaContrasena;
        private System.Windows.Forms.Label lblConfirmarContrasena;
        private System.Windows.Forms.Panel pnlConfirmarContrasena;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Button btnVerConfirmar;
        private System.Windows.Forms.Label lblErrorConfirmar;
        private System.Windows.Forms.Panel pnlBotonesAccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCrearAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacionCargo;
        private System.Windows.Forms.DataGridViewButtonColumn colAccion;
    }
}
