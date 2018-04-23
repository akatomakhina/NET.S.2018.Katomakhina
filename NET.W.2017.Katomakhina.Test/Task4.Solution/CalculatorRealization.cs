using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution
{
    public class CalculatorRealization
    {
        public double DoCalc(List<double> values, ICalculate calculate)
        {
            return calculate.CalculateAverage(values);
        }

        public double DoCalcWithDelegate(List<double> values, Func<List<double>, double> calculate)
        {
            return calculate(values);
        }
    }
}
