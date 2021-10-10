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
        public FrmFactura(Sesion sesionActual)
        {
            InitializeComponent();
            this.sesionActual = sesionActual;
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

            buffer.AppendLine("CYBER SRL");
            buffer.AppendLine("-----------------");
            buffer.AppendLine($"ID EQUIPO: {sesionActual.Equipo.Id}");
            buffer.AppendLine("TIPO: ");
            if (sesionActual.Equipo.TipoDeEquipo == Equipos.Equipo.TipoEquipo.Computadora)
            {
                buffer.Append("COMPUTADORA");
            } else
            {
                buffer.Append("CABINA TELEFÓNICA");
            }
            buffer.AppendLine($"\nUSUARIO: {sesionActual.UsuarioActual.Nombre} {sesionActual.UsuarioActual.Apellido}");
            buffer.AppendLine("-----------------");
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
    }
}
