using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Task_2;
using Task2.Solution;

namespace Task2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesCount = 1;
            var contentLength = 100;

            var randomBytesFileGenerator = new RandomBytesFileGenerator(@"E:\.NET.Training\NET.S.2018.Katomakhina\NET.W.2017.Katomakhina.Test", ".bin");
            var randomCharsFileGenerator = new RandomCharsFileGenerator(@"E:\.NET.Training\NET.S.2018.Katomakhina\NET.W.2017.Katomakhina.Test", ".txt");

            randomBytesFileGenerator.GenerateFiles(filesCount, contentLength);
            randomCharsFileGenerator.GenerateFiles(filesCount, contentLength);
        }
    }
}