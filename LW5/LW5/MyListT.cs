using System;
using System.Collections;
using System.Collections.Generic;

namespace LW5
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;
        private int capacity;

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
            this.capacity = capacity;
            items = new T[capacity];
            count = 0;
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

        // property
        public int Count => count;

        // collection init
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
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
            items = new T[4];
            count = 0;
            capacity = 4;
        }

        // "are item in items"?
        public bool Contains(T item) 
        {
            for (int i = 0; i<count; i++)
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
            for (int i = 0; i<count; i++)
                if (EqualityComparer<T>.Default.Equals(items[0], item))
                    return i;
            return -1;
        }

        // remove by index
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range");

            for (int i = index;  i < count; i++)
            {
                items[i] = items[i+1];
            }
            count--;
            items[count] = default(T);
        }
    }
}
