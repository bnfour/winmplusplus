using System;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace winmplusplus_ii
{
	/// <summary>
	/// Main form that is always hidden, but listening.
	/// Also hosts the tray icon and handles autorun.
	/// </summary>
	public partial class MainForm : Form
	{
		// Used for resource loading
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		
		const String registryRoot = "HKEY_CURRENT_USER";
		const String registrySubkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
		const String registryPath = registryRoot + "\\" + registrySubkey;
		const String registryValue = "Win-M++";
		// Path to running executable file
		static String path_to = "\""+Assembly.GetExecutingAssembly().Location+"\"";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		// Hide the form and set the autorun menu flag accordingly on startup
		void MainFormShown(object sender, EventArgs e)
		{
			Hide();
			startupMenuItem.Checked = isAutorunEnabled();
		}

		void quitMenuClicked(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void enabledMenuClicked(object sender, EventArgs e)
		{
			updateIcon();
		}
		
		void aboutMenuClicked(object sender, EventArgs e)
		{
			AboutForm af = new AboutForm();
			af.Show();
		}
		
		void startupMenuClicked(object sender, EventArgs e)
		{
			if (startupMenuItem.Checked) {
				enableAutoRun();
			}
			else {
				disableAutoRun();
			}
		}
		
		public bool isEnabled()
		{
			return enabledMenuItem.Checked;
		}
		
		void TrayiconDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				enabledMenuItem.Checked = !enabledMenuItem.Checked;
				updateIcon();
			}
		}
		
		void updateIcon()
		{
			if (isEnabled()) {
				trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
			}
			else {
				trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.IconDisabled")));
			}
		}

		bool isAutorunEnabled()
		{
			String registry = (String)Registry.GetValue(registryPath, registryValue, "no");
			return !registry.Equals("no");
		}
		
		void enableAutoRun()
		{
			Registry.SetValue(registryPath, registryValue, path_to);
		}
		
		void disableAutoRun()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(registrySubkey, true);
			if (key != null) {
				key.DeleteValue(registryValue);
			}
		}
		
	}
}
