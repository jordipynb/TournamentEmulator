namespace TableGames
{
    partial class Contenedor
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
            this.btonJTicTacToe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEdita2 = new System.Windows.Forms.RichTextBox();
            this.txtEdita1 = new System.Windows.Forms.RichTextBox();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.lblGoloso = new System.Windows.Forms.Label();
            this.lblAleatorio = new System.Windows.Forms.Label();
            this.btonAnadGol = new System.Windows.Forms.Button();
            this.btonAnadAleat = new System.Windows.Forms.Button();
            this.tboxJugadores = new System.Windows.Forms.TextBox();
            this.btonTit = new System.Windows.Forms.Button();
            this.btonCI = new System.Windows.Forms.Button();
            this.btonDaD = new System.Windows.Forms.Button();
            this.btonEquipos = new System.Windows.Forms.Button();
            this.btonOthello = new System.Windows.Forms.Button();
            this.btonDomino = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btonJTicTacToe
            // 
            this.btonJTicTacToe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonJTicTacToe.BackColor = System.Drawing.Color.White;
            this.btonJTicTacToe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btonJTicTacToe.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btonJTicTacToe.FlatAppearance.BorderSize = 0;
            this.btonJTicTacToe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonJTicTacToe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonJTicTacToe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonJTicTacToe.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonJTicTacToe.Location = new System.Drawing.Point(341, 28);
            this.btonJTicTacToe.Name = "btonJTicTacToe";
            this.btonJTicTacToe.Size = new System.Drawing.Size(176, 47);
            this.btonJTicTacToe.TabIndex = 0;
            this.btonJTicTacToe.Text = "Tic Tac Toe";
            this.btonJTicTacToe.UseVisualStyleBackColor = false;
            this.btonJTicTacToe.Visible = false;
            this.btonJTicTacToe.Click += new System.EventHandler(this.BtonJTicTacToe_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // txtEdita2
            // 
            this.txtEdita2.Font = new System.Drawing.Font("MV Boli", 10.15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdita2.Location = new System.Drawing.Point(239, 104);
            this.txtEdita2.Multiline = false;
            this.txtEdita2.Name = "txtEdita2";
            this.txtEdita2.Size = new System.Drawing.Size(164, 30);
            this.txtEdita2.TabIndex = 3;
            this.txtEdita2.Text = "Editar nombre";
            this.txtEdita2.Visible = false;
            // 
            // txtEdita1
            // 
            this.txtEdita1.Font = new System.Drawing.Font("MV Boli", 10.15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdita1.Location = new System.Drawing.Point(239, 64);
            this.txtEdita1.Multiline = false;
            this.txtEdita1.Name = "txtEdita1";
            this.txtEdita1.Size = new System.Drawing.Size(164, 30);
            this.txtEdita1.TabIndex = 4;
            this.txtEdita1.Text = "Editar nombre";
            this.txtEdita1.Visible = false;
            // 
            // lblInformacion
            // 
            this.lblInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lblInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInformacion.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.Location = new System.Drawing.Point(12, 28);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(549, 37);
            this.lblInformacion.TabIndex = 5;
            this.lblInformacion.Text = "Establecer un nombre al Jugador deseado y añadir:";
            this.lblInformacion.Visible = false;
            // 
            // lblGoloso
            // 
            this.lblGoloso.BackColor = System.Drawing.Color.Transparent;
            this.lblGoloso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGoloso.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoloso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoloso.Location = new System.Drawing.Point(25, 64);
            this.lblGoloso.Name = "lblGoloso";
            this.lblGoloso.Size = new System.Drawing.Size(193, 30);
            this.lblGoloso.TabIndex = 6;
            this.lblGoloso.Text = "Jugador Goloso";
            this.lblGoloso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoloso.Visible = false;
            // 
            // lblAleatorio
            // 
            this.lblAleatorio.BackColor = System.Drawing.Color.Transparent;
            this.lblAleatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAleatorio.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAleatorio.Location = new System.Drawing.Point(25, 104);
            this.lblAleatorio.Name = "lblAleatorio";
            this.lblAleatorio.Size = new System.Drawing.Size(193, 30);
            this.lblAleatorio.TabIndex = 7;
            this.lblAleatorio.Text = "Jugador Aleatorio";
            this.lblAleatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAleatorio.Visible = false;
            // 
            // btonAnadGol
            // 
            this.btonAnadGol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonAnadGol.BackColor = System.Drawing.Color.White;
            this.btonAnadGol.FlatAppearance.BorderSize = 0;
            this.btonAnadGol.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonAnadGol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonAnadGol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonAnadGol.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonAnadGol.Location = new System.Drawing.Point(409, 64);
            this.btonAnadGol.Name = "btonAnadGol";
            this.btonAnadGol.Size = new System.Drawing.Size(95, 30);
            this.btonAnadGol.TabIndex = 8;
            this.btonAnadGol.Text = "Añadir";
            this.btonAnadGol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btonAnadGol.UseVisualStyleBackColor = true;
            this.btonAnadGol.Visible = false;
            this.btonAnadGol.Click += new System.EventHandler(this.BtonAnadGol_Click);
            // 
            // btonAnadAleat
            // 
            this.btonAnadAleat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonAnadAleat.FlatAppearance.BorderSize = 0;
            this.btonAnadAleat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonAnadAleat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonAnadAleat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonAnadAleat.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonAnadAleat.Location = new System.Drawing.Point(409, 104);
            this.btonAnadAleat.Name = "btonAnadAleat";
            this.btonAnadAleat.Size = new System.Drawing.Size(95, 30);
            this.btonAnadAleat.TabIndex = 9;
            this.btonAnadAleat.Text = "Añadir";
            this.btonAnadAleat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btonAnadAleat.UseVisualStyleBackColor = true;
            this.btonAnadAleat.Visible = false;
            this.btonAnadAleat.Click += new System.EventHandler(this.BtonAnadAleat_Click);
            // 
            // tboxJugadores
            // 
            this.tboxJugadores.BackColor = System.Drawing.Color.White;
            this.tboxJugadores.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxJugadores.Location = new System.Drawing.Point(511, 64);
            this.tboxJugadores.Margin = new System.Windows.Forms.Padding(4);
            this.tboxJugadores.Multiline = true;
            this.tboxJugadores.Name = "tboxJugadores";
            this.tboxJugadores.ReadOnly = true;
            this.tboxJugadores.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tboxJugadores.Size = new System.Drawing.Size(347, 135);
            this.tboxJugadores.TabIndex = 10;
            this.tboxJugadores.TabStop = false;
            this.tboxJugadores.Visible = false;
            this.tboxJugadores.WordWrap = false;
            // 
            // btonTit
            // 
            this.btonTit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonTit.FlatAppearance.BorderSize = 0;
            this.btonTit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonTit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonTit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonTit.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonTit.Location = new System.Drawing.Point(776, 20);
            this.btonTit.Name = "btonTit";
            this.btonTit.Size = new System.Drawing.Size(82, 37);
            this.btonTit.TabIndex = 11;
            this.btonTit.Text = "Título";
            this.btonTit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btonTit.UseVisualStyleBackColor = true;
            this.btonTit.Visible = false;
            this.btonTit.Click += new System.EventHandler(this.BtonTit_Click);
            // 
            // btonCI
            // 
            this.btonCI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonCI.FlatAppearance.BorderSize = 0;
            this.btonCI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonCI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonCI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonCI.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonCI.Location = new System.Drawing.Point(306, 20);
            this.btonCI.Name = "btonCI";
            this.btonCI.Size = new System.Drawing.Size(246, 37);
            this.btonCI.TabIndex = 12;
            this.btonCI.Text = "Calificación Individual";
            this.btonCI.UseVisualStyleBackColor = true;
            this.btonCI.Visible = false;
            this.btonCI.Click += new System.EventHandler(this.BtonCI_Click);
            // 
            // btonDaD
            // 
            this.btonDaD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonDaD.FlatAppearance.BorderSize = 0;
            this.btonDaD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonDaD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonDaD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonDaD.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonDaD.Location = new System.Drawing.Point(12, 20);
            this.btonDaD.Name = "btonDaD";
            this.btonDaD.Size = new System.Drawing.Size(131, 37);
            this.btonDaD.TabIndex = 13;
            this.btonDaD.Text = "Dos a Dos";
            this.btonDaD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btonDaD.UseVisualStyleBackColor = true;
            this.btonDaD.Visible = false;
            this.btonDaD.Click += new System.EventHandler(this.BtonDaD_Click);
            // 
            // btonEquipos
            // 
            this.btonEquipos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonEquipos.BackColor = System.Drawing.Color.Transparent;
            this.btonEquipos.FlatAppearance.BorderSize = 0;
            this.btonEquipos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btonEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btonEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonEquipos.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonEquipos.Location = new System.Drawing.Point(616, 660);
            this.btonEquipos.Name = "btonEquipos";
            this.btonEquipos.Size = new System.Drawing.Size(252, 48);
            this.btonEquipos.TabIndex = 14;
            this.btonEquipos.UseVisualStyleBackColor = false;
            this.btonEquipos.Visible = false;
            this.btonEquipos.Click += new System.EventHandler(this.BtonEquipos_Click);
            // 
            // btonOthello
            // 
            this.btonOthello.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonOthello.FlatAppearance.BorderSize = 0;
            this.btonOthello.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonOthello.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonOthello.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonOthello.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonOthello.Location = new System.Drawing.Point(341, 81);
            this.btonOthello.Name = "btonOthello";
            this.btonOthello.Size = new System.Drawing.Size(176, 47);
            this.btonOthello.TabIndex = 16;
            this.btonOthello.Text = "Othello";
            this.btonOthello.UseVisualStyleBackColor = true;
            this.btonOthello.Visible = false;
            this.btonOthello.Click += new System.EventHandler(this.BtonOthello_Click);
            // 
            // btonDomino
            // 
            this.btonDomino.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonDomino.FlatAppearance.BorderSize = 0;
            this.btonDomino.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btonDomino.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btonDomino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonDomino.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonDomino.Location = new System.Drawing.Point(341, 134);
            this.btonDomino.Name = "btonDomino";
            this.btonDomino.Size = new System.Drawing.Size(176, 47);
            this.btonDomino.TabIndex = 17;
            this.btonDomino.Text = "Dominó";
            this.btonDomino.UseVisualStyleBackColor = true;
            this.btonDomino.Visible = false;
            this.btonDomino.Click += new System.EventHandler(this.BtonDomino_Click);
            // 
            // Contenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(880, 710);
            this.Controls.Add(this.btonDomino);
            this.Controls.Add(this.btonOthello);
            this.Controls.Add(this.btonEquipos);
            this.Controls.Add(this.btonDaD);
            this.Controls.Add(this.btonCI);
            this.Controls.Add(this.btonTit);
            this.Controls.Add(this.tboxJugadores);
            this.Controls.Add(this.btonAnadAleat);
            this.Controls.Add(this.btonAnadGol);
            this.Controls.Add(this.lblAleatorio);
            this.Controls.Add(this.lblGoloso);
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.txtEdita1);
            this.Controls.Add(this.txtEdita2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btonJTicTacToe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Contenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form3";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormContenedor_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btonJTicTacToe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtEdita2;
        private System.Windows.Forms.RichTextBox txtEdita1;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.Label lblGoloso;
        private System.Windows.Forms.Label lblAleatorio;
        private System.Windows.Forms.Button btonAnadGol;
        private System.Windows.Forms.Button btonAnadAleat;
        private System.Windows.Forms.TextBox tboxJugadores;
        private System.Windows.Forms.Button btonTit;
        private System.Windows.Forms.Button btonCI;
        private System.Windows.Forms.Button btonDaD;
        private System.Windows.Forms.Button btonEquipos;
        private System.Windows.Forms.Button btonOthello;
        private System.Windows.Forms.Button btonDomino;
    }
}