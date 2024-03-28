using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Last_task_CSh
{
    public class NodeAVL : Node<NodeAVL>
    {
        public NodeAVL(int key) : base(key)
        {

        }

        public override NodeAVL? Instert(NodeAVL? node, int k, Func<int, NodeAVL>? creator = null)
        {
            creator = (key) => new NodeAVL(key);
            return base.Instert(node, k, creator);
        }

        byte HeightHandler(NodeAVL node)
        {
            return node != null ? node.Height : (byte) 0;
        }

        int BFactor(NodeAVL node)
        {
            return HeightHandler(node.Right) - HeightHandler(node.Left);
        }

        void FixHeight(NodeAVL node)
        {
            byte hl = HeightHandler(node.Left);
            byte hr = HeightHandler(node.Right);
            node.Height = (byte)((hl > hr ? hl : hr) + 1);
        }

        NodeAVL RotateRight(NodeAVL node)
        {
            NodeAVL q = node.Left;
            node.Left = q.Right;
            q.Right = node;
            FixHeight(node);
            FixHeight(q);
            return q;
        }

        NodeAVL RotateLeft(NodeAVL node)
        {
            NodeAVL q = node.Right;
            node.Right = q.Left;
            q.Left = node;
            FixHeight(node);
            FixHeight(q);
            return q;
        }

        protected override NodeAVL Balance(NodeAVL node)
        {
            FixHeight(node);
            if (BFactor(node) == 2)
            {
                if (BFactor(node.Right) < 0)
                {
                    node.Right = RotateRight(node.Right);
                }
                return RotateLeft(node);
            }
            if (BFactor(node) == -2)
            {
                if (BFactor(node.Left) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }
            return node;
        }

        public void Display(int level = 0)
        {
            int i;
            if (this != null)
            {
                Right?.Display(level + 1);
                Console.Write("\n");
                if (level == 0)
                    Console.Write("Root -> ");
                for (i = 0; i < level && level != 0; i++)
                    Console.Write("        ");
                Console.Write(Key);
                Left?.Display(level + 1);
            }
        }

    }
}
