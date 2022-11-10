namespace TableGames
{
    partial class Configuracion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btonTorneos = new System.Windows.Forms.Button();
            this.btonJugadores = new System.Windows.Forms.Button();
            this.btonJuegos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btonFin = new System.Windows.Forms.Button();
            this.btonSig = new System.Windows.Forms.Button();
            this.btonAnt = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btonTorneos);
            this.panel1.Controls.Add(this.btonJugadores);
            this.panel1.Controls.Add(this.btonJuegos);
            this.panel1.Location = new System.Drawing.Point(-7, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 788);
            this.panel1.TabIndex = 0;
            // 
            // btonTorneos
            // 
            this.btonTorneos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonTorneos.BackColor = System.Drawing.Color.Transparent;
            this.btonTorneos.FlatAppearance.BorderSize = 0;
            this.btonTorneos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.btonTorneos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btonTorneos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonTorneos.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonTorneos.ForeColor = System.Drawing.Color.White;
            this.btonTorneos.Image = ((System.Drawing.Image)(resources.GetObject("btonTorneos.Image")));
            this.btonTorneos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btonTorneos.Location = new System.Drawing.Point(0, 221);
            this.btonTorneos.Name = "btonTorneos";
            this.btonTorneos.Size = new System.Drawing.Size(316, 77);
            this.btonTorneos.TabIndex = 2;
            this.btonTorneos.Text = "Torneos";
            this.btonTorneos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btonTorneos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.btonTorneos, "Seleccionar el tipo de torneo deseado.");
            this.btonTorneos.UseVisualStyleBackColor = false;
            this.btonTorneos.Visible = false;
            this.btonTorneos.Click += new System.EventHandler(this.BtonTorneos_Click);
            // 
            // btonJugadores
            // 
            this.btonJugadores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonJugadores.BackColor = System.Drawing.Color.Transparent;
            this.btonJugadores.FlatAppearance.BorderSize = 0;
            this.btonJugadores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.btonJugadores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btonJugadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonJugadores.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonJugadores.ForeColor = System.Drawing.Color.White;
            this.btonJugadores.Image = ((System.Drawing.Image)(resources.GetObject("btonJugadores.Image")));
            this.btonJugadores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btonJugadores.Location = new System.Drawing.Point(0, 136);
            this.btonJugadores.Name = "btonJugadores";
            this.btonJugadores.Size = new System.Drawing.Size(316, 79);
            this.btonJugadores.TabIndex = 1;
            this.btonJugadores.Text = "Jugadores";
            this.btonJugadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btonJugadores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.btonJugadores, "Crear los jugadores de la competencia.");
            this.btonJugadores.UseVisualStyleBackColor = false;
            this.btonJugadores.Visible = false;
            this.btonJugadores.Click += new System.EventHandler(this.BtonJugadores_Click);
            // 
            // btonJuegos
            // 
            this.btonJuegos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonJuegos.BackColor = System.Drawing.Color.Transparent;
            this.btonJuegos.FlatAppearance.BorderSize = 0;
            this.btonJuegos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.btonJuegos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btonJuegos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonJuegos.Font = new System.Drawing.Font("Snap ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonJuegos.ForeColor = System.Drawing.Color.White;
            this.btonJuegos.Image = ((System.Drawing.Image)(resources.GetObject("btonJuegos.Image")));
            this.btonJuegos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btonJuegos.Location = new System.Drawing.Point(3, 52);
            this.btonJuegos.Name = "btonJuegos";
            this.btonJuegos.Size = new System.Drawing.Size(313, 78);
            this.btonJuegos.TabIndex = 0;
            this.btonJuegos.Text = "Juegos";
            this.btonJuegos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btonJuegos, "Seleccionar el juego deseado.");
            this.btonJuegos.UseVisualStyleBackColor = false;
            this.btonJuegos.Click += new System.EventHandler(this.BtonJuegos_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(211)))), ((int)(((byte)(248)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btonFin);
            this.panel2.Controls.Add(this.btonSig);
            this.panel2.Controls.Add(this.btonAnt);
            this.panel2.Location = new System.Drawing.Point(308, 700);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 88);
            this.panel2.TabIndex = 1;
            // 
            // btonFin
            // 
            this.btonFin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonFin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btonFin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btonFin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btonFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonFin.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonFin.ForeColor = System.Drawing.Color.White;
            this.btonFin.Location = new System.Drawing.Point(729, 22);
            this.btonFin.Name = "btonFin";
            this.btonFin.Size = new System.Drawing.Size(134, 43);
            this.btonFin.TabIndex = 2;
            this.btonFin.Text = "Finalizar";
            this.btonFin.UseVisualStyleBackColor = false;
            this.btonFin.Visible = false;
            this.btonFin.Click += new System.EventHandler(this.BtonFin_Click);
            // 
            // btonSig
            // 
            this.btonSig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonSig.BackColor = System.Drawing.Color.Transparent;
            this.btonSig.Cursor = System.Windows.Forms.Cursors.Default;
            this.btonSig.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btonSig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btonSig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btonSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonSig.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonSig.ForeColor = System.Drawing.Color.White;
            this.btonSig.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btonSig.Location = new System.Drawing.Point(729, 22);
            this.btonSig.Name = "btonSig";
            this.btonSig.Size = new System.Drawing.Size(134, 43);
            this.btonSig.TabIndex = 1;
            this.btonSig.Text = "Siguiente";
            this.btonSig.UseCompatibleTextRendering = true;
            this.btonSig.UseVisualStyleBackColor = false;
            this.btonSig.Click += new System.EventHandler(this.BtonSig_Click);
            // 
            // btonAnt
            // 
            this.btonAnt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonAnt.BackColor = System.Drawing.Color.Transparent;
            this.btonAnt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btonAnt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btonAnt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btonAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonAnt.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonAnt.ForeColor = System.Drawing.Color.White;
            this.btonAnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btonAnt.Location = new System.Drawing.Point(578, 22);
            this.btonAnt.Name = "btonAnt";
            this.btonAnt.Size = new System.Drawing.Size(134, 43);
            this.btonAnt.TabIndex = 0;
            this.btonAnt.Text = "Anterior";
            this.btonAnt.UseVisualStyleBackColor = false;
            this.btonAnt.Visible = false;
            this.btonAnt.Click += new System.EventHandler(this.BtonAnt_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Controls.Add(this.pictureBox1);
            this.panelContenedor.ForeColor = System.Drawing.Color.Black;
            this.panelContenedor.Location = new System.Drawing.Point(308, -4);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(880, 710);
            this.panelContenedor.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 706);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 778);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emulador de Torneos";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form2_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btonTorneos;
        private System.Windows.Forms.Button btonJugadores;
        private System.Windows.Forms.Button btonJuegos;
        private System.Windows.Forms.Button btonAnt;
        private System.Windows.Forms.Button btonSig;
        private System.Windows.Forms.Button btonFin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}