using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ForAMomentIWasSoExcited_Code.DataStructures
{
    [DebuggerDisplay("{Value}")]
    public class SNode<T>
    {
        public SNode<T> Next { get; set; }
        public T Value { get; set; }
        public SNode(T value)
        {
            Value = value;
        }
    }
    [DebuggerDisplay("Count = {Count}")]
    public class SLinkedList<T> : IEnumerable
    {
        public SLinkedList() { }
        public SLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        private SNode<T> head, tail;
        public int Count { get; private set; }
        public void Add(SNode<T> node)
        {
            if (tail != null)
                tail.Next = node;
            else
                head = node;
            tail = node;
            Count++;
        }
        public void Add(T value)
        {
            Add(new SNode<T>(value));
        }
        public SNode<T> Find(T value)
        {
            return FindNode(value, head);
        }
        public void Remove(SNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            SNode<T> prev;
            if (node == head)
            {
                prev = null;
                head = head.Next;
            }
            else
            {
                prev = FindPrevious(head, node);
                prev.Next = node.Next;
            }

            if (node == tail)
                tail = prev;
            Count--;
        }
        public void Remove(T value)
        {
            var node = Find(value);
            if (node == null)
                return;
            Remove(node);
        }
        public void Clear()
        {
            RemoveAll(head);
            Count = 0;
        }
        private SNode<T> FindNode(T value, SNode<T> head)
        {
            if (head == null)
                return null;
            if (head.Value.Equals(value))
                return head;
            else
                return FindNode(value, head.Next);
        }
        private SNode<T> FindPrevious(SNode<T> _head, SNode<T> node)
        {
            if (_head.Next == node)
                return _head;
            else
                return FindPrevious(_head.Next, node);
        }
        private void RemoveAll(SNode<T> node)
        {
            if (node != null)
            {
                RemoveAll(node.Next);
                node.Next = null;
                node.Value = default;
            }
        }

        #region Enumerators
        public IEnumerator<SNode<T>> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
