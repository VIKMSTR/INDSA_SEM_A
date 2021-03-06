﻿namespace INDSA_Sem_A
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NodeTypeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.InsertNodeButton = new System.Windows.Forms.ToolStripButton();
            this.InsertEdgeButton = new System.Windows.Forms.ToolStripButton();
            this.ShortestPathButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.loadButton = new System.Windows.Forms.ToolStripButton();
            this.matrixButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 433);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 66);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertNodeButton,
            this.InsertEdgeButton,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.NodeTypeCombo,
            this.ShortestPathButton,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.loadButton,
            this.toolStripSeparator5,
            this.matrixButton,
            this.toolStripSeparator6,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(654, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NodeTypeCombo
            // 
            this.NodeTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodeTypeCombo.Items.AddRange(new object[] {
            "Křižovatka",
            "Odpočívadlo",
            "Zastávka"});
            this.NodeTypeCombo.Name = "NodeTypeCombo";
            this.NodeTypeCombo.Size = new System.Drawing.Size(121, 25);
            this.NodeTypeCombo.SelectedIndexChanged += new System.EventHandler(this.NodeTypeCombo_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(22, 22);
            this.toolStripLabel1.Text = "---";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(654, 408);
            this.panel3.TabIndex = 3;
            this.panel3.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.panel3.MouseHover += new System.EventHandler(this.panel3_MouseHover);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackgroundImage = global::INDSA_Sem_A.Properties.Resources.MAP_BACKGRND;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 371);
            this.panel2.TabIndex = 2;
            this.panel2.TabStop = true;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // InsertNodeButton
            // 
            this.InsertNodeButton.Checked = true;
            this.InsertNodeButton.CheckOnClick = true;
            this.InsertNodeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InsertNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InsertNodeButton.Image = ((System.Drawing.Image)(resources.GetObject("InsertNodeButton.Image")));
            this.InsertNodeButton.ImageTransparentColor = System.Drawing.Color.White;
            this.InsertNodeButton.Name = "InsertNodeButton";
            this.InsertNodeButton.Size = new System.Drawing.Size(23, 22);
            this.InsertNodeButton.Text = "toolStripButton1";
            this.InsertNodeButton.CheckedChanged += new System.EventHandler(this.InsertNodeButton_CheckedChanged);
            // 
            // InsertEdgeButton
            // 
            this.InsertEdgeButton.CheckOnClick = true;
            this.InsertEdgeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InsertEdgeButton.Image = ((System.Drawing.Image)(resources.GetObject("InsertEdgeButton.Image")));
            this.InsertEdgeButton.ImageTransparentColor = System.Drawing.Color.White;
            this.InsertEdgeButton.Name = "InsertEdgeButton";
            this.InsertEdgeButton.Size = new System.Drawing.Size(23, 22);
            this.InsertEdgeButton.Text = "toolStripButton1";
            this.InsertEdgeButton.CheckedChanged += new System.EventHandler(this.InsertEdgeButton_CheckedChanged);
            // 
            // ShortestPathButton
            // 
            this.ShortestPathButton.CheckOnClick = true;
            this.ShortestPathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShortestPathButton.Image = ((System.Drawing.Image)(resources.GetObject("ShortestPathButton.Image")));
            this.ShortestPathButton.ImageTransparentColor = System.Drawing.Color.White;
            this.ShortestPathButton.Name = "ShortestPathButton";
            this.ShortestPathButton.Size = new System.Drawing.Size(23, 22);
            this.ShortestPathButton.Text = "toolStripButton1";
            this.ShortestPathButton.ToolTipText = "Vypočítat nejkratší trasu";
            this.ShortestPathButton.CheckedChanged += new System.EventHandler(this.ShortestPathButton_CheckedChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Uložit graf";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // loadButton
            // 
            this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(23, 22);
            this.loadButton.Text = "toolStripButton2";
            this.loadButton.ToolTipText = "Načíst graf ";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // matrixButton
            // 
            this.matrixButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.matrixButton.Image = ((System.Drawing.Image)(resources.GetObject("matrixButton.Image")));
            this.matrixButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.matrixButton.Name = "matrixButton";
            this.matrixButton.Size = new System.Drawing.Size(23, 22);
            this.matrixButton.Text = "Vytvořit matici následníků";
            this.matrixButton.Click += new System.EventHandler(this.matrixButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::INDSA_Sem_A.Properties.Resources.print_icon;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Vytisknout graf ..";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::INDSA_Sem_A.Properties.Resources.Button_Refresh_icon;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Nastavit všechny hrany na průchozí";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 499);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton InsertNodeButton;
        private System.Windows.Forms.ToolStripButton InsertEdgeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox NodeTypeCombo;
        private System.Windows.Forms.ToolStripButton ShortestPathButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton loadButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton matrixButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}