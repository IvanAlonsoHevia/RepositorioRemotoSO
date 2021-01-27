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
        int cont = 0;//Contador de las respuestas a las invitaciones (ya sea si o no).
        int ID;//ID de la partida.
        int juegan = 1;//Número de jugadores que juegan en la partida.
        Socket server;//Socket del cliente que le pasamos desde el login.
        bool algunañadido = false;//bolean que nos permite saber si hay algún usuario añadido a la partida.
        bool invited = true; //bolean que nos permite saber si se ha invitado ya o no.
        string[] invitado = new string[4];//Array de invitados.
        int contador = 0; //Número de invitaciones

        public CrearPartida(Socket server)
        {
            InitializeComponent();
            this.server = server;
        }
        private void LoadTheme() //Formato (interfaz)
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

        private void Añadir_Click(object sender, EventArgs e) //Función que añade a los conectados seleccionados de la DataGridViewa una Lista de invitados.
        {
            if (invited) //Si ya han contestado las invitaciones de la anterior partida, te dej invitar jugadores a una nueva.
            {
                if (ListaConectados.CurrentCell.Value.ToString() != usuario)
                {
                    bool encontrado = false;
                    int i = 0;
                    while (i < contador && !encontrado) //Bucle que mira si el jugador ya está enla lista de invitados para no volverlo a meter.
                    {
                        if (invitado[i] == ListaConectados.CurrentCell.Value.ToString())
                        {
                            encontrado = true;
                        }
                        i++;
                    }
                    if (!encontrado) //Añadimos el nuevo jugador a la Lista de Invitados.
                    {
                        invitado[contador] = ListaConectados.CurrentCell.Value.ToString();
                        MessageBox.Show(invitado[contador] + " ha sido añadido correctamente a la lista de invitaciones");
                        contador = contador + 1; //Número de jugadores invitados hasta el momento.
                        algunañadido = true; //Ya hay como mínimo un jugador invitado.
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
                while (i < contador) //Construimos el mensaje con la Lista de Invitados para el servidor.
                {
                    envio = invitado[i] + "/";
                    mensaje += envio;
                    i = i + 1;
                }
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                i = 0;
                while (i < contador) //Reseteamos la lista de invitados una vez enviada la invitación a todos.
                {
                    invitado[i] = "";
                    i = i + 1;
                }
                algunañadido = false; //Reseteamos el booleano para evitardarle sin querer y que se envíe un 7/ al servidor.
                invited = false; //Aun no han respondido la invitación los invitados.
                juegan = 1; //Como mínimo jueg el jugador que invitada
            }
        }
        public void EscribirenListaConectados(string mensajerecibido) //Actualizar la lista de conectados
        {
            NumConn.Text = "0";
            //Formato (interfaz)
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
                    mensaje2 = trozos[i].Split('\0')[0]; //Sacamos los nombres de usuario de los conectados
                    ListaConectados.Rows.Add(mensaje2);
                    ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
                NumConn.Text = "0";
        }

        public void TomaUsuario(string user) //Recogemos el usuario del login
        {
            usuario = user;
        }

        public void HacerInvitacion(string mensajerecibido) //Recibe la invitación "7/ID/NombreAnfitrión
        {
            string[] trozos = mensajerecibido.Split('/');
            string mensaje = trozos[1];
            string mensaje2;
            ID = Convert.ToInt32(mensaje);
            mensaje2 = trozos[2];
            DialogResult result;
            if (ID != -1)
            {

                result = (MessageBox.Show("Hola, " + usuario + ": " + mensaje2 + " te ha invitado a jugar a la partida " + ID + ", ¿aceptas?", "aceptar", MessageBoxButtons.YesNo));
                switch (result) //Generamos la respuesta con un DialogResult 
                {
                    //Envíamos la respuesta al servidor: "8/ID/SI ó 8/ID/NO"
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

        public void RecibirRespuesta(string mensajerecibido) //Recibe del servidor: "8/ID/NombreInvitado/SI"
        {
            string[] trozos = mensajerecibido.Split('/');
            string mensaje = trozos[1].Split('\0')[0];
            string mensaje2;
            ID = Convert.ToInt32(mensaje);
            mensaje2 = trozos[2].Split('\0')[0];
            string mensaje3 = trozos[3].Split('\0')[0];
            if (mensaje3 == "SI") //Si me contestan que si mostramos un mensaje y sumamos el juegan (numero de jugadores de la partida) y el cont (número de jugadores que responde a la invitación)
            {
                MessageBox.Show(mensaje2 + " ha aceptado a jugar la partida " + ID);
                cont = cont + 1;
                juegan = juegan + 1;
            }
            else //Si no, solo sumo el número de jugadores que responden a la invitación y muestro la respuesta.
            {
                MessageBox.Show(mensaje3);
                cont = cont + 1;
            }

            if (cont == contador) //Una vez que respondan todos a la invitación 
            {
                //Inicializo el invited y los contadores.
                invited = true; 
                contador = 0;
                cont = 0;
                string mensaje4 = "14/" + ID + "/" + invited + "/" + juegan;
                //Enviamos el booleano invited de que todos hayan contestado y el número de jugadores que hay en la partida.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje4);
                server.Send(msg);
                if (juegan < 2) //Si todos los invitados me contestan que no, Eliminamos la partida ya que no puede haber un solo jugador.
                {
                    string mensaje5 = "11/" + ID + "/" + "Eliminar" + "/";
                    //Eliminamos la partida.
                    byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje5);
                    server.Send(msg2);
                }
            }
        }

        private void CrearPartida_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        public void dameFormPartida(JugarPartida FormPartida) //Recibimos el Form Jugar Partida 
        {
            FormJugarPartida = FormPartida;
        }
    }
}
