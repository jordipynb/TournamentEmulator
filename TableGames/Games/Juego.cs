using System;
using System.Collections;
using System.Collections.Generic;

namespace Games
{
    public sealed class Juego : IEnumerable<Jugada>
    {
        #region Campos
        private readonly IArbitro arbitro;
        #endregion

        #region Propiedades
        public EstadoJuego Estado { get; private set; }
        #endregion

        public Juego(IArbitro arbitro)
        {
            this.arbitro = arbitro ?? throw new InvalidOperationException("No hay Árbitro controlando el Juego de Mesa establecido");
            Estado = arbitro.EstadoJuego;
        }

        public string NotificaJuego(bool seMuestra) => arbitro.NotificarJuego(seMuestra);
        public string NotificaJugadas(bool seMuestra) => arbitro.NotificarJugada(seMuestra);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<Jugada> GetEnumerator()
        {
            while(Estado == EstadoJuego.Iniciando || Estado == EstadoJuego.EnProgreso)
            {
                yield return arbitro.RealizarJugada();
                Estado = arbitro.EstadoJuego;
            }
        }
    }

    #region Tipo de Estado para Juego
    public enum EstadoJuego
    {
        Iniciando,
        EnProgreso,
        Empate,
        Finalizo
    }
    #endregion
}