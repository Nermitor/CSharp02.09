using System;
using CSharp02._09.Exceptions;

namespace CSharp02._09
{
    public class SetNodes<T>
    {
        private Node<T> _topNode = null;

        public bool Empty() => _topNode == null;

        public virtual void Push(T value)
        {
            Node<T> newNode = new Node<T>(value, _topNode);
            _topNode = newNode;
        }

        public T Peek()
        {
            if (Empty()) throw new SetNodesPeekException("Empty stack in Peek");
            return _topNode.Value;
        }


        public virtual T Pop()
        {
            if (Empty()) throw new SetNodesPopException("Empty stack in Pop");
            T value = _topNode.Value;
            _topNode = _topNode.Prev;
            return value;

        }

        public virtual void Clear()
        {
            while (!Empty())
            {
                Pop();
            }
        }

        public virtual String ToStr()
        {
            String stringify = "";

            Node<T> cur_node = _topNode;
            while (cur_node != null)
            {
                stringify += cur_node.Value.ToString() + "-";
                cur_node = cur_node.Prev;
            }

            return stringify + "end";
        }
        
    }
}