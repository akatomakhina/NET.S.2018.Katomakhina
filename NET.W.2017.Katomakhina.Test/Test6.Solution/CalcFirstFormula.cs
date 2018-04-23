using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class CalcFirstFormula : ICalculateFormula<int>
    {
        public int Calculate(int a, int b)
        {
            return b + a;
        }
    }
}
