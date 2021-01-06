using INDSA_Sem_A.Graph;

namespace INDSA_Sem_A.Dijkstra
{
    public interface IDijkstraNode
    {
        double GetRank();
        void SetRank(double set);
        INode GetPredchudce();
        void SetPredchudce(INode set); 
    }
}