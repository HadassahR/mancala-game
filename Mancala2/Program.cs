namespace Mancala2
{
    class Program
    {
        //static int MAX_DEPTH = 4;  // default value reset inside ProcessConfiguration
        //static bool ALPHA_BETA = false;
        static void Main(string[] args)
        {
            NewBoard board = new NewBoard();
            board.ShowBoard();
            //board.MakeMove(1, 1);
            //board.MakeMove(1, 2);
            //board.MakeMove(1, 3);
            //board.MakeMove(1, 4);
            //board.MakeMove(1, 5);
            board.MakeMove(1, 6);
            board.ShowBoard();
            //    bool gameOver = false;
            //    Board mancala = new Board(); 

            //    while (!gameOver)
            //    {
            //        Console.WriteLine("Hi");
            //        double highVal = -1.0;
            //        int bestMove = 0;
            //        double alfa = -1.0;
            //        double beta = 1.0;

            //        for (int col = 0; col < Board.NR_COLS; col++)
            //        {
            //            if (mancala.isValidMove(0, col))
            //            {
            //                Board nextPos = mancala.MakeMove(0, col);


            //                //double thisVal = ALPHA_BETA
            //                //    ? AlphaBeta.Value(nextPos, MAX_DEPTH - 1, alfa, beta, Player.MIN)
            //                //    : MiniMax.Value(nextPos, MAX_DEPTH - 1, Player.MIN);
            //                //Trace.println($" col = {col}   value = {Math.Round(thisVal, 2)}", 11, MAX_DEPTH);
            //                //if (thisVal > highVal)
            //                //{
            //                //    bestMove = col;
            //                //    highVal = thisVal;
            //                }
            //        }
            //    }
            //}
        }
    }
}
