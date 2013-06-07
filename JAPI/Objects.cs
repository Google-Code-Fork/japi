using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JAPI
{
    public class Objects
    {
        public struct Error
        {
            public string Message;
            public int type; // Type can be 1-5, depending on the urgency of errors selected.
        }
        public struct Client
        {
            public Process Process;
            public string Name;
        }

        public struct Hotkey
        {
            public string Key;
            public string Value;
        }

        public struct MiniMapFile
        {
           //MiniMapTile[] Tiles = new MiniMapTile[256 * 256];
            // I will add shit here later for dealing with the markers on minimap
        }

        public struct MiniMapTile
        {
            public bool walkable; // Is the tile walkable
            public bool floorchange; // Is it a floor change (appears yellow on mimimap
            public bool fishable; // Is the tile WATER - Not sure if this returns correctly for certain water tiles which are not fishable
            public int speed; // 0-255, 255 being non-walkable though walkable is determined in 2 places
            public int x; // Coordinates are offsets from the file start (e.g each file will begin at 0, 0, and go to 255, 255) I think.
            public int y; //
            public int z; //
            public int color; // Colour on the minimap tile, this could be useful for some reason, not sure why, but it's not a lot of RAM
        }

        public struct MapTile
        {
            public int count; // The count of the items
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
            public int Unknown2; // This is the hangable state and returns something like 18 or 19 if the item is hanging vertical or horiz
            public int StackCount;
        }

        public struct Container
        {
            public int HasParent; // Is the parent button clickable - VERY USEFUL!
            public int Id; // the Id of the container itself
            public string Name; // The name as a string, terminated by \0
            public int Amount; // The amount of times this container is open? IDFK.
            public string IsOpen; // Is the container open
            public int Volume; // The volume of it (amount of slots, for the lesser informed)
            public Item[] Items; // The array of items, as a list of the above, this is maximum of 36.
        }

        public struct BList
        {
            public int Addr; // The current creatures offset from the start of the battle list as a number to be multiplied

            public int Id; // Creature ID
            public int Type; // Type - 64 = creature, 2 = player?
            public string Name; // Name, terminated by \0
            public int Z; // Z position
            public int Y; // Y position
            public int X; // X position
            public int TimeLastMoved; // The time in milliseconds since this creature last moved
            public int Walking; // Is it walking? 
            public int Direction; // Which direction is it facing 
            public int Previous; // What the fuck is this for? I've gotta stop reading shit I don't know about
            public int Next; // Again, what the fuck?!
            public int Outfit; // Outfit ID, can be enumerated later on
            public int MountId; // Mount ID, again can be enumerated though probably about as much use as a condom in a nunnery.

            public int BlackSquare; // Is this even still valid? I swear to god they removed this shit.
            public int Hppc; // Health, as a percentage... That's out of 100!!!!
            public int Speed; // The creatures speed as determined by CIPs dodgy calculations

            public int SkullType; // The type of skull the player has (0 for none), can be enum'd
            public int Party; // Party type (leader, invited, member)
            public int WarIcon; // War icon (friendly, enemy, not part of your war so stay the fuck out of shit you ain't involved in).
            public int Visible; // CAN YOU SEE ME MOTHERFUCKER?

            // 20 entries total.
        }

        public struct Player
        {
            public int Cid; // Creature ID, useful for reading name from battle list
            public int Hp; // Your HP
            public int Mp; // Your MP
            public int HpMax; // Your max HP
            public int MpMax; // Your max MP
            public int Exp; // Your Exp from Tibia, non calculated
            public int Soul; // Your soul is mine nigger.
            public int X; // Your x pos, again useful for blist comparison I guess
            public int Y; // Your y pos, I'm not typing this shit again.
            public int Z; // Fuck you, work it out.
        }

        public struct HealRule
        {
            public int MinHp; // Heal rules minimum health to cast a spell on | spell will be casted when hp is > minhp and
            public int MaxHp; // Heal rules maximum health to cast a spell on | hp is < maxhp, we got ur back bro.
            public int Mana; // The minimum required mana to cast the spell. Fuck me this is obvious.
            public string Hotkey; // The hotkey to press, this could be calculated later but fuck I'm lazy.
        }

        public struct Colour // This is for the minimap shit, dunno where to put it so I dumped it here.
        {
            public int r; // RED
            public int g; // GREEN
            public int b; // BLUE
        }                 // FUUUUUUUUUUUUUUUUUUUUUU

        public struct Location // A struct for locations (x, y, z coordinates.)
        {
            public int x;
            public int y;
            public int z;
        }
    }
}
