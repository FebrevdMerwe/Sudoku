using Sudoku.Puzzle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Generator
{
    public interface ISudokuGenerator
    {
        ISudokuPuzzle Generate(Configuration config, int? seed = null);
    }
}
