namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skalaSzarościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projekcjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szkieletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projekcjaLiteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapisDoPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porównanieDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odczytZPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.edycjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Checked = true;
            this.plikToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.Checked = true;
            this.edycjaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skalaSzarościToolStripMenuItem,
            this.progowanieToolStripMenuItem,
            this.projekcjaToolStripMenuItem,
            this.szkieletToolStripMenuItem,
            this.projekcjaLiteryToolStripMenuItem,
            this.odczytZPlikuToolStripMenuItem,
            this.porównanieDanychToolStripMenuItem,
            this.zapisDoPlikuToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // skalaSzarościToolStripMenuItem
            // 
            this.skalaSzarościToolStripMenuItem.Name = "skalaSzarościToolStripMenuItem";
            this.skalaSzarościToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.skalaSzarościToolStripMenuItem.Text = "Skala Szarości";
            this.skalaSzarościToolStripMenuItem.Click += new System.EventHandler(this.skalaSzarościToolStripMenuItem_Click);
            // 
            // progowanieToolStripMenuItem
            // 
            this.progowanieToolStripMenuItem.Name = "progowanieToolStripMenuItem";
            this.progowanieToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.progowanieToolStripMenuItem.Text = "Progowanie";
            this.progowanieToolStripMenuItem.Click += new System.EventHandler(this.progowanieToolStripMenuItem_Click);
            // 
            // projekcjaToolStripMenuItem
            // 
            this.projekcjaToolStripMenuItem.Name = "projekcjaToolStripMenuItem";
            this.projekcjaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.projekcjaToolStripMenuItem.Text = "Projekcja";
            this.projekcjaToolStripMenuItem.Click += new System.EventHandler(this.projekcjaToolStripMenuItem_Click);
            // 
            // szkieletToolStripMenuItem
            // 
            this.szkieletToolStripMenuItem.Name = "szkieletToolStripMenuItem";
            this.szkieletToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.szkieletToolStripMenuItem.Text = "Szkielet";
            this.szkieletToolStripMenuItem.Click += new System.EventHandler(this.szkieletToolStripMenuItem_Click);
            // 
            // projekcjaLiteryToolStripMenuItem
            // 
            this.projekcjaLiteryToolStripMenuItem.Name = "projekcjaLiteryToolStripMenuItem";
            this.projekcjaLiteryToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.projekcjaLiteryToolStripMenuItem.Text = "ProjekcjaLitery";
            this.projekcjaLiteryToolStripMenuItem.Click += new System.EventHandler(this.projekcjaLiteryToolStripMenuItem_Click);
            // 
            // zapisDoPlikuToolStripMenuItem
            // 
            this.zapisDoPlikuToolStripMenuItem.Name = "zapisDoPlikuToolStripMenuItem";
            this.zapisDoPlikuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.zapisDoPlikuToolStripMenuItem.Text = "ZapisDoPliku";
            this.zapisDoPlikuToolStripMenuItem.Click += new System.EventHandler(this.zapisDoPlikuToolStripMenuItem_Click);
            // 
            // porównanieDanychToolStripMenuItem
            // 
            this.porównanieDanychToolStripMenuItem.Name = "porównanieDanychToolStripMenuItem";
            this.porównanieDanychToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.porównanieDanychToolStripMenuItem.Text = "PorównanieDanych";
            this.porównanieDanychToolStripMenuItem.Click += new System.EventHandler(this.porównanieDanychToolStripMenuItem_Click);
            // 
            // odczytZPlikuToolStripMenuItem
            // 
            this.odczytZPlikuToolStripMenuItem.Name = "odczytZPlikuToolStripMenuItem";
            this.odczytZPlikuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.odczytZPlikuToolStripMenuItem.Text = "OdczytZPliku";
            this.odczytZPlikuToolStripMenuItem.Click += new System.EventHandler(this.odczytZPlikuToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 28);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 422);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem skalaSzarościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projekcjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szkieletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projekcjaLiteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapisDoPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porównanieDanychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odczytZPlikuToolStripMenuItem;
    }
}

