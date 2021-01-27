using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows;

namespace WindowsFormsApplication1.Forms
{
    public partial class Consulta : Form
    {
        Socket serverConsulta;
        public Consulta(Socket serverConsulta)
        {
            InitializeComponent();
            LoadTheme();
            this.serverConsulta = serverConsulta;
        }
        private void Consulta_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
        }

        private void enviar_Click_1(object sender, EventArgs e)
        {
            if (Ivan.Checked) //CONSULTA1 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "3/" + UsernameBox.Text + "/";
                // Enviamos al servidor los parametros introducidos por teclado para realizar la consulta.
                if (UsernameBox.Text == "")
                {
                    MessageBox.Show("Consulta mal formulada.");
                }
                else
                {
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    serverConsulta.Send(msg);
                }
            }
            else if (Edgar.Checked) //CONSULTA2 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "4/" + UsernameBox.Text + "/";
                // Enviamos al servidor el username tecleado
                if (UsernameBox.Text == "")
                {
                    MessageBox.Show("Consulta mal formulada.");
                }
                else
                {
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    serverConsulta.Send(msg);
                }
            }

            else if (Omar.Checked) //CONSULTA3 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "5/" + UsernameBox.Text + "/";
                // Enviamos al servidor los parametros introducidos por teclado para realizar la consulta.
                if (UsernameBox.Text == "")
                {
                    MessageBox.Show("Consulta mal formulada.");
                }
                else
                {
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    serverConsulta.Send(msg);
                }
            }
            else
                //En el caso de no haberse identificado, se exige haberlo hecho antes de pedir la consulta.
                MessageBox.Show("Pida la consulta que desea relizar");

        }
        public void Consulta1(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public void Consulta2(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public void Consulta3(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void Ivan_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
