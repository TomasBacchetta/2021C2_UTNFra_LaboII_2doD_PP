using System;
using System.Collections.Generic;
using Equipos;
using Datos;
using Personas;
using Sesiones;


namespace Negocio
{
    public class CyberCafe
    {
        private List<Equipo> listaEquipos;
        private Queue<Cliente> colaClientes;
        private int cantidadComputadoras;
        private int cantidadCabinas;
        private int cantidadClientes;
        private List<Sesion> sesiones;
        private Dictionary<string, Queue<Cliente>> subColaClientes;

        public List<Sesion> Sesiones
        {
            get
            {
                return this.sesiones;
            }
        }
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
                return this.listaEquipos;
            }
        }

        public Queue<Cliente> ColaClientes
        {
            get
            {
                return this.colaClientes;
            }
        }

        public int CantidadClientes
        {
            get
            {
                return this.cantidadClientes;
            }
        }
        public CyberCafe(int cantidadComputadoras, int cantidadCabinas, int cantidadClientes)
        {
            this.listaEquipos = new List<Equipo>();
            this.colaClientes = new Queue<Cliente>();
            this.cantidadCabinas = cantidadCabinas;
            this.cantidadComputadoras = cantidadComputadoras;
            this.cantidadClientes = cantidadClientes;
            this.sesiones = new List<Sesion>();
            this.subColaClientes = new Dictionary<string, Queue<Cliente>>();
            
            this.CargarEquipos();
            this.CargarColaClientes();
            this.CargarSubColaClientes();


        }

        private void CargarColaClientes()
        {
            NombresPersonas nombres = new NombresPersonas();
            ApellidosPersonas apellidos = new ApellidosPersonas();
            NumeroTelefono numeroTelefono = new NumeroTelefono();
            Random dni = new Random();
            Random rnd = new Random();
            Carga datos1 = new Carga();
            Carga datos2 = new Carga();
            Carga datos3 = new Carga();
            int chanceCategorias;
            int chanceTipoCategoria;

            for (int x = 0; x < this.cantidadClientes; x++)
            {
                if (rnd.Next(0,5) < 3)//chance de 3/5 de que sea cliente de computadora
                {
                    chanceCategorias = rnd.Next(0, 5);
                    if (chanceCategorias < 2)//chance de 2/5 de que tenga una sola categoria favorita
                    {
                        chanceTipoCategoria = rnd.Next(1, 4);
                        switch (chanceTipoCategoria)//chance de 1/3 de que sea alguna de las 3 categorías
                        {
                            case 1:
                                datos1 = new Juegos();
                                break;
                            case 2:
                                datos1 = new Programas();
                                break;
                            case 3:
                                datos1 = new Perifericos();
                                break;
                        }
                        this.colaClientes.Enqueue(new ClienteDeComputadora(nombres.CargarDatos(), apellidos.CargarDatos(), dni.Next(400000, 500000), datos1));
                    }
                    else
                    {
                        if (chanceCategorias < 4)//chance 2/5 de que tenga dos categorias favoritas
                        {
                            chanceTipoCategoria = rnd.Next(1, 4);
                            switch (chanceTipoCategoria)//chance de 1/3 de que tenga alguna de las combinaciones posibles de categorias
                            {
                                case 1:
                                    datos1 = new Juegos();
                                    datos2 = new Programas();
                                    break;
                                case 2:
                                    datos1 = new Programas();
                                    datos2 = new Perifericos();
                                    break;
                                case 3:
                                    datos1 = new Juegos();
                                    datos2 = new Perifericos();
                                    break;
                            }
                            this.colaClientes.Enqueue(new ClienteDeComputadora(nombres.CargarDatos(), apellidos.CargarDatos(), dni.Next(400000, 500000), datos1, datos2));
                        } else//chance de 1/5 que tenga 3 categorias favoritas
                        {
                            datos1 = new Juegos();
                            datos2 = new Programas();
                            datos3 = new Perifericos();
                            this.colaClientes.Enqueue(new ClienteDeComputadora(nombres.CargarDatos(), apellidos.CargarDatos(), dni.Next(400000, 500000), datos1, datos2, datos3));
                        }
                    }
                   
                } else//chance de 2/5 de que sea cliente de teléfono
                {
                    this.colaClientes.Enqueue(new ClienteDeTelefono(nombres.CargarDatos(), apellidos.CargarDatos(), dni.Next(400000, 500000), numeroTelefono.GenerarNumeroTelefono()));
                }
                
            }
        }
        private void CargarSubColaClientes()
        {
            foreach (Equipo item in this.Equipos)
            {
                Queue<Cliente> subCola = new Queue<Cliente>();
                this.subColaClientes.Add(item.Id, subCola);
            }
        }
        private void CargarEquipos()
        {
            Programas software = new Programas();
            Juegos juegos = new Juegos();
            Perifericos perifericos = new Perifericos();
            Cpus cpus = new Cpus();
            PlacasDeVideo placasDeVideo = new PlacasDeVideo();
            MarcasTelefono marcasTelefono = new MarcasTelefono();

            MemoriasRam ram = new MemoriasRam();
            for (int x = 0; x < this.cantidadComputadoras; x++)
            {

                this.listaEquipos.Add(new Computadora($"C0{x + 1}", software.CargarDatos(), juegos.CargarDatos(), perifericos.CargarDatos(), cpus.CargarDato(), placasDeVideo.CargarDato(), ram.CargarDato()));

            }
            for (int x = 0; x < this.cantidadCabinas; x++)
            {
                Random num = new Random();
                Cabina.TipoLlamadaCabina tipoLlamadaCabina;
                if (num.Next(0,5) > 2)//chance de 2/5 de que la cabina tenga llamadas larga distancia e internacionales
                {
                    tipoLlamadaCabina = Cabina.TipoLlamadaCabina.Todas;
                } else
                {
                    tipoLlamadaCabina = Cabina.TipoLlamadaCabina.Local;
                }

                this.listaEquipos.Add(new Cabina($"T0{x + 1}", (Cabina.Tipo)num.Next(0, 2), marcasTelefono.CargarDato(), tipoLlamadaCabina));

            }
        }
       
        public Equipo BuscarEquipoPorId(string id)
        {
            foreach (Equipo item in this.Equipos)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Sesion BuscarSesionPorEquipo(string id)
        {
            foreach (Sesion item in this.sesiones)
            {
                if (item.IdEquipo == id)
                {
                    return item;
                }
            }
            return null;
        }


        public void CargarClienteEnSubCola(string idEquipo)
        {
            
            this.subColaClientes[idEquipo].Enqueue(this.ObtenerProximoCliente());
            
        }

        public void CargarSesionNueva(Equipo equipo)
        {
            if (equipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
            {
                SesionComputadora sesionNueva = new SesionComputadora(this.ObtenerProximoClienteSubcola(equipo.Id), equipo);
                this.sesiones.Add(sesionNueva);
            } else
            {
                SesionCabina sesionNueva = new SesionCabina(this.ObtenerProximoClienteSubcola(equipo.Id), equipo);
                this.sesiones.Add(sesionNueva);
            }
            
            
        }

        /// <summary>
        /// Asigna un cliente de la cola principal a la subcola de un equipo en particular
        /// </summary>
        /// <param name="idEquipo">Recibe el ID del equipo</param>
        /// <returns>Devuelve: 
        /// 1 si logró cargar en una computadora, 
        /// 2 si logró cargar en una cabina,
        ///-1 si no pudo cargar en una computadora por no cumplir con las especificaciones del cliente, 
        ///-2 si el tipo de equipo no era el indicado para el cliente</returns>
        public int AsignarClienteAEquipo(string idEquipo)
        {

            Equipo auxEquipo = BuscarEquipoPorId(idEquipo);

            if (auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Cabina && this.ObtenerProximoCliente().TipoDeCliente == Cliente.TipoCliente.ClienteTelefono ||
                 auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora && this.ObtenerProximoCliente().TipoDeCliente == Cliente.TipoCliente.ClienteComputadora)
            {
                if (auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
                {
                    if ((Computadora)auxEquipo == this.ObtenerProximoCliente())//comprueba si la computadora es del gusto del cliente
                    {
                        this.CargarClienteEnSubCola(idEquipo);
                        if (auxEquipo.enUso == false)
                        {
                            this.CargarSesionNueva(auxEquipo);
                            this.subColaClientes[idEquipo].Dequeue();

                        }
                        this.colaClientes.Dequeue();

                        return 1;//logro cargar en una computadora
                    }
                    else
                    {
                        return -1;//no pudo cargar 
                    }
                } else
                {
                    if ((Cabina)auxEquipo == ObtenerProximoCliente())
                    {
                        this.CargarClienteEnSubCola(idEquipo);
                        if (auxEquipo.enUso == false)
                        {
                            this.CargarSesionNueva(auxEquipo);
                            this.subColaClientes[idEquipo].Dequeue();

                        }
                        this.colaClientes.Dequeue();
                    } else
                    {
                        return -1;//no pudo cargar 
                    }
                    
                    return 2;//logro cargar en una cabina
                }
                
                
            }
            return -2;//el equipo no era el indicado para el cliente
        }

        public Cliente ObtenerProximoCliente()
        {
            return this.ColaClientes.Peek();
        }

        public Cliente ObtenerAtenderProximoCliente()
        {
            return this.ColaClientes.Dequeue();
        }

        public Cliente ObtenerProximoClienteSubcola(string idEquipo)
        {
            return this.ObtenerSubColaClientes(idEquipo).Peek();
        }

        public Cliente ObtenerAtenderProximoClienteSubcola(string idEquipo)
        {
           return this.ObtenerSubColaClientes(idEquipo).Dequeue();
                        
        }

        
        public Queue<Cliente> ObtenerSubColaClientes(string idEquipo)
        {
            return this.subColaClientes[idEquipo];
        }

        

        public Sesion BuscarProximaSesionActivaDeUnEquipo(string idEquipo)
        {
            if (this.sesiones.Count > 0)
            {
                foreach (Sesion sesion in this.sesiones)
                {
                    if (sesion.IdEquipo == idEquipo && sesion.EnCurso == true)
                    {
                        return sesion;
                    }
                }
            }
            
            return null;
        }

        
    }
}
