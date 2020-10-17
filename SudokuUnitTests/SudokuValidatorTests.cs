using NUnit.Framework;
using Sudoku.Cells;
using Sudoku.Puzzle;
using Sudoku.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuUnitTests
{
    public class SudokuValidatorTests
    {
        private ISudokuValidator m_Validator;

        [SetUp]
        public void Setup()
        {
            m_Validator = new SudokuValidator();
        }

        [Test]
        public void ValidSolved()
        {
            string puzzleString = "876549321543182769291763854385471692964328175127695438752816943419237586638954217";

            SudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            bool res = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(res);
        }

        [Test]
        public void InValidSolved()
        {
            string puzzleString = "876549321543182769291763854385471692964329175127695438752816943419237586638954217";

            SudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            bool res = m_Validator.ValidateSudoku(puzzle);

            Assert.IsFalse(res);
        }

        [Test]
        public void ValidUnsolved()
        {
            string puzzleString = "000006000510900340000000250700000008000002900003460102008004017096870004472050000";

            SudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            bool res = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(res);
        }

        [Test]
        public void InValidUnsolved()
        {
            string puzzleString = "000006000510900340000000250700000008000002900003460102008004017096870004475050000";

            SudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            bool res = m_Validator.ValidateSudoku(puzzle);

            Assert.IsFalse(res);
        }

        [Test]
        public void ValidCell()
        {
            string puzzleString = "540070009000901000009460000050040020200000040910600785030590200000180006605200000";

            SudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            Cell cell = new UserCell(2)
            {
                Value = 6
            };

            bool res = m_Validator.ValidateCell(puzzle, cell);

            Assert.IsTrue(res);
        }


        [Test]
        public void InvalidCell()
        {
            string puzzleString = "540070009000901000009460000050040020200000040910600785030590200000180006605200000";

            SudokuPuzzle puzzle = new SudokuPuzzle(puzzleString);

            Cell cell = new UserCell(2)
            {
                Value = 5
            };

            bool res = m_Validator.ValidateCell(puzzle, cell);

            Assert.IsFalse(res);
        }
    }
}
