using System;
using System.Collections.Generic;
using System.Linq;

namespace Datastructures_and_Algorithms
{
    /// <summary>
    /// Normally this data structure is called a 'hash table' or 'hashtable'.
    /// But in the case of OO languages, when they are used to store other types than structs and primitives types, they are referred to as 'hash map' or 'hashmap'.
    /// </summary>
    /// <typeparam name="T">The type stored within the hash map.</typeparam>
    public class HashMap<T>
    {
        private LinkedList<HashTableNode>[] _map;
        private int _mapSize;

        // Typically you save the value with the key, in case of hash table collisions
        internal class HashTableNode
        {
            internal T Data;
            internal string Key; 
        }

        // Constructor
        public HashMap(int hashMapSize)
        {
            _mapSize = hashMapSize;
            _map = new LinkedList<HashTableNode>[hashMapSize];

            for (int i = 0; i < hashMapSize; i++)
            {
                _map[i] = new LinkedList<HashTableNode>();
            }
        }

        public void Put(string key, T value)
        {
            int index = Hash(key) % _mapSize;

            _map[index].AddLast(new HashTableNode { Data = value, Key = key });
        }

        public T Get(string key)
        {
            int index = Hash(key) % _mapSize;

            if (_map[index].Count == 0)
            {
                return default(T);
            } else if (_map[index].Count == 1)
            {
                return _map[index].First.Value.Data;
            } else
            {
                return _map[index].First(x => x.Key.Equals(key)).Data;
            }
        }

        private int Hash(string key)
        {
            int result = 0;

            foreach (var item in key)
            {
                result += item.GetHashCode();
            }

            return result;
        }
    }
}