namespace DD_Character.Model.Statistique
{
    public class Caractéristiques
    {

        public Caractéristique Force { get; set; }
        public Caractéristique Dexterite { get; set; }
        public Caractéristique Constitution { get; set; }
        public Caractéristique Intelligence { get; set; }
        public Caractéristique Sagesse { get; set; }
        public Caractéristique Charisme { get; set; }

        public Caractéristiques()
        {
            Force = new Caractéristique();
            Dexterite = new Caractéristique();
            Constitution = new Caractéristique();
            Intelligence = new Caractéristique();
            Sagesse = new Caractéristique();
            Charisme = new Caractéristique();
        }
    }
}
