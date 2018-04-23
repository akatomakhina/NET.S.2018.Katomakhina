using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    class CalcSecondFormula : ICalculateFormula<int>
    {
        public int Calculate(int a, int b)
        {
            return (6 * b - 8 * a);
        }
    }
}
