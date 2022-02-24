using System;
using System.Collections;
using System.Collections.Generic;

namespace Datastructures_and_Algorithms
{
    public class Set<T> where T: IEquatable<T>
    {
        private List<T> _values; // Depending on the space allocation differences and dynamic requirements. This field might be better implemented as an array. Although that brings up the factor of dynamic resizing of said array.

        public List<T> Values { get { return _values; } }

        public Set()
        {
            _values = new List<T>();
        }

        public void Add(T value)
        {
            if (!_values.Contains(value))
            {
                _values.Add(value);
            }
        }

        public void Remove(T value)
        {
            _values.Remove(value);
        }

        // The union algorithm has a run time of O(m + n) where m is the number of items in the first set and n is the number of items in the second set.
        // This runtime applies only to sets that exhibit O(1) insertions.
        public Set<T> Union(Set<T> set1, Set<T> set2)
        {
            if (set1 is null || set2 is null)
            {
                throw new ArgumentNullException();
            }

            Set<T> union = new Set<T>();
            foreach (var item in set1._values)
            {
                union.Add(item);
            }
            foreach (var item in set2._values)
            {
                union.Add(item);
            }
            return union;
        }

        public Set<T> Intersection(Set<T> set1, Set<T> set2)
        {
            if (set1 is null || set2 is null)
            {
                throw new ArgumentNullException();
            }

            Set<T> smallerSet;
            Set<T> intersection = new Set<T>();

            if (set1._values.Count < set2._values.Count) // We only need to go through the smallest set, because if we have exhausted all the items in the smaller of the two sets, then there are no more items that are members of both sets.
            {
                smallerSet = set1;
            } else
            {
                smallerSet = set2;
            }

            foreach (var item in smallerSet._values)
            {
                intersection.Add(item);
            }

            return intersection;
        }
    }
}
