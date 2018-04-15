using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchLogic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 12, 23, 29, 30, 44, 56, 68, 90, 123 };
            Console.WriteLine(BinarySearcher.BinarySearch(array, 12));
            Console.ReadKey();
        }
    }
}
