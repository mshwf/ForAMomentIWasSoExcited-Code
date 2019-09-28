using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ForAMomentIWasSoExcited_Code.DataStructures
{
    [DebuggerDisplay("{Value}")]
    public class TreeNode<TValue>
    {
        public TreeNode(TValue value)
        {
            Value = value;
        }
        public IList<TreeNode<TValue>> Children { get; set; } = new List<TreeNode<TValue>>();
        public TValue Value { get; private set; }
        public IList<TreeNode<TValue>> Parents { get; set; }
    }
    [DebuggerDisplay("Count = {Count}")]
    public class Tree<TValue>
    {
        public int Count { get; private set; }
        public string Graph { get; private set; }
        public TreeNode<TValue> Root { get; private set; }
        public TreeNode<TValue> Last { get; private set; }
        /// <summary>
        /// Add a node to the tree after the specified parent and return the node
        /// </summary>
        /// <param name="value">The value of the noe</param>
        /// <param name="parent">The node's parent</param>
        /// <returns></returns>
        public TreeNode<TValue> Add(TValue value, TreeNode<TValue> parent = null)
        {
            TreeNode<TValue> current = new TreeNode<TValue>(value);
            current.Parents = new List<TreeNode<TValue>> { parent };
            if (parent == null)
            {
                Count = 0;
                Root = current;
            }
            else
                parent.Children.Add(current);
            Last = current;
            Count++;
            return current;
        }

        public TreeNode<TValue> AddMultiParent(TValue value, List<TreeNode<TValue>> parents = null)
        {
            TreeNode<TValue> current = new TreeNode<TValue>(value);
            current.Parents = parents;
            if (parents == null)
            {
                Count = 0;
                Root = current;
            }
            else
                parents.ForEach(p => p.Children.Add(current));
            Last = current;
            Count++;
            return current;
        }
    }
}
