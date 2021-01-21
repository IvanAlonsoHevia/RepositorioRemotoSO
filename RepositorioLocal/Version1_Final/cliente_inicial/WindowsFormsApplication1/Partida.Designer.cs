namespace WindowsFormsApplication1
{
    partial class Partida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partida));
            this.Bienvenido = new System.Windows.Forms.Label();
            this.textChat = new System.Windows.Forms.TextBox();
            this.MensajesChat = new System.Windows.Forms.RichTextBox();
            this.PalabraText = new System.Windows.Forms.TextBox();
            this.txtWrongguesses = new System.Windows.Forms.TextBox();
            this.txtGuessesLeft = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWordLen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Bienvenido
            // 
            this.Bienvenido.BackColor = System.Drawing.SystemColors.Window;
            this.Bienvenido.Location = new System.Drawing.Point(12, 2);
            this.Bienvenido.Name = "Bienvenido";
            this.Bienvenido.Size = new System.Drawing.Size(500, 22);
            this.Bienvenido.TabIndex = 78;
            // 
            // textChat
            // 
            this.textChat.BackColor = System.Drawing.Color.White;
            this.textChat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textChat.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChat.Location = new System.Drawing.Point(725, 317);
            this.textChat.Margin = new System.Windows.Forms.Padding(2);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(229, 20);
            this.textChat.TabIndex = 90;
            this.textChat.Text = "Enter the message to be sent....";
            // 
            // MensajesChat
            // 
            this.MensajesChat.BackColor = System.Drawing.Color.Black;
            this.MensajesChat.Location = new System.Drawing.Point(725, 27);
            this.MensajesChat.Margin = new System.Windows.Forms.Padding(2);
            this.MensajesChat.Name = "MensajesChat";
            this.MensajesChat.Size = new System.Drawing.Size(229, 291);
            this.MensajesChat.TabIndex = 89;
            this.MensajesChat.Text = "";
            // 
            // PalabraText
            // 
            this.PalabraText.Location = new System.Drawing.Point(397, 316);
            this.PalabraText.Margin = new System.Windows.Forms.Padding(2);
            this.PalabraText.Name = "PalabraText";
            this.PalabraText.Size = new System.Drawing.Size(68, 20);
            this.PalabraText.TabIndex = 79;
            this.PalabraText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PalabraText_KeyDown);
            // 
            // txtWrongguesses
            // 
            this.txtWrongguesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWrongguesses.Location = new System.Drawing.Point(257, 124);
            this.txtWrongguesses.Name = "txtWrongguesses";
            this.txtWrongguesses.ReadOnly = true;
            this.txtWrongguesses.Size = new System.Drawing.Size(200, 21);
            this.txtWrongguesses.TabIndex = 86;
            // 
            // txtGuessesLeft
            // 
            this.txtGuessesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuessesLeft.Location = new System.Drawing.Point(165, 122);
            this.txtGuessesLeft.Name = "txtGuessesLeft";
            this.txtGuessesLeft.ReadOnly = true;
            this.txtGuessesLeft.Size = new System.Drawing.Size(39, 22);
            this.txtGuessesLeft.TabIndex = 87;
            this.txtGuessesLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(277, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 16);
            this.label3.TabIndex = 85;
            this.label3.Text = "Intentos fallidos (letras)";
            // 
            // txtWordLen
            // 
            this.txtWordLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWordLen.Location = new System.Drawing.Point(46, 122);
            this.txtWordLen.Name = "txtWordLen";
            this.txtWordLen.ReadOnly = true;
            this.txtWordLen.Size = new System.Drawing.Size(41, 22);
            this.txtWordLen.TabIndex = 88;
            this.txtWordLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(123, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 83;
            this.label2.Text = "Intentos restantes";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 38);
            this.label1.TabIndex = 84;
            this.label1.Text = "Longitud de la palabra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(471, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 313);
            this.panel1.TabIndex = 82;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 176);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(461, 140);
            this.flowLayoutPanel1.TabIndex = 81;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(2, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 50);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(87, 149);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 24);
            this.lblInfo.TabIndex = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 92;
            this.button1.Text = "Enviar Palabra";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(953, 338);
            this.Controls.Add(this.Bienvenido);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.textChat);
            this.Controls.Add(this.MensajesChat);
            this.Controls.Add(this.PalabraText);
            this.Controls.Add(this.txtWrongguesses);
            this.Controls.Add(this.txtGuessesLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWordLen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Partida";
            this.Text = "Partida";
            this.Load += new System.EventHandler(this.Partida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Bienvenido;
        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.RichTextBox MensajesChat;
        private System.Windows.Forms.TextBox PalabraText;
        private System.Windows.Forms.TextBox txtWrongguesses;
        private System.Windows.Forms.TextBox txtGuessesLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWordLen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button button1;
    }
}