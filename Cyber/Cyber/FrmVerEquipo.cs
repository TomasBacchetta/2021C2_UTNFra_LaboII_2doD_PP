﻿using System;
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

            Equipo auxEquipo = cyber1.BuscarEquipoPorId(idEquipo);
            richTextBoxDatosEquipo.Text = auxEquipo.Mostrar();

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
            
            if (!(sesionActual is null))
            {
                richTextBoxDatosEquipo.AppendText($"\nSiendo utilizado por: \n{sesionActual.MostrarSesion()}");
            }
            
        }

        private void buttonTerminarSesion_Click(object sender, EventArgs e)
        {
            if (!(this.sesionActual is null) && this.sesionActual.EnCurso == true)
            {
                this.sesionActual.EnCurso = false;
                sesionActual.EnCurso = false;
                ArchivosMedia.ReproducirSonidoFacturacion();
                MessageBox.Show($"Monto facturado: ${sesionActual.CostoTotal} por {sesionActual.CalcularMinutosPasados()} minutos de uso ");
                
                
                cyber1.BuscarEquipoPorId(idEquipo).enUso = false;

               

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
                    

                } /*else
                {
                    richTextBoxProximoCliente.Text = "";
                }*/

                
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
        /*
        private void reproducirSonidoFacturacion()
        {
            SoundPlayer sonidoFacturacion = new SoundPlayer(Cyber.Properties.Resources.cash2);
            sonidoFacturacion.Play();
        }

        private void reproducirSonidoVerComputadora()
        {
            SoundPlayer sonidoVerComputadora = new SoundPlayer(Cyber.Properties.Resources.keyboard);
            sonidoVerComputadora.Play();
        }

        private void reproducirSonidoVerTelefono()
        {
            SoundPlayer sonidoAsignarCliente = new SoundPlayer(Cyber.Properties.Resources.TPBUSY);
            sonidoAsignarCliente.Play();
        }
        */
        private void buttonHistorialSesiones_Click(object sender, EventArgs e)
        {
            
            List<Sesion> listaSesionEquipo = new List<Sesion>();

            foreach (Sesion item in cyber1.Sesiones)
            {
                if (item.IdEquipo == this.idEquipo)
                {
                    listaSesionEquipo.Add(item);
                }
            }


            FrmHistorialEquipo form3 = new FrmHistorialEquipo(listaSesionEquipo);
            form3.Show();
        }
    }
}
