using System.Runtime.CompilerServices;

namespace Confrontation
{
    public static class Program
    {
        public static void Main()
        {
            var x = new GameManager(new DiceRoller(), new RulesManager(), new Displayer(new Writer()));
            x.Play();
        }
    }
}
