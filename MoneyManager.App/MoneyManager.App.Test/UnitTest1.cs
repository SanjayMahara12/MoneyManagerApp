using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyManager.App.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.App.Test
{
    [TestClass]
    public class UnitTest1
    {
        string datalist = "";
        List<SimpleMoney> simpleMoneyList;
        MoneyManager.App.Lib.SimpleMoneyManager moneyManager;
        public void prepareData()
        {
            List<string> datathing = datalist.Split(',').ToList();
            simpleMoneyList = new List<SimpleMoney>();
            foreach (string str in datathing)
            {
                int index = str.IndexOfAny("0123456789".ToCharArray());
                SimpleMoney money = new SimpleMoney(Convert.ToDecimal(str.Substring(index)), str.Substring(0, index).Trim());
                simpleMoneyList.Add(money);
            }
            moneyManager = new MoneyManager.App.Lib.SimpleMoneyManager(simpleMoneyList);
        }

        [TestMethod]
        public void WhenSetPassedWithSameCurrencyItShouldReturnMaxAmount()
        {
            //update the fields loca
            datalist = "GBP10,GBP20,GBP50";
            decimal expectedMaxAmount = 50;
            prepareData();
            SimpleMoney simpleMoneylargest = moneyManager.getMaxMoney();
            Assert.AreEqual(expectedMaxAmount, simpleMoneylargest.Amount);
        }
    }
}
