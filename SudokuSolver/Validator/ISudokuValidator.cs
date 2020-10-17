using Sudoku.Cells;
using Sudoku.Puzzle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Validator
{
    public interface ISudokuValidator
    {
        bool ValidateSudoku(ISudokuPuzzle puzzle);
        bool ValidateCell(ISudokuPuzzle puzzle, Cell cell);
    }
}
