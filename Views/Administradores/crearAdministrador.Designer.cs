using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Administradores
{
    partial class crearAdministrador
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.btnCerrarTop = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIconoHeader = new System.Windows.Forms.Label();
            this.cardForm = new System.Windows.Forms.Panel();
            this.pnlInfoCredenciales = new System.Windows.Forms.Panel();
            this.lblInfoCredenciales = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblSegundoNombre = new System.Windows.Forms.Label();
            this.txtSegundoNombre = new System.Windows.Forms.TextBox();
            this.lblPrimerNombre = new System.Windows.Forms.Label();
            this.txtPrimerNombre = new System.Windows.Forms.TextBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.cardHeader.SuspendLayout();
            this.cardForm.SuspendLayout();
            this.pnlInfoCredenciales.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelContenedor
            //
            this.panelContenedor.BackColor = Tema.Fondo;
            this.panelContenedor.Controls.Add(this.panelBotones);
            this.panelContenedor.Controls.Add(this.cardForm);
            this.panelContenedor.Controls.Add(this.cardHeader);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(20);
            this.panelContenedor.Size = new System.Drawing.Size(650, 560);
            this.panelContenedor.TabIndex = 0;
            //
            // cardHeader
            //
            this.cardHeader.BackColor = System.Drawing.Color.White;
            this.cardHeader.Controls.Add(this.btnCerrarTop);
            this.cardHeader.Controls.Add(this.lblSubtitulo);
            this.cardHeader.Controls.Add(this.lblTitulo);
            this.cardHeader.Controls.Add(this.lblIconoHeader);
            this.cardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardHeader.Location = new System.Drawing.Point(20, 20);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Size = new System.Drawing.Size(610, 68);
            this.cardHeader.TabIndex = 0;
            //
            // btnCerrarTop
            //
            this.btnCerrarTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarTop.FlatAppearance.BorderSize = 0;
            this.btnCerrarTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarTop.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarTop.ForeColor = Tema.TextoSecundario;
            this.btnCerrarTop.Location = new System.Drawing.Point(570, 14);
            this.btnCerrarTop.Name = "btnCerrarTop";
            this.btnCerrarTop.Size = new System.Drawing.Size(30, 30);
            this.btnCerrarTop.TabIndex = 3;
            this.btnCerrarTop.Text = "✕";
            this.btnCerrarTop.UseVisualStyleBackColor = true;
            this.btnCerrarTop.Click += new System.EventHandler(this.btnCerrarTop_Click);
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(64, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Complete los datos personales del perfil de administrador.";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nuevo Administrador";
            //
            // lblIconoHeader
            //
            this.lblIconoHeader.BackColor = System.Drawing.Color.FromArgb(226, 238, 248);
            this.lblIconoHeader.Font = new System.Drawing.Font(Tema.FamiliaFuente, 15F);
            this.lblIconoHeader.ForeColor = Tema.AzulPrimario;
            this.lblIconoHeader.Location = new System.Drawing.Point(14, 12);
            this.lblIconoHeader.Name = "lblIconoHeader";
            this.lblIconoHeader.Size = new System.Drawing.Size(42, 42);
            this.lblIconoHeader.TabIndex = 0;
            this.lblIconoHeader.Text = "";
            this.lblIconoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cardForm
            //
            this.cardForm.BackColor = System.Drawing.Color.White;
            this.cardForm.Controls.Add(this.pnlInfoCredenciales);
            this.cardForm.Controls.Add(this.lblError);
            this.cardForm.Controls.Add(this.lblCorreo);
            this.cardForm.Controls.Add(this.txtCorreo);
            this.cardForm.Controls.Add(this.lblTelefono);
            this.cardForm.Controls.Add(this.txtTelefono);
            this.cardForm.Controls.Add(this.lblCedula);
            this.cardForm.Controls.Add(this.txtCedula);
            this.cardForm.Controls.Add(this.lblSegundoApellido);
            this.cardForm.Controls.Add(this.txtSegundoApellido);
            this.cardForm.Controls.Add(this.lblPrimerApellido);
            this.cardForm.Controls.Add(this.txtPrimerApellido);
            this.cardForm.Controls.Add(this.lblSegundoNombre);
            this.cardForm.Controls.Add(this.txtSegundoNombre);
            this.cardForm.Controls.Add(this.lblPrimerNombre);
            this.cardForm.Controls.Add(this.txtPrimerNombre);
            this.cardForm.Location = new System.Drawing.Point(20, 100);
            this.cardForm.Name = "cardForm";
            this.cardForm.Padding = new System.Windows.Forms.Padding(24);
            this.cardForm.Size = new System.Drawing.Size(610, 375);
            this.cardForm.TabIndex = 1;
            //
            // pnlInfoCredenciales
            //
            this.pnlInfoCredenciales.BackColor = System.Drawing.Color.FromArgb(240, 246, 252);
            this.pnlInfoCredenciales.Controls.Add(this.lblInfoCredenciales);
            this.pnlInfoCredenciales.Location = new System.Drawing.Point(24, 256);
            this.pnlInfoCredenciales.Name = "pnlInfoCredenciales";
            this.pnlInfoCredenciales.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlInfoCredenciales.Size = new System.Drawing.Size(562, 58);
            this.pnlInfoCredenciales.TabIndex = 14;
            //
            // lblInfoCredenciales
            //
            this.lblInfoCredenciales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoCredenciales.Font = Tema.FuentePequena;
            this.lblInfoCredenciales.ForeColor = Tema.AzulOscuro;
            this.lblInfoCredenciales.Location = new System.Drawing.Point(12, 8);
            this.lblInfoCredenciales.Name = "lblInfoCredenciales";
            this.lblInfoCredenciales.Size = new System.Drawing.Size(538, 42);
            this.lblInfoCredenciales.TabIndex = 0;
            this.lblInfoCredenciales.Text = "ℹ️ Este formulario registra el perfil de la persona. Para asignarle un nombre de usuario y contraseña, utilice la opción \'Asignar acceso a perfil\' una vez guardado.";
            this.lblInfoCredenciales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblError
            //
            this.lblError.Font = Tema.FuentePequena;
            this.lblError.ForeColor = Tema.Error;
            this.lblError.Location = new System.Drawing.Point(24, 324);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(562, 26);
            this.lblError.TabIndex = 15;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCorreo
            //
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = Tema.FuenteLabelCampo;
            this.lblCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblCorreo.Location = new System.Drawing.Point(24, 190);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(121, 16);
            this.lblCorreo.TabIndex = 12;
            this.lblCorreo.Text = "Correo electrónico";
            //
            // txtCorreo
            //
            this.txtCorreo.Font = Tema.FuenteCuerpo;
            this.txtCorreo.ForeColor = Tema.TextoPrincipal;
            this.txtCorreo.Location = new System.Drawing.Point(24, 212);
            this.txtCorreo.MaxLength = 150;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(562, 24);
            this.txtCorreo.TabIndex = 13;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(316, 134);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(60, 16);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono";
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteCuerpo;
            this.txtTelefono.ForeColor = Tema.TextoPrincipal;
            this.txtTelefono.Location = new System.Drawing.Point(316, 156);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(270, 24);
            this.txtTelefono.TabIndex = 11;
            //
            // lblCedula
            //
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = Tema.FuenteLabelCampo;
            this.lblCedula.ForeColor = Tema.TextoPrincipal;
            this.lblCedula.Location = new System.Drawing.Point(24, 134);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(52, 16);
            this.lblCedula.TabIndex = 8;
            this.lblCedula.Text = "Cédula";
            //
            // txtCedula
            //
            this.txtCedula.Font = Tema.FuenteCuerpo;
            this.txtCedula.ForeColor = Tema.TextoPrincipal;
            this.txtCedula.Location = new System.Drawing.Point(24, 156);
            this.txtCedula.MaxLength = 20;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(270, 24);
            this.txtCedula.TabIndex = 9;
            //
            // lblSegundoApellido
            //
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Font = Tema.FuenteLabelCampo;
            this.lblSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoApellido.Location = new System.Drawing.Point(316, 76);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(117, 16);
            this.lblSegundoApellido.TabIndex = 6;
            this.lblSegundoApellido.Text = "Segundo apellido";
            //
            // txtSegundoApellido
            //
            this.txtSegundoApellido.Font = Tema.FuenteCuerpo;
            this.txtSegundoApellido.ForeColor = Tema.TextoPrincipal;
            this.txtSegundoApellido.Location = new System.Drawing.Point(316, 98);
            this.txtSegundoApellido.MaxLength = 50;
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(270, 24);
            this.txtSegundoApellido.TabIndex = 7;
            //
            // lblPrimerApellido
            //
            this.lblPrimerApellido.AutoSize = true;
            this.lblPrimerApellido.Font = Tema.FuenteLabelCampo;
            this.lblPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerApellido.Location = new System.Drawing.Point(24, 76);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(120, 16);
            this.lblPrimerApellido.TabIndex = 4;
            this.lblPrimerApellido.Text = "Primer apellido *";
            //
            // txtPrimerApellido
            //
            this.txtPrimerApellido.Font = Tema.FuenteCuerpo;
            this.txtPrimerApellido.ForeColor = Tema.TextoPrincipal;
            this.txtPrimerApellido.Location = new System.Drawing.Point(24, 98);
            this.txtPrimerApellido.MaxLength = 50;
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(270, 24);
            this.txtPrimerApellido.TabIndex = 5;
            //
            // lblSegundoNombre
            //
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Font = Tema.FuenteLabelCampo;
            this.lblSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.lblSegundoNombre.Location = new System.Drawing.Point(316, 18);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(114, 16);
            this.lblSegundoNombre.TabIndex = 2;
            this.lblSegundoNombre.Text = "Segundo nombre";
            //
            // txtSegundoNombre
            //
            this.txtSegundoNombre.Font = Tema.FuenteCuerpo;
            this.txtSegundoNombre.ForeColor = Tema.TextoPrincipal;
            this.txtSegundoNombre.Location = new System.Drawing.Point(316, 40);
            this.txtSegundoNombre.MaxLength = 50;
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(270, 24);
            this.txtSegundoNombre.TabIndex = 3;
            //
            // lblPrimerNombre
            //
            this.lblPrimerNombre.AutoSize = true;
            this.lblPrimerNombre.Font = Tema.FuenteLabelCampo;
            this.lblPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.lblPrimerNombre.Location = new System.Drawing.Point(24, 18);
            this.lblPrimerNombre.Name = "lblPrimerNombre";
            this.lblPrimerNombre.Size = new System.Drawing.Size(116, 16);
            this.lblPrimerNombre.TabIndex = 0;
            this.lblPrimerNombre.Text = "Primer nombre *";
            //
            // txtPrimerNombre
            //
            this.txtPrimerNombre.Font = Tema.FuenteCuerpo;
            this.txtPrimerNombre.ForeColor = Tema.TextoPrincipal;
            this.txtPrimerNombre.Location = new System.Drawing.Point(24, 40);
            this.txtPrimerNombre.MaxLength = 50;
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Size = new System.Drawing.Size(270, 24);
            this.txtPrimerNombre.TabIndex = 1;
            //
            // panelBotones
            //
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(20, 486);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(610, 54);
            this.panelBotones.TabIndex = 2;
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = Tema.FondoSecundario;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteBoton;
            this.btnCancelar.ForeColor = Tema.TextoPrincipal;
            this.btnCancelar.Location = new System.Drawing.Point(346, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(476, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(134, 42);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // crearAdministrador
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(650, 560);
            this.Controls.Add(this.panelContenedor);
            this.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "crearAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.crearAdministrador_Load);
            this.panelContenedor.ResumeLayout(false);
            this.cardHeader.ResumeLayout(false);
            this.cardHeader.PerformLayout();
            this.cardForm.ResumeLayout(false);
            this.cardForm.PerformLayout();
            this.pnlInfoCredenciales.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.Label lblIconoHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnCerrarTop;
        private System.Windows.Forms.Panel cardForm;
        private System.Windows.Forms.Label lblPrimerNombre;
        private System.Windows.Forms.TextBox txtPrimerNombre;
        private System.Windows.Forms.Label lblSegundoNombre;
        private System.Windows.Forms.TextBox txtSegundoNombre;
        private System.Windows.Forms.Label lblPrimerApellido;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Panel pnlInfoCredenciales;
        private System.Windows.Forms.Label lblInfoCredenciales;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
