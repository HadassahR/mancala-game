using System;
namespace Mancala2
{
    class Program
    {
        //static int MAX_DEPTH = 4;  // default value reset inside ProcessConfiguration
        //static bool ALPHA_BETA = false;


        static int MAX_DEPTH = 4;  // default value reset inside ProcessConfiguration
        static bool ALPHA_BETA = false;
        public static readonly double MIN_VALUE = -1.0;
        public static readonly double MAX_VALUR = 1.0;

        static void Main(string[] args)
        {
            ProcessConfiguration();
            Board gameBoard = new Board();
            bool gameOver = false;

            while (!gameOver)
            {
                Console.WriteLine("I am thinking about my move now");
                double highVal = -1.0;
                int bestMove = 0;
                double alfa = -1.0;
                double beta = 1.0;
                for (int col = 0; col < Board.NR_COLS; ++col)
                {
                    if (gameBoard.canMove(col))
                    {
                        Board nextPos = gameBoard.MakeMove(Player.MAX, col);

                        double thisVal = ALPHA_BETA
                            ? AlphaBeta.Value(nextPos, MAX_DEPTH - 1, alfa, beta, Player.MIN)
                            : MiniMax.Value(nextPos, MAX_DEPTH - 1, Player.MIN);
                        Trace.println($" col = {col}   value = {Math.Round(thisVal, 2)}", 11, MAX_DEPTH);
                        if (thisVal > highVal)
                        {
                            bestMove = col;
                            highVal = thisVal;
                        }
                    }
                }
                ----whats this..implement---- -
                if (highVal == -1)
                {
                    bestMove = DesperationMove(gameBoard);
                }
                Console.WriteLine($"My move is {(bestMove + 1)}    (subj. value {highVal})");
                gameBoard = gameBoard.MakeMove(Player.MAX, bestMove);
                gameBoard.showBoard();

                if (gameBoard.isWin(Player.MAX))
                {
                    Console.WriteLine("\n I win");
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("Your move");
                    int theirMove = UserInput.getInteger("Select column 1 - 7", 1, 7) - 1;
                    if (gameBoard.canMove(theirMove))
                    {
                        gameBoard = gameBoard.MakeMove(Player.MIN, theirMove);
                        Console.WriteLine("");
                        gameBoard.showBoard();
                    }
                    if (gameBoard.isWin(Player.MIN))
                    {
                        Console.WriteLine("\n You win :-(");
                        gameOver = true;
                    }
                }
            }
            Console.WriteLine("nr of calls to minimax: " + MiniMax.NrEntries);
            Console.WriteLine("nr of calls to AlphaBeta: " + AlphaBeta.NrEntries);
            Console.ReadKey();
        }

        private static int DesperationMove(Board gameBoard)
        {
            int ColumnPicked = 0;
            for (int col = 0; col < Board.NR_COLS; ++col)
            {
                if (gameBoard.canMove(col))
                {
                    Board nextPos = gameBoard.MakeMove(Player.MIN, col);

                    if (nextPos.isWin(Player.MIN))
                    {
                        ColumnPicked = col;
                        break;
                    }
                }
            }
            return ColumnPicked;
        }

        private static void ProcessConfiguration()
        {

            String strDepth = ConfigurationManager.AppSettings["Depth"];
            var depth = 0;
            if (int.TryParse(strDepth, out depth))
            {
                if (depth > 1 && depth < 10) MAX_DEPTH = depth;
            }

            String strTrace = ConfigurationManager.AppSettings["Trace"];
            Int16 trcVal = 0;
            if (Int16.TryParse(strTrace, out trcVal))
            {
                Trace.ON = true;
                Trace.TraceDetailLevel = trcVal;
            }
            else Trace.ON = false;


            String strAB = ConfigurationManager.AppSettings["AlphaBeta"];
            ALPHA_BETA = strAB.CompareTo("AB") == 0;
        }
    }
    //Board board = new Board();
    ////Console.WriteLine(board.isValidMove(0, 1));
    ////Console.WriteLine(board.isValidMove(0, 2));
    ////Console.WriteLine(board.isValidMove(0, 3));
    ////Console.WriteLine(board.isValidMove(0, 4));
    ////Console.WriteLine(board.isValidMove(0, 5));
    ////Console.WriteLine(board.isValidMove(0, 6));
    ////Console.WriteLine(board.isValidMove(1, 8));
    ////Console.WriteLine(board.isValidMove(1, 9));
    ////Console.WriteLine(board.isValidMove(1, 10));
    ////Console.WriteLine(board.isValidMove(1, 11));
    ////Console.WriteLine(board.isValidMove(1, 12));
    ////Console.WriteLine(board.isValidMove(1, 13));            
    ////Console.WriteLine(board.isValidMove(0, 0));
    ////Console.WriteLine(board.isValidMove(1, 7));


    ////board.ShowBoard();
    ////board.MakeMove(1, 1);
    //////board.MakeMove(1, 2);
    //////board.MakeMove(1, 3);
    //board.MakeMove(0, 6);
    //board.ShowBoard();
    //board.MakeMove(1, 10);
    //board.ShowBoard();
    //////board.MakeMove(1, 5);
    ////board.MakeMove(1, 6);

    ////    bool gameOver = false;
    ////    Board mancala = new Board(); 

    ////    while (!gameOver)
    ////    {
    ////        Console.WriteLine("Hi");
    ////        double highVal = -1.0;
    ////        int bestMove = 0;
    ////        double alfa = -1.0;
    ////        double beta = 1.0;

    ////        for (int col = 0; col < Board.NR_COLS; col++)
    ////        {
    ////            if (mancala.isValidMove(0, col))
    ////            {
    ////                Board nextPos = mancala.MakeMove(0, col);


    ////                //double thisVal = ALPHA_BETA
    ////                //    ? AlphaBeta.Value(nextPos, MAX_DEPTH - 1, alfa, beta, Player.MIN)
    ////                //    : MiniMax.Value(nextPos, MAX_DEPTH - 1, Player.MIN);
    ////                //Trace.println($" col = {col}   value = {Math.Round(thisVal, 2)}", 11, MAX_DEPTH);
    ////                //if (thisVal > highVal)
    ////                //{
    ////                //    bestMove = col;
    ////                //    highVal = thisVal;
    ////                }
    ////        }
    ////    }
    ////}
}
    }
}
