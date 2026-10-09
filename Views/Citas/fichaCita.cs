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
        private readonly int? idPacienteFiltro;
        private readonly citasControllers controlador = new citasControllers();
        private SanarRuralUnan.Citas citaActual;

        public fichaCita(int idCita, int? idDoctor = null, int? idPaciente = null)
        {
            this.idCita = idCita;
            this.idDoctorFiltro = idDoctor;
            this.idPacienteFiltro = idPaciente;
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
            if (panelEncabezado.ClientSize.Width > 0)
            {
                lblPrefijo.Left = 24;
                lblPrefijo.Top = 14;

                lblTitulo.Left = 22;
                lblTitulo.Top = lblPrefijo.Bottom + 4;

                lblSubtitulo.Left = 24;
                lblSubtitulo.Top = lblTitulo.Bottom + 4;

                panelEncabezado.Height = Math.Max(105, lblSubtitulo.Bottom + 16);

                btnCerrarTop.Top = 26;
                btnCerrarTop.Left = Math.Max(300, panelEncabezado.ClientSize.Width - btnCerrarTop.Width - 24);

                panelBadgeEstado.Top = 26;
                panelBadgeEstado.Width = 140;
                panelBadgeEstado.Height = 36;
                panelBadgeEstado.Left = Math.Max(150, btnCerrarTop.Left - panelBadgeEstado.Width - 14);
            }

            if (panelContenido.ClientSize.Width <= 0) return;

            int margen = 20;
            int anchoDisponible = Math.Max(480, panelContenido.ClientSize.Width - (margen * 2) - 20);

            panelCardPaciente.Left = margen;
            panelCardPaciente.Width = anchoDisponible;
            panelCardPaciente.Height = 138;

            panelCardMedico.Left = margen;
            panelCardMedico.Width = anchoDisponible;
            panelCardMedico.Height = 88;

            panelCardHospital.Left = margen;
            panelCardHospital.Width = anchoDisponible;
            panelCardHospital.Height = 88;

            panelCardProgramacion.Left = margen;
            panelCardProgramacion.Width = anchoDisponible;
            panelCardProgramacion.Height = 138;

            panelCardMotivo.Left = margen;
            panelCardMotivo.Width = anchoDisponible;
            panelCardMotivo.Height = 118;
            panelMotivoBox.Left = 18;
            panelMotivoBox.Width = Math.Max(200, anchoDisponible - 36);

            panelCardAcciones.Left = margen;
            panelCardAcciones.Width = anchoDisponible;
            panelCardAcciones.Height = 88;

            // Flujo vertical dinámico sin solapamiento
            panelCardPaciente.Top = 16;
            panelCardMedico.Top = panelCardPaciente.Bottom + 12;
            panelCardHospital.Top = panelCardMedico.Bottom + 12;
            panelCardProgramacion.Top = panelCardHospital.Bottom + 12;
            panelCardMotivo.Top = panelCardProgramacion.Bottom + 12;
            panelCardAcciones.Top = panelCardMotivo.Bottom + 12;

            // Alineación de botón cerrar a la derecha en la tarjeta de acciones
            btnCerrar.Left = Math.Max(300, panelCardAcciones.ClientSize.Width - btnCerrar.Width - 18);

            // Columnas internas para Datos del Paciente (3 columnas superiores, dirección completa abajo)
            int c1 = 18;
            int c2 = Math.Max(240, (anchoDisponible * 36) / 100);
            int c3 = Math.Max(480, (anchoDisponible * 70) / 100);

            lblPacienteT.Left = c1; lblPacienteVal.Left = c1;
            lblCedulaT.Left = c2; lblCedulaVal.Left = c2;
            lblTelefonoT.Left = c3; lblTelefonoVal.Left = c3;

            lblDireccionT.Left = c1;
            lblDireccionVal.Left = c1;
            lblDireccionVal.Width = Math.Max(200, anchoDisponible - 36);

            // Columnas internas para Asignación Médica y Sede (2 columnas al 50%)
            int colMitad = Math.Max(240, (anchoDisponible * 50) / 100);
            lblDoctorT.Left = c1; lblDoctorVal.Left = c1;
            lblEspecialidadT.Left = colMitad; lblEspecialidadVal.Left = colMitad;

            lblHospitalT.Left = c1; lblHospitalVal.Left = c1;
            lblUbicacionT.Left = colMitad; lblUbicacionVal.Left = colMitad;

            // Columnas internas para Programación de la Cita (2 columnas limpias en 2 filas)
            int colProg = Math.Max(200, (anchoDisponible * 28) / 100);
            lblIdCitaT.Left = c1; lblIdCitaVal.Left = c1;
            lblFechaHoraT.Left = colProg; lblFechaHoraVal.Left = colProg;
            lblFechaHoraVal.Width = Math.Max(240, anchoDisponible - colProg - 20);

            lblFechaRegistroT.Left = c1; lblFechaRegistroVal.Left = c1;
            lblEstadoDetalleT.Left = colProg; lblEstadoDetalleVal.Left = colProg;
        }

        public void CargarDetalle()
        {
            try
            {
                citaActual = controlador.obtenerCitaPorId(idCita, idDoctorFiltro, idPacienteFiltro);
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
                lblSubtitulo.Text = $"Programada para el {citaActual.FechaHoraProgramada:dd/MM/yyyy hh:mm tt}  •  Sede: {hosp?.Nombre ?? "Sin sede asignada"}";

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

                // Datos de Programación con formato en español garantizado
                lblIdCitaVal.Text = $"#{citaActual.IdCita}";
                var culturaEs = new System.Globalization.CultureInfo("es-NI");
                string fechaProgTexto = citaActual.FechaHoraProgramada.ToString("dddd, dd 'de' MMMM 'de' yyyy — hh:mm tt", culturaEs);
                if (fechaProgTexto.Length > 0)
                    fechaProgTexto = char.ToUpper(fechaProgTexto[0]) + fechaProgTexto.Substring(1);
                lblFechaHoraVal.Text = fechaProgTexto;

                lblFechaRegistroVal.Text = citaActual.FechaCreacion.ToString("dd/MM/yyyy hh:mm tt");
                lblEstadoDetalleVal.Text = citaActual.Estado;

                // Motivo
                lblMotivoVal.Text = string.IsNullOrWhiteSpace(citaActual.Motivo)
                    ? "No se registró un motivo específico para esta cita médica."
                    : citaActual.Motivo;

                // Badge de Estado
                ActualizarBadgeEstado(citaActual.Estado);

                // Botones de acción disponibles según el estado y rol
                bool enProcesoOActiva = (citaActual.Estado == "Pendiente" || citaActual.Estado == "Confirmada");
                bool citaYaPaso = citaActual.FechaHoraProgramada <= DateTime.Now;

                if (idPacienteFiltro.HasValue)
                {
                    btnConfirmar.Visible = false;
                    btnEditar.Visible = false;
                    btnNoAsistio.Visible = false;
                    btnCancelar.Visible = (citaActual.Estado == "Pendiente");
                }
                else
                {
                    btnConfirmar.Visible = (citaActual.Estado == "Pendiente");
                    btnEditar.Visible = enProcesoOActiva;
                    btnCancelar.Visible = enProcesoOActiva;
                    btnNoAsistio.Visible = enProcesoOActiva && citaYaPaso;
                }

                AjustarLayout();
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
                    controlador.cambiarEstadoCita(idCita, "Confirmada", idDoctorFiltro, idPacienteFiltro);
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
            using (var formEditar = new crearCita(idCita, idDoctorFiltro, idPacienteFiltro))
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
                    controlador.cambiarEstadoCita(idCita, "Cancelada", idDoctorFiltro, idPacienteFiltro);
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
                    controlador.cambiarEstadoCita(idCita, "NoAsistio", idDoctorFiltro, idPacienteFiltro);
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
