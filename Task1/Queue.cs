using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                throw new ArgumentNullException($"{collection} is null.");
            array = new T[defaultCapacity];

            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while(enumerator.MoveNext())
                    Enqueue(enumerator.Current);
            }
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void SetCapacity(int capacity)
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
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
