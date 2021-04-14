using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.App.Lib
{
    public class MoneyManager
    {
        IEnumerable<IMoney> monies;
        IMoneyCalculator calculator;
        public MoneyManager(IEnumerable<SimpleMoney> suppliedmonies)
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
            throw new Exception();

        }
    }
}
