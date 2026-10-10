using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Citas
{
    // Formulario modal para agendar y reprogramar citas médicas.
    public partial class crearCita : Form
    {
        private readonly citasControllers controlador = new citasControllers();
        private readonly int? idDoctorAutenticado;
        private readonly int? idPacienteAutenticado;
        private int? idCitaEdicion;
        private bool cargando = false;

        // Constructor para agendar una nueva cita médica (modo administrativo o general).
        public crearCita() : this(null, null, null)
        {
        }

        // Constructor para agendar cita restringida al médico autenticado.
        public crearCita(int? idDoctorAutenticado) : this(null, idDoctorAutenticado, null)
        {
        }

        // Constructor para agendar cita por médico o paciente autenticado.
        public crearCita(int? idDoctorAutenticado, int? idPacienteAutenticado) : this(null, idDoctorAutenticado, idPacienteAutenticado)
        {
        }

        // Constructor para reprogramar una cita médica existente (con restricción opcional de médico o paciente).
        public crearCita(int idCita, int? idDoctorAutenticado = null, int? idPacienteAutenticado = null) : this((int?)idCita, idDoctorAutenticado, idPacienteAutenticado)
        {
        }

        private crearCita(int? idCita, int? idDoctorAutenticado, int? idPacienteAutenticado)
        {
            this.idCitaEdicion = idCita;
            this.idDoctorAutenticado = idDoctorAutenticado;
            this.idPacienteAutenticado = idPacienteAutenticado;
            InitializeComponent();
        }

        // ============================================================
        // INICIALIZACIÓN Y CARGA DE CATÁLOGOS
        // ============================================================
        private void crearCita_Load(object sender, EventArgs e)
        {
            try
            {
                cargando = true;

                ConfigurarEstilosVisuales();
                LimpiarErrores();
                ConfigurarRestriccionesFechas();
                CargarPacientes();
                CargarEspecialidades();

                if (idCitaEdicion.HasValue)
                {
                    CargarDatosParaEdicion(idCitaEdicion.Value);
                }
                else
                {
                    ConfigurarModoCreacion();
                }
            }
            finally
            {
                cargando = false;
            }
        }

        private void ConfigurarModoCreacion()
        {
            this.Text = "Sanar Rural - Programar Cita Médica";
            lblTitulo.Text = "Programar Cita Médica";
            lblSubtitulo.Text = "Seleccione paciente, especialidad, médico y horario convenido.";
            lblBadgeModo.Text = "+ Nueva Cita";
            lblBadgeModo.BackColor = Color.FromArgb(236, 248, 238);
            lblBadgeModo.ForeColor = Tema.VerdeOscuro;
            btnGuardar.Text = "💾 Agendar Cita";
        }

        private void ConfigurarEstilosVisuales()
        {
            this.DoubleBuffered = true;
            btnCancelar.Click += (s, ev) => { DialogResult = DialogResult.Cancel; Close(); };
            this.CancelButton = btnCancelar;

            // Microinteracciones de botones
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;

            // Dibujado suave de tarjetas
            cardHeader.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardHeader.Width - 1, cardHeader.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardAtencion.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardAtencion.Width - 1, cardAtencion.Height - 1), Tema.Superficie, Tema.Borde, 10);
            cardProgramacion.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardProgramacion.Width - 1, cardProgramacion.Height - 1), Tema.Superficie, Tema.Borde, 10);

            // Iconos circulares suaves
            lblIconoHeader.Paint += (s, ev) => DibujarBadgeCircular(lblIconoHeader, ev, "📅");
            lblIconoAtencion.Paint += (s, ev) => DibujarBadgeCircular(lblIconoAtencion, ev, "🩺");
            lblIconoProgramacion.Paint += (s, ev) => DibujarBadgeCircular(lblIconoProgramacion, ev, "⏱️");
        }

        private static void DibujarBadgeCircular(Control c, PaintEventArgs e, string icono)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(c.Parent?.BackColor ?? Tema.Superficie);
            using (Brush br = new SolidBrush(Tema.AzulPrimario))
            {
                e.Graphics.FillEllipse(br, 1, 1, c.Width - 3, c.Height - 3);
            }
            using (Font f = new Font("Segoe UI Emoji", 11F))
            using (Brush brText = new SolidBrush(Color.White))
            {
                SizeF sf = e.Graphics.MeasureString(icono, f);
                e.Graphics.DrawString(icono, f, brText, (c.Width - sf.Width) / 2 + 1, (c.Height - sf.Height) / 2);
            }
        }

        private void ConfigurarRestriccionesFechas()
        {
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Now.AddHours(1);
        }

        private void CargarPacientes()
        {
            var pacientes = controlador.listarPacientesActivos();
            cmbPaciente.DataSource = pacientes;
            cmbPaciente.DisplayMember = "NombreCompleto";
            cmbPaciente.ValueMember = "IdPaciente";
            if (pacientes.Count == 0)
            {
                lblErrorPaciente.Text = "No hay pacientes registrados activos.";
            }
            else if (idPacienteAutenticado.HasValue)
            {
                cmbPaciente.SelectedValue = idPacienteAutenticado.Value;
                cmbPaciente.Enabled = false;
            }
            else
            {
                cmbPaciente.SelectedIndex = -1;
            }
        }

        private void CargarEspecialidades()
        {
            var especialidades = controlador.listarEspecialidadesConAsignacion(idDoctorAutenticado);
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "IdEspecialidad";
            cmbEspecialidad.SelectedIndex = -1;
            cmbDoctor.DataSource = null;
            cmbDoctor.Enabled = false;
            cmbHospital.DataSource = null;
            cmbHospital.Enabled = false;

            if (especialidades.Count == 0)
            {
                lblErrorEspecialidad.Text = "No hay especialidades médicas disponibles.";
            }
        }

        // ============================================================
        // EDICIÓN / REPROGRAMACIÓN DE CITA
        // ============================================================
        private void CargarDatosParaEdicion(int idCita)
        {
            var cita = controlador.obtenerCitaPorId(idCita, idDoctorAutenticado, idPacienteAutenticado);
            if (cita == null)
            {
                MessageBox.Show("No se encontró la cita solicitada o no tiene permisos para gestionarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (cita.Estado == "Atendida" || cita.Estado == "Cancelada" || cita.Estado == "NoAsistio")
            {
                MessageBox.Show($"No es posible reprogramar una cita que ya se encuentra en estado '{cita.Estado}'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Adecuación de textos de encabezado para modo de reprogramación.
            this.Text = "Sanar Rural - Reprogramar Cita Médica";
            lblTitulo.Text = "Reprogramar Cita Médica";
            lblSubtitulo.Text = string.Format("Reprogramación de cita #{0} | Actualice horario o sede", idCita);
            lblBadgeModo.Text = "✎ Reprogramación";
            lblBadgeModo.BackColor = Color.FromArgb(235, 245, 252);
            lblBadgeModo.ForeColor = Tema.AzulPrimario;
            btnGuardar.Text = "💾 Guardar Cambios";

            // Si la cita tenía una fecha anterior a hoy (por ej. si se reprograma hoy), ajustar MinDate para evitar excepción de WinForms.
            if (cita.FechaHoraProgramada.Date < dtpFecha.MinDate)
            {
                dtpFecha.MinDate = cita.FechaHoraProgramada.Date;
            }

            // Seleccionar paciente asignado.
            cmbPaciente.SelectedValue = cita.IdPaciente;

            // Seleccionar especialidad y disparar cascada de doctores y hospitales.
            cmbEspecialidad.SelectedValue = cita.IdEspecialidad;

            var doctores = controlador.listarDoctoresPorEspecialidad(cita.IdEspecialidad, idDoctorAutenticado);
            cmbDoctor.DataSource = doctores;
            cmbDoctor.DisplayMember = "NombreCompleto";
            cmbDoctor.ValueMember = "IdDoctor";
            cmbDoctor.SelectedValue = cita.IdDoctor;
            cmbDoctor.Enabled = !idDoctorAutenticado.HasValue && doctores.Count > 0;

            var hospitales = controlador.listarHospitalesPorDoctorYEspecialidad(cita.IdDoctor, cita.IdEspecialidad);
            cmbHospital.DataSource = hospitales;
            cmbHospital.DisplayMember = "Nombre";
            cmbHospital.ValueMember = "IdHospital";
            cmbHospital.SelectedValue = cita.IdHospital;
            cmbHospital.Enabled = hospitales.Count > 0;

            // Cargar fecha, hora y motivo.
            dtpFecha.Value = cita.FechaHoraProgramada.Date;
            dtpHora.Value = cita.FechaHoraProgramada;
            txtMotivo.Text = cita.Motivo;
        }

        // ============================================================
        // COMBOS EN CASCADA ESTRICTA
        // ============================================================
        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;

            LimpiarError(lblErrorEspecialidad);
            LimpiarError(lblErrorDoctor);
            LimpiarError(lblErrorHospital);
            cmbDoctor.DataSource = null;
            cmbDoctor.Enabled = false;
            cmbHospital.DataSource = null;
            cmbHospital.Enabled = false;

            if (cmbEspecialidad.SelectedValue is int idEspecialidad)
            {
                var doctores = controlador.listarDoctoresPorEspecialidad(idEspecialidad, idDoctorAutenticado);
                cmbDoctor.DataSource = doctores;
                cmbDoctor.DisplayMember = "NombreCompleto";
                cmbDoctor.ValueMember = "IdDoctor";

                if (doctores.Count == 0)
                {
                    lblErrorDoctor.Text = "No hay médicos disponibles para esta especialidad.";
                    return;
                }

                if (idDoctorAutenticado.HasValue)
                {
                    // En sesión médica: el doctor queda asignado a su propio perfil y bloqueado contra cambios.
                    cmbDoctor.SelectedValue = idDoctorAutenticado.Value;
                    cmbDoctor.Enabled = false;

                    // Cargar de inmediato los hospitales autorizados para este médico y especialidad.
                    var hospitales = controlador.listarHospitalesPorDoctorYEspecialidad(idDoctorAutenticado.Value, idEspecialidad);
                    cmbHospital.DataSource = hospitales;
                    cmbHospital.DisplayMember = "Nombre";
                    cmbHospital.ValueMember = "IdHospital";
                    cmbHospital.SelectedIndex = -1;
                    cmbHospital.Enabled = hospitales.Count > 0;

                    if (hospitales.Count == 0)
                    {
                        lblErrorHospital.Text = "No hay sedes asignadas para este médico en la especialidad seleccionada.";
                    }
                }
                else
                {
                    cmbDoctor.SelectedIndex = -1;
                    cmbDoctor.Enabled = true;
                }
            }
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;

            LimpiarError(lblErrorDoctor);
            LimpiarError(lblErrorHospital);
            cmbHospital.DataSource = null;
            cmbHospital.Enabled = false;

            if (cmbDoctor.SelectedValue is int idDoctor && cmbEspecialidad.SelectedValue is int idEspecialidad)
            {
                var hospitales = controlador.listarHospitalesPorDoctorYEspecialidad(idDoctor, idEspecialidad);
                cmbHospital.DataSource = hospitales;
                cmbHospital.DisplayMember = "Nombre";
                cmbHospital.ValueMember = "IdHospital";
                cmbHospital.SelectedIndex = -1;
                cmbHospital.Enabled = hospitales.Count > 0;

                if (hospitales.Count == 0)
                {
                    lblErrorHospital.Text = "El médico seleccionado no tiene sedes asignadas para esta especialidad.";
                }
            }
        }

        // ============================================================
        // VALIDACIÓN Y GUARDADO
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LimpiarErrores();
            bool esValido = true;

            // Validación de Paciente
            if (cmbPaciente.SelectedValue == null)
            {
                lblErrorPaciente.Text = "Debe seleccionar un paciente para la cita.";
                esValido = false;
            }

            // Validación de Especialidad
            if (cmbEspecialidad.SelectedValue == null)
            {
                lblErrorEspecialidad.Text = "Debe seleccionar la especialidad médica requerida.";
                esValido = false;
            }

            // Validación de Doctor
            if (cmbDoctor.SelectedValue == null)
            {
                lblErrorDoctor.Text = "Debe seleccionar el médico que atenderá la cita.";
                esValido = false;
            }

            // Validación de Hospital
            if (cmbHospital.SelectedValue == null)
            {
                lblErrorHospital.Text = "Debe seleccionar la sede hospitalaria de la cita.";
                esValido = false;
            }

            // Validación de Fecha y Hora programada
            DateTime fechaSeleccionada = dtpFecha.Value.Date;
            TimeSpan horaSeleccionada = dtpHora.Value.TimeOfDay;
            DateTime fechaHora = fechaSeleccionada.Add(horaSeleccionada);

            if (fechaHora < DateTime.Now)
            {
                lblErrorFechaHora.Text = "La cita no puede programarse en una fecha u hora pasada.";
                esValido = false;
            }

            // Validación de Motivo
            string motivo = txtMotivo.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivo))
            {
                lblErrorMotivo.Text = "El motivo de la cita médica es obligatorio.";
                esValido = false;
            }

            if (!esValido)
            {
                return;
            }

            int idPaciente = (int)cmbPaciente.SelectedValue;
            int idEspecialidad = (int)cmbEspecialidad.SelectedValue;
            int idDoctor = (int)cmbDoctor.SelectedValue;
            int idHospital = (int)cmbHospital.SelectedValue;

            try
            {
                if (idCitaEdicion.HasValue)
                {
                    controlador.actualizarCita(
                        idCitaEdicion.Value,
                        idPaciente,
                        idDoctor,
                        idHospital,
                        idEspecialidad,
                        fechaHora,
                        motivo,
                        idDoctorAutenticado
                    );

                    MessageBox.Show(
                        "La cita médica ha sido reprogramada exitosamente.",
                        "Operación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    controlador.guardarCita(
                        idPaciente,
                        idDoctor,
                        idHospital,
                        idEspecialidad,
                        fechaHora,
                        motivo,
                        idDoctorAutenticado,
                        idPacienteAutenticado
                    );

                    MessageBox.Show(
                        "La cita médica ha sido programada exitosamente con estado 'Pendiente'.",
                        "Operación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar la cita médica:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LimpiarErrores()
        {
            LimpiarError(lblErrorPaciente);
            LimpiarError(lblErrorEspecialidad);
            LimpiarError(lblErrorDoctor);
            LimpiarError(lblErrorHospital);
            LimpiarError(lblErrorFechaHora);
            LimpiarError(lblErrorMotivo);
        }

        private static void LimpiarError(Label lbl)
        {
            if (lbl != null) lbl.Text = string.Empty;
        }
    }
}
