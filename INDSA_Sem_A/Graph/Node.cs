using System;
using System.Collections.Generic;
using System.Drawing;

namespace INDSA_Sem_A.Graph
{
     [Serializable]
    public class Node : INode
    {
        private string Id;
        private LinkedList<Follower> followers ;
        private NodeType nodeType;
        private Point location;
        private double rank;
        public INode predchudce;


        public Node(NodeType nodeType, Point location  )
        {
            Id = Generator.CreateUniqueID(nodeType);
            this.nodeType = nodeType;
            followers = new LinkedList<Follower>();
            this.location = location;
            rank = double.PositiveInfinity;
            predchudce = null;

        }

        public override string ToString()
        {
            return "ID : " + Id + " Node Type: " + nodeType + ", located at: [" + location.X + "," + location.Y+ "] ";
        }

        public LinkedList<Follower> GetFollowers()
        {
            return followers;
        }

        public Point GetLocation()
        {
            return location;
        }

        public double GetRank()
        {
            return rank;
        }

        public void SetRank(double set)
        {
            rank = set;
        }

        public INode GetPredchudce()
        {
            return predchudce;
        }

        public void SetPredchudce(INode set)
        {
            predchudce = set;
        }


        public string GetId()
        {
            return Id;
        }
    }
}