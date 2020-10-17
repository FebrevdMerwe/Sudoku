using SudokuSolver.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
  public class Sudoku
  {
    public Dictionary<int, Cell> Cells { get; }

    public Sudoku(Dictionary<int, Cell> cells)
    {
      Cells = cells;
    }

    public Sudoku(string input)
    {
      Cells = new Dictionary<int, Cell>();
      ParseSudoku(input);
    }

    private void ParseSudoku(string input)
    {
      char[] values = input.ToCharArray();

      for (int i = 0; i < values.Length; i++)
      {
        int num = int.Parse(values[i].ToString());

        Cell cell;
        if (num == 0)
          cell = new UserCell(i);
        else
          cell = new FixedCell(i, num);

        Cells.Add(i, cell);
      }
    }
  }
}
