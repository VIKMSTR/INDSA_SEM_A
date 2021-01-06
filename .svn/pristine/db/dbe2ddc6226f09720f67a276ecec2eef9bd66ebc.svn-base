namespace INDSA_Sem_A.Graph
{
    public interface IGraph<KeyType,ListType>
    {

        #region Informative Methods
        bool IsEmpty();
        int NumberOfElements();
        #endregion

        #region Inserting Methods
        void AddNewNode(INode n);
        void AddNewEdge(INode from, INode to);
        #endregion

        #region Removing Methods
        INode RemoveNode(KeyType key);
        Edge RemoveEdge();
        #endregion

        #region Accessing Methods
        INode FindNode(KeyType key);
        Edge FindEdge();
        ListType GetIncidentals(KeyType key);
        void GetAllNodes();
        #endregion

    }
}