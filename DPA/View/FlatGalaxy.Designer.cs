using System.Drawing;

namespace DPA
{
    partial class FlatGalaxy
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
            this.components = new System.ComponentModel.Container();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondeTerugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.functiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzeerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openKeybindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.galaxyCanvas1 = new DPA.View.GalaxyCanvas();
            this.disableBreadthFirstSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondeTerugToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // secondeTerugToolStripMenuItem
            // 
            this.secondeTerugToolStripMenuItem.Name = "secondeTerugToolStripMenuItem";
            this.secondeTerugToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(443, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // functiesToolStripMenuItem
            // 
            this.functiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rewindToolStripMenuItem,
            this.pauzeerToolStripMenuItem,
            this.openKeybindsToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.algorithmInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.disableBreadthFirstSearchToolStripMenuItem});
            this.functiesToolStripMenuItem.Name = "functiesToolStripMenuItem";
            this.functiesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.functiesToolStripMenuItem.Text = "Functies";
            // 
            // rewindToolStripMenuItem
            // 
            this.rewindToolStripMenuItem.Name = "rewindToolStripMenuItem";
            this.rewindToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rewindToolStripMenuItem.Text = "Rewind";
            this.rewindToolStripMenuItem.Click += new System.EventHandler(this.rewindToolStripMenuItem_Click);
            // 
            // pauzeerToolStripMenuItem
            // 
            this.pauzeerToolStripMenuItem.Name = "pauzeerToolStripMenuItem";
            this.pauzeerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pauzeerToolStripMenuItem.Text = "Simulatie Pauzeren";
            this.pauzeerToolStripMenuItem.Click += new System.EventHandler(this.PauzeerToolStripMenuItem_Click);
            // 
            // openKeybindsToolStripMenuItem
            // 
            this.openKeybindsToolStripMenuItem.Name = "openKeybindsToolStripMenuItem";
            this.openKeybindsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openKeybindsToolStripMenuItem.Text = "Open keybinds";
            this.openKeybindsToolStripMenuItem.Click += new System.EventHandler(this.OpenKeybindsToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localToolStripMenuItem,
            this.webToolStripMenuItem});
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadFileToolStripMenuItem.Text = "Load File";
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.localToolStripMenuItem.Text = "Local";
            this.localToolStripMenuItem.Click += new System.EventHandler(this.LocalToolStripMenuItem_Click);
            // 
            // webToolStripMenuItem
            // 
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            this.webToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.webToolStripMenuItem.Text = "Web";
            this.webToolStripMenuItem.Click += new System.EventHandler(this.WebToolStripMenuItem_Click);
            // 
            // algorithmInfoToolStripMenuItem
            // 
            this.algorithmInfoToolStripMenuItem.Name = "algorithmInfoToolStripMenuItem";
            this.algorithmInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.algorithmInfoToolStripMenuItem.Text = "Algorithm Info";
            this.algorithmInfoToolStripMenuItem.Click += new System.EventHandler(this.AlgorithmInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.toolStripMenuItem1.Text = "Dijkstra algorithm";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(194, 0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip1_Popup);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // galaxyCanvas1
            // 
            this.galaxyCanvas1.Location = new System.Drawing.Point(0, 27);
            this.galaxyCanvas1.Margin = new System.Windows.Forms.Padding(0);
            this.galaxyCanvas1.MinimumSize = new System.Drawing.Size(800, 600);
            this.galaxyCanvas1.Name = "galaxyCanvas1";
            this.galaxyCanvas1.Size = new System.Drawing.Size(800, 600);
            this.galaxyCanvas1.TabIndex = 2;
            this.galaxyCanvas1.Load += new System.EventHandler(this.GalaxyCanvas1_Load);
            // 
            // disableBreadthFirstSearchToolStripMenuItem
            // 
            this.disableBreadthFirstSearchToolStripMenuItem.Checked = true;
            this.disableBreadthFirstSearchToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableBreadthFirstSearchToolStripMenuItem.Name = "disableBreadthFirstSearchToolStripMenuItem";
            this.disableBreadthFirstSearchToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.disableBreadthFirstSearchToolStripMenuItem.Text = "Breadth first search algorithm";
            this.disableBreadthFirstSearchToolStripMenuItem.Click += new System.EventHandler(this.DisableBreadthFirstSearchToolStripMenuItem_Click);
            // 
            // FlatGalaxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(443, 749);
            this.Controls.Add(this.galaxyCanvas1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FlatGalaxy";
            this.Text = "Flat galaxy society";
            this.Load += new System.EventHandler(this.FlatGalaxy_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondeTerugToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem functiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauzeerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKeybindsToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private View.GalaxyCanvas galaxyCanvas1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem algorithmInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disableBreadthFirstSearchToolStripMenuItem;
    }
}

