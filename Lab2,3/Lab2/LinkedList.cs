using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    /// <summary>
    /// This is a class of a node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Node<T> where T : IComparable<T>, IEquatable<T>
    {
        public T Data { get; set; }
        /// <summary>
        /// One way node//one link
        /// </summary>
        public Node<T> Link { get; set; }

        /// <summary>
        /// Constructor of a node
        /// </summary>
        /// <param name="value">Type value</param>
        /// <param name="address">Node type adress</param>
        public Node(T value, Node<T> address)
        {
            Data = value;
            Link = address;
        }
    }

    /// <summary>
    /// This class is dedicated to a linked list of objects
    /// </summary>
    public sealed class LinkedList<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        private Node<T> begin;
        private Node<T> end;
        private Node<T> current;

        /// <summary>
        /// Constructor of a linked list with pointers
        /// </summary>
        public LinkedList()
        {
            begin = null;
            end = null;
            current = null;
        }

        /// <summary>
        /// Creating the begining of a linked list
        /// </summary>
        /// <param name="obj">Input type object</param>
        public void SetLifo(T obj)
        {
            begin = new Node<T>(obj, begin);
        }

        /// <summary>
        /// Creating the end of a linked list
        /// </summary>
        /// <param name="obj">Input type object</param>
        public void Add(T obj)
        {
            var temp = new Node<T>(obj, null);
            if (begin != null)
            {
                end.Link = temp;
                end = temp;
            }
            else
            {
                begin = temp;
                end = temp;
            }
        }

        /// <summary>
        /// Sorting method by certain requirements
        /// </summary>
        public void Sort()
        {
            for (Node<T> a1 = begin; a1 != null; a1 = a1.Link)
            {
                for (Node<T> a2 = a1.Link; a2 != null; a2 = a2.Link)
                {
                    if (a1.Data.CompareTo(a2.Data) > 0)
                    {
                        T K = a1.Data;
                        a1.Data = a2.Data;
                        a2.Data = K;
                    }
                }
            }
        }

        /// <summary>
        /// This is a count method of items in the linked list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            Node<T> temp = begin;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.Link;
            }
            return count;
        }

        /// <summary>
        /// Method dedicated to go through objects of this linked list by using a loop
        /// </summary>
        public void Start()
        {
            current = begin;
        }

        /// <summary>
        /// Method dedicated to go through objects of this linked list by using a loop
        /// </summary>
        public void Next()
        {
            current = current.Link;
        }

        /// <summary>
        /// Method dedicated to go through objects of this linked list by using a loop
        /// </summary>
        public bool Exist()
        {
            return current != null;
        }

        /// <summary>
        /// Method dedicated to go get an object of this linked list
        /// </summary>
        /// <returns></returns>
        public T TakeData()
        {
            return current.Data;
        }

        /// <summary>
        /// IEnumerator interface method
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (begin != null)
            {
                for (Node<T> dd = begin; dd != null; dd = dd.Link)
                {
                    yield return dd.Data;
                }
            }
        }

        /// <summary>
        /// IEnumerator interface method
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}