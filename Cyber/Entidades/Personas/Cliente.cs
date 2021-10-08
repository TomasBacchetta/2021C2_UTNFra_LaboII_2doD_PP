﻿using System;
using System.Collections.Generic;
using System.Text;
using static Personas.ClienteDeTelefono;

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
        private int puntosDeFelicidad;

        public virtual List<string> JuegosFavoritos { get; }
       

        public virtual List<string> ProgramasFavoritos { get; }
       

        public virtual List<string> PerifericosFavoritos{ get; }

        public virtual TipoLlamada TipoDeLlamada { get; }

        public int PuntosDeFelicidad
        {
            get
            {
                return this.puntosDeFelicidad;
            }
            set
            {
                this.puntosDeFelicidad = value;
            }
        }
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
            this.puntosDeFelicidad = 0;
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

    

    
}
