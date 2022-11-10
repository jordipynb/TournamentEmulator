using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Games;

namespace TableGames
{
    public partial class Emulador : Form
    {
        // Emulador del torneo agregado respecto al Juego que se quiere jugar
        readonly Emulador<TicTacToe> emuladorTicTacToe;
        readonly Emulador<Othello> emuladorOthello;
        readonly Emulador<Domino> emuladorDomino;
        readonly IEnumerator<string> iterador;

        // Es recomndable que agregue los constructores según el juego escogido
        public Emulador(Torneo<TicTacToe> torneo)
        {
            InitializeComponent();
            emuladorTicTacToe = new Emulador<TicTacToe>(torneo);
            iterador = emuladorTicTacToe.PasoAPaso();
        }
        public Emulador(Torneo<Othello> torneo)
        {
            InitializeComponent();
            emuladorOthello = new Emulador<Othello>(torneo);
            iterador = emuladorOthello.PasoAPaso();
        }
        public Emulador(Torneo<Domino> torneo)
        {
            InitializeComponent();
            emuladorDomino = new Emulador<Domino>(torneo);
            iterador = emuladorDomino.PasoAPaso();
        }

        private void BtonLimpiar_Click(object sender, EventArgs e)
        {
            tboxResultados.Clear();
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            lblInfor.Text = trackBar1.Value.ToString();
            timer1.Interval = trackBar1.Value;
        }

        private void CheckPartida_CheckedChanged(object sender, EventArgs e)
        {
            //Dependiendo del emulador se muestra o no, las notificaciones de las Partidas
            if(emuladorTicTacToe != null) emuladorTicTacToe.NotificacionPartidas = checkPartida.Checked;
            else if(emuladorOthello != null) emuladorOthello.NotificacionPartidas = checkPartida.Checked;
            else if(emuladorDomino != null) emuladorDomino.NotificacionPartidas = checkPartida.Checked;
        }
        private void CheckJuegos_CheckedChanged(object sender, EventArgs e)
        {
            //Dependiendo del emulador se muestra o no, las notificaciones de los Juegos
            if(emuladorTicTacToe != null) emuladorTicTacToe.NotificacionJuegos = checkJuegos.Checked;
            else if(emuladorOthello != null) emuladorOthello.NotificacionJuegos = checkJuegos.Checked;
            else if(emuladorDomino != null) emuladorDomino.NotificacionJuegos = checkJuegos.Checked;
        }
        private void CheckJugadas_CheckedChanged(object sender, EventArgs e)
        {
            //Dependiendo del emulador se muestra o no, las notificaciones de las Jugadas
            if(emuladorTicTacToe != null) emuladorTicTacToe.NotificacionJugadas = checkJugadas.Checked;
            else if(emuladorOthello != null) emuladorOthello.NotificacionJugadas = checkJugadas.Checked;
            else if(emuladorDomino != null) emuladorDomino.NotificacionJugadas = checkJugadas.Checked;
        }

        private void BtonEjecTorneo_Click(object sender, EventArgs e)
        {
            //Dependiendo del emulador se ejecuta el torneo
            if(emuladorTicTacToe != null)
            {
                while(emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                Timer1_Tick(sender, e);
            }
            else if(emuladorOthello != null)
            {
                while(emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                Timer1_Tick(sender, e);
            }
            else if(emuladorDomino != null)
            {
                while(emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                Timer1_Tick(sender, e);
            }
        }
        private void BtonEjecPart_Click(object sender, EventArgs e)
        {
            //Dependiendo del emulador se ejecuta la partida actual
            if(emuladorTicTacToe != null)
            {
                while(emuladorTicTacToe.PartidaActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorTicTacToe.TorneoActual.Estado == EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                while(emuladorTicTacToe.PartidaActual != null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
            }
            else if(emuladorOthello != null)
            {
                while(emuladorOthello.PartidaActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorOthello.TorneoActual.Estado == EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                while(emuladorOthello.PartidaActual != null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
            }
            else if(emuladorDomino != null)
            {
                while(emuladorDomino.PartidaActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorDomino.TorneoActual.Estado == EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                while(emuladorDomino.PartidaActual != null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
            }
        }
        private void BtonEjecJuego_Click(object sender, EventArgs e)
        {
            //Dependiendo del emulador se ejecuta el juego actual
            if(emuladorTicTacToe != null)
            {
                while(emuladorTicTacToe.PartidaActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                while(emuladorTicTacToe.JuegoActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorTicTacToe.TorneoActual.Estado == EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                while(emuladorTicTacToe.JuegoActual != null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
            }
            else if(emuladorOthello != null)
            {
                while(emuladorOthello.PartidaActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                while(emuladorOthello.JuegoActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorOthello.TorneoActual.Estado == EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                while(emuladorOthello.JuegoActual != null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
            }
            else if(emuladorDomino != null)
            {
                while(emuladorDomino.PartidaActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                while(emuladorDomino.JuegoActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorDomino.TorneoActual.Estado == EstadoTorneo.Finalizo) Timer1_Tick(sender, e);
                while(emuladorDomino.JuegoActual != null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
            }
        }
        private void BtonEjecJugada_Click(object sender, EventArgs e)
        {
            //Dependiendo del emulador se ejecuta la jugada actual
            if(emuladorTicTacToe != null)
            {
                while(emuladorTicTacToe.PartidaActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                while(emuladorTicTacToe.JuegoActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorTicTacToe.TorneoActual.Estado == EstadoTorneo.Finalizo) { Timer1_Tick(sender, e); return; }
                if(emuladorTicTacToe.JugadaActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                {
                    Timer1_Tick(sender, e);
                    if(emuladorTicTacToe.JuegoActual == null && emuladorTicTacToe.TorneoActual.Estado != EstadoTorneo.Finalizo)
                        BtonEjecJugada_Click(sender, e);
                    return;
                }
            }
            else if(emuladorOthello != null)
            {
                while(emuladorOthello.PartidaActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                while(emuladorOthello.JuegoActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorOthello.TorneoActual.Estado == EstadoTorneo.Finalizo) { Timer1_Tick(sender, e); return; }
                if(emuladorOthello.JugadaActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                {
                    Timer1_Tick(sender, e);
                    if(emuladorOthello.JuegoActual == null && emuladorOthello.TorneoActual.Estado != EstadoTorneo.Finalizo)
                        BtonEjecJugada_Click(sender, e);
                    return;
                }
            }
            else if(emuladorDomino != null)
            {
                while(emuladorDomino.PartidaActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                while(emuladorDomino.JuegoActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                    Timer1_Tick(sender, e);
                if(emuladorDomino.TorneoActual.Estado == EstadoTorneo.Finalizo) { Timer1_Tick(sender, e); return; }
                if(emuladorDomino.JugadaActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                {
                    Timer1_Tick(sender, e);
                    if(emuladorDomino.JuegoActual == null && emuladorDomino.TorneoActual.Estado != EstadoTorneo.Finalizo)
                        BtonEjecJugada_Click(sender, e);
                    return;
                }
            }
        }

        private void BtonAutom_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void BtonPausar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (iterador.MoveNext())
            {
                string mostrar = iterador.Current;
                if (mostrar != "")
                {
                    tboxResultados.AppendText(mostrar + "\n");
                    tboxResultados.AppendText("\n");
                }
                return;
            }
            timer1.Stop();
            //Dependiendo del emulador se muestran las puntuaciones una vez finalizado el torneo
            IEnumerator<string> iteradorPuntuac;
            if(emuladorTicTacToe != null) iteradorPuntuac = emuladorTicTacToe.TorneoActual.NotificaPuntuaciones();
            else if(emuladorOthello != null) iteradorPuntuac = emuladorOthello.TorneoActual.NotificaPuntuaciones();
            else if(emuladorDomino != null) iteradorPuntuac = emuladorDomino.TorneoActual.NotificaPuntuaciones();
            else iteradorPuntuac = null;
            string muestra = "";
            while (iteradorPuntuac.MoveNext())
                muestra += "\n" + iteradorPuntuac.Current;
            MessageBox.Show(muestra, "Puntuaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}