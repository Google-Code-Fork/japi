using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JAPI
{
    public class Objects
    {
        /*public struct World
        {
            public Objects.BList BList;
            public Objects.Player Player;
            public Objects.Minimap Minimap;
            public Objects.GUI GUI;
        }

        public struct GUI
        {
            public int i;
        }

        public struct Minimap
        {
            public int i;
        }*/

        public struct MapTile
        {
            public int count;
            public int[] StackOrder; // Not entirely sure what this is, but suspect it's something to do with where the tile is?
            public Item[] Items; // 10 items, each with 12 bytes using item structure
            public int Effect;
            /*
            public uint count;
            public fixed uint stackOrder[10];
            public fixed uint items[10 * 3];
            public uint effect;
             */
        }

        public struct Item
        {
            public int Id;
            public int Unknown2;
            public int StackCount;
        }

        public struct Container
        {
            public int HasParent;
            public int Id;
            public string Name;
            public int Amount;
            public int IsOpen;
            public int Volume;
            public Item[] Items;
        }

        public struct BList
        {
            public int Addr;

            public int Id;
            public int Type;
            public string Name;
            public int Z;
            public int Y;
            public int X;
            public int TimeLastMoved;
            public int Walking;
            public int Direction;
            public int Previous;
            public int Next;
            public int Outfit;
            public int MountId;

            public int BlackSquare;
            public int Hppc;
            public int Speed;

            public int SkullType;
            public int Party;
            public int WarIcon;
            public int Visible;
        }

        public struct Player
        {
            public int Cid;
            public int Hp;
            public int Mp;
            public int HpMax;
            public int MpMax;
            public int Exp;
            public int Soul;
            public int X;
            public int Y;
            public int Z;
        }

        public struct HealRule
        {
            public int MinHp;
            public int MaxHp;
            public int Mana;
            public string Hotkey;
        }
    }
}
