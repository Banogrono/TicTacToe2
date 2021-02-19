using System;

namespace TicTacToe
{
    public static class Utilities
    {   
        // Change this string for different separator style. Default: " ".
        private static readonly string Separator = " ";
        
        // Change this string for different first player symbol. Default "X".
        public static readonly string Player1Symbol = "x";
        
        // Change this string for different second player symbol. Default "O".
        public static readonly string Player2Symbol = "o";
        
        // Main game board, registers Xs and Os. Has to be square; e.g. 3x3 / 4x4/ etc.
        private static readonly string[,] GameBoard = new string[3, 3];
        
        // If turn equals true, the round belongs to X, otherwise it's O round.
        private static bool _turn = true;
        
        /// <summary>
        /// Checks if spot on gameboard is occupied.  
        /// </summary>
        /// <param name="x"></param> row number.
        /// <param name="y"></param> column number.
        /// <returns></returns> Returns true, if spot is clear. Returns false if spot is occupied.
        static bool IsSpotClear(int x, int y)
        {
            return GameBoard[x,y].Equals(" ");
        }
        
        /// <summary>
        /// Prints gameBoard.
        /// </summary>
        public static void PrintBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Console.Write(GameBoard[row,column] + Separator);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Puts players symbol onto the gameBoard. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public static void SetSymbol(int row, int column)
        {
            if (IsSpotClear(row,column))
            {
                string symbol;
                if (_turn)
                {
                    symbol = Player1Symbol;
                    _turn = false;
                }
                else
                {
                    symbol = Player2Symbol;
                    _turn = true;
                }
                
                GameBoard[row, column] = symbol;
            }
            else
            {
                Console.WriteLine("This spot is occupied! You have to choose other one.");
            }
        }
        
        /// <summary>
        /// Initializes (also clears) array with " ".
        /// </summary>
        public static void InitializeMatrix()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j] = " ";
                }
            }
        }
        
        // Check if there is winning condition on GameBoard.
        public static bool CheckWin(string symbol)
        {
            if (CheckColumns(symbol) || CheckRows(symbol) || CheckDiagonal(symbol))
            {
                Console.WriteLine(symbol + " won!");
                return true;
            }

            return false;
        }
        
        // Check if there is a diagonal winning condition on GameBoard.
        private static bool CheckDiagonal(string symbol)
        {
            int count = 0;

            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                if (GameBoard[i,i].Equals(symbol))
                {
                    count++;
                }
            }
            
            if (count == GameBoard.GetLength(0))
            {
                return true;
            }

            count = 0;
            
            for (int i = (GameBoard.GetLength(0) - 1), j = 0; i >= 0 && j < GameBoard.GetLength(1); i--, j++)
            {
                if (GameBoard[i,j].Equals(symbol))
                {
                    count++;
                }
            }
            
            if (count == 3)
            {
                return true;
            }
            return false;
        }
        
        // Check if there is a horizontal winning condition on GameBoard.
        private static bool CheckRows(string symbol)
        {
            int count = 0;
            
            for (int i = 0; i < GameBoard.GetLength(1); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i,j].Equals(symbol))
                    {
                        count++;
                    }
                }

                if (count == GameBoard.GetLength(0))
                {
                    return true;
                }
                count = 0;
            }

            return false;
        }
        
        // Check if there is a vertical winning condition on GameBoard.
        private static bool CheckColumns(string symbol)
        {
            int count = 0;
            
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[j,i].Equals(symbol))
                    {
                        count++;
                    }
                }

                if (count == GameBoard.GetLength(0))
                {
                    return true;
                }
                count = 0;
            }

            return false;
        }
        
        // Check for a draw
        public static bool CheckForDraw()
        {
            var xCount = 0;
            var oCount = 0;

            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i,j].Equals(Player1Symbol))
                    {
                        xCount++;
                    }
                    else if (GameBoard[i,j].Equals(Player2Symbol))
                    {
                        oCount++;
                    }
                }
            }

            if (xCount + oCount < GameBoard.Length)
            {
                return false;
            }
            
            Console.WriteLine("Looks like we have a draw!");
            return true;
        }
        
        /// <summary>
        /// Alternative gameBoard printing method, imported from my older Java tic-tac-toe implementation.  
        /// </summary>
        public static void PrintGameTable() {
            Console.WriteLine("---------");
            for (int rows = 0; rows < GameBoard.GetLength(0); rows++) {
                for (int columns = 0; columns < GameBoard.GetLength(1); columns++) {
        
                    if (columns == 0)
                        Console.Write("| ");
        
                    Console.Write(GameBoard[rows, columns] + " ");
        
                    if (columns == 2)
                        Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------");
        }
        
    }
}