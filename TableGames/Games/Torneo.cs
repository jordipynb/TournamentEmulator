using System;
using System.Collections;
using System.Collections.Generic;

namespace Games
{
    public abstract class Torneo<JM> : IEnumerable<Partida<JM>> where JM : JuegosdeMesa
    {
        #region Campos
        protected readonly JM juego;
        protected readonly List<IJugador<JM>> jugadores;
        protected readonly List<Equipo<JM>> equipos;
        protected readonly bool esPorEquipos;
        protected int[] puntuaciones;
        #endregion

        #region Propiedades
        public int[] Puntuaciones { get { if(Estado == EstadoTorneo.Finalizo) return puntuaciones;
                                          throw new InvalidOperationException("El Torneo no ha finalizado"); } }
        public abstract EstadoTorneo Estado { get; }
        #endregion

        public Torneo(JM juego, List<IJugador<JM>> jugadores)
        {
            this.juego = juego ?? throw new InvalidOperationException("No hay Juego de Mesa establecido");
            esPorEquipos = juego.Equipos;
            if(esPorEquipos)
            {
                equipos = Equipo<JM>.FormaEquipos(jugadores, juego.CantJugadoresPorEquipos);
                puntuaciones = new int[equipos.Count];
            }
            else
            {
                if(jugadores == null || jugadores.Count == 0)
                    throw new InvalidOperationException("No hay Jugadores para realizar el Torneo");
                this.jugadores = jugadores;
                puntuaciones = new int[jugadores.Count];
            }
        }

        /// <summary>
        /// Notifica el proceso del Torneo según su Estado.
        /// </summary>
        /// <returns></returns>
        public abstract string NotificaTorneo();
        public abstract IEnumerator<Partida<JM>> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// Representa las Puntuaciones de cada Jugador o Equipo finalizado el Torneo.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> NotificaPuntuaciones()
        {
            if(Estado == EstadoTorneo.Finalizo)
            {
                if(esPorEquipos)
                {
                    OrdenaPuntuacion(equipos, puntuaciones);
                    for(int i = 0 ; i < equipos.Count ; i++) yield return equipos[i].ToString() + ": " + puntuaciones[i] + " ptos";
                }
                else
                {
                    OrdenaPuntuacion(jugadores, puntuaciones);
                    for(int i = 0 ; i < jugadores.Count ; i++) yield return jugadores[i].ToString() + ": " + puntuaciones[i] + " ptos";
                }
            }
        }
        private void OrdenaPuntuacion<T>(List<T> participantes, int[] puntuaciones)
        {
            for(int k = 0 ; k < puntuaciones.Length - 1 ; k++)
                for(int j = k + 1 ; j < puntuaciones.Length ; j++)
                    if(puntuaciones[j].CompareTo(puntuaciones[k]) > 0)
                    {
                        int temp = puntuaciones[j];
                        puntuaciones[j] = puntuaciones[k];
                        puntuaciones[k] = temp;
                        T tempP = participantes[j];
                        participantes[j] = participantes[k];
                        participantes[k] = tempP;
                    }
        }
    }

    public class CalificacionIndividual<JM> : Torneo<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private EstadoTorneo estado;
        /// <summary>
        /// Jugador Virtual creado para cuando el Juego es de dos Jugadores.
        /// </summary>
        private readonly JugadorGoloso<JM> jugadorVirtual;
        #endregion

        #region Propiedades
        public override EstadoTorneo Estado => estado;
        #endregion

        public CalificacionIndividual(JM juego, List<IJugador<JM>> jugadores, IEvaluador<JM> evaluador) : base(juego, jugadores)
        {
            estado = EstadoTorneo.Iniciando;
            if(!juego.DaPuntuacion || juego.CapacidadMinima > 2)
                throw new InvalidOperationException("Este Tipo de Torneo no es válido para el Juego de Mesa establecido");
            if(!esPorEquipos && evaluador != null) jugadorVirtual = new JugadorGoloso<JM>("Jordan", 0, evaluador);
            else throw new InvalidOperationException("Este Torneo no permite Equipos o usted no pasó un Evaluador.");
        }

        public override IEnumerator<Partida<JM>> GetEnumerator()
        {
            for(int i = 0 ; i < jugadores.Count ; i++)
            {
                List<IJugador<JM>> jugadoresQueCompiten;
                if(juego.CapacidadMinima == 1) jugadoresQueCompiten = new List<IJugador<JM>>(1) { jugadores[i] };
                else jugadoresQueCompiten = new List<IJugador<JM>>(2) { jugadores[i], jugadorVirtual };
                Partida<JM> partidaActual = new Partida<JM>(juego, jugadoresQueCompiten);
                estado = EstadoTorneo.EnProgreso;
                yield return partidaActual;
                puntuaciones[i] = partidaActual.Puntuaciones[0];
            }
            estado = EstadoTorneo.Finalizo;
        }

        public override string NotificaTorneo()
        {
            if(estado == EstadoTorneo.Iniciando) return "Comienza el Torneo por Calificación Individual";
            else if(estado == EstadoTorneo.Finalizo) return "El Torneo ha finalizado";
            else return "El Torneo está en progreso";
        }
    }
    public class Titulo<JM> : Torneo<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private EstadoTorneo estado;
        #endregion

        #region Propiedades
        public override EstadoTorneo Estado => estado;
        #endregion

        public Titulo(JM juego, List<IJugador<JM>> jugadores) : base(juego, jugadores)
        {
            estado = EstadoTorneo.Iniciando;
            if(juego.CapacidadMinima > 2 || juego.CapacidadMaxima < 2)
                throw new InvalidOperationException("Este Tipo de Torneo no es válido para el Juego de Mesa establecido");
            if(esPorEquipos && equipos.Count <= 1) throw new InvalidOperationException("Este Torneo es válido para al menos 2 Equipos.");
        }

        public override IEnumerator<Partida<JM>> GetEnumerator()
        {
            bool[] hanCompetido; int primerC; Partida<JM> partidaActual;
            if(esPorEquipos) hanCompetido = new bool[equipos.Count];
            else hanCompetido = new bool[jugadores.Count];
            Random random = new Random();
            if(esPorEquipos) primerC = random.Next(0, equipos.Count);
            else primerC = random.Next(0, jugadores.Count);
            hanCompetido[primerC] = true;
            List<int> indexValidos = PosicionesVacias(hanCompetido);
            while(indexValidos.Count > 0)
            {
                int segundoC = random.Next(0, indexValidos.Count);
                segundoC = indexValidos[segundoC];
                hanCompetido[segundoC] = true;
                if(esPorEquipos) partidaActual = new Partida<JM>(juego, new List<Equipo<JM>>(2) { equipos[primerC], equipos[segundoC] });
                else partidaActual = new Partida<JM>(juego, new List<IJugador<JM>>(2) { jugadores[primerC], jugadores[segundoC] });
                estado = EstadoTorneo.EnProgreso;
                yield return partidaActual;
                if(partidaActual.Estado != EstadoPartida.Empate && partidaActual.Estado != EstadoPartida.Finalizo)
                    throw new InvalidOperationException("La Partida no ha finalizado, " +
                        "no puede pedir la siguiente sino conoce el Campeón actual");
                if(partidaActual.Estado == EstadoPartida.Empate || partidaActual.IndexGanador == 0)
                { puntuaciones[primerC] = 1; puntuaciones[segundoC] = 0; }
                else { puntuaciones[primerC] = 0; puntuaciones[segundoC] = 1; primerC = segundoC; }
                indexValidos = PosicionesVacias(hanCompetido);
            }
            estado = EstadoTorneo.Finalizo;
        }

        #region Método Auxiliar
        private List<int> PosicionesVacias(bool[] arrayIndex)
        {
            List<int> indexValidos = new List<int>();
            for(int i = 0 ; i < arrayIndex.Length ; i++)
                if(!arrayIndex[i]) indexValidos.Add(i);
            return indexValidos;
        }
        #endregion

        public override string NotificaTorneo()
        {
            if(estado == EstadoTorneo.Iniciando) return "Comienza el Torneo por Título";
            else if(estado == EstadoTorneo.Finalizo) return "El Torneo ha finalizado";
            else return "El Torneo está en progreso";
        }
    }
    public class DosADos<JM> : Torneo<JM> where JM : JuegosdeMesa
    {
        #region Campos
        private EstadoTorneo estado;
        #endregion

        #region Propiedades
        public override EstadoTorneo Estado => estado;
        #endregion

        public DosADos(JM juego, List<IJugador<JM>> jugadores) : base(juego, jugadores)
        {
            estado = EstadoTorneo.Iniciando;
            if(juego.CapacidadMinima > 2 || juego.CapacidadMaxima < 2 || !juego.DaPuntuacion)
                throw new InvalidOperationException("Este Tipo de Torneo no es válido para el Juego de Mesa establecido");
            if(esPorEquipos && equipos.Count <= 1)
                throw new InvalidOperationException("Este Torneo es válido para al menos 2 Equipos." +
                    "\nNOTA: cantidad de Jugadores debe ser mayor o igual a: " + juego.CantJugadoresPorEquipos * 2 + ".");
        }

        public override IEnumerator<Partida<JM>> GetEnumerator()
        {
            Partida<JM> partidaActual;
            for(int i = 0 ; (esPorEquipos && i < equipos.Count - 1) || (!esPorEquipos && i < jugadores.Count - 1) ; i++)
                for(int j = i + 1 ; (esPorEquipos && j < equipos.Count) || (!esPorEquipos && j < jugadores.Count) ; j++)
                {
                    if(esPorEquipos) partidaActual = new Partida<JM>(juego, new List<Equipo<JM>>(2) { equipos[i], equipos[j] });
                    else partidaActual = new Partida<JM>(juego, new List<IJugador<JM>>(2) { jugadores[i], jugadores[j] });
                    estado = EstadoTorneo.EnProgreso;
                    yield return partidaActual;
                    puntuaciones[i] += partidaActual.Puntuaciones[0];
                    puntuaciones[j] += partidaActual.Puntuaciones[1];
                }
            estado = EstadoTorneo.Finalizo;
        }

        public override string NotificaTorneo()
        {
            if(estado == EstadoTorneo.Iniciando) return "Comienza el Torneo por Dos a Dos";
            else if(estado == EstadoTorneo.Finalizo) return "El Torneo ha finalizado";
            else return "El Torneo está en progreso";
        }
    }

    #region Tipo de Estado para Torneo
    public enum EstadoTorneo
    {
        Iniciando,
        EnProgreso,
        Finalizo
    }
    #endregion
}