using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Games;

namespace TableGames
{
    public partial class Contenedor : Form
    {
        #region Campos
        private readonly int numeroActivo;
        private int count;
        #endregion

        #region Propiedades
        public JuegosdeMesa Juego { get; private set; }
        public List<IJugador<TicTacToe>> JugadorTicTacToe { get; private set; }
        public List<IJugador<Othello>> JugadorOthello { get; private set; }
        public List<IJugador<Domino>> JugadorDomino { get; private set; }
        public TipodeTorneo Torneo { get; private set; }
        #endregion

        public Contenedor(int numeroActivo, JuegosdeMesa juego)
        {
            InitializeComponent();
            this.numeroActivo = numeroActivo;
            // Dependiendo del Juego se cre el torneo y los jugadores con ese tipo
            Juego = juego;
            MostrarControlesFormulario();
            Torneo = TipodeTorneo.None;
            count = 1;
            // Iniciacion de las posibles listas de jugadores a crear
            JugadorTicTacToe = new List<IJugador<TicTacToe>>();
            JugadorOthello = new List<IJugador<Othello>>();
            JugadorDomino = new List<IJugador<Domino>>();
    }

        private void MostrarControlesFormulario()
        {
            switch (numeroActivo)
            {
                case 0:
                    btonJTicTacToe.Visible = true; btonOthello.Visible = true; btonDomino.Visible = true;
                break;
                case 1:
                // Dependiendo del Juego que sea se muestran los jugadores que pueden jugarlo
                if(Juego is TicTacToe || Juego is Othello || Juego is Domino)
                {
                    lblInformacion.Visible = true; lblGoloso.Visible = true; txtEdita1.Visible = true; btonAnadGol.Visible = true;
                    lblAleatorio.Visible = true; txtEdita2.Visible = true; btonAnadAleat.Visible = true; tboxJugadores.Visible = true;
                }
                break;
                default:
                // Dependiendo del Juego que sea se muestran los torneos que pueden ejecutarlo
                if(Juego is TicTacToe || Juego is Othello)
                {
                    btonCI.Visible = true; btonTit.Visible = true; btonDaD.Visible = true;
                }
                else if(Juego is Domino)
                {
                    btonTit.Visible = true; btonDaD.Visible = true;
                    if(!Juego.Equipos) btonCI.Visible = true;
                }
                break;
            }
        }
        private void FormContenedor_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            float width = 0, height = 0;
            Image imagesel;
            switch (numeroActivo)
            {
                case 0: imagesel = Image.FromFile("Pictures\\form3image1.jpg"); break;
                case 1: imagesel = Image.FromFile("Pictures\\form3image2.jpg"); break;
                default: imagesel = Image.FromFile("Pictures\\form3image3.jpg"); width = -5; height = 27; break;
            }
            gr.DrawImage(imagesel, width, height, Width, Height);
        }


        private void BtonEquipos_Click(object sender, EventArgs e)
        {
            if (!Juego.Equipos)
            {
                Juego.Equipos = true;
                btonEquipos.Text = "Desactivar Equipos";
            }
            else
            {
                Juego.Equipos = false;
                btonEquipos.Text = "Activar Equipos";
            }
        }

        // Se escoge el Juego
        private void BtonJTicTacToe_Click(object sender, EventArgs e)
        {
            Juego = new TicTacToe();
            btonEquipos.Visible = Juego.Equipos;
            if (btonEquipos.Visible) btonEquipos.Text = "Desactivar Equipos";
        }
        private void BtonOthello_Click(object sender, EventArgs e)
        {
            Juego = new Othello();
            btonEquipos.Visible = Juego.Equipos;
            if (btonEquipos.Visible) btonEquipos.Text = "Desactivar Equipos";
        }
        private void BtonDomino_Click(object sender, EventArgs e)
        {
            Juego = new Domino();
            btonEquipos.Visible = Juego.Equipos;
            if (btonEquipos.Visible) btonEquipos.Text = "Desactivar Equipos";
        }

        // Se añaden los Juegadores disponibles al torneo
        private void BtonAnadGol_Click(object sender, EventArgs e)
        {
            if (count == 1) tboxJugadores.AppendText("Lista de Jugadores:");
            // Dependiendo del Juego se agregan los jugadores a la lista que le corresponde
            if(Juego is TicTacToe) JugadorTicTacToe.Add(new JugadorGoloso<TicTacToe>(txtEdita1.Text, count, new EvaluadorGoloso()));
            else if(Juego is Othello) JugadorOthello.Add(new JugadorGoloso<Othello>(txtEdita1.Text, count, new EvaluadorGoloso()));
            else if(Juego is Domino) JugadorDomino.Add(new JugadorGoloso<Domino>(txtEdita1.Text, count, new EvaluadorGoloso()));
            tboxJugadores.AppendText("\n");
            tboxJugadores.AppendText(count + ". Jugador Goloso: " + txtEdita1.Text);
            txtEdita1.Text = "Editar nombre";
            count++;
        }
        private void BtonAnadAleat_Click(object sender, EventArgs e)
        {
            if (count == 1) tboxJugadores.AppendText("Lista de Jugadores:");
            // Dependiendo del Juego se agregan los jugadores a la lista que le corresponde
            if(Juego is TicTacToe)
                JugadorTicTacToe.Add(new JugadorAleatorio<TicTacToe>(txtEdita2.Text, count, new EvaluadorAleatorio()));
            else if(Juego is Othello) JugadorOthello.Add(new JugadorAleatorio<Othello>(txtEdita2.Text, count, new EvaluadorAleatorio()));
            else if(Juego is Domino) JugadorDomino.Add(new JugadorAleatorio<Domino>(txtEdita2.Text, count, new EvaluadorAleatorio()));
            tboxJugadores.AppendText("\n");
            tboxJugadores.AppendText(count + ". Jugador Aleatorio: " + txtEdita2.Text);
            txtEdita2.Text = "Editar nombre";
            count++;
        }


        private void BtonCI_Click(object sender, EventArgs e)
        {
            Torneo = TipodeTorneo.CalificacionIndividual;
        }
        private void BtonTit_Click(object sender, EventArgs e)
        {
            Torneo = TipodeTorneo.Titulo;
        }
        private void BtonDaD_Click(object sender, EventArgs e)
        {
            Torneo = TipodeTorneo.DosADos;
        }
    }
}