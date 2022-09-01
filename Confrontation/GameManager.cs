namespace Confrontation
{
    public class GameManager
    {
        private readonly IDiceRoller _diceRoller;
        private readonly IRulesManager _rulesManager;
        private readonly IDisplayer _displayer;

        public GameManager(IDiceRoller diceRoller, IRulesManager rulesManager, IDisplayer displayer)
        {
            _diceRoller = diceRoller;
            _rulesManager = rulesManager;
            _displayer = displayer;
        }

        public void Play()
        {
            var gameData = new GameData();

            for (int i = 0; i < 6; i++)
            {
                var dice = _diceRoller.RollDice();
                var score = _rulesManager.ComputePoint(dice);
                gameData.Scores.Add(score);
                gameData.Dice.Add(dice);
            }

            _displayer.DisplayGame(gameData);
        }
    }
}