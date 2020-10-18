using Sudoku.Cells;
using Sudoku.Puzzle;

namespace Sudoku.Validator
{
    public interface ISudokuValidator
    {
        bool ValidateSudoku(ISudokuPuzzle puzzle);

        bool ValidateCell(ISudokuPuzzle puzzle, Cell cell);
    }
}