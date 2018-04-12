using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueLogic
{
    public class Queue<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;

        private T[] queue;
        private int head;
        private int tail;
        private int capacity;
        private int size;
        private int version;

        public int Size => size;

        #region ctors
        public Queue()
        {
            queue = new T[DefaultCapacity];
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"{nameof(capacity)} can't less then zero");
            }
            queue = new T[capacity];
            this.capacity = capacity;
        }

        public Queue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"{nameof(collection)} is null");
            }
            queue = new T[collection.Count()];
            capacity = queue.Length;
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        #endregion

        #region queue methods
        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (size == capacity)
            {
                capacity *= 2;
                Resize(capacity);
            }
            queue[tail] = item;
            tail = (tail + 1) % capacity;
            size++;
            version++;
        }

        private void Resize(int capacity)
        {
            T[] newArray = new T[capacity];

            if (size > 0)
            {
                if (head < tail)
                    Array.Copy(queue, head, newArray, 0, size);
                else
                {
                    Array.Copy(queue, head, newArray, 0, queue.Length - head);
                    Array.Copy(queue, 0, newArray, queue.Length - head, tail);
                }
            }

            queue = newArray;
            head = 0;
            tail = size == capacity ? 0 : size;
            version++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            if (size == 0) throw new InvalidOperationException("Queue is empty");

            T item = queue[head];
            queue[head] = default(T);
            head = (head + 1) % capacity;
            size--;
            version++;
            return item;
        }

        public T Peek()
        {
            if (size == 0) throw new InvalidOperationException("Queue is empty");
            return queue[head];
        }

        #endregion

        #region other methods

        public bool Contains(T item)
        {
            EqualityComparer<T> equialityComparer = EqualityComparer<T>.Default;
            int index = head;

            for (int counter = size; counter > 0; counter--)
            {
                if (ReferenceEquals(queue[index], item)) return true;
                if (equialityComparer.Equals(queue[index], item))
                    return true;
                index = (index + 1) % capacity;
            }

            return false;
        }

        public void Clear()
        {
            if (head < tail)
                Array.Clear(queue, 0, size);
            else
            {
                Array.Clear(queue, head, capacity - head);
                Array.Clear(queue, 0, tail);
            }

            head = 0;
            tail = 0;
            size = 0;
            version++;
        }

        public void СоруТо(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException($"{nameof(array)} is null");
            if (arrayIndex < 0) throw new ArgumentException($"{nameof(arrayIndex)} can't be less than 0");

            int numOfElem = array.Length - arrayIndex < size ? array.Length - arrayIndex : size;
            if (numOfElem == 0) return;

            int fromHead = capacity - head < numOfElem ? capacity - head : numOfElem;
            Array.Copy(this.queue, head, array, arrayIndex, fromHead);

            int fromStart = numOfElem - fromHead;
            if (fromStart <= 0) return;
            Array.Copy(this.queue, 0, array, arrayIndex + capacity - head, fromStart);
        }

        public T[] ToArray()
        {
            T[] newArray = new T[size];

            if (head < tail)
                Array.Copy(queue, head, newArray, 0, size);
            else
            {
                Array.Copy(queue, head, newArray, 0, capacity - head);
                Array.Copy(queue, 0, newArray, capacity - head, tail);
            }

            return newArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
