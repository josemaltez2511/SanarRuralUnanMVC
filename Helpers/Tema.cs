using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

// Clase central de estilos visuales de Sanar Rural.
// Aquí viven TODOS los colores, fuentes y medidas del sistema, en un solo lugar.
// Regla del equipo: ningún formulario debe escribir un Color.FromArgb(...) directo.
// Siempre se usa Tema.ColorX o Tema.FuenteX, así si un color cambia, se cambia aquí
// una sola vez y se actualiza en todas las pantallas automáticamente.
namespace SanarRuralUnan.Helpers
{
    public static class Tema
    {
        // ===== COLORES =====
        public static readonly Color Fondo = Color.FromArgb(237, 247, 240);
        public static readonly Color FondoSecundario = Color.FromArgb(228, 241, 232);
        public static readonly Color Superficie = Color.FromArgb(249, 252, 250);
        public static readonly Color AzulPrimario = Color.FromArgb(35, 120, 183);
        public static readonly Color AzulOscuro = Color.FromArgb(23, 74, 107);
        public static readonly Color AzulClaro = Color.FromArgb(88, 169, 210);
        public static readonly Color Verde = Color.FromArgb(120, 184, 106);
        public static readonly Color VerdeOscuro = Color.FromArgb(77, 142, 86);
        public static readonly Color TextoPrincipal = Color.FromArgb(23, 51, 66);
        public static readonly Color TextoSecundario = Color.FromArgb(89, 112, 120);
        public static readonly Color Borde = Color.FromArgb(207, 225, 213);
        public static readonly Color Error = Color.FromArgb(198, 83, 83);
        public static readonly Color Advertencia = Color.FromArgb(214, 154, 58);
        public static readonly Color Informacion = AzulPrimario;

        // ===== COLORES PARA SELECCIÓN, HOVER Y ENCABEZADOS DE TABLAS (DataGridView) =====
        public static readonly Color SeleccionFila = Color.FromArgb(221, 239, 229); // #DDEFE5 - Verde menta claro suave institucional
        public static readonly Color SeleccionFilaBorde = Color.FromArgb(120, 184, 106); // #78B86A - Borde delimitador sutil de fila seleccionada
        public static readonly Color SeleccionFilaIndicador = VerdeOscuro; // #4D8E56 - Barra indicadora izquierda de 4px para fila seleccionada
        public static readonly Color SeleccionTexto = TextoPrincipal; // #173342 - Azul oscuro pizarra de alto contraste (WCAG AAA)
        public static readonly Color FilaHover = Color.FromArgb(242, 248, 244); // #F2F8F4 - Tono sutil entre Superficie (#F9FCFA) y Fondo (#EDF7F0)

        // Alias conservados para los formularios existentes.
        public static readonly Color VerdeAcento = Verde; // Línea decorativa, éxito
        public static readonly Color FondoVentana = Fondo; // Fondo detrás de la tarjeta
        public static readonly Color FondoTarjeta = Superficie;
        public static readonly Color FondoTarjetaSeleccionada = FondoSecundario; // Fondo de la tarjeta de tipo de usuario cuando está elegida
        public static readonly Color TextoAyuda = TextoSecundario; // Texto gris de ayuda (más oscuro para contraste)
        public static readonly Color ColorError = Error;
        public static readonly Color ColorExito = VerdeOscuro;

        // Colores para estados y badges del nuevo diseño
        public static readonly Color BadgeActivoFondo = Color.FromArgb(235, 247, 238);
        public static readonly Color BadgeInactivoFondo = Color.FromArgb(243, 245, 247);
        public static readonly Color BadgeRolAdminFondo = Color.FromArgb(228, 239, 250);
        public static readonly Color BadgeRolDoctorFondo = Color.FromArgb(233, 244, 252);
        public static readonly Color BadgeRolPacienteFondo = Color.FromArgb(235, 248, 238);
        public static readonly Color BadgePendienteFondo = Color.FromArgb(254, 249, 237);
        public static readonly Color BadgePendienteBorde = Color.FromArgb(248, 225, 172);
        public static readonly Color BadgeConfirmadaFondo = Color.FromArgb(235, 247, 238);
        public static readonly Color BadgeConfirmadaBorde = Color.FromArgb(190, 230, 202);
        public static readonly Color BadgeAtendidaFondo = Color.FromArgb(228, 239, 250);
        public static readonly Color BadgeAtendidaBorde = Color.FromArgb(185, 218, 242);
        public static readonly Color BadgeCanceladaFondo = Color.FromArgb(254, 242, 242);
        public static readonly Color BadgeCanceladaBorde = Color.FromArgb(245, 198, 198);
        public static readonly Color BadgeNoAsistioFondo = Color.FromArgb(243, 245, 247);
        public static readonly Color BadgeNoAsistioBorde = Color.FromArgb(220, 224, 228);
        public static readonly Color BotonPeligroFondo = Color.FromArgb(254, 242, 242);
        public static readonly Color BotonPeligroBorde = Color.FromArgb(245, 198, 198);
        public static readonly Color BotonEditarFondo = Color.FromArgb(240, 247, 253);
        public static readonly Color BotonEditarBorde = Color.FromArgb(195, 222, 243);

        // ===== FUENTES =====
        // FontStyle.Bold / Regular ya vienen incluidos en cada constante para no repetirlo en cada formulario
        public const string FamiliaFuente = "Segoe UI";
        public const float TamanoTitulo = 22F;
        public const float TamanoSubtitulo = 10F;
        public const float TamanoCuerpo = 10F;
        public const float TamanoEtiqueta = 9.5F;
        public const float TamanoBoton = 10F;
        public const float TamanoAyuda = 9F;

        public static Font FuenteTitulo => new Font(FamiliaFuente, TamanoTitulo, FontStyle.Bold);
        public static Font FuenteMarca => new Font(FamiliaFuente, 16F, FontStyle.Bold);
        public static Font FuenteSubtitulo => new Font(FamiliaFuente, TamanoSubtitulo, FontStyle.Regular);
        public static Font FuenteCuerpo => new Font(FamiliaFuente, TamanoCuerpo, FontStyle.Regular);
        public static Font FuenteLabelCampo => new Font(FamiliaFuente, TamanoEtiqueta, FontStyle.Bold);
        public static Font FuenteInput => new Font(FamiliaFuente, 11F, FontStyle.Regular);
        public static Font FuenteAyuda => new Font(FamiliaFuente, TamanoAyuda, FontStyle.Regular);
        public static Font FuenteBoton => new Font(FamiliaFuente, TamanoBoton, FontStyle.Bold);
        public static Font FuentePequena => new Font(FamiliaFuente, 8.5F, FontStyle.Regular);
        public static Font FuenteMetricaNumero => new Font(FamiliaFuente, 20F, FontStyle.Bold);
        public static Font FuenteMetricaLabel => new Font(FamiliaFuente, 9F, FontStyle.Regular);

        // Espaciado
        public const int EspacioPequeno = 8;
        public const int EspacioMediano = 16;
        public const int EspacioGrande = 24;
        public const int EspacioExtraGrande = 32;

        // ===== MEDIDAS ESTÁNDAR =====
        public const int AltoBoton = 42;
        public const int AltoCampo = 40;
        public const int AltoEncabezado = 48;
        public const int AltoFilaTabla = 38;
        public const int RadioTarjeta = 10;
        public const int RadioBoton = 6;

        // Alias conservados para formularios existentes.
        public const int AnchoTarjeta = 500;
        public const int AnchoInput = 420;
        public const int AltoInput = AltoCampo;
        public const int MargenIzquierdo = 40;
        public const int EspacioEntreCampos = 70; // Distancia vertical estándar entre un campo y el siguiente

        // Duraciones disponibles para transiciones sencillas de interfaz.
        public const int AnimacionRapida = 150;
        public const int AnimacionNormal = 180;

        // Genera una ruta gráfica con esquinas redondeadas para tarjetas y botones.
        public static GraphicsPath CrearRutaRedondeada(Rectangle rect, int radio)
        {
            var ruta = new GraphicsPath();
            if (radio <= 0)
            {
                ruta.AddRectangle(rect);
                return ruta;
            }

            int diametro = radio * 2;
            int r = System.Math.Min(diametro, System.Math.Min(rect.Width, rect.Height));

            ruta.AddArc(rect.X, rect.Y, r, r, 180, 90);
            ruta.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            ruta.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            ruta.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            ruta.CloseFigure();
            return ruta;
        }

        // Dibuja una tarjeta con fondo y borde redondeados con suavizado GDI+.
        public static void DibujarTarjetaRedondeada(Graphics g, Rectangle rect, Color fondo, Color borde, int radio = 10)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var ruta = CrearRutaRedondeada(rect, radio))
            {
                using (var brocha = new SolidBrush(fondo))
                {
                    g.FillPath(brocha, ruta);
                }
                using (var pluma = new Pen(borde, 1f))
                {
                    g.DrawPath(pluma, ruta);
                }
            }
        }

        private class EstadoHoverTabla
        {
            public int FilaHover = -1;
        }

        private static readonly ConditionalWeakTable<DataGridView, EstadoHoverTabla> EstadosHover =
            new ConditionalWeakTable<DataGridView, EstadoHoverTabla>();

        public static void ConfigurarTabla(DataGridView tabla)
        {
            if (tabla == null) return;

            // 1. Doble búfer vía Reflection para garantizar un redibujado instantáneo sin parpadeo
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                    null, tabla, new object[] { true });
            }
            catch { }

            // 2. Propiedades estructurales de la tabla
            tabla.BackgroundColor = Superficie;
            tabla.BorderStyle = BorderStyle.None;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabla.GridColor = Borde;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.MultiSelect = false;
            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.RowHeadersVisible = false;
            tabla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabla.RowTemplate.Height = AltoFilaTabla;

            // 3. Encabezados de columna: verde claro institucional (#E4F1E8) con texto azul oscuro (#174A6B)
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabla.ColumnHeadersHeight = AltoEncabezado;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            tabla.ColumnHeadersDefaultCellStyle.BackColor = FondoSecundario;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = AzulOscuro;
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = FondoSecundario;
            tabla.ColumnHeadersDefaultCellStyle.SelectionForeColor = AzulOscuro;
            tabla.ColumnHeadersDefaultCellStyle.Font = FuenteLabelCampo;

            // 4. Filas normales (Superficie #F9FCFA) y Filas alternas (Fondo #EDF7F0)
            tabla.DefaultCellStyle.BackColor = Superficie;
            tabla.DefaultCellStyle.ForeColor = TextoPrincipal;
            tabla.DefaultCellStyle.SelectionBackColor = SeleccionFila;
            tabla.DefaultCellStyle.SelectionForeColor = SeleccionTexto;
            tabla.DefaultCellStyle.Font = FuenteCuerpo;

            tabla.AlternatingRowsDefaultCellStyle.BackColor = Fondo;
            tabla.AlternatingRowsDefaultCellStyle.ForeColor = TextoPrincipal;
            tabla.AlternatingRowsDefaultCellStyle.SelectionBackColor = SeleccionFila;
            tabla.AlternatingRowsDefaultCellStyle.SelectionForeColor = SeleccionTexto;
            tabla.AlternatingRowsDefaultCellStyle.Font = FuenteCuerpo;

            // 5. Encabezados de fila (por si alguna vista los utiliza)
            tabla.RowHeadersDefaultCellStyle.BackColor = FondoSecundario;
            tabla.RowHeadersDefaultCellStyle.ForeColor = AzulOscuro;
            tabla.RowHeadersDefaultCellStyle.SelectionBackColor = FondoSecundario;
            tabla.RowHeadersDefaultCellStyle.SelectionForeColor = AzulOscuro;

            // 6. Configurar estilos de encabezado en columnas existentes y futuras
            foreach (DataGridViewColumn col in tabla.Columns)
            {
                AplicarEstiloEncabezadoColumna(col);
            }

            tabla.ColumnAdded -= Tabla_ColumnAdded_Estilo;
            tabla.ColumnAdded += Tabla_ColumnAdded_Estilo;

            // 7. Eventos de renderizado personalizado (encabezados consistentes e indicador de selección)
            tabla.CellPainting -= Tabla_CellPainting_Encabezados;
            tabla.CellPainting += Tabla_CellPainting_Encabezados;

            tabla.RowPostPaint -= Tabla_RowPostPaint_Indicador;
            tabla.RowPostPaint += Tabla_RowPostPaint_Indicador;

            tabla.SelectionChanged -= Tabla_SelectionChanged_Redibujar;
            tabla.SelectionChanged += Tabla_SelectionChanged_Redibujar;

            // 8. Efecto hover sutil al pasar el cursor sobre filas no seleccionadas
            tabla.CellMouseEnter -= Tabla_CellMouseEnter_Hover;
            tabla.CellMouseEnter += Tabla_CellMouseEnter_Hover;

            tabla.CellMouseLeave -= Tabla_CellMouseLeave_Hover;
            tabla.CellMouseLeave += Tabla_CellMouseLeave_Hover;

            tabla.MouseLeave -= Tabla_MouseLeave_Hover;
            tabla.MouseLeave += Tabla_MouseLeave_Hover;
        }

        private static void AplicarEstiloEncabezadoColumna(DataGridViewColumn col)
        {
            if (col == null || col.HeaderCell == null) return;
            col.HeaderCell.Style.BackColor = FondoSecundario;
            col.HeaderCell.Style.ForeColor = AzulOscuro;
            col.HeaderCell.Style.SelectionBackColor = FondoSecundario;
            col.HeaderCell.Style.SelectionForeColor = AzulOscuro;
            col.HeaderCell.Style.Font = FuenteLabelCampo;
        }

        private static void Tabla_ColumnAdded_Estilo(object sender, DataGridViewColumnEventArgs e)
        {
            AplicarEstiloEncabezadoColumna(e.Column);
        }

        private static void Tabla_CellPainting_Encabezados(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                // Fondo verde claro uniforme en cualquier estado (clic, ordenamiento, foco)
                using (var brushFondo = new SolidBrush(FondoSecundario))
                {
                    e.Graphics.FillRectangle(brushFondo, e.CellBounds);
                }

                // Línea inferior sutil institucional
                using (var penBorde = new Pen(Borde, 1f))
                {
                    e.Graphics.DrawLine(penBorde, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                if (e.ColumnIndex >= 0)
                {
                    // Renderizar texto y flecha de ordenamiento preservando alineación
                    e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                }

                e.Handled = true;
            }
        }

        private static void Tabla_RowPostPaint_Indicador(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var tabla = sender as DataGridView;
            if (tabla == null) return;
            if (e.RowIndex < 0 || e.RowIndex >= tabla.Rows.Count) return;

            DataGridViewRow fila = tabla.Rows[e.RowIndex];
            if (fila.Selected)
            {
                // 1. Barra indicadora vertical izquierda de 4px en VerdeOscuro (#4D8E56)
                int anchoIndicador = 4;
                Rectangle rectIndicador = new Rectangle(
                    e.RowBounds.Left,
                    e.RowBounds.Top,
                    anchoIndicador,
                    e.RowBounds.Height - 1
                );
                using (var brushIndicador = new SolidBrush(SeleccionFilaIndicador))
                {
                    e.Graphics.FillRectangle(brushIndicador, rectIndicador);
                }

                // 2. Borde sutil superior e inferior de la fila seleccionada en Verde (#78B86A)
                using (var penBorde = new Pen(SeleccionFilaBorde, 1f))
                {
                    e.Graphics.DrawLine(penBorde, e.RowBounds.Left, e.RowBounds.Top, e.RowBounds.Right - 1, e.RowBounds.Top);
                    e.Graphics.DrawLine(penBorde, e.RowBounds.Left, e.RowBounds.Bottom - 1, e.RowBounds.Right - 1, e.RowBounds.Bottom - 1);
                }
            }
        }

        private static void Tabla_SelectionChanged_Redibujar(object sender, EventArgs e)
        {
            var tabla = sender as DataGridView;
            if (tabla != null && !tabla.IsDisposed)
            {
                tabla.Invalidate();
            }
        }

        private static void Tabla_CellMouseEnter_Hover(object sender, DataGridViewCellEventArgs e)
        {
            var tabla = sender as DataGridView;
            if (tabla == null) return;

            if (e.RowIndex >= 0 && e.RowIndex < tabla.Rows.Count)
            {
                EstadoHoverTabla estado;
                if (!EstadosHover.TryGetValue(tabla, out estado))
                {
                    estado = new EstadoHoverTabla();
                    EstadosHover.Add(tabla, estado);
                }

                if (estado.FilaHover >= 0 && estado.FilaHover < tabla.Rows.Count && estado.FilaHover != e.RowIndex)
                {
                    int filaAnterior = estado.FilaHover;
                    estado.FilaHover = -1;
                    if (!tabla.Rows[filaAnterior].Selected)
                    {
                        tabla.Rows[filaAnterior].DefaultCellStyle.BackColor = Color.Empty;
                    }
                }

                estado.FilaHover = e.RowIndex;
                if (!tabla.Rows[e.RowIndex].Selected)
                {
                    tabla.Rows[e.RowIndex].DefaultCellStyle.BackColor = FilaHover;
                }
            }
        }

        private static void Tabla_CellMouseLeave_Hover(object sender, DataGridViewCellEventArgs e)
        {
            var tabla = sender as DataGridView;
            if (tabla == null) return;

            if (e.RowIndex >= 0 && e.RowIndex < tabla.Rows.Count)
            {
                if (!tabla.Rows[e.RowIndex].Selected)
                {
                    tabla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
                }
            }
        }

        private static void Tabla_MouseLeave_Hover(object sender, EventArgs e)
        {
            var tabla = sender as DataGridView;
            if (tabla == null) return;

            EstadoHoverTabla estado;
            if (EstadosHover.TryGetValue(tabla, out estado) && estado.FilaHover >= 0)
            {
                if (estado.FilaHover < tabla.Rows.Count && !tabla.Rows[estado.FilaHover].Selected)
                {
                    tabla.Rows[estado.FilaHover].DefaultCellStyle.BackColor = Color.Empty;
                }
                estado.FilaHover = -1;
            }
        }


        // Obtiene la imagen del logo institucional desde los recursos del proyecto.
        public static Image ObtenerLogo()
        {
            try
            {
                byte[] datos = Properties.Resources.ResourceManager.GetObject("SanarRuralLogo") as byte[];
                if (datos == null)
                    return null;

                using (var flujo = new System.IO.MemoryStream(datos))
                using (var imagen = Image.FromStream(flujo))
                {
                    return new Bitmap(imagen);
                }
            }
            catch
            {
                return null;
            }
        }

        // Sanea textos provenientes de la base de datos con problemas de codificación UTF-8 / Windows-1252
        public static string SanearTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;
            if (texto.Contains("Ã"))
            {
                try
                {
                    byte[] bytes = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(texto);
                    return System.Text.Encoding.UTF8.GetString(bytes);
                }
                catch
                {
                    return texto;
                }
            }
            return texto;
        }

        // ===== RENDERIZADO VECTORIAL GDI+ DE ICONOS INSTITUCIONALES =====
        // Dibuja iconos vectoriales nítidos y escalables para evitar caracteres Unicode no soportados (cajas/cuadrados).

        public static void DibujarFondoCircular(Graphics g, Rectangle r, Color fondo)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(fondo))
            {
                g.FillEllipse(brush, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            }
        }

        public static void DibujarIconoLupa(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Lupa", r, color);
        public static void DibujarIconoFiltro(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Filtro", r, color);
        public static void DibujarIconoUsuarios(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Usuarios", r, color);
        public static void DibujarIconoUsuario(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Usuario", r, color);
        public static void DibujarIconoDoctor(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Doctor", r, color);
        public static void DibujarIconoAdmin(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Admin", r, color);
        public static void DibujarIconoPersonal(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Personal", r, color);
        public static void DibujarIconoPaciente(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Paciente", r, color);
        public static void DibujarIconoCheck(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Check", r, color);
        public static void DibujarIconoInactivo(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Inactivo", r, color);
        public static void DibujarIconoOjo(Graphics g, Rectangle r, Color color, bool cerrado = false) => DibujarIconoVectorial(g, cerrado ? "OjoCerrado" : "Ojo", r, color);
        public static void DibujarIconoCandado(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Candado", r, color);
        public static void DibujarIconoCalendario(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Calendario", r, color);
        public static void DibujarIconoHistorial(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Historial", r, color);
        public static void DibujarIconoLapiz(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Lapiz", r, color);
        public static void DibujarIconoProhibido(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Prohibido", r, color);
        public static void DibujarIconoReactivar(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Reactivar", r, color);
        public static void DibujarIconoCasa(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Casa", r, color);
        public static void DibujarIconoAlerta(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Alerta", r, color);
        public static void DibujarIconoGuardar(Graphics g, Rectangle r, Color color) => DibujarIconoVectorial(g, "Guardar", r, color);

        public static void DibujarIconoVectorial(Graphics g, string tipo, Rectangle r, Color c)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int size = Math.Max(12, Math.Min(r.Width - 4, Math.Min(r.Height - 4, 16)));
            int cx = r.X + (r.Width / 2);
            int cy = r.Y + (r.Height / 2);
            int ix = cx - (size / 2);
            int iy = cy - (size / 2);

            using (var pen = new Pen(c, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            using (var brush = new SolidBrush(c))
            {
                switch (tipo)
                {
                    case "Lupa":
                        g.DrawEllipse(pen, ix + 1, iy + 1, 9, 9);
                        g.DrawLine(pen, ix + 8, iy + 8, ix + 14, iy + 14);
                        break;

                    case "Filtro":
                        PointF[] embudo = {
                            new PointF(ix + 1, iy + 2),
                            new PointF(ix + 15, iy + 2),
                            new PointF(ix + 10, iy + 8),
                            new PointF(ix + 10, iy + 13),
                            new PointF(ix + 6, iy + 15),
                            new PointF(ix + 6, iy + 8)
                        };
                        g.DrawPolygon(pen, embudo);
                        break;

                    case "Usuarios":
                        g.FillEllipse(brush, ix + 2, iy + 2, 5, 5);
                        g.DrawArc(pen, ix, iy + 8, 9, 7, 180, 180);
                        g.FillEllipse(brush, ix + 9, iy + 3, 5, 5);
                        g.DrawArc(pen, ix + 7, iy + 9, 9, 6, 190, 160);
                        break;

                    case "Usuario":
                        g.FillEllipse(brush, ix + 4, iy + 1, 7, 7);
                        g.DrawArc(pen, ix + 1, iy + 9, 13, 7, 180, 180);
                        break;

                    case "Check":
                        g.DrawLine(pen, ix + 2, iy + 8, ix + 6, iy + 12);
                        g.DrawLine(pen, ix + 6, iy + 12, ix + 14, iy + 3);
                        break;

                    case "Inactivo":
                        g.DrawEllipse(pen, ix + 3, iy + 3, 10, 10);
                        break;

                    case "Admin":
                        PointF[] escudo = {
                            new PointF(ix + 2, iy + 2),
                            new PointF(ix + 14, iy + 2),
                            new PointF(ix + 14, iy + 7),
                            new PointF(ix + 8, iy + 15),
                            new PointF(ix + 2, iy + 7)
                        };
                        g.DrawPolygon(pen, escudo);
                        g.FillEllipse(brush, ix + 7, iy + 6, 2, 2);
                        break;

                    case "Personal":
                        g.DrawArc(pen, ix + 5, iy + 1, 6, 4, 180, 180);
                        g.DrawRectangle(pen, ix + 1, iy + 4, 14, 10);
                        g.DrawLine(pen, ix + 1, iy + 8, ix + 15, iy + 8);
                        g.FillRectangle(brush, ix + 7, iy + 7, 2, 2);
                        break;

                    case "Doctor":
                        g.DrawLine(pen, ix + 3, iy + 1, ix + 3, iy + 5);
                        g.DrawLine(pen, ix + 13, iy + 1, ix + 13, iy + 5);
                        g.DrawArc(pen, ix + 3, iy + 2, 10, 8, 0, 180);
                        g.DrawLine(pen, ix + 8, iy + 10, ix + 8, iy + 13);
                        g.DrawArc(pen, ix + 8, iy + 11, 4, 4, 90, 180);
                        g.FillEllipse(brush, ix + 11, iy + 12, 3, 3);
                        break;

                    case "Paciente":
                        g.FillEllipse(brush, ix + 3, iy + 1, 6, 6);
                        g.DrawArc(pen, ix, iy + 8, 12, 7, 180, 180);
                        g.DrawLine(pen, ix + 12, iy + 5, ix + 12, iy + 11);
                        g.DrawLine(pen, ix + 9, iy + 8, ix + 15, iy + 8);
                        break;

                    case "Ojo":
                        PointF[] aSup = { new PointF(ix + 1, iy + 8), new PointF(ix + 8, iy + 2), new PointF(ix + 15, iy + 8) };
                        PointF[] aInf = { new PointF(ix + 1, iy + 8), new PointF(ix + 8, iy + 14), new PointF(ix + 15, iy + 8) };
                        g.DrawCurve(pen, aSup);
                        g.DrawCurve(pen, aInf);
                        g.FillEllipse(brush, ix + 6, iy + 6, 4, 4);
                        break;

                    case "OjoCerrado":
                        PointF[] acSup = { new PointF(ix + 1, iy + 8), new PointF(ix + 8, iy + 2), new PointF(ix + 15, iy + 8) };
                        PointF[] acInf = { new PointF(ix + 1, iy + 8), new PointF(ix + 8, iy + 14), new PointF(ix + 15, iy + 8) };
                        g.DrawCurve(pen, acSup);
                        g.DrawCurve(pen, acInf);
                        g.FillEllipse(brush, ix + 6, iy + 6, 4, 4);
                        g.DrawLine(pen, ix + 2, iy + 15, ix + 14, iy + 1);
                        break;

                    case "Candado":
                        g.DrawArc(pen, ix + 4, iy + 1, 8, 7, 180, 180);
                        g.DrawLine(pen, ix + 4, iy + 4, ix + 4, iy + 7);
                        g.DrawLine(pen, ix + 12, iy + 4, ix + 12, iy + 7);
                        g.DrawRectangle(pen, ix + 2, iy + 7, 12, 8);
                        g.FillEllipse(brush, ix + 7, iy + 10, 2, 2);
                        break;

                    case "Calendario":
                        g.DrawRectangle(pen, ix + 1, iy + 3, 14, 12);
                        g.DrawLine(pen, ix + 4, iy + 1, ix + 4, iy + 4);
                        g.DrawLine(pen, ix + 12, iy + 1, ix + 12, iy + 4);
                        g.DrawLine(pen, ix + 1, iy + 6, ix + 15, iy + 6);
                        g.FillRectangle(brush, ix + 4, iy + 8, 2, 2);
                        g.FillRectangle(brush, ix + 8, iy + 8, 2, 2);
                        g.FillRectangle(brush, ix + 12, iy + 8, 2, 2);
                        break;

                    case "Historial":
                        g.DrawRectangle(pen, ix + 2, iy + 3, 12, 12);
                        g.DrawRectangle(pen, ix + 5, iy + 1, 6, 3);
                        g.DrawLine(pen, ix + 5, iy + 7, ix + 11, iy + 7);
                        g.DrawLine(pen, ix + 5, iy + 10, ix + 11, iy + 10);
                        g.DrawLine(pen, ix + 5, iy + 13, ix + 9, iy + 13);
                        break;

                    case "Lapiz":
                        g.DrawLine(pen, ix + 2, iy + 13, ix + 12, iy + 3);
                        g.DrawLine(pen, ix + 4, iy + 15, ix + 14, iy + 5);
                        g.DrawLine(pen, ix + 12, iy + 3, ix + 14, iy + 5);
                        g.DrawLine(pen, ix + 1, iy + 15, ix + 3, iy + 13);
                        break;

                    case "Prohibido":
                        g.DrawEllipse(pen, ix + 2, iy + 2, 12, 12);
                        g.DrawLine(pen, ix + 4, iy + 12, ix + 12, iy + 4);
                        break;

                    case "Reactivar":
                        g.DrawArc(pen, ix + 2, iy + 2, 12, 12, 45, 270);
                        g.DrawLine(pen, ix + 11, iy + 3, ix + 14, iy + 6);
                        g.DrawLine(pen, ix + 8, iy + 6, ix + 14, iy + 6);
                        break;

                    case "Casa":
                        PointF[] techo = { new PointF(ix + 1, iy + 7), new PointF(ix + 8, iy + 1), new PointF(ix + 15, iy + 7) };
                        g.DrawLines(pen, techo);
                        g.DrawRectangle(pen, ix + 3, iy + 7, 10, 8);
                        g.DrawRectangle(pen, ix + 6, iy + 10, 4, 5);
                        break;

                    case "Alerta":
                        PointF[] tri = { new PointF(ix + 8, iy + 1), new PointF(ix + 15, iy + 14), new PointF(ix + 1, iy + 14) };
                        g.DrawPolygon(pen, tri);
                        g.DrawLine(pen, ix + 8, iy + 5, ix + 8, iy + 9);
                        g.FillRectangle(brush, ix + 7, iy + 11, 2, 2);
                        break;

                    case "Guardar":
                        g.DrawRectangle(pen, ix + 2, iy + 2, 12, 12);
                        g.FillRectangle(brush, ix + 4, iy + 2, 7, 4);
                        g.DrawLine(pen, ix + 4, iy + 10, ix + 12, iy + 10);
                        break;
                }
            }
        }
    }
}
