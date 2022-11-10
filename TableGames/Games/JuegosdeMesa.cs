using System;
using System.Collections.Generic;

namespace Games
{
    public abstract class JuegosdeMesa
    {    
        /// <summary>
        /// Permite al usuario determinar si el Juego será por Equipos (en caso, de que el juego lo permita) o Individual entre los Jugadores.
        /// </summary>
        public abstract bool Equipos { get; set; }
        /// <summary>
        /// Muestra si el Juego establecerá Puntuaciones a los Jugadores.
        /// </summary>
        public abstract bool DaPuntuacion { get; }
        /// <summary>
        /// Muestra cuantos Jugadores por Equipo permite el Juego, en caso de permitir Equipos.
        /// </summary>
        public abstract int CantJugadoresPorEquipos { get; }
        /// <summary>
        /// Muestra la Capacidad Máxima de Jugadores que permite el Juego.
        /// </summary>
        public abstract int CapacidadMaxima { get; }
        /// <summary>
        /// Muestra la Capacidad Mínima de Jugadores que permite el Juego.
        /// </summary>
        public abstract int CapacidadMinima { get; }
        /// <summary>
        /// Crea un árbitro para el Juego de Mesa definido.
        /// </summary>
        /// <param name="participantes">Participantes que juegan dicho Juego de Mesa.</param>
        /// <returns></returns>
        public abstract IArbitro CrearArbitro<T>(List<T> participantes);
    }

    public class TicTacToe : JuegosdeMesa
    {
        #region Piezas del Juego
        public enum CeroCruz
        {
            None,
            O,
            X,
        }
        #endregion

        #region Propiedades
        public override bool Equipos { get => false; set => throw new InvalidOperationException("Este juego no admite equipos"); }
        public override bool DaPuntuacion => true;
        public override int CantJugadoresPorEquipos => throw new InvalidOperationException("Este juego no admite equipos");
        public override int CapacidadMaxima => 2;
        public override int CapacidadMinima => 2;
        #endregion

        #region Métodos Auxiliares
        public override IArbitro CrearArbitro<T>(List<T> participantes)
        {
            if(participantes == null) throw new InvalidOperationException("No hay Jugadores");
            if(participantes is List<IJugador<TicTacToe>> jugadores)
            {
                if(jugadores.Count == 2) return new ArbitroTicTacToe(jugadores);
                throw new InvalidOperationException("La cantidad de Jugadores no es válida");
            }
            throw new TypeLoadException("El tipo de la Lista no es válido");
        }
        #endregion
    }

    public class Othello : JuegosdeMesa
    {
        #region Piezas del Juego
        public enum Color
        {
            None,
            Verde,
            Rojo
        }
        #endregion

        #region Propiedades
        public override bool Equipos { get => false; set => throw new InvalidOperationException("Este juego no admite equipos"); }
        public override bool DaPuntuacion => true;
        public override int CantJugadoresPorEquipos => throw new InvalidOperationException("Este juego no admite equipos");
        public override int CapacidadMaxima => 2;
        public override int CapacidadMinima => 2;
        #endregion

        #region Métodos Auxiliares
        public override IArbitro CrearArbitro<T>(List<T> participantes)
        {
            if(participantes == null) throw new InvalidOperationException("No hay Jugadores");
            if(participantes is List<IJugador<Othello>> jugadores)
            {
                if(jugadores.Count == 2) return new ArbitroOthello(jugadores);
                throw new InvalidOperationException("La cantidad de Jugadores no es válida");
            }
            throw new TypeLoadException("El tipo de la Lista no es válido");
        }
        #endregion
    }

    public class Domino : JuegosdeMesa
    {
        #region Propiedades
        public override bool Equipos { get; set; }
        public override bool DaPuntuacion => true;
        public override int CantJugadoresPorEquipos => 2;
        public override int CapacidadMaxima => 4;
        public override int CapacidadMinima => 2;
        #endregion

        #region Métodos Auxiliares
        public Domino()
        {
            Equipos = true;
        }
        public override IArbitro CrearArbitro<T>(List<T> participantes)
        {
            if(participantes == null) throw new InvalidOperationException("No hay Jugadores o Equipos");
            if(participantes is List<IJugador<Domino>> jugadores)
            {
                if(jugadores.Count > 1 && jugadores.Count < 5) return new ArbitroDomino(jugadores);
                throw new InvalidOperationException("La cantidad de Jugadores no es válida");
            }
            else if(participantes is List<Equipo<Domino>> equipos)
            {
                if(equipos.Count == 2 && equipos[0].Jugadores.Count == 2 && equipos[1].Jugadores.Count == 2)
                    return new ArbitroDomino(equipos);
                throw new InvalidOperationException("La cantidad de Equipos o Jugadores en los Equipos no es válida");
            }
            throw new TypeLoadException("El tipo de la Lista no es válido");
        }
        #endregion
    }
}