using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Class1
{
        private Tile[,] map;
        private Random rand = new Random();
        private Coordinate startPos;
        private Coordinate endPos;

        public Class1(Coordinate startPos)
        {
            this.startPos = startPos;
        }

        public Tile[,] GetMap()
        {
            return map;
        }

        //0 = North, 1 = South, 2 = East, 3 = West
        private void CreatePath(Coordinate origin, int direction)
        {
            Coordinate destination = origin.Offset(direction);

            Coordinate[] Neighbors = GetNeighbors(origin);

            for (int i = 0; i < Neighbors.Length; i++)
            {
                if (InBounds(Neighbors[i]))
                {
                    if (i != direction)
                    {
                        if (TileAt(Neighbors[i]).Equals(TileDefinition.Instance.DEFAULT))
                        {
                            SetTile(TileDefinition.Instance.TEMPWALL, Neighbors[i]);
                        }
                        else if (TileAt(Neighbors[i]).Equals(TileDefinition.Instance.TEMPWALL))
                        {
                            SetTile(TileDefinition.Instance.PERMWALL, Neighbors[i]);
                        }
                    }
                }
            }

            SetTile(TileDefinition.Instance.PATH, origin);
        }

        public Coordinate GetEndPoint()
        {
            return endPos;
        }

        private void SetTile(Tile tile, Coordinate position)
        {
            map[position.x, position.y] = tile;
        }

        private void SetTile(Tile tile, int x, int y)
        {
            map[x, y] = tile;
        }

        private bool InBounds(Coordinate position)
        {
            if ((position.x < 0 || position.x >= map.GetLength(0)))
            {
                return false;
            }
            else if ((position.y < 0 || position.y >= map.GetLength(1)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidMove(Coordinate origin, int direction)
        {
            Coordinate destination = origin.Offset(direction);
            if (!InBounds(destination))
            {
                return false;
            }
            if (TileAt(destination).Equals(TileDefinition.Instance.DEFAULT))
            {
                return true;
            }
            return false;
        }

        private bool ValidMove(int x, int y, int direction)
        {
            Coordinate destination = new Coordinate(x, y).Offset(direction);
            if (!InBounds(destination))
            {
                return false;
            }
            if (TileAt(destination).Equals(TileDefinition.Instance.DEFAULT))
            {
                return true;
            }
            return false;
        }

        private Coordinate[] GetNeighbors(Coordinate position)
        {
            Coordinate[] GetNeighbors = new Coordinate[4];

            GetNeighbors[0] = position.Offset(0, -1);
            GetNeighbors[1] = position.Offset(0, 1);
            GetNeighbors[2] = position.Offset(-1, 0);
            GetNeighbors[3] = position.Offset(1, 0);

            return GetNeighbors;
        }

        private Coordinate[] GetNeighbors(int x, int y)
        {
            Coordinate position = new Coordinate(x, y);
            Coordinate[] GetNeighbors = new Coordinate[4];

            GetNeighbors[0] = position.Offset(0, -1);
            GetNeighbors[1] = position.Offset(0, 1);
            GetNeighbors[2] = position.Offset(-1, 0);
            GetNeighbors[3] = position.Offset(1, 0);

            return GetNeighbors;
        }

        public void GenerateMap(int width, int height)
        {
            this.map = new Tile[width, height];

            bool stuck = false;

            for (int l = 0; l < map.GetLength(1); l++)
            {
                for (int w = 0; w < map.GetLength(0); w++)
                {
                    SetTile(TileDefinition.Instance.DEFAULT, w, l);
                }
            }

            Coordinate cursor = startPos;
            while (!stuck)
            {
                int direction = rand.Next(4);
                int distance = rand.Next(1, 5);

                for (int j = 0; j < distance; j++)
                {
                    if (ValidMove(cursor, direction))
                    {
                        CreatePath(cursor, direction);
                        cursor = cursor.Offset(direction);
                        //Print();
                        //Console.WriteLine(distance + " in " + direction);
                        //Console.ReadKey();
                    }
                }

                bool hasValidMove = false;
                for (int d = 0; d < 4; d++)
                {
                    // If any direction is a valid move
                    if (ValidMove(cursor, d))
                    {
                        hasValidMove = true;
                    }
                }

                if (!hasValidMove)
                {
                    SetTile(TileDefinition.Instance.PERMWALL, cursor);
                    List<Coordinate> possibleStarts = new List<Coordinate>();
                    for (int l = 0; l < map.GetLength(1); l++)
                    {
                        for (int w = 0; w < map.GetLength(0); w++)
                        {
                            if(TileAt(w, l).Equals(TileDefinition.Instance.TEMPWALL))
                            {
                                bool valid = false;
                                for (int n = 0; n < 4; n++)
                                {
                                    if (ValidMove(w, l, n) && !valid)
                                    {
                                        possibleStarts.Add(new Coordinate(w, l));
                                        valid = true;
                                    }
                                }
                                if (!valid)
                                {
                                    SetTile(TileDefinition.Instance.PERMWALL, new Coordinate(w, l));
                                }
                            }
                        }
                    }

                    if (possibleStarts.Count == 0)
                    {
                        stuck = true;
                    }
                    else
                    {
                        int newBranch = rand.Next(possibleStarts.Count);
                        cursor = possibleStarts[newBranch];
                    }
                }

            }

            this.map[startPos.x, startPos.y] = TileDefinition.Instance.START;

            List<Coordinate> possibleEndPoints = new List<Coordinate>();
            for (int l = 0; l < map.GetLength(1); l++)
            {
                for (int w = 0; w < map.GetLength(0); w++)
                {
                    if (TileAt(w, l).Equals(TileDefinition.Instance.PATH))
                    {
                        int numWalls = 0;
                        Coordinate[] neighbors = GetNeighbors(w, l);
                        for (int n = 0; n < 4; n++)
                        {
                            if (InBounds(neighbors[n]))
                            {
                                if (TileAt(neighbors[n]).Equals(TileDefinition.Instance.PERMWALL))
                                {
                                    numWalls++;
                                }
                            }
                        }
                        if (numWalls == 3)
                        {
                            possibleEndPoints.Add(new Coordinate(w, l));
                        }
                    }
                }
            }

            int endIndex = rand.Next(possibleEndPoints.Count);

            SetTile(TileDefinition.Instance.END, possibleEndPoints[endIndex]);
            endPos = possibleEndPoints[endIndex];
        }


        public void Print()
        {
            Console.Clear();
            string header = "";
            for (int w = 0; w < map.GetLength(0) + 2; w++)
            {
                header = header + TileDefinition.Instance.WALL.GetDisplay();
            }
            Console.WriteLine(header);

            for (int l = 0; l < map.GetLength(1); l++)
            {
                string line = TileDefinition.Instance.WALL.GetDisplay();
                for (int w = 0; w < map.GetLength(0); w++)
                {
                    line = line + TileAt(w, l).GetDisplay();
                }
                line = line + TileDefinition.Instance.WALL.GetDisplay();
                Console.WriteLine(line);
            }

            Console.WriteLine(header);
        }

        public Tile TileAt(Coordinate position)
        {
            if (position.x >= 0 && position.x < map.GetLength(0) && position.y >= 0 && position.y < map.GetLength(1))
            {
                return map[position.x, position.y];
            }
            else
            {
                return null;
            }
        }

        public Tile TileAt(int x, int y)
        {
            if (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
            {
                return map[x, y];
            }
            else
            {
                return null;
            }
        }
    }
}
