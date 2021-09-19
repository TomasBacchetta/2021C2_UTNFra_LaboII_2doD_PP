using System;
using System.Collections.Generic;

/*

private static string[] listaRam = new string[] { "512 mb", "256 mb", "128 mb" };

 */
namespace Datos
{
    public class Programas:Carga
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
                } else
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

    public class PlacasDeVideo:Carga
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

    public class MemoriasRam:Carga
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

    public class MarcasTelefono:Carga
    {
        private string[] marcasTelefono = new string[]
        {
            "Toshiba", "General Electric", "Philips", "Motorola"
        };

        public string this[int indice]
        {
            get
            {
                if (indice > 0 && indice < marcasTelefono.Length)
                {
                    return marcasTelefono[indice];
                }
                else
                {
                    return marcasTelefono[0];
                }
            }
        }

        public string CargarDato()
        {
            return CargarDatoUnitario(marcasTelefono);
        }
    }


    public class Carga
    {
        public static List<string> CargarDatosLista(string[] datos)
        {
            List<string> lista = new List<string>();
            Random numRandom = new Random();
            bool yaEsta = false;

            for (int x = 0; x < numRandom.Next(1, datos.Length + 1); x++)
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
