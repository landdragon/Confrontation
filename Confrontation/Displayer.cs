namespace Confrontation
{
    public class Displayer : IDisplayer
    {
        private readonly IWriter _writer;

        public Displayer(IWriter writer)
        {
            _writer = writer;
        }

        public void DisplayScores(List<(int player, int computer)> scores)
        {
            var scoresPlayer = scores.Select(x => x.player);
            var scoresPlayerFormated = string.Join(", ", scoresPlayer);
            _writer.WriteLine($"Player: [{scoresPlayerFormated}] = {scoresPlayer.Sum()}");
            var scoresComputer = scores.Select(x => x.computer);
            var scoresComputerFormated = string.Join(", ", scoresComputer);
            _writer.WriteLine($"Computer: [{scoresComputerFormated}] = {scoresComputer.Sum()}");
        }

        public void DisplayDice(List<(int heaven, int hell)> dice)
        {
            for (int i = 0; i < 6; i++)
            {
                _writer.WriteLine($"Round {i+1}: heaven ({dice[i].heaven}) hell ({dice[i].hell})");
            }
        }
        public void DisplayWinner(WinnerEnum winner)
        {
            if (winner == WinnerEnum.Null)
            {
                _writer.WriteLine("Match Nul");
            }
            else if (winner == WinnerEnum.Player)
            {
                _writer.WriteLine("Player");
            }
            else
            {
                _writer.WriteLine("Computer");
            }
        }
        private void DisplayWinner(int playerScore, int computerScore)
        {
            if (playerScore == computerScore)
            {
                _writer.WriteLine("Match Nul");
            }
            else if (playerScore > computerScore)
            {
                _writer.WriteLine("Player");
            }
            else
            {
                _writer.WriteLine("Computer");
            }
        }
    }
}