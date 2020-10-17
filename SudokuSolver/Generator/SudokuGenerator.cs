using Sudoku.Cells;
using Sudoku.Puzzle;
using Sudoku.Validator;
using System;
using System.Collections.Generic;

namespace Sudoku.Generator
{
    public class SudokuGenerator
    {
        private Dictionary<int, List<int>> m_AvailableNumbers = new Dictionary<int, List<int>>();
        private ISudokuValidator m_Validator = new SudokuValidator();

        private void AdjustPuzzleToConfig(ISudokuPuzzle sudoku, Configuration config, int seed)
        {
            int vals = GetDifficulty(config);

            List<int> locations = new List<int>();
            Random rand = new Random(seed);

            for (int i = 0; i < vals; i++)
            {
                int location;
                do
                {
                    location = rand.Next(81);
                } while (locations.Contains(location));
                locations.Add(location);
            }

            foreach (int i in locations)
            {
                sudoku.Cells[i] = new UserCell(i);
            }
        }

        private int GetDifficulty(Configuration config)
        {
            switch (config)
            {
                case Configuration.easy:
                    return 81 - 35;

                case Configuration.medium:
                    return 81 - 30;

                case Configuration.hard:
                    return 81 - 25;

                case Configuration.solved:
                    return 0;

                default:
                    throw new NotImplementedException($"{config.ToString()} is not implemented");
            }
        }

        public ISudokuPuzzle Generate(Configuration config, int? seed = null)
        {
            if (seed == null)
                seed = new Random().Next();

            SudokuPuzzle puzzle = new SudokuPuzzle();

            m_AvailableNumbers.Clear();

            int i = 0;

            while (i < 81)
            {
                if (!TryGetNextNumber(i, (int)seed, out int val))
                {
                    puzzle.Cells[i].Value = 0;
                    i--;
                    continue;
                }

                puzzle.Cells[i].Value = val;

                if (m_Validator.ValidateSudoku(puzzle))
                    i++;
            }

            AdjustPuzzleToConfig(puzzle, config, (int)seed);
            return puzzle;
        }

        private bool TryGetNextNumber(int id, int seed, out int num)
        {
            List<int> available = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            num = 0;

            if (m_AvailableNumbers.ContainsKey(id))
                available = m_AvailableNumbers[id];

            if (available.Count == 0)
            {
                m_AvailableNumbers.Remove(id);
                return false;
            }

            var random = new Random(seed);
            int index = random.Next(available.Count);
            num = available[index];

            available.Remove(num);
            m_AvailableNumbers[id] = available;

            return true;
        }
    }
}