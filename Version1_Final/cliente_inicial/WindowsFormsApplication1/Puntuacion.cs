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
    public partial class Puntuacion : Form
    {
        //Variables comunes
        int ID;
        Socket server;
        int num;  //Guarda el numero de jugadores
        int contadorganadores; //Guarda el numero de ganadores (numero de palabras acertadas)
        int contador;

        public Puntuacion(int ID, Socket server)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.server = server;
            this.ID = ID;
        }

        public void MostrarPuntuaciones(string mensajerecibido) 
        {
            string[] trozos = mensajerecibido.Split('/');
            num = Convert.ToInt32(trozos[2]);
            contadorganadores = Convert.ToInt32(trozos[3]);
            int k = 4;
            int n = 4 + 2*num;
            int i;
            

            //Formato de la datagrid view Jugadores-Palabras
            PalabrasGrid.Rows.Clear();
            PalabrasGrid.ColumnCount = 2;
            PalabrasGrid.ColumnHeadersVisible = false;
            PalabrasGrid.DefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            PalabrasGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 50, 137);
            PalabrasGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Olive;
            PalabrasGrid.EnableHeadersVisualStyles = false;
            PalabrasGrid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);
            PalabrasGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 50, 137);

            //Formato de la datagrid view Jugadores-Puntuaciones
            PuntuacionesGrid.Rows.Clear();
            PuntuacionesGrid.ColumnCount = 2;
            PuntuacionesGrid.ColumnHeadersVisible = false;
            PuntuacionesGrid.DefaultCellStyle.BackColor = Color.Black;
            PuntuacionesGrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            PuntuacionesGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Black;
            PuntuacionesGrid.EnableHeadersVisualStyles = false;
            PuntuacionesGrid.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            PuntuacionesGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        
            PuntuacionesGrid.RowCount = num+1;
            PuntuacionesGrid.Rows[0].Cells[0].Value = "JUGADOR";
            PuntuacionesGrid.Rows[0].Cells[1].Value = "PUNTUACION";

            PalabrasGrid.RowCount = contadorganadores+1;
            PalabrasGrid.Rows[0].Cells[0].Value = "JUGADOR";
            PalabrasGrid.Rows[0].Cells[1].Value = "PALABRA ACERTADA";

            for (i = 1; i < num+1; i++)
            {
                PuntuacionesGrid.Rows[i].Cells[0].Value = trozos[k];
                PuntuacionesGrid.Rows[i].Cells[1].Value = trozos[k+1];
                k = k + 2;
            }

            for (i = 1; i < contadorganadores+1; i++)
            {
                PalabrasGrid.Rows[i].Cells[0].Value = trozos[n];
                PalabrasGrid.Rows[i].Cells[1].Value = trozos[n + 1];
                n = n + 2;
            }

            
        
        }

        private void Puntuacion_Load(object sender, EventArgs e)
        {
            label1.Text = contador.ToString();
            timer1.Start();
            timer1.Interval = 1000;
            contador = 9;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador = contador - 1;
            label1.Text = contador.ToString();

            
            if (contador == 0) {

                timer1.Stop();
                string mensaje5 = "11/" + ID + "/" + "Eliminar" + "/";
                //Eliminamos la partida.
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje5);
                server.Send(msg2);
                this.Close();           
            
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
