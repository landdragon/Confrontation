namespace Confrontation
{
    public class DiceRoller : IDiceRoller
    {
        public (int heaven, int hell) RollDice()
        {
            var random = new Random();
            return (random.Next(1, 6), random.Next(1, 6));
        }
    }
}