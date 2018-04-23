using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Solution
{
    public abstract class Generator
    {
        const string INPUT = "abcdefghijklmnopqrstuvwxyz0123456789";

        public string WorkingDirectory
        {
            get;
        }

        public string FileExtension
        {
            get;
        }

        protected Generator(string workingDirectory, string fileExtension)
        {
            WorkingDirectory = workingDirectory;
            FileExtension = fileExtension;
        }

        public abstract byte[] GenerateFileContent(int contentLength);

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }        

        protected string RandomString(int Size)
        {
            var random = new Random();

            var chars = Enumerable.Range(0, Size).Select(x => INPUT[random.Next(0, INPUT.Length)]);

            return new string(chars.ToArray());
        }

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
