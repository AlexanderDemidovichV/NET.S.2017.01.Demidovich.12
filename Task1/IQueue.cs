using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    interface IQueue<T>: IEnumerable<T>
    {
        int Count { get; }

        void Clear();

        bool Contains(T item);

        void CopyTo(T[] array, int arrayIndex);

        T Dequeue();

        void Enqueue(T item);

        T[] ToArray();

        void TrimExcess();

        T Peek();

        void SetCapacity(int capacity);
    }
}
