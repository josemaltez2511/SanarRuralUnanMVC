using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class menuPrincipalMedicos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panelBannerPaisaje = new System.Windows.Forms.Panel();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblUsuarioNombre = new System.Windows.Forms.Label();
            this.lblUsuarioRol = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnConsultas = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.panelSidebarLema = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelPlaceholder = new System.Windows.Forms.Panel();
            this.lblPlaceholderBadge = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.panelEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelUsuario.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelPlaceholder.SuspendLayout();
            this.SuspendLayout();
            //
            // panelEncabezado
            //
            this.panelEncabezado.BackColor = Tema.Superficie;
            this.panelEncabezado.Controls.Add(this.picLogo);
            this.panelEncabezado.Controls.Add(this.lblMarca);
            this.panelEncabezado.Controls.Add(this.lblDescripcion);
            this.panelEncabezado.Controls.Add(this.panelBannerPaisaje);
            this.panelEncabezado.Controls.Add(this.panelUsuario);
            this.panelEncabezado.Controls.Add(this.btnCerrarSesion);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 82;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(1280, 82);
            this.panelEncabezado.TabIndex = 0;
            //
            // picLogo
            //
            this.picLogo.AccessibleDescription = "Identidad visual de Sanar Rural";
            this.picLogo.AccessibleName = "Logo institucional";
            this.picLogo.Location = new System.Drawing.Point(20, 14);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(54, 54);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // lblMarca
            //
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = Tema.AzulOscuro;
            this.lblMarca.Location = new System.Drawing.Point(82, 14);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(188, 30);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "SANAR RURAL";
            //
            // lblDescripcion
            //
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = Tema.FuenteAyuda;
            this.lblDescripcion.ForeColor = Tema.TextoSecundario;
            this.lblDescripcion.Location = new System.Drawing.Point(84, 48);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(175, 15);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Atención Médica Comunitaria";
            //
            // panelBannerPaisaje
            //
            this.panelBannerPaisaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBannerPaisaje.BackColor = Tema.Superficie;
            this.panelBannerPaisaje.Location = new System.Drawing.Point(280, 2);
            this.panelBannerPaisaje.Name = "panelBannerPaisaje";
            this.panelBannerPaisaje.Size = new System.Drawing.Size(560, 78);
            this.panelBannerPaisaje.TabIndex = 3;
            //
            // panelUsuario
            //
            this.panelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUsuario.BackColor = Tema.Superficie;
            this.panelUsuario.Controls.Add(this.lblAvatar);
            this.panelUsuario.Controls.Add(this.lblUsuarioNombre);
            this.panelUsuario.Controls.Add(this.lblUsuarioRol);
            this.panelUsuario.Location = new System.Drawing.Point(860, 16);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(240, 50);
            this.panelUsuario.TabIndex = 4;
            //
            // lblAvatar
            //
            this.lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this.lblAvatar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = Tema.VerdeOscuro;
            this.lblAvatar.Location = new System.Drawing.Point(8, 7);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(36, 36);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "DR";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUsuarioNombre
            //
            this.lblUsuarioNombre.AutoEllipsis = true;
            this.lblUsuarioNombre.Font = Tema.FuenteLabelCampo;
            this.lblUsuarioNombre.ForeColor = Tema.AzulOscuro;
            this.lblUsuarioNombre.Location = new System.Drawing.Point(50, 6);
            this.lblUsuarioNombre.Name = "lblUsuarioNombre";
            this.lblUsuarioNombre.Size = new System.Drawing.Size(184, 18);
            this.lblUsuarioNombre.TabIndex = 1;
            this.lblUsuarioNombre.Text = "Personal Médico";
            //
            // lblUsuarioRol
            //
            this.lblUsuarioRol.AutoSize = true;
            this.lblUsuarioRol.Font = Tema.FuentePequena;
            this.lblUsuarioRol.ForeColor = Tema.TextoSecundario;
            this.lblUsuarioRol.Location = new System.Drawing.Point(50, 26);
            this.lblUsuarioRol.Name = "lblUsuarioRol";
            this.lblUsuarioRol.Size = new System.Drawing.Size(95, 15);
            this.lblUsuarioRol.TabIndex = 2;
            this.lblUsuarioRol.Text = "Médico General";
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = Tema.Superficie;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 1;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = Tema.FuenteLabelCampo;
            this.btnCerrarSesion.ForeColor = Tema.TextoPrincipal;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1116, 21);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(144, 40);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "🚪 Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            //
            // panelSidebar
            //
            this.panelSidebar.BackColor = Tema.Fondo;
            this.panelSidebar.Controls.Add(this.btnPacientes);
            this.panelSidebar.Controls.Add(this.btnCitas);
            this.panelSidebar.Controls.Add(this.btnConsultas);
            this.panelSidebar.Controls.Add(this.btnHistorial);
            this.panelSidebar.Controls.Add(this.panelSidebarLema);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 82);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this.panelSidebar.Size = new System.Drawing.Size(195, 718);
            this.panelSidebar.TabIndex = 1;
            //
            // btnPacientes
            //
            this.btnPacientes.BackColor = Tema.AzulPrimario;
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = Tema.FuenteBoton;
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(14, 16);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(167, 44);
            this.btnPacientes.TabIndex = 0;
            this.btnPacientes.Text = "  👥  Pacientes";
            this.btnPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            //
            // btnCitas
            //
            this.btnCitas.BackColor = System.Drawing.Color.Transparent;
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = Tema.FuenteBoton;
            this.btnCitas.ForeColor = Tema.AzulOscuro;
            this.btnCitas.Location = new System.Drawing.Point(14, 68);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(167, 44);
            this.btnCitas.TabIndex = 1;
            this.btnCitas.Text = "  📅  Citas";
            this.btnCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCitas.UseVisualStyleBackColor = false;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            //
            // btnConsultas
            //
            this.btnConsultas.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultas.FlatAppearance.BorderSize = 0;
            this.btnConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultas.Font = Tema.FuenteBoton;
            this.btnConsultas.ForeColor = Tema.AzulOscuro;
            this.btnConsultas.Location = new System.Drawing.Point(14, 120);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(167, 44);
            this.btnConsultas.TabIndex = 2;
            this.btnConsultas.Text = "  🩺  Consultas";
            this.btnConsultas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultas.UseVisualStyleBackColor = false;
            this.btnConsultas.Click += new System.EventHandler(this.btnConsultas_Click);
            //
            // btnHistorial
            //
            this.btnHistorial.BackColor = System.Drawing.Color.Transparent;
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = Tema.FuenteBoton;
            this.btnHistorial.ForeColor = Tema.AzulOscuro;
            this.btnHistorial.Location = new System.Drawing.Point(14, 172);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(167, 44);
            this.btnHistorial.TabIndex = 3;
            this.btnHistorial.Text = "  📋  Historial clínico";
            this.btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            //
            // panelSidebarLema
            //
            this.panelSidebarLema.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSidebarLema.Location = new System.Drawing.Point(14, 582);
            this.panelSidebarLema.Name = "panelSidebarLema";
            this.panelSidebarLema.Size = new System.Drawing.Size(167, 120);
            this.panelSidebarLema.TabIndex = 4;
            //
            // panelContenido
            //
            this.panelContenido.BackColor = Tema.Fondo;
            this.panelContenido.Controls.Add(this.panelPlaceholder);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(195, 82);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(18, 16, 20, 18);
            this.panelContenido.Size = new System.Drawing.Size(1085, 718);
            this.panelContenido.TabIndex = 2;
            //
            // panelPlaceholder
            //
            this.panelPlaceholder.BackColor = Tema.Superficie;
            this.panelPlaceholder.Controls.Add(this.lblPlaceholderBadge);
            this.panelPlaceholder.Controls.Add(this.lblSeccion);
            this.panelPlaceholder.Controls.Add(this.lblContenido);
            this.panelPlaceholder.Location = new System.Drawing.Point(232, 180);
            this.panelPlaceholder.Name = "panelPlaceholder";
            this.panelPlaceholder.Padding = new System.Windows.Forms.Padding(36);
            this.panelPlaceholder.Size = new System.Drawing.Size(620, 240);
            this.panelPlaceholder.TabIndex = 0;
            this.panelPlaceholder.Visible = false;
            //
            // lblPlaceholderBadge
            //
            this.lblPlaceholderBadge.AutoSize = true;
            this.lblPlaceholderBadge.Font = Tema.FuenteAyuda;
            this.lblPlaceholderBadge.ForeColor = Tema.AzulPrimario;
            this.lblPlaceholderBadge.Location = new System.Drawing.Point(36, 32);
            this.lblPlaceholderBadge.Name = "lblPlaceholderBadge";
            this.lblPlaceholderBadge.Size = new System.Drawing.Size(175, 15);
            this.lblPlaceholderBadge.TabIndex = 0;
            this.lblPlaceholderBadge.Text = "HISTORIAL CLÍNICO INTEGRAL";
            //
            // lblSeccion
            //
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = Tema.FuenteTitulo;
            this.lblSeccion.ForeColor = Tema.AzulOscuro;
            this.lblSeccion.Location = new System.Drawing.Point(34, 60);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(185, 32);
            this.lblSeccion.TabIndex = 1;
            this.lblSeccion.Text = "Historial Clínico";
            //
            // lblContenido
            //
            this.lblContenido.Font = Tema.FuenteSubtitulo;
            this.lblContenido.ForeColor = Tema.TextoSecundario;
            this.lblContenido.Location = new System.Drawing.Point(36, 108);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(548, 90);
            this.lblContenido.TabIndex = 2;
            this.lblContenido.Text = "El módulo de trazabilidad y consulta cronológica de atenciones clínicas se incorporará en la siguiente fase de desarrollo.";
            //
            // menuPrincipalMedicos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "menuPrincipalMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Atención Médica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.menuPrincipalMedicos_FormClosed);
            this.Resize += new System.EventHandler(this.menuPrincipalMedicos_Resize);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.panelPlaceholder.ResumeLayout(false);
            this.panelPlaceholder.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel panelBannerPaisaje;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUsuarioNombre;
        private System.Windows.Forms.Label lblUsuarioRol;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel panelSidebarLema;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelPlaceholder;
        private System.Windows.Forms.Label lblPlaceholderBadge;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblContenido;
    }
}
