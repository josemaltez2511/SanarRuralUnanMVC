using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.ConsultaMedica
{
    // Ventana clínica completa para la atención médica, captura de signos vitales, evolución, diagnóstico y prescripción.
    public partial class atencionConsulta : Form
    {
        private readonly consultasControllers controlador = new consultasControllers();
        private readonly int idConsulta;
        private readonly int? idDoctorAutenticado;
        private readonly int? idPacienteAutenticado;

        private ConsultaDetalleDto consultaActual;
        private readonly List<DiagnosticoItemDto> listaDiagnosticos = new List<DiagnosticoItemDto>();
        private readonly List<PrescripcionItemDto> listaPrescripciones = new List<PrescripcionItemDto>();
        private bool esSoloLectura = false;

        public atencionConsulta(int idConsulta, int? idDoctorAutenticado = null, int? idPacienteAutenticado = null)
        {
            this.idConsulta = idConsulta;
            this.idDoctorAutenticado = idDoctorAutenticado;
            this.idPacienteAutenticado = idPacienteAutenticado;
            InitializeComponent();
        }

        // ============================================================
        // INICIALIZACIÓN Y CARGA DE DATOS
        // ============================================================
        private void atencionConsulta_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloTablas();
            ConfigurarComportamientoSignosVitales();
            CargarCatalogos();
            CargarExpedienteConsulta();
        }

        private void ConfigurarEstiloTablas()
        {
            Tema.ConfigurarTabla(dgvDiagnosticos);
            dgvDiagnosticos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDiagnosticos.AllowUserToResizeRows = false;

            Tema.ConfigurarTabla(dgvPrescripciones);
            dgvPrescripciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPrescripciones.AllowUserToResizeRows = false;
        }

        private void CargarCatalogos()
        {
            // Tipos oficiales de diagnósticos
            cmbTipoDiagnostico.Items.Clear();
            cmbTipoDiagnostico.Items.Add("Principal");
            cmbTipoDiagnostico.Items.Add("Secundario");
            cmbTipoDiagnostico.Items.Add("Presuntivo");
            cmbTipoDiagnostico.Items.Add("Diferencial");
            cmbTipoDiagnostico.SelectedIndex = 0;

            // Catálogo de Enfermedades activas
            var enfermedades = controlador.listarEnfermedadesActivas();
            cmbEnfermedad.DisplayMember = "NombreEnfermedad";
            cmbEnfermedad.ValueMember = "IdEnfermedad";
            cmbEnfermedad.DataSource = enfermedades;

            // Vías de administración farmacológica
            cmbVia.Items.Clear();
            cmbVia.Items.AddRange(new object[]
            {
                "Oral",
                "Intravenosa",
                "Intramuscular",
                "Tópica",
                "Oftálmica",
                "Inhalatoria",
                "Sublingual",
                "Rectal",
                "Nasal"
            });
            cmbVia.SelectedIndex = 0;

            // Catálogo de Medicamentos activos
            var medicamentos = controlador.listarMedicamentosActivos();
            cmbMedicamento.DisplayMember = "NombreParaSelector";
            cmbMedicamento.ValueMember = "IdMedicamento";
            cmbMedicamento.DataSource = medicamentos;
        }

        private void CargarExpedienteConsulta()
        {
            try
            {
                consultaActual = controlador.obtenerConsultaDetalle(idConsulta, idDoctorAutenticado, idPacienteAutenticado);
                if (consultaActual == null)
                {
                    MessageBox.Show("No se encontró la consulta médica especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Determinación de modo solo lectura
                bool esFinalizada = consultaActual.EstadoConsulta == "Finalizada";
                bool esSupervisionAdmin = !idDoctorAutenticado.HasValue && !idPacienteAutenticado.HasValue;
                bool esPaciente = idPacienteAutenticado.HasValue;
                esSoloLectura = esFinalizada || esSupervisionAdmin || esPaciente;

                // 1. Banner superior
                ActualizarBanner(esFinalizada, esSupervisionAdmin);

                // 2. Signos vitales
                CargarSignosVitales();

                // 3. Evolución clínica
                txtPadecimientoActual.Text = consultaActual.PadecimientoActual ?? string.Empty;
                txtExamenFisico.Text = consultaActual.ExamenFisico ?? string.Empty;
                txtObservaciones.Text = consultaActual.Observaciones ?? string.Empty;

                // 4. Diagnósticos
                listaDiagnosticos.Clear();
                if (consultaActual.Diagnosticos != null)
                {
                    listaDiagnosticos.AddRange(consultaActual.Diagnosticos);
                }
                RefrescarGridDiagnosticos();

                // 5. Prescripciones y Plan de Seguimiento
                listaPrescripciones.Clear();
                if (consultaActual.Prescripciones != null)
                {
                    listaPrescripciones.AddRange(consultaActual.Prescripciones);
                }
                RefrescarGridPrescripciones();
                txtPlanSeguimiento.Text = consultaActual.PlanSeguimiento ?? string.Empty;

                // 6. Aplicar restricciones de solo lectura si aplica
                if (esSoloLectura)
                {
                    AplicarModoSoloLectura(esSupervisionAdmin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el expediente clínico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ActualizarBanner(bool esFinalizada, bool esSupervisionAdmin)
        {
            string edadTexto = "Edad no registrada";
            if (consultaActual.FechaNacimiento.HasValue)
            {
                int edad = DateTime.Today.Year - consultaActual.FechaNacimiento.Value.Year;
                if (consultaActual.FechaNacimiento.Value.Date > DateTime.Today.AddYears(-edad)) edad--;
                edadTexto = $"{edad} años";
            }

            lblPacienteInfo.Text = $"Paciente: {consultaActual.Paciente}  |  Cédula: {consultaActual.Cedula}  |  Sexo: {consultaActual.Sexo}  |  Edad: {edadTexto}";
            lblCitaInfo.Text = $"Médico: {consultaActual.Doctor}  |  Sede: {consultaActual.Hospital}  |  Especialidad: {consultaActual.Especialidad}  |  Cita: {consultaActual.FechaHoraProgramadaTexto}  |  Motivo: {consultaActual.MotivoCita}";

            if (esFinalizada)
            {
                lblChipEstado.Text = "FINALIZADA";
                lblChipEstado.BackColor = Tema.FondoSecundario;
                lblChipEstado.ForeColor = Tema.VerdeOscuro;
            }
            else
            {
                lblChipEstado.Text = "EN PROCESO";
                lblChipEstado.BackColor = Tema.FondoSecundario;
                lblChipEstado.ForeColor = Tema.Advertencia;
            }
        }

        private void ConfigurarComportamientoSignosVitales()
        {
            var controles = new[]
            {
                numSistolica, numDiastolica, numPulso, numRespiracion,
                numTemperatura, numSaturacion, numPeso, numTalla
            };

            foreach (var num in controles)
            {
                num.Enter += (s, e) =>
                {
                    if (num.Value == 0)
                    {
                        num.Select(0, num.Text.Length);
                    }
                };
                num.Leave += (s, e) =>
                {
                    if (num.Value == 0)
                    {
                        num.Text = string.Empty;
                    }
                };
            }
        }

        private void CargarSignosVitales()
        {
            var sv = consultaActual.SignosVitales;
            if (sv != null)
            {
                numSistolica.Value = sv.PresionSistolica ?? 0;
                numDiastolica.Value = sv.PresionDiastolica ?? 0;
                numPulso.Value = sv.FrecuenciaCardiaca ?? 0;
                numRespiracion.Value = sv.FrecuenciaRespiratoria ?? 0;
                numTemperatura.Value = sv.Temperatura ?? 0;
                numSaturacion.Value = sv.SaturacionOxigeno ?? 0;
                numPeso.Value = sv.PesoKg ?? 0;
                numTalla.Value = sv.TallaCm ?? 0;
            }
            else
            {
                numSistolica.Value = 0;
                numDiastolica.Value = 0;
                numPulso.Value = 0;
                numRespiracion.Value = 0;
                numTemperatura.Value = 0;
                numSaturacion.Value = 0;
                numPeso.Value = 0;
                numTalla.Value = 0;
            }

            ActualizarVisualizacionSignosNoRegistrados();
            CalcularImcEnTiempoReal(this, EventArgs.Empty);
        }

        private void ActualizarVisualizacionSignosNoRegistrados()
        {
            var controles = new[]
            {
                numSistolica, numDiastolica, numPulso, numRespiracion,
                numTemperatura, numSaturacion, numPeso, numTalla
            };

            foreach (var num in controles)
            {
                if (num.Value == 0)
                {
                    num.Text = string.Empty;
                }
            }
        }

        private void AplicarModoSoloLectura(bool esSupervisionAdmin)
        {
            btnGuardarBorrador.Visible = false;
            btnFinalizar.Visible = false;
            btnAgregarDiagnostico.Enabled = false;
            btnAgregarPrescripcion.Enabled = false;

            numSistolica.Enabled = false;
            numDiastolica.Enabled = false;
            numPulso.Enabled = false;
            numRespiracion.Enabled = false;
            numTemperatura.Enabled = false;
            numSaturacion.Enabled = false;
            numPeso.Enabled = false;
            numTalla.Enabled = false;
            ActualizarVisualizacionSignosNoRegistrados();

            txtPadecimientoActual.ReadOnly = true;
            txtExamenFisico.ReadOnly = true;
            txtObservaciones.ReadOnly = true;
            txtPlanSeguimiento.ReadOnly = true;

            cmbTipoDiagnostico.Enabled = false;
            cmbEnfermedad.Enabled = false;
            txtDiagDescripcion.ReadOnly = true;
            txtDiagObservaciones.ReadOnly = true;

            cmbMedicamento.Enabled = false;
            txtDosis.ReadOnly = true;
            txtFrecuencia.ReadOnly = true;
            txtDuracion.ReadOnly = true;
            cmbVia.Enabled = false;
            txtIndicaciones.ReadOnly = true;
            chkPermiteSustitucion.Enabled = false;

            btnCopiarRecomendacion.Enabled = false;

            lblMensajeEstado.Text = esSupervisionAdmin
                ? "👁️ Supervisión administrativa: Consulta en modo de solo lectura."
                : "🔒 Consulta finalizada: El expediente no puede ser modificado.";
            lblMensajeEstado.ForeColor = esSupervisionAdmin ? Tema.AzulPrimario : Tema.TextoSecundario;
        }

        // ============================================================
        // CÁLCULO DINÁMICO DE ÍNDICE DE MASA CORPORAL (IMC)
        // ============================================================
        private void CalcularImcEnTiempoReal(object sender, EventArgs e)
        {
            decimal peso = numPeso.Value;
            decimal talla = numTalla.Value;

            if (peso > 0 && talla > 0)
            {
                decimal metros = talla / 100m;
                decimal imc = Math.Round(peso / (metros * metros), 1);
                lblImcValor.Text = $"{imc} kg/m²";

                if (imc < 18.5m)
                {
                    lblImcClasificacion.Text = "Bajo peso";
                    lblImcClasificacion.ForeColor = Tema.Advertencia;
                }
                else if (imc <= 24.9m)
                {
                    lblImcClasificacion.Text = "Normopeso (Rango saludable)";
                    lblImcClasificacion.ForeColor = Tema.VerdeOscuro;
                }
                else if (imc <= 29.9m)
                {
                    lblImcClasificacion.Text = "Sobrepeso";
                    lblImcClasificacion.ForeColor = Tema.Advertencia;
                }
                else
                {
                    lblImcClasificacion.Text = "Obesidad";
                    lblImcClasificacion.ForeColor = Tema.Error;
                }
            }
            else
            {
                lblImcValor.Text = "-- kg/m²";
                lblImcClasificacion.Text = "Sin registrar (Ingrese Peso y Talla)";
                lblImcClasificacion.ForeColor = Tema.TextoSecundario;
            }
        }

        // ============================================================
        // APOYO CLÍNICO Y RECOMENDACIONES
        // ============================================================
        private void cmbEnfermedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEnfermedad.SelectedValue is int idEnfermedad)
            {
                var recomendaciones = controlador.obtenerRecomendacionesPorEnfermedad(idEnfermedad);
                lstRecomendaciones.Items.Clear();

                if (recomendaciones.Count > 0)
                {
                    foreach (var rec in recomendaciones)
                    {
                        lstRecomendaciones.Items.Add(rec.Descripcion);
                    }
                }
                else
                {
                    lstRecomendaciones.Items.Add("No hay recomendaciones clínicas específicas registradas.");
                }

                // Autocompletar la descripción diagnóstica sugerida si está vacía
                if (string.IsNullOrWhiteSpace(txtDiagDescripcion.Text) && cmbEnfermedad.SelectedItem is EnfermedadItemDto enf)
                {
                    txtDiagDescripcion.Text = enf.NombreEnfermedad;
                }
            }
        }

        private void btnCopiarRecomendacion_Click(object sender, EventArgs e)
        {
            if (lstRecomendaciones.SelectedItem != null)
            {
                string texto = lstRecomendaciones.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(texto) && !texto.StartsWith("No hay recomendaciones"))
                {
                    if (string.IsNullOrWhiteSpace(txtPlanSeguimiento.Text))
                    {
                        txtPlanSeguimiento.Text = "• " + texto;
                    }
                    else
                    {
                        txtPlanSeguimiento.Text += Environment.NewLine + "• " + texto;
                    }
                    MessageBox.Show("La recomendación médica se ha copiado al Plan Terapéutico.", "Recomendación Copiada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una recomendación de la lista para copiarla al plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ============================================================
        // GESTIÓN DE DIAGNÓSTICOS
        // ============================================================
        private void RefrescarGridDiagnosticos()
        {
            dgvDiagnosticos.DataSource = null;
            dgvDiagnosticos.DataSource = listaDiagnosticos.ToList();

            if (dgvDiagnosticos.Columns["TipoDiagnostico"] != null)
            {
                dgvDiagnosticos.Columns["TipoDiagnostico"].HeaderText = "Tipo";
                dgvDiagnosticos.Columns["TipoDiagnostico"].FillWeight = 85;
            }
            if (dgvDiagnosticos.Columns["NombreEnfermedad"] != null)
            {
                dgvDiagnosticos.Columns["NombreEnfermedad"].HeaderText = "Enfermedad / CIE";
                dgvDiagnosticos.Columns["NombreEnfermedad"].FillWeight = 140;
            }
            if (dgvDiagnosticos.Columns["Descripcion"] != null)
            {
                dgvDiagnosticos.Columns["Descripcion"].HeaderText = "Descripción Clínica";
                dgvDiagnosticos.Columns["Descripcion"].FillWeight = 160;
            }
            if (dgvDiagnosticos.Columns["Observaciones"] != null)
            {
                dgvDiagnosticos.Columns["Observaciones"].HeaderText = "Observaciones";
                dgvDiagnosticos.Columns["Observaciones"].FillWeight = 110;
            }

            OcultarColumnaSiExiste(dgvDiagnosticos, "IdDiagnostico");
            OcultarColumnaSiExiste(dgvDiagnosticos, "IdEnfermedad");

            if (!esSoloLectura && !dgvDiagnosticos.Columns.Contains("colQuitarDiag"))
            {
                DataGridViewButtonColumn colQuitar = new DataGridViewButtonColumn
                {
                    Name = "colQuitarDiag",
                    HeaderText = "Acción",
                    Text = "✕ Quitar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 70
                };
                dgvDiagnosticos.Columns.Add(colQuitar);
            }

            if (dgvDiagnosticos.Columns.Contains("colQuitarDiag"))
            {
                dgvDiagnosticos.Columns["colQuitarDiag"].DisplayIndex = dgvDiagnosticos.Columns.Count - 1;
            }
        }

        private void btnAgregarDiagnostico_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipoDiagnostico.SelectedItem?.ToString() ?? "Principal";
            string descripcion = txtDiagDescripcion.Text.Trim();
            string observaciones = txtDiagObservaciones.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Debe indicar una descripción clínica para el diagnóstico.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagDescripcion.Focus();
                return;
            }

            int? idEnfermedad = null;
            string nombreEnfermedad = "Sin catalogar";
            if (cmbEnfermedad.SelectedValue is int idEnf)
            {
                idEnfermedad = idEnf;
                nombreEnfermedad = cmbEnfermedad.Text;
            }

            // Si se agrega un nuevo diagnóstico Principal, verificar si ya existe uno para alertar
            if (tipo == "Principal" && listaDiagnosticos.Any(d => d.TipoDiagnostico == "Principal"))
            {
                DialogResult reemplazar = MessageBox.Show(
                    "Ya existe un diagnóstico catalogado como 'Principal'. ¿Desea convertir los anteriores a 'Secundario'?",
                    "Diagnóstico Principal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (reemplazar == DialogResult.Yes)
                {
                    foreach (var d in listaDiagnosticos.Where(x => x.TipoDiagnostico == "Principal"))
                    {
                        d.TipoDiagnostico = "Secundario";
                    }
                }
            }

            listaDiagnosticos.Add(new DiagnosticoItemDto
            {
                IdDiagnostico = 0,
                IdEnfermedad = idEnfermedad,
                NombreEnfermedad = nombreEnfermedad,
                TipoDiagnostico = tipo,
                Descripcion = descripcion,
                Observaciones = observaciones
            });

            txtDiagDescripcion.Clear();
            txtDiagObservaciones.Clear();
            RefrescarGridDiagnosticos();
        }

        private void dgvDiagnosticos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvDiagnosticos.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colQuitarDiag" && !esSoloLectura)
            {
                e.PaintBackground(e.CellBounds, true);
                Rectangle btnRect = new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, e.CellBounds.Width - 8, e.CellBounds.Height - 8);

                using (SolidBrush brush = new SolidBrush(Tema.ColorError))
                {
                    e.Graphics.FillRectangle(brush, btnRect);
                }

                using (Font fuenteBoton = Tema.FuenteBoton)
                {
                    TextRenderer.DrawText(e.Graphics, "✕ Quitar", fuenteBoton, btnRect, Tema.Superficie,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
        }

        private void dgvDiagnosticos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvDiagnosticos.Columns[e.ColumnIndex].Name;
                dgvDiagnosticos.Cursor = (nombreColumna == "colQuitarDiag" && !esSoloLectura) ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                dgvDiagnosticos.Cursor = Cursors.Default;
            }
        }

        private void dgvDiagnosticos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || esSoloLectura) return;

            string nombreColumna = dgvDiagnosticos.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colQuitarDiag")
            {
                if (e.RowIndex < listaDiagnosticos.Count)
                {
                    listaDiagnosticos.RemoveAt(e.RowIndex);
                    RefrescarGridDiagnosticos();
                }
            }
        }

        // ============================================================
        // GESTIÓN DE PRESCRIPCIONES
        // ============================================================
        private void RefrescarGridPrescripciones()
        {
            dgvPrescripciones.DataSource = null;
            dgvPrescripciones.DataSource = listaPrescripciones.ToList();

            if (dgvPrescripciones.Columns["NombreMedicamento"] != null)
            {
                dgvPrescripciones.Columns["NombreMedicamento"].HeaderText = "Medicamento";
                dgvPrescripciones.Columns["NombreMedicamento"].FillWeight = 140;
            }
            if (dgvPrescripciones.Columns["Dosis"] != null)
            {
                dgvPrescripciones.Columns["Dosis"].HeaderText = "Dosis";
                dgvPrescripciones.Columns["Dosis"].FillWeight = 80;
            }
            if (dgvPrescripciones.Columns["Frecuencia"] != null)
            {
                dgvPrescripciones.Columns["Frecuencia"].HeaderText = "Frecuencia";
                dgvPrescripciones.Columns["Frecuencia"].FillWeight = 90;
            }
            if (dgvPrescripciones.Columns["Duracion"] != null)
            {
                dgvPrescripciones.Columns["Duracion"].HeaderText = "Duración";
                dgvPrescripciones.Columns["Duracion"].FillWeight = 80;
            }
            if (dgvPrescripciones.Columns["ViaAdministracion"] != null)
            {
                dgvPrescripciones.Columns["ViaAdministracion"].HeaderText = "Vía";
                dgvPrescripciones.Columns["ViaAdministracion"].FillWeight = 70;
            }
            if (dgvPrescripciones.Columns["Indicaciones"] != null)
            {
                dgvPrescripciones.Columns["Indicaciones"].HeaderText = "Indicaciones";
                dgvPrescripciones.Columns["Indicaciones"].FillWeight = 130;
            }
            if (dgvPrescripciones.Columns["PermiteSustitucion"] != null)
            {
                dgvPrescripciones.Columns["PermiteSustitucion"].HeaderText = "Genérico";
                dgvPrescripciones.Columns["PermiteSustitucion"].FillWeight = 60;
            }

            OcultarColumnaSiExiste(dgvPrescripciones, "IdPrescripcion");
            OcultarColumnaSiExiste(dgvPrescripciones, "IdMedicamento");
            OcultarColumnaSiExiste(dgvPrescripciones, "PrincipioActivo");
            OcultarColumnaSiExiste(dgvPrescripciones, "Concentracion");
            OcultarColumnaSiExiste(dgvPrescripciones, "FechaPrescripcion");

            if (!esSoloLectura && !dgvPrescripciones.Columns.Contains("colQuitarPresc"))
            {
                DataGridViewButtonColumn colQuitar = new DataGridViewButtonColumn
                {
                    Name = "colQuitarPresc",
                    HeaderText = "Acción",
                    Text = "✕ Quitar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 70
                };
                dgvPrescripciones.Columns.Add(colQuitar);
            }

            if (dgvPrescripciones.Columns.Contains("colQuitarPresc"))
            {
                dgvPrescripciones.Columns["colQuitarPresc"].DisplayIndex = dgvPrescripciones.Columns.Count - 1;
            }
        }

        private void btnAgregarPrescripcion_Click(object sender, EventArgs e)
        {
            if (!(cmbMedicamento.SelectedValue is int idMedicamento))
            {
                MessageBox.Show("Debe seleccionar un medicamento activo del catálogo.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dosis = txtDosis.Text.Trim();
            string frecuencia = txtFrecuencia.Text.Trim();
            string duracion = txtDuracion.Text.Trim();
            string via = cmbVia.SelectedItem?.ToString() ?? "Oral";
            string indicaciones = txtIndicaciones.Text.Trim();
            bool permiteSustitucion = chkPermiteSustitucion.Checked;

            if (string.IsNullOrWhiteSpace(dosis))
            {
                MessageBox.Show("Debe especificar la dosis requerida para el medicamento.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDosis.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(frecuencia))
            {
                MessageBox.Show("Debe especificar la frecuencia de administración (ej. Cada 8 horas).", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFrecuencia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(duracion))
            {
                MessageBox.Show("Debe especificar la duración del tratamiento (ej. 7 días).", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuracion.Focus();
                return;
            }

            var medItem = cmbMedicamento.SelectedItem as MedicamentoItemDto;
            string nombreMed = medItem != null ? medItem.NombreMedicamento : cmbMedicamento.Text;

            listaPrescripciones.Add(new PrescripcionItemDto
            {
                IdPrescripcion = 0,
                IdMedicamento = idMedicamento,
                NombreMedicamento = nombreMed,
                PrincipioActivo = medItem?.PrincipioActivo ?? string.Empty,
                Concentracion = medItem?.Concentracion ?? string.Empty,
                Dosis = dosis,
                Frecuencia = frecuencia,
                Duracion = duracion,
                ViaAdministracion = via,
                Indicaciones = indicaciones,
                PermiteSustitucion = permiteSustitucion,
                FechaPrescripcion = DateTime.Now
            });

            txtDosis.Clear();
            txtFrecuencia.Clear();
            txtDuracion.Clear();
            txtIndicaciones.Clear();
            RefrescarGridPrescripciones();
        }

        private void dgvPrescripciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvPrescripciones.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colQuitarPresc" && !esSoloLectura)
            {
                e.PaintBackground(e.CellBounds, true);
                Rectangle btnRect = new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, e.CellBounds.Width - 8, e.CellBounds.Height - 8);

                using (SolidBrush brush = new SolidBrush(Tema.ColorError))
                {
                    e.Graphics.FillRectangle(brush, btnRect);
                }

                using (Font fuenteBoton = Tema.FuenteBoton)
                {
                    TextRenderer.DrawText(e.Graphics, "✕ Quitar", fuenteBoton, btnRect, Tema.Superficie,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
        }

        private void dgvPrescripciones_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvPrescripciones.Columns[e.ColumnIndex].Name;
                dgvPrescripciones.Cursor = (nombreColumna == "colQuitarPresc" && !esSoloLectura) ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                dgvPrescripciones.Cursor = Cursors.Default;
            }
        }

        private void dgvPrescripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || esSoloLectura) return;

            string nombreColumna = dgvPrescripciones.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colQuitarPresc")
            {
                if (e.RowIndex < listaPrescripciones.Count)
                {
                    listaPrescripciones.RemoveAt(e.RowIndex);
                    RefrescarGridPrescripciones();
                }
            }
        }

        // ============================================================
        // OBTENCIÓN DE DATOS DEL FORMULARIO
        // ============================================================
        private SignosVitalesDto ObtenerSignosVitalesDesdeFormulario()
        {
            return new SignosVitalesDto
            {
                PresionSistolica = numSistolica.Value > 0 ? (short)numSistolica.Value : (short?)null,
                PresionDiastolica = numDiastolica.Value > 0 ? (short)numDiastolica.Value : (short?)null,
                FrecuenciaCardiaca = numPulso.Value > 0 ? (short)numPulso.Value : (short?)null,
                FrecuenciaRespiratoria = numRespiracion.Value > 0 ? (short)numRespiracion.Value : (short?)null,
                Temperatura = numTemperatura.Value > 0 ? numTemperatura.Value : (decimal?)null,
                SaturacionOxigeno = numSaturacion.Value > 0 ? numSaturacion.Value : (decimal?)null,
                PesoKg = numPeso.Value > 0 ? numPeso.Value : (decimal?)null,
                TallaCm = numTalla.Value > 0 ? numTalla.Value : (decimal?)null
            };
        }

        // ============================================================
        // ACCIONES PRINCIPALES: GUARDAR BORRADOR Y FINALIZAR
        // ============================================================
        private void btnGuardarBorrador_Click(object sender, EventArgs e)
        {
            if (esSoloLectura) return;

            try
            {
                string padecimiento = txtPadecimientoActual.Text.Trim();
                string examen = txtExamenFisico.Text.Trim();
                string observaciones = txtObservaciones.Text.Trim();
                string plan = txtPlanSeguimiento.Text.Trim();
                var signos = ObtenerSignosVitalesDesdeFormulario();

                controlador.guardarBorradorConsulta(
                    idConsulta,
                    padecimiento,
                    examen,
                    observaciones,
                    plan,
                    signos,
                    listaDiagnosticos,
                    listaPrescripciones,
                    idDoctorAutenticado
                );

                lblMensajeEstado.Text = $"💾 Borrador guardado exitosamente a las {DateTime.Now:hh:mm:ss tt}.";
                lblMensajeEstado.ForeColor = Tema.VerdeOscuro;

                MessageBox.Show("El borrador de la consulta clínica se ha guardado correctamente.", "Borrador Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el borrador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (esSoloLectura) return;

            string padecimiento = txtPadecimientoActual.Text.Trim();
            string examen = txtExamenFisico.Text.Trim();
            string observaciones = txtObservaciones.Text.Trim();
            string plan = txtPlanSeguimiento.Text.Trim();

            // Validaciones requeridas por regla de negocio (al menos un diagnóstico principal)
            if (!listaDiagnosticos.Any())
            {
                MessageBox.Show("Debe ingresar al menos un diagnóstico antes de finalizar la consulta.", "Validación Clínica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabConsulta.SelectedTab = tabDiagnosticos;
                txtDiagDescripcion.Focus();
                return;
            }

            if (!listaDiagnosticos.Any(d => d.TipoDiagnostico == "Principal"))
            {
                MessageBox.Show("Debe existir al menos un diagnóstico clasificado como 'Principal' para finalizar la atención médica.", "Validación Clínica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabConsulta.SelectedTab = tabDiagnosticos;
                cmbTipoDiagnostico.Focus();
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea finalizar formalmente la consulta médica?\n\n" +
                "• El expediente quedará cerrado y en modo de sólo lectura.\n" +
                "• La cita médica pasará automáticamente a estado 'Atendida'.\n" +
                "• Esta operación no se puede deshacer.",
                "Confirmar Cierre de Consulta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var signos = ObtenerSignosVitalesDesdeFormulario();

                controlador.finalizarConsulta(
                    idConsulta,
                    padecimiento,
                    examen,
                    observaciones,
                    plan,
                    signos,
                    listaDiagnosticos,
                    listaPrescripciones,
                    idDoctorAutenticado
                );

                MessageBox.Show("La consulta médica ha sido finalizada exitosamente.", "Consulta Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar la consulta: " + ex.Message, "Error al Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!esSoloLectura)
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea salir de la consulta médica? Cualquier cambio no guardado se descartará.",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }
            }

            this.Close();
        }

        private void OcultarColumnaSiExiste(DataGridView grid, string nombreColumna)
        {
            if (grid.Columns[nombreColumna] != null)
            {
                grid.Columns[nombreColumna].Visible = false;
            }
        }
    }
}
