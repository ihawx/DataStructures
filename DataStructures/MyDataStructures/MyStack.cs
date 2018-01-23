using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyStack<T>
    {

        Node<T> Head;
        private int InternalCount = 0;
        public int Count { get => InternalCount; }

        public MyStack()
        {
            Head = null;
        }

        public MyStack(T data)
        {
            Head = new Node<T>
            {
                Data = data
            };
        }

        public void Push(T data)
        {
            Node<T> node = new Node<T> { Data = data };
            node.Next = Head;
            Head = node;
            InternalCount++;
        }

        public T Peek()
        {
            return Head.Data;
        }

        public T Pop()
        {
            if (Head == null)
            {
                throw new Exception("The stack is empty");
            }
            else
            {
                T result = Head.Data;
                Head = Head.Next;
                InternalCount--;
                return result;
            }
        }

        private class Node<U>
        {
            internal U Data;
            internal Node<U> Next;
        }
    }
}
