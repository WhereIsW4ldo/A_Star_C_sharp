namespace A_Star
{
    internal class ReadInput
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
    }
}
