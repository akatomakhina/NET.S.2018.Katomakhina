using System;
using System.IO;

namespace LabExam
{
    public class CanonPrinter : BasePrinter
    {
        public CanonPrinter(string name, string model) : base(name, model)
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
            Console.WriteLine("Printer Canon started work");
            Console.WriteLine("{0}", arg);
        }
    }
}