using System.Windows;
using DD_Character.Model;
using DD_Character.Model.Statistique;
using Classe = DD_Character.Model.Statistique.Classe;
using DescriptionClasse = DD_Character.Model.Description.Classe;

namespace DD_Character
{

    /*class test
    {
        public Setable<int> lol = new Setable<int>();
        public int mdr = 1;
    }

    internal class surtest
    {
        public test test = new test();

        public int lol
        {
            get
            {
                return test.lol;
            }
        }
    }*/

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var test2 = new DescriptionClasse
            {
                BonusDeBaseAttaque = Constantes.BonusDeBaseAttaque.Faible,
                Sauvegardes =
                {
                    Reflexe = Constantes.Sauvegarde.Faible,
                    Vigueur = Constantes.Sauvegarde.Faible,
                    Volonte = Constantes.Sauvegarde.Eleve
                }
            };
            
            var test3 = new Personnage();
            test3.AddClasse(DescriptionClasse.Guerrier);
            test3.AddClasse(test2);

            MessageBox.Show(test3.BonusBaseAttaque.ToString());
            MessageBox.Show(test3.Reflexe.ToString());

            /*var plop = new Func<int>(() => 1);
            var plopi = new Setable<int>(1);
            var plopii = Computed.From(() => plopi.Value);

            Stopwatch test = Stopwatch.StartNew();
            int b;
            for (int i = 0; i < 1000000; i++)
            {
                b = plop();
            }
            Console.WriteLine(test.ElapsedMilliseconds);*/

            /*SetableList<test> nope = new SetableList<test>();

            var lol = Computed.From(() => nope.Select(test => test.mdr).Sum());
            
            Console.WriteLine(lol.Value.ToString());

            nope.Add(new test());
            
            Console.WriteLine(lol.Value.ToString());*/

            /*var test = new Personnage();

            var d = new DescriptionClasse {Sauvegardes = new Sauvegardes {Reflexe = i => i, Vigueur = i => i, Volonte = i => i}};

            var c = new Classe(d);

            test.Classes.Add(Setable.From(c));
            
            Console.WriteLine(test.Reflexe);

            test.Classes[0].Niveau = 2;

            Console.WriteLine(test.Reflexe);*/

        }
    }
}
