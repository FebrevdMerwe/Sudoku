using NUnit.Framework;
using Sudoku.Puzzle;
using Sudoku.Solver;
using Sudoku.Validator;
using Sudoku.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuUnitTests
{
    public class SudokuSolverTests
    {
        ISudokuValidator m_Validator;

        [SetUp]
        public void Setup()
        {
            m_Validator = new SudokuValidator();
        }

        [Test]
        public void SolveValidString()
        {
            string puzzle = "540072009000901000009460007050040020200000040910600785430590200000180056605200100";
            ISudokuSolver solver = new SudokuSolver(puzzle, m_Validator);

            string actual = solver.Solve().ToString();

            string expected = "546372819378951462129468537853749621267815943914623785431596278792184356685237194";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SolveValidPuzzle()
        {
            string puzzleString = "540072009000901000009460007050040020200000040910600785430590200000180056605200100";

            ISudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            ISudokuSolver solver = new SudokuSolver(puzzle, m_Validator);

            string actual = solver.Solve().ToString();

            string expected = "546372819378951462129468537853749621267815943914623785431596278792184356685237194";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SolveInValidString()
        {
            string puzzle = "540072009000901000009460007050040020200000040910600785430590200000188056605200100";
            ISudokuSolver solver = new SudokuSolver(puzzle, m_Validator);

            Assert.Catch<InvalidPuzzleException>(() => solver.Solve());
        }

        [Test]
        public void SolveCompleteString()
        {
            string puzzle = "546372819378951462129468537853749621267815943914623785431596278792184356685237194";
            ISudokuSolver solver = new SudokuSolver(puzzle, m_Validator);

            string actual = solver.Solve().ToString();

            string expected = "546372819378951462129468537853749621267815943914623785431596278792184356685237194";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnSolvableString()
        {
            string puzzle = "120456789003000000000000000000000000000000000000000000000000000000000000000000000";
            ISudokuSolver solver = new SudokuSolver(puzzle, m_Validator);

            Assert.Catch<UnsolvablePuzzleException>(() => solver.Solve());
        }
    }
}
