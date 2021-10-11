using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;


namespace Equipos
{
    public class Cabina : Equipo
    {
        //esto esta sólo como "flavor". No es una característica crucial de un teléfono
        public enum Tipo
        {
            A_Disco, Con_Teclado
        }
        /// <summary>
        /// si bien son 3 tipos de llamadas, se considera que un teléfono o es local, o los 3 al mismo tiempo
        /// </summary>
        public enum TipoLlamadaCabina
        {
            Local, Todas
        }


        private Tipo tipo;
        private TipoLlamadaCabina tipoLlamadaCabina;
        private string marca;//la marca del teléfono también es "flavor"



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
        /// <summary>
        /// Una cabina es igual a un cliente cuando concuerda su tipo de llamada, en cuanto a todos, o a local
        /// </summary>
        /// <param name="cabina">recibe el objeto cabina</param>
        /// <param name="cliente">recibe un objeto cliente</param>
        /// <returns>devuelve verdadero o falso si se cumple la condición</returns>
        public static bool operator ==(Cabina cabina, Cliente cliente)
        {
            ClienteDeTelefono auxUsuario = (ClienteDeTelefono)cliente;
            if (auxUsuario.TipoDeLlamada == ClienteDeTelefono.TipoLlamada.Local)
            {
                return true;
            }
            if ((auxUsuario.TipoDeLlamada == ClienteDeTelefono.TipoLlamada.LargaDistancia || auxUsuario.TipoDeLlamada == ClienteDeTelefono.TipoLlamada.Internacional)&& cabina.tipoLlamadaCabina == TipoLlamadaCabina.Todas)
            {
                return true;
            }

            return false;
            

        }

        public static bool operator !=(Cabina cabina, Cliente cliente)
        {
            return !(cabina == cliente);
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
