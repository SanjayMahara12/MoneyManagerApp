using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyManager.App.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.App.Test
{
    [TestClass]
    public class MoneyManagerTest
    {
        string datalist = "";
        List<IMoney> simpleMoneyList;
        IMoneyCalculator moneyManager;
        public void prepareData()
        {
            List<string> datathing = datalist.Split(',').ToList();
            simpleMoneyList = new List<IMoney>();
            foreach (string str in datathing)
            {
                int index = str.IndexOfAny("0123456789".ToCharArray());
                IMoney money = new SimpleMoney(Convert.ToDecimal(str.Substring(index)), str.Substring(0, index).Trim());
                simpleMoneyList.Add(money);
            }
            moneyManager = new SimpleMoneyCalculator();
        }

        [TestMethod]
        public void WhenSetPassedWithSameCurrencyItShouldReturnMaxAmount()
        {
            //update the fields loca
            datalist = "GBP10,GBP20,GBP50";
            decimal expectedMaxAmount = 50;
            prepareData();
            IMoney simpleMoneylargest = moneyManager.Max(simpleMoneyList);
            Assert.AreEqual(expectedMaxAmount, simpleMoneylargest.Amount);
        }

        [TestMethod]
        public void WhenSetpassedWithDifferentCurrencyReturnsArgumentException()
        {
            datalist = "GBP10,GBP20,USDP50";
            prepareData();
            bool passed = false;
            try
            {
                IMoney simpleMoneylargest = moneyManager.Max(simpleMoneyList);
            }
            catch (ArgumentException argEx)
            {
                passed = true;
            }
            catch
            {
                passed = false;
            }

            Assert.IsTrue(passed);

        }

        [TestMethod]
        public void GivenSetWithDifferentCurrencyShouldResultInGroupTotalByCurrency()
        {
            datalist = "GBP10,GBP20,USDP50";
            prepareData();
            List<IMoney> setGroup = moneyManager.SumPerCurrency(simpleMoneyList).OrderByDescending(x => x.Amount).ToList();
            Assert.IsTrue(setGroup.Count == 2 &&
                          setGroup.FirstOrDefault().Amount == 50 &&
                          setGroup.LastOrDefault().Amount == 30);
        }

    }
}
