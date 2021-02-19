using System;


namespace TicTacToe
{
    /// <summary>
    /// Simple console Tic-Tac-Toe game implemented in C#. This is my first C# project.
    /// @author s.
    /// @date 19.2.2021
    /// </summary>
    static class Program
    {
        private static int _row, _column;
        
        static void Main()
        {
            GameStart();
         
        }
        
        private static void GameStart()
        {
            Utilities.InitializeMatrix();
            while (true)
            {
                GetInput();
                Utilities.SetSymbol(_row, _column);
                //Utilities.PrintBoard();
                Utilities.PrintGameTable();

                if (Utilities.CheckWin(Utilities.Player1Symbol) || Utilities.CheckWin(Utilities.Player2Symbol) || Utilities.CheckForDraw())
                {
                    if (!PlayAgain())
                    {
                        break;
                    }
                    Utilities.InitializeMatrix();
                }
            }
        }

        private static void GetInput()
        {
            do
            {
                try
                {
                    Console.Write("Please enter row and column number separated by space: ");
                    
                    // weird ?before the dot is null-conditional operator, it checks if .Split returns null.
                    // basically equal to: tempArray = Console.ReadLine()?.Split(" ") == null ? null : Console.ReadLine()?.Split(" ");
                    // imho odd
                    var tempArray = Console.ReadLine()?.Split(" ");
                    if (tempArray != null)
                    {
                        _row = Convert.ToInt32(tempArray[0]);
                        _column = Convert.ToInt32(tempArray[1]);
                    }
                    else
                    {
                        _row    = -1;
                        _column = -1;
                    }

                    if (_row > 3 || _row < 1 || _column > 3 || _column < 1)
                    {
                        Console.WriteLine("Number must be between 1 and 3.");
                    }
                }
                catch (Exception )
                {
                    Console.WriteLine("Something went wrong. Please check your input!");
                    _row    = -1;
                    _column = -1;
                    //throw;
                }
            } while (_row > 3 || _row < 1 || _column > 3 || _column < 1);

            _row--;
            _column--;
            
            Console.WriteLine();
        }

        private static bool PlayAgain()
        {
            do
            {
                try
                {
                    Console.WriteLine("Do you want to play again? Y/n ");
                    return Console.ReadLine().Equals("Y") || Console.ReadLine().Equals("y");
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong. Please check your input!");
                }
            } while (true);
        }
    }
}