using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Cells
{
  public class FixedCell : Cell
  {
    public FixedCell(int id, int value)
      : base(id, value)
    {
    }
  }
}
