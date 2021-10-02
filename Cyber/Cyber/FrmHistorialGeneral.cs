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
using static Personas.ClienteDeTelefono;

namespace Cyber
{
    public partial class FrmHistorialGeneral : Form
    {
        private CyberCafe cyber;
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

        public void GenerarPestania(string titulo)
        {
            //genera pestaña
            TabPage tab = new TabPage();
            
            //genera imagen de fondo

            tab.BackgroundImage = Properties.Resources.fondoHistorial;
            tab.BackgroundImageLayout = ImageLayout.Stretch;

            //genera cuadro de texto de historial
            RichTextBox cuadroTextHistorial = new RichTextBox();
            cuadroTextHistorial.Name = "rtbHistorial";
            tab.Controls.Add(cuadroTextHistorial);
            cuadroTextHistorial.Size = new Size(317, 317);
            cuadroTextHistorial.Location = new Point(28, 15);
            tab.Text = $"{titulo}";
            
            cuadroTextHistorial.Text = "Sin sesiones que mostrar";
            this.sesionesArchivadas.Add(titulo, new List<Sesion>());

            //genera label de informes
            RichTextBox richTextInformes = new RichTextBox();
            richTextInformes.Name = "rtbInformes";
            tab.Controls.Add(richTextInformes);
            richTextInformes.Location = new Point(400, 15);
            richTextInformes.Size = new Size(317, 317);
            richTextInformes.Visible = false;

            //agrega la pestaña al control de pestañas del formulario
            tabHistorial.TabPages.Add(tab);
            
        }

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
                        if (item.Key == sesion.IdEquipo || item.Key == histGeneral && sesion.EnCurso == false)
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
                                    sbHist.AppendLine(sesion.MostrarSesion());
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

        /*
        
        Ganancias totales y clasificadas por servicio (teléfono/computadora).+
        Horas totales y la recaudación por tipo de llamada.++
        El software más pedido por los clientes.+
        El periférico más pedido por los clientes.+
        El juego más pedido por los clientes.+
         */

        public string ImprimirRichTextInformes(TabPage tab)
        {
            StringBuilder buffer = new StringBuilder();
            double gananciasTotales = 0;
            Dictionary<TipoLlamada, double> recaudacionPorTipoLlamada = new Dictionary<TipoLlamada, double>();
            double tiempoTotalCabina = 0;
            double tiempoTotalComputadora = 0;
            Dictionary<string, int> softwareMasPedido = new Dictionary<string, int>();
            Dictionary<string, int> juegoMasPedido = new Dictionary<string, int>();
            Dictionary<string, int> perifericoMasPedido = new Dictionary<string, int>();
            Dictionary<string, long> computadorasPorTiempo = new Dictionary<string, long>();
            Dictionary<string, long> cabinasPorTiempo = new Dictionary<string, long>();
            

            bool esCabina = false;
            bool esComputadora = false;
            
            foreach (Sesion sesion in sesionesArchivadas[tab.Text])
            {
                if (!sesion.EnCurso)
                {
                    gananciasTotales += sesion.CostoTotal;


                    if (sesion.GetType() == typeof(SesionCabina))//si la sesion es de tipo de cabina
                    {
                        if (esCabina == false)
                        {
                            esCabina = true;//por lo menos una sesion es de cabina
                        }

                        tiempoTotalCabina += sesion.TiempoPasado;
                        if (recaudacionPorTipoLlamada.ContainsKey(sesion.TipoLlamada))
                        {
                            recaudacionPorTipoLlamada[sesion.TipoLlamada] += sesion.CostoTotal;
                        }
                        else
                        {
                            recaudacionPorTipoLlamada.Add(sesion.TipoLlamada, sesion.CostoTotal);
                        }

                        if (cabinasPorTiempo.ContainsKey(sesion.IdEquipo))
                        {
                            cabinasPorTiempo[sesion.IdEquipo] += sesion.TiempoPasado;
                        }
                        else
                        {
                            cabinasPorTiempo.Add(sesion.IdEquipo, sesion.TiempoPasado);
                        }

                    }
                    else //la sesion es de tipo de computadora
                    {
                        if (esComputadora == false)
                        {
                            esComputadora = true;//por lo menos una sesion es de cabina
                        }
                        tiempoTotalComputadora += sesion.TiempoPasado;

                        foreach (string software in sesion.SoftwareUtilizado)
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

                        foreach (string juego in sesion.JuegosUtilizados)
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

                        foreach (string periferico in sesion.PerifericosUtilizados)
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
            
            buffer.AppendLine($"Ganancias Totales: ${gananciasTotales}");
            buffer.AppendLine($"\n-----------------\n");
            if (esCabina)
            {
                buffer.AppendFormat($"Horas totales de uso de las cabinas: {tiempoTotalCabina} minutos\n");
                buffer.AppendLine($"-----------------");
                buffer.AppendLine($"Recaudacion por tipo de llamada: ");
                if (recaudacionPorTipoLlamada.ContainsKey(TipoLlamada.Local))
                {
                    buffer.AppendLine($"-Local: ${recaudacionPorTipoLlamada[TipoLlamada.Local]}");
                }
                if (recaudacionPorTipoLlamada.ContainsKey(TipoLlamada.LargaDistancia))
                {
                    buffer.AppendLine($"-Larga distancia: ${recaudacionPorTipoLlamada[TipoLlamada.LargaDistancia]}");
                }
                if (recaudacionPorTipoLlamada.ContainsKey(TipoLlamada.Internacional))
                {
                    buffer.AppendLine($"-Internacional: ${recaudacionPorTipoLlamada[TipoLlamada.Internacional]}");
                }
                
                buffer.AppendLine($"\n-----------------\n");

            }
            if (esComputadora)
            {
                buffer.AppendFormat($"Horas totales de uso de las computadoras: {tiempoTotalComputadora} minutos\n");
                buffer.AppendLine($"\n-----------------\n");
                if (softwareMasPedido.Count > 0)
                {
                    buffer.AppendLine($"Software más popular:\n");
                    buffer.AppendJoin("\n", DeterminarElementoCompuFavorito(softwareMasPedido));
                    buffer.Append("\n");
                }
                if (juegoMasPedido.Count > 0)
                {
                    buffer.AppendLine($"Juego/s más popular/es:\n");
                    buffer.AppendJoin("\n", DeterminarElementoCompuFavorito(juegoMasPedido));
                    buffer.Append("\n");
                }
                if (perifericoMasPedido.Count > 0)
                {
                    buffer.AppendLine($"Periferico/s más popular/es:\n");
                    buffer.AppendJoin("\n", DeterminarElementoCompuFavorito(perifericoMasPedido));
                    buffer.Append("\n");
                }
                
                
                buffer.AppendLine($"\n-----------------\n");

                
            }

            if (tab.Text == histGeneral)
            {
                buffer.AppendLine(ImprimirListadoCabinas(cabinasPorTiempo));
                buffer.AppendLine(ImprimirListadoComputadoras(computadorasPorTiempo));
            }
            
            
            return $"{buffer}";
        }

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
