using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    public partial class crearDoctor : Form
    {
        // ============================================================
        // CONTROLLERS
        // ============================================================
        // La Vista nunca accede directamente a la base de datos.
        private readonly doctoresControllers controladorDoctores = new doctoresControllers();

        // ============================================================
        // PROPIEDADES DE ESTADO
        // ============================================================
        private int? idUsuario;
        private int idDoctorEdicion;
        private bool esModoEdicion;
        private bool formularioConfigurado;
        private byte[] foto;
        private string fotoNombre;
        private string fotoMimeType;
        private bool fotoEliminadaExplicita;

        private TextBox txtPrimerNombre;
        private TextBox txtSegundoNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private TextBox txtCedula;
        private TextBox txtTelefono;
        private TextBox txtLicencia;
        private CheckedListBox lstEspecialidades;
        private ComboBox cmbHospitalAsignacion;
        private ComboBox cmbEspecialidadHospital;
        private ListBox lstAsignaciones;
        private Label lblFoto;
        private Button btnSeleccionarFoto;
        private Button btnQuitarFoto;
        private PictureBox picPreview;
        private Button btnAgregarAsignacion;
        private Button btnQuitarAsignacion;
        private readonly List<Tuple<int, int>> asignaciones = new List<Tuple<int, int>>();
        private List<Especialidades> especialidadesDisponibles = new List<Especialidades>();
        private List<SanarRuralUnan.Hospitales> hospitalesDisponibles = new List<SanarRuralUnan.Hospitales>();

        // ============================================================
        // CONSTRUCTORES
        // ============================================================
        // Permite registrar un doctor sin una cuenta de usuario.
        // Constructor para registro nuevo sin cuenta de usuario.
        public crearDoctor()
        {
            InitializeComponent();
        }

        public crearDoctor(int idUsuarioRecibido)
        {
            InitializeComponent();
            // Conserva la cuenta creada en el paso anterior del registro.
            idUsuario = idUsuarioRecibido > 0 ? idUsuarioRecibido : (int?)null;
        }

        public crearDoctor(int idDoctor, bool modoEdicion)
        {
            InitializeComponent();
            idDoctorEdicion = idDoctor;
            esModoEdicion = modoEdicion;
        }

        // ============================================================
        // LOAD
        // ============================================================
        private void crearDoctor_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            try
            {
                CargarCatalogos();

                if (esModoEdicion)
                {
                    lblSubtitulo.Text = "Modificar Datos del Doctor";
                    btnGuardar.Text = "Guardar Cambios";
                    CargarDoctor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible cargar los datos del doctor.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                btnGuardar.Enabled = false;
            }
        }

        // ============================================================
        // CONFIGURAR FORMULARIO
        // ============================================================
        private void ConfigurarFormulario()
        {
            if (formularioConfigurado)
            {
                return;
            }

            formularioConfigurado = true;
            panelCard.Controls.Clear();
            panelCard.AutoScroll = true;
            panelCard.AutoScrollMinSize = Size.Empty;

            panelCard.Controls.Add(panelLineaVerde);
            panelCard.Controls.Add(lblTitulo);
            panelCard.Controls.Add(lblSubtitulo);

            lblTitulo.Location = new Point(58, 20);
            lblSubtitulo.Location = new Point(61, 56);

            txtPrimerNombre = AgregarCampo("Primer nombre *", 45, 105, 500, 1);
            txtSegundoNombre = AgregarCampo("Segundo nombre", 590, 105, 500, 2);
            txtPrimerApellido = AgregarCampo("Primer apellido *", 45, 180, 500, 3);
            txtSegundoApellido = AgregarCampo("Segundo apellido", 590, 180, 500, 4);
            txtCedula = AgregarCampo("Cédula *", 45, 255, 500, 5);
            txtTelefono = AgregarCampo("Teléfono", 590, 255, 500, 6);
            txtLicencia = AgregarCampo("Número de licencia *", 45, 330, 500, 7);
            txtPrimerNombre.MaxLength = 50;
            txtSegundoNombre.MaxLength = 50;
            txtPrimerApellido.MaxLength = 50;
            txtSegundoApellido.MaxLength = 50;
            txtCedula.MaxLength = 20;
            txtTelefono.MaxLength = 30;
            txtLicencia.MaxLength = 50;

            // Vista previa de la foto del doctor
            AgregarEtiqueta("Foto del doctor", 590, 330);
            picPreview = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Tema.FondoSecundario,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(590, 355),
                Size = new Size(130, 130),
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = "photoPreview",
                AccessibleName = "Vista previa de la foto del doctor"
            };
            panelCard.Controls.Add(picPreview);

            lblFoto = new Label
            {
                AutoEllipsis = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = Tema.FuenteAyuda,
                ForeColor = Tema.TextoSecundario,
                Location = new Point(730, 360),
                Size = new Size(360, 20),
                Tag = "photoLabel",
                Text = "Sin foto seleccionada",
                TextAlign = ContentAlignment.MiddleLeft
            };
            panelCard.Controls.Add(lblFoto);

            btnSeleccionarFoto = CrearBoton("Seleccionar foto", 730, 385, 140, 32);
            btnSeleccionarFoto.Tag = "photoButton";
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            panelCard.Controls.Add(btnSeleccionarFoto);

            btnQuitarFoto = CrearBoton("Quitar foto", 730, 425, 140, 32);
            btnQuitarFoto.Tag = "photoRemoveButton";
            btnQuitarFoto.BackColor = Tema.Error;
            btnQuitarFoto.Visible = false;
            btnQuitarFoto.Click += btnQuitarFoto_Click;
            panelCard.Controls.Add(btnQuitarFoto);

            // Especialidades y asignaciones hospitalarias
            AgregarEtiqueta("Especialidades * (puede elegir varias)", 45, 515);
            lstEspecialidades = new CheckedListBox
            {
                CheckOnClick = true,
                Font = Tema.FuenteCuerpo,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(45, 540),
                Size = new Size(420, 230),
                Tag = "specialties"
            };
            panelCard.Controls.Add(lstEspecialidades);

            AgregarEtiqueta("Hospital", 500, 515);
            AgregarEtiqueta("Especialidad que ejerce allí", 790, 515);
            cmbHospitalAsignacion = CrearCombo(500, 540, 270, 32);
            cmbHospitalAsignacion.Tag = "assignHospital";
            cmbEspecialidadHospital = CrearCombo(790, 540, 300, 32);
            cmbEspecialidadHospital.Tag = "assignSpecialty";
            panelCard.Controls.Add(cmbHospitalAsignacion);
            panelCard.Controls.Add(cmbEspecialidadHospital);

            btnAgregarAsignacion = CrearBoton("Agregar", 500, 585, 115, 34);
            btnAgregarAsignacion.Tag = "addAssignment";
            btnAgregarAsignacion.Click += btnAgregarAsignacion_Click;
            panelCard.Controls.Add(btnAgregarAsignacion);

            AgregarEtiqueta("Hospitales y especialidades asignados", 500, 630);
            lstAsignaciones = new ListBox
            {
                Font = Tema.FuenteCuerpo,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(500, 655),
                Size = new Size(590, 115),
                Tag = "assignments"
            };
            panelCard.Controls.Add(lstAsignaciones);

            btnQuitarAsignacion = CrearBoton("Quitar seleccionado", 500, 780, 180, 34);
            btnQuitarAsignacion.Tag = "removeAssignment";
            btnQuitarAsignacion.Click += btnQuitarAsignacion_Click;
            panelCard.Controls.Add(btnQuitarAsignacion);

            btnGuardar.Location = new Point(45, 840);
            btnGuardar.Size = new Size(1045, 42);
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Doctor";
            panelCard.Controls.Add(btnGuardar);

            lnkVolver.Location = new Point(490, 900);
            lnkVolver.Tag = "back";
            lnkVolver.Text = "Completar después / Volver";
            panelCard.Controls.Add(lnkVolver);

            panelCard.Resize += panelCard_Resize;
            AjustarLayoutDoctor();
        }

        private TextBox AgregarCampo(string texto, int x, int y, int ancho, int tabIndex)
        {
            AgregarEtiqueta(texto, x, y);
            var campo = new TextBox
            {
                Font = Tema.FuenteInput,
                Anchor = x < 500 ? AnchorStyles.Top | AnchorStyles.Left : AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(x, y + 25),
                Size = new Size(ancho, 30),
                Tag = x < 500 ? "leftField" : "rightField",
                TabIndex = tabIndex,
                AccessibleName = texto,
                AccessibleDescription = "Ingrese " + texto.TrimEnd('*', ' ')
            };
            panelCard.Controls.Add(campo);
            return campo;
        }

        private void AgregarEtiqueta(string texto, int x, int y)
        {
            panelCard.Controls.Add(new Label
            {
                AutoSize = true,
                Anchor = x < 500 ? AnchorStyles.Top | AnchorStyles.Left : AnchorStyles.Top | AnchorStyles.Right,
                Font = Tema.FuenteLabelCampo,
                Location = new Point(x, y),
                Tag = x,
                Text = texto
            });
        }

        private ComboBox CrearCombo(int x, int y, int ancho, int alto)
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = Tema.FuenteCuerpo,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AccessibleName = x < 700 ? "Hospital" : "Especialidad que ejerce en el hospital",
                Location = new Point(x, y),
                Size = new Size(ancho, alto)
            };
        }

        private Button CrearBoton(string texto, int x, int y, int ancho, int alto)
        {
            return new Button
            {
                BackColor = Tema.AzulPrimario,
                Anchor = x < 500 ? AnchorStyles.Top | AnchorStyles.Left : AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = Tema.FuenteBoton,
                ForeColor = Tema.Superficie,
                Location = new Point(x, y),
                Size = new Size(ancho, alto),
                Text = texto,
                UseVisualStyleBackColor = false
            };
        }

        private void panelCard_Resize(object sender, EventArgs e)
        {
            AjustarLayoutDoctor();
        }

        private void AjustarLayoutDoctor()
        {
            int margen = 28;
            int espacio = 24;
            int anchoContenido = Math.Max(0, panelCard.ClientSize.Width - margen * 2);
            int anchoColumna = Math.Max(0, (anchoContenido - espacio) / 2);
            int xDerecha = margen + anchoColumna + espacio;
            int anchoMitad = Math.Max(0, (anchoColumna - 16) / 2);

            foreach (Control control in panelCard.Controls)
            {
                if (control.Tag is int xEtiqueta)
                {
                    int x = xEtiqueta < 500 ? margen : xDerecha;
                    if (xEtiqueta == 790)
                        x = xDerecha + anchoMitad + 16;
                    control.Location = new Point(x, control.Top);
                    continue;
                }

                switch (control.Tag as string)
                {
                    case "leftField":
                        control.Location = new Point(margen, control.Top);
                        control.Width = anchoColumna;
                        break;
                    case "rightField":
                        control.Location = new Point(xDerecha, control.Top);
                        control.Width = anchoColumna;
                        break;
                    case "photoPreview":
                        control.Location = new Point(xDerecha, control.Top);
                        break;
                    case "photoLabel":
                        control.Location = new Point(xDerecha + 140, control.Top);
                        control.Width = Math.Max(80, anchoColumna - 155);
                        break;
                    case "photoButton":
                    case "photoRemoveButton":
                        control.Location = new Point(xDerecha + 140, control.Top);
                        break;
                    case "specialties":
                        control.Location = new Point(margen, control.Top);
                        control.Width = anchoColumna;
                        break;
                    case "assignHospital":
                        control.Location = new Point(xDerecha, control.Top);
                        control.Width = anchoMitad;
                        break;
                    case "assignSpecialty":
                        control.Location = new Point(xDerecha + anchoMitad + 16, control.Top);
                        control.Width = anchoMitad;
                        break;
                    case "addAssignment":
                    case "removeAssignment":
                        control.Location = new Point(xDerecha, control.Top);
                        break;
                    case "assignments":
                        control.Location = new Point(xDerecha, control.Top);
                        control.Width = anchoColumna;
                        break;
                    case "back":
                        control.Location = new Point(Math.Max(margen, (panelCard.ClientSize.Width - control.Width) / 2), control.Top);
                        break;
                }
            }

            btnGuardar.Location = new Point(margen, btnGuardar.Top);
            btnGuardar.Width = anchoContenido;
        }

        // ============================================================
        // CARGAR ESPECIALIDADES Y HOSPITALES
        // ============================================================
        private void CargarCatalogos()
        {
            especialidadesDisponibles = controladorDoctores.listarEspecialidades();
            hospitalesDisponibles = controladorDoctores.listarHospitales();

            lstEspecialidades.DataSource = especialidadesDisponibles;
            lstEspecialidades.DisplayMember = "Nombre";
            lstEspecialidades.ValueMember = "IdEspecialidad";

            cmbHospitalAsignacion.DataSource = hospitalesDisponibles;
            cmbHospitalAsignacion.DisplayMember = "Nombre";
            cmbHospitalAsignacion.ValueMember = "IdHospital";
            cmbHospitalAsignacion.SelectedIndex = -1;

            cmbEspecialidadHospital.DataSource = especialidadesDisponibles.ToList();
            cmbEspecialidadHospital.DisplayMember = "Nombre";
            cmbEspecialidadHospital.ValueMember = "IdEspecialidad";
            cmbEspecialidadHospital.SelectedIndex = -1;
        }

        // ============================================================
        // CARGAR DATOS DEL DOCTOR
        // ============================================================
        private void CargarDoctor()
        {
            var doctor = controladorDoctores.consultarDoctorPorId(idDoctorEdicion);
            if (doctor == null)
            {
                MessageBox.Show("No se encontró el doctor seleccionado.", "Doctor no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtPrimerNombre.Text = doctor.PrimerNombre;
            txtSegundoNombre.Text = doctor.SegundoNombre;
            txtPrimerApellido.Text = doctor.PrimerApellido;
            txtSegundoApellido.Text = doctor.SegundoApellido;
            txtCedula.Text = doctor.Cedula;
            txtTelefono.Text = doctor.Telefono;
            txtLicencia.Text = doctor.NumeroLicencia;

            foreach (var doctorEspecialidad in doctor.DoctorEspecialidad)
            {
                int indice = especialidadesDisponibles.FindIndex(e => e.IdEspecialidad == doctorEspecialidad.IdEspecialidad);
                if (indice >= 0)
                {
                    lstEspecialidades.SetItemChecked(indice, true);
                }

                foreach (var asignacion in doctorEspecialidad.DoctorHospitalEspecialidad)
                {
                    AgregarAsignacion(asignacion.IdHospital, asignacion.IdEspecialidad);
                }
            }

            foto = doctor.Foto;
            fotoNombre = doctor.FotoNombre;
            fotoMimeType = doctor.FotoMimeType;

            if (foto != null && foto.Length > 0)
            {
                MostrarPreviewDesdeBytes(foto);
                lblFoto.Text = fotoNombre ?? "Foto cargada";
                btnQuitarFoto.Visible = true;
            }
            else
            {
                lblFoto.Text = "Sin foto seleccionada";
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (var selector = new OpenFileDialog())
            {
                selector.Title = "Seleccionar foto del doctor";
                selector.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (selector.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Se leen los bytes directamente para no retener bloqueos sobre el archivo original.
                byte[] bytesArchivo;
                try
                {
                    bytesArchivo = File.ReadAllBytes(selector.FileName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        "No se pudo leer el archivo seleccionado.\n\n" + ex.Message,
                        "Error de lectura",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Validar que el archivo corresponda a una imagen legible.
                Image imagenCargada;
                try
                {
                    using (var stream = new MemoryStream(bytesArchivo))
                    {
                        // Se crea una copia en un nuevo Bitmap para gestionar independientemente el ciclo de vida.
                        using (var temporal = Image.FromStream(stream))
                        {
                            imagenCargada = new Bitmap(temporal);
                        }
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(
                        "El archivo seleccionado no es una imagen válida.\nFormatos permitidos: JPG, PNG, BMP.",
                        "Imagen no válida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Liberar la imagen anterior para evitar fugas de memoria en GDI+.
                LimpiarPreview();

                foto = bytesArchivo;
                fotoNombre = Path.GetFileName(selector.FileName);
                fotoMimeType = GetMimeType(selector.FileName);
                fotoEliminadaExplicita = false;

                picPreview.Image = imagenCargada;
                lblFoto.Text = fotoNombre;
                btnQuitarFoto.Visible = true;
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            LimpiarPreview();
            foto = null;
            fotoNombre = null;
            fotoMimeType = null;
            fotoEliminadaExplicita = true;
            lblFoto.Text = "Sin foto seleccionada";
            btnQuitarFoto.Visible = false;
        }

        // ============================================================
        // MÉTODOS DE VISTA PREVIA DE FOTO
        // ============================================================
        // Genera un Bitmap a partir del arreglo de bytes y lo asigna al PictureBox.
        private void MostrarPreviewDesdeBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return;
            }

            try
            {
                Image imagenNueva;
                using (var stream = new MemoryStream(bytes))
                {
                    using (var temporal = Image.FromStream(stream))
                    {
                        imagenNueva = new Bitmap(temporal);
                    }
                }

                LimpiarPreview();
                picPreview.Image = imagenNueva;
            }
            catch (ArgumentException)
            {
                // Si los bytes almacenados no forman una imagen válida, se deja la vista previa vacía.
            }
        }

        // Libera la imagen actual del PictureBox para gestionar adecuadamente los recursos GDI+.
        private void LimpiarPreview()
        {
            if (picPreview.Image != null)
            {
                var imagenAnterior = picPreview.Image;
                picPreview.Image = null;
                imagenAnterior.Dispose();
            }
        }

        private string GetMimeType(string ruta)
        {
            switch (Path.GetExtension(ruta).ToLowerInvariant())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream";
            }
        }

        private void btnAgregarAsignacion_Click(object sender, EventArgs e)
        {
            if (cmbHospitalAsignacion.SelectedValue == null || cmbEspecialidadHospital.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un hospital y una especialidad.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspecialidad = Convert.ToInt32(cmbEspecialidadHospital.SelectedValue);
            bool especialidadSeleccionada = lstEspecialidades.CheckedItems
                .Cast<Especialidades>()
                .Any(especialidad => especialidad.IdEspecialidad == idEspecialidad);

            if (!especialidadSeleccionada)
            {
                MessageBox.Show("Marque primero esa especialidad en la lista del doctor.", "Especialidad no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarAsignacion(Convert.ToInt32(cmbHospitalAsignacion.SelectedValue), idEspecialidad);
        }

        private void AgregarAsignacion(int idHospital, int idEspecialidad)
        {
            if (asignaciones.Any(a => a.Item1 == idHospital && a.Item2 == idEspecialidad))
            {
                return;
            }

            asignaciones.Add(Tuple.Create(idHospital, idEspecialidad));
            lstAsignaciones.Items.Add(FormatearAsignacion(idHospital, idEspecialidad));
        }

        private string FormatearAsignacion(int idHospital, int idEspecialidad)
        {
            string hospital = hospitalesDisponibles.FirstOrDefault(h => h.IdHospital == idHospital)?.Nombre ?? "Hospital";
            string especialidad = especialidadesDisponibles.FirstOrDefault(e => e.IdEspecialidad == idEspecialidad)?.Nombre ?? "Especialidad";
            return hospital + " — " + especialidad;
        }

        private void btnQuitarAsignacion_Click(object sender, EventArgs e)
        {
            int indice = lstAsignaciones.SelectedIndex;
            if (indice >= 0)
            {
                asignaciones.RemoveAt(indice);
                lstAsignaciones.Items.RemoveAt(indice);
            }
        }

        // ============================================================
        // GUARDAR / EDITAR DOCTOR
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de campos obligatorios.
            string primerNombre = txtPrimerNombre.Text.Trim();
            string primerApellido = txtPrimerApellido.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string numeroLicencia = txtLicencia.Text.Trim();
            var idEspecialidades = lstEspecialidades.CheckedItems
                .Cast<Especialidades>()
                .Select(especialidad => especialidad.IdEspecialidad)
                .ToList();
            var asignacionesSeleccionadas = asignaciones
                .Where(asignacion => idEspecialidades.Contains(asignacion.Item2))
                .ToList();

            if (string.IsNullOrWhiteSpace(primerNombre) || string.IsNullOrWhiteSpace(primerApellido) ||
                string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(numeroLicencia))
            {
                MessageBox.Show("Complete primer nombre, primer apellido, cédula y número de licencia.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idEspecialidades.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una especialidad para el doctor.", "Especialidad requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (asignacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("Asigne el doctor al menos a un hospital.", "Hospital requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (controladorDoctores.existeCedula(cedula, esModoEdicion ? (int?)idDoctorEdicion : null))
            {
                MessageBox.Show("Ya existe un doctor registrado con el número de cédula ingresado.", "Cédula duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            if (controladorDoctores.existeNumeroLicencia(numeroLicencia, esModoEdicion ? (int?)idDoctorEdicion : null))
            {
                MessageBox.Show("Ya existe un doctor registrado con el número de licencia médica ingresado.", "Licencia duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicencia.Focus();
                return;
            }

            try
            {
                if (esModoEdicion)
                {
                    // MODO EDICIÓN
                    controladorDoctores.editarDoctor(
                        idDoctorEdicion,
                        primerNombre,
                        txtSegundoNombre.Text.Trim(),
                        primerApellido,
                        txtSegundoApellido.Text.Trim(),
                        cedula,
                        numeroLicencia,
                        txtTelefono.Text.Trim(),
                        foto,
                        fotoNombre,
                        fotoMimeType,
                        fotoEliminadaExplicita,
                        idEspecialidades,
                        asignacionesSeleccionadas
                    );
                }
                else
                {
                    // MODO CREACIÓN
                    controladorDoctores.crearDoctor(
                        idUsuario,
                        primerNombre,
                        txtSegundoNombre.Text.Trim(),
                        primerApellido,
                        txtSegundoApellido.Text.Trim(),
                        cedula,
                        numeroLicencia,
                        txtTelefono.Text.Trim(),
                        foto,
                        fotoNombre,
                        fotoMimeType,
                        idEspecialidades,
                        asignacionesSeleccionadas
                    );
                }

                MessageBox.Show(
                    esModoEdicion ? "¡Doctor modificado con éxito!" : "¡Doctor registrado con éxito!",
                    esModoEdicion ? "Registro Actualizado" : "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // No mostrar detalles técnicos de base de datos al usuario final.
                System.Diagnostics.Debug.WriteLine("Error al guardar doctor: " + ex);
                MessageBox.Show(
                    "Ocurrió un error al procesar el guardado del doctor. Por favor, intente nuevamente o contacte al administrador si el problema persiste.",
                    "Error al Guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // VOLVER / CANCELAR
        // ============================================================
        private void lnkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
