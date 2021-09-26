using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PlacasDeVideo : Carga
    {
        private string[] placasDeVideo = new string[]
        {
            "3dfx Voodoo 5", "Nvidia GeForce 4", "Ati Radeon 6800", "Nvidia GeForce 5000"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < placasDeVideo.Length)
                {
                    return placasDeVideo[indice];
                }
                else
                {
                    return placasDeVideo[0];
                }
            }
        }
        public string CargarDato()
        {
            return CargarDatoUnitario(placasDeVideo);
        }

    }
}
