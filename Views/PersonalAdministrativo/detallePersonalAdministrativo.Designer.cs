using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.PersonalAdministrativo
{
    partial class detallePersonalAdministrativo
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
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cardCredenciales = new System.Windows.Forms.Panel();
            this.lblValorEstadoUsuario = new System.Windows.Forms.Label();
            this.lblTituloEstadoUsuario = new System.Windows.Forms.Label();
            this.lblValorCorreoUsuario = new System.Windows.Forms.Label();
            this.lblTituloCorreoUsuario = new System.Windows.Forms.Label();
            this.lblValorUsuario = new System.Windows.Forms.Label();
            this.lblTituloUsuario = new System.Windows.Forms.Label();
            this.lblIconoCredenciales = new System.Windows.Forms.Label();
            this.lblEncabezadoCredenciales = new System.Windows.Forms.Label();
            this.cardDatosPersonales = new System.Windows.Forms.Panel();
            this.lblValorEstado = new System.Windows.Forms.Label();
            this.lblTituloEstado = new System.Windows.Forms.Label();
            this.lblValorCorreo = new System.Windows.Forms.Label();
            this.lblTituloCorreo = new System.Windows.Forms.Label();
            this.lblValorTelefono = new System.Windows.Forms.Label();
            this.lblTituloTelefono = new System.Windows.Forms.Label();
            this.lblValorCedula = new System.Windows.Forms.Label();
            this.lblTituloCedula = new System.Windows.Forms.Label();
            this.lblValorCargo = new System.Windows.Forms.Label();
            this.lblTituloCargo = new System.Windows.Forms.Label();
            this.lblIconoDatos = new System.Windows.Forms.Label();
            this.lblEncabezadoDatos = new System.Windows.Forms.Label();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.btnCerrarTop = new System.Windows.Forms.Button();
            this.lblSubtituloRol = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.panelContenedor.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.cardCredenciales.SuspendLayout();
            this.cardDatosPersonales.SuspendLayout();
            this.cardHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // panelContenedor
            //
            this.panelContenedor.BackColor = Tema.Fondo;
            this.panelContenedor.Controls.Add(this.panelBotones);
            this.panelContenedor.Controls.Add(this.cardCredenciales);
            this.panelContenedor.Controls.Add(this.cardDatosPersonales);
            this.panelContenedor.Controls.Add(this.cardHeader);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(20);
            this.panelContenedor.Size = new System.Drawing.Size(600, 560);
            this.panelContenedor.TabIndex = 0;
            //
            // panelBotones
            //
            this.panelBotones.Controls.Add(this.btnEditar);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(20, 486);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(560, 54);
            this.panelBotones.TabIndex = 3;
            //
            // btnEditar
            //
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = Tema.AzulPrimario;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = Tema.FuenteBoton;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(426, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(134, 42);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar perfil";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = Tema.FondoSecundario;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = Tema.FuenteBoton;
            this.btnCerrar.ForeColor = Tema.TextoPrincipal;
            this.btnCerrar.Location = new System.Drawing.Point(296, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 42);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // cardCredenciales
            //
            this.cardCredenciales.BackColor = System.Drawing.Color.White;
            this.cardCredenciales.Controls.Add(this.lblValorEstadoUsuario);
            this.cardCredenciales.Controls.Add(this.lblTituloEstadoUsuario);
            this.cardCredenciales.Controls.Add(this.lblValorCorreoUsuario);
            this.cardCredenciales.Controls.Add(this.lblTituloCorreoUsuario);
            this.cardCredenciales.Controls.Add(this.lblValorUsuario);
            this.cardCredenciales.Controls.Add(this.lblTituloUsuario);
            this.cardCredenciales.Controls.Add(this.lblIconoCredenciales);
            this.cardCredenciales.Controls.Add(this.lblEncabezadoCredenciales);
            this.cardCredenciales.Location = new System.Drawing.Point(20, 316);
            this.cardCredenciales.Name = "cardCredenciales";
            this.cardCredenciales.Padding = new System.Windows.Forms.Padding(18);
            this.cardCredenciales.Size = new System.Drawing.Size(560, 154);
            this.cardCredenciales.TabIndex = 2;
            //
            // lblValorEstadoUsuario
            //
            this.lblValorEstadoUsuario.AutoSize = true;
            this.lblValorEstadoUsuario.Font = Tema.FuenteLabelCampo;
            this.lblValorEstadoUsuario.ForeColor = Tema.TextoPrincipal;
            this.lblValorEstadoUsuario.Location = new System.Drawing.Point(296, 114);
            this.lblValorEstadoUsuario.Name = "lblValorEstadoUsuario";
            this.lblValorEstadoUsuario.Size = new System.Drawing.Size(43, 16);
            this.lblValorEstadoUsuario.TabIndex = 7;
            this.lblValorEstadoUsuario.Text = "Activa";
            //
            // lblTituloEstadoUsuario
            //
            this.lblTituloEstadoUsuario.AutoSize = true;
            this.lblTituloEstadoUsuario.Font = Tema.FuentePequena;
            this.lblTituloEstadoUsuario.ForeColor = Tema.TextoSecundario;
            this.lblTituloEstadoUsuario.Location = new System.Drawing.Point(296, 96);
            this.lblTituloEstadoUsuario.Name = "lblTituloEstadoUsuario";
            this.lblTituloEstadoUsuario.Size = new System.Drawing.Size(109, 15);
            this.lblTituloEstadoUsuario.TabIndex = 6;
            this.lblTituloEstadoUsuario.Text = "Estado de la cuenta";
            //
            // lblValorCorreoUsuario
            //
            this.lblValorCorreoUsuario.AutoSize = true;
            this.lblValorCorreoUsuario.Font = Tema.FuenteLabelCampo;
            this.lblValorCorreoUsuario.ForeColor = Tema.TextoPrincipal;
            this.lblValorCorreoUsuario.Location = new System.Drawing.Point(18, 114);
            this.lblValorCorreoUsuario.Name = "lblValorCorreoUsuario";
            this.lblValorCorreoUsuario.Size = new System.Drawing.Size(11, 16);
            this.lblValorCorreoUsuario.TabIndex = 5;
            this.lblValorCorreoUsuario.Text = "-";
            //
            // lblTituloCorreoUsuario
            //
            this.lblTituloCorreoUsuario.AutoSize = true;
            this.lblTituloCorreoUsuario.Font = Tema.FuentePequena;
            this.lblTituloCorreoUsuario.ForeColor = Tema.TextoSecundario;
            this.lblTituloCorreoUsuario.Location = new System.Drawing.Point(18, 96);
            this.lblTituloCorreoUsuario.Name = "lblTituloCorreoUsuario";
            this.lblTituloCorreoUsuario.Size = new System.Drawing.Size(110, 15);
            this.lblTituloCorreoUsuario.TabIndex = 4;
            this.lblTituloCorreoUsuario.Text = "Correo institucional";
            //
            // lblValorUsuario
            //
            this.lblValorUsuario.AutoSize = true;
            this.lblValorUsuario.Font = Tema.FuenteLabelCampo;
            this.lblValorUsuario.ForeColor = Tema.AzulPrimario;
            this.lblValorUsuario.Location = new System.Drawing.Point(18, 68);
            this.lblValorUsuario.Name = "lblValorUsuario";
            this.lblValorUsuario.Size = new System.Drawing.Size(144, 16);
            this.lblValorUsuario.TabIndex = 3;
            this.lblValorUsuario.Text = "Sin usuario asignado";
            //
            // lblTituloUsuario
            //
            this.lblTituloUsuario.AutoSize = true;
            this.lblTituloUsuario.Font = Tema.FuentePequena;
            this.lblTituloUsuario.ForeColor = Tema.TextoSecundario;
            this.lblTituloUsuario.Location = new System.Drawing.Point(18, 50);
            this.lblTituloUsuario.Name = "lblTituloUsuario";
            this.lblTituloUsuario.Size = new System.Drawing.Size(109, 15);
            this.lblTituloUsuario.TabIndex = 2;
            this.lblTituloUsuario.Text = "Nombre de usuario";
            //
            // lblIconoCredenciales
            //
            this.lblIconoCredenciales.AutoSize = true;
            this.lblIconoCredenciales.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoCredenciales.ForeColor = Tema.AzulPrimario;
            this.lblIconoCredenciales.Location = new System.Drawing.Point(18, 16);
            this.lblIconoCredenciales.Name = "lblIconoCredenciales";
            this.lblIconoCredenciales.Size = new System.Drawing.Size(26, 20);
            this.lblIconoCredenciales.TabIndex = 0;
            this.lblIconoCredenciales.Text = "◈";
            //
            // lblEncabezadoCredenciales
            //
            this.lblEncabezadoCredenciales.AutoSize = true;
            this.lblEncabezadoCredenciales.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblEncabezadoCredenciales.ForeColor = Tema.AzulOscuro;
            this.lblEncabezadoCredenciales.Location = new System.Drawing.Point(46, 16);
            this.lblEncabezadoCredenciales.Name = "lblEncabezadoCredenciales";
            this.lblEncabezadoCredenciales.Size = new System.Drawing.Size(149, 19);
            this.lblEncabezadoCredenciales.TabIndex = 1;
            this.lblEncabezadoCredenciales.Text = "Credenciales de Acceso";
            //
            // cardDatosPersonales
            //
            this.cardDatosPersonales.BackColor = System.Drawing.Color.White;
            this.cardDatosPersonales.Controls.Add(this.lblValorEstado);
            this.cardDatosPersonales.Controls.Add(this.lblTituloEstado);
            this.cardDatosPersonales.Controls.Add(this.lblValorCorreo);
            this.cardDatosPersonales.Controls.Add(this.lblTituloCorreo);
            this.cardDatosPersonales.Controls.Add(this.lblValorTelefono);
            this.cardDatosPersonales.Controls.Add(this.lblTituloTelefono);
            this.cardDatosPersonales.Controls.Add(this.lblValorCedula);
            this.cardDatosPersonales.Controls.Add(this.lblTituloCedula);
            this.cardDatosPersonales.Controls.Add(this.lblValorCargo);
            this.cardDatosPersonales.Controls.Add(this.lblTituloCargo);
            this.cardDatosPersonales.Controls.Add(this.lblIconoDatos);
            this.cardDatosPersonales.Controls.Add(this.lblEncabezadoDatos);
            this.cardDatosPersonales.Location = new System.Drawing.Point(20, 106);
            this.cardDatosPersonales.Name = "cardDatosPersonales";
            this.cardDatosPersonales.Padding = new System.Windows.Forms.Padding(18);
            this.cardDatosPersonales.Size = new System.Drawing.Size(560, 194);
            this.cardDatosPersonales.TabIndex = 1;
            //
            // lblValorEstado
            //
            this.lblValorEstado.AutoSize = true;
            this.lblValorEstado.Font = Tema.FuenteLabelCampo;
            this.lblValorEstado.ForeColor = Tema.VerdeOscuro;
            this.lblValorEstado.Location = new System.Drawing.Point(296, 154);
            this.lblValorEstado.Name = "lblValorEstado";
            this.lblValorEstado.Size = new System.Drawing.Size(56, 16);
            this.lblValorEstado.TabIndex = 11;
            this.lblValorEstado.Text = "● Activo";
            //
            // lblTituloEstado
            //
            this.lblTituloEstado.AutoSize = true;
            this.lblTituloEstado.Font = Tema.FuentePequena;
            this.lblTituloEstado.ForeColor = Tema.TextoSecundario;
            this.lblTituloEstado.Location = new System.Drawing.Point(296, 136);
            this.lblTituloEstado.Name = "lblTituloEstado";
            this.lblTituloEstado.Size = new System.Drawing.Size(97, 15);
            this.lblTituloEstado.TabIndex = 10;
            this.lblTituloEstado.Text = "Estado del perfil";
            //
            // lblValorCorreo
            //
            this.lblValorCorreo.AutoSize = true;
            this.lblValorCorreo.Font = Tema.FuenteLabelCampo;
            this.lblValorCorreo.ForeColor = Tema.TextoPrincipal;
            this.lblValorCorreo.Location = new System.Drawing.Point(18, 154);
            this.lblValorCorreo.Name = "lblValorCorreo";
            this.lblValorCorreo.Size = new System.Drawing.Size(11, 16);
            this.lblValorCorreo.TabIndex = 9;
            this.lblValorCorreo.Text = "-";
            //
            // lblTituloCorreo
            //
            this.lblTituloCorreo.AutoSize = true;
            this.lblTituloCorreo.Font = Tema.FuentePequena;
            this.lblTituloCorreo.ForeColor = Tema.TextoSecundario;
            this.lblTituloCorreo.Location = new System.Drawing.Point(18, 136);
            this.lblTituloCorreo.Name = "lblTituloCorreo";
            this.lblTituloCorreo.Size = new System.Drawing.Size(107, 15);
            this.lblTituloCorreo.TabIndex = 8;
            this.lblTituloCorreo.Text = "Correo electrónico";
            //
            // lblValorTelefono
            //
            this.lblValorTelefono.AutoSize = true;
            this.lblValorTelefono.Font = Tema.FuenteLabelCampo;
            this.lblValorTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblValorTelefono.Location = new System.Drawing.Point(296, 104);
            this.lblValorTelefono.Name = "lblValorTelefono";
            this.lblValorTelefono.Size = new System.Drawing.Size(11, 16);
            this.lblValorTelefono.TabIndex = 7;
            this.lblValorTelefono.Text = "-";
            //
            // lblTituloTelefono
            //
            this.lblTituloTelefono.AutoSize = true;
            this.lblTituloTelefono.Font = Tema.FuentePequena;
            this.lblTituloTelefono.ForeColor = Tema.TextoSecundario;
            this.lblTituloTelefono.Location = new System.Drawing.Point(296, 86);
            this.lblTituloTelefono.Name = "lblTituloTelefono";
            this.lblTituloTelefono.Size = new System.Drawing.Size(54, 15);
            this.lblTituloTelefono.TabIndex = 6;
            this.lblTituloTelefono.Text = "Teléfono";
            //
            // lblValorCedula
            //
            this.lblValorCedula.AutoSize = true;
            this.lblValorCedula.Font = Tema.FuenteLabelCampo;
            this.lblValorCedula.ForeColor = Tema.TextoPrincipal;
            this.lblValorCedula.Location = new System.Drawing.Point(18, 104);
            this.lblValorCedula.Name = "lblValorCedula";
            this.lblValorCedula.Size = new System.Drawing.Size(11, 16);
            this.lblValorCedula.TabIndex = 5;
            this.lblValorCedula.Text = "-";
            //
            // lblTituloCedula
            //
            this.lblTituloCedula.AutoSize = true;
            this.lblTituloCedula.Font = Tema.FuentePequena;
            this.lblTituloCedula.ForeColor = Tema.TextoSecundario;
            this.lblTituloCedula.Location = new System.Drawing.Point(18, 86);
            this.lblTituloCedula.Name = "lblTituloCedula";
            this.lblTituloCedula.Size = new System.Drawing.Size(46, 15);
            this.lblTituloCedula.TabIndex = 4;
            this.lblTituloCedula.Text = "Cédula";
            //
            // lblValorCargo
            //
            this.lblValorCargo.AutoSize = true;
            this.lblValorCargo.Font = Tema.FuenteLabelCampo;
            this.lblValorCargo.ForeColor = Tema.AzulPrimario;
            this.lblValorCargo.Location = new System.Drawing.Point(18, 54);
            this.lblValorCargo.Name = "lblValorCargo";
            this.lblValorCargo.Size = new System.Drawing.Size(147, 16);
            this.lblValorCargo.TabIndex = 3;
            this.lblValorCargo.Text = "Personal Administrativo";
            //
            // lblTituloCargo
            //
            this.lblTituloCargo.AutoSize = true;
            this.lblTituloCargo.Font = Tema.FuentePequena;
            this.lblTituloCargo.ForeColor = Tema.TextoSecundario;
            this.lblTituloCargo.Location = new System.Drawing.Point(18, 36);
            this.lblTituloCargo.Name = "lblTituloCargo";
            this.lblTituloCargo.Size = new System.Drawing.Size(111, 15);
            this.lblTituloCargo.TabIndex = 2;
            this.lblTituloCargo.Text = "Cargo institucional";
            //
            // lblIconoDatos
            //
            this.lblIconoDatos.AutoSize = true;
            this.lblIconoDatos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoDatos.ForeColor = Tema.AzulPrimario;
            this.lblIconoDatos.Location = new System.Drawing.Point(18, 12);
            this.lblIconoDatos.Name = "lblIconoDatos";
            this.lblIconoDatos.Size = new System.Drawing.Size(26, 20);
            this.lblIconoDatos.TabIndex = 0;
            this.lblIconoDatos.Text = "◈";
            //
            // lblEncabezadoDatos
            //
            this.lblEncabezadoDatos.AutoSize = true;
            this.lblEncabezadoDatos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10F, System.Drawing.FontStyle.Bold);
            this.lblEncabezadoDatos.ForeColor = Tema.AzulOscuro;
            this.lblEncabezadoDatos.Location = new System.Drawing.Point(46, 12);
            this.lblEncabezadoDatos.Name = "lblEncabezadoDatos";
            this.lblEncabezadoDatos.Size = new System.Drawing.Size(209, 19);
            this.lblEncabezadoDatos.TabIndex = 1;
            this.lblEncabezadoDatos.Text = "Información Personal y Laboral";
            //
            // cardHeader
            //
            this.cardHeader.BackColor = System.Drawing.Color.White;
            this.cardHeader.Controls.Add(this.btnCerrarTop);
            this.cardHeader.Controls.Add(this.lblSubtituloRol);
            this.cardHeader.Controls.Add(this.lblNombreCompleto);
            this.cardHeader.Controls.Add(this.lblAvatar);
            this.cardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardHeader.Location = new System.Drawing.Point(20, 20);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Size = new System.Drawing.Size(560, 74);
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
            this.btnCerrarTop.Location = new System.Drawing.Point(520, 16);
            this.btnCerrarTop.Name = "btnCerrarTop";
            this.btnCerrarTop.Size = new System.Drawing.Size(30, 30);
            this.btnCerrarTop.TabIndex = 3;
            this.btnCerrarTop.Text = "✕";
            this.btnCerrarTop.UseVisualStyleBackColor = true;
            this.btnCerrarTop.Click += new System.EventHandler(this.btnCerrarTop_Click);
            //
            // lblSubtituloRol
            //
            this.lblSubtituloRol.AutoSize = true;
            this.lblSubtituloRol.Font = Tema.FuentePequena;
            this.lblSubtituloRol.ForeColor = Tema.VerdeOscuro;
            this.lblSubtituloRol.Location = new System.Drawing.Point(74, 42);
            this.lblSubtituloRol.Name = "lblSubtituloRol";
            this.lblSubtituloRol.Size = new System.Drawing.Size(133, 15);
            this.lblSubtituloRol.TabIndex = 2;
            this.lblSubtituloRol.Text = "Personal Administrativo";
            //
            // lblNombreCompleto
            //
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 13F, System.Drawing.FontStyle.Bold);
            this.lblNombreCompleto.ForeColor = Tema.AzulOscuro;
            this.lblNombreCompleto.Location = new System.Drawing.Point(72, 16);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(161, 23);
            this.lblNombreCompleto.TabIndex = 1;
            this.lblNombreCompleto.Text = "Nombre Colaborador";
            //
            // lblAvatar
            //
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(235, 248, 242);
            this.lblAvatar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 12F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = Tema.VerdeOscuro;
            this.lblAvatar.Location = new System.Drawing.Point(14, 14);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(46, 46);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "PA";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // detallePersonalAdministrativo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(600, 560);
            this.Controls.Add(this.panelContenedor);
            this.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "detallePersonalAdministrativo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle del Personal Administrativo";
            this.Load += new System.EventHandler(this.detallePersonalAdministrativo_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.cardCredenciales.ResumeLayout(false);
            this.cardCredenciales.PerformLayout();
            this.cardDatosPersonales.ResumeLayout(false);
            this.cardDatosPersonales.PerformLayout();
            this.cardHeader.ResumeLayout(false);
            this.cardHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblSubtituloRol;
        private System.Windows.Forms.Button btnCerrarTop;
        private System.Windows.Forms.Panel cardDatosPersonales;
        private System.Windows.Forms.Label lblEncabezadoDatos;
        private System.Windows.Forms.Label lblIconoDatos;
        private System.Windows.Forms.Label lblTituloCargo;
        private System.Windows.Forms.Label lblValorCargo;
        private System.Windows.Forms.Label lblTituloCedula;
        private System.Windows.Forms.Label lblValorCedula;
        private System.Windows.Forms.Label lblTituloTelefono;
        private System.Windows.Forms.Label lblValorTelefono;
        private System.Windows.Forms.Label lblTituloCorreo;
        private System.Windows.Forms.Label lblValorCorreo;
        private System.Windows.Forms.Label lblTituloEstado;
        private System.Windows.Forms.Label lblValorEstado;
        private System.Windows.Forms.Panel cardCredenciales;
        private System.Windows.Forms.Label lblEncabezadoCredenciales;
        private System.Windows.Forms.Label lblIconoCredenciales;
        private System.Windows.Forms.Label lblTituloUsuario;
        private System.Windows.Forms.Label lblValorUsuario;
        private System.Windows.Forms.Label lblTituloCorreoUsuario;
        private System.Windows.Forms.Label lblValorCorreoUsuario;
        private System.Windows.Forms.Label lblTituloEstadoUsuario;
        private System.Windows.Forms.Label lblValorEstadoUsuario;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEditar;
    }
}
