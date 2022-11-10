using System;
using System.Collections.Generic;

namespace Games
{
    public class EvaluadorAleatorio : IEvaluador<TicTacToe>, IEvaluador<Othello>, IEvaluador<Domino>
    {
        #region Evaluador de TicTacToe
        List<Tuple<Jugada, int>> IEvaluador<TicTacToe>.Evalua(IEstado<TicTacToe> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            if(!(estadoJuego is EstadoTicTacToe estado))
                throw new InvalidOperationException("El estado del Juego no corresponde con el Juego");
            List<Tuple<Jugada, int>> jugadasValidas = new List<Tuple<Jugada, int>>();
            for(int i = 0 ; i < 9 ; i++)
                if(estado.Tablero[i / 3, i % 3] == TicTacToe.CeroCruz.None)
                    jugadasValidas.Add(new Tuple<Jugada, int>(new Posiciones(i / 3, i % 3), 0));
            return jugadasValidas;
        }
        #endregion

        #region Evaluador de Othello
        #region Método Auxiliar
        private bool EsValido(int f, int c) => f > -1 && f < 8 && c > -1 && c < 8;
        #endregion

        List<Tuple<Jugada, int>> IEvaluador<Othello>.Evalua(IEstado<Othello> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            if(!(estadoJuego is EstadoOthello estado))
                throw new InvalidOperationException("El estado del Juego no corresponde con el Juego");
            List<Tuple<Jugada, int>> jugadasValidas = new List<Tuple<Jugada, int>>();
            int[] df = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };
            Othello.Color clrJugador = estado.CurrentJugador == 0 ? Othello.Color.Verde : Othello.Color.Rojo;
            Othello.Color clrContrar = estado.CurrentJugador == 0 ? Othello.Color.Rojo : Othello.Color.Verde;
            for(int i = 0 ; i < 8 ; i++)
                for(int j = 0 ; j < 8 ; j++)
                    if(estado.Tablero[i, j] == Othello.Color.None)
                        for(int k = 0 ; k < df.Length ; k++)
                        {
                            int newF = i + df[k];
                            int newC = j + dc[k];
                            if(EsValido(newF, newC))
                            {
                                while(estado.Tablero[newF, newC] == clrContrar)
                                {
                                    newF += df[k];
                                    newC += dc[k];
                                    if(EsValido(newF, newC))
                                    {
                                        if(estado.Tablero[newF, newC] == clrJugador)
                                        { jugadasValidas.Add(new Tuple<Jugada, int>(new Posiciones(i, j),0)); break; }
                                        else if(estado.Tablero[newF, newC] == Othello.Color.None) break;
                                    }
                                    else break;
                                }
                            }
                        }
            return jugadasValidas;
        }
        #endregion

        #region Evaluador de Domino
        List<Tuple<Jugada, int>> IEvaluador<Domino>.Evalua(IEstado<Domino> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            if(!(estadoJuego is EstadoDomino estado))
                throw new InvalidOperationException("El estado del Juego no corresponde con el Juego");
            List<Tuple<Jugada, int>> jugadasValidas = new List<Tuple<Jugada, int>>();
            if(estado.FichasEnMesa.Count == 0) for(int i = 0 ; i < estado.FichasJugador.Count ; i++)
                    jugadasValidas.Add(new Tuple<Jugada, int>(estado.FichasJugador[i], 0));
            else for(int i = 0 ; i < estado.FichasJugador.Count ; i++)
                    if(estado.FichasJugador[i].Inferior == estado.FichasEnMesa[0] ||
                       estado.FichasJugador[i].Superior == estado.FichasEnMesa[0] ||
                       estado.FichasJugador[i].Inferior == estado.FichasEnMesa[estado.FichasEnMesa.Count - 1] ||
                       estado.FichasJugador[i].Superior == estado.FichasEnMesa[estado.FichasEnMesa.Count - 1])
                        jugadasValidas.Add(new Tuple<Jugada, int>(estado.FichasJugador[i],0));
            return jugadasValidas;
        }
        #endregion
    }

    public class EvaluadorGoloso : IEvaluador<TicTacToe>, IEvaluador<Othello>, IEvaluador<Domino>
    {
        #region Evaluador TicTacToe
        #region Métodos Auxiliares
        /// <summary>
        /// Marca un tablero con números en las casillas dependiendo de la prioridad de la Jugada y respecto al Tablero principal.
        /// </summary>
        /// <param name="tablero">Tablero principal.</param>
        /// <param name="currentJugador">Índice del Jugador.</param>
        /// <returns></returns>
        private int[,] MarcaTablero(TicTacToe.CeroCruz[,] tablero, int currentJugador)
        {
            int[,] tab = new int[3, 3];
            EsquinasVacias(tablero, tab, currentJugador);
            HayDosDelMismo(tablero, tab, currentJugador);
            return tab;
        }

        /// <summary>
        /// Marca un tablero dependiendo si sus esquinas son vacías para realizar diagonales.
        /// </summary>
        /// <param name="tablero">Tablero principal.</param>
        /// <param name="tab">Tablero con valores según la prioridad de la Jugada.</param>
        /// <param name="currentJugador">Índice del Jugador.</param>
        private void EsquinasVacias(TicTacToe.CeroCruz[,] tablero, int[,] tab, int currentJugador)
        {
            if(tablero[0, 0] == TicTacToe.CeroCruz.None) tab[0, 0] = 1;
            if(tablero[0, 2] == TicTacToe.CeroCruz.None) tab[0, 2] = 1;
            if(tablero[2, 0] == TicTacToe.CeroCruz.None) tab[2, 0] = 1;
            if(tablero[2, 2] == TicTacToe.CeroCruz.None) tab[2, 2] = 1;
            TicTacToe.CeroCruz OXJugador = currentJugador == 0 ? TicTacToe.CeroCruz.O : TicTacToe.CeroCruz.X;
            TicTacToe.CeroCruz OXContrar = currentJugador == 0 ? TicTacToe.CeroCruz.X : TicTacToe.CeroCruz.O;
            if(tablero[0, 0] == OXJugador)
            {
                if(tablero[2, 2] == TicTacToe.CeroCruz.None) tab[2, 2] = 2;
                else if(tablero[2, 2] == OXContrar)
                {
                    if(tablero[0, 2] == TicTacToe.CeroCruz.None) tab[0, 2] = 2;
                    if(tablero[2, 0] == TicTacToe.CeroCruz.None) tab[2, 0] = 2;
                }
            }
            if(tablero[0, 2] == OXJugador)
            {
                if(tablero[2, 0] == TicTacToe.CeroCruz.None) tab[2, 0] = 2;
                else if(tablero[2, 0] == OXContrar)
                {
                    if(tablero[0, 0] == TicTacToe.CeroCruz.None) tab[0, 0] = 2;
                    if(tablero[2, 2] == TicTacToe.CeroCruz.None) tab[2, 2] = 2;
                }
            }
            if(tablero[2, 0] == OXJugador)
            {
                if(tablero[0, 2] == TicTacToe.CeroCruz.None) tab[0, 2] = 2;
                else if(tablero[0, 2] == OXContrar)
                {
                    if(tablero[0, 0] == TicTacToe.CeroCruz.None) tab[0, 0] = 2;
                    if(tablero[2, 2] == TicTacToe.CeroCruz.None) tab[2, 2] = 2;
                }
            }
            if(tablero[2, 2] == OXJugador)
            {
                if(tablero[0, 0] == TicTacToe.CeroCruz.None) tab[0, 0] = 2;
                else if(tablero[0, 0] == OXContrar)
                {
                    if(tablero[0, 2] == TicTacToe.CeroCruz.None) tab[0, 2] = 2;
                    if(tablero[2, 0] == TicTacToe.CeroCruz.None) tab[2, 0] = 2;
                }
            }
        }

        /// <summary>
        /// Marca un tablero dependiendo si hay dos piezas del mismo tipo.
        /// </summary>
        /// <param name="tablero">Tablero principal.</param>
        /// <param name="tab">Tablero con valores según la prioridad de la Jugada.</param>
        /// <param name="currentJugador">Índice del Jugador.</param>
        private void HayDosDelMismo(TicTacToe.CeroCruz[,] tablero, int[,] tab, int currentJugador)
        {
            TicTacToe.CeroCruz OXJugador = currentJugador == 0 ? TicTacToe.CeroCruz.O : TicTacToe.CeroCruz.X;
            if(tablero[0, 0] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 1] != TicTacToe.CeroCruz.None && tablero[0, 1] == tablero[0, 2])
                    if(tablero[0, 1] == OXJugador) tab[0, 0] = 4; else if(tab[0, 0] < 3) tab[0, 0] = 3;
                if(tablero[1, 0] != TicTacToe.CeroCruz.None && tablero[1, 0] == tablero[2, 0])
                    if(tablero[1, 0] == OXJugador) tab[0, 0] = 4; else if(tab[0, 0] < 3) tab[0, 0] = 3;
                if(tablero[1, 1] != TicTacToe.CeroCruz.None && tablero[1, 1] == tablero[2, 2])
                    if(tablero[1, 1] == OXJugador) tab[0, 0] = 4; else if(tab[0, 0] < 3) tab[0, 0] = 3;
            }
            if(tablero[0, 1] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 0] != TicTacToe.CeroCruz.None && tablero[0, 0] == tablero[0, 2])
                    if(tablero[0, 0] == OXJugador) tab[0, 1] = 4; else if(tab[0, 1] < 3) tab[0, 1] = 3;
                if(tablero[1, 1] != TicTacToe.CeroCruz.None && tablero[1, 1] == tablero[2, 1])
                    if(tablero[1, 1] == OXJugador) tab[0, 1] = 4; else if(tab[0, 1] < 3) tab[0, 1] = 3;
            }
            if(tablero[0, 2] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 0] != TicTacToe.CeroCruz.None && tablero[0, 0] == tablero[0, 1])
                    if(tablero[0, 0] == OXJugador) tab[0, 2] = 4; else if(tab[0, 2] < 3) tab[0, 2] = 3;
                if(tablero[1, 1] != TicTacToe.CeroCruz.None && tablero[1, 1] == tablero[2, 0])
                    if(tablero[1, 1] == OXJugador) tab[0, 2] = 4; else if(tab[0, 2] < 3) tab[0, 2] = 3;
                if(tablero[1, 2] != TicTacToe.CeroCruz.None && tablero[1, 2] == tablero[2, 2])
                    if(tablero[1, 2] == OXJugador) tab[0, 2] = 4; else if(tab[0, 2] < 3) tab[0, 2] = 3;
            }
            if(tablero[1, 0] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 0] != TicTacToe.CeroCruz.None && tablero[0, 0] == tablero[2, 0])
                    if(tablero[0, 0] == OXJugador) tab[1, 0] = 4; else if(tab[1, 0] < 3) tab[1, 0] = 3;
                if(tablero[1, 1] != TicTacToe.CeroCruz.None && tablero[1, 1] == tablero[1, 2])
                    if(tablero[1, 1] == OXJugador) tab[1, 0] = 4; else if(tab[1, 0] < 3) tab[1, 0] = 3;
            }
            if(tablero[1, 1] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 0] != TicTacToe.CeroCruz.None && tablero[0, 0] == tablero[2, 2])
                    if(tablero[0, 0] == OXJugador) tab[1, 1] = 4; else if(tab[1, 1] < 3) tab[1, 1] = 3;
                if(tablero[0, 1] != TicTacToe.CeroCruz.None && tablero[0, 1] == tablero[2, 1])
                    if(tablero[0, 1] == OXJugador) tab[1, 1] = 4; else if(tab[1, 1] < 3) tab[1, 1] = 3;
                if(tablero[0, 2] != TicTacToe.CeroCruz.None && tablero[0, 2] == tablero[2, 0])
                    if(tablero[0, 2] == OXJugador) tab[1, 1] = 4; else if(tab[1, 1] < 3) tab[1, 1] = 3;
                if(tablero[1, 0] != TicTacToe.CeroCruz.None && tablero[1, 0] == tablero[1, 2])
                    if(tablero[1, 0] == OXJugador) tab[1, 1] = 4; else if(tab[1, 1] < 3) tab[1, 1] = 3;
            }
            if(tablero[1, 2] == TicTacToe.CeroCruz.None)
            {
                if(tablero[1, 0] != TicTacToe.CeroCruz.None && tablero[1, 0] == tablero[1, 1])
                    if(tablero[1, 0] == OXJugador) tab[1, 2] = 4; else if(tab[1, 2] < 3) tab[1, 2] = 3;
                if(tablero[0, 2] != TicTacToe.CeroCruz.None && tablero[0, 2] == tablero[2, 2])
                    if(tablero[0, 2] == OXJugador) tab[1, 2] = 4; else if(tab[1, 2] < 3) tab[1, 2] = 3;
            }
            if(tablero[2, 0] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 0] != TicTacToe.CeroCruz.None && tablero[0, 0] == tablero[1, 0])
                    if(tablero[0, 0] == OXJugador) tab[2, 0] = 4; else if(tab[2, 0] < 3) tab[2, 0] = 3;
                if(tablero[1, 1] != TicTacToe.CeroCruz.None && tablero[1, 1] == tablero[0, 2])
                    if(tablero[1, 1] == OXJugador) tab[2, 0] = 4; else if(tab[2, 0] < 3) tab[2, 0] = 3;
                if(tablero[2, 1] != TicTacToe.CeroCruz.None && tablero[2, 1] == tablero[2, 2])
                    if(tablero[2, 1] == OXJugador) tab[2, 0] = 4; else if(tab[2, 0] < 3) tab[2, 0] = 3;
            }
            if(tablero[2, 1] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 1] != TicTacToe.CeroCruz.None && tablero[0, 1] == tablero[1, 1])
                    if(tablero[0, 1] == OXJugador) tab[2, 1] = 4; else if(tab[2, 1] < 3) tab[2, 1] = 3;
                if(tablero[2, 0] != TicTacToe.CeroCruz.None && tablero[2, 0] == tablero[2, 2])
                    if(tablero[2, 0] == OXJugador) tab[2, 1] = 4; else if(tab[2, 1] < 3) tab[2, 1] = 3;
            }
            if(tablero[2, 2] == TicTacToe.CeroCruz.None)
            {
                if(tablero[0, 0] != TicTacToe.CeroCruz.None && tablero[0, 0] == tablero[1, 1])
                    if(tablero[0, 0] == OXJugador) tab[2, 2] = 4; else if(tab[2, 2] < 3) tab[2, 2] = 3;
                if(tablero[0, 2] != TicTacToe.CeroCruz.None && tablero[0, 2] == tablero[1, 2])
                    if(tablero[0, 2] == OXJugador) tab[2, 2] = 4; else if(tab[2, 2] < 3) tab[2, 2] = 3;
                if(tablero[2, 0] != TicTacToe.CeroCruz.None && tablero[2, 0] == tablero[2, 1])
                    if(tablero[2, 0] == OXJugador) tab[2, 2] = 4; else if(tab[2, 2] < 3) tab[2, 2] = 3;
            }
        }
        #endregion

        List<Tuple<Jugada, int>> IEvaluador<TicTacToe>.Evalua(IEstado<TicTacToe> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            if(!(estadoJuego is EstadoTicTacToe estado))
                throw new InvalidOperationException("El estado del Juego no corresponde con el Juego");
            List<Tuple<Jugada, int>> jugadasValidas = new List<Tuple<Jugada, int>>();
            int[,] tab = MarcaTablero(estado.Tablero, estado.CurrentJugador);
            for(int i = 0 ; i < 9 ; i++)
                if(estado.Tablero[i / 3, i % 3] == TicTacToe.CeroCruz.None)
                    jugadasValidas.Add(new Tuple<Jugada, int>(new Posiciones(i / 3, i % 3), tab[i / 3, i % 3]));
            return jugadasValidas;
        }
        #endregion

        #region Evaluador Othello
        #region Método Auxiliar
        private bool EsValido(int f, int c) => f > -1 && f < 8 && c > -1 && c < 8;
        #endregion

        List<Tuple<Jugada, int>> IEvaluador<Othello>.Evalua(IEstado<Othello> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            if(!(estadoJuego is EstadoOthello estado))
                throw new InvalidOperationException("El estado del Juego no corresponde con el Juego");
            int[] df = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };
            Dictionary<Posiciones, int> jugadasValidasporPeso = new Dictionary<Posiciones, int>();
            Othello.Color clrJugador = estado.CurrentJugador == 0 ? Othello.Color.Verde : Othello.Color.Rojo;
            Othello.Color clrContrar = estado.CurrentJugador == 0 ? Othello.Color.Rojo : Othello.Color.Verde;
            for(int i = 0 ; i < 8 ; i++)
                for(int j = 0 ; j < 8 ; j++)
                    if(estado.Tablero[i, j] == Othello.Color.None)
                        for(int k = 0 ; k < df.Length ; k++)
                        {
                            int newF = i + df[k];
                            int newC = j + dc[k];
                            if(EsValido(newF, newC))
                            {
                                int count = 0;
                                while(estado.Tablero[newF, newC] == clrContrar)
                                {
                                    count++;
                                    newF += df[k];
                                    newC += dc[k];
                                    if(EsValido(newF, newC))
                                    {
                                        if(estado.Tablero[newF, newC] == clrJugador)
                                        {
                                            if(jugadasValidasporPeso.TryGetValue(new Posiciones(i, j), out int valor))
                                                jugadasValidasporPeso[new Posiciones(i, j)] = valor + count;
                                            else jugadasValidasporPeso.Add(new Posiciones(i, j), count);
                                            break;
                                        }
                                        else if(estado.Tablero[newF, newC] == Othello.Color.None) break;
                                    }
                                    else break;
                                }
                            }
                        }
            List<Tuple<Jugada, int>> jugadasValidas = new List<Tuple<Jugada, int>>(jugadasValidasporPeso.Count);
            foreach(var item in jugadasValidasporPeso)
                jugadasValidas.Add(new Tuple<Jugada, int>(item.Key, item.Value));
            return jugadasValidas;
        }
        #endregion

        #region Evaluador Domino
        List<Tuple<Jugada, int>> IEvaluador<Domino>.Evalua(IEstado<Domino> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            if(!(estadoJuego is EstadoDomino estado))
                throw new InvalidOperationException("El estado del Juego no corresponde con el Juego");
            List<Tuple<Jugada, int>> jugadasValidas = new List<Tuple<Jugada, int>>();
            if(estado.FichasEnMesa.Count == 0) for(int i = 0 ; i < estado.FichasJugador.Count ; i++)
                    jugadasValidas.Add(new Tuple<Jugada, int>(estado.FichasJugador[i], 
                                       estado.FichasJugador[i].Inferior + estado.FichasJugador[i].Superior));
            else for(int i = 0 ; i < estado.FichasJugador.Count ; i++)
                    if(estado.FichasJugador[i].Inferior == estado.FichasEnMesa[0] ||
                       estado.FichasJugador[i].Superior == estado.FichasEnMesa[0] ||
                       estado.FichasJugador[i].Inferior == estado.FichasEnMesa[estado.FichasEnMesa.Count - 1] ||
                       estado.FichasJugador[i].Superior == estado.FichasEnMesa[estado.FichasEnMesa.Count - 1])
                        jugadasValidas.Add(new Tuple<Jugada, int>(estado.FichasJugador[i],
                                           estado.FichasJugador[i].Inferior + estado.FichasJugador[i].Superior));
            return jugadasValidas;
        }
        #endregion
    }
}