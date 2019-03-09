using FakeUpdate.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FakeUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel { get; set; } = new MainViewModel();

        bool _realClose;

        public MainWindow()
        {
            DataContext = ViewModel;
            ViewModel.CompleteEvent += ViewModel_CompleteEvent;
            InitializeComponent();
            Closing += MainWindow_Closing;
            HookKeyboard();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_realClose;
        }

        private void ViewModel_CompleteEvent()
        {
            _realClose = true;
            if(ViewModel.CompleteCommand != string.Empty)
            {
                var cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine(ViewModel.CompleteCommand);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }
            Close();
        }

        public MainWindow(MainViewModel vm)
        {
            ViewModel = vm;
            DataContext = ViewModel;
            ViewModel.CompleteEvent += ViewModel_CompleteEvent;
            InitializeComponent();
            Closing += MainWindow_Closing;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.IncreaseInRandom();
        }

        private static readonly Key[] BlockingKeys = { Key.System, Key.F4, Key.LWin, Key.RWin, Key.Tab, Key.LeftAlt, Key.RightAlt };

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(BlockingKeys.Contains(e.Key))
            {
                e.Handled = true;
            }
        }
    }
}
