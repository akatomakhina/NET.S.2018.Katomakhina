// <copyright file="Filter.cs" company="Nastichka Enterprises">
//     Copyright? I dont know what is it.
// </copyright>
// <author>Anastasiya Katomakhina</author>

namespace FilterLogic
{
    using System;
    using IPredicateLogic;

    /// <summary>
    /// This class realize filtering method.
    /// </summary>
    public class Filter : IPredicate<int>
    {

        #region PrivateFields

        private int filterNumber;

        #endregion

        #region PublicMethod

        public int FilterNumber
        {
            get => filterNumber;

            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                filterNumber = value;
            }
        }

        #endregion

        #region PrivateMethod
        
        bool IPredicate<int>.Predicate(int element)
        {
            do
            {
                if (element % 10 == FilterNumber || element % 10 == -FilterNumber)
                {
                    return true;
                }

                element /= 10;
            }
            while (element != 0);

            return false;
        }       
                        
        #endregion
    }

    public class EvenNumbers : IPredicate<int>
    {
        public bool Predicate(int element)
        {
            if (element % 2 == 0)
            {
                return true;
            }
            else return false;
        }
    }

    public class OddNumbers : IPredicate<int>
    {
        public bool Predicate(int element)
        {
            if (element % 2 == 0)
            {
                return false;
            }
            else return true;
        }
    }

    public class SimpleNumbers : IPredicate<int>
    {
        public bool Predicate(int element)
        {
            if (element > 1)
            {
                for (int i = 2; i <= element / 2; i++)
                {
                    if (element % i == 0)
                        return false;
                }
                return true;
            }
            else throw new ArgumentException(nameof(element));
        }
    }

    public class PolyndromNumbers : IPredicate<int>
    {
        public bool Predicate(int element)
        {            
            int left = 0;
            int right = element;
            while (right > 0)
            {
                left = left * 10 + right % 10;
                right = right / 10;
            }

            if (left == element)
            {
                return true;
            }
            else return false;
        }
    }
}
