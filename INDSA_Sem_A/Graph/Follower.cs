using System;

namespace INDSA_Sem_A.Graph
{
    [Serializable]
    public class Follower
    {
        private string Id;
       
        private Edge edge; // hrana, p�es kterou se k vrcholu p�istupuje 

        public Follower(string id, Edge edge)
        {
            this.Id = id;
            this.edge = edge;
        }

        public bool GetFollowingNode(out string Id, out double distance) /// vraci jestli lze prejit, vystupni atributy jsou id dalsiho vrcholu a vzdalenost
        {
            Id = this.Id;
            distance = edge.GetDistance();
            return edge.IsEnabled();
        }
        
        public void DisableEdge()
        {
            edge.SetEnabled(false);
        }
        public void EnableEdge()
        {
            edge.SetEnabled(true);
        }

        public string GetReferencedKey()
        {
            return Id;
        }

    }
}