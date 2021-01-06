using System;
using System.Collections.Generic;
using System.Drawing;

namespace INDSA_Sem_A.RangeTree
{
    public class RangeTree2D : IRangeTree2D<GraphNode>
    {
        public TreeNode<GraphNode> Root { get; private set; }
        private TreeNode<GraphNode> Predchudce; 
        private const int XDimension = 0;
        private const int YDimension = 1;

        public RangeTree2D(IEnumerable<GraphNode> unsortedItems)
        {
            Root = BuildTree(unsortedItems, XDimension);
        }

        public TreeNode<GraphNode> BuildTree(IEnumerable<GraphNode> unsortedItems, int dimension)
        {
            List<GraphNode> graphNodes = new List<GraphNode>(unsortedItems);
            Predchudce = null;
           if (dimension == XDimension)
           {
               graphNodes.Sort(new CompareByX());
               return BuildSubTree(graphNodes, dimension);
           }
           else
           {
               graphNodes.Sort(new CompareByY());
               return BuildSubTree(graphNodes, dimension);
           }
        }

        public TreeNode<GraphNode> BuildSubTree(List<GraphNode> sortedItems, int dimension)
        {
            TreeNode<GraphNode> node = new TreeNode<GraphNode>();

         node.Median =   DetermineMedian(sortedItems,dimension);

            if (sortedItems.Count > 1)
            {
                List<GraphNode> leftList;
                List<GraphNode> rightList;
                SplitList(sortedItems, out leftList, out rightList);
                node.LeftChild = BuildSubTree(leftList, dimension);
                node.RightChild = BuildSubTree(rightList, dimension);
          
            }
            else
            {
                node.Value = sortedItems[0]; //list
                //zřetězení listů
                if (Predchudce == null)
                {
                    Predchudce = node;
                }
                else
                {
                    Predchudce.NextLeaf = node;
                  //  node.NextLeaf = Predchudce;
                    Predchudce = node;
                }
            }

            if (dimension == XDimension && sortedItems.Count > 1) //vytváření roota druhé dimenze
            {
                // CompareByY cmpY = new CompareByY();
                //   List<GraphNode> nextDimensionList = new List<GraphNode>(sortedItems);
                //    nextDimensionList.Sort(new CompareByY());
                TreeNode<GraphNode> Predchudce2=Predchudce;
                Predchudce = null;
                node.NextDimensionRoot = BuildTree(sortedItems, YDimension);
                Predchudce = Predchudce2;
            }
            
               
          
            return node;
        }

        private int DetermineMedian(List<GraphNode> sortedItems, int dimension)
        {
           
            if (dimension == XDimension) //budujeme podle X
            {
                if (sortedItems.Count%2 == 0) //sudy pocet prvku
                {
                    int index1 = sortedItems.Count/2 - 1;
                    int index2 = sortedItems.Count/2;

                    return (sortedItems[index1].Location.X + sortedItems[index2].Location.X)/2;
                }
                int index = sortedItems.Count/2;
                return sortedItems[index].Location.X;
            }
            if (dimension == YDimension) //budujeme podle Y
            {
                if (sortedItems.Count % 2 == 0) //sudy pocet prvku
                {
                    int index1 = sortedItems.Count / 2 - 1;
                    int index2 = sortedItems.Count / 2;

                    return (sortedItems[index1].Location.Y + sortedItems[index2].Location.Y) / 2;
                }
                int index = sortedItems.Count / 2;
                return sortedItems[index].Location.Y;
            }
            throw new Exception("Invalid dimension specifier");
        }

        //urci median


        private static void SplitList(List<GraphNode> inputList, out List<GraphNode> firstHalf,out List<GraphNode> secondHalf)
        {
            int firstHalfCount = inputList.Count - inputList.Count/2;

            firstHalf = new List<GraphNode>(firstHalfCount);
            secondHalf = new List<GraphNode>(inputList.Count - firstHalfCount);

            int i = 0;

            foreach (var graphNode in inputList)
            {
                if (i < firstHalfCount)
                {
                    firstHalf.Add(graphNode);
                }
                else
                {
                    secondHalf.Add(graphNode);
                }
                i++;
            }
        }


        public List<GraphNode> GetAllInRange(Point start, Point end)
        {
            if (start == null || end == null || start.IsEmpty || end.IsEmpty || 
                start.X < 0 || start.Y < 0 || end.X < 0 || end.Y < 0 || 
                start.X > end.X || start.Y > end.Y
                )
            {
                throw new Exception("Invalid input to search");
              
               
            }

            int minX = start.X;
            int maxX = end.X;

            int minY = start.Y;
            int maxY = end.Y;

            var result = new List<GraphNode>();
            TreeNode<GraphNode> node = Root;
            TreeNode<GraphNode> yNode; 
            while (node.Value == null)
            {
                if (minX <= node.Median && maxX <= node.Median)
                {
                    //jdeme doleva
                    node = node.LeftChild;
                    continue;
                    
                }
                if (minX > node.Median && maxX > node.Median)
                {
                    //jdeme doprava
                    node = node.RightChild;
                    continue;
                    
                    
                }
                if (minX <= node.Median && maxX > node.Median)
                {
                    #region Y search
                    //jsme na místě - budeme cestovat po Y
                    yNode = node.NextDimensionRoot;

                    while (yNode.Value == null) // prepsat tak, aby kdyz je null se to breaklo 
                    {
                       /*   if (yNode.Value != null)  /// jsme na listu
                          {
                              if (yNode.Value.Location.X >= minX && yNode.Value.Location.X <=  maxX)
                                   {

                                       if (yNode.Value.Location.Y >= minY && yNode.Value.Location.Y <= maxY){
                                       result.Add(yNode.Value);
                          return result;
                                       }
                                   }
                         
                          }*/
                        if (minY <= yNode.Median && maxY <= yNode.Median)
                        {
                            //jdeme doleva
                            yNode = yNode.LeftChild;
                            if (yNode.Value != null)  /// jsme na listu
                            {
                                if (yNode.Value.Location.X >= minX && yNode.Value.Location.X <= maxX)
                                {

                                    if (yNode.Value.Location.Y >= minY && yNode.Value.Location.Y <= maxY)
                                    {
                                        result.Add(yNode.Value);
                                        return result;
                                    }
                                }

                            }
                            continue;

                        }
                        if (minY > yNode.Median && maxY > yNode.Median)
                        {
                            yNode = yNode.RightChild;
                            if (yNode.Value != null)  /// jsme na listu
                            {
                                if (yNode.Value.Location.X >= minX && yNode.Value.Location.X <= maxX)
                                {

                                    if (yNode.Value.Location.Y >= minY && yNode.Value.Location.Y <= maxY)
                                    {
                                        result.Add(yNode.Value);
                                        return result;
                                    }
                                }

                            }
                            continue;

                            //jdeme doprava
                        }
                        if (minY <= yNode.Median && maxY > yNode.Median)
                        {
                            //tak ..jsme na medianu Y 
                            // potrebujeme se dostat az na listy Ystromu a ty ziskat
                            TreeNode<GraphNode> passNode = yNode;
                            result.Clear();
                            while (true)
                            {
                                passNode = passNode.LeftChild; // do listu nejvice vlevo
                                if (passNode.Value != null)
                                {
                                    break;
                                }
                            }

                            while(true)
                            {


                                // budeme ovsem muset testovat, zdali xova souradnice neni nahodou mimo rozsah (tady jsou razene jinak)
                               
                                 if (passNode.Value.Location.X >= minX && passNode.Value.Location.X <=  maxX)
                                 {

                                     if (passNode.Value.Location.Y >= minY && passNode.Value.Location.Y <= maxY){
                                     result.Add(passNode.Value);
                                     }
                                 }
                                passNode = passNode.NextLeaf; // jedeme dal
                                if (passNode == null)
                                {
                                    return result;
                                }
                                
                            }
                        }


                    }

                    #endregion
                }
            }
           


            return result;
        }

       
        public GraphNode GetSingleNode(Point finding, int tolerance)
        {


            Point start = new Point();
            Point end = new Point();
            start.X = finding.X - tolerance/2;
            start.Y = finding.Y - tolerance/2;
            end.X = finding.X + tolerance/2;
            end.Y = finding.Y + tolerance/2;

            List<GraphNode> found = GetAllInRange(start, end);

            return found[0];

        }
 
    }
}