using System;

namespace Mancala2
{
    class Board
    {
        private int[] board = new int[14];
        public static readonly int COMPUTER_MANCALA = 0;
        public static readonly int HUMAN_MANCALA = 7;
        public static readonly int NR_CUPS = 14;

        public Board()
        {
            for (int ix = 0; ix < NR_CUPS; ix++)
            {
                board[ix] = 4;
            }
            board[COMPUTER_MANCALA] = 0;
            board[HUMAN_MANCALA] = 0;
        }

        public void ShowBoard()
        {
            const String FIVE_SPACE = "     ";

            Console.Write(FIVE_SPACE);
            for (int ix = NR_CUPS - 1; ix > HUMAN_MANCALA; ix--)
            {
                Console.Write("| " + board[ix] + " |");
            }

            Console.Write(FIVE_SPACE);
            Console.WriteLine();
            Console.Write("( " + board[COMPUTER_MANCALA] + " )");
            Console.Write("                              ");
            Console.Write("( " + board[HUMAN_MANCALA] + " )");
            Console.WriteLine();
            Console.Write(FIVE_SPACE);

            for (int ix = COMPUTER_MANCALA + 1; ix < HUMAN_MANCALA; ix++)
            {
                Console.Write("| " + board[ix] + " |");
            }
            Console.Write(FIVE_SPACE);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");

        }

        public void MakeMove(Player player, int cup)
        {

            Console.WriteLine(player == Player.MAX ? "Computer chose cup " + cup : "Human chose cup " + cup);
            int marbles = board[cup];
            board[cup] = 0;
            int playerMancala = player == Player.MAX ? COMPUTER_MANCALA : HUMAN_MANCALA;

            int landingCup = MoveMarbles(player, marbles, cup + 1);

            if (board[landingCup] == 1 && landingCup != playerMancala)
            {
                MarbleSwap(player, landingCup);
            }

        }

        public int MoveMarbles(Player player, int marbles, int startingCup)
        {
            int landingCup = 0;
            for (int ix = startingCup; ix < NR_CUPS; ix++)
            {
                //skip opponent mancala, based on player id passed to method
                if (player == Player.MAX && ix == HUMAN_MANCALA)
                {
                    ix++;
                }
                if (player == Player.MIN && ix == COMPUTER_MANCALA)
                {
                    ix++;
                }

                if (marbles > 0)
                {
                    board[ix]++;
                    marbles--;
                    landingCup = ix;
                }
            }
            if (marbles > 0)
            {
                MoveMarbles(player, marbles, 0);
            }
            return landingCup;
        }


        public void MarbleSwap(Player player, int landingCup)
        {
            int[] computer = { 13, 12, 11, 10, 9, 8 };
            int[] human = { 1, 2, 3, 4, 5, 6 };
            int[] playerCups = player == Player.MAX ? computer : human;
            int[] opponentCups = player == Player.MAX ? human : computer;
            int playerMancala = player == Player.MAX ? COMPUTER_MANCALA : HUMAN_MANCALA;


            int opponentCup = 0;

            foreach (int ix in playerCups)
            {
                if (playerCups[ix] == landingCup)
                {
                    opponentCup = ix;
                    break;
                }
            }

            board[playerMancala] += board[landingCup] + board[opponentCup];
            board[landingCup] = 0;
            board[opponentCup] = 0;
        }


        //public Boolean checkIfCurrentPlayersCup(Player player, int cup)
        //{
        //    bool valid = false;
        //    int[] computer = { 13, 12, 11, 10, 9, 8 };
        //    int[] human = { 1, 2, 3, 4, 5, 6 };

        //    if (player == Player.MAX)
        //    {
        //        foreach (int n in computer)
        //        {
        //            if (n == cup)
        //            {
        //                valid = true;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (int n in human)
        //        {
        //            if (n == cup)
        //            {
        //                valid = true;
        //                break;
        //            }
        //        }
        //    }
        //    return valid;
        //}

        public Boolean isValidMove(int cup)
        {
            return checkIfCurrentPlayersCup(player, cup) && board[cup] > 0;
        }

        public Boolean gameOver()
        {
            bool computerStillHas = false;
            bool humanStillHas = false;
            for (int ix = 0; ix < HUMAN_MANCALA; ix++)
            {
                if (board[ix] > 0)
                {
                    humanStillHas = true;
                    break;
                }
            }
            for (int ix = HUMAN_MANCALA + 1; ix < NR_CUPS; ix++)
            {
                if (board[ix] > 0)
                {
                    computerStillHas = true;
                }
            }

            return !computerStillHas || !humanStillHas;
        }

        public void onGameOver(Player lastPlayer)
        {
            int startIndex = lastPlayer == Player.MAX ? HUMAN_MANCALA : COMPUTER_MANCALA;
            int endIndex = lastPlayer == Player.MAX ? board.Length : HUMAN_MANCALA;
            int playerMancala = lastPlayer == Player.MAX ? COMPUTER_MANCALA : HUMAN_MANCALA;
            int marbles = 0;

            for (int ix = startIndex; ix < endIndex; ix++)
            {
                marbles += board[ix];
                board[ix] = 0;
            }
            board[playerMancala] += marbles;
        }

        public Player calculateWinner()
        {
            return board[COMPUTER_MANCALA] > board[HUMAN_MANCALA] ? Player.MAX : Player.MIN;
        }


        #region heuristic
        /*----------------------------------------------------------------------
         * assign a value between -1 (min is winning) and 1 (MAX is winning)
         * to the given board positin
         ---------------------------------------------------------------------*/
        public double heuristicValue()
        {
            double retVal = 0.0;
            if (isWin(Player.MAX))
            {
                retVal = 1.0;
            }
            else if (isWin(Player.MIN))
            {
                retVal = -1.0;
            }
            else
            {
                retVal = heuristicColumsCount();
            }
            return retVal;
        }

        private double heuristicColumsCount()
        {
            double value = 0.0;
            int midColumn = NR_COLS / 2;
            for (int row = 0; row < NR_ROWS; ++row)
            {
                for (int col = 1; col <= midColumn; ++col)
                {
                    if (board[row, col] == Cell.RED)
                    {
                        value += col * 0.05;
                    }
                    else if (board[row, col] == Cell.BLACK)
                    {
                        value -= col * 0.05;
                    }
                }

                for (int col = NR_COLS - 2; col > midColumn; --col)
                {
                    if (board[row, col] == Cell.RED)
                    {
                        value += (NR_COLS - col) * 0.05;
                    }
                    else if (board[row, col] == Cell.BLACK)
                    {
                        value -= (NR_COLS - col) * 0.05;
                    }
                }
            }
            return value;
        }
        #endregion


    }
}

