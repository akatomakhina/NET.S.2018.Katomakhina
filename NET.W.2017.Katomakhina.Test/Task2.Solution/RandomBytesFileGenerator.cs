using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Solution
{
    public class RandomBytesFileGenerator : Generator
    {
        public RandomBytesFileGenerator(string workingDirectory, string fileExtension) : base(workingDirectory, fileExtension)
        {
            /*workingDirectory = "Files with random bytes";

            fileExtension = ".bytes";*/
        }

        public override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}
