using System;
using System.Collections.Generic;
using INDSA_Sem_A.Exceptions;

namespace INDSA_Sem_A.Graph
{
    [Serializable]
    public class Graph : IGraph<string,LinkedList<Follower>> //implementace IGrafu - kl��e jsou stringy, followery jsou v seznamu
    {
        public Dictionary<string, INode> Nodes; // kl��em je string, hodnotou je objekt typu INode  (IVrchol)

        public Graph()
        {
            Nodes = new Dictionary<string, INode>(StringComparer.CurrentCulture);
        }

        public bool IsEmpty()
        {
            if (Nodes.Count == 0)
            {
                return true;
            }
             return false;
        }

        public int NumberOfElements()
        {
            return Nodes.Count;
        }

        public void AddNewNode(INode n)
        {
            if (n != null)
            {
                
            
            Nodes.Add(n.GetId(),n);
            }
         
        }

        public void AddNewEdge(INode from , INode to)
        {
            INode accessed;
            INode accessed2;

            if (from.Equals(to))
            {
                throw new LoopEdgeException("Nelze vlo�it hranu - smy�ku");
            }
            // zpristupnit vrchol, ze ktereho vede, 
            if (Nodes.ContainsKey(from.GetId()))
            {
                accessed = Nodes[from.GetId()];
            }
            else
            {
                throw new NodeNotFoundException("Prvek neexistuje");
            }
            double distance = Math.Sqrt(Math.Pow(Math.Abs(from.GetLocation().X - to.GetLocation().X), 2) + Math.Pow(Math.Abs(from.GetLocation().Y - to.GetLocation().Y), 2));
            //vlozit do nasledniku (pokud uz neexistuje)
            Follower inserter = new Follower(to.GetId(),new Edge(distance));
            accessed.GetFollowers().AddLast(inserter);

            if (Nodes.ContainsKey(to.GetId()))
            {
                accessed2 = Nodes[to.GetId()];
            }
            else
            {
                throw new NodeNotFoundException("Prvek neexistuje");
            }
            accessed2.GetFollowers().AddLast(new Follower(from.GetId(), new Edge(distance)));


        }

        public INode RemoveNode(string key)
        {

            if (String.IsNullOrEmpty(key))
            {
                throw new InvalidKeyException("Pr�zdn� kl��");
            }
            if (Nodes.ContainsKey(key))
            {
                INode returnValue;
                List<string> ReferencedNodesKeys = new List<string>();
                // zpristupnit nasledniky klicoveho vrcholu
                foreach (Follower f in Nodes[key].GetFollowers())
                {
                    string addkey;
                    double distance;
                    f.GetFollowingNode(out addkey, out distance);
                    ReferencedNodesKeys.Add(addkey);
                }

                Nodes[key].GetFollowers().Clear();
                // odstranit reference na ne
                                
                    // prohledat n�sledn�ky a u kazdeho vrcholu obsahujici referenci na klicovy vrchol tuto referenci smazat
                foreach (string referencedNodesKey in ReferencedNodesKeys)
                {
                    Follower toRemove = null;
                  foreach (Follower f in Nodes[referencedNodesKey].GetFollowers())
                  {
                      string refkey;
                      double distance;
                      f.GetFollowingNode(out refkey, out distance);
                      if (refkey.Equals(key))
                      {
                          toRemove = f;
                      }
                  }
                    Nodes[referencedNodesKey].GetFollowers().Remove(toRemove);

                }
                   /* foreach (Follower f in Nodes[i].GetFollowers())
                    {
                        string refkey;
                        double distance;
                        f.GetFollowingNode(out refkey, out distance);
                        if (refkey.Equals(key))
                        {
                            Nodes[i].GetFollowers().Remove(f);
                        }
                    }
                    */
                returnValue = Nodes[key];

                Nodes.Remove(key);
                return returnValue;

            }

            throw new NodeNotFoundException("Prvek nenalezen");


        }

        public Edge RemoveEdge()
        {
            throw new System.NotImplementedException();
        }

        public INode FindNode(string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                throw new InvalidKeyException("Pr�zdn� kl��");
            }
            if (Nodes.ContainsKey(key))
            {
                return Nodes[key];
            }
            throw new NodeNotFoundException("Prvek nenalezen");
        }

        public Edge FindEdge()
        {
            throw new System.NotImplementedException();
        }

        public LinkedList<Follower> GetIncidentals(string key)
        {
            if (Nodes.ContainsKey(key))
            {
                
            
            return Nodes[key].GetFollowers();
            }
            throw new NodeNotFoundException("Prvek neexistuje");
        }

        public void GetAllNodes()
        {
            //TODO: dod�lat getnut� v�ech prvk� 
            foreach (string s in Nodes.Keys)
            {
                Console.WriteLine("{0} - {1}",s,Nodes[s].ToString());
                
            }
        }
    }
}