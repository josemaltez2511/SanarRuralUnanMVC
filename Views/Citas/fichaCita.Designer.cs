using System.Drawing;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Citas
{
    partial class fichaCita
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
            this.panelCardPaciente = new System.Windows.Forms.Panel();
            this.lblSecPaciente = new System.Windows.Forms.Label();
            this.lblPacienteT = new System.Windows.Forms.Label();
            this.lblPacienteVal = new System.Windows.Forms.Label();
            this.lblCedulaT = new System.Windows.Forms.Label();
            this.lblCedulaVal = new System.Windows.Forms.Label();
            this.lblTelefonoT = new System.Windows.Forms.Label();
            this.lblTelefonoVal = new System.Windows.Forms.Label();
            this.lblDireccionT = new System.Windows.Forms.Label();
            this.lblDireccionVal = new System.Windows.Forms.Label();
            this.panelCardMedico = new System.Windows.Forms.Panel();
            this.lblSecMedico = new System.Windows.Forms.Label();
            this.lblDoctorT = new System.Windows.Forms.Label();
            this.lblDoctorVal = new System.Windows.Forms.Label();
            this.lblEspecialidadT = new System.Windows.Forms.Label();
            this.lblEspecialidadVal = new System.Windows.Forms.Label();
            this.panelCardHospital = new System.Windows.Forms.Panel();
            this.lblSecHospital = new System.Windows.Forms.Label();
            this.lblHospitalT = new System.Windows.Forms.Label();
            this.lblHospitalVal = new System.Windows.Forms.Label();
            this.lblUbicacionT = new System.Windows.Forms.Label();
            this.lblUbicacionVal = new System.Windows.Forms.Label();
            this.panelCardProgramacion = new System.Windows.Forms.Panel();
            this.lblSecProgramacion = new System.Windows.Forms.Label();
            this.lblIdCitaT = new System.Windows.Forms.Label();
            this.lblIdCitaVal = new System.Windows.Forms.Label();
            this.lblFechaHoraT = new System.Windows.Forms.Label();
            this.lblFechaHoraVal = new System.Windows.Forms.Label();
            this.lblFechaRegistroT = new System.Windows.Forms.Label();
            this.lblFechaRegistroVal = new System.Windows.Forms.Label();
            this.lblEstadoDetalleT = new System.Windows.Forms.Label();
            this.lblEstadoDetalleVal = new System.Windows.Forms.Label();
            this.panelCardMotivo = new System.Windows.Forms.Panel();
            this.lblSecMotivo = new System.Windows.Forms.Label();
            this.panelMotivoBox = new System.Windows.Forms.Panel();
            this.lblMotivoVal = new System.Windows.Forms.Label();
            this.panelCardAcciones = new System.Windows.Forms.Panel();
            this.lblSecAcciones = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNoAsistio = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelBadgeEstado.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelCardPaciente.SuspendLayout();
            this.panelCardMedico.SuspendLayout();
            this.panelCardHospital.SuspendLayout();
            this.panelCardProgramacion.SuspendLayout();
            this.panelCardMotivo.SuspendLayout();
            this.panelMotivoBox.SuspendLayout();
            this.panelCardAcciones.SuspendLayout();
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
            this.panelEncabezado.Height = 94;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.panelEncabezado.Size = new System.Drawing.Size(940, 94);
            this.panelEncabezado.TabIndex = 0;
            //
            // lblPrefijo
            //
            this.lblPrefijo.AutoSize = true;
            this.lblPrefijo.Font = Tema.FuenteAyuda;
            this.lblPrefijo.ForeColor = Tema.AzulPrimario;
            this.lblPrefijo.Location = new System.Drawing.Point(24, 12);
            this.lblPrefijo.Name = "lblPrefijo";
            this.lblPrefijo.Size = new System.Drawing.Size(205, 15);
            this.lblPrefijo.TabIndex = 0;
            this.lblPrefijo.Text = "DETALLE DE CITA MÉDICA PROGRAMADA";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = Tema.FuenteTitulo;
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(22, 28);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(270, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Cita # 0 — Paciente";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = Tema.FuenteSubtitulo;
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 64);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(275, 20);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Fecha programada | Sede hospitalaria";
            //
            // panelBadgeEstado
            //
            this.panelBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBadgeEstado.BackColor = Tema.FondoSecundario;
            this.panelBadgeEstado.Controls.Add(this.lblEstadoBadge);
            this.panelBadgeEstado.Location = new System.Drawing.Point(670, 28);
            this.panelBadgeEstado.Name = "panelBadgeEstado";
            this.panelBadgeEstado.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.panelBadgeEstado.Size = new System.Drawing.Size(130, 36);
            this.panelBadgeEstado.TabIndex = 3;
            //
            // lblEstadoBadge
            //
            this.lblEstadoBadge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoBadge.Font = Tema.FuenteBoton;
            this.lblEstadoBadge.ForeColor = Tema.VerdeOscuro;
            this.lblEstadoBadge.Location = new System.Drawing.Point(12, 6);
            this.lblEstadoBadge.Name = "lblEstadoBadge";
            this.lblEstadoBadge.Size = new System.Drawing.Size(106, 24);
            this.lblEstadoBadge.TabIndex = 0;
            this.lblEstadoBadge.Text = "Confirmada";
            this.lblEstadoBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnCerrarTop
            //
            this.btnCerrarTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarTop.BackColor = Tema.Superficie;
            this.btnCerrarTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarTop.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrarTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarTop.Font = Tema.FuenteLabelCampo;
            this.btnCerrarTop.ForeColor = Tema.TextoSecundario;
            this.btnCerrarTop.Location = new System.Drawing.Point(814, 26);
            this.btnCerrarTop.Name = "btnCerrarTop";
            this.btnCerrarTop.Size = new System.Drawing.Size(100, 38);
            this.btnCerrarTop.TabIndex = 4;
            this.btnCerrarTop.Text = "✕ Cerrar";
            this.btnCerrarTop.UseVisualStyleBackColor = false;
            //
            // panelContenido
            //
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = Tema.Fondo;
            this.panelContenido.Controls.Add(this.panelCardAcciones);
            this.panelContenido.Controls.Add(this.panelCardMotivo);
            this.panelContenido.Controls.Add(this.panelCardProgramacion);
            this.panelContenido.Controls.Add(this.panelCardHospital);
            this.panelContenido.Controls.Add(this.panelCardMedico);
            this.panelContenido.Controls.Add(this.panelCardPaciente);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 94);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(20, 16, 20, 20);
            this.panelContenido.Size = new System.Drawing.Size(940, 606);
            this.panelContenido.TabIndex = 1;
            //
            // panelCardPaciente
            //
            this.panelCardPaciente.BackColor = Tema.Superficie;
            this.panelCardPaciente.Controls.Add(this.lblDireccionVal);
            this.panelCardPaciente.Controls.Add(this.lblDireccionT);
            this.panelCardPaciente.Controls.Add(this.lblTelefonoVal);
            this.panelCardPaciente.Controls.Add(this.lblTelefonoT);
            this.panelCardPaciente.Controls.Add(this.lblCedulaVal);
            this.panelCardPaciente.Controls.Add(this.lblCedulaT);
            this.panelCardPaciente.Controls.Add(this.lblPacienteVal);
            this.panelCardPaciente.Controls.Add(this.lblPacienteT);
            this.panelCardPaciente.Controls.Add(this.lblSecPaciente);
            this.panelCardPaciente.Location = new System.Drawing.Point(20, 16);
            this.panelCardPaciente.Name = "panelCardPaciente";
            this.panelCardPaciente.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelCardPaciente.Size = new System.Drawing.Size(880, 115);
            this.panelCardPaciente.TabIndex = 0;
            //
            // lblSecPaciente
            //
            this.lblSecPaciente.AutoSize = true;
            this.lblSecPaciente.Font = Tema.FuenteBoton;
            this.lblSecPaciente.ForeColor = Tema.AzulPrimario;
            this.lblSecPaciente.Location = new System.Drawing.Point(16, 12);
            this.lblSecPaciente.Name = "lblSecPaciente";
            this.lblSecPaciente.Size = new System.Drawing.Size(200, 19);
            this.lblSecPaciente.TabIndex = 0;
            this.lblSecPaciente.Text = "👤 INFORMACIÓN DEL PACIENTE";
            //
            // lblPacienteT
            //
            this.lblPacienteT.AutoSize = true;
            this.lblPacienteT.Font = Tema.FuentePequena;
            this.lblPacienteT.ForeColor = Tema.TextoSecundario;
            this.lblPacienteT.Location = new System.Drawing.Point(18, 40);
            this.lblPacienteT.Name = "lblPacienteT";
            this.lblPacienteT.Size = new System.Drawing.Size(107, 15);
            this.lblPacienteT.TabIndex = 1;
            this.lblPacienteT.Text = "Nombre Completo:";
            //
            // lblPacienteVal
            //
            this.lblPacienteVal.AutoSize = true;
            this.lblPacienteVal.Font = Tema.FuenteLabelCampo;
            this.lblPacienteVal.ForeColor = Tema.TextoPrincipal;
            this.lblPacienteVal.Location = new System.Drawing.Point(18, 58);
            this.lblPacienteVal.Name = "lblPacienteVal";
            this.lblPacienteVal.Size = new System.Drawing.Size(15, 17);
            this.lblPacienteVal.TabIndex = 2;
            this.lblPacienteVal.Text = "-";
            //
            // lblCedulaT
            //
            this.lblCedulaT.AutoSize = true;
            this.lblCedulaT.Font = Tema.FuentePequena;
            this.lblCedulaT.ForeColor = Tema.TextoSecundario;
            this.lblCedulaT.Location = new System.Drawing.Point(340, 40);
            this.lblCedulaT.Name = "lblCedulaT";
            this.lblCedulaT.Size = new System.Drawing.Size(122, 15);
            this.lblCedulaT.TabIndex = 3;
            this.lblCedulaT.Text = "Cédula de Identidad:";
            //
            // lblCedulaVal
            //
            this.lblCedulaVal.AutoSize = true;
            this.lblCedulaVal.Font = Tema.FuenteLabelCampo;
            this.lblCedulaVal.ForeColor = Tema.TextoPrincipal;
            this.lblCedulaVal.Location = new System.Drawing.Point(340, 58);
            this.lblCedulaVal.Name = "lblCedulaVal";
            this.lblCedulaVal.Size = new System.Drawing.Size(15, 17);
            this.lblCedulaVal.TabIndex = 4;
            this.lblCedulaVal.Text = "-";
            //
            // lblTelefonoT
            //
            this.lblTelefonoT.AutoSize = true;
            this.lblTelefonoT.Font = Tema.FuentePequena;
            this.lblTelefonoT.ForeColor = Tema.TextoSecundario;
            this.lblTelefonoT.Location = new System.Drawing.Point(580, 40);
            this.lblTelefonoT.Name = "lblTelefonoT";
            this.lblTelefonoT.Size = new System.Drawing.Size(124, 15);
            this.lblTelefonoT.TabIndex = 5;
            this.lblTelefonoT.Text = "Teléfono de Contacto:";
            //
            // lblTelefonoVal
            //
            this.lblTelefonoVal.AutoSize = true;
            this.lblTelefonoVal.Font = Tema.FuenteLabelCampo;
            this.lblTelefonoVal.ForeColor = Tema.TextoPrincipal;
            this.lblTelefonoVal.Location = new System.Drawing.Point(580, 58);
            this.lblTelefonoVal.Name = "lblTelefonoVal";
            this.lblTelefonoVal.Size = new System.Drawing.Size(15, 17);
            this.lblTelefonoVal.TabIndex = 6;
            this.lblTelefonoVal.Text = "-";
            //
            // lblDireccionT
            //
            this.lblDireccionT.AutoSize = true;
            this.lblDireccionT.Font = Tema.FuentePequena;
            this.lblDireccionT.ForeColor = Tema.TextoSecundario;
            this.lblDireccionT.Location = new System.Drawing.Point(18, 82);
            this.lblDireccionT.Name = "lblDireccionT";
            this.lblDireccionT.Size = new System.Drawing.Size(130, 15);
            this.lblDireccionT.TabIndex = 7;
            this.lblDireccionT.Text = "Comunidad / Dirección:";
            //
            // lblDireccionVal
            //
            this.lblDireccionVal.AutoSize = true;
            this.lblDireccionVal.Font = Tema.FuenteCuerpo;
            this.lblDireccionVal.ForeColor = Tema.TextoPrincipal;
            this.lblDireccionVal.Location = new System.Drawing.Point(160, 80);
            this.lblDireccionVal.Name = "lblDireccionVal";
            this.lblDireccionVal.Size = new System.Drawing.Size(15, 20);
            this.lblDireccionVal.TabIndex = 8;
            this.lblDireccionVal.Text = "-";
            //
            // panelCardMedico
            //
            this.panelCardMedico.BackColor = Tema.Superficie;
            this.panelCardMedico.Controls.Add(this.lblEspecialidadVal);
            this.panelCardMedico.Controls.Add(this.lblEspecialidadT);
            this.panelCardMedico.Controls.Add(this.lblDoctorVal);
            this.panelCardMedico.Controls.Add(this.lblDoctorT);
            this.panelCardMedico.Controls.Add(this.lblSecMedico);
            this.panelCardMedico.Location = new System.Drawing.Point(20, 141);
            this.panelCardMedico.Name = "panelCardMedico";
            this.panelCardMedico.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelCardMedico.Size = new System.Drawing.Size(880, 85);
            this.panelCardMedico.TabIndex = 1;
            //
            // lblSecMedico
            //
            this.lblSecMedico.AutoSize = true;
            this.lblSecMedico.Font = Tema.FuenteBoton;
            this.lblSecMedico.ForeColor = Tema.AzulPrimario;
            this.lblSecMedico.Location = new System.Drawing.Point(16, 12);
            this.lblSecMedico.Name = "lblSecMedico";
            this.lblSecMedico.Size = new System.Drawing.Size(185, 19);
            this.lblSecMedico.TabIndex = 0;
            this.lblSecMedico.Text = "🩺 ASIGNACIÓN MÉDICA";
            //
            // lblDoctorT
            //
            this.lblDoctorT.AutoSize = true;
            this.lblDoctorT.Font = Tema.FuentePequena;
            this.lblDoctorT.ForeColor = Tema.TextoSecundario;
            this.lblDoctorT.Location = new System.Drawing.Point(18, 38);
            this.lblDoctorT.Name = "lblDoctorT";
            this.lblDoctorT.Size = new System.Drawing.Size(107, 15);
            this.lblDoctorT.TabIndex = 1;
            this.lblDoctorT.Text = "Médico Asignado:";
            //
            // lblDoctorVal
            //
            this.lblDoctorVal.AutoSize = true;
            this.lblDoctorVal.Font = Tema.FuenteLabelCampo;
            this.lblDoctorVal.ForeColor = Tema.TextoPrincipal;
            this.lblDoctorVal.Location = new System.Drawing.Point(18, 56);
            this.lblDoctorVal.Name = "lblDoctorVal";
            this.lblDoctorVal.Size = new System.Drawing.Size(15, 17);
            this.lblDoctorVal.TabIndex = 2;
            this.lblDoctorVal.Text = "-";
            //
            // lblEspecialidadT
            //
            this.lblEspecialidadT.AutoSize = true;
            this.lblEspecialidadT.Font = Tema.FuentePequena;
            this.lblEspecialidadT.ForeColor = Tema.TextoSecundario;
            this.lblEspecialidadT.Location = new System.Drawing.Point(340, 38);
            this.lblEspecialidadT.Name = "lblEspecialidadT";
            this.lblEspecialidadT.Size = new System.Drawing.Size(117, 15);
            this.lblEspecialidadT.TabIndex = 3;
            this.lblEspecialidadT.Text = "Especialidad Clínica:";
            //
            // lblEspecialidadVal
            //
            this.lblEspecialidadVal.AutoSize = true;
            this.lblEspecialidadVal.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidadVal.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidadVal.Location = new System.Drawing.Point(340, 56);
            this.lblEspecialidadVal.Name = "lblEspecialidadVal";
            this.lblEspecialidadVal.Size = new System.Drawing.Size(15, 17);
            this.lblEspecialidadVal.TabIndex = 4;
            this.lblEspecialidadVal.Text = "-";
            //
            // panelCardHospital
            //
            this.panelCardHospital.BackColor = Tema.Superficie;
            this.panelCardHospital.Controls.Add(this.lblUbicacionVal);
            this.panelCardHospital.Controls.Add(this.lblUbicacionT);
            this.panelCardHospital.Controls.Add(this.lblHospitalVal);
            this.panelCardHospital.Controls.Add(this.lblHospitalT);
            this.panelCardHospital.Controls.Add(this.lblSecHospital);
            this.panelCardHospital.Location = new System.Drawing.Point(20, 236);
            this.panelCardHospital.Name = "panelCardHospital";
            this.panelCardHospital.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelCardHospital.Size = new System.Drawing.Size(880, 85);
            this.panelCardHospital.TabIndex = 2;
            //
            // lblSecHospital
            //
            this.lblSecHospital.AutoSize = true;
            this.lblSecHospital.Font = Tema.FuenteBoton;
            this.lblSecHospital.ForeColor = Tema.AzulPrimario;
            this.lblSecHospital.Location = new System.Drawing.Point(16, 12);
            this.lblSecHospital.Name = "lblSecHospital";
            this.lblSecHospital.Size = new System.Drawing.Size(195, 19);
            this.lblSecHospital.TabIndex = 0;
            this.lblSecHospital.Text = "🏥 SEDE HOSPITALARIA";
            //
            // lblHospitalT
            //
            this.lblHospitalT.AutoSize = true;
            this.lblHospitalT.Font = Tema.FuentePequena;
            this.lblHospitalT.ForeColor = Tema.TextoSecundario;
            this.lblHospitalT.Location = new System.Drawing.Point(18, 38);
            this.lblHospitalT.Name = "lblHospitalT";
            this.lblHospitalT.Size = new System.Drawing.Size(147, 15);
            this.lblHospitalT.TabIndex = 1;
            this.lblHospitalT.Text = "Hospital / Centro de Salud:";
            //
            // lblHospitalVal
            //
            this.lblHospitalVal.AutoSize = true;
            this.lblHospitalVal.Font = Tema.FuenteLabelCampo;
            this.lblHospitalVal.ForeColor = Tema.TextoPrincipal;
            this.lblHospitalVal.Location = new System.Drawing.Point(18, 56);
            this.lblHospitalVal.Name = "lblHospitalVal";
            this.lblHospitalVal.Size = new System.Drawing.Size(15, 17);
            this.lblHospitalVal.TabIndex = 2;
            this.lblHospitalVal.Text = "-";
            //
            // lblUbicacionT
            //
            this.lblUbicacionT.AutoSize = true;
            this.lblUbicacionT.Font = Tema.FuentePequena;
            this.lblUbicacionT.ForeColor = Tema.TextoSecundario;
            this.lblUbicacionT.Location = new System.Drawing.Point(340, 38);
            this.lblUbicacionT.Name = "lblUbicacionT";
            this.lblUbicacionT.Size = new System.Drawing.Size(150, 15);
            this.lblUbicacionT.TabIndex = 3;
            this.lblUbicacionT.Text = "Departamento / Municipio:";
            //
            // lblUbicacionVal
            //
            this.lblUbicacionVal.AutoSize = true;
            this.lblUbicacionVal.Font = Tema.FuenteLabelCampo;
            this.lblUbicacionVal.ForeColor = Tema.TextoPrincipal;
            this.lblUbicacionVal.Location = new System.Drawing.Point(340, 56);
            this.lblUbicacionVal.Name = "lblUbicacionVal";
            this.lblUbicacionVal.Size = new System.Drawing.Size(15, 17);
            this.lblUbicacionVal.TabIndex = 4;
            this.lblUbicacionVal.Text = "-";
            //
            // panelCardProgramacion
            //
            this.panelCardProgramacion.BackColor = Tema.Superficie;
            this.panelCardProgramacion.Controls.Add(this.lblEstadoDetalleVal);
            this.panelCardProgramacion.Controls.Add(this.lblEstadoDetalleT);
            this.panelCardProgramacion.Controls.Add(this.lblFechaRegistroVal);
            this.panelCardProgramacion.Controls.Add(this.lblFechaRegistroT);
            this.panelCardProgramacion.Controls.Add(this.lblFechaHoraVal);
            this.panelCardProgramacion.Controls.Add(this.lblFechaHoraT);
            this.panelCardProgramacion.Controls.Add(this.lblIdCitaVal);
            this.panelCardProgramacion.Controls.Add(this.lblIdCitaT);
            this.panelCardProgramacion.Controls.Add(this.lblSecProgramacion);
            this.panelCardProgramacion.Location = new System.Drawing.Point(20, 331);
            this.panelCardProgramacion.Name = "panelCardProgramacion";
            this.panelCardProgramacion.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelCardProgramacion.Size = new System.Drawing.Size(880, 85);
            this.panelCardProgramacion.TabIndex = 3;
            //
            // lblSecProgramacion
            //
            this.lblSecProgramacion.AutoSize = true;
            this.lblSecProgramacion.Font = Tema.FuenteBoton;
            this.lblSecProgramacion.ForeColor = Tema.AzulPrimario;
            this.lblSecProgramacion.Location = new System.Drawing.Point(16, 12);
            this.lblSecProgramacion.Name = "lblSecProgramacion";
            this.lblSecProgramacion.Size = new System.Drawing.Size(260, 19);
            this.lblSecProgramacion.TabIndex = 0;
            this.lblSecProgramacion.Text = "📅 PROGRAMACIÓN DE LA ATENCIÓN";
            //
            // lblIdCitaT
            //
            this.lblIdCitaT.AutoSize = true;
            this.lblIdCitaT.Font = Tema.FuentePequena;
            this.lblIdCitaT.ForeColor = Tema.TextoSecundario;
            this.lblIdCitaT.Location = new System.Drawing.Point(18, 38);
            this.lblIdCitaT.Name = "lblIdCitaT";
            this.lblIdCitaT.Size = new System.Drawing.Size(95, 15);
            this.lblIdCitaT.TabIndex = 1;
            this.lblIdCitaT.Text = "Número de Cita:";
            //
            // lblIdCitaVal
            //
            this.lblIdCitaVal.AutoSize = true;
            this.lblIdCitaVal.Font = Tema.FuenteLabelCampo;
            this.lblIdCitaVal.ForeColor = Tema.TextoPrincipal;
            this.lblIdCitaVal.Location = new System.Drawing.Point(18, 56);
            this.lblIdCitaVal.Name = "lblIdCitaVal";
            this.lblIdCitaVal.Size = new System.Drawing.Size(15, 17);
            this.lblIdCitaVal.TabIndex = 2;
            this.lblIdCitaVal.Text = "-";
            //
            // lblFechaHoraT
            //
            this.lblFechaHoraT.AutoSize = true;
            this.lblFechaHoraT.Font = Tema.FuentePequena;
            this.lblFechaHoraT.ForeColor = Tema.TextoSecundario;
            this.lblFechaHoraT.Location = new System.Drawing.Point(160, 38);
            this.lblFechaHoraT.Name = "lblFechaHoraT";
            this.lblFechaHoraT.Size = new System.Drawing.Size(135, 15);
            this.lblFechaHoraT.TabIndex = 3;
            this.lblFechaHoraT.Text = "Fecha y Hora Prevista:";
            //
            // lblFechaHoraVal
            //
            this.lblFechaHoraVal.AutoSize = true;
            this.lblFechaHoraVal.Font = Tema.FuenteLabelCampo;
            this.lblFechaHoraVal.ForeColor = Tema.AzulOscuro;
            this.lblFechaHoraVal.Location = new System.Drawing.Point(160, 56);
            this.lblFechaHoraVal.Name = "lblFechaHoraVal";
            this.lblFechaHoraVal.Size = new System.Drawing.Size(15, 17);
            this.lblFechaHoraVal.TabIndex = 4;
            this.lblFechaHoraVal.Text = "-";
            //
            // lblFechaRegistroT
            //
            this.lblFechaRegistroT.AutoSize = true;
            this.lblFechaRegistroT.Font = Tema.FuentePequena;
            this.lblFechaRegistroT.ForeColor = Tema.TextoSecundario;
            this.lblFechaRegistroT.Location = new System.Drawing.Point(440, 38);
            this.lblFechaRegistroT.Name = "lblFechaRegistroT";
            this.lblFechaRegistroT.Size = new System.Drawing.Size(107, 15);
            this.lblFechaRegistroT.TabIndex = 5;
            this.lblFechaRegistroT.Text = "Fecha de Registro:";
            //
            // lblFechaRegistroVal
            //
            this.lblFechaRegistroVal.AutoSize = true;
            this.lblFechaRegistroVal.Font = Tema.FuenteLabelCampo;
            this.lblFechaRegistroVal.ForeColor = Tema.TextoPrincipal;
            this.lblFechaRegistroVal.Location = new System.Drawing.Point(440, 56);
            this.lblFechaRegistroVal.Name = "lblFechaRegistroVal";
            this.lblFechaRegistroVal.Size = new System.Drawing.Size(15, 17);
            this.lblFechaRegistroVal.TabIndex = 6;
            this.lblFechaRegistroVal.Text = "-";
            //
            // lblEstadoDetalleT
            //
            this.lblEstadoDetalleT.AutoSize = true;
            this.lblEstadoDetalleT.Font = Tema.FuentePequena;
            this.lblEstadoDetalleT.ForeColor = Tema.TextoSecundario;
            this.lblEstadoDetalleT.Location = new System.Drawing.Point(680, 38);
            this.lblEstadoDetalleT.Name = "lblEstadoDetalleT";
            this.lblEstadoDetalleT.Size = new System.Drawing.Size(84, 15);
            this.lblEstadoDetalleT.TabIndex = 7;
            this.lblEstadoDetalleT.Text = "Estado Oficial:";
            //
            // lblEstadoDetalleVal
            //
            this.lblEstadoDetalleVal.AutoSize = true;
            this.lblEstadoDetalleVal.Font = Tema.FuenteLabelCampo;
            this.lblEstadoDetalleVal.ForeColor = Tema.VerdeOscuro;
            this.lblEstadoDetalleVal.Location = new System.Drawing.Point(680, 56);
            this.lblEstadoDetalleVal.Name = "lblEstadoDetalleVal";
            this.lblEstadoDetalleVal.Size = new System.Drawing.Size(15, 17);
            this.lblEstadoDetalleVal.TabIndex = 8;
            this.lblEstadoDetalleVal.Text = "-";
            //
            // panelCardMotivo
            //
            this.panelCardMotivo.BackColor = Tema.Superficie;
            this.panelCardMotivo.Controls.Add(this.panelMotivoBox);
            this.panelCardMotivo.Controls.Add(this.lblSecMotivo);
            this.panelCardMotivo.Location = new System.Drawing.Point(20, 426);
            this.panelCardMotivo.Name = "panelCardMotivo";
            this.panelCardMotivo.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelCardMotivo.Size = new System.Drawing.Size(880, 110);
            this.panelCardMotivo.TabIndex = 4;
            //
            // lblSecMotivo
            //
            this.lblSecMotivo.AutoSize = true;
            this.lblSecMotivo.Font = Tema.FuenteBoton;
            this.lblSecMotivo.ForeColor = Tema.AzulPrimario;
            this.lblSecMotivo.Location = new System.Drawing.Point(16, 12);
            this.lblSecMotivo.Name = "lblSecMotivo";
            this.lblSecMotivo.Size = new System.Drawing.Size(215, 19);
            this.lblSecMotivo.TabIndex = 0;
            this.lblSecMotivo.Text = "📋 MOTIVO DE LA CONSULTA";
            //
            // panelMotivoBox
            //
            this.panelMotivoBox.BackColor = Tema.FondoSecundario;
            this.panelMotivoBox.Controls.Add(this.lblMotivoVal);
            this.panelMotivoBox.Location = new System.Drawing.Point(18, 38);
            this.panelMotivoBox.Name = "panelMotivoBox";
            this.panelMotivoBox.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelMotivoBox.Size = new System.Drawing.Size(844, 58);
            this.panelMotivoBox.TabIndex = 1;
            //
            // lblMotivoVal
            //
            this.lblMotivoVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMotivoVal.Font = Tema.FuenteCuerpo;
            this.lblMotivoVal.ForeColor = Tema.TextoPrincipal;
            this.lblMotivoVal.Location = new System.Drawing.Point(12, 10);
            this.lblMotivoVal.Name = "lblMotivoVal";
            this.lblMotivoVal.Size = new System.Drawing.Size(820, 38);
            this.lblMotivoVal.TabIndex = 0;
            this.lblMotivoVal.Text = "-";
            //
            // panelCardAcciones
            //
            this.panelCardAcciones.BackColor = Tema.Superficie;
            this.panelCardAcciones.Controls.Add(this.btnCerrar);
            this.panelCardAcciones.Controls.Add(this.btnNoAsistio);
            this.panelCardAcciones.Controls.Add(this.btnCancelar);
            this.panelCardAcciones.Controls.Add(this.btnEditar);
            this.panelCardAcciones.Controls.Add(this.btnConfirmar);
            this.panelCardAcciones.Controls.Add(this.lblSecAcciones);
            this.panelCardAcciones.Location = new System.Drawing.Point(20, 546);
            this.panelCardAcciones.Name = "panelCardAcciones";
            this.panelCardAcciones.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.panelCardAcciones.Size = new System.Drawing.Size(880, 80);
            this.panelCardAcciones.TabIndex = 5;
            //
            // lblSecAcciones
            //
            this.lblSecAcciones.AutoSize = true;
            this.lblSecAcciones.Font = Tema.FuenteBoton;
            this.lblSecAcciones.ForeColor = Tema.AzulPrimario;
            this.lblSecAcciones.Location = new System.Drawing.Point(16, 12);
            this.lblSecAcciones.Name = "lblSecAcciones";
            this.lblSecAcciones.Size = new System.Drawing.Size(265, 19);
            this.lblSecAcciones.TabIndex = 0;
            this.lblSecAcciones.Text = "⚡ ACCIONES Y GESTIÓN DE LA CITA";
            //
            // btnConfirmar
            //
            this.btnConfirmar.BackColor = Tema.BadgeConfirmadaFondo;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = Tema.BadgeConfirmadaBorde;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = Tema.FuenteLabelCampo;
            this.btnConfirmar.ForeColor = Tema.VerdeOscuro;
            this.btnConfirmar.Location = new System.Drawing.Point(18, 36);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(140, 36);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "✓ Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            //
            // btnEditar
            //
            this.btnEditar.BackColor = Tema.BotonEditarFondo;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = Tema.BotonEditarBorde;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = Tema.FuenteLabelCampo;
            this.btnEditar.ForeColor = Tema.AzulPrimario;
            this.btnEditar.Location = new System.Drawing.Point(168, 36);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(130, 36);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "✏ Editar Cita";
            this.btnEditar.UseVisualStyleBackColor = false;
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = Tema.BotonPeligroFondo;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.BotonPeligroBorde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteLabelCampo;
            this.btnCancelar.ForeColor = Tema.Error;
            this.btnCancelar.Location = new System.Drawing.Point(308, 36);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "✕ Cancelar Cita";
            this.btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnNoAsistio
            //
            this.btnNoAsistio.BackColor = Tema.BadgeNoAsistioFondo;
            this.btnNoAsistio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoAsistio.FlatAppearance.BorderColor = Tema.BadgeNoAsistioBorde;
            this.btnNoAsistio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoAsistio.Font = Tema.FuenteLabelCampo;
            this.btnNoAsistio.ForeColor = Tema.TextoSecundario;
            this.btnNoAsistio.Location = new System.Drawing.Point(458, 36);
            this.btnNoAsistio.Name = "btnNoAsistio";
            this.btnNoAsistio.Size = new System.Drawing.Size(160, 36);
            this.btnNoAsistio.TabIndex = 4;
            this.btnNoAsistio.Text = "⊘ Marcar Inasistencia";
            this.btnNoAsistio.UseVisualStyleBackColor = false;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = Tema.Superficie;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = Tema.FuenteLabelCampo;
            this.btnCerrar.ForeColor = Tema.TextoPrincipal;
            this.btnCerrar.Location = new System.Drawing.Point(744, 36);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 36);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            //
            // fichaCita
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(940, 700);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "fichaCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de la Cita Médica";
            this.Load += new System.EventHandler(this.fichaCita_Load);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelBadgeEstado.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.panelCardPaciente.ResumeLayout(false);
            this.panelCardPaciente.PerformLayout();
            this.panelCardMedico.ResumeLayout(false);
            this.panelCardMedico.PerformLayout();
            this.panelCardHospital.ResumeLayout(false);
            this.panelCardHospital.PerformLayout();
            this.panelCardProgramacion.ResumeLayout(false);
            this.panelCardProgramacion.PerformLayout();
            this.panelCardMotivo.ResumeLayout(false);
            this.panelCardMotivo.PerformLayout();
            this.panelMotivoBox.ResumeLayout(false);
            this.panelCardAcciones.ResumeLayout(false);
            this.panelCardAcciones.PerformLayout();
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
        private System.Windows.Forms.Panel panelCardPaciente;
        private System.Windows.Forms.Label lblSecPaciente;
        private System.Windows.Forms.Label lblPacienteT;
        private System.Windows.Forms.Label lblPacienteVal;
        private System.Windows.Forms.Label lblCedulaT;
        private System.Windows.Forms.Label lblCedulaVal;
        private System.Windows.Forms.Label lblTelefonoT;
        private System.Windows.Forms.Label lblTelefonoVal;
        private System.Windows.Forms.Label lblDireccionT;
        private System.Windows.Forms.Label lblDireccionVal;
        private System.Windows.Forms.Panel panelCardMedico;
        private System.Windows.Forms.Label lblSecMedico;
        private System.Windows.Forms.Label lblDoctorT;
        private System.Windows.Forms.Label lblDoctorVal;
        private System.Windows.Forms.Label lblEspecialidadT;
        private System.Windows.Forms.Label lblEspecialidadVal;
        private System.Windows.Forms.Panel panelCardHospital;
        private System.Windows.Forms.Label lblSecHospital;
        private System.Windows.Forms.Label lblHospitalT;
        private System.Windows.Forms.Label lblHospitalVal;
        private System.Windows.Forms.Label lblUbicacionT;
        private System.Windows.Forms.Label lblUbicacionVal;
        private System.Windows.Forms.Panel panelCardProgramacion;
        private System.Windows.Forms.Label lblSecProgramacion;
        private System.Windows.Forms.Label lblIdCitaT;
        private System.Windows.Forms.Label lblIdCitaVal;
        private System.Windows.Forms.Label lblFechaHoraT;
        private System.Windows.Forms.Label lblFechaHoraVal;
        private System.Windows.Forms.Label lblFechaRegistroT;
        private System.Windows.Forms.Label lblFechaRegistroVal;
        private System.Windows.Forms.Label lblEstadoDetalleT;
        private System.Windows.Forms.Label lblEstadoDetalleVal;
        private System.Windows.Forms.Panel panelCardMotivo;
        private System.Windows.Forms.Label lblSecMotivo;
        private System.Windows.Forms.Panel panelMotivoBox;
        private System.Windows.Forms.Label lblMotivoVal;
        private System.Windows.Forms.Panel panelCardAcciones;
        private System.Windows.Forms.Label lblSecAcciones;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNoAsistio;
        private System.Windows.Forms.Button btnCerrar;
    }
}
