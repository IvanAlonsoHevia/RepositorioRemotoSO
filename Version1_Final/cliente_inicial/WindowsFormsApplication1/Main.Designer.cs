namespace WindowsFormsApplication1
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.botonRest = new System.Windows.Forms.PictureBox();
            this.botonMin = new System.Windows.Forms.PictureBox();
            this.botonMax = new System.Windows.Forms.PictureBox();
            this.botonCerrar = new System.Windows.Forms.PictureBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.Bienvenido = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnjugar = new System.Windows.Forms.Button();
            this.btncrear = new System.Windows.Forms.Button();
            this.btnconsultar = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.botonRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonCerrar)).BeginInit();
            this.MenuVertical.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelDesktopPanel.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.BarraTitulo.Controls.Add(this.botonRest);
            this.BarraTitulo.Controls.Add(this.botonMin);
            this.BarraTitulo.Controls.Add(this.botonMax);
            this.BarraTitulo.Controls.Add(this.botonCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1429, 38);
            this.BarraTitulo.TabIndex = 0;
            // 
            // botonRest
            // 
            this.botonRest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonRest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonRest.Image = ((System.Drawing.Image)(resources.GetObject("botonRest.Image")));
            this.botonRest.Location = new System.Drawing.Point(1361, 7);
            this.botonRest.Name = "botonRest";
            this.botonRest.Size = new System.Drawing.Size(25, 25);
            this.botonRest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botonRest.TabIndex = 2;
            this.botonRest.TabStop = false;
            this.botonRest.Visible = false;
            this.botonRest.Click += new System.EventHandler(this.botonRest_Click_1);
            // 
            // botonMin
            // 
            this.botonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonMin.Image = ((System.Drawing.Image)(resources.GetObject("botonMin.Image")));
            this.botonMin.Location = new System.Drawing.Point(1330, 7);
            this.botonMin.Name = "botonMin";
            this.botonMin.Size = new System.Drawing.Size(25, 25);
            this.botonMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botonMin.TabIndex = 1;
            this.botonMin.TabStop = false;
            this.botonMin.Click += new System.EventHandler(this.botonMin_Click);
            // 
            // botonMax
            // 
            this.botonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonMax.Image = ((System.Drawing.Image)(resources.GetObject("botonMax.Image")));
            this.botonMax.Location = new System.Drawing.Point(1361, 7);
            this.botonMax.Name = "botonMax";
            this.botonMax.Size = new System.Drawing.Size(25, 25);
            this.botonMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botonMax.TabIndex = 1;
            this.botonMax.TabStop = false;
            this.botonMax.Click += new System.EventHandler(this.botonMax_Click);
            // 
            // botonCerrar
            // 
            this.botonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonCerrar.Image = ((System.Drawing.Image)(resources.GetObject("botonCerrar.Image")));
            this.botonCerrar.Location = new System.Drawing.Point(1392, 7);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(25, 25);
            this.botonCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botonCerrar.TabIndex = 0;
            this.botonCerrar.TabStop = false;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.MenuVertical.Controls.Add(this.Bienvenido);
            this.MenuVertical.Controls.Add(this.panelDesktop);
            this.MenuVertical.Controls.Add(this.btnjugar);
            this.MenuVertical.Controls.Add(this.btncrear);
            this.MenuVertical.Controls.Add(this.btnconsultar);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 38);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(350, 974);
            this.MenuVertical.TabIndex = 1;
            // 
            // Bienvenido
            // 
            this.Bienvenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bienvenido.Font = new System.Drawing.Font("Goudy Stout", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bienvenido.ForeColor = System.Drawing.Color.Gainsboro;
            this.Bienvenido.Location = new System.Drawing.Point(0, 609);
            this.Bienvenido.Name = "Bienvenido";
            this.Bienvenido.Size = new System.Drawing.Size(350, 365);
            this.Bienvenido.TabIndex = 2;
            this.Bienvenido.Text = "Bienvenid@ de nuevo";
            this.Bienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Location = new System.Drawing.Point(350, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(947, 496);
            this.panelDesktop.TabIndex = 3;
            // 
            // btnjugar
            // 
            this.btnjugar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnjugar.FlatAppearance.BorderSize = 0;
            this.btnjugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnjugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnjugar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnjugar.Image = global::WindowsFormsApplication1.Properties.Resources.play_new_1_preview_rev_1;
            this.btnjugar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnjugar.Location = new System.Drawing.Point(0, 406);
            this.btnjugar.Name = "btnjugar";
            this.btnjugar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnjugar.Size = new System.Drawing.Size(350, 203);
            this.btnjugar.TabIndex = 3;
            this.btnjugar.Text = "    Jugar ";
            this.btnjugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnjugar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnjugar.UseVisualStyleBackColor = true;
            this.btnjugar.Click += new System.EventHandler(this.btnjugar_Click);
            // 
            // btncrear
            // 
            this.btncrear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncrear.FlatAppearance.BorderSize = 0;
            this.btncrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncrear.ForeColor = System.Drawing.Color.Gainsboro;
            this.btncrear.Image = global::WindowsFormsApplication1.Properties.Resources.descarga_1_preview_rev_1;
            this.btncrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncrear.Location = new System.Drawing.Point(0, 203);
            this.btncrear.Name = "btncrear";
            this.btncrear.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btncrear.Size = new System.Drawing.Size(350, 203);
            this.btncrear.TabIndex = 2;
            this.btncrear.Text = "    Crear una partida";
            this.btncrear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncrear.UseVisualStyleBackColor = true;
            this.btncrear.Click += new System.EventHandler(this.btncrear_Click);
            // 
            // btnconsultar
            // 
            this.btnconsultar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnconsultar.FlatAppearance.BorderSize = 0;
            this.btnconsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconsultar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnconsultar.Image = global::WindowsFormsApplication1.Properties.Resources.alguna_pregunta_1_1_preview_rev_1;
            this.btnconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnconsultar.Location = new System.Drawing.Point(0, 0);
            this.btnconsultar.Name = "btnconsultar";
            this.btnconsultar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnconsultar.Size = new System.Drawing.Size(350, 203);
            this.btnconsultar.TabIndex = 1;
            this.btnconsultar.Text = "    Realizar una consulta ";
            this.btnconsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnconsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnconsultar.UseVisualStyleBackColor = true;
            this.btnconsultar.Click += new System.EventHandler(this.btnconsultar_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelContenedor.Controls.Add(this.panelLogo);
            this.panelContenedor.Controls.Add(this.panelDesktopPanel);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(350, 38);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1079, 974);
            this.panelContenedor.TabIndex = 2;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogo.Location = new System.Drawing.Point(0, 855);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(1079, 119);
            this.panelLogo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wide Latin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(402, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "PLATJUMP";
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.Controls.Add(this.panelTitleBar);
            this.panelDesktopPanel.Controls.Add(this.pictureBox3);
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(0, 0);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Size = new System.Drawing.Size(1079, 974);
            this.panelDesktopPanel.TabIndex = 3;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(146)))));
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1079, 71);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::WindowsFormsApplication1.Properties.Resources.cruz;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(75, 71);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(485, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.MidnightBlue;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(950, 500);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1079, 974);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 1012);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.MenuVertical);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Form2";
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.botonRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonCerrar)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelDesktopPanel.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox botonCerrar;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox botonMin;
        private System.Windows.Forms.PictureBox botonMax;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox botonRest;
        private System.Windows.Forms.Button btnjugar;
        private System.Windows.Forms.Button btncrear;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnconsultar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Label Bienvenido;
    }
}