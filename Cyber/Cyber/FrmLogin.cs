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

namespace Cyber
{
    
    public partial class FrmLogin : Form
    {
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string nombre;
            string razonSocial;

            nombre = txtNombre.Text;
            razonSocial = txtRazonSocial.Text;

            if (!DeterminarSiEsNombre(nombre) || !DeterminarSiEsNombre(razonSocial))
            {
                MessageBox.Show("Cargue bien los datos", "Error de login");
            } else
            {
                FrmPrincipal formPrincipal = new FrmPrincipal(new CyberCafe(10, 5, 40, FormatearNombre(nombre), razonSocial), this);
                formPrincipal.Show();
                this.Hide();
            }


        }

        //Los siguientes métodos fueron inventados por mí en C, readaptados a C#. Puede haber algunas redundancias ya resueltas por este lenguaje

        /// <summary>
        /// Determina si un string corresponde a un nombre y apellido en español
        /// </summary>
        /// <param name="cadena">recibe el nombre y/o apellido</param>
        /// <returns>devuelve true si corresponde a un nombre, falso si no</returns>
        private static bool DeterminarSiEsNombre(string nombre)
        {
            bool esNombre = false;
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                esNombre = true;
                for (int x = 0; x < nombre.Length; x++)
                {
                    if (((nombre[x] < 65 || nombre[x] > 122) && nombre[x] != ' ' && nombre[x] != 'á' && nombre[x] != 'é' && nombre[x] != 'í' && nombre[x] != 'ó' && nombre[x] != 'ú' && nombre[x] != '\n') || nombre[0] == ' ') //si no es texto incluyendo espacio y salto de linea, mientras que el espacio no este adelante o al final de la cadena
                    {
                        esNombre = false;
                        break;
                    }
                    if (x > 0)  //evita leer fuera del rango de cadena
                    {
                        if (nombre[x - 1] == ' ' && nombre[x] == ' ')  //si hay por lo menos dos espacios consecutivos
                        {
                            esNombre = false;
                            break;
                        }
                    }
                }
            }
            return esNombre;
        }
        /// <summary>
        /// Le da formato a un nombre. Por ejemplo, si el string corresponde a jorge pérez, devolverá Jorge Pérez
        /// </summary>
        /// <param name="nombre">recibe un string correspondiente a nombre y/o apellido</param>
        /// <returns>devuelve un string nuevo formateado</returns>
        public static string FormatearNombre(string nombre)
        {
            StringBuilder buffer = new StringBuilder();
            List<char> cadena = new List<char>();

            foreach (char item in nombre)
            {
                cadena.Add(item);
            }
            if (nombre.Length > 0) //mayuscula para el primer caracter si la necesita
            {
                if (cadena[0] >= 97 && cadena[0] <= 122)
                {
                    cadena[0] = (cadena[0].ToString().ToUpper())[0];
                }
                for (int x = 1; x < cadena.Count; x++)
                {
                    if (cadena[x] >= 65 && cadena[x] <= 90) //minuscula para el caracter que la necesite
                    {
                        cadena[x] = (cadena[x].ToString().ToLower())[0];
                    }
                    if (x > 0)  //para no leer la posicion de memoria anterior a la cadena
                    {
                        if (cadena[x - 1] == ' ')  //para darle mayuscula a iniciales de nombres o apellidos dobles que la necesiten
                        {
                            if (cadena[x] >= 97 && cadena[x] <= 122)
                            {
                                cadena[x] = (cadena[x].ToString().ToUpper())[0];
                            }
                        }
                    }
                }
                
            }
            foreach (char item in cadena)
            {
                buffer.Append(item);
            }
            return buffer.ToString();
        }

    }
}
