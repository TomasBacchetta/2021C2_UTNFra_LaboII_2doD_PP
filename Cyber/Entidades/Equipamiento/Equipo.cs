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
        /// <summary>
        /// este es un enumerado de efectos que pueden alterar el funcionamiento de un equipo
        /// Funciona en tándem junto con los efectos de sesiones, pero no posee el del alcohol porque en ese
        /// caso solo la sesion del cliente que compró el producto se ve afectada
        /// </summary>
        public enum Efecto
        {
            Ninguno, BebidaChina, Tabaco
        }

        private string id;
        private TipoEquipo tipoDeEquipo;
        private bool enUso;
        private Efecto efectoDeLaMaquina;

        

        public Efecto EfectoDeLaMaquina
        {
            get
            {
                return this.efectoDeLaMaquina;
            }
            set
            {
                this.efectoDeLaMaquina = value;
            }
        }
        public bool EnUso
        {
            get
            {
                return this.enUso;
            }
            set
            {
                this.enUso = value;
            }
        }

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
            this.efectoDeLaMaquina = Efecto.Ninguno;
            
        }
        public virtual string Mostrar()
        {
            StringBuilder buffer = new StringBuilder();
            
            if (this.enUso == true)
            {
                buffer.AppendLine($"***EN USO***");
            }
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
            hash.Add(id);
            return hash.ToHashCode();
        }
        /// <summary>
        /// Devuelve un string con todos los datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
    }

}
