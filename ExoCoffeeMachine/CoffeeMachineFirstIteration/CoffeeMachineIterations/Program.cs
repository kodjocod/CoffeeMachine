﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Démarrage des commandes");
            Console.WriteLine("Veuillez entrer votre commande sous le format :Boisson:Sucre:Touillettes:Prix "); //exemple "T:1:0:0,5";
            string commande = Console.ReadLine();
            string[] strCommande = null;
            char[] splitdelimiter = { ':' };
            strCommande= commande.Split(splitdelimiter);
            string boissonchoisi = strCommande[0];

            int nbsugar;
            int nbstick;
      
            bool isSuccessul = Int32.TryParse(strCommande[1], out nbsugar);
            if (!isSuccessul)
                nbsugar = 0;

            isSuccessul = Int32.TryParse(strCommande[2], out nbstick);
            if (!isSuccessul)
                nbstick = 0;

            if (nbsugar >= 1 && nbstick == 0)
                nbstick += 1;

            double prixsaisie = Double.Parse(strCommande[3]);
            

            switch (boissonchoisi)
            {
                case "T":
                    Tea tea = new Tea(nbsugar, nbstick, prixsaisie);
                    if (prixsaisie < tea.Price)
                    {
                        Console.WriteLine("Le montant saisie est inférieure au montant minimal il manque :{0} euros", tea.Price - prixsaisie);
                    }
                    else if (prixsaisie> tea.Price)
                    {
                        Console.WriteLine("Votre monnaie est :{0} euros", prixsaisie -  tea.Price );
                        Console.WriteLine(tea.EnvoyerMessage());
                    }
                    else
                    {

                    }
                    break;
                case "H":
                    //Chocolate choco = new Chocolate(nbsugar, nbstick);
                  //  Console.WriteLine(choco.EnvoyerMessage());
                    break;
                case "C":

                  //  Coffee coffee = new Coffee(nbsugar , nbstick);
                   // Console.WriteLine(coffee.EnvoyerMessage());
                    break;
            }
            Console.ReadKey();

        }
    }

   public class Drink
    {
        public int NbSugar { get;  set; }
        public int NbStick { get;  set; }
 


        public Drink( int nbsugar, int nbStick)
        {

            NbSugar = nbsugar;
            NbStick = nbStick;
        }
        public virtual string EnvoyerMessage()
        {
            return "Drink maker makes";
        }


    }
   public  class Tea : Drink
    {
        private double price=0.4;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if ((value >= 0.4))
                {
                    price = value;
                }

            }

        }


        public Tea( int nbsugar, int nbStick, double price) : base(nbsugar, nbStick)
        {
            NbSugar = nbsugar;
            NbStick = nbStick;
            Price = price;
        }



        public override string EnvoyerMessage()
        {
            return base.EnvoyerMessage() + ""  + " tea with " + NbSugar + " sugar(s) and " + NbStick + " stick(s)";
        }

    }
   public class Coffee : Drink
    {
        private double price = 0.6;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if ((value >= 0.6))
                {
                    price = value;
                }

            }

        }

        public Coffee( int nbsugar, int nbStick,double price) : base( nbsugar, nbStick)
        {

            NbSugar = nbsugar;
            NbStick = nbStick;
            Price = price;
        }
        public override string EnvoyerMessage()
        {
            return base.EnvoyerMessage() +  " coffee with " + NbSugar + " sugar(s) and " + NbStick + " stick(s)";
        }
    }
   public  class Chocolate : Drink
    {
        private double price = 0.5;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if ((value >= 0.5))
                {
                    price = value;
                }

            }

        }

        public Chocolate(int nbsugar, int nbStick,double price) : base( nbsugar, nbStick)
        {
            NbSugar = nbsugar;
            NbStick = nbStick;
            Price = price;
        }
        public override string EnvoyerMessage()
        {
            return base.EnvoyerMessage() + " chocolate with " + NbSugar + " sugar(s) and " + NbStick + " stick(s)";
        }
    }

}


