using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver.Models
{
    class Board
    {
        List<Number> Numbers = new List<Number>();

        public Board()
        {
            GenerateEmptyBoard(9);
            
            ChangeValueAtLocation(new Number(1,1,9));
        }

        public Number GetNumberByLocation(int x, int y)
        {
            Number tempNumber = (from r in Numbers
                                 where r.X == x && r.Y == y
                                 select r).First();
            return tempNumber;
        }

        public List<Number> GetNumbersByXCoordinate(int x)
        {
            List<Number> tempNumbers = (from r in this.Numbers
                                       where r.X == x
                                       select r).ToList();
            return tempNumbers;
        }

        public List<Number> GetNumbersByYCoordinate(int y)
        {
            List<Number> tempNumbers = (from r in this.Numbers
                                        where r.Y == y
                                        select r).ToList();
            return tempNumbers;
        }

        public List<Number> GetNumbersByQuadrant(int x, int y)
        {
            List<Number> TempNumbers = new List<Number>();
            for (int xAxis = x; xAxis >= 3; xAxis++)
            {
                for (int yAxis = y; yAxis >= 3; yAxis++)
                {
                    TempNumbers.Add(GetNumberByLocation(xAxis, yAxis));
                }
            }
            return TempNumbers;
        }

        public bool IsValidValuePlacement(Number potentialNumber)
        {
            if (!CompareNumberValues(potentialNumber)) return false;
            else return true;
        }

        public void ChangeValueAtLocation(Number newValue)
        {
            foreach (Number r in this.Numbers)
            {
                if (r.X == newValue.X && r.Y == newValue.Y)
                {
                    r.Value = newValue.Value;
                }
            }
        }

        private void GenerateEmptyBoard(int dimension)
        {
            for (var x = 1; x <= dimension; x++)
            {
                for (var y = 1; y <= dimension; y++)
                {
                    this.Numbers.Add(new Number(x, y));
                }
            }
        }

        private bool CompareNumberValues(Number potenialNumber)
        {
            List<Number> xValues = (from r in this.Numbers
                where r.X == potenialNumber.X && r.Value == potenialNumber.Value && r.Value != 0
                                    select r).ToList();
            if (xValues.Count != 0) return false;

            List<Number> yValues = (from r in this.Numbers
                                    where r.Y == potenialNumber.Y && r.Value == potenialNumber.Value && r.Value != 0
                                    select r).ToList();
            if (yValues.Count != 0) return false;

            return true;
        }
        

        
    }
}
