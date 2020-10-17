using Sudoku.Cells;
using Sudoku.Puzzle;
using Sudoku.Validator;
using System;
using System.Linq;

namespace Sudoku.Solver
{
    public class SudokuSolver : ISudokuSolver
    {
        private ISudokuPuzzle m_Puzzle;
        private ISudokuValidator m_Validator;

        public SudokuSolver(string sudoku, ISudokuValidator validator)
        {
            m_Puzzle = new SudokuPuzzle(sudoku);
            m_Validator = validator;
        }

        public SudokuSolver(ISudokuPuzzle input, ISudokuValidator validator)
        {
            m_Puzzle = input;
            m_Validator = validator;
        }

        public ISudokuPuzzle Solve()
        {
            int i = 0;
            Cell[] userCells = m_Puzzle.Cells.Where(c => c is UserCell).ToArray();

            while (i < userCells.Length)
            {
                UserCell cell = userCells[i] as UserCell;

                int val = cell.Value + 1;

                if (val > 9)
                {
                    cell.Value = 0;
                    i--;
                    continue;
                }

                cell.Value = val;

                if (m_Validator.ValidateCell(m_Puzzle, cell))
                    i++;
            }

            return m_Puzzle;
        }
    }
}
