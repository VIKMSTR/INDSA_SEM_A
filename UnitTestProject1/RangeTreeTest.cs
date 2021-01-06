using System;
using System.Collections.Generic;
using System.Drawing;
using INDSA_Sem_A.RangeTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class RangeTreeTest
    {/*
        private List<GraphNode> graphNodes;
        private RangeTree2D rangeTree2D;*/
        public  RangeTreeTest()

    {
       // rangeTree2D = new RangeTree2D(graphNodes);
       // graphNodes = new List<GraphNode>();
    }
        [TestMethod]
        public void TestBuilding()
        {
            List<GraphNode> graphNodes = new List<GraphNode>();
          /* for (int i = 0; i < 20; i++)
           {
               graphNodes.Add(new GraphNode(Convert.ToString(i),new Point(i,i*2)));
           }*/
            graphNodes.Add(new GraphNode("aa", new Point(2,5)));
            graphNodes.Add(new GraphNode("bb", new Point(3, 1)));
            graphNodes.Add(new GraphNode("cc", new Point(4, 8)));
            graphNodes.Add(new GraphNode("dd", new Point(3, 6)));
            graphNodes.Add(new GraphNode("ee", new Point(9, 11)));
            graphNodes.Add(new GraphNode("ff", new Point(5, 88)));
            graphNodes.Add(new GraphNode("gg", new Point(40, 2)));
            graphNodes.Add(new GraphNode("hh", new Point(52, 5)));

           RangeTree2D rangeTree2D = new RangeTree2D(graphNodes);
            TreeNode<GraphNode> root = rangeTree2D.Root;

            #region null/not null tests
            Assert.IsNotNull(rangeTree2D);
            Assert.IsNotNull(root);
            Assert.IsNotNull(root.LeftChild);
            Assert.IsNotNull(root.RightChild);
            Assert.IsNotNull(root.NextDimensionRoot);
            Assert.IsNull(root.Value);
            #endregion

            #region equality tests
            Assert.AreEqual(4,root.Median);
            Assert.AreEqual(5,root.NextDimensionRoot.Median);
            #endregion

          
           

        }
        [TestMethod]
        public void TestGetting()
        {
            List<GraphNode> graphNodes = new List<GraphNode>();
            
          
            graphNodes.Add(new GraphNode("aa", new Point(2, 5)));
            graphNodes.Add(new GraphNode("bb", new Point(3, 1)));
            graphNodes.Add(new GraphNode("cc", new Point(4, 8)));
            graphNodes.Add(new GraphNode("dd", new Point(3, 6)));
            graphNodes.Add(new GraphNode("ee", new Point(9, 11)));
            graphNodes.Add(new GraphNode("ff", new Point(5, 88)));
            graphNodes.Add(new GraphNode("gg", new Point(40, 2)));
            graphNodes.Add(new GraphNode("hh", new Point(52, 5)));

            RangeTree2D rangeTree2D = new RangeTree2D(graphNodes);
            TreeNode<GraphNode> root = rangeTree2D.Root;

            Assert.IsNotNull(rangeTree2D);
            Assert.IsNotNull(root);


            List < GraphNode > selected = rangeTree2D.GetAllInRange(new Point(2, 4), new Point(10, 10));

            Assert.IsNotNull(rangeTree2D);
            Assert.AreEqual(3,selected.Count);


            List<GraphNode> err = null;
            try
            {
                Console.WriteLine("Trying to make an error");
               err = rangeTree2D.GetAllInRange(new Point(), new Point());
            }
            catch (Exception e)
            {
                Console.WriteLine("OK: " + e.Message);
                Assert.IsNull(err);
            }
        }
    [TestMethod]
    public void TestSingle()
    {
        List<GraphNode> graphNodes = new List<GraphNode>();
        List<GraphNode> result = new List<GraphNode>();
        graphNodes.Add(new GraphNode("aaa", new Point(10, 10)));
        RangeTree2D rangeTree2D = new RangeTree2D(graphNodes);
        TreeNode<GraphNode> root = rangeTree2D.Root;

       result = rangeTree2D.GetAllInRange(new Point(5, 5), new Point(15, 15));
    }
    }

}
