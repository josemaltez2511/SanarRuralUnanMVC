using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views
{
    partial class menuPrincipalMedicos
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
            this.panelLineaVerde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnDoctores = new System.Windows.Forms.Button();
            this.btnHospitales = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.panelLineaVerde);
            this.panelCard.Controls.Add(this.lblTitulo);
            this.panelCard.Controls.Add(this.lblSubtitulo);
            this.panelCard.Controls.Add(this.btnPacientes);
            this.panelCard.Controls.Add(this.btnDoctores);
            this.panelCard.Controls.Add(this.btnHospitales);
            this.panelCard.Controls.Add(this.btnCerrarSesion);
            this.panelCard.Location = new System.Drawing.Point(125, 30);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 470);
            this.panelCard.TabIndex = 0;
            // 
            // panelLineaVerde
            // 
            this.panelLineaVerde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(32)))));
            this.panelLineaVerde.Location = new System.Drawing.Point(40, 20);
            this.panelLineaVerde.Name = "panelLineaVerde";
            this.panelLineaVerde.Size = new System.Drawing.Size(6, 45);
            this.panelLineaVerde.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.lblTitulo.Location = new System.Drawing.Point(52, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "SANAR RURAL";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(98)))), ((int)(((byte)(112)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(55, 48);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(198, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Menú Principal - Gestión Médica";
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.Location = new System.Drawing.Point(40, 120);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(420, 60);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "🧑‍⚕️  Módulo de Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnDoctores
            // 
            this.btnDoctores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.btnDoctores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoctores.FlatAppearance.BorderSize = 0;
            this.btnDoctores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctores.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDoctores.ForeColor = System.Drawing.Color.White;
            this.btnDoctores.Location = new System.Drawing.Point(40, 200);
            this.btnDoctores.Name = "btnDoctores";
            this.btnDoctores.Size = new System.Drawing.Size(420, 60);
            this.btnDoctores.TabIndex = 2;
            this.btnDoctores.Text = "👨‍⚕️  Módulo de Doctores";
            this.btnDoctores.UseVisualStyleBackColor = false;
            this.btnDoctores.Click += new System.EventHandler(this.btnDoctores_Click);
            // 
            // btnHospitales
            // 
            this.btnHospitales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(108)))), ((int)(((byte)(168)))));
            this.btnHospitales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHospitales.FlatAppearance.BorderSize = 0;
            this.btnHospitales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHospitales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHospitales.ForeColor = System.Drawing.Color.White;
            this.btnHospitales.Location = new System.Drawing.Point(40, 280);
            this.btnHospitales.Name = "btnHospitales";
            this.btnHospitales.Size = new System.Drawing.Size(420, 60);
            this.btnHospitales.TabIndex = 3;
            this.btnHospitales.Text = "🏥  Módulo de Hospitales";
            this.btnHospitales.UseVisualStyleBackColor = false;
            this.btnHospitales.Click += new System.EventHandler(this.btnHospitales_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(40, 380);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(420, 50);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "🚪  Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // menuPrincipalMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(750, 530);
            this.Controls.Add(this.panelCard);
            this.Name = "menuPrincipalMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Menú Principal";
            this.Load += new System.EventHandler(this.menuPrincipal_Load);
            this.Resize += new System.EventHandler(this.menuPrincipal_Resize);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelLineaVerde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnDoctores;
        private System.Windows.Forms.Button btnHospitales;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}