﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Sesiones;
using static Entidades.Consumible;
using Entidades;

namespace Cyber
{
    public partial class FrmProductos : Form
    {
        CyberCafe cyber;
        List<Sesion> listaSesionesDeEsteEquipo;
        FrmVerEquipo formAnterior;
        Sesion sesionActual;
        public FrmProductos(FrmVerEquipo formAnterior)
        {
            InitializeComponent();
            this.formAnterior = formAnterior;
            this.cyber = formAnterior.cyber1;
            this.listaSesionesDeEsteEquipo = cyber.ObtenerSesionesDeEquipo(formAnterior.idEquipo);
            this.CargarImagenes();
            this.CargarDescripciones();
            this.ConfigurarTagsCheckboxes();
            this.sesionActual = ObtenerSesionActualDeLaLista();


        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ArchivosMedia.AsignarFondoPantallaProductos(this);
            ArchivosMedia.ReproducirSonidoFormProductos();
            this.CargarPreciosYStock();
            this.ActualizarEstadoDeCheckBoxes();
            this.ActualizarPuntosDeFelicidad();

        }
        /// <summary>
        /// refresca el estado de los checkboxes. Teneniendo en cuenta que un cliente solo puede comprar un solo producto por tipo
        /// </summary>
        private void ActualizarEstadoDeCheckBoxes()
        {
            foreach (Control item in Controls)
            {
                if (item is CheckBox)
                {

                    if (sesionActual.DeterminarSiCarritoYaTieneUnProducto((TipoConsumible)item.Tag))
                    {
                        item.Enabled = false;
                        item.Text = "Ya comprado";

                    } else
                    {
                        if (cyber.ObtenerProductoPorTipo((TipoConsumible)item.Tag).Stock <= 0)
                        {
                            item.Enabled = false;
                            item.Text = "SIN STOCK";
                        } else
                        {
                            item.Enabled = true;
                        }
                        
                    }

                }
            }
        }
        /// <summary>
        /// carga las imagenes de los productos
        /// </summary>
        private void CargarImagenes()
        {
            pictBebidaChina.BackgroundImage = Properties.Resources.bebidaChina;
            pictBebidaChina.BackgroundImageLayout = ImageLayout.Stretch;

            pictBebidaAlcoh.BackgroundImage = Properties.Resources.bebidaAlcoholica;
            pictBebidaAlcoh.BackgroundImageLayout = ImageLayout.Stretch;

            pictBebidaCoquita.BackgroundImage = Properties.Resources.coquita;
            pictBebidaCoquita.BackgroundImageLayout = ImageLayout.Stretch;

            pictBebidaCigarros.BackgroundImage = Properties.Resources.cigarro;
            pictBebidaCigarros.BackgroundImageLayout = ImageLayout.Stretch;

            pictBebidaConfitura.BackgroundImage = Properties.Resources.confite;
            pictBebidaConfitura.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// carga las descripciones de los productos
        /// </summary>
        private void CargarDescripciones()
        {
            lblDescChina.Text = this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaChina).Descripcion;
            lblDescAlcohol.Text = this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaAlcoholica).Descripcion;
            lblDescCoquita.Text = this.cyber.ObtenerProductoPorTipo(TipoConsumible.Coquita).Descripcion;
            lblDescCigarro.Text = this.cyber.ObtenerProductoPorTipo(TipoConsumible.Cigarro).Descripcion;
            lblDescConfitu.Text = this.cyber.ObtenerProductoPorTipo(TipoConsumible.Confitura).Descripcion;
        }

        /// <summary>
        /// actualiza precios y stock de los productos
        /// </summary>
        private void CargarPreciosYStock()
        {
            
            lblCostoBebidaChin.Text = $"{this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaChina).MostrarCostos()} - Stock: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaChina).Stock}";
            if (this.sesionActual.EfectoActual == Sesion.Efecto.BebidaChina)
            {
                lblCostoBebidaChin.Text = $"Precio: ${this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaChina).Precio} Costo de felicidad: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaChina).CostoFelicidad - 5} - Stock: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaChina).Stock}";
            }
            
            lblCostoCoquita.Text = $"{this.cyber.ObtenerProductoPorTipo(TipoConsumible.Coquita).MostrarCostos()} - Stock: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.Coquita).Stock}";
            lblCostoCigarro.Text = $"{this.cyber.ObtenerProductoPorTipo(TipoConsumible.Cigarro).MostrarCostos()} - Stock: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.Cigarro).Stock}";
            lblCostoConfitura.Text = $"{this.cyber.ObtenerProductoPorTipo(TipoConsumible.Confitura).MostrarCostos()} - Stock: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.Confitura).Stock}";
            lblCostoBebidaAlcoh.Text = $"{this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaAlcoholica).MostrarCostos()} - Stock: {this.cyber.ObtenerProductoPorTipo(TipoConsumible.BebidaAlcoholica).Stock}";
        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
            int costoEnFelicidad = 0;
            bool algoComprado = false;


            foreach (Control item in Controls)
            {
                if (item is CheckBox && ((CheckBox)item).Checked && item.Enabled)
                {
                    if ((TipoConsumible)item.Tag == TipoConsumible.BebidaChina && sesionActual.EfectoActual == Sesion.Efecto.BebidaChina)
                    {
                        costoEnFelicidad += cyber.ObtenerProductoPorTipo((TipoConsumible)item.Tag).CostoFelicidad - 5;
                    } else
                    {
                        costoEnFelicidad += cyber.ObtenerProductoPorTipo((TipoConsumible)item.Tag).CostoFelicidad;
                    }

                    

                }
            }
            if (costoEnFelicidad <= sesionActual.UsuarioActual.PuntosDeFelicidad)
            {
                foreach (Control item in Controls)
                {
                    if (item is CheckBox && ((CheckBox)item).Checked && item.Enabled && cyber.ActualizarStockListaProductos((TipoConsumible)item.Tag))
                    {
                        
                        sesionActual.CarritoDeCompras.Add(cyber.ObtenerProductoPorTipo((TipoConsumible)item.Tag));
                        algoComprado = true;
                   
                    }
                }
                sesionActual.UsuarioActual.PuntosDeFelicidad -= costoEnFelicidad;

                this.CargarPreciosYStock();
                this.ActualizarEstadoDeCheckBoxes();
                this.ActualizarPuntosDeFelicidad();

                for (int x = 0; x < sesionActual.CarritoDeCompras.Count; x++)
                {
                    switch (sesionActual.CarritoDeCompras[x].Tipo)
                    {
                        case TipoConsumible.BebidaChina:
                            ArchivosMedia.ReproducirSonidoEfectoBebidaChina();
                            MessageBox.Show("La bebida China llama la atención de todos los clientes de la cola de este equipo. Reciben todos un descuento de 5 puntos de felicidad para más bebidas chinas", "Efecto Bebida Exótica Activado");
                            cyber.BuscarEquipoPorId(this.formAnterior.idEquipo).EfectoDeLaMaquina = Equipos.Equipo.Efecto.BebidaChina;
                            break;
                        case TipoConsumible.BebidaAlcoholica:
                            ArchivosMedia.ReproducirSonidoEfectoBebidaAlcoholica();
                            MessageBox.Show("Tiene una chance del 50% de poder sobrefacturar esta sesión", "Efecto Alcohol Activado");
                            this.sesionActual.EfectoActual = Sesion.Efecto.Alcoholismo;
                            break;
                        case TipoConsumible.Cigarro:
                            ArchivosMedia.ReproducirSonidoEfectoCigarros();
                            MessageBox.Show("A nadie le gusta ver ceniceros usados en su equipo. Todos los clientes actuales de la subcola verán su felicidad reducida en 4", "Efecto Cigarro Activado");
                            cyber.BuscarEquipoPorId(this.formAnterior.idEquipo).EfectoDeLaMaquina = Equipos.Equipo.Efecto.Tabaco;
                            break;

                    }
                    
                }
                if (algoComprado)
                {
                    ArchivosMedia.ReproducirSonidoComprar();
                } else 
                {
                    MessageBox.Show("¡Vuelva cuando decida comprar algo!");
                }
                this.Close();
            }
            else
            {
                ArchivosMedia.ReproducirSonidoProblema();
                MessageBox.Show("No alcanzan los puntos de felicidad");
                
            }
            
        }
        /// <summary>
        /// Actualiza el label que muestra los de puntos de felicidad del cliente de la sesión actual
        /// </summary>
        private void ActualizarPuntosDeFelicidad()
        {
            labelFelicidad.Text = $"Puntos de felicidad: {sesionActual.UsuarioActual.PuntosDeFelicidad}";
        }
        /// <summary>
        /// asigna a los tags de los checkboxes de productos un tipo individual
        /// para poder enlazarlos facilmente con un producto
        /// </summary>
        private void ConfigurarTagsCheckboxes()
        {
            this.checkBoxBebChina.Tag = TipoConsumible.BebidaChina;
            this.checkBoxBebidaAlcoh.Tag = TipoConsumible.BebidaAlcoholica;
            this.checkBoxCigarro.Tag = TipoConsumible.Cigarro;
            this.checkBoxConfitu.Tag = TipoConsumible.Confitura;
            this.checkBoxCoquita.Tag = TipoConsumible.Coquita;
        }
        /// <summary>
        /// obtiene la sesion en curso de la lista, en el contexto en que se llama este metodo siempre la encontrará
        /// </summary>
        /// <returns>devuelve la sesion o null si no la encuentra</returns>
        private Sesion ObtenerSesionActualDeLaLista()
        {
       
            foreach (Sesion item in this.listaSesionesDeEsteEquipo)
            {
                if (item.EnCurso)
                {
                    return item;
                }
            }

            return null;
        }

        private void FrmProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            formAnterior.RefrescarForm();
        }
    }
}
