using Sudoku.Cells;
using System.Collections.Generic;

namespace Sudoku.Puzzle
{
    public interface ISudokuPuzzle
    {
        int Id { get; }

        List<Cell> Cells { get; }

        List<Cell> GetRow(int rowId);

        List<Cell> GetColumn(int columnId);

        List<Cell> GetBlock(int blockId);
    }
}