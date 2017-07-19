using System;
using System.Windows.Forms;

namespace winmplusplus_ii
{
	/// <summary>
	/// This form shows info about the program.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		// Load actual version number when form is first shown
		void AboutFormShown(object sender, EventArgs e)
		{
			versionlabel.Text = "version " + Application.ProductVersion;
		}
	}
}
