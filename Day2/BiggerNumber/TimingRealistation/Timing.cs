// <copyright file="Timing.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace TimingRealistation
{
    using System;
    using BiggerNumberLogic;

    /// <summary>
    /// The class contains the implementation of the time interval.
    /// </summary>
    public class Timing
    {
        /// <summary>
        /// The method realizes the time interval of searching for the bigger number.
        /// </summary>
        /// <param name="args">The received arguments.</param>
        public static void Main(string[] args)
        {
            NextBiggerNumber nextNumber = new NextBiggerNumber();
           
            Console.WriteLine(NextBiggerNumber.FindNextBiggerNumberTiming(nextNumber.FindNextBiggerNumber(4138)));
            Console.WriteLine(NextBiggerNumber.FindNextBiggerNumberTiming(nextNumber.FindNextBiggerNumber(-345)));
            Console.WriteLine(NextBiggerNumber.FindNextBiggerNumberTiming(nextNumber.FindNextBiggerNumber(7255)));
            Console.ReadKey();
        }
    }
}
