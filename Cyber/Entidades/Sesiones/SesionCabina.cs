using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas;
using Equipos;
using static Personas.ClienteDeTelefono;
using Entidades;

namespace Sesiones
{
    public sealed class SesionCabina : Sesion
    {

        private Cabina.TipoLlamadaTelefono tipoLlamada;
        /// <summary>
        /// el apartado set de la propiedad EnCurso se encarga de capturar el tiempo en que se cerro la sesion
        /// calcula el tiempo pasado
        /// y calcula los costos
        /// </summary>
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
                    double costoGolosinas = 0;
                    
                    this.enCurso = value;
                    this.tiempoFinUso = DateTime.Now;
                    this.tiempoPasado = this.CalcularMinutosPasados();
                    this.costoTotal = this.CalcularCosto();
                    
                    //agrega los costos de los productos del carrito de compras si es que hay
                    if (this.carritoDeCompras.Count > 0)
                    {
                        foreach(Consumible item in this.carritoDeCompras)
                        {
                            costoGolosinas += item.Precio;
                        }
                    }
                    this.costoFinal = (costoTotal + costoGolosinas)*1.21;///el costo final contempla el iva
                     



                }

            }
        }

        public Cabina.TipoLlamadaTelefono TipoLlamada
        {
            get
            {
                return this.tipoLlamada;
            }
        }

       
        public SesionCabina(Cliente usuarioActual, Equipo equipo, Efecto efectoActual) : base(usuarioActual, equipo, efectoActual)
        {
            ClienteDeTelefono auxClienteTel = (ClienteDeTelefono)usuarioActual;
            this.tipoLlamada = Cabina.DeterminarTipoDeLlamada(auxClienteTel.Telefono);
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
        /// <summary>
        /// calcula el costo de la llamada en base a su tipo
        /// </summary>
        /// <returns>devuelve el costo resultante</returns>
        public override double CalcularCosto()
        {
            double multiplicador = 0;
            ClienteDeTelefono auxClienteTel = (ClienteDeTelefono)usuarioActual;
            switch (Cabina.DeterminarTipoDeLlamada(auxClienteTel.Telefono))
            {
                case Cabina.TipoLlamadaTelefono.Local:
                    multiplicador = 1;
                    break;
                case Cabina.TipoLlamadaTelefono.LargaDistancia:
                    multiplicador = 2.5;
                    break;
                case Cabina.TipoLlamadaTelefono.Internacional:
                    multiplicador = 5;
                    break;
            }
            return this.tiempoPasado * multiplicador;
        }
       
    }
}
