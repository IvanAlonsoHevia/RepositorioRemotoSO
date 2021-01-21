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
    public partial class login : Form
    {
        List<Partida> formulariosPartida = new List<Partida>();
        int contFormsPartida;
        Partida FormPartida;
        string autor;
        List<Main> formulariosMain = new List<Main>();  //Creamos lista formularios de tipo Main
        List<Consulta> formulariosConsulta = new List<Consulta>(); //Creamos lista formularios de tipo Consulta
        List<CrearPartida> formulariosCrearPartida = new List<CrearPartida>(); //Creamos lista formularios de tipo CrearPartida
        List<JugarPartida> formulariosJugarPartida = new List<JugarPartida>(); //Creamos lista formularios de tipo JugarParida
        int contFormsMain;
        int contFormsConsulta;
        int contFormsCrearPartida;
        int contFormsJugarPartida;
        Socket server;
        Thread atender;
        bool registered; //bolean que nos permite saber si el usuario esta registrado o no en la base de datos.
        bool connected; //bolean que nos permite saber si nos hemos conectado o no a la base de datos.
        bool formularioAbierto;
        delegate void DelegadoChat(int ID, string Autor, string mensaje);
        delegate void DelegadoPalabra(int ID, string mensaje1, int mensaje2);        
        delegate void DelegadoPartida(int ID, string mensaje1, char mensaje2);
        delegate void DelegadoPartida2(int ID, string mensaje1, int mensaje2, string mensaje3);
        delegate void DelegadoPartida3(int ID, string mensaje1);
        delegate void DelegadoBienvenido(int ID, string mensaje1);

        public login()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los crearon.
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Funciones para mostrar "USUARIO" y "CONTRASEÑA" en los campos correspondientes cuando no hay nada escrito
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        //Boton para cerrar el formulario y desconectarnos del servidor
        private void btncerrar_Click(object sender, EventArgs e)
        {
            if (connected == true)
            {
                registered = false;    //Cuando el ususario se desconecta, ya no esta logeado
                //Mensaje de desconexión
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Cerramos todos los otros formularios si estan abiertos
                if (formularioAbierto)
                {
                    formularioAbierto = false;
                    formulariosMain[contFormsMain].Close();
                    formulariosCrearPartida[contFormsCrearPartida].Close();
                    formulariosJugarPartida[contFormsJugarPartida].Close();
                }

                //Nos desconectamos
                connected = false;
                Application.Exit();
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                atender.Abort();
                this.Close();
            }
            
        }

        //Boton para minimizar el formulario
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Botón para maximizar el formulario
        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmaximizar.Visible = false;
            btnrest.Visible = true;           
        }

        //Botón para reescalar el formulario
        private void btnrest_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnrest.Visible = false;
            btnmaximizar.Visible = true;                
        }
        
        //Este boton nos conecta con la base de datos.
        //Sino, nos sale un mensaje para avisarnos que no se ha podido realizar.
        //Este boton introduce en la base de datos, el username y la password que el usuario ha tecleado
        //Si el username esta cogido ya (introducido previamente en la base de datos), saldra un mensaje que nos indicara que escojamos otro.
        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            //El ususario no se puede conectar sin introducir el nombre de usuario y su respectiva contraseña.
            if (registered == false)
            {
                if ((connected == false) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (txtuser.Text != "") && (txtpass.Text != ""))
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse("192.168.56.102");
                    //Nos conectamos al mismo puerto que en el servidor.
                    IPEndPoint ipep = new IPEndPoint(direc, 50052);


                    //Creamos el socket 
                    //Este proceso lo debe hacer una única vez, cuando nos conectamos.
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        connected = true;  //Ya estoy conectado con el servidor

                    }
                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No he podido conectar con el servidor");
                        return;
                    }


                    string mensaje = "1/" + txtuser.Text + "/" + txtpass.Text;
                    MessageBox.Show(mensaje);
                    // Enviamos al servidor el username y password tecleadas.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                }

                else if ((connected == true) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (txtuser.Text != "") && (txtpass.Text != ""))
                {
                    string mensaje = "1/" + txtuser.Text + "/" + txtpass.Text;
                    MessageBox.Show(mensaje);
                    // Enviamos al servidor el username y password tecleadas.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos");
            }
            else
                MessageBox.Show("Debes hacer Log Out antes de registrarte con otro usuario");
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (connected == true)
            {
                registered = false;    //Cuando el ususario se desconecta, ya no esta logeado
                //Mensaje de desconexión
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Cerramos todos los otros formularios
                if (formularioAbierto)
                {
                    formularioAbierto = false;
                    formulariosMain[contFormsMain].Close();
                    formulariosCrearPartida[contFormsCrearPartida].Close();
                    formulariosJugarPartida[contFormsJugarPartida].Close();
                }

                // Nos desconectamos
                connected = false;
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                
            }
        }

        public void AbrirMain()
        {
            //Sacamos el valor del contador de cada lista de formularios
            contFormsMain = formulariosMain.Count;
            contFormsConsulta = formulariosConsulta.Count;
            contFormsCrearPartida = formulariosCrearPartida.Count;
            contFormsJugarPartida = formulariosJugarPartida.Count;
            //Creamos formularios
            Main FormMain = new Main(server);  
            Consulta FormConsulta = new Consulta(server);
            CrearPartida FormCrearPartida = new CrearPartida(server);
            JugarPartida FormJugarPartida = new JugarPartida(server);
            formularioAbierto = true;
            //Añadimos los formularios a cada lista de formularios
            formulariosMain.Add(FormMain);
            formulariosConsulta.Add(FormConsulta);
            formulariosCrearPartida.Add(FormCrearPartida);
            formulariosJugarPartida.Add(FormJugarPartida);
            //Le pasamos al Main el form CrearPartida
            formulariosMain[contFormsMain].dameFormCrearPartida(FormCrearPartida);
            //Le pasamos al Main el form JugarPartida
            formulariosMain[contFormsMain].dameFormJugarPartida(FormJugarPartida);
            //Le pasamos al Main el form JugarPartida
            formulariosMain[contFormsMain].dameFormConsulta(FormConsulta); 
            //Le pasamos el nombre del usuario al Main y al CrearPartida
            formulariosCrearPartida[contFormsCrearPartida].TomaUsuario(txtuser.Text);
            formulariosMain[contFormsMain].TomaUsuario(txtuser.Text);
            //Solo mostramos el form Main, desde donde se podrán abrir los demás formularios
            FormMain.ShowDialog();
            this.Close();
        }

        //Este boton nos conecta con la base de datos, si no se ha registrado antes el usuario, si lo ha hecho
        //ya estará conectado y por tanto no hará falta volverlo a hacera.
        //Este boton permite conectar a un usuario ya registrado en la base de datos 
        //Si el usuario no existe o la contraseña es incorrecta, debera registrarse para realizar las consultas.
        private void btnacceder_Click(object sender, EventArgs e)
        {
            //El ususario no puede acceder puede conectar sin estar logeado
            //Una vez logeado accederá una sola vez
            if (registered == false)
            {
                if ((connected == false) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (txtuser.Text != "") && (txtpass.Text != ""))
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse("192.168.56.102");
                    //Nos conectamos al mismo puerto que en el servidor.
                    IPEndPoint ipep = new IPEndPoint(direc, 50052);

                    //Creamos el socket
                    //Este proceso lo debe hacer una única vez, cuando nos conectamos.
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        connected = true; //Nos hemos conectado al servidor

                    }
                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No he podido conectar con el servidor");
                        return;
                    }
                    string mensaje = "2/" + txtuser.Text + "/" + txtpass.Text;
                    // Enviamos al servidor el username y password tecleadas.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Ponemos en marcha el thread de AtenderServidor
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();                   

                    
                }
                else if ((connected == true) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (txtuser.Text != "") && (txtpass.Text != ""))
                {
                    string mensaje = "2/" + txtuser.Text + "/" + txtpass.Text;
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

        public void AbrirPartida(int ID, string mensajerecibido)
        {
            contFormsPartida = formulariosPartida.Count;
            FormPartida = new Partida(ID, server); //Pasamos el socket, el ID y el username como constructores al Form de la partida al recibir el código 11.
            formulariosPartida.Add(FormPartida);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            formulariosPartida[contFormsPartida].RecibirUsernameyNumJugadores(mensajerecibido); 
            FormPartida.ShowDialog();
        }

        public void EnviarPalabra(int ID, string palabra, int longitud)
        {
            int i;
            for (i = 0; i <= contFormsPartida; i++)
            {
                formulariosPartida[i].RecibirPalabra(ID, palabra, longitud); //El contador de formularios de Partida puede no corresponderse con el ID de la partida.
            }
        }

        public void PasarleFormJugarPartida()
        {
            formulariosCrearPartida[contFormsCrearPartida].dameFormPartida(formulariosJugarPartida[contFormsJugarPartida]);
        }

        public void ThreadPartida(int ID, string mensajerecibido)
        {
            ThreadStart te = delegate { AbrirPartida(ID, mensajerecibido); };
            Thread form1 = new Thread(te);
            form1.Start();
        }

        public void EnviarChat(int ID, string Autor, string mensaje)
        {
            int i;
            for (i = 0; i <= contFormsPartida; i++)
            {
                formulariosPartida[i].RecibirChat(ID, Autor, mensaje); //El contador de formularios de Partida puede no corresponderse con el ID de la partida.
            }
        }

        public void EnviarJugada(int ID, string continua, char letra)
        {
            int i;
            for (i = 0; i <= contFormsPartida; i++)
            {
                formulariosPartida[i].RecibirJugada(ID, continua, letra); //El contador de formularios de Partida puede no corresponderse con el ID de la partida.
            }
        }

        public void EnviarJugada2(int ID, string user, int ronda, string mensajerecibido)
        {
            int i;
            for (i = 0; i <= contFormsPartida; i++)
            {
                formulariosPartida[i].RecibirJugada2(ID, user, ronda, mensajerecibido); //El contador de formularios de Partida puede no corresponderse con el ID de la partida.
            }
        }

        public void EnviarJugada3(int ID, string mensajerecibido)
        {
            int i;
            for (i = 0; i <= contFormsPartida; i++)
            {
                formulariosPartida[i].RecibirJugada3(); //El contador de formularios de Partida puede no corresponderse con el ID de la partida.
            }
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensajerecibido = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensajerecibido.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1];
                string mensaje2;
                switch (codigo)
                {
                    case 1:
                        if (mensaje == "SI")
                        {
                            mensaje2 = trozos[2];
                            MessageBox.Show("El usuario: " + mensaje2 + ", se ha registrado correctamente.");
                        }
                        else
                        {
                            mensaje2 = trozos[2];
                            MessageBox.Show("El usuario: " + mensaje2 + ", ya está cogido.");
                        }
                        break;


                    case 2:
                        mensaje2 = trozos[2];

                        if (mensaje == "SI")
                        {
                            if (mensaje2 == "El usuario: " + txtuser.Text + ", se ha anadido correctamente a la lista")
                            {
                                registered = true; //ya estamos logeados
                                MessageBox.Show(mensaje2);
                                //Abrimos el formulario Main a través de un delegate
                                ThreadStart ti = delegate { AbrirMain(); };
                                Thread T = new Thread(ti);
                                T.Start();
                            }
                            else
                            {
                                MessageBox.Show(mensaje2);
                            }
                        }
                        else
                            MessageBox.Show(mensaje2);

                        break;

                    case 3:
                        //Enviar la respuesta a la consulta 1 al Form Consulta.
                        formulariosConsulta[contFormsConsulta].Consulta1(mensaje);
                        break;

                    case 4:
                        //Enviar la respuesta a la consulta 2 al Form Consulta.
                        formulariosConsulta[contFormsConsulta].Consulta2(mensaje);
                        break;

                    case 5:
                        //Enviar la respuesta a la consulta 3 al Form Consulta.
                        formulariosConsulta[contFormsConsulta].Consulta3(mensaje);
                        break;

                    case 6:
                        //Recibimos notificación 
                        System.Threading.Thread.Sleep(500); //damos tiempo a que el programa cree los formularios
                        //No puede enviar nada a ningun formulario hasta que no esten creados
                        if (registered)
                            formulariosCrearPartida[contFormsCrearPartida].EscribirenListaConectados(mensajerecibido); //solo escribimos la notificación si el usuario se ha logeado correctamente
                        break;

                    case 7:
                        formulariosCrearPartida[contFormsCrearPartida].HacerInvitacion(mensajerecibido);
                        break;

                    case 8:
                        //Abrimos el formulario Main a través de un delegate
                        ThreadStart th = delegate { PasarleFormJugarPartida(); };
                        Thread thr = new Thread(th);
                        thr.Start();
                        formulariosCrearPartida[contFormsCrearPartida].RecibirRespuesta(mensajerecibido);
                        break;

                    case 9:

                        mensaje2 = trozos[2];
                        autor = mensaje2;
                        string mensaje3 = trozos[3];
                        DelegadoChat delegadochat = new DelegadoChat(EnviarChat);
                        this.Invoke(delegadochat, new object[] { Convert.ToInt32(mensaje), autor, mensaje3 });
                        break;

                    case 10:
                        //Recibimos notificación 
                        formulariosJugarPartida[contFormsJugarPartida].TomaUsuario(txtuser.Text);
                        formulariosJugarPartida[contFormsJugarPartida].EscribirenListaPartidas(mensajerecibido);
                        break;

                    case 11:
                        //Jugada
                        DelegadoBienvenido delegadobienvenido = new DelegadoBienvenido(ThreadPartida);
                        this.Invoke(delegadobienvenido, new object[ ] {Convert.ToInt32(mensaje), mensajerecibido});
                        break;

                    case 12:
                        //Darse de baja
                        MessageBox.Show(mensaje);
                        break;

                    case 13:
                        //Recibir palabra del jugador que escoge
                        DelegadoPalabra delegadopalabra = new DelegadoPalabra(EnviarPalabra);
                        this.Invoke(delegadopalabra, new object[] {Convert.ToInt32(mensaje), trozos[2], Convert.ToInt32(trozos[3])});
                        break;

                    case 14:
                        mensaje2 = trozos[2];
                        mensaje3 = trozos[3];
                        formulariosJugarPartida[contFormsJugarPartida].TomaIDyBool(Convert.ToInt32(mensaje), Convert.ToBoolean(mensaje2), Convert.ToInt32(mensaje3)); 
                        break;

                    case 15:

                        DelegadoPartida delegadopartida = new DelegadoPartida(EnviarJugada);
                        this.Invoke(delegadopartida, new object[] { Convert.ToInt32(mensaje), trozos[2], Convert.ToChar(trozos[3])});
                        break;

                    case 16:

                        DelegadoPartida2 delegadopartida2 = new DelegadoPartida2(EnviarJugada2);
                        this.Invoke(delegadopartida2, new object[] { Convert.ToInt32(mensaje), trozos[2], Convert.ToInt32(trozos[3]), mensajerecibido});
                        break;

                    case 17:

                        DelegadoPartida3 delegadopartida3 = new DelegadoPartida3(EnviarJugada3);
                        this.Invoke(delegadopartida3, new object[] { });
                        break;

                    
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            //Cuando abrimos el formulario login no estamos ni conectados ni logeados ni tenemos el formulario main abierto
            connected = false;
            registered = false;
        }

        private void signout_Click(object sender, EventArgs e)
        {
            if (registered == false)
            {
                if ((connected == false) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (txtuser.Text != "") && (txtpass.Text != ""))
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse("192.168.56.102");
                    //Nos conectamos al mismo puerto que en el servidor.
                    IPEndPoint ipep = new IPEndPoint(direc, 50053);

                    //Creamos el socket
                    //Este proceso lo debe hacer una única vez, cuando nos conectamos.
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        connected = true; //Nos hemos conectado al servidor

                    }
                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No he podido conectar con el servidor");
                        return;
                    }

                    DialogResult dr = MessageBox.Show("¿Estás seguro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes) 
                    {
                        string mensaje = "12/" + txtuser.Text + "/" + txtpass.Text;
                        // Enviamos al servidor el username y password tecleadas.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }         

                    //Ponemos en marcha el thread de AtenderServidor
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                }

                else if ((connected == true) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (txtuser.Text != "") && (txtpass.Text != ""))
                {
                    DialogResult dr = MessageBox.Show("¿Estás seguro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        string mensaje = "12/" + txtuser.Text + "/" + txtpass.Text;
                        // Enviamos al servidor el username y password tecleadas.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    } 

                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos");
                
            }
            else
                MessageBox.Show("Debes hacer Log Out para poder darte de baja");
        }
    }
}