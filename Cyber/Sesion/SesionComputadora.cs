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
                    base.enCurso = value;
                    base.tiempoFinUso = DateTime.Now;
                    base.costoTotal = this.CalcularCosto();
                }

            }
        }

         

        public SesionComputadora(Cliente usuarioActual, string idEquipo) : base(usuarioActual, idEquipo)
        {

        }

        public override string MostrarSesion()
        {
            

            return $"{base.MostrarSesion()}";
        }
        public double CalcularCosto()
        {
            return base.CalcularMinutosPasados() * 0.5F;
        }


    }
}
