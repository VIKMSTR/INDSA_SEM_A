using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using INDSA_Sem_A.Dijkstra;
using INDSA_Sem_A.Exceptions;
using INDSA_Sem_A.GFX;
using INDSA_Sem_A.Graph;
using INDSA_Sem_A.RangeTree;
namespace INDSA_Sem_A
{
    public partial class MainForm : Form
    {

        #region Declarations
        private Graph.Graph g;

        private List<DrawingNode> drawingNodes;

        private List<INode> shortestPath;
        private Brush nodeBrush;
        private Brush busBrush;
        private Brush restBrush;
        private Brush edgeBrush;
        private Brush disabledBrush;
        private Brush shortestBrush;
        private Node created;
        private INode from;
        private INode to;
        private INode nearestNode;
        private bool begining;
        private bool drawShortestPath;
        private INode pathBegin;
        private INode pathEnd;
        private bool beginingPath;
        private double zoomstep;
        private Dijkstra.DijkstraAlgorithm dijkstra;
        private BinaryFormatter bf;
        private Point XORloc;

        private List<GraphNode> graphNodes;
        private RangeTree2D rangeTree;
        private Point selectFirst;
        private Point selectSecond;
        private Point XORselect;
        private bool selecting;
            #endregion
        
        #region GDI32 Imports
        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr HDC, int x, int y);
        [DllImport("gdi32.dll")]
        public static extern int SetROP2(IntPtr HDC, int drawMode);
        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr HDC, int x, int y, IntPtr lpPoint);
        [DllImport("gdi32.dll")]
        public static extern bool Ellipse(IntPtr HDC, int nLeftRect,
    int nTopRect, int nRightRect, int nBottomRect);
        [DllImportAttribute("gdi32.dll")]
        public static extern void Rectangle(IntPtr HDC, int X1, int Y1,
    int X2, int Y2);
        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr GetStockObject(int brStyle);
        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreatePen(int enPenStyle, int nWidth, int crColor);
        [DllImportAttribute("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr HDC, IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(int crColor);

        #endregion

        public MainForm()
        {
            InitializeComponent();
          panel2.Size = panel2.BackgroundImage.Size;
         
            
       //   panel2.Focus();

        //    panel2.AutoScroll = true;
             panel3.MouseWheel += OnMouseWheelZoom;
            drawingNodes = new List<DrawingNode>();
            shortestPath = new List<INode>();


            nodeBrush = new SolidBrush(Color.Black);
            busBrush = new SolidBrush(Color.BlueViolet);
            restBrush = new SolidBrush(Color.DarkOrange);
            edgeBrush = new SolidBrush(Color.SlateGray);
            disabledBrush = new SolidBrush(Color.Red);
            shortestBrush = new SolidBrush(Color.DarkBlue);
            
            NodeTypeCombo.SelectedIndex = 0;
            created = null;
            g = new Graph.Graph();
            begining = true;
            beginingPath = true;
            dijkstra = new DijkstraAlgorithm(g);
            zoomstep = 1;
            toolStripLabel1.Text = zoomstep*100 + " %";
            bf = new BinaryFormatter();
            selecting = false;
            graphNodes = new List<GraphNode>();
        }


        private void cara(Point od, Point kam, Color barva,Graphics g)
        {
            Point pom = new Point(od.X, od.Y);
            IntPtr HDC = g.GetHdc();

            IntPtr AktPen = CreatePen((int)PenStyles.PS_SOLID, 1, RGBColor(barva));

            IntPtr OldPen = SelectObject(HDC, AktPen);

            IntPtr OldBrush = SelectObject(HDC,
            GetStockObject((int)StockObjects.NULL_BRUSH));

            int OldMode = SetROP2(HDC, (int)RasterOps.R2_NOTXORPEN);

            MoveToEx(HDC, od.X, od.Y, IntPtr.Zero);

            LineTo(HDC, kam.X, kam.Y);

            SelectObject(HDC, OldPen);

            DeleteObject(AktPen);

            SelectObject(HDC, OldBrush);

            SetROP2(HDC, OldMode);

            // Release DC 
            g.ReleaseHdc(HDC);
        }

        private int RGBColor(Color barva)
        {
           // return ColorTranslator.ToWin32(barva);
           // return 0;
             return ((((int)barva.B) << 16) | (((int)barva.G << 8)) | ((int)barva.R));
        }

        private void OnMouseWheelZoom(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            if (zoomstep*100 >= 10)
            {
                
            
            int growX = (panel2.Width / 10);
            int growY = (panel2.Height / 10);
                double shiftRatioX = Convert.ToDouble(e.Location.X)/panel3.Width; //pomer polohy a sirky - detekce umisteni kurzoru a posunu
                double shiftRatioY = Convert.ToDouble(e.Location.Y)/panel3.Height;
            if (e.Delta > 0)
            {

                panel2.Width = panel2.Width + growX;

                panel2.Height = panel2.Height + growY;
                ;
                //
                panel2.Location = panel2.Location - new Size(Convert.ToInt32(growX*shiftRatioX),Convert.ToInt32(growY*shiftRatioY));
                zoomstep += 0.1;
                toolStripLabel1.Text = zoomstep * 100 + " %";
                //     panel2.Size = new Size(Convert.ToInt32(panel2.Width + 10 * e.Delta), Convert.ToInt32(panel2.Height + 10 * e.Delta));
                //   panel2.Size = new Size(panel2.Width+10,panel2.Height+10);
               
            }
            else
            {
                panel2.Width = panel2.Width - growX;
                panel2.Height = panel2.Height - growY;
                //    panel2.Location = panel2.Location + new Size(growX, growY);
                panel2.Location = panel2.Location + new Size(Convert.ToInt32(growX * shiftRatioX), Convert.ToInt32(growY * shiftRatioY));

                zoomstep -= 0.1;
                toolStripLabel1.Text = zoomstep * 100 + " %";
              
            }
            panel2.Invalidate();
            }
            //e = (HandledMouseEventArgs) e;

            
            
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
             
            Graphics gx = e.Graphics;

     
            if (drawingNodes.Count == 0)
            {
                return;
            }
           

            #region DRAW NODES

            foreach (DrawingNode dn in drawingNodes)
            {
                if (dn.nodeID.Contains("K"))
                {
                    gx.FillEllipse(nodeBrush, Convert.ToInt32((dn.drawLocation.X - 4) /dn.zoomed * zoomstep), Convert.ToInt32((dn.drawLocation.Y - 4) /dn.zoomed* zoomstep ), Convert.ToInt32(8 * zoomstep), Convert.ToInt32(8 * zoomstep));
                    gx.DrawString(dn.nodeID, new Font(FontFamily.GenericSansSerif, 6), nodeBrush, Convert.ToInt32((dn.drawLocation.X + 10) /dn.zoomed*zoomstep),
                                  Convert.ToInt32((dn.drawLocation.Y - 10)/ dn.zoomed *zoomstep));


                }
                else if (dn.nodeID.Contains("Z"))
                {
                    gx.FillEllipse(busBrush, Convert.ToInt32((dn.drawLocation.X - 4) / dn.zoomed * zoomstep), Convert.ToInt32((dn.drawLocation.Y - 4) / dn.zoomed * zoomstep ), Convert.ToInt32(8 * zoomstep), Convert.ToInt32(8 * zoomstep));
                    gx.DrawString(dn.nodeID, new Font(FontFamily.GenericSansSerif, 6), busBrush, Convert.ToInt32((dn.drawLocation.X + 10) /dn.zoomed * zoomstep),
                                 Convert.ToInt32((dn.drawLocation.Y - 10) /dn.zoomed * zoomstep));


                }
                else
                {
                    gx.FillEllipse(restBrush,  Convert.ToInt32((dn.drawLocation.X - 4) / dn.zoomed * zoomstep), Convert.ToInt32((dn.drawLocation.Y - 4) / dn.zoomed * zoomstep ), Convert.ToInt32(8 * zoomstep), Convert.ToInt32(8 * zoomstep));
                    gx.DrawString(dn.nodeID, new Font(FontFamily.GenericSansSerif, 6), restBrush, Convert.ToInt32((dn.drawLocation.X + 10) / dn.zoomed* zoomstep),
                                Convert.ToInt32((dn.drawLocation.Y - 10) / dn.zoomed * zoomstep));


                }
            }

            #endregion

            #region DRAW EDGES
            DrawEdges(gx);
/*
            INode n = null;
            string key;
            double dist;
            foreach (DrawingNode dn in drawingNodes)
            {
                n = g.FindNode(dn.nodeID);
                foreach (Follower f in n.GetFollowers())
                {
                    bool enabled = f.GetFollowingNode(out key, out dist);
                    INode dest = g.FindNode(key);

                    if (enabled)
                    {
                        gx.DrawLine(new Pen(edgeBrush, 2), Convert.ToInt32(n.GetLocation().X * zoomstep), Convert.ToInt32(n.GetLocation().Y * zoomstep), Convert.ToInt32(dest.GetLocation().X*zoomstep), Convert.ToInt32(dest.GetLocation().Y*zoomstep));

                    }
                    else
                    {
                        gx.DrawLine(new Pen(disabledBrush, 3), Convert.ToInt32(n.GetLocation().X * zoomstep), Convert.ToInt32(n.GetLocation().Y * zoomstep), Convert.ToInt32(dest.GetLocation().X * zoomstep), Convert.ToInt32(dest.GetLocation().Y * zoomstep));

                    }
                }
            }*/
            #endregion

            if (drawShortestPath)
            {
           #region DRAW SHORTEST PATH
                /// 
                /// 
                /// 
                for(int i = 0; i < shortestPath.Count-1; i++ ) 
                {
                    gx.DrawLine(new Pen(shortestBrush, 3), Convert.ToInt32(shortestPath[i].GetLocation().X * zoomstep), Convert.ToInt32(shortestPath[i].GetLocation().Y*zoomstep), Convert.ToInt32(shortestPath[i + 1].GetLocation().X*zoomstep), Convert.ToInt32(shortestPath[i + 1].GetLocation().Y*zoomstep));
                }
           #endregion
            }

            if (nearestNode != null)
            {
                #region DRAW NEAREST POINT

                foreach (DrawingNode dn in drawingNodes)
                {
                    if (dn.nodeID == nearestNode.GetId())
                    {
                        gx.FillEllipse(disabledBrush, dn.drawLocation.X - 4, dn.drawLocation.Y - 4, 8, 8);

                    }
                }

                #endregion

            }

         //   bg.Render();
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!begining && to == null && from != null && drawingNodes.Count > 1 && InsertEdgeButton.Checked&&e.Button == MouseButtons.Left)
            {
                
                cara(from.GetLocation(),XORloc,Color.MediumBlue,panel2.CreateGraphics());
                XORloc = e.Location;
                cara(from.GetLocation(), XORloc, Color.MediumBlue, panel2.CreateGraphics());
                //   panel2.Invalidate();
            }

            if (selecting  &&  drawingNodes.Count > 1 && InsertEdgeButton.Checked &&
                e.Button == MouseButtons.Right)
            {
                //smazani puvodnich car;

              //  MessageBox.Show("Pravej drag");
                 cara(selectFirst, new Point (selectFirst.X,XORselect.Y),Color.DarkRed,panel2.CreateGraphics() );
                cara(selectFirst, new Point(XORselect.X, selectFirst.Y), Color.DarkRed, panel2.CreateGraphics());
                cara( new Point(XORselect.X, selectFirst.Y),XORselect, Color.DarkRed, panel2.CreateGraphics());
                cara(new Point(selectFirst.X, XORselect.Y), XORselect, Color.DarkRed, panel2.CreateGraphics());
                // cara(selectFirst, new Point(selectFirst.X, XORselect.Y), Color.DarkRed, panel2.CreateGraphics());
                //kresleni novych car;
                XORselect = e.Location;
                cara(selectFirst, new Point(selectFirst.X, XORselect.Y), Color.DarkRed, panel2.CreateGraphics());
                cara(selectFirst, new Point(XORselect.X, selectFirst.Y), Color.DarkRed, panel2.CreateGraphics());
                cara(new Point(XORselect.X, selectFirst.Y), XORselect, Color.DarkRed, panel2.CreateGraphics());
                cara(new Point(selectFirst.X, XORselect.Y), XORselect, Color.DarkRed, panel2.CreateGraphics());
            }
         //   selecting = false;
            //panel2.Focus();
            /*string key = FindNearestNode(e.Location);
            if (String.IsNullOrEmpty(key))
            {
                return;
            }
            nearestNode = g.FindNode(key);*/
            //  panel2.Invalidate();
        }
      
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {

            if (!ShortestPathButton.Checked)
            {
                if (InsertNodeButton.Checked) // vkladame vrcholy
            
                    if(e.Button == MouseButtons.Left){
                    #region INSERT NODE

                {
                    if (NodeTypeCombo.SelectedIndex == 0)
                    {
                        created = new Node(NodeType.Crossroads, new Point(e.Location.X, e.Location.Y));
                    }
                    else if (NodeTypeCombo.SelectedIndex == 1)
                    {
                        created = new Node(NodeType.RestingPlace, e.Location);
                    }
                    else
                    {
                        created = new Node(NodeType.BusStop, e.Location);
                    }

                    g.AddNewNode(created);
                    string id = created.GetId();
                    graphNodes.Add(new GraphNode(created.GetId(),created.GetLocation()));
                    drawingNodes.Add(new DrawingNode(e.Location, id,zoomstep));

                    // InsertNode();
                    panel2.Invalidate();
                    return;
                }

                #endregion

                    }else if (e.Button == MouseButtons.Right)
                    #region REMOVE NODE
                    {
                        if (drawingNodes.Count != 0)
                        {
                            g.RemoveNode(FindNearestNode(e.Location));
                            DrawingNode removing = null;
                            GraphNode removingNode = null;
                            foreach (DrawingNode dn in drawingNodes)
                            {
                                if (FindNearestNode(e.Location).Equals(dn.nodeID))
                                {
                                    removing = dn;
                                }
                            }
                            foreach (GraphNode gn in graphNodes)
                            {
                                if (FindNearestNode(e.Location).Equals(gn.Key))
                                {
                                    removingNode = gn;
                                }
                            }
                            drawingNodes.Remove(removing);
                            graphNodes.Remove(removingNode);
                            panel2.Invalidate();
                        }
                        else
                        {
                            MessageBox.Show("V grafu nejsou žádné vrcholy k odebrání", "Nelze odebrat vrchol");
                        }
                    } 
                    #endregion

                if (InsertEdgeButton.Checked) // vytvarime hrany
                
                    #region INSERT EDGE

                {

                    if (drawingNodes.Count == 0)
                    {
                        return;
                    }
                    string nearestkey = FindNearestNode(e.Location);
                    {
                        // je u bodu

                        if (begining) // nastavujeme pocatecni bod
                        {

                            to = null;
                            from = g.FindNode(nearestkey); // oznacit jako pocatek
                            begining = false;

                     /*       if (e.Button == MouseButtons.Right && selecting == false)
                            {
                            //    XORloc = new Point(from.GetLocation().X, from.GetLocation().Y);
                                selectFirst = e.Location;
                                selecting = true;
                            }*/
                            //else
                            {
                                XORloc = new Point(from.GetLocation().X, from.GetLocation().Y);
                                cara(from.GetLocation(), XORloc, Color.MediumBlue, panel2.CreateGraphics());
                            }
                           

                        }
                        else //nastavujeme koncovy bod
                        {
                            to = g.FindNode(nearestkey); // oznacit jako konec
                            begining = true;

                        }
                        if (to != null)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                try
                                {
                                    g.AddNewEdge(from, to);
                                }
                                catch (LoopEdgeException exx)
                                {
                                    MessageBox.Show(
                                        "Smyčková hrana nemůže být vložena ( počáteční vrchol se shoduje s koncovým)",
                                        "Nelze vložit smyčkovou hranu");
                                }
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                              /*  if (selecting)
                                {
                                    ;
                                }
                                selectFirst = e.Location;
                                List<GraphNode> selected = SelectNodes();*/
                               
                                foreach (Follower f in from.GetFollowers())
                                {
                                    if (f.GetReferencedKey() == to.GetId())
                                    {
                                        f.DisableEdge();
                                    }
                                }
                                foreach (Follower f in to.GetFollowers())
                                {
                                    if (f.GetReferencedKey() == from.GetId())
                                    {
                                        f.DisableEdge();

                                    }
                                }
                            }
                        }

                    }
                   
                    
                    panel2.Invalidate();
                    return;
                }

                #endregion}
            }
            else
            {
                    #region SHORTEST PATH
                if (drawingNodes.Count == 0 || drawingNodes.Count == 1)
                {
                    MessageBox.Show("Nedostatek vrcholů pro výpočet cesty","Chyba hledání cesty");
                    return;
                }
                if (e.Button == MouseButtons.Right)
                {
                    pathBegin = null;
                    pathEnd = null;
                    beginingPath = true;
                    ShortestPathButton.Checked = false;
                    shortestPath.Clear();
                    return;
                }
                if (beginingPath)
                {
                    string key = FindNearestNode(e.Location);
                    pathBegin = g.FindNode(key);
                    beginingPath = false;
                    pathEnd = null;
                }
                else  
                {
                    string key2 = FindNearestNode(e.Location);
                    pathEnd = g.FindNode(key2);
               
                    shortestPath = dijkstra.ExecuteOptimized(pathBegin, pathEnd);
                    drawShortestPath = true;
                    panel2.Invalidate();
                 
                } 

                #endregion
            }
           
        }

        


        private void InsertEdgeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (InsertEdgeButton.Checked)
            {
                InsertNodeButton.Checked = false;
            }
            else
            {
                InsertNodeButton.Checked = true;
            }
        }

        private void InsertNodeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (InsertNodeButton.Checked)
            {
                InsertEdgeButton.Checked = false;
            }
            else
            {
                InsertEdgeButton.Checked = true;
            }
        }

        private void ShortestPathButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!ShortestPathButton.Checked)
            {
                shortestPath = new List<INode>();
                drawShortestPath = false;
                panel2.Invalidate();
            }
        }

      private string FindNearestNode(Point e)
      {
          double dist = double.PositiveInfinity;
          string key = null;
          foreach (DrawingNode dn in drawingNodes)
          {
              double calcdist = Math.Sqrt(Math.Pow(dn.drawLocation.X/dn.zoomed*zoomstep - e.X*zoomstep, 2) + Math.Pow(dn.drawLocation.Y/dn.zoomed*zoomstep - e.Y*zoomstep, 2));
              if (calcdist < dist)
              {
                  key = dn.nodeID;
                  dist = calcdist;
              }
          }
          return key;
      }

      private void panel2_MouseDown(object sender, MouseEventArgs e)
      {
          if (e.Button == MouseButtons.Right && selecting == false)
          {
              //    XORloc = new Point(from.GetLocation().X, from.GetLocation().Y);
              selectFirst = XORselect = e.Location;
              selecting = true;
          }
      }
       

       
        private void NodeTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendKeys.SendWait("{ESC}"); //hack na ztratu focusu
           

        }

        private void matrixButton_Click(object sender, EventArgs e)
        {
          
          Dictionary<string,Dictionary<string,string>> fm = dijkstra.GenerateFollowerMatrix();
          MatrixForm mf = new MatrixForm();
            mf.SetMatrix(fm);
            mf.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using(FileStream fs = new FileStream("graph.bin",FileMode.Create))
            {
                bf.Serialize(fs,g);
            }
            /*using (FileStream fs = new FileStream("nodegraph.bin", FileMode.Create))
            {
                bf.Serialize(fs, g);
            }*/
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("graph.bin", FileMode.Open))
            {
                g = (Graph.Graph) bf.Deserialize(fs);
                dijkstra.SetGraph(g);

            }
            drawingNodes.Clear();
            foreach (string key in g.Nodes.Keys)
            {

                drawingNodes.Add(new DrawingNode(g.Nodes[key].GetLocation(),g.Nodes[key].GetId(),1.0));
            }
            foreach (string key in g.Nodes.Keys)
            {

                graphNodes.Add(new GraphNode(key,g.Nodes[key].GetLocation()));
            }
               
            panel2.Invalidate();
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
   //         panel3.Focus();
   //         MessageBox.Show("!");
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
           panel3.Focus();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel3.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && InsertEdgeButton.Checked)
            {
            DisableNodes(selectFirst,e.Location);
            selectFirst = Point.Empty;
            XORselect = Point.Empty;
            selecting = false;
             Invalidate();
            }
         
        }
        private void DisableNodes(Point first, Point second)
        {
            List<GraphNode> result = new List<GraphNode>();
            rangeTree = new RangeTree2D(graphNodes);
       if (second.X <= first.X && second.Y <= first.Y)
       {
           result = rangeTree.GetAllInRange(second, first); // pokud je druhej mensi nez prvni, prohodit
       }
       else
       {
           result = rangeTree.GetAllInRange(first, second);
       }

            foreach (var graphNode in result) // projit vsechny vysledne vrcholy
            {
           INode n = g.FindNode(graphNode.Key);
                foreach (var follower in n.GetFollowers()) // a zakazat vsechny jejich hrany
                {
                    follower.DisableEdge();
                }
            }

        }
       
        private void DrawEdges(Graphics gfx)
        {
            INode n = null;
            string key;
            double dist;
            foreach (DrawingNode dn in drawingNodes)
            {
                n = g.FindNode(dn.nodeID);
                foreach (Follower f in n.GetFollowers())
                {
                    bool enabled = f.GetFollowingNode(out key, out dist);
                    INode dest = g.FindNode(key);

                    if (enabled)
                    {
                        gfx.DrawLine(new Pen(edgeBrush, 2), Convert.ToInt32(n.GetLocation().X * zoomstep), Convert.ToInt32(n.GetLocation().Y * zoomstep), Convert.ToInt32(dest.GetLocation().X*zoomstep), Convert.ToInt32(dest.GetLocation().Y*zoomstep));

                    }
                    else
                    {
                        gfx.DrawLine(new Pen(disabledBrush, 3), Convert.ToInt32(n.GetLocation().X * zoomstep), Convert.ToInt32(n.GetLocation().Y * zoomstep), Convert.ToInt32(dest.GetLocation().X * zoomstep), Convert.ToInt32(dest.GetLocation().Y * zoomstep));

                    }
                }
        }
      
            }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (graphNodes.Count >= 1)
            {

                INode enablenode;
            foreach (var gr in graphNodes)
            {
                enablenode = g.FindNode(gr.Key);
                foreach (var follower in enablenode.GetFollowers())
                {
                    follower.EnableEdge();
                }
            }
                panel2.Invalidate();
            }
        }

      
    }

    [Serializable]
    internal class DrawingNode
    {
        public Point drawLocation;
        public double zoomed;
        public string nodeID;

        public DrawingNode(Point loc, string nodeID,double zoomed)
        {
            drawLocation = loc;
            this.nodeID = nodeID;
            this.zoomed = zoomed;
        }
    }
}
