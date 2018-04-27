using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{    

    public class PrinterManager : IPrinterManager
    {
        //конструктор без логера
        public PrinterManager()
        {
            Printers = new HashSet<object>();
        }

        //конструктор с логером
        public PrinterManager(ILogger logger) : this()
        {
            if (ReferenceEquals(logger, null))
            {
                throw new ArgumentNullException(nameof(logger));
            } 

            logger = Logger;
        }

        //Уникальные объекты в коллекции
        public HashSet<object> Printers { get; set; }

        public ILogger Logger { get; set; }


        //Логика реализации событий
        public delegate void PrinterDelegate(string arg);

        public event PrinterDelegate Printed;

        protected virtual void OnPrinted(string arg)
        {
            Printed?.Invoke(arg);
        }

        public void SimulateNewPrint(string arg)
        {
            OnPrinted(arg);
        }


        public void Add(BasePrinter basePrinter)
        {
            if (ReferenceEquals(basePrinter, null))
            {
                throw new ArgumentNullException(nameof(basePrinter));
            }

            Console.WriteLine("Enter printer name and model");
            basePrinter.Name = Console.ReadLine();
            basePrinter.Model = Console.ReadLine();           

            if (!Printers.Contains(basePrinter))
            {
                Printers.Add(basePrinter);
                Console.WriteLine("Printer added");
            }
        }

        public void Print(BasePrinter basePrinter, ILogger logger)
        {
            if (ReferenceEquals(basePrinter, null))
            {
                throw new ArgumentNullException(nameof(basePrinter));
            }

            if (ReferenceEquals(logger, null))
            {
                throw new ArgumentNullException(nameof(logger));
            }

            Logger = logger;

            Logger?.Info("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            basePrinter.Print(f);
            Logger?.Info("Print finished");
        }        
    }
}