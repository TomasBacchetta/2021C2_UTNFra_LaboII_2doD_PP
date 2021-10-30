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
            this.ConfigurarGroupBoxPrincipal();
            ArchivosMedia.ReproducirSonidoFormPrincipal();
            lblInfo.Text = $"{cyber1.Nombre} - {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} - Creado por Tomás Bacchetta";
            
            labelCantidadClientes.Text = $"Clientes en cola: {cyber1.ColaClientes.Count}";
            
            richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().ToString();

            
        }
        /// <summary>
        /// Enlaza los radiobutton y los picturebox con un equipo en particular, en base a su id.
        /// Me valgo de los tags, que pueden contener cualquier tipo de valor, para indentificarlos 
        /// </summary>
        private void ConfigurarGroupBoxPrincipal()
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


                    }
                    else
                    {
                        pict.BackgroundImage = Resources.cabinaLIBRE;
                    }

                    pict.BackgroundImageLayout = ImageLayout.Stretch;
                    indiceImagen++;

                }


            }
        }
        /// <summary>
        /// Actualiza el estado del icono de equipo
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
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

        private void ButtonMostrarEquipo_Click(object sender, EventArgs e)
        {
            
            foreach (Control item in groupBoxEquipos.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton auxRadioButton = (RadioButton)item;
                    if (auxRadioButton.Checked == true)
                    {
                        FrmVerEquipo formVerEquipo = new FrmVerEquipo(cyber1, item.Tag.ToString(), this);
                        formVerEquipo.ShowDialog();
                    }
                }
                
            }
            
        }

        private void ButtonEcharCliente_Click(object sender, EventArgs e)
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
                    richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().ToString();
                }
                labelCantidadClientes.Text = $"Clientes en cola: {cyber1.ColaClientes.Count}";
            }

        }

        private void ButtonAsignar_Click(object sender, EventArgs e)
        {
           
            CyberCafe.ResultadoAsignacion respuesta = CyberCafe.ResultadoAsignacion.EquipoNoIndicadoParaCliente;
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
                            if (cyber1.BuscarEquipoPorId(auxRadioButton.Tag.ToString()) is Cabina && cyber1.ObtenerProximoCliente() is ClienteDeTelefono)
                            {
                                FrmTelefono frmTel = new FrmTelefono((ClienteDeTelefono)cyber1.ObtenerProximoCliente());
                                frmTel.ShowDialog();
                            }
                            respuesta = cyber1.AsignarClienteAEquipo(item.Tag.ToString());
                            labelCantidadClientes.Text = $"Clientes en cola: {cyber1.ColaClientes.Count}";

                            break;
                        }
                        
                    }
                }

                if (respuesta == CyberCafe.ResultadoAsignacion.CargoEnComputadora || respuesta == CyberCafe.ResultadoAsignacion.CargoEnCabina)
                {
                    if (cyber1.ColaClientes.Count > 0)
                    {
                        richTextBoxDatosCliente.Text = cyber1.ObtenerProximoCliente().ToString();
                    } else
                    {
                        richTextBoxDatosCliente.Text = "No hay más clientes";
                    }
                    
                    cyber1.BuscarEquipoPorId(idEquipo).EnUso = true;
                    this.ImprimirEtiquetaEquipo(idEquipo);
                    this.CambiarIconoEquipo(idEquipo);
                    ArchivosMedia.ReproducirSonidoAsignarCliente();
                    MessageBox.Show("Cliente cargado a la cola del equipo.\nSi este está ocupado deberá esperar");

                }
                else
                {
                    if (respuesta == CyberCafe.ResultadoAsignacion.NoPudoCargar)
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
        /// <summary>
        /// Imprime texto en el campo de texto de un radiobutton de equipo
        /// </summary>
        /// <param name="idEquipo">recibe el id de equipo</param>
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
                        item.Text = $"{item.Tag} - {estado}\n{cyber1.ObtenerColaDeClientesEnUnEquipo(idEquipo).Count} clientes en cola";
                    }
                }
                
            }

        }

        private void ButtonHist_Click(object sender, EventArgs e)
        {
            FrmHistorialGeneral formHistorial = new FrmHistorialGeneral(this.cyber1);
            formHistorial.ShowDialog();
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
                //comprueba si hay sesiones en curso
                foreach (Sesion item in cyber1.Sesiones)
                {
                    if (item.EnCurso)
                    {
                        e.Cancel = true;
                        sesionesEnCurso = true;
                        MessageBox.Show("Aún hay sesiones abiertas. Los clientes no se pueden quedar a dormir. Cierre todas las sesiones antes de salir","Alerta");
                        break;

                    }

                }
                if (!sesionesEnCurso)
                {
                    formAnterior.Close();
                }
            }
            
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FrmTutorial tutorial = new FrmTutorial();
            tutorial.ShowDialog();
        }
    }
}
