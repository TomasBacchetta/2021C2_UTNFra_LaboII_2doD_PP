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
            SoundPlayer sonidoFacturacion = new SoundPlayer(Cyber.Properties.Resources.sonidoFact1);
            sonidoFacturacion.Play();
        }
        public static void ReproducirSonidoComprar()
        {
            SoundPlayer sonidoComprar = new SoundPlayer(Cyber.Properties.Resources.cash2);
            sonidoComprar.Play();
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
            SoundPlayer sonidoInformes = new SoundPlayer(Cyber.Properties.Resources.formHistorial);
            sonidoInformes.Play();

        }
        public static void ReproducirSonidoFormProductos()
        {
            SoundPlayer sonidoProductos = new SoundPlayer(Cyber.Properties.Resources.formProductos);
            sonidoProductos.Play();

        }

        public static void ReproducirSonidoFormTutorial()
        {
            SoundPlayer sonidoTutorial = new SoundPlayer(Cyber.Properties.Resources.formTutorial);
            sonidoTutorial.Play();

        }
        public static void ReproducirSonidoFormPrincipal()
        {
            SoundPlayer sonidoPrincipal = new SoundPlayer(Cyber.Properties.Resources.formPrincipal);
            sonidoPrincipal.Play();

        }

        public static void ReproducirSonidoProblema()
        {
            SoundPlayer sonidoProblema = new SoundPlayer(Cyber.Properties.Resources.problema);
            sonidoProblema.Play();

        }

        public static void ReproducirSonidoEfectoBebidaChina()
        {
            SoundPlayer sonidoChino = new SoundPlayer(Cyber.Properties.Resources.efectoBebidaChina);
            sonidoChino.Play();

        }

        public static void ReproducirSonidoEfectoBebidaAlcoholica()
        {
            SoundPlayer sonidoAlcohol = new SoundPlayer(Cyber.Properties.Resources.efectoAlcohol);
            sonidoAlcohol.Play();

        }
        public static void ReproducirSonidoEfectoCigarros()
        {
            SoundPlayer sonidoCigarros = new SoundPlayer(Cyber.Properties.Resources.efectoCigarrillo);
            sonidoCigarros.Play();

        }

        public static void ReproducirSonidoSobreFactura()
        {
            SoundPlayer sonidoSobreFact = new SoundPlayer(Cyber.Properties.Resources.sobreFactura);
            sonidoSobreFact.Play();

        }
        public static void ReproducirSonidoSobreFactExitosa()
        {
            SoundPlayer sonidoSobreFactExito = new SoundPlayer(Cyber.Properties.Resources.sobrefactExito);
            sonidoSobreFactExito.Play();

        }
        public static void ReproducirSonidoSobreFactFracasada()
        {
            SoundPlayer sonidoSobreFactFracaso = new SoundPlayer(Cyber.Properties.Resources.sobrefactFracaso);
            sonidoSobreFactFracaso.Play();

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
