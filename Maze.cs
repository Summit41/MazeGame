using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneration
{
    class Maze
    {
        private const int WALL = 8;
        private const string WALL_DISPLAY = "#";
        private const int PATH = 0;
        private const string PATH_DISPLAY = " ";
        private const int END = 1;
        private const string END_DISPLAY = "!";
        private const int PLAYER = 2;
        private const string PLAYER_DISPLAY = "*";


        private int[,] map;
        private Coordinate startPos;
        private Coordinate endPos;

        public Maze(int width, int height, Coordinate startPos, Coordinate endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
            this.map = new int[width, height];
            this.GenerateMaze();
        }

        private void GenerateMaze()
        {
            map[endPos.x, endPos.y] = END;
            map[startPos.x, startPos.y] = PLAYER;
            map[1, 1] = WALL;
        }



        public bool CanMove(Coordinate position, ConsoleKey direction)
        {
            if (direction == ConsoleKey.UpArrow || direction == ConsoleKey.W)
            {
                if (position.y > 0 && ValueAt(new Coordinate(position.x, position.y - 1)) != WALL)
                {
                    return true;
                }
            }
            else if (direction == ConsoleKey.DownArrow || direction == ConsoleKey.S)
            {
                if (position.y < map.GetLength(1) - 1 && ValueAt(new Coordinate(position.x, position.y + 1)) != WALL)
                {
                    return true;
                }
            }
            else if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
            {
                if (position.x > 0 && ValueAt(new Coordinate(position.x - 1, position.y)) != WALL)
                {
                    return true;
                }
            }
            else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
            {
                if (position.x < map.GetLength(0) - 1 && ValueAt(new Coordinate(position.x + 1, position.y)) != WALL)
                {
                    return true;
                }
            }

            return false;

        }

        public void Print()
        {
            Console.WriteLine();
            string header = "";
            for (int w = 0; w < map.GetLength(0) + 2; w++)
            {
                header = header + WALL;
            }
            header = header.Replace("" + WALL, WALL_DISPLAY);
            Console.WriteLine(header);

            for (int l = 0; l < map.GetLength(1); l++)
            {
                string line = "" + WALL;
                for (int w = 0; w < map.GetLength(0); w++)
                {
                    line = line + ValueAt(w, l);
                }

                line = line + WALL;
                line = line.Replace("" + WALL, WALL_DISPLAY);
                line = line.Replace("" + PATH, PATH_DISPLAY);
                line = line.Replace("" + END, END_DISPLAY);
                line = line.Replace("" + PLAYER, PLAYER_DISPLAY);
                Console.WriteLine(line);
            }

            Console.WriteLine(header);
        }

        public void MoveItem(Coordinate itemPosition, Coordinate destination)
        {
            map[destination.x, destination.y] = map[itemPosition.x, itemPosition.y];
            map[itemPosition.x, itemPosition.y] = PATH;
        }

        public int ValueAt(Coordinate position)
        {
            if (position.x >= 0 && position.x < map.GetLength(0) && position.y >= 0 && position.y < map.GetLength(1))
            {
                return map[position.x, position.y];
            }
            else
            {
                return -1;
            }
        }

        public int ValueAt(int x, int y)
        {
            if (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
            {
                return map[x, y];
            }
            else
            {
                return -1;
            }
        }
    }
}
