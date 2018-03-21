// <copyright file="FillProgram.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace FilterTiming
{
    using System;
    using System.IO;
    using FilterLogic;

    /// <summary>
    /// 
    /// </summary>
    public class TimingProgram
    {
        /// <summary>
        /// This variable describes the filter digit.
        /// </summary>
        public const int FILTER = 3;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">The received arguments.</param>
        public static void Main(string[] args)
        {
            int count = 10000;
            int[] array = new int[count];

            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                array[i] = random.Next(-1000, 1001);
            }

            Console.WriteLine(Filter.FilterTiming(array, 3));
            Console.WriteLine(Filter.FilterTimingString(array, 3));
            Console.ReadKey();
        }
    }
}
