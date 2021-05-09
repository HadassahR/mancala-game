using System;

namespace Mancala2
{
    class NewBoard
    {
        private int[] board = new int[14];
        public static readonly int COMPUTER_MANCALA = 0;
        public static readonly int HUMAN_MANCALA = 7;

        public NewBoard()
        {
            for (int ix = 0; ix < board.Length; ix++)
            {
                board[ix] = 4;
            }
            board[COMPUTER_MANCALA] = 0;
            board[HUMAN_MANCALA] = 0;
        }

        public void ShowBoard()
        {
            Console.Write("     ");
            for (int ix = board.Length - 1; ix > HUMAN_MANCALA; ix--)
            {
                Console.Write("| " + board[ix] + " |");
            }
            Console.Write("     ");
            Console.WriteLine();
            Console.Write("( " + board[COMPUTER_MANCALA] + " )");
            Console.Write("                              ");
            Console.Write("( " + board[HUMAN_MANCALA] + " )");
            Console.WriteLine();
            Console.Write("     ");
            for (int ix = COMPUTER_MANCALA + 1; ix < HUMAN_MANCALA; ix++)
            {
                Console.Write("| " + board[ix] + " |");
            }
            Console.Write("     ");

            Console.WriteLine();

        }

        public int MoveMarbles(int player, int marbles, int startingIndex)
        {
            int landingCup = 0;
            for (int ix = startingIndex; ix < board.Length; ix++)
            {
                //skip opponent mancala, based on player id passed to method
                if (player == 0 && ix == HUMAN_MANCALA)
                {
                    ix++;
                }
                if (player == 1 && ix == COMPUTER_MANCALA)
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
            if(marbles > 0)
            {
                MoveMarbles(player, marbles, 0);
            }
            return landingCup;
        }


        public void MarbleSwap(int player, int landingCup)
        {
            //marble swap code
            int marbles;
            int opponentCup = 0;
            int playerMancala = player == 0 ? COMPUTER_MANCALA : HUMAN_MANCALA;

            if (player == 0)
            {
                opponentCup = 6;
                for (int ix = 8; ix < board.Length; ix++)
                {
                    if (ix == landingCup)
                    {
                        break;
                    }
                    else
                    {
                        opponentCup--;
                    }
                }
            }

            if (player == 1)
            {
                opponentCup = 13;
                for (int ix = 1; ix < HUMAN_MANCALA; ix++)
                {
                    if (ix == landingCup)
                    {
                        break;
                    }
                    else
                    {
                        opponentCup--;
                    }
                }
            }

            marbles = board[opponentCup] + board[landingCup];
            board[landingCup] = 0;
            board[opponentCup] = 0;
            board[playerMancala] += marbles;


        }

        /*
         * Enter number cup - computer 1-6, player - 8-13
         */
        public void MakeMove(int player, int cup)
        {

            int marbles = board[cup];
            board[cup] = 0;
            int landingCup = 0;
            int playerMancala = player == 0 ? COMPUTER_MANCALA : HUMAN_MANCALA;

            landingCup = MoveMarbles(player, marbles, cup + 1);
            
            if (board[landingCup] == 1 && landingCup != playerMancala)
            {
                MarbleSwap(player, landingCup);
            }


        }

        public Boolean isValidMove()
        {
            // Checks if player can select that mancala, also checks that cup isn't empty 
        }

        public Boolean gameOver()
        {
            // Checks if all of one one players cups are empty
        }

        public void onGameOver()
        {
            // Moves all marbles from opponents cups to winners mancala
        }

        public int calculateWinner()
        {
            //  returns winning player based on which player has higher value in mancala
        }

        

    }
}

