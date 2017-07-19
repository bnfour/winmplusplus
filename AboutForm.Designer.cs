
namespace winmplusplus_ii
{
	partial class AboutForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label titlelabel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label versionlabel;
		private System.Windows.Forms.Label authorlabel;
		
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
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.titlelabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.versionlabel = new System.Windows.Forms.Label();
			this.authorlabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// titlelabel
			// 
			this.titlelabel.AutoSize = true;
			this.titlelabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titlelabel.Location = new System.Drawing.Point(50, 12);
			this.titlelabel.Name = "titlelabel";
			this.titlelabel.Size = new System.Drawing.Size(86, 22);
			this.titlelabel.TabIndex = 0;
			this.titlelabel.Text = "Win-M++";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// versionlabel
			// 
			this.versionlabel.AutoSize = true;
			this.versionlabel.Location = new System.Drawing.Point(50, 34);
			this.versionlabel.Name = "versionlabel";
			this.versionlabel.Size = new System.Drawing.Size(143, 14);
			this.versionlabel.TabIndex = 2;
			this.versionlabel.Text = "version {will load at runtime}";
			// 
			// authorlabel
			// 
			this.authorlabel.AutoSize = true;
			this.authorlabel.Location = new System.Drawing.Point(50, 48);
			this.authorlabel.Name = "authorlabel";
			this.authorlabel.Size = new System.Drawing.Size(94, 14);
			this.authorlabel.TabIndex = 3;
			this.authorlabel.Text = "by Βn4, june 2017";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(197, 69);
			this.Controls.Add(this.authorlabel);
			this.Controls.Add(this.versionlabel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.titlelabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About Win-M++";
			this.Shown += new System.EventHandler(this.AboutFormShown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
