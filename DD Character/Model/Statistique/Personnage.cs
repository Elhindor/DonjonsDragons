using System.Linq;
using DD_Character.Utilitaire.Eventless;
using DescriptionClasse = DD_Character.Model.Description.Classe;

namespace DD_Character.Model.Statistique
{
    public class Personnage
    {

        #region Attributs
        
        private readonly Computed<int> _reflexe;
        private readonly Computed<int> _vigueur;
        private readonly Computed<int> _volonte;
        private readonly Computed<int> _bonusDeBaseAttaque;
        private readonly SetableList<Classe> _classes = new SetableList<Classe>();
        private readonly SetableList<int> _vieAChaqueNiveau = new SetableList<int>();

        #endregion

        public Personnage() {
            Caractéristiques = new Caractéristiques();
            _reflexe = Computed.From(() => _classes.Sum(setable => setable.Reflexe) + Caractéristiques.Dexterite.Modificateur);
            _vigueur = Computed.From(() => _classes.Sum(setable => setable.Vigueur) + Caractéristiques.Constitution.Modificateur);
            _volonte = Computed.From(() => _classes.Sum(setable => setable.Volonte) + Caractéristiques.Sagesse.Modificateur);
            _bonusDeBaseAttaque = Computed.From(() => _classes.Sum(classe => classe.BonusDeBaseAttaque));
        }
        
        public int Reflexe { get { return _reflexe.Value; } }
        public int Vigueur { get { return _vigueur.Value; } }
        public int Volonte { get { return _volonte.Value; } }
        public int Vie { get { return _vieAChaqueNiveau.Sum() + Caractéristiques.Constitution.Modificateur*NiveauGlobal; } }
        public int NiveauGlobal { get { return _classes.Sum(classe => classe.Niveau); } }
        public Caractéristiques Caractéristiques { get; private set; }
        public int BonusBaseAttaque { get { return _bonusDeBaseAttaque.Value; } }

        public void AddClasse(Classe classe) 
        {
            _classes.Add(classe);
        }

        public void AddClasse(DescriptionClasse classe)
        {
            _classes.Add(new Classe(classe));
        }

        public void LevelUp(string classeIdentificateur)
        {
            _classes.First(classe => classe.ClasseIdentificateur.Equals(classeIdentificateur)).LevelUp();
        }

    }
}
