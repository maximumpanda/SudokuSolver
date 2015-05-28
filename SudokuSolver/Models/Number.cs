using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    class Number : Point
    {
        public int Value { get; set; }

        public Number(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Value = 0;
        }

        public Number(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }
    }
}
