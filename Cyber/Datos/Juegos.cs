using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Juegos : Carga
    {
        private string[] juegos = new string[]
        {
            "Counter-Strike", "Diablo II", "Argentum", "Sven Co-op", "Age of Empires II", "Starcraft"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < juegos.Length)
                {
                    return juegos[indice];
                }
                else
                {
                    return juegos[0];
                }
            }
        }
        public List<string> CargarDatos()
        {
            return CargarDatosLista(juegos);
        }


    }
}
