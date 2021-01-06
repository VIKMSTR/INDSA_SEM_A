using System;
using System.Drawing;

namespace INDSA_Sem_A.RangeTree
{
    public class GraphNode :IComparable<GraphNode>
    {
        public string Key;
        public Point Location;

        public GraphNode(string key, Point location)
        {
            Key = key;
            Location = location;
        }

        public int CompareTo(GraphNode other)
        {
            throw new NotImplementedException();
        }
    }
}