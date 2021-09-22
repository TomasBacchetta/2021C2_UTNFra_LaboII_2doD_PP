using System;
using Personas;
using Equipos;

namespace Sesiones
{
    public class Sesion
    {
        private Cliente usuarioActual;
        private string idEquipo;
        protected DateTime tiempoInicio;
        protected DateTime tiempoFinUso;
        protected double costoTotal;
        protected bool enCurso;


        public string IdEquipo
        {
            get
            {
                return this.idEquipo;
            }
        }
        public Cliente UsuarioActual
        {
            get
            {
                return this.usuarioActual;
            }
        }
        public double CostoTotal
        {
            get
            {
                return this.costoTotal;
            }
            set
            {
                
            }
        }
        public DateTime TiempoInicio
        {
            get
            {
                return this.tiempoInicio;
            }
            set
            {
                this.tiempoInicio = value;
            }
        }
        public DateTime TiempoFin
        {
            get
            {
                return this.TiempoFin;
            }
            set
            {
                this.TiempoFin = value;
            }
        }
        
        public virtual bool EnCurso
        {
            get
            {
                return this.enCurso;
            }
            set
            {
                if (value == false)//la sesion se crea con este atributo en true, por lo que una vez cambiado nunca podra volver a ser true
                {
                    this.enCurso = value;
                    this.tiempoFinUso = DateTime.Now;
                    
                }

            }
        }
        
        public Sesion(Cliente usuarioActual, string idEquipo)
        {
            this.usuarioActual = usuarioActual;
            this.idEquipo = idEquipo;
            this.tiempoInicio = DateTime.Now;
            this.tiempoFinUso = DateTime.MaxValue;
            this.enCurso = true;
            costoTotal = 0;
        }


        public double CalcularMinutosPasados()
        {
            long tiempoMinReal;
            long tiempoSegReal;

            tiempoMinReal = this.tiempoFinUso.Minute - this.tiempoInicio.Minute;
            tiempoSegReal = this.tiempoFinUso.Second - this.tiempoInicio.Second;

            if (tiempoMinReal < 0)
            {
                tiempoMinReal += 60;
            }
            if (tiempoSegReal < 0)
            {
                tiempoSegReal += 60;
            }
            tiempoSegReal += tiempoMinReal * 60;

            return tiempoSegReal;
        }

        
        
        

    }
    
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


        public SesionComputadora(Cliente usuarioActual, string idEquipo):base(usuarioActual, idEquipo)
        {

        }
        public double CalcularCosto()
        {
            return base.CalcularMinutosPasados() * 0.5F;
        }


    }

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
                    base.enCurso = value;
                    base.tiempoFinUso = DateTime.Now;
                    base.costoTotal = this.CalcularCosto();
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
