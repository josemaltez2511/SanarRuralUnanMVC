using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Pacientes
{
    partial class fichaPaciente
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

        private void InitializeComponent()
        {
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblPrefijo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelBadgeEstado = new System.Windows.Forms.Panel();
            this.lblEstadoBadge = new System.Windows.Forms.Label();
            this.btnCerrarTop = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.lblSecDatos = new System.Windows.Forms.Label();
            this.lblNombreT = new System.Windows.Forms.Label();
            this.lblNombreVal = new System.Windows.Forms.Label();
            this.lblCedulaT = new System.Windows.Forms.Label();
            this.lblCedulaVal = new System.Windows.Forms.Label();
            this.lblInssT = new System.Windows.Forms.Label();
            this.lblInssVal = new System.Windows.Forms.Label();
            this.lblNacimientoT = new System.Windows.Forms.Label();
            this.lblNacimientoVal = new System.Windows.Forms.Label();
            this.lblGeneroT = new System.Windows.Forms.Label();
            this.lblGeneroVal = new System.Windows.Forms.Label();
            this.lblTelefonoT = new System.Windows.Forms.Label();
            this.lblTelefonoVal = new System.Windows.Forms.Label();
            this.panelUbicacion = new System.Windows.Forms.Panel();
            this.lblSecUbicacion = new System.Windows.Forms.Label();
            this.lblDeptoT = new System.Windows.Forms.Label();
            this.lblDeptoVal = new System.Windows.Forms.Label();
            this.lblMuniT = new System.Windows.Forms.Label();
            this.lblMuniVal = new System.Windows.Forms.Label();
            this.lblComunidadT = new System.Windows.Forms.Label();
            this.lblComunidadVal = new System.Windows.Forms.Label();
            this.lblDireccionT = new System.Windows.Forms.Label();
            this.lblDireccionVal = new System.Windows.Forms.Label();
            this.panelSalud = new System.Windows.Forms.Panel();
            this.lblSecSalud = new System.Windows.Forms.Label();
            this.lblSangreT = new System.Windows.Forms.Label();
            this.lblSangreVal = new System.Windows.Forms.Label();
            this.lblAlergiasT = new System.Windows.Forms.Label();
            this.lblAlergiasVal = new System.Windows.Forms.Label();
            this.lblAntecedentesT = new System.Windows.Forms.Label();
            this.lblAntecedentesVal = new System.Windows.Forms.Label();
            this.panelContactos = new System.Windows.Forms.Panel();
            this.lblSecContactos = new System.Windows.Forms.Label();
            this.lblContactosAyuda = new System.Windows.Forms.Label();
            this.panelTablaContactos = new System.Windows.Forms.Panel();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.colParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefonoContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedulaContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSinContactos = new System.Windows.Forms.Label();
            this.panelPie = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelBadgeEstado.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelUbicacion.SuspendLayout();
            this.panelSalud.SuspendLayout();
            this.panelContactos.SuspendLayout();
            this.panelTablaContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.panelPie.SuspendLayout();
            this.SuspendLayout();
            //
            // panelEncabezado
            //
            this.panelEncabezado.BackColor = Tema.Superficie;
            this.panelEncabezado.Controls.Add(this.lblPrefijo);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Controls.Add(this.panelBadgeEstado);
            this.panelEncabezado.Controls.Add(this.btnCerrarTop);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 90;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(24, 12, 24, 10);
            this.panelEncabezado.Size = new System.Drawing.Size(1104, 90);
            this.panelEncabezado.TabIndex = 0;
            //
            // lblPrefijo
            //
            this.lblPrefijo.AutoSize = true;
            this.lblPrefijo.Font = Tema.FuenteAyuda;
            this.lblPrefijo.ForeColor = Tema.AzulPrimario;
            this.lblPrefijo.Location = new System.Drawing.Point(22, 10);
            this.lblPrefijo.Name = "lblPrefijo";
            this.lblPrefijo.Size = new System.Drawing.Size(193, 15);
            this.lblPrefijo.TabIndex = 0;
            this.lblPrefijo.Text = "EXPEDIENTE CLÍNICO INTEGRAL";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(20, 26);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nombre del Paciente";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 60);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(235, 20);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Expediente #0 | Cédula: -";
            //
            // panelBadgeEstado
            //
            this.panelBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBadgeEstado.BackColor = Tema.FondoSecundario;
            this.panelBadgeEstado.Controls.Add(this.lblEstadoBadge);
            this.panelBadgeEstado.Location = new System.Drawing.Point(820, 24);
            this.panelBadgeEstado.Name = "panelBadgeEstado";
            this.panelBadgeEstado.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.panelBadgeEstado.Size = new System.Drawing.Size(120, 38);
            this.panelBadgeEstado.TabIndex = 3;
            //
            // lblEstadoBadge
            //
            this.lblEstadoBadge.AutoSize = true;
            this.lblEstadoBadge.Font = Tema.FuenteLabelCampo;
            this.lblEstadoBadge.ForeColor = Tema.VerdeOscuro;
            this.lblEstadoBadge.Location = new System.Drawing.Point(12, 10);
            this.lblEstadoBadge.Name = "lblEstadoBadge";
            this.lblEstadoBadge.Size = new System.Drawing.Size(63, 17);
            this.lblEstadoBadge.TabIndex = 0;
            this.lblEstadoBadge.Text = "● ACTIVO";
            //
            // btnCerrarTop
            //
            this.btnCerrarTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarTop.BackColor = Tema.Superficie;
            this.btnCerrarTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarTop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrarTop.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrarTop.FlatAppearance.BorderSize = 1;
            this.btnCerrarTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarTop.Font = Tema.FuenteLabelCampo;
            this.btnCerrarTop.ForeColor = Tema.TextoSecundario;
            this.btnCerrarTop.Location = new System.Drawing.Point(954, 24);
            this.btnCerrarTop.Name = "btnCerrarTop";
            this.btnCerrarTop.Size = new System.Drawing.Size(124, 38);
            this.btnCerrarTop.TabIndex = 4;
            this.btnCerrarTop.Text = "✕  Cerrar";
            this.btnCerrarTop.UseVisualStyleBackColor = false;
            //
            // panelContenido
            //
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = Tema.Fondo;
            this.panelContenido.Controls.Add(this.panelPie);
            this.panelContenido.Controls.Add(this.panelContactos);
            this.panelContenido.Controls.Add(this.panelSalud);
            this.panelContenido.Controls.Add(this.panelUbicacion);
            this.panelContenido.Controls.Add(this.panelDatos);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 90);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(24, 16, 24, 24);
            this.panelContenido.Size = new System.Drawing.Size(1104, 651);
            this.panelContenido.TabIndex = 1;
            //
            // panelDatos
            //
            this.panelDatos.BackColor = Tema.Superficie;
            this.panelDatos.Controls.Add(this.lblSecDatos);
            this.panelDatos.Controls.Add(this.lblNombreT);
            this.panelDatos.Controls.Add(this.lblNombreVal);
            this.panelDatos.Controls.Add(this.lblCedulaT);
            this.panelDatos.Controls.Add(this.lblCedulaVal);
            this.panelDatos.Controls.Add(this.lblInssT);
            this.panelDatos.Controls.Add(this.lblInssVal);
            this.panelDatos.Controls.Add(this.lblNacimientoT);
            this.panelDatos.Controls.Add(this.lblNacimientoVal);
            this.panelDatos.Controls.Add(this.lblGeneroT);
            this.panelDatos.Controls.Add(this.lblGeneroVal);
            this.panelDatos.Controls.Add(this.lblTelefonoT);
            this.panelDatos.Controls.Add(this.lblTelefonoVal);
            this.panelDatos.Location = new System.Drawing.Point(24, 16);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Padding = new System.Windows.Forms.Padding(20);
            this.panelDatos.Size = new System.Drawing.Size(1036, 170);
            this.panelDatos.TabIndex = 0;
            //
            // lblSecDatos
            //
            this.lblSecDatos.AutoSize = true;
            this.lblSecDatos.Font = Tema.FuenteLabelCampo;
            this.lblSecDatos.ForeColor = Tema.AzulOscuro;
            this.lblSecDatos.Location = new System.Drawing.Point(20, 14);
            this.lblSecDatos.Name = "lblSecDatos";
            this.lblSecDatos.Size = new System.Drawing.Size(161, 17);
            this.lblSecDatos.TabIndex = 0;
            this.lblSecDatos.Text = "1. DATOS PERSONALES";
            //
            // lblNombreT
            //
            this.lblNombreT.AutoSize = true;
            this.lblNombreT.Font = Tema.FuenteAyuda;
            this.lblNombreT.ForeColor = Tema.TextoSecundario;
            this.lblNombreT.Location = new System.Drawing.Point(20, 48);
            this.lblNombreT.Name = "lblNombreT";
            this.lblNombreT.Size = new System.Drawing.Size(111, 15);
            this.lblNombreT.TabIndex = 1;
            this.lblNombreT.Text = "Nombre completo:";
            //
            // lblNombreVal
            //
            this.lblNombreVal.AutoSize = true;
            this.lblNombreVal.Font = Tema.FuenteLabelCampo;
            this.lblNombreVal.ForeColor = Tema.TextoPrincipal;
            this.lblNombreVal.Location = new System.Drawing.Point(20, 68);
            this.lblNombreVal.Name = "lblNombreVal";
            this.lblNombreVal.Size = new System.Drawing.Size(14, 17);
            this.lblNombreVal.TabIndex = 2;
            this.lblNombreVal.Text = "-";
            //
            // lblCedulaT
            //
            this.lblCedulaT.AutoSize = true;
            this.lblCedulaT.Font = Tema.FuenteAyuda;
            this.lblCedulaT.ForeColor = Tema.TextoSecundario;
            this.lblCedulaT.Location = new System.Drawing.Point(20, 102);
            this.lblCedulaT.Name = "lblCedulaT";
            this.lblCedulaT.Size = new System.Drawing.Size(51, 15);
            this.lblCedulaT.TabIndex = 3;
            this.lblCedulaT.Text = "Cédula:";
            //
            // lblCedulaVal
            //
            this.lblCedulaVal.AutoSize = true;
            this.lblCedulaVal.Font = Tema.FuenteLabelCampo;
            this.lblCedulaVal.ForeColor = Tema.TextoPrincipal;
            this.lblCedulaVal.Location = new System.Drawing.Point(20, 122);
            this.lblCedulaVal.Name = "lblCedulaVal";
            this.lblCedulaVal.Size = new System.Drawing.Size(14, 17);
            this.lblCedulaVal.TabIndex = 4;
            this.lblCedulaVal.Text = "-";
            //
            // lblInssT
            //
            this.lblInssT.AutoSize = true;
            this.lblInssT.Font = Tema.FuenteAyuda;
            this.lblInssT.ForeColor = Tema.TextoSecundario;
            this.lblInssT.Location = new System.Drawing.Point(280, 102);
            this.lblInssT.Name = "lblInssT";
            this.lblInssT.Size = new System.Drawing.Size(89, 15);
            this.lblInssT.TabIndex = 5;
            this.lblInssT.Text = "Número INSS:";
            //
            // lblInssVal
            //
            this.lblInssVal.AutoSize = true;
            this.lblInssVal.Font = Tema.FuenteLabelCampo;
            this.lblInssVal.ForeColor = Tema.TextoPrincipal;
            this.lblInssVal.Location = new System.Drawing.Point(280, 122);
            this.lblInssVal.Name = "lblInssVal";
            this.lblInssVal.Size = new System.Drawing.Size(14, 17);
            this.lblInssVal.TabIndex = 6;
            this.lblInssVal.Text = "-";
            //
            // lblNacimientoT
            //
            this.lblNacimientoT.AutoSize = true;
            this.lblNacimientoT.Font = Tema.FuenteAyuda;
            this.lblNacimientoT.ForeColor = Tema.TextoSecundario;
            this.lblNacimientoT.Location = new System.Drawing.Point(540, 48);
            this.lblNacimientoT.Name = "lblNacimientoT";
            this.lblNacimientoT.Size = new System.Drawing.Size(126, 15);
            this.lblNacimientoT.TabIndex = 7;
            this.lblNacimientoT.Text = "Fecha de nacimiento:";
            //
            // lblNacimientoVal
            //
            this.lblNacimientoVal.AutoSize = true;
            this.lblNacimientoVal.Font = Tema.FuenteLabelCampo;
            this.lblNacimientoVal.ForeColor = Tema.TextoPrincipal;
            this.lblNacimientoVal.Location = new System.Drawing.Point(540, 68);
            this.lblNacimientoVal.Name = "lblNacimientoVal";
            this.lblNacimientoVal.Size = new System.Drawing.Size(14, 17);
            this.lblNacimientoVal.TabIndex = 8;
            this.lblNacimientoVal.Text = "-";
            //
            // lblGeneroT
            //
            this.lblGeneroT.AutoSize = true;
            this.lblGeneroT.Font = Tema.FuenteAyuda;
            this.lblGeneroT.ForeColor = Tema.TextoSecundario;
            this.lblGeneroT.Location = new System.Drawing.Point(540, 102);
            this.lblGeneroT.Name = "lblGeneroT";
            this.lblGeneroT.Size = new System.Drawing.Size(51, 15);
            this.lblGeneroT.TabIndex = 9;
            this.lblGeneroT.Text = "Género:";
            //
            // lblGeneroVal
            //
            this.lblGeneroVal.AutoSize = true;
            this.lblGeneroVal.Font = Tema.FuenteLabelCampo;
            this.lblGeneroVal.ForeColor = Tema.TextoPrincipal;
            this.lblGeneroVal.Location = new System.Drawing.Point(540, 122);
            this.lblGeneroVal.Name = "lblGeneroVal";
            this.lblGeneroVal.Size = new System.Drawing.Size(14, 17);
            this.lblGeneroVal.TabIndex = 10;
            this.lblGeneroVal.Text = "-";
            //
            // lblTelefonoT
            //
            this.lblTelefonoT.AutoSize = true;
            this.lblTelefonoT.Font = Tema.FuenteAyuda;
            this.lblTelefonoT.ForeColor = Tema.TextoSecundario;
            this.lblTelefonoT.Location = new System.Drawing.Point(800, 102);
            this.lblTelefonoT.Name = "lblTelefonoT";
            this.lblTelefonoT.Size = new System.Drawing.Size(59, 15);
            this.lblTelefonoT.TabIndex = 11;
            this.lblTelefonoT.Text = "Teléfono:";
            //
            // lblTelefonoVal
            //
            this.lblTelefonoVal.AutoSize = true;
            this.lblTelefonoVal.Font = Tema.FuenteLabelCampo;
            this.lblTelefonoVal.ForeColor = Tema.TextoPrincipal;
            this.lblTelefonoVal.Location = new System.Drawing.Point(800, 122);
            this.lblTelefonoVal.Name = "lblTelefonoVal";
            this.lblTelefonoVal.Size = new System.Drawing.Size(14, 17);
            this.lblTelefonoVal.TabIndex = 12;
            this.lblTelefonoVal.Text = "-";
            //
            // panelUbicacion
            //
            this.panelUbicacion.BackColor = Tema.Superficie;
            this.panelUbicacion.Controls.Add(this.lblSecUbicacion);
            this.panelUbicacion.Controls.Add(this.lblDeptoT);
            this.panelUbicacion.Controls.Add(this.lblDeptoVal);
            this.panelUbicacion.Controls.Add(this.lblMuniT);
            this.panelUbicacion.Controls.Add(this.lblMuniVal);
            this.panelUbicacion.Controls.Add(this.lblComunidadT);
            this.panelUbicacion.Controls.Add(this.lblComunidadVal);
            this.panelUbicacion.Controls.Add(this.lblDireccionT);
            this.panelUbicacion.Controls.Add(this.lblDireccionVal);
            this.panelUbicacion.Location = new System.Drawing.Point(24, 202);
            this.panelUbicacion.Name = "panelUbicacion";
            this.panelUbicacion.Padding = new System.Windows.Forms.Padding(20);
            this.panelUbicacion.Size = new System.Drawing.Size(1036, 140);
            this.panelUbicacion.TabIndex = 1;
            //
            // lblSecUbicacion
            //
            this.lblSecUbicacion.AutoSize = true;
            this.lblSecUbicacion.Font = Tema.FuenteLabelCampo;
            this.lblSecUbicacion.ForeColor = Tema.AzulOscuro;
            this.lblSecUbicacion.Location = new System.Drawing.Point(20, 14);
            this.lblSecUbicacion.Name = "lblSecUbicacion";
            this.lblSecUbicacion.Size = new System.Drawing.Size(189, 17);
            this.lblSecUbicacion.TabIndex = 0;
            this.lblSecUbicacion.Text = "2. UBICACIÓN GEOGRÁFICA";
            //
            // lblDeptoT
            //
            this.lblDeptoT.AutoSize = true;
            this.lblDeptoT.Font = Tema.FuenteAyuda;
            this.lblDeptoT.ForeColor = Tema.TextoSecundario;
            this.lblDeptoT.Location = new System.Drawing.Point(20, 48);
            this.lblDeptoT.Name = "lblDeptoT";
            this.lblDeptoT.Size = new System.Drawing.Size(89, 15);
            this.lblDeptoT.TabIndex = 1;
            this.lblDeptoT.Text = "Departamento:";
            //
            // lblDeptoVal
            //
            this.lblDeptoVal.AutoSize = true;
            this.lblDeptoVal.Font = Tema.FuenteLabelCampo;
            this.lblDeptoVal.ForeColor = Tema.TextoPrincipal;
            this.lblDeptoVal.Location = new System.Drawing.Point(20, 68);
            this.lblDeptoVal.Name = "lblDeptoVal";
            this.lblDeptoVal.Size = new System.Drawing.Size(14, 17);
            this.lblDeptoVal.TabIndex = 2;
            this.lblDeptoVal.Text = "-";
            //
            // lblMuniT
            //
            this.lblMuniT.AutoSize = true;
            this.lblMuniT.Font = Tema.FuenteAyuda;
            this.lblMuniT.ForeColor = Tema.TextoSecundario;
            this.lblMuniT.Location = new System.Drawing.Point(280, 48);
            this.lblMuniT.Name = "lblMuniT";
            this.lblMuniT.Size = new System.Drawing.Size(65, 15);
            this.lblMuniT.TabIndex = 3;
            this.lblMuniT.Text = "Municipio:";
            //
            // lblMuniVal
            //
            this.lblMuniVal.AutoSize = true;
            this.lblMuniVal.Font = Tema.FuenteLabelCampo;
            this.lblMuniVal.ForeColor = Tema.TextoPrincipal;
            this.lblMuniVal.Location = new System.Drawing.Point(280, 68);
            this.lblMuniVal.Name = "lblMuniVal";
            this.lblMuniVal.Size = new System.Drawing.Size(14, 17);
            this.lblMuniVal.TabIndex = 4;
            this.lblMuniVal.Text = "-";
            //
            // lblComunidadT
            //
            this.lblComunidadT.AutoSize = true;
            this.lblComunidadT.Font = Tema.FuenteAyuda;
            this.lblComunidadT.ForeColor = Tema.TextoSecundario;
            this.lblComunidadT.Location = new System.Drawing.Point(540, 48);
            this.lblComunidadT.Name = "lblComunidadT";
            this.lblComunidadT.Size = new System.Drawing.Size(75, 15);
            this.lblComunidadT.TabIndex = 5;
            this.lblComunidadT.Text = "Comunidad:";
            //
            // lblComunidadVal
            //
            this.lblComunidadVal.AutoSize = true;
            this.lblComunidadVal.Font = Tema.FuenteLabelCampo;
            this.lblComunidadVal.ForeColor = Tema.TextoPrincipal;
            this.lblComunidadVal.Location = new System.Drawing.Point(540, 68);
            this.lblComunidadVal.Name = "lblComunidadVal";
            this.lblComunidadVal.Size = new System.Drawing.Size(14, 17);
            this.lblComunidadVal.TabIndex = 6;
            this.lblComunidadVal.Text = "-";
            //
            // lblDireccionT
            //
            this.lblDireccionT.AutoSize = true;
            this.lblDireccionT.Font = Tema.FuenteAyuda;
            this.lblDireccionT.ForeColor = Tema.TextoSecundario;
            this.lblDireccionT.Location = new System.Drawing.Point(20, 94);
            this.lblDireccionT.Name = "lblDireccionT";
            this.lblDireccionT.Size = new System.Drawing.Size(100, 15);
            this.lblDireccionT.TabIndex = 7;
            this.lblDireccionT.Text = "Dirección exacta:";
            //
            // lblDireccionVal
            //
            this.lblDireccionVal.AutoSize = true;
            this.lblDireccionVal.Font = Tema.FuenteLabelCampo;
            this.lblDireccionVal.ForeColor = Tema.TextoPrincipal;
            this.lblDireccionVal.Location = new System.Drawing.Point(130, 94);
            this.lblDireccionVal.Name = "lblDireccionVal";
            this.lblDireccionVal.Size = new System.Drawing.Size(14, 17);
            this.lblDireccionVal.TabIndex = 8;
            this.lblDireccionVal.Text = "-";
            //
            // panelSalud
            //
            this.panelSalud.BackColor = Tema.Superficie;
            this.panelSalud.Controls.Add(this.lblSecSalud);
            this.panelSalud.Controls.Add(this.lblSangreT);
            this.panelSalud.Controls.Add(this.lblSangreVal);
            this.panelSalud.Controls.Add(this.lblAlergiasT);
            this.panelSalud.Controls.Add(this.lblAlergiasVal);
            this.panelSalud.Controls.Add(this.lblAntecedentesT);
            this.panelSalud.Controls.Add(this.lblAntecedentesVal);
            this.panelSalud.Location = new System.Drawing.Point(24, 358);
            this.panelSalud.Name = "panelSalud";
            this.panelSalud.Padding = new System.Windows.Forms.Padding(20);
            this.panelSalud.Size = new System.Drawing.Size(1036, 140);
            this.panelSalud.TabIndex = 2;
            //
            // lblSecSalud
            //
            this.lblSecSalud.AutoSize = true;
            this.lblSecSalud.Font = Tema.FuenteLabelCampo;
            this.lblSecSalud.ForeColor = Tema.AzulOscuro;
            this.lblSecSalud.Location = new System.Drawing.Point(20, 14);
            this.lblSecSalud.Name = "lblSecSalud";
            this.lblSecSalud.Size = new System.Drawing.Size(232, 17);
            this.lblSecSalud.TabIndex = 0;
            this.lblSecSalud.Text = "3. INFORMACIÓN CLÍNICA INICIAL";
            //
            // lblSangreT
            //
            this.lblSangreT.AutoSize = true;
            this.lblSangreT.Font = Tema.FuenteAyuda;
            this.lblSangreT.ForeColor = Tema.TextoSecundario;
            this.lblSangreT.Location = new System.Drawing.Point(20, 48);
            this.lblSangreT.Name = "lblSangreT";
            this.lblSangreT.Size = new System.Drawing.Size(91, 15);
            this.lblSangreT.TabIndex = 1;
            this.lblSangreT.Text = "Tipo de sangre:";
            //
            // lblSangreVal
            //
            this.lblSangreVal.AutoSize = true;
            this.lblSangreVal.Font = Tema.FuenteBoton;
            this.lblSangreVal.ForeColor = Tema.AzulPrimario;
            this.lblSangreVal.Location = new System.Drawing.Point(20, 68);
            this.lblSangreVal.Name = "lblSangreVal";
            this.lblSangreVal.Size = new System.Drawing.Size(15, 19);
            this.lblSangreVal.TabIndex = 2;
            this.lblSangreVal.Text = "-";
            //
            // lblAlergiasT
            //
            this.lblAlergiasT.AutoSize = true;
            this.lblAlergiasT.Font = Tema.FuenteAyuda;
            this.lblAlergiasT.ForeColor = Tema.TextoSecundario;
            this.lblAlergiasT.Location = new System.Drawing.Point(200, 48);
            this.lblAlergiasT.Name = "lblAlergiasT";
            this.lblAlergiasT.Size = new System.Drawing.Size(117, 15);
            this.lblAlergiasT.TabIndex = 3;
            this.lblAlergiasT.Text = "Alergias conocidas:";
            //
            // lblAlergiasVal
            //
            this.lblAlergiasVal.Font = Tema.FuenteLabelCampo;
            this.lblAlergiasVal.ForeColor = Tema.TextoPrincipal;
            this.lblAlergiasVal.Location = new System.Drawing.Point(200, 68);
            this.lblAlergiasVal.Name = "lblAlergiasVal";
            this.lblAlergiasVal.Size = new System.Drawing.Size(350, 50);
            this.lblAlergiasVal.TabIndex = 4;
            this.lblAlergiasVal.Text = "Ninguna conocida";
            //
            // lblAntecedentesT
            //
            this.lblAntecedentesT.AutoSize = true;
            this.lblAntecedentesT.Font = Tema.FuenteAyuda;
            this.lblAntecedentesT.ForeColor = Tema.TextoSecundario;
            this.lblAntecedentesT.Location = new System.Drawing.Point(580, 48);
            this.lblAntecedentesT.Name = "lblAntecedentesT";
            this.lblAntecedentesT.Size = new System.Drawing.Size(134, 15);
            this.lblAntecedentesT.TabIndex = 5;
            this.lblAntecedentesT.Text = "Antecedentes médicos:";
            //
            // lblAntecedentesVal
            //
            this.lblAntecedentesVal.Font = Tema.FuenteLabelCampo;
            this.lblAntecedentesVal.ForeColor = Tema.TextoPrincipal;
            this.lblAntecedentesVal.Location = new System.Drawing.Point(580, 68);
            this.lblAntecedentesVal.Name = "lblAntecedentesVal";
            this.lblAntecedentesVal.Size = new System.Drawing.Size(430, 50);
            this.lblAntecedentesVal.TabIndex = 6;
            this.lblAntecedentesVal.Text = "Ninguno registrado";
            //
            // panelContactos
            //
            this.panelContactos.BackColor = Tema.Superficie;
            this.panelContactos.Controls.Add(this.lblSecContactos);
            this.panelContactos.Controls.Add(this.lblContactosAyuda);
            this.panelContactos.Controls.Add(this.panelTablaContactos);
            this.panelContactos.Location = new System.Drawing.Point(24, 514);
            this.panelContactos.Name = "panelContactos";
            this.panelContactos.Padding = new System.Windows.Forms.Padding(20);
            this.panelContactos.Size = new System.Drawing.Size(1036, 210);
            this.panelContactos.TabIndex = 3;
            //
            // lblSecContactos
            //
            this.lblSecContactos.AutoSize = true;
            this.lblSecContactos.Font = Tema.FuenteLabelCampo;
            this.lblSecContactos.ForeColor = Tema.AzulOscuro;
            this.lblSecContactos.Location = new System.Drawing.Point(20, 14);
            this.lblSecContactos.Name = "lblSecContactos";
            this.lblSecContactos.Size = new System.Drawing.Size(239, 17);
            this.lblSecContactos.TabIndex = 0;
            this.lblSecContactos.Text = "4. CONTACTOS DE EMERGENCIA";
            //
            // lblContactosAyuda
            //
            this.lblContactosAyuda.AutoSize = true;
            this.lblContactosAyuda.Font = Tema.FuenteAyuda;
            this.lblContactosAyuda.ForeColor = Tema.TextoSecundario;
            this.lblContactosAyuda.Location = new System.Drawing.Point(22, 36);
            this.lblContactosAyuda.Name = "lblContactosAyuda";
            this.lblContactosAyuda.Size = new System.Drawing.Size(358, 15);
            this.lblContactosAyuda.TabIndex = 1;
            this.lblContactosAyuda.Text = "Personas de confianza registradas para contactar en emergencias.";
            //
            // panelTablaContactos
            //
            this.panelTablaContactos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTablaContactos.BackColor = Tema.Borde;
            this.panelTablaContactos.Controls.Add(this.dgvContactos);
            this.panelTablaContactos.Controls.Add(this.lblSinContactos);
            this.panelTablaContactos.Location = new System.Drawing.Point(20, 58);
            this.panelTablaContactos.Name = "panelTablaContactos";
            this.panelTablaContactos.Padding = new System.Windows.Forms.Padding(1);
            this.panelTablaContactos.Size = new System.Drawing.Size(996, 134);
            this.panelTablaContactos.TabIndex = 2;
            //
            // dgvContactos
            //
            this.dgvContactos.BackgroundColor = Tema.Superficie;
            this.dgvContactos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colParentesco,
            this.colNombreContacto,
            this.colTelefonoContacto,
            this.colCedulaContacto});
            this.dgvContactos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContactos.Location = new System.Drawing.Point(1, 1);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.Size = new System.Drawing.Size(994, 132);
            this.dgvContactos.TabIndex = 0;
            //
            // colParentesco
            //
            this.colParentesco.HeaderText = "Parentesco";
            this.colParentesco.Name = "colParentesco";
            //
            // colNombreContacto
            //
            this.colNombreContacto.HeaderText = "Nombre completo";
            this.colNombreContacto.Name = "colNombreContacto";
            //
            // colTelefonoContacto
            //
            this.colTelefonoContacto.HeaderText = "Teléfono";
            this.colTelefonoContacto.Name = "colTelefonoContacto";
            //
            // colCedulaContacto
            //
            this.colCedulaContacto.HeaderText = "Cédula";
            this.colCedulaContacto.Name = "colCedulaContacto";
            //
            // lblSinContactos
            //
            this.lblSinContactos.BackColor = Tema.FondoSecundario;
            this.lblSinContactos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSinContactos.Font = Tema.FuenteCuerpo;
            this.lblSinContactos.ForeColor = Tema.TextoSecundario;
            this.lblSinContactos.Location = new System.Drawing.Point(1, 1);
            this.lblSinContactos.Name = "lblSinContactos";
            this.lblSinContactos.Size = new System.Drawing.Size(994, 132);
            this.lblSinContactos.TabIndex = 1;
            this.lblSinContactos.Text = "No hay contactos de emergencia registrados para este paciente.";
            this.lblSinContactos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinContactos.Visible = false;
            //
            // panelPie
            //
            this.panelPie.Controls.Add(this.btnCerrar);
            this.panelPie.Location = new System.Drawing.Point(24, 736);
            this.panelPie.Name = "panelPie";
            this.panelPie.Size = new System.Drawing.Size(1036, 60);
            this.panelPie.TabIndex = 4;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = Tema.AzulPrimario;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = Tema.FuenteBoton;
            this.btnCerrar.ForeColor = Tema.Superficie;
            this.btnCerrar.Location = new System.Drawing.Point(876, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(160, 42);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar ficha";
            this.btnCerrar.UseVisualStyleBackColor = false;
            //
            // fichaPaciente
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 580);
            this.Name = "fichaPaciente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Ficha del Paciente";
            this.Load += new System.EventHandler(this.fichaPaciente_Load);
            this.Resize += new System.EventHandler(this.fichaPaciente_Resize);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelBadgeEstado.ResumeLayout(false);
            this.panelBadgeEstado.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelUbicacion.ResumeLayout(false);
            this.panelUbicacion.PerformLayout();
            this.panelSalud.ResumeLayout(false);
            this.panelSalud.PerformLayout();
            this.panelContactos.ResumeLayout(false);
            this.panelContactos.PerformLayout();
            this.panelTablaContactos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.panelPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblPrefijo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelBadgeEstado;
        private System.Windows.Forms.Label lblEstadoBadge;
        private System.Windows.Forms.Button btnCerrarTop;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblSecDatos;
        private System.Windows.Forms.Label lblNombreT;
        private System.Windows.Forms.Label lblNombreVal;
        private System.Windows.Forms.Label lblCedulaT;
        private System.Windows.Forms.Label lblCedulaVal;
        private System.Windows.Forms.Label lblInssT;
        private System.Windows.Forms.Label lblInssVal;
        private System.Windows.Forms.Label lblNacimientoT;
        private System.Windows.Forms.Label lblNacimientoVal;
        private System.Windows.Forms.Label lblGeneroT;
        private System.Windows.Forms.Label lblGeneroVal;
        private System.Windows.Forms.Label lblTelefonoT;
        private System.Windows.Forms.Label lblTelefonoVal;
        private System.Windows.Forms.Panel panelUbicacion;
        private System.Windows.Forms.Label lblSecUbicacion;
        private System.Windows.Forms.Label lblDeptoT;
        private System.Windows.Forms.Label lblDeptoVal;
        private System.Windows.Forms.Label lblMuniT;
        private System.Windows.Forms.Label lblMuniVal;
        private System.Windows.Forms.Label lblComunidadT;
        private System.Windows.Forms.Label lblComunidadVal;
        private System.Windows.Forms.Label lblDireccionT;
        private System.Windows.Forms.Label lblDireccionVal;
        private System.Windows.Forms.Panel panelSalud;
        private System.Windows.Forms.Label lblSecSalud;
        private System.Windows.Forms.Label lblSangreT;
        private System.Windows.Forms.Label lblSangreVal;
        private System.Windows.Forms.Label lblAlergiasT;
        private System.Windows.Forms.Label lblAlergiasVal;
        private System.Windows.Forms.Label lblAntecedentesT;
        private System.Windows.Forms.Label lblAntecedentesVal;
        private System.Windows.Forms.Panel panelContactos;
        private System.Windows.Forms.Label lblSecContactos;
        private System.Windows.Forms.Label lblContactosAyuda;
        private System.Windows.Forms.Panel panelTablaContactos;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefonoContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedulaContacto;
        private System.Windows.Forms.Label lblSinContactos;
        private System.Windows.Forms.Panel panelPie;
        private System.Windows.Forms.Button btnCerrar;
    }
}
