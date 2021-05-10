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
            const String FIVE_SPACE = "     "; 

            Console.Write(FIVE_SPACE);
            for (int ix = board.Length - 1; ix > HUMAN_MANCALA; ix--)
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

        public void MakeMove(int player, int cup)
        {

                Console.WriteLine(player == 0 ? "Computer chose cup " + cup : "Human chose cup " + cup);
                int marbles = board[cup];
                board[cup] = 0;
                int playerMancala = player == 0 ? COMPUTER_MANCALA : HUMAN_MANCALA;

                int landingCup = MoveMarbles(player, marbles, cup + 1);

                if (board[landingCup] == 1 && landingCup != playerMancala && checkIfCurrentPlayersCup(player, cup))
                {
                    MarbleSwap(player, landingCup);
                }

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
            if (marbles > 0)
            {
                MoveMarbles(player, marbles, 0);
            }
            return landingCup;
        }


        public void MarbleSwap(int player, int landingCup)
        {
            int[] computer = { 1, 2, 3, 4, 5, 6 };
            int[] human = { 8, 9, 10, 11, 12, 13 };
            int[] playerCups = player == 0 ? computer : human;
            int[] opponentCups = player == 0 ? human : computer;
            int playerMancala = player == 0 ? COMPUTER_MANCALA : HUMAN_MANCALA;


            int opponentCup = 0; 

            foreach (int ix in playerCups)
            {
                if (playerCups [ix] == landingCup)
                {
                    opponentCup = ix;
                    break;
                }
            }

            board[playerMancala] = board[landingCup] + board[opponentCup];
            board[landingCup] = 0;
            board[opponentCup] = 0; 










            //int marbles;
            //int opponentCup = 0;
            //int playerMancala = player == 0 ? COMPUTER_MANCALA : HUMAN_MANCALA;

            //if (player == 0)
            //{
            //    opponentCup = 6;
            //    for (int ix = 8; ix < board.Length; ix++)
            //    {
            //        if (ix == landingCup)
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            opponentCup--;
            //        }
            //    }
            //}

            //if (player == 1)
            //{
            //    opponentCup = 13;
            //    for (int ix = 1; ix < HUMAN_MANCALA; ix++)
            //    {
            //        if (ix == landingCup)
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            opponentCup--;
            //        }
            //    }
            //}

            //marbles = board[opponentCup] + board[landingCup];
            //board[landingCup] = 0;
            //board[opponentCup] = 0;
            //board[playerMancala] += marbles;


        }


        public Boolean checkIfCurrentPlayersCup(int player, int cup)
        {
            bool valid = false;
            int[] computer = { 1, 2, 3, 4, 5, 6 };
            int[] human = { 8, 9, 10, 11, 12, 13 };

            if (player == 0)
            {
                foreach (int n in human)
                {
                    if (n == cup)
                    {
                        valid = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (int n in computer)
                {
                    if (n == cup)
                    {
                        valid = true;
                        break;
                    }
                }
            }
            return valid;
        }

        public Boolean isValidMove(int player, int cup)
        {
            return checkIfCurrentPlayersCup(player, cup) && board[cup] > 0; 
        }

        public Boolean gameOver()
        {
            return true;
            // Checks if all of one one players cups are empty
        }

        public void onGameOver()
        {
            // Moves all marbles from opponents cups to winners mancala
        }

        public int calculateWinner()
        {
            return board[COMPUTER_MANCALA] > board[HUMAN_MANCALA] ? 0 : 1; 
        }



    }
}

