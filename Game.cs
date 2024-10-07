using System;

namespace Connect4ConsoleGame
{
    class Game
    {
        private Board board;
        private Player currentPlayer;

        public Game()
        {
            board = new Board();
            currentPlayer = new Player(1);
        }

        public void Start()
        {
            bool gameWon = false;

            while (!gameWon && !board.IsGridFull())
            {
                board.PrintGrid();
                Console.WriteLine($"Player {currentPlayer.Number}'s turn. Choose a column (0-6):");

                int column;
                while (!int.TryParse(Console.ReadLine(), out column) || column < 0 || column > 6 || !board.IsColumnAvailable(column))
                {
                    Console.WriteLine("Invalid input. Please choose a valid column (0-6) that is not full.");
                }

                // Drop the piece in the column
                int row = board.DropPiece(column, currentPlayer.Number);

                // Check for win
                if (CheckForWin(row, column))
                {
                    board.PrintGrid();
                    Console.WriteLine($"Player {currentPlayer.Number} wins!");
                    gameWon = true;
                }
                else
                {
                    // Switch player
                    currentPlayer.Switch();
                }
            }

            if (!gameWon)
            {
                board.PrintGrid();
                Console.WriteLine("The game is a draw!");
            }
        }

        private bool CheckForWin(int row, int col)
        {
            return CheckDirection(row, col, 1, 0) || // Horizontal
                   CheckDirection(row, col, 0, 1) || // Vertical
                   CheckDirection(row, col, 1, 1) || // Diagonal \
                   CheckDirection(row, col, 1, -1);  // Diagonal /
        }

        private bool CheckDirection(int row, int col, int rowOffset, int colOffset)
        {
            int count = 1;
            count += CountPieces(row, col, rowOffset, colOffset);
            count += CountPieces(row, col, -rowOffset, -colOffset);
            return count >= 4;
        }

        private int CountPieces(int row, int col, int rowOffset, int colOffset)
        {
            int count = 0;
            int player = board.GetGrid()[row, col];

            for (int i = 1; i < 4; i++)
            {
                int newRow = row + i * rowOffset;
                int newCol = col + i * colOffset;

                if (newRow >= 0 && newRow < 6 && newCol >= 0 && newCol < 7 && board.GetGrid()[newRow, newCol] == player)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }
}

