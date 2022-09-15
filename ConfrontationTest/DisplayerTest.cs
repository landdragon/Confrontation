using Confrontation;
using Moq;

namespace ConfrontationTest
{
    public class DisplayerTest
    {
        private Mock<IWriter> _writer;
        private IDisplayer _displayer;

        public DisplayerTest()
        {
            _writer = new Mock<IWriter>();
            _displayer = new Displayer(_writer.Object);
        }

        [Fact]
        public void DisplayWinner_Match_Null()
        {
            _displayer.DisplayWinner(WinnerEnum.Null);

            _writer.Verify(x => x.WriteLine("Match Nul"), Times.Once);
        }

        [Fact]
        public void DisplayWinner_Player_Win()
        {
            _displayer.DisplayWinner(WinnerEnum.Player);

            _writer.Verify(x => x.WriteLine("Player"), Times.Once);
        }

        [Fact]
        public void DisplayWinner_Computer_Win()
        {
            _displayer.DisplayWinner(WinnerEnum.Computer);

            _writer.Verify(x => x.WriteLine("Computer"), Times.Once);
        }
        [Fact]
        public void DisplayScores()
        {
            var scores = new List<(int player, int computer)>();
            for (int i = 0; i < 3; i++)
            {
                scores.Add((3, -3));
            }
            for (int i = 0; i < 3; i++)
            {
                scores.Add((-3, 3));
            }
            _displayer.DisplayScores(scores);

            var scoresPlayer = scores.Select(x => x.player);
            var scoresPlayerFormated = string.Join(", ", scoresPlayer);
            _writer.Verify(x => x.WriteLine($"Player: [{scoresPlayerFormated}] = {scoresPlayer.Sum()}"), Times.Once);
            var scoresComputer = scores.Select(x => x.computer);
            var scoresComputerFormated = string.Join(", ", scoresComputer);
            _writer.Verify(x => x.WriteLine($"Computer: [{scoresComputerFormated}] = {scoresComputer.Sum()}"), Times.Once);
        }
        [Fact]
        public void DisplayDice()
        {
            var dice = new List<(int heaven, int hell)>();
            for (int i = 0; i < 6; i++)
            {
                var heaven = i + 1;
                var hell = i + 2 > 6 ? i + 2 - 6 : i + 2;
                dice.Add((heaven, hell));
            }
            _displayer.DisplayDice(dice);

            for (int i = 0; i < dice.Count; i++)
            {
                _writer.Verify(x => x.WriteLine($"Round {i+1}: heaven ({dice[i].heaven}) hell ({dice[i].hell})"), Times.Once);
            }
        }
    }
}
