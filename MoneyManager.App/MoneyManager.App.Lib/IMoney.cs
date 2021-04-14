using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.App.Lib
{
    interface IMoney
    {
        /// <summary>
        /// The amount of money this instance represents.
        /// </summary>
        /// </summary>
        decimal Amount { get; }

        /// <summary>
        /// The ISO currency code of this instance.
        /// </summary>
        string Currency { get; }
    }
}
