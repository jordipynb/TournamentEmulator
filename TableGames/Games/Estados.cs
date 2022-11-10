using System;
using System.Collections.Generic;

namespace Games
{
    public class EstadoTicTacToe : IEstado<TicTacToe>
    {
        public TicTacToe.CeroCruz[,] Tablero { get; private set; }
        public int CurrentJugador { get; private set; }

        public EstadoTicTacToe(TicTacToe.CeroCruz[,] tablero, int currentJugador)
        {
            Tablero = tablero ?? throw new InvalidOperationException("No hay tablero establecido");
            CurrentJugador = currentJugador;
        }
    }

    public class EstadoOthello : IEstado<Othello>
    {
        public Othello.Color[,] Tablero { get; private set; }
        public int CurrentJugador { get; private set; }

        public EstadoOthello(Othello.Color[,] tablero, int currentJugador)
        {
            Tablero = tablero ?? throw new InvalidOperationException("No hay tablero establecido");
            CurrentJugador = currentJugador;
        }
    }

    public class EstadoDomino : IEstado<Domino>
    {
        public List<int> FichasEnMesa { get; private set; }
        public List<Fichas> FichasJugador { get; private set; }

        public EstadoDomino(List<int> fichasEnMEsa, List<Fichas> fichasJugador)
        {
            FichasEnMesa = fichasEnMEsa ?? throw new InvalidOperationException("No hay fichas en la mesa");
            FichasJugador = fichasJugador ?? throw new InvalidOperationException("El jugador no tiene fichas");
        }
    }
}