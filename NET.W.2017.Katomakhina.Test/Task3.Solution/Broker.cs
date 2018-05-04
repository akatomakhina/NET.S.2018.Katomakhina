using System;

namespace Task3.Solution
{
    public sealed class Broker
    {
        public string Name { get; set; }

        public Broker(string name)
        {
            this.Name = name;
        }

        public Broker(string name, StockManager stockManager)
        {
            this.Name = name;
            stockManager.NewStock += BrokerMsg;
        }

        public void Register(StockManager stockManager)
        {
            stockManager.NewStock += BrokerMsg;
        }

        public void Unregister(StockManager stockManager)
        {
            stockManager.NewStock -= BrokerMsg;
        }

        public void BrokerMsg(object info, StockInfo stockInfo)
        {
            if (stockInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, stockInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, stockInfo.USD);
        }
    }
}
