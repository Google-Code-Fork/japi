using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPI
{
    class Addresses
    {
        public static UInt32 Cid = 0x58AEA4; //
        public static UInt32 Xor = 0x3BF1F0; //
        public static UInt32 Hp = 0x553000; //
        public static UInt32 MaxHp = 0x58AE9C; //
        public static UInt32 Mp = 0x3BF244; //
        public static UInt32 MaxMp = 0x3BF1F4; //
        public static UInt32 Soul = 0x3BF230; //
        public static UInt32 XPos = 0x58AEA8; //
        public static UInt32 YPos = 0x58AEAC; //
        public static UInt32 ZPos = 0x58AEB0; //
        public static UInt32 Exp = 0x3BF200;//
        public static UInt32 IsConnected = 0x3C8FF8;//
    }

    class Hotkeys
    {
        public static UInt32 HKStart = 0x3C6998;
        public static UInt32 HKStep = 0x100;
        public static UInt32 HKMax = 24;

        public static UInt32 HKSendStart = 0x3C6970;
        public static UInt32 HKSendStep = 0x1;

        public static UInt32 HKItemStart = 0x3C8F30; //
        public static UInt32 HKItemStep = 0x4;

        public static UInt32 HKItemUseTypeStart = 0x3C67C0;
        public static UInt32 HKItemUseTypeStep = 0x4;
    }

    class BListAdresses
    {
        public static UInt32 Start = 0x553008;
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

        //public static int ContLength = 0xFC; // Container is 60 bytes long plus items, each item is 12 bytes, and max containers is 16, so 252 bytes per container.

        public static UInt32 HasParentOffset = 0;
        public static UInt32 IdOffset = 0xC;
        public static UInt32 AmountOffset = 0x2C;
        public static UInt32 IsOpenOffset = 0x34;
        public static UInt32 VolumeOffset = 0x38;
        public static UInt32 NameOffset = 0x10;
        public static UInt32 ItemsOffset = 0x38 + 0xC;
    }

    class MapAddresses
    {
        public static UInt32 MapStart = 0x5E1B54;
        public static UInt32 MaxTiles = 0x7E0;
        public static UInt32 Step = 0xA8;

        public static UInt32 CountOffset = 0x0;
        public static UInt32 StackOrderOffset = 0x4;
        public static UInt32 ItemOffset = 0x2C;
        public static UInt32 EffectOffset = 0xA4;

    }

    class ItemAddresses
    {
        public static UInt32 Step = 0xC;
        public static UInt32 Id = 0;
        public static UInt32 Unknown2 = 0x4;
        public static UInt32 Count = 0x8;
    }
}
