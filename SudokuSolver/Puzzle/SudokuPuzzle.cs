using Sudoku.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Puzzle
{
    public class SudokuPuzzle : ISudokuPuzzle
    {
        public List<Cell> Cells { get; }

        public SudokuPuzzle(List<Cell> cells)
        {
            Cells = cells;
        }

        public SudokuPuzzle(string input)
        {
            Cells = new List<Cell>();
            ParseSudoku(input);
        }

        public SudokuPuzzle()
        {
            Cells = new List<Cell>();
            for (int i = 0; i < 81; i++)
            {
                Cells.Add(new FixedCell(i, 0));
            }
        }


        public List<Cell> GetRow(int rowId)
        {
            return Cells.Where(c => c.Row == rowId).ToList();
        }

        public List<Cell> GetColumn(int columnId)
        {
            return Cells.Where(c => c.Column == columnId).ToList();
        }

        public List<Cell> GetBlock(int blockId)
        {
            return Cells.Where(c => c.Block == blockId).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Cell cell in Cells.OrderBy(c=>c.Id))
            {
                sb.Append(cell.Value);
            }

            return sb.ToString();
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

                Cells.Add(cell);
            }
        }
    }
}
