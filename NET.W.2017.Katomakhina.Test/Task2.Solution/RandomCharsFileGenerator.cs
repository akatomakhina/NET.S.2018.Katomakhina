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
    }
}
