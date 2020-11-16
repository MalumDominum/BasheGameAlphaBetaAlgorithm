using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BasheGamePA
{
    class BasheCore
    {
        public int MaxDamage { get; set; }
        public bool Turn { get; set; }
        public bool FirstTurn { get; set; }

        private int Heuristic(int depth)
        {
            int evaluation = depth;
            return evaluation;
        }
        public int AlphaBetaPruning(int damage, int currentBossHealth, int alpha, int beta, int depth, bool maximizingPlayer)
        {
            if (depth == 0 || currentBossHealth <= 0)
            {
                if (maximizingPlayer)
                    return -1;
                else
                    return Heuristic(depth);
            }

            if (maximizingPlayer)
            {
                int maxEval = -999;

                for (int i = 1; i <= MaxDamage; i++)
                {
                    currentBossHealth -= i;
                    var eval = AlphaBetaPruning(i, currentBossHealth, alpha, beta, depth - 1, false);
                    currentBossHealth += i;
                    maxEval = Math.Max(maxEval, eval);
                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha)
                        break;
                }
                return maxEval;
            }
            else
            {
                int minEval = 999;

                for (int i = 1; i <= MaxDamage; i++)
                {
                    currentBossHealth -= i;
                    var eval = AlphaBetaPruning(i, currentBossHealth, alpha, beta, depth - 1, true);
                    currentBossHealth += i;
                    minEval = Math.Min(minEval, eval);
                    beta = Math.Min(beta, eval);
                    if (beta <= alpha)
                        break;
                }
                return minEval;
            }
        }
    }
}
