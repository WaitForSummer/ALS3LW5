using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LW5
{
    public class MyList<T> : IEnumerable<T>
    {
        // init fields
        private T[] items;
        private int count;
        private int capacity;

        // properties and methods
        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        // adding method
        public void Add(T item)
        {
            if (count == capacity)
            {
                T[] newItems = new T[capacity * 2];
                Array.Copy(items, newItems, count);
                items = newItems;
                capacity *= 2;
            }
            items[count] = item;
            count++;
        }

        // collection init
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Collection is null");

            foreach (var item in collection)
                Add(item);
        }

        // constructor
        public MyList()
        {
            capacity = 4;
            items = new T[capacity];
            count = 0;
        }

        // constructor w capacity
        public MyList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be > 0");

            this.capacity = capacity;
            items = new T[capacity];
            count = 0;
        }

        // constructor w collection
        public MyList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Collection is null");

            items = collection.ToArray();
            count = items.Length;
            capacity = Math.Max(count, 4);
        }

        // user indexator
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index out of range");
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Index out of range");
                items[index] = value;
            }
        }

        // realization of IEnumarable
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // additing methods for comfotability
        public void Clear()
        {
            if (count > 0)
            {
                Array.Clear(items, 0, count);
            }
            count = 0;
        }

        // "are item in items"?
        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                // look if item in items
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                    return true;
            }
            return false;
        }

        // return index
        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                    return i;
            return -1;
        }

        // remove by index
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range");

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
            items[count] = default(T);
        }

        // remove by value
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {

                RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
