using System.Drawing;

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
        public static readonly Color AzulPrimario = Color.FromArgb(27, 108, 168);   // Botones, título, marca
        public static readonly Color VerdeAcento = Color.FromArgb(120, 190, 32);    // Línea decorativa, éxito
        public static readonly Color FondoVentana = Color.FromArgb(238, 243, 248);  // Fondo detrás de la tarjeta
        public static readonly Color FondoTarjeta = Color.White;
        public static readonly Color FondoTarjetaSeleccionada = Color.FromArgb(230, 240, 248); // Fondo de la tarjeta de tipo de usuario cuando está elegida
        public static readonly Color TextoPrincipal = Color.FromArgb(50, 60, 70);   // Labels de campo
        public static readonly Color TextoAyuda = Color.FromArgb(85, 98, 112);      // Texto gris de ayuda (más oscuro para contraste)
        public static readonly Color ColorError = Color.FromArgb(211, 47, 47);
        public static readonly Color ColorExito = Color.FromArgb(120, 190, 32);

        // ===== FUENTES =====
        // FontStyle.Bold / Regular ya vienen incluidos en cada constante para no repetirlo en cada formulario
        public static Font FuenteTitulo => new Font("Segoe UI", 18F, FontStyle.Bold);
        public static Font FuenteSubtitulo => new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static Font FuenteLabelCampo => new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static Font FuenteInput => new Font("Segoe UI", 11F);
        public static Font FuenteAyuda => new Font("Segoe UI", 8.5F);
        public static Font FuenteBoton => new Font("Segoe UI", 11F, FontStyle.Bold);

        // ===== MEDIDAS ESTÁNDAR =====
        public const int AnchoTarjeta = 500;
        public const int AnchoInput = 420;
        public const int AltoInput = 32;          // Antes 27px — se sube un poco para mejor accesibilidad táctil
        public const int MargenIzquierdo = 40;
        public const int EspacioEntreCampos = 70; // Distancia vertical estándar entre un campo y el siguiente
        public const int AltoBoton = 44;
    }
}