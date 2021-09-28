using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equipos;
using Negocio;
using Personas;
using Sesiones;
using System.Media;
using Cyber.Properties;

namespace Cyber
{
    public partial class FrmPrincipal : Form
    {
        CyberCafe cyber1 = new CyberCafe(10, 5, 20);
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control item in groupBoxEquipos.Controls)
            {

                
                item.Tag = cyber1.Equipos[groupBoxEquipos.Controls.IndexOf(item)].Id;
                this.ImprimirEtiquetaEquipo(item.Tag.ToString());

            }
            
            richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().MostrarCliente();
        }

        private void buttonMostrarEquipo_Click(object sender, EventArgs e)
        {
            
            foreach (RadioButton item in groupBoxEquipos.Controls)
            {
                if (item.Checked)
                {
                    FrmVerEquipo form2 = new FrmVerEquipo(cyber1, item.Tag.ToString(), this);
                    form2.Show();
                }
            }
            
        }

        private void buttonEcharCliente_Click(object sender, EventArgs e)
        {
            
            if (cyber1.ColaClientes.Count > 0)
            {
                cyber1.ColaClientes.Dequeue();
                ArchivosMedia.ReproducirSonidoEcharCliente();
                if (cyber1.ColaClientes.Count == 0)
                {
                    richTextBoxDatosCliente.Text = "No hay más clientes";
                } else
                {
                    richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().MostrarCliente();
                }
            }

        }

        private void buttonAsignar_Click(object sender, EventArgs e)
        {
           
            int respuesta = 0;
            string idEquipo = ""; ;
            if (cyber1.ColaClientes.Count > 0)
            {
                foreach (RadioButton item in groupBoxEquipos.Controls)
                {
                    if (item.Checked == true)
                    {
                        idEquipo = item.Tag.ToString();
                        respuesta = cyber1.AsignarClienteAEquipo(item.Tag.ToString());


                        break;
                    }
                }

                if (respuesta == 1 || respuesta == 2)
                {
                    richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().MostrarCliente();
                    cyber1.BuscarEquipoPorId(idEquipo).enUso = true;
                    this.ImprimirEtiquetaEquipo(idEquipo);
                    ArchivosMedia.ReproducirSonidoAsignarCliente();
                    MessageBox.Show("Cliente cargado a la cola del equipo.\nSi este está ocupado deberá esperar");

                }
                else
                {
                    if (respuesta == -1)
                    {
                        MessageBox.Show("El cliente no está interesado en esta computadora. \nRecuerde que debe haber presentes por lo menos un favorito de cada categoría");
                    }
                    else
                    {
                        MessageBox.Show("El cliente no vino para utilizar eso");
                    }
                }
            }
            
            
        }

        public void ImprimirEtiquetaEquipo(string idEquipo)
        {
            string estado;

            if (cyber1.BuscarEquipoPorId(idEquipo).enUso == true)
            {
                estado = "OCUPADO";
            } else
            {
                estado = "LIBRE";
            }

            foreach (RadioButton item in groupBoxEquipos.Controls)
            {
                if (!(item.Tag is null) && item.Tag.ToString() == idEquipo)
                {
                    item.Text = $"{item.Tag} -{estado}\n{cyber1.ObtenerSubColaClientes(idEquipo).Count} clientes en cola";
                }
            }

        }

        /*
        private void reproducirSonidoAsignarCliente()
        {
            SoundPlayer sonidoAsignarCliente = new SoundPlayer(Cyber.Properties.Resources.YEAH1);
            sonidoAsignarCliente.Play();
        }
        private void reproducirSonidoEcharCliente()
        {
            SoundPlayer sonidoEcharCliente = new SoundPlayer(Cyber.Properties.Resources.BOO);
            sonidoEcharCliente.Play();
            
        }

        
        */
    }
}
