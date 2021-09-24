using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;
using Equipos;

namespace Sesiones
{
    public class SesionCabina : Sesion
    {
        public enum TipoLlamada
        {
            Local, LargaDistancia, Internacional
        }

        private TipoLlamada tipoDeLlamada;
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
                    this.tipoDeLlamada = this.DeterminarTipoDeLlamada();
                }

            }


        }


        public SesionCabina(Cliente usuarioActual, string idEquipo) : base(usuarioActual, idEquipo)
        {

        }
        public double CalcularCosto()
        {
            double multiplicador = 0;

            switch (this.tipoDeLlamada)
            {
                case TipoLlamada.Local:
                    multiplicador = 1;
                    break;
                case TipoLlamada.LargaDistancia:
                    multiplicador = 2.5;
                    break;
                case TipoLlamada.Internacional:
                    multiplicador = 5;
                    break;
            }
            return base.CalcularMinutosPasados() * multiplicador;
        }

        public TipoLlamada DeterminarTipoDeLlamada()
        {
            ClienteDeTelefono auxUsuario = (ClienteDeTelefono)this.UsuarioActual;

            string telefono = auxUsuario.Telefono;

            if ($"{telefono[0]}{telefono[1]}" == "54")
            {
                if ($"{telefono[3]}{telefono[4]}" == "11")
                {
                    return TipoLlamada.Local;
                }
                return TipoLlamada.LargaDistancia;
            }
            else
            {
                return TipoLlamada.Internacional;
            }
        }
    }
}
