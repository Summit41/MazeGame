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
            int height = 27;
            int width = 117;
            //int height = 10;
            //int width = 10;

            Coordinate position = new Coordinate(0, 0);
            Player player = new Player(position, "*", 5, 0);
            EntityList.Instance.Entities.Add(player);

            Class1 map = new Class1(position);
            map.GenerateMap(width, height);
            Map.Instance.GenerateMap(map.GetMap());

            Coordinate goal = map.GetEndPoint();
            Entity endPoint = new Entity(goal, "!", 0, 1);
            EntityList.Instance.Entities.Add(endPoint);


            //map.Print();
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
