
namespace Server.Tools.Controls
{
	partial class MapCanvas
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Background = new Server.Tools.Controls.MapCanvas.CanvasLayer();
            this.Canvas = new Server.Tools.Controls.MapCanvas.CanvasImage();
            this.Regions = new Server.Tools.Controls.MapCanvas.CanvasLayer();
            this.Surface = new Server.Tools.Controls.MapCanvas.CanvasLayer();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.Canvas.SuspendLayout();
            this.Regions.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu.Name = "Menu";
            // 
            // Background
            // 
            this.Background.AutoScroll = true;
            this.Background.AutoSize = true;
            this.Background.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Background.BackColor = System.Drawing.Color.Transparent;
            this.Background.Controls.Add(this.Canvas);
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Margin = new System.Windows.Forms.Padding(0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(300, 300);
            this.Background.TabIndex = 1;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.Transparent;
            this.Canvas.Controls.Add(this.Regions);
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Margin = new System.Windows.Forms.Padding(0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(300, 300);
            this.Canvas.TabIndex = 2;
            this.Canvas.TabStop = false;
            // 
            // Regions
            // 
            this.Regions.AutoSize = true;
            this.Regions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Regions.BackColor = System.Drawing.Color.Transparent;
            this.Regions.Controls.Add(this.Surface);
            this.Regions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Regions.Location = new System.Drawing.Point(0, 0);
            this.Regions.Margin = new System.Windows.Forms.Padding(0);
            this.Regions.Name = "Regions";
            this.Regions.Size = new System.Drawing.Size(300, 300);
            this.Regions.TabIndex = 3;
            // 
            // Surface
            // 
            this.Surface.AutoSize = true;
            this.Surface.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Surface.BackColor = System.Drawing.Color.Transparent;
            this.Surface.ContextMenuStrip = this.Menu;
            this.Surface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Surface.Location = new System.Drawing.Point(0, 0);
            this.Surface.Margin = new System.Windows.Forms.Padding(0);
            this.Surface.Name = "Surface";
            this.Surface.Size = new System.Drawing.Size(300, 300);
            this.Surface.TabIndex = 4;
            // 
            // MapCanvas
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Background);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MapCanvas";
            this.Size = new System.Drawing.Size(300, 300);
            this.Background.ResumeLayout(false);
            this.Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.Canvas.ResumeLayout(false);
            this.Canvas.PerformLayout();
            this.Regions.ResumeLayout(false);
            this.Regions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip Menu;
		private CanvasLayer Background;
		private CanvasImage Canvas;
		private CanvasLayer Regions;
		private CanvasLayer Surface;
	}
}
