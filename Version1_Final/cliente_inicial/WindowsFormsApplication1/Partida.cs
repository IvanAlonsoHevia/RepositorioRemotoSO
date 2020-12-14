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
using WindowsFormsApplication1.Forms;

namespace WindowsFormsApplication1
{
    public partial class Partida : Form
    {
        int idOrigen;
        int ID;
        Socket server;
        public Partida(int ID, Socket server)
        {
            InitializeComponent();
            this.server = server;
            this.ID = ID;
        }

        public void bienvenido (string mensajerecibido)
        {
            Bienvenido.Text = mensajerecibido;
        }

        public void RecibirChat(int idOrigen, string autor, string message)
        {
            if (idOrigen == ID)
            {
                MensajesChat.SelectionFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                MensajesChat.SelectionColor = Color.Green;
                MensajesChat.AppendText(autor);
                MensajesChat.SelectionFont = new Font("Microsoft Sans Serif", 8);
                MensajesChat.SelectionColor = Color.White;
                MensajesChat.AppendText(" :\n" + message + "\r\n");
                MensajesChat.ScrollToCaret();
                MensajesChat.BackColor = Color.Black;
            }
        }

        private void EnviarChat_Click(object sender, EventArgs e)
        {
            string mensaje = "9/" + ID + "/" + textChat.Text + "/";
            // Enviamos al servidor el mensaje del chat.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            textChat.Text = "";
        }

        private void textChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string mensaje = "9/" + ID + "/" + textChat.Text + "/";
                // Enviamos al servidor el mensaje del chat.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                textChat.Text = "";
            }
        }
    }
}