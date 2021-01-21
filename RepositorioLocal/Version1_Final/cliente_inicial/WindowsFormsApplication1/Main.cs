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
    public partial class Main : Form
    {
        bool LabelBienvenida=false;
        //declaramos los tres tipos de forms que abrimos desde el main
        CrearPartida FormCrearPartida;
        JugarPartida FormJugarPartida;
        Consulta FormConsulta;
        //Variables Globales
        Socket server;
        string usuario;
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public string Usuario;
        //Constructor

        public Main(Socket server)
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.server = server;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in MenuVertical.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //Función que abre los formularios dentro del main y configura su posición y su estilo
        private void OpenChildForm(Form childForm, object btnSender)
        {
            
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        //boton para cerrar el Main
        private void botonCerrar_Click(object sender, EventArgs e)
        {
            Close();
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void botonMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            botonMax.Visible = false;
            botonRest.Visible = true;

        }

        private void botonRest_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            botonRest.Visible = false;
            botonMax.Visible = true;

        }

        private void botonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Abre el formulario CrearPartida
        private void btncrear_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormCrearPartida, sender);
        }

        //Abre el formulario Consulta
        private void btnconsultar_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormConsulta, sender);
        }
        
        //Abre el formulario JugarPartida
        private void btnjugar_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormJugarPartida, sender);
        }

        //Resetea el formulario
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Hide();
            Reset();  //Cuando cerramos uno de los tres formularios (JugarPartida,CrearPartida o Consulta), reseteamos el main
        }

        //Recibe el form CrearPartida des del form Login
        public void dameFormCrearPartida(CrearPartida Form)
        {
            FormCrearPartida = Form;
        }

        //Recibe el form JugarPartida des del form Login
        public void dameFormJugarPartida(JugarPartida Form)
        {
            FormJugarPartida = Form;
        }

        //Recibe el form Consulta des del form Login
        public void dameFormConsulta(Consulta Form)
        {
            FormConsulta = Form;
        }


        //escribe el nombre del usuario en el formulario del main
        public void TomaUsuario(string user)
        {
            usuario = user;
            if (LabelBienvenida == false)
            {
                Bienvenido.Text = Bienvenido.Text + ": " + usuario + "!";
                LabelBienvenida = true;
            }

        }
    }
}