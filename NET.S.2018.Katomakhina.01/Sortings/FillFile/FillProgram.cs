// <copyright file="FillProgram.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace FillFile
{
    using System;
    using System.IO;

    /// <summary>
    /// This class is used to fill a one file with random numbers and a second sorted one.
    /// </summary>
    public class FillProgram
    {
        /// <summary>
        /// We fill the file with random integers.
        /// Then we read the elements from the file into an array and sort it.
        /// </summary>
        /// <param name="args">The received arguments.</param>
        public static void Main(string[] args)
        {
            int count = 50;
            int[] array = new int[count];

            Random random = new Random();
            FileStream fileForSorting = new FileStream(@"..\..\..\Resources\arrayWithoutSorting.txt", FileMode.Open);
            StreamWriter writerWithoutSorting = new StreamWriter(fileForSorting);
            FileStream sortedFile = new FileStream(@"..\..\..\Resources\arrayWithSorting.txt", FileMode.Open);
            StreamWriter writerWithSorting = new StreamWriter(sortedFile);

            for (int i = 0; i < count; i++)
            {
                array[i] = random.Next(-100, 101);
                writerWithoutSorting.WriteLine(array[i]);
            }

            writerWithoutSorting.Close();

            Array.Sort(array);

            for (int i = 0; i < count; i++)
            {
                writerWithSorting.WriteLine(array[i]);
            }

            writerWithSorting.Close();
        }
    }
}
