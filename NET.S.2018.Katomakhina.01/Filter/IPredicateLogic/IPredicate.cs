using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPredicateLogic
{
    public interface IPredicate<T>
    {
        bool Predicate(T element); 
    }
}
