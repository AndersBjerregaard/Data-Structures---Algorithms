using System;

namespace Datastructures_and_Algorithms
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public Node(T t)
            {
                Data = t;
            }

            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public int Count;

        public void Insert(T value)
        {
            // Pass potential custom type checks for type T

            if (root is null)
            {
                root = new Node(value);
            } else
            {
                InsertNode(root, value);
            }

            Count++;
        }

        // Recursive function
        private void InsertNode(Node current, T value)
        {
            if (value.CompareTo(current.Data) < 0)
            {
                if (current.Left is null)
                {
                    current.Left = new Node(value);
                } else
                {
                    InsertNode(current.Left, value);
                }
            }
            else
            {
                if (current.Right is null)
                {
                    current.Right = new Node(value);
                } else
                {
                    InsertNode(current.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            if (root is null)
            {
                return false;
            }
            if (root.Data.CompareTo(value) == 0)
            {
                return true;
            } else if (value.CompareTo(root.Data) < 0)
            {
                return Contains(root.Left, value);
            } else
            {
                return Contains(root.Right, value);
            }
        }

        // Recursive function
        private bool Contains(Node current, T value)
        {
            if (current is null)
            {
                return false;
            }
            if (current.Data.CompareTo(value) == 0)
            {
                return true;
            }
            else if (value.CompareTo(current.Data) < 0)
            {
                return Contains(current.Left, value);
            } else
            {
                return Contains(current.Right, value);
            }
        }

        public bool Remove(T value)
        {
            var nodeToRemove = FindNode(root, value);

            if (nodeToRemove is null) return false; // Value not in BST

            var parent = FindParent(value, root);

            if (Count == 1)
            {
                root = null;
            } else if (nodeToRemove.Left is null && nodeToRemove.Right is null) // The value to remove is a leaf node
            {
                if (nodeToRemove.Data.CompareTo(parent.Data) < 0)
                {
                    parent.Left = null;
                } else
                {
                    parent.Right = null;
                }
            } else if (nodeToRemove.Left is null && !(nodeToRemove.Right is null)) // The value to remove has a right subtree, but no left subtree
            {
                if (nodeToRemove.Data.CompareTo(parent.Data) < 0)
                {
                    parent.Left = nodeToRemove.Right;
                } else
                {
                    parent.Right = nodeToRemove.Right;
                }
            } else if (!(nodeToRemove.Left is null) && nodeToRemove.Right is null) // The value to remove has a left subtree, but no right subtree
            {
                if (nodeToRemove.Data.CompareTo(parent.Data) < 0)
                {
                    parent.Left = nodeToRemove.Left;
                } else
                {
                    parent.Right = nodeToRemove.Left;
                }
            } else // The value to remove has both a left and a right subtree in which case we promote the largest value in the left subtree
            {
                var largestValue = nodeToRemove.Left;
                while (!(largestValue.Right is null)) // Find the largest value in the left subtree of nodeToRemove
                {
                    largestValue = largestValue.Right;
                }
                // Set the parents' Right pointer of largestValue to null
                FindParent(largestValue.Data, root).Right = null;

                nodeToRemove.Data = largestValue.Data;
            }

            Count++;

            return true;
        }

        // Recursive function
        private Node FindParent(T value, Node current)
        {
            if (value.CompareTo(root.Data) == 0)
            {
                return null;
            }
            if (value.CompareTo(root.Data) < 0)
            {
                if (root.Left is null)
                {
                    return null;
                } else if (root.Left.Data.CompareTo(value) == 0)
                {
                    return root;
                } else
                {
                    return FindParent(value, root.Left);
                }
            } else
            {
                if (root.Right is null)
                {
                    return null;
                } else if (root.Right.Data.CompareTo(value) == 0)
                {
                    return root;
                } else
                {
                    return FindParent(value, root.Right);
                }
            }
        }

        // Recursive function
        private Node FindNode(Node current, T value)
        {
            if (current is null)
            {
                return null;
            }
            if (current.Data.CompareTo(value) == 0)
            {
                return current;
            } else if (value.CompareTo(current.Data) < 0)
            {
                return FindNode(current.Left, value);
            } else
            {
                return FindNode(current.Right, value);
            }
        }
    }
}
