using System;
using System.Collections.Generic;
using Equipos;
using Datos;
using Personas;
using Sesiones;
using Entidades;
using static Entidades.Consumible;

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
        private Dictionary<TipoConsumible, Queue<Consumible>> listaProductos;
        private string nombre;
        private string razonSocial;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
        }
        public Dictionary<TipoConsumible, Queue<Consumible>> ListaProductos
        {
            get
            {
                return this.listaProductos;
            }
        }
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
        public CyberCafe(int cantidadComputadoras, int cantidadCabinas, int cantidadClientes, string nombre, string razonSocial)
        {
            this.listaEquipos = new List<Equipo>();
            this.colaClientes = new Queue<Cliente>();
            this.cantidadCabinas = cantidadCabinas;
            this.cantidadComputadoras = cantidadComputadoras;
            this.cantidadClientes = cantidadClientes;
            this.sesiones = new List<Sesion>();
            this.subColaClientes = new Dictionary<string, Queue<Cliente>>();
            this.nombre = nombre;
            this.razonSocial = razonSocial;
            this.CargarEquipos();
            this.CargarColaClientes();
            this.CargarSubColaClientes();
            this.CargarProductos();


        }
        /// <summary>
        /// Carga los diversos productos en la cola de productos, que a su vez se categorizan por la key que corresponde al tipo de producto
        /// </summary>
        private void CargarProductos()
        {
            this.listaProductos = new Dictionary<TipoConsumible, Queue<Consumible>>();

            listaProductos.Add(TipoConsumible.BebidaChina, new Queue<Consumible>());
            listaProductos.Add(TipoConsumible.BebidaAlcoholica, new Queue<Consumible>());
            listaProductos.Add(TipoConsumible.Coquita, new Queue<Consumible>());
            listaProductos.Add(TipoConsumible.Cigarro, new Queue<Consumible>());
            listaProductos.Add(TipoConsumible.Confitura, new Queue<Consumible>());

            for (int x = 0; x < 10; x++)
            {
                listaProductos[TipoConsumible.BebidaChina].Enqueue(new Consumible(TipoConsumible.BebidaChina));
                listaProductos[TipoConsumible.BebidaAlcoholica].Enqueue(new Consumible(TipoConsumible.BebidaAlcoholica));
                listaProductos[TipoConsumible.Coquita].Enqueue(new Consumible(TipoConsumible.Coquita));
                listaProductos[TipoConsumible.Cigarro].Enqueue(new Consumible(TipoConsumible.Cigarro));
                listaProductos[TipoConsumible.Confitura].Enqueue(new Consumible(TipoConsumible.Confitura));
            }
            
            
                
                    
        }
        /// <summary>
        /// Muestra el stock de un producto
        /// </summary>
        /// <param name="tipo">Recibe el stock del producto</param>
        /// <returns>Devuelve la cantidad entera de stock</returns>
        public int MostrarStockProducto(TipoConsumible tipo)
        {
            return listaProductos[tipo].Count;
        }
        /// <summary>
        /// Carga la cola general de clientes de forma pseudo-aleatoria
        /// </summary>
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
        /// <summary>
        /// Carga las especificaciones de todos los equipos de forma pseudo-aleatoria, forzando en algunos casos las tiradas
        /// </summary>
        private void CargarEquipos()
        {
            Programas software = new Programas();
            Juegos juegos = new Juegos();
            Perifericos perifericos = new Perifericos();
            Cpus cpus = new Cpus();
            PlacasDeVideo placasDeVideo = new PlacasDeVideo();
            MarcasTelefono marcasTelefono = new MarcasTelefono();
            bool cabinaUniversal = false; //determina si existe por lo menos una cabina con tipo de llamada universal
            bool computadoraCompleta = false;//determina si existe por lo menos una máquina con todas las especificaciones posibles

            MemoriasRam ram = new MemoriasRam();
            do//toda la asignación se hace de nuevo si por lo menos no hay una máquina que tenga todos las especificaciones posibles.
              //No es la mejor opcion ni la mas performante por eso puede llegar a tardar en arrancar el programa
              //Lo ideal sería relacionar la forma en que se generan los clientes con la que se generan las máquinas, para evitar
              //invariables incompatibilidades, pero eso complejizaría el algoritmo
            {
                for (int x = 0; x < this.cantidadComputadoras; x++)
                {

                    this.listaEquipos.Add(new Computadora($"C0{x + 1}", software.CargarDatos(), juegos.CargarDatos(), perifericos.CargarDatos(), cpus.CargarDato(), placasDeVideo.CargarDato(), ram.CargarDato()));

                }
                foreach(Computadora item in this.listaEquipos)
                {
                    if (item.Juegos.Count == 6 && item.Software.Count == 4 && item.Perifericos.Count == 4)
                    {
                        computadoraCompleta = true;
                    }
                }
                if (!computadoraCompleta)
                {
                    listaEquipos.Clear();
                }
            } while (!computadoraCompleta);
            
            do// toda la asignación de cabinas se hará de nuevo si no apareció ninguna cabina de tipo de llamada "todas"
            {
                for (int x = 0; x < this.cantidadCabinas; x++)
                {
                    Random num = new Random();
                    Cabina.TipoLlamadaCabina tipoLlamadaCabina;
                    if (num.Next(0, 5) > 1)//chance de 1/5 de que la cabina tenga llamadas larga distancia e internacionales
                    {
                        tipoLlamadaCabina = Cabina.TipoLlamadaCabina.Todas;
                        cabinaUniversal = true;
                    }
                    else
                    {
                        tipoLlamadaCabina = Cabina.TipoLlamadaCabina.Local;
                    }

                    this.listaEquipos.Add(new Cabina($"T0{x + 1}", (Cabina.Tipo)num.Next(0, 2), marcasTelefono.CargarDato(), tipoLlamadaCabina));

                }
                if (!cabinaUniversal)
                {
                    for (int x = this.listaEquipos.Count; x >= 0 ; x--)
                    {
                        if (this.listaEquipos[x] is Cabina)
                        {
                            this.listaEquipos.RemoveAt(x);
                        }
                    }
                }
            } while (!cabinaUniversal);
            
        }
       /// <summary>
       /// Busca un equipo por su id único
       /// </summary>
       /// <param name="id">recibe el id en formato string</param>
       /// <returns>Devuelve el equipo si lo encuentra, en la práctica siempre lo encontrará</returns>
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
        /// <summary>
        /// Busca una sesion por el id del equipo al que esta enlazada
        /// </summary>
        /// <param name="id">recibe el id del equipo</param>
        /// <returns>Devuelve el equipo si lo encuentra, en la práctica siempre lo encontrará</returns>
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

        /// <summary>
        /// Carga un cliente de la cola general en la subcola de un equipo. También llama a una función que determina cuantos puntos se restan de su felicidad
        /// </summary>
        /// <param name="idEquipo"></param>
        public void CargarClienteEnSubCola(string idEquipo)
        {
            this.AjustarPuntosDeFelicidad(idEquipo, this.ObtenerProximoCliente());
            this.subColaClientes[idEquipo].Enqueue(this.ObtenerProximoCliente());
            
        }
        /// <summary>
        /// Carga una sesión nueva
        /// </summary>
        /// <param name="equipo"></param>
        public void CargarSesionNueva(Equipo equipo)
        {
            if (equipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
            {
                SesionComputadora sesionNueva = new SesionComputadora(this.ObtenerProximoClienteSubcola(equipo.Id), equipo, (Sesion.Efecto)equipo.EfectoDeLaMaquina);
                this.RestarFelicidadPorTabaco(sesionNueva);
                this.sesiones.Add(sesionNueva);
            } else
            {
                SesionCabina sesionNueva = new SesionCabina(this.ObtenerProximoClienteSubcola(equipo.Id), equipo, (Sesion.Efecto)equipo.EfectoDeLaMaquina);
                this.sesiones.Add(sesionNueva);
            }
            equipo.EnUso = true;
            
        }
        /// <summary>
        /// Ajusta la felicidad por la presencia del efecto del tabaco en la sesion
        /// </summary>
        /// <param name="sesion"></param>
        private void RestarFelicidadPorTabaco(Sesion sesion)
        {
            if (sesion.EfectoActual == Sesion.Efecto.Tabaco)
            {
                sesion.UsuarioActual.PuntosDeFelicidad -= 3;
                if (sesion.UsuarioActual.PuntosDeFelicidad < 0)
                {
                    sesion.UsuarioActual.PuntosDeFelicidad = 0;
                }
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
            //comprueba si concuerda el tipo de equipo con lo que el cliente está buscando
            if (auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Cabina && this.ObtenerProximoCliente().TipoDeCliente == Cliente.TipoCliente.ClienteTelefono ||
                 auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora && this.ObtenerProximoCliente().TipoDeCliente == Cliente.TipoCliente.ClienteComputadora)
            {
                if (auxEquipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
                {
                    if ((Computadora)auxEquipo == this.ObtenerProximoCliente())//comprueba si la computadora es del gusto del cliente
                    {
                        
                        this.CargarClienteEnSubCola(idEquipo);
                        if (auxEquipo.EnUso == false)
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
                        if (auxEquipo.EnUso == false)
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

        private void AjustarPuntosDeFelicidad(string idEquipo, Cliente cliente)
        {
            //esto hace que cuente el usuario que utiliza el equipo pero que no está en la subcola
            int clienteEnEquipo = 0;
            if (BuscarEquipoPorId(idEquipo).EnUso)
            {
                clienteEnEquipo = 1;
            }
            //
            cliente.PuntosDeFelicidad -= (this.subColaClientes[idEquipo].Count + clienteEnEquipo);
            if (cliente.PuntosDeFelicidad < 0)
            {
                cliente.PuntosDeFelicidad = 0;
            }
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

        public Consumible ObtenerProductoPorTipo(TipoConsumible tipo)
        {
            Consumible auxProducto;
            if (this.listaProductos[tipo].Count > 0)
            {
                auxProducto = this.listaProductos[tipo].Peek();
            } else
            {
                auxProducto = new Consumible(tipo);
            }
            return auxProducto;
            
        }
        public Consumible ObtenerProductoPorTipoYRemoverDeInventario(TipoConsumible tipo)
        {
            return this.listaProductos[tipo].Dequeue();

        }
        public List<Sesion> ObtenerSesionesDeEquipo(string idEquipo)
        {

            List<Sesion> listaSesionEquipo = new List<Sesion>();

            foreach (Sesion item in Sesiones)
            {
                if (item.IdEquipo == idEquipo)
                {
                    listaSesionEquipo.Add(item);
                }
            }

            return listaSesionEquipo;
        }

    }
}
