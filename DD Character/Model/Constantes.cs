using System;
using System.Runtime.Caching;

namespace DD_Character.Model
{
    public static class Constantes
    {

        public static class Sauvegarde
        {
            public static readonly Func<int, int> Eleve = i => i/2 + 2;
            public static readonly Func<int, int> Faible = i => (int) Math.Floor(i / 3.33);
        }

        public static class BonusDeBaseAttaque
        {
            private const double TroisQuart = 3/4;
            private const double UnDemi = 1 / 2;

            public static readonly Func<int, int> Eleve = i => i;
            public static readonly Func<int, int> Moyen = i => (int) Math.Floor(i * TroisQuart);
            public static readonly Func<int, int> Faible = i => (int) Math.Floor(i * UnDemi);
        }

        public static ObjectCache Cache = MemoryCache.Default;

    }
}
