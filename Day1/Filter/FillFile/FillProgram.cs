// <copyright file="FillProgram.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace FillFile
{
    using System;
    using System.IO;
    using FilterLogic;

    /// <summary>
    /// This class is used to fill a one file with random numbers and a second sorted one.
    /// </summary>
    public class FillProgram
    {
        /// <summary>
        /// This variable describes the filter digit.
        /// </summary>
        public const int FILTER = 3;

        /// <summary>
        /// We fill the file with random integers.
        /// Then we read the elements from the file into an array and sort it.
        /// </summary>
        /// <param name="args">The received arguments.</param>
        public static void Main(string[] args)
        {
            Filter filter = new Filter();
            int count = 100;
            int[] array = new int[count];
            int[] filteredArray;

            Random random = new Random();
            FileStream fileForFiltered = new FileStream(@"..\..\..\Resources\arrayForFilter.txt", FileMode.Open);
            StreamWriter writerWithoutFilter = new StreamWriter(fileForFiltered);
            FileStream fileWithFilter = new FileStream(@"..\..\..\Resources\arrayWithFilteredNumber.txt", FileMode.Open);
            StreamWriter writerWithFilter = new StreamWriter(fileWithFilter);

            for (int i = 0; i < count; i++)
            {
                array[i] = random.Next(-100, 101);
                writerWithoutFilter.WriteLine(array[i]);
            }

            writerWithoutFilter.Close();

            filteredArray = filter.FilterDigit(array, FILTER);

            for (int i = 0; i < filteredArray.Length; i++)
            {
                writerWithFilter.WriteLine(filteredArray[i]);
            }

            writerWithFilter.Close();
        }
    }
}
