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
using Equipos;
using Sesiones;

namespace Cyber
{
    public partial class FrmHistorialGeneral : Form
    {
        private CyberCafe cyber;
        private Dictionary<string, List<Sesion>> sesionesArchivadas;
        public FrmHistorialGeneral(CyberCafe cyber)
        {
            int contador = 0;
            InitializeComponent();
            this.cyber = cyber;
            this.sesionesArchivadas = new Dictionary<string, List<Sesion>>();

            foreach (Equipo item in this.cyber.Equipos)
            {
                TabPage tab = new TabPage();
                this.sesionesArchivadas.Add(item.Id, new List<Sesion>());
                RichTextBox cuadroTextHistorial = new RichTextBox();
                tab.Controls.Add(cuadroTextHistorial);
                cuadroTextHistorial.Size = new Size(317, 428);
                cuadroTextHistorial.Location = new Point(28, 15);
                tab.Text = $"{item.Id}";
                tabHistorial.TabPages.Add(tab);
                
                cuadroTextHistorial.Text = "Sin sesiones que mostrar";
                
                contador++;
            }
        }

        private void FrmHistorialGeneral_Load(object sender, EventArgs e)
        {
            if (cyber.Sesiones.Count > 0)
            {
                foreach (KeyValuePair<string, List<Sesion>> item in this.sesionesArchivadas)
                {
                    foreach (Sesion sesion in cyber.Sesiones)
                    {
                        if (item.Key == sesion.IdEquipo && sesion.EnCurso == false)
                        {
                            this.sesionesArchivadas[item.Key].Add(sesion);
                        }
                    }
                }
            }
            foreach (TabPage tab in tabHistorial.TabPages)
            {
                foreach (Control control in tab.Controls)
                {
                    if (control.GetType() == typeof(RichTextBox))
                    {
                        StringBuilder buffer = new StringBuilder();
                        RichTextBox richTextBox = (RichTextBox)control;
                        if (sesionesArchivadas[tab.Text].Count > 0)
                        {
                            foreach (Sesion sesion in sesionesArchivadas[tab.Text])
                            {
                                buffer.AppendLine(sesion.MostrarSesion());
                            }
                            richTextBox.Text = $"{buffer}";
                        } 
                        
                    }
                  
                }
            }
            
        }
    }
}
