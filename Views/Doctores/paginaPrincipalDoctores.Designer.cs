using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Doctores
{
    partial class paginaPrincipalDoctores
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
            this.panelCardPrincipal = new System.Windows.Forms.Panel();
            this.panelHeaderModulo = new System.Windows.Forms.Panel();
            this.panelIconoModulo = new System.Windows.Forms.Panel();
            this.lblIconoModulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.lblIconoBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.panelMetricas = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblIconoTotal = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotalNum = new System.Windows.Forms.Label();
            this.cardActivos = new System.Windows.Forms.Panel();
            this.lblIconoActivos = new System.Windows.Forms.Label();
            this.lblActivosTitulo = new System.Windows.Forms.Label();
            this.lblActivosNum = new System.Windows.Forms.Label();
            this.cardEspecialidades = new System.Windows.Forms.Panel();
            this.lblIconoEspecialidades = new System.Windows.Forms.Label();
            this.lblEspecialidadesTitulo = new System.Windows.Forms.Label();
            this.lblEspecialidadesNum = new System.Windows.Forms.Label();
            this.panelGridContenedor = new System.Windows.Forms.Panel();
            this.dgvDoctores = new System.Windows.Forms.DataGridView();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblConteo = new System.Windows.Forms.Label();
            this.btnPaginaAnt = new System.Windows.Forms.Button();
            this.btnPaginaActual = new System.Windows.Forms.Button();
            this.btnPaginaSig = new System.Windows.Forms.Button();
            this.panelCardPrincipal.SuspendLayout();
            this.panelHeaderModulo.SuspendLayout();
            this.panelIconoModulo.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelMetricas.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardActivos.SuspendLayout();
            this.cardEspecialidades.SuspendLayout();
            this.panelGridContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctores)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // panelCardPrincipal
            //
            this.panelCardPrincipal.BackColor = Tema.Superficie;
            this.panelCardPrincipal.Controls.Add(this.panelFooter);
            this.panelCardPrincipal.Controls.Add(this.panelGridContenedor);
            this.panelCardPrincipal.Controls.Add(this.panelMetricas);
            this.panelCardPrincipal.Controls.Add(this.panelToolbar);
            this.panelCardPrincipal.Controls.Add(this.panelHeaderModulo);
            this.panelCardPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelCardPrincipal.Name = "panelCardPrincipal";
            this.panelCardPrincipal.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.panelCardPrincipal.Size = new System.Drawing.Size(1085, 718);
            this.panelCardPrincipal.TabIndex = 0;
            //
            // panelHeaderModulo
            //
            this.panelHeaderModulo.Controls.Add(this.btnNuevo);
            this.panelHeaderModulo.Controls.Add(this.lblSubtitulo);
            this.panelHeaderModulo.Controls.Add(this.lblTitulo);
            this.panelHeaderModulo.Controls.Add(this.panelIconoModulo);
            this.panelHeaderModulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderModulo.Height = 60;
            this.panelHeaderModulo.Location = new System.Drawing.Point(24, 20);
            this.panelHeaderModulo.Name = "panelHeaderModulo";
            this.panelHeaderModulo.Size = new System.Drawing.Size(1037, 60);
            this.panelHeaderModulo.TabIndex = 0;
            //
            // panelIconoModulo
            //
            this.panelIconoModulo.BackColor = System.Drawing.Color.FromArgb(226, 238, 248);
            this.panelIconoModulo.Controls.Add(this.lblIconoModulo);
            this.panelIconoModulo.Location = new System.Drawing.Point(0, 4);
            this.panelIconoModulo.Name = "panelIconoModulo";
            this.panelIconoModulo.Size = new System.Drawing.Size(46, 46);
            this.panelIconoModulo.TabIndex = 0;
            //
            // lblIconoModulo
            //
            this.lblIconoModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconoModulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 16F);
            this.lblIconoModulo.ForeColor = Tema.AzulPrimario;
            this.lblIconoModulo.Location = new System.Drawing.Point(0, 0);
            this.lblIconoModulo.Name = "lblIconoModulo";
            this.lblIconoModulo.Size = new System.Drawing.Size(46, 46);
            this.lblIconoModulo.TabIndex = 0;
            this.lblIconoModulo.Text = "🩺";
            this.lblIconoModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(54, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Doctores";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteAyuda;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(56, 35);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Catálogo y administración del cuerpo médico de la red rural.";
            //
            // btnNuevo
            //
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = Tema.AzulPrimario;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = Tema.FuenteBoton;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(877, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(160, 42);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "＋  Nuevo doctor";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // panelToolbar
            //
            this.panelToolbar.Controls.Add(this.panelBuscar);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Height = 52;
            this.panelToolbar.Location = new System.Drawing.Point(24, 80);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1037, 52);
            this.panelToolbar.TabIndex = 1;
            //
            // panelBuscar
            //
            this.panelBuscar.BackColor = System.Drawing.Color.White;
            this.panelBuscar.Controls.Add(this.btnLimpiarBusqueda);
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Controls.Add(this.lblIconoBuscar);
            this.panelBuscar.Location = new System.Drawing.Point(0, 6);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(460, 40);
            this.panelBuscar.TabIndex = 0;
            //
            // lblIconoBuscar
            //
            this.lblIconoBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F);
            this.lblIconoBuscar.ForeColor = Tema.TextoSecundario;
            this.lblIconoBuscar.Location = new System.Drawing.Point(8, 6);
            this.lblIconoBuscar.Name = "lblIconoBuscar";
            this.lblIconoBuscar.Size = new System.Drawing.Size(26, 26);
            this.lblIconoBuscar.TabIndex = 0;
            this.lblIconoBuscar.Text = "🔍";
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font(Tema.FamiliaFuente, 10.5F);
            this.txtBuscar.ForeColor = Tema.TextoPrincipal;
            this.txtBuscar.Location = new System.Drawing.Point(38, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(384, 19);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // btnLimpiarBusqueda
            //
            this.btnLimpiarBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.btnLimpiarBusqueda.ForeColor = Tema.TextoSecundario;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(426, 6);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(28, 28);
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "✕";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Visible = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            //
            // panelMetricas
            //
            this.panelMetricas.Controls.Add(this.cardEspecialidades);
            this.panelMetricas.Controls.Add(this.cardActivos);
            this.panelMetricas.Controls.Add(this.cardTotal);
            this.panelMetricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetricas.Height = 84;
            this.panelMetricas.Location = new System.Drawing.Point(24, 132);
            this.panelMetricas.Name = "panelMetricas";
            this.panelMetricas.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelMetricas.Size = new System.Drawing.Size(1037, 84);
            this.panelMetricas.TabIndex = 2;
            //
            // cardTotal
            //
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(237, 245, 250);
            this.cardTotal.Controls.Add(this.lblTotalNum);
            this.cardTotal.Controls.Add(this.lblTotalTitulo);
            this.cardTotal.Controls.Add(this.lblIconoTotal);
            this.cardTotal.Location = new System.Drawing.Point(0, 6);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(330, 68);
            this.cardTotal.TabIndex = 0;
            //
            // lblIconoTotal
            //
            this.lblIconoTotal.BackColor = System.Drawing.Color.FromArgb(216, 235, 247);
            this.lblIconoTotal.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoTotal.ForeColor = Tema.AzulPrimario;
            this.lblIconoTotal.Location = new System.Drawing.Point(12, 14);
            this.lblIconoTotal.Name = "lblIconoTotal";
            this.lblIconoTotal.Size = new System.Drawing.Size(40, 40);
            this.lblIconoTotal.TabIndex = 0;
            this.lblIconoTotal.Text = "🩺";
            this.lblIconoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTotalTitulo
            //
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = Tema.FuenteMetricaLabel;
            this.lblTotalTitulo.ForeColor = Tema.TextoSecundario;
            this.lblTotalTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(126, 17);
            this.lblTotalTitulo.TabIndex = 1;
            this.lblTotalTitulo.Text = "Doctores registrados";
            //
            // lblTotalNum
            //
            this.lblTotalNum.AutoSize = true;
            this.lblTotalNum.Font = Tema.FuenteMetricaNumero;
            this.lblTotalNum.ForeColor = Tema.AzulOscuro;
            this.lblTotalNum.Location = new System.Drawing.Point(60, 28);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size(33, 37);
            this.lblTotalNum.TabIndex = 2;
            this.lblTotalNum.Text = "0";
            //
            // cardActivos
            //
            this.cardActivos.BackColor = System.Drawing.Color.FromArgb(238, 248, 240);
            this.cardActivos.Controls.Add(this.lblActivosNum);
            this.cardActivos.Controls.Add(this.lblActivosTitulo);
            this.cardActivos.Controls.Add(this.lblIconoActivos);
            this.cardActivos.Location = new System.Drawing.Point(350, 6);
            this.cardActivos.Name = "cardActivos";
            this.cardActivos.Size = new System.Drawing.Size(330, 68);
            this.cardActivos.TabIndex = 1;
            //
            // lblIconoActivos
            //
            this.lblIconoActivos.BackColor = System.Drawing.Color.FromArgb(219, 241, 223);
            this.lblIconoActivos.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoActivos.ForeColor = Tema.VerdeOscuro;
            this.lblIconoActivos.Location = new System.Drawing.Point(12, 14);
            this.lblIconoActivos.Name = "lblIconoActivos";
            this.lblIconoActivos.Size = new System.Drawing.Size(40, 40);
            this.lblIconoActivos.TabIndex = 0;
            this.lblIconoActivos.Text = "👤";
            this.lblIconoActivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblActivosTitulo
            //
            this.lblActivosTitulo.AutoSize = true;
            this.lblActivosTitulo.Font = Tema.FuenteMetricaLabel;
            this.lblActivosTitulo.ForeColor = Tema.TextoSecundario;
            this.lblActivosTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblActivosTitulo.Name = "lblActivosTitulo";
            this.lblActivosTitulo.Size = new System.Drawing.Size(95, 17);
            this.lblActivosTitulo.TabIndex = 1;
            this.lblActivosTitulo.Text = "Médicos activos";
            //
            // lblActivosNum
            //
            this.lblActivosNum.AutoSize = true;
            this.lblActivosNum.Font = Tema.FuenteMetricaNumero;
            this.lblActivosNum.ForeColor = Tema.VerdeOscuro;
            this.lblActivosNum.Location = new System.Drawing.Point(60, 28);
            this.lblActivosNum.Name = "lblActivosNum";
            this.lblActivosNum.Size = new System.Drawing.Size(33, 37);
            this.lblActivosNum.TabIndex = 2;
            this.lblActivosNum.Text = "0";
            //
            // cardEspecialidades
            //
            this.cardEspecialidades.BackColor = System.Drawing.Color.FromArgb(242, 246, 252);
            this.cardEspecialidades.Controls.Add(this.lblEspecialidadesNum);
            this.cardEspecialidades.Controls.Add(this.lblEspecialidadesTitulo);
            this.cardEspecialidades.Controls.Add(this.lblIconoEspecialidades);
            this.cardEspecialidades.Location = new System.Drawing.Point(700, 6);
            this.cardEspecialidades.Name = "cardEspecialidades";
            this.cardEspecialidades.Size = new System.Drawing.Size(330, 68);
            this.cardEspecialidades.TabIndex = 2;
            //
            // lblIconoEspecialidades
            //
            this.lblIconoEspecialidades.BackColor = System.Drawing.Color.FromArgb(226, 235, 247);
            this.lblIconoEspecialidades.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F);
            this.lblIconoEspecialidades.ForeColor = Tema.AzulPrimario;
            this.lblIconoEspecialidades.Location = new System.Drawing.Point(12, 14);
            this.lblIconoEspecialidades.Name = "lblIconoEspecialidades";
            this.lblIconoEspecialidades.Size = new System.Drawing.Size(40, 40);
            this.lblIconoEspecialidades.TabIndex = 0;
            this.lblIconoEspecialidades.Text = "🏥";
            this.lblIconoEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEspecialidadesTitulo
            //
            this.lblEspecialidadesTitulo.AutoSize = true;
            this.lblEspecialidadesTitulo.Font = Tema.FuenteMetricaLabel;
            this.lblEspecialidadesTitulo.ForeColor = Tema.TextoSecundario;
            this.lblEspecialidadesTitulo.Location = new System.Drawing.Point(62, 12);
            this.lblEspecialidadesTitulo.Name = "lblEspecialidadesTitulo";
            this.lblEspecialidadesTitulo.Size = new System.Drawing.Size(130, 17);
            this.lblEspecialidadesTitulo.TabIndex = 1;
            this.lblEspecialidadesTitulo.Text = "Con hospital asignado";
            //
            // lblEspecialidadesNum
            //
            this.lblEspecialidadesNum.AutoSize = true;
            this.lblEspecialidadesNum.Font = Tema.FuenteMetricaNumero;
            this.lblEspecialidadesNum.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidadesNum.Location = new System.Drawing.Point(60, 28);
            this.lblEspecialidadesNum.Name = "lblEspecialidadesNum";
            this.lblEspecialidadesNum.Size = new System.Drawing.Size(33, 37);
            this.lblEspecialidadesNum.TabIndex = 2;
            this.lblEspecialidadesNum.Text = "0";
            //
            // panelGridContenedor
            //
            this.panelGridContenedor.Controls.Add(this.dgvDoctores);
            this.panelGridContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridContenedor.Location = new System.Drawing.Point(24, 216);
            this.panelGridContenedor.Name = "panelGridContenedor";
            this.panelGridContenedor.Padding = new System.Windows.Forms.Padding(0, 10, 0, 8);
            this.panelGridContenedor.Size = new System.Drawing.Size(1037, 444);
            this.panelGridContenedor.TabIndex = 3;
            //
            // dgvDoctores
            //
            this.dgvDoctores.AllowUserToAddRows = false;
            this.dgvDoctores.AllowUserToDeleteRows = false;
            this.dgvDoctores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoctores.Name = "dgvDoctores";
            this.dgvDoctores.ReadOnly = true;
            this.dgvDoctores.TabIndex = 0;
            this.dgvDoctores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctores_CellContentClick);
            this.dgvDoctores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoctores_CellMouseMove);
            this.dgvDoctores.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDoctores_CellPainting);
            //
            // panelFooter
            //
            this.panelFooter.Controls.Add(this.btnPaginaSig);
            this.panelFooter.Controls.Add(this.btnPaginaActual);
            this.panelFooter.Controls.Add(this.btnPaginaAnt);
            this.panelFooter.Controls.Add(this.lblConteo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Height = 38;
            this.panelFooter.Location = new System.Drawing.Point(24, 660);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1037, 38);
            this.panelFooter.TabIndex = 4;
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = Tema.FuentePequena;
            this.lblConteo.ForeColor = Tema.TextoSecundario;
            this.lblConteo.Location = new System.Drawing.Point(0, 12);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(170, 15);
            this.lblConteo.TabIndex = 0;
            this.lblConteo.Text = "Mostrando 0 de 0 doctores";
            //
            // btnPaginaAnt
            //
            this.btnPaginaAnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginaAnt.BackColor = System.Drawing.Color.White;
            this.btnPaginaAnt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnt.FlatAppearance.BorderColor = Tema.Borde;
            this.btnPaginaAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaAnt.Font = Tema.FuentePequena;
            this.btnPaginaAnt.ForeColor = Tema.TextoSecundario;
            this.btnPaginaAnt.Location = new System.Drawing.Point(925, 4);
            this.btnPaginaAnt.Name = "btnPaginaAnt";
            this.btnPaginaAnt.Size = new System.Drawing.Size(32, 30);
            this.btnPaginaAnt.TabIndex = 1;
            this.btnPaginaAnt.Text = "‹";
            this.btnPaginaAnt.UseVisualStyleBackColor = false;
            //
            // btnPaginaActual
            //
            this.btnPaginaActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginaActual.BackColor = Tema.AzulPrimario;
            this.btnPaginaActual.FlatAppearance.BorderSize = 0;
            this.btnPaginaActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaActual.Font = Tema.FuentePequena;
            this.btnPaginaActual.ForeColor = System.Drawing.Color.White;
            this.btnPaginaActual.Location = new System.Drawing.Point(963, 4);
            this.btnPaginaActual.Name = "btnPaginaActual";
            this.btnPaginaActual.Size = new System.Drawing.Size(32, 30);
            this.btnPaginaActual.TabIndex = 2;
            this.btnPaginaActual.Text = "1";
            this.btnPaginaActual.UseVisualStyleBackColor = false;
            //
            // btnPaginaSig
            //
            this.btnPaginaSig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginaSig.BackColor = System.Drawing.Color.White;
            this.btnPaginaSig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSig.FlatAppearance.BorderColor = Tema.Borde;
            this.btnPaginaSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaSig.Font = Tema.FuentePequena;
            this.btnPaginaSig.ForeColor = Tema.TextoSecundario;
            this.btnPaginaSig.Location = new System.Drawing.Point(1001, 4);
            this.btnPaginaSig.Name = "btnPaginaSig";
            this.btnPaginaSig.Size = new System.Drawing.Size(32, 30);
            this.btnPaginaSig.TabIndex = 3;
            this.btnPaginaSig.Text = "›";
            this.btnPaginaSig.UseVisualStyleBackColor = false;
            //
            // paginaPrincipalDoctores
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(1085, 718);
            this.Controls.Add(this.panelCardPrincipal);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "paginaPrincipalDoctores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanar Rural - Gestión de Doctores";
            this.Load += new System.EventHandler(this.paginaPrincipalDoctores_Load);
            this.Resize += new System.EventHandler(this.paginaPrincipalDoctores_Resize);
            this.panelCardPrincipal.ResumeLayout(false);
            this.panelHeaderModulo.ResumeLayout(false);
            this.panelHeaderModulo.PerformLayout();
            this.panelIconoModulo.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelMetricas.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.cardActivos.ResumeLayout(false);
            this.cardActivos.PerformLayout();
            this.cardEspecialidades.ResumeLayout(false);
            this.cardEspecialidades.PerformLayout();
            this.panelGridContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctores)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCardPrincipal;
        private System.Windows.Forms.Panel panelHeaderModulo;
        private System.Windows.Forms.Panel panelIconoModulo;
        private System.Windows.Forms.Label lblIconoModulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.Label lblIconoBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.Panel panelMetricas;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblIconoTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalNum;
        private System.Windows.Forms.Panel cardActivos;
        private System.Windows.Forms.Label lblIconoActivos;
        private System.Windows.Forms.Label lblActivosTitulo;
        private System.Windows.Forms.Label lblActivosNum;
        private System.Windows.Forms.Panel cardEspecialidades;
        private System.Windows.Forms.Label lblIconoEspecialidades;
        private System.Windows.Forms.Label lblEspecialidadesTitulo;
        private System.Windows.Forms.Label lblEspecialidadesNum;
        private System.Windows.Forms.Panel panelGridContenedor;
        private System.Windows.Forms.DataGridView dgvDoctores;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Button btnPaginaAnt;
        private System.Windows.Forms.Button btnPaginaActual;
        private System.Windows.Forms.Button btnPaginaSig;
    }
}
