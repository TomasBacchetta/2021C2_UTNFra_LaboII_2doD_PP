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
using Sesiones;
using Equipos;
using static Personas.ClienteDeTelefono;

namespace Cyber
{
    /// <summary>
    /// Este formulario se encarga de mostrar el historial y los informes de todo el cyber
    /// </summary>
    public partial class FrmHistorialGeneral : Form
    {
        private CyberCafe cyber;
        /// <summary>
        /// este diccionario tiene las sesiones terminadas catalogadas por el id de equipo (la key)
        /// </summary>
        private Dictionary<string, List<Sesion>> sesionesArchivadas;
        private const string histGeneral = "General";
        
        public FrmHistorialGeneral(CyberCafe cyber)
        {
            
            InitializeComponent();
            this.cyber = cyber;
            this.sesionesArchivadas = new Dictionary<string, List<Sesion>>();
            this.GenerarPestania(histGeneral);
            this.GenerarPestaniasEquipo();
            

        }
        /// <summary>
        /// Aquí quise experimentar un poco con la generación dinámica de los controles de un formulario.
        /// Genera todos los controles del formulario
        /// </summary>
        /// <param name="titulo"></param>
        public void GenerarPestania(string titulo)
        {
            //genera pestaña
            TabPage tab = new TabPage();
            
            //genera imagen de fondo

            tab.BackgroundImage = Properties.Resources.fondoHistorial;
            tab.BackgroundImageLayout = ImageLayout.Stretch;

            //genera cuadro de texto de historial
            Label labelHistorial = new Label();
            labelHistorial.Text = "Historial: ";
            labelHistorial.Location = new Point(28, 15);
            tab.Controls.Add(labelHistorial);
            RichTextBox cuadroTextHistorial = new RichTextBox();
            cuadroTextHistorial.Name = "rtbHistorial";
            tab.Controls.Add(cuadroTextHistorial);
            cuadroTextHistorial.Size = new Size(317, 317);
            cuadroTextHistorial.Location = new Point(28, 40);
            tab.Text = $"{titulo}";
            
            cuadroTextHistorial.Text = "Sin sesiones que mostrar";
            this.sesionesArchivadas.Add(titulo, new List<Sesion>());

            //genera richtextbox de informes
            Label labelInformes = new Label();
            labelInformes.Text = "Informes: ";
            labelInformes.Location = new Point(400, 15);
            tab.Controls.Add(labelInformes);
            RichTextBox richTextInformes = new RichTextBox();
            richTextInformes.Name = "rtbInformes";
            tab.Controls.Add(richTextInformes);
            richTextInformes.Size = new Size(317, 317);
            richTextInformes.Location = new Point(400, 40);
            richTextInformes.Text = "Sin informes que mostrar";


            //agrega la pestaña al control de pestañas del formulario
            tabHistorial.TabPages.Add(tab);
            
        }
        /// <summary>
        /// Crea una pestaña tab para cada equipo del cyber
        /// </summary>
        public void GenerarPestaniasEquipo()
        {
            foreach (Equipo item in this.cyber.Equipos)
            {
                this.GenerarPestania(item.Id);

            }
        }
       
        private void FrmHistorialGeneral_Load(object sender, EventArgs e)
        {
            ArchivosMedia.ReproducirSonidoHistorialEInformes();
            
            //cargar las sesiones archivadas de este formulario
            if (cyber.Sesiones.Count > 0)
            {
                foreach (KeyValuePair<string, List<Sesion>> item in this.sesionesArchivadas)
                {
                    foreach (Sesion sesion in cyber.Sesiones)
                    {
                        if ((item.Key == sesion.IdEquipo || item.Key == histGeneral) && !sesion.EnCurso)
                        {
                            this.sesionesArchivadas[item.Key].Add(sesion);
                            

                        }

                    }

                }
                
            }

            foreach (TabPage tab in tabHistorial.TabPages)
            {
                //ordenar sesiones
                //Lista de sesiones ordenadas por minutos de uso de forma descendente.
                //Lista de sesiones ordenadas por minutos de uso de forma descendente.
                StringBuilder buffer = new StringBuilder();
                this.sesionesArchivadas[tab.Text].Sort(OrdenarPorSesionesPorMinutosDescedente);

                foreach (Control control in tab.Controls)
                {
                    if (control.GetType() == typeof(RichTextBox))
                    {
                        StringBuilder sbHist = new StringBuilder();
                        if (control.Name == "rtbHistorial")
                        {
                            RichTextBox richTextBox = (RichTextBox)control;
                            if (sesionesArchivadas[tab.Text].Count > 0)
                            {
                                foreach (Sesion sesion in sesionesArchivadas[tab.Text])
                                {
                                    sbHist.AppendLine($"{sesion}");
                                    sbHist.AppendLine("\n----------------\n");
                                }
                                richTextBox.Text = $"{sbHist}";
                            }
                            else
                            {
                                richTextBox.Text = "Sin sesiones que mostrar";
                            }
                        } else
                        {
                            if (sesionesArchivadas[tab.Text].Count > 0)
                            {
                                
                                RichTextBox richTextInformes = (RichTextBox)control;
                                richTextInformes.Visible = true;
                                buffer.AppendLine(ImprimirRichTextInformes(tab));
                                
                                
                                
                                richTextInformes.Text = $"{buffer}";
                            }
                        }
                        
                        
                    }
                    

                }
            }
            
            
        }
        
        
        public static int OrdenarPorSesionesPorMinutosDescedente(Sesion sesion1, Sesion sesion2)
        {
            return (int)(sesion2.TiempoPasado - sesion1.TiempoPasado);
        }

        public static int OrdenarEquiposPorMinutosDescedente(KeyValuePair<string, long> elemento1, KeyValuePair<string, long> elemento2)
        {
            return (int)(elemento2.Value - elemento1.Value);
        }

        
        /// <summary>
        /// Imprime el apartado de informes en el richtextbox correspondiente
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public string ImprimirRichTextInformes(TabPage tab)
        {
            StringBuilder buffer = new StringBuilder();
            double gananciasTotales = 0;
            Dictionary<Cabina.TipoLlamadaTelefono, double> recaudacionPorTipoLlamada = new Dictionary<Cabina.TipoLlamadaTelefono, double>();
            double tiempoTotalCabina = 0;
            double tiempoTotalComputadora = 0;
            ///Los siguientes diccionarios son contadores indexados por un elemento particular de una computadora, para cada categoría
            Dictionary<string, int> softwareMasPedido = new Dictionary<string, int>();
            Dictionary<string, int> juegoMasPedido = new Dictionary<string, int>();
            Dictionary<string, int> perifericoMasPedido = new Dictionary<string, int>();
            //Los siguientes diccionarios acumulan el tiempo de uso para cada tipo de equipo, indexados por el id único del equipo 
            Dictionary<string, long> computadorasPorTiempo = new Dictionary<string, long>();
            Dictionary<string, long> cabinasPorTiempo = new Dictionary<string, long>();
            

            bool esCabina = false;
            bool esComputadora = false;
            
            foreach (Sesion sesion in sesionesArchivadas[tab.Text])
            {
                if (!sesion.EnCurso)
                {
                    gananciasTotales += sesion.CostoFinal;


                    if (sesion.GetType() == typeof(SesionCabina))//si la sesion es de tipo de cabina
                    {
                        SesionCabina auxSesionCabina = (SesionCabina)sesion;
                        if (esCabina == false)
                        {
                            esCabina = true;//por lo menos una sesion es de cabina
                        }

                        tiempoTotalCabina += sesion.TiempoPasado;
                        if (recaudacionPorTipoLlamada.ContainsKey(auxSesionCabina.TipoLlamada))
                        {
                            recaudacionPorTipoLlamada[auxSesionCabina.TipoLlamada] += auxSesionCabina.CostoFinal;
                        }
                        else
                        {
                            recaudacionPorTipoLlamada.Add(auxSesionCabina.TipoLlamada, auxSesionCabina.CostoFinal);
                        }

                        if (cabinasPorTiempo.ContainsKey(auxSesionCabina.IdEquipo))
                        {
                            cabinasPorTiempo[auxSesionCabina.IdEquipo] += auxSesionCabina.TiempoPasado;
                        }
                        else
                        {
                            cabinasPorTiempo.Add(auxSesionCabina.IdEquipo, auxSesionCabina.TiempoPasado);
                        }

                    }
                    else //la sesion es de tipo de computadora
                    {
                        SesionComputadora auxSesionComp = (SesionComputadora)sesion;
                        if (esComputadora == false)
                        {
                            esComputadora = true;//por lo menos una sesion es de cabina
                        }
                        tiempoTotalComputadora += sesion.TiempoPasado;

                        foreach (string software in auxSesionComp.SoftwareUtilizado)
                        {
                            if (softwareMasPedido.ContainsKey(software))
                            {
                                softwareMasPedido[software]++;
                            }
                            else
                            {
                                softwareMasPedido.Add(software, 1);
                            }
                        }

                        foreach (string juego in (auxSesionComp.JuegosUtilizados))
                        {
                            if (juegoMasPedido.ContainsKey(juego))
                            {
                                juegoMasPedido[juego]++;
                            }
                            else
                            {
                                juegoMasPedido.Add(juego, 1);
                            }
                        }

                        foreach (string periferico in auxSesionComp.PerifericosUtilizados)
                        {
                            if (perifericoMasPedido.ContainsKey(periferico))
                            {
                                perifericoMasPedido[periferico]++;
                            }
                            else
                            {
                                perifericoMasPedido.Add(periferico, 1);
                            }
                        }

                        if (computadorasPorTiempo.ContainsKey(sesion.IdEquipo))
                        {
                            computadorasPorTiempo[sesion.IdEquipo] += sesion.TiempoPasado;
                        }
                        else
                        {
                            computadorasPorTiempo.Add(sesion.IdEquipo, sesion.TiempoPasado);
                        }
                        
                    }
                }
            }
            
            buffer.AppendFormat("\nGanancias Totales: ${0:0.00}\n", gananciasTotales);
            buffer.AppendLine($"-----------------\n");
            if (esCabina)//si es cabina significa que debe imprimir los siguientes datos específicos de la cabina
            {
                buffer.AppendFormat($"Horas totales de uso de las cabinas: {tiempoTotalCabina} minutos\n");
                buffer.AppendLine($"-----------------");
                buffer.AppendLine($"Recaudacion por tipo de llamada: ");
                if (recaudacionPorTipoLlamada.ContainsKey(Cabina.TipoLlamadaTelefono.Local))
                {
                    buffer.AppendFormat("\n-Local: ${0:0.00}", recaudacionPorTipoLlamada[Cabina.TipoLlamadaTelefono.Local]);
                }
                if (recaudacionPorTipoLlamada.ContainsKey(Cabina.TipoLlamadaTelefono.LargaDistancia))
                {
                    buffer.AppendFormat("\n-Larga distancia: ${0:0.00}", recaudacionPorTipoLlamada[Cabina.TipoLlamadaTelefono.LargaDistancia]);
                }
                if (recaudacionPorTipoLlamada.ContainsKey(Cabina.TipoLlamadaTelefono.Internacional))
                {
                    buffer.AppendFormat("\n-Internacional: ${0:0.00}", recaudacionPorTipoLlamada[Cabina.TipoLlamadaTelefono.Internacional]);
                }
                
                buffer.AppendLine($"\n-----------------\n");

            }
            if (esComputadora)//si es computadora significa que debe imprimir los siguientes datos específicos de la cabina
            {
                buffer.AppendFormat($"Horas totales de uso de las computadoras: {tiempoTotalComputadora} minutos\n");
                buffer.AppendLine($"\n-----------------\n");
                if (softwareMasPedido.Count > 0)
                {
                    buffer.AppendLine($"\nSoftware más popular:");
                    buffer.AppendJoin("\n", DeterminarElementoCompuFavorito(softwareMasPedido));
                    buffer.Append('\n');
                }
                if (juegoMasPedido.Count > 0)
                {
                    buffer.AppendLine($"\nJuego/s más popular/es:");
                    buffer.AppendJoin("\n", DeterminarElementoCompuFavorito(juegoMasPedido));
                    buffer.Append('\n');
                }
                if (perifericoMasPedido.Count > 0)
                {
                    buffer.AppendLine($"\nPeriferico/s más popular/es:");
                    buffer.AppendJoin("\n", DeterminarElementoCompuFavorito(perifericoMasPedido));
                    buffer.Append('\n');
                }
                
                
                buffer.AppendLine($"-----------------\n");

                
            }

            if (tab.Text == histGeneral)//si el tab donde se está operando corresponde al del historial e informes General, se imprimen los listados de uso de tiempo
             //de cada tipo de equipo, tal como pide la consigna
            {
                buffer.AppendLine(ImprimirListadoCabinas(cabinasPorTiempo));
                buffer.AppendLine(ImprimirListadoComputadoras(computadorasPorTiempo));
            }
            
            
            return $"{buffer}";
        }
        /// <summary>
        /// imprime el listado de cabinas, que se agrega al richtextbox de informes. Este aparecerá solamente en el tab General
        /// </summary>
        /// <param name="cabinasPorTiempo">recibe el tiempo de uso de cada cabina clasificado por id</param>
        /// <returns></returns>
        private static string ImprimirListadoCabinas(Dictionary<string, long> cabinasPorTiempo)
        {
            StringBuilder buffer = new StringBuilder();
            List<KeyValuePair<string, long>> listaCabinas = new List<KeyValuePair<string, long>>();
            
            foreach (KeyValuePair<string, long> item in cabinasPorTiempo)
            {
                listaCabinas.Add(item);
            }
            
            listaCabinas.Sort(OrdenarEquiposPorMinutosDescedente);

            buffer.AppendLine($"\n\nUso horario por cada cabina:\n");
            foreach (KeyValuePair<string, long> item in listaCabinas)
            {
                buffer.AppendLine($"{item.Key}: {item.Value} minutos");
            }
            

            return $"{buffer}";
        }
        /// <summary>
        /// imprime el listado de computadoras, que se agrega al richtextbox de informes. Este aparecerá solamente en el tab General
        /// </summary>
        /// <param name="computadorasPorTiempo"></param>
        /// <returns></returns>
        private static string ImprimirListadoComputadoras(Dictionary<string, long> computadorasPorTiempo)
        {
            StringBuilder buffer = new StringBuilder();
            List<KeyValuePair<string, long>> listaComputadoras = new List<KeyValuePair<string, long>>();
            
            foreach (KeyValuePair<string, long> item in computadorasPorTiempo)
            {
                listaComputadoras.Add(item);
            }
            
            listaComputadoras.Sort(OrdenarEquiposPorMinutosDescedente);
            

            buffer.AppendLine($"\n\nUso horario por cada computadora:\n");
            
            foreach (KeyValuePair<string, long> item in listaComputadoras)
            {
                buffer.AppendLine($"{item.Key}: {item.Value} minutos");
            }

            return $"{buffer}";
        }



        public static string[] DeterminarElementoCompuFavorito(Dictionary<string, int> coleccion)
        {
            int mayorCantidad = 0;
            List<string> favoritos = new List<string>();

            foreach (KeyValuePair<string, int> item in coleccion)
            {
                if (item.Value > mayorCantidad)
                {
                    mayorCantidad = item.Value;
                }
            }

            foreach (KeyValuePair<string, int> item in coleccion)
            {
                if (item.Value == mayorCantidad)
                {
                    favoritos.Add(item.Key);
                }
            }

            return favoritos.ToArray();
        }
    }

    
}
