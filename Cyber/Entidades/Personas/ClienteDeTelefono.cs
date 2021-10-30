using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    public sealed class ClienteDeTelefono : Cliente
    {
        private string telefonoAMarcar;
        
        public string Telefono
        {
            get
            {
                return this.telefonoAMarcar;
            }
            set
            {
                this.telefonoAMarcar = value;
            }
        }
        public ClienteDeTelefono(string nombre, string apellido, int edad, long dni) : base(nombre, apellido, edad, dni, TipoCliente.ClienteTelefono)
        {
            telefonoAMarcar = "";
            base.PuntosDeFelicidad = 1;
        }

        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();
            if (telefonoAMarcar != "")
            {
                buffer.Append($"Telefono discado: {this.telefonoAMarcar}");
            }
            
            return $"{base.MostrarCliente()} {buffer}";
        }
        
    }
}
