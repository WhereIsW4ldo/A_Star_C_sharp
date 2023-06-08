using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A_Star
{
    internal class A_star
    {
        bool debug;

        int grid_size;
        int start_x, start_y;
        int end_x, end_y;

        List<(int, int)> open;
        List<(int, int)> closed;
        List<(int, int)> path;

        Node[,] grid;
        Visual v;

        public A_star(bool debug = false) 
        {
            this.debug = debug;
            open = new List<(int, int)>();
            closed = new List<(int, int)>();
            path = new List<(int, int)>();
        }

        public void read_input()
        {
            IInput input = new ReadInput();
            grid_size = input.getSizeOfGrid();

            grid = new Node[grid_size, grid_size];

            (start_x, start_y) = input.getPosition(grid_size, true);
            (end_x, end_y) = input.getPosition(grid_size, false);

            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                {
                    grid[i, j] = new Node(i, j);
                    grid[i, j].calculate_h(end_x, end_y);
                }
            }
            v = new Visual();

            foreach (Tuple<int, int> wall in input.getWalls(grid_size))
            {
                grid[wall.Item1, wall.Item2].state = 'w';
            }

            grid[start_x, start_y].state = 's';
            grid[end_x, end_y].state = 'e';

            if (debug)
            {
                Console.WriteLine("Grid (size " + grid_size + "), start node: " + start_x + ", " + start_y + ", end node: " + end_x + ", " + end_y);
            }
        }

        public void display()
        {
            v.show(grid);
        }

        public static List<Tuple<int, int>> get_adjacent(int r, int c, int grid_size)
        {
            List<Tuple<int, int>> adjacents = new List<Tuple<int, int>>();

            // node not on top row
            if (r > 0)
                adjacents.Add(Tuple.Create(r - 1, c));

            // node not on bottom row
            if (r < grid_size - 1)
                adjacents.Add(Tuple.Create(r + 1, c));

            // node not on left column
            if (c > 0)
                adjacents.Add(Tuple.Create(r, c - 1));

            // node not on right column
            if (c < grid_size - 1)
                adjacents.Add(Tuple.Create(r, c + 1));

            // dia left down
            if (c > 0 && r < grid_size - 1)
                adjacents.Add(Tuple.Create(r + 1, c - 1));

            // dia left up
            if (c > 0 && r > 0)
                adjacents.Add(Tuple.Create(r - 1, c - 1));

            // dia right down
            if (c < grid_size - 1 && r < grid_size - 1)
                adjacents.Add(Tuple.Create(r + 1, c + 1));

            // dia right up
            if (c < grid_size - 1 && r > 0)
                adjacents.Add(Tuple.Create(r - 1, c + 1));


            return adjacents;
        }

        private (int row, int col) lowest_open_and_remove()
        {
            int lowest_f = int.MaxValue;
            int row = -1, col = -1;

            for (int i = 0; i < open.Count; i++)
            {
                int r = open[i].Item1;
                int c = open[i].Item2;

                if (grid[r, c].f < lowest_f)
                {
                    lowest_f = grid[r, c].f;
                    row = r; col = c;
                }
            }
            open.Remove((row, col));
            return (row,  col);
        }

        private void trace_path()
        {
            Node current_node = grid[end_x, end_y];
            while(true)
            {
                Console.WriteLine("node on: " + current_node.row + ", " + current_node.col);
                if (current_node.parent == (-1, -1))
                {
                    break;
                }
                current_node.state = 'p';
                current_node = grid[current_node.parent.row, current_node.parent.col];
            }
        }

        public void calculate_path()
        {
            // add starting node to open list
            open.Add((start_x, start_y));

            //for (int i = 0; i < 10; i++)
            while (open.Count > 0)
            {
                // find node with lowest f-cost in open list and remove from open list
                (int row, int col) = lowest_open_and_remove();

                Node current_node = grid[row, col];

                // add current_node to closed list
                closed.Add((row, col));
                current_node.state = 'c';

                // get adjacent nodes and set parents to current node
                List<Tuple<int, int>> adjacents = get_adjacent(row, col, grid_size);

                foreach (Tuple<int, int> adjacent in adjacents)
                {
                    Node adj = grid[adjacent.Item1, adjacent.Item2];

                    // end found!
                    if ((adjacent.Item1, adjacent.Item2) == (end_x, end_y))
                    {
                        // set end node parent to adjacent
                        grid[end_x, end_y].parent = (row, col);

                        Console.WriteLine("End found!");

                        trace_path();
                        v.show(grid);

                        return;
                    }

                    if (closed.Contains((adjacent.Item1, adjacent.Item2)) || adj.state == 'w')
                    {
                        continue;
                    }

                    if (!open.Contains((adjacent.Item1, adjacent.Item2)))
                    {
                        open.Add((adjacent.Item1, adjacent.Item2));
                        adj.state = 'o';
                        adj.parent = (row, col);
                        adj.g = current_node.g + 1;
                        adj.calculate_f();
                    }
                    else
                    {
                        if (adj.g > current_node.g + 1)
                        {
                            adj.parent = (row, col);
                            adj.g = current_node.g + 1;
                            adj.calculate_f();
                        }
                    }
                }
                //v.show(grid);
            }
        }
    }
}
