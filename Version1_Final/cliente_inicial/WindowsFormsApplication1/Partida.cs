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
        //Variables comunes
        int ID;
        Socket server;
        int NumJugadores;//Da el número de personajes/jugadores de la partida id.
        string[] ListaJugadores = new string[4]; //Guarda los jugadores que partician en la partida id
        string username; //Username de nuestro jugador
        string jugadorqueescoge;
        string Palabra; //Palabra de la partida
        int Longitud; //Longitud de la palabra
        int turno;
        bool encontrado;
        Button b;
        delegate void DelegadoLabels();
        delegate void DelegadoButtons();
        delegate void DelegadoReset();
        public delegate void SetLabelTextCallback(Label l);
        public delegate void SetButtonsTextCallback(Button b);

        

        enum HangState
        {
            Nada,
            Pilar1,
            Pilar2,
            Pilar3,
            Pilar4,
            Cuerda,
            Cabeza,
            Cuerpo,
            BrazoIzquierdo,
            BrazoDerecho,
            ManoIzquierda,
            ManoDerecha,
            PiernaIzquierda,
            PiernaDerecha,
            PieIzquierdo,
            PieSDerecho
        }


        // Holds currnent word characters
        List<Label> labels = new List<Label>();
        // Word under consideration
        List<char> letrasescogidas = new List<char>();
        List<Button> buttons = new List<Button>();
        public string currentWord { get; set; }
        // Default character for hidden word letters
        public string DefaultChar { get { return "__"; } }
        // Current hangstate, used specially to repaint panel grphics
        private HangState CurrentHangState = HangState.Nada;
        // HangState enum size
        public int HangStateSize { get { return (Enum.GetValues(typeof(HangState)).Length - 1); } }

        // Datos globales para dibujar
        Pen p;
        Pen pRope;
        Pen c;
        int panelLocX = 0;
        int panelLocY = 0;
        int AnchoPanel = 0;
        int AlturaPanel = 0;

        // Datos pilares y las coordenadas entre extremos.
        int FondoPilar2X;
        int FondoPilar2Y;
        int CimaPilar2X;
        int CimaPilar2Y;
        int HorDerechPilar1X;
        int HorDerechPilar1Y;
        int HorIzqPilar1X;
        int HorIzqPilar1Y;
        int HorDerechPilar3X;
        int HorDerechPilar3Y;
        int HorIzqPilar3X;
        int HorIzqPilar3Y;

        // Datos cuerda
        int CimaCuerdaX;
        int CimaCuerdaY;
        int FondoCuerdaX;
        int FondoCuerdaY;

        // Datos Cabeza
        int diametro = 40;
        int HeadBoundingRectX;

        // Datos Cuerpo
        int bodyBoundingRectY;
        int TamañoCuerpo;
        

        public Partida(int ID, Socket server)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.server = server;
            this.ID = ID;
            //Guardar las posiciones al inicializar
            
        }

        //Pintar el Panel donde se dibuja el hangman
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //Inicializar valores

        private void InitializeVars()
        {
            // Global graphics data            
            p = new Pen(Color.Black, 5);
            pRope = new Pen(Color.Black, 4);
            c = new Pen(Color.Black, 2);
            panelLocX = panel1.Location.X;
            panelLocY = panel1.Location.Y;
            AnchoPanel = panel1.Width;
            AlturaPanel = panel1.Height;

            // Puntos donde acaban los pilares
            FondoPilar2X = AnchoPanel - 30;
            FondoPilar2Y = AlturaPanel - 15;
            CimaPilar2X = FondoPilar2X;
            CimaPilar2Y = AlturaPanel - AlturaPanel + 30;
            HorIzqPilar1X = AnchoPanel - 30 + 10;
            HorDerechPilar1Y = AlturaPanel - 15;
            HorDerechPilar1X = AnchoPanel - AnchoPanel + 50;
            HorIzqPilar1Y = HorDerechPilar1Y;
            HorDerechPilar3X = AnchoPanel - 30 + 10;
            HorDerechPilar3Y = AlturaPanel - AlturaPanel + 50;
            HorIzqPilar3X = AnchoPanel - AnchoPanel + 50;
            HorIzqPilar3Y = HorDerechPilar3Y;

            // Datos cuerda
            CimaCuerdaX = (HorDerechPilar3X + HorIzqPilar3X) / 3;
            CimaCuerdaY = HorIzqPilar3Y;
            FondoCuerdaX = CimaCuerdaX;
            FondoCuerdaY = CimaCuerdaY + 40;

            // Datos Cabeza
            diametro = 40;
            HeadBoundingRectX = FondoCuerdaX - diametro / 2;

            // Datos cuerpo
            bodyBoundingRectY = FondoCuerdaY + diametro;
            TamañoCuerpo = (FondoPilar2Y - CimaPilar2Y) / 3;
        } 

               
        
        private void Partida_Load(object sender, EventArgs e)
        {
        }

        

        
        //Resetear paneles y controles
        private void ResetControls()
        {
            // Resetting things
            flowLayoutPanel1.Controls.Clear();
            AddButtons();
            CurrentHangState = HangState.Nada;
            panel1.Invalidate();
            txtWrongguesses.Clear();
            lblInfo.Text = "";
        }

        //Añadir los botones del teclado
        private void AddButtons()
        {
            for (int i = (int)'A'; i <= (int)'Z'; i++)
            {
                Button b = new Button();
                b.Text = ((char)i).ToString();
                b.Parent = flowLayoutPanel1; 
                b.Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
                b.Size = new Size(40, 40);
                b.BackColor = Color.White;
                b.Click += b_Click;
                buttons.Add(b);
            }

            // Disabling buttons
            flowLayoutPanel1.Enabled = false;
        }

        //Clicar a una de las letras del panel
        void b_Click(object sender, EventArgs e)
        {
            if (ListaJugadores[turno] == username)
            {
                b = (Button)sender;
                char charClicked = b.Text.ToCharArray()[0];
                b.Enabled = false;
                if (letrasescogidas.Contains(charClicked))
                {

                    lblInfo.Text = "CUIDADO! Esta letra ya ha sido escogida";

                }

                else { 
                
                    string mensaje = "15/" + ID + "/" + charClicked + "/";
                    // Enviamos al servidor el mensaje del chat.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                
                }
                
            }

        } 

        public void RecibirUsernameyNumJugadores(string mensajerecibido) //Recibe "11/ID/Username/nºJugs/Nombre1/Nombre2/...NombreN/"
        //La debemos implementar con un thread para evitar los problemas con los controles de ResetControls
        {
            ResetControls();
            turno = 1; //Empieza el siguiente del anfitrion
            encontrado = false;

            //Pongo todos los labels en una lista de labels y los hago invisibles
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            
                       

            string[] trozos = mensajerecibido.Split('/');
            username = trozos[2];
            NumJugadores = Convert.ToInt32(trozos[3]);
            int k = 4;
            int i;
            for (i = 0; i < NumJugadores; i++)
            {
                ListaJugadores[i] = trozos[k];
                k = k + 1;
            }

            jugadorqueescoge = ListaJugadores[0];
            //Mensaje de bienvenida
            Bienvenido.Text = "Hola " + username + ", bienvenido a la partida " + ID;

            if (username == jugadorqueescoge)
            {
                //Hacer invisible y disabled el teclado y visible y enabled el text box la primera ve
                PalabraText.Enabled = true;
                PalabraText.Visible = true;
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel1.Visible = false;

            }

            else
            {
                //Hacer invisible y disabled el text box y visible y disabled el teclado
                PalabraText.Enabled = false;
                PalabraText.Visible = false;
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel1.Visible = true;

            }

            //MessageBox.Show("Soy el usuario " + username + " , es el turno: " + turno+" .El jugador que escoje es: "+jugadorqueescoge);
   

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

        

        //Recibo la Palabra
        public void RecibirPalabra(int idOrigen, string palabra, int longitud)
        {
            if (idOrigen == ID)
            {
                labels.Add(label4);
                labels.Add(label5);
                labels.Add(label6);
                labels.Add(label7);
                labels.Add(label8);
                labels.Add(label9);
                labels.Add(label10);
                labels.Add(label11);
                labels.Add(label12);
                labels.Add(label13);
                labels.Add(label14);
                labels.Add(label15);
                labels.Add(label16);

                Palabra = palabra;
                Longitud = longitud;
                char[] wordChars = Palabra.ToCharArray();
                int len = wordChars.Length;
                int refer = (422 - 20) / len;

                for (int i = 0; i < len; i++)
                {
                    labels[i].BringToFront();
                    labels[i].Font = new Font("Microsoft Sans Serif", 18);
                    labels[i].Text = "__";
                    labels[i].Size = new Size(25, 35);
                    labels[i].Location = new Point(22 + i * refer + refer / 2, 43);
                    labels[i].BackColor = Color.White;
                    labels[i].ForeColor = Color.Black;
                    labels[i].Visible = true;       

                }

                // Writting text boxes 
                txtWordLen.Text = len.ToString();
                txtGuessesLeft.Text = HangStateSize.ToString();

                //Miro quien es el jugador que escoge y de quien es el turno
                for (int i = 0; i < NumJugadores && !encontrado; i++)
                {
                    if (ListaJugadores[i] == jugadorqueescoge)

                        if (i == NumJugadores - 1)
                            turno = 0;
                        else {
                            turno = i + 1;
                            encontrado = true;                        
                        }
                            
                }

                encontrado = false;

                if (username == jugadorqueescoge)
                {

                    //Deshabilitamos el textbox, hacemos invisible y deshabilitamos el teclado
                    PalabraText.Text = "";
                    PalabraText.Enabled = false;
                    PalabraText.Visible = true;
                    button1.Visible = true;
                    button1.Enabled = false;
                    flowLayoutPanel1.Enabled = false;
                    flowLayoutPanel1.Visible = false;

                }

                else{

                    if (username == ListaJugadores[turno])
                    {

                        //Habilitamos y hacemos visible el teclado, deshabilitamos y hacemos invisible el textbox
                        PalabraText.Text = "";
                        PalabraText.Enabled = false;
                        PalabraText.Visible = false;
                        button1.Visible = false;
                        button1.Enabled = false;
                        flowLayoutPanel1.Enabled = true;
                        flowLayoutPanel1.Visible = true;
                    }

                    else {

                        //Deshabilitamos teclado y hacemos visible el teclado, deshabilitamos y hacemos invisible el textbox
                        PalabraText.Text = "";
                        PalabraText.Enabled = false;
                        PalabraText.Visible = false;
                        button1.Visible = false;
                        button1.Enabled = false;
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel1.Visible = true;
                    }
                        
                
                }

               // MessageBox.Show("Soy el usuario " + username + ", es el turno: " + turno + " .El jugador que escoje es: " + jugadorqueescoge);
               
            }
        }



        private void SetButton(Button b)
        {
                       
        }

        //Recibo la letra
        public void RecibirJugada(int idOrigen, string continua, char letra)
        {
            if (idOrigen == ID)
            {
                letrasescogidas.Add(letra);

                if (continua == "SI")
                {
                    // letra escogida correcta
                    if(ListaJugadores[turno]==username)
                    {
                        lblInfo.Text ="Has escogido bien la letra";
                        b.BackColor = Color.Green;
                        lblInfo.ForeColor = Color.White;                        

                    }
                    else
                    {
                        lblInfo.Text ="El jugador "+ListaJugadores[turno]+" ha escogido bien la letra";
                    }
                      

                    //Meter la letra en la palabra     
                    
                    char[] charArray = Palabra.ToCharArray();
                    for (int i = 0; i < Palabra.Length; i++)
                    {
                        if (charArray[i] == letra)
                        {
                            labels[i].Text = letra.ToString();
                            labels[i].BringToFront();
                        }
                    }
                }

                else {

                    //Poner la letra en el listado de letras incorrectas
                    //Dibujamos otra parte del cuerpo
                    if (CurrentHangState != HangState.PieSDerecho)
                        CurrentHangState++;
                    txtGuessesLeft.Text = (HangStateSize - (int)CurrentHangState).ToString();
                    txtWrongguesses.Text += string.IsNullOrWhiteSpace(txtWrongguesses.Text) ? letra.ToString() : "," + letra;

                    panel1.Invalidate();

                    // Letra incorrecta
                    if(ListaJugadores[turno]==username)
                    {
                        lblInfo.Text = "Respuesta incorrecta, pierdes el turno";
                        lblInfo.ForeColor = Color.Red;
                        b.BackColor = Color.Red;

                    }
                    else
                    {
                        lblInfo.Text = "El jugador "+ListaJugadores[turno]+" pierde el turno";
                        lblInfo.ForeColor = Color.Red;
                    }                   


                    if (turno == NumJugadores-1)  //si el turno es el del ultimo jugador de la lista de jugadores
                    {

                        if (ListaJugadores[0] == jugadorqueescoge)  //si el jugador en la posicion 0 es el jugador que escoje el turno es 1 sino 0
                        {
                            turno = 1;             
                        }

                        else
                        {
                            turno = 0;                            
                        }
                    }

                    else if (turno + 1 == NumJugadores - 1)  //si el proximo turno es la posicion final de la lista de jugadores...
                    {

                        if (ListaJugadores[NumJugadores - 1] == jugadorqueescoge)
                        {
                            turno = 0;                            
                        }
                        else
                        {
                            turno = NumJugadores - 1;
                            
                        }
                    }
                    else {

                        if (ListaJugadores[turno + 1] == jugadorqueescoge)
                        {
                            turno = turno + 2;
                            
                        }
                        else
                        {
                            turno = turno + 1;                            
                        }                
                    
                    }

                    System.Threading.Thread.Sleep(2000);
                    lblInfo.Text = "Es el turno del jugador: " + ListaJugadores[turno];
                    lblInfo.ForeColor = Color.White;

                    if (username == ListaJugadores[turno])
                    {

                        //Habilitamos y hacemos visible el teclado, deshabilitamos y hacemos invisible el textbox
                        PalabraText.Enabled = false;
                        PalabraText.Visible = false;
                        button1.Visible = false;
                        button1.Enabled = false;
                        flowLayoutPanel1.Enabled = true;
                        flowLayoutPanel1.Visible = true;
                    }

                    else
                    {
                        
                        //Deshabilitamos teclado y hacemos visible el teclado, deshabilitamos y hacemos invisible el textbox
                        PalabraText.Enabled = false;
                        PalabraText.Visible = false;
                        button1.Visible = false;
                        button1.Enabled = false;
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel1.Visible = false;

                        if (username != jugadorqueescoge) {

                            flowLayoutPanel1.Visible = true;
                        
                        }
                    }
                
                
                }

                //MessageBox.Show("Soy el usuario " + username + " , es el turno: " + turno + " .El jugador que escoje es: " + jugadorqueescoge);

            }
        }

        //Acaba la ronda i/o la partida
        public void RecibirJugada2(int idOrigen, string user, int ronda, string mensajerecibido)
        {
            if (idOrigen == ID)
            {
                string[] trozos = mensajerecibido.Split('/');
                if (trozos[4] == "1" && trozos[2] != "NO")  //si la ronda ha acabado y alguien ha acertado la palabra
                {                   
                    char[] charArray = Palabra.ToCharArray();
                    for (int i = 0; i < Palabra.Length; i++)
                    {
                        if (charArray[i] == Convert.ToChar(trozos[5]))
                            labels[i].Text = trozos[5].ToString();
                            labels[i].BringToFront();                            
                    }
                
                }

                if (user != "NO")
                {
                    if (user == username)
                    {
                        lblInfo.ForeColor = Color.White;
                        lblInfo.Text = "Buen trabajo " + username + "! Has adivinado la palabra. Ronda terminada!";
                        b.BackColor = Color.Green;
                        lblInfo.ForeColor = Color.White;  
                    }

                    else {

                        lblInfo.ForeColor = Color.White;
                        lblInfo.Text = user + " ha adivinado la palabra. Ronda terminada!";
                    }

                    jugadorqueescoge = ListaJugadores[ronda];


                    if (ronda == NumJugadores - 1)
                    {
                        turno = 0;
                    }

                    else
                    {
                        turno = ronda + 1;

                    }
                    
                }

                else { 
                
                //Dibujar la ultima parte del muñeco
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = "La habeis cagado. Ronda terminada! La palabra correcta era: "+Palabra;
                    if (CurrentHangState != HangState.PieSDerecho)
                        CurrentHangState++;
                    panel1.Invalidate();

                    if(user==username)
                        b.BackColor = Color.Red;

                    jugadorqueescoge = ListaJugadores[ronda];


                    if (ronda == NumJugadores - 1)
                    {
                        turno = 0;
                    }

                    else
                    {
                        turno = ronda + 1;

                    }
                    
                }

                System.Threading.Thread.Sleep(2000); //damos tiempo a que el usuario lea el mensaje

                if (ronda != NumJugadores)  //Cuando acaba la partida no hay siguiente turno
                {                    
                    lblInfo.Text = "Prepárate! " + jugadorqueescoge + " escoge la palabra";
                    System.Threading.Thread.Sleep(2000); //damos tiempo a que el programa cree los formularios

                    if (username == jugadorqueescoge)
                    {

                        //Hacer invisible y disabled el teclado y visible y enabled el text box
                        PalabraText.Enabled = true;
                        PalabraText.Visible = true;
                        button1.Visible = true;
                        button1.Enabled = true;
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel1.Visible = false;

                    }

                    else
                    {

                        //Hacer invisible y disabled el text box y visible y disabled el teclado
                        PalabraText.Enabled = false;
                        PalabraText.Visible = false;
                        button1.Visible = false;
                        button1.Enabled = false;
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel1.Visible = true;

                    }

                    //Reseteo la configuracion de los botones
                    foreach (Button b in buttons)
                    {
                        b.BackColor = Color.White;
                        b.Enabled = true;
                    }

                    //Reseteo la configuración de los labels

                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;

                    labels.Clear(); //Vaciamos el vector de labels para la proxima ronda, pues no se ha acabado la partida

                    letrasescogidas.Clear(); //Resetea las letras escogidas en la ronda anterior
                    CurrentHangState = HangState.Nada;  //Reseta el Hangman state
                    panel1.Invalidate();
                    txtWrongguesses.Clear();
                    lblInfo.Text = "";
                    txtWordLen.Text = "";
                    txtGuessesLeft.Text = "";
                    txtWrongguesses.Text = "";
                    
                }

                //MessageBox.Show("Soy el usuario " + username + " , es el turno: " + turno + " .El jugador que escoje es: " + jugadorqueescoge);
                    

            }
        }

        //Enviamos el mensaje de chat
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

        //Jugada3: se ha acabado la partida
        public void RecibirJugada3(int idOrigen)
        {
            if (idOrigen == ID)
            {
                this.Close();
                labels.Clear();
            
            }            
        }

        private void PalabraText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PalabraText.Text == "")
                MessageBox.Show("Debes introducir una palabra");
            else
            {
                string mensaje = "13/" + ID + "/" + PalabraText.Text.ToUpper() + "/";
                // Enviamos al servidor el mensaje del chat.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
        }

        private void MensajesChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            InitializeVars();
            var g = e.Graphics; //Graphic to draw on

            if (CurrentHangState >= HangState.Pilar1)
            {
                g.DrawLine(p, new Point(HorDerechPilar1X, HorDerechPilar1Y), new Point(HorIzqPilar1X, HorIzqPilar1Y));

            }
            if (CurrentHangState >= HangState.Pilar2)
            {
                Pen d;
                d = new Pen(Color.Black, 10);
                g.DrawLine(d, new Point(FondoPilar2X, FondoPilar2Y), new Point(CimaPilar2X, CimaPilar2Y));

            }
            if (CurrentHangState >= HangState.Pilar3)
            {
                g.DrawLine(p, new Point(HorDerechPilar3X, HorDerechPilar3Y), new Point(HorIzqPilar3X, HorIzqPilar3Y));
            }
            if (CurrentHangState >= HangState.Pilar4)
            {
                g.DrawLine(p, new Point(CimaPilar2X, CimaPilar2Y), new Point(HorIzqPilar3X + 90, HorIzqPilar3Y));
            }

            if (CurrentHangState >= HangState.Cuerda)
            {
                g.DrawLine(pRope, new Point(CimaCuerdaX, CimaCuerdaY), new Point(FondoCuerdaX, FondoCuerdaY));
            }

            if (CurrentHangState >= HangState.Cabeza)
            {

                g.DrawEllipse(c, new Rectangle(new Point(HeadBoundingRectX, FondoCuerdaY), new Size(diametro, diametro)));
                g.DrawEllipse(c, new Rectangle(new Point(HeadBoundingRectX + 10, FondoCuerdaY + 10), new Size(6, 6)));// Left eye
                g.DrawEllipse(c, new Rectangle(new Point(HeadBoundingRectX + diametro - 10 - 6, FondoCuerdaY + 10), new Size(6, 6))); // Right eye
                g.DrawEllipse(c, new Rectangle(new Point(FondoCuerdaX - 10, FondoCuerdaY + diametro / 2 + 10), new Size(20, 5))); // Mouth
                g.FillRectangles(new SolidBrush(Color.Black),
                    new[] {
                            new Rectangle(new Point(FondoCuerdaX, FondoCuerdaY + diametro/2), new Size(2, 2)),  // Nose
                        });
            }

            if (CurrentHangState >= HangState.Cuerpo)
            {
                g.DrawLine(pRope, new Point(FondoCuerdaX, FondoCuerdaY + diametro), new Point(FondoCuerdaX, FondoCuerdaY + diametro + TamañoCuerpo));
            }

            if (CurrentHangState >= HangState.BrazoIzquierdo)
            {
                g.DrawLine(c, new Point(FondoCuerdaX, FondoCuerdaY + diametro + 20), new Point(FondoCuerdaX - 50, FondoCuerdaY + diametro + 20));
            }

            if (CurrentHangState >= HangState.BrazoDerecho)
            {
                g.DrawLine(c, new Point(FondoCuerdaX, FondoCuerdaY + diametro + 20), new Point(FondoCuerdaX + 50, FondoCuerdaY + diametro + 20));
            }
            if (CurrentHangState >= HangState.ManoIzquierda)
            {
                g.DrawEllipse(c, new Rectangle(new Point(FondoCuerdaX - 50 - 10, FondoCuerdaY + diametro + 20 - 5), new Size(10, 10))); //Left Hand 
            }
            if (CurrentHangState >= HangState.ManoDerecha)
            {
                g.DrawEllipse(c, new Rectangle(new Point(FondoCuerdaX + 50, FondoCuerdaY + diametro + 20 - 5), new Size(10, 10))); //Right Hand
            }
            if (CurrentHangState >= HangState.PiernaIzquierda)
            {
                g.DrawLine(pRope, new Point(FondoCuerdaX, FondoCuerdaY + diametro + TamañoCuerpo), new Point(FondoCuerdaX - 30, FondoCuerdaY + diametro + TamañoCuerpo + 50));
            }

            if (CurrentHangState >= HangState.PiernaDerecha)
            {
                g.DrawLine(pRope, new Point(FondoCuerdaX, FondoCuerdaY + diametro + TamañoCuerpo), new Point(FondoCuerdaX + 30, FondoCuerdaY + diametro + TamañoCuerpo + 50));
            }

            if (CurrentHangState >= HangState.PieIzquierdo)
            {
                g.DrawLine(pRope, new Point(FondoCuerdaX - 30, FondoCuerdaY + diametro + TamañoCuerpo + 50), new Point(FondoCuerdaX - 40, FondoCuerdaY + diametro + TamañoCuerpo + 50));
            }

            if (CurrentHangState >= HangState.PieSDerecho)
            {
                g.DrawLine(pRope, new Point(FondoCuerdaX + 30, FondoCuerdaY + diametro + TamañoCuerpo + 50), new Point(FondoCuerdaX + 40, FondoCuerdaY + diametro + TamañoCuerpo + 50));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "9/" + ID + "/" + textChat.Text + "/";
            // Enviamos al servidor el mensaje del chat.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            textChat.Text = "";
        }

        private void textChat_Enter(object sender, EventArgs e)
        {
            if (textChat.Text == "Escribe el mensaje")
            {
                textChat.Text = "";
                textChat.ForeColor = Color.LightGray;
            }
        }

        private void textChat_Leave(object sender, EventArgs e)
        {
            if (textChat.Text == "")
            {
                textChat.Text = "Escribe el mensaje";
                textChat.ForeColor = Color.DimGray;
            }
        }

        private void textChat_TextChanged(object sender, EventArgs e)
        {

        }



        
    }


}
