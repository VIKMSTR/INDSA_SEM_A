using System;
using System.Collections.Generic;
using System.Drawing;

namespace INDSA_Sem_A.RangeTree
{
   
    public class CompareByX : IComparer<GraphNode>
    {
        public  int Compare(GraphNode x, GraphNode y)
        {
            if (x.Location.X < y.Location.X)
            {
                return -1;
            }
            if (x.Location.X > y.Location.X)
            {
                return 1;
            }
            return 0;
        }
     }

    public class CompareByY : IComparer<GraphNode>
    {
        public  int Compare(GraphNode x, GraphNode y)
        {
            if (x.Location.Y < y.Location.Y)
            {
                return -1;
            }
            if (x.Location.Y > y.Location.Y)
            {
                return 1;
            }
            return 0;
        }
    }

}