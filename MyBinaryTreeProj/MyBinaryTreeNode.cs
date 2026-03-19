namespace MyBinaryTreeProj
{
    public class MyBinaryTreeNode<TNode> : IComparable<TNode>
        where TNode : IComparable<TNode>
    {
        public TNode Value { get; private set; }
        public MyBinaryTreeNode<TNode> Left { get; set; }
        public MyBinaryTreeNode<TNode> Right { get; set; }

        public MyBinaryTreeNode(TNode value)
        {            
            Value = value;  
        }
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }

    }
}