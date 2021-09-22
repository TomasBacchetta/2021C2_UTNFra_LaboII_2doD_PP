using System;
using System.Collections.Generic;


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

            return $"{primerPrefijo}-{segundoPrefijo}-{rnd.Next(2000,9999)}-{rnd.Next(2000,9000)}";

        }
    }
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
