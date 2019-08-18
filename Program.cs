using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate position = new Coordinate(0, 0);
            Coordinate goal = new Coordinate(4, 4);
            Maze map = new Maze(5, 5, position, goal);
            ConsoleKeyInfo move;

            map.Print();

            while (!position.Equals(goal))
            {
                Console.WriteLine("What direction would you like to move?");
                move = Console.ReadKey();


                if (map.CanMove(position, move.Key))
                {
                    if (move.Key == ConsoleKey.UpArrow || move.Key == ConsoleKey.W)
                    {
                        map.MoveItem(position, position.Offset(0, -1));
                        position = position.Offset(0, -1);
                    }
                    else if (move.Key == ConsoleKey.DownArrow || move.Key == ConsoleKey.S)
                    {
                        map.MoveItem(position, position.Offset(0, 1));
                        position = position.Offset(0, 1);
                    }
                    else if (move.Key == ConsoleKey.LeftArrow || move.Key == ConsoleKey.A)
                    {
                        map.MoveItem(position, position.Offset(-1, 0));
                        position = position.Offset(-1, 0);
                    }
                    else if (move.Key == ConsoleKey.RightArrow || move.Key == ConsoleKey.D)
                    {
                        map.MoveItem(position, position.Offset(1, 0));
                        position = position.Offset(1, 0);
                    }
                }

                map.Print();
                //Console.WriteLine(position.ToText());



            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
