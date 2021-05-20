using System;

namespace Mancala2
{
    class Program
    {
        static int MAX_DEPTH = 4;  // default value reset inside ProcessConfiguration
        static bool ALPHA_BETA = true;
        public static readonly double MIN_VALUE = -1.0;
        public static readonly double MAX_VALUE = 1.0;

        static void Main(string[] args)
        {
            Board gameBoard = new Board();
            bool gameOver = false;
            gameBoard.ShowBoard();
            while (!gameOver)
            {
                Console.Write("Your move: ");
                int theirMove = UserInput.getInteger("Enter a number between 1-6 ", 1, 6);
                if (gameBoard.IsValidMove(theirMove))
                {
                    gameBoard.MakeMove(Player.MIN, theirMove);
                    gameBoard.ShowBoard();

                }

                Console.Write("Computer move ");
                int compMove = UserInput.getInteger("Enter a number between 8-13 ", 8, 13);
                if (gameBoard.IsValidMove(compMove))
                {
                    gameBoard.MakeMove(Player.MAX, compMove);
                    gameBoard.ShowBoard();

                }
            }
        }


        //    static void Main(string[] args)
        //    {
        //        Board gameBoard = new Board();
        //        bool gameOver = false;

        //        while (!gameOver)
        //        {
        //            Console.WriteLine("I am thinking about my move now");
        //            double highVal = -1.0;
        //            int bestMove = 0;
        //            double alfa = -1.0;
        //            double beta = 1.0;
        //            for (int cup = Board.HUMAN_MANCALA + 1; cup < Board.NR_CUPS; ++cup)
        //            {
        //                if (gameBoard.isValidMove(cup))
        //                {
        //                    Board nextPos = gameBoard.MakeMove(Player.MAX, cup);

        //                    double thisVal = AlphaBeta.Value(nextPos, MAX_DEPTH - 1, alfa, beta, Player.MIN);

        //                    if (thisVal > highVal)
        //                    {
        //                        bestMove = cup;
        //                        highVal = thisVal;
        //                    }
        //                }
        //            }

        //            Console.WriteLine($"My move is {(bestMove + 1)}    (subj. value {highVal})");
        //            gameBoard = gameBoard.MakeMove(Player.MAX, bestMove);
        //            gameBoard.ShowBoard();

        //            if (gameBoard.getWinner() == Player.MAX)
        //            {
        //                Console.WriteLine("\n I win");
        //                gameOver = true;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Your move");
        //            int theirMove = UserInput.getInteger("Select a cup between 1 and 6", 1, 6);
        //            if (gameBoard.isValidMove(theirMove))
        //            {
        //                gameBoard = gameBoard.MakeMove(Player.MIN, theirMove);
        //                Console.WriteLine("");
        //                gameBoard.ShowBoard();
        //            }
        //            if (gameBoard.getWinner() == Player.MIN)
        //            {
        //                Console.WriteLine("\n You win :-(");
        //                gameOver = true;
        //            }
        //        }
        //    }
        //Console.ReadKey();
        //        }
        //    }
    }
}
