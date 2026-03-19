using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyBinaryTreeProj
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private MyBinaryTreeNode<T> _root;
        private int _count;

        #region Add

        public void Add(T value)
        {
            _root = AddRecursive(_root, value);
            _count++;
        }

        private MyBinaryTreeNode<T> AddRecursive(MyBinaryTreeNode<T> node, T value)
        {
            if (node == null)
                return new MyBinaryTreeNode<T>(value);

            if (value.CompareTo(node.Value) < 0)
                node.Left = AddRecursive(node.Left, value);

            else if (value.CompareTo(node.Value) > 0)
                node.Right = AddRecursive(node.Right, value);

            return node;
        }

        #endregion
        public bool Contains(T value)
        {
            return ContainsRecursive(_root, value);
        }
        private BinaryTree



        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}