using Sudoku.Puzzle;

namespace Sudoku.Solver
{
    public interface ISudokuSolver
    {
        ISudokuPuzzle Solve();
    }
}