﻿using System;
using System.Text;
using System.Collections.Generic;

namespace Equipos
{
    public class Equipo
    {
        
        public enum TipoEquipo
        {
            Computadora, Cabina
        }

        private string id;
        private DateTime tiempoInicioUso;
        private DateTime tiempoFinUso;
        private TipoEquipo tipoDeEquipo;

        public TipoEquipo TipoDeEquipo
        {
            get
            {
                return this.tipoDeEquipo;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public DateTime TiempoInicioUso
        {
            get
            {
                return this.tiempoInicioUso;
            }
            set
            {
                this.tiempoInicioUso = value;
            }
        }
        public DateTime TiempoFinUso
        {
            get
            {
                return this.TiempoFinUso;
            }
            set
            {
                this.TiempoFinUso = value;
            }
        }

        public Equipo(string id, TipoEquipo tipoDeEquipo)
        {
            this.id = id;
            this.tiempoInicioUso = DateTime.MinValue;
            this.tiempoFinUso = DateTime.MaxValue;
            this.tipoDeEquipo = tipoDeEquipo;
        }
        public string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Id: #{this.id}");
            if (this.tiempoInicioUso != DateTime.MinValue)
            {
                buffer.AppendLine($"Tiempo inicio de uso: {this.tiempoInicioUso}");
            }

            return $"{buffer}";

        }

        public static bool operator ==(Equipo e1, Equipo e2)
        {
            return e1.id == e2.id;
        }

        public static bool operator !=(Equipo e1, Equipo e2)
        {
            return !(e1 == e2);
        }

        public static bool operator ==(Equipo e, string id)
        {
            return e.id == id;
        }

        public static bool operator !=(Equipo e, string id)
        {
            return !(e == id);
        }

    }

    public class Cabina : Equipo
    {
        public enum Tipo
        {
            A_Disco, Con_Teclado
        }

        private string id;
        private Tipo tipo;
        private string marca;
        


        public Cabina(string id, Tipo tipo, string marca) : base(id, TipoEquipo.Cabina)
        {
            this.tipo = tipo;
            this.marca = marca;
            

        }

        public new string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Tipo: {this.tipo}");
            buffer.AppendLine($"Marca: {this.marca}");

            return $"{base.Mostrar()}{buffer}";

        }



    }

    public class Computadora : Equipo
    {
        private List<string> software;
        private List<string> juegos;
        private List<string> perifericos;
        private string cpu;
        private string placaVideo;
        private string ram;
        
        
        
        public Computadora(string id, List<string> software, List<string> juegos, List<string> perifericos, string cpu, string placaVideo, string ram) : base(id, TipoEquipo.Computadora)
        {
            this.software = software;
            this.juegos = juegos;
            this.perifericos = perifericos;
            this.cpu = cpu;
            this.placaVideo = placaVideo;
            this.ram = ram;
            
        
        }
        public new string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();


            buffer.AppendLine($"Lista de Software: ");
            foreach (string item in this.software)
            {
                buffer.AppendLine(item);
            }
            buffer.AppendLine($"Lista de Juegos: ");
            foreach (string item in this.juegos)
            {
                buffer.AppendLine(item);
            }
            buffer.AppendLine($"Lista de Periféricos: ");
            foreach (string item in this.perifericos)
            {
                buffer.AppendLine(item);
            }
            buffer.AppendLine($"Cpu: {this.cpu}");
            buffer.AppendLine($"Placa de video: {this.placaVideo}");
            buffer.AppendLine($"Ram: {this.ram}");


            return $"{base.Mostrar()}{buffer}";
        }


        /// <summary>
        /// Carga datos en una lista de forma pseudo-aleatoria
        /// </summary>
        /// <param name="datos">el array de strings a cargar</param>
        /// <returns>Devuelve una lista con los datos cargados</returns>
        private static List<string> CargarDatos(string[] datos)
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



    }
}
