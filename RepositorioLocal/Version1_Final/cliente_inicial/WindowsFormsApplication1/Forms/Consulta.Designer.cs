namespace WindowsFormsApplication1.Forms
{
    partial class Consulta
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PerdedorBox = new System.Windows.Forms.TextBox();
            this.UsernameConsultaBox = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FechaBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumJugadoresBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PuntuacionBox = new System.Windows.Forms.TextBox();
            this.Edgar = new System.Windows.Forms.RadioButton();
            this.Omar = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.PosicionBox = new System.Windows.Forms.TextBox();
            this.Ivan = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(350, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Perdedor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(510, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Username consulta";
            // 
            // PerdedorBox
            // 
            this.PerdedorBox.Location = new System.Drawing.Point(299, 90);
            this.PerdedorBox.Name = "PerdedorBox";
            this.PerdedorBox.Size = new System.Drawing.Size(151, 20);
            this.PerdedorBox.TabIndex = 30;
            // 
            // UsernameConsultaBox
            // 
            this.UsernameConsultaBox.Location = new System.Drawing.Point(471, 90);
            this.UsernameConsultaBox.Name = "UsernameConsultaBox";
            this.UsernameConsultaBox.Size = new System.Drawing.Size(174, 20);
            this.UsernameConsultaBox.TabIndex = 29;
            // 
            // enviar
            // 
            this.enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.Location = new System.Drawing.Point(10, 205);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(149, 31);
            this.enviar.TabIndex = 23;
            this.enviar.Text = "enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(519, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Fecha y Hora";
            // 
            // FechaBox
            // 
            this.FechaBox.Location = new System.Drawing.Point(471, 49);
            this.FechaBox.Name = "FechaBox";
            this.FechaBox.Size = new System.Drawing.Size(174, 20);
            this.FechaBox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(315, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Número de Jugadores";
            // 
            // NumJugadoresBox
            // 
            this.NumJugadoresBox.Location = new System.Drawing.Point(299, 51);
            this.NumJugadoresBox.Name = "NumJugadoresBox";
            this.NumJugadoresBox.Size = new System.Drawing.Size(151, 20);
            this.NumJugadoresBox.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(179, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Puntuación";
            // 
            // PuntuacionBox
            // 
            this.PuntuacionBox.Location = new System.Drawing.Point(143, 90);
            this.PuntuacionBox.Name = "PuntuacionBox";
            this.PuntuacionBox.Size = new System.Drawing.Size(137, 20);
            this.PuntuacionBox.TabIndex = 24;
            // 
            // Edgar
            // 
            this.Edgar.AutoSize = true;
            this.Edgar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Edgar.Location = new System.Drawing.Point(10, 159);
            this.Edgar.Name = "Edgar";
            this.Edgar.Size = new System.Drawing.Size(609, 17);
            this.Edgar.TabIndex = 15;
            this.Edgar.TabStop = true;
            this.Edgar.Text = "Quiero el ganador que ha jugado contra el usuario que te doy en las partidas con " +
                "un número de jugadores mayor o igual a 3.";
            this.Edgar.UseVisualStyleBackColor = true;
            // 
            // Omar
            // 
            this.Omar.AutoSize = true;
            this.Omar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Omar.Location = new System.Drawing.Point(10, 181);
            this.Omar.Name = "Omar";
            this.Omar.Size = new System.Drawing.Size(712, 17);
            this.Omar.TabIndex = 16;
            this.Omar.TabStop = true;
            this.Omar.Text = "Quiero las IDs de partida. Te doy Puntuacion minima total, Num Jugadores minimos " +
                "y La fecha y Hora en el formato siguiente (dd-mm-aaaa-hh:mm)";
            this.Omar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(187, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Posición";
            // 
            // PosicionBox
            // 
            this.PosicionBox.Location = new System.Drawing.Point(143, 49);
            this.PosicionBox.Name = "PosicionBox";
            this.PosicionBox.Size = new System.Drawing.Size(137, 20);
            this.PosicionBox.TabIndex = 19;
            // 
            // Ivan
            // 
            this.Ivan.AutoSize = true;
            this.Ivan.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Ivan.Location = new System.Drawing.Point(10, 137);
            this.Ivan.Name = "Ivan";
            this.Ivan.Size = new System.Drawing.Size(828, 17);
            this.Ivan.TabIndex = 17;
            this.Ivan.TabStop = true;
            this.Ivan.Text = "Quiero el nombre de usuario. Te doy  la posicion del jugador con una puntuación p" +
                "or debajo de la propuesta en la misma partida en la que el usuario propuesto ha " +
                "perdido.";
            this.Ivan.UseVisualStyleBackColor = true;
            this.Ivan.CheckedChanged += new System.EventHandler(this.Ivan_CheckedChanged);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(851, 251);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PerdedorBox);
            this.Controls.Add(this.UsernameConsultaBox);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FechaBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NumJugadoresBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PuntuacionBox);
            this.Controls.Add(this.Edgar);
            this.Controls.Add(this.Omar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PosicionBox);
            this.Controls.Add(this.Ivan);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Consulta";
            this.Text = "Consulta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PerdedorBox;
        private System.Windows.Forms.TextBox UsernameConsultaBox;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FechaBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NumJugadoresBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PuntuacionBox;
        private System.Windows.Forms.RadioButton Edgar;
        private System.Windows.Forms.RadioButton Omar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PosicionBox;
        private System.Windows.Forms.RadioButton Ivan;
    }
}