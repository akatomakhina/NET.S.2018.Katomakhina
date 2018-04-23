using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    class Generate<T>
    {
        private int count;
        private T a;
        private T b;

        public int Count => count;
        public T AProp => a;
        public T BProp => b;


        public static IEnumerable<T> GenerateSequence<T>(int count, T a, T b, ICalculateFormula<T> calc)
        {
            Validation(count, a, b);

            if (ReferenceEquals(calc, null))
            {
                throw new ArgumentNullException(nameof(calc));
            }                

            return GenerateMethod(count, a, b, calc.Calculate);
        }

        private static IEnumerable<T> GenerateMethod<T>(int count, T a, T b, Func<T, T, T> calculator)
        {
            if (count == 1) yield return a;

            for (int i = 2; i <= count; i++)
            {
                var temp = b;
                b = calculator(a, b);
                yield return b;
                a = temp;
            }
        }

        private static void Validation<T>(int count, T a, T b)
        {
            if (count < 0)
                throw new ArgumentException($"{nameof(count)} must be greater than 0.", nameof(count));

            if (ReferenceEquals(a, null))
                throw new ArgumentNullException(nameof(a));

            if (ReferenceEquals(b, null))
                throw new ArgumentNullException(nameof(b));            
        }
    }
}
