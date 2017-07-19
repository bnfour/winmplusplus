
using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace winmplusplus_ii
{
	/// <summary>
	/// Class that incapsulates BackgroundWorker to minimize windows
	/// </summary>
	public class BackgroundMinimizer
	{
		// ShowWindowAsync argument, see related MSDN article
		const int SW_MINIMIZE = 6;
		
		const int ONE_MONITOR = 1;
		const int ALL_MONITORS = 2;
		
		const String exceptions_file_name = "exceptions.txt";
		// Here because app was looking for file in %windir%\system32 by default
		static String exceptions_file = AppDomain.CurrentDomain.BaseDirectory + "\\" + exceptions_file_name;
		// List of screens detected
		static List<Screen> monitors = new List<Screen>();
		// List of (system) windows to not minimize
		static List<String> exceptions = new List<String>();
		// The screen focused window belongs to
		static Screen focusedScreen;
		readonly BackgroundWorker worker;
		
		private delegate bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam);
		
		public BackgroundMinimizer()
		{
			
			// Runs only once, so requires app restart whenever monitor setup is changed
			foreach (var s in Screen.AllScreens)
			{
				monitors.Add(s);
			}
			// Trying to load exceptions from file
			try {
				using (StreamReader sr = new StreamReader(exceptions_file)) {
					while (!sr.EndOfStream) {
						String line = sr.ReadLine();
						exceptions.Add(line);
					}
				}
			}
			// If unable to, reverting to hardcoded default
			catch (Exception e) {
				MessageBox.Show("Unable to open exceptions file, reverting to built-in default\n " + e.ToString());
				exceptions.Clear();
				// Hardcoded for english Windows 7
				exceptions.Add("Start");
				exceptions.Add("Program Manager");
				exceptions.Add("Start menu");
			}

			worker = new BackgroundWorker();
			worker.DoWork += new DoWorkEventHandler(doWork);
		}
		
		void doWork(object sender, DoWorkEventArgs e)
		{

			EnumWindowsCallback usedMethod = null;

			int key = (int)e.Argument;
			
			switch (key) {
				case ONE_MONITOR:
					usedMethod = EnumMinimizeScreen;
					focusedScreen = Screen.FromHandle(GetForegroundWindow());
				break;
				
				case ALL_MONITORS:
					usedMethod = EnumMinimizeAll;
				break;
			}
			
			EnumWindows(usedMethod, IntPtr.Zero);
		}
		
		// Checks window's titles to determine their eligibility for minimizing
		static bool isForbidden(IntPtr hWnd)
		{
			// Windows with blank title are ignored
			int size = GetWindowTextLength(hWnd);
			if (size++ <= 0)
			{
				return true;
			}
			// Checking exceptions list
			var sb = new StringBuilder(size);
			GetWindowText(hWnd, sb, size);
			String sb_str = sb.ToString();
			foreach (var s in exceptions)
			{
				if (s.Equals(sb_str))
				{
					return true;
				}
			}
			// If title is not blank, and not in exceptions list,
			// the window is eligible for minimizing
			return false;
		}
		// Default behaviour, minimize every visible window
		// (except system ones) 
		static bool EnumMinimizeAll(IntPtr hWnd, IntPtr lParam)
		{
			if (IsWindowVisible(hWnd) && !hWnd.Equals(IntPtr.Zero) && !isForbidden(hWnd))
			{
				ShowWindowAsync(hWnd, SW_MINIMIZE);
			}
			return true;
		}
		// Modified behavior, minimize windows on Screen with the focused window
		static bool EnumMinimizeScreen(IntPtr hWnd, IntPtr lParam)
		{
			if (IsWindowVisible(hWnd) && !hWnd.Equals(IntPtr.Zero) && !isForbidden(hWnd))
			{
				Screen currentScreen = Screen.FromHandle(hWnd);
				if (!currentScreen.Equals(IntPtr.Zero))
				{
					if (currentScreen.Equals(focusedScreen))
					{
						ShowWindowAsync(hWnd, SW_MINIMIZE);
					}
				}
			}
			return true;
		}
		// Minimizing interfaces
		public void MinimizeAll()
		{
			worker.RunWorkerAsync(ALL_MONITORS);
		}
		
		public void MinimizeScreen()
		{
			worker.RunWorkerAsync(ONE_MONITOR);
		}
		
		// WINAPI imports
		[DllImport("user32.dll")]
		static extern bool EnumWindows(EnumWindowsCallback enumProc, IntPtr lParam);
		
		[DllImport("user32.dll")]
		static extern bool IsWindowVisible(IntPtr hWnd);
		
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();
		
		[DllImport("user32.dll")]
		static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
		
		[DllImport("user32.dll")] 
		static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount); 
        
		[DllImport("user32.dll")] 
		static extern int GetWindowTextLength(IntPtr hWnd); 
		
	}
}
