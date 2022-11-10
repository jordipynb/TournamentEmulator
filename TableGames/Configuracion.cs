using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Games;

namespace TableGames
{
    public partial class Configuracion : Form
    {
        #region Campos
        private Contenedor FormAux;
        private JuegosdeMesa juego;
        private List<IJugador<TicTacToe>> jugadorTicTacToe;
        private List<IJugador<Othello>> jugadorOthello;
        private List<IJugador<Domino>> jugadorDomino;
        private TipodeTorneo torneo;
        private PictureBox pboxenPanel;
        private bool JuegoActivo;
        private bool JugadoresActivo;
        private bool TorneoActivo;
        #endregion

        public Configuracion()
        {
            InitializeComponent();
            // Iniciacion de las posibles listas de jugadores a crear
            jugadorTicTacToe = new List<IJugador<TicTacToe>>();
            jugadorOthello = new List<IJugador<Othello>>();
            jugadorDomino = new List<IJugador<Domino>>();
            torneo = TipodeTorneo.None;
            juego = null;
        }

        private void AbrirFormEnPanel(Contenedor formhijo)
        {
            FormAux = formhijo;
            pboxenPanel = (PictureBox)panelContenedor.Controls[0];
            panelContenedor.Controls.RemoveAt(0);
            formhijo.TopLevel = false;
            formhijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formhijo);
            panelContenedor.Tag = formhijo;
            formhijo.Show();
        }

        private void BtonJuegos_Click(object sender, EventArgs e)
        {
            if (!JuegoActivo && !btonAnt.Visible)
            {
                AbrirFormEnPanel(new Contenedor(0,juego));
                JuegoActivo = true;
                JugadoresActivo = false;
                TorneoActivo = false;
            }
        }

        private void BtonJugadores_Click(object sender, EventArgs e)
        {
            if (!JugadoresActivo && !btonFin.Visible)
            {
                AbrirFormEnPanel(new Contenedor(1, juego));
                JuegoActivo = false;
                JugadoresActivo = true;
                TorneoActivo = false;
            }
        }

        private void BtonTorneos_Click(object sender, EventArgs e)
        {
            if (!TorneoActivo && btonFin.Visible)
            {
                AbrirFormEnPanel(new Contenedor(2, juego));
                JuegoActivo = false;
                JugadoresActivo = false;
                TorneoActivo = true;
            }
        }

        private void BtonSig_Click(object sender, EventArgs e)
        {
            if (!btonAnt.Visible)
            {
                if (FormAux == null)
                {
                    MessageBox.Show("No puede continuar sin seleccionar el Juego.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // Luego de haber escogido um juego la guardamos en esta variable
                    // Así sabremos crear el torneo y los juadores en funcion de él
                    juego = FormAux.Juego;
                    if (juego == null)
                    {
                        MessageBox.Show("No puede continuar sin seleccionar el Juego.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                btonAnt.Visible = true;
                btonJugadores.Visible = true;
            }
            else
            {
                // Aquí se guardan las listas de jugadores configuradas y se escoge la del juego correspondiente
                jugadorTicTacToe = FormAux.JugadorTicTacToe;
                jugadorOthello = FormAux.JugadorOthello;
                jugadorDomino = FormAux.JugadorDomino;
                // Aquí se comprueba si la cantidad de jugadores agregados corresponde 
                // con la cantidad que necesita el Juego seleccionado
                if((juego is TicTacToe && jugadorTicTacToe.Count < juego.CapacidadMinima) ||
                    (juego is Othello && jugadorOthello.Count < juego.CapacidadMinima) ||
                    (juego is Domino && jugadorDomino.Count < juego.CapacidadMinima))
                {
                    MessageBox.Show("No puede continuar sin la adecuada selección de los Jugadores.\n \nNOTA: mínimo " +
                        juego.CapacidadMinima + " jugadores.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // En el caso de los juegos por Equipos es necesario comprobar si la cantidad de jugadores agregados
                // es compatible con la cantidad de equipos que se pueden formar según la capacidad del Juego
                if(juego.Equipos)
                {
                    if(juego is Domino && jugadorDomino.Count % juego.CantJugadoresPorEquipos != 0)
                    {
                        MessageBox.Show("Usted ha escogido jugar por Equipos.\n \nNOTA: cantidad debe ser divisible por: " + juego.CantJugadoresPorEquipos + ".", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                btonTorneos.Visible = true;
                btonFin.Visible = true;
                btonSig.Visible = false;
            }
            if (FormAux != null)
            {
                FormAux.Close();
                panelContenedor.Controls.Add(pboxenPanel);
            }
        }

        private void BtonAnt_Click(object sender, EventArgs e)
        {
            if (!btonSig.Visible)
            {
                btonFin.Visible = false;
                btonSig.Visible = true;
                btonTorneos.Visible = false;
                JugadoresActivo = false;
                // Dio anterior antes de finalizar, por lo que se arrepintió de los Jugadores
                // en tal caso reiniciarlos
                if(juego is TicTacToe) jugadorTicTacToe = new List<IJugador<TicTacToe>>();
                else if(juego is Othello) jugadorOthello = new List<IJugador<Othello>>();
                else if(juego is Domino) jugadorDomino = new List<IJugador<Domino>>();
            }
            else if (!btonTorneos.Visible)
            {
                btonJugadores.Visible = false;
                btonAnt.Visible = false;
                JuegoActivo = false;
                // Dio anterior luego de iniciar la configuración de Jugadores, por lo que se arrepintió del Juego
                // en tal caso reiniciarlo
                juego = null;
            }
            if (FormAux != null)
            {
                FormAux.Close();
                panelContenedor.Controls.Add(pboxenPanel);
            }
        }

        private void BtonFin_Click(object sender, EventArgs e)
        {
            // Aquí se recoge la información del tipo de torneo que quiere Ejecutar
            torneo = FormAux.Torneo;
            // Según el torneo escogido, se comprueban los requisitos que necesita para pasara su Ejecución
            if (torneo == TipodeTorneo.None)
            {
                MessageBox.Show("No puede continuar sin seleccionar el Tipo de Torneo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (torneo == TipodeTorneo.DosADos || torneo == TipodeTorneo.Titulo)
            {
                if (juego.CapacidadMinima > 2 || juego.CapacidadMaxima < 2 || (torneo == TipodeTorneo.DosADos && !juego.DaPuntuacion))
                {
                    MessageBox.Show("Este Tipo de Torneo no es válido para el Juego seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Dado que en estos tipos de Torneos se puede Jugar por Equipos
                //Comprobar si se puede formar al menos 2 Equipos
                if(juego.Equipos)
                {
                    if(juego is Domino && jugadorDomino.Count == juego.CantJugadoresPorEquipos)
                    {
                        MessageBox.Show("Este Torneo es válido para al menos 2 Equipos.\n \nNOTA: cantidad de Jugadores debe ser mayor o igual a: " + juego.CantJugadoresPorEquipos * 2 + ".", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else if (torneo == TipodeTorneo.CalificacionIndividual)
            {
                if (!juego.DaPuntuacion || juego.CapacidadMinima > 2)
                {
                    MessageBox.Show("Este Tipo de Torneo no es válido para el Juego seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Si escoge un Juego que no se puede jugar por equipos
                // Entonce no puede seleccionar este tipo de torneo
                if (juego.Equipos)
                {
                    MessageBox.Show("Este Torneo no permite Equipos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            // Segun el juego, se crea el torneo seleccionado de tipo de juego, y se le pasa como parametro
            // el juego y los jugadores que le corresponda, así como lo que necesite ese torneo
            //para su correcta ejecución
            if(juego is TicTacToe)
            {
                TicTacToe tictactoe = juego as TicTacToe;
                if(torneo == TipodeTorneo.CalificacionIndividual)
                {
                    _ = new Emulador(new CalificacionIndividual<TicTacToe>(tictactoe, jugadorTicTacToe, new EvaluadorGoloso()))
                    { Visible = true }; Visible = false;
                }
                else if(torneo == TipodeTorneo.DosADos)
                {
                    _ = new Emulador(new DosADos<TicTacToe>(tictactoe, jugadorTicTacToe))
                    { Visible = true }; Visible = false;
                }
                else if(torneo == TipodeTorneo.Titulo)
                {
                    _ = new Emulador(new Titulo<TicTacToe>(tictactoe, jugadorTicTacToe))
                    { Visible = true }; Visible = false;
                }
            }
            else if(juego is Othello)
            {
                Othello othello = juego as Othello;
                if(torneo == TipodeTorneo.CalificacionIndividual)
                {
                    _ = new Emulador(new CalificacionIndividual<Othello>(othello, jugadorOthello, new EvaluadorGoloso()))
                    { Visible = true }; Visible = false;
                }
                else if(torneo == TipodeTorneo.DosADos)
                {
                    _ = new Emulador(new DosADos<Othello>(othello, jugadorOthello))
                    { Visible = true }; Visible = false;
                }
                else if(torneo == TipodeTorneo.Titulo)
                {
                    _ = new Emulador(new Titulo<Othello>(othello, jugadorOthello))
                    { Visible = true }; Visible = false;
                }

            }
            else if(juego is Domino)
            {
                Domino domino = juego as Domino;
                if(torneo == TipodeTorneo.CalificacionIndividual)
                {
                    _ = new Emulador(new CalificacionIndividual<Domino>(domino, jugadorDomino, new EvaluadorGoloso()))
                    { Visible = true }; Visible = false;
                }
                else if(torneo == TipodeTorneo.DosADos)
                {
                    _ = new Emulador(new DosADos<Domino>(domino, jugadorDomino))
                    { Visible = true }; Visible = false;
                }
                else if(torneo == TipodeTorneo.Titulo)
                {
                    _ = new Emulador(new Titulo<Domino>(domino, jugadorDomino))
                    { Visible = true }; Visible = false;
                }

            }
            
        }

        private void Form2_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Usted está en la sección de la configuración del\n" +
                            "Emulador de Torneos para Juegos de Mesa, si\n" +
                            "presenta alguna dificultad en la realización de la\n" +
                            "misma, solo tiene que detenerse en los botones de\n" +
                            "la izquierda y le mostrará la información que necesita.\n" +
                            "Gracias por su atención.\n" +
                            "                                                          Creador: Jordan Plá.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

    // Tipos de torneo implementado en forma de enum
    // para preguntar por el que se desea crear, antes de crearlo con el juego que se quiere Jugar
    #region Tipos de Torneo
    public enum TipodeTorneo
    {
        None,
        CalificacionIndividual,
        Titulo,
        DosADos
    }
    #endregion
}