using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    partial class seleccionarCitaConsulta
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
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblConteo = new System.Windows.Forms.Label();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.lblIconoBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelIconoModulo = new System.Windows.Forms.Panel();
            this.lblIconoModulo = new System.Windows.Forms.Label();
            this.panelCard.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelIconoModulo.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCard
            //
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.panelTabla);
            this.panelCard.Controls.Add(this.panelToolbar);
            this.panelCard.Controls.Add(this.panelFooter);
            this.panelCard.Controls.Add(this.panelHeader);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.panelCard.Size = new System.Drawing.Size(960, 580);
            this.panelCard.TabIndex = 0;
            //
            // panelFooter
            //
            this.panelFooter.Controls.Add(this.lblConteo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Height = 36;
            this.panelFooter.Location = new System.Drawing.Point(20, 528);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(920, 36);
            this.panelFooter.TabIndex = 3;
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = Tema.FuenteAyuda;
            this.lblConteo.ForeColor = Tema.TextoSecundario;
            this.lblConteo.Location = new System.Drawing.Point(4, 10);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(200, 15);
            this.lblConteo.TabIndex = 0;
            this.lblConteo.Text = "Mostrando 0 citas elegibles";
            //
            // panelTabla
            //
            this.panelTabla.Controls.Add(this.dgvCitas);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(20, 118);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(920, 410);
            this.panelTabla.TabIndex = 2;
            //
            // dgvCitas
            //
            this.dgvCitas.AccessibleDescription = "Lista de citas disponibles para consulta";
            this.dgvCitas.AccessibleName = "Citas elegibles";
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.AllowUserToResizeRows = false;
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.BackgroundColor = Tema.Superficie;
            this.dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCitas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.Location = new System.Drawing.Point(0, 0);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.RowTemplate.Height = 44;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(920, 410);
            this.dgvCitas.TabIndex = 0;
            this.dgvCitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellContentClick);
            this.dgvCitas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCitas_CellMouseMove);
            this.dgvCitas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCitas_CellPainting);
            //
            // panelToolbar
            //
            this.panelToolbar.Controls.Add(this.panelBuscar);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Height = 50;
            this.panelToolbar.Location = new System.Drawing.Point(20, 68);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(920, 50);
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
            this.panelBuscar.Size = new System.Drawing.Size(420, 38);
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
            this.txtBuscar.Size = new System.Drawing.Size(344, 19);
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
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(386, 6);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(26, 26);
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = false;
            this.btnLimpiarBusqueda.Visible = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.btnCerrar);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.panelIconoModulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 58;
            this.panelHeader.Location = new System.Drawing.Point(20, 16);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(920, 58);
            this.panelHeader.TabIndex = 0;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = Tema.Superficie;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrar.FlatAppearance.BorderSize = 1;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = Tema.FuenteLabelCampo;
            this.btnCerrar.ForeColor = Tema.TextoPrincipal;
            this.btnCerrar.Location = new System.Drawing.Point(824, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(96, 36);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "✕ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(52, 34);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(410, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Seleccione una cita programada para abrir el expediente e iniciar la atención";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(52, 2);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(288, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Citas Elegibles para Consulta";
            //
            // panelIconoModulo
            //
            this.panelIconoModulo.BackColor = System.Drawing.Color.FromArgb(226, 238, 248);
            this.panelIconoModulo.Controls.Add(this.lblIconoModulo);
            this.panelIconoModulo.Location = new System.Drawing.Point(0, 2);
            this.panelIconoModulo.Name = "panelIconoModulo";
            this.panelIconoModulo.Size = new System.Drawing.Size(42, 42);
            this.panelIconoModulo.TabIndex = 0;
            //
            // lblIconoModulo
            //
            this.lblIconoModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconoModulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoModulo.ForeColor = Tema.AzulPrimario;
            this.lblIconoModulo.Location = new System.Drawing.Point(0, 0);
            this.lblIconoModulo.Name = "lblIconoModulo";
            this.lblIconoModulo.Size = new System.Drawing.Size(42, 42);
            this.lblIconoModulo.TabIndex = 0;
            this.lblIconoModulo.Text = "📅";
            this.lblIconoModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // seleccionarCitaConsulta
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(960, 580);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "seleccionarCitaConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Cita para Consulta Médica";
            this.Load += new System.EventHandler(this.seleccionarCitaConsulta_Load);
            this.panelCard.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelIconoModulo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelIconoModulo;
        private System.Windows.Forms.Label lblIconoModulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.Label lblIconoBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblConteo;
    }
}
