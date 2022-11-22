using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Tree<T>
        where T : IComparable
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
        public void Add(T data)
        {
            if (Root == null) {
                Root = new Node<T>(data, null);
                Count = 1;
                return;
            }
            Add(Root, new Node<T>(data, null));
            Count++;
        }
        public List<T> Preorder() {
            if (Root == null)
            {
                return new List<T>();
            }
            return Preorder(Root);
        }
        public List<T> Postorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Postorder(Root);
        }
        public List<T> Inorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Inorder(Root);
        }
        public Node<T> Search(T elem)
        {
            return Search(Root, elem);
        }
        public Node<T> Min()
        {
            if (Root == null) {
                return null;
            }
            return Min(Root);
        }
        public Node<T> Max()
        {
            if (Root == null)
            {
                return null;
            }
            return Max(Root);
        }
        public Node<T> Next(T data) {
            return Next(Search(Root, data));
        }
        public Node<T> Prev(T data) { 
            return Prev(Search(Root, data));       
        }
        public void Delete(T data)
        {
            Root = Delete(Root, data);
            return;
        }
        public List<T> BreadthFirst()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return BreadthFirst(Root);
        }
        public void ShowTree() {
            List<Node<T>> queue = new List<Node<T>>();
            List<T> values = new List<T>();
            queue.Add(Root);
            
            while (queue.Count != 0)
            {
                var tmpNode = queue[0];
                Console.WriteLine("Root: " + tmpNode.Data);
                queue.RemoveAt(0);
                values.Add(tmpNode.Data);
                if (tmpNode.Left != null)
                {
                    queue.Add(tmpNode.Left);
                    Console.WriteLine("Left-child: " + tmpNode.Left.Data);
                }
                if (tmpNode.Right != null)
                {
                    queue.Add(tmpNode.Right);
                    Console.WriteLine("Right-child: " + tmpNode.Right.Data);
                }
            }
        }
        private void Add(Node<T> root, Node<T> elem) {
            while (root != null)
            {
                if (elem.CompareTo(root)==1)
                {
                    if(root.Right != null)
                    {
                        root = root.Right;    
                    }else
                    {
                        elem.Parent = root;
                        root.Right = elem;
                        break;
                    }
                }else if(elem.CompareTo(root)==-1)
                {
                    if(root.Left != null) { 
                        root = root.Left;
                    }else
                    {
                        elem.Parent = root;
                        root.Left = elem;
                        break;
                    }                        
                }
            }
        }
        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);
                if(node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }
                if (node.Right != null) { 
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }
        
        private List<T> Postorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }
                list.Add(node.Data);
            }
            return list;
        }
        private List<T> Inorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }
                list.Add(node.Data);
                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }
            }
            return list;
        }
        private Node<T> Search(Node<T> root, T elem)
        {
            if (root == null || elem.CompareTo(root.Data) == 0)
            {
                return root;
            }
            if (elem.CompareTo(root.Data) == -1)
            {
                return Search(root.Left, elem);
            }
            else
            {
                return Search(root.Right, elem);
            }
        }
        private Node<T> Min(Node<T> root)
        {
            if (root.Left == null)
                return root;
            return Min(root.Left);
        }
        private Node<T> Max(Node<T> root)
        {
            if (root.Right == null)
                return root;
            return Max(root.Right);
        }
        private Node<T> Next(Node<T> root) {
            if (root.Right != null) {
                return Min(root.Right);
            }
            var node = root.Parent;
            while (node != null && root == node.Right) {
                root = node;
                node = node.Parent;
            }
            return node;
        }
        private Node<T> Prev(Node<T> root)
        {
            if(root.Left != null)
                return Max(root.Left);
            var node = root.Parent;
            while (node != null && root == node.Left)
            {
                root = node;
                node = node.Parent;
            }
            return node;
        }
        public Node<T> Delete(Node<T> root, T data)
        {
            if (root == null)
                return root;
            if (data.CompareTo(root.Data) == -1)
            {
                root.Left = Delete(root.Left, data);
            }else if(data.CompareTo(root.Data) == 1)
            {
                root.Right = Delete(root.Right, data);
            }else if(root.Left != null && root.Right != null)
            {
                root.Data = Min(root.Right).Data;
                root.Right = Delete(root.Right, root.Data);
            }else
            {
                if (root.Left != null)
                {
                    root = root.Left;
                }else if (root.Right != null)
                {
                    root=root.Right;
                }else
                {
                    root = null;
                }
            }
            return root;
        }
        private List<T> BreadthFirst(Node<T> root) { 
            List<Node<T>> queue = new List<Node<T>>();
            List<T> values = new List<T>();
            queue.Add(root);
            while (queue.Count != 0)
            {
                var tmpNode = queue[0];
                queue.RemoveAt(0); 
                values.Add(tmpNode.Data);
                if(tmpNode.Left != null)
                { 
                    queue.Add(tmpNode.Left);
                }
                if(tmpNode.Right != null)
                {
                    queue.Add(tmpNode.Right);
                }
            }
            return values;
        }
    }
}
