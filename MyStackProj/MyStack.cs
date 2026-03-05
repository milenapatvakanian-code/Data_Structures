using MyLinkedListProj;
using System.Collections;   
namespace MyStackProj;

public class MyStack<T> : IEnumerable<T>
{
    public MyLinkedList<T> MyStackItems = new MyLinkedList<T>();
    public MyStack()
    {

    }

    
    public MyStack(ICollection<T> collection)
    {
        foreach (var item in collection)
        {
            Push(item);
        }
    }

    public void Push(T value)
    {
        MyStackItems.AddFirst(value);
    }

    public T Pop()
    {
        var itemToRemove = MyStackItems.Head.Value;

        MyStackItems.RemoveFirst<T>();

        return itemToRemove;
    }

    public T Peek()
    {
        return MyStackItems.Head.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return MyStackItems.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}



