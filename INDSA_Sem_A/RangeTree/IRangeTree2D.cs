using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace INDSA_Sem_A.RangeTree
{
    public interface IRangeTree2D<T>
    {
        TreeNode<T> BuildTree(IEnumerable<T> unsortedItems, int dimension);
        TreeNode<T> BuildSubTree(List<T> sortedItems, int dimension);
        List<T> GetAllInRange(Point start, Point end);
    }
}