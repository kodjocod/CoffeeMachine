using System;
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
            string order = "C:2:0:0,6";
            Machine m = new Machine();
            m.PassOrder(order);
            string order2 = "C:2:0:0,6";
            m.PassOrder(order2);
            m.DisplayReport();


        }
    }
    public interface EmailNotifier
    {
        void notifyMissingDrink(String drink);
    }
    public interface BeverageQuantityChecker
    {
        bool isEmpty(String drink);
    }
    public class Machine : EmailNotifier,BeverageQuantityChecker
    {
        public static int TotalNbCoffee { get; set; }
        public static int TotalNbTea { get; set; }
        public static int TotalNbChocolate { get; set; }
        public static int TotalNbOrange { get; set; }
        public static double TotalMoney { get; set; }

        public string PassOrder(String order)
        {
            string[] strOrder = null;
            char[] splitdelimiter = { ':' };
            strOrder = order.Split(splitdelimiter);

            int nbsugar;
            int nbstick;
            bool isSuccessul = Int32.TryParse(strOrder[1], out nbsugar);
            if (!isSuccessul)
                nbsugar = 0;

            isSuccessul = Int32.TryParse(strOrder[2], out nbstick);
            if (!isSuccessul)
                nbstick = 0;

            if (nbsugar >= 1 && nbstick == 0)
                nbstick = 1;

            string drinkname = strOrder[0];
            Drink drink = new Drink(drinkname);
            double orderprice;
            if (strOrder.Length > 3)
            {
                orderprice = Double.Parse(strOrder[3]);
            }
            else
            {
                orderprice = drink.Price;
            }


            string message = "Drink maker will makes";
            if (drinkname.Contains("h"))
                message += " an extra hot";

            message += " 1 " + drink.Name + " with " + nbsugar + " sugar(s)";
            if (nbstick == 0)
                message += " therefore no stick";
            else if (nbstick == 1)
                message += " and a stick";
            else
                message += " and " + nbstick + "sticks";

            Machine machine = new Machine();
            if (orderprice == drink.Price)
            {
    
                Console.WriteLine(message);
                machine.ComputeDrinks(drink);

            }
            else if (orderprice > drink.Price)
            {
                double change = orderprice - drink.Price;
                Console.WriteLine(message += " you will have " + change + " of change");
                machine.ComputeDrinks(drink);

            }
            else if (orderprice < drink.Price)
            {
                double diff = drink.Price - orderprice;
                Console.WriteLine(message = "not enough money missing " + diff);

            }

            return message;

        }
        public void ComputeDrinks(Drink drink)
        {
            string drinkname = drink.Name;

            if (drinkname == "tea")
            {
                TotalNbTea += 1;
                TotalMoney += drink.Price;
            }
            else if (drinkname == "coffee")
            {
                TotalNbCoffee += 1;
                TotalMoney += drink.Price;
            }

            else if (drinkname == "chocolate")
            {
                TotalNbChocolate += 1;
                TotalMoney += drink.Price;
            }
            else if (drinkname == "orange")
            {
                TotalNbOrange += 1;
                TotalMoney += drink.Price;
            }
        }
        public string DisplayReport()
        {
            string mes = "People have bought :" + "\r\n" + TotalNbCoffee + " coffee(s) " + "\r\n" + TotalNbTea + " tea(s)" + "\r\n" + TotalNbChocolate + " chocolate(s)" + "\r\n" + TotalNbOrange + " orange(s)" + "\r\n" + "Total Cost :" + TotalMoney;
            return mes;
        }

        public bool isEmpty(string drink)
        {
            if (drink == "coffee")
            {
                return true;
            }
            else if (drink=="tea")
            {
                return false;
            }
            else if (drink == "chocolate")
            {
                return false;
            }
            else if (drink == "orange")
            {
                return true;
            }
            return false;
        }

       public void notifyMissingDrink(string drink)
        {
            Console.WriteLine("there is no more " + drink + " in the Drink maker");
        }
    }
    public class Drink
    {
        public double Price { get; set; }
        public string Name { get; set; }



        public Drink(string name)
        {
            Name = name;
            if (name == "T" | name == "Th")
            {
                Name = "tea";
                Price = 0.4;
            }
            else if (name == "C" | name == "Ch")
            {
                Name = "coffee";
                Price = 0.6;
            }

            else if (name == "H" | name == "Hh")
            {
                Name = "chocolate";
                Price = 0.5;
            }
            else if (name == "O")
            {
                Name = "orange";
                Price = 0.6;
            }
            else
                Price = 0;
        }


    }


}
