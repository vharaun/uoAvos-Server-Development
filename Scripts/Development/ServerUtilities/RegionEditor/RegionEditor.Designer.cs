
namespace Server.Tools
{
    public partial class RegionEditor
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.Canvas = new Server.Tools.Controls.MapCanvas();
            this.Frame = new System.Windows.Forms.SplitContainer();
            this.Navigation = new System.Windows.Forms.SplitContainer();
            this.Regions = new Server.Tools.Controls.MapRegionsTree();
            this.Props = new Server.Tools.Controls.RegionPropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            this.Frame.Panel1.SuspendLayout();
            this.Frame.Panel2.SuspendLayout();
            this.Frame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navigation)).BeginInit();
            this.Navigation.Panel1.SuspendLayout();
            this.Navigation.Panel2.SuspendLayout();
            this.Navigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.AutoScroll = true;
            this.Canvas.AutoSize = true;
            this.Canvas.BackColor = System.Drawing.Color.Black;
            this.Canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Map = null;
            this.Canvas.MapRegion = null;
            this.Canvas.Margin = new System.Windows.Forms.Padding(0);
            this.Canvas.Name = "Canvas";
            this.Canvas.ScrollX = 0;
            this.Canvas.ScrollY = 0;
            this.Canvas.Size = new System.Drawing.Size(543, 623);
            this.Canvas.TabIndex = 0;
            // 
            // Frame
            // 
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Frame.Name = "Frame";
            // 
            // Frame.Panel1
            // 
            this.Frame.Panel1.Controls.Add(this.Navigation);
            this.Frame.Panel1MinSize = 200;
            // 
            // Frame.Panel2
            // 
            this.Frame.Panel2.BackColor = System.Drawing.Color.Black;
            this.Frame.Panel2.Controls.Add(this.Canvas);
            this.Frame.Panel2MinSize = 200;
            this.Frame.Size = new System.Drawing.Size(848, 623);
            this.Frame.SplitterDistance = 300;
            this.Frame.SplitterWidth = 5;
            this.Frame.TabIndex = 1;
			// 
			// Navigation
			// 
			this.Navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Navigation.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.Navigation.Location = new System.Drawing.Point(0, 0);
            this.Navigation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Navigation.Name = "Navigation";
            this.Navigation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Navigation.Panel1
            // 
            this.Navigation.Panel1.Controls.Add(this.Regions);
            this.Navigation.Panel1MinSize = 200;
            // 
            // Navigation.Panel2
            // 
            this.Navigation.Panel2.Controls.Add(this.Props);
            this.Navigation.Panel2MinSize = 200;
            this.Navigation.Size = new System.Drawing.Size(300, 623);
            this.Navigation.SplitterDistance = 200;
            this.Navigation.SplitterWidth = 5;
            this.Navigation.TabIndex = 1;
			// 
			// Regions
			// 
			this.Regions.AllowDrop = true;
            this.Regions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Regions.HideSelection = false;
            this.Regions.LabelEdit = true;
            this.Regions.Location = new System.Drawing.Point(0, 0);
            this.Regions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Regions.Name = "Regions";
            this.Regions.Size = new System.Drawing.Size(300, 200);
            this.Regions.Sorted = true;
            this.Regions.TabIndex = 0;
            // 
            // Props
            // 
            this.Props.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Props.HelpVisible = false;
            this.Props.Location = new System.Drawing.Point(0, 0);
            this.Props.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Props.Name = "Props";
            this.Props.SelectedObject = null;
            this.Props.Size = new System.Drawing.Size(300, 419);
            this.Props.TabIndex = 0;
            // 
            // RegionEditor
            // 
            this.ClientSize = new System.Drawing.Size(848, 623);
            this.Controls.Add(this.Frame);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "RegionEditor";
            this.Text = "Region Editor";
            this.Frame.Panel1.ResumeLayout(false);
            this.Frame.Panel2.ResumeLayout(false);
            this.Frame.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).EndInit();
            this.Frame.ResumeLayout(false);
            this.Navigation.Panel1.ResumeLayout(false);
            this.Navigation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Navigation)).EndInit();
            this.Navigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.SplitContainer Frame;
		private Server.Tools.Controls.MapCanvas Canvas;
		private Server.Tools.Controls.MapRegionsTree Regions;
		private System.Windows.Forms.SplitContainer Navigation;
		private Server.Tools.Controls.RegionPropertyGrid Props;
	}
}
