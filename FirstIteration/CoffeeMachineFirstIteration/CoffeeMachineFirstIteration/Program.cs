using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Démmarrage des commandes");
            string commande = Console.ReadLine();

        }
    }

    class Boisson
    {
        public int Qte { get; set; }
        public int NbSugar { get; set; }
        public int NbCuillere { get; set; }

        public Boisson(int qte, int nbsugar, int nbcuillere)
        {
            Qte = qte;
            NbSugar = nbsugar;
            NbCuillere = nbcuillere;
        }
        public virtual string EnvoyerMessage()
        {
            return "Drink maker makes";
        }


    }
    class Thé : Boisson
    {
        public Thé(int qte, int nbsugar, int nbcuillere) : base(qte, nbsugar, nbcuillere)
        {
            Qte = qte;
            NbSugar = nbsugar;
            NbCuillere = nbcuillere;
        }



        public override string EnvoyerMessage()
        {
            return base.EnvoyerMessage() + "" + Qte + " tea with" + NbSugar + "sugar and " + NbCuillere + "cuillère";
        }

    }
}
}
