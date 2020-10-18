using Sudoku.Cells;
using Sudoku.Puzzle;
using System;
using System.Linq;

namespace Sudoku.Validator
{
    public class SudokuValidator : ISudokuValidator
    {
        public bool ValidateCell(ISudokuPuzzle puzzle, Cell cell)
        {
            var rowValues = puzzle.GetRow(cell.Row).Where(c => c.Id != cell.Id && c.Value != 0).Select(c => c.Value);
            if (rowValues.Contains(cell.Value))
                return false;

            var colValues = puzzle.GetColumn(cell.Column).Where(c => c.Id != cell.Id && c.Value != 0).Select(c => c.Value);
            if (colValues.Contains(cell.Value))
                return false;

            var blockValues = puzzle.GetBlock(cell.Block).Where(c => c.Id != cell.Id && c.Value != 0).Select(c => c.Value);
            if (blockValues.Contains(cell.Value))
                return false;

            return true;
        }

        public bool ValidateSudoku(ISudokuPuzzle puzzle)
        {
            foreach (Cell cell in puzzle.Cells.Where(c => c.Value != 0))
            {
                if (!ValidateCell(puzzle, cell))
                    return false;
            }
            return true;
        }
    }
}