using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using JAPI;

namespace JAPI
{
    public class ControlWindow
    {

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(Constants.MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        // Mouse Tricks
        public bool LeftClick(int dx, int dy)
        {
            SetCursorPos(dx, dy);
            mouse_event(Constants.MouseEventFlag.LeftDown, dx, dy, 0, UIntPtr.Zero);
            mouse_event(Constants.MouseEventFlag.LeftUp, dx, dy, 0, UIntPtr.Zero);
            return true;
        }
        public bool RightClick(int dx, int dy)
        {
            SetCursorPos(dx, dy);
            mouse_event(Constants.MouseEventFlag.RightDown, dx, dy, 0, UIntPtr.Zero);
            mouse_event(Constants.MouseEventFlag.RightUp, dx, dy, 0, UIntPtr.Zero);
            return true;
        }

        // Get key codes ready for sending
        public UInt32 getKeyCode(string Key)
        {
            Constants.KeyboardControls keynum;
            if (Enum.TryParse<Constants.KeyboardControls>(Key, true, out keynum))
            {
                return (UInt32)(keynum);
            }
            else
            {
                return new UInt32();
            }
        }

        // Send key codes
        public void SendKeys(string message)
        {
            foreach (char c in message)
            {
                int charValue = c;
                IntPtr val = new IntPtr((Int32)c);
                SendMessage(Util.Handle, Constants.WM_CHAR, val, new IntPtr(0));
            }
        }

        public void SendButton(string Key)
        {
            IntPtr wParam = new IntPtr(getKeyCode(Key));
            SendMessage(Util.Handle, Constants.WM_KEYDOWN, wParam, new IntPtr(0));
            SendMessage(Util.Handle, Constants.WM_KEYUP, wParam, new IntPtr(0));
        }
    }
}
