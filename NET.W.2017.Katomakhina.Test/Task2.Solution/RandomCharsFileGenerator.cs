using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Solution
{
    public class RandomCharsFileGenerator : Generator
    {
        const string INPUT = "abcdefghijklmnopqrstuvwxyz0123456789";

        public RandomCharsFileGenerator(string workingDirectory, string fileExtension) : base(workingDirectory, fileExtension)
        {
            workingDirectory = "Files with random chars";

            fileExtension = ".txt";
        }       

        public override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = this.RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private string RandomString(int Size)
        {
            var random = new Random();

            var chars = Enumerable.Range(0, Size).Select(x => INPUT[random.Next(0, INPUT.Length)]);

            return new string(chars.ToArray());
        }
    }
}
