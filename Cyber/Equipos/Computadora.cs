﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;

namespace Equipos
{
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
        public override string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();


            buffer.AppendLine($"Lista de Software: ");
            foreach (string item in this.software)
            {
                buffer.AppendLine(item);
            }
            buffer.Append($"------\n");
            buffer.AppendLine($"Lista de Juegos: ");
            foreach (string item in this.juegos)
            {
                buffer.AppendLine(item);
            }
            buffer.Append($"------\n");
            buffer.AppendLine($"Lista de Periféricos: ");
            foreach (string item in this.perifericos)
            {
                buffer.AppendLine(item);
            }
            buffer.Append($"------\n");
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

        public static bool operator ==(Computadora comp, Cliente usuario)
        {
            bool matchJuegos = false;
            bool matchSoftware = false;
            bool matchPerifericos = false;

            ClienteDeComputadora auxUsuario = (ClienteDeComputadora)usuario;
            foreach (string juego in comp.juegos)
            {
                if (auxUsuario.JuegosFavoritos.Contains(juego))
                {
                    matchJuegos = true;
                }
            }
            foreach (string software in comp.software)
            {
                if (auxUsuario.ProgramasFavoritos.Contains(software))
                {
                    matchSoftware = true;
                }
            }
            foreach (string periferico in comp.perifericos)
            {
                if (auxUsuario.PerifericosFavoritos.Contains(periferico))
                {
                    matchPerifericos = true;
                }
            }

            return matchJuegos && matchSoftware && matchPerifericos;
        }

        public static bool operator !=(Computadora comp, Cliente usuario)
        {
            return !(comp == usuario);
        }

    }
}
