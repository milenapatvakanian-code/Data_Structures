using MyBinaryTreeProj;
using MyLinkedListProj;
using MyQueueProj;
using MyStackProj;


using PostfixProj;
using System.Collections;
using MyHashTableAlgorithms;
using MySetProj;
using MyBubbleProj;


namespace Testing_DataStructures;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("---TESTING--");


        #region LinkedList
        var linkedList = new MyLinkedList<string>();

        linkedList.AddFirst("1");
        linkedList.AddFirst("3");
        linkedList.AddFirst("5");
        linkedList.AddFirst("7");
        linkedList.AddFirst("9");

        foreach (var item in linkedList)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        Console.WriteLine();
        linkedList.RemoveFirst();



        foreach (var item in linkedList)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        #endregion LinkedList

        #region Stack
        Console.WriteLine("---Stack---");
        var stack = new MyStack<string>();
        stack.Push("1");
        stack.Push("2");
        stack.Push("3");
        stack.Push("4");
        foreach (var item in stack)
        {
            Console.WriteLine($"Current Item: {item}");
        }
        Console.WriteLine();
        Console.WriteLine("Top:" + stack.Peek());
        stack.Pop();
        Console.WriteLine("After Pop Top:" + stack.Peek());

        #endregion Stack

        #region Queue
        Console.WriteLine("---Queue---");

        var queue = new MyQueue<string>();

        queue.Enqueue("X");
        queue.Enqueue("Y");
        queue.Enqueue("Z");
        queue.Enqueue("W");

        Console.WriteLine("Queue Items:");

        foreach (var item in queue)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        Console.WriteLine();

        Console.WriteLine("Front of Queue: " + queue.Peek());

        queue.Dequeue();

        Console.WriteLine("After Dequeue Front: " + queue.Peek());

        queue.Dequeue();

        Console.WriteLine("After Dequeue Front: " + queue.Peek());

        #endregion Queue

        //#region Postfix

        //Console.WriteLine("---Postfix---");

        //string expression = "(5 2) + 3 *)";

        //int result = PostfixCalculator.Evaluate(expression);

        //Console.WriteLine("Expression: " + expression);
        //Console.WriteLine("Result: " + result);

        //#endregion

        #region BinaryTree

        Console.WriteLine("---Binary Tree---");

        var tree = new MyBinaryTree<int>();

        // Add elements
        tree.Add(4);
        tree.Add(2);
        tree.Add(6);
        tree.Add(1);
        tree.Add(3);
        tree.Add(5);
        tree.Add(7);

        // InOrder (should be sorted)
        Console.WriteLine("InOrder:");
        foreach (var item in tree.InOrder())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // PreOrder
        Console.WriteLine("PreOrder:");
        foreach (var item in tree.PreOrder())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // PostOrder
        Console.WriteLine("PostOrder:");
        foreach (var item in tree.PostOrder())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Remove leaf
        Console.WriteLine("Remove (2):");
        tree.Remove(2);
        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Remove node with one child
        Console.WriteLine("Remove node with one child (3):");
        tree.Remove(3);
        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Remove node with two children
        Console.WriteLine("Remove node with two children (5):");
        tree.Remove(5);
        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        #endregion BinaryTree

        #region BubbleSort
        Console.WriteLine("___BubbleSort___");

        var bubbleSort = new MyBubbleSort<int>();
        int[] bubbleArray = { 5, 2, 9, 1,  6 };
        bubbleSort.Sort(bubbleArray);
        Console.WriteLine("Sorted Array:");
        foreach (var item in bubbleArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        #endregion BubbleSort

        #region InsertionSort
        Console.WriteLine("___InsertionSort___");

        var insertionSort = new MyInsertion<int>();
        int[] insertionArray = { 5, 18, 9, 1, 0 };
        insertionSort.Sort(insertionArray);

        Console.WriteLine("Sorted Array:");
        foreach (var item in insertionArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        #endregion

        #region SelectionSort
        Console.WriteLine("___SelectionSort___");

        var selectionSort = new SelectionSort<int>();
        int[] selectionArray = { 11, 8, 20, 1, 10 };

        selectionSort.Sort(selectionArray);

        Console.WriteLine("Sorted Array:");
        foreach (var item in selectionArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        #endregion

        #region MergeSort
        Console.WriteLine("___MergeSort___");

        var mergeSort = new MyMergeSort<int>();
        int[] mergeArray = { 5, 18, 9, 1, 0 };

        mergeSort.Sort(mergeArray);

        Console.WriteLine("Sorted Array:");
        foreach (var item in mergeArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        #endregion

        #region QuickSort
        Console.WriteLine("___QuickSort___");

        var quickSort = new MyQuickSort<int>();
        int[] array = { 8, 2, 4, 7, 1, 3, 9, 6, 5 };  

        quickSort.Sort(array);

        Console.WriteLine("Sorted Array:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        #endregion


    }
}
