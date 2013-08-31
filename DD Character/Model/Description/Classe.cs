using System;

namespace DD_Character.Model.Description
{
    public class Classe
    {

        public string ClasseIdentificateur { get; set; }

        public int DéDeVie { get; set; }
        public Func<int, int> BonusDeBaseAttaque { get; set; }
        public Sauvegardes Sauvegardes { get; set; }

        public Classe()
        {
            Sauvegardes = new Sauvegardes();
        }

        public static Classe Guerrier
        {
            get
            {
                return new Classe
                {
                    BonusDeBaseAttaque = Constantes.BonusDeBaseAttaque.Eleve,
                    ClasseIdentificateur = "Guerrier",
                    DéDeVie = 10,
                    Sauvegardes = new Sauvegardes
                    {
                        Reflexe = Constantes.Sauvegarde.Faible,
                        Vigueur = Constantes.Sauvegarde.Eleve,
                        Volonte = Constantes.Sauvegarde.Faible
                    }
                };
            }
        }

        public static Classe Barbare
        {
            get
            {
                return new Classe
                {
                    BonusDeBaseAttaque = Constantes.BonusDeBaseAttaque.Eleve,
                    ClasseIdentificateur = "Barbare",
                    DéDeVie = 12,
                    Sauvegardes = new Sauvegardes
                    {
                        Reflexe = Constantes.Sauvegarde.Faible,
                        Vigueur = Constantes.Sauvegarde.Eleve,
                        Volonte = Constantes.Sauvegarde.Faible
                    }
                };
            }

        }

    }
}
