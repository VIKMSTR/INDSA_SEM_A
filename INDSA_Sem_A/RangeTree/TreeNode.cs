using System.Drawing;

namespace INDSA_Sem_A.RangeTree
{
    public class TreeNode<T>
    {
        public TreeNode<T> LeftChild;  // levy potomek
        public TreeNode<T> RightChild; //pravy potomek
        public TreeNode<T> NextDimensionRoot; //koren dalsi dimenze

        public TreeNode<T> NextLeaf; 
        public int Median;
//        public Point Location;
        public T Value;


        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null && Value != null && NextDimensionRoot != null)
            {
                return true;
            }
             return false;
        }

    }
}