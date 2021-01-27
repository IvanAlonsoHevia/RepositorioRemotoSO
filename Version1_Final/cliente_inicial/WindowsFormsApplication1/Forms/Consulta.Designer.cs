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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.enviar = new System.Windows.Forms.Button();
            this.Edgar = new System.Windows.Forms.RadioButton();
            this.Omar = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.Ivan = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // enviar
            // 
            this.enviar.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.Location = new System.Drawing.Point(376, 238);
            this.enviar.Margin = new System.Windows.Forms.Padding(4);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(175, 38);
            this.enviar.TabIndex = 23;
            this.enviar.Text = "ENVIAR";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click_1);
            // 
            // Edgar
            // 
            this.Edgar.AutoSize = true;
            this.Edgar.BackColor = System.Drawing.Color.Transparent;
            this.Edgar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edgar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Edgar.Location = new System.Drawing.Point(72, 348);
            this.Edgar.Margin = new System.Windows.Forms.Padding(4);
            this.Edgar.Name = "Edgar";
            this.Edgar.Size = new System.Drawing.Size(447, 21);
            this.Edgar.TabIndex = 15;
            this.Edgar.TabStop = true;
            this.Edgar.Text = "Posición más alta que ha obtenido el usuario introducido.";
            this.Edgar.UseVisualStyleBackColor = false;
            // 
            // Omar
            // 
            this.Omar.AutoSize = true;
            this.Omar.BackColor = System.Drawing.Color.Transparent;
            this.Omar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Omar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Omar.Location = new System.Drawing.Point(72, 377);
            this.Omar.Margin = new System.Windows.Forms.Padding(4);
            this.Omar.Name = "Omar";
            this.Omar.Size = new System.Drawing.Size(530, 21);
            this.Omar.TabIndex = 16;
            this.Omar.TabStop = true;
            this.Omar.Text = "Número de partidas en las que ha participado el usuario introducido.";
            this.Omar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(172, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Username";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(152, 250);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(181, 22);
            this.UsernameBox.TabIndex = 19;
            // 
            // Ivan
            // 
            this.Ivan.AutoSize = true;
            this.Ivan.BackColor = System.Drawing.Color.Transparent;
            this.Ivan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ivan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Ivan.Location = new System.Drawing.Point(72, 319);
            this.Ivan.Margin = new System.Windows.Forms.Padding(4);
            this.Ivan.Name = "Ivan";
            this.Ivan.Size = new System.Drawing.Size(546, 21);
            this.Ivan.TabIndex = 17;
            this.Ivan.TabStop = true;
            this.Ivan.Text = "Puntuación Máxima de entre todas las partidas del usuario introducido.";
            this.Ivan.UseVisualStyleBackColor = false;
            this.Ivan.CheckedChanged += new System.EventHandler(this.Ivan_CheckedChanged);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1098, 618);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.Edgar);
            this.Controls.Add(this.Omar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.Ivan);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Consulta";
            this.Text = "Consulta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.RadioButton Edgar;
        private System.Windows.Forms.RadioButton Omar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.RadioButton Ivan;
    }
}