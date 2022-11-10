using System;
using System.Collections;
using System.Collections.Generic;

namespace Games
{
    public sealed class Partida<JM> : IEnumerable<Juego> where JM : JuegosdeMesa
    {
        #region Campos
        private readonly IArbitro arbitro;
        private int[] puntuaciones;
        #endregion

        #region Propiedades
        public int IndexGanador { get; private set; }
        public int[] Puntuaciones { get { if(Estado == EstadoPartida.Finalizo || Estado == EstadoPartida.Empate) return puntuaciones;
                                          throw new InvalidOperationException("La Partida no ha finalizado"); } }
        public EstadoPartida Estado { get; private set; }
        #endregion

        public Partida(JM juego, List<Equipo<JM>> equipos)
        {
            if(juego == null) throw new InvalidOperationException("No hay Juego de Mesa establecido");
            if(equipos == null || equipos.Count == 0) throw new InvalidOperationException("No hay Equipos disponibles para Jugar");
            arbitro = juego.CrearArbitro(equipos);
            if(arbitro == null) throw new InvalidOperationException("No hay árbitro establecido");
            puntuaciones = new int[equipos.Count];
            Estado = arbitro.EstadoPartida;
        }
        public Partida(JM juego, List<IJugador<JM>> jugadores)
        {
            if(juego == null) throw new InvalidOperationException("No hay Juego de Mesa establecido");
            if(jugadores == null || jugadores.Count == 0) throw new InvalidOperationException("No hay Jugadores disponibles para Jugar");
            arbitro = juego.CrearArbitro(jugadores);
            if(arbitro == null) throw new InvalidOperationException("No hay árbitro establecido");
            puntuaciones = new int[jugadores.Count];
            Estado = arbitro.EstadoPartida;
        }

        public string NotificaPartida(bool seMuestra) => arbitro.NotificarPartida(seMuestra);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<Juego> GetEnumerator()
        {
            while(Estado == EstadoPartida.Iniciando || Estado == EstadoPartida.EnProgreso)
            {
                Juego juegoActual = arbitro.RealizarJuego();
                yield return juegoActual;
                if(juegoActual.Estado != EstadoJuego.Finalizo && juegoActual.Estado != EstadoJuego.Empate)
                    throw new InvalidOperationException("El Juego no ha finalizado.");
                Estado = arbitro.EstadoPartida;
            }
            puntuaciones = arbitro.Puntuaciones;
            IndexGanador = arbitro.IndexGanador;
        }
    }

    #region Tipo de Estado para Partida
    public enum EstadoPartida
    {
        Iniciando,
        EnProgreso,
        Empate,
        Finalizo,
    }
    #endregion
}