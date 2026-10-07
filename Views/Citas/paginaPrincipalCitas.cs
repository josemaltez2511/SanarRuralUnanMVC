using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;

namespace SanarRuralUnan.Views.Citas
{
    // Vista principal para consulta, filtrado y ciclo de vida de citas médicas.
    public partial class paginaPrincipalCitas : Form
    {
        private readonly citasControllers controlador = new citasControllers();
        private readonly int? idDoctorFiltro;

        // Constructor para modo administrativo (visualiza y gestiona todas las citas).
        public paginaPrincipalCitas() : this(null)
        {
        }

        // Constructor con filtro opcional de doctor (para cuando inicia sesión un médico).
        public paginaPrincipalCitas(int? idDoctor)
        {
            this.idDoctorFiltro = idDoctor;
            InitializeComponent();
        }

        // ============================================================
        // INICIALIZACIÓN
        // ============================================================
        private void paginaPrincipalCitas_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloGrid();
            CargarFiltrosEstado();
            CargarCitas();

            // Refresca la tabla automáticamente cuando la ventana vuelve a mostrarse en el contenedor.
            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible)
                {
                    CargarCitas();
                }
            };
        }

        private void ConfigurarEstiloGrid()
        {
            Tema.ConfigurarTabla(dgvCitas);
            dgvCitas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCitas.AllowUserToResizeRows = false;
            dgvCitas.AccessibleName = "Listado de citas médicas";
            dgvCitas.AccessibleDescription = "Use las flechas para recorrer las citas programadas y acceder a sus acciones.";
        }

        private void CargarFiltrosEstado()
        {
            cmbEstadoFiltro.Items.Clear();
            cmbEstadoFiltro.Items.Add("Todos");
            cmbEstadoFiltro.Items.Add("Pendiente");
            cmbEstadoFiltro.Items.Add("Confirmada");
            cmbEstadoFiltro.Items.Add("Atendida");
            cmbEstadoFiltro.Items.Add("Cancelada");
            cmbEstadoFiltro.Items.Add("NoAsistio");
            cmbEstadoFiltro.SelectedIndex = 0;
        }

        // ============================================================
        // CARGA DE DATOS Y COLUMNAS
        // ============================================================
        public void CargarCitas()
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                DateTime? fecha = chkTodasFechas.Checked ? (DateTime?)null : dtpFechaFiltro.Value.Date;
                string estado = cmbEstadoFiltro.SelectedItem?.ToString() ?? "Todos";

                dgvCitas.DataSource = controlador.listarCitas(busqueda, fecha, estado, idDoctorFiltro);

                // Configuración de encabezados y visibilidad de columnas de datos.
                if (dgvCitas.Columns["IdCita"] != null)
                {
                    dgvCitas.Columns["IdCita"].HeaderText = "ID";
                    dgvCitas.Columns["IdCita"].FillWeight = 35;
                }
                if (dgvCitas.Columns["FechaHoraTexto"] != null)
                {
                    dgvCitas.Columns["FechaHoraTexto"].HeaderText = "Fecha / Hora";
                    dgvCitas.Columns["FechaHoraTexto"].FillWeight = 110;
                }
                if (dgvCitas.Columns["Paciente"] != null)
                {
                    dgvCitas.Columns["Paciente"].HeaderText = "Paciente";
                    dgvCitas.Columns["Paciente"].FillWeight = 140;
                }
                if (dgvCitas.Columns["Cedula"] != null)
                {
                    dgvCitas.Columns["Cedula"].HeaderText = "Cédula";
                    dgvCitas.Columns["Cedula"].FillWeight = 85;
                }
                if (dgvCitas.Columns["Especialidad"] != null)
                {
                    dgvCitas.Columns["Especialidad"].HeaderText = "Especialidad";
                    dgvCitas.Columns["Especialidad"].FillWeight = 100;
                }
                if (dgvCitas.Columns["Doctor"] != null)
                {
                    dgvCitas.Columns["Doctor"].HeaderText = "Médico";
                    dgvCitas.Columns["Doctor"].FillWeight = 130;
                }
                if (dgvCitas.Columns["Hospital"] != null)
                {
                    dgvCitas.Columns["Hospital"].HeaderText = "Hospital / Sede";
                    dgvCitas.Columns["Hospital"].FillWeight = 110;
                }
                if (dgvCitas.Columns["Estado"] != null)
                {
                    dgvCitas.Columns["Estado"].HeaderText = "Estado";
                    dgvCitas.Columns["Estado"].FillWeight = 75;
                }
                if (dgvCitas.Columns["Motivo"] != null)
                {
                    dgvCitas.Columns["Motivo"].HeaderText = "Motivo";
                    dgvCitas.Columns["Motivo"].FillWeight = 120;
                }

                // Ocultar identificadores técnicos que no deben ser visibles al usuario.
                OcultarColumnaSiExiste("IdPaciente");
                OcultarColumnaSiExiste("IdDoctor");
                OcultarColumnaSiExiste("IdHospital");
                OcultarColumnaSiExiste("IdEspecialidad");
                OcultarColumnaSiExiste("FechaHoraProgramada");

                AgregarColumnasAcciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el listado de citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnaSiExiste(string nombreColumna)
        {
            if (dgvCitas.Columns[nombreColumna] != null)
            {
                dgvCitas.Columns[nombreColumna].Visible = false;
            }
        }

        private void AgregarColumnasAcciones()
        {
            if (!dgvCitas.Columns.Contains("colConfirmar"))
            {
                DataGridViewButtonColumn colConfirmar = new DataGridViewButtonColumn
                {
                    Name = "colConfirmar",
                    HeaderText = "Confirmar",
                    Text = "✓ Confirmar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 75
                };
                dgvCitas.Columns.Add(colConfirmar);
            }

            if (!dgvCitas.Columns.Contains("colEditar"))
            {
                DataGridViewButtonColumn colEditar = new DataGridViewButtonColumn
                {
                    Name = "colEditar",
                    HeaderText = "Editar",
                    Text = "✏️ Editar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 75
                };
                dgvCitas.Columns.Add(colEditar);
            }

            if (!dgvCitas.Columns.Contains("colCancelar"))
            {
                DataGridViewButtonColumn colCancelar = new DataGridViewButtonColumn
                {
                    Name = "colCancelar",
                    HeaderText = "Cancelar",
                    Text = "✕ Cancelar",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 75
                };
                dgvCitas.Columns.Add(colCancelar);
            }

            if (!dgvCitas.Columns.Contains("colNoAsistio"))
            {
                DataGridViewButtonColumn colNoAsistio = new DataGridViewButtonColumn
                {
                    Name = "colNoAsistio",
                    HeaderText = "No Asistió",
                    Text = "⊘ No Asistió",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    FillWeight = 80
                };
                dgvCitas.Columns.Add(colNoAsistio);
            }

            // Ubicar las columnas de acción al final de la tabla.
            dgvCitas.Columns["colConfirmar"].DisplayIndex = dgvCitas.Columns.Count - 4;
            dgvCitas.Columns["colEditar"].DisplayIndex = dgvCitas.Columns.Count - 3;
            dgvCitas.Columns["colCancelar"].DisplayIndex = dgvCitas.Columns.Count - 2;
            dgvCitas.Columns["colNoAsistio"].DisplayIndex = dgvCitas.Columns.Count - 1;
        }

        // ============================================================
        // DIBUJADO PERSONALIZADO DE BOTONES Y ESTADOS
        // ============================================================
        private void dgvCitas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
            string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "";

            // Indicador visual con color temático para la columna Estado.
            if (nombreColumna == "Estado")
            {
                e.PaintBackground(e.CellBounds, true);

                Color colorFondo = Tema.Superficie;
                Color colorTexto = Tema.TextoPrincipal;

                if (estado == "Pendiente")
                {
                    colorFondo = Tema.FondoSecundario;
                    colorTexto = Tema.Advertencia;
                }
                else if (estado == "Confirmada")
                {
                    colorFondo = Tema.FondoSecundario;
                    colorTexto = Tema.VerdeOscuro;
                }
                else if (estado == "Atendida")
                {
                    colorFondo = Tema.FondoSecundario;
                    colorTexto = Tema.AzulPrimario;
                }
                else if (estado == "Cancelada")
                {
                    colorFondo = Tema.Fondo;
                    colorTexto = Tema.ColorError;
                }
                else if (estado == "NoAsistio")
                {
                    colorFondo = Tema.Fondo;
                    colorTexto = Tema.TextoSecundario;
                }

                Rectangle chipRect = new Rectangle(
                    e.CellBounds.X + 4,
                    e.CellBounds.Y + 6,
                    e.CellBounds.Width - 8,
                    e.CellBounds.Height - 12
                );

                using (SolidBrush brushFondo = new SolidBrush(colorFondo))
                {
                    e.Graphics.FillRectangle(brushFondo, chipRect);
                }

                using (Pen penBorde = new Pen(colorTexto))
                {
                    e.Graphics.DrawRectangle(penBorde, chipRect);
                }

                using (Font fuenteEstado = Tema.FuenteLabelCampo)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        estado,
                        fuenteEstado,
                        chipRect,
                        colorTexto,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }

                e.Handled = true;
                return;
            }

            // Dibujado contextual de botones de acción según el estado de la cita.
            if (nombreColumna == "colConfirmar" ||
                nombreColumna == "colEditar" ||
                nombreColumna == "colCancelar" ||
                nombreColumna == "colNoAsistio")
            {
                e.PaintBackground(e.CellBounds, true);

                DateTime fechaProg = DateTime.MaxValue;
                if (dgvCitas.Rows[e.RowIndex].Cells["FechaHoraProgramada"]?.Value is DateTime dtProg)
                {
                    fechaProg = dtProg;
                }
                bool citaYaPaso = fechaProg <= DateTime.Now;

                bool habilitado = false;
                Color colorBoton = Tema.AzulPrimario;
                string textoBoton = "";

                if (nombreColumna == "colConfirmar")
                {
                    habilitado = (estado == "Pendiente");
                    colorBoton = Tema.VerdeOscuro;
                    textoBoton = "✓ Confirmar";
                }
                else if (nombreColumna == "colEditar")
                {
                    habilitado = (estado == "Pendiente" || estado == "Confirmada");
                    colorBoton = Tema.AzulPrimario;
                    textoBoton = "✏️ Editar";
                }
                else if (nombreColumna == "colCancelar")
                {
                    habilitado = (estado == "Pendiente" || estado == "Confirmada");
                    colorBoton = Tema.ColorError;
                    textoBoton = "✕ Cancelar";
                }
                else if (nombreColumna == "colNoAsistio")
                {
                    // Regla de negocio: la acción No Asistió solo está disponible para citas cuya fecha/hora ya pasó.
                    habilitado = (estado == "Pendiente" || estado == "Confirmada") && citaYaPaso;
                    colorBoton = Tema.TextoSecundario;
                    textoBoton = "⊘ No Asistió";
                }

                if (habilitado)
                {
                    Rectangle btnRect = new Rectangle(
                        e.CellBounds.X + 4,
                        e.CellBounds.Y + 4,
                        e.CellBounds.Width - 8,
                        e.CellBounds.Height - 8
                    );

                    using (SolidBrush brush = new SolidBrush(colorBoton))
                    {
                        e.Graphics.FillRectangle(brush, btnRect);
                    }

                    using (Font fuenteBoton = Tema.FuenteBoton)
                    {
                        TextRenderer.DrawText(
                            e.Graphics,
                            textoBoton,
                            fuenteBoton,
                            btnRect,
                            Tema.Superficie,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                        );
                    }
                }

                e.Handled = true;
            }
        }

        // ============================================================
        // CAMBIAR CURSOR AL PASAR POR BOTONES DISPONIBLES
        // ============================================================
        private void dgvCitas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
                string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "";

                DateTime fechaProg = DateTime.MaxValue;
                if (dgvCitas.Rows[e.RowIndex].Cells["FechaHoraProgramada"]?.Value is DateTime dtProg)
                {
                    fechaProg = dtProg;
                }
                bool citaYaPaso = fechaProg <= DateTime.Now;

                bool esBotonAccion =
                    (nombreColumna == "colConfirmar" && estado == "Pendiente") ||
                    (nombreColumna == "colEditar" && (estado == "Pendiente" || estado == "Confirmada")) ||
                    (nombreColumna == "colCancelar" && (estado == "Pendiente" || estado == "Confirmada")) ||
                    (nombreColumna == "colNoAsistio" && (estado == "Pendiente" || estado == "Confirmada") && citaYaPaso);

                dgvCitas.Cursor = esBotonAccion ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                dgvCitas.Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // ACCIONES DE BOTONES EN CADA FILA
        // ============================================================
        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvCitas.Columns[e.ColumnIndex].Name;
            int idCita = Convert.ToInt32(dgvCitas.Rows[e.RowIndex].Cells["IdCita"].Value);
            string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"]?.Value?.ToString() ?? "";
            string paciente = dgvCitas.Rows[e.RowIndex].Cells["Paciente"]?.Value?.ToString() ?? "el paciente";
            string doctor = dgvCitas.Rows[e.RowIndex].Cells["Doctor"]?.Value?.ToString() ?? "el médico";
            string fechaHora = dgvCitas.Rows[e.RowIndex].Cells["FechaHoraTexto"]?.Value?.ToString() ?? "";

            // Acción: CONFIRMAR CITA (Pendiente -> Confirmada)
            if (nombreColumna == "colConfirmar")
            {
                if (estado != "Pendiente")
                {
                    MessageBox.Show("Solo se pueden confirmar citas que se encuentren en estado 'Pendiente'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    $"¿Desea confirmar la cita médica de {paciente} con {doctor} para el {fechaHora}?",
                    "Confirmar Cita",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        controlador.cambiarEstadoCita(idCita, "Confirmada", idDoctorFiltro);
                        MessageBox.Show("La cita ha sido confirmada exitosamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al confirmar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Acción: EDITAR / REPROGRAMAR CITA
            else if (nombreColumna == "colEditar")
            {
                if (estado == "Atendida" || estado == "Cancelada" || estado == "NoAsistio")
                {
                    MessageBox.Show($"No se puede editar ni reprogramar una cita en estado '{estado}'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (crearCita formEditar = new crearCita(idCita, idDoctorFiltro))
                {
                    if (formEditar.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarCitas();
                    }
                }
            }
            // Acción: CANCELAR CITA
            else if (nombreColumna == "colCancelar")
            {
                if (estado != "Pendiente" && estado != "Confirmada")
                {
                    MessageBox.Show($"No se puede cancelar una cita en estado '{estado}'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea cancelar la cita médica de {paciente} con {doctor}?",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        controlador.cambiarEstadoCita(idCita, "Cancelada", idDoctorFiltro);
                        MessageBox.Show("La cita ha sido cancelada correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Acción: MARCAR NO ASISTIÓ
            else if (nombreColumna == "colNoAsistio")
            {
                if (estado != "Pendiente" && estado != "Confirmada")
                {
                    MessageBox.Show($"No se puede registrar inasistencia para una cita en estado '{estado}'.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaProg = DateTime.MaxValue;
                if (dgvCitas.Rows[e.RowIndex].Cells["FechaHoraProgramada"]?.Value is DateTime dtProg)
                {
                    fechaProg = dtProg;
                }

                if (fechaProg > DateTime.Now)
                {
                    MessageBox.Show("No se puede marcar la cita como no asistida hasta que haya pasado la fecha y hora programada.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Confirmar que el paciente {paciente} no se presentó a la cita programada?\n\nEsta acción es definitiva.",
                    "Registrar Inasistencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        controlador.cambiarEstadoCita(idCita, "NoAsistio", idDoctorFiltro);
                        MessageBox.Show("Se ha registrado la inasistencia del paciente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================================
        // EVENTOS DE BÚSQUEDA Y FILTROS
        // ============================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (!chkTodasFechas.Checked)
            {
                CargarCitas();
            }
        }

        private void chkTodasFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaFiltro.Enabled = !chkTodasFechas.Checked;
            CargarCitas();
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        // ============================================================
        // BOTÓN: AGENDAR NUEVA CITA
        // ============================================================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (crearCita formCrear = new crearCita(idDoctorFiltro))
            {
                if (formCrear.ShowDialog(this) == DialogResult.OK)
                {
                    CargarCitas();
                }
            }
        }
    }
}
