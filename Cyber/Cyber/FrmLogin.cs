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
    
    public partial class FrmLogin : Form
    {
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string nombre;
            string razonSocial;

            nombre = txtNombre.Text;
            razonSocial = txtRazonSocial.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(razonSocial))
            {
                MessageBox.Show("Cargue los datos", "Error de login");
            } else
            {
                FrmPrincipal formPrincipal = new FrmPrincipal(new CyberCafe(10, 5, 40, nombre, razonSocial), this);
                formPrincipal.Show();
                this.Hide();
            }

            


        }
    }
}
