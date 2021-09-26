using System;
using System.Text;
using System.Collections.Generic;
using Personas;

namespace Equipos
{
    public class Equipo
    {
        
        public enum TipoEquipo
        {
            Computadora, Cabina
        }

        private string id;
        private TipoEquipo tipoDeEquipo;
        public bool enUso;
        

        

       
        public TipoEquipo TipoDeEquipo
        {
            get
            {
                return this.tipoDeEquipo;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }
        

        public Equipo(string id, TipoEquipo tipoDeEquipo)
        {
            this.id = id;
            this.tipoDeEquipo = tipoDeEquipo;
            this.enUso = false;
            
        }
        public virtual string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Id: #{this.id}");
            
           
            return $"{buffer}";

        }

        public static bool operator ==(Equipo e1, Equipo e2)
        {
            return e1.id == e2.id;
        }

        public static bool operator !=(Equipo e1, Equipo e2)
        {
            return !(e1 == e2);
        }

        public static bool operator ==(Equipo e, string id)
        {
            return e.id == id;
        }

        public static bool operator !=(Equipo e, string id)
        {
            return !(e == id);
        }
        
        

    }

}
