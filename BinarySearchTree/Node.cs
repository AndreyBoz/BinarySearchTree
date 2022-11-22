using System;


namespace BinarySearchTree
{
    class Node<T> : IComparable
        where T : IComparable
    {
        public T Data { get; set; }    
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public Node(T data, Node<T> parent) { 
            Data = data;
            Parent = parent;
        }

        public Node(T data, Node<T> left, Node<T> right){
            Data = data;
            Left = left;
            Right = right;
        }

        public int CompareTo(object? obj){
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item.Data);
            }
            else {
                throw new ArgumentException();
            }           
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
