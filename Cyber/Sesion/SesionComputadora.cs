using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;
using Equipos;


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
                    this.enCurso = value;
                    this.tiempoFinUso = DateTime.Now;
                    this.costoTotal = this.CalcularCosto();
                }

            }
        }

        public SesionComputadora(Cliente usuarioActual, Equipo equipo) : base(usuarioActual, equipo)
        {
            this.softwareUtilizado = DeterminarProgramasUtilizados();
            this.juegosUtilizados = DeterminarJuegosUtilizados();
            this.perifericosUtilizados = DeterminarPerifericosUtilizados();
        }

        public override string MostrarSesion()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"Programas utilizados:");
            foreach (string programa in this.softwareUtilizado)
            {
                buffer.AppendLine($"-{programa}");
            }
            
            buffer.AppendLine($"Juegos utilizados:");
            foreach (string juego in this.juegosUtilizados)
            {
                buffer.AppendLine($"-{juego}");
            }
            buffer.AppendLine($"Periféricos utilizados:");
            foreach (string periferico in this.perifericosUtilizados)
            {
                buffer.AppendLine($"-{periferico}");
            }
            return $"{base.MostrarSesion()} {buffer}";
        }
        public double CalcularCosto()
        {
            return base.CalcularMinutosPasados() * 0.5F;
        }

        public List<string> DeterminarProgramasUtilizados()
        {
            List<string> programasUtilizados= new List<string>();

            foreach (string program in this.usuarioActual.ProgramasFavoritos)
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

            foreach (string juego in this.usuarioActual.JuegosFavoritos)
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

            foreach (string periferico in this.usuarioActual.PerifericosFavoritos)
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
