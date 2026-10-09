using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Pacientes
{
    // Vista dedicada para que el paciente consulte su ficha personal y actualice sus datos demográficos de contacto.
    // Preserva intactos los datos de identificación legal y antecedentes clínicos.
    public partial class perfilPaciente : Form
    {
        private readonly pacientesControllers controlador = new pacientesControllers();
        private readonly usuariosControllers controladorUsuarios = new usuariosControllers();
        private int idPacienteActual;
        private PacienteDetalleDto datosCargados;
        private BindingList<ContactoEmergenciaDto> listaContactos = new BindingList<ContactoEmergenciaDto>();
        private bool cargandoUbicacion = false;

        public perfilPaciente(int? idPaciente = null)
        {
            if (idPaciente.HasValue && idPaciente.Value > 0)
            {
                this.idPacienteActual = idPaciente.Value;
            }
            else
            {
                int? idDetectado = controladorUsuarios.ObtenerIdPacienteActual();
                this.idPacienteActual = idDetectado ?? 0;
            }

            InitializeComponent();
        }

        private void perfilPaciente_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosVisuales();
            ConfigurarTablaContactos();

            if (cmbContParentesco.Items.Count > 0)
            {
                cmbContParentesco.SelectedIndex = 0;
            }

            if (idPacienteActual <= 0)
            {
                MessageBox.Show(
                    "No se pudo identificar el expediente médico asociado a la sesión actual.",
                    "Perfil no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                pnlAcciones.Enabled = false;
                cardDemograficos.Enabled = false;
                cardEmergencia.Enabled = false;
                return;
            }

            CargarDatosPerfil();
        }

        // ============================================================
        // CONFIGURACIÓN VISUAL Y TEMA
        // ============================================================
        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.Fondo;
            panelScroll.BackColor = Tema.Fondo;
            panelContenido.BackColor = Tema.Fondo;

            cardEncabezado.BackColor = Tema.Superficie;
            cardDatosLegales.BackColor = Tema.Superficie;
            cardDemograficos.BackColor = Tema.Superficie;
            cardEmergencia.BackColor = Tema.Superficie;

            cardEncabezado.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardEncabezado.Width - 1, cardEncabezado.Height - 1), Tema.Superficie, Tema.Borde, 8);
            cardDatosLegales.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardDatosLegales.Width - 1, cardDatosLegales.Height - 1), Tema.Superficie, Tema.Borde, 8);
            cardDemograficos.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardDemograficos.Width - 1, cardDemograficos.Height - 1), Tema.Superficie, Tema.Borde, 8);
            cardEmergencia.Paint += (s, ev) => Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardEmergencia.Width - 1, cardEmergencia.Height - 1), Tema.Superficie, Tema.Borde, 8);

            lblAvatar.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(235, 248, 238)))
                {
                    ev.Graphics.FillEllipse(brush, 1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
                }
                using (var pen = new Pen(Color.FromArgb(207, 235, 214), 1.5f))
                {
                    ev.Graphics.DrawEllipse(pen, 1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
                }
            };
            lblAvatar.ForeColor = Tema.VerdeOscuro;

            lblBadgeRol.BackColor = Color.FromArgb(235, 248, 238);
            lblBadgeRol.ForeColor = Tema.VerdeOscuro;
            lblBadgeRol.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, lblBadgeRol.Width - 1, lblBadgeRol.Height - 1), Color.FromArgb(235, 248, 238), Color.FromArgb(207, 235, 214), 6);
            };

            lblTituloCardLegales.ForeColor = Tema.AzulPrimario;
            lblTituloCardDemograficos.ForeColor = Tema.AzulPrimario;
            lblTituloCardEmergencia.ForeColor = Tema.AzulPrimario;

            lblCedulaEtiqueta.ForeColor = Tema.TextoSecundario;
            lblINSSEtiqueta.ForeColor = Tema.TextoSecundario;
            lblNacimientoEtiqueta.ForeColor = Tema.TextoSecundario;
            lblGeneroEtiqueta.ForeColor = Tema.TextoSecundario;
            lblTipoSangreEtiqueta.ForeColor = Tema.TextoSecundario;
            lblAlergiasEtiqueta.ForeColor = Tema.TextoSecundario;
            lblAntecedentesEtiqueta.ForeColor = Tema.TextoSecundario;

            btnGuardar.BackColor = Tema.AzulPrimario;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;

            btnRestablecer.BackColor = Tema.FondoSecundario;
            btnRestablecer.ForeColor = Tema.AzulOscuro;
            btnRestablecer.FlatAppearance.BorderColor = Tema.Borde;

            btnAgregarContacto.BackColor = Tema.AzulPrimario;
            btnAgregarContacto.ForeColor = Color.White;
            btnAgregarContacto.FlatAppearance.BorderSize = 0;
        }

        private void ConfigurarTablaContactos()
        {
            Tema.ConfigurarTabla(dgvContactos);
            dgvContactos.AutoGenerateColumns = false;
            dgvContactos.Columns.Clear();

            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrimerNombre",
                HeaderText = "Primer Nombre",
                FillWeight = 85
            });

            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrimerApellido",
                HeaderText = "Primer Apellido",
                FillWeight = 85
            });

            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Parentesco",
                HeaderText = "Parentesco",
                FillWeight = 75
            });

            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                FillWeight = 90
            });

            var colQuitar = new DataGridViewButtonColumn
            {
                Name = "colQuitar",
                HeaderText = "Acción",
                Text = "✕ Quitar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 50
            };
            colQuitar.DefaultCellStyle.ForeColor = Tema.Error;
            dgvContactos.Columns.Add(colQuitar);

            dgvContactos.DataSource = listaContactos;
        }

        // ============================================================
        // CARGA DE DATOS DEL PERFIL
        // ============================================================
        private void CargarDatosPerfil()
        {
            try
            {
                datosCargados = controlador.obtenerPacienteDetalle(idPacienteActual);
                if (datosCargados == null)
                {
                    MessageBox.Show("No se encontró la información del expediente del paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Encabezado
                lblNombreCompleto.Text = datosCargados.NombreCompleto;
                lblSubtituloEncabezado.Text = $"Expediente #{datosCargados.IdPaciente} | Comunidad: {datosCargados.Comunidad}";

                string ini1 = !string.IsNullOrWhiteSpace(datosCargados.PrimerNombre) ? datosCargados.PrimerNombre.Substring(0, 1) : "P";
                string ini2 = !string.IsNullOrWhiteSpace(datosCargados.PrimerApellido) ? datosCargados.PrimerApellido.Substring(0, 1) : "A";
                lblAvatar.Text = (ini1 + ini2).ToUpper();

                // Datos legales / clínicos de solo lectura
                lblCedulaValor.Text = !string.IsNullOrWhiteSpace(datosCargados.Cedula) ? datosCargados.Cedula : "No registrada";
                lblINSSValor.Text = !string.IsNullOrWhiteSpace(datosCargados.NumeroINSS) ? datosCargados.NumeroINSS : "No registrado";
                
                int edad = DateTime.Today.Year - datosCargados.FechaNacimiento.Year;
                if (datosCargados.FechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
                lblNacimientoValor.Text = $"{datosCargados.FechaNacimiento:dd/MM/yyyy} ({edad} años)";

                lblGeneroValor.Text = !string.IsNullOrWhiteSpace(datosCargados.Genero) ? datosCargados.Genero : "No especificado";
                lblTipoSangreValor.Text = !string.IsNullOrWhiteSpace(datosCargados.TipoSangre) ? datosCargados.TipoSangre : "No registrado";
                lblAlergiasValor.Text = !string.IsNullOrWhiteSpace(datosCargados.Alergias) ? datosCargados.Alergias : "Ninguna reportada";
                lblAntecedentesValor.Text = !string.IsNullOrWhiteSpace(datosCargados.Antecedentes) ? datosCargados.Antecedentes : "Sin antecedentes patológicos registrados";

                // Datos demográficos editables
                txtTelefono.Text = datosCargados.Telefono ?? string.Empty;
                txtDireccion.Text = datosCargados.Direccion ?? string.Empty;

                CargarDepartamentos(datosCargados.IdDepartamento, datosCargados.IdMunicipio, datosCargados.IdComunidad);

                // Contactos de emergencia
                listaContactos.Clear();
                if (datosCargados.ContactosEmergencia != null)
                {
                    foreach (var c in datosCargados.ContactosEmergencia)
                    {
                        listaContactos.Add(new ContactoEmergenciaDto
                        {
                            IdContactoEmergencia = c.IdContactoEmergencia,
                            IdPaciente = c.IdPaciente,
                            PrimerNombre = c.PrimerNombre,
                            SegundoNombre = c.SegundoNombre,
                            PrimerApellido = c.PrimerApellido,
                            SegundoApellido = c.SegundoApellido,
                            Parentesco = c.Parentesco,
                            Telefono = c.Telefono,
                            Cedula = c.Cedula
                        });
                    }
                }

                lblMensajeEstado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del perfil:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CASCADA GEOGRÁFICA
        // ============================================================
        private void CargarDepartamentos(int? idDeptoSeleccionar = null, int? idMuniSeleccionar = null, int? idComSeleccionar = null)
        {
            try
            {
                cargandoUbicacion = true;
                var departamentos = controlador.listarDepartamentos();
                cmbDepartamento.DataSource = departamentos;
                cmbDepartamento.DisplayMember = "Nombre";
                cmbDepartamento.ValueMember = "Id";

                if (idDeptoSeleccionar.HasValue && idDeptoSeleccionar.Value > 0)
                {
                    cmbDepartamento.SelectedValue = idDeptoSeleccionar.Value;
                    CargarMunicipios(idDeptoSeleccionar.Value, idMuniSeleccionar, idComSeleccionar);
                }
                else
                {
                    cmbDepartamento.SelectedIndex = -1;
                    cmbMunicipio.DataSource = null;
                    cmbComunidad.DataSource = null;
                }
            }
            finally
            {
                cargandoUbicacion = false;
            }
        }

        private void CargarMunicipios(int idDepartamento, int? idMuniSeleccionar = null, int? idComSeleccionar = null)
        {
            try
            {
                cargandoUbicacion = true;
                var municipios = controlador.listarMunicipios(idDepartamento);
                cmbMunicipio.DataSource = municipios;
                cmbMunicipio.DisplayMember = "Nombre";
                cmbMunicipio.ValueMember = "Id";

                if (idMuniSeleccionar.HasValue && idMuniSeleccionar.Value > 0)
                {
                    cmbMunicipio.SelectedValue = idMuniSeleccionar.Value;
                    CargarComunidades(idMuniSeleccionar.Value, idComSeleccionar);
                }
                else
                {
                    cmbMunicipio.SelectedIndex = -1;
                    cmbComunidad.DataSource = null;
                }
            }
            finally
            {
                cargandoUbicacion = false;
            }
        }

        private void CargarComunidades(int idMunicipio, int? idComSeleccionar = null)
        {
            try
            {
                cargandoUbicacion = true;
                var comunidades = controlador.listarComunidades(idMunicipio);
                cmbComunidad.DataSource = comunidades;
                cmbComunidad.DisplayMember = "Nombre";
                cmbComunidad.ValueMember = "Id";

                if (idComSeleccionar.HasValue && idComSeleccionar.Value > 0)
                {
                    cmbComunidad.SelectedValue = idComSeleccionar.Value;
                }
                else
                {
                    cmbComunidad.SelectedIndex = -1;
                }
            }
            finally
            {
                cargandoUbicacion = false;
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion || cmbDepartamento.SelectedValue == null) return;
            if (cmbDepartamento.SelectedValue is int idDepto)
            {
                CargarMunicipios(idDepto);
            }
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoUbicacion || cmbMunicipio.SelectedValue == null) return;
            if (cmbMunicipio.SelectedValue is int idMuni)
            {
                CargarComunidades(idMuni);
            }
        }

        // ============================================================
        // GESTIÓN DE CONTACTOS DE EMERGENCIA
        // ============================================================
        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            string nombre = txtContPrimerNombre.Text.Trim();
            string apellido = txtContPrimerApellido.Text.Trim();
            string parentesco = cmbContParentesco.SelectedItem?.ToString() ?? "";
            string tel = txtContTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Debe especificar el nombre y apellido del contacto de emergencia.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tel))
            {
                MessageBox.Show("Debe especificar el número telefónico del contacto.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listaContactos.Add(new ContactoEmergenciaDto
            {
                IdPaciente = idPacienteActual,
                PrimerNombre = nombre,
                PrimerApellido = apellido,
                Parentesco = parentesco,
                Telefono = tel
            });

            txtContPrimerNombre.Clear();
            txtContPrimerApellido.Clear();
            txtContTelefono.Clear();
            txtContPrimerNombre.Focus();
        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvContactos.Columns[e.ColumnIndex].Name == "colQuitar")
            {
                if (e.RowIndex < listaContactos.Count)
                {
                    listaContactos.RemoveAt(e.RowIndex);
                }
            }
        }

        // ============================================================
        // GUARDADO DE CAMBIOS DEMOGRÁFICOS
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbComunidad.SelectedValue == null || !(cmbComunidad.SelectedValue is int))
            {
                MessageBox.Show("Debe seleccionar una comunidad de residencia válida.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbComunidad.Focus();
                return;
            }

            int idComunidad = (int)cmbComunidad.SelectedValue;
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (telefono.Length > 30)
            {
                MessageBox.Show("El teléfono no puede exceder los 30 caracteres.", "Longitud Excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (direccion.Length > 300)
            {
                MessageBox.Show("La dirección no puede exceder los 300 caracteres.", "Longitud Excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            try
            {
                var listaFinal = listaContactos.ToList();
                bool exito = controlador.editarPerfilDemograficoPaciente(
                    idPacienteActual,
                    telefono,
                    idComunidad,
                    direccion,
                    listaFinal
                );

                if (exito)
                {
                    MessageBox.Show(
                        "Sus datos de contacto y residencia han sido actualizados exitosamente.",
                        "Perfil Actualizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    CargarDatosPerfil();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del perfil:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            CargarDatosPerfil();
        }
    }
}
