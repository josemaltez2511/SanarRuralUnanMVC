namespace SanarRuralUnan.Views.Pacientes
{
    partial class perfilPaciente
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
            this.panelScroll = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.cardEncabezado = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.lblSubtituloEncabezado = new System.Windows.Forms.Label();
            this.lblBadgeRol = new System.Windows.Forms.Label();
            this.cardDatosLegales = new System.Windows.Forms.Panel();
            this.lblTituloCardLegales = new System.Windows.Forms.Label();
            this.lblAvisoPrivacidad = new System.Windows.Forms.Label();
            this.lblCedulaEtiqueta = new System.Windows.Forms.Label();
            this.lblCedulaValor = new System.Windows.Forms.Label();
            this.lblINSSEtiqueta = new System.Windows.Forms.Label();
            this.lblINSSValor = new System.Windows.Forms.Label();
            this.lblNacimientoEtiqueta = new System.Windows.Forms.Label();
            this.lblNacimientoValor = new System.Windows.Forms.Label();
            this.lblGeneroEtiqueta = new System.Windows.Forms.Label();
            this.lblGeneroValor = new System.Windows.Forms.Label();
            this.lblTipoSangreEtiqueta = new System.Windows.Forms.Label();
            this.lblTipoSangreValor = new System.Windows.Forms.Label();
            this.lblAlergiasEtiqueta = new System.Windows.Forms.Label();
            this.lblAlergiasValor = new System.Windows.Forms.Label();
            this.lblAntecedentesEtiqueta = new System.Windows.Forms.Label();
            this.lblAntecedentesValor = new System.Windows.Forms.Label();
            this.cardDemograficos = new System.Windows.Forms.Panel();
            this.lblTituloCardDemograficos = new System.Windows.Forms.Label();
            this.lblTelefonoEtiqueta = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDepartamentoEtiqueta = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipioEtiqueta = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.lblComunidadEtiqueta = new System.Windows.Forms.Label();
            this.cmbComunidad = new System.Windows.Forms.ComboBox();
            this.lblDireccionEtiqueta = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cardEmergencia = new System.Windows.Forms.Panel();
            this.lblTituloCardEmergencia = new System.Windows.Forms.Label();
            this.lblContNombre = new System.Windows.Forms.Label();
            this.txtContPrimerNombre = new System.Windows.Forms.TextBox();
            this.lblContApellido = new System.Windows.Forms.Label();
            this.txtContPrimerApellido = new System.Windows.Forms.TextBox();
            this.lblContParentesco = new System.Windows.Forms.Label();
            this.cmbContParentesco = new System.Windows.Forms.ComboBox();
            this.lblContTelefono = new System.Windows.Forms.Label();
            this.txtContTelefono = new System.Windows.Forms.TextBox();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.lblMensajeEstado = new System.Windows.Forms.Label();
            this.panelScroll.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.cardEncabezado.SuspendLayout();
            this.cardDatosLegales.SuspendLayout();
            this.cardDemograficos.SuspendLayout();
            this.cardEmergencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScroll
            // 
            this.panelScroll.AutoScroll = true;
            this.panelScroll.Controls.Add(this.panelContenido);
            this.panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScroll.Location = new System.Drawing.Point(0, 0);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Size = new System.Drawing.Size(1040, 720);
            this.panelScroll.TabIndex = 0;
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.cardEncabezado);
            this.panelContenido.Controls.Add(this.cardDatosLegales);
            this.panelContenido.Controls.Add(this.cardDemograficos);
            this.panelContenido.Controls.Add(this.cardEmergencia);
            this.panelContenido.Controls.Add(this.pnlAcciones);
            this.panelContenido.Location = new System.Drawing.Point(20, 16);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1000, 1020);
            this.panelContenido.TabIndex = 0;
            // 
            // cardEncabezado
            // 
            this.cardEncabezado.Controls.Add(this.lblAvatar);
            this.cardEncabezado.Controls.Add(this.lblNombreCompleto);
            this.cardEncabezado.Controls.Add(this.lblSubtituloEncabezado);
            this.cardEncabezado.Controls.Add(this.lblBadgeRol);
            this.cardEncabezado.Location = new System.Drawing.Point(0, 0);
            this.cardEncabezado.Name = "cardEncabezado";
            this.cardEncabezado.Size = new System.Drawing.Size(1000, 96);
            this.cardEncabezado.TabIndex = 0;
            // 
            // lblAvatar
            // 
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.Location = new System.Drawing.Point(18, 14);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(68, 68);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "PA";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblNombreCompleto.Location = new System.Drawing.Point(96, 18);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(200, 28);
            this.lblNombreCompleto.TabIndex = 1;
            this.lblNombreCompleto.Text = "Cargando perfil...";
            // 
            // lblSubtituloEncabezado
            // 
            this.lblSubtituloEncabezado.AutoSize = true;
            this.lblSubtituloEncabezado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtituloEncabezado.Location = new System.Drawing.Point(98, 52);
            this.lblSubtituloEncabezado.Name = "lblSubtituloEncabezado";
            this.lblSubtituloEncabezado.Size = new System.Drawing.Size(380, 17);
            this.lblSubtituloEncabezado.TabIndex = 2;
            this.lblSubtituloEncabezado.Text = "Expediente digital | Consulta y actualización de datos personales";
            // 
            // lblBadgeRol
            // 
            this.lblBadgeRol.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBadgeRol.Location = new System.Drawing.Point(820, 30);
            this.lblBadgeRol.Name = "lblBadgeRol";
            this.lblBadgeRol.Size = new System.Drawing.Size(155, 32);
            this.lblBadgeRol.TabIndex = 3;
            this.lblBadgeRol.Text = "Paciente Activo";
            this.lblBadgeRol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardDatosLegales
            // 
            this.cardDatosLegales.Controls.Add(this.lblTituloCardLegales);
            this.cardDatosLegales.Controls.Add(this.lblAvisoPrivacidad);
            this.cardDatosLegales.Controls.Add(this.lblCedulaEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblCedulaValor);
            this.cardDatosLegales.Controls.Add(this.lblINSSEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblINSSValor);
            this.cardDatosLegales.Controls.Add(this.lblNacimientoEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblNacimientoValor);
            this.cardDatosLegales.Controls.Add(this.lblGeneroEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblGeneroValor);
            this.cardDatosLegales.Controls.Add(this.lblTipoSangreEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblTipoSangreValor);
            this.cardDatosLegales.Controls.Add(this.lblAlergiasEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblAlergiasValor);
            this.cardDatosLegales.Controls.Add(this.lblAntecedentesEtiqueta);
            this.cardDatosLegales.Controls.Add(this.lblAntecedentesValor);
            this.cardDatosLegales.Location = new System.Drawing.Point(0, 110);
            this.cardDatosLegales.Name = "cardDatosLegales";
            this.cardDatosLegales.Size = new System.Drawing.Size(1000, 240);
            this.cardDatosLegales.TabIndex = 1;
            // 
            // lblTituloCardLegales
            // 
            this.lblTituloCardLegales.AutoSize = true;
            this.lblTituloCardLegales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloCardLegales.Location = new System.Drawing.Point(18, 14);
            this.lblTituloCardLegales.Name = "lblTituloCardLegales";
            this.lblTituloCardLegales.Size = new System.Drawing.Size(370, 21);
            this.lblTituloCardLegales.TabIndex = 0;
            this.lblTituloCardLegales.Text = "📋 Identificación y Antecedentes Clínicos (Solo lectura)";
            // 
            // lblAvisoPrivacidad
            // 
            this.lblAvisoPrivacidad.AutoSize = true;
            this.lblAvisoPrivacidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblAvisoPrivacidad.Location = new System.Drawing.Point(20, 40);
            this.lblAvisoPrivacidad.Name = "lblAvisoPrivacidad";
            this.lblAvisoPrivacidad.Size = new System.Drawing.Size(580, 15);
            this.lblAvisoPrivacidad.TabIndex = 1;
            this.lblAvisoPrivacidad.Text = "Estos datos están protegidos legalmente y únicamente pueden ser modificados por el personal médico acreditado.";
            // 
            // lblCedulaEtiqueta
            // 
            this.lblCedulaEtiqueta.AutoSize = true;
            this.lblCedulaEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCedulaEtiqueta.Location = new System.Drawing.Point(20, 72);
            this.lblCedulaEtiqueta.Name = "lblCedulaEtiqueta";
            this.lblCedulaEtiqueta.Size = new System.Drawing.Size(53, 15);
            this.lblCedulaEtiqueta.TabIndex = 2;
            this.lblCedulaEtiqueta.Text = "CÉDULA:";
            // 
            // lblCedulaValor
            // 
            this.lblCedulaValor.AutoSize = true;
            this.lblCedulaValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCedulaValor.Location = new System.Drawing.Point(20, 92);
            this.lblCedulaValor.Name = "lblCedulaValor";
            this.lblCedulaValor.Size = new System.Drawing.Size(13, 17);
            this.lblCedulaValor.TabIndex = 3;
            this.lblCedulaValor.Text = "-";
            // 
            // lblINSSEtiqueta
            // 
            this.lblINSSEtiqueta.AutoSize = true;
            this.lblINSSEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblINSSEtiqueta.Location = new System.Drawing.Point(260, 72);
            this.lblINSSEtiqueta.Name = "lblINSSEtiqueta";
            this.lblINSSEtiqueta.Size = new System.Drawing.Size(59, 15);
            this.lblINSSEtiqueta.TabIndex = 4;
            this.lblINSSEtiqueta.Text = "N° INSS:";
            // 
            // lblINSSValor
            // 
            this.lblINSSValor.AutoSize = true;
            this.lblINSSValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblINSSValor.Location = new System.Drawing.Point(260, 92);
            this.lblINSSValor.Name = "lblINSSValor";
            this.lblINSSValor.Size = new System.Drawing.Size(13, 17);
            this.lblINSSValor.TabIndex = 5;
            this.lblINSSValor.Text = "-";
            // 
            // lblNacimientoEtiqueta
            // 
            this.lblNacimientoEtiqueta.AutoSize = true;
            this.lblNacimientoEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNacimientoEtiqueta.Location = new System.Drawing.Point(500, 72);
            this.lblNacimientoEtiqueta.Name = "lblNacimientoEtiqueta";
            this.lblNacimientoEtiqueta.Size = new System.Drawing.Size(142, 15);
            this.lblNacimientoEtiqueta.TabIndex = 6;
            this.lblNacimientoEtiqueta.Text = "FECHA DE NACIMIENTO:";
            // 
            // lblNacimientoValor
            // 
            this.lblNacimientoValor.AutoSize = true;
            this.lblNacimientoValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNacimientoValor.Location = new System.Drawing.Point(500, 92);
            this.lblNacimientoValor.Name = "lblNacimientoValor";
            this.lblNacimientoValor.Size = new System.Drawing.Size(13, 17);
            this.lblNacimientoValor.TabIndex = 7;
            this.lblNacimientoValor.Text = "-";
            // 
            // lblGeneroEtiqueta
            // 
            this.lblGeneroEtiqueta.AutoSize = true;
            this.lblGeneroEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGeneroEtiqueta.Location = new System.Drawing.Point(780, 72);
            this.lblGeneroEtiqueta.Name = "lblGeneroEtiqueta";
            this.lblGeneroEtiqueta.Size = new System.Drawing.Size(57, 15);
            this.lblGeneroEtiqueta.TabIndex = 8;
            this.lblGeneroEtiqueta.Text = "GÉNERO:";
            // 
            // lblGeneroValor
            // 
            this.lblGeneroValor.AutoSize = true;
            this.lblGeneroValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGeneroValor.Location = new System.Drawing.Point(780, 92);
            this.lblGeneroValor.Name = "lblGeneroValor";
            this.lblGeneroValor.Size = new System.Drawing.Size(13, 17);
            this.lblGeneroValor.TabIndex = 9;
            this.lblGeneroValor.Text = "-";
            // 
            // lblTipoSangreEtiqueta
            // 
            this.lblTipoSangreEtiqueta.AutoSize = true;
            this.lblTipoSangreEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTipoSangreEtiqueta.Location = new System.Drawing.Point(20, 130);
            this.lblTipoSangreEtiqueta.Name = "lblTipoSangreEtiqueta";
            this.lblTipoSangreEtiqueta.Size = new System.Drawing.Size(107, 15);
            this.lblTipoSangreEtiqueta.TabIndex = 10;
            this.lblTipoSangreEtiqueta.Text = "GRUPO SANGUÍNEO:";
            // 
            // lblTipoSangreValor
            // 
            this.lblTipoSangreValor.AutoSize = true;
            this.lblTipoSangreValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTipoSangreValor.Location = new System.Drawing.Point(20, 150);
            this.lblTipoSangreValor.Name = "lblTipoSangreValor";
            this.lblTipoSangreValor.Size = new System.Drawing.Size(13, 17);
            this.lblTipoSangreValor.TabIndex = 11;
            this.lblTipoSangreValor.Text = "-";
            // 
            // lblAlergiasEtiqueta
            // 
            this.lblAlergiasEtiqueta.AutoSize = true;
            this.lblAlergiasEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAlergiasEtiqueta.Location = new System.Drawing.Point(260, 130);
            this.lblAlergiasEtiqueta.Name = "lblAlergiasEtiqueta";
            this.lblAlergiasEtiqueta.Size = new System.Drawing.Size(65, 15);
            this.lblAlergiasEtiqueta.TabIndex = 12;
            this.lblAlergiasEtiqueta.Text = "ALERGIAS:";
            // 
            // lblAlergiasValor
            // 
            this.lblAlergiasValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAlergiasValor.Location = new System.Drawing.Point(260, 150);
            this.lblAlergiasValor.Name = "lblAlergiasValor";
            this.lblAlergiasValor.Size = new System.Drawing.Size(220, 70);
            this.lblAlergiasValor.TabIndex = 13;
            this.lblAlergiasValor.Text = "-";
            // 
            // lblAntecedentesEtiqueta
            // 
            this.lblAntecedentesEtiqueta.AutoSize = true;
            this.lblAntecedentesEtiqueta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAntecedentesEtiqueta.Location = new System.Drawing.Point(500, 130);
            this.lblAntecedentesEtiqueta.Name = "lblAntecedentesEtiqueta";
            this.lblAntecedentesEtiqueta.Size = new System.Drawing.Size(176, 15);
            this.lblAntecedentesEtiqueta.TabIndex = 14;
            this.lblAntecedentesEtiqueta.Text = "ANTECEDENTES PATOLÓGICOS:";
            // 
            // lblAntecedentesValor
            // 
            this.lblAntecedentesValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAntecedentesValor.Location = new System.Drawing.Point(500, 150);
            this.lblAntecedentesValor.Name = "lblAntecedentesValor";
            this.lblAntecedentesValor.Size = new System.Drawing.Size(475, 70);
            this.lblAntecedentesValor.TabIndex = 15;
            this.lblAntecedentesValor.Text = "-";
            // 
            // cardDemograficos
            // 
            this.cardDemograficos.Controls.Add(this.lblTituloCardDemograficos);
            this.cardDemograficos.Controls.Add(this.lblTelefonoEtiqueta);
            this.cardDemograficos.Controls.Add(this.txtTelefono);
            this.cardDemograficos.Controls.Add(this.lblDepartamentoEtiqueta);
            this.cardDemograficos.Controls.Add(this.cmbDepartamento);
            this.cardDemograficos.Controls.Add(this.lblMunicipioEtiqueta);
            this.cardDemograficos.Controls.Add(this.cmbMunicipio);
            this.cardDemograficos.Controls.Add(this.lblComunidadEtiqueta);
            this.cardDemograficos.Controls.Add(this.cmbComunidad);
            this.cardDemograficos.Controls.Add(this.lblDireccionEtiqueta);
            this.cardDemograficos.Controls.Add(this.txtDireccion);
            this.cardDemograficos.Location = new System.Drawing.Point(0, 365);
            this.cardDemograficos.Name = "cardDemograficos";
            this.cardDemograficos.Size = new System.Drawing.Size(1000, 230);
            this.cardDemograficos.TabIndex = 2;
            // 
            // lblTituloCardDemograficos
            // 
            this.lblTituloCardDemograficos.AutoSize = true;
            this.lblTituloCardDemograficos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloCardDemograficos.Location = new System.Drawing.Point(18, 14);
            this.lblTituloCardDemograficos.Name = "lblTituloCardDemograficos";
            this.lblTituloCardDemograficos.Size = new System.Drawing.Size(350, 21);
            this.lblTituloCardDemograficos.TabIndex = 0;
            this.lblTituloCardDemograficos.Text = "🏠 Contacto y Residencia (Editable por el paciente)";
            // 
            // lblTelefonoEtiqueta
            // 
            this.lblTelefonoEtiqueta.AutoSize = true;
            this.lblTelefonoEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefonoEtiqueta.Location = new System.Drawing.Point(20, 52);
            this.lblTelefonoEtiqueta.Name = "lblTelefonoEtiqueta";
            this.lblTelefonoEtiqueta.Size = new System.Drawing.Size(127, 15);
            this.lblTelefonoEtiqueta.TabIndex = 1;
            this.lblTelefonoEtiqueta.Text = "Teléfono de Contacto:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(20, 72);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(260, 25);
            this.txtTelefono.TabIndex = 2;
            // 
            // lblDepartamentoEtiqueta
            // 
            this.lblDepartamentoEtiqueta.AutoSize = true;
            this.lblDepartamentoEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepartamentoEtiqueta.Location = new System.Drawing.Point(310, 52);
            this.lblDepartamentoEtiqueta.Name = "lblDepartamentoEtiqueta";
            this.lblDepartamentoEtiqueta.Size = new System.Drawing.Size(91, 15);
            this.lblDepartamentoEtiqueta.TabIndex = 3;
            this.lblDepartamentoEtiqueta.Text = "Departamento:";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(310, 72);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(210, 25);
            this.cmbDepartamento.TabIndex = 4;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // lblMunicipioEtiqueta
            // 
            this.lblMunicipioEtiqueta.AutoSize = true;
            this.lblMunicipioEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMunicipioEtiqueta.Location = new System.Drawing.Point(540, 52);
            this.lblMunicipioEtiqueta.Name = "lblMunicipioEtiqueta";
            this.lblMunicipioEtiqueta.Size = new System.Drawing.Size(66, 15);
            this.lblMunicipioEtiqueta.TabIndex = 5;
            this.lblMunicipioEtiqueta.Text = "Municipio:";
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(540, 72);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(210, 25);
            this.cmbMunicipio.TabIndex = 6;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            // 
            // lblComunidadEtiqueta
            // 
            this.lblComunidadEtiqueta.AutoSize = true;
            this.lblComunidadEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblComunidadEtiqueta.Location = new System.Drawing.Point(770, 52);
            this.lblComunidadEtiqueta.Name = "lblComunidadEtiqueta";
            this.lblComunidadEtiqueta.Size = new System.Drawing.Size(73, 15);
            this.lblComunidadEtiqueta.TabIndex = 7;
            this.lblComunidadEtiqueta.Text = "Comunidad:";
            // 
            // cmbComunidad
            // 
            this.cmbComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComunidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbComunidad.FormattingEnabled = true;
            this.cmbComunidad.Location = new System.Drawing.Point(770, 72);
            this.cmbComunidad.Name = "cmbComunidad";
            this.cmbComunidad.Size = new System.Drawing.Size(210, 25);
            this.cmbComunidad.TabIndex = 8;
            // 
            // lblDireccionEtiqueta
            // 
            this.lblDireccionEtiqueta.AutoSize = true;
            this.lblDireccionEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccionEtiqueta.Location = new System.Drawing.Point(20, 115);
            this.lblDireccionEtiqueta.Name = "lblDireccionEtiqueta";
            this.lblDireccionEtiqueta.Size = new System.Drawing.Size(167, 15);
            this.lblDireccionEtiqueta.TabIndex = 9;
            this.lblDireccionEtiqueta.Text = "Dirección exacta / Referencia:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.Location = new System.Drawing.Point(20, 135);
            this.txtDireccion.MaxLength = 300;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(960, 75);
            this.txtDireccion.TabIndex = 10;
            // 
            // cardEmergencia
            // 
            this.cardEmergencia.Controls.Add(this.lblTituloCardEmergencia);
            this.cardEmergencia.Controls.Add(this.lblContNombre);
            this.cardEmergencia.Controls.Add(this.txtContPrimerNombre);
            this.cardEmergencia.Controls.Add(this.lblContApellido);
            this.cardEmergencia.Controls.Add(this.txtContPrimerApellido);
            this.cardEmergencia.Controls.Add(this.lblContParentesco);
            this.cardEmergencia.Controls.Add(this.cmbContParentesco);
            this.cardEmergencia.Controls.Add(this.lblContTelefono);
            this.cardEmergencia.Controls.Add(this.txtContTelefono);
            this.cardEmergencia.Controls.Add(this.btnAgregarContacto);
            this.cardEmergencia.Controls.Add(this.dgvContactos);
            this.cardEmergencia.Location = new System.Drawing.Point(0, 610);
            this.cardEmergencia.Name = "cardEmergencia";
            this.cardEmergencia.Size = new System.Drawing.Size(1000, 310);
            this.cardEmergencia.TabIndex = 3;
            // 
            // lblTituloCardEmergencia
            // 
            this.lblTituloCardEmergencia.AutoSize = true;
            this.lblTituloCardEmergencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloCardEmergencia.Location = new System.Drawing.Point(18, 14);
            this.lblTituloCardEmergencia.Name = "lblTituloCardEmergencia";
            this.lblTituloCardEmergencia.Size = new System.Drawing.Size(260, 21);
            this.lblTituloCardEmergencia.TabIndex = 0;
            this.lblTituloCardEmergencia.Text = "📞 Contactos en Caso de Emergencia";
            // 
            // lblContNombre
            // 
            this.lblContNombre.AutoSize = true;
            this.lblContNombre.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblContNombre.Location = new System.Drawing.Point(20, 48);
            this.lblContNombre.Name = "lblContNombre";
            this.lblContNombre.Size = new System.Drawing.Size(95, 15);
            this.lblContNombre.TabIndex = 1;
            this.lblContNombre.Text = "Primer Nombre:";
            // 
            // txtContPrimerNombre
            // 
            this.txtContPrimerNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContPrimerNombre.Location = new System.Drawing.Point(20, 68);
            this.txtContPrimerNombre.MaxLength = 50;
            this.txtContPrimerNombre.Name = "txtContPrimerNombre";
            this.txtContPrimerNombre.Size = new System.Drawing.Size(170, 24);
            this.txtContPrimerNombre.TabIndex = 2;
            // 
            // lblContApellido
            // 
            this.lblContApellido.AutoSize = true;
            this.lblContApellido.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblContApellido.Location = new System.Drawing.Point(205, 48);
            this.lblContApellido.Name = "lblContApellido";
            this.lblContApellido.Size = new System.Drawing.Size(95, 15);
            this.lblContApellido.TabIndex = 3;
            this.lblContApellido.Text = "Primer Apellido:";
            // 
            // txtContPrimerApellido
            // 
            this.txtContPrimerApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContPrimerApellido.Location = new System.Drawing.Point(205, 68);
            this.txtContPrimerApellido.MaxLength = 50;
            this.txtContPrimerApellido.Name = "txtContPrimerApellido";
            this.txtContPrimerApellido.Size = new System.Drawing.Size(170, 24);
            this.txtContPrimerApellido.TabIndex = 4;
            // 
            // lblContParentesco
            // 
            this.lblContParentesco.AutoSize = true;
            this.lblContParentesco.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblContParentesco.Location = new System.Drawing.Point(390, 48);
            this.lblContParentesco.Name = "lblContParentesco";
            this.lblContParentesco.Size = new System.Drawing.Size(73, 15);
            this.lblContParentesco.TabIndex = 5;
            this.lblContParentesco.Text = "Parentesco:";
            // 
            // cmbContParentesco
            // 
            this.cmbContParentesco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContParentesco.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbContParentesco.FormattingEnabled = true;
            this.cmbContParentesco.Items.AddRange(new object[] {
            "Madre",
            "Padre",
            "Cónyuge",
            "Hijo/a",
            "Hermano/a",
            "Tío/a",
            "Vecino/a",
            "Tutor/a Legal",
            "Otro"});
            this.cmbContParentesco.Location = new System.Drawing.Point(390, 68);
            this.cmbContParentesco.Name = "cmbContParentesco";
            this.cmbContParentesco.Size = new System.Drawing.Size(160, 24);
            this.cmbContParentesco.TabIndex = 6;
            // 
            // lblContTelefono
            // 
            this.lblContTelefono.AutoSize = true;
            this.lblContTelefono.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblContTelefono.Location = new System.Drawing.Point(565, 48);
            this.lblContTelefono.Name = "lblContTelefono";
            this.lblContTelefono.Size = new System.Drawing.Size(59, 15);
            this.lblContTelefono.TabIndex = 7;
            this.lblContTelefono.Text = "Teléfono:";
            // 
            // txtContTelefono
            // 
            this.txtContTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContTelefono.Location = new System.Drawing.Point(565, 68);
            this.txtContTelefono.MaxLength = 30;
            this.txtContTelefono.Name = "txtContTelefono";
            this.txtContTelefono.Size = new System.Drawing.Size(180, 24);
            this.txtContTelefono.TabIndex = 8;
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarContacto.Location = new System.Drawing.Point(760, 64);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarContacto.TabIndex = 9;
            this.btnAgregarContacto.Text = "+ Agregar contacto";
            this.btnAgregarContacto.UseVisualStyleBackColor = true;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Location = new System.Drawing.Point(20, 108);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.Size = new System.Drawing.Size(960, 185);
            this.dgvContactos.TabIndex = 10;
            this.dgvContactos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactos_CellContentClick);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.btnGuardar);
            this.pnlAcciones.Controls.Add(this.btnRestablecer);
            this.pnlAcciones.Controls.Add(this.lblMensajeEstado);
            this.pnlAcciones.Location = new System.Drawing.Point(0, 935);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1000, 65);
            this.pnlAcciones.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(20, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 42);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestablecer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnRestablecer.Location = new System.Drawing.Point(260, 14);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(150, 38);
            this.btnRestablecer.TabIndex = 1;
            this.btnRestablecer.Text = "🔄 Restablecer";
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // lblMensajeEstado
            // 
            this.lblMensajeEstado.AutoSize = true;
            this.lblMensajeEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMensajeEstado.Location = new System.Drawing.Point(430, 24);
            this.lblMensajeEstado.Name = "lblMensajeEstado";
            this.lblMensajeEstado.Size = new System.Drawing.Size(0, 17);
            this.lblMensajeEstado.TabIndex = 2;
            // 
            // perfilPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.panelScroll);
            this.Name = "perfilPaciente";
            this.Text = "Mi Perfil - Sanar Rural";
            this.Load += new System.EventHandler(this.perfilPaciente_Load);
            this.panelScroll.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.cardEncabezado.ResumeLayout(false);
            this.cardEncabezado.PerformLayout();
            this.cardDatosLegales.ResumeLayout(false);
            this.cardDatosLegales.PerformLayout();
            this.cardDemograficos.ResumeLayout(false);
            this.cardDemograficos.PerformLayout();
            this.cardEmergencia.ResumeLayout(false);
            this.cardEmergencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel cardEncabezado;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblSubtituloEncabezado;
        private System.Windows.Forms.Label lblBadgeRol;
        private System.Windows.Forms.Panel cardDatosLegales;
        private System.Windows.Forms.Label lblTituloCardLegales;
        private System.Windows.Forms.Label lblAvisoPrivacidad;
        private System.Windows.Forms.Label lblCedulaEtiqueta;
        private System.Windows.Forms.Label lblCedulaValor;
        private System.Windows.Forms.Label lblINSSEtiqueta;
        private System.Windows.Forms.Label lblINSSValor;
        private System.Windows.Forms.Label lblNacimientoEtiqueta;
        private System.Windows.Forms.Label lblNacimientoValor;
        private System.Windows.Forms.Label lblGeneroEtiqueta;
        private System.Windows.Forms.Label lblGeneroValor;
        private System.Windows.Forms.Label lblTipoSangreEtiqueta;
        private System.Windows.Forms.Label lblTipoSangreValor;
        private System.Windows.Forms.Label lblAlergiasEtiqueta;
        private System.Windows.Forms.Label lblAlergiasValor;
        private System.Windows.Forms.Label lblAntecedentesEtiqueta;
        private System.Windows.Forms.Label lblAntecedentesValor;
        private System.Windows.Forms.Panel cardDemograficos;
        private System.Windows.Forms.Label lblTituloCardDemograficos;
        private System.Windows.Forms.Label lblTelefonoEtiqueta;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDepartamentoEtiqueta;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblMunicipioEtiqueta;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.Label lblComunidadEtiqueta;
        private System.Windows.Forms.ComboBox cmbComunidad;
        private System.Windows.Forms.Label lblDireccionEtiqueta;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Panel cardEmergencia;
        private System.Windows.Forms.Label lblTituloCardEmergencia;
        private System.Windows.Forms.Label lblContNombre;
        private System.Windows.Forms.TextBox txtContPrimerNombre;
        private System.Windows.Forms.Label lblContApellido;
        private System.Windows.Forms.TextBox txtContPrimerApellido;
        private System.Windows.Forms.Label lblContParentesco;
        private System.Windows.Forms.ComboBox cmbContParentesco;
        private System.Windows.Forms.Label lblContTelefono;
        private System.Windows.Forms.TextBox txtContTelefono;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRestablecer;
        private System.Windows.Forms.Label lblMensajeEstado;
    }
}
