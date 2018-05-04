using System;

namespace Task3.Solution
{
    public class StockManager
    {
        public event EventHandler<StockInfo> NewStock = delegate { };

        protected virtual void OnNewMail(StockInfo stockInfo)
        {
            EventHandler<StockInfo> temp = NewStock;
            temp?.Invoke(this, stockInfo);
        }

        public void SimulateNewStock()
        {
            StockInfo stock = new StockInfo();
            Random rnd = new Random();
            stock.USD = rnd.Next(20, 40);
            stock.Euro = rnd.Next(30, 50);
            OnNewMail(new StockInfo(stock.USD, stock.Euro));
        }
    }
}
