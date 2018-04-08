using System;
using System.Collections.Generic;

namespace AlgorithmSorting
{
    internal class DelegateForSort : IComparer<int[]>
    {
        private Comparison<int[]> delegateComparator;

        public DelegateForSort(Comparison<int[]> comparator)
        {
            if (ReferenceEquals(comparator, null))
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            delegateComparator = comparator;
        }

        public int Compare(int[] x, int[] y) =>
            delegateComparator(x, y);
    }
}
