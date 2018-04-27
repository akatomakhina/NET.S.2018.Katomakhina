using System;
using LabExam.Logger;

namespace LabExam
{
    class Program
    {
        public ILogger logger = new NLogger("Program");

        [STAThread]
        static void Main(string[] args)
        {            
            var canon = new CanonPrinter("Canon", "1454");
            var epson = new EpsonPrinter("Epson", "1231");

            var manager = new PrinterManager();
            canon.Register(manager);
            epson.Register(manager);
            manager.SimulateNewPrint("Start");

            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(canon);
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(epson);
            }

            while (true)
            {
                // waiting
            }
        }

        private void Print(BasePrinter epsonPrinter)
        {
            PrinterManager.Print(epsonPrinter, logger);
            logger.Info("Printed on Epson");
        }

        private void Print(CanonPrinter canonPrinter)
        {
            PrinterManager.Print(canonPrinter, logger);
            logger.Info("Printed on Canon");
        }

        private static void CreatePrinter()
        {
            PrinterManager.Add(new BasePrinter(string name, string model));
        }
    }
}
