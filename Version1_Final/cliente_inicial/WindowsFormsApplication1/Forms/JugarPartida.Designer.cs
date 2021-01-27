namespace WindowsFormsApplication1.Forms
{
    partial class JugarPartida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JugarPartida));
            this.ListaPartidas = new System.Windows.Forms.DataGridView();
            this.partidasLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.partidasBox = new System.Windows.Forms.Label();
            this.Jugar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListaPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaPartidas
            // 
            this.ListaPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaPartidas.Location = new System.Drawing.Point(212, 114);
            this.ListaPartidas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListaPartidas.Name = "ListaPartidas";
            this.ListaPartidas.RowTemplate.Height = 28;
            this.ListaPartidas.Size = new System.Drawing.Size(227, 198);
            this.ListaPartidas.TabIndex = 19;
            // 
            // partidasLabel
            // 
            this.partidasLabel.AutoSize = true;
            this.partidasLabel.BackColor = System.Drawing.Color.Transparent;
            this.partidasLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidasLabel.Location = new System.Drawing.Point(103, 50);
            this.partidasLabel.Name = "partidasLabel";
            this.partidasLabel.Size = new System.Drawing.Size(386, 34);
            this.partidasLabel.TabIndex = 25;
            this.partidasLabel.Text = "PARTIDAS DISPONIBLES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Elige una partida para unirte.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // partidasBox
            // 
            this.partidasBox.BackColor = System.Drawing.Color.Transparent;
            this.partidasBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.partidasBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidasBox.Location = new System.Drawing.Point(507, 50);
            this.partidasBox.Name = "partidasBox";
            this.partidasBox.Size = new System.Drawing.Size(85, 42);
            this.partidasBox.TabIndex = 26;
            // 
            // Jugar
            // 
            this.Jugar.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugar.Location = new System.Drawing.Point(263, 330);
            this.Jugar.Margin = new System.Windows.Forms.Padding(4);
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(144, 49);
            this.Jugar.TabIndex = 21;
            this.Jugar.Text = "JUGAR";
            this.Jugar.UseVisualStyleBackColor = true;
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // JugarPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(901, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.partidasBox);
            this.Controls.Add(this.partidasLabel);
            this.Controls.Add(this.ListaPartidas);
            this.Controls.Add(this.Jugar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "JugarPartida";
            this.Text = "JugarPartida";
            this.Load += new System.EventHandler(this.JugarPartida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaPartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListaPartidas;
        private System.Windows.Forms.Label partidasLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label partidasBox;
        private System.Windows.Forms.Button Jugar;
    }
}