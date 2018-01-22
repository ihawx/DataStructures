using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class MyLinkedList<T>
    {
        private Node<T> head = null;
        public int Length { get => GetLength(); }

        // Constructors
        public MyLinkedList()
        {
            head = null;
        }

        public MyLinkedList(T data)
        {
            head = new Node<T>
            {
                Data = data
            };
        }

        public MyLinkedList(ICollection<T> dataEnumerable)
        {
            foreach (T element in dataEnumerable)
            {
                Insert(element);
            }
        }
        // Endof: Constructors


        /// <summary>
        /// Removes all elements from list
        /// </summary>
        public void Clear()
        {
            head = null;
        }

        /// <summary>
        /// Add an element to the end of the list.
        /// </summary>
        /// <param name="data">Element</param>
        public void Insert(T data)
        {
            InsertAt(data, Length);
        }

        /// <summary>
        /// Add an element at the start of the list
        /// </summary>
        /// <param name="data">Element</param>
        public void InsertFirst(T data)
        {
            InsertAt(data, 0);
        }

        /// <summary>
        /// Insert element to a specified index
        /// </summary>
        /// <param name="data">Element to be inserted</param>
        /// <param name="index">Index at which it will be inserted</param>
        public void InsertAt(T data, int index)
        {
            int length = GetLength();
            if (index > length)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            head = InsertAtInternal(head, data, index);
        }


        /// <summary>
        /// Inserts a collection at the end of a list
        /// </summary>
        /// <param name="collection">Collection</param>
        public void InsertAll(ICollection<T> collection)
        {
            foreach(var element in collection)
            {
                Insert(element);
            }
        }

        /// <summary>
        /// Returns the element at the start of the list
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            if (head == null)
            {
                throw new IndexOutOfRangeException("The list is empty");
            }
            else
            {
                return head.Data;
            }
        }

        /// <summary>
        /// Return the element at the end of the list
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            if (head == null)
            {
                throw new IndexOutOfRangeException("The list is empty");
            }
            else
            {
                return GetAtPosition(GetLength() - 1);
            }
        }

        /// <summary>
        /// Returns the element at specified index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public T GetAtPosition(int index)
        {
            int length = GetLength() - 1;
            if (index > length || index < 0)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            return GetAtPositionInternal(head, index);
        }

        /// <summary>
        /// Remove element at specified position
        /// </summary>
        /// <param name="index">Index at which element will be deleted</param>
        public void RemoveAt(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            head = RemoveAtInternal(head, index);
        }

        /// <summary>
        /// Removes the first element in the list
        /// </summary>
        public void RemoveFirst()
        {
            if (head.Next != null)
            {
                head = head.Next;
            }
        }

        /// <summary>
        /// Removes the last element in the list
        /// </summary>
        public void RemoveLast()
        {
            RemoveAt(Length - 1);
        }

        /// <summary>
        /// Returns the index of the first occurence of the specified element
        /// </summary>
        /// <param name="data">Element</param>
        /// <returns></returns>
        public int FindIndex(T data)
        {
            return FindIndexInternal(head, data, 0);
        }

        /// <summary>
        /// Returns true if the list contains specified element, otherwise returns false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            return FindIndex(data) > -1 ? true : false;
        }

        private int FindIndexInternal(Node<T> head, T data, int index)
        {
            if (head.Data.Equals(data))
            {
                return index;
            }
            else if (index < Length - 1)
            {
                return FindIndexInternal(head.Next, data, index + 1);
            }
            else
            {
                return -1;
            }
        }

        private Node<T> RemoveAtInternal(Node<T> head, int index)
        {
            if (index == 0)
            {
                return head.Next;
            }
            else
            {
                head.Next = RemoveAtInternal(head.Next, index - 1);
            }
            return head;
        }

        private int GetLength()
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                return GetLengthInternal(head.Next, 1);
            }
        }


        private Node<T> InsertAtInternal(Node<T> head, T data, int index)
        {
            var internalNode = new Node<T>
            {
                Data = data
            };

            if (head == null)
            {
                return internalNode;
            }
            else
            {
                if (index == 0)
                {
                    internalNode.Next = head;
                    return internalNode;
                }
                else
                {
                    head.Next = InsertAtInternal(head.Next, data, index - 1);
                }
            }
            return head;
        }

        private int GetLengthInternal(Node<T> head, int v)
        {
            if (head == null)
            {
                return v;
            }
            else
            {
                return GetLengthInternal(head.Next, v + 1);
            }
        }

        private T GetAtPositionInternal(Node<T> head, int index)
        {
            if (head == null)
            {
                return default(T);
            }
            else
            {
                if (index == 0)
                {
                    return head.Data;
                }
                else
                {
                    return GetAtPositionInternal(head.Next, index - 1);
                }
            }
        }

        private class Node<U>
        {
            internal U Data;
            internal Node<U> Next;
        }
    }




}

