using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Personas;
using Datos;
using Equipos;

namespace Cyber
{
    public partial class FrmTelefono : Form
    {
        private ClienteDeTelefono cliente;
        public FrmTelefono(ClienteDeTelefono cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            string numero = txtBoxNumero.Text;
            
            if (numero.Length == 12)
            {
                Marcar();
            }
            else
            {
                if ((numero.Length == 13 && numero[0] == '0') ||
                    numero.Length == 13 && numero[2] == '0')
                {
                    Marcar();
                }
                else
                {
                    if (numero.Length == 14 && numero[0] == '0' && numero[3] == '0')
                    {
                        Marcar();
                    }
                    else
                    {
                        MessageBox.Show("Número inválido");
                        LimpiarNumero();
                    }
                }

            }
        }
        
        private void Marcar()
        {
            cliente.Telefono = txtBoxNumero.Text;
            MessageBox.Show($"Marcando número {Cabina.DeterminarTipoDeLlamada(cliente.Telefono)}", "Marcando");
            this.Close();
        }
        private void LimpiarNumero()
        {
            txtBoxNumero.Text = "";
        }

       /// <summary>
       /// al presionar este boton se genera un numero de telefono al azar
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnGenerarAlAzar_Click(object sender, EventArgs e)
        {
            txtBoxNumero.Text = NumeroTelefono.GenerarNumeroTelefono();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtBoxNumero.Text = "";
        }

        private void MarcarNumero(int numero)
        {
            if (txtBoxNumero.Text.Length < 12)
            {
                txtBoxNumero.Text += $"{numero}";
            }
        }
        private void btnNum1_Click(object sender, EventArgs e)
        {
            MarcarNumero(1);
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            MarcarNumero(2);
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            MarcarNumero(3);
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            MarcarNumero(4);
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            MarcarNumero(5);
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            MarcarNumero(6);
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            MarcarNumero(7);
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            MarcarNumero(8);
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            MarcarNumero(9);
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            MarcarNumero(0);
        }

       
    }
}
