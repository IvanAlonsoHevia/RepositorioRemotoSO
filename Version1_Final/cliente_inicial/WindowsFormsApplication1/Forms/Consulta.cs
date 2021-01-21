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
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            label8.ForeColor = ThemeColor.SecondaryColor;
        }

        private void enviar_Click_1(object sender, EventArgs e)
        {
            if (Ivan.Checked) //CONSULTA1 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "3/" + PerdedorBox.Text + "/" + PosicionBox.Text + "/" + PuntuacionBox.Text;
                // Enviamos al servidor los parametros introducidos por teclado para realizar la consulta.
                if ((PerdedorBox.Text == "") || (PosicionBox.Text == "") || (PuntuacionBox.Text == ""))
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
                string mensaje = "4/" + UsernameConsultaBox.Text;
                // Enviamos al servidor el username tecleado
                if (UsernameConsultaBox.Text == "")
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
                string mensaje = "5/" + NumJugadoresBox.Text + "/" + PuntuacionBox.Text + "/" + FechaBox.Text;
                // Enviamos al servidor los parametros introducidos por teclado para realizar la consulta.
                if ((NumJugadoresBox.Text == "") || (PuntuacionBox.Text == "") || (FechaBox.Text == ""))
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
