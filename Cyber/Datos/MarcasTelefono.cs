using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MarcasTelefono : Carga
    {
        private string[] marcasTelefono = new string[]
        {
            "Toshiba", "General Electric", "Philips", "Motorola"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < marcasTelefono.Length)
                {
                    return marcasTelefono[indice];
                }
                else
                {
                    return marcasTelefono[0];
                }
            }
        }

        public string CargarDato()
        {
            return CargarDatoUnitario(marcasTelefono);
        }
    }
}
