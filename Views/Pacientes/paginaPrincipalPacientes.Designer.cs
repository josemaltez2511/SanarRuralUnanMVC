using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Pacientes
{
    partial class paginaPrincipalPacientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelResumen = new System.Windows.Forms.Panel();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblResumenAyuda = new System.Windows.Forms.Label();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.colIdPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComunidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelEncabezado.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.panelResumen.SuspendLayout();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();

            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 94;
            this.panelEncabezado.BackColor = Tema.Fondo;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(4, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Pacientes";
            this.lblTitulo.AccessibleName = "Sección Pacientes";
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(6, 55);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Consulta y administra los pacientes registrados.";

            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusqueda.Height = 76;
            this.panelBusqueda.BackColor = Tema.Fondo;
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.btnNuevo);
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = Tema.FuenteLabelCampo;
            this.lblBuscar.ForeColor = Tema.TextoPrincipal;
            this.lblBuscar.Location = new System.Drawing.Point(6, 2);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar por nombre o cédula";
            this.lblBuscar.AccessibleName = "Buscar pacientes";
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.BackColor = Tema.Superficie;
            this.txtBuscar.ForeColor = Tema.TextoPrincipal;
            this.txtBuscar.Location = new System.Drawing.Point(8, 29);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(680, Tema.AltoCampo);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.AccessibleName = "Buscar pacientes por nombre o cédula";
            this.txtBuscar.AccessibleDescription = "Escriba un nombre o número de cédula para filtrar la lista.";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = Tema.Superficie;
            this.btnNuevo.Location = new System.Drawing.Point(826, 25);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(188, Tema.AltoBoton);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "+  Nuevo paciente";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.AccessibleName = "Registrar paciente";
            this.btnNuevo.AccessibleDescription = "Abre el formulario para registrar un nuevo paciente.";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.panelResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResumen.Height = 68;
            this.panelResumen.BackColor = Tema.Superficie;
            this.panelResumen.Padding = new System.Windows.Forms.Padding(0, 6, 0, 10);
            this.panelResumen.Controls.Add(this.lblCantidad);
            this.panelResumen.Controls.Add(this.lblResumenAyuda);
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = Tema.FuenteLabelCampo;
            this.lblCantidad.ForeColor = Tema.VerdeOscuro;
            this.lblCantidad.Location = new System.Drawing.Point(8, 8);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cargando pacientes...";
            this.lblCantidad.AccessibleName = "Cantidad de pacientes activos";
            this.lblResumenAyuda.AutoSize = true;
            this.lblResumenAyuda.Font = Tema.FuenteAyuda;
            this.lblResumenAyuda.ForeColor = Tema.TextoSecundario;
            this.lblResumenAyuda.Location = new System.Drawing.Point(8, 34);
            this.lblResumenAyuda.Name = "lblResumenAyuda";
            this.lblResumenAyuda.Text = "Los registros inactivos no aparecen en este listado.";

            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.BackColor = Tema.Superficie;
            this.panelTabla.Padding = new System.Windows.Forms.Padding(1);
            this.panelTabla.Controls.Add(this.dgvPacientes);
            this.dgvPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colIdPaciente, this.colNombre, this.colCedula, this.colTelefono,
                this.colComunidad, this.colMunicipio, this.colDepartamento, this.colEstado,
                this.colEditar, this.colBaja});
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.TabIndex = 2;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            this.dgvPacientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPacientes_CellFormatting);
            this.colIdPaciente.HeaderText = "IdPaciente";
            this.colIdPaciente.Name = "IdPaciente";
            this.colIdPaciente.Visible = false;
            this.colNombre.HeaderText = "Nombre completo";
            this.colNombre.Name = "Nombre";
            this.colCedula.HeaderText = "Cédula";
            this.colCedula.Name = "Cedula";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "Telefono";
            this.colComunidad.HeaderText = "Comunidad";
            this.colComunidad.Name = "Comunidad";
            this.colMunicipio.HeaderText = "Municipio";
            this.colMunicipio.Name = "Municipio";
            this.colDepartamento.HeaderText = "Departamento";
            this.colDepartamento.Name = "Departamento";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colBaja.HeaderText = "Baja";
            this.colBaja.Name = "colBaja";
            this.colBaja.Text = "Dar de baja";
            this.colBaja.UseColumnTextForButtonValue = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1040, 680);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelResumen);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.panelEncabezado);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "paginaPrincipalPacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Pacientes";
            this.Load += new System.EventHandler(this.paginaPrincipalPacientes_Load);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelResumen.ResumeLayout(false);
            this.panelResumen.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panelResumen;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblResumenAyuda;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComunidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMunicipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colBaja;
    }
}
