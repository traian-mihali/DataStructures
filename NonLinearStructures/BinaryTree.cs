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

        public bool Contains(int value)
        {
            return Contains(_root, value);
        }

        private bool Contains(Node root, int value)
        {
            if (root == null)
                return false;

            if (root.Value == value)
                return true;

            return Contains(root.LeftChild, value) || Contains(root.RightChild, value);
        }

        public void TraverseLevelOrder()
        {
            for (var i = 0; i <= Height(); i++)
                foreach (var value in GetNodesAtDistance(i))
                    Console.WriteLine(value);
        }

        public void TraverseBreadthFirst()
        {
            TraverseBreadthFirst(_root);
        }

        private void TraverseBreadthFirst(Node root)
        {
            var nodes = new Queue<Node>();
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                if (current.LeftChild != null)
                    nodes.Enqueue(current.LeftChild);

                if (current.RightChild != null)
                    nodes.Enqueue(current.RightChild);

                Console.WriteLine(current.Value);
            }
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

        public int Size()
        {
            return Size(_root);
        }

        private int Size(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return 1 + Size(root.LeftChild) + Size(root.RightChild);
        }

        public int Min()
        {
            if (_root == null)
                throw new InvalidOperationException();

            return Min(_root);
        }

        private int Min(Node root)
        {
            if (root == null)
                return int.MaxValue;

            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }

        public int MinFromBST()
        {
            return MinFromBST(_root);
        }

        private int MinFromBST(Node root)
        {
            if (root == null)
                throw new InvalidOperationException();

            var current = root;
            while (current.LeftChild != null)
                current = current.LeftChild;

            return current.Value;
        }

        public int Max()
        {
            if (_root == null)
                throw new InvalidOperationException();

            return Max(_root);
        }

        private int Max(Node root)
        {
            if (root.RightChild == null)
                return root.Value;

            return Max(root.RightChild);
        }

        public int MaxFromBST()
        {
            return MaxFromBST(_root);
        }

        private int MaxFromBST(Node root)
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

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(_root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.Value < min || root.Value > max)
                return false;

            return IsBinarySearchTree(root.LeftChild, min, root.Value - 1) && IsBinarySearchTree(root.RightChild, root.Value + 1, max);
        }

        public void SwapRoot()
        {
            var left = _root.LeftChild;
            _root.LeftChild = _root.RightChild;
            _root.RightChild = left;
        }

        public IEnumerable<int> GetNodesAtDistance(int distance)
        {
            IList<int> nodes = new List<int>();

            GetNodesAtDistance(_root, distance, nodes);

            return nodes;
        }

        private void GetNodesAtDistance(Node root, int distance, IList<int> nodes)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                nodes.Add(root.Value);
                return;
            }

            GetNodesAtDistance(root.LeftChild, distance - 1, nodes);
            GetNodesAtDistance(root.RightChild, distance - 1, nodes);
        }

        public int CountLeaves()
        {
            return CountLeaves(_root);
        }

        private int CountLeaves(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return CountLeaves(root.LeftChild) + CountLeaves(root.RightChild);
        }

        public bool AreSibling(int first, int second)
        {
            return AreSibling(_root, first, second);
        }

        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null)
                return false;

            var areSibling = false;
            if (root.LeftChild != null && root.RightChild != null)
                areSibling = (root.LeftChild.Value == first && root.RightChild.Value == second) || (root.RightChild.Value == first && root.LeftChild.Value == second);

            return areSibling || AreSibling(root.LeftChild, first, second) || AreSibling(root.RightChild, first, second);
        }

        public IList<int> GetAncestors(int value)
        {
            var list = new List<int>();
            GetAncestors(_root, value, list);
            return list;
        }

        private bool GetAncestors(Node root, int value, IList<int> list)
        {
            if (root == null)
                return false;

            if (root.Value == value)
                return true;

            if (GetAncestors(root.LeftChild, value, list) || GetAncestors(root.RightChild, value, list))
            {
                list.Add(root.Value);
                return true;
            }

            return false;
        }

        public bool IsBalanced()
        {
            return IsBalanced(_root);
        }

        private bool IsBalanced(Node root)
        {
            if (root == null)
                return true;

            var balanceFactor = Height(root.LeftChild) - Height(root.RightChild);

            //return Math.Abs(balanceFactor) <= 1 && IsBalanced(root.LeftChild) && IsBalanced(root.RightChild);
            return Math.Abs(balanceFactor) <= 1;
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
