using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : AbstractBaseMatrix<T>
    {
        private T[] elements;

        public SquareMatrix(int size)
        {
            Size = size;
        }

        protected override T GetElement(int i, int j)
        {
            throw new NotImplementedException();
        }

        protected override void SetElement(int i, int j, T value)
        {
            throw new NotImplementedException();
        }
    }
}
