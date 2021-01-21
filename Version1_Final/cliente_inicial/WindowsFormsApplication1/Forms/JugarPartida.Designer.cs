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
            this.ListaPartidas.Location = new System.Drawing.Point(105, 68);
            this.ListaPartidas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ListaPartidas.Name = "ListaPartidas";
            this.ListaPartidas.RowTemplate.Height = 28;
            this.ListaPartidas.Size = new System.Drawing.Size(458, 136);
            this.ListaPartidas.TabIndex = 19;
            // 
            // partidasLabel
            // 
            this.partidasLabel.AutoSize = true;
            this.partidasLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.partidasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidasLabel.Location = new System.Drawing.Point(100, 11);
            this.partidasLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.partidasLabel.Name = "partidasLabel";
            this.partidasLabel.Size = new System.Drawing.Size(292, 36);
            this.partidasLabel.TabIndex = 25;
            this.partidasLabel.Text = "Partidas disponibles:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Elige una partida para unirte.";
            // 
            // partidasBox
            // 
            this.partidasBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.partidasBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.partidasBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidasBox.Location = new System.Drawing.Point(409, 11);
            this.partidasBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.partidasBox.Name = "partidasBox";
            this.partidasBox.Size = new System.Drawing.Size(64, 34);
            this.partidasBox.TabIndex = 26;
            // 
            // Jugar
            // 
            this.Jugar.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugar.Location = new System.Drawing.Point(244, 268);
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(204, 64);
            this.Jugar.TabIndex = 21;
            this.Jugar.Text = "JUGAR";
            this.Jugar.UseVisualStyleBackColor = true;
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // JugarPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(676, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.partidasBox);
            this.Controls.Add(this.partidasLabel);
            this.Controls.Add(this.ListaPartidas);
            this.Controls.Add(this.Jugar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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