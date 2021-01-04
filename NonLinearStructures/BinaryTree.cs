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
