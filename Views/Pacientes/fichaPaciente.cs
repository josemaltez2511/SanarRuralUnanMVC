using System;
using System.Drawing;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Pacientes
{
    /// <summary>
    /// Vista de solo lectura para visualizar el expediente completo del paciente,
    /// incluyendo datos personales, ubicación geográfica, salud y contactos de emergencia.
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
        }

        private void ConfigurarControles()
        {
            Tema.ConfigurarTabla(dgvContactos);
            dgvContactos.AutoGenerateColumns = false;
            colParentesco.DataPropertyName = "Parentesco";
            colNombreContacto.DataPropertyName = "NombreCompleto";
            colTelefonoContacto.DataPropertyName = "Telefono";
            colCedulaContacto.DataPropertyName = "Cedula";
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
                    "Expediente #{0} | Cédula: {1}",
                    detalle.IdPaciente,
                    string.IsNullOrWhiteSpace(detalle.Cedula) ? "Sin cédula" : detalle.Cedula);

                if (detalle.Estado)
                {
                    lblEstadoBadge.Text = "✓ ACTIVO";
                    lblEstadoBadge.ForeColor = Tema.VerdeOscuro;
                }
                else
                {
                    lblEstadoBadge.Text = "INACTIVO";
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
    }
}
