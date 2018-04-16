using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeLogic
{
    /// <summary>
    /// The class represents a simple binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of tree elements.</typeparam>
    public class BinarySearchTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        #region private fields

        private BinaryTreeNode<T> root;
        private Comparison<T> comparision;
        private IEnumerable<T> enumerable;

        #endregion

        #region ctors

        /// <inheritdoc />
        /// <summary>
        /// Initializes an empty tree with comparator.
        /// </summary>
        /// <param name="orderComparer">Tree elements comparer.</param>
        /// <exception cref="T:System.ArgumentNullException">Exception thrown when <paramref name="orderComparer" /> is null.</exception>
        public BinarySearchTree(IComparer<T> orderComparer) : this(orderComparer.Compare)
        {
        }

        /// <summary>
        /// Initializes an empty tree with comparator.
        /// </summary>
        /// <param name="orderComparer">Tree elements comparer.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when <paramref name="orderComparer"/> is null.</exception>
        public BinarySearchTree(Comparison<T> orderComparer)
        {
            this.OrderComparer = orderComparer;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes an empty tree with comparator and adds enumeration elements to it.
        /// </summary>
        /// <param name="orderComparer">Tree elements comparer.</param>
        /// <param name="enumerable">Tree elements.</param>
        /// <exception cref="T:System.ArgumentNullException">Exception thrown when <paramref name="orderComparer" />
        /// or <paramref name="enumerable" /> is null.</exception>
        public BinarySearchTree(IComparer<T> orderComparer, IEnumerable<T> enumerable)
            : this(orderComparer.Compare, enumerable)
        {
        }

        public BinarySearchTree(Comparison<T> orderComparer, IEnumerable<T> enumerable) : this(orderComparer)
        {
            this.enumerable = enumerable;
        }

        #endregion

        #region public methods

        #region collection implements

        /// <summary>
        /// Return number of element in tree.
        /// </summary>
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        /// <summary>
        /// Add data in tree.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        /// <exception cref="ArgumentNullException">Throws when item is null.</exception>
        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.Add(ref root, item);
            Count++;
        }

        /// <summary>
        /// Clear tree.
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Define whether tree contains data.
        /// </summary>
        /// <param name="item">Item to be checked.</param>
        public bool Contains(T item) => this.Contains(root, item);

        /// <summary>
        /// Copy elements of tree in inorder traversal to array.
        /// </summary>
        /// <param name="array">Array to which elements are copied.</param>
        /// <param name="arrayIndex">Index from which starts copying.</param>
        /// <exception cref="ArgumentNullException">Throws when array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws when index less then null.</exception>
        /// <exception cref="ArgumentException">Throws when index is invalid.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"{nameof(arrayIndex)} must be greater than or equal to 0.");
            }

            try
            {
                var temp = this.ToArray();
                Array.Copy(temp, 0, array, arrayIndex, temp.Length);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Remove data from tree.
        /// </summary>
        /// <param name="item">Item to be removed.</param>
        /// <returns>True if item is sucessfully removed, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Throws when item is null.</exception>
        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            var parent = root;
            var isRemoved = this.Remove(ref root, ref parent, item);
            if (isRemoved)
            {
                Count--;
            }

            return isRemoved;
        }

        #endregion

        #region enumerable implements

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        #endregion

        public T[] ToArray()
        {
            var result = new T[Count];
            int i = 0;
            foreach (var item in this)
            {
                result[i++] = item;
            }

            return result;
        }

        #endregion

        #region private methods

        private void Add(ref BinaryTreeNode<T> root, T item)
        {
            if (ReferenceEquals(root, null))
            {
                root = new BinaryTreeNode<T>(null, null, item);
                return;
            }

            var comparisonResult = OrderComparer(root.Data, item);

            if (comparisonResult == 0)
            {
                root.Data = item;
                return;
            }

            if (comparisonResult > 0)
            {
                Add(ref root.Left, item);
                return;
            }

            Add(ref root.Right, item);
        }

        private bool Contains(BinaryTreeNode<T> root, T item)
        {
            while (true)
            {
                if (ReferenceEquals(root, null))
                {
                    return false;
                }

                var comparisonResult = OrderComparer(root.Data, item);
                if (comparisonResult == 0)
                {
                    return true;
                }

                if (comparisonResult > 0)
                {
                    root = root.Left;
                    continue;
                }

                root = root.Right;
            }
        }

        private Comparison<T> OrderComparer
        {
            get
            {
                return comparision;
            }

            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(OrderComparer));
                }

                comparision = value;
            }
        }

        private bool Remove(ref BinaryTreeNode<T> root, ref BinaryTreeNode<T> parent, T item)
        {
            if (ReferenceEquals(root, null))
            {
                return false;
            }

            var comparisonResult = OrderComparer(item, root.Data);
            if (comparisonResult < 0)
            {
                parent = root;
                return Remove(ref root.Left, ref parent, item);
            }

            if (comparisonResult > 0)
            {
                parent = root;
                return Remove(ref root.Right, ref parent, item);
            }

            if (ReferenceEquals(root.Left, null) && ReferenceEquals(root.Right, null))
            {
                root = null;
                return true;
            }

            if (!ReferenceEquals(root.Left, null) && ReferenceEquals(root.Right, null))
            {
                root = root.Left;
                return true;
            }

            if (ReferenceEquals(root.Left, null))
            {
                root = root.Right;
                return true;
            }

            if (ReferenceEquals(root.Right.Left, null))
            {
                root.Data = root.Right.Data;
                root.Right = root.Right.Right;
                return true;
            }

            var temp = root.Right;
            while (!ReferenceEquals(temp.Left, null))
            {
                parent = temp;
                temp = temp.Left;
            }

            var data = temp.Data;
            Remove(ref root, ref parent, data);
            root.Data = data;
            return true;
        }

        #endregion

        #region travels

        /// <summary>
        /// Return inorder traversal.
        /// </summary>
        public IEnumerable<T> InOrder
        {
            get
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> temp = root;
                while (stack.Count != 0 || temp != null)
                {
                    if (temp != null)
                    {
                        stack.Push(temp);
                        temp = temp.Left;
                    }
                    else
                    {
                        temp = stack.Pop();
                        yield return temp.Data;
                        temp = temp.Right;
                    }
                }
            }
        }

        /// <summary>
        /// Return preorder traversal.
        /// </summary>
        public IEnumerable<T> PreOrder
        {
            get
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                stack.Push(root);
                while (true)
                {
                    if (stack.Count == 0) break;

                    BinaryTreeNode<T> temp = stack.Pop();
                    yield return temp.Data;

                    if (temp.Right != null)
                    {
                        stack.Push(temp.Right);
                    }

                    if (temp.Left != null)
                    {
                        stack.Push(temp.Left);
                    }
                }
            }
        }

        /// <summary>
        /// Return postorder traversal.
        /// </summary>
        public IEnumerable<T> PostOrder => RecursionPostOrder(root);

        private static IEnumerable<T> RecursionPostOrder(BinaryTreeNode<T> node)
        {
            if (node == null) yield break;

            if (node.Left != null)
            {
                foreach (var item in RecursionPostOrder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in RecursionPostOrder(node.Right))
                {
                    yield return item;
                }
            }
            yield return node.Data;
        }

        #endregion

        #region private class

        /// <summary>
        /// Class that represents node for tree.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        private class BinaryTreeNode<T>
        {
            /// <summary>
            /// Reference to the left node.
            /// </summary>
            internal BinaryTreeNode<T> Left;

            /// <summary>
            /// Reference to the right node.
            /// </summary>
            internal BinaryTreeNode<T> Right;

            /// <summary>
            /// Value of node.
            /// </summary>
            internal T Data;

            /// <summary>
            /// Initializes a new instance of node with data and neighbors.
            /// </summary>
            /// <param name="left">Left node.</param>
            /// <param name="right">Right node.</param>
            /// <param name="data">Data of value.</param>
            public BinaryTreeNode(BinaryTreeNode<T> left, BinaryTreeNode<T> right, T data)
            {
                Left = left;
                Right = right;
                Data = data;
            }
        }

        #endregion
    }
}
