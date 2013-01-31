using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPI
{
    class Addresses
    {
        public static UInt32 Cid = 0x583EA4;
        public static UInt32 Xor = 0x3b6ef0;
        public static UInt32 Hp = 0x54c000;
        public static UInt32 MaxHp = 0x583e9c;
        public static UInt32 Mp = 0x3b6f44;
        public static UInt32 MaxMp = 0x3b6ef4;
        public static UInt32 Soul = 0x3b6f30;
        public static UInt32 XPos = 0x583ea8;
        public static UInt32 YPos = 0x583eac;
        public static UInt32 ZPos = 0x583eb0;
        public static UInt32 Exp = 0x3B6F00;
    }

    class BListAdresses
    {
        public static UInt32 Start = 0x54C008;
        public static UInt32 Step = 0xB0;
        public static int Max = 1300;
        public static UInt32 IdOffset = 0x0;
        public static UInt32 TypeOffset = 0x3;
        public static UInt32 NameOffset = 0x4;
        public static UInt32 ZOffset = 0x24;
        public static UInt32 YOffset = 0x28;
        public static UInt32 XOffset = 0x2C;
        public static UInt32 TimeLastMovedOffset = 0x3C;
        public static UInt32 WalkingOffset = 0x50;
        public static UInt32 DirectionOffset = 0x38;
        public static UInt32 PreviousOffset = 0x58;
        public static UInt32 NextOffset = 0x5C;
        public static UInt32 OutfitOffset = 0x60;
        public static UInt32 MountIdOffset = 0x78;
        public static UInt32 BlackSquareOffset = 0x88;
        public static UInt32 HppcOffset = 0x8C;
        public static UInt32 SpeedOffset = 0x90;
        public static UInt32 SkullOffset = 0x98;
        public static UInt32 PartyOffset = 0x9C;
        public static UInt32 WarOffset = 0xA8;
        public static UInt32 VisibleOffset = 0xAC;
    }

    class ContainerAddresses
    {
        public static UInt32 ContainerStart = 0x4063E0; // 4219872
        public static UInt32 ContainerMaxSlots = 36;
        public static UInt32 Max = 16;
        public static UInt32 MaxStack = 100;
        public static UInt32 Step = 0x1EC; // 192

        public static int ContLength = 0xFC; // Container is 60 bytes long plus items, each item is 12 bytes, and max containers is 16, so 252 bytes per container.

        public static UInt32 HasParentOffset = 0;
        public static UInt32 IdOffset = 0xC;
        public static UInt32 AmountOffset = 0x2C;
        public static UInt32 IsOpenOffset = 0x34;
        public static UInt32 VolumeOffset = 0x38;
        public static UInt32 NameOffset = 0x10;
        public static UInt32 ItemsOffset = 0x38;

        /*public uint HasParent;
        private fixed byte unknown[8];
        public uint Id;
        public fixed byte name[32];
        public uint Amount;
        public uint IsOpen;
        public uint Volume;*/
    }

    class MapAddresses
    {
        public static UInt32 MapStart = 0x5DA5C4;
        public static UInt32 MaxTiles = 2016;
    }

    class ItemAddresses
    {
        public static UInt32 Step = 0xC;
        public static UInt32 Id = 0;
        public static UInt32 Unknown2 = 0x4;
        public static UInt32 Count = 0x8;
    }
}
