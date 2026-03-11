using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyStackArrayProj
{
    internal class MyStackArray
    {
        class MyStack<T>
        {
            private T[] elements;
            private int top;
            private int max;

            public MyStack(int size)
            {
                elements = new int[size];
                top = -1; // -1 means the stack is empty
                max = size;
            }

            public void Push(int item)
            {
                if (top == max - 1)
                {
                    Console.WriteLine("Stack Overflow!"); // No more room
                    return;
                }
                elements[++top] = item; // Increment top, then add item
            }

            public int Pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Stack Underflow!");
                    return -1;
                }
                return elements[top--]; // Return item, then decrement top
            }

            public int Peek()
            {
                return elements[top];
            }

            public void Display()
            {
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(elements[i]);
                }
            }
        }

        class Program
        {
            static void Main()
            {
                MyStack stack = new MyStack(5); // Stack with capacity of 5

                stack.Push(10);
                stack.Push(20);
                stack.Push(30);

                Console.WriteLine("Current Stack:");
                stack.Display();

                Console.WriteLine("Top element: " + stack.Peek());
                Console.WriteLine("Removed: " + stack.Pop());

                Console.WriteLine("Stack after Pop:");
                stack.Display();
            }
        }
    }
}
