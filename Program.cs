using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //int height = 27;
            //int width = 117;
            int height = 10;
            int width = 10;

            Coordinate position = new Coordinate(0, 0);
            Player player = new Player(position, "*", 3, 0);
            EntityList.Instance.Entities.Add(player);

            Map.Instance.GenerateMap(width, height);

            Coordinate goal = new Coordinate(rand.Next(width), rand.Next(height));
            while (!Map.Instance.TileAt(goal).IsPathable() || goal.Equals(position))
            {
                goal = new Coordinate(rand.Next(width), rand.Next(height));
            }
            Entity endPoint = new Entity(goal, "!", 0, 1);
            EntityList.Instance.Entities.Add(endPoint);


            Map.Instance.Print();


            while (!player.GetPosition().Equals(goal))
            {
                ConsoleKey action = Console.ReadKey().Key;

                player.AcceptInput(action);

                Map.Instance.Print();
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
