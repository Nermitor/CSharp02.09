using System;

namespace CSharp02._09
{
    public class Node<T>
    {
        private Node<T> next;
        private T value;


        public Node( T value, Node<T> prev=null)
        {
            Value = value;
            Prev = prev;
        }

        public Node<T> Prev { get; }

        public T Value { get; }

        
    }
}