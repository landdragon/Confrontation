namespace Confrontation
{
    public class RulesManager : IRulesManager
    {
        private readonly List<Func<int, int, bool>> _rulesCondition = new()
        {
            {(heaven,hell) => { return heaven == 1 && hell == 1; } },
            {(heaven,hell) => { return heaven == 2 && hell == 2; } },
            {(heaven,hell) => { return heaven == hell; } },
            {(heaven,hell) => { return heaven != hell; } },
        };

        private readonly List<Func<int, int, (int Player, int Computer)>> _rulesResult = new()
        {
            { (heaven, hell) => { return (5, -5); }},
            { (heaven, hell) => { return (8, -8); } },
            { (heaven,hell) => { return (3, -3); } },
            { (heaven,hell) =>
                {
                    var result = (heaven * heaven)-(hell*hell*hell);
                    return (-(result), result);
                }
            },
        };

        public (int player, int computer) ComputePoint((int heaven, int hell) dice)
        {
            var ruleIndex = _rulesCondition.FindIndex(Rule => Rule(dice.heaven, dice.hell));
            return _rulesResult[ruleIndex](dice.heaven, dice.hell);
        }

        public WinnerEnum EvaluateWinner(List<(int player, int computer)> scores)
        {
            var playerScore = scores.Sum(x => x.player);
            var computerScore = scores.Sum(x => x.computer);
            if (playerScore == computerScore)
            {
                return WinnerEnum.Null;
            }
            if (playerScore > computerScore)
            {
                return WinnerEnum.Player;

            }
            return WinnerEnum.Computer;
        }
    }
}