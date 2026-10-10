using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Citas
{
    partial class crearCita
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
            this.panelScroll = new System.Windows.Forms.Panel();
            this.cardHeader = new System.Windows.Forms.Panel();
            this.lblIconoHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblBadgeModo = new System.Windows.Forms.Label();
            this.cardAtencion = new System.Windows.Forms.Panel();
            this.lblIconoAtencion = new System.Windows.Forms.Label();
            this.lblTituloAtencion = new System.Windows.Forms.Label();
            this.lblSubtituloAtencion = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.lblErrorPaciente = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblErrorEspecialidad = new System.Windows.Forms.Label();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblErrorDoctor = new System.Windows.Forms.Label();
            this.lblHospital = new System.Windows.Forms.Label();
            this.cmbHospital = new System.Windows.Forms.ComboBox();
            this.lblErrorHospital = new System.Windows.Forms.Label();
            this.cardProgramacion = new System.Windows.Forms.Panel();
            this.lblIconoProgramacion = new System.Windows.Forms.Label();
            this.lblTituloProgramacion = new System.Windows.Forms.Label();
            this.lblSubtituloProgramacion = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblErrorFechaHora = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblErrorMotivo = new System.Windows.Forms.Label();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.lnkVolver = new System.Windows.Forms.LinkLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelScroll.SuspendLayout();
            this.cardHeader.SuspendLayout();
            this.cardAtencion.SuspendLayout();
            this.cardProgramacion.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelScroll
            //
            this.panelScroll.AutoScroll = true;
            this.panelScroll.BackColor = Tema.Fondo;
            this.panelScroll.Controls.Add(this.cardHeader);
            this.panelScroll.Controls.Add(this.cardAtencion);
            this.panelScroll.Controls.Add(this.cardProgramacion);
            this.panelScroll.Controls.Add(this.panelAcciones);
            this.panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScroll.Location = new System.Drawing.Point(0, 0);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Padding = new System.Windows.Forms.Padding(20, 16, 20, 20);
            this.panelScroll.Size = new System.Drawing.Size(750, 630);
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
            this.cardHeader.Controls.Add(this.lblBadgeModo);
            this.cardHeader.Location = new System.Drawing.Point(20, 16);
            this.cardHeader.Name = "cardHeader";
            this.cardHeader.Size = new System.Drawing.Size(710, 68);
            this.cardHeader.TabIndex = 0;
            //
            // lblIconoHeader
            //
            this.lblIconoHeader.Font = new System.Drawing.Font("Segoe UI Emoji", 15F);
            this.lblIconoHeader.ForeColor = Tema.AzulPrimario;
            this.lblIconoHeader.Location = new System.Drawing.Point(14, 13);
            this.lblIconoHeader.Name = "lblIconoHeader";
            this.lblIconoHeader.Size = new System.Drawing.Size(42, 42);
            this.lblIconoHeader.TabIndex = 0;
            this.lblIconoHeader.Text = "ðŸ“…";
            this.lblIconoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.AzulOscuro;
            this.lblTitulo.Location = new System.Drawing.Point(62, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Programar Cita Médica";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.8F);
            this.lblSubtitulo.ForeColor = Tema.TextoSecundario;
            this.lblSubtitulo.Location = new System.Drawing.Point(64, 39);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(370, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Seleccione paciente, especialidad, médico y horario convenido.";
            //
            // lblBadgeModo
            //
            this.lblBadgeModo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeModo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            this.lblBadgeModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBadgeModo.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBadgeModo.ForeColor = Tema.VerdeOscuro;
            this.lblBadgeModo.Location = new System.Drawing.Point(550, 18);
            this.lblBadgeModo.Name = "lblBadgeModo";
            this.lblBadgeModo.Size = new System.Drawing.Size(145, 28);
            this.lblBadgeModo.TabIndex = 3;
            this.lblBadgeModo.Text = "+ Nueva Cita";
            this.lblBadgeModo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cardAtencion
            //
            this.cardAtencion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardAtencion.BackColor = Tema.Superficie;
            this.cardAtencion.Controls.Add(this.lblIconoAtencion);
            this.cardAtencion.Controls.Add(this.lblTituloAtencion);
            this.cardAtencion.Controls.Add(this.lblSubtituloAtencion);
            this.cardAtencion.Controls.Add(this.lblPaciente);
            this.cardAtencion.Controls.Add(this.cmbPaciente);
            this.cardAtencion.Controls.Add(this.lblErrorPaciente);
            this.cardAtencion.Controls.Add(this.lblEspecialidad);
            this.cardAtencion.Controls.Add(this.cmbEspecialidad);
            this.cardAtencion.Controls.Add(this.lblErrorEspecialidad);
            this.cardAtencion.Controls.Add(this.lblDoctor);
            this.cardAtencion.Controls.Add(this.cmbDoctor);
            this.cardAtencion.Controls.Add(this.lblErrorDoctor);
            this.cardAtencion.Controls.Add(this.lblHospital);
            this.cardAtencion.Controls.Add(this.cmbHospital);
            this.cardAtencion.Controls.Add(this.lblErrorHospital);
            this.cardAtencion.Location = new System.Drawing.Point(20, 96);
            this.cardAtencion.Name = "cardAtencion";
            this.cardAtencion.Size = new System.Drawing.Size(710, 212);
            this.cardAtencion.TabIndex = 1;
            //
            // lblIconoAtencion
            //
            this.lblIconoAtencion.Font = new System.Drawing.Font("Segoe UI Emoji", 13F);
            this.lblIconoAtencion.ForeColor = Tema.AzulPrimario;
            this.lblIconoAtencion.Location = new System.Drawing.Point(14, 12);
            this.lblIconoAtencion.Name = "lblIconoAtencion";
            this.lblIconoAtencion.Size = new System.Drawing.Size(32, 32);
            this.lblIconoAtencion.TabIndex = 0;
            this.lblIconoAtencion.Text = "ðŸ©º";
            this.lblIconoAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloAtencion
            //
            this.lblTituloAtencion.AutoSize = true;
            this.lblTituloAtencion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloAtencion.ForeColor = Tema.AzulOscuro;
            this.lblTituloAtencion.Location = new System.Drawing.Point(50, 10);
            this.lblTituloAtencion.Name = "lblTituloAtencion";
            this.lblTituloAtencion.Size = new System.Drawing.Size(242, 20);
            this.lblTituloAtencion.TabIndex = 1;
            this.lblTituloAtencion.Text = "Atención Médica y Profesionales";
            //
            // lblSubtituloAtencion
            //
            this.lblSubtituloAtencion.AutoSize = true;
            this.lblSubtituloAtencion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblSubtituloAtencion.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloAtencion.Location = new System.Drawing.Point(52, 32);
            this.lblSubtituloAtencion.Name = "lblSubtituloAtencion";
            this.lblSubtituloAtencion.Size = new System.Drawing.Size(325, 15);
            this.lblSubtituloAtencion.TabIndex = 2;
            this.lblSubtituloAtencion.Text = "Seleccione el paciente, especialidad, médico y sede asistencial.";
            //
            // lblPaciente
            //
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = Tema.FuenteLabelCampo;
            this.lblPaciente.ForeColor = Tema.TextoPrincipal;
            this.lblPaciente.Location = new System.Drawing.Point(16, 58);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(86, 17);
            this.lblPaciente.TabIndex = 3;
            this.lblPaciente.Text = "Paciente (*):";
            //
            // cmbPaciente
            //
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Font = Tema.FuenteInput;
            this.cmbPaciente.Location = new System.Drawing.Point(16, 78);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(325, 27);
            this.cmbPaciente.TabIndex = 4;
            //
            // lblErrorPaciente
            //
            this.lblErrorPaciente.AutoSize = true;
            this.lblErrorPaciente.Font = Tema.FuenteAyuda;
            this.lblErrorPaciente.ForeColor = Tema.ColorError;
            this.lblErrorPaciente.Location = new System.Drawing.Point(16, 107);
            this.lblErrorPaciente.Name = "lblErrorPaciente";
            this.lblErrorPaciente.Size = new System.Drawing.Size(0, 15);
            this.lblErrorPaciente.TabIndex = 5;
            //
            // lblEspecialidad
            //
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = Tema.FuenteLabelCampo;
            this.lblEspecialidad.ForeColor = Tema.TextoPrincipal;
            this.lblEspecialidad.Location = new System.Drawing.Point(365, 58);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(155, 17);
            this.lblEspecialidad.TabIndex = 6;
            this.lblEspecialidad.Text = "Especialidad Médica (*):";
            //
            // cmbEspecialidad
            //
            this.cmbEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.Font = Tema.FuenteInput;
            this.cmbEspecialidad.Location = new System.Drawing.Point(365, 78);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(325, 27);
            this.cmbEspecialidad.TabIndex = 7;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            //
            // lblErrorEspecialidad
            //
            this.lblErrorEspecialidad.AutoSize = true;
            this.lblErrorEspecialidad.Font = Tema.FuenteAyuda;
            this.lblErrorEspecialidad.ForeColor = Tema.ColorError;
            this.lblErrorEspecialidad.Location = new System.Drawing.Point(365, 107);
            this.lblErrorEspecialidad.Name = "lblErrorEspecialidad";
            this.lblErrorEspecialidad.Size = new System.Drawing.Size(0, 15);
            this.lblErrorEspecialidad.TabIndex = 8;
            //
            // lblDoctor
            //
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = Tema.FuenteLabelCampo;
            this.lblDoctor.ForeColor = Tema.TextoPrincipal;
            this.lblDoctor.Location = new System.Drawing.Point(16, 128);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(137, 17);
            this.lblDoctor.TabIndex = 9;
            this.lblDoctor.Text = "Médico Tratante (*):";
            //
            // cmbDoctor
            //
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.Enabled = false;
            this.cmbDoctor.Font = Tema.FuenteInput;
            this.cmbDoctor.Location = new System.Drawing.Point(16, 148);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(325, 27);
            this.cmbDoctor.TabIndex = 10;
            this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.cmbDoctor_SelectedIndexChanged);
            //
            // lblErrorDoctor
            //
            this.lblErrorDoctor.AutoSize = true;
            this.lblErrorDoctor.Font = Tema.FuenteAyuda;
            this.lblErrorDoctor.ForeColor = Tema.ColorError;
            this.lblErrorDoctor.Location = new System.Drawing.Point(16, 177);
            this.lblErrorDoctor.Name = "lblErrorDoctor";
            this.lblErrorDoctor.Size = new System.Drawing.Size(0, 15);
            this.lblErrorDoctor.TabIndex = 11;
            //
            // lblHospital
            //
            this.lblHospital.AutoSize = true;
            this.lblHospital.Font = Tema.FuenteLabelCampo;
            this.lblHospital.ForeColor = Tema.TextoPrincipal;
            this.lblHospital.Location = new System.Drawing.Point(365, 128);
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(126, 17);
            this.lblHospital.TabIndex = 12;
            this.lblHospital.Text = "Hospital / Sede (*):";
            //
            // cmbHospital
            //
            this.cmbHospital.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHospital.Enabled = false;
            this.cmbHospital.Font = Tema.FuenteInput;
            this.cmbHospital.Location = new System.Drawing.Point(365, 148);
            this.cmbHospital.Name = "cmbHospital";
            this.cmbHospital.Size = new System.Drawing.Size(325, 27);
            this.cmbHospital.TabIndex = 13;
            //
            // lblErrorHospital
            //
            this.lblErrorHospital.AutoSize = true;
            this.lblErrorHospital.Font = Tema.FuenteAyuda;
            this.lblErrorHospital.ForeColor = Tema.ColorError;
            this.lblErrorHospital.Location = new System.Drawing.Point(365, 177);
            this.lblErrorHospital.Name = "lblErrorHospital";
            this.lblErrorHospital.Size = new System.Drawing.Size(0, 15);
            this.lblErrorHospital.TabIndex = 14;
            //
            // cardProgramacion
            //
            this.cardProgramacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardProgramacion.BackColor = Tema.Superficie;
            this.cardProgramacion.Controls.Add(this.lblIconoProgramacion);
            this.cardProgramacion.Controls.Add(this.lblTituloProgramacion);
            this.cardProgramacion.Controls.Add(this.lblSubtituloProgramacion);
            this.cardProgramacion.Controls.Add(this.lblFecha);
            this.cardProgramacion.Controls.Add(this.dtpFecha);
            this.cardProgramacion.Controls.Add(this.lblHora);
            this.cardProgramacion.Controls.Add(this.dtpHora);
            this.cardProgramacion.Controls.Add(this.lblErrorFechaHora);
            this.cardProgramacion.Controls.Add(this.lblMotivo);
            this.cardProgramacion.Controls.Add(this.txtMotivo);
            this.cardProgramacion.Controls.Add(this.lblErrorMotivo);
            this.cardProgramacion.Location = new System.Drawing.Point(20, 318);
            this.cardProgramacion.Name = "cardProgramacion";
            this.cardProgramacion.Size = new System.Drawing.Size(710, 222);
            this.cardProgramacion.TabIndex = 2;
            //
            // lblIconoProgramacion
            //
            this.lblIconoProgramacion.Font = new System.Drawing.Font("Segoe UI Emoji", 13F);
            this.lblIconoProgramacion.ForeColor = Tema.AzulPrimario;
            this.lblIconoProgramacion.Location = new System.Drawing.Point(14, 12);
            this.lblIconoProgramacion.Name = "lblIconoProgramacion";
            this.lblIconoProgramacion.Size = new System.Drawing.Size(32, 32);
            this.lblIconoProgramacion.TabIndex = 0;
            this.lblIconoProgramacion.Text = "⏱️";
            this.lblIconoProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTituloProgramacion
            //
            this.lblTituloProgramacion.AutoSize = true;
            this.lblTituloProgramacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloProgramacion.ForeColor = Tema.AzulOscuro;
            this.lblTituloProgramacion.Location = new System.Drawing.Point(50, 10);
            this.lblTituloProgramacion.Name = "lblTituloProgramacion";
            this.lblTituloProgramacion.Size = new System.Drawing.Size(262, 20);
            this.lblTituloProgramacion.TabIndex = 1;
            this.lblTituloProgramacion.Text = "Programación y Motivo de Consulta";
            //
            // lblSubtituloProgramacion
            //
            this.lblSubtituloProgramacion.AutoSize = true;
            this.lblSubtituloProgramacion.Font = new System.Drawing.Font(Tema.FamiliaFuente, 8.2F);
            this.lblSubtituloProgramacion.ForeColor = Tema.TextoSecundario;
            this.lblSubtituloProgramacion.Location = new System.Drawing.Point(52, 32);
            this.lblSubtituloProgramacion.Name = "lblSubtituloProgramacion";
            this.lblSubtituloProgramacion.Size = new System.Drawing.Size(315, 15);
            this.lblSubtituloProgramacion.TabIndex = 2;
            this.lblSubtituloProgramacion.Text = "Defina la fecha, el horario y la causa médica de la cita.";
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = Tema.FuenteLabelCampo;
            this.lblFecha.ForeColor = Tema.TextoPrincipal;
            this.lblFecha.Location = new System.Drawing.Point(16, 58);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(150, 17);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha Programada (*):";
            //
            // dtpFecha
            //
            this.dtpFecha.Font = Tema.FuenteInput;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(16, 78);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(325, 27);
            this.dtpFecha.TabIndex = 4;
            //
            // lblHora
            //
            this.lblHora.AutoSize = true;
            this.lblHora.Font = Tema.FuenteLabelCampo;
            this.lblHora.ForeColor = Tema.TextoPrincipal;
            this.lblHora.Location = new System.Drawing.Point(365, 58);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(65, 17);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora (*):";
            //
            // dtpHora
            //
            this.dtpHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHora.CustomFormat = "hh:mm tt";
            this.dtpHora.Font = Tema.FuenteInput;
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(365, 78);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(325, 27);
            this.dtpHora.TabIndex = 6;
            //
            // lblErrorFechaHora
            //
            this.lblErrorFechaHora.AutoSize = true;
            this.lblErrorFechaHora.Font = Tema.FuenteAyuda;
            this.lblErrorFechaHora.ForeColor = Tema.ColorError;
            this.lblErrorFechaHora.Location = new System.Drawing.Point(16, 107);
            this.lblErrorFechaHora.Name = "lblErrorFechaHora";
            this.lblErrorFechaHora.Size = new System.Drawing.Size(0, 15);
            this.lblErrorFechaHora.TabIndex = 7;
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = Tema.FuenteLabelCampo;
            this.lblMotivo.ForeColor = Tema.TextoPrincipal;
            this.lblMotivo.Location = new System.Drawing.Point(16, 126);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(147, 17);
            this.lblMotivo.TabIndex = 8;
            this.lblMotivo.Text = "Motivo de la Cita (*):";
            //
            // txtMotivo
            //
            this.txtMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivo.Font = Tema.FuenteInput;
            this.txtMotivo.Location = new System.Drawing.Point(16, 146);
            this.txtMotivo.MaxLength = 500;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(674, 48);
            this.txtMotivo.TabIndex = 9;
            //
            // lblErrorMotivo
            //
            this.lblErrorMotivo.AutoSize = true;
            this.lblErrorMotivo.Font = Tema.FuenteAyuda;
            this.lblErrorMotivo.ForeColor = Tema.ColorError;
            this.lblErrorMotivo.Location = new System.Drawing.Point(16, 197);
            this.lblErrorMotivo.Name = "lblErrorMotivo";
            this.lblErrorMotivo.Size = new System.Drawing.Size(0, 15);
            this.lblErrorMotivo.TabIndex = 10;
            //
            // panelAcciones
            //
            this.panelAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAcciones.BackColor = System.Drawing.Color.Transparent;
            this.panelAcciones.Controls.Add(this.lnkVolver);
            this.panelAcciones.Controls.Add(this.btnCancelar);
            this.panelAcciones.Controls.Add(this.btnGuardar);
            this.panelAcciones.Location = new System.Drawing.Point(20, 548);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(710, 52);
            this.panelAcciones.TabIndex = 3;
            //
            // lnkVolver
            //
            this.lnkVolver.AutoSize = true;
            this.lnkVolver.Font = Tema.FuenteSubtitulo;
            this.lnkVolver.LinkColor = Tema.AzulPrimario;
            this.lnkVolver.Location = new System.Drawing.Point(4, 15);
            this.lnkVolver.Name = "lnkVolver";
            this.lnkVolver.Size = new System.Drawing.Size(175, 19);
            this.lnkVolver.TabIndex = 0;
            this.lnkVolver.TabStop = true;
            this.lnkVolver.Text = "← Volver al listado de citas";
            this.lnkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolver_LinkClicked);
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = Tema.Superficie;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = Tema.Borde;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = Tema.FuenteBoton;
            this.btnCancelar.ForeColor = Tema.TextoPrincipal;
            this.btnCancelar.Location = new System.Drawing.Point(375, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✕ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnGuardar
            //
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = Tema.AzulPrimario;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = Tema.FuenteBoton;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(520, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(185, 42);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "ðŸ’¾ Agendar Cita";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // crearCita
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Tema.Fondo;
            this.ClientSize = new System.Drawing.Size(750, 630);
            this.Controls.Add(this.panelScroll);
            this.Font = new System.Drawing.Font(Tema.FamiliaFuente, 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(730, 600);
            this.Name = "crearCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanar Rural - Programar Cita Médica";
            this.Load += new System.EventHandler(this.crearCita_Load);
            this.panelScroll.ResumeLayout(false);
            this.cardHeader.ResumeLayout(false);
            this.cardHeader.PerformLayout();
            this.cardAtencion.ResumeLayout(false);
            this.cardAtencion.PerformLayout();
            this.cardProgramacion.ResumeLayout(false);
            this.cardProgramacion.PerformLayout();
            this.panelAcciones.ResumeLayout(false);
            this.panelAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.Panel cardHeader;
        private System.Windows.Forms.Label lblIconoHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBadgeModo;
        private System.Windows.Forms.Panel cardAtencion;
        private System.Windows.Forms.Label lblIconoAtencion;
        private System.Windows.Forms.Label lblTituloAtencion;
        private System.Windows.Forms.Label lblSubtituloAtencion;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Label lblErrorPaciente;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label lblErrorEspecialidad;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblErrorDoctor;
        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.ComboBox cmbHospital;
        private System.Windows.Forms.Label lblErrorHospital;
        private System.Windows.Forms.Panel cardProgramacion;
        private System.Windows.Forms.Label lblIconoProgramacion;
        private System.Windows.Forms.Label lblTituloProgramacion;
        private System.Windows.Forms.Label lblSubtituloProgramacion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblErrorFechaHora;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblErrorMotivo;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.LinkLabel lnkVolver;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
