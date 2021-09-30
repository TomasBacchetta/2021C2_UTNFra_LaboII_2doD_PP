using System;
using System.Collections.Generic;


namespace Datos
{
    public class Carga
    {

        
        public static List<string> CargarDatosLista(string[] datos)
        {
            List<string> lista = new List<string>();
            Random numRandom = new Random();
            bool yaEsta = false;

            for (int x = 0; x < numRandom.Next(1, datos.Length*2); x++)
            {
                int indice = numRandom.Next(0, datos.Length);
                if (lista.Count == 0)
                {
                    lista.Add(datos[indice]);
                }
                else
                {
                    foreach (string item in lista)
                    {
                        if (item == datos[indice])
                        {
                            yaEsta = true;
                            break;
                        }

                    }
                    if (!yaEsta)
                    {
                        lista.Add(datos[indice]);
                    }
                }
            }
            return lista;
        }

       

        public static string CargarDatoUnitario(string[] datos)
        {
            Random numRandom = new Random();

            return datos[numRandom.Next(0, datos.Length)];

            
        }

        
    }

}
