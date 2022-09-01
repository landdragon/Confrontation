using Confrontation;
using Moq;

namespace ConfrontationTest
{
    public class GameManagerTest
    {
        private GameManager _gameManager;
        private Mock<IDiceRoller> _diceRoller;
        private Mock<IRulesManager> _rulesManager;
        private Mock<IDisplayer> _displayer;

        public GameManagerTest()
        {
            _diceRoller = new Mock<IDiceRoller>();
            _rulesManager = new Mock<IRulesManager>();
            _displayer = new Mock<IDisplayer>();
            _gameManager = new GameManager(_diceRoller.Object, _rulesManager.Object, _displayer.Object);
        }

        [Fact]  
        public void PlayTest()
        {
            (int heaven, int hell) dice = (1, 1);
            _diceRoller.Setup(x => x.RollDice()).Returns(dice);
            (int player, int computer) score1 = (5, -5);
            _rulesManager.Setup(x => x.ComputePoint(dice)).Returns(score1);

            _gameManager.Play();

            _diceRoller.Verify(x => x.RollDice(), Times.Exactly(6));
            _rulesManager.Verify(x => x.ComputePoint(dice), Times.Exactly(6));
            _displayer.Verify(x => x.DisplayGame(It.IsAny<GameData>()), Times.Once);
        }
    }
}
