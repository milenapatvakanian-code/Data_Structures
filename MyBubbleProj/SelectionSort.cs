using System;
using System.Collections.Generic;
using System.Text;

namespace MyBubbleProj
{
    public class SelectionSort<T> where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            for (int i = 0; i < items.Length -1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[j].CompareTo(items[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                Swap(items, i, minIndex);
            }
        }
        private void Swap(T[] items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
