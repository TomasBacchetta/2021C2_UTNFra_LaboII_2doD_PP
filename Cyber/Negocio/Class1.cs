using System;
using System.Collections.Generic;
using Equipos;
using Datos;

namespace Negocio
{
    public class CyberCafe
    {
        private List<Equipo> equipos;
        private int cantidadComputadoras;
        private int cantidadCabinas;

        public int CantidadComputadoras
        {
            get
            {
                return this.cantidadComputadoras;
            }
        }

        public int CantidadCabinas
        {
            get
            {
                return this.cantidadCabinas;
            }
        }

        public List<Equipo> Equipos
        {
            get
            {
                return this.equipos;
            }
        }
        public CyberCafe(int cantidadComputadoras, int cantidadCabinas)
        {
            this.equipos = new List<Equipo>();
            this.cantidadCabinas = cantidadCabinas;
            this.cantidadComputadoras = cantidadComputadoras;

            Programas software = new Programas();
            Juegos juegos = new Juegos();
            Perifericos perifericos = new Perifericos();
            Cpus cpus = new Cpus();
            PlacasDeVideo placasDeVideo = new PlacasDeVideo();
            MarcasTelefono marcasTelefono = new MarcasTelefono();
            
            MemoriasRam ram = new MemoriasRam();
            for (int x = 0; x < cantidadComputadoras; x++)
            {

                this.equipos.Add(new Computadora($"C0{x + 1}", software.CargarDatos(), juegos.CargarDatos(), perifericos.CargarDatos(), cpus.CargarDato(), placasDeVideo.CargarDato(),ram.CargarDato()));

            }
            for (int x = 0; x < cantidadCabinas; x++)
            {
                Random num = new Random();

                this.equipos.Add(new Cabina($"T0{x + 1}", (Cabina.Tipo)num.Next(0,2), marcasTelefono.CargarDato()));

            }


        }


    }
}
