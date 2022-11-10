using System;
using System.Collections.Generic;

namespace Games
{
    public interface IArbitro
    {
        /// <summary>
        /// Indica el Índice del Jugador o Equipo ganador en la Partida respecto a los Jugadores o Equipos que hayan en el mismo y 
        /// su posición.
        /// </summary>
        int IndexGanador { get; }

        /// <summary>
        /// Guarda las Puntuaciones de cada Jugador o Equipo en el transcurso del Juego respecto a sus posiciones.
        /// </summary>
        int[] Puntuaciones { get; }

        /// <summary>
        /// Indica el Estado de la Partida.
        /// </summary>
        EstadoPartida EstadoPartida { get; }

        /// <summary>
        /// Representa la Notificación de la Partida.
        /// </summary>
        /// <param name="seMuestra">Representa si se quiere o no mostrar la Notificación.</param>
        /// <returns></returns>
        string NotificarPartida(bool seMuestra);

        /// <summary>
        /// Indica el Estado del Juego.
        /// </summary>
        EstadoJuego EstadoJuego { get; }

        /// <summary>
        /// Realiza un único Juego en la Partida realizada.
        /// </summary>
        /// <returns></returns>
        Juego RealizarJuego();

        /// <summary>
        /// Representa la Notificación del Juego.
        /// </summary>
        /// <param name="seMuestra">Representa si se quiere o no mostrar la Notificación.</param>
        /// <returns></returns>
        string NotificarJuego(bool seMuestra);

        /// <summary>
        /// Realiza una única Jugada en el Juego realizado.
        /// </summary>
        /// <returns></returns>
        Jugada RealizarJugada();

        /// <summary>
        /// Representa la Notificación de la Jugada realizada.
        /// </summary>
        /// <param name="seMuestra">Representa si se quiere o no mostrar la Notificación.</param>
        /// <returns></returns>
        string NotificarJugada(bool seMuestra);
    }

    public interface IEvaluador<JM> where JM : JuegosdeMesa
    { 
        /// <summary>
        /// Evalúa el Juego respecto al Jugador.
        /// </summary>
        /// <param name="estadoJuego">Estado del Juego.</param>
        /// <returns></returns>
        List<Tuple<Jugada, int>> Evalua(IEstado<JM> estadoJuego);
    }

    public interface IEstado<JM> where JM : JuegosdeMesa { }

    public interface IJugador<JM> where JM : JuegosdeMesa
    {
        /// <summary>
        /// Representa la Estrategia que tendrá el Jugador.
        /// </summary>
        /// <param name="estadoJuego">Estado del Juego.</param>
        /// <returns></returns>
        Jugada Estrategia(IEstado<JM> estadoJuego);
    }
}