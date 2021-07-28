using System;
using System.Collections.Generic;
using System.Text;

namespace AVLtree
{
    class AVL
    {
        public Node root { get; set; }
        public AVL()
        {
        }
        public void InsertRoot(int data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = Insert(root, newItem);
            }
        }
        private Node Insert(Node current, Node k)
        {
            if (current == null)
            {
                current = k;
                return current;
            }
            else if (k.data < current.data)
            {
                current.left = Insert(current.left, k);
                current = Balancing(current);
            }
            else if (k.data > current.data)
            {
                current.right = Insert(current.right, k);
                current = Balancing(current);
            }
            return current;
        }
        public Node Balancing(Node current)
        {
            int heightDiff = HeightDifference(current);//разница высот
            if (heightDiff > 1)
            {
                if (HeightDifference(current.left) > 0)
                {
                    current = RotateRight(current);
                }
                else
                {
                    current = RotateLeftRight(current);
                }
            }
            else
            {
                if (heightDiff < -1)
                {
                    if (HeightDifference(current.right) > 0)
                    {
                        current = RotateRightLeft(current);
                    }
                    else
                    {
                        current = RotateLeft(current);
                    }
                }
            }
            return current;
        }

        public Node RotateRight(Node current)
        {
            Node element = current.left;
            current.left = element.right;
            element.right = current;
            return element;
        }
        public Node RotateLeft(Node current)
        {
            Node element = current.right;
            current.right = element.left;
            element.left = current;
            return element;
        }
        public Node RotateLeftRight(Node current)
        {
            RotateLeft(current.left);
            return RotateRight(current);
        }
        public Node RotateRightLeft(Node current)
        {
            RotateRight(current.right);
            return RotateLeft(current);
        }
        public int HeightDifference(Node current)
        {
            int left = GetHeight(current.left);
            int right = GetHeight(current.right);
            return left - right;
        }
        public int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.left);
                int right = GetHeight(current.right);
                int max;
                if (left > right)
                {
                    max = left;
                }
                else
                {
                    max = right;
                }
                height = max + 1;
            }
            return height;
        }

        public void Print(Node root, int n)
        {
            if (root != null)
            {
                Print(root.right, n + 5);
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(root.data);
                Print(root.left, n + 5);
            }
        }
    }
}
