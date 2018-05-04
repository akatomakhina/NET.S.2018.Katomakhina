using System;

namespace Matrix
{
    public class ChangeElementEventArgs<T> : EventArgs
    {
        public int Row { get; }

        public int Column { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        public ChangeElementEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
