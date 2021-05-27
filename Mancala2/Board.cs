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

        public Board(int[] other)
        {
            for (int cup = 0; cup < NR_CUPS; cup++)
            {
                board[cup] = other[cup];
            }
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
            for (int ix = 0; ix < board.Length; ix++)
            {
                Console.WriteLine(ix + ": " + board[ix]);
            }

            Console.WriteLine("** After Player mancala: " + board[7]);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");


        }

        public Boolean IsValidMove(int cup)
        {
            return board[cup] > 0;
        }

        public Board MakeMove(Player player, int cup)
        {
            Board newBoard = new Board(board);
            Console.WriteLine(player == Player.MAX ? "Computer chose cup " + cup : "Human chose cup " + cup);
            int marbles = board[cup];
            board[cup] = 0;
            int playerMancala = player == Player.MAX ? COMPUTER_MANCALA : HUMAN_MANCALA;

            int landingCup = MoveMarbles(player, marbles, cup + 1);

            if (board[landingCup] == 1 && landingCup != playerMancala)
            {
                Console.WriteLine("Marble Swap!");
                MarbleSwap(player, landingCup);
            }
            return newBoard;
        }

        private int MoveMarbles(Player player, int marbles, int startingCup)
        {
            int landingCup = 0;
            for (int ix = startingCup; ix < NR_CUPS; ix++)
            {
                //skip opponent mancala
                if (player == Player.MAX && ix == HUMAN_MANCALA)
                {
                    ix++;
                } else if (player == Player.MIN && ix == COMPUTER_MANCALA)
                {
                    ix++;
                } else if (marbles > 0)
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

        private void MarbleSwap(Player player, int landingCup)
        {
            int[] computer = { 13, 12, 11, 10, 9, 8 };
            int[] human = { 1, 2, 3, 4, 5, 6 };
            int[] playerCups = player == Player.MAX ? computer : human;
            int[] opponentCups = player == Player.MAX ? human : computer;
            int playerMancala = player == Player.MAX ? COMPUTER_MANCALA : HUMAN_MANCALA;

            int playerCup = 0;

            for (int ix = 0; ix < opponentCups.Length; ix++)
            {
                if (opponentCups[ix] == landingCup)
                {
                    playerCup = ix + 1;
                    break;
                }
            }
            Console.WriteLine("landing cup: " + board[landingCup]);
            Console.WriteLine("player cup: " + board[playerCup]);
            Console.WriteLine("playerMancala: " + board[playerMancala]);
            board[playerMancala] += board[landingCup] + board[playerCup];
            board[landingCup] = 0;
            board[playerCup] = 0;
        }

        public Boolean IsGameOver()
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
            // determine who was last player
            return !computerStillHas || !humanStillHas;
        }

        public void OnGameOver(Player lastPlayer)
        {
            int startIndex = lastPlayer == Player.MAX ? HUMAN_MANCALA : COMPUTER_MANCALA;
            int endIndex = lastPlayer == Player.MAX ? board.Length : HUMAN_MANCALA;
            int playerMancala = lastPlayer == Player.MAX ? COMPUTER_MANCALA : HUMAN_MANCALA;
            int marbles = 0;

            for (int ix = startIndex; ix < endIndex; ix++)
            {
                marbles += board[ix];
            }
            board[playerMancala] += marbles;
        }

        public Player GetWinner()
        {
            return board[COMPUTER_MANCALA] > board[HUMAN_MANCALA] ? Player.MAX : Player.MIN;
        }

        #region heuristic

        /*----------------------------------------------------------------------
         * assign a value between -1 (min is winning) and 1 (MAX is winning)
         * to the given board positin
         ---------------------------------------------------------------------*/
        public double heuristicValue(Player player)
        {
            double retVal = 0.0;
            if (this.IsGameOver())
            {
                this.OnGameOver(player);
                retVal = this.GetWinner() == Player.MAX ? 1.0 : -1.0; 
            } else
            {
                return board[COMPUTER_MANCALA] - board[HUMAN_MANCALA] / NR_CUPS;
            }
            return retVal; 
        }

        #endregion
    }
}

