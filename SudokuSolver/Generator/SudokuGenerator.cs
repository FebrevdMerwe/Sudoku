using System;
using System.Collections.Generic;

namespace Sudoku.Generator
{
    public class SudokuGenerator
    {
        Dictionary<int, List<int>> m_AvailableNumbers = new Dictionary<int, List<int>>();

        public string Generate(Configuration config, int? seed)
        {
            if (seed == null)
                seed = new Random().Next();

            string sudoku = "";
            foreach (int num in Generate((int)seed))
                sudoku += num;

            return AdjustSolutionToConfig(sudoku, config, (int)seed);
        }

        private string AdjustSolutionToConfig(string sudoku, Configuration config, int seed)
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

            char[] chars = sudoku.ToCharArray();

            foreach (int i in locations)
            {
                chars[i] = '0';
            }

            return new Sudoku()
            {
                Puzzle = new string(chars),
                Seed = seed
            };
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

        private int[,] Generate(int seed)
        {
            int[,] sudoku = new int[9, 9];

            m_AvailableNumbers.Clear();

            int x = 0;
            int y = 0;

            while (y < 9)
            {
                while (x < 9)
                {
                    if (!TryGetNextNumber(x + 1, y + 1, seed, out int val))
                    {
                        sudoku[y, x] = 0;
                        if (x >= 1)
                        {
                            x--;
                        }
                        else
                        {
                            y--;
                            x = 8;
                        }
                        continue;
                    }

                    sudoku[y, x] = val;

                    if (!Validate(sudoku))
                        x--;

                    x++;
                }
                x = 0;
                y++;
            }

            return sudoku;
        }

        public bool Validate(int[,] sudoku)
        {
            if (!ValidateRows(sudoku))
                return false;

            if (!ValidateColumns(sudoku))
                return false;

            if (!ValidateBlocks(sudoku))
                return false;

            return true;
        }

        public bool ValidateRows(int[,] sudoku)
        {
            List<int> row = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int val = sudoku[i, j];

                    if (val == 0)
                        continue;

                    if (row.Contains(val))
                        return false;

                    row.Add(val);
                }
                row = new List<int>();
            }

            return true;
        }

        public bool ValidateColumns(int[,] sudoku)
        {
            List<int> col = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int val = sudoku[j, i];

                    if (val == 0)
                        continue;

                    if (col.Contains(val))
                        return false;

                    col.Add(val);
                }
                col = new List<int>();
            }

            return true;
        }

        public bool ValidateBlocks(int[,] sudoku)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int x = j / 3;
                    int y = i / 3;
                    int key = x + 3 * y;
                    int val = sudoku[i, j];

                    if (val == 0)
                        continue;

                    if (!map.ContainsKey(key))
                        map.Add(key, new List<int>());

                    List<int> current = map[key];

                    if (current.Contains(val))
                        return false;

                    current.Add(val);
                    map[key] = current;
                }
            }

            return true;
        }

        private bool TryGetNextNumber(int x, int y, int seed, out int num)
        {
            List<int> available = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int key = x * y;

            num = 0;

            if (m_AvailableNumbers.ContainsKey(key))
                available = m_AvailableNumbers[key];

            if (available.Count == 0)
            {
                m_AvailableNumbers.Remove(key);
                return false;
            }

            var random = new Random(seed);
            int index = random.Next(available.Count);
            num = available[index];

            available.Remove(num);
            m_AvailableNumbers[key] = available;

            return true;
        }
    }
}
