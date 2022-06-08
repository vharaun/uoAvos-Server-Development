
namespace Server.Tools
{
    public partial class Editor
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
            this.Canvas = new Server.Tools.MapCanvas();
            this.Frame = new System.Windows.Forms.SplitContainer();
            this.Regions = new Server.Tools.MapRegionsTree();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            this.Frame.Panel1.SuspendLayout();
            this.Frame.Panel2.SuspendLayout();
            this.Frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.AutoScroll = true;
            this.Canvas.AutoSize = true;
            this.Canvas.BackColor = System.Drawing.Color.Black;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Margin = new System.Windows.Forms.Padding(0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1197, 1082);
            this.Canvas.TabIndex = 0;
            // 
            // Frame
            // 
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Frame.Name = "Frame";
            // 
            // Frame.Panel1
            // 
            this.Frame.Panel1.Controls.Add(this.Regions);
            this.Frame.Panel1MinSize = 200;
            // 
            // Frame.Panel2
            // 
            this.Frame.Panel2.BackColor = System.Drawing.Color.Black;
            this.Frame.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Frame.Panel2.Controls.Add(this.Canvas);
            this.Frame.Panel2MinSize = 200;
            this.Frame.Size = new System.Drawing.Size(1503, 1082);
            this.Frame.SplitterDistance = 300;
            this.Frame.SplitterWidth = 6;
            this.Frame.TabIndex = 1;
            // 
            // Regions
            // 
            this.Regions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Regions.HideSelection = false;
            this.Regions.HotTracking = true;
            this.Regions.LabelEdit = false;
            this.Regions.Location = new System.Drawing.Point(0, 0);
            this.Regions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Regions.Name = "Regions";
            this.Regions.Size = new System.Drawing.Size(300, 1082);
            this.Regions.TabIndex = 0;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 1082);
            this.Controls.Add(this.Frame);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1189, 883);
            this.Name = "Editor";
            this.Text = "Region Editor";
            this.Frame.Panel1.ResumeLayout(false);
            this.Frame.Panel2.ResumeLayout(false);
            this.Frame.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).EndInit();
            this.Frame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.SplitContainer Frame;
		private MapCanvas Canvas;
		private MapRegionsTree Regions;
	}
}
