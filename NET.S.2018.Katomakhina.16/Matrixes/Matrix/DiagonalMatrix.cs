using System;

namespace Matrix
{
    public class DiagonalMatrix<T> : AbstractBaseMatrix<T>
    {
        private T[] diagonalElements;

        public DiagonalMatrix(int size)
        {
            Size = size;
            diagonalElements = new T[size];
        }

        public DiagonalMatrix(int size, T[] elements) : this(size)
        {
            for (int i = 0; i < diagonalElements.Length && i < elements.Length; i++)
            {
                diagonalElements[i] = elements[i];
            }
        }

        protected override T GetElement(int i, int j)
        {
            IndexValidation(i, j);
            return i == j ? diagonalElements[i - 1] : default(T);
        }

        protected override void SetElement(int i, int j, T value)
        {
            IndexValidation(i, j);
            if (i != j)
            {
                throw new ArgumentException
                      ("other than the default values can be only the elements on the main diagonal");
            }

            diagonalElements[i - 1] = value;
        }
    }
}
