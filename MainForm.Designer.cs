
namespace winmplusplus_ii
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NotifyIcon trayicon;
		private System.Windows.Forms.ContextMenuStrip traymenu;
		private System.Windows.Forms.ToolStripMenuItem enabledMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startupMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		protected void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
			this.traymenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.enabledMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.traymenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(196, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "If you don\'t have time to do it right, when will you have time to do it over?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(135, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 14);
			this.label2.TabIndex = 1;
			this.label2.Text = "John Wooden";
			// 
			// trayicon
			// 
			this.trayicon.ContextMenuStrip = this.traymenu;
			this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
			this.trayicon.Text = "Win-M++";
			this.trayicon.Visible = true;
			this.trayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayiconDoubleClick);
			// 
			// traymenu
			// 
			this.traymenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.enabledMenuItem,
			this.startupMenuItem,
			this.toolStripSeparator,
			this.aboutMenuItem,
			this.quitMenuItem});
			this.traymenu.Name = "traymenu";
			this.traymenu.Size = new System.Drawing.Size(164, 98);
			// 
			// enabledMenuItem
			// 
			this.enabledMenuItem.Checked = true;
			this.enabledMenuItem.CheckOnClick = true;
			this.enabledMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enabledMenuItem.Name = "enabledMenuItem";
			this.enabledMenuItem.Size = new System.Drawing.Size(163, 22);
			this.enabledMenuItem.Text = "Enabled";
			this.enabledMenuItem.Click += new System.EventHandler(this.enabledMenuClicked);
			// 
			// startupMenuItem
			// 
			this.startupMenuItem.CheckOnClick = true;
			this.startupMenuItem.Name = "startupMenuItem";
			this.startupMenuItem.Size = new System.Drawing.Size(163, 22);
			this.startupMenuItem.Text = "Run at startup";
			this.startupMenuItem.Click += new System.EventHandler(this.startupMenuClicked);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(160, 6);
			// 
			// aboutMenuItem
			// 
			this.aboutMenuItem.Name = "aboutMenuItem";
			this.aboutMenuItem.Size = new System.Drawing.Size(163, 22);
			this.aboutMenuItem.Text = "About Win-M++";
			this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuClicked);
			// 
			// quitMenuItem
			// 
			this.quitMenuItem.Name = "quitMenuItem";
			this.quitMenuItem.Size = new System.Drawing.Size(163, 22);
			this.quitMenuItem.Text = "Quit";
			this.quitMenuItem.Click += new System.EventHandler(this.quitMenuClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(220, 69);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Win-M++ main";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.traymenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}

