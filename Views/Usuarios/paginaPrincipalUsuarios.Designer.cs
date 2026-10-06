using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class paginaPrincipalUsuarios
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
            this.panelTabla = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBaja = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(28, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(242, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Administrar usuarios";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = Tema.FuenteLabelCampo;
            this.lblBuscar.ForeColor = Tema.TextoPrincipal;
            this.lblBuscar.Location = new System.Drawing.Point(32, 91);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(138, 19);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar correo o rol:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = Tema.FuenteInput;
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Location = new System.Drawing.Point(177, 88);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(510, Tema.AltoCampo);
            this.txtBuscar.AccessibleName = "Buscar usuarios por correo o rol";
            this.txtBuscar.AccessibleDescription = "Escriba parte de un correo o el nombre de un rol para filtrar.";
            this.txtBuscar.TabIndex = 2;
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
            this.btnNuevo.Location = new System.Drawing.Point(723, 79);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(150, 38);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo Usuario";
            this.btnNuevo.AccessibleName = "Crear usuario";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = Tema.Superficie;
            this.dgvUsuarios.ColumnHeadersHeight = 36;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUsuario,
            this.Correo,
            this.Rol,
            this.FechaRegistro,
            this.Estado,
            this.colEditar,
            this.colBaja});
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.TabIndex = 5;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // IdUsuario
            // 
            this.IdUsuario.HeaderText = "IdUsuario";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.ReadOnly = true;
            this.IdUsuario.Visible = false;
            // 
            // Correo
            // 
            this.Correo.FillWeight = 150F;
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha de registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.FillWeight = 65F;
            this.colEditar.HeaderText = "";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // colBaja
            // 
            this.colBaja.FillWeight = 75F;
            this.colBaja.HeaderText = "";
            this.colBaja.Name = "colBaja";
            this.colBaja.ReadOnly = true;
            this.colBaja.Text = "Dar de baja";
            this.colBaja.UseColumnTextForButtonValue = true;
            // 
            // paginaPrincipalUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1068, 630);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 132;
            this.panelEncabezado.BackColor = Tema.Fondo;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblBuscar);
            this.panelEncabezado.Controls.Add(this.txtBuscar);
            this.panelEncabezado.Controls.Add(this.btnNuevo);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Padding = new System.Windows.Forms.Padding(24, 0, 24, 24);
            this.panelTabla.BackColor = Tema.Fondo;
            this.panelTabla.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelEncabezado);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "paginaPrincipalUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Usuarios";
            this.Load += new System.EventHandler(this.paginaPrincipalUsuarios_Load);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colBaja;
    }
}
