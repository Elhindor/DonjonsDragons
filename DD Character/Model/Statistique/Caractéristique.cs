using DD_Character.Utilitaire.Eventless;

namespace DD_Character.Model.Statistique
{
    public class Caractéristique
    {

        private readonly Setable<int> _carac;
        public int Carac { get { return _carac.Value; } }
        private readonly Computed<int> _modificateur;
        public int Modificateur { get { return _modificateur.Value; } }

        public Caractéristique()
        {
            _carac = new Setable<int>();
            _modificateur = new Computed<int>(() => (Carac - 10) / 2);
        }

    }
}
