using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;
using Equipos;
using Entidades;

namespace Sesiones
{
    public class SesionComputadora : Sesion
    {
        private List<string> softwareUtilizado;
        private List<string> juegosUtilizados;
        private List<string> perifericosUtilizados;
        public override bool EnCurso
        {
            get
            {
                return base.enCurso;
            }
            set
            {
                if (value == false)//la sesion se crea con este atributo en true, por lo que una vez cambiado nunca podra volver a ser true
                {
                    double costoGolosinas = 0;
                    this.enCurso = value;
                    this.tiempoFinUso = DateTime.Now;
                    this.tiempoPasado = this.CalcularMinutosPasados();
                    this.costoTotal = this.CalcularCosto();
                    if (this.carritoDeCompras.Count > 0)
                    {
                        foreach (Consumible item in this.carritoDeCompras)
                        {
                            costoGolosinas += item.Precio;
                        }
                    }
                    this.costoFinal = (costoTotal + costoGolosinas)*1.21;

                }

            }
        }

        public List<string> SoftwareUtilizado
        {
            get
            {
                return this.softwareUtilizado;
            }
        }

        public List<string> JuegosUtilizados
        {
            get
            {
                return this.juegosUtilizados;
            }
        }

        public List<string> PerifericosUtilizados
        {
            get
            {
                return this.perifericosUtilizados;
            }
        }



        public SesionComputadora(Cliente usuarioActual, Equipo equipo, Efecto efectoActual) : base(usuarioActual, equipo, efectoActual)
        {
            this.softwareUtilizado = DeterminarProgramasUtilizados();
            this.juegosUtilizados = DeterminarJuegosUtilizados();
            this.perifericosUtilizados = DeterminarPerifericosUtilizados();
        }

        public override string MostrarSesion()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine("Tipo: COMPUTADORA");
            if (softwareUtilizado.Count > 0)
            {
                buffer.AppendLine($"Programas utilizados:");
                foreach (string programa in this.softwareUtilizado)
                {
                    buffer.AppendLine($"-{programa}");
                }
            }
            if (juegosUtilizados.Count > 0)
            {
                buffer.AppendLine($"Juegos utilizados:");
                foreach (string juego in this.juegosUtilizados)
                {
                    buffer.AppendLine($"-{juego}");
                }
            }
            if (perifericosUtilizados.Count > 0)
            {
                buffer.AppendLine($"Periféricos utilizados:");
                foreach (string periferico in this.perifericosUtilizados)
                {
                    buffer.AppendLine($"-{periferico}");
                }
            }
            
            return $"{base.MostrarSesion()} {buffer}";
        }
        /// <summary>
        /// Calcula la cantidad de bloques unitarios de 30 minutos redondeando para arriba y recibiendo los minutos (segundos en la vida real) transcurridos 
        /// </summary>
        /// <param name="tiempoMinRetorno"></param>
        /// <returns></returns>
        public static int CalcularBloqueDeTiempo(long tiempoMinRetorno)
        {
            float bloques = tiempoMinRetorno / 30F;
            int bloqueEntero = 0;

            if (tiempoMinRetorno > 0)
            {
                if (Math.Round(bloques) - bloques != 0 || bloques < 1)
                {
                    bloques++;
                    bloqueEntero = (int)bloques;
                }
            }
            return bloqueEntero;
        }
        public double CalcularCosto()
        {
            return CalcularBloqueDeTiempo(this.tiempoPasado) * 0.5F;
        }

        public List<string> DeterminarProgramasUtilizados()
        {
            List<string> programasUtilizados= new List<string>();
            ClienteDeComputadora auxClienteComp = (ClienteDeComputadora)usuarioActual;
            foreach (string program in auxClienteComp.ProgramasFavoritos)
            {
                if (this.equipoEnUso.Software.Contains(program))
                {
                    programasUtilizados.Add(program);
                }
            }

            return programasUtilizados;
        }

        public List<string> DeterminarJuegosUtilizados()
        {
            List<string> juegosUtilizados = new List<string>();
            ClienteDeComputadora auxClienteComp = (ClienteDeComputadora)usuarioActual;
            foreach (string juego in auxClienteComp.JuegosFavoritos)
            {
                if (this.equipoEnUso.Juegos.Contains(juego))
                {
                    juegosUtilizados.Add(juego);
                }
            }

            return juegosUtilizados;
        }

        public List<string> DeterminarPerifericosUtilizados()
        {
            List<string> perifericosUtilizados = new List<string>();
            ClienteDeComputadora auxClienteComp = (ClienteDeComputadora)usuarioActual;
            foreach (string periferico in auxClienteComp.PerifericosFavoritos)
            {
                if (this.equipoEnUso.Perifericos.Contains(periferico))
                {
                    perifericosUtilizados.Add(periferico);
                }
            }

            return perifericosUtilizados;
        }

        


    }
}
