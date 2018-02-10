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
            string order = "C:3:0:2";
            Machine m = new Machine();
            m.PassOrder(order);
            Console.ReadKey();

        }
    }

    public class Machine
    {
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

            string name = strOrder[0];
            double orderprice = Double.Parse(strOrder[3]);
            Drink drink = new Drink(name);
            Machine machine = new Machine();

            string message = "Drink maker makes ";
            message += "1 " + drink.Name + " with " + nbsugar + " sugar(s) ";
            if (nbstick == 0)
                message += " therefore no stick";
            else if (nbstick == 1)
                message += " and a stick";
            else
                message += " and " + nbstick + "sticks";

            if (orderprice == drink.Price)
            {
                Console.WriteLine(message);
            }
            else if (orderprice > drink.Price)
            {
                double change = orderprice - drink.Price;
                Console.WriteLine(message += " you will have " + change + " of change");

            }
            else if (orderprice < drink.Price)
            {
                double diff = drink.Price - orderprice;
                Console.WriteLine(message = "not enough money missing " + diff);

            }

            return message;


        }

    }
   public class Drink
    {
        public double Price { get; set; }
        public string Name { get; set; }
        

        public Drink( string name)
        {
            Name = name;
                if (name == "T")
                {
                    Name = "tea";
                    Price = 0.4;
                }
                else if (name == "C")
                {
                    Name = "coffee";
                    Price = 0.6;
                }

                else if (name == "H")
                {
                    Name = "chocolate";
                    Price = 0.5;
                }
                else
                    Price = 0;
            }
    
        }

    }




