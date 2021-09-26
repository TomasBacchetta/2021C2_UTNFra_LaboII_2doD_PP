using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class NombresPersonas : Carga
    {
        private string[] nombresPersonas = new string[]
        {
            "Tomás","Juan","Pedro","Leandro","Lautaro","Maximiliano","Juan Francisco","Ramón","Florencia","Anna","Horacio","Pablo","Jorge"
            ,"Ricardo","Jorgelina","Jesús","Johnny","Sergio","Esteban","Gustavo","Simón","Artemio","Néstor","León","Catalina","Rodrigo"
            ,"Fernando","Norma","Agustina","Cristina","Germán","Brian","José","Jorge","Mauricio","José Luis","Federico","Silvia","Claudia"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < nombresPersonas.Length)
                {
                    return nombresPersonas[indice];
                }
                else
                {
                    return nombresPersonas[0];
                }

            }

        }
        public string CargarDatos()
        {
            return CargarDatoUnitario(nombresPersonas);
        }
    }
}
