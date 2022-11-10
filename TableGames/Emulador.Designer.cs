namespace TableGames
{
    partial class Emulador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Emulador));
            this.tboxResultados = new System.Windows.Forms.TextBox();
            this.btonEjecTorneo = new System.Windows.Forms.Button();
            this.btonEjecPart = new System.Windows.Forms.Button();
            this.btonEjecJuego = new System.Windows.Forms.Button();
            this.btonLimpiar = new System.Windows.Forms.Button();
            this.checkPartida = new System.Windows.Forms.CheckBox();
            this.checkJuegos = new System.Windows.Forms.CheckBox();
            this.checkJugadas = new System.Windows.Forms.CheckBox();
            this.btonEjecJugada = new System.Windows.Forms.Button();
            this.btonAutom = new System.Windows.Forms.Button();
            this.btonPausar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblInfor = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxResultados
            // 
            this.tboxResultados.BackColor = System.Drawing.Color.White;
            this.tboxResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxResultados.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxResultados.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxResultados.ForeColor = System.Drawing.Color.SteelBlue;
            this.tboxResultados.Location = new System.Drawing.Point(498, 150);
            this.tboxResultados.Margin = new System.Windows.Forms.Padding(4);
            this.tboxResultados.Multiline = true;
            this.tboxResultados.Name = "tboxResultados";
            this.tboxResultados.ReadOnly = true;
            this.tboxResultados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tboxResultados.Size = new System.Drawing.Size(613, 562);
            this.tboxResultados.TabIndex = 9;
            this.tboxResultados.TabStop = false;
            this.tboxResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxResultados.WordWrap = false;
            // 
            // btonEjecTorneo
            // 
            this.btonEjecTorneo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonEjecTorneo.BackColor = System.Drawing.Color.Transparent;
            this.btonEjecTorneo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonEjecTorneo.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonEjecTorneo.ForeColor = System.Drawing.Color.Black;
            this.btonEjecTorneo.Location = new System.Drawing.Point(27, 44);
            this.btonEjecTorneo.Name = "btonEjecTorneo";
            this.btonEjecTorneo.Size = new System.Drawing.Size(140, 56);
            this.btonEjecTorneo.TabIndex = 10;
            this.btonEjecTorneo.Text = "Ejecutar Torneo";
            this.toolTip1.SetToolTip(this.btonEjecTorneo, "Ejecutar todas las partidas restantes del torneo.");
            this.btonEjecTorneo.UseVisualStyleBackColor = false;
            this.btonEjecTorneo.Click += new System.EventHandler(this.BtonEjecTorneo_Click);
            // 
            // btonEjecPart
            // 
            this.btonEjecPart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonEjecPart.BackColor = System.Drawing.Color.Transparent;
            this.btonEjecPart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonEjecPart.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonEjecPart.ForeColor = System.Drawing.Color.Black;
            this.btonEjecPart.Location = new System.Drawing.Point(206, 32);
            this.btonEjecPart.Name = "btonEjecPart";
            this.btonEjecPart.Size = new System.Drawing.Size(142, 56);
            this.btonEjecPart.TabIndex = 11;
            this.btonEjecPart.Text = "Ejecutar Partida";
            this.toolTip1.SetToolTip(this.btonEjecPart, "Ejecutar partida actual.");
            this.btonEjecPart.UseVisualStyleBackColor = false;
            this.btonEjecPart.Click += new System.EventHandler(this.BtonEjecPart_Click);
            // 
            // btonEjecJuego
            // 
            this.btonEjecJuego.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonEjecJuego.BackColor = System.Drawing.Color.Transparent;
            this.btonEjecJuego.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonEjecJuego.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonEjecJuego.ForeColor = System.Drawing.Color.Black;
            this.btonEjecJuego.Location = new System.Drawing.Point(387, 44);
            this.btonEjecJuego.Name = "btonEjecJuego";
            this.btonEjecJuego.Size = new System.Drawing.Size(144, 55);
            this.btonEjecJuego.TabIndex = 12;
            this.btonEjecJuego.Text = "Ejecutar Juego";
            this.toolTip1.SetToolTip(this.btonEjecJuego, "Ejecutar juego actual.");
            this.btonEjecJuego.UseVisualStyleBackColor = false;
            this.btonEjecJuego.Click += new System.EventHandler(this.BtonEjecJuego_Click);
            // 
            // btonLimpiar
            // 
            this.btonLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonLimpiar.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btonLimpiar.Location = new System.Drawing.Point(939, 32);
            this.btonLimpiar.Name = "btonLimpiar";
            this.btonLimpiar.Size = new System.Drawing.Size(172, 67);
            this.btonLimpiar.TabIndex = 13;
            this.btonLimpiar.Text = "Borrar Notificaciones";
            this.btonLimpiar.UseVisualStyleBackColor = false;
            this.btonLimpiar.Click += new System.EventHandler(this.BtonLimpiar_Click);
            // 
            // checkPartida
            // 
            this.checkPartida.AutoSize = true;
            this.checkPartida.BackColor = System.Drawing.Color.Transparent;
            this.checkPartida.Checked = true;
            this.checkPartida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPartida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkPartida.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPartida.ForeColor = System.Drawing.Color.Black;
            this.checkPartida.Location = new System.Drawing.Point(761, 12);
            this.checkPartida.Name = "checkPartida";
            this.checkPartida.Size = new System.Drawing.Size(100, 26);
            this.checkPartida.TabIndex = 15;
            this.checkPartida.Text = "Partidas";
            this.toolTip1.SetToolTip(this.checkPartida, "Activar/Desactivar notificación.");
            this.checkPartida.UseVisualStyleBackColor = false;
            this.checkPartida.CheckedChanged += new System.EventHandler(this.CheckPartida_CheckedChanged);
            // 
            // checkJuegos
            // 
            this.checkJuegos.AutoSize = true;
            this.checkJuegos.BackColor = System.Drawing.Color.Transparent;
            this.checkJuegos.Checked = true;
            this.checkJuegos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkJuegos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkJuegos.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkJuegos.ForeColor = System.Drawing.Color.Black;
            this.checkJuegos.Location = new System.Drawing.Point(761, 47);
            this.checkJuegos.Name = "checkJuegos";
            this.checkJuegos.Size = new System.Drawing.Size(88, 26);
            this.checkJuegos.TabIndex = 16;
            this.checkJuegos.Text = "Juegos";
            this.toolTip1.SetToolTip(this.checkJuegos, "Activar/Desactivar notificación.");
            this.checkJuegos.UseVisualStyleBackColor = false;
            this.checkJuegos.CheckedChanged += new System.EventHandler(this.CheckJuegos_CheckedChanged);
            // 
            // checkJugadas
            // 
            this.checkJugadas.AutoSize = true;
            this.checkJugadas.BackColor = System.Drawing.Color.Transparent;
            this.checkJugadas.Checked = true;
            this.checkJugadas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkJugadas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkJugadas.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkJugadas.ForeColor = System.Drawing.Color.Black;
            this.checkJugadas.Location = new System.Drawing.Point(761, 86);
            this.checkJugadas.Name = "checkJugadas";
            this.checkJugadas.Size = new System.Drawing.Size(97, 26);
            this.checkJugadas.TabIndex = 17;
            this.checkJugadas.Text = "Jugadas";
            this.toolTip1.SetToolTip(this.checkJugadas, "Activar/Desactivar notificación.");
            this.checkJugadas.UseVisualStyleBackColor = false;
            this.checkJugadas.CheckedChanged += new System.EventHandler(this.CheckJugadas_CheckedChanged);
            // 
            // btonEjecJugada
            // 
            this.btonEjecJugada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonEjecJugada.BackColor = System.Drawing.Color.Transparent;
            this.btonEjecJugada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonEjecJugada.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonEjecJugada.ForeColor = System.Drawing.Color.Black;
            this.btonEjecJugada.Location = new System.Drawing.Point(564, 32);
            this.btonEjecJugada.Name = "btonEjecJugada";
            this.btonEjecJugada.Size = new System.Drawing.Size(133, 56);
            this.btonEjecJugada.TabIndex = 18;
            this.btonEjecJugada.Text = "Ejecutar Jugada";
            this.toolTip1.SetToolTip(this.btonEjecJugada, "Ejecutar una única jugada en el juego actual.");
            this.btonEjecJugada.UseVisualStyleBackColor = false;
            this.btonEjecJugada.Click += new System.EventHandler(this.BtonEjecJugada_Click);
            // 
            // btonAutom
            // 
            this.btonAutom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonAutom.BackColor = System.Drawing.Color.Transparent;
            this.btonAutom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonAutom.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonAutom.Image = ((System.Drawing.Image)(resources.GetObject("btonAutom.Image")));
            this.btonAutom.Location = new System.Drawing.Point(387, 169);
            this.btonAutom.Name = "btonAutom";
            this.btonAutom.Size = new System.Drawing.Size(56, 54);
            this.btonAutom.TabIndex = 19;
            this.btonAutom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btonAutom, "Ejecutar automáticamente con un tiempo de espera entre jugadas.");
            this.btonAutom.UseVisualStyleBackColor = false;
            this.btonAutom.Click += new System.EventHandler(this.BtonAutom_Click);
            // 
            // btonPausar
            // 
            this.btonPausar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btonPausar.BackColor = System.Drawing.Color.Transparent;
            this.btonPausar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btonPausar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btonPausar.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonPausar.Image = ((System.Drawing.Image)(resources.GetObject("btonPausar.Image")));
            this.btonPausar.Location = new System.Drawing.Point(387, 229);
            this.btonPausar.Name = "btonPausar";
            this.btonPausar.Size = new System.Drawing.Size(56, 54);
            this.btonPausar.TabIndex = 20;
            this.btonPausar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btonPausar, "Pausar la ejecución automática.");
            this.btonPausar.UseVisualStyleBackColor = false;
            this.btonPausar.Click += new System.EventHandler(this.BtonPausar_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.Color.SteelBlue;
            this.trackBar1.LargeChange = 3;
            this.trackBar1.Location = new System.Drawing.Point(27, 108);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar1.Size = new System.Drawing.Size(412, 54);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.trackBar1, "Modificar el tiempo de la ejecución.");
            this.trackBar1.Value = 1000;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // lblInfor
            // 
            this.lblInfor.BackColor = System.Drawing.Color.Transparent;
            this.lblInfor.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfor.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblInfor.Location = new System.Drawing.Point(22, 169);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(80, 54);
            this.lblInfor.TabIndex = 23;
            this.lblInfor.Text = "1000";
            this.lblInfor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblInfor, "Mostrar el intervalo del tiempo de espera entre jugadas.");
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Emulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 778);
            this.Controls.Add(this.lblInfor);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btonPausar);
            this.Controls.Add(this.btonAutom);
            this.Controls.Add(this.btonEjecJugada);
            this.Controls.Add(this.checkJugadas);
            this.Controls.Add(this.checkJuegos);
            this.Controls.Add(this.checkPartida);
            this.Controls.Add(this.btonLimpiar);
            this.Controls.Add(this.btonEjecJuego);
            this.Controls.Add(this.btonEjecPart);
            this.Controls.Add(this.btonEjecTorneo);
            this.Controls.Add(this.tboxResultados);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Emulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emulador de Torneos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btonEjecTorneo;
        private System.Windows.Forms.Button btonEjecPart;
        private System.Windows.Forms.Button btonEjecJuego;
        private System.Windows.Forms.Button btonLimpiar;
        private System.Windows.Forms.CheckBox checkPartida;
        private System.Windows.Forms.CheckBox checkJuegos;
        private System.Windows.Forms.CheckBox checkJugadas;
        private System.Windows.Forms.Button btonEjecJugada;
        private System.Windows.Forms.Button btonAutom;
        private System.Windows.Forms.Button btonPausar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblInfor;
        private System.Windows.Forms.TextBox tboxResultados;
    }
}

