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
        int ID;
        int contFormsPartida;
        Partida FormPartida;
        string autor;
        CrearPartida FormCrearPartida;
        JugarPartida FormJugarPartida;
        int contFormsMain;
        int contFormsConsulta;
        int contFormsCrearPartida;
        int contFormsJugarPartida;
        List<Main> formulariosMain = new List<Main>();
        List<Consulta> formulariosConsulta = new List<Consulta>();
        List<CrearPartida> formulariosCrearPartida = new List<CrearPartida>();
        List<JugarPartida> formulariosJugarPartida = new List<JugarPartida>();
        Socket server;
        Thread atender;
        bool registered; //bolean que nos permite saber si el usuario esta registrado o no en la base de datos.
        bool connected; //bolean que nos permite saber si nos hemos conectado o no a la base de datos.
        delegate void DelegadoChat(int ID, string Autor, string mensaje);
        delegate void DelegadoBienvenido(string mensaje);
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

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            atender.Abort();
        }

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

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmaximizar.Visible = false;
            btnrest.Visible = true;           
        }

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
            if ((connected == false) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (registered == false))
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("147.83.117.22");
                //IPAddress direc = IPAddress.Parse("192.168.56.102");
                //Nos conectamos al mismo puerto que en el servidor.
                IPEndPoint ipep = new IPEndPoint(direc, 50052);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    MessageBox.Show("Conectado");

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                connected = true;

                string mensaje = "1/" + txtuser.Text + "/" + txtpass.Text;
                // Enviamos al servidor el username y password tecleadas.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }

            else if ((connected == true) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA") && (registered == false))
            {
                string mensaje = "1/" + txtuser.Text + "/" + txtpass.Text;
                // Enviamos al servidor el username y password tecleadas.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
                MessageBox.Show("Debes hacer Log Out antes de registrarte con otro usuario");
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            //Cuando el ususario se desconecta, la grid view esta vacia y además cambia el fondo a gris.
            //NumConn.Text = "0";
            registered = false;
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


            // Nos desconectamos
            connected = false;
            //ListaConectados.Rows.Clear();
            //ListaPartidas.Rows.Clear();
            atender.Abort();
        }

        public void AbrirMain()
        {
            contFormsMain = formulariosMain.Count;
            contFormsConsulta = formulariosConsulta.Count;
            contFormsCrearPartida = formulariosCrearPartida.Count;
            contFormsJugarPartida = formulariosJugarPartida.Count; 
            Main FormMain = new Main(server);
            Consulta FormConsulta = new Consulta(server);
            FormCrearPartida = new CrearPartida(server);
            FormJugarPartida = new JugarPartida(server);
            formulariosMain.Add(FormMain);
            formulariosConsulta.Add(FormConsulta);
            formulariosCrearPartida.Add(FormCrearPartida);
            formulariosJugarPartida.Add(FormJugarPartida);
            FormMain.ShowDialog();
        }

        //Este boton nos conecta con la base de datos, si no se ha registrado antes el usuario, si lo ha hecho
        //ya estará conectado y por tanto no hará falta volverlo a hacera.
        //Este boton permite conectar a un usuario ya registrado en la base de datos 
        //Si el usuario no existe o la contraseña es incorrecta, debera registrarse para realizar las consultas.
        private void btnacceder_Click(object sender, EventArgs e)
        {
            //El ususario no se puede conectar sin introducir el nombre de usuario y su respectiva contraseña.
            if (registered == false)
            {
                if ((connected == false) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA"))
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse("147.83.117.22");
                    //IPAddress direc = IPAddress.Parse("192.168.56.102");
                    //Nos conectamos al mismo puerto que en el servidor.
                    IPEndPoint ipep = new IPEndPoint(direc, 50052);

                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        MessageBox.Show("Conectado");

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
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();

                    ThreadStart ti = delegate { AbrirMain(); };
                    Thread form = new Thread(ti);
                    form.Start();

                    connected = true;
                }
                else if ((connected == true) && (txtuser.Text != "USUARIO") && (txtpass.Text != "CONTRASEÑA"))
                {
                    string mensaje = "2/" + txtuser.Text + "/" + txtpass.Text;
                    // Enviamos al servidor el username y password tecleadas.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    ThreadStart ts = delegate { AbrirMain(); };
                    Thread form = new Thread(ts);
                    form.Start();
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos");
            }
            else
                MessageBox.Show("Debes hacer Log Out antes de hacer Log In con otro usuario");

        }

        public void AbrirPartida(string mensaje2)
        {
            contFormsPartida = formulariosPartida.Count;
            FormPartida = new Partida(ID, server);
            formulariosPartida.Add(FormPartida);
            formulariosPartida[contFormsPartida].bienvenido(mensaje2);
            FormPartida.ShowDialog();
        }

        public void ThreadPartida(string mensaje2)
        {
            ThreadStart te = delegate { AbrirPartida(mensaje2); };
            Thread form1 = new Thread(te);
            form1.Start();
        }

        public void EnviarChat(int ID, string Autor, string mensaje)
        {
            int i;
            for (i = 0; i <= contFormsPartida; i++)
            {
                formulariosPartida[i].RecibirChat(ID, Autor, mensaje);
            }
        }

        //public void EnviarBienvenida(string mensaje)
        //{
        //    formulariosPartida[contFormsPartida].bienvenido(mensaje);
        //}

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
                            MessageBox.Show("El usuario: " + txtuser.Text + ", se ha registrado correctamente.");
                        }
                        else
                            MessageBox.Show("El usuario: " + txtuser.Text + ", ya está cogido.");
                        break;


                    case 2:
                        mensaje2 = trozos[2].Split('\0')[0];

                        if (mensaje == "SI")
                        {
                            if (mensaje2 == "El usuario: " + txtuser.Text + ", se ha anadido correctamente a la lista")
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
                        formulariosMain[contFormsMain].damePartida(FormCrearPartida);
                        formulariosMain[contFormsMain].dameFormPartida(FormJugarPartida);
                        formulariosCrearPartida[contFormsCrearPartida].TomaUsuario(txtuser.Text);
                        formulariosMain[contFormsMain].TomaUsuario(txtuser.Text);
                        formulariosCrearPartida[contFormsCrearPartida].EscribirenListaConectados(mensajerecibido); 
                        break;

                    case 7:
                        formulariosCrearPartida[contFormsCrearPartida].HacerInvitacion(mensajerecibido);
                        break;

                    case 8:
                        formulariosCrearPartida[contFormsCrearPartida].dameFormPartida(formulariosJugarPartida[contFormsJugarPartida]);
                        formulariosCrearPartida[contFormsCrearPartida].RecibirRespuesta(mensajerecibido);
                        break;

                    case 9:
                        ID = Convert.ToInt32(mensaje);
                        mensaje2 = trozos[2].Split('\0')[0];
                        autor = mensaje2;
                        string mensaje3 = trozos[3].Split('\0')[0];
                        DelegadoChat delegadochat = new DelegadoChat(EnviarChat);
                        this.Invoke(delegadochat, new object[] { ID, autor, mensaje3 });
                        break;

                    case 10:
                        //Recibimos notificación 
                        formulariosJugarPartida[contFormsJugarPartida].TomaUsuario(txtuser.Text);
                        formulariosJugarPartida[contFormsJugarPartida].EscribirenListaPartidas(mensajerecibido);
                        break;

                    case 11:
                        //Jugada
                        //formulariosJugarPartida[contFormsJugarPartida].Jugada(mensajerecibido);
                        ID = Convert.ToInt32(mensaje);
                        mensaje2 = trozos[2].Split('\0')[0];
                        DelegadoBienvenido delegadobienvenido = new DelegadoBienvenido(ThreadPartida);
                        this.Invoke(delegadobienvenido, new object[] { mensaje2 });
                        break;
                }
            }
        }
    }
}
