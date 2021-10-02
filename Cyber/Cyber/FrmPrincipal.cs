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
            int indiceRadio = 0;
            int indiceImagen = 0;
            foreach (Control item in groupBoxEquipos.Controls)
            {
                if (item is RadioButton)
                {
                    item.Tag = cyber1.Equipos[indiceRadio].Id;
                    this.ImprimirEtiquetaEquipo(item.Tag.ToString());
                    
                    indiceRadio++;
                }
                if (item is PictureBox)
                {
                    item.Tag = $"I{cyber1.Equipos[indiceImagen].Id}";
                    PictureBox pict = (PictureBox)item;
                    
                    if (indiceImagen < cyber1.CantidadComputadoras)
                    {
                        pict.BackgroundImage = Resources.pcLIBRE;
                        
                        
                    } else
                    {
                        pict.BackgroundImage = Resources.cabinaLIBRE;
                    }
                    
                    pict.BackgroundImageLayout = ImageLayout.Stretch;
                    indiceImagen++;

                }
                

            }
            labelCantidadClientes.Text = $"Clientes en cola: {cyber1.ColaClientes.Count}";
            
            richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().MostrarCliente();

            
        }

       
        public void CambiarIconoEquipo(string idEquipo)
        {
            foreach (Control item in groupBoxEquipos.Controls)
            {
                
                if (item is PictureBox && item.Tag.ToString() == $"I{idEquipo}")
                {
                    PictureBox pict = (PictureBox)item;
                    Equipo auxEquipo = cyber1.BuscarEquipoPorId(idEquipo);
                    if (auxEquipo.enUso == true)
                    {
                        if (auxEquipo.GetType() == typeof(Computadora))
                        {
                            pict.BackgroundImage = Resources.pcOCUPADA;
                        } else
                        {
                            pict.BackgroundImage = Resources.cabinaOCUPADA;
                        }
                        
                    } else
                    {
                        if (auxEquipo.GetType() == typeof(Computadora))
                        {
                            pict.BackgroundImage = Resources.pcLIBRE;
                        }else
                        {
                            pict.BackgroundImage = Resources.cabinaLIBRE;
                        }
                        
                    }
                }
            }
        }

        private void buttonMostrarEquipo_Click(object sender, EventArgs e)
        {
            
            foreach (Control item in groupBoxEquipos.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton auxRadioButton = (RadioButton)item;
                    if (auxRadioButton.Checked == true)
                    {
                        FrmVerEquipo form2 = new FrmVerEquipo(cyber1, item.Tag.ToString(), this);
                        form2.ShowDialog();
                    }
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
                labelCantidadClientes.Text = $"Clientes en cola: {cyber1.ColaClientes.Count}";
            }

        }

        private void buttonAsignar_Click(object sender, EventArgs e)
        {
           
            int respuesta = 0;
            string idEquipo = ""; 
            
            if (cyber1.ColaClientes.Count > 0)
            {
                foreach (Control item in groupBoxEquipos.Controls)
                {
                    if (item is RadioButton)
                    {
                        RadioButton auxRadioButton = (RadioButton)item;
                        if (auxRadioButton.Checked)
                        {
                            idEquipo = item.Tag.ToString();
                            respuesta = cyber1.AsignarClienteAEquipo(item.Tag.ToString());
                            labelCantidadClientes.Text = $"Clientes en cola: {cyber1.ColaClientes.Count}";

                            break;
                        }
                        
                    }
                }

                if (respuesta == 1 || respuesta == 2)
                {
                    richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().MostrarCliente();
                    cyber1.BuscarEquipoPorId(idEquipo).enUso = true;
                    this.ImprimirEtiquetaEquipo(idEquipo);
                    this.CambiarIconoEquipo(idEquipo);
                    ArchivosMedia.ReproducirSonidoAsignarCliente();
                    MessageBox.Show("Cliente cargado a la cola del equipo.\nSi este está ocupado deberá esperar");

                }
                else
                {
                    if (respuesta == -1)
                    {
                        MessageBox.Show("El equipo no cumple los requerimientos del cliente.");
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

            foreach (Control item in groupBoxEquipos.Controls)
            {
                if (item is RadioButton)
                {
                    if (!(item.Tag is null) && item.Tag.ToString() == idEquipo)
                    {
                        item.Text = $"{item.Tag} -{estado}\n{cyber1.ObtenerSubColaClientes(idEquipo).Count} clientes en cola";
                    }
                }
                
            }

        }

        private void buttonHist_Click(object sender, EventArgs e)
        {
            FrmHistorialGeneral formHistorial = new FrmHistorialGeneral(this.cyber1);
            formHistorial.Show();
        }
    }
}
