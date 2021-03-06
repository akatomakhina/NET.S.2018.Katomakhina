﻿using System;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            FileStream reader = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);

            FileStream writer = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

            int count = 0;

            for (int i = 0; i < reader.Length; i++)
            {
                writer.WriteByte((byte)reader.ReadByte());
                count++;
            }

            return count;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            byte[] arrayOfBits;

            TextReader reader = new StreamReader(sourcePath);

            byte[] arrayOfSourceBits = Encoding.UTF8.GetBytes(reader.ReadToEnd());

            var memory = new MemoryStream(arrayOfSourceBits);

            memory.Close();
            arrayOfBits = memory.ToArray();

            TextWriter writer = new StreamWriter(destinationPath);

            char[] source = Encoding.UTF8.GetChars(arrayOfBits);

            writer.Write(source);

            return source.Length;
            
            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file
            }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            FileStream reader = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            FileStream writer = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

            byte[] arrayOfBits;

            arrayOfBits = new byte[(int)reader.Length];

            reader.Read(arrayOfBits, 0, arrayOfBits.Length);

            writer.Write(arrayOfBits, 0, arrayOfBits.Length);

            return (int)writer.Length;
            
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static void ByLineCopy(string sourcePath, string destinationPath)
        {
            StreamReader streamReader = new StreamReader(new FileStream(sourcePath, FileMode.Open, FileAccess.Read));
            StreamWriter streamWriter = new StreamWriter(new FileStream(destinationPath, FileMode.Create, FileAccess.Write));

            while (!streamReader.EndOfStream)
            {
                string text = "";
                string temp = streamReader.ReadLine();
                text += temp;
                streamWriter.WriteLine(text);
            }     
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {

        }

        #endregion

        #endregion

    }
}
