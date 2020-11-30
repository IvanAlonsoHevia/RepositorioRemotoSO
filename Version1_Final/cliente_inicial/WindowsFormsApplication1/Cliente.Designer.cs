namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MensajesChat = new System.Windows.Forms.RichTextBox();
            this.Chat = new System.Windows.Forms.TextBox();
            this.partidasBox = new System.Windows.Forms.Label();
            this.partidasLabel = new System.Windows.Forms.Label();
            this.ListaPartidas = new System.Windows.Forms.DataGridView();
            this.Añadir = new System.Windows.Forms.Button();
            this.Invitar = new System.Windows.Forms.Button();
            this.Jugar = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PerdedorBox = new System.Windows.Forms.TextBox();
            this.UsernameConsultaBox = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.registrar = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FechaBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumJugadoresBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PuntuacionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Edgar = new System.Windows.Forms.RadioButton();
            this.Omar = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.PosicionBox = new System.Windows.Forms.TextBox();
            this.Ivan = new System.Windows.Forms.RadioButton();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.NumConn = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(133, 31);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(147, 20);
            this.Username.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.MensajesChat);
            this.groupBox1.Controls.Add(this.Chat);
            this.groupBox1.Controls.Add(this.partidasBox);
            this.groupBox1.Controls.Add(this.partidasLabel);
            this.groupBox1.Controls.Add(this.ListaPartidas);
            this.groupBox1.Controls.Add(this.Añadir);
            this.groupBox1.Controls.Add(this.Invitar);
            this.groupBox1.Controls.Add(this.Jugar);
            this.groupBox1.Controls.Add(this.logout);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.PerdedorBox);
            this.groupBox1.Controls.Add(this.UsernameConsultaBox);
            this.groupBox1.Controls.Add(this.enviar);
            this.groupBox1.Controls.Add(this.registrar);
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.FechaBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NumJugadoresBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PuntuacionBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.Edgar);
            this.groupBox1.Controls.Add(this.Omar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PosicionBox);
            this.groupBox1.Controls.Add(this.Ivan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Username);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 382);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // MensajesChat
            // 
            this.MensajesChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MensajesChat.Location = new System.Drawing.Point(510, 259);
            this.MensajesChat.Name = "MensajesChat";
            this.MensajesChat.Size = new System.Drawing.Size(137, 82);
            this.MensajesChat.TabIndex = 18;
            this.MensajesChat.Text = "";
            // 
            // Chat
            // 
            this.Chat.Location = new System.Drawing.Point(510, 347);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(137, 20);
            this.Chat.TabIndex = 17;
            // 
            // partidasBox
            // 
            this.partidasBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.partidasBox.Location = new System.Drawing.Point(617, 223);
            this.partidasBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.partidasBox.Name = "partidasBox";
            this.partidasBox.Size = new System.Drawing.Size(40, 15);
            this.partidasBox.TabIndex = 10;
            // 
            // partidasLabel
            // 
            this.partidasLabel.AutoSize = true;
            this.partidasLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.partidasLabel.Location = new System.Drawing.Point(515, 223);
            this.partidasLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.partidasLabel.Name = "partidasLabel";
            this.partidasLabel.Size = new System.Drawing.Size(103, 13);
            this.partidasLabel.TabIndex = 10;
            this.partidasLabel.Text = "Partidas disponibles:";
            // 
            // ListaPartidas
            // 
            this.ListaPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaPartidas.Location = new System.Drawing.Point(661, 223);
            this.ListaPartidas.Margin = new System.Windows.Forms.Padding(2);
            this.ListaPartidas.Name = "ListaPartidas";
            this.ListaPartidas.RowTemplate.Height = 28;
            this.ListaPartidas.Size = new System.Drawing.Size(174, 73);
            this.ListaPartidas.TabIndex = 10;
            // 
            // Añadir
            // 
            this.Añadir.Location = new System.Drawing.Point(249, 324);
            this.Añadir.Margin = new System.Windows.Forms.Padding(2);
            this.Añadir.Name = "Añadir";
            this.Añadir.Size = new System.Drawing.Size(73, 34);
            this.Añadir.TabIndex = 16;
            this.Añadir.Text = "Añadir Invitación";
            this.Añadir.UseVisualStyleBackColor = true;
            this.Añadir.Click += new System.EventHandler(this.Añadir_Click);
            // 
            // Invitar
            // 
            this.Invitar.Location = new System.Drawing.Point(327, 324);
            this.Invitar.Margin = new System.Windows.Forms.Padding(2);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(65, 34);
            this.Invitar.TabIndex = 10;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // Jugar
            // 
            this.Jugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugar.Location = new System.Drawing.Point(661, 335);
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(149, 36);
            this.Jugar.TabIndex = 15;
            this.Jugar.Text = "Enviar";
            this.Jugar.UseVisualStyleBackColor = true;
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click_1);
            // 
            // logout
            // 
            this.logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.Location = new System.Drawing.Point(334, 89);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(149, 31);
            this.logout.TabIndex = 11;
            this.logout.Text = "log out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Perdedor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(701, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Username consulta";
            // 
            // PerdedorBox
            // 
            this.PerdedorBox.Location = new System.Drawing.Point(491, 71);
            this.PerdedorBox.Name = "PerdedorBox";
            this.PerdedorBox.Size = new System.Drawing.Size(151, 20);
            this.PerdedorBox.TabIndex = 14;
            // 
            // UsernameConsultaBox
            // 
            this.UsernameConsultaBox.Location = new System.Drawing.Point(662, 71);
            this.UsernameConsultaBox.Name = "UsernameConsultaBox";
            this.UsernameConsultaBox.Size = new System.Drawing.Size(174, 20);
            this.UsernameConsultaBox.TabIndex = 14;
            // 
            // enviar
            // 
            this.enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.Location = new System.Drawing.Point(15, 195);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(149, 31);
            this.enviar.TabIndex = 12;
            this.enviar.Text = "enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // registrar
            // 
            this.registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrar.Location = new System.Drawing.Point(177, 89);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(149, 31);
            this.registrar.TabIndex = 11;
            this.registrar.Text = "registrarse";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(15, 89);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(149, 31);
            this.login.TabIndex = 11;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(711, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha y Hora";
            // 
            // FechaBox
            // 
            this.FechaBox.Location = new System.Drawing.Point(662, 29);
            this.FechaBox.Name = "FechaBox";
            this.FechaBox.Size = new System.Drawing.Size(174, 20);
            this.FechaBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Número de Jugadores";
            // 
            // NumJugadoresBox
            // 
            this.NumJugadoresBox.Location = new System.Drawing.Point(491, 31);
            this.NumJugadoresBox.Name = "NumJugadoresBox";
            this.NumJugadoresBox.Size = new System.Drawing.Size(151, 20);
            this.NumJugadoresBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Puntuación";
            // 
            // PuntuacionBox
            // 
            this.PuntuacionBox.Location = new System.Drawing.Point(334, 71);
            this.PuntuacionBox.Name = "PuntuacionBox";
            this.PuntuacionBox.Size = new System.Drawing.Size(137, 20);
            this.PuntuacionBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Password";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(133, 58);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(147, 20);
            this.Password.TabIndex = 12;
            // 
            // Edgar
            // 
            this.Edgar.AutoSize = true;
            this.Edgar.Location = new System.Drawing.Point(15, 149);
            this.Edgar.Name = "Edgar";
            this.Edgar.Size = new System.Drawing.Size(609, 17);
            this.Edgar.TabIndex = 7;
            this.Edgar.TabStop = true;
            this.Edgar.Text = "Quiero el ganador que ha jugado contra el usuario que te doy en las partidas con " +
                "un número de jugadores mayor o igual a 3.";
            this.Edgar.UseVisualStyleBackColor = true;
            // 
            // Omar
            // 
            this.Omar.AutoSize = true;
            this.Omar.Location = new System.Drawing.Point(15, 171);
            this.Omar.Name = "Omar";
            this.Omar.Size = new System.Drawing.Size(712, 17);
            this.Omar.TabIndex = 7;
            this.Omar.TabStop = true;
            this.Omar.Text = "Quiero las IDs de partida. Te doy Puntuacion minima total, Num Jugadores minimos " +
                "y La fecha y Hora en el formato siguiente (dd-mm-aaaa-hh:mm)";
            this.Omar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Posición";
            // 
            // PosicionBox
            // 
            this.PosicionBox.Location = new System.Drawing.Point(334, 29);
            this.PosicionBox.Name = "PosicionBox";
            this.PosicionBox.Size = new System.Drawing.Size(137, 20);
            this.PosicionBox.TabIndex = 9;
            // 
            // Ivan
            // 
            this.Ivan.AutoSize = true;
            this.Ivan.Location = new System.Drawing.Point(15, 127);
            this.Ivan.Name = "Ivan";
            this.Ivan.Size = new System.Drawing.Size(828, 17);
            this.Ivan.TabIndex = 8;
            this.Ivan.TabStop = true;
            this.Ivan.Text = "Quiero el nombre de usuario. Te doy  la posicion del jugador con una puntuación p" +
                "or debajo de la propuesta en la misma partida en la que el usuario propuesto ha " +
                "perdido.";
            this.Ivan.UseVisualStyleBackColor = true;
            // 
            // ListaConectados
            // 
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.Location = new System.Drawing.Point(271, 259);
            this.ListaConectados.Margin = new System.Windows.Forms.Padding(2);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.RowTemplate.Height = 28;
            this.ListaConectados.Size = new System.Drawing.Size(107, 73);
            this.ListaConectados.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(21, 259);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Número de usuarios conectados:";
            // 
            // NumConn
            // 
            this.NumConn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NumConn.Location = new System.Drawing.Point(198, 259);
            this.NumConn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumConn.Name = "NumConn";
            this.NumConn.Size = new System.Drawing.Size(40, 15);
            this.NumConn.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1413, 569);
=======
            this.ClientSize = new System.Drawing.Size(913, 398);
>>>>>>> dev-v4
            this.Controls.Add(this.NumConn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ListaConectados);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Edgar;
        private System.Windows.Forms.RadioButton Ivan;
        private System.Windows.Forms.RadioButton Omar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PosicionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FechaBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NumJugadoresBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PuntuacionBox;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UsernameConsultaBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PerdedorBox;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.DataGridView ListaConectados;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label NumConn;
<<<<<<< HEAD
=======
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Button Jugar;
        private System.Windows.Forms.Button Añadir;
        private System.Windows.Forms.Label partidasLabel;
        private System.Windows.Forms.DataGridView ListaPartidas;
        private System.Windows.Forms.Label partidasBox;
        private System.Windows.Forms.TextBox Chat;
        private System.Windows.Forms.RichTextBox MensajesChat;
>>>>>>> dev-v4
    }
}

