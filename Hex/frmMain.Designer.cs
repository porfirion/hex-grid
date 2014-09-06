namespace Hex {
	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.log = new System.Windows.Forms.TextBox();
			this.statusLabel = new System.Windows.Forms.Label();
			this.giveEnergyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoLabel = new System.Windows.Forms.Label();
			this.restartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(774, 675);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.restartToolStripMenuItem1,
            this.giveEnergyToolStripMenuItem,
            this.clearLogToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.fileToolStripMenuItem.Visible = false;
			this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.testToolStripMenuItem.Text = "test";
			this.testToolStripMenuItem.Visible = false;
			this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
			// 
			// restartToolStripMenuItem
			// 
			this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
			this.restartToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.restartToolStripMenuItem.Text = "Новая игра";
			this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
			// 
			// log
			// 
			this.log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.log.Location = new System.Drawing.Point(792, 252);
			this.log.Multiline = true;
			this.log.Name = "log";
			this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.log.Size = new System.Drawing.Size(384, 450);
			this.log.TabIndex = 2;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.Location = new System.Drawing.Point(792, 162);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(384, 87);
			this.statusLabel.TabIndex = 4;
			this.statusLabel.Text = "label1";
			// 
			// giveEnergyToolStripMenuItem
			// 
			this.giveEnergyToolStripMenuItem.Name = "giveEnergyToolStripMenuItem";
			this.giveEnergyToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.giveEnergyToolStripMenuItem.Text = "Дать энергию";
			this.giveEnergyToolStripMenuItem.Click += new System.EventHandler(this.giveEnergyToolStripMenuItem_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.infoLabel.Location = new System.Drawing.Point(792, 27);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(384, 87);
			this.infoLabel.TabIndex = 4;
			this.infoLabel.Text = "label1";
			// 
			// restartToolStripMenuItem1
			// 
			this.restartToolStripMenuItem1.Name = "restartToolStripMenuItem1";
			this.restartToolStripMenuItem1.Size = new System.Drawing.Size(99, 20);
			this.restartToolStripMenuItem1.Text = "Начать заново";
			this.restartToolStripMenuItem1.Click += new System.EventHandler(this.restartToolStripMenuItem1_Click);
			// 
			// clearLogToolStripMenuItem
			// 
			this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
			this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.clearLogToolStripMenuItem.Text = "Очистить лог";
			this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(1188, 714);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.log);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "Hex";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.TextBox log;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem giveEnergyToolStripMenuItem;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
	}
}

