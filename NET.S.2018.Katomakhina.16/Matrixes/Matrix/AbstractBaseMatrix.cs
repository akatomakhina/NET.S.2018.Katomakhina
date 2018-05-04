using System;
using System.Collections;
using System.Collections.Generic;

namespace Matrix
{
    public abstract class AbstractBaseMatrix<T> : IEnumerable<T>
    {
        private int size = 1;

        public int Size
        {
            get => size;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Size)} can't be negative");
                }

                size = value;
            }
        }

        //????
        public event EventHandler<ChangeElementEventArgs<T>> ChangeElement = delegate { };

        //????
        private void OnChangeElement(ChangeElementEventArgs<T> args)
        {
            EventHandler<ChangeElementEventArgs<T>> temp = ChangeElement;
            temp?.Invoke(this, args);
        }

        public T this[int i, int j]
        {
            get
            {
                IndexValidation(i, j);
                return GetElement(i, j);
            }
            set
            {
                IndexValidation(i, j);
                T old = GetElement(i, j);
                SetElement(i, j, value);
                OnChangeElement(new ChangeElementEventArgs<T>(i, j, old, value));
            }
        }        

        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(int i, int j, T value);        

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 1; i <= Size; i++)
            {
                for (int j = 1; j <= Size; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void IndexValidation(int i, int j)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), $"{nameof(i)} must be > 0");
            }

            if (i > Size)
            {
                throw new ArgumentOutOfRangeException(nameof(i), $"{nameof(i)} must be < size");
            }

            if (j < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(j), $"{nameof(j)} must be > 0");
            }

            if (j > Size)
            {
                throw new ArgumentOutOfRangeException(nameof(j), $"{nameof(j)} must be < size");
            }
        }
    }
}
