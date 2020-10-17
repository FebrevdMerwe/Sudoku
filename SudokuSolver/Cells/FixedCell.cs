using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Cells
{
  public class FixedCell : Cell
  {
    public FixedCell(int id, int value)
      : base(id, value)
    {
    }
  }
}
