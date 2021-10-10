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
using System.Media;

namespace Cyber
{
    public partial class FrmVerEquipo : Form
    {
        public CyberCafe cyber1;
        public string idEquipo;
        public Sesion sesionActual;
        public FrmPrincipal formPrincipal;
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

            Equipo auxEquipo = cyber1.BuscarEquipoPorId(idEquipo);
            richTextBoxDatosEquipo.Text = auxEquipo.Mostrar();
            this.RefrescarForm();
            if (auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
            {
                this.Text = $"Computadora {auxEquipo.Id}";
                ArchivosMedia.AsignarFondoPantallaComputadora(this);
                ArchivosMedia.ReproducirSonidoVerComputadora();
            } else
            {
                this.Text = $"Teléfono {auxEquipo.Id}";
                ArchivosMedia.AsignarFondoPantallaCabina(this);
                ArchivosMedia.ReproducirSonidoVerTelefono();
            }
            if (cyber1.ObtenerSubColaClientes(idEquipo).Count > 0)
            {
                richTextBoxProximoCliente.Text = cyber1.ObtenerProximoClienteSubcola(idEquipo).MostrarCliente();
            }
            
            

            
            
        }

        private void buttonTerminarSesion_Click(object sender, EventArgs e)
        {
            if (!(this.sesionActual is null) && this.sesionActual.EnCurso == true)
            {
                this.sesionActual.EnCurso = false;
                sesionActual.EnCurso = false;
                ArchivosMedia.ReproducirSonidoFacturacion();
                //MessageBox.Show($"Monto facturado: ${sesionActual.CostoTotal} por {sesionActual.CalcularMinutosPasados()} minutos de uso ");
                FrmFactura factura = new FrmFactura(sesionActual, cyber1.RazonSocial);
                factura.Show();
                cyber1.BuscarEquipoPorId(idEquipo).EnUso = false;
                
                if (cyber1.ObtenerSubColaClientes(idEquipo).Count > 0)
                {
                    cyber1.CargarSesionNueva(cyber1.BuscarEquipoPorId(idEquipo));
                    
                    cyber1.ObtenerAtenderProximoClienteSubcola(idEquipo);
                    this.sesionActual = cyber1.BuscarProximaSesionActivaDeUnEquipo(idEquipo);
                    if (cyber1.ObtenerSubColaClientes(idEquipo).Count == 0)
                    {
                        richTextBoxProximoCliente.Text = "";
                       
                    } else
                    {
                        richTextBoxProximoCliente.Text = cyber1.ObtenerProximoClienteSubcola(idEquipo).MostrarCliente();
                    }
                  
                } 



                this.RefrescarForm();
                formPrincipal.ImprimirEtiquetaEquipo(idEquipo);
                formPrincipal.CambiarIconoEquipo(idEquipo);
            }

        }

        public void RefrescarForm()
        {
            
            richTextBoxDatosEquipo.Text = cyber1.BuscarEquipoPorId(idEquipo).Mostrar();

            if (!(sesionActual is null) && sesionActual.EnCurso)
            {
                labelFelicidad.Text = $"Puntos de felicidad: {sesionActual.UsuarioActual.PuntosDeFelicidad}";
                buttonTerminarSesion.Enabled = true;
                btnComprarProd.Enabled = true;
                pictureBoxJack.Visible = true;
                labelFelicidad.Visible = true;
                richTextBoxDatosEquipo.AppendText($"\nSiendo utilizado por: \n{sesionActual.MostrarSesion()}");
                

            } else
            {
                buttonTerminarSesion.Enabled = false;
                btnComprarProd.Enabled = false;
                pictureBoxJack.Visible = false;
                labelFelicidad.Visible = false;
                cyber1.BuscarEquipoPorId(idEquipo).EfectoDeLaMaquina = Equipo.Efecto.Ninguno; //limpia los efectos del equipo cuando ya no queda nadie en la subcola
            }
        }
        
        private void buttonHistorialSesiones_Click(object sender, EventArgs e)
        {

            
            FrmHistorialEquipo form3 = new FrmHistorialEquipo(this.cyber1.ObtenerSesionesDeEquipo(this.idEquipo));
            form3.Show();
        }

        private void btnComprarProd_Click(object sender, EventArgs e)
        {

            FrmProductos frmProd = new FrmProductos(this);
            frmProd.Show();
        }

        
    }
}
