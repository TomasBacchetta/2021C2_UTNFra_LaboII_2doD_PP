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
    public partial class FrmVerEquipo : Form
    {
        CyberCafe cyber1;
        string idEquipo;
        Sesion sesionActual;
        FrmPrincipal formPrincipal;
        public FrmVerEquipo(CyberCafe cyber, string idEquipo, FrmPrincipal formPrincipal)
        {
            this.cyber1 = cyber;
            this.idEquipo = idEquipo;
            this.sesionActual = cyber1.BuscarProximaSesionActivaDeUnEquipo(idEquipo);
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void FrmVerEquipo_Load(object sender, EventArgs e)
        {
            
            
            richTextBoxDatosEquipo.Text = cyber1.BuscarEquipoPorId(idEquipo).Mostrar();
            if (cyber1.subColaClientes[idEquipo].Count > 0)
            {
                richTextBoxProximoCliente.Text = cyber1.ObtenerProximoClienteSubcola(idEquipo).MostrarCliente();
            }
            
            if (!(sesionActual is null))
            {
                richTextBoxDatosEquipo.AppendText($"\nSiendo utilizado por: \n{sesionActual.UsuarioActual.Nombre} {sesionActual.UsuarioActual.Apellido}");
            }
            
        }

        private void buttonTerminarSesion_Click(object sender, EventArgs e)
        {
            if (!(sesionActual is null))
            {
                this.sesionActual.EnCurso = false;
                sesionActual.EnCurso = false;
                MessageBox.Show($"Monto facturado:{sesionActual.CostoTotal} por {sesionActual.CalcularMinutosPasados()} minutos de uso ");
                cyber1.BuscarEquipoPorId(idEquipo).enUso = false;

                if (!(sesionActual is null))
                {

                }

                if (cyber1.subColaClientes[idEquipo].Count > 0)
                {
                    cyber1.CargarSesionNueva(idEquipo);
                    cyber1.subColaClientes[idEquipo].Dequeue();
                    this.sesionActual = cyber1.BuscarProximaSesionActivaDeUnEquipo(idEquipo);


                }

                if (cyber1.subColaClientes[idEquipo].Count > 0)
                {
                    richTextBoxProximoCliente.Text = cyber1.ObtenerProximoClienteSubcola(idEquipo).MostrarCliente();
                }
                else
                {
                    richTextBoxProximoCliente.Text = "";
                }

                richTextBoxDatosEquipo.Text = cyber1.BuscarEquipoPorId(idEquipo).Mostrar();

                if (!(sesionActual is null))
                {
                    if (sesionActual.EnCurso == true)
                    {
                        richTextBoxDatosEquipo.AppendText($"\nSiendo utilizado por: \n{sesionActual.UsuarioActual.Nombre} {sesionActual.UsuarioActual.Apellido}");
                    }

                }
                formPrincipal.ImprimirEtiquetaEquipo(idEquipo);
            }
            
            
            



        }
    }
}
