using System;

namespace Task3.Solution
{
    public sealed class Bank
    {
        public string Name { get; set; }

        public Bank(string name)
        {
            this.Name = name;            
        }

        public Bank(string name, StockManager stockManager)
        {
            this.Name = name;
            stockManager.NewStock += BankMsg;
        }

        public void Register(StockManager stockManager)
        {
            stockManager.NewStock += BankMsg;
        }

        public void Unregister(StockManager stockManager)
        {
            stockManager.NewStock -= BankMsg;
        }

        public void BankMsg(object info, StockInfo stockInfo)
        {
            if (stockInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, stockInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, stockInfo.Euro);
        }
    }
}
