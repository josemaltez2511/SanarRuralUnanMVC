using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Enfermedades
{
    partial class paginaPrincipalEnfermedades
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTarjeta;
        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNuevaEnfermedad;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private DataGridView tabla;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewButtonColumn colDetalle;
        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn colBaja;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTarjeta = new System.Windows.Forms.Panel();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnNuevaEnfermedad = new System.Windows.Forms.Button();
            this.panelTarjeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.panelBusqueda.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTarjeta
            //
            this.panelTarjeta.BackColor = Tema.Superficie;
            this.panelTarjeta.Controls.Add(this.tabla);
            this.panelTarjeta.Controls.Add(this.panelBusqueda);
            this.panelTarjeta.Controls.Add(this.panelEncabezado);
            this.panelTarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTarjeta.Location = new System.Drawing.Point(0, 0);
            this.panelTarjeta.Name = "panelTarjeta";
            this.panelTarjeta.Padding = new System.Windows.Forms.Padding(24);
            this.panelTarjeta.Size = new System.Drawing.Size(929, 556);
            this.panelTarjeta.TabIndex = 0;
            //
            // tabla
            //
            this.tabla.AccessibleDescription = "Listado de enfermedades activas y acciones disponibles.";
            this.tabla.AccessibleName = "Listado de enfermedades activas";
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.AutoGenerateColumns = false;
            this.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabla.BackgroundColor = Tema.Superficie;
            this.tabla.ColumnHeadersHeight = 42;
            this.tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colCategoria,
            this.colDescripcion,
            this.colDetalle,
            this.colEditar,
            this.colBaja});
            this.tabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabla.Location = new System.Drawing.Point(21, 130);
            this.tabla.Name = "tabla";
            this.tabla.ReadOnly = true;
            this.tabla.RowHeadersVisible = false;
            this.tabla.RowTemplate.Height = 44;
            this.tabla.Size = new System.Drawing.Size(887, 405);
            this.tabla.TabIndex = 2;
            this.tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellContentClick);
            //
            // colId
            //
            this.colId.DataPropertyName = "IdEnfermedad";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            //
            // colNombre
            //
            this.colNombre.DataPropertyName = "NombreEnfermedad";
            this.colNombre.FillWeight = 25F;
            this.colNombre.HeaderText = "Enfermedad";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            //
            // colCategoria
            //
            this.colCategoria.DataPropertyName = "Categoria";
            this.colCategoria.FillWeight = 17F;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            //
            // colDescripcion
            //
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.FillWeight = 35F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            //
            // colDetalle
            //
            this.colDetalle.FillWeight = 11F;
            this.colDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDetalle.HeaderText = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.ReadOnly = true;
            this.colDetalle.Text = "Ver detalle";
            this.colDetalle.UseColumnTextForButtonValue = true;
            //
            // colEditar
            //
            this.colEditar.FillWeight = 10F;
            this.colEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            //
            // colBaja
            //
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Tema.BotonPeligroFondo;
            dataGridViewCellStyle1.ForeColor = Tema.Error;
            this.colBaja.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBaja.FillWeight = 12F;
            this.colBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBaja.HeaderText = "Acción";
            this.colBaja.Name = "colBaja";
            this.colBaja.ReadOnly = true;
            this.colBaja.Text = "Dar de baja";
            this.colBaja.UseColumnTextForButtonValue = true;
            //
            // panelBusqueda
            //
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusqueda.Location = new System.Drawing.Point(21, 83);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Padding = new System.Windows.Forms.Padding(0, 5, 0, 7);
            this.panelBusqueda.Size = new System.Drawing.Size(887, 47);
            this.panelBusqueda.TabIndex = 1;
            //
            // txtBuscar
            //
            this.txtBuscar.AccessibleDescription = "Filtra por nombre, categoría o descripción.";
            this.txtBuscar.AccessibleName = "Buscar enfermedades";
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.Location = new System.Drawing.Point(0, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(361, 27);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // panelEncabezado
            //
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Controls.Add(this.btnNuevaEnfermedad);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(21, 21);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(887, 62);
            this.panelEncabezado.TabIndex = 0;
            this.panelEncabezado.Resize += new System.EventHandler(this.panelEncabezado_Resize);
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(218, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Enfermedades";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(2, 36);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(283, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Catálogo de enfermedades registradas en el sistema.";
            //
            // btnNuevaEnfermedad
            //
            this.btnNuevaEnfermedad.AccessibleDescription = "Abre el formulario para agregar una enfermedad al catálogo.";
            this.btnNuevaEnfermedad.AccessibleName = "Registrar una enfermedad";
            this.btnNuevaEnfermedad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaEnfermedad.BackColor = Tema.AzulPrimario;
            this.btnNuevaEnfermedad.FlatAppearance.BorderSize = 0;
            this.btnNuevaEnfermedad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaEnfermedad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevaEnfermedad.ForeColor = Tema.Superficie;
            this.btnNuevaEnfermedad.Location = new System.Drawing.Point(709, 8);
            this.btnNuevaEnfermedad.Name = "btnNuevaEnfermedad";
            this.btnNuevaEnfermedad.Size = new System.Drawing.Size(154, 36);
            this.btnNuevaEnfermedad.TabIndex = 2;
            this.btnNuevaEnfermedad.Text = "+ Nueva enfermedad";
            this.btnNuevaEnfermedad.UseVisualStyleBackColor = false;
            this.btnNuevaEnfermedad.Click += new System.EventHandler(this.btnNuevaEnfermedad_Click);
            //
            // paginaPrincipalEnfermedades
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(929, 556);
            this.Controls.Add(this.panelTarjeta);
            this.MinimumSize = new System.Drawing.Size(654, 421);
            this.Name = "paginaPrincipalEnfermedades";
            this.Text = "Enfermedades";
            this.panelTarjeta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
