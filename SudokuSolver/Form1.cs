using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SudokuSolver.Models;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Board NewBoard = new Board();

            NewBoard.IsValidValuePlacement(new Number(2,2,9));
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
