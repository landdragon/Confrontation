using Confrontation;
using Moq;
using System.Linq;

namespace ConfrontationTest
{
    public class DisplayerTest
    {
        private Mock<IWriter> _writer;
        private IDisplayer _displayer;
        (int heaven, int hell) _playerWinDice = (3, 3);
        (int heaven, int hell) _computerWinDice = (2, 1);

        public DisplayerTest()
        {
            _writer = new Mock<IWriter>();
            _displayer = new Displayer(_writer.Object);
        }

        [Fact]
        void Display_Match_Null()
        {
            var gameData = GenerateGameDataWithComputerEquality();

            _displayer.DisplayGame(gameData);

            _writer.Verify(x => x.WriteLine("Match Nul"), Times.Once);

            _writer.Verify(x => x.WriteLine($"Round 1: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 2: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 3: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 4: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 5: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 6: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            var scoresPlayer = gameData.Scores.Select(x => x.player);
            var scoresPlayerFormated = string.Join(", ", scoresPlayer);
            _writer.Verify(x => x.WriteLine($"Player: [{scoresPlayerFormated}] = {scoresPlayer.Sum()}"), Times.Once);
            var scoresComputer = gameData.Scores.Select(x => x.computer);
            var scoresComputerFormated = string.Join(", ", scoresComputer);
            _writer.Verify(x => x.WriteLine($"Computer: [{scoresComputerFormated}] = {scoresComputer.Sum()}"), Times.Once);
        }

        [Fact]
        void Display_Player_Win()
        {
            var gameData = GenerateGameDataWithPlayerWin();

            _displayer.DisplayGame(gameData);

            _writer.Verify(x => x.WriteLine("Player"), Times.Once);

            _writer.Verify(x => x.WriteLine($"Round 1: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 2: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 3: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 4: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 5: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 6: heaven ({_playerWinDice.heaven}) hell ({_playerWinDice.hell})"), Times.Once);
            var scoresPlayer = gameData.Scores.Select(x => x.player);
            var scoresPlayerFormated = string.Join(", ", scoresPlayer);
            _writer.Verify(x => x.WriteLine($"Player: [{scoresPlayerFormated}] = {scoresPlayer.Sum()}"), Times.Once);
            var scoresComputer = gameData.Scores.Select(x => x.computer);
            var scoresComputerFormated = string.Join(", ", scoresComputer);
            _writer.Verify(x => x.WriteLine($"Computer: [{scoresComputerFormated}] = {scoresComputer.Sum()}"), Times.Once);
        }

        [Fact]
        void Display_Computer_Win()
        {
            var gameData = GenerateGameDataWithComputerWin();

            _displayer.DisplayGame(gameData);

            _writer.Verify(x => x.WriteLine("Computer"), Times.Once);

            _writer.Verify(x => x.WriteLine($"Round 1: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 2: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 3: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 4: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 5: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            _writer.Verify(x => x.WriteLine($"Round 6: heaven ({_computerWinDice.heaven}) hell ({_computerWinDice.hell})"), Times.Once);
            var scoresPlayer = gameData.Scores.Select(x => x.player);
            var scoresPlayerFormated = string.Join(", ", scoresPlayer);
            _writer.Verify(x => x.WriteLine($"Player: [{scoresPlayerFormated}] = {scoresPlayer.Sum()}"), Times.Once);
            var scoresComputer = gameData.Scores.Select(x => x.computer);
            var scoresComputerFormated = string.Join(", ", scoresComputer);
            _writer.Verify(x => x.WriteLine($"Computer: [{scoresComputerFormated}] = {scoresComputer.Sum()}"), Times.Once);


        }

        private GameData GenerateGameDataWithPlayerWin()
        {
            var gameData = new GameData();
            for (int i = 0; i < 6; i++)
            {
                gameData.Dice.Add(_playerWinDice);
                gameData.Scores.Add((3, -3));
            }
            return gameData;
        }
        private GameData GenerateGameDataWithComputerWin()
        {
            var gameData = new GameData();
            for (int i = 0; i < 6; i++)
            {
                gameData.Dice.Add(_computerWinDice);
                gameData.Scores.Add((-3, 3));
            }
            return gameData;
        }
        private GameData GenerateGameDataWithComputerEquality()
        {
            var gameData = new GameData();
            for (int i = 0; i < 3; i++)
            {
                gameData.Dice.Add(_playerWinDice);
                gameData.Scores.Add((3, -3));
            }
            for (int i = 0; i < 3; i++)
            {
                gameData.Dice.Add(_computerWinDice);
                gameData.Scores.Add((-3, 3));
            }
            return gameData;
        }
    }
}
