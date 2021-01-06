using System;
using System.Drawing;

namespace INDSA_Sem_A.Graph
{
    public class Generator
    {
        private static int count = 0;
        public static string CreateUniqueID(NodeType nodeType)
        {
            count++;
            if (nodeType == NodeType.BusStop)
            {
                 return "Z" + count;
            }else if (nodeType == NodeType.RestingPlace)
            {
                return "O" + count;

            }
                return "K" + count;

        } 

        public static void InsertRandomNode(Graph g)
        {
            Random rndOne = new Random();
            Random rndTwo = new Random();
            int one, two, type;
            one = Convert.ToInt32(rndOne.NextDouble() * 40);
            two = Convert.ToInt32(rndTwo.NextDouble() * 40);
            type = (one + two)%3;

            switch (type)
            {
                case 0: g.AddNewNode(new Node(NodeType.BusStop, new Point(one, two)));
                    break;
                case 1: g.AddNewNode(new Node(NodeType.Crossroads, new Point(one, two)));
                    break;
                default: g.AddNewNode(new Node(NodeType.RestingPlace, new Point(one, two)));
                    break;
            }
        }
    }
}