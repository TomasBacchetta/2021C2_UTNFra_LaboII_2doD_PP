﻿using System;
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
            SoundPlayer sonidoAsignarCliente = new SoundPlayer(Cyber.Properties.Resources.YEAH1);
            sonidoAsignarCliente.Play();
        }
        public static void ReproducirSonidoEcharCliente()
        {
            SoundPlayer sonidoEcharCliente = new SoundPlayer(Cyber.Properties.Resources.BOO);
            sonidoEcharCliente.Play();

        }

    }
}
