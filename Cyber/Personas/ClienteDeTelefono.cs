using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    public class ClienteDeTelefono : Cliente
    {

        private string telefono;

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
        }

        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Teléfono a marcar: {this.telefono}");


            return $"{base.MostrarCliente()}{buffer}";
        }
    }
}
