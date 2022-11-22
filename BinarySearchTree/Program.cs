using BinarySearchTree;
using System;
namespace Program;
class Program
{
    static void Main(string[] args)
    {
        var tree = new Tree<int>();
        tree.Add(5);
        tree.Add(3);
        tree.Add(7);
        tree.Add(1);
        tree.Add(2);
        tree.Add(8);
        tree.Add(6);
        tree.Add(9);
        Console.WriteLine("Search: " + tree.Search(5));
        Console.WriteLine("Min: " + tree.Min());
        Console.WriteLine("Max: " + tree.Max());
        Console.WriteLine("Prev element: " + tree.Prev(6));
        Console.WriteLine("Next element: " + tree.Next(8));
        Console.WriteLine("Preorder: ");
        foreach (var item in tree.Preorder()) { 
            Console.Write(item + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("Postorder: ");
        foreach (var item in tree.Postorder()) {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
        tree.Delete(5);
        Console.WriteLine("Inorder: ");
        foreach (var item in tree.Inorder())
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine("BreadthFirst: ");
        foreach (var item in tree.BreadthFirst())
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("Elements of tree by level: ");
        tree.ShowTree();
    }
}