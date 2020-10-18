using Sudoku.Cells;
using Sudoku.Exceptions;
using Sudoku.Puzzle;
using Sudoku.Validator;
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


        //TODO: Solve from front and back to see if multiple solutions exist (throw exception)
        public ISudokuPuzzle Solve()
        {
            if (!m_Validator.ValidateSudoku(m_Puzzle))
                throw new InvalidPuzzleException();

            int i = 0;
            Cell[] userCells = m_Puzzle.Cells.Where(c => c is UserCell).ToArray();

            while (i < userCells.Length)
            {
                if (i < 0)
                    throw new UnsolvablePuzzleException();

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