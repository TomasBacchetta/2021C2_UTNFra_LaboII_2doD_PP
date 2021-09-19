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

namespace Cyber
{
    public partial class FrmPrincipal : Form
    {
        CyberCafe cyber1 = new CyberCafe(10, 5);
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (RadioButton item in groupBoxCompuradoras.Controls)
            {
                item.Text = cyber1.Equipos[groupBoxCompuradoras.Controls.IndexOf(item)].Id;
            }

           

        }

        private void buttonMostrarEquipo_Click(object sender, EventArgs e)
        {
            
            foreach (RadioButton item in groupBoxCompuradoras.Controls)
            {
                if (item.Checked)
                {
                    foreach (Equipo equipo in cyber1.Equipos)
                    {
                        if (equipo == item.Text)
                        {
                            if (equipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
                            {
                                Computadora comp = (Computadora)equipo;
                                FrmVerEquipo form2 = new FrmVerEquipo(comp.Mostrar());
                                form2.Show();
                            } else
                            {
                                Cabina cabina = (Cabina)equipo;
                                FrmVerEquipo form2 = new FrmVerEquipo(cabina.Mostrar());
                                form2.Show();
                            }
                            
                            
                            
                        }
                    }
                }
            }
            

        }
    }
}
