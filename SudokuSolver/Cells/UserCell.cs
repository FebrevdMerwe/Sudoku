using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Cells
{
  public class UserCell : Cell
  {
    public UserCell(int id)
      : base(id)
    {
    }

    public void SetValue(int value)
    {
      Value = value;
    }
  }
}
