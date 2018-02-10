using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine;

namespace UnitTestExoCoffeeMachine
{
    [TestClass]
    public class UnitTestCoffeeMachine
    {
        [TestMethod]
        public void OrderCoffeeWithEnoughMoney()
        {
            string order = "C:2:0:0,6";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("Drink maker will makes 1 coffee with 2 sugar(s) and a stick", m.PassOrder(order));
        }
        [TestMethod]
        public void OrderTeaWithNotEnoughMoney()
        {
            string order = "T:0:0:0,1";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("not enough money missing 0,3", m.PassOrder(order));

        }
        [TestMethod]
        public void OrderChocolateWithTooMuchMoney()
        {
            string order = "H:2:0:2";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("Drink maker will makes 1 chocolate with 2 sugar(s) and a stick you will have 1,5 of change", m.PassOrder(order));

        }

        [TestMethod]

         public void OrderSimpleOrangeJuice()
        {
            string order = "O::";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("Drink maker will makes 1 orange with 0 sugar(s) therefore no stick", m.PassOrder(order));

        }
        [TestMethod]
        public void OrderExtraHotChocolate()
        {

            string order = "Hh:1:0";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("Drink maker will makes an extra hot 1 chocolate with 1 sugar(s) and a stick", m.PassOrder(order));

        }
        [TestMethod]
        public void OrderExtraHotTea()
        {
            string order = "Th:2:0";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("Drink maker will makes an extra hot 1 tea with 2 sugar(s) and a stick", m.PassOrder(order));

        }
        [TestMethod]
        public void OrderExtraHotCoffee()
        {
            string order = "Ch::";
            Machine m = new Machine();
            m.PassOrder(order);
            Assert.AreEqual("Drink maker will makes an extra hot 1 coffee with 0 sugar(s) therefore no stick", m.PassOrder(order));

        }
        [TestMethod]
        public void SetCoffeePrice()
        {
            Drink d = new Drink("T");
            Assert.AreEqual(0.4, d.Price);
        }
        [TestMethod]
        public void SetChocolatePrice()
        {
            Drink d = new Drink("H");
            Assert.AreEqual(0.5, d.Price);
        }
        [TestMethod]
        public void SetTeaPrice()
        {
            Drink d = new Drink("T");
            Assert.AreEqual(0.4, d.Price);
        }
    }
}