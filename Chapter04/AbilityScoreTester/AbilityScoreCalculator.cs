using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreTester
{
    class AbilityScoreCalculator
    {
        public int RollResult { get; set; } = 14;
        public double DivideBy { get; set; } = 1.75;
        public int AddAmount { get; set; } = 2;
        public int Minimum { get; set; } = 3;
        public int Score { get; set; } = 0;

        public void CalculateAbilityScore()
        {
            // Divide the roll result by the DivideBy field
            double divided = RollResult / DivideBy;
            // Add AddAmount to the result of that division
            int added = AddAmount + (int)divided;
            // If the result is too small, use Minimum
            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }
    }
}
