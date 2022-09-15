namespace Confrontation
{
    public interface IRulesManager
    {
        (int player, int computer) ComputePoint((int heaven, int hell) dice);
        WinnerEnum EvaluateWinner(List<(int player, int computer)> scores);
    }
}