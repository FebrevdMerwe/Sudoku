using Sudoku.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Puzzle
{
    public interface ISudokuPuzzle
    {
        List<Cell> Cells { get; }

        List<Cell> GetRow(int rowId);

        List<Cell> GetColumn(int columnId);

        List<Cell> GetBlock(int blockId);
    }
}
