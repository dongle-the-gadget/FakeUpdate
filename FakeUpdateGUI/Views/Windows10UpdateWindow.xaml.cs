using FakeUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FakeUpdate.Views
{
    /// <summary>
    /// Interaction logic for Windows10UpdateWindow.xaml
    /// </summary>
    public partial class Windows10UpdateWindow : Window
    {
        bool isRequested = false;

        private Windows10Update ViewModel { get; set; }
        public Windows10UpdateWindow(Windows10Update vm)
        {
            ViewModel = vm;
            DataContext = ViewModel;
            ViewModel.UpdateComplete += ViewModel_UpdateComplete;
            InitializeComponent();
            HookKeyboard();
        }

        #region Windows Api
        private void HookKeyboard()
        {
            var hModule = GetModuleHandle(IntPtr.Zero);
            hookProc = LowLevelKeyboardProc;
            hHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hModule, 0);
            if (hHook == IntPtr.Zero)
            {
                MessageBox.Show("Failed to set hook, error = " + Marshal.GetLastWin32Error());
            }

        }
        private struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            int scanCode;
            public int flags;
            int time;
            int dwExtraInfo;
        }

        private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(IntPtr path);

        private IntPtr hHook;
        LowLevelKeyboardProcDelegate hookProc; // prevent gc
        const int WH_KEYBOARD_LL = 13;
        private static int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0)
                switch (wParam)
                {
                    case 256: // WM_KEYDOWN
                    case 257: // WM_KEYUP
                    case 260: // WM_SYSKEYDOWN
                    case 261: // M_SYSKEYUP
                        if (
                            (lParam.flags == 32) || // alt whatever after
                            (lParam.vkCode == 0x1b && lParam.flags == 32) || // Alt+Esc
                            (lParam.vkCode == 0x73 && lParam.flags == 32) || // Alt+F4
                            (lParam.vkCode == 0x1b && lParam.flags == 0) || // Ctrl+Esc
                            (lParam.vkCode == 0x5b && lParam.flags == 1) || // Left Windows Key 
                            (lParam.vkCode == 0x5c && lParam.flags == 1))    // Right Windows Key 
                        {
                            return 1; //Do not handle key events
                        }
                        break;
                }
            return CallNextHookEx(0, nCode, wParam, ref lParam);
        }

        #endregion

        private void ViewModel_UpdateComplete()
        {
            UnhookWindowsHookEx(hHook);
            ViewModel.Progress = 0;
            isRequested = true;
            if(!String.IsNullOrWhiteSpace(ViewModel.Command))
            {
                Utils.RunCommand(ViewModel.Command);
            }
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !isRequested;
        }
    }
}
