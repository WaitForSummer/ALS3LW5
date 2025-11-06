using System;
using System.Collections;
using System.Collections.Generic;

namespace LW5
{
    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        // init fields
        private struct MyObject
        {
            public int hashCode;
            public int nextI;
            public TKey key;
            public TValue value;
        }

        private MyObject[] myObjects;
        private int[] buckets;
        private int count;
        private int capacity;
        private int freeL;
        private int freeC;

        // constructor
        public MyDictionary() : this(0) { }
        public MyDictionary(int capacity)
        {
            // init base params
            if (capacity < 0)
            {
                this.capacity = 4;
            }
            else if (capacity == 0)
            {
                this.capacity = 4;
            }
            else
            {
                this.capacity = capacity;
            }
            buckets = new int[this.capacity];
            myObjects = new MyObject[this.capacity];

            for (int i = 0; i < this.capacity; i++)
                buckets[i] = -1;

            // init of list of free cells 
            freeL = -1;
            count = 0;
            freeC = 0;
            //filling free cells list
            for (int i = 0; i < this.capacity; i++)
            {
                myObjects[i].nextI = freeL;
                freeL = i;
                freeC++;
            }
        }

        //additional methods
        // hash code method
        private int GetHash(TKey key)
        {
            return EqualityComparer<TKey>.Default.GetHashCode(key) & 0x7FFFFFFF;
        }

        // get free index method
        private int GetFreeInd()
        {
            if (freeL == -1)
                return -1;

            int index = freeL;
            freeL = myObjects[index].nextI;
            freeC--;
            return index;
        }

        private void Resize()
        {
            int oldCapacity = capacity;
            int newCapacity = oldCapacity == 0 ? 4 : oldCapacity * 2;
            MyObject[] newMyObjects = new MyObject[newCapacity];
            int[] newBuckets = new int[newCapacity];

            for (int i = 0; i < newCapacity; i++)
                newBuckets[i] = -1;

            // old buckets
            for (int i = 0; i < oldCapacity; i++)
            {
                newMyObjects[i] = myObjects[i];
                
                if (myObjects[i].hashCode != 0)
                {
                    int newBucketIndex = myObjects[i].hashCode & newCapacity;
                    newMyObjects[i].nextI = newBuckets[newBucketIndex];
                    newBuckets[newBucketIndex] = i;
                }
            }

            // new free cells
            freeL = -1;
            freeC = newCapacity - count;
            for (int i = newCapacity - 1; i >= oldCapacity; i--)
            {
                newMyObjects[i].nextI = freeL;
                newMyObjects[i].hashCode = 0;
                freeL = i;
            }
            
            // adding old free cells
            for (int i = 0; i < oldCapacity; i++)
            {
                if (myObjects[i].hashCode == 0)
                {
                    newMyObjects[i].nextI = freeL;
                    freeL = i;
                }
            }

            // update refs
            myObjects = newMyObjects;
            buckets = newBuckets;
            capacity = newCapacity;
        }

        // find index method
        private int FindInd(TKey key)
        {
            if (buckets == null) return -1;

            int hashCode = GetHash(key);
            int targetBucket = hashCode % buckets.Length;

            int i = buckets[targetBucket];
            while (i != -1)
            {
                // checking hashCode and key
                if (myObjects[i].hashCode == hashCode &&
                    EqualityComparer<TKey>.Default.Equals(myObjects[i].key, key))
                {
                    return i;
                }
                i = myObjects[i].nextI;
            }
            return -1;
        }

        // Methods
        // adding method
        public void Add(TKey key, TValue value)
        {
            // calc hash
            int hashCode = GetHash(key);

            int targetBucket = hashCode % buckets.Length;

            int i = buckets[targetBucket];

            while (i != -1)
            {
                if (myObjects[i].hashCode == hashCode && EqualityComparer<TKey>.Default.Equals(myObjects[i].key, key))
                {
                    throw new ArgumentException("An element with the same key already exists in the MyDictionary.");
                }
                i = myObjects[i].nextI;
            }

            // check key
            int newIndex = GetFreeInd();
            if (newIndex == -1)
            {
                Resize();
                targetBucket = hashCode % buckets.Length;
                newIndex = GetFreeInd();
            }

            // fill new object
            myObjects[newIndex].hashCode = hashCode;
            myObjects[newIndex].key = key;
            myObjects[newIndex].value = value;

            // add to bucket
            myObjects[newIndex].nextI = buckets[targetBucket];
            buckets[targetBucket] = newIndex;

            count++;
        }

        // indexer
        public TValue this[TKey key]
        {
            get
            {
                int index = FindInd(key);
                // check index
                if (index == -1) 
                {
                    throw new KeyNotFoundException("The given key was not present in the MyDictionary.");
                }
                return myObjects[index].value;
            }
            set
            {
                int index = FindInd(key);
                if (index == -1)
                {
                    Add(key, value);
                }
                else
                {
                    myObjects[index].value = value;
                }
            }
        }

        // properties
        public int Count => count;

        // enumerator
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (myObjects[i].hashCode != 0)
                {
                    yield return new KeyValuePair<TKey, TValue>(myObjects[i].key, myObjects[i].value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void DebugInfo()
        {
            Console.WriteLine($"--- Debug Info ---");
            Console.WriteLine($"Count: {Count}, Capacity: {capacity}");
            Console.WriteLine($"FreeList: {freeL}, FreeCount: {freeC}");
            Console.WriteLine("Active entries:");
            for (int i = 0; i < capacity; i++)
            {
                if (myObjects[i].hashCode != 0)
                {
                    Console.WriteLine($"  [{i}] Key: '{myObjects[i].key}', Value: {myObjects[i].value}, Hash: {myObjects[i].hashCode}, Next: {myObjects[i].nextI}");
                }
            }
            Console.WriteLine("--- End Debug ---");
        }
    }
}
