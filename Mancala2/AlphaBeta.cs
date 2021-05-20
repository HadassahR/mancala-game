

namespace Mancala2
{
    class AlphaBeta
    {
        public static double Value(Board board, int depth, double alfa, double beta, Player player)
        {

            double value = 0.0;
            if (depth == 0 || board.IsGameOver())
            {
                value = board.heuristicValue(player);
            }
            else
            {
                Player opponent = player == Player.MAX ? Player.MIN : Player.MAX;

                if (player == Player.MAX)
                {
                    for (int cup = 0; cup < Board.NR_CUPS; ++cup)
                    {
                        if (board.IsValidMove(cup))
                        {
                            Board nextPos = board.MakeMove(Player.MAX, cup);
                            double thisVal = Value(nextPos, depth - 1, alfa, beta, opponent);
                            if (thisVal > alfa)
                            {
                                alfa = thisVal;
                            }
                            if (beta <= alfa)
                            {
                                break;
                            }
                        }
                    }
                    value = alfa;
                }
                else  // player == Player.MIN
                {
                    for (int cup = 0; cup < Board.NR_CUPS; ++cup)
                    {
                        if (board.IsValidMove(cup))
                        {
                            Board nextPos = board.MakeMove(Player.MIN, cup);
                            double thisVal = Value(nextPos, depth - 1, alfa, beta, opponent);
                            if (thisVal < beta)
                            {
                                beta = thisVal;
                            }
                            if (beta <= alfa)
                            {
                                break;
                            }
                        }
                    }
                    value = beta;
                }
            }
            return value;
        }
    }
}