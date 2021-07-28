using System;

namespace AVLtree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL tree = new AVL();
            Console.WriteLine("Сбалансированное АВЛ-дерево:");

            tree.InsertRoot(5);
            tree.InsertRoot(3);
            tree.InsertRoot(7);
            tree.InsertRoot(2);
            tree.InsertRoot(4);
            tree.InsertRoot(10);
            tree.InsertRoot(6);

            tree.Print(tree.root, -2);
            Console.WriteLine();
        }
    }
}
