using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ApellidosPersonas : Carga
    {
        private string[] apellidosPersonas = new string[]
        {
            "Ruiz","Peretti","Fernández","Santos","Lampone","Medina","Rago","Roth","Ibn Batutta","Corsi","Rossi","Russo","Mamani"
            ,"Quispe","Rodríguez","Tazzone","Rosatti","Bertone","Posca","Smith","Barclay","Guzmán","Fritz","De León","Bagratión","Flores"
            ,"Jiménez","Blanco","Negri","Bustamante","Cázeres","López","Ramírez","García","Corleone","Sánchez","Roy","Tumini","Mosca"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < apellidosPersonas.Length)
                {
                    return apellidosPersonas[indice];
                }
                else
                {
                    return apellidosPersonas[0];
                }

            }

        }
        public string CargarDatos()
        {
            return CargarDatoUnitario(apellidosPersonas);
        }
    }
}
