using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine;

namespace UnitTestExoCoffeeMachine
{
    [TestClass]
    public class UnitTestCoffeeMachine
    {
        [TestMethod]
        public void CommandeCoffeWith2Sugars()
        {
            string commande ="C:2:0";
            string[] strCommande = null;
            char[] splitdelimiter = { ':' };
            strCommande = commande.Split(splitdelimiter);
            int nbsugar = Int32.Parse(strCommande[1]);
            int nbstick= Int32.Parse(strCommande[2]);
            if (nbsugar >= 1 && nbstick == 0)
                nbstick += 1;
            Coffee coffee = new Coffee(nbsugar, nbstick);
            Assert.AreEqual("Drink maker makes coffee with 2 sugar(s) and 1 stick(s)",coffee.EnvoyerMessage());
        }
        [TestMethod]
        public void CommandeTeaWith1Stick()
        {
            string commande = "T:1:0";
            string[] strCommande = null;
            char[] splitdelimiter = { ':' };
            strCommande = commande.Split(splitdelimiter);
            int nbsugar = Int32.Parse(strCommande[1]);
            int nbstick = Int32.Parse(strCommande[2]);
            if (nbsugar >= 1 && nbstick == 0)
                nbstick += 1;
            Tea tea = new Tea (nbsugar, nbstick);
            Assert.AreEqual("Drink maker makes tea with 1 sugar(s) and 1 stick(s)", tea.EnvoyerMessage());

        }

    }
}
