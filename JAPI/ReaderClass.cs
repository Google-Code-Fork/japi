using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace JAPI
{
    public class ReaderClass
    {
        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

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
            return ReadBytes(Util.Tibia.Handle, Address, 1)[0];
        }
        public int ReadBool(Int64 Address)
        {
            return ReadBytes(Util.Tibia.Handle, Address, 1)[0];
        }
        public int ReadInt32(long Address, uint length = 4)
        {
            return BitConverter.ToInt32(ReadBytes(Util.Tibia.Handle, Address, length), 0);
        }
        public ushort ReadInt16(long Address)
        {
            return BitConverter.ToUInt16(ReadBytes(Util.Tibia.Handle, Address, 2), 0);
        }
        public double ReadDouble(long Address)
        {
            return BitConverter.ToDouble(ReadBytes(Util.Tibia.Handle, Address, 8), 0);
        }
        public string ReadString(long Address)
        {
            string temp3 = ASCIIEncoding.Default.GetString(ReadBytes(Util.Tibia.Handle, Address, 32));
            string[] temp3str = temp3.Split('\0');
            return temp3str[0];
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
            return ReadInt32(Addresses.Hp + Util.Base) ^ ReadInt32(Addresses.Xor + Util.Base);
        }
        public int MaxHp()
        {
            return ReadInt32(Addresses.MaxHp + Util.Base) ^ ReadInt32(Addresses.Xor + Util.Base);
        }
        public int Mp()
        {
            return ReadInt32(Addresses.Mp + Util.Base) ^ ReadInt32(Addresses.Xor + Util.Base);
        }
        public int MaxMp()
        {
            return ReadInt32(Addresses.MaxMp + Util.Base) ^ ReadInt32(Addresses.Xor + Util.Base);
        }
        public int Soul()
        {
            return ReadInt32(Addresses.Soul + Util.Base) ^ ReadInt32(Addresses.Xor + Util.Base);
        }
        public int X()
        {
            return ReadInt32(Addresses.XPos + Util.Base);
        }
        public int Y()
        {
            return ReadInt32(Addresses.YPos + Util.Base);
        }
        public int Z()
        {
            return ReadInt32(Addresses.ZPos + Util.Base);
        }
        public int Cid()
        {
            return ReadInt32(Addresses.Cid + Util.Base);
        }
        public int Exp()
        {
            return ReadInt32(Addresses.Exp + Util.Base);
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
            Objects.BList[] batt = new Objects.BList[BListAdresses.Max];
            batt = BlGet(true);
            foreach (Objects.BList crit in batt)
            {
                if (crit.Id == Cid())
                {
                    return crit.Name;
                }
            }
            return "";
        }

        // Reading array info
        public Objects.BList[] BlGet(bool idname = false, bool returnall = true)
        {
            int max = Convert.ToInt32(BListAdresses.Step) * BListAdresses.Max;
            Objects.BList[] bat = new Objects.BList[BListAdresses.Max];
            for (int i = 0; i < BListAdresses.Max; i++)
            {
                UInt32 CreatureOffset = Convert.ToUInt32(i) * BListAdresses.Step;
                Objects.BList batt = new Objects.BList();
                batt.Addr = i;
                batt.Id = ReadInt32(BListAdresses.Start + BListAdresses.IdOffset + CreatureOffset + Util.Base);
                if (batt.Id != 0 && idname != true)
                {
                    UInt32 currentMem = BListAdresses.Start + CreatureOffset + Util.Base;
                    batt.Type = ReadByte(BListAdresses.TypeOffset + currentMem);
                    batt.Name = ReadString(BListAdresses.NameOffset + currentMem);
                    batt.Z = ReadInt32(BListAdresses.ZOffset + currentMem);
                    batt.Y = ReadInt32(BListAdresses.YOffset + currentMem);
                    batt.X = ReadInt32(BListAdresses.XOffset + currentMem);
                    batt.TimeLastMoved = ReadInt32(BListAdresses.TimeLastMovedOffset + currentMem);
                    batt.Walking = ReadInt32(BListAdresses.WalkingOffset + currentMem);
                    batt.Direction = ReadInt32(BListAdresses.DirectionOffset + currentMem);
                    batt.Previous = ReadInt32(BListAdresses.PreviousOffset + currentMem);
                    batt.Next = ReadInt32(BListAdresses.NextOffset + currentMem);
                    batt.Outfit = ReadInt32(BListAdresses.OutfitOffset + currentMem);
                    batt.MountId = ReadInt32(BListAdresses.MountIdOffset + currentMem);

                    batt.BlackSquare = ReadInt32(BListAdresses.BlackSquareOffset + currentMem); // This address might have been removed - needs testing.
                    batt.Hppc = ReadInt32(BListAdresses.HppcOffset + currentMem);
                    batt.Speed = ReadInt32(BListAdresses.SpeedOffset + currentMem);

                    batt.SkullType = ReadInt32(BListAdresses.SkullOffset + currentMem);
                    batt.Party = ReadInt32(BListAdresses.PartyOffset + currentMem);
                    batt.WarIcon = ReadInt32(BListAdresses.WarOffset + currentMem);
                    batt.Visible = ReadByte(BListAdresses.VisibleOffset + currentMem);
                    bat[i] = batt;
                }
                else if (batt.Id != 0 && idname == true)
                {
                    batt.Id = ReadInt32(BListAdresses.Start + BListAdresses.IdOffset + CreatureOffset + Util.Base);
                    batt.Name = ReadString(BListAdresses.Start + BListAdresses.NameOffset + CreatureOffset + Util.Base);
                    bat[i] = batt;
                }
            }

            if (!returnall)
            {
                int validcount = 0;
                foreach (Objects.BList crit in bat)
                {
                    if (crit.Id != 0 && crit.Visible != 0)
                    {
                        validcount ++;
                    }
                }
                Objects.BList[] batt = new Objects.BList[validcount];
                int index = 0;
                foreach (Objects.BList crit in bat)
                {
                    if (crit.Id != 0 && crit.Visible != 0)
                    {
                        batt[index] = crit;
                        index++;
                    }
                }
                return batt;
            }

            return bat;
        }

        public Objects.Container[] getContainers()
        {
            UInt32 max = ContainerAddresses.Step * ContainerAddresses.Max;
            Objects.Container[] cont = new Objects.Container[ContainerAddresses.Max];
            int totcons = 0;
            for (int i = 0; i < ContainerAddresses.Max; i++)
            {
                UInt32 ThisReadOffset = (Convert.ToUInt32(i) * (UInt32)ContainerAddresses.Step) + ContainerAddresses.ContainerStart + Util.Base;
                Objects.Container con = new Objects.Container();
                if (ReadInt32(ContainerAddresses.IdOffset + ThisReadOffset) != 0)
                {
                    con.Id = ReadInt32(ContainerAddresses.IdOffset + ThisReadOffset);
                    con.Volume = ReadInt32(ContainerAddresses.VolumeOffset + ThisReadOffset);
                    con.Name = ReadString(ContainerAddresses.NameOffset + ThisReadOffset);
                    con.IsOpen = ReadBool(ContainerAddresses.IsOpenOffset + ThisReadOffset);
                    con.Items = getItems(con.Volume, ThisReadOffset + ContainerAddresses.ItemsOffset);
                    cont[i] = con;
                    totcons++;
                }
            }

            int ind = 0;

            Objects.Container[] contz = new Objects.Container[totcons];
            foreach (Objects.Container cn in cont)
            {
                if (cn.Id != 0)
                {
                    contz[ind] = cn;
                    ind++;
                }
            }

            return contz;
        }

        public Objects.Item[] getItems(int Volume, UInt32 AdrStart)
        {
            Objects.Item[] Itenz = new Objects.Item[Volume];
            for (int i = 0; i < Volume; i++)
            {
                UInt32 ThisReadOffset = AdrStart + ((UInt32)i * ItemAddresses.Step);
                Objects.Item iten = new Objects.Item();
                iten.StackCount = ReadInt32(ThisReadOffset + ItemAddresses.Count);
                iten.Id = ReadInt32(ThisReadOffset + ItemAddresses.Id);
                iten.Unknown2 = ReadInt32(ThisReadOffset + ItemAddresses.Unknown2);
                Itenz[i] = iten;
            }
            return Itenz;
        }

        public Objects.MapTile[] getMap()
        {
            Objects.MapTile[] Tiles = new Objects.MapTile[MapAddresses.MaxTiles];
            for (UInt32 i = 0; i < MapAddresses.MaxTiles; i++)
            {
                Objects.MapTile Tile = new Objects.MapTile();
                UInt32 ThisReadOffset = MapAddresses.MapStart + (i * MapAddresses.Step);
                Tile.count = ReadInt32(ThisReadOffset + MapAddresses.CountOffset);
                Tile.Items = getItems(10, ThisReadOffset + MapAddresses.ItemOffset);
                Tile.Effect = ReadInt32(ThisReadOffset + MapAddresses.EffectOffset);
                Tiles[i] = Tile;
            }
            return Tiles;
        }

    }
}