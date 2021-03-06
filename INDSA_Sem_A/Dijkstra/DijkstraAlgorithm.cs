using System;
using System.Collections.Generic;
using INDSA_Sem_A.Graph;

namespace INDSA_Sem_A.Dijkstra
{
     [Serializable]
    public class DijkstraAlgorithm
    {
         //Postupn� na��tat vrcholy, nenaplnit to v�emi najednou (neefektivn�)
        private Graph.Graph g;
        private PriorityQueue<double, string> priority;
        
        private Dictionary<string, string> marked; //key - vrchol // value - id p�edch�dce

        List<INode> ShortestPathNodes;
        public void SetGraph(Graph.Graph g)
        {
            this.g = g;
        }
        private Dictionary<string, Dictionary<string, string>> Matrix; 
        
        public DijkstraAlgorithm(Graph.Graph g)
        {
            this.g = g;
            priority = new PriorityQueue<double, string>();
            ShortestPathNodes = new List<INode>();
            marked = new Dictionary<string, string>();
        }

        public List<INode> Execute(INode start, INode finish)
        {
            //vstupni na 0
            foreach (string nulkey in g.Nodes.Keys)
            {
                INode nulled = g.FindNode(nulkey);
                nulled.SetPredchudce(null);
                nulled.SetRank(double.PositiveInfinity);

            }
            priority = new PriorityQueue<double, string>();
            ShortestPathNodes = new List<INode>();
      //      marked = new Dictionary<string, string>();
            start.SetRank(0.0);
            priority.Add(new KeyValuePair<double, string>(start.GetRank(),start.GetId())); //vlo�en� po��te�n�ho vrcholu

            while (!priority.IsEmpty)
            {
                INode node = g.FindNode(priority.DequeueValue());
                INode next;
                foreach (Follower f in node.GetFollowers()) // vsechny nasledniky
                {
                    string key;
                    double dist;
                    if (f.GetFollowingNode(out key, out dist)) // je pruchozi
                    {
                        next = g.FindNode(key);
                        if ((dist + node.GetRank()) < next.GetRank())
                        {
                            priority.Remove(new KeyValuePair<double, string>(next.GetRank(), next.GetId()));
                            next.SetRank(dist + node.GetRank()); // novej rank
                            next.SetPredchudce(node);
                        //    marked.Add(next.GetId(),node.GetId()); // predchudce nexta je node (key, key)
                            priority.Add(new KeyValuePair<double, string>(next.GetRank(),next.GetId()));
                        };
                    }
                }
            }


            /*Vypis*/
            for (INode inode = finish; inode != null; inode = inode.GetPredchudce())
            {
                ShortestPathNodes.Add(inode);
            }
/*
            for (INode inode = finish; !inode.Equals(start); inode = inode.GetPredchudce())
            {
                ShortestPathNodes.Add(inode);
            }
            ShortestPathNodes.Add(start);*/

            ShortestPathNodes.Reverse();

                return ShortestPathNodes;
        }
        


        public List<INode> ExecuteOptimized(INode start, INode finish)
        {
            priority.Clear();
            ShortestPathNodes.Clear();
            marked.Clear();
            foreach (string nulkey in g.Nodes.Keys)
            {
                INode nulled = g.FindNode(nulkey);
                nulled.SetPredchudce(null);
                nulled.SetRank(double.PositiveInfinity);

            }
            start.SetRank(0.0);

            priority.Add(new KeyValuePair<double, string>(start.GetRank(), start.GetId())); //vlo�en� po��te�n�ho vrcholu
            while (!priority.IsEmpty)
            {
                INode node = g.FindNode(priority.DequeueValue());
                if (node.GetId().Equals(finish.GetId()))
                {
                    break;
                }
                INode next;
                foreach (Follower f in node.GetFollowers()) // vsechny nasledniky
                {
                    string key;
                    double dist;
                    if (f.GetFollowingNode(out key, out dist)) // je pruchozi
                    {
                        next = g.FindNode(key);
                        if ((dist + node.GetRank()) < next.GetRank())
                        {
                   //         priority.Remove(new KeyValuePair<double, string>(next.GetRank(), next.GetId()));
                            next.SetRank(dist + node.GetRank()); // novej rank
                            next.SetPredchudce(node);
                            //    marked.Add(next.GetId(),node.GetId()); // predchudce nexta je node (key, key)
                            priority.Add(new KeyValuePair<double, string>(next.GetRank(), next.GetId()));
                        };
                    }
                }
            }

            
            /*Vypis*/
            for (INode inode = finish; inode != null; inode = inode.GetPredchudce())
            {
                ShortestPathNodes.Add(inode);
            }
            
            ShortestPathNodes.Reverse();

            return ShortestPathNodes; 
        } 

        public Dictionary<string, Dictionary<string, string>> GenerateFollowerMatrix()
        {

            // pro v�echny vrcholy naj�t nejkrat�� cestu do ostatn�ch
            List<INode> foundNodes;
            INode n;
            INode nx;
            Matrix = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> MatrixRow = null;
            foreach (string keyn in g.Nodes.Keys)
            {
                n = g.FindNode(keyn);
                MatrixRow = new Dictionary<string, string>();

                foreach (string keynx in g.Nodes.Keys)
                {
                    nx = g.FindNode(keynx);
                    if (n.Equals(nx))
                    {
                        MatrixRow.Add(n.GetId()," X ");
                    }
                   foundNodes = Execute(n, nx);
                   int total = foundNodes.Count;
                   if (total > 2)
                   {
                    MatrixRow.Add(foundNodes[total-1].GetId(),foundNodes[total-2].GetId());
                   }
                   else if(total == 2)
                   {
                       MatrixRow.Add(nx.GetId(),n.GetId());
                   }
             /*      for (int i = 0; i < foundNodes.Count - 1; i++)
                   {
                       adding.Add(foundNodes[i].GetId(),foundNodes[i+1].GetId());
                   }*/
               //     Matrix.Add(n.GetId(),MatrixRow);
                }
                Matrix.Add(n.GetId(),MatrixRow);
            }

            return Matrix;
        }
    }
}