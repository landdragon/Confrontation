namespace Confrontation
{
    public class GameData
    {
        public List<(int player, int computer)> Scores { get; set; } = new();
        public List<(int heaven, int hell)> Dice { get; set; } = new();
    }
}