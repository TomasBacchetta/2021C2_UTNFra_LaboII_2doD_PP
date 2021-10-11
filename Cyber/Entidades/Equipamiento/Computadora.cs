using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;

namespace Equipos
{
    public class Computadora : Equipo
    {
        /// <summary>
        /// Software, juego y periféricos se guardan en Listas de strings ya que puede haber más de uno. En cambio los componentes al ser únicos, son strings. 
        /// Estos últimos también son "flavor", no son cruciales para el funcionamiento del programa
        /// </summary>
        private List<string> software;
        private List<string> juegos;
        private List<string> perifericos;
        private string cpu;
        private string placaVideo;
        private string ram;


        public override List<string> Software
        {
            get
            {
                return this.software;
            }
        }
        public override List<string> Juegos
        {
            get
            {
                return this.juegos;
            }
        }
        public override List<string> Perifericos
        {
            get
            {
                return this.perifericos;
            }
        }

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

            buffer.AppendLine($"------------");
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
        /// Determina si una computadora cumple con los requisitos de un usuario tanto en software como en juegos y perifercos.
        /// También se encarga de asignar los puntos de felicidad al cliente.
        /// </summary>
        /// <param name="comp">recibe un objeto equipo de tipo computadora</param>
        /// <param name="usuario">recibe un objeto cliente</param>
        /// <returns>verdadero o falso dependiendo el caso</returns>
        
        public static bool operator ==(Computadora comp, Cliente usuario)
        {
            bool matchJuegos = false;
            bool matchSoftware = false;
            bool matchPerifericos = false;

            ClienteDeComputadora auxUsuario = (ClienteDeComputadora)usuario;
            if (auxUsuario.JuegosFavoritos.Count > 0)
            {
                foreach (string juego in comp.juegos)
                {
                    if (auxUsuario.JuegosFavoritos.Contains(juego))
                    {
                        matchJuegos = true;
                        auxUsuario.PuntosDeFelicidad += 2;//aumenta la felicidad del usuario por cada match
                    }
                }
            } else
            {
                matchJuegos = true;//si no hay elementos favoritos de esa categoria, se ignora el match (se establece como true)
            }

            if (auxUsuario.ProgramasFavoritos.Count > 0)
            {
                foreach (string software in comp.software)
                {
                    if (auxUsuario.ProgramasFavoritos.Contains(software))
                    {
                        matchSoftware = true;//si no hay elementos favoritos de esa categoria, se ignora el match (se establece como true)
                        auxUsuario.PuntosDeFelicidad += 2;//aumenta la felicidad del usuario por cada match
                    }
                }
            } else
            {
                matchSoftware = true;
            }

            if (auxUsuario.PerifericosFavoritos.Count > 0)
            {
                foreach (string periferico in comp.perifericos)
                {
                    if (auxUsuario.PerifericosFavoritos.Contains(periferico))
                    {
                        matchPerifericos = true;//si no hay elementos favoritos de esa categoria, se ignora el match (se establece como true)
                        auxUsuario.PuntosDeFelicidad += 2;//aumenta la felicidad del usuario por cada match
                    }
                }
            } else
            {
                matchPerifericos = true;
            }
                
            if (matchJuegos && matchSoftware && matchPerifericos)
            {
                return true;
            } else
            {
                auxUsuario.PuntosDeFelicidad = 0;//hubo matches, pero no para todas las categorías, por ende la felicidad se anula.
                return false;
            }
           
        }


        public static bool operator !=(Computadora comp, Cliente usuario)
        {
            return !(comp == usuario);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
