using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Cyber
{
    public static class ArchivosMedia
    {
        public static void ReproducirSonidoFacturacion()
        {
            SoundPlayer sonidoFacturacion = new SoundPlayer(Cyber.Properties.Resources.cash2);
            sonidoFacturacion.Play();
        }

        public static void ReproducirSonidoVerComputadora()
        {
            SoundPlayer sonidoVerComputadora = new SoundPlayer(Cyber.Properties.Resources.keyboard);
            sonidoVerComputadora.Play();
        }

        public static void ReproducirSonidoVerTelefono()
        {
            SoundPlayer sonidoAsignarCliente = new SoundPlayer(Cyber.Properties.Resources.TPBUSY);
            sonidoAsignarCliente.Play();
        }

        public static void ReproducirSonidoAsignarCliente()
        {
            SoundPlayer sonidoAsignarCliente = new SoundPlayer(Cyber.Properties.Resources.asignar);
            sonidoAsignarCliente.Play();
        }
        public static void ReproducirSonidoEcharCliente()
        {
            SoundPlayer sonidoEcharCliente = new SoundPlayer(Cyber.Properties.Resources.BOO);
            sonidoEcharCliente.Play();

        }

        public static void ReproducirSonidoHistorialEInformes()
        {
            SoundPlayer sonidoHistorial = new SoundPlayer(Cyber.Properties.Resources.historialEInformes);
            sonidoHistorial.Play();

        }

        public static void AsignarFondoPantallaComputadora(FrmVerEquipo form)
        {
            form.BackgroundImage = Properties.Resources.fondoComputadora;
            form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        public static void AsignarFondoPantallaCabina(FrmVerEquipo form)
        {
            form.BackgroundImage = Properties.Resources.fondoCabina;
            form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        public static void AsignarFondoPantallaProductos(FrmProductos form)
        {
            form.BackgroundImage = Properties.Resources.fondoProductos;
            form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

    }
}
