using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace winmplusplus_ii
{
	/// <summary>
	/// Class with program entry point and hook creation.
	/// </summary>
	internal sealed class Program
	{
		// WINAPI constants
		const int WH_KEYBOARD_LL = 0xd;
		const int WM_KEYDOWN = 0x0100;
		const int WM_KEYUP = 0x0101;
		// Keycodes to intercept
		const int win_key_code = 92;
		const int l_shift_key_code = 160;
		const int r_shift_key_code = 161;
		const int m_key_code = 77;
		// Keydown flags
		static bool win_down;
		static bool l_shift_down;
		static bool r_shift_down;

		static MainForm mf;
		// Hook callback delegate
		delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
		// Pointer to the hook
		static IntPtr hookID = IntPtr.Zero;
		// Callback function
		static LowLevelKeyboardProc hook_callback = handleHook;
		//
		static readonly BackgroundMinimizer minimizer = new BackgroundMinimizer();
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			hookID = setHook(hook_callback);
			mf = new MainForm();
			Application.Run(mf);
			UnhookWindowsHookEx(hookID);
		}
		
		static IntPtr setHook(LowLevelKeyboardProc callback)
		{
			ProcessModule curModule = Process.GetCurrentProcess().MainModule;
			return SetWindowsHookEx(WH_KEYBOARD_LL, callback, GetModuleHandle(curModule.ModuleName), 0);
		}
		
		static IntPtr handleHook(int nCode, IntPtr wParam, IntPtr lParam)
		{
			/*
			Retruning CallNextHook allows event to be processed in other apps;
			Returning pointer to -1 prevents that
			*/
			
			// Can be disabled via app's menu
			if (!mf.isEnabled()) {
				return CallNextHookEx(hookID, nCode, wParam, lParam);
			}
			
			int vkCode = Marshal.ReadInt32(lParam);
			// KeyUp event
			if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
			{
				switch (vkCode) {
					// Setting modifier flags
					case win_key_code:
						win_down = true;
						return CallNextHookEx(hookID, nCode, wParam, lParam);
					case l_shift_key_code:
						l_shift_down = true;
						return CallNextHookEx(hookID, nCode, wParam, lParam);
					case r_shift_key_code:
						r_shift_down = true;
						return CallNextHookEx(hookID, nCode, wParam, lParam);
					// M was pressed, reacting accordingly to flags
					case m_key_code:
						if (win_down)
						{
							if (l_shift_down || r_shift_down)
							{
								// Win-Shift-M minimizes every window on every monitor
								minimizer.MinimizeAll();
								return (IntPtr)(-1);
							}
							// Win-M minimizes windows on monitor with currently focused window
							minimizer.MinimizeScreen();
							return (IntPtr)(-1);
						}
						return CallNextHookEx(hookID, nCode, wParam, lParam);
				}
			}
			// KeyDown event
			if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
			{
				switch (vkCode) {
					// Resetting modifier flags
					case win_key_code:
						win_down = false;
						break;
					case l_shift_key_code:
						l_shift_down = false;
						break;
					case r_shift_key_code:
						r_shift_down = false;
						break;
				}
			}
			return CallNextHookEx(hookID, nCode, wParam, lParam);
		}
		
		// WINAPI imports
		[DllImport("user32.dll")]
		private static extern IntPtr SetWindowsHookEx(int idHook,
		                                              LowLevelKeyboardProc lpfn, 
		                                              IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll")]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
		                                            IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(string lpModuleName);
		
	}
}
