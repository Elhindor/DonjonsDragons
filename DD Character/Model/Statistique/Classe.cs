using DD_Character.Utilitaire.Eventless;

namespace DD_Character.Model.Statistique
{
    public class Classe
    {

        private readonly Description.Classe _classe;

        public string ClasseIdentificateur { get { return _classe.ClasseIdentificateur; } }

        private readonly Setable<int>_niveau = new Setable<int>(1);

        public int Niveau
        {
            get { return _niveau.Value; }
            set { _niveau.Value = value; }
        }
        
        private readonly Computed<int> _reflexe;
        public int Reflexe
        { get { return _reflexe.Value; } }

        private readonly Computed<int> _vigueur;
        public int Vigueur
        { get { return _vigueur.Value; } }

        private readonly Computed<int> _volonte;
        public int Volonte
        { get { return _volonte.Value; } }

        private readonly Computed<int> _bonusDeBaseAttaque;
        public int BonusDeBaseAttaque {get { return _bonusDeBaseAttaque.Value; }}

        public Classe(Description.Classe classe)
        {
            _classe = classe;
            _reflexe = Computed.From(() => _classe.Sauvegardes.Reflexe(Niveau));
            _vigueur = Computed.From(() => _classe.Sauvegardes.Vigueur(Niveau));
            _volonte = Computed.From(() => _classe.Sauvegardes.Volonte(Niveau));
            _bonusDeBaseAttaque = Computed.From(() => _classe.BonusDeBaseAttaque(Niveau));
        }

        public void LevelUp()
        {
            var tmp = Niveau;
            Niveau = tmp + 1;
        }
    }
}
