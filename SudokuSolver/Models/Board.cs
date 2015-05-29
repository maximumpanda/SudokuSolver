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
        readonly List<Number> _numbers = new List<Number>();
        private const int QuadrantDimensions = 3;
        private const int QuadrantCount = 9;

        public Board()
        {
            this.GenerateEmptyBoard(9);
            
            this.ReplaceNumber(new Number(1,1,9));
            this.GetQuadrantByNumber(new Number(9, 9, 9));
        }

        public Number GetNumberByLocation(int x, int y)
        {
            Number tempNumber = (from r in _numbers
                                 where r.X == x && r.Y == y
                                 select r).First();
            return tempNumber;
        }

        public List<Number> GetNumbersByXCoordinate(int x)
        {
            List<Number> tempNumbers = (from r in this._numbers
                                       where r.X == x
                                       select r).ToList();
            return tempNumbers;
        }

        public List<Number> GetNumbersByYCoordinate(int y)
        {
            List<Number> tempNumbers = (from r in this._numbers
                                        where r.Y == y
                                        select r).ToList();
            return tempNumbers;
        }

        public List<Number> GetNumbersByQuadrant(int x, int y)
        {
            List<Number> tempNumbers = new List<Number>();
            for (int xAxis = x; xAxis >= QuadrantDimensions; xAxis++)
            {
                for (int yAxis = y; yAxis >= QuadrantDimensions; yAxis++)
                {
                    tempNumbers.Add(GetNumberByLocation(xAxis, yAxis));
                }
            }
            return tempNumbers;
        }

        public bool IsValidValuePlacement(Number potentialNumber)
        {
            if (!CompareNumberValues(potentialNumber)) return false;
            else return true;
        }

        public void ReplaceNumber(Number newValue)
        {
            foreach (Number r in this._numbers)
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
                    this._numbers.Add(new Number(x, y));
                }
            }
        }
        
        public List<Number> GetQuadrantByNumber(Number sourceNumber)
        {
            var quadrant = new List<Number>();
            int location = (sourceNumber.X*10) + sourceNumber.Y;
            for (var xAxis = 0; xAxis < QuadrantCount; xAxis++)
            {
                for (var yAxis = 0; yAxis < QuadrantDimensions; yAxis++)
                {
                    bool numberLocationFound = false;                   
                    for (var stepX = 1; stepX <= QuadrantDimensions; stepX++)
                    {
                        for (var stepY = 1; stepY <= QuadrantDimensions; stepY++)
                        {
                            int currentLocation = (((xAxis*QuadrantDimensions) + stepX)*10) + ((yAxis*QuadrantDimensions) + stepY);
                            quadrant.Add(this.GetNumberByLocation((xAxis*QuadrantDimensions) + stepX, (yAxis*QuadrantDimensions) + stepY));
                            if(currentLocation == location) numberLocationFound = true;
                        }   
                    }
                    if (!numberLocationFound) quadrant.Clear();
                    else return quadrant;
                }
            }
            return quadrant;
        }

        private bool CompareNumberValues(Number potenialNumber)
        {
            List<Number> xValues = (from r in this._numbers
                where r.X == potenialNumber.X && r.Value == potenialNumber.Value && r.Value != 0
                select r).ToList();
            if (xValues.Count != 0) return false;

            List<Number> yValues = (from r in this._numbers
                where r.Y == potenialNumber.Y && r.Value == potenialNumber.Value && r.Value != 0
                select r).ToList();
            if (yValues.Count != 0) return false;

            return true;
        }

    }
}
