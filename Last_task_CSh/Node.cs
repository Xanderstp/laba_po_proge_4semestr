using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_task_CSh
{

    public class Node<T> where T : Node<T>
    {
        public int Key { get; private set; }
        public byte Height { get; protected set; }

        public T? Left;
        public T? Right;

        public Node(int key)
        {
            Key = key;
            Height = 1;
            Left = default;
            Right = default;
        }


        public virtual T? Instert(T? node, int k, Func<int, T>? creator= null)
        {
            if (node == null) return creator(k);
            if (k < node.Key)
            {
                node.Left = Instert(node.Left, k, creator);
            }
            else
            {
                node.Right = Instert(node.Right, k, creator);
            }

            return Balance(node);
        }

        protected virtual T Balance(T node)
        {
            return node;
        }



        public virtual T? Remove(T? p, int k)
        {
            if (p == null) return null;
            if (k < p.Key)
            {
                p.Left = Remove(p.Left, k);
            }
            else if (k > p.Key)
            {
                p.Right = Remove(p.Right, k);
            }
            else
            {
                T? l = p.Left;
                T? r = p.Right;
                if (r==null) return l;
                T min = FindMin(r);
                min.Right = RemoveMin(r);
                min.Left = l;
                return Balance(min);
            }
            return Balance(p);
        }

        public virtual T? Search(T? node, int k)
        {
            if (node == null || node.Key == k)
            {
                return node;
            }
            if (node.Key < k)
            {
                return Search(node.Right, k);
            }

            return Search(node.Left, k);
        }

        T? FindMin(T? node)
        {
            return node.Left != null ? FindMin(node.Left) : node;
        }

        private T? RemoveMin(T? node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            node.Left = RemoveMin(node.Left);
            return Balance(node);
        }
    }
}
