using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipos
{
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

        public override string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Tipo: {this.tipo}");
            buffer.AppendLine($"Marca: {this.marca}");

            return $"{base.Mostrar()}{buffer}";

        }



    }
}
