using System;
using System.IO;

namespace LabExam
{
    public class EpsonPrinter : BasePrinter
    {
        public EpsonPrinter(string name, string model) : base(name, model)
        {            
        }        

        public override void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }

        public override void Message(string arg)
        {
            Console.WriteLine("Printer Epson started work");
            Console.WriteLine("{0}", arg);
        }
    }
}