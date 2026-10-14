using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SanarRuralUnan.Controllers;
using SanarRuralUnan.Helpers;
using SanarRuralUnan.Models;

namespace SanarRuralUnan.Views.Administradores
{
    /// <summary>
    /// Ficha de detalle de un Administrador.
    /// Muestra la información personal del perfil y el estado de su cuenta de acceso asociada.
    /// Exclusivo para el rol 'Admin'.
    /// </summary>
    public partial class detalleAdministrador : Form
    {
        private readonly int idAdministrador;
        private readonly administradoresControllers controlador = new administradoresControllers();

        public detalleAdministrador(int idAdministrador)
        {
            this.idAdministrador = idAdministrador;
            InitializeComponent();
            ConfigurarEstilosVisuales();
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.Fondo;

            cardHeader.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardHeader.Width - 1, cardHeader.Height - 1), Color.White, Tema.Borde, 8);
            };

            cardDatosPersonales.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardDatosPersonales.Width - 1, cardDatosPersonales.Height - 1), Color.White, Tema.Borde, 8);
            };

            cardCredenciales.Paint += (s, ev) =>
            {
                Tema.DibujarTarjetaRedondeada(ev.Graphics, new Rectangle(0, 0, cardCredenciales.Width - 1, cardCredenciales.Height - 1), Color.White, Tema.Borde, 8);
            };

            lblAvatar.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(235, 245, 255)))
                {
                    ev.Graphics.FillEllipse(brush, 1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
                }
                using (var pen = new Pen(Color.FromArgb(195, 220, 245), 1f))
                {
                    ev.Graphics.DrawEllipse(pen, 1, 1, lblAvatar.Width - 3, lblAvatar.Height - 3);
                }
                if (!string.IsNullOrEmpty(lblAvatar.Text))
                {
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    using (var brushTexto = new SolidBrush(Tema.AzulPrimario))
                    {
                        ev.Graphics.DrawString(lblAvatar.Text, lblAvatar.Font, brushTexto, new RectangleF(0, 0, lblAvatar.Width, lblAvatar.Height), sf);
                    }
                }
            };
        }

        private void detalleAdministrador_Load(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void CargarDetalle()
        {
            try
            {
                AdministradorDetalleDto detalle = controlador.ObtenerDetalle(idAdministrador);
                if (detalle == null)
                {
                    MessageBox.Show("No se encontró el administrador especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                lblNombreCompleto.Text = detalle.NombreCompleto;
                lblAvatar.Text = ObtenerIniciales(detalle.NombreCompleto);

                lblValorCedula.Text = string.IsNullOrWhiteSpace(detalle.Cedula) ? "No especificada" : detalle.Cedula;
                lblValorTelefono.Text = string.IsNullOrWhiteSpace(detalle.Telefono) ? "No especificado" : detalle.Telefono;
                lblValorCorreo.Text = string.IsNullOrWhiteSpace(detalle.Correo) ? "No especificado" : detalle.Correo;

                if (detalle.Estado)
                {
                    lblValorEstado.Text = "● Activo";
                    lblValorEstado.ForeColor = Tema.VerdeOscuro;
                }
                else
                {
                    lblValorEstado.Text = "○ Inactivo";
                    lblValorEstado.ForeColor = Tema.TextoSecundario;
                }

                if (detalle.TieneCuenta)
                {
                    lblValorUsuario.Text = detalle.NombreUsuario;
                    lblValorUsuario.ForeColor = Tema.AzulPrimario;
                    lblValorCorreoUsuario.Text = string.IsNullOrWhiteSpace(detalle.CorreoUsuario) ? "No registrado" : detalle.CorreoUsuario;

                    if (detalle.EstadoUsuario == true)
                    {
                        lblValorEstadoUsuario.Text = "● Activa / Habilitada";
                        lblValorEstadoUsuario.ForeColor = Tema.VerdeOscuro;
                    }
                    else
                    {
                        lblValorEstadoUsuario.Text = "○ Inactiva / Suspendida";
                        lblValorEstadoUsuario.ForeColor = Tema.Error;
                    }
                }
                else
                {
                    lblValorUsuario.Text = "○ Sin cuenta de acceso asignada";
                    lblValorUsuario.ForeColor = Tema.TextoSecundario;
                    lblValorCorreoUsuario.Text = "N/A";
                    lblValorEstadoUsuario.Text = "N/A";
                    lblValorEstadoUsuario.ForeColor = Tema.TextoSecundario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información del administrador:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private static string ObtenerIniciales(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "AD";
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
            }
            return partes[0].Substring(0, Math.Min(2, partes[0].Length)).ToUpper();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (crearAdministrador form = new crearAdministrador(idAdministrador))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CargarDetalle();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCerrarTop_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
