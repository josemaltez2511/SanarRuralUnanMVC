using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    partial class paginaPrincipalHospitales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvHospitales = new System.Windows.Forms.DataGridView();
            this.colIdHospital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitales)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(215, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Módulo Hospitales";
            //
            // lblBuscar
            //
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = Tema.FuenteLabelCampo;
            this.lblBuscar.ForeColor = Tema.TextoPrincipal;
            this.lblBuscar.Location = new System.Drawing.Point(40, 92);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 17);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar";
            //
            // txtBuscar
            //
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Location = new System.Drawing.Point(40, 114);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(650, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // btnNuevo
            //
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = Tema.Superficie;
            this.btnNuevo.Location = new System.Drawing.Point(850, 105);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(180, 40);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo Hospital";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // dgvHospitales
            //
            this.dgvHospitales.AllowUserToAddRows = false;
            this.dgvHospitales.AllowUserToDeleteRows = false;
            this.dgvHospitales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHospitales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHospitales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdHospital,
            this.colNombre,
            this.colDepartamento,
            this.colMunicipio,
            this.colDireccion,
            this.colTelefono,
            this.colEditar,
            this.colBaja});
            this.dgvHospitales.MultiSelect = false;
            this.dgvHospitales.Name = "dgvHospitales";
            this.dgvHospitales.ReadOnly = true;
            this.dgvHospitales.RowHeadersVisible = false;
            this.dgvHospitales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospitales.TabIndex = 3;
            this.dgvHospitales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospitales_CellContentClick);
            //
            // colIdHospital
            //
            this.colIdHospital.HeaderText = "IdHospital";
            this.colIdHospital.Name = "IdHospital";
            this.colIdHospital.ReadOnly = true;
            this.colIdHospital.Visible = false;
            //
            // colNombre
            //
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "Nombre";
            this.colNombre.ReadOnly = true;
            //
            // colDepartamento
            //
            this.colDepartamento.HeaderText = "Departamento";
            this.colDepartamento.Name = "Departamento";
            this.colDepartamento.ReadOnly = true;
            //
            // colMunicipio
            //
            this.colMunicipio.HeaderText = "Municipio";
            this.colMunicipio.Name = "Municipio";
            this.colMunicipio.ReadOnly = true;
            //
            // colDireccion
            //
            this.colDireccion.HeaderText = "Dirección";
            this.colDireccion.Name = "Direccion";
            this.colDireccion.ReadOnly = true;
            //
            // colTelefono
            //
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "Telefono";
            this.colTelefono.ReadOnly = true;
            //
            // colEditar
            //
            this.colEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            //
            // colBaja
            //
            this.colBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBaja.HeaderText = "Dar de baja";
            this.colBaja.Name = "colBaja";
            this.colBaja.ReadOnly = true;
            this.colBaja.Text = "Dar de baja";
            this.colBaja.UseColumnTextForButtonValue = true;
            //
            // paginaPrincipalHospitales
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.FondoVentana;
            this.ClientSize = new System.Drawing.Size(1160, 680);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 150;
            this.panelEncabezado.BackColor = Tema.Fondo;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblBuscar);
            this.panelEncabezado.Controls.Add(this.txtBuscar);
            this.panelEncabezado.Controls.Add(this.btnNuevo);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Padding = new System.Windows.Forms.Padding(40, 0, 40, 24);
            this.panelTabla.BackColor = Tema.Fondo;
            this.panelTabla.Controls.Add(this.dgvHospitales);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelEncabezado);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "paginaPrincipalHospitales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Hospitales";
            this.Load += new System.EventHandler(this.paginaPrincipalHospitales_Load);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvHospitales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdHospital;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMunicipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colBaja;
    }
}
