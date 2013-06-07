using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JAPI
{
    public static class Util
    {
        public static List<Objects.Error> Errors = new List<Objects.Error>();
        public static Objects.Error lastError;
        public static Process _Tibia = Process.GetCurrentProcess();
        public static UInt32 _BaseAddress;
        public static IntPtr _Handle;
        public static Objects.Hotkey[] _Hotkeys;

        public static Objects.Hotkey[] Hotkeys
        {
            get { return _Hotkeys; }
            set { _Hotkeys = value; }
        }

        public static Process Tibia
        {
            get { return _Tibia; }
            set
            {
                _Tibia = value;
                _BaseAddress = Convert.ToUInt32(value.MainModule.BaseAddress.ToInt32());
                _Handle = value.MainWindowHandle;
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

        public static string getFileVersion(string filePath)
        {
            return FileVersionInfo.GetVersionInfo(Environment.ExpandEnvironmentVariables(filePath)).FileVersion;
        }

        public static string getProcessName(Process proc)
        {
            return proc.MainWindowTitle;
        }
    }
}
