using MyLinkedListProj;
using MyStackProj;
using MyQueueProj;
using PostfixProj;


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
        stack.Push("A");
        stack.Push("B");
        stack.Push("C");
        stack.Push("D");
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
        
        #region Postfix

        Console.WriteLine("---Postfix---");

        string expression = "3 10 7 * +";

        int result = PostfixCalculator.Evaluate(expression);

        Console.WriteLine("Expression: " + expression);
        Console.WriteLine("Result: " + result);

        #endregion
    }
}