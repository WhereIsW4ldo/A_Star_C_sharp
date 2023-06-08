using System.Net;

namespace A_Star
{
    internal class ReadInput: IInput
    {

        public ReadInput()
        {

        }

        public int getSizeOfGrid()
        {
            while (true)
            {
                Console.Write("Please give size of grid: ");
                var input = Console.ReadLine();

                if (input == null)
                    continue;
                else
                {
                    try
                    {
                        int size = Convert.ToInt32(input);
                        if (size > 0)
                            return size;
                        else
                            continue;
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
        }

        public (int x, int y) getPosition(int size_grid, bool start)
        {
            int x = -1, y = -1;
            while (true)
            {
                string input_x = null, input_y = null;

                if (start)
                    Console.WriteLine("Please give start positions: ");
                else 
                    Console.WriteLine("Please give end positions: ");

                if (x == -1)
                {
                    Console.Write("x: ");
                    input_x = Console.ReadLine();
                }
                if (y == -1)
                {
                    Console.Write("y: ");
                    input_y = Console.ReadLine();
                }
                if (input_x != null)
                {
                    try
                    {
                        var temp = Convert.ToInt32(input_x);
                        if (temp >= 0 && temp < size_grid) x = temp;
                    }
                    catch { }
                }
                if (input_y != null)
                {
                    try
                    {
                        var temp = Convert.ToInt32(input_y);
                        if (temp >= 0 && temp < size_grid) y = temp;
                    }
                    catch { }
                }
                if (x >= 0 && y >= 0)
                {
                        return (x, y);
                }
            }
        }

        public List<Tuple<int, int>> getWalls(int size_grid)
        {
            Console.WriteLine("Please give amount of walls to be placed: ");
            string len = Console.ReadLine();
            int l = int.Parse(len);

            List<Tuple<int, int>> walls = new List<Tuple<int, int>>();

            int x = -1, y = -1;
            while (walls.Count <= l)
            {
                string input_x = null, input_y = null;
                Console.WriteLine("Wall " + walls.Count + " position: ");

                if (x == -1)
                {
                    Console.Write("x: ");
                    input_x = Console.ReadLine();
                }
                if (y == -1)
                {
                    Console.Write("y: ");
                    input_y = Console.ReadLine();
                }
                if (input_x != null)
                {
                    try
                    {
                        var temp = Convert.ToInt32(input_x);
                        if (temp >= 0 && temp < size_grid) x = temp;
                    }
                    catch { }
                }
                if (input_y != null)
                {
                    try
                    {
                        var temp = Convert.ToInt32(input_y);
                        if (temp >= 0 && temp < size_grid) y = temp;
                    }
                    catch { }
                }
                if (x >= 0 && y >= 0)
                {
                    walls.Add(Tuple.Create(x, y));
                    x = -1;
                    y = -1;
                }
            }
            return walls;
        }
    }
}
