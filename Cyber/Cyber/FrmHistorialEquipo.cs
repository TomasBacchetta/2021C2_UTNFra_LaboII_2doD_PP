using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sesiones;

namespace Cyber
{
    public partial class FrmHistorialEquipo : Form
    {
        List<Sesion> listaSesiones;
        public FrmHistorialEquipo(List<Sesion> listaSesiones)
        {
            this.listaSesiones = listaSesiones;
            InitializeComponent();
        }

        private void FrmHistorialEquipo_Load(object sender, EventArgs e)
        {
            StringBuilder buffer = new StringBuilder();
            bool haySesionCerrada = false;
            if (this.listaSesiones.Count > 0)
            {
                foreach (Sesion item in this.listaSesiones)
                    if (item.EnCurso == false)
                    {
                        haySesionCerrada = true;
                        buffer.Append(item.MostrarSesion());
                        buffer.AppendLine("\n----------\n");
                    }
                    if (haySesionCerrada)
                {
                    richTextBoxHistorial.Text = buffer.ToString();
                } else
                {
                    richTextBoxHistorial.Text = "No hay sesiones que mostrar";
                }
                    
            } else
            {
                richTextBoxHistorial.Text = "No hay sesiones que mostrar";
            }
            
        }
    }
}
