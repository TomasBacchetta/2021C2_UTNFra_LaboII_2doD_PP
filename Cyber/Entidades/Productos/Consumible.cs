using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consumible
    {
        public enum TipoConsumible
        {
            BebidaChina, Coquita, Confitura, BebidaAlcoholica, Cigarro
        }

        private string nombre;
        private double precio;
        private int costoDeFelicidad;
        private string descripcion;
        private TipoConsumible tipo;

        public Consumible(TipoConsumible tipo)
        {
            this.tipo = tipo;
            EstablecerConsumible(tipo);
            
        }
        /// <summary>
        /// establece los campos de un producto consumible en base a su tipo
        /// </summary>
        /// <param name="tipo">recibe el tipo de producto</param>
        private void EstablecerConsumible(TipoConsumible tipo)
        {
            switch (tipo)
            {
                case TipoConsumible.BebidaChina:
                    this.nombre = "Bebida energética china";
                    this.descripcion = "Una bebida energética del lejano oriente.\n**Exótico**: Este producto llama la atención. \nAl comprarlo, baja el costo en felicidad en 5 \nde este mismo producto para todos los clientes de la subcola";
                    this.precio = 10;
                    this.costoDeFelicidad = 8;
                    break;
                case TipoConsumible.Coquita:
                    this.nombre = "Coquita";
                    this.descripcion = "La clásica coquita";
                    this.precio = 3;
                    this.costoDeFelicidad = 2;
                    break;
                case TipoConsumible.Confitura:
                    this.nombre = "Confitura";
                    this.descripcion = "Caramelos de colores";
                    this.precio = 1;
                    this.costoDeFelicidad = 1;
                    break;
                case TipoConsumible.BebidaAlcoholica:
                    this.nombre = "Bebida Alcohólica";
                    this.descripcion = "Una bebida embriagadora.\n**Producto alcohólico**: \nAl beberlo existe una alta probabilidad de \nsufrir una sofrefacturación de toda la sesión";
                    this.precio = 2;
                    this.costoDeFelicidad = 4;
                    break;
                case TipoConsumible.Cigarro:
                    this.nombre = "Cigarro";
                    this.descripcion = "Una dosis de nicotina.\n**Producto contaminante:** Reduce la felicidad de todos \nlos clientes actuales de la subcola en 3";
                    this.precio = 15;
                    this.costoDeFelicidad = 4;
                    break;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }
        public int CostoFelicidad
        {
            get
            {
                return this.costoDeFelicidad;
            }
        }
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
        }
        
        public TipoConsumible Tipo
        {
            get
            {
                return this.tipo;
            }
        }

        public string MostrarCostos()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append($"Precio: ${this.precio} - Costo en Felicidad: {this.costoDeFelicidad}");

            return $"{buffer}";
        }

        


    }
}
