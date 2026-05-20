using MyLinkedListProj;

using System.Collections;

namespace MyPriorityQueueProj

{
    public class MyPriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        MyLinkedList<T> items = new MyLinkedList<T>();

        public void Enqueue(T item)
        {
            if (items.Count == 0)
            {
                items.Add(item);

            }
            else
            {
                MyLinkedListNode < T > current = items.Head; 
                while (current != null && current.Value.CompareTo(item)>0)
                        {
                    current = current.Next;
                    
                        }
                if (current == null)
                {
                    items.AddLast(item);
                }
                else
                {
                    items.AddBefore(current,item);
                }
                    

            }
        }
        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidCastException("THE QUEUE IS EMPTY");
            }
            T value=items.First.Value;
            items.RemoveFirst();
            return value;
        }
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
