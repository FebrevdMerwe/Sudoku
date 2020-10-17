using NUnit.Framework;
using Sudoku.Generator;
using Sudoku.Puzzle;
using Sudoku.Validator;

namespace SudokuUnitTests
{
    public class SudokuGeneratorTests
    {
        private ISudokuGenerator m_Generator;
        private ISudokuValidator m_Validator;

        [SetUp]
        public void Setup()
        {
            m_Generator = new SudokuGenerator();
            m_Validator = new SudokuValidator();
        }

        [Test]
        public void Easy()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.easy);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void EasyWithSeed()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.easy, 0);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void Hard()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.hard);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void HardWithSeed()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.hard, 2);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void Medium()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.medium);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void MediumWithSeed()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.medium, 1);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void Solved()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.solved);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }

        [Test]
        public void SolvedWithSeed()
        {
            ISudokuPuzzle puzzle = m_Generator.Generate(Configuration.solved, 3);

            bool valid = m_Validator.ValidateSudoku(puzzle);

            Assert.IsTrue(valid);
        }
    }
}