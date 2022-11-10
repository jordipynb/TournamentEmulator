using System;

namespace Games
{
    public abstract class Jugada { }
    public class Posiciones : Jugada
    {
        #region Propiedades
        public int X { get; private set; }
        public int Y { get; private set; }
        #endregion

        public Posiciones(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if(obj != null && obj is Posiciones)
                return X == ((Posiciones)obj).X && Y == ((Posiciones)obj).Y;
            return false;
        }
        public override int GetHashCode() => X + Y + X * Y * 10;
        public override string ToString() => "Posición: {" + X + " , " + Y + "}";
    }
    public class Fichas : Jugada
    {
        #region Propiedades
        public int Inferior { get; private set; }
        public int Superior { get; private set; }
        #endregion

        public Fichas(int inf, int sup)
        {
            if(inf < 0 || inf > 9 || sup < 0 || sup > 9) throw new InvalidOperationException("Los valores son inválidos");
            if(inf > sup) { int temp = sup; sup = inf; inf = temp; }
            Inferior = inf;
            Superior = sup;
        }

        public override bool Equals(object obj)
        {
            if(obj != null && obj is Fichas)
                return Superior == ((Fichas)obj).Superior && Inferior == ((Fichas)obj).Inferior;
            return false;
        }
        public override int GetHashCode() => 100 * (Superior + Inferior);
        public override string ToString() => $"Ficha: {Inferior} | {Superior}";
    }
}