using System;


namespace Mancala2
{
    class OldBoard
    {
        public static readonly int NR_ROWS = 2;
        public static readonly int NR_COLS = 7; // includes a mancala for each player
        public static readonly int FIRST_ROW = 0;
        public static readonly int FIRST_COL = 0;
        public static readonly int LAST_ROW = NR_ROWS - 1;
        public static readonly int LAST_COL = NR_COLS - 1;

        private int[,] board = new int[NR_ROWS, NR_COLS];

        public OldBoard()
        {
            for (int row = 0; row < NR_ROWS; row++)
            {
                for (int col = 0; col < NR_COLS; col++)
                {
                    if ((row == FIRST_ROW && col == FIRST_COL) || (row == LAST_ROW && col == LAST_COL))
                    {
                        board[row, col] = 0;
                    }
                    else
                    {
                        board[row, col] = 4;
                    }
                }
            }
        }

        //public Board(int[,] otherBoard)
        //{
        //    for (int row = 0; row < NR_ROWS; row++)
        //    {
        //        for (int col = 0; col < NR_COLS; col++)
        //        {
        //            board[row, col] = otherBoard[row, col];
        //        }
        //    }
        //}


        public void ShowBoard()
        {
            for (int row = 0; row < NR_ROWS; row++)
            {
                for (int col = 0; col < NR_COLS; col++)
                {
                    if ((row == FIRST_ROW && col == FIRST_COL) || (row == LAST_ROW && col == LAST_COL))
                    {
                        Console.Write("( " + board[row, col] + " )");
                    }
                    else
                    {
                        Console.Write("| " + board[row, col] + " |");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int[,] MakeMove(int player, int cup)
        {
            int marbles = board[player, cup];
            board[player, cup] = 0;

            return board;


























            //int[] computerCups = { 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5 };
            //int[] playerCups = { 0, 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1 };


            //int startRow = player;
            //int startCup = player == 0 ? cup - 1 : cup + 1;
            //int endCup = player == 0 ? 0 : LAST_COL;
            //int incOrDecrement = player == 0 ? -1 : 1;


            //// Stone distribution

            //while (stones > 0)
            //{
            //    board[startRow, startCup]++;
            //    stones--; 
            //}

            //return newBoard;
        }

        /* If stone distribution landed on player cup, opponents stones
         * are transferred from corresponding cup
         */
        //public Board StoneSwap(int player, int cup)
        //{
        //    //Board newBoard = new Board(board);
        //    int playerToTakeFrom = player == 0 ? 1 : 0;
        //    int cupToTakeFrom = player == 0 ? cup - 1 : cup + 1;
        //    int stonesTaken = board[playerToTakeFrom, cupToTakeFrom];
        //    board[playerToTakeFrom, cupToTakeFrom] = 0;
        //    board[player, cup] += stonesTaken;

        //    return newBoard; 
        //}

        public Boolean isValidMove(int player, int cup)
        {

            bool validRange = (player == 0 && cup > 0 && cup < 7) ? true : false ||
                (player == 1 && cup > -1 && cup < 6) ? true : false;

            bool containsStones = board[player, cup] > 0;

            return validRange && containsStones;
        }
        public int whoWins()
        {
            if (board[FIRST_ROW, FIRST_COL] > board[LAST_ROW, LAST_COL])
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public Boolean gameOver()
        {
            // implement
            return false;

        }
    }
}




