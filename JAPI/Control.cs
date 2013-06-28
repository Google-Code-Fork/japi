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
        public void LeftClick(System.Drawing.Point pt)
        {
            int coords = pt.X | (pt.Y << 16);
            SendMessage(Util.Handle, (int)Constants.KeyboardControls.lbtndn, (IntPtr)0x1, (IntPtr)coords);
            SendMessage(Util.Handle, (int)Constants.KeyboardControls.lbtnup, (IntPtr)0x1, (IntPtr)coords);
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
            IntPtr rtn = new IntPtr((Int32)'\0');
            SendMessage(Util.Handle, Constants.WM_CHAR, rtn, new IntPtr(0));
        }

        public void SendButton(string Key, string CtrlShift = "")
        {
            IntPtr wParam = new IntPtr(getKeyCode(Key));
            if (CtrlShift == "")
            {
                SendMessage(Util.Handle, Constants.WM_SYSKEYDOWN, (IntPtr)getKeyCode(Key), new IntPtr(0));
                SendMessage(Util.Handle, Constants.WM_SYSKEYUP, (IntPtr)getKeyCode(Key), new IntPtr(0));
            }
            else
            {
                SendMessage(Util.Handle, Constants.WM_SYSKEYDOWN, (IntPtr)getKeyCode(CtrlShift), new IntPtr(0));
                SendMessage(Util.Handle, Constants.WM_SYSKEYUP, (IntPtr)getKeyCode(Key), new IntPtr(0));
                SendMessage(Util.Handle, Constants.WM_SYSKEYDOWN, (IntPtr)getKeyCode(Key), new IntPtr(0));
                SendMessage(Util.Handle, Constants.WM_SYSKEYUP, (IntPtr)getKeyCode(CtrlShift), new IntPtr(0));
            }
        }

        public void CastSpell(string spellName)
        {
            string key = ReaderClass.FindHotkey(spellName);
            if (key == string.Empty)
            {
                SendKeys(spellName);
            }
            else if (key.Contains("+"))
            {
                string[] splitstrings = key.Split('+');
                SendButton(splitstrings[1], splitstrings[0]);
            }
            else
            {
                SendButton(key);
            }

        }

        
    }
}
