using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.App.Lib
{
    public class SimpleMoneyManager
    {
        IEnumerable<IMoney> monies;
        IMoneyCalculator calculator;
        public SimpleMoneyManager(IEnumerable<SimpleMoney> suppliedmonies)
        {
            monies = suppliedmonies;
            calculator = new MoneyCalculator();
        }

        public SimpleMoney getMaxMoney()
        {
            IMoney money = new SimpleMoney();
            return calculator.Max(monies) as SimpleMoney;

        }

        public IEnumerable<SimpleMoney> sumTotalPerCurrency()
        {
            var regroupedMoneyByCurrency = monies.GroupBy(a => a.Currency)
                            .Select(a => new SimpleMoney { Amount = a.Sum(b => b.Amount), Currency = a.Key })
                            .ToList();

            return regroupedMoneyByCurrency;

        }
    }
}
