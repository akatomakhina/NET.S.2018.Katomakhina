using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    class CalcThirdFormula : ICalculateFormula<double>
    {
        public double Calculate(double a, double b)
        {
            return b + (a / b);
        }
    }
}
