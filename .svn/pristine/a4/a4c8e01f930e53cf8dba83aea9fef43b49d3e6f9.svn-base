using System;

namespace INDSA_Sem_A.Graph
{
     [Serializable]
    public class Edge
    {
        private bool enabled;
        private double distance;
        
        public Edge(double distance)
        {
            enabled = true;
            this.distance = distance;
        }

        public void SetEnabled(bool enabled)
        {
            this.enabled = enabled;
        }
        public void ChangeDistance(double newdistance)
        {
            distance = newdistance;
        }

        public bool IsEnabled()
        {
            return enabled;
        }
        public double GetDistance()
        {
            return distance;
        }
    }
}