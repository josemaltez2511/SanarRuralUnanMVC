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
            this.panelBarra = new System.Windows.Forms.Panel();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.lblEstadoSesion = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnConsultas = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.panelIndicador = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelPlaceholder = new System.Windows.Forms.Panel();
            this.lblPlaceholderBadge = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.panelBarra.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            this.panelNavegacion.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            //
            // panelBarra
            //
            this.panelBarra.BackColor = Tema.Superficie;
            this.panelBarra.Controls.Add(this.panelNavegacion);
            this.panelBarra.Controls.Add(this.panelEncabezado);
            this.panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarra.Height = 134;
            this.panelBarra.TabIndex = 0;
            //
            // panelEncabezado
            //
            this.panelEncabezado.BackColor = Tema.Superficie;
            this.panelEncabezado.Controls.Add(this.picLogo);
            this.panelEncabezado.Controls.Add(this.lblMarca);
            this.panelEncabezado.Controls.Add(this.lblDescripcion);
            this.panelEncabezado.Controls.Add(this.panelUsuario);
            this.panelEncabezado.Controls.Add(this.btnCerrarSesion);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 78;
            this.panelEncabezado.TabIndex = 0;
            //
            // picLogo
            //
            this.picLogo.AccessibleDescription = "Identidad visual del sistema Sanar Rural";
            this.picLogo.AccessibleName = "Logo de Sanar Rural";
            this.picLogo.Location = new System.Drawing.Point(20, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(56, 56);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // lblMarca
            //
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = Tema.FuenteMarca;
            this.lblMarca.ForeColor = Tema.AzulOscuro;
            this.lblMarca.Location = new System.Drawing.Point(86, 14);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(148, 30);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "SANAR RURAL";
            //
            // lblDescripcion
            //
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = Tema.FuenteAyuda;
            this.lblDescripcion.ForeColor = Tema.TextoSecundario;
            this.lblDescripcion.Location = new System.Drawing.Point(88, 44);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(184, 15);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Atención médica comunitaria";
            //
            // panelUsuario
            //
            this.panelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUsuario.Controls.Add(this.lblEstadoSesion);
            this.panelUsuario.Controls.Add(this.lblRol);
            this.panelUsuario.Location = new System.Drawing.Point(890, 16);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(190, 46);
            this.panelUsuario.TabIndex = 3;
            //
            // lblEstadoSesion
            //
            this.lblEstadoSesion.AutoSize = true;
            this.lblEstadoSesion.Font = Tema.FuenteAyuda;
            this.lblEstadoSesion.ForeColor = Tema.VerdeOscuro;
            this.lblEstadoSesion.Location = new System.Drawing.Point(0, 4);
            this.lblEstadoSesion.Name = "lblEstadoSesion";
            this.lblEstadoSesion.Size = new System.Drawing.Size(95, 15);
            this.lblEstadoSesion.TabIndex = 0;
            this.lblEstadoSesion.Text = "● Sesión activa";
            //
            // lblRol
            //
            this.lblRol.AccessibleDescription = "Sesión de atención médica";
            this.lblRol.AccessibleName = "Rol actual";
            this.lblRol.AutoSize = true;
            this.lblRol.Font = Tema.FuenteLabelCampo;
            this.lblRol.ForeColor = Tema.TextoPrincipal;
            this.lblRol.Location = new System.Drawing.Point(0, 22);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(126, 17);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Personal médico";
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.AccessibleDescription = "Cerrar la sesión actual de trabajo";
            this.btnCerrarSesion.AccessibleName = "Cerrar sesión";
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = Tema.Superficie;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 1;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = Tema.FuenteLabelCampo;
            this.btnCerrarSesion.ForeColor = Tema.Error;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1096, 20);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 38);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "⎋  Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            //
            // panelNavegacion
            //
            this.panelNavegacion.BackColor = Tema.FondoSecundario;
            this.panelNavegacion.Controls.Add(this.btnPacientes);
            this.panelNavegacion.Controls.Add(this.btnCitas);
            this.panelNavegacion.Controls.Add(this.btnConsultas);
            this.panelNavegacion.Controls.Add(this.btnHistorial);
            this.panelNavegacion.Controls.Add(this.panelIndicador);
            this.panelNavegacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavegacion.Height = 56;
            this.panelNavegacion.TabIndex = 1;
            //
            // btnPacientes
            //
            this.btnPacientes.AccessibleDescription = "Navegar al módulo de Pacientes";
            this.btnPacientes.AccessibleName = "Pacientes";
            this.btnPacientes.BackColor = Tema.Superficie;
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = Tema.FuenteBoton;
            this.btnPacientes.ForeColor = Tema.AzulPrimario;
            this.btnPacientes.Location = new System.Drawing.Point(20, 6);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(140, 44);
            this.btnPacientes.TabIndex = 0;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            //
            // btnCitas
            //
            this.btnCitas.AccessibleDescription = "Navegar al módulo de Citas";
            this.btnCitas.AccessibleName = "Citas";
            this.btnCitas.BackColor = System.Drawing.Color.Transparent;
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = Tema.FuenteLabelCampo;
            this.btnCitas.ForeColor = Tema.TextoSecundario;
            this.btnCitas.Location = new System.Drawing.Point(168, 6);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(120, 44);
            this.btnCitas.TabIndex = 1;
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = false;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            //
            // btnConsultas
            //
            this.btnConsultas.AccessibleDescription = "Módulo de consultas médicas en preparación";
            this.btnConsultas.AccessibleName = "Consultas";
            this.btnConsultas.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultas.FlatAppearance.BorderSize = 0;
            this.btnConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultas.Font = Tema.FuenteLabelCampo;
            this.btnConsultas.ForeColor = Tema.TextoSecundario;
            this.btnConsultas.Location = new System.Drawing.Point(296, 6);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(140, 44);
            this.btnConsultas.TabIndex = 2;
            this.btnConsultas.Text = "Consultas";
            this.btnConsultas.UseVisualStyleBackColor = false;
            this.btnConsultas.Click += new System.EventHandler(this.btnConsultas_Click);
            //
            // btnHistorial
            //
            this.btnHistorial.AccessibleDescription = "Módulo de historial clínico en preparación";
            this.btnHistorial.AccessibleName = "Historial clínico";
            this.btnHistorial.BackColor = System.Drawing.Color.Transparent;
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = Tema.FuenteLabelCampo;
            this.btnHistorial.ForeColor = Tema.TextoSecundario;
            this.btnHistorial.Location = new System.Drawing.Point(444, 6);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(160, 44);
            this.btnHistorial.TabIndex = 3;
            this.btnHistorial.Text = "Historial clínico";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            //
            // panelIndicador
            //
            this.panelIndicador.BackColor = Tema.AzulPrimario;
            this.panelIndicador.Location = new System.Drawing.Point(20, 50);
            this.panelIndicador.Name = "panelIndicador";
            this.panelIndicador.Size = new System.Drawing.Size(140, 3);
            this.panelIndicador.TabIndex = 4;
            //
            // panelContenido
            //
            this.panelContenido.BackColor = Tema.Fondo;
            this.panelContenido.Controls.Add(this.panelPlaceholder);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 134);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1264, 627);
            this.panelContenido.TabIndex = 1;
            //
            // panelPlaceholder
            //
            this.panelPlaceholder.BackColor = Tema.Superficie;
            this.panelPlaceholder.Controls.Add(this.lblPlaceholderBadge);
            this.panelPlaceholder.Controls.Add(this.lblSeccion);
            this.panelPlaceholder.Controls.Add(this.lblContenido);
            this.panelPlaceholder.Location = new System.Drawing.Point(320, 140);
            this.panelPlaceholder.Name = "panelPlaceholder";
            this.panelPlaceholder.Padding = new System.Windows.Forms.Padding(32);
            this.panelPlaceholder.Size = new System.Drawing.Size(620, 220);
            this.panelPlaceholder.TabIndex = 0;
            this.panelPlaceholder.Visible = false;
            //
            // lblPlaceholderBadge
            //
            this.lblPlaceholderBadge.AutoSize = true;
            this.lblPlaceholderBadge.Font = Tema.FuenteAyuda;
            this.lblPlaceholderBadge.ForeColor = Tema.AzulPrimario;
            this.lblPlaceholderBadge.Location = new System.Drawing.Point(32, 28);
            this.lblPlaceholderBadge.Name = "lblPlaceholderBadge";
            this.lblPlaceholderBadge.Size = new System.Drawing.Size(155, 15);
            this.lblPlaceholderBadge.TabIndex = 0;
            this.lblPlaceholderBadge.Text = "MÓDULO EN PREPARACIÓN";
            //
            // lblSeccion
            //
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = Tema.FuenteTitulo;
            this.lblSeccion.ForeColor = Tema.AzulOscuro;
            this.lblSeccion.Location = new System.Drawing.Point(30, 56);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(130, 32);
            this.lblSeccion.TabIndex = 1;
            this.lblSeccion.Text = "Consultas";
            //
            // lblContenido
            //
            this.lblContenido.Font = Tema.FuenteSubtitulo;
            this.lblContenido.ForeColor = Tema.TextoSecundario;
            this.lblContenido.Location = new System.Drawing.Point(32, 102);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(550, 80);
            this.lblContenido.TabIndex = 2;
            this.lblContenido.Text = "Esta sección se incorporará próximamente para la atención integral de consultas clínicas y registro de expedientes.";
            //
            // menuPrincipalMedicos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "menuPrincipalMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Atención médica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.menuPrincipalMedicos_Resize);
            this.panelBarra.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.panelNavegacion.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.panelPlaceholder.ResumeLayout(false);
            this.panelPlaceholder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelBarra;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblEstadoSesion;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel panelIndicador;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelPlaceholder;
        private System.Windows.Forms.Label lblPlaceholderBadge;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblContenido;
    }
}
