using System;

namespace Task3.Solution
{
    public class StockInfo : EventArgs
    {
        public StockInfo() { }

        public StockInfo(int usd, int euro)
        {
            USD = usd;
            Euro = euro;
        }

        public int USD { get; set; }
        public int Euro { get; set; }
    }
}
