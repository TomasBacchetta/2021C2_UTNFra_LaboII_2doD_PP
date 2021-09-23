using System;
using System.Collections.Generic;
using System.Text;

namespace Personas
{
    public class Cliente
    {
        public enum TipoCliente
        {
            ClienteComputadora, ClienteTelefono
        }
        private string nombre;
        private string apellido;
        private long documento;
        private TipoCliente tipoDeCliente;


        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        public long Documento
        {
            get
            {
                return this.documento;
            }
        }

        public TipoCliente TipoDeCliente
        {
            get
            {
                return this.tipoDeCliente;
            }
        }

        protected Cliente(string nombre, string apellido, long documento, TipoCliente tipoDeCliente)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.tipoDeCliente = tipoDeCliente;
        }

        public virtual string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Nombre: {this.nombre}");
            buffer.AppendLine($"Apellido: {this.apellido}");
            buffer.AppendLine($"Documento: {this.documento}");
            buffer.AppendLine($"Tipo Cliente: ");
            if (this.tipoDeCliente == TipoCliente.ClienteComputadora)
            {
                buffer.Append($"Computadora");
            } else
            {
                buffer.Append($"Cabina");
            }
            
            return $"{buffer}";
        }

    }

    public class ClienteDeComputadora:Cliente
    {
        private List<string> juegosFavoritos;
        private List<string> programasFavoritos;
        private List<string> perifericosFavoritos;
        

        public List<string> JuegosFavoritos
        {
            get
            {
                return this.juegosFavoritos;
            }
        }

        public List<string> ProgramasFavoritos
        {
            get
            {
                return this.programasFavoritos;
            }
        }

        public List<string> PerifericosFavoritos
        {
            get
            {
                return this.perifericosFavoritos;
            }
        }

       

        public ClienteDeComputadora(string nombre, string apellido, long documento, List<string> juegosFavoritos, List<string> programasFavoritos, List<string> perifericosFavoritos):base(nombre, apellido, documento, TipoCliente.ClienteComputadora)
        {
            this.juegosFavoritos = juegosFavoritos;
            this.programasFavoritos = programasFavoritos;
            this.perifericosFavoritos = perifericosFavoritos;
        }

        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"\nProgramas favoritos:");
            foreach (string item in this.programasFavoritos)
            {
                buffer.AppendLine($"{item} ");
            }
            buffer.Append($"------\n");
            buffer.AppendLine($"Juegos favoritos:");
            foreach (string item in this.juegosFavoritos)
            {
                buffer.AppendLine($"{item} ");
            }
            buffer.Append($"-------\n");
            buffer.AppendLine($"Periféricos favoritos:");
            foreach (string item in this.perifericosFavoritos)
            {
                buffer.AppendLine($"{item} ");
            }


            return $"{base.MostrarCliente()}\n{buffer}";
        }


    }

    public class ClienteDeTelefono : Cliente
    {

        private string telefono;

        public string Telefono
        {
            get
            {
                return this.telefono;
            }
        }
        public ClienteDeTelefono(string nombre, string apellido, long dni, string telefono):base(nombre, apellido, dni, TipoCliente.ClienteTelefono)
        {
            this.telefono = telefono;
        }

        public override string MostrarCliente()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Teléfono a marcar: {this.telefono}");
           

            return $"{base.MostrarCliente()}{buffer}";
        }
    }
}
