using System;
using System.Collections.Generic;

namespace Games
{
    public sealed class Equipo<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private readonly int identificador;
        #endregion

        #region Propiedades
        public List<IJugador<JM>> Jugadores { get; private set; }
        #endregion

        public Equipo(List<IJugador<JM>> jugadores, int identificador)
        {
            if(jugadores == null || jugadores.Count == 0) throw new InvalidOperationException("El Equipo no tiene Jugadores");
            Jugadores = jugadores;
            this.identificador = identificador;
        }

        public override bool Equals(object obj)
        {
            if(obj != null && obj is Equipo<JM>)
                return GetHashCode() == ((Equipo<JM>)obj).GetHashCode();
            return false;
        }
        public override int GetHashCode() => identificador;
        public override string ToString() => $"Equipo: {identificador}";
        /// <summary>
        /// Forma los Equipos con los Jugadores dependiendo de que cantidad habrá por cada cual.
        /// </summary>
        /// <param name="jugadores">Lista de Jugadores en Competencia.</param>
        /// <param name="cantJugadorporEquipo">Cantidad de Jugadores que habrá por Equipos.</param>
        /// <returns></returns>
        public static List<Equipo<JM>> FormaEquipos(List<IJugador<JM>> jugadores, int cantJugadorporEquipo)
        {
            if(jugadores == null || cantJugadorporEquipo == 0) throw new InvalidOperationException("No es posible formar los Equipos");
            if(jugadores.Count < cantJugadorporEquipo || jugadores.Count % cantJugadorporEquipo != 0)
                throw new InvalidOperationException("No es posible formar los Equipos");
            List<Equipo<JM>> equipos = new List<Equipo<JM>>(jugadores.Count / cantJugadorporEquipo);
            for(int i = 0, count = 1 ; i < jugadores.Count ; count++)
            {
                List<IJugador<JM>> jugadoresPorEquipo = new List<IJugador<JM>>(cantJugadorporEquipo);
                while(jugadoresPorEquipo.Count < cantJugadorporEquipo)
                    jugadoresPorEquipo.Add(jugadores[i++]);
                equipos.Add(new Equipo<JM>(jugadoresPorEquipo, count));
            }
            return equipos;
        }
    }

    public class JugadorAleatorio<JM> : IJugador<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private readonly IEvaluador<JM> evaluador;
        private readonly int identificador;
        private readonly string nombre;
        private readonly Random random;
        #endregion

        public JugadorAleatorio(string nombre, int identificador, IEvaluador<JM> evaluador)
        {
            this.nombre = nombre ?? throw new InvalidOperationException("El Jugador no tiene nombre");
            this.identificador = identificador;
            this.evaluador = evaluador ?? throw new InvalidOperationException("El Jugador no tiene evaluador"); ;
            random = new Random();
        }

        public Jugada Estrategia(IEstado<JM> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            List<Tuple<Jugada,int>> jugadasValidas = evaluador.Evalua(estadoJuego);
            if(jugadasValidas.Count > 0)
            {
                int index = random.Next(0, jugadasValidas.Count);
                return jugadasValidas[index].Item1;
            }
            return null;
        }
        public override bool Equals(object obj)
        {
            if(obj != null && obj is JugadorAleatorio<JM>)
                return GetHashCode() == ((JugadorAleatorio<JM>)obj).GetHashCode() && nombre == ((JugadorAleatorio<JM>)obj).nombre;
            return false;
        }
        public override int GetHashCode() => identificador;
        public override string ToString() => nombre;

    }
    public class JugadorGoloso<JM> : IJugador<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private readonly IEvaluador<JM> evaluador;
        private readonly int identificador;
        private readonly string nombre;
        private readonly Random random;
        #endregion

        public JugadorGoloso(string nombre, int identificador, IEvaluador<JM> evaluador)
        {
            this.nombre = nombre ?? throw new InvalidOperationException("El Jugador no tiene nombre");
            this.identificador = identificador;
            this.evaluador = evaluador ?? throw new InvalidOperationException("El Jugador no tiene evaluador"); ;
            random = new Random();
        }

        public Jugada Estrategia(IEstado<JM> estadoJuego)
        {
            if(estadoJuego == null) throw new InvalidOperationException("No hay estado de Juego disponible");
            List<Tuple<Jugada, int>> jugadasValidas = evaluador.Evalua(estadoJuego);
            if(jugadasValidas.Count > 0)
            {
                List<Jugada> nuevasJugadas = new List<Jugada> { jugadasValidas[0].Item1 };
                int prioridad = jugadasValidas[0].Item2;
                for(int i = 1 ; i < jugadasValidas.Count ; i++)
                {
                    if(jugadasValidas[i].Item2 < prioridad) continue;
                    else if(jugadasValidas[i].Item2 == prioridad) nuevasJugadas.Add(jugadasValidas[i].Item1);
                    else
                    {
                        nuevasJugadas = new List<Jugada> { jugadasValidas[i].Item1 };
                        prioridad = jugadasValidas[i].Item2;
                    }
                }
                int index = random.Next(0, nuevasJugadas.Count);
                return nuevasJugadas[index];
            }
            return null;
        }
        public override bool Equals(object obj)
        {
            if(obj != null && obj is JugadorGoloso<JM>)
                return GetHashCode() == ((JugadorGoloso<JM>)obj).GetHashCode() && nombre == ((JugadorGoloso<JM>)obj).nombre;
            return false;
        }
        public override int GetHashCode() => identificador;
        public override string ToString() => nombre;
    }
}