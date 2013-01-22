using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace JBot
{
    class ReaderClass
    {
        #region vars
        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        public Process Tibia { get; set; }

        public static UInt32 BLStart = 0x54C008;
        public static UInt32 BLStep = 0xB0;
        public static int BLMax = 1300;
        #endregion

        // Reading Memory Functions
        public byte[] ReadBytes(IntPtr Handle, Int64 Address, uint BytesToRead)
        {
            IntPtr ptrBytesRead;
            byte[] buffer = new byte[BytesToRead];
            ReadProcessMemory(Handle, new IntPtr(Address), buffer, BytesToRead, out ptrBytesRead);
            return buffer;
        }
        public byte ReadByte(Int64 Address)
        {
            return ReadBytes(Tibia.Handle, Address, 1)[0];
        }
        public int ReadInt32(long Address, uint length = 4)
        {
            return BitConverter.ToInt32(ReadBytes(Tibia.Handle, Address, length), 0);
        }
        public ushort ReadInt16(long Address)
        {
            return BitConverter.ToUInt16(ReadBytes(Tibia.Handle, Address, 2), 0);
        }
        public double ReadDouble(long Address)
        {
            return BitConverter.ToDouble(ReadBytes(Tibia.Handle, Address, 8), 0);
        }
        public string ReadString(long Address)
        {
            string temp3 = ASCIIEncoding.Default.GetString(ReadBytes(Tibia.Handle, Address, 32));
            return temp3;
        }

        // Getting client functions
        public Process[] getClients()
        {
            return Process.GetProcessesByName("Tibia");
        }
        public Process getFirstClient()
        {
            Process[] ProcList = getClients();
            return ProcList[0];
        }
        public Process getClientById(int id)
        {
            Process[] ProcList = getClients();
            foreach (Process p in ProcList)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        // Reading self info
        public int Hp()
        {
            return ReadInt32(Addresses.Hp + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32())) ^ ReadInt32(Addresses.Xor + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int MaxHp()
        {
            return ReadInt32(Addresses.MaxHp + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32())) ^ ReadInt32(Addresses.Xor + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int Mp()
        {
            return ReadInt32(Addresses.Mp + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32())) ^ ReadInt32(Addresses.Xor + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int MaxMp()
        {
            return ReadInt32(Addresses.MaxMp + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32())) ^ ReadInt32(Addresses.Xor + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int Soul()
        {
            return ReadInt32(Addresses.Soul + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32())) ^ ReadInt32(Addresses.Xor + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int X()
        {
            return ReadInt32(Addresses.XPos + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int Y()
        {
            return ReadInt32(Addresses.YPos + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int Z()
        {
            return ReadInt32(Addresses.ZPos + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int Cid()
        {
            return ReadInt32(Addresses.Cid + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public int Exp()
        {
            return ReadInt32(Addresses.Exp + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
        }
        public Objects.Player GetPlayerInfo()
        {
            Objects.Player p = new Objects.Player();
            p.Hp = Hp();
            p.HpMax = MaxHp();
            p.Mp = Mp();
            p.MpMax = MaxMp();
            p.Soul = Soul();
            p.X = X();
            p.Y = Y();
            p.Z = Z();
            p.Cid = Cid();
            p.Exp = Exp();
            return p;
        }
        public string getMyName()
        {
            Objects.BList[] batt = new Objects.BList[BLMax];
            batt = BlGet(true);
            foreach (Objects.BList crit in batt)
            {
                if (crit.Id == GetPlayerInfo().Cid)
                {
                    return crit.Name;
                }
            }
            return "";
        }

        // Reading array info
        public Objects.BList[] BlGet(bool idname = false)
        {
            int max = Convert.ToInt32(BLStep) * BLMax;
            Objects.BList[] bat = new Objects.BList[BLMax];
            for (int i = 0; i < BLMax; i++)
            {
                UInt32 CreatureOffset = Convert.ToUInt32(i) * BLStep;
                Objects.BList batt = new Objects.BList();
                batt.Addr = i;
                batt.Id = ReadInt32(BLStart + BListAdresses.IdOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                if (batt.Id != 0 && idname != false)
                {
                    batt.Type = ReadByte(BLStart + BListAdresses.TypeOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Name = ReadString(BLStart + BListAdresses.NameOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Z = ReadInt32(BLStart + BListAdresses.ZOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Y = ReadInt32(BLStart + BListAdresses.YOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.X = ReadInt32(BLStart + BListAdresses.XOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.TimeLastMoved = ReadInt32(BLStart + BListAdresses.TimeLastMovedOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Walking = ReadInt32(BLStart + BListAdresses.WalkingOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Direction = ReadInt32(BLStart + BListAdresses.DirectionOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Previous = ReadInt32(BLStart + BListAdresses.PreviousOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Next = ReadInt32(BLStart + BListAdresses.NextOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Outfit = ReadInt32(BLStart + BListAdresses.OutfitOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.MountId = ReadInt32(BLStart + BListAdresses.MountIdOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));

                    batt.BlackSquare = ReadInt32(BLStart + BListAdresses.BlackSquareOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Hppc = ReadInt32(BLStart + BListAdresses.HppcOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Speed = ReadInt32(BLStart + BListAdresses.SpeedOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));

                    batt.SkullType = ReadInt32(BLStart + BListAdresses.SkullOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Party = ReadInt32(BLStart + BListAdresses.PartyOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.WarIcon = ReadInt32(BLStart + BListAdresses.WarOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Visible = ReadByte(BLStart + BListAdresses.VisibleOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    bat[i] = batt;
                }
                else if (batt.Id != 0 && idname == true)
                {
                    batt.Id = ReadInt32(BLStart + BListAdresses.IdOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                    batt.Name = ReadString(BLStart + BListAdresses.NameOffset + CreatureOffset + Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32()));
                }
            }

            return bat;
        }

    }
}



