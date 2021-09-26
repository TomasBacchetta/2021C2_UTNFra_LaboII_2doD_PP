using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Perifericos : Carga
    {
        private string[] perifericos = new string[]
        {
            "Web-Cam", "Conector USB", "Impresora", "Escáner"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < perifericos.Length)
                {
                    return perifericos[indice];
                }
                else
                {
                    return perifericos[0];
                }
            }
        }
        public List<string> CargarDatos()
        {
            return CargarDatosLista(perifericos);
        }


    }
}
