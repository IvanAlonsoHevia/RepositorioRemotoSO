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
    public partial class JugarPartida : Form
    {
        bool[] invited = new bool [100]; //Array de booleanos que hace referencia a si se han respondido todas las invitaciones en una partida o no.
        int[] JugadoresRespuesta = new int[100]; //Array de integuers que indica el número de jugadores de una partida.
        string usuario; //Jugador
        Socket server; //Servidor
        int ID; //ID de la partida
        public JugarPartida(Socket server)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los crearon.
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
        }

        private void Jugar_Click(object sender, EventArgs e)
        {
            //Escogemos el ID de la partida en la que queremosjugar.
            ID = Convert.ToInt32(ListaPartidas.CurrentCell.Value.ToString());
            if (invited[ID])
            {
                
                //Le pasamos el personaje escogido 
                string mensaje = "11/" + Convert.ToString(ID) +"/Jugar/";
                // Enviamos al servidor que queremos jugar.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            else
                MessageBox.Show("Por favor, espera a que sean contestadas todas tus invitaciones.");
        }

        public void EscribirenListaPartidas(string mensajerecibido)
        {
            ListaPartidas.Rows.Clear();
            ListaPartidas.ColumnCount = 1;
            ListaPartidas.ColumnHeadersVisible = true;
            ListaPartidas.DefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            ListaPartidas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 50, 137);
            ListaPartidas.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Olive;
            ListaPartidas.EnableHeadersVisualStyles = false;
            ListaPartidas.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            ListaPartidas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);

            string[] trozos = mensajerecibido.Split('/');
            string mensaje = trozos[1].Split('\0')[0];
            string mensaje2;
            int nm = Convert.ToInt32(mensaje);
            if (nm != 0)
            {
                ListaPartidas.Rows.Clear();
                partidasBox.Text = mensaje;
                int i;
                for (i = 2; i < nm + 2; i++)
                {
                    mensaje2 = trozos[i].Split('\0')[0];
                    ListaPartidas.Rows.Add(mensaje2);
                    ListaPartidas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                ListaPartidas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
                partidasBox.Text = "0";
        }

        public void TomaUsuario(string user)
        {
            usuario = user;
        }

        private void JugarPartida_Load(object sender, EventArgs e)
        {
            LoadTheme();  
        }

        public void TomaIDyBool(int id, bool invitado, int juegan)
        {
            invited[id] = invitado; //Booleano que dice si todos han respondido o no a la invitación.
            JugadoresRespuesta[id] = juegan; //Número de jugadores que juegan en la partida id.
        }

        

       
    }
}
