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

        public enum TipoLlamadaCabina
        {
            Local, Todas
        }


        private Tipo tipo;
        private TipoLlamadaCabina tipoLlamadaCabina;
        private string marca;



        public Cabina(string id, Tipo tipo, string marca, TipoLlamadaCabina tipoLlamadaCabina) : base(id, TipoEquipo.Cabina)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.tipoLlamadaCabina = tipoLlamadaCabina;

        }

        public override string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Tipo: {this.tipo}");
            buffer.AppendLine($"Marca: {this.marca}");
            buffer.AppendLine($"Compatible con llamadas: ");
            buffer.AppendLine("Local");
            if (tipoLlamadaCabina == TipoLlamadaCabina.Todas)
            {
                buffer.AppendLine("Larga distancia");
                buffer.AppendLine("Internacional");
            }

            return $"{base.Mostrar()}{buffer}";

        }



    }
}
