using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.App.Lib
{
    public class SimpleMoney : IMoney
    {
        public SimpleMoney() { }
        public SimpleMoney(decimal amount,string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
