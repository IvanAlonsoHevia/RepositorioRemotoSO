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

namespace WindowsFormsApplication1.Forms
{
    public partial class CrearPartida : Form
    {
        JugarPartida FormJugarPartida;
        string usuario;
        int cont;
        int ID;
        int juegan;
        Socket server;
        bool algunañadido; //bolean que nos permite saber si hay algún usuario añadido a la partida.
        bool invited; //bolean que nos permite saber si se ha invitado ya o no.
        string[] invitado = new string[5];
        int contador;

        public CrearPartida(Socket server)
        {
            InitializeComponent();
            this.server = server;
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
            //label3.ForeColor = ThemeColor.SecondaryColor;
            //label4.ForeColor = ThemeColor.PrimaryColor;
            //label5.ForeColor = ThemeColor.SecondaryColor;
            //label6.ForeColor = ThemeColor.PrimaryColor;
            //label7.ForeColor = ThemeColor.SecondaryColor;
            //label7.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Añadir_Click(object sender, EventArgs e)
        {
            if (invited)
            {
                if (ListaConectados.CurrentCell.Value.ToString() != usuario)
                {
                    bool encontrado = false;
                    int i = 0;
                    while (i < contador && !encontrado)
                    {
                        if (invitado[i] == ListaConectados.CurrentCell.Value.ToString())
                        {
                            encontrado = true;
                        }
                        i++;
                    }
                    if (!encontrado)
                    {
                        invitado[contador] = ListaConectados.CurrentCell.Value.ToString();
                        MessageBox.Show(invitado[contador] + " ha sido añadido correctamente a la lista de invitaciones");
                        contador = contador + 1;
                        algunañadido = true;
                    }
                    else
                        MessageBox.Show("El usuario ya ha sido añadido anteriormente a la lista de invitaciones");

                }
                else
                {
                    MessageBox.Show("Selecciona otro usuario distinto a ti mismo");
                }
            }
        }

        private void Invitar_Click(object sender, EventArgs e)
        { 
            if (algunañadido == false)
            {
                MessageBox.Show("Añade como mínimo a otro usuario más para poder jugar la partida");
            }
            else
            {
                string mensaje = "7/";
                int i = 0;
                string envio;
                while (i < contador)
                {
                    if (i == contador - 1)
                    {
                        envio = invitado[i];
                    }
                    else
                    {
                        envio = invitado[i] + "/";
                    }
                    mensaje += envio;
                    i = i + 1;
                }
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                i = 0;
                while (i < contador)
                {
                    invitado[i] = "";
                    i = i + 1;
                }
                algunañadido = false;
                invited = false;
                juegan = 1;
            }
        }
        public void EscribirenListaConectados(string mensajerecibido)
        {
            NumConn.Text = "0";
            algunañadido = false;
            invited = true;
            contador = 0;
            cont = 0;
            juegan = 1;
            ListaConectados.Rows.Clear();
            ListaConectados.ColumnCount = 1;
            ListaConectados.ColumnHeadersVisible = true;
            ListaConectados.DefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            ListaConectados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 50, 137);
            ListaConectados.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Olive;
            ListaConectados.EnableHeadersVisualStyles = false;
            ListaConectados.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            ListaConectados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            string[] trozos = mensajerecibido.Split('/');
            string mensaje = trozos[1].Split('\0')[0];
            string mensaje2;
            int nm = Convert.ToInt32(mensaje);
            if (nm != 0)
            {
                ListaConectados.Rows.Clear();
                NumConn.Text = mensaje;
                int i;
                for (i = 2; i < nm + 2; i++)
                {
                    mensaje2 = trozos[i].Split('\0')[0];
                    ListaConectados.Rows.Add(mensaje2);
                    ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
                NumConn.Text = "0";
        }

        public void TomaUsuario(string user)
        {
            usuario = user;
        }

        //public void PonTabla(string conectado)
        //{
        //    ListaConectados.Rows.Add(conectado);
        //    ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //}

        public void HacerInvitacion(string mensajerecibido)
        {
            string[] trozos = mensajerecibido.Split('/');
            string mensaje = trozos[1].Split('\0')[0];
            string mensaje2;
            ID = Convert.ToInt32(mensaje);
            mensaje2 = trozos[2].Split('\0')[0];
            DialogResult result;
            if (ID != -1)
            {

                result = (MessageBox.Show("Hola, " + usuario + ": " + mensaje2 + " te ha invitado a jugar a la partida " + ID + ", ¿aceptas?", "aceptar", MessageBoxButtons.YesNo));
                switch (result)
                {
                    case DialogResult.Yes:
                        string envio = "8/" + mensaje + "/SI";
                        // Enviamos al servidor el username y password tecleadas.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(envio);
                        server.Send(msg);
                        break;
                    case DialogResult.No:
                        envio = "8/" + mensaje + "/NO";
                        // Enviamos al servidor el username y password tecleadas.
                        msg = System.Text.Encoding.ASCII.GetBytes(envio);
                        server.Send(msg);
                        break;
                }
            }
            else
                MessageBox.Show(mensaje2);
        }

        public void RecibirRespuesta(string mensajerecibido)
        {
            string[] trozos = mensajerecibido.Split('/');
            string mensaje = trozos[1].Split('\0')[0];
            string mensaje2;
            ID = Convert.ToInt32(mensaje);
            mensaje2 = trozos[2].Split('\0')[0];
            string mensaje3 = trozos[3].Split('\0')[0];
            if (mensaje3 == "SI")
            {
                MessageBox.Show(mensaje2 + " ha aceptado a jugar la partida " + ID);
                cont = cont + 1;
                juegan = juegan + 1;
            }
            else
            {
                MessageBox.Show(mensaje3);
                cont = cont + 1;
            }

            if (cont == contador)
            {
                invited = true;
                contador = 0;
                cont = 0;
                FormJugarPartida.TomaIDyBool(invited, ID);
                if (juegan < 2)
                {
                    string mensaje4 = "11/" + ID + "/" + "Eliminar" + "/";
                    //Eliminamos la partida.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje4);
                    server.Send(msg);
                }
            }
        }

        private void CrearPartida_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        public void dameFormPartida(JugarPartida FormPartida)
        {
            FormJugarPartida = FormPartida;
        }
    }
}
