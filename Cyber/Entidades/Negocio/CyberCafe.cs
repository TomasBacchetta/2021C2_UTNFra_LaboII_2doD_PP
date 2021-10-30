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
        /// <summary>
        /// los equipos del cyber se agrupan en una lista de Equipos sin importar el tipo
        /// </summary>
        private List<Equipo> listaEquipos;
        /// <summary>
        /// la cola de clientes es, lógicamente, una Queue de Clientes, sin importar el tipo
        /// </summary>
        private Queue<Cliente> colaClientes;
        private int cantidadComputadoras;
        private int cantidadCabinas;
        private int cantidadClientes;
        /// <summary>
        /// las sesiones de todo el cyber van agrupadas en una lista
        /// </summary>
        private List<Sesion> sesiones;
        /// <summary>
        /// las subcolas, que son las colas especificas de cada equipo (puede imaginarse una fila de chicos esperando detrás de la máquina favorita)
        /// son colecciones diccionario cuya key es un string que corresponde al id único de un equipo, sin importar el tipo, cuyo valor es una cola (independiente
        /// de la general) de clientes
        /// </summary>
        private Dictionary<string, Queue<Cliente>> colaDeClientesEnUnEquipo;
        /// <summary>
        /// la lista de productos es un diccionario que tiene como key el tipo de producto, y su valor será una cola de objetos de tipo consumible (los productos)
        /// </summary>
        private List<Consumible> listaProductos;
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
        public List<Consumible> ListaProductos
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
            this.colaDeClientesEnUnEquipo = new Dictionary<string, Queue<Cliente>>();
            this.nombre = nombre;
            this.razonSocial = razonSocial;
            this.CargarEquipos();
            this.CargarColaClientes();
            this.CargarSubColaClientes();
            this.CargarProductos();


        }
        /// <summary>
        /// Instancia la lista de productos y le agrega productos
        /// </summary>
        private void CargarProductos()
        {
            listaProductos = new List<Consumible>();
            listaProductos.Add(new Consumible(TipoConsumible.BebidaChina, 6));
            listaProductos.Add(new Consumible(TipoConsumible.BebidaAlcoholica, 8));
            listaProductos.Add(new Consumible(TipoConsumible.Coquita, 15));
            listaProductos.Add(new Consumible(TipoConsumible.Cigarro, 8));
            listaProductos.Add(new Consumible(TipoConsumible.Confitura, 20));
            
                    
        }
        /// <summary>
        /// Obtiene un producto en base a su tipo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public Consumible ObtenerProductoPorTipo(TipoConsumible tipo)
        {
            foreach (Consumible item in listaProductos)
            {
                if (item == tipo)
                {
                    return item;
                }
            }
            return null;
        }

        public bool ActualizarStockListaProductos(TipoConsumible tipo)
        {
            
            if (ObtenerProductoPorTipo(tipo).Stock > 0)
            {
                ObtenerProductoPorTipo(tipo).Stock--;
                return true;
            }
            return false;
            
        }


        /// <summary>
        /// Carga la cola general de clientes de forma pseudo-aleatoria
        /// </summary>
        private void CargarColaClientes()
        {
            NombresPersonas nombres = new NombresPersonas();
            ApellidosPersonas apellidos = new ApellidosPersonas();
            Random dni = new Random();
            Random edad = new Random();
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
                    ///a continuación se van a cargar tres tipos de sobrecargas de constructor de cliente de computadora. Esto se hace así para tratar de respetar
                    ///la consigna de utilizar por lo menos alguna sobrecarga de constructores. 
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
                        this.colaClientes.Enqueue(new ClienteDeComputadora(nombres.CargarDatos(), apellidos.CargarDatos(), edad.Next(15,99), dni.Next(400000, 500000), datos1));
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
                            this.colaClientes.Enqueue(new ClienteDeComputadora(nombres.CargarDatos(), apellidos.CargarDatos(), edad.Next(15,99), dni.Next(400000, 500000), datos1, datos2));
                        } else//chance de 1/5 que tenga 3 categorias favoritas
                        {
                            datos1 = new Juegos();
                            datos2 = new Programas();
                            datos3 = new Perifericos();
                            this.colaClientes.Enqueue(new ClienteDeComputadora(nombres.CargarDatos(), apellidos.CargarDatos(), edad.Next(15, 99), dni.Next(400000, 500000), datos1, datos2, datos3));
                        }
                    }
                   
                } else//chance de 2/5 de que sea cliente de teléfono
                {
                    this.colaClientes.Enqueue(new ClienteDeTelefono(nombres.CargarDatos(), apellidos.CargarDatos(), edad.Next(15, 99), dni.Next(400000, 500000)));
                }
                
            }
        }
        /// <summary>
        /// instancia las subcolas de clientes en base a las keys de los id de equipos
        /// </summary>
        private void CargarSubColaClientes()
        {
            foreach (Equipo item in this.Equipos)
            {
                Queue<Cliente> subCola = new Queue<Cliente>();
                this.colaDeClientesEnUnEquipo.Add(item.Id, subCola);
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

        public Sesion BuscarSesionPorEquipo(Equipo equipo)
        {
            return BuscarSesionPorEquipo(equipo.Id);
        }

        /// <summary>
        /// Carga un cliente de la cola general en la subcola de un equipo. También llama a una función que determina cuantos puntos se restan de su felicidad
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
        public void CargarClienteEnSubCola(string idEquipo)
        {
            this.AjustarPuntosDeFelicidad(idEquipo, this.ObtenerProximoCliente());
            this.colaDeClientesEnUnEquipo[idEquipo].Enqueue(this.ObtenerProximoCliente());
            
        }
        /// <summary>
        /// Carga una sesión nueva a la lista general de sesiones
        /// </summary>
        /// <param name="equipo">recibe un equipo como parametro</param>
        public void CargarSesionNueva(Equipo equipo)
        {
            if (equipo.TipoDeEquipo == Equipo.TipoEquipo.Computadora)
            {
                SesionComputadora sesionNueva = new SesionComputadora(this.ObtenerProximoClienteEnColaDeUnEquipo(equipo.Id), equipo, (Sesion.Efecto)equipo.EfectoDeLaMaquina);
                RestarFelicidadPorTabaco(sesionNueva);
                this.sesiones.Add(sesionNueva);
            } else
            {
                SesionCabina sesionNueva = new SesionCabina(this.ObtenerProximoClienteEnColaDeUnEquipo(equipo.Id), equipo, (Sesion.Efecto)equipo.EfectoDeLaMaquina);
                this.sesiones.Add(sesionNueva);
            }
            equipo.EnUso = true;
            
        }
        /// <summary>
        /// Ajusta la felicidad por la presencia del efecto del tabaco en la sesion
        /// </summary>
        /// <param name="sesion">recibe una sesión por parámetro</param>
        private static void RestarFelicidadPorTabaco(Sesion sesion)
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
        public ResultadoAsignacion AsignarClienteAEquipo(string idEquipo)
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
                            this.colaDeClientesEnUnEquipo[idEquipo].Dequeue();

                        } 
                        this.colaClientes.Dequeue();

                        return ResultadoAsignacion.CargoEnComputadora;//logro cargar en una computadora
                    }
                    else
                    {
                        return ResultadoAsignacion.NoPudoCargar;//no pudo cargar 
                    }
                } else //es de tipo cabina
                {
                    if ((Cabina)auxEquipo == ObtenerProximoCliente())
                    {
                        
                        this.CargarClienteEnSubCola(idEquipo);
                        if (auxEquipo.EnUso == false)
                        {
                            this.CargarSesionNueva(auxEquipo);
                            this.colaDeClientesEnUnEquipo[idEquipo].Dequeue();

                        } 
                        this.colaClientes.Dequeue();
                    } else
                    {
                        return ResultadoAsignacion.NoPudoCargar;//no pudo cargar 
                    }
                    
                    return ResultadoAsignacion.CargoEnCabina;//logro cargar en una cabina
                }
                
                
            }
            return ResultadoAsignacion.EquipoNoIndicadoParaCliente;//el equipo no era el indicado para el cliente
        }

        public enum ResultadoAsignacion
        {
            CargoEnComputadora,
            CargoEnCabina,
            NoPudoCargar,
            EquipoNoIndicadoParaCliente
        }
        /// <summary>
        /// Ajusta los puntos de felicidad iniciales, restando 1 por cada cliente que ya este en la subcola del equipo
        /// del cliente donde va a ser asignado, contando tambien el que use la computadora
        /// </summary>
        /// <param name="idEquipo"></param>
        /// <param name="cliente"></param>
        private void AjustarPuntosDeFelicidad(string idEquipo, Cliente cliente)
        {
            //esto hace que cuente el usuario que utiliza el equipo pero que no está en la subcola
            int clienteEnEquipo = 0;
            if (BuscarEquipoPorId(idEquipo).EnUso)
            {
                clienteEnEquipo = 1;
            }
            //
            cliente.PuntosDeFelicidad -= (this.colaDeClientesEnUnEquipo[idEquipo].Count + clienteEnEquipo);
            if (cliente.PuntosDeFelicidad < 0)//si la felicidad llega a 0, se queda ahi
            {
                cliente.PuntosDeFelicidad = 0;
            }
        }
        /// <summary>
        /// obtiene el próximo cliente de la cola general del cyber
        /// </summary>
        /// <returns>devuelve el cliente</returns>
        public Cliente ObtenerProximoCliente()
        {
            return this.ColaClientes.Peek();
        }

        /// <summary>
        /// obtiene el próximo cliente de la cola general del cyber, y lo saca de la cola
        /// </summary>
        /// <returns>devuelve el cliente</returns>
        public Cliente ObtenerAtenderProximoCliente()
        {
            return this.ColaClientes.Dequeue();
        }
        /// <summary>
        /// obtiene el proximo cliente de la subcola de un equipo
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
        /// <returns>devuelve el cliente</returns>
        public Cliente ObtenerProximoClienteEnColaDeUnEquipo(string idEquipo)
        {
            return this.ObtenerColaDeClientesEnUnEquipo(idEquipo).Peek();
        }

        /// <summary>
        /// obtiene el próximo cliente de la subcola de un equipo y lo saca de la subcola
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
        /// <returns>devuelve el cliente</returns>
        public Cliente ObtenerYAtenderProximoClienteEnColaDeUnEquipo(string idEquipo)
        {
           return this.ObtenerColaDeClientesEnUnEquipo(idEquipo).Dequeue();
                        
        }

        /// <summary>
        /// obtiene la cola de clientes de un equipo en base a su id de equipo (su key)
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
        /// <returns>devuelve la subcola</returns>
        public Queue<Cliente> ObtenerColaDeClientesEnUnEquipo(string idEquipo)
        {
            return this.colaDeClientesEnUnEquipo[idEquipo];
        }

        
        /// <summary>
        /// devuelve la sesion activa de una subcola
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
        /// <returns>devuelve la sesion si la encuentra, null si no</returns>
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
        
        
        /// <summary>
        /// obtiene la lista de sesiones de un equipo
        /// </summary>
        /// <param name="idEquipo">recibe el id del equipo</param>
        /// <returns>devuelve la lista de sesiones</returns>
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

        public List<Sesion> ObtenerSesionesDeEquipo(Equipo equipo)
        {

            return ObtenerSesionesDeEquipo(equipo.Id);
        }

    }
}
