using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.NonLinearStructures
{
    public class BinaryTree
    {
        private Node _root;

        public void Insert(int value)
        {
            var node = new Node() { Value = value };

            if (_root == null)
            {
                _root = node;
                return;
            }

            var current = _root;
            while (true)
            {
                if (value < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                        break;
                    }

                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                        break;
                    }

                    current = current.RightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var current = _root;
            while (current != null)
            {
                if (value == current.Value)
                    return true;

                if (value < current.Value)
                    current = current.LeftChild;
                else
                    current = current.RightChild;
            }

            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(_root);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.Value);
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.LeftChild);
            Console.WriteLine(root.Value);
            TraverseInOrder(root.RightChild);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }

        public int Height()
        {
            return Height(_root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }

        public int Min()
        {
            return Min(_root);
        }

        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }

        public int MinFromBinarySearchTree()
        {
            return MinFromBinarySearchTree(_root);
        }

        private int MinFromBinarySearchTree(Node root)
        {
            if (root == null)
                throw new InvalidOperationException();

            var current = root;
            while (current.LeftChild != null)
                current = current.LeftChild;

            return current.Value;
        }

        public int MaxFromBinarySearchTree()
        {
            return MaxFromBinarySearchTree(_root);
        }

        private int MaxFromBinarySearchTree(Node root)
        {
            if (root == null)
                throw new InvalidOperationException();

            var current = root;
            while (current.RightChild != null)
                current = current.RightChild;

            return current.Value;
        }

        public bool Equals(BinaryTree other)
        {
            if (other == null)
                return false;

            return Equals(_root, other._root);
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.Value == second.Value && Equals(first.LeftChild, second.LeftChild) && Equals(first.RightChild, second.RightChild);

            return false;
        }

        private bool IsLeaf(Node root)
        {
            return root.LeftChild == null && root.RightChild == null;
        }

        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public override string ToString()
            {
                return "Node=" + Value;
            }
        }
    }
}
