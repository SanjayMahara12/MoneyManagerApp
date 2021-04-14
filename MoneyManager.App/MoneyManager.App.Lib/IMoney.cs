﻿namespace MoneyManager.App.Lib
{
    public interface IMoney
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
