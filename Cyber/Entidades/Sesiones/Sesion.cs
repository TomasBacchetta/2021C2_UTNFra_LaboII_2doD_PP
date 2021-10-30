using System;
using Personas;
using Equipos;
using System.Text;
using System.Collections.Generic;
using static Personas.ClienteDeTelefono;
using Entidades;
using static Entidades.Consumible;

namespace Sesiones
{
    public abstract class Sesion
    {

        public enum Efecto
        {
            Ninguno, BebidaChina, Tabaco, Alcoholismo
        }
        protected Cliente usuarioActual;
        protected Equipo equipoEnUso;
        protected DateTime tiempoInicio;
        protected DateTime tiempoFinUso;
        protected long tiempoPasado;
        protected double costoTotal;
        protected double costoFinal;
        protected bool enCurso;
        protected List<Consumible> carritoDeCompras;//aquí se almacenan los productos comprados
        protected Efecto efectoActual;
        

        public double CostoFinal
        {
            get
            {
                return this.costoFinal;
            }
            set
            {
                this.costoFinal = value;
            }
        }
        public Efecto EfectoActual
        {
            get
            {
                return this.efectoActual;
            }
            set
            {
                this.efectoActual = value;
            }
        }
        public List<Consumible> CarritoDeCompras
        {
            get
            {
                return this.carritoDeCompras;
            }
            
        }
        public Equipo Equipo
        {
            get
            {
                return equipoEnUso;
            }
        }

        public string IdEquipo
        {
            get
            {
                return this.Equipo.Id;
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
                return this.tiempoFinUso;
            }
            set
            {
                this.tiempoFinUso = value;
                
            }
        }

        public long TiempoPasado
        {
            get
            {
                return this.tiempoPasado;
            }
        }

       
        public abstract bool EnCurso { get; set; }

        public abstract double CalcularCosto();
       
        
        public Sesion(Cliente usuarioActual, Equipo equipoEnUso, Efecto efectoActual)
        {
            this.usuarioActual = usuarioActual;
            this.equipoEnUso = equipoEnUso;
            this.tiempoInicio = DateTime.Now;
            this.tiempoFinUso = DateTime.MaxValue;
            this.tiempoPasado = 0;
            this.enCurso = true;
            this.carritoDeCompras = new List<Consumible>();
            this.costoTotal = 0;
            this.costoFinal = 0;
            this.efectoActual = efectoActual;
        }

        public virtual string MostrarSesion()
        {
            StringBuilder buffer = new StringBuilder();
            
            buffer.AppendLine($"Usuario: {this.usuarioActual.Nombre} {this.usuarioActual.Apellido}");
            buffer.AppendLine($"Id Equipo: {this.IdEquipo}");
            if (this.enCurso == false)
            {
                buffer.AppendLine($"Duración de la sesión: {this.tiempoPasado} minutos");
                buffer.AppendFormat("\nMonto facturado: ${0:0.00}\n", this.CostoFinal);
            }
            if (carritoDeCompras.Count > 0)
            {
                buffer.AppendLine("Productos comprados");
                foreach (Consumible item in this.carritoDeCompras)
                {
                    buffer.AppendLine($"-{item.Nombre}");
                }
                
            }
            if (this.efectoActual != Efecto.Ninguno && this.enCurso)
            {
                buffer.AppendLine("**EFECTOS ACTIVOS**:");
                switch (this.efectoActual)
                {
                    case Efecto.BebidaChina:
                        buffer.AppendLine("-BEBIDA CHINA MAS BARATA");
                        break;
                    case Efecto.Alcoholismo:
                        buffer.AppendLine("-POSIBILIDAD DE SOBREFACTURAR POR ESTAR EMBRIAGADO");
                        break;
                    case Efecto.Tabaco:
                        buffer.AppendLine("-REDUCCION DE FELICIDAD POR TABACO");
                        break;
                }
            }
            
            return $"{buffer}";
        }

        /// <summary>
        /// calcula los minutos pasados en base a la diferencia de dos datetime
        /// </summary>
        /// <returns>devuelve el tiempo en minutos (segundos reales)</returns>
        public long CalcularMinutosPasados()
        {
            long tiempoMinReal;
            long tiempoSegReal;
            long tiempoMinRetorno;

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
        /// <summary>
        /// determina si un carrito ya tiene un producto en base a su tipo
        /// </summary>
        /// <param name="tipo">recibe el tipo de producto</param>
        /// <returns>devuelve true si esta, false si no</returns>
        public bool DeterminarSiCarritoYaTieneUnProducto(TipoConsumible tipo)
        {
            foreach (Consumible item in this.carritoDeCompras)
            {
                if (item.Tipo == tipo)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Devuelve un string con todos los datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarSesion();
        }


    }
    
   

    
}
