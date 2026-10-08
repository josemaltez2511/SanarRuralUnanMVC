using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Citas
{
    /// <summary>
    /// Ventana modal de detalle integral para la visualización y gestión completa de una cita médica.
    /// Presenta datos completos del paciente, asignación facultativa, sede hospitalaria,
    /// programación temporal, motivo clínico íntegro y acciones de ciclo de vida.
    /// </summary>
    public partial class fichaCita : Form
    {
        private readonly int idCita;
        private readonly int? idDoctorFiltro;
        private readonly citasControllers controlador = new citasControllers();
        private SanarRuralUnan.Citas citaActual;

        public fichaCita(int idCita, int? idDoctor = null)
        {
            this.idCita = idCita;
            this.idDoctorFiltro = idDoctor;
            InitializeComponent();
        }

        private void fichaCita_Load(object sender, EventArgs e)
        {
            ConfigurarEstilos();
            CargarDetalle();
            AjustarLayout();
            this.Resize += (s, ev) => AjustarLayout();
        }

        private void ConfigurarEstilos()
        {
            panelEncabezado.Paint += (s, e) =>
            {
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawLine(pen, 0, panelEncabezado.Height - 1, panelEncabezado.Width, panelEncabezado.Height - 1);
                }
            };

            ConfigurarBordeCard(panelCardPaciente);
            ConfigurarBordeCard(panelCardMedico);
            ConfigurarBordeCard(panelCardHospital);
            ConfigurarBordeCard(panelCardProgramacion);
            ConfigurarBordeCard(panelCardMotivo);
            ConfigurarBordeCard(panelCardAcciones);

            panelMotivoBox.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelMotivoBox.Width - 1, panelMotivoBox.Height - 1), 8))
                using (var pen = new Pen(Tema.Borde, 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };

            btnCerrarTop.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
            btnCerrar.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };

            btnConfirmar.Click += btnConfirmar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnNoAsistio.Click += btnNoAsistio_Click;
        }

        private static void ConfigurarBordeCard(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 10))
                {
                    using (var pen = new Pen(Tema.Borde, 1f))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        private void AjustarLayout()
        {
            if (panelContenido.ClientSize.Width <= 0) return;

            int margen = 20;
            int anchoDisponible = Math.Max(400, panelContenido.ClientSize.Width - (margen * 2));

            panelCardPaciente.Left = margen;
            panelCardPaciente.Width = anchoDisponible;

            panelCardMedico.Left = margen;
            panelCardMedico.Width = anchoDisponible;

            panelCardHospital.Left = margen;
            panelCardHospital.Width = anchoDisponible;

            panelCardProgramacion.Left = margen;
            panelCardProgramacion.Width = anchoDisponible;

            panelCardMotivo.Left = margen;
            panelCardMotivo.Width = anchoDisponible;
            panelMotivoBox.Width = anchoDisponible - 36;

            panelCardAcciones.Left = margen;
            panelCardAcciones.Width = anchoDisponible;

            // Flujo vertical dinámico
            panelCardPaciente.Top = 16;
            panelCardMedico.Top = panelCardPaciente.Bottom + 12;
            panelCardHospital.Top = panelCardMedico.Bottom + 12;
            panelCardProgramacion.Top = panelCardHospital.Bottom + 12;
            panelCardMotivo.Top = panelCardProgramacion.Bottom + 12;
            panelCardAcciones.Top = panelCardMotivo.Bottom + 12;
        }

        public void CargarDetalle()
        {
            try
            {
                citaActual = controlador.obtenerCitaPorId(idCita, idDoctorFiltro);
                if (citaActual == null)
                {
                    MessageBox.Show("No se encontró la cita médica solicitada o no tiene permisos para consultarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                var pac = citaActual.Pacientes;
                var dhe = citaActual.DoctorHospitalEspecialidad;
                var doc = dhe?.DoctorEspecialidad?.Doctores;
                var esp = dhe?.DoctorEspecialidad?.Especialidades;
                var hosp = dhe?.Hospitales;

                string nombrePaciente = string.Join(" ", new[]
                {
                    pac?.PrimerNombre,
                    pac?.SegundoNombre,
                    pac?.PrimerApellido,
                    pac?.SegundoApellido
                }.Where(p => !string.IsNullOrWhiteSpace(p)));

                string nombreDoctor = string.Join(" ", new[]
                {
                    doc?.PrimerNombre,
                    doc?.SegundoNombre,
                    doc?.PrimerApellido,
                    doc?.SegundoApellido
                }.Where(p => !string.IsNullOrWhiteSpace(p)));

                lblTitulo.Text = $"Cita #{citaActual.IdCita} — {nombrePaciente}";
                lblSubtitulo.Text = $"Programada para el {citaActual.FechaHoraProgramada:dd/MM/yyyy hh:mm tt} | Sede: {hosp?.Nombre ?? "Sin sede"}";

                // Datos del Paciente
                lblPacienteVal.Text = nombrePaciente;
                lblCedulaVal.Text = string.IsNullOrWhiteSpace(pac?.Cedula) ? "Sin cédula registrada" : pac.Cedula;
                lblTelefonoVal.Text = string.IsNullOrWhiteSpace(pac?.Telefono) ? "Sin teléfono registrado" : pac.Telefono;
                lblDireccionVal.Text = string.IsNullOrWhiteSpace(pac?.Direccion) ? "Sin dirección registrada" : pac.Direccion;

                // Datos Médicos
                lblDoctorVal.Text = $"Dr(a). {nombreDoctor}";
                lblEspecialidadVal.Text = esp?.Nombre ?? "Sin especialidad";

                // Datos del Hospital
                lblHospitalVal.Text = hosp?.Nombre ?? "Sin hospital asignado";
                string depto = hosp?.Municipios?.Departamentos?.Nombre ?? "-";
                string muni = hosp?.Municipios?.Nombre ?? "-";
                lblUbicacionVal.Text = $"{depto}, {muni}";

                // Datos de Programación
                lblIdCitaVal.Text = $"#{citaActual.IdCita}";
                lblFechaHoraVal.Text = citaActual.FechaHoraProgramada.ToString("dddd, dd 'de' MMMM 'de' yyyy — hh:mm tt");
                lblFechaRegistroVal.Text = citaActual.FechaCreacion.ToString("dd/MM/yyyy hh:mm tt");
                lblEstadoDetalleVal.Text = citaActual.Estado;

                // Motivo
                lblMotivoVal.Text = string.IsNullOrWhiteSpace(citaActual.Motivo)
                    ? "No se registró un motivo específico para esta cita médica."
                    : citaActual.Motivo;

                // Badge de Estado
                ActualizarBadgeEstado(citaActual.Estado);

                // Botones de acción disponibles según el estado
                bool enProcesoOActiva = (citaActual.Estado == "Pendiente" || citaActual.Estado == "Confirmada");
                bool citaYaPaso = citaActual.FechaHoraProgramada <= DateTime.Now;

                btnConfirmar.Visible = (citaActual.Estado == "Pendiente");
                btnEditar.Visible = enProcesoOActiva;
                btnCancelar.Visible = enProcesoOActiva;
                btnNoAsistio.Visible = enProcesoOActiva && citaYaPaso;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarBadgeEstado(string estado)
        {
            Color colorFondo = Tema.Superficie;
            Color colorBorde = Tema.Borde;
            Color colorTexto = Tema.TextoPrincipal;
            string textoEstado = estado;

            if (estado == "Pendiente")
            {
                colorFondo = Tema.BadgePendienteFondo;
                colorBorde = Tema.BadgePendienteBorde;
                colorTexto = Tema.Advertencia;
                textoEstado = "⏳ Pendiente";
            }
            else if (estado == "Confirmada")
            {
                colorFondo = Tema.BadgeConfirmadaFondo;
                colorBorde = Tema.BadgeConfirmadaBorde;
                colorTexto = Tema.VerdeOscuro;
                textoEstado = "✓ Confirmada";
            }
            else if (estado == "Atendida")
            {
                colorFondo = Tema.BadgeAtendidaFondo;
                colorBorde = Tema.BadgeAtendidaBorde;
                colorTexto = Tema.AzulPrimario;
                textoEstado = "✓ Atendida";
            }
            else if (estado == "Cancelada")
            {
                colorFondo = Tema.BadgeCanceladaFondo;
                colorBorde = Tema.BadgeCanceladaBorde;
                colorTexto = Tema.Error;
                textoEstado = "✕ Cancelada";
            }
            else if (estado == "NoAsistio")
            {
                colorFondo = Tema.BadgeNoAsistioFondo;
                colorBorde = Tema.BadgeNoAsistioBorde;
                colorTexto = Tema.TextoSecundario;
                textoEstado = "⊘ No asistió";
            }

            panelBadgeEstado.BackColor = colorFondo;
            lblEstadoBadge.Text = textoEstado;
            lblEstadoBadge.ForeColor = colorTexto;
            lblEstadoDetalleVal.ForeColor = colorTexto;

            panelBadgeEstado.Paint -= PanelBadgeEstado_Paint;
            panelBadgeEstado.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = Tema.CrearRutaRedondeada(new Rectangle(0, 0, panelBadgeEstado.Width - 1, panelBadgeEstado.Height - 1), 10))
                using (var pen = new Pen(colorBorde, 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
            panelBadgeEstado.Invalidate();
        }

        private void PanelBadgeEstado_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "¿Desea confirmar esta cita médica?",
                "Confirmación de Cita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                try
                {
                    controlador.cambiarEstadoCita(idCita, "Confirmada", idDoctorFiltro);
                    MessageBox.Show("La cita ha sido confirmada correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDetalle();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al confirmar la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (var formEditar = new crearCita(idCita, idDoctorFiltro))
            {
                if (formEditar.ShowDialog(this) == DialogResult.OK)
                {
                    CargarDetalle();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "¿Está seguro de que desea cancelar esta cita médica?\nEsta acción no se puede deshacer.",
                "Cancelar Cita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (res == DialogResult.Yes)
            {
                try
                {
                    controlador.cambiarEstadoCita(idCita, "Cancelada", idDoctorFiltro);
                    MessageBox.Show("La cita médica ha sido cancelada.", "Cita Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDetalle();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNoAsistio_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "¿Desea registrar que el paciente no asistió a su cita programada?",
                "Registrar Inasistencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.Yes)
            {
                try
                {
                    controlador.cambiarEstadoCita(idCita, "NoAsistio", idDoctorFiltro);
                    MessageBox.Show("Se ha registrado la inasistencia del paciente.", "Inasistencia Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDetalle();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar inasistencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
