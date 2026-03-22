using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBinaryTreeProj;

public class MyBinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private MyBinaryTreeNode<T> Root { get; set; }
    private int Count;

    #region Add

    public void Add(T value)
    {
        Root = Add(Root, value);
        Count++;
    }

    private MyBinaryTreeNode<T> Add(MyBinaryTreeNode<T> node, T value)
    {
        if (node == null)
            return new MyBinaryTreeNode<T>(value);

        if (value.CompareTo(node.Value) < 0)
            node.Left = Add(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = Add(node.Right, value);

        return node;
    }

    #endregion

    #region Remove

    public void Remove(T value)
    {
        Root = Remove(Root, value);
    }

    private MyBinaryTreeNode<T> Remove(MyBinaryTreeNode<T> node, T value)
    {
        if (node == null)
            return null;

        int compare = value.CompareTo(node.Value);

        if (compare < 0)
            node.Left = Remove(node.Left, value);
        else if (compare > 0)
            node.Right = Remove(node.Right, value);
        else
        {
            // No children
            if (node.Left == null && node.Right == null)
            {
                Count--;
                return null;
            }

            // One child
            if (node.Left == null)
            {
                Count--;
                return node.Right;
            }

            if (node.Right == null)
            {
                Count--;
                return node.Left;
            }

            // Two children
            MyBinaryTreeNode<T> min = FindMin(node.Right);
            node.Value = min.Value;
            node.Right = Remove(node.Right, min.Value);
        }

        return node;
    }

    private MyBinaryTreeNode<T> FindMin(MyBinaryTreeNode<T> node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    #endregion

    #region Traversals

    // In-order 
    public IEnumerable<T> InOrder()
    {
        return InOrder(Root);
    }

    private IEnumerable<T> InOrder(MyBinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var left in InOrder(node.Left))
                yield return left;

            yield return node.Value;

            foreach (var right in InOrder(node.Right))
                yield return right;
        }
    }

    // Pre-order (Root, Left, Right)
    public IEnumerable<T> PreOrder()
    {
        return PreOrder(Root);
    }

    private IEnumerable<T> PreOrder(MyBinaryTreeNode<T> node)
    {
        if (node != null)
        {
            yield return node.Value;

            foreach (var left in PreOrder(node.Left))
                yield return left;

            foreach (var right in PreOrder(node.Right))
                yield return right;
        }
    }

    // Post-order (Left, Right, Root)
    public IEnumerable<T> PostOrder()
    {
        return PostOrder(Root);
    }

    private IEnumerable<T> PostOrder(MyBinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var left in PostOrder(node.Left))
                yield return left;

            foreach (var right in PostOrder(node.Right))
                yield return right;

            yield return node.Value;
        }
    }

    #endregion

    #region IEnumerable

    public IEnumerator<T> GetEnumerator()
    {
        return InOrder().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}