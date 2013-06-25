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
            public float heuristic;
            public float G;
            public float F;
            public int parentID;
            public bool walkable;
        }
    }
}
