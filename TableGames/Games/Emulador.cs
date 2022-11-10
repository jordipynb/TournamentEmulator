using System;
using System.Collections.Generic;

namespace Games
{
    public sealed class Emulador<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private IEnumerator<Partida<JM>> iteradorPartidas;
        private IEnumerator<Juego> iteradorJuegos;
        private IEnumerator<Jugada> iteradorJugadas;
        #endregion

        #region Propiedades
        public bool NotificacionPartidas { get; set; }
        public bool NotificacionJuegos { get; set; }
        public bool NotificacionJugadas { get; set; }
        public Torneo<JM> TorneoActual { get; }
        public Partida<JM> PartidaActual { get; private set; }
        public Juego JuegoActual { get; private set; }
        public Jugada JugadaActual { get; private set; }
        #endregion

        public Emulador(Torneo<JM> torneoParaEmular)
        {
            TorneoActual = torneoParaEmular ?? 
                throw new InvalidOperationException("No se puede realizar un Emulador sin Torneo para emular.");
            iteradorPartidas = null;
            PartidaActual = null;
            iteradorJuegos = null;
            JuegoActual = null;
            iteradorJugadas = null;
            JugadaActual = null;
            NotificacionPartidas = true;
            NotificacionJuegos = true;
            NotificacionJugadas = true;
        }

        /// <summary>
        /// Muestra la Ejecución y Notificación de cada momento del Torneo.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> PasoAPaso()
        {
            if(TorneoActual.Estado == EstadoTorneo.Finalizo) throw new InvalidOperationException("El Torneo ha finalizado");
            yield return TorneoActual.NotificaTorneo();
            iteradorPartidas = TorneoActual.GetEnumerator();
            while(iteradorPartidas.MoveNext())
            {
                PartidaActual = iteradorPartidas.Current;
                string muestra = PartidaActual.NotificaPartida(NotificacionPartidas);
                yield return muestra;
                iteradorJuegos = PartidaActual.GetEnumerator();
                while(iteradorJuegos.MoveNext())
                {
                    JuegoActual = iteradorJuegos.Current;
                    muestra = JuegoActual.NotificaJuego(NotificacionJuegos);
                    yield return muestra;
                    iteradorJugadas = JuegoActual.GetEnumerator();
                    while(iteradorJugadas.MoveNext())
                    {
                        JugadaActual = iteradorJugadas.Current;
                        muestra = JuegoActual.NotificaJugadas(NotificacionJugadas);
                        JugadaActual = null;
                        yield return muestra;
                    }
                    iteradorJugadas = null;
                    muestra = JuegoActual.NotificaJuego(NotificacionJuegos);
                    JuegoActual = null;
                    yield return muestra;
                }
                iteradorJuegos = null;
                muestra = PartidaActual.NotificaPartida(NotificacionPartidas);
                PartidaActual = null;
                yield return muestra;
            }
            iteradorPartidas = null;
            yield return TorneoActual.NotificaTorneo();
        }
    }
}