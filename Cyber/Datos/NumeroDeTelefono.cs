using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class NumeroTelefono
    {
        /*
         Local: $1.00 por minuto. Se reconoce a una llamada como local cuando el prefijo contiene un '11' o '011' luego del código de país (54 - 11 - #### - ####).
            Larga distancia: $2.50 por minuto. Se reconoce a una llamada como de larga distancia cuando el prefijo contiene un número distinto de '11' o '011' luego del código de país (54 - #### - #### - ####).
            Internacional: $5.00 por minuto. Se reconoce a una llamada como de larga distancia cuando el código de país es distinto de '54'.
         */
        public string GenerarNumeroTelefono()
        {
            Random rnd = new Random();
            int primerPrefijo;
            int segundoPrefijo;

            if (rnd.Next(0, 5) > 3)// 1 en 5 chance de que sea internacional
            {
                primerPrefijo = rnd.Next(1, 99);
                segundoPrefijo = rnd.Next(1, 99);
            }
            else
            {
                primerPrefijo = 54;
                if (rnd.Next(0, 3) > 0)// 2 en 3 chance de que sea local
                {

                    segundoPrefijo = 11;
                }
                else
                {
                    segundoPrefijo = rnd.Next(9, 30);
                }

            }

            return $"{primerPrefijo}-{segundoPrefijo}-{rnd.Next(2000, 9999)}-{rnd.Next(2000, 9000)}";

        }
    }
}
