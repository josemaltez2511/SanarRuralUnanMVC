using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Pacientes
{
    /// <summary>
    /// Vista de detalle integral para la visualización del expediente clínico del paciente,
    /// estructurada en tarjetas claras de datos personales, ubicación, salud y contactos de emergencia.
    /// </summary>
    public partial class fichaPaciente : Form
    {
        private readonly int idPaciente;
        private readonly pacientesControllers controlador = new pacientesControllers();

        public fichaPaciente(int idPaciente)
        {
            this.idPaciente = idPaciente;
            InitializeComponent();
        }

        private void fichaPaciente_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarDetalle();
            AjustarLayoutTarjetas();
        }

        private void ConfigurarControles()
        {
            Tema.ConfigurarTabla(dgvContactos);
            dgvContactos.AutoGenerateColumns = false;
            dgvContactos.RowTemplate.Height = 36;
            dgvContactos.ColumnHeadersHeight = 36;

            colParentesco.DataPropertyName = "Parentesco";
            colNombreContacto.DataPropertyName = "NombreCompleto";
            colTelefonoContacto.DataPropertyName = "Telefono";
            colCedulaContacto.DataPropertyName = "Cedula";

            colParentesco.FillWeight = 80;
            colNombreContacto.FillWeight = 160;
            colTelefonoContacto.FillWeight = 85;
            colCedulaContacto.FillWeight = 85;

            panelDatos.Paint += DibujarBordeCard;
            panelUbicacion.Paint += DibujarBordeCard;
            panelSalud.Paint += DibujarBordeCard;
            panelContactos.Paint += DibujarBordeCard;
            panelBadgeEstado.Paint += DibujarBordeCard;

            btnCerrarTop.Click += (s, ev) => { DialogResult = DialogResult.OK; Close(); };
            btnCerrar.Click += (s, ev) => { DialogResult = DialogResult.OK; Close(); };
        }

        private void DibujarBordeCard(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                using (var pen = new Pen(Tema.Borde, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
                }
            }
        }

        private void AjustarLayoutTarjetas()
        {
            if (panelContenido.ClientSize.Width <= 0)
                return;

            int margen = 20;
            int anchoDisponible = Math.Max(400, panelContenido.ClientSize.Width - (margen * 2));

            panelDatos.Left = margen;
            panelDatos.Width = anchoDisponible;

            panelUbicacion.Left = margen;
            panelUbicacion.Width = anchoDisponible;

            panelSalud.Left = margen;
            panelSalud.Width = anchoDisponible;

            panelContactos.Left = margen;
            panelContactos.Width = anchoDisponible;

            panelPie.Left = margen;
            panelPie.Width = anchoDisponible;

            // Ajuste estricto del contenedor de la tabla para que quede perfectamente dentro de panelContactos
            panelTablaContactos.Left = 20;
            panelTablaContactos.Width = Math.Max(200, panelContactos.ClientSize.Width - 40);

            // Ajuste del botón en el pie para alinearse a la derecha de las tarjetas
            btnCerrar.Left = Math.Max(0, panelPie.ClientSize.Width - btnCerrar.Width);

            // Ajuste del encabezado superior para que el badge y el botón cerrar se alineen a la derecha
            if (panelEncabezado.ClientSize.Width > 0)
            {
                btnCerrarTop.Left = Math.Max(300, panelEncabezado.ClientSize.Width - btnCerrarTop.Width - 24);
                panelBadgeEstado.Left = Math.Max(150, btnCerrarTop.Left - panelBadgeEstado.Width - 16);
            }

            // Ajuste responsivo de columnas dentro de panelDatos
            int col2 = Math.Max(260, anchoDisponible / 2);
            lblNacimientoT.Left = col2;
            lblNacimientoVal.Left = col2;
            lblGeneroT.Left = col2;
            lblGeneroVal.Left = col2;

            int colTel = Math.Min(anchoDisponible - 180, col2 + 220);
            if (colTel > col2 + 80)
            {
                lblTelefonoT.Left = colTel;
                lblTelefonoVal.Left = colTel;
            }

            // Ajuste de columnas en panelUbicacion
            lblComunidadT.Left = col2;
            lblComunidadVal.Left = col2;

            // Ajuste de antecedentes en panelSalud
            lblAntecedentesT.Left = col2;
            lblAntecedentesVal.Left = col2;
            lblAntecedentesVal.Width = Math.Max(200, anchoDisponible - col2 - 30);
        }

        private void CargarDetalle()
        {
            try
            {
                PacienteDetalleDto detalle = controlador.obtenerPacienteDetalle(idPaciente);
                if (detalle == null)
                {
                    MessageBox.Show(
                        "No se encontró el paciente solicitado o no tiene permisos para consultarlo.",
                        "Expediente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                // Encabezado
                lblTitulo.Text = detalle.NombreCompleto;
                lblSubtitulo.Text = string.Format(
                    "Expediente #{0}  •  Cédula: {1}  •  Sanar Rural",
                    detalle.IdPaciente,
                    string.IsNullOrWhiteSpace(detalle.Cedula) ? "Sin cédula registrada" : detalle.Cedula);

                if (detalle.Estado)
                {
                    lblEstadoBadge.Text = "● ACTIVO";
                    lblEstadoBadge.ForeColor = Tema.VerdeOscuro;
                }
                else
                {
                    lblEstadoBadge.Text = "○ INACTIVO";
                    lblEstadoBadge.ForeColor = Tema.Error;
                }

                // Datos personales
                lblNombreVal.Text = detalle.NombreCompleto;
                lblCedulaVal.Text = string.IsNullOrWhiteSpace(detalle.Cedula) ? "No registrada" : detalle.Cedula;
                lblInssVal.Text = string.IsNullOrWhiteSpace(detalle.NumeroINSS) ? "No registrado" : detalle.NumeroINSS;
                lblNacimientoVal.Text = string.Format("{0:dd/MM/yyyy} ({1} años)", detalle.FechaNacimiento, detalle.Edad);
                lblGeneroVal.Text = string.IsNullOrWhiteSpace(detalle.Genero) ? "No especificado" : detalle.Genero;
                lblTelefonoVal.Text = string.IsNullOrWhiteSpace(detalle.Telefono) ? "No registrado" : detalle.Telefono;

                // Ubicación
                lblDeptoVal.Text = string.IsNullOrWhiteSpace(detalle.Departamento) ? "-" : detalle.Departamento;
                lblMuniVal.Text = string.IsNullOrWhiteSpace(detalle.Municipio) ? "-" : detalle.Municipio;
                lblComunidadVal.Text = string.IsNullOrWhiteSpace(detalle.Comunidad) ? "-" : detalle.Comunidad;
                lblDireccionVal.Text = string.IsNullOrWhiteSpace(detalle.Direccion) ? "Sin dirección específica" : detalle.Direccion;

                // Registro de salud
                lblSangreVal.Text = string.IsNullOrWhiteSpace(detalle.TipoSangre) ? "No especificado" : detalle.TipoSangre;
                lblAlergiasVal.Text = string.IsNullOrWhiteSpace(detalle.Alergias) ? "Ninguna conocida" : detalle.Alergias;
                lblAntecedentesVal.Text = string.IsNullOrWhiteSpace(detalle.Antecedentes) ? "Ninguno registrado" : detalle.Antecedentes;

                // Contactos de emergencia
                if (detalle.ContactosEmergencia != null && detalle.ContactosEmergencia.Count > 0)
                {
                    dgvContactos.DataSource = detalle.ContactosEmergencia;
                    dgvContactos.Visible = true;
                    lblSinContactos.Visible = false;
                }
                else
                {
                    dgvContactos.DataSource = null;
                    dgvContactos.Visible = false;
                    lblSinContactos.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar la ficha del paciente:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void fichaPaciente_Resize(object sender, EventArgs e)
        {
            AjustarLayoutTarjetas();
        }
    }
}
