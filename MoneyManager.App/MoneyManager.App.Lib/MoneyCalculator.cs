using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.App.Lib
{
    class MoneyCalculator : IMoneyCalculator
    {
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            
            return monies.OrderByDescending(x => x.Amount).First();
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            throw new NotImplementedException();
        }
    }
}
