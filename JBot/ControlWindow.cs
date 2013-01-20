using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace JBot
{
    class ControlWindow
    {
        public Process Tibia { get; set; }

        public const Int32 WM_CHAR = 0x0102;
        public const Int32 WM_KEYDOWN = 0x0100;
        public const Int32 WM_KEYUP = 0x0101;
        public const Int32 VK_RETURN = 0x0D;

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        public bool LeftClick(int dx, int dy)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, 0, UIntPtr.Zero);
            return true;
        }
        public bool RightClick(int dx, int dy)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.RightDown, dx, dy, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, dx, dy, 0, UIntPtr.Zero);
            return true;
        }

        public void SendKeys(String message)
        {
            IntPtr wParam = new IntPtr(0);
            IntPtr lParam = new IntPtr(0);
            foreach (char c in message)
            {
                int charValue = c;
                IntPtr val = new IntPtr((Int32)c);
                SendMessage(Tibia.MainWindowHandle, WM_CHAR, val, lParam);
            }
        }

        public void SendHotkey(UInt32 Key)
        {
            SendMessage(Tibia.MainWindowHandle, WM_KEYDOWN, new IntPtr(Key), new IntPtr(0));
            SendMessage(Tibia.MainWindowHandle, WM_KEYUP, new IntPtr(Key), new IntPtr(0));
        }

    }
}
