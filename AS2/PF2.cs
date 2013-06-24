using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AS2
{
    class PF2
    {
        // Function FindPath

        public Structs.Node GetLowestF(List<Structs.Node> nList)
        {
            int currentLowest = 65535;
            Structs.Node currentNode = nList[0];
            foreach (Structs.Node node in nList)
            {
                if (currentLowest > node.F) // Maybe this should be greater than not less than.
                {
                    currentLowest = node.F;
                    currentNode = node;
                }
            }
            return currentNode;
        }

        public Structs.Node getParent(int ID, List<Structs.Node> ClosedList)
        {
            foreach (Structs.Node nd in ClosedList)
            {
                if (nd.ID == ID)
                {
                    return nd;
                }
            }
            return new Structs.Node();
        }

        public List<Structs.Node> ReconstructPath(List<Structs.Node> ClosedList, Structs.Node End, Structs.Node Start)
        {
            List<Structs.Node> Path = new List<Structs.Node>();
            foreach (Structs.Node nd in ClosedList)
            {
                if (nd.X == End.X && nd.Y == End.Y)
                {
                    Path.Add(nd); // First path point added.
                }
            }
            while (Path[Path.Count - 1].X != Start.X || Path[Path.Count -1].Y != Start.Y)
            {
                // Add last items parent to Path list (Path[Path.Count - 1].ParentID)
                Path.Add(getParent(Path[Path.Count - 1].parentID, ClosedList));
            }
            return Path;
        }

        public List<Structs.Node> FindPath(Structs.Node Start, Structs.Node End, int[,] MapMatrix)
        {
            // A counter to check progress when debugging:
            int index = 0;
            bool Finished = false;

            // Declare Open and Closed sets, Current Node
            List<Structs.Node> OpenSet = new List<Structs.Node>();
            List<Structs.Node> ClosedSet = new List<Structs.Node>();
            Structs.Node CurrentNode = Start;
            int i = 0;

            // Set CurrentNode X and Y to their correct values:
            CurrentNode.X = Start.X;
            CurrentNode.Y = Start.Y;

            // Set G to 0
            CurrentNode.G = 0;

            // Set Heuristic to the estimated heuristic
            CurrentNode.heuristic = Math.Abs((CurrentNode.X - End.X) + (CurrentNode.Y - End.Y));

            // Set the F to the Heuristic + the G score.
            CurrentNode.F = CurrentNode.G + CurrentNode.heuristic;

            // Set the current nodes ID
            CurrentNode.ID = i;
            OpenSet.Add(CurrentNode);
            ClosedSet.Add(CurrentNode);

            // Add the current node to the OpenSet for consideration.

            // While the open set contains nodes
            while (Finished == false)
            {
                i++;
                // Set the current node to the value in the open set with the lowest F (H + G)
                CurrentNode = GetLowestF(OpenSet);

                // If the current tile is the goal, return reconstruct path method
                if (CurrentNode.X == End.X && CurrentNode.Y == End.Y)
                {
                    // TODO : Add ReconstructPath to this return method.
                    return OpenSet;
                }

                // Remove the current tile from the open set, but retain it in current tile var
                OpenSet.Remove(CurrentNode);

                // Add the current tile to the closed set, retaining it in the current tile var
                ClosedSet.Add(CurrentNode);

                // For each neighbor tile
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        if (CurrentNode.X + x < 0 || CurrentNode.Y + y < 0 || CurrentNode.X + x > 8 || CurrentNode.Y + y > 8 )
                        {
                            break;
                        }

                        index++;
                        // Create a neighbor node for investigation
                        Structs.Node neighbor = new Structs.Node();
                        neighbor.X = CurrentNode.X + x;
                        neighbor.Y = CurrentNode.Y + y;
                        neighbor.ID = i;
                        i++;

                        if (MapMatrix[neighbor.X, neighbor.Y] == 3)
                        {
                            break;
                        }

                        // Set Heuristic to the estimated heuristic
                        if (!(x == 0 || y == 0)) // If the X and Y are not both +1 or -1
                        {
                            neighbor.heuristic = Math.Abs((neighbor.X - End.X) + (neighbor.Y - End.Y));// +1; // Increase the heuristic if we are walking diagonally.
                        }
                        else
                        {
                            neighbor.heuristic = Math.Abs((neighbor.X - End.X) + (neighbor.Y - End.Y));
                        }

                        // Set G score of neighbor to current G score + cost of moving from current to neighbor
                        neighbor.G = CurrentNode.G + MapMatrix[neighbor.X, neighbor.Y];
                        neighbor.parentID = CurrentNode.ID;
                        neighbor.G = CurrentNode.G + MapMatrix[neighbor.X, neighbor.Y];
                        neighbor.F = neighbor.G + neighbor.heuristic;

                        // If the neighbor is in the closed set or the G score is higher than the current G score, break
                        // If the neighbor is not in the open set or the neighbor G score is less than the current G score
                        if ((!OpenSet.Contains(neighbor) || neighbor.G >= CurrentNode.G) && (neighbor.G >= CurrentNode.G || !ClosedSet.Contains(neighbor)))
                        {
                            if (!OpenSet.Contains(neighbor))
                            {
                                OpenSet.Add(neighbor);
                            }
                            if (neighbor.X == End.X && neighbor.Y == End.Y)
                            {
                                ClosedSet.Add(neighbor);
                                Finished = true;
                            }
                        }
                    }
                }


            }

            // Return failure if the open set is empty (break the while loop)
            return ClosedSet;
        }

        // reconstruct path function
        public List<Structs.Node> ReconstructPath(List<Structs.Node> OpenList)
        {
            List<Structs.Node> PathList = new List<Structs.Node>();
            int i = PathList.Count;
            foreach (Structs.Node PathPoint in OpenList)
            {
                PathList.Add(PathPoint);
            }

            return PathList;
        }

        
    }
}
