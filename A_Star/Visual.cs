using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star
{
    internal class Visual
    {
        public Visual() 
        {
        }

        public void show(Node[,] grid)
        {
            Console.Clear();
            int size_i = grid.GetLength(0);
            int size_j = grid.GetLength(1);

            for (int i = 0; i < size_i; i++)
            {
                for (int j = 0; j < size_j - 1; j++)
                {
                    display_char(grid[i, j]);
                    Console.Write(" ");
                }
                display_char(grid[i, size_j - 1]);
                Console.WriteLine(" ");
            }
        }

        private void display_char(Node node)
        {
            switch (node.state)
            {
                // possible states: 'n', 'e', 's', 'o', 'c', 'p'
                case 'n':
                    break;
                case 'e':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case 's':
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'o':
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'c':
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 'p':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case 'w':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                default:
                    break;
            }
            Console.Write('#');
            Console.ResetColor();
        }
    }
}