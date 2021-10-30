using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;


namespace Equipos
{
    public sealed class Cabina : Equipo
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

        public enum TipoLlamadaTelefono
        {
            Local, LargaDistancia, Internacional
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
            if (!string.IsNullOrEmpty(auxUsuario.Telefono))
            {
                if (DeterminarTipoDeLlamada(auxUsuario.Telefono) == TipoLlamadaTelefono.Local)
                {
                    return true;
                }
                if ((DeterminarTipoDeLlamada(auxUsuario.Telefono) == TipoLlamadaTelefono.LargaDistancia || DeterminarTipoDeLlamada(auxUsuario.Telefono) == TipoLlamadaTelefono.Internacional) && cabina.tipoLlamadaCabina == TipoLlamadaCabina.Todas)
                {
                    return true;
                }
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
            HashCode hash = new HashCode();
            hash.Add(base.Id);
            return hash.ToHashCode();
        }

        /// <summary>
        /// Determina el tipo de llamad en base al numero de telefono generado aleatoriamente
        /// es la forma ideal de hacerlo si eventualmente se pudiese cargar a mano el número
        /// </summary>
        /// <returns></returns>
        public static TipoLlamadaTelefono DeterminarTipoDeLlamada(string telIngresado)
        {
            string telefono = telIngresado;

            if ($"{telefono[0]}{telefono[1]}" == "54")
            {
                if ($"{telefono[2]}{telefono[3]}" == "11")
                {
                    return TipoLlamadaTelefono.Local;
                }
                return TipoLlamadaTelefono.LargaDistancia;
            }
            else
            {
                return TipoLlamadaTelefono.Internacional;
            }
        }
    }
}
