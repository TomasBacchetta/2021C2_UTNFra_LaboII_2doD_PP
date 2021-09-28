using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    public class ClienteDeComputadora : Cliente
    {
        private List<string> juegosFavoritos;
        private List<string> programasFavoritos;
        private List<string> perifericosFavoritos;


        public override List<string> JuegosFavoritos
        {
            get
            {
                return this.juegosFavoritos;
            }
        }

        public override List<string> ProgramasFavoritos
        {
            get
            {
                return this.programasFavoritos;
            }
        }

        public override List<string> PerifericosFavoritos
        {
            get
            {
                return this.perifericosFavoritos;
            }
        }

        public ClienteDeComputadora(string nombre, string apellido, long documento, List<string> juegosFavoritos, List<string> programasFavoritos, List<string> perifericosFavoritos) : base(nombre, apellido, documento, TipoCliente.ClienteComputadora)
        {
            this.juegosFavoritos = juegosFavoritos;
            this.programasFavoritos = programasFavoritos;
            this.perifericosFavoritos = perifericosFavoritos;
        }

        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"\nProgramas favoritos:");
            foreach (string item in this.programasFavoritos)
            {
                buffer.AppendLine($"{item} ");
            }
            buffer.Append($"------\n");
            buffer.AppendLine($"Juegos favoritos:");
            foreach (string item in this.juegosFavoritos)
            {
                buffer.AppendLine($"{item} ");
            }
            buffer.Append($"-------\n");
            buffer.AppendLine($"Periféricos favoritos:");
            foreach (string item in this.perifericosFavoritos)
            {
                buffer.AppendLine($"{item} ");
            }


            return $"{base.MostrarCliente()}\n{buffer}";
        }


    }
}
