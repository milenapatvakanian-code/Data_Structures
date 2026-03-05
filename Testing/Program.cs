using MyLinkedListProj;
using MyStackProj;

namespace Testing_DataStructures;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("=======Hello Void=======");

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
        linkedList.RemoveFirst<string>();



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
    }
}