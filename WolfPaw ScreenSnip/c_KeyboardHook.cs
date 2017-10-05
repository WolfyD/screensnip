using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//=====================================Acknowledgements=====================================//
//Code copied from Adam O'Neil's Development Blog / Low Level Keyboard (& Mouse) Hook		//
//http://www.seesharpdot.net/?p=96															//
//It's not copyrighted, but it's some fine code, Thanks Adam!								//
//==========================================================================================//

namespace WolfPaw_ScreenSnip
{
	public class c_KeyboardHook
	{
		#region DLL Imports
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardProcedure lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);
		#endregion
		
		private const int WH_KEYBOARD_LL = 13;
		private const int WM_KEYDOWN = 0x0100;
		private const int WM_SYSKEYDOWN = 0x0104;

		#region Member Variables
		private KeyboardProcedure keyboardProcedure;

		private KeyboardProcedure CurrentKeyboardProcedure
		{
			get
			{
				if (keyboardProcedure == null)
				{
					keyboardProcedure = HookCallback;
				}
				return keyboardProcedure;
			}
			set { keyboardProcedure = value; }
		}
		private IntPtr keyboardHookId = IntPtr.Zero;
		#endregion

		public c_KeyboardHook()
		{
			keyboardHookId = SetHook(CurrentKeyboardProcedure);
		}

		private IntPtr SetHook(KeyboardProcedure proc)
		{
			Process currentProcess = Process.GetCurrentProcess();
			ProcessModule currentModule = currentProcess.MainModule;
			return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
					GetModuleHandle(currentModule.ModuleName), 0);
		}

		private delegate IntPtr KeyboardProcedure(
			int nCode, IntPtr wParam, IntPtr lParam);

		public event KeyEventHandler KeyPressDetected;

		private void OnKeyPressDetected(object sender, KeyEventArgs args)
		{
			if (KeyPressDetected != null)
			{
				KeyPressDetected(sender, args);
			}
		}

		private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && (wParam ==
				(IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
			{
				int vkCode = Marshal.ReadInt32(lParam);

				Keys key = ((Keys)vkCode);

				if (key == Keys.LControlKey ||
					key == Keys.RControlKey)
				{
					key = key | Keys.Control;
				}

				if (key == Keys.LShiftKey ||
					key == Keys.RShiftKey)
				{
					key = key | Keys.Shift;
				}

				if (key == Keys.LMenu ||
					key == Keys.RMenu)
				{
					key = key | Keys.Alt;
				}

				OnKeyPressDetected(null, new KeyEventArgs(key));
			}
			return CallNextHookEx(keyboardHookId, nCode, wParam, lParam);
		}

		#region IDisposable Members

		public void Dispose()
		{
			UnhookWindowsHookEx(keyboardHookId);
		}

		#endregion

	}
}
