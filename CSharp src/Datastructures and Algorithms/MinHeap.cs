using System;
using System.Collections.Generic;

namespace Datastructures_and_Algorithms
{
    public class MinHeap<T> where T : IEquatable<T>, IComparable<T>
    {
        private T[] _heap;
        private int _count = 0;
        private int _size;

        public int Count { get { return _count; } }

        public T this[int index]
        {
            get { return _heap[index]; }
            set { _heap[index] = value; }
        }

        private int GetLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int GetRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private bool HasLeftChild(int index) { return GetLeftChildIndex(index) < _size; }
        private bool HasRightChild(int index) { return GetRightChildIndex(index) < _size; }
        private bool HasParent(int index) { return GetParentIndex(index) >= 0; }

        public MinHeap(int arraySize)
        {
            _heap = new T[arraySize];
            _size = arraySize;
        }

        public void Add(T value)
        {
            EnsureExtraCapacity();
            _heap[_count] = value;
            _count++;
            MinHeapify();
        }

        public bool Remove(T value)
        {
            // Step 1
            if (!FindIndex(value, out int index))
                return false;

            int count = _count - 1;

            // Step 2
            _heap[index] = _heap[count];
            _heap[count] = default;
            _count--;

            if (!HasLeftChild(index)) // If the node removed was a leaf node, then there's no need to sort the heap
            {
                return true;
            }

            // Step 3
            while ((2 * index + 1) < _count && _heap[index].CompareTo(_heap[2 * index + 1]) > 0 || _heap[index].CompareTo(_heap[2 * index + 2]) > 0)
            {
                // Promote the smallest key from subtree
                if (_heap[2 * index + 1].CompareTo(_heap[2 * index + 2]) < 0 && ! (EqualityComparer<T>.Default.Equals(_heap[2 * index + 1], default)))
                {

                    // Swap the two values
                    T temp = _heap[2 * index + 1];
                    _heap[2 * index + 1] = _heap[index];
                    _heap[index] = temp;

                    if (!HasLeftChild(index * 2 + 1)) // If there are no more children, break. The reason for this check is, the while loops conditioning attempts to check a null reference
                        break;
                    // Update indexer to left child
                    index = index * 2 + 1;
                }
                else if ( ! (EqualityComparer<T>.Default.Equals(_heap[2 * index + 2], default)))
                {
                    // Swap the two values
                    T temp = _heap[2 * index + 2];
                    _heap[2 * index + 2] = _heap[index];
                    _heap[index] = temp;

                    if (!HasLeftChild(index * 2 + 2)) // If there are no more children, break. The reason for this check is, the while loops conditioning attempts to check a null reference
                        break;
                    // Update indexer to right child
                    index = index * 2 + 2;
                }
                else
                {
                    break;
                }
            }
            return true;
        }

        public bool FindIndex(T value, out int start)
        {
            start = 0;
            int nodes = 1;
            int end;
            int count;
            while (start < _count)
            {
                start = nodes - 1;
                end = nodes + start;
                count = 0;
                while (start < _count && start < end)
                {
                    if (value.CompareTo(_heap[start]) == 0)
                    {
                        return true;
                    }
                    else if (value.CompareTo(_heap[(start - 1) / 2]) > 0 && value.CompareTo(_heap[start]) < 0) // Consider a min-heap that doesn't contain the value 5. We can only rule that the value is not in the heap if 5 > the parent of the current node being inspected and < the current node being inspected for all nodes at the current level we are traversing. If this is the case then 5 cannot be in the heap so we can provide an answer without traversing the rest of the heap.
                    {
                        count++;
                    }
                    start++;
                }
                if (count == nodes)
                {
                    return false;
                }
                nodes *= 2;
            }
            return false;
        }

        private void MinHeapify()
        {
            int index = _count - 1;
            while (index > 0 && _heap[index].CompareTo(_heap[(index - 1) / 2]) < 0) // (Index - 1) / 2 results in the parent of the node to the given index
            {
                // Swap the two values
                T temp = _heap[(index - 1) / 2];
                _heap[(index - 1) / 2] = _heap[index];
                _heap[index] = temp;
                // Update indexer
                index = (index - 1) / 2;
            }
        }

        private void EnsureExtraCapacity()
        {
            if (_count == _size)
            {
                T[] destinationArray = new T[_size * 2];
                Array.Copy(_heap, destinationArray, _size);
                _heap = destinationArray;
                _size *= 2;
            }
        }

        public override string ToString()
        {
            return String.Join(',', _heap);
        }
    }
}
