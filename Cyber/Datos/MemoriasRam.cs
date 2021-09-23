using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MemoriasRam : Carga
    {
        private string[] memoriasRam = new string[]
        {
            "512 mb", "256 mb", "128 mb"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < memoriasRam.Length)
                {
                    return memoriasRam[indice];
                }
                else
                {
                    return memoriasRam[0];
                }
            }
        }

        public string CargarDato()
        {
            return CargarDatoUnitario(memoriasRam);
        }
    }
}
