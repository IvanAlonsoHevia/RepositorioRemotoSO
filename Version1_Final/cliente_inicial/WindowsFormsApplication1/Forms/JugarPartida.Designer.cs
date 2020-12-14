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
            this.Jugar = new System.Windows.Forms.Button();
            this.partidasLabel = new System.Windows.Forms.Label();
            this.partidasBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListaPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaPartidas
            // 
            this.ListaPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaPartidas.Location = new System.Drawing.Point(158, 172);
            this.ListaPartidas.Name = "ListaPartidas";
            this.ListaPartidas.RowTemplate.Height = 28;
            this.ListaPartidas.Size = new System.Drawing.Size(687, 377);
            this.ListaPartidas.TabIndex = 19;
            // 
            // Jugar
            // 
            this.Jugar.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugar.Location = new System.Drawing.Point(158, 574);
            this.Jugar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(687, 129);
            this.Jugar.TabIndex = 21;
            this.Jugar.Text = "JUGAR";
            this.Jugar.UseVisualStyleBackColor = true;
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // partidasLabel
            // 
            this.partidasLabel.AutoSize = true;
            this.partidasLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.partidasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidasLabel.Location = new System.Drawing.Point(149, 56);
            this.partidasLabel.Name = "partidasLabel";
            this.partidasLabel.Size = new System.Drawing.Size(425, 52);
            this.partidasLabel.TabIndex = 25;
            this.partidasLabel.Text = "Partidas disponibles:";
            // 
            // partidasBox
            // 
            this.partidasBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.partidasBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.partidasBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidasBox.Location = new System.Drawing.Point(613, 56);
            this.partidasBox.Name = "partidasBox";
            this.partidasBox.Size = new System.Drawing.Size(97, 52);
            this.partidasBox.TabIndex = 26;
            // 
            // JugarPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1057, 918);
            this.Controls.Add(this.partidasBox);
            this.Controls.Add(this.partidasLabel);
            this.Controls.Add(this.ListaPartidas);
            this.Controls.Add(this.Jugar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "JugarPartida";
            this.Text = "JugarPartida";
            this.Load += new System.EventHandler(this.JugarPartida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaPartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListaPartidas;
        private System.Windows.Forms.Button Jugar;
        private System.Windows.Forms.Label partidasLabel;
        private System.Windows.Forms.Label partidasBox;
    }
}