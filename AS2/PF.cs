using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AS2
{
    public class PF
    {
        List<Structs.Node> openList = new List<Structs.Node>();
        List<Structs.Node> closedList = new List<Structs.Node>();
        public List<Structs.Node> findPath(int startX, int startY, int endX, int endY, int[,] mapMatrix)
        {
            int i = 0;
            bool pathFound = false;
            int currentH = Math.Abs(startX - startY) + Math.Abs(endX - endY);
            List<Structs.Node> path = new List<Structs.Node>();
            Structs.Node currentTile = new Structs.Node();
            currentTile = researchNode(startX, startY, endX, endY, i, mapMatrix, -1);
            openList.Add(currentTile);
            while (!pathFound)
            {
                float lowestH = 65535;
                // When we don't have a path, find the lowest H value in our openList
                foreach (Structs.Node nd in openList)
                {
                    // If its walkable and has lowest H value, make it the next tile to be examined.
                    if (nd.heuristic < lowestH && nd.walkable)
                    {
                        currentTile = nd;
                        lowestH = currentTile.heuristic;
                    }
                    // Else if it's not walkable, remove from open and add to closed list.
                    else if (!nd.walkable)
                    {
                        openList.Remove(nd);
                        closedList.Add(nd);
                    }
                }

                // Now research the tile around the selected node.
                // For each value where the X coord is within 1 sqm of the node, as is the Y coord
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        if (x == 0 && y == 0)
                        {

                        }
                        else
                        {
                            try
                            {
                                if (mapMatrix[currentTile.X + x, currentTile.Y + y] == 2)
                                {
                                    pathFound = true;
                                }
                                // Add the researched tile to the open list.
                                openList.Add(researchNode(currentTile.X + x, currentTile.Y + y, endX, endY, i, mapMatrix, currentTile.ID));
                            }
                            catch (Exception ex)
                            {
                                
                            }
                        }
                    }
                }
                openList.Remove(currentTile);
            }
            return openList;
        }
        public int getHeuristic(int startX, int startY, int endX, int endY)
        {
            int h = Math.Abs(startX - startY) + Math.Abs(endX - endY);
            return h;
        }

        public Structs.Node researchNode(int X, int Y, int endX, int endY, int i, int[,] mapMatrix, int pId)
        {
            Structs.Node currentTile = new Structs.Node();
            currentTile.ID = i;
            currentTile.X = X;
            currentTile.Y = Y;
            currentTile.speed = mapMatrix[X, Y];
            currentTile.heuristic = getHeuristic(X, Y, endX, endY);
            currentTile.parentID = pId;
            if (mapMatrix[X, Y] == 3)
                currentTile.walkable = false;
            else
                currentTile.walkable = true;
            return currentTile;
        }
    }
}
