using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Programas : Carga
    {
        private string[] programas = new string[]
        {
            "Office", "Messenger", "ICQ", "Ares"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < programas.Length)
                {
                    return programas[indice];
                }
                else
                {
                    return programas[0];
                }

            }

        }
        public List<string> CargarDatos()
        {
            return CargarDatosLista(programas);
        }


    }
}
