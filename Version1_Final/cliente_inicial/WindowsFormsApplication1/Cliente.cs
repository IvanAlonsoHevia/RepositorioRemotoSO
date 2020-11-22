using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        bool registered; //bolean que nos permite saber si el usuario esta registrado o no en la base de datos.
        bool connected; //bolean que nos permite saber si nos hemos conectado o no a la base de datos.
        delegate void DelegadoParaEscribir(string conectado);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los creaaron.
        }
        
        //Este boton nos conecta con la base de datos, y si lo hace bien, nos cambia el color del fondo a verde.
        //Sino, nos sale un mensaje para avisarnos que no se ha podido realizar.
        //Este boton introduce en la base de datos, el username y la password que el usuario ha tecleado
        //Si el username esta cogido ya (introducido previamente en la base de datos), saldra un mensaje que nos indicara que escojamos otro.
        private void registrar_Click(object sender, EventArgs e)
        {
            //El ususario no se puede conectar sin introducir el nombre de usuario y su respectiva contraseña.
            if ((connected == false) && (Username.Text != "") && (Password.Text != "") && (registered==false)) {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("147.83.117.22");
                //Nos conectamos al mismo puerto que en el servidor.
                IPEndPoint ipep = new IPEndPoint(direc, 50051);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                connected = true;

                string mensaje = "1/" + Username.Text + "/" + Password.Text;
                // Enviamos al servidor el username y password tecleadas.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
           }

            else if ((connected == true) && (Username.Text != "") && (Password.Text != "") && (registered == false))
            {
                string mensaje = "1/" + Username.Text + "/" + Password.Text;
                // Enviamos al servidor el username y password tecleadas.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
                MessageBox.Show("Debes hacer Log Out antes de registrarte con otro usuario");
            
        }

        //Este boton nos conecta con la base de datos, si no se ha registrado antes el usuario, si lo ha hecho
        //ya estará conectado y por tanto no hará falta volverlo a hacer. Se pondrá de color verde si se conecta.
        //Este boton permite conectar a un usuario ya registrado en la base de datos 
        //Si el usuario no existe o la contraseña es incorrecta, debera registrarse para realizar las consultas.
        private void login_Click(object sender, EventArgs e)
        {
            //El ususario no se puede conectar sin introducir el nombre de usuario y su respectiva contraseña.
            if (registered == false)
            {
                if ((connected == false) && (Username.Text != "") && (Password.Text != ""))
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse("147.83.117.22");
                    //Nos conectamos al mismo puerto que en el servidor.
                    IPEndPoint ipep = new IPEndPoint(direc, 50051);

                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        this.BackColor = Color.Green;
                        MessageBox.Show("Conectado");

                    }
                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No he podido conectar con el servidor");
                        return;
                    }
                    string mensaje = "2/" + Username.Text + "/" + Password.Text;
                    // Enviamos al servidor el username y password tecleadas.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                    connected = true;
                }
                else if ((connected == true) && (Username.Text != "") && (Password.Text != ""))
                {
                    string mensaje = "2/" + Username.Text + "/" + Password.Text;
                    // Enviamos al servidor el username y password tecleadas.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos");
            }
            else
                MessageBox.Show("Debes hacer Log Out antes de hacer Log In con otro usuario");
        }
        //Este boton tiene la funcion de enviar la consulta que seleccionamos con los respectivos parametros de esta introducidos por teclado.
        private void enviar_Click(object sender, EventArgs e)
        {
            if (Ivan.Checked && registered) //CONSULTA1 (solo se realizara si se ha identificado el usuario previamente)
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
                    server.Send(msg);
                }
            }
            else if (Edgar.Checked && registered) //CONSULTA2 (solo se realizara si se ha identificado el usuario previamente)
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
                    server.Send(msg);
                }
            }

            else if (Omar.Checked && registered) //CONSULTA3 (solo se realizara si se ha identificado el usuario previamente)
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
                    server.Send(msg);
                }
            }
            else
                //En el caso de no haberse identificado, se exige haberlo hecho antes de pedir la consulta.
                MessageBox.Show("Se debe loguear antes de realizar la consulta.");
        
        }

        //Este boton nos permite finalizar la conexion con la base de datos.
        //Una vez hecha la desconexion, cambia el color del fondo a gris.
        //Aparte hace un log out de la sesión.
        private void logout_Click(object sender, EventArgs e)
        {
            //Cuando el ususario se desconecta, la grid view esta vacia y además cambia el fondo a gris.
            NumConn.Text = "0";
            registered = false;
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            connected = false;
            ListaConectados.Rows.Clear();
            atender.Abort();
        }
        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensajerecibido = Encoding.ASCII.GetString(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                string mensaje2;
                switch (codigo)
                {
                   case 1:
                        if (mensaje == "SI")
                        {
                            MessageBox.Show("El usuario: " + Username.Text + ", se ha registrado correctamente.");
                        }
                        else
                            MessageBox.Show("El usuario: " + Username.Text + ", ya está cogido.");
                        break;
                    case 2:
                        mensaje2 = trozos[2].Split('\0')[0];

                        if (mensaje == "SI")
                        {
                            if (mensaje2 == "El usuario: " + Username.Text + ", se ha anadido correctamente a la lista")
                            {
                                MessageBox.Show(mensaje2);
                                registered = true;
                            }
                            else
                            {
                                MessageBox.Show(mensaje2);
                                registered = false;
                            }
                        }
                        else
                            MessageBox.Show(mensaje2);
                        break;
                    case 3:
                            MessageBox.Show(mensaje);
                        break;
                    case 4:
                            MessageBox.Show(mensaje);
                        break;
                    case 5:
                            MessageBox.Show(mensaje);
                        break;
                    case 6:
                        //Recibimos notificación
                        int nm = Convert.ToInt32(mensaje);
                        if (nm != 0)
                        {
                            ListaConectados.Rows.Clear();
                            NumConn.Text = mensaje;
                            int i;
                            for (i = 2; i < nm+2; i++)
                            {
                                mensaje2 = trozos[i].Split('\0')[0];
                                DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonTabla);
                                ListaConectados.Invoke(delegado, new object [] {mensaje2});
                            }
                            ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                        else
                            NumConn.Text = "0";
                        break;
                }
            }
        }

        public void PonTabla(string conectado)
        {
            ListaConectados.Rows.Add(conectado);
            ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NumConn.Text = "0";
            registered = false;
            connected = false;
            ListaConectados.Rows.Clear();
            ListaConectados.ColumnCount = 1;
            ListaConectados.ColumnHeadersVisible = true;
        }
    }
}