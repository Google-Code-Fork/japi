using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPI
{
    public class Constants
    {
        public static string ClientVersion = "10.0.2.0";
        // Key code preparation.
        [Flags]
        public enum MouseEventFlag : uint
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
        public enum KeyboardControls : uint
        {
            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7A,
            F12 = 0x7B,
            left = 0x25,
            up = 0x26,
            right = 0x27,
            down = 0x28,
            ctrl = 0x11,
            shift = 0x10,
            lbtndn = 0x0201,
            lbtnup = 0x0202

        }
        public enum ErrorTypes : int
        {
            WARN = 0,
            ERR1 = 1,
            ERR2 = 2,
            ERR3 = 3,
            FATAL = 4,
        }

        public const Int32 WM_CHAR = 0x0102;
        public const Int32 WM_KEYDOWN = 0x0100;
        public const Int32 WM_KEYUP = 0x0101;
        public const Int32 VK_RETURN = 0x0D;
        public const Int32 WM_SYSKEYDOWN = 0x0104;
        public const Int32 WM_SYSKEYUP = 0x0105;
        
    }
}
