using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala2
{
    class NewBoard
         {
        private int[] board = new int[14];
        public static readonly int COMPUTER_MANCALA = 0;
        public static readonly int PLAYER_MANCALA = 7;

        public NewBoard()
        {
            for (int ix = 0; ix < board.Length; ix++)
            {
                board[ix] = 4;
            }
            board[COMPUTER_MANCALA] = 0;
            board[PLAYER_MANCALA] = 0; 
        }

        public void ShowBoard()
        {
            Console.Write("     ");
            for (int ix = board.Length-1; ix > PLAYER_MANCALA; ix --) {
                Console.Write("| " + board[ix] + " |"); 
            }
            Console.Write("     ");
            Console.WriteLine();
            Console.Write("( " + board[COMPUTER_MANCALA] + " )");
            Console.Write("                              ");
            Console.Write("( " + board[PLAYER_MANCALA] + " )");
            Console.WriteLine();
            Console.Write("     ");
            for (int ix = COMPUTER_MANCALA+1; ix < PLAYER_MANCALA; ix++)
            {
                Console.Write("| " + board[ix] + " |"); 
            }
            Console.Write("     ");

            Console.WriteLine();

        }
        /*
         * Enter number cup - computer 1-6, player - 8-13
         */
        public int[] MakeMove(int player, int cup)
        {
            int marbles = board[cup];
            board[cup] = 0;
            
            for (int ix = cup + 1; ix < board.Length; ix++)
            {
                if(marbles > 0)
                {
                    board[ix]++;
                    marbles--;
                } 
            }
            if (marbles > 0)
            {
                for (int ix = 0; ix < board.Length; ix++)
                {
                    if (marbles > 0)
                    {
                        board[ix]++;
                        marbles--;
                    }
                }
            }

            // Skip opponents mancala
            // If land on own side and is empty, move player and opponents 
            // marbles (from opposite cup) to player's mancala
            return board;
        }


    }
}
