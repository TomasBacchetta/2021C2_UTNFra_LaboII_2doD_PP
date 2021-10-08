using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;


namespace Cyber
{
    public partial class FrmProductos : Form
    {
        CyberCafe cyber;
        public FrmProductos(CyberCafe cyber)
        {
            InitializeComponent();
            this.cyber = cyber;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ArchivosMedia.AsignarFondoPantallaProductos(this);
            this.CargarImagenes();
            this.CargarDescripciones();
        }

        private void CargarImagenes()
        {
            pictBebidaChina.BackgroundImage = Properties.Resources.bebidaChina;
            pictBebidaChina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            pictBebidaAlcoh.BackgroundImage = Properties.Resources.bebidaAlcoholica;
            pictBebidaAlcoh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            pictBebidaCoquita.BackgroundImage = Properties.Resources.coquita;
            pictBebidaCoquita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            pictBebidaCigarros.BackgroundImage = Properties.Resources.cigarro;
            pictBebidaCigarros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            pictBebidaConfitura.BackgroundImage = Properties.Resources.confite;
            pictBebidaConfitura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void CargarDescripciones()
        {
            lblDescChina.Text = this.cyber.ObtenerProductoPorTipo(Entidades.Consumible.TipoConsumible.BebidaChina).Descripcion;
            lblDescAlcohol.Text = this.cyber.ObtenerProductoPorTipo(Entidades.Consumible.TipoConsumible.BebidaAlcoholica).Descripcion;
            lblDescCoquita.Text = this.cyber.ObtenerProductoPorTipo(Entidades.Consumible.TipoConsumible.Coquita).Descripcion;
            lblDescCigarro.Text = this.cyber.ObtenerProductoPorTipo(Entidades.Consumible.TipoConsumible.Cigarro).Descripcion;
            lblDescConfitu.Text = this.cyber.ObtenerProductoPorTipo(Entidades.Consumible.TipoConsumible.Confitura).Descripcion;
        }
    }
}
