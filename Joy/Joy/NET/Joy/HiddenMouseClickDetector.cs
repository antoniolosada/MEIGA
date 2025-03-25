using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Joy
{

    class HiddenMouseClickDetector
    {
        public static bool run = false;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_LBUTTONDOWN = 0x0201;
        public int clic = 0;
        // Delegado para el hook del ratón.
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_MOUSE_LL = 14; // Hook global para eventos del ratón.

        private static IntPtr hookId = IntPtr.Zero;

        public void Run()
        {
            run = true;
            HookProc mouseProc = MouseHookCallback;
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                hookId = SetWindowsHookEx(WH_MOUSE_LL, mouseProc, GetModuleHandle(currentModule.ModuleName), 0);
            }
        }
        public void Stop()
        {
            run = false;
            UnhookWindowsHookEx(hookId);
        }

        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (run)
                if (nCode >= 0)
                {
                    if (wParam == (IntPtr)WM_LBUTTONDOWN)
                    {
                        clic = 1;
                        if (Cursor.Position.Y > 20)
                            return (IntPtr)1;
                    }
                    if (wParam == (IntPtr)WM_RBUTTONDOWN)
                    {
                        clic = 2;
                        if (Cursor.Position.Y > 20)
                            return (IntPtr)1;
                    }
                }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }
    }

}
