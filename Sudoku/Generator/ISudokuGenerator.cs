using Sudoku.Puzzle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Generator
{
    public interface ISudokuGenerator
    {
        ISudokuPuzzle Generate(SudokuDifficulty config, int? seed = null);
    }
}
