using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    public class ClienteDeTelefono : Cliente
    {
        public enum TipoLlamada
        {
            Local, LargaDistancia, Internacional
        }

        private string telefono;
        private TipoLlamada tipoLlamada;

        public override TipoLlamada TipoDeLlamada
        {
            get
            {
                return this.tipoLlamada;
            }
        }

        public string Telefono
        {
            get
            {
                return this.telefono;
            }
        }
        public ClienteDeTelefono(string nombre, string apellido, long dni, string telefono) : base(nombre, apellido, dni, TipoCliente.ClienteTelefono)
        {
            this.telefono = telefono;
            this.tipoLlamada = this.DeterminarTipoDeLlamada();
            base.PuntosDeFelicidad = 1;
        }

        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Teléfono a marcar: {this.telefono}");
            buffer.AppendLine($"Tipo de llamada: {this.tipoLlamada}");


            return $"{base.MostrarCliente()}{buffer}";
        }

        private TipoLlamada DeterminarTipoDeLlamada()
        {
            string telefono = this.telefono;

            if ($"{telefono[0]}{telefono[1]}" == "54")
            {
                if ($"{telefono[3]}{telefono[4]}" == "11")
                {
                    return TipoLlamada.Local;
                }
                return TipoLlamada.LargaDistancia;
            }
            else
            {
                return TipoLlamada.Internacional;
            }
        }
    }
}
