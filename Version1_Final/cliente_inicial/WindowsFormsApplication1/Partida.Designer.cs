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
            this.MensajesChat = new System.Windows.Forms.RichTextBox();
            this.textChat = new System.Windows.Forms.TextBox();
            this.Bienvenido = new System.Windows.Forms.Label();
            this.EnviarChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MensajesChat
            // 
            this.MensajesChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MensajesChat.Location = new System.Drawing.Point(-1, 406);
            this.MensajesChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MensajesChat.Name = "MensajesChat";
            this.MensajesChat.Size = new System.Drawing.Size(1407, 278);
            this.MensajesChat.TabIndex = 26;
            this.MensajesChat.Text = "";
            // 
            // textChat
            // 
            this.textChat.Location = new System.Drawing.Point(-1, 658);
            this.textChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(1287, 26);
            this.textChat.TabIndex = 27;
            this.textChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textChat_KeyDown);
            // 
            // Bienvenido
            // 
            this.Bienvenido.BackColor = System.Drawing.SystemColors.Control;
            this.Bienvenido.Font = new System.Drawing.Font("Goudy Stout", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bienvenido.ForeColor = System.Drawing.Color.Black;
            this.Bienvenido.Location = new System.Drawing.Point(-1, 0);
            this.Bienvenido.Name = "Bienvenido";
            this.Bienvenido.Size = new System.Drawing.Size(1396, 76);
            this.Bienvenido.TabIndex = 28;
            this.Bienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnviarChat
            // 
            this.EnviarChat.Location = new System.Drawing.Point(1282, 658);
            this.EnviarChat.Name = "EnviarChat";
            this.EnviarChat.Size = new System.Drawing.Size(124, 26);
            this.EnviarChat.TabIndex = 29;
            this.EnviarChat.Text = "Enviar";
            this.EnviarChat.UseVisualStyleBackColor = true;
            this.EnviarChat.Click += new System.EventHandler(this.EnviarChat_Click);
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 681);
            this.Controls.Add(this.EnviarChat);
            this.Controls.Add(this.Bienvenido);
            this.Controls.Add(this.textChat);
            this.Controls.Add(this.MensajesChat);
            this.Name = "Partida";
            this.Text = "Partida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MensajesChat;
        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.Label Bienvenido;
        private System.Windows.Forms.Button EnviarChat;
    }
}