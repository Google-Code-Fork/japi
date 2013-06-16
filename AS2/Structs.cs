using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AS2
{
    public class Structs
    {
        public struct Node
        {
            public int ID;
            public int X;
            public int Y;
            public int speed;
            public int heuristic;
            public int parentID;
            public bool walkable;
        }
    }
}
