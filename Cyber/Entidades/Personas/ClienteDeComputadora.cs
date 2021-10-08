using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Personas
{
    public class ClienteDeComputadora : Cliente
    {
        private List<string> juegosFavoritos;
        private List<string> programasFavoritos;
        private List<string> perifericosFavoritos;


        public override List<string> JuegosFavoritos
        {
            get
            {
                return this.juegosFavoritos;
            }
        }

        public override List<string> ProgramasFavoritos
        {
            get
            {
                return this.programasFavoritos;
            }
        }

        public override List<string> PerifericosFavoritos
        {
            get
            {
                return this.perifericosFavoritos;
            }
        }

        
        //constructores de cliente de computadora con sobrecarga 
        public ClienteDeComputadora(string nombre, string apellido, long documento, Carga datos1) : base(nombre, apellido, documento, TipoCliente.ClienteComputadora)
        {
            

            if (datos1 is Juegos)
            {
                this.juegosFavoritos = ((Juegos)datos1).CargarDatos();
               
            }
            else
            {
                if (datos1 is Programas)
                {
                    
                    this.programasFavoritos = ((Programas)datos1).CargarDatos();

                } else
                {
                    
                    this.perifericosFavoritos = ((Perifericos)datos1).CargarDatos();
                    
                }
            }
            //inicializan los atributos que no fueron inicializados
            if (this.juegosFavoritos is null)
            {
                this.juegosFavoritos = new List<string>();
            }
            if (this.programasFavoritos is null)
            {
                this.programasFavoritos = new List<string>();
            }
            if (this.perifericosFavoritos is null)
            {
                this.perifericosFavoritos = new List<string>();
            }


        }
        public ClienteDeComputadora(string nombre, string apellido, long documento, Carga datos1, Carga datos2) : this(nombre, apellido, documento, datos1)
        {
            
            if (datos2 is Juegos)
            {
                this.juegosFavoritos = ((Juegos)datos2).CargarDatos();
                
            }
            else
            {
                if (datos2 is Programas)
                {

                    this.programasFavoritos = ((Programas)datos2).CargarDatos();
                    
                }
                else
                {

                    this.perifericosFavoritos = ((Perifericos)datos2).CargarDatos();
                    
                }
            }

        }
        public ClienteDeComputadora(string nombre, string apellido, long documento, Carga datos1, Carga datos2, Carga datos3) : this(nombre, apellido, documento, datos1, datos2)
        {
            
            if (datos3 is Juegos)
            {
                this.juegosFavoritos = ((Juegos)datos3).CargarDatos();

            }
            else
            {
                if (datos3 is Programas)
                {

                    this.programasFavoritos = ((Programas)datos3).CargarDatos();

                }
                else
                {

                    this.perifericosFavoritos = ((Perifericos)datos3).CargarDatos();
                }
            }

        }
        
        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();
            if (this.programasFavoritos.Count > 0)
            {
                buffer.AppendLine($"\nProgramas favoritos:");
                foreach (string item in this.programasFavoritos)
                {
                    buffer.AppendLine($"{item} ");
                }
                buffer.Append($"------\n");
            }
            if (this.juegosFavoritos.Count > 0)
            {
                buffer.AppendLine($"Juegos favoritos:");
                foreach (string item in this.juegosFavoritos)
                {
                    buffer.AppendLine($"{item} ");
                }
                buffer.Append($"-------\n");
            }
            if (this.perifericosFavoritos.Count > 0)
            {
                buffer.AppendLine($"Periféricos favoritos:");
                foreach (string item in this.perifericosFavoritos)
                {
                    buffer.AppendLine($"{item} ");
                }
            }
            
            return $"{base.MostrarCliente()}\n{buffer}";
        }


    }
}
