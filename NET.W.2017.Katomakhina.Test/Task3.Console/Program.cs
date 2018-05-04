using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new StockManager();
            var bank = new Bank("Kakoy-to bank", manager);
            var broker = new Broker("Kakoy-to broker", manager);
            broker.Register(manager);
            bank.Register(manager);
            manager.SimulateNewStock();
            System.Console.WriteLine();

            bank.Unregister(manager);

            manager.SimulateNewStock();

            System.Console.WriteLine();
            System.Console.ReadKey();
        }
    }
}
