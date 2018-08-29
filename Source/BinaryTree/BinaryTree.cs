
using System;
using System.Drawing;

namespace BinaryTree
{
    public class BinaryTree
    {
        
        public Node RootNode { get; private set; }

        public BinaryTree()
        {
            RootNode = new Node(int.MinValue);
        }

        
        public int Count { get { return RootNode.Right.Count; } }

        
        /// adds a node to the tree
        
        public bool Add(Node node)
        {
            return RootNode.Add(node);
        }
        
        /// Removes the node containing the inserted value.
        /// returns true if could find and remove the node.
        /// return false if the value does not exist on any of nodes. (except rootnode)
       
        public bool Remove(int value)
        {
            bool isRootNode;
            var res = RootNode.Remove(value, out isRootNode);
            return !isRootNode && res;// return false if the inserted value is on rootNode, or the value does not exist on any of nodes
        }
        // draw
        public Image Draw()
        {
            GC.Collect();// collects the unreffered locations on the memory
            int temp;
            return RootNode.Right == null ? null : RootNode.Right.Draw(out temp);
        }

  
        /// returns true if the current node or it's childs containd the inserted value
        
        public bool Exists(int item)
        {
            return RootNode.Exists(item);
        }
    }
}
