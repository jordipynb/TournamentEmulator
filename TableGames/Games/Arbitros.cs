using System;
using System.Collections.Generic;

namespace Games
{
    public class ArbitroTicTacToe : IArbitro
    {
        #region Campos
        private TicTacToe.CeroCruz[,] tablero;
        private readonly int[] cuantasGanadas;
        private string jugadorActual;
        private readonly List<IJugador<TicTacToe>> jugadores;
        private int cantJuegos;
        private int rondasPorJuego;
        private int quienComenzo;
        private int currentJugador;
        private int ptosGanador;
        private Jugada jugadaActual;
        #endregion

        #region Propiedades
        public int IndexGanador { get; private set; }
        public int[] Puntuaciones { get; private set; }
        public EstadoPartida EstadoPartida { get; private set; }
        public EstadoJuego EstadoJuego { get; private set; }
        #endregion

        #region Constructores
        public ArbitroTicTacToe(List<IJugador<TicTacToe>> jugadores)
        {
            this.jugadores = jugadores ?? throw new InvalidOperationException("No hay Jugadores disponibles");
            if(jugadores.Count != 2) throw new InvalidOperationException("La cantidad de Jugadores es inválida");
            Random random = new Random();
            quienComenzo = random.Next(0, 2);
            EstadoPartida = EstadoPartida.Iniciando;
            Puntuaciones = new int[2];
            cuantasGanadas = new int[2];
            cantJuegos = 0;
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Devuelve el Juego a su estado Inicial.
        /// </summary>
        private void ReiniciarJuego()
        {
            tablero = new TicTacToe.CeroCruz[3, 3];
            EstadoJuego = EstadoJuego.Iniciando;
            jugadorActual = null;
            rondasPorJuego = 0;
            currentJugador = quienComenzo;
            ptosGanador = 0;
            IndexGanador = 0;
            jugadaActual = null;
            cantJuegos += 1;
        }

        /// <summary>
        /// Muestra si hay tres piezas alineadas (horizontal, vertical o diagonal) del mismo tipo. 
        /// </summary>
        /// <returns></returns>
        private bool HayTresEnLinea()
        {
            TicTacToe.CeroCruz OX = currentJugador == 0 ? TicTacToe.CeroCruz.O : TicTacToe.CeroCruz.X;
            if(tablero[0, 0] == OX)
            {
                if(tablero[0, 1] == OX && tablero[0, 2] == OX) return true;
                if(tablero[1, 0] == OX && tablero[2, 0] == OX) return true;
                if(tablero[1, 1] == OX && tablero[2, 2] == OX) return true;
            }
            if(tablero[0, 1] == OX && tablero[1, 1] == OX && tablero[2, 1] == OX) return true;
            if(tablero[0, 2] == OX)
            {
                if(tablero[1, 2] == OX && tablero[2, 2] == OX) return true;
                if(tablero[1, 1] == OX && tablero[2, 0] == OX) return true;
            }
            if(tablero[1, 0] == OX && tablero[1, 1] == OX && tablero[1, 2] == OX) return true;
            if(tablero[2, 0] == OX && tablero[2, 1] == OX && tablero[2, 2] == OX) return true;
            return false;
        }

        /// <summary>
        /// Muestra si el Tablero está totalmente ocupado de piezas.
        /// </summary>
        /// <returns></returns>
        private bool EstaLLeno()
        {
            for(int i = 0 ; i < 9 ; i++)
                if(tablero[i / 3, i % 3] == TicTacToe.CeroCruz.None) return false;
            return true;
        }
        #endregion

        #region Partida
        public string NotificarPartida(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(EstadoPartida == EstadoPartida.Iniciando)
                    muestra = $"Comienza la Partida: {jugadores[0].ToString()} v/s {jugadores[1].ToString()}";
                else if(EstadoPartida == EstadoPartida.EnProgreso) muestra = "La Partida está en progreso";
                else if(EstadoPartida == EstadoPartida.Empate) muestra = "La Partida ha terminado en EMPATE!";
                else muestra = "La Partida ha finalizado";
            }
            return muestra;
        }

        public Juego RealizarJuego()
        {
            EstadoPartida = EstadoPartida.EnProgreso;
            ReiniciarJuego();
            return new Juego(this);
        }
        #endregion

        #region Juego
        public string NotificarJuego(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(EstadoJuego == EstadoJuego.Iniciando) muestra = $"Comienza el Juego: {cantJuegos}";
                else if(EstadoJuego == EstadoJuego.EnProgreso) muestra = "El Juego está en progreso";
                else if(EstadoJuego == EstadoJuego.Empate) muestra = "El Juego ha terminado en EMPATE!";
                else muestra = "El Juego ha finalizado. Ha ganado: " + jugadorActual + " con " + ptosGanador + " ptos";
            }
            return muestra;
        }

        public Jugada RealizarJugada()
        {
            EstadoJuego = EstadoJuego.EnProgreso;
            if(quienComenzo == currentJugador) rondasPorJuego += 1;
            TicTacToe.CeroCruz[,] tablero = new TicTacToe.CeroCruz[3, 3];
            Array.Copy(this.tablero, tablero, this.tablero.Length);
            EstadoTicTacToe estado = new EstadoTicTacToe(tablero, currentJugador);
            jugadaActual = jugadores[currentJugador].Estrategia(estado);
            if(jugadaActual == null) throw new InvalidOperationException("El jugador hizo trampa");
            if(this.tablero[((Posiciones)jugadaActual).X, ((Posiciones)jugadaActual).Y] != TicTacToe.CeroCruz.None)
                throw new InvalidOperationException("El jugador hizo trampa");
            this.tablero[((Posiciones)jugadaActual).X, ((Posiciones)jugadaActual).Y] = (TicTacToe.CeroCruz)(currentJugador + 1);
            jugadorActual = jugadores[currentJugador].ToString();
            if(HayTresEnLinea())
            {
                ptosGanador = (6 - rondasPorJuego) * 50;
                Puntuaciones[currentJugador] = Puntuaciones[currentJugador] + ptosGanador;
                cuantasGanadas[currentJugador] += 1;
                quienComenzo = currentJugador;
                EstadoJuego = EstadoJuego.Finalizo;
            }
            else if(EstadoJuego != EstadoJuego.Finalizo && EstaLLeno())
            {
                Puntuaciones[0] += 25;
                Puntuaciones[1] += 25;
                EstadoJuego = EstadoJuego.Empate;
                quienComenzo = (quienComenzo + 1) % 2;
            }
            if(cuantasGanadas[currentJugador] == 2) { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = currentJugador; }
            else if(cantJuegos == 3)
            {
                if(cuantasGanadas[0] == 1 && cuantasGanadas[1] == 0)
                { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = 0; }
                else if(cuantasGanadas[0] == 0 && cuantasGanadas[1] == 1)
                { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = 1; }
                else
                { EstadoPartida = EstadoPartida.Empate; IndexGanador = -1; }
            }
            currentJugador = (currentJugador + 1) % 2;
            return jugadaActual;
        }

        public string NotificarJugada(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(jugadaActual == null) throw new InvalidOperationException("No hay Jugada notificable");
                muestra = jugadorActual + " juega en la " + jugadaActual.ToString();
            }
            jugadaActual = null;
            return muestra;
        }
        #endregion
    }

    public class ArbitroOthello : IArbitro
    {
        #region Campos
        private Othello.Color[,] tablero;
        private string jugadorActual;
        private string jugadorGanador;
        private int pases;
        private readonly List<IJugador<Othello>> jugadores;
        private int cantJuegos;
        private int quienComenzo;
        private int currentJugador;
        private int rondasPorJuego;
        private int ptosGanador;
        private Jugada jugadaActual;
        private readonly int[] df = { -1, -1, 0, 1, 1, 1, 0, -1 };
        private readonly int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };
        #endregion

        #region Propiedades
        public int IndexGanador { get; private set; }
        public int[] Puntuaciones { get; private set; }
        public EstadoPartida EstadoPartida { get; private set; }
        public EstadoJuego EstadoJuego { get; private set; }
        #endregion

        #region Constructores
        public ArbitroOthello(List<IJugador<Othello>> jugadores)
        {
            this.jugadores = jugadores ?? throw new InvalidOperationException("No hay Jugadores disponibles");
            if(jugadores.Count != 2) throw new InvalidOperationException("La cantidad de Jugadores es inválida");
            Random random = new Random();
            quienComenzo = random.Next(0, 2);
            EstadoPartida = EstadoPartida.Iniciando;
            Puntuaciones = new int[2];
            cantJuegos = 0;
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Devuelve el Juego a su estado Inicial.
        /// </summary>
        private void ReiniciarJuego()
        {
            tablero = new Othello.Color[8, 8];
            tablero[3, 3] = tablero[4, 4] = Othello.Color.Verde;
            tablero[3, 4] = tablero[4, 3] = Othello.Color.Rojo;
            EstadoJuego = EstadoJuego.Iniciando;
            jugadorActual = null;
            jugadorGanador = null;
            pases = 0;
            currentJugador = quienComenzo;
            ptosGanador = 0;
            IndexGanador = 0;
            jugadaActual = null;
            rondasPorJuego = 0;
            cantJuegos += 1;
        }

        /// <summary>
        /// Muestra si el Tablero está totalmente ocupado de piezas.
        /// </summary>
        /// <returns></returns>
        private bool EstaLLeno()
        {
            for(int i = 0 ; i < 8 ; i++)
                for(int j = 0 ; j < 8 ; j++)
                    if(tablero[i, j] == Othello.Color.None) return false;
            return true;
        }

        /// <summary>
        /// Cambia los colores de las piezas del tipo contrario que están entre la casilla y sus desplazamientos.
        /// </summary>
        /// <param name="f">Posición fila de la casilla.</param>
        /// <param name="c">Posición columna de la casilla.</param>
        private bool CambiaColores(int f, int c)
        {
            List<Tuple<int, Posiciones>> posiciones = PosicionesDelMismoColor(f, c);
            if(posiciones.Count == 0) return false;
            for(int i = 0 ; i < posiciones.Count ; i++)
            {
                int index = posiciones[i].Item1;
                int newF = f + df[index];
                int newC = c + dc[index];
                while(true)
                {
                    tablero[newF, newC] = (Othello.Color)(currentJugador + 1);
                    newF += df[index];
                    newC += dc[index];
                    if(newF == posiciones[i].Item2.X && newC == posiciones[i].Item2.Y) break;
                }
            }
            return true;
        }

        /// <summary>
        /// Representa una lista de Desplazamiento y Posiciones de piezas del mismo tipo que el de la casilla.
        /// </summary>
        /// <param name="f">Posición fila de la casilla.</param>
        /// <param name="c">Posición columna de la casilla.</param>
        /// <returns></returns>
        private List<Tuple<int, Posiciones>> PosicionesDelMismoColor(int f, int c)
        {
            List<Tuple<int, Posiciones>> posiciones = new List<Tuple<int, Posiciones>>();
            for(int k = 0 ; k < df.Length ; k++)
            {
                int newF = f + df[k];
                int newC = c + dc[k];
                if(EsValido(newF, newC))
                {
                    while(tablero[newF, newC] != Othello.Color.None && tablero[newF, newC] != tablero[f, c])
                    {
                        newF += df[k];
                        newC += dc[k];
                        if(EsValido(newF, newC))
                        {
                            if(tablero[newF, newC] == tablero[f, c])
                            {
                                posiciones.Add(Tuple.Create(k, new Posiciones(newF, newC)));
                                break;
                            }
                        }
                        else break;
                    }
                }
            }
            return posiciones;
        }

        /// <summary>
        /// Muestra si la casilla está en Rango con respecto al tablero. 
        /// </summary>
        /// <param name="f">Posición fila de la casilla.</param>
        /// <param name="c">Posición columna de la casilla.</param>
        /// <returns></returns>
        private bool EsValido(int f, int c) => f > -1 && f < 8 && c > -1 && c < 8;

        /// <summary>
        /// Comprueba si el Jugador hizo trampa.
        /// </summary>
        /// <returns></returns>
        private bool HizoTrampas()
        {
            int[] df = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };
            Othello.Color clrJugador = currentJugador == 0 ? Othello.Color.Verde : Othello.Color.Rojo;
            Othello.Color clrContrar = currentJugador == 0 ? Othello.Color.Rojo : Othello.Color.Verde;
            for(int i = 0 ; i < 8 ; i++)
                for(int j = 0 ; j < 8 ; j++)
                    if(tablero[i, j] == Othello.Color.None)
                        for(int k = 0 ; k < df.Length ; k++)
                        {
                            int newF = i + df[k];
                            int newC = j + dc[k];
                            if(EsValido(newF, newC))
                            {
                                while(tablero[newF, newC] == clrContrar)
                                {
                                    newF += df[k];
                                    newC += dc[k];
                                    if(EsValido(newF, newC))
                                    {
                                        if(tablero[newF, newC] == clrJugador) return true;
                                        else if(tablero[newF, newC] == Othello.Color.None) break;
                                    }
                                    else break;
                                }
                            }
                        }
            return false;
        }
        #endregion

        #region Partida
        public string NotificarPartida(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(EstadoPartida == EstadoPartida.Iniciando)
                    muestra = $"Comienza la Partida: {jugadores[0].ToString()} v/s {jugadores[1].ToString()}";
                else if(EstadoPartida == EstadoPartida.EnProgreso) muestra = "La Partida está en progreso";
                else if(EstadoPartida == EstadoPartida.Empate) muestra = "La Partida ha terminado en EMPATE!";
                else muestra = "La Partida ha finalizado";
            }
            return muestra;
        }

        public Juego RealizarJuego()
        {
            EstadoPartida = EstadoPartida.EnProgreso;
            ReiniciarJuego();
            return new Juego(this);
        }
        #endregion

        #region Juego
        public string NotificarJuego(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(EstadoJuego == EstadoJuego.Iniciando) muestra = $"Comienza el Juego: {cantJuegos}";
                else if(EstadoJuego == EstadoJuego.EnProgreso) muestra = "El Juego está en progreso";
                else if(EstadoJuego == EstadoJuego.Empate) muestra = "El Juego ha terminado en EMPATE!";
                else muestra = "El Juego ha finalizado. Ha ganado: " + jugadorGanador + " con " + ptosGanador + " ptos";
            }
            return muestra;
        }

        public Jugada RealizarJugada()
        {
            EstadoJuego = EstadoJuego.EnProgreso;
            if(quienComenzo == currentJugador) rondasPorJuego += 1;
            Othello.Color[,] tablero = new Othello.Color[8, 8];
            Array.Copy(this.tablero, tablero, this.tablero.Length);
            EstadoOthello estado = new EstadoOthello(tablero, currentJugador);
            jugadaActual = jugadores[currentJugador].Estrategia(estado);
            if(jugadaActual != null)
            {
                if(this.tablero[((Posiciones)jugadaActual).X, ((Posiciones)jugadaActual).Y] != Othello.Color.None)
                    throw new InvalidOperationException("El jugador hizo trampa");
                this.tablero[((Posiciones)jugadaActual).X, ((Posiciones)jugadaActual).Y] = (Othello.Color)(currentJugador + 1);
                if(!CambiaColores(((Posiciones)jugadaActual).X, ((Posiciones)jugadaActual).Y))
                    throw new InvalidOperationException("El jugador hizo trampa");
                pases = 0;
            }
            else
            {
                if(HizoTrampas()) throw new InvalidOperationException("El jugador hizo trampa");
                else pases += 1;
            }
            jugadorActual = jugadores[currentJugador].ToString();
            if(pases == 2 || EstaLLeno())
            {
                int fichasJ1 = 0;
                int fichasJ2 = 0;
                for(int i = 0 ; i < 8 ; i++)
                    for(int j = 0 ; j < 8 ; j++)
                        if(this.tablero[i, j] == Othello.Color.Verde) fichasJ1++;
                        else if(this.tablero[i, j] == Othello.Color.Rojo) fichasJ2++; else continue;
                if(fichasJ1 == fichasJ2)
                {
                    EstadoJuego = EstadoJuego.Empate;
                    quienComenzo = (quienComenzo + 1) % 2;
                    if(cantJuegos == 2)
                    { EstadoPartida = EstadoPartida.Empate; IndexGanador = -1; }
                }
                else
                {
                    if(fichasJ1 > fichasJ2)
                    {
                        ptosGanador = 120 - rondasPorJuego + (32 - fichasJ2);
                        Puntuaciones[0] = ptosGanador;
                        IndexGanador = 0;
                        jugadorGanador = jugadores[0].ToString();
                    }
                    else
                    {
                        ptosGanador = 120 - rondasPorJuego + (32 - fichasJ1);
                        Puntuaciones[1] = ptosGanador;
                        IndexGanador = 1;
                        jugadorGanador = jugadores[1].ToString();
                    }
                    EstadoJuego = EstadoJuego.Finalizo;
                    EstadoPartida = EstadoPartida.Finalizo;
                }
            }
            currentJugador = (currentJugador + 1) % 2;
            return jugadaActual;
        }

        public string NotificarJugada(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(jugadaActual == null && pases == 0) throw new InvalidOperationException("No hay Jugada notificable");
                else if(pases > 0) muestra = jugadorActual + " PASA turno!";
                else muestra = jugadorActual + " juega en la " + jugadaActual.ToString();
            }
            jugadaActual = null;
            return muestra;
        }
        #endregion
    }

    public class ArbitroDomino : IArbitro
    {
        #region Piezas del Juego
        private List<int> fichasEnMesa;
        #endregion

        #region Campos
        private readonly List<Fichas> fichasTotales;
        private List<Fichas>[] fichasJugadores;
        private readonly List<IJugador<Domino>> jugadores;
        private readonly List<Equipo<Domino>> equipos;
        private int pases;
        private string jugadorActual;
        private string jugadorGanador;
        private string equipoGanador;
        private int cantJuegos;
        private int quienComenzo;
        private int currentJugador;
        private int ptosGanador;
        private Jugada jugadaActual;
        #endregion

        #region Propiedades
        public int IndexGanador { get; private set; }
        public int[] Puntuaciones { get; private set; }
        public EstadoPartida EstadoPartida { get; private set; }
        public EstadoJuego EstadoJuego { get; private set; }
        #endregion
       
        #region Constructores
        public ArbitroDomino(List<IJugador<Domino>> jugadores)
        {
            this.jugadores = jugadores ?? throw new InvalidOperationException("No hay Jugadores disponibles");
            if(jugadores.Count < 2 || jugadores.Count > 4) throw new InvalidOperationException("La cantidad de Jugadores es inválida");
            Random random = new Random();
            quienComenzo = random.Next(0, jugadores.Count);
            fichasTotales = new List<Fichas>(55);
            for(int i = 0 ; i < 10 ; i++)
                for(int j = i ; j < 10 ; j++)
                    fichasTotales.Add(new Fichas(i, j));
            EstadoPartida = EstadoPartida.Iniciando;
            Puntuaciones = new int[jugadores.Count];
            equipos = null;
            cantJuegos = 0;
        }

        public ArbitroDomino(List<Equipo<Domino>> equipos)
        {
            this.equipos = equipos ?? throw new InvalidOperationException("No hay Equipos disponibles");
            if(equipos.Count != 2 || equipos[0].Jugadores.Count != 2 || equipos[1].Jugadores.Count != 2)
                throw new InvalidOperationException("La cantidad de Equipos o Jugadores en los Equipos es inválida");
            Random random = new Random();
            quienComenzo = random.Next(0, 4);
            fichasTotales = new List<Fichas>(55);
            for(int i = 0 ; i < 10 ; i++)
                for(int j = i ; j < 10 ; j++)
                    fichasTotales.Add(new Fichas(i, j));
            EstadoPartida = EstadoPartida.Iniciando;
            Puntuaciones = new int[equipos.Count];
            jugadores = new List<IJugador<Domino>>(4)
                            { equipos[0].Jugadores[0], equipos[1].Jugadores[0], equipos[0].Jugadores[1], equipos[1].Jugadores[1] };
            cantJuegos = 0;
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Devuelve el Juego a su estado Inicial.
        /// </summary>
        private void ReiniciarJuego()
        {
            pases = 0;
            fichasEnMesa = new List<int>();
            fichasJugadores = new List<Fichas>[jugadores.Count];
            RepartirFichas();
            EstadoJuego = EstadoJuego.Iniciando;
            jugadorActual = null;
            jugadorGanador = null;
            equipoGanador = null;
            ptosGanador = 0;
            jugadaActual = null;
            currentJugador = quienComenzo;
            IndexGanador = 0;
            cantJuegos += 1;
        }

        /// <summary>
        /// Reparte las Fichas a los Jugadores en Juego.
        /// </summary>
        private void RepartirFichas()
        {
            bool[] enUso = new bool[55];
            Random random = new Random();
            for(int pos = 0 ; pos < jugadores.Count ; pos++)
            {
                fichasJugadores[pos] = new List<Fichas>(10);
                List<int> indexValidos = Busca(enUso);
                while(true)
                {
                    int index = random.Next(0, indexValidos.Count);
                    if(enUso[indexValidos[index]]) continue;
                    else
                    {
                        enUso[indexValidos[index]] = true;
                        fichasJugadores[pos].Add(fichasTotales[indexValidos[index]]);
                        if(fichasJugadores[pos].Count == 10) break;
                    }
                    if(pos == 3) indexValidos = Busca(enUso);
                }
            }
        }

        /// <summary>
        /// Busca que Fichas están disponibles para otorgarlas.
        /// </summary>
        /// <param name="enUso">Fichas que están en Juego.</param>
        /// <returns></returns>
        private List<int> Busca(bool[] enUso)
        {
            List<int> valores = new List<int>();
            for(int i = 0 ; i < enUso.Length ; i++)
                if(!enUso[i]) valores.Add(i);
            return valores;
        }

        /// <summary>
        /// Comprueba si el Jugador Actual hizo trampas.
        /// </summary>
        /// <returns></returns>
        private bool HizoTrampas()
        {
            if(fichasEnMesa.Count == 0) { if(fichasJugadores[currentJugador].Count > 0) return true; }
            else for(int i = 0 ; i < fichasJugadores[currentJugador].Count ; i++)
                    if(fichasJugadores[currentJugador][i].Inferior == fichasEnMesa[0] ||
                       fichasJugadores[currentJugador][i].Superior == fichasEnMesa[0] ||
                       fichasJugadores[currentJugador][i].Inferior == fichasEnMesa[fichasEnMesa.Count - 1] ||
                       fichasJugadores[currentJugador][i].Superior == fichasEnMesa[fichasEnMesa.Count - 1]) return true;
            return false;
        }
        #endregion

        #region Partida
        public string NotificarPartida(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(EstadoPartida == EstadoPartida.Iniciando && jugadores.Count == 2)
                    muestra = $"Comienza la Partida: {jugadores[0].ToString()} v/s {jugadores[1].ToString()}";
                else if(EstadoPartida == EstadoPartida.Iniciando && jugadores.Count == 3)
                    muestra = $"Comienza la Partida: {jugadores[0].ToString()},{jugadores[1].ToString()},{jugadores[2].ToString()}";
                else if(EstadoPartida == EstadoPartida.Iniciando && equipos != null)
                    muestra = $"Comienza la Partida: {equipos[0].ToString()} v/s {equipos[1].ToString()}";
                else if(EstadoPartida == EstadoPartida.Iniciando && jugadores.Count == 4)
                    muestra = $"Comienza la Partida: {jugadores[0].ToString()},{jugadores[1].ToString()}," +
                                                   $"{jugadores[2].ToString()},{jugadores[3].ToString()}";
                else if(EstadoPartida == EstadoPartida.EnProgreso) muestra = "La Partida está en progreso";
                else muestra = "La Partida ha finalizado";
            }
            return muestra;
        }

        public Juego RealizarJuego()
        {
            EstadoPartida = EstadoPartida.EnProgreso;
            ReiniciarJuego();
            return new Juego(this);
        }
        #endregion

        #region Juego
        public string NotificarJuego(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(EstadoJuego == EstadoJuego.Iniciando) muestra = $"Comienza el Juego: {cantJuegos}";
                else if(EstadoJuego == EstadoJuego.EnProgreso) muestra = "El Juego está en progreso";
                else if(EstadoJuego == EstadoJuego.Empate) muestra = "El Juego ha terminado en EMPATE!";
                else if(EstadoJuego == EstadoJuego.Finalizo && equipos != null)
                    muestra = "El Juego ha finalizado. Ha ganado: " + equipoGanador + " con " + ptosGanador + " ptos";
                else muestra = "El Juego ha finalizado. Ha ganado: " + jugadorGanador + " con " + ptosGanador + " ptos";
            }
            return muestra;
        }

        public Jugada RealizarJugada()
        {
            EstadoJuego = EstadoJuego.EnProgreso;
            jugadorActual = jugadores[currentJugador].ToString();
            List<Fichas> fichas = new List<Fichas>();
            for(int i = 0 ; i < fichasJugadores[currentJugador].Count ; i++)
                fichas.Add(fichasJugadores[currentJugador][i]);
            List<int> fichasenmesa = new List<int>();
            for(int i = 0 ; i < fichasEnMesa.Count ; i++)
                fichasenmesa.Add(fichasEnMesa[i]);
            EstadoDomino estado = new EstadoDomino(fichasenmesa, fichas);
            jugadaActual = jugadores[currentJugador].Estrategia(estado);
            if(jugadaActual != null)
            {
                if(!fichasJugadores[currentJugador].Remove((Fichas)jugadaActual))
                    throw new InvalidOperationException("El jugador hizo trampa");
                if(fichasEnMesa.Count == 0)
                {
                    if(((Fichas)jugadaActual).Inferior == ((Fichas)jugadaActual).Superior) fichasEnMesa.Add(((Fichas)jugadaActual).Inferior);
                    else { fichasEnMesa.Add(((Fichas)jugadaActual).Inferior); fichasEnMesa.Add(((Fichas)jugadaActual).Superior); }
                }
                else
                {
                    if(((Fichas)jugadaActual).Inferior == fichasEnMesa[0]) fichasEnMesa.Insert(0, ((Fichas)jugadaActual).Superior);
                    else if(((Fichas)jugadaActual).Superior == fichasEnMesa[0]) fichasEnMesa.Insert(0, ((Fichas)jugadaActual).Inferior);
                    else if(((Fichas)jugadaActual).Inferior == fichasEnMesa[fichasEnMesa.Count - 1])
                        fichasEnMesa.Add(((Fichas)jugadaActual).Superior);
                    else if(((Fichas)jugadaActual).Superior == fichasEnMesa[fichasEnMesa.Count - 1])
                        fichasEnMesa.Add(((Fichas)jugadaActual).Inferior);
                    else throw new InvalidOperationException("El jugador hizo trampa");
                }
                pases = 0;
                if(fichasJugadores[currentJugador].Count == 0)
                {
                    if(equipos != null)
                    {
                        equipoGanador = equipos[currentJugador % 2].ToString();
                        List<Fichas> fichasJ = fichasJugadores[(currentJugador + 1) % 4];
                        for(int i = 0 ; i < fichasJ.Count ; i++)
                            ptosGanador += fichasJ[i].Inferior + fichasJ[i].Superior;
                        fichasJ = fichasJugadores[(currentJugador + 3) % 4];
                        for(int i = 0 ; i < fichasJ.Count ; i++)
                            ptosGanador += fichasJ[i].Inferior + fichasJ[i].Superior;
                        Puntuaciones[currentJugador % 2] += ptosGanador;
                    }
                    else
                    {
                        jugadorGanador = jugadorActual;
                        for(int pos = 0 ; pos < jugadores.Count - 1 ; pos++)
                        {
                            List<Fichas> fichasJ = fichasJugadores[(currentJugador + 1 + pos) % jugadores.Count];
                            for(int i = 0 ; i < fichasJ.Count ; i++)
                                ptosGanador += fichasJ[i].Inferior + fichasJ[i].Superior;
                        }
                        Puntuaciones[currentJugador] += ptosGanador;
                    }
                    EstadoJuego = EstadoJuego.Finalizo;
                    quienComenzo = currentJugador;
                }
            }
            else
            {
                if(HizoTrampas()) throw new InvalidOperationException("El jugador hizo trampa");
                else
                {
                    pases += 1;
                    if(pases == jugadores.Count)
                    {
                        if(equipos != null)
                        {
                            int primerE = 0;
                            for(int i = 0 ; i < fichasJugadores[0].Count ; i++)
                                primerE += fichasJugadores[0][i].Inferior + fichasJugadores[0][i].Superior;
                            for(int i = 0 ; i < fichasJugadores[2].Count ; i++)
                                primerE += fichasJugadores[2][i].Inferior + fichasJugadores[2][i].Superior;
                            int segundoE = 0;
                            for(int i = 0 ; i < fichasJugadores[1].Count ; i++)
                                segundoE += fichasJugadores[1][i].Inferior + fichasJugadores[1][i].Superior;
                            for(int i = 0 ; i < fichasJugadores[3].Count ; i++)
                                segundoE += fichasJugadores[3][i].Inferior + fichasJugadores[3][i].Superior;
                            if(primerE == segundoE)
                            {
                                EstadoJuego = EstadoJuego.Empate;
                                if(quienComenzo == 0 || quienComenzo == 2) quienComenzo = 1;
                                else quienComenzo = 0;
                            }
                            else
                            {
                                if(primerE < segundoE)
                                {
                                    equipoGanador = equipos[0].ToString();
                                    ptosGanador = segundoE;
                                    Puntuaciones[0] += ptosGanador;
                                    if(quienComenzo == 0) quienComenzo = 2;
                                    else quienComenzo = 0;
                                }
                                else
                                {
                                    equipoGanador = equipos[1].ToString();
                                    ptosGanador = primerE;
                                    Puntuaciones[1] += ptosGanador;
                                    if(quienComenzo == 1) quienComenzo = 3;
                                    else quienComenzo = 1;
                                }
                                EstadoJuego = EstadoJuego.Finalizo;
                            }
                        }
                        else
                        {
                            int primerJ = 0, segundoJ = 0, tercerJ = 0, cuartoJ = 0;

                            for(int i = 0 ; i < fichasJugadores[0].Count ; i++)
                                primerJ += fichasJugadores[0][i].Inferior + fichasJugadores[0][i].Superior;
                            for(int i = 0 ; i < fichasJugadores[1].Count ; i++)
                                segundoJ += fichasJugadores[1][i].Inferior + fichasJugadores[1][i].Superior;
                            if(jugadores.Count > 2)
                                for(int i = 0 ; i < fichasJugadores[2].Count ; i++)
                                    tercerJ += fichasJugadores[2][i].Inferior + fichasJugadores[2][i].Superior;
                            if(jugadores.Count > 3)
                                for(int i = 0 ; i < fichasJugadores[3].Count ; i++)
                                    cuartoJ += fichasJugadores[3][i].Inferior + fichasJugadores[3][i].Superior;
                            if(jugadores.Count == 2)
                            {
                                if(primerJ == segundoJ)
                                {
                                    EstadoJuego = EstadoJuego.Empate;
                                    if(quienComenzo == 0) quienComenzo = 1;
                                    else quienComenzo = 0;
                                }
                                else
                                {
                                    if(primerJ < segundoJ)
                                    {
                                        jugadorGanador = jugadores[0].ToString();
                                        ptosGanador = segundoJ;
                                        Puntuaciones[0] += ptosGanador;
                                        quienComenzo = 0;
                                    }
                                    else
                                    {
                                        jugadorGanador = jugadores[1].ToString();
                                        ptosGanador = primerJ;
                                        Puntuaciones[1] += ptosGanador;
                                        quienComenzo = 1;
                                    }
                                    EstadoJuego = EstadoJuego.Finalizo;
                                }
                            }
                            else if(jugadores.Count == 3)
                            {
                                EstadoJuego = EstadoJuego.Finalizo;
                                if(primerJ < segundoJ && primerJ < tercerJ)
                                {
                                    jugadorGanador = jugadores[0].ToString();
                                    ptosGanador = segundoJ + tercerJ;
                                    Puntuaciones[0] += ptosGanador;
                                    quienComenzo = 0;
                                }
                                else if(segundoJ < primerJ && segundoJ < tercerJ)
                                {
                                    jugadorGanador = jugadores[1].ToString();
                                    ptosGanador = primerJ + tercerJ;
                                    Puntuaciones[1] += ptosGanador;
                                    quienComenzo = 1;
                                }
                                else if(tercerJ < primerJ && tercerJ < segundoJ)
                                {
                                    jugadorGanador = jugadores[2].ToString();
                                    ptosGanador = primerJ + segundoJ;
                                    Puntuaciones[2] += ptosGanador;
                                    quienComenzo = 2;
                                }
                                else
                                {
                                    EstadoJuego = EstadoJuego.Empate;
                                    quienComenzo = (quienComenzo + 1) % 3;
                                }
                            }
                            else if(jugadores.Count == 4)
                            {
                                EstadoJuego = EstadoJuego.Finalizo;
                                if(primerJ < segundoJ && primerJ < tercerJ && primerJ < cuartoJ)
                                {
                                    jugadorGanador = jugadores[0].ToString();
                                    ptosGanador = segundoJ + tercerJ + cuartoJ;
                                    Puntuaciones[0] += ptosGanador;
                                    quienComenzo = 0;
                                }
                                else if(segundoJ < primerJ && segundoJ < tercerJ && segundoJ < cuartoJ)
                                {
                                    jugadorGanador = jugadores[1].ToString();
                                    ptosGanador = primerJ + tercerJ + cuartoJ;
                                    Puntuaciones[1] += ptosGanador;
                                    quienComenzo = 1;
                                }
                                else if(tercerJ < primerJ && tercerJ < segundoJ && tercerJ < cuartoJ)
                                {
                                    jugadorGanador = jugadores[2].ToString();
                                    ptosGanador = primerJ + segundoJ + cuartoJ;
                                    Puntuaciones[2] += ptosGanador;
                                    quienComenzo = 2;
                                }
                                else if(cuartoJ < primerJ && cuartoJ < segundoJ && cuartoJ < tercerJ)
                                {
                                    jugadorGanador = jugadores[3].ToString();
                                    ptosGanador = primerJ + segundoJ + tercerJ;
                                    Puntuaciones[3] += ptosGanador;
                                    quienComenzo = 3;
                                }
                                else
                                {
                                    EstadoJuego = EstadoJuego.Empate;
                                    quienComenzo = (quienComenzo + 1) % 4;
                                }
                            }
                        }
                    }
                }
            }
            if(Puntuaciones[0] >= 100) { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = 0; }
            else if(Puntuaciones[1] >= 100) { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = 1; }
            else if(equipos == null && jugadores.Count > 2 && Puntuaciones[2] >= 100)
            { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = 2; }
            else if(equipos == null && jugadores.Count > 3 && Puntuaciones[3] >= 100)
            { EstadoPartida = EstadoPartida.Finalizo; IndexGanador = 3; }
            currentJugador = (currentJugador + 1) % jugadores.Count;
            return jugadaActual;
        }

        public string NotificarJugada(bool seMuestra)
        {
            string muestra = "";
            if(seMuestra)
            {
                if(jugadaActual == null && pases == 0) throw new InvalidOperationException("No hay Jugada notificable");
                else if(pases > 0) muestra = jugadorActual + " PASA turno!";
                else muestra = jugadorActual + " juega la " + jugadaActual.ToString();
            }
            jugadaActual = null;
            return muestra;
        }
        #endregion
    }
}