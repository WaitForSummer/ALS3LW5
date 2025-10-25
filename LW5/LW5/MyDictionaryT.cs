//using System;
//using System.Collections;
//using System.Collections.Generic;

//namespace LW5
//{
//    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
//    {
//        // init fields
//        private struct MyObject
//        {
//            public int hashCode;
//            public int nextI;
//            public TKey key;
//            public TValue value;
//        }

//        private MyObject[] myObjects;
//        private int[] buckets;
//        private int count;
//        private int capacity;
//        private int freeL;
//        private int freeC;

//        // constructor
//        public MyDictionary() : this(0) { }
//        public MyDictionary(int capacity)
//        {
//            // init base params
//            if (capacity < 0) 
//            { 
//                this.capacity = 4; 
//            }
//            else
//            {
//                this.capacity = capacity;
//            }

//            buckets = new int[this.capacity];
//            myObjects = new MyObject[this.capacity];

//            for (int i = 0; i < this.capacity; i++) 
//                buckets[i] = -1;

//            freeL = -1;
//            count = 0;
//            freeC = 0;
//        }
//    }
//}
