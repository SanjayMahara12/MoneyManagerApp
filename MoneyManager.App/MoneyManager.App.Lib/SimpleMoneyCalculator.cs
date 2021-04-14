using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.App.Lib
{
    public class SimpleMoneyCalculator : IMoneyCalculator
    {
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            var val = monies.First().Currency;
            var ret = monies.All(x => x.Currency == val) ;
            if (!ret)
                throw new ArgumentException("All monies are not in the same currency.");
            return monies.OrderByDescending(x => x.Amount).First();
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            var regroupedMoneyByCurrency = monies.GroupBy(a => a.Currency)
                            .Select(a => new SimpleMoney { Amount = a.Sum(b => b.Amount), Currency = a.Key })
                            .ToList();

            return regroupedMoneyByCurrency.AsEnumerable<IMoney>();
        }
    }
}
