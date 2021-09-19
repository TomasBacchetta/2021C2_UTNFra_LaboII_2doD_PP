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

namespace Cyber
{
    public partial class FrmVerEquipo : Form
    {
        string dataEquipo;
        public FrmVerEquipo(string dataEquipo)
        {
            this.dataEquipo = dataEquipo; 
            InitializeComponent();
        }

        private void FrmVerEquipo_Load(object sender, EventArgs e)
        {
            richTextBoxDatosEquipo.Text = dataEquipo;
        }
    }
}
