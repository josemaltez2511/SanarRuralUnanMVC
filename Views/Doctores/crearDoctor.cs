using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Views.Doctores;

namespace SanarRuralUnan.Views
{
    public partial class crearDoctor : Form
    {
        // ============================================================
        // CONTROLADORES Y ESTADO DE NEGOCIO
        // ============================================================
        private readonly doctoresControllers controladorDoctores = new doctoresControllers();
        private int? idUsuario;
        private int idDoctorEdicion;
        private bool esModoEdicion;
        private byte[] foto;
        private string fotoNombre;
        private string fotoMimeType;
        private bool fotoEliminadaExplicita;

        private readonly List<Tuple<int, int>> asignaciones = new List<Tuple<int, int>>();
        private List<Especialidades> especialidadesDisponibles = new List<Especialidades>();
        private List<SanarRuralUnan.Hospitales> hospitalesDisponibles = new List<SanarRuralUnan.Hospitales>();

        // ============================================================
        // CONSTRUCTORES
        // ============================================================
        public crearDoctor()
        {
            InitializeComponent();
            ConfigurarOptimizacionesVisuales();
        }

        public crearDoctor(int idUsuarioRecibido) : this()
        {
            idUsuario = idUsuarioRecibido > 0 ? idUsuarioRecibido : (int?)null;
        }

        public crearDoctor(int idDoctor, bool modoEdicion) : this()
        {
            idDoctorEdicion = idDoctor;
            esModoEdicion = modoEdicion;
        }

        // Configuración de doble búfer para evitar parpadeos visuales al maximizar o redimensionar
        private void ConfigurarOptimizacionesVisuales()
        {
            this.DoubleBuffered = true;
            HabilitarDobleBufer(panelHero);
            HabilitarDobleBufer(panelFormContenedor);
            HabilitarDobleBufer(panelCard);
            HabilitarDobleBufer(panelHeroBloque1);
            HabilitarDobleBufer(panelHeroBloque2);
            HabilitarDobleBufer(panelHeroBloque3);
            HabilitarDobleBufer(panelLema);
        }

        private static void HabilitarDobleBufer(Control control)
        {
            try
            {
                typeof(Control).InvokeMember(
                    "DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    control,
                    new object[] { true }
                );
            }
            catch
            {
                // Si la reflexión falla, continuar normalmente
            }
        }

        // ============================================================
        // LOAD Y CONFIGURACIÓN INICIAL
        // ============================================================
        private void crearDoctor_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            // Cargar logotipo institucional desde los recursos del sistema
            picLogoHero.Image = Tema.ObtenerLogo();

            // Microinteracciones de hover
            btnGuardar.MouseEnter += (s, ev) => btnGuardar.BackColor = Tema.AzulOscuro;
            btnGuardar.MouseLeave += (s, ev) => btnGuardar.BackColor = Tema.AzulPrimario;
            btnCancelar.MouseEnter += (s, ev) => btnCancelar.BackColor = Tema.FondoSecundario;
            btnCancelar.MouseLeave += (s, ev) => btnCancelar.BackColor = Tema.Superficie;
            btnSeleccionarFoto.MouseEnter += (s, ev) => btnSeleccionarFoto.BackColor = Tema.AzulOscuro;
            btnSeleccionarFoto.MouseLeave += (s, ev) => btnSeleccionarFoto.BackColor = Tema.AzulPrimario;
            btnAgregarAsignacion.MouseEnter += (s, ev) => btnAgregarAsignacion.BackColor = Tema.AzulOscuro;
            btnAgregarAsignacion.MouseLeave += (s, ev) => btnAgregarAsignacion.BackColor = Tema.AzulPrimario;

            // Navegación ágil por teclado (Enter)
            txtPrimerNombre.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtSegundoNombre.Focus(); ev.SuppressKeyPress = true; } };
            txtSegundoNombre.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtPrimerApellido.Focus(); ev.SuppressKeyPress = true; } };
            txtPrimerApellido.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtSegundoApellido.Focus(); ev.SuppressKeyPress = true; } };
            txtSegundoApellido.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtCedula.Focus(); ev.SuppressKeyPress = true; } };
            txtCedula.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtTelefono.Focus(); ev.SuppressKeyPress = true; } };
            txtTelefono.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) { txtLicencia.Focus(); ev.SuppressKeyPress = true; } };

            try
            {
                CargarCatalogos();

                if (esModoEdicion)
                {
                    lblTitulo.Text = "Modificar Datos del Doctor";
                    lblSubtitulo.Text = "Actualice los datos profesionales y asignaciones del médico";
                    lblRegistroTituloHero.Text = "Modificar Doctor";
                    btnGuardar.Text = "💾 Guardar Cambios";
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

            AjustarLayoutDoctor();
            txtPrimerNombre.Focus();
        }

        private void crearDoctor_Resize(object sender, EventArgs e)
        {
            AjustarLayoutDoctor();
        }

        // ============================================================
        // LAYOUT RESPONSIVO DINÁMICO
        // ============================================================
        private void AjustarLayoutDoctor()
        {
            int anchoTotal = this.ClientSize.Width;
            int altoTotal = this.ClientSize.Height;

            if (anchoTotal <= 0 || altoTotal <= 0)
                return;

            // División de pantalla: ~36% Hero a la izquierda y ~64% Formulario a la derecha
            int anchoHero = (int)(anchoTotal * 0.36f);
            if (anchoHero < 380)
                anchoHero = Math.Min(380, anchoTotal / 2);

            int anchoForm = anchoTotal - anchoHero;

            panelHero.SetBounds(0, 0, anchoHero, altoTotal);
            panelFormContenedor.SetBounds(anchoHero, 0, anchoForm, altoTotal);

            // Ajuste interno del panel Hero
            int margenHero = Math.Max(25, (anchoHero - 340) / 2);
            int anchoContenidoHero = Math.Min(340, anchoHero - (margenHero * 2));

            picLogoHero.Location = new Point(margenHero, Math.Max(20, (int)(altoTotal * 0.03f)));
            lblNombreHero.Location = new Point(margenHero - 3, picLogoHero.Bottom + 8);
            lblSubtituloHero.Location = new Point(margenHero, lblNombreHero.Bottom + 4);
            lblRegistroTituloHero.Location = new Point(margenHero, lblSubtituloHero.Bottom + 12);
            lblDescripcionHero.Location = new Point(margenHero, lblRegistroTituloHero.Bottom + 8);
            lblDescripcionHero.Width = anchoContenidoHero;

            panelHeroBloque1.Location = new Point(margenHero, lblDescripcionHero.Bottom + 14);
            panelHeroBloque1.Width = anchoContenidoHero;
            lblHeroDesc1.Width = panelHeroBloque1.Width - lblHeroDesc1.Left - 10;

            panelHeroBloque2.Location = new Point(margenHero, panelHeroBloque1.Bottom + 10);
            panelHeroBloque2.Width = anchoContenidoHero;
            lblHeroDesc2.Width = panelHeroBloque2.Width - lblHeroDesc2.Left - 10;

            panelHeroBloque3.Location = new Point(margenHero, panelHeroBloque2.Bottom + 10);
            panelHeroBloque3.Width = anchoContenidoHero;
            lblHeroDesc3.Width = panelHeroBloque3.Width - lblHeroDesc3.Left - 10;

            if (altoTotal >= 680)
            {
                panelLema.Visible = true;
                panelLema.Location = new Point(margenHero, panelHeroBloque3.Bottom + 14);
                panelLema.Width = anchoContenidoHero;
            }
            else
            {
                panelLema.Visible = false;
            }

            // Ajuste interno de la tarjeta de formulario
            int anchoCard = Math.Min(740, panelFormContenedor.ClientSize.Width - 40);
            if (anchoCard < 580)
                anchoCard = Math.Max(500, panelFormContenedor.ClientSize.Width - 20);

            panelCard.Width = anchoCard;
            panelCard.Left = Math.Max(15, (panelFormContenedor.ClientSize.Width - panelCard.Width) / 2);

            // Reajuste de dos columnas responsivas dentro de panelCard
            int margenCard = 30;
            int espacioCol = 24;
            int anchoCol = (panelCard.Width - (margenCard * 2) - espacioCol) / 2;
            int xCol1 = margenCard;
            int xCol2 = margenCard + anchoCol + espacioCol;

            panelSeparadorCabecera.Left = margenCard;
            panelSeparadorCabecera.Width = panelCard.Width - (margenCard * 2);

            // Columna 1: Primer nombre, Primer apellido, Cédula, Licencia, Especialidades
            lblPrimerNombre.Left = xCol1;
            txtPrimerNombre.Left = xCol1;
            txtPrimerNombre.Width = anchoCol;

            lblPrimerApellido.Left = xCol1;
            txtPrimerApellido.Left = xCol1;
            txtPrimerApellido.Width = anchoCol;

            lblCedula.Left = xCol1;
            txtCedula.Left = xCol1;
            txtCedula.Width = anchoCol;

            lblNumeroLicencia.Left = xCol1;
            txtLicencia.Left = xCol1;
            txtLicencia.Width = anchoCol;

            lblEspecialidadesTitulo.Left = xCol1;
            lstEspecialidades.Left = xCol1;
            lstEspecialidades.Width = anchoCol;

            // Columna 2: Segundo nombre, Segundo apellido, Teléfono, Foto, Asignaciones
            lblSegundoNombre.Left = xCol2;
            txtSegundoNombre.Left = xCol2;
            txtSegundoNombre.Width = anchoCol;

            lblSegundoApellido.Left = xCol2;
            txtSegundoApellido.Left = xCol2;
            txtSegundoApellido.Width = anchoCol;

            lblTelefono.Left = xCol2;
            txtTelefono.Left = xCol2;
            txtTelefono.Width = anchoCol;

            lblFotoTitulo.Left = xCol2;
            picPreview.Left = xCol2;
            lblFoto.Left = xCol2 + 95;
            lblFoto.Width = Math.Max(100, anchoCol - 95);
            btnSeleccionarFoto.Left = xCol2 + 95;
            btnQuitarFoto.Left = btnSeleccionarFoto.Right + 8;
            lblFotoAyuda.Left = xCol2 + 95;

            lblHospitalTitulo.Left = xCol2;
            int anchoCombo = (anchoCol - 12) / 2;
            cmbHospitalAsignacion.Left = xCol2;
            cmbHospitalAsignacion.Width = anchoCombo;

            lblEspecialidadHospTitulo.Left = cmbHospitalAsignacion.Right + 12;
            cmbEspecialidadHospital.Left = cmbHospitalAsignacion.Right + 12;
            cmbEspecialidadHospital.Width = anchoCombo;

            btnAgregarAsignacion.Left = xCol2;
            lblAsignacionesTitulo.Left = xCol2;
            lstAsignaciones.Left = xCol2;
            lstAsignaciones.Width = anchoCol;
            btnQuitarAsignacion.Left = xCol2;

            // Botones inferiores
            panelSeparadorInferior.Left = margenCard;
            panelSeparadorInferior.Width = panelCard.Width - (margenCard * 2);

            btnGuardar.Left = panelCard.Width - margenCard - btnGuardar.Width;
            btnCancelar.Left = btnGuardar.Left - 12 - btnCancelar.Width;
        }

        // ============================================================
        // PINTADO ESTÉTICO GDI+
        // ============================================================
        private void panelHero_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelHero.Width;
            int h = panelHero.Height;

            using (Pen penOnda1 = new Pen(Color.FromArgb(22, Tema.AzulClaro), 38f))
            using (Pen penOnda2 = new Pen(Color.FromArgb(18, Tema.Verde), 30f))
            {
                penOnda1.StartCap = LineCap.Round;
                penOnda1.EndCap = LineCap.Round;
                penOnda2.StartCap = LineCap.Round;
                penOnda2.EndCap = LineCap.Round;

                Point[] puntos1 = new Point[]
                {
                    new Point((int)(w * 0.40f), -20),
                    new Point((int)(w * 0.70f), (int)(h * 0.28f)),
                    new Point((int)(w * 0.85f), (int)(h * 0.60f)),
                    new Point(w + 30, (int)(h * 0.80f))
                };
                e.Graphics.DrawCurve(penOnda1, puntos1, 0.5f);

                Point[] puntos2 = new Point[]
                {
                    new Point(-20, (int)(h * 0.60f)),
                    new Point((int)(w * 0.30f), (int)(h * 0.76f)),
                    new Point((int)(w * 0.65f), (int)(h * 0.72f)),
                    new Point(w + 30, (int)(h * 0.88f))
                };
                e.Graphics.DrawCurve(penOnda2, puntos2, 0.5f);
            }
        }

        private void panelHeroBloque_Paint(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            if (c == null) return;
            using (Pen pen = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
            }
        }

        private void panelLema_Paint(object sender, PaintEventArgs e)
        {
            using (Brush brushAcento = new SolidBrush(Tema.VerdeOscuro))
            {
                e.Graphics.FillRectangle(brushAcento, 0, 0, 4, panelLema.Height);
            }

            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelLema.Width - 1, panelLema.Height - 1);
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penBorde = new Pen(Tema.Borde, 1f))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, panelCard.ClientSize.Width - 1, panelCard.ClientSize.Height - 1);
            }
        }

        // ============================================================
        // CARGA DE CATÁLOGOS Y DATOS
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

        // ============================================================
        // GESTIÓN DE FOTOGRAFÍA
        // ============================================================
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

                Image imagenCargada;
                try
                {
                    using (var stream = new MemoryStream(bytesArchivo))
                    {
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

        private void MostrarPreviewDesdeBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return;

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
                // Silencioso si los bytes no corresponden a un formato válido
            }
        }

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

        // ============================================================
        // ASIGNACIONES HOSPITALARIAS
        // ============================================================
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
                MessageBox.Show("Marque primero esa especialidad en la lista de especialidades del doctor.", "Especialidad no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarAsignacion(Convert.ToInt32(cmbHospitalAsignacion.SelectedValue), idEspecialidad);
        }

        private void AgregarAsignacion(int idHospital, int idEspecialidad)
        {
            if (asignaciones.Any(a => a.Item1 == idHospital && a.Item2 == idEspecialidad))
                return;

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
        // CANCELAR Y RETORNO
        // ============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
