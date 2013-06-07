using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EnumWindowTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (IsWin64(p) && p.MainModule.FileName.Contains("Tibia")) //p.MainModule.FileName
                {
                    listBox1.Items.Add(p.MainWindowTitle + IsWin64(p).ToString());
                }
            }
        }

        private static bool IsWin64(Process process)
        {
            if ((Environment.OSVersion.Version.Major > 5)
                || ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1)))
            {
                IntPtr processHandle;
                bool retVal;

                try
                {
                    processHandle = Process.GetProcessById(process.Id).Handle;
                }
                catch
                {
                    return false; // access is denied to the process
                }

                return NativeMethods.IsWow64Process(processHandle, out retVal) && retVal;
            }

            return false; // not on 64-bit Windows
        }
    }
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);
    }
}