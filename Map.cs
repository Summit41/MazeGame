using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    sealed class Map
    {

        private Tile[,] map;
        private Random rand = new Random();

        private static readonly Map INSTANCE = new Map();

        public static Map Instance
        {
            get
            {
                return INSTANCE;
            }
        }

        public void GenerateMap(int width, int height)
        {
            this.map = new Tile[width, height];

            for (int l = 0; l < map.GetLength(1); l++)
            {
                string line = "" + TileDefinition.Instance.WALL;
                for (int w = 0; w < map.GetLength(0); w++)
                {
                    if (rand.Next(99) < 10)
                    {
                        this.map[w, l] = TileDefinition.Instance.WALL;
                    }
                    else
                    {
                        this.map[w, l] = TileDefinition.Instance.PATH;
                    }
                }
            }

            map[1, 1] = TileDefinition.Instance.WALL;
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
                    bool visible = false;
                    string display = "";
                    int displayPriority = 100000;

                    foreach (var entity in EntityList.Instance.Entities)
                    {
                        if (entity.GetPosition().DistanceBetween(w, l) <= entity.GetLineOfSight())
                        {
                            visible = true;
                        }
                        if (entity.GetPosition().DistanceBetween(w, l) == 0)
                        {
                            if (entity.getDisplayPriority() < displayPriority)
                            {
                                displayPriority = entity.getDisplayPriority();
                                display = entity.GetDisplay();
                            }
                        }
                    }
                    if (visible)
                    {
                        if (display != "")
                        {
                            line = line + display;
                        }
                        else
                        {
                            line = line + TileAt(w, l).GetDisplay();
                        }
                    }
                    else
                    {
                        line = line + TileAt(w, l).GetFOW_Display();
                    }
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
