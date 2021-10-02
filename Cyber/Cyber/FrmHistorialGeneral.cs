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
        private const string histGeneral = "General";
        public FrmHistorialGeneral(CyberCafe cyber)
        {
            
            InitializeComponent();
            this.cyber = cyber;
            this.sesionesArchivadas = new Dictionary<string, List<Sesion>>();
            this.GenerarPestania(histGeneral);
            this.GenerarPestaniasEquipo();



        }

        public void GenerarPestania(string titulo)
        {
            TabPage tab = new TabPage();
            RichTextBox cuadroTextHistorial = new RichTextBox();
            tab.Controls.Add(cuadroTextHistorial);
            cuadroTextHistorial.Size = new Size(317, 428);
            cuadroTextHistorial.Location = new Point(28, 15);
            tab.Text = $"{titulo}";
            tabHistorial.TabPages.Add(tab);
            cuadroTextHistorial.Text = "Sin sesiones que mostrar";
            this.sesionesArchivadas.Add(titulo, new List<Sesion>());
        }

        public void GenerarPestaniasEquipo()
        {
            foreach (Equipo item in this.cyber.Equipos)
            {
                this.GenerarPestania(item.Id);

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

                        if (item.Key == histGeneral && sesion.EnCurso == false)
                        {
                            this.sesionesArchivadas[item.Key].Add(sesion);//agrega indiscriminadamente al tab de historial general
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
