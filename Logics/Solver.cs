using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    public class Solver
    {
        public int[][] Solve(int[][] sudoku)
        {
            //int[][] solved = sudoku;
            char[][] solved = HashSolver.IntToJagChar(sudoku, 9);

            return HashSolver.SolveSudoku(solved);
        }

		public int[][] Create(int[][] sudoku)
        {

            return sudoku;
        }
    }
}