using System;
using System.Collections;
using System.Collections.Generic;

namespace lab2
{
    public class BinaryTree<T> : ICollection<T>
    {
        public class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Left { get; set; }
            public Node<TValue> Right { get; set; }
            public Node(TValue value) { Value = value; }
        }

        protected Node<T> root;
        protected IComparer<T> comparer;

        public BinaryTree() : this(Comparer<T>.Default)
        {
        }
        public BinaryTree(IComparer<T> defaultComparer)
        {
            if (defaultComparer == null)
                throw new ArgumentNullException("Default comparer is null");
            comparer = defaultComparer;
        }
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {

        }
        public BinaryTree(IEnumerable<T> collection, IComparer<T> defaultComparer) : this(defaultComparer)
        {
            AddRange(collection);
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);
        }
        public IEnumerable<T> Preorder()
        {
            if (root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

        public int Count { get; protected set; }
        public void Add(T item)
        {
            var node = new Node<T>(item);

            if (root == null)
                root = node;
            else
            {
                Node<T> current = root, parent = null;

                while (current != null)
                {
                    parent = current;
                    if (comparer.Compare(item, current.Value) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                if (comparer.Compare(item, parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++Count;
        }
        public bool Remove(T item)
        {
            if (root == null)
                return false;

            Node<T> current = root, parent = null;

            int result;
            do
            {
                result = comparer.Compare(item, current.Value);
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                if (current == null)
                    return false;
            }
            while (result != 0);

            if (current.Right == null)
            {
                if (current == root)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == root)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node<T> min = current.Right.Left, prev = current.Right;
                while (min.Left != null)
                {
                    prev = min;
                    min = min.Left;
                }
                prev.Left = min.Right;
                min.Left = current.Left;
                min.Right = current.Right;

                if (current == root)
                    root = min;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = min;
                    else
                        parent.Right = min;
                }
            }
            --Count;
            return true;
        }
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        public int PrintTree(int coordinate)
        {
            return Print(root, coordinate); 
        }
        int Print(Node<T> root, int coordinate, int y = 0)
        {
            if (root == null)
                return 0;
            Console.SetCursorPosition(coordinate, y);
            Console.Write(root.Value);

            var loc = y;

            if (root.Right != null)
            {
                Console.SetCursorPosition(coordinate + 2, y);
                Console.Write("--");
                y = Print(root.Right, coordinate + 4, y);
            }

            if (root.Left != null)
            {
                while (loc <= y)
                {
                    Console.SetCursorPosition(coordinate, loc + 1);
                    Console.Write(" |");
                    loc++;
                }
                y = Print(root.Left, coordinate, y + 2);
            }
            Console.WriteLine();
            return y;


        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var value in this)
                array[arrayIndex++] = value;
        }
        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public bool Contains(T item)
        {
            var current = root;
            while (current != null)
            {
                var result = comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                if (result < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}