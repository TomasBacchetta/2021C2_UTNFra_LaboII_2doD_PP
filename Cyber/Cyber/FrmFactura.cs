using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sesiones;
using Entidades;

namespace Cyber
{
    public partial class FrmFactura : Form
    {
        Sesion sesionActual;
        string razonSocial;
        public FrmFactura(Sesion sesionActual, string razonSocial)
        {
            InitializeComponent();
            this.sesionActual = sesionActual;
            this.razonSocial = razonSocial;
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            btnSobreFacturar.Visible = false;
            if (this.sesionActual.EfectoActual == Sesion.Efecto.Alcoholismo)
            {
                btnSobreFacturar.Visible = true;
            }
            rtbFactura.Text = ImprimirFactura();
        }

        private string ImprimirFactura()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"***{this.razonSocial.ToUpper()}***");
            buffer.AppendLine("-----------------");
            buffer.AppendLine($"ID EQUIPO: {sesionActual.Equipo.Id}");
            buffer.Append("TIPO: ");
            if (sesionActual.Equipo.TipoDeEquipo == Equipos.Equipo.TipoEquipo.Computadora)
            {
                buffer.Append("COMPUTADORA");
            } else
            {
                buffer.Append("CABINA TELEFÓNICA");
            }
            buffer.AppendLine($"\nUSUARIO: {sesionActual.UsuarioActual.Nombre} {sesionActual.UsuarioActual.Apellido}");
            buffer.AppendLine("-----------------");
            if (sesionActual is SesionCabina)
            {
                SesionCabina auxSesionCabina = (SesionCabina)sesionActual;
                buffer.Append("TIPO DE LLAMADA: ");
                switch (auxSesionCabina.TipoLlamada)
                {
                    case Personas.ClienteDeTelefono.TipoLlamada.Local:
                        buffer.Append("LOCAL\n");
                        break;
                    case Personas.ClienteDeTelefono.TipoLlamada.LargaDistancia:
                        buffer.Append("LARGA DISTANCIA\n");
                        break;
                    case Personas.ClienteDeTelefono.TipoLlamada.Internacional:
                        buffer.Append("INTERNACIONAL\n");
                        break;
                }
            }
            buffer.AppendLine($"TIEMPO DE USO: {sesionActual.CalcularMinutosPasados()} minutos -------- ${sesionActual.CostoTotal}");
            if (sesionActual.CarritoDeCompras.Count > 0)
            {
                foreach (Consumible item in sesionActual.CarritoDeCompras)
                {
                    buffer.AppendLine($"{item.Nombre} ----------- ${item.Precio}");
                }
            }
            buffer.AppendFormat("\nCOSTO TOTAL CON I.V.A 21%: ----${0:0.00}", sesionActual.CostoFinal);

            return $"{buffer}";
        }

        private void BtnSobreFacturar_Click(object sender, EventArgs e)
        {
            ArchivosMedia.ReproducirSonidoSobreFactura();
            DialogResult resultado = MessageBox.Show("¿Seguro quiere sobrefacturar? Esto es moralmente reprochable y si el cliente se da cuenta se puede enojar", "Sobrefacturar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultado == DialogResult.Yes)
            {
                Random num = new Random();
                if (num.Next(0,2) > 0)// 1/2 de poder sobrefacturar
                {
                    sesionActual.CostoFinal *= 3;
                    rtbFactura.Text = ImprimirFactura();
                    ArchivosMedia.ReproducirSonidoSobreFactExitosa();
                    MessageBox.Show("¡Sobrefactura lograda exito! Se triplicó la facturación. El jefe y Lucifer estarán contentos.", "¡Excelente!");
                } else
                {
                    ArchivosMedia.ReproducirSonidoSobreFactFracasada();
                    MessageBox.Show("¡El cliente se dio cuenta! Para que no se enoje, no se le cobrará esta sesión", "¡Cáspita!");
                    sesionActual.CostoFinal = 0;
                    rtbFactura.Text = ImprimirFactura();
                }
            }
            btnSobreFacturar.Visible = false;
        }
    }
}
