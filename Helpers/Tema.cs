using System.Drawing;
using System.Drawing.Drawing2D;
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

        public static void ConfigurarTabla(DataGridView tabla)
        {
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
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = FondoSecundario;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = AzulOscuro;
            tabla.ColumnHeadersDefaultCellStyle.Font = FuenteLabelCampo;
            tabla.ColumnHeadersHeight = AltoEncabezado;
            tabla.DefaultCellStyle.BackColor = Superficie;
            tabla.DefaultCellStyle.ForeColor = TextoPrincipal;
            tabla.DefaultCellStyle.SelectionBackColor = FondoSecundario;
            tabla.DefaultCellStyle.SelectionForeColor = TextoPrincipal;
            tabla.DefaultCellStyle.Font = FuenteCuerpo;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Fondo;
            tabla.RowTemplate.Height = AltoFilaTabla;
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
    }
}
