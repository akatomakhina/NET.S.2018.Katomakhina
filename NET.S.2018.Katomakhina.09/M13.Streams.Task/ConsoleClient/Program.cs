using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var source = ConfigurationManager.AppSettings["sourceFilePath"];

            var destination = ConfigurationManager.AppSettings["destinationFiePath"];

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");

            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            Console.WriteLine(IsContentEquals(source, destination));*/
            var source = @"..\..\..\Resources\SourceText.txt";
            var destination = @"..\..\..\Resources\DestinationText.txt";
            Console.WriteLine(InMemoryByByteCopy(source, destination));
            Console.ReadKey();
            //etc
        }
    }
}
