using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;
using Equipos;
using static Personas.ClienteDeTelefono;

namespace Sesiones
{
    public class SesionCabina : Sesion
    {

        private TipoLlamada tipoLlamada;
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
                    this.tiempoPasado = this.CalcularMinutosPasados();
                    this.costoTotal = this.CalcularCosto();
                    
                    
                }

            }
        }

        public override TipoLlamada TipoLlamada
        {
            get
            {
                return this.tipoLlamada;
            }
        }

       

        public SesionCabina(Cliente usuarioActual, Equipo equipo) : base(usuarioActual, equipo)
        {
            this.tipoLlamada = usuarioActual.TipoDeLlamada;
        }

        public override string MostrarSesion()
        {
            StringBuilder buffer = new StringBuilder();

            ClienteDeTelefono auxUsuario = (ClienteDeTelefono)this.UsuarioActual;
            buffer.AppendLine("Tipo: CABINA TELEFÓNICA");
            buffer.AppendLine($"Número marcado: {auxUsuario.Telefono}");
            buffer.AppendLine($"Tipo de llamada: {this.tipoLlamada}");

            return $"{base.MostrarSesion()} {buffer}";
        }
        public double CalcularCosto()
        {
            double multiplicador = 0;

            switch (this.usuarioActual.TipoDeLlamada)
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
            return this.tiempoPasado * multiplicador;
        }
       
    }
}
