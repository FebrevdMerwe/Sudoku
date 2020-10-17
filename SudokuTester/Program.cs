using Sudoku.Solver;
using Sudoku.Validator;
using System;


namespace SudokuTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string easy = "760543001040172000231600004075061030000007060026830007000000300403090070007050200";
            string solved = "768543921549172683231689754975461832384927165126835497652718349413296578897354216";

            SudokuValidator validator = new SudokuValidator();
            SudokuSolver solver = new SudokuSolver(easy, validator);

            string result = solver.Solve();

            if(result == solved)
                Console.WriteLine("Pass");
            else
                Console.WriteLine("Failed");

            Console.ReadLine();
        }
    }
}
