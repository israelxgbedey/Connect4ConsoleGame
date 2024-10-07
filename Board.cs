using System;

namespace Connect4ConsoleGame
{
    class Board
    {
        private int[,] grid = new int[6, 7]; // 6 rows, 7 columns

        public Board()
        {
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    grid[row, col] = 0; // 0 means empty
                }
            }
        }

        public void PrintGrid()
        {
            Console.Clear();
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("0 1 2 3 4 5 6"); // Column numbers for reference
        }

        public int DropPiece(int col, int player)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (grid[row, col] == 0)
                {
                    grid[row, col] = player;
                    return row;
                }
            }
            return -1; // Column is full (shouldn't happen due to input validation)
        }

        public bool IsColumnAvailable(int col)
        {
            return grid[0, col] == 0;
        }

        public bool IsGridFull()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (grid[row, col] == 0)
                        return false;
                }
            }
            return true;
        }

        public int[,] GetGrid()
        {
            return grid;
        }
    }
}
