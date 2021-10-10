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
        CyberCafe cyber1;
        Form formAnterior;
        public FrmPrincipal(CyberCafe cyber, Form formAnterior)
        {
            InitializeComponent();
            this.cyber1 = cyber;
            this.formAnterior = formAnterior;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            int indiceRadio = 0;
            int indiceImagen = 0;
            ArchivosMedia.ReproducirSonidoFormPrincipal();
            lblInfo.Text = $"{cyber1.Nombre} - {DateTime.Now}";
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
                    if (auxEquipo.EnUso == true)
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
                    cyber1.BuscarEquipoPorId(idEquipo).EnUso = true;
                    this.ImprimirEtiquetaEquipo(idEquipo);
                    this.CambiarIconoEquipo(idEquipo);
                    ArchivosMedia.ReproducirSonidoAsignarCliente();
                    MessageBox.Show("Cliente cargado a la cola del equipo.\nSi este está ocupado deberá esperar");

                }
                else
                {
                    if (respuesta == -1)
                    {
                        ArchivosMedia.ReproducirSonidoProblema();
                        MessageBox.Show("El equipo no cumple los requerimientos del cliente.");
                        
                    }
                    else
                    {
                        ArchivosMedia.ReproducirSonidoProblema();
                        MessageBox.Show("El cliente no vino para utilizar eso");
                        
                    }
                }
            }
            
            
        }

        public void ImprimirEtiquetaEquipo(string idEquipo)
        {
            string estado;

            if (cyber1.BuscarEquipoPorId(idEquipo).EnUso == true)
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

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            bool sesionesEnCurso = false;
            DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            } else
            {
                
                foreach (Sesion item in cyber1.Sesiones)
                {
                    if (item.EnCurso)
                    {
                        e.Cancel = true;
                        sesionesEnCurso = true;
                        MessageBox.Show("Aún hay sesiones abiertas. Ciérre todas las sesiones antes de salir","Alerta");
                        break;


                    }

                }
                if (!sesionesEnCurso)
                {
                    formAnterior.Close();
                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTutorial tutorial = new frmTutorial();
            tutorial.Show();
        }
    }
}
