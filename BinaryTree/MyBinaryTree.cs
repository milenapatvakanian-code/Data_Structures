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

    //In-Order
    public List<T> InOrder()
    {
        var result = new List<T>();
        InOrder(Root, result);
        return result;
    }

    private void InOrder(MyBinaryTreeNode<T> node, List<T> result)
    {
        if (node == null)
            return;

        InOrder(node.Left, result);
        result.Add(node.Value);
        InOrder(node.Right, result);
    }

    //Pre-Order
    public List<T> PreOrder()
    {
        var result = new List<T>();
        PreOrder(Root, result);
        return result;
    }
    
   
    private void PreOrder(MyBinaryTreeNode<T> node, List<T> result)
    {
        if (node == null)
            return;

        result.Add(node.Value);
        PreOrder(node.Left, result);
        PreOrder(node.Right, result);
    }

    //Post-Order
    public List<T> PostOrder()
    {
        var result = new List<T>();
        PostOrder(Root, result);
        return result;
    }

    private void PostOrder(MyBinaryTreeNode<T> node, List<T> result)
    {
        if (node == null)
            return;

        PostOrder(node.Left, result);
        PostOrder(node.Right, result);
        result.Add(node.Value);
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