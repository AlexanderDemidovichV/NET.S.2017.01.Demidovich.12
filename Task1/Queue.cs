using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArrayQueue<T> : IQueue<T>
    {

        private T[] array;

        private const int defaultCapacity = 4;

        private int head;

        private int tail;

        private int size;

        public int Count
        {
            get { return this.size; }
        }

        public ArrayQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException($"{capacity} less than zero.");
            this.array = new T[capacity];
        }

        public ArrayQueue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException($"{nameof(collection)} is null.");
            array = new T[defaultCapacity];

            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while(enumerator.MoveNext())
                    Enqueue(enumerator.Current);
            }
        }

        public void Enqueue(T item)
        {
            if (size == array.Length)
            {
                int capacity = (int)(array.Length * 200L / 100L);
                if (capacity < array.Length + defaultCapacity)
                    capacity = this.array.Length + defaultCapacity;
                SetCapacity(capacity);

            }
            this.array[tail] = item;
            tail = (tail + 1) % array.Length;
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException("Empty queue.");

            T local = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            size--;
            return local;
        }

        public void Clear()
        {
            if (head < tail)
                Array.Clear(array, head, size);
            else
            {
                Array.Clear(array, head, array.Length - head);
                Array.Clear(array, 0, head);
            }
            head = 0;
            tail = 0;
            size = 0;
        }

        public bool Contains(T item)
        {
            int index = head;
            int i = size;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (i-- > 0)
            {
                if (comparer.Equals(item, default(T)))
                {
                    if (comparer.Equals(array[index], default(T)))
                        return true;
                }
                else if (comparer.Equals(array[index], default(T)) && comparer.Equals(item, array[index]))
                {
                    return true;
                }
                index = index + 1 % array.Length;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("Empty queue.");
            return array[head];
        }

        public T[] ToArray()
        {
            T[] destinationArray = new T[size];

            if (size != 0)
            {
                
            }

            return destinationArray;
        }

        public void TrimExcess()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal T GetElement(int index)
        {
            throw new NotImplementedException();
        }

        private void SetCapacity(int capacity)
        {
            T[] destinationArray = new T[capacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, destinationArray, 0, size);
                }
                else
                {
                    Array.Copy(array, head, destinationArray, 0, array.Length - head);
                    Array.Copy(array, 0, destinationArray, array.Length - head, tail);
                }
            }
            array = destinationArray;
            head = 0;
            tail = (size == capacity) ? 0 : size;
        }

        private struct ArrayQueueEnumerator : IEnumerator<T>
        {
            private ArrayQueue<T> q;

            private int index;

            private T currentElement;

            internal ArrayQueueEnumerator(ArrayQueue<T> q)
            {
                this.q = q;
                index = -1;
                currentElement = default(T);
            }

            public T Current
            {
                get
                {
                    if (this.index < 0)
                    {
                        if (this.index == -1)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    return currentElement;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (index == -2)
                    return false;
                index++;
                if (index == q.size)
                {
                    index = -2;
                    currentElement = default(T);
                    return false;
                }
                currentElement = q.GetElement(index);
                return true;
            }

            public void Reset()
            {
                index = -1;
                currentElement = default(T);
            }

            public void Dispose()
            {
                index = -2;
                currentElement = default(T);
            }
        }
    }
}
