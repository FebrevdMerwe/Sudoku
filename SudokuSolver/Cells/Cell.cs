using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SudokuSolver.Cells
{
  public abstract class Cell
  {
    public int Id { get; }
    public int Column { get; }
    public int Row { get; }
    public int Block { get; }
    public int Value { get; protected set; }

    protected Cell(int id)
    {
      Id = id;
      Column = id % 9;
      Row = id / 9;
      Block = Column / 3 + (Row / 3) * 3;
    }

    protected Cell(int id, int value)
      : this(id)
    {
      Value = value;
    }
  }
}
