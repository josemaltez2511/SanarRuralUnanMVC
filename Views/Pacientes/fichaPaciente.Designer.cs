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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblEstadoBadge = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelCard = new System.Windows.Forms.Panel();
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
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.colParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefonoContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedulaContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSinContactos = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelUbicacion.SuspendLayout();
            this.panelSalud.SuspendLayout();
            this.panelContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            //
            // panelEncabezado
            //
            this.panelEncabezado.BackColor = Tema.Fondo;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Controls.Add(this.lblEstadoBadge);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Height = 85;
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(25, 15, 25, 10);
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(22, 12);
            this.lblTitulo.Text = "Ficha del Paciente";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(25, 52);
            this.lblSubtitulo.Text = "Consulta integral de datos demográficos, clínicos y contactos.";
            //
            // lblEstadoBadge
            //
            this.lblEstadoBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoBadge.AutoSize = true;
            this.lblEstadoBadge.Font = Tema.FuenteBoton;
            this.lblEstadoBadge.ForeColor = Tema.VerdeOscuro;
            this.lblEstadoBadge.Location = new System.Drawing.Point(740, 20);
            this.lblEstadoBadge.Text = "✓ Activo";
            //
            // panelContenido
            //
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = Tema.Fondo;
            this.panelContenido.Controls.Add(this.panelCard);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 85);
            //
            // panelCard
            //
            this.panelCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCard.BackColor = Tema.Superficie;
            this.panelCard.Controls.Add(this.panelDatos);
            this.panelCard.Controls.Add(this.panelUbicacion);
            this.panelCard.Controls.Add(this.panelSalud);
            this.panelCard.Controls.Add(this.panelContactos);
            this.panelCard.Controls.Add(this.btnCerrar);
            this.panelCard.Location = new System.Drawing.Point(20, 10);
            this.panelCard.Width = 840;
            this.panelCard.Height = 750;
            this.panelCard.Padding = new System.Windows.Forms.Padding(20);
            //
            // panelDatos
            //
            this.panelDatos.BackColor = Tema.Superficie;
            this.panelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panelDatos.Location = new System.Drawing.Point(20, 15);
            this.panelDatos.Size = new System.Drawing.Size(380, 230);
            //
            // lblSecDatos
            //
            this.lblSecDatos.AutoSize = true;
            this.lblSecDatos.Font = Tema.FuenteBoton;
            this.lblSecDatos.ForeColor = Tema.AzulPrimario;
            this.lblSecDatos.Location = new System.Drawing.Point(15, 12);
            this.lblSecDatos.Text = "DATOS PERSONALES";
            //
            // lblNombreT
            //
            this.lblNombreT.AutoSize = true;
            this.lblNombreT.Font = Tema.FuenteLabelCampo;
            this.lblNombreT.ForeColor = Tema.TextoSecundario;
            this.lblNombreT.Location = new System.Drawing.Point(15, 42);
            this.lblNombreT.Text = "Nombre:";
            //
            // lblNombreVal
            //
            this.lblNombreVal.AutoSize = true;
            this.lblNombreVal.Font = Tema.FuenteInput;
            this.lblNombreVal.ForeColor = Tema.TextoPrincipal;
            this.lblNombreVal.Location = new System.Drawing.Point(110, 42);
            this.lblNombreVal.Text = "-";
            //
            // lblCedulaT
            //
            this.lblCedulaT.AutoSize = true;
            this.lblCedulaT.Font = Tema.FuenteLabelCampo;
            this.lblCedulaT.ForeColor = Tema.TextoSecundario;
            this.lblCedulaT.Location = new System.Drawing.Point(15, 72);
            this.lblCedulaT.Text = "Cédula:";
            //
            // lblCedulaVal
            //
            this.lblCedulaVal.AutoSize = true;
            this.lblCedulaVal.Font = Tema.FuenteInput;
            this.lblCedulaVal.ForeColor = Tema.TextoPrincipal;
            this.lblCedulaVal.Location = new System.Drawing.Point(110, 72);
            this.lblCedulaVal.Text = "-";
            //
            // lblInssT
            //
            this.lblInssT.AutoSize = true;
            this.lblInssT.Font = Tema.FuenteLabelCampo;
            this.lblInssT.ForeColor = Tema.TextoSecundario;
            this.lblInssT.Location = new System.Drawing.Point(15, 102);
            this.lblInssT.Text = "INSS:";
            //
            // lblInssVal
            //
            this.lblInssVal.AutoSize = true;
            this.lblInssVal.Font = Tema.FuenteInput;
            this.lblInssVal.ForeColor = Tema.TextoPrincipal;
            this.lblInssVal.Location = new System.Drawing.Point(110, 102);
            this.lblInssVal.Text = "-";
            //
            // lblNacimientoT
            //
            this.lblNacimientoT.AutoSize = true;
            this.lblNacimientoT.Font = Tema.FuenteLabelCampo;
            this.lblNacimientoT.ForeColor = Tema.TextoSecundario;
            this.lblNacimientoT.Location = new System.Drawing.Point(15, 132);
            this.lblNacimientoT.Text = "Nacimiento:";
            //
            // lblNacimientoVal
            //
            this.lblNacimientoVal.AutoSize = true;
            this.lblNacimientoVal.Font = Tema.FuenteInput;
            this.lblNacimientoVal.ForeColor = Tema.TextoPrincipal;
            this.lblNacimientoVal.Location = new System.Drawing.Point(110, 132);
            this.lblNacimientoVal.Text = "-";
            //
            // lblGeneroT
            //
            this.lblGeneroT.AutoSize = true;
            this.lblGeneroT.Font = Tema.FuenteLabelCampo;
            this.lblGeneroT.ForeColor = Tema.TextoSecundario;
            this.lblGeneroT.Location = new System.Drawing.Point(15, 162);
            this.lblGeneroT.Text = "Género:";
            //
            // lblGeneroVal
            //
            this.lblGeneroVal.AutoSize = true;
            this.lblGeneroVal.Font = Tema.FuenteInput;
            this.lblGeneroVal.ForeColor = Tema.TextoPrincipal;
            this.lblGeneroVal.Location = new System.Drawing.Point(110, 162);
            this.lblGeneroVal.Text = "-";
            //
            // lblTelefonoT
            //
            this.lblTelefonoT.AutoSize = true;
            this.lblTelefonoT.Font = Tema.FuenteLabelCampo;
            this.lblTelefonoT.ForeColor = Tema.TextoSecundario;
            this.lblTelefonoT.Location = new System.Drawing.Point(15, 192);
            this.lblTelefonoT.Text = "Teléfono:";
            //
            // lblTelefonoVal
            //
            this.lblTelefonoVal.AutoSize = true;
            this.lblTelefonoVal.Font = Tema.FuenteInput;
            this.lblTelefonoVal.ForeColor = Tema.TextoPrincipal;
            this.lblTelefonoVal.Location = new System.Drawing.Point(110, 192);
            this.lblTelefonoVal.Text = "-";
            //
            // panelUbicacion
            //
            this.panelUbicacion.BackColor = Tema.Superficie;
            this.panelUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUbicacion.Controls.Add(this.lblSecUbicacion);
            this.panelUbicacion.Controls.Add(this.lblDeptoT);
            this.panelUbicacion.Controls.Add(this.lblDeptoVal);
            this.panelUbicacion.Controls.Add(this.lblMuniT);
            this.panelUbicacion.Controls.Add(this.lblMuniVal);
            this.panelUbicacion.Controls.Add(this.lblComunidadT);
            this.panelUbicacion.Controls.Add(this.lblComunidadVal);
            this.panelUbicacion.Controls.Add(this.lblDireccionT);
            this.panelUbicacion.Controls.Add(this.lblDireccionVal);
            this.panelUbicacion.Location = new System.Drawing.Point(420, 15);
            this.panelUbicacion.Size = new System.Drawing.Size(395, 230);
            //
            // lblSecUbicacion
            //
            this.lblSecUbicacion.AutoSize = true;
            this.lblSecUbicacion.Font = Tema.FuenteBoton;
            this.lblSecUbicacion.ForeColor = Tema.AzulPrimario;
            this.lblSecUbicacion.Location = new System.Drawing.Point(15, 12);
            this.lblSecUbicacion.Text = "UBICACIÓN GEOGRÁFICA";
            //
            // lblDeptoT
            //
            this.lblDeptoT.AutoSize = true;
            this.lblDeptoT.Font = Tema.FuenteLabelCampo;
            this.lblDeptoT.ForeColor = Tema.TextoSecundario;
            this.lblDeptoT.Location = new System.Drawing.Point(15, 42);
            this.lblDeptoT.Text = "Departamento:";
            //
            // lblDeptoVal
            //
            this.lblDeptoVal.AutoSize = true;
            this.lblDeptoVal.Font = Tema.FuenteInput;
            this.lblDeptoVal.ForeColor = Tema.TextoPrincipal;
            this.lblDeptoVal.Location = new System.Drawing.Point(135, 42);
            this.lblDeptoVal.Text = "-";
            //
            // lblMuniT
            //
            this.lblMuniT.AutoSize = true;
            this.lblMuniT.Font = Tema.FuenteLabelCampo;
            this.lblMuniT.ForeColor = Tema.TextoSecundario;
            this.lblMuniT.Location = new System.Drawing.Point(15, 72);
            this.lblMuniT.Text = "Municipio:";
            //
            // lblMuniVal
            //
            this.lblMuniVal.AutoSize = true;
            this.lblMuniVal.Font = Tema.FuenteInput;
            this.lblMuniVal.ForeColor = Tema.TextoPrincipal;
            this.lblMuniVal.Location = new System.Drawing.Point(135, 72);
            this.lblMuniVal.Text = "-";
            //
            // lblComunidadT
            //
            this.lblComunidadT.AutoSize = true;
            this.lblComunidadT.Font = Tema.FuenteLabelCampo;
            this.lblComunidadT.ForeColor = Tema.TextoSecundario;
            this.lblComunidadT.Location = new System.Drawing.Point(15, 102);
            this.lblComunidadT.Text = "Comunidad:";
            //
            // lblComunidadVal
            //
            this.lblComunidadVal.AutoSize = true;
            this.lblComunidadVal.Font = Tema.FuenteInput;
            this.lblComunidadVal.ForeColor = Tema.TextoPrincipal;
            this.lblComunidadVal.Location = new System.Drawing.Point(135, 102);
            this.lblComunidadVal.Text = "-";
            //
            // lblDireccionT
            //
            this.lblDireccionT.AutoSize = true;
            this.lblDireccionT.Font = Tema.FuenteLabelCampo;
            this.lblDireccionT.ForeColor = Tema.TextoSecundario;
            this.lblDireccionT.Location = new System.Drawing.Point(15, 132);
            this.lblDireccionT.Text = "Dirección:";
            //
            // lblDireccionVal
            //
            this.lblDireccionVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDireccionVal.Font = Tema.FuenteInput;
            this.lblDireccionVal.ForeColor = Tema.TextoPrincipal;
            this.lblDireccionVal.Location = new System.Drawing.Point(135, 132);
            this.lblDireccionVal.Size = new System.Drawing.Size(245, 80);
            this.lblDireccionVal.Text = "-";
            //
            // panelSalud
            //
            this.panelSalud.BackColor = Tema.Superficie;
            this.panelSalud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSalud.Controls.Add(this.lblSecSalud);
            this.panelSalud.Controls.Add(this.lblSangreT);
            this.panelSalud.Controls.Add(this.lblSangreVal);
            this.panelSalud.Controls.Add(this.lblAlergiasT);
            this.panelSalud.Controls.Add(this.lblAlergiasVal);
            this.panelSalud.Controls.Add(this.lblAntecedentesT);
            this.panelSalud.Controls.Add(this.lblAntecedentesVal);
            this.panelSalud.Location = new System.Drawing.Point(20, 260);
            this.panelSalud.Size = new System.Drawing.Size(795, 170);
            //
            // lblSecSalud
            //
            this.lblSecSalud.AutoSize = true;
            this.lblSecSalud.Font = Tema.FuenteBoton;
            this.lblSecSalud.ForeColor = Tema.VerdeOscuro;
            this.lblSecSalud.Location = new System.Drawing.Point(15, 12);
            this.lblSecSalud.Text = "INFORMACIÓN CLÍNICA INICIAL";
            //
            // lblSangreT
            //
            this.lblSangreT.AutoSize = true;
            this.lblSangreT.Font = Tema.FuenteLabelCampo;
            this.lblSangreT.ForeColor = Tema.TextoSecundario;
            this.lblSangreT.Location = new System.Drawing.Point(15, 42);
            this.lblSangreT.Text = "Tipo de Sangre:";
            //
            // lblSangreVal
            //
            this.lblSangreVal.AutoSize = true;
            this.lblSangreVal.Font = Tema.FuenteInput;
            this.lblSangreVal.ForeColor = Tema.AzulPrimario;
            this.lblSangreVal.Location = new System.Drawing.Point(140, 42);
            this.lblSangreVal.Text = "-";
            //
            // lblAlergiasT
            //
            this.lblAlergiasT.AutoSize = true;
            this.lblAlergiasT.Font = Tema.FuenteLabelCampo;
            this.lblAlergiasT.ForeColor = Tema.TextoSecundario;
            this.lblAlergiasT.Location = new System.Drawing.Point(15, 72);
            this.lblAlergiasT.Text = "Alergias:";
            //
            // lblAlergiasVal
            //
            this.lblAlergiasVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlergiasVal.Font = Tema.FuenteInput;
            this.lblAlergiasVal.ForeColor = Tema.TextoPrincipal;
            this.lblAlergiasVal.Location = new System.Drawing.Point(140, 72);
            this.lblAlergiasVal.Size = new System.Drawing.Size(635, 40);
            this.lblAlergiasVal.Text = "Ninguna registrada.";
            //
            // lblAntecedentesT
            //
            this.lblAntecedentesT.AutoSize = true;
            this.lblAntecedentesT.Font = Tema.FuenteLabelCampo;
            this.lblAntecedentesT.ForeColor = Tema.TextoSecundario;
            this.lblAntecedentesT.Location = new System.Drawing.Point(15, 115);
            this.lblAntecedentesT.Text = "Antecedentes:";
            //
            // lblAntecedentesVal
            //
            this.lblAntecedentesVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAntecedentesVal.Font = Tema.FuenteInput;
            this.lblAntecedentesVal.ForeColor = Tema.TextoPrincipal;
            this.lblAntecedentesVal.Location = new System.Drawing.Point(140, 115);
            this.lblAntecedentesVal.Size = new System.Drawing.Size(635, 45);
            this.lblAntecedentesVal.Text = "Sin antecedentes registrados.";
            //
            // panelContactos
            //
            this.panelContactos.BackColor = Tema.Superficie;
            this.panelContactos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContactos.Controls.Add(this.lblSecContactos);
            this.panelContactos.Controls.Add(this.dgvContactos);
            this.panelContactos.Controls.Add(this.lblSinContactos);
            this.panelContactos.Location = new System.Drawing.Point(20, 445);
            this.panelContactos.Size = new System.Drawing.Size(795, 220);
            //
            // lblSecContactos
            //
            this.lblSecContactos.AutoSize = true;
            this.lblSecContactos.Font = Tema.FuenteBoton;
            this.lblSecContactos.ForeColor = Tema.AzulPrimario;
            this.lblSecContactos.Location = new System.Drawing.Point(15, 12);
            this.lblSecContactos.Text = "CONTACTOS DE EMERGENCIA (0..N)";
            //
            // dgvContactos
            //
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContactos.BackgroundColor = Tema.Superficie;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colParentesco,
            this.colNombreContacto,
            this.colTelefonoContacto,
            this.colCedulaContacto});
            this.dgvContactos.Location = new System.Drawing.Point(15, 40);
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.Size = new System.Drawing.Size(760, 160);
            //
            // colParentesco
            //
            this.colParentesco.DataPropertyName = "Parentesco";
            this.colParentesco.HeaderText = "Parentesco";
            this.colParentesco.Name = "colParentesco";
            this.colParentesco.ReadOnly = true;
            this.colParentesco.FillWeight = 80;
            //
            // colNombreContacto
            //
            this.colNombreContacto.DataPropertyName = "NombreCompleto";
            this.colNombreContacto.HeaderText = "Nombre Completo";
            this.colNombreContacto.Name = "colNombreContacto";
            this.colNombreContacto.ReadOnly = true;
            this.colNombreContacto.FillWeight = 140;
            //
            // colTelefonoContacto
            //
            this.colTelefonoContacto.DataPropertyName = "Telefono";
            this.colTelefonoContacto.HeaderText = "Teléfono";
            this.colTelefonoContacto.Name = "colTelefonoContacto";
            this.colTelefonoContacto.ReadOnly = true;
            this.colTelefonoContacto.FillWeight = 90;
            //
            // colCedulaContacto
            //
            this.colCedulaContacto.DataPropertyName = "Cedula";
            this.colCedulaContacto.HeaderText = "Cédula";
            this.colCedulaContacto.Name = "colCedulaContacto";
            this.colCedulaContacto.ReadOnly = true;
            this.colCedulaContacto.FillWeight = 90;
            //
            // lblSinContactos
            //
            this.lblSinContactos.AutoSize = true;
            this.lblSinContactos.Font = Tema.FuenteCuerpo;
            this.lblSinContactos.ForeColor = Tema.TextoSecundario;
            this.lblSinContactos.Location = new System.Drawing.Point(20, 50);
            this.lblSinContactos.Text = "No se registraron contactos de emergencia para este paciente.";
            this.lblSinContactos.Visible = false;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = Tema.AzulPrimario;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = Tema.FuenteBoton;
            this.btnCerrar.ForeColor = Tema.Superficie;
            this.btnCerrar.Location = new System.Drawing.Point(675, 685);
            this.btnCerrar.Size = new System.Drawing.Size(140, 40);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            //
            // fichaPaciente
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(880, 840);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fichaPaciente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Ficha del Paciente";
            this.Load += new System.EventHandler(this.fichaPaciente_Load);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelUbicacion.ResumeLayout(false);
            this.panelUbicacion.PerformLayout();
            this.panelSalud.ResumeLayout(false);
            this.panelSalud.PerformLayout();
            this.panelContactos.ResumeLayout(false);
            this.panelContactos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblEstadoBadge;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelCard;
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
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentesco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefonoContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedulaContacto;
        private System.Windows.Forms.Label lblSinContactos;
        private System.Windows.Forms.Button btnCerrar;
    }
}
