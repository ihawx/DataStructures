using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class QueueTwoStacks<T>
    {
        private Stack<T> firstStack = new Stack<T>();
        private Stack<T> secondStack = new Stack<T>();

        public int Count { get => firstStack.Count + secondStack.Count; }

        public void Enqueue(T data)
        {
            firstStack.Push(data);
        }

        public T Dequeue()
        {
            
            if (secondStack.Count == 0)
            {
                while (firstStack.Count > 1)
                {
                    secondStack.Push(firstStack.Pop());
                }
                return firstStack.Pop();
            }
            else
            {
                return secondStack.Pop();
            }
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            if (secondStack.Count == 0)
            {
                return firstStack.ToArray()[firstStack.Count - 1];
            }
            else
            {
                return secondStack.Peek();
            }
        }
    }
}
