namespace Confrontation
{
    public interface IDisplayer
    {
        void DisplayDice(List<(int heaven, int hell)> dice);
        void DisplayScores(List<(int player, int computer)> scores);
        void DisplayWinner(WinnerEnum winner);
    }
}