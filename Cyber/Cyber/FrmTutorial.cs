using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyber
{
    public partial class frmTutorial : Form
    {
        public frmTutorial()
        {
            InitializeComponent();
        }

        private void frmTutorial_Load(object sender, EventArgs e)
        {
            ArchivosMedia.ReproducirSonidoFormTutorial();
            StringBuilder buffer1 = new StringBuilder();
            StringBuilder buffer2 = new StringBuilder();

            buffer1.AppendLine("Bienvenido a Cyber 1.0");
            buffer1.AppendLine("-Lo ideal es tener los parlantes encendidos");
            buffer1.AppendLine("-Podrá ver el detalle del equipo cuyo botón radial fue seleccionado, presionando el botón 'Ver Equipo'");
            buffer1.AppendLine("-Para poder asignar a un cliente a un equipo, debe ser del tipo que esté buscando, y también cumplir con ciertos requisitos");
            buffer1.AppendLine("-Si es una cabina telefónica, debe concordar el tipo de llamada con la que quiere el cliente");
            buffer1.AppendLine("-Si es una computadora, deben existir en ella por lo menos un software, un juego y un periférico de los que busca el cliente");
            buffer1.AppendLine("-Si es una computadora, deben existir en ella por lo menos un software, un juego y un periférico de las categorías que busca el cliente");
            buffer1.AppendLine("-Para asignar clientes, presione el botón 'Asignar'. Se asignará el primer cliente de la cola principal al equipo que tenga su botón radial seleccionado");
            buffer1.AppendLine("-Si el equipo está ocupado, el cliente esperará en una subcola propia del equipo");
            buffer1.AppendLine("-Si el equipo está libre, se iniciará una sesión dentro del equipo");
            buffer1.AppendLine("-La sesión se finaliza a discreción del usuario del programa. Una vez finaliza, se imprime en pantalla la factura");
            buffer1.AppendLine("-Al finalizar la sesión, si hay clientes en espera dentro de una subcola de un equipo, se asignará el próximo cliente automáticamente al equipo");
            buffer1.AppendLine("-Puede acceder a los historiales e informes desde el formulario principal del programa y un historial específico del equipo en la ventana de detalles de equipo");

            buffer2.AppendLine("-La felicidad permite comprar productos a los clientes en sesión");
            buffer2.AppendLine("-Estos productos tienen un costo monetario (que el cliente siempre estará dispuesto a pagar)");
            buffer2.AppendLine("-El cliente solo comprará una unidad de cada producto, no pudiendo comprar más de un mismo item");
            buffer2.AppendLine("-El costo monetario de los productos comprados se verán reflejados en la facturación");
            buffer2.AppendLine("-Los productos también tienen un costo en puntos de felicidad");
            buffer2.AppendLine("-Algunos productos tienen efectos que alteran el comportamiento de los clientes en sesión");
            buffer2.AppendLine("-También hay otros productos que alteran las próximas sesiones de la subcola de un equipo");
            buffer2.AppendLine("-Se considera que estos últimos efectos se anulan cuando el equipo queda vacío, y sin clientes esperando en la subcola");
            buffer2.AppendLine("-Todos los clientes de cabina empiezan con un nivel de felicidad en 1, y este no puede ser incrementado");
            buffer2.AppendLine("-Todos los clientes de computadora empiezan con un nivel de felicidad en 0");
            buffer2.AppendLine("-Estos últimos ven incrementado su nivel en 2 por cada programa, juego o periférico que esté buscando y esté presente en la computadora");
            buffer2.AppendLine("-El nivel de felicidad de un cliente decrece en 1 por cada otro cliente en la subcola del equipo donde fue asignado");
            

            rtbTutorial1.Text = buffer1.ToString();
            rtbTutorial2.Text = buffer2.ToString();
        }
    }
}
