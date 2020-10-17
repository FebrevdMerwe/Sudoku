﻿using Sudoku.Puzzle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Solver
{
    public interface ISudokuSolver
    {
        ISudokuPuzzle Solve();
    }
}
