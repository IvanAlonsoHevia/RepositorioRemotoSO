namespace WindowsFormsApplication1.Forms
{
    partial class CrearPartida
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
            this.Invitar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Añadir = new System.Windows.Forms.Button();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.NumConn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // Invitar
            // 
            this.Invitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Invitar.Location = new System.Drawing.Point(542, 565);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(306, 166);
            this.Invitar.TabIndex = 19;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Olive;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(848, 64);
            this.label9.TabIndex = 18;
            this.label9.Text = "Número de usuarios conectados:";
            // 
            // Añadir
            // 
            this.Añadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Añadir.Location = new System.Drawing.Point(192, 565);
            this.Añadir.Name = "Añadir";
            this.Añadir.Size = new System.Drawing.Size(318, 166);
            this.Añadir.TabIndex = 20;
            this.Añadir.Text = "Añadir Invitación";
            this.Añadir.UseVisualStyleBackColor = true;
            this.Añadir.Click += new System.EventHandler(this.Añadir_Click);
            // 
            // ListaConectados
            // 
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaConectados.Location = new System.Drawing.Point(192, 183);
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.RowTemplate.Height = 28;
            this.ListaConectados.Size = new System.Drawing.Size(656, 376);
            this.ListaConectados.TabIndex = 22;
            // 
            // NumConn
            // 
            this.NumConn.BackColor = System.Drawing.Color.Olive;
            this.NumConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumConn.Location = new System.Drawing.Point(894, 47);
            this.NumConn.Name = "NumConn";
            this.NumConn.Size = new System.Drawing.Size(90, 64);
            this.NumConn.TabIndex = 23;
            // 
            // CrearPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1057, 918);
            this.Controls.Add(this.NumConn);
            this.Controls.Add(this.ListaConectados);
            this.Controls.Add(this.Invitar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Añadir);
            this.Name = "CrearPartida";
            this.Text = "CrearPartitda";
            this.Load += new System.EventHandler(this.CrearPartida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Añadir;
        private System.Windows.Forms.DataGridView ListaConectados;
        private System.Windows.Forms.Label NumConn;
    }
}