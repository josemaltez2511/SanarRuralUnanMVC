using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Hospitales
{
    partial class crearHospital
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHero = new System.Windows.Forms.Panel();
            this.picLogoHero = new System.Windows.Forms.PictureBox();
            this.lblBrandBadge = new System.Windows.Forms.Label();
            this.lblHeroTitulo = new System.Windows.Forms.Label();
            this.lblHeroSubtitulo = new System.Windows.Forms.Label();
            this.panelHeroBloque1 = new System.Windows.Forms.Panel();
            this.lblHeroIcono1 = new System.Windows.Forms.Label();
            this.lblHeroTitulo1 = new System.Windows.Forms.Label();
            this.lblHeroDesc1 = new System.Windows.Forms.Label();
            this.panelHeroBloque2 = new System.Windows.Forms.Panel();
            this.lblHeroIcono2 = new System.Windows.Forms.Label();
            this.lblHeroTitulo2 = new System.Windows.Forms.Label();
            this.lblHeroDesc2 = new System.Windows.Forms.Label();
            this.panelHeroBloque3 = new System.Windows.Forms.Panel();
            this.lblHeroIcono3 = new System.Windows.Forms.Label();
            this.lblHeroTitulo3 = new System.Windows.Forms.Label();
            this.lblHeroDesc3 = new System.Windows.Forms.Label();
            this.panelLema = new System.Windows.Forms.Panel();
            this.lblLemaTexto = new System.Windows.Forms.Label();
            this.panelFormContenedor = new System.Windows.Forms.Panel();
            this.panelScroll = new System.Windows.Forms.Panel();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.lblIconoHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.cardUbicacion = new System.Windows.Forms.Panel();
            this.lblIconoUbicacion = new System.Windows.Forms.Label();
            this.lblTituloUbicacion = new System.Windows.Forms.Label();
            this.lblSubtituloUbicacion = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.cardDatos = new System.Windows.Forms.Panel();
            this.lblIconoDatos = new System.Windows.Forms.Label();
            this.lblTituloDatos = new System.Windows.Forms.Label();
            this.lblSubtituloDatos = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.panelHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).BeginInit();
            this.panelHeroBloque1.SuspendLayout();
            this.panelHeroBloque2.SuspendLayout();
            this.panelHeroBloque3.SuspendLayout();
            this.panelLema.SuspendLayout();
            this.panelFormContenedor.SuspendLayout();
            this.panelScroll.SuspendLayout();
            this.cardHeader.SuspendLayout();
            this.cardUbicacion.SuspendLayout();
            this.cardDatos.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHero
            //
            this.panelHero.BackColor = Tema.AzulOscuro;
            this.panelHero.Controls.Add(this.picLogoHero);
            this.panelHero.Controls.Add(this.lblBrandBadge);
            this.panelHero.Controls.Add(this.lblHeroTitulo);
            this.panelHero.Controls.Add(this.lblHeroSubtitulo);
            this.panelHero.Controls.Add(this.panelHeroBloque1);
            this.panelHero.Controls.Add(this.panelHeroBloque2);
            this.panelHero.Controls.Add(this.panelHeroBloque3);
            this.panelHero.Controls.Add(this.panelLema);
            this.panelHero.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHero.Location = new System.Drawing.Point(0, 0);
            this.panelHero.Name = "panelHero";
            this.panelHero.Padding = new System.Windows.Forms.Padding(24);
            this.panelHero.Size = new System.Drawing.Size(275, 680);
            this.panelHero.TabIndex = 0;
            //
            // picLogoHero
            //
            this.picLogoHero.BackColor = System.Drawing.Color.Transparent;
            this.picLogoHero.Location = new System.Drawing.Point(24, 28);
            this.picLogoHero.Name = "picLogoHero";
            this.picLogoHero.Size = new System.Drawing.Size(56, 56);
            this.picLogoHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoHero.TabIndex = 0;
            this.picLogoHero.TabStop = false;
            //
            // lblBrandBadge
            //
            this.lblBrandBadge.AutoSize = true;
            this.lblBrandBadge.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandBadge.Font = new System.Drawing.Font(Tema.FamiliaFuente, 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBrandBadge.ForeColor = Tema.VerdeAcento;
            this.lblBrandBadge.Location = new System.Drawing.Point(24, 96);
            this.lblBrandBadge.Name = "lblBrandBadge";
            this.lblBrandBadge.Size = new System.Drawing.Size(95, 15);
            this.lblBrandBadge.TabIndex = 1;
            this.lblBrandBadge.Text = "SANAR RURAL";
            //
            // lblHeroTitulo
            //
            this.lblHeroTitulo.AutoSize = true;
            this.lblHeroTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblHeroTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitulo.Location = new System.Drawing.Point(22, 118);
            this.lblHeroTitulo.Name = "lblHeroTitulo";
            this.lblHeroTitulo.Size = new System.Drawing.Size(217, 31);
            this.lblHeroTitulo.TabIndex = 2;
            this.lblHeroTitulo.Text = "Red Hospitalaria";
            //
            // lblHeroSubtitulo
            //
            this.lblHeroSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblHeroSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.lblHeroSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(225)))), ((int)(((byte)(245)))));
            this.lblHeroSubtitulo.Location = new System.Drawing.Point(24, 156);
            this.lblHeroSubtitulo.Name = "lblHeroSubtitulo";
            this.lblHeroSubtitulo.Size = new System.Drawing.Size(227, 52);
            this.lblHeroSubtitulo.TabIndex = 3;
            this.lblHeroSubtitulo.Text = "Gestión de centros hospitalarios y sedes de atención médica comunitaria.";
            //
            // panelHeroBloque1
            //
            this.panelHeroBloque1.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroBloque1.Controls.Add(this.lblHeroIcono1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroTitulo1);
            this.panelHeroBloque1.Controls.Add(this.lblHeroDesc1);
            this.panelHeroBloque1.Location = new System.Drawing.Point(20, 225);
            this.panelHeroBloque1.Name = "panelHeroBloque1";
            this.panelHeroBloque1.Size = new System.Drawing.Size(235, 62);
            this.panelHeroBloque1.TabIndex = 4;
            //
            // lblHeroIcono1
            //
            this.lblHeroIcono1.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblHeroIcono1.ForeColor = System.Drawing.Color.White;
            this.lblHeroIcono1.Location = new System.Drawing.Point(4, 8);
            this.lblHeroIcono1.Name = "lblHeroIcono1";
            this.lblHeroIcono1.Size = new System.Drawing.Size(32, 32);
            this.lblHeroIcono1.TabIndex = 0;
            this.lblHeroIcono1.Text = "📍";
            this.lblHeroIcono1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo1
            //
            this.lblHeroTitulo1.AutoSize = true;
            this.lblHeroTitulo1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo1.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitulo1.Location = new System.Drawing.Point(40, 6);
            this.lblHeroTitulo1.Name = "lblHeroTitulo1";
            this.lblHeroTitulo1.Size = new System.Drawing.Size(149, 19);
            this.lblHeroTitulo1.TabIndex = 1;
            this.lblHeroTitulo1.Text = "Cobertura Territorial";
            //
            // lblHeroDesc1
            //
            this.lblHeroDesc1.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8F);
            this.lblHeroDesc1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.lblHeroDesc1.Location = new System.Drawing.Point(40, 26);
            this.lblHeroDesc1.Name = "lblHeroDesc1";
            this.lblHeroDesc1.Size = new System.Drawing.Size(185, 30);
            this.lblHeroDesc1.TabIndex = 2;
            this.lblHeroDesc1.Text = "Sedes articuladas por departamento y municipio.";
            //
            // panelHeroBloque2
            //
            this.panelHeroBloque2.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroBloque2.Controls.Add(this.lblHeroIcono2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroTitulo2);
            this.panelHeroBloque2.Controls.Add(this.lblHeroDesc2);
            this.panelHeroBloque2.Location = new System.Drawing.Point(20, 298);
            this.panelHeroBloque2.Name = "panelHeroBloque2";
            this.panelHeroBloque2.Size = new System.Drawing.Size(235, 62);
            this.panelHeroBloque2.TabIndex = 5;
            //
            // lblHeroIcono2
            //
            this.lblHeroIcono2.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblHeroIcono2.ForeColor = System.Drawing.Color.White;
            this.lblHeroIcono2.Location = new System.Drawing.Point(4, 8);
            this.lblHeroIcono2.Name = "lblHeroIcono2";
            this.lblHeroIcono2.Size = new System.Drawing.Size(32, 32);
            this.lblHeroIcono2.TabIndex = 0;
            this.lblHeroIcono2.Text = "🏥";
            this.lblHeroIcono2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo2
            //
            this.lblHeroTitulo2.AutoSize = true;
            this.lblHeroTitulo2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo2.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitulo2.Location = new System.Drawing.Point(40, 6);
            this.lblHeroTitulo2.Name = "lblHeroTitulo2";
            this.lblHeroTitulo2.Size = new System.Drawing.Size(155, 19);
            this.lblHeroTitulo2.TabIndex = 1;
            this.lblHeroTitulo2.Text = "Capacidad Asistencial";
            //
            // lblHeroDesc2
            //
            this.lblHeroDesc2.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8F);
            this.lblHeroDesc2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.lblHeroDesc2.Location = new System.Drawing.Point(40, 26);
            this.lblHeroDesc2.Name = "lblHeroDesc2";
            this.lblHeroDesc2.Size = new System.Drawing.Size(185, 30);
            this.lblHeroDesc2.TabIndex = 2;
            this.lblHeroDesc2.Text = "Asignación de especialidades y doctores tratantes.";
            //
            // panelHeroBloque3
            //
            this.panelHeroBloque3.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroBloque3.Controls.Add(this.lblHeroIcono3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroTitulo3);
            this.panelHeroBloque3.Controls.Add(this.lblHeroDesc3);
            this.panelHeroBloque3.Location = new System.Drawing.Point(20, 371);
            this.panelHeroBloque3.Name = "panelHeroBloque3";
            this.panelHeroBloque3.Size = new System.Drawing.Size(235, 62);
            this.panelHeroBloque3.TabIndex = 6;
            //
            // lblHeroIcono3
            //
            this.lblHeroIcono3.Font = new System.Drawing.Font("Segoe UI Emoji", 14F);
            this.lblHeroIcono3.ForeColor = System.Drawing.Color.White;
            this.lblHeroIcono3.Location = new System.Drawing.Point(4, 8);
            this.lblHeroIcono3.Name = "lblHeroIcono3";
            this.lblHeroIcono3.Size = new System.Drawing.Size(32, 32);
            this.lblHeroIcono3.TabIndex = 0;
            this.lblHeroIcono3.Text = "🤝";
            this.lblHeroIcono3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitulo3
            //
            this.lblHeroTitulo3.AutoSize = true;
            this.lblHeroTitulo3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitulo3.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitulo3.Location = new System.Drawing.Point(40, 6);
            this.lblHeroTitulo3.Name = "lblHeroTitulo3";
            this.lblHeroTitulo3.Size = new System.Drawing.Size(125, 19);
            this.lblHeroTitulo3.TabIndex = 1;
            this.lblHeroTitulo3.Text = "Equidad en Salud";
            //
            // lblHeroDesc3
            //
            this.lblHeroDesc3.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8F);
            this.lblHeroDesc3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.lblHeroDesc3.Location = new System.Drawing.Point(40, 26);
            this.lblHeroDesc3.Name = "lblHeroDesc3";
            this.lblHeroDesc3.Size = new System.Drawing.Size(185, 30);
            this.lblHeroDesc3.TabIndex = 2;
            this.lblHeroDesc3.Text = "Acceso médico digno para familias del campo.";
            //
            // panelLema
            //
            this.panelLema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLema.Controls.Add(this.lblLemaTexto);
            this.panelLema.Location = new System.Drawing.Point(20, 580);
            this.panelLema.Name = "panelLema";
            this.panelLema.Padding = new System.Windows.Forms.Padding(12);
            this.panelLema.Size = new System.Drawing.Size(235, 75);
            this.panelLema.TabIndex = 7;
            //
            // lblLemaTexto
            //
            this.lblLemaTexto.BackColor = System.Drawing.Color.Transparent;
            this.lblLemaTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLemaTexto.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F, System.Drawing.FontStyle.Italic);
            this.lblLemaTexto.ForeColor = System.Drawing.Color.White;
            this.lblLemaTexto.Location = new System.Drawing.Point(12, 12);
            this.lblLemaTexto.Name = "lblLemaTexto";
            this.lblLemaTexto.Size = new System.Drawing.Size(211, 51);
            this.lblLemaTexto.TabIndex = 0;
            this.lblLemaTexto.Text = "\"Conectando la salud con nuestras comunidades rurales.\"";
            this.lblLemaTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelFormContenedor
            //
            this.panelFormContenedor.BackColor = Tema.Fondo;
            this.panelFormContenedor.Controls.Add(this.panelScroll);
            this.panelFormContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormContenedor.Location = new System.Drawing.Point(275, 0);
            this.panelFormContenedor.Name = "panelFormContenedor";
            this.panelFormContenedor.Size = new System.Drawing.Size(705, 680);
            this.panelFormContenedor.TabIndex = 1;
            //
            // panelScroll
            //
            this.panelScroll.AutoScroll = true;
            this.panelScroll.BackColor = Tema.Fondo;
            this.panelScroll.Controls.Add(this.cardHeader);
            this.panelScroll.Controls.Add(this.cardUbicacion);
            this.panelScroll.Controls.Add(this.cardDatos);
            this.panelScroll.Controls.Add(this.panelAcciones);
            this.panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScroll.Location = new System.Drawing.Point(0, 0);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Padding = new System.Windows.Forms.Padding(24, 20, 24, 24);
            this.panelScroll.Size = new System.Drawing.Size(705, 680);
            this.panelScroll.TabIndex = 0;
            //
            // cardHeader
            //
            this.cardHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardHeader.BackColor = Tema.Superficie;
            this.cardHeader.Controls.Add(this.lblIconoHeader);
            this.cardHeader.Controls.Add(this.lblTitulo);
            this.cardHeader.Controls.Add(this.lblSubtitulo);
            this.cardHeader.Location = new System.Drawing.Point(24, 20);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.cardHeader.Size = new System.Drawing.Size(657, 72);
            this.cardHeader.TabIndex = 0;
            //
            // lblIconoHeader
            //
            this.lblIconoHeader.Font = new System.Drawing.Font("Segoe UI Emoji", 16F);
            this.lblIconoHeader.ForeColor = Tema.AzulPrimario;
            this.lblIconoHeader.Location = new System.Drawing.Point(14, 14);
            this.lblIconoHeader.Name = "lblIconoHeader";
            this.lblIconoHeader.Size = new System.Drawing.Size(42, 42);
            this.lblIconoHeader.TabIndex = 0;
            this.lblIconoHeader.Text = "🏥";
            this.lblIconoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulPrimario;
            this.lblTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(183, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nuevo Hospital";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(64, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(450, 16);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Registre los datos de la sede hospitalaria para habilitar la atención médica.";
            //
            // cardUbicacion
            //
            this.cardUbicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardUbicacion.BackColor = Tema.Superficie;
            this.cardUbicacion.Controls.Add(this.lblIconoUbicacion);
            this.cardUbicacion.Controls.Add(this.lblTituloUbicacion);
            this.cardUbicacion.Controls.Add(this.lblSubtituloUbicacion);
            this.cardUbicacion.Controls.Add(this.lblDepartamento);
            this.cardUbicacion.Controls.Add(this.cmbDepartamento);
            this.cardUbicacion.Controls.Add(this.lblMunicipio);
            this.cardUbicacion.Controls.Add(this.cmbMunicipio);
            this.cardUbicacion.Location = new System.Drawing.Point(24, 104);
            this.cardUbicacion.Name = "cardUbicacion";
            this.cardUbicacion.Padding = new System.Windows.Forms.Padding(20);
            this.cardUbicacion.Size = new System.Drawing.Size(657, 145);
            this.cardUbicacion.TabIndex = 1;
            //
            // lblIconoUbicacion
            //
            this.lblIconoUbicacion.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblIconoUbicacion.Location = new System.Drawing.Point(16, 16);
            this.lblIconoUbicacion.Name = "lblIconoUbicacion";
            this.lblIconoUbicacion.Size = new System.Drawing.Size(26, 26);
            this.lblIconoUbicacion.TabIndex = 0;
            this.lblIconoUbicacion.Text = "📍";
            //
            // lblTituloUbicacion
            //
            this.lblTituloUbicacion.AutoSize = true;
            this.lblTituloUbicacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloUbicacion.ForeColor = Tema.TextoPrincipal;
            this.lblTituloUbicacion.Location = new System.Drawing.Point(44, 16);
            this.lblTituloUbicacion.Name = "lblTituloUbicacion";
            this.lblTituloUbicacion.Size = new System.Drawing.Size(183, 21);
            this.lblTituloUbicacion.TabIndex = 1;
            this.lblTituloUbicacion.Text = "Ubicación Geográfica";
            //
            // lblSubtituloUbicacion
            //
            this.lblSubtituloUbicacion.AutoSize = true;
            this.lblSubtituloUbicacion.Font = Tema.FuenteAyuda;
            this.lblSubtituloUbicacion.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloUbicacion.Location = new System.Drawing.Point(46, 38);
            this.lblSubtituloUbicacion.Name = "lblSubtituloUbicacion";
            this.lblSubtituloUbicacion.Size = new System.Drawing.Size(350, 16);
            this.lblSubtituloUbicacion.TabIndex = 2;
            this.lblSubtituloUbicacion.Text = "Jurisdicción departamental y municipal de la instalación";
            //
            // lblDepartamento
            //
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = Tema.FuenteLabelCampo;
            this.lblDepartamento.ForeColor = Tema.TextoPrincipal;
            this.lblDepartamento.Location = new System.Drawing.Point(20, 68);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(123, 19);
            this.lblDepartamento.TabIndex = 3;
            this.lblDepartamento.Text = "Departamento *";
            //
            // cmbDepartamento
            //
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = Tema.FuenteInput;
            this.cmbDepartamento.Location = new System.Drawing.Point(20, 92);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(295, 27);
            this.cmbDepartamento.TabIndex = 4;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            //
            // lblMunicipio
            //
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = Tema.FuenteLabelCampo;
            this.lblMunicipio.ForeColor = Tema.TextoPrincipal;
            this.lblMunicipio.Location = new System.Drawing.Point(335, 68);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(89, 19);
            this.lblMunicipio.TabIndex = 5;
            this.lblMunicipio.Text = "Municipio *";
            //
            // cmbMunicipio
            //
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Font = Tema.FuenteInput;
            this.cmbMunicipio.Location = new System.Drawing.Point(335, 92);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(295, 27);
            this.cmbMunicipio.TabIndex = 6;
            //
            // cardDatos
            //
            this.cardDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardDatos.BackColor = Tema.Superficie;
            this.cardDatos.Controls.Add(this.lblIconoDatos);
            this.cardDatos.Controls.Add(this.lblTituloDatos);
            this.cardDatos.Controls.Add(this.lblSubtituloDatos);
            this.cardDatos.Controls.Add(this.lblNombre);
            this.cardDatos.Controls.Add(this.txtNombre);
            this.cardDatos.Controls.Add(this.lblTelefono);
            this.cardDatos.Controls.Add(this.txtTelefono);
            this.cardDatos.Controls.Add(this.lblDireccion);
            this.cardDatos.Controls.Add(this.txtDireccion);
            this.cardDatos.Location = new System.Drawing.Point(24, 261);
            this.cardDatos.Name = "cardDatos";
            this.cardDatos.Padding = new System.Windows.Forms.Padding(20);
            this.cardDatos.Size = new System.Drawing.Size(657, 260);
            this.cardDatos.TabIndex = 2;
            //
            // lblIconoDatos
            //
            this.lblIconoDatos.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblIconoDatos.Location = new System.Drawing.Point(16, 16);
            this.lblIconoDatos.Name = "lblIconoDatos";
            this.lblIconoDatos.Size = new System.Drawing.Size(26, 26);
            this.lblIconoDatos.TabIndex = 0;
            this.lblIconoDatos.Text = "🏢";
            //
            // lblTituloDatos
            //
            this.lblTituloDatos.AutoSize = true;
            this.lblTituloDatos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloDatos.ForeColor = Tema.TextoPrincipal;
            this.lblTituloDatos.Location = new System.Drawing.Point(44, 16);
            this.lblTituloDatos.Name = "lblTituloDatos";
            this.lblTituloDatos.Size = new System.Drawing.Size(193, 21);
            this.lblTituloDatos.TabIndex = 1;
            this.lblTituloDatos.Text = "Información de la Sede";
            //
            // lblSubtituloDatos
            //
            this.lblSubtituloDatos.AutoSize = true;
            this.lblSubtituloDatos.Font = Tema.FuenteAyuda;
            this.lblSubtituloDatos.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloDatos.Location = new System.Drawing.Point(46, 38);
            this.lblSubtituloDatos.Name = "lblSubtituloDatos";
            this.lblSubtituloDatos.Size = new System.Drawing.Size(360, 16);
            this.lblSubtituloDatos.TabIndex = 2;
            this.lblSubtituloDatos.Text = "Nombre institucional, teléfono de contacto y dirección física";
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = Tema.FuenteLabelCampo;
            this.lblNombre.ForeColor = Tema.TextoPrincipal;
            this.lblNombre.Location = new System.Drawing.Point(20, 68);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(157, 19);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre del Hospital *";
            //
            // txtNombre
            //
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = Tema.FuenteInput;
            this.txtNombre.Location = new System.Drawing.Point(20, 92);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(610, 27);
            this.txtNombre.TabIndex = 4;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = Tema.FuenteLabelCampo;
            this.lblTelefono.ForeColor = Tema.TextoPrincipal;
            this.lblTelefono.Location = new System.Drawing.Point(20, 130);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(149, 19);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono de Contacto";
            //
            // txtTelefono
            //
            this.txtTelefono.Font = Tema.FuenteInput;
            this.txtTelefono.Location = new System.Drawing.Point(20, 154);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(295, 27);
            this.txtTelefono.TabIndex = 6;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = Tema.FuenteLabelCampo;
            this.lblDireccion.ForeColor = Tema.TextoPrincipal;
            this.lblDireccion.Location = new System.Drawing.Point(20, 192);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(111, 19);
            this.lblDireccion.TabIndex = 7;
            this.lblDireccion.Text = "Dirección Física";
            //
            // txtDireccion
            //
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.Font = Tema.FuenteInput;
            this.txtDireccion.Location = new System.Drawing.Point(20, 216);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(610, 27);
            this.txtDireccion.TabIndex = 8;
            //
            // panelAcciones
            //
            this.panelAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAcciones.BackColor = System.Drawing.Color.Transparent;
            this.panelAcciones.Controls.Add(this.btnGuardar);
            this.panelAcciones.Controls.Add(this.btnCancelar);
            this.panelAcciones.Controls.Add(this.lnkVolver);
            this.panelAcciones.Location = new System.Drawing.Point(24, 532);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(657, 54);
            this.panelAcciones.TabIndex = 3;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 44);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar Hospital";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = Tema.Superficie;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteBoton;
            this.btnCancelar.ForeColor = Tema.TextoPrincipal;
            this.btnCancelar.Location = new System.Drawing.Point(215, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 44);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.lnkVolver_LinkClicked);
            //
            // lnkVolver
            //
            this.lnkVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = Tema.FuenteSubtitulo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(525, 16);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(123, 19);
            this.lnkVolver.TabIndex = 2;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "← Volver a Sedes";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            //
            // crearHospital
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(980, 680);
            this.Controls.Add(this.panelFormContenedor);
            this.Controls.Add(this.panelHero);
            this.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "crearHospital";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Gestión de Hospital";
            this.Load += new System.EventHandler(this.crearHospital_Load);
            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoHero)).EndInit();
            this.panelHeroBloque1.ResumeLayout(false);
            this.panelHeroBloque1.PerformLayout();
            this.panelHeroBloque2.ResumeLayout(false);
            this.panelHeroBloque2.PerformLayout();
            this.panelHeroBloque3.ResumeLayout(false);
            this.panelHeroBloque3.PerformLayout();
            this.panelLema.ResumeLayout(false);
            this.panelFormContenedor.ResumeLayout(false);
            this.panelScroll.ResumeLayout(false);
            this.cardHeader.ResumeLayout(false);
            this.cardHeader.PerformLayout();
            this.cardUbicacion.ResumeLayout(false);
            this.cardUbicacion.PerformLayout();
            this.cardDatos.ResumeLayout(false);
            this.cardDatos.PerformLayout();
            this.panelAcciones.ResumeLayout(false);
            this.panelAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelHero;
        private System.Windows.Forms.PictureBox picLogoHero;
        private System.Windows.Forms.Label lblBrandBadge;
        private System.Windows.Forms.Label lblHeroTitulo;
        private System.Windows.Forms.Label lblHeroSubtitulo;
        private System.Windows.Forms.Panel panelHeroBloque1;
        private System.Windows.Forms.Label lblHeroIcono1;
        private System.Windows.Forms.Label lblHeroTitulo1;
        private System.Windows.Forms.Label lblHeroDesc1;
        private System.Windows.Forms.Panel panelHeroBloque2;
        private System.Windows.Forms.Label lblHeroIcono2;
        private System.Windows.Forms.Label lblHeroTitulo2;
        private System.Windows.Forms.Label lblHeroDesc2;
        private System.Windows.Forms.Panel panelHeroBloque3;
        private System.Windows.Forms.Label lblHeroIcono3;
        private System.Windows.Forms.Label lblHeroTitulo3;
        private System.Windows.Forms.Label lblHeroDesc3;
        private System.Windows.Forms.Panel panelLema;
        private System.Windows.Forms.Label lblLemaTexto;
        private System.Windows.Forms.Panel panelFormContenedor;
        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.Label lblIconoHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel cardUbicacion;
        private System.Windows.Forms.Label lblIconoUbicacion;
        private System.Windows.Forms.Label lblTituloUbicacion;
        private System.Windows.Forms.Label lblSubtituloUbicacion;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.Panel cardDatos;
        private System.Windows.Forms.Label lblIconoDatos;
        private System.Windows.Forms.Label lblTituloDatos;
        private System.Windows.Forms.Label lblSubtituloDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.LinkLabel lnkVolver;
    }
}
