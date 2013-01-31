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

        public struct Container
        {
            public int HasParent;
            public int Id;
            public string Name;
            public int Amount;
            public int IsOpen;
            public int Volume;
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
