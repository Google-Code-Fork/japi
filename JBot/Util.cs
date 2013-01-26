using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JBot
{
    public static class Util
    {
        public static Process _Tibia = Process.GetCurrentProcess();
        public static UInt32 _BaseAddress;
        public static IntPtr _Handle;
        public static Process Tibia
        {
            get { return _Tibia; }
            set {
                _Tibia = value; _BaseAddress = Convert.ToUInt32(value.MainModule.BaseAddress.ToInt32());
                Base = Convert.ToUInt32(value.MainModule.BaseAddress.ToInt32());
                Handle = _Tibia.Handle;
            }
        }
        public static UInt32 Base
        {
            get { return _BaseAddress; }
            set { _BaseAddress = value; }
        }
        public static IntPtr Handle
        {
            get { return _Handle; }
            set { _Handle = value; }
        }
    }
}
