using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cpus : Carga
    {
        private string[] cpus = new string[]
        {
            "Pentium 4", "Athlon XP", "Pentium 3", "Sempron"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < cpus.Length)
                {
                    return cpus[indice];
                }
                else
                {
                    return cpus[0];
                }
            }
        }
        public string CargarDato()
        {
            return CargarDatoUnitario(cpus);
        }
    }
}
