using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public interface IVerifyPasswordTwo
    {
        Tuple<bool, string> VerifyPassword(string password);
    }
}
