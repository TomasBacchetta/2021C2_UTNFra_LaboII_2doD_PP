using System;
using Personas;
using Equipos;
using System.Text;

namespace Sesiones
{
    public abstract class Sesion
    {
        protected Cliente usuarioActual;
        protected string idEquipo;
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
        
        public abstract bool EnCurso { get; set; }
       
        
        public Sesion(Cliente usuarioActual, string idEquipo)
        {
            this.usuarioActual = usuarioActual;
            this.idEquipo = idEquipo;
            this.tiempoInicio = DateTime.Now;
            this.tiempoFinUso = DateTime.MaxValue;
            this.enCurso = true;
            costoTotal = 0;
        }

        public virtual string MostrarSesion()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Id Equipo: {this.idEquipo}");
            buffer.AppendLine($"Usuario: {this.usuarioActual.Nombre} {this.usuarioActual.Apellido}");
            buffer.AppendLine($"Duración de la sesión: {this.CalcularMinutosPasados()} minutos");
            buffer.AppendLine($"Monto facturado: ${this.costoTotal}");
            

            return $"{buffer}";
        }


        public double CalcularMinutosPasados()
        {
            long tiempoMinReal;
            long tiempoSegReal;
            long tiempoMinRetorno = 0;

            tiempoMinReal = this.tiempoFinUso.Minute - this.tiempoInicio.Minute;
            tiempoSegReal = this.tiempoFinUso.Second - this.tiempoInicio.Second;

            if (tiempoMinReal < 0)
            {
                tiempoMinReal += 60;
            }
            if (tiempoSegReal < 0)
            {
                tiempoSegReal += 60;
                tiempoMinReal -= 1;
            }
            tiempoMinRetorno = tiempoSegReal + tiempoMinReal * 60;

            return tiempoMinRetorno;
        }

        
        
        

    }
    
   

    
}
