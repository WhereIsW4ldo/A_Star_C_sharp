using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star
{
    internal class Node
    {
        private char _state = 'n'; // possible states: 'n', 'e', 's', 'o', 'c', 'p', 'w'
        private int _g, _h, _f;
        private int _row;
        private int _col;
        private (int row, int col) _parent;
        
        public Node(int row, int col)
        {
            g = -1;
            h = -1;
            f = -1;
            this.row = row;
            this.col = col;
            parent = (-1, -1);
        }

        public void calculate_f()
        {
            f = g + h;
        }

        public void calculate_h(int goal_r, int goal_c)
        {
            h = (int) Math.Pow(Math.Abs(row - goal_r), 2) + (int) Math.Pow(Math.Abs(col - goal_c), 2);
        }

        public int g { get { return _g; } set { _g = value; } }
        public int h { get { return _h; } set { _h = value; } }
        public int f { get { return _f; } set { _f = value; } }
        public char state { get { return _state; } set { _state = value; } }
        public int row { get { return _row; } set { _row = value; } }
        public int col { get { return _col; } set { _col = value; } }
        public (int row, int col) parent { get { return _parent; } set { _parent = value; } }
    }
}
