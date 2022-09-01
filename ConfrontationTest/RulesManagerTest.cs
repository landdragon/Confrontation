using Confrontation;

namespace ConfrontationTest
{
    public class RulesManagerTest
    {
        private RulesManager _rulesManager;

        public RulesManagerTest()
        {
            _rulesManager = new RulesManager();
        }

        [Fact]
        public void Heaven_1_Hell_1()
        {
            (int player, int computer) = _rulesManager.ComputePoint((1, 1));

            Assert.Equal(5, player);
            Assert.Equal(-5, computer);
        }

        [Fact]
        public void Heaven_2_Hell_2()
        {
            (int player, int computer) = _rulesManager.ComputePoint((2, 2));

            Assert.Equal(8, player);
            Assert.Equal(-8, computer);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Heaven_And_Hell_AreEqual_But_Not_2_And_1(int heavenAndHell)
        {
            (int player, int computer) = _rulesManager.ComputePoint((heavenAndHell, heavenAndHell));

            Assert.Equal(3, player);
            Assert.Equal(-3, computer);
        }

        [Theory]
        [InlineData(1, 2, 7, -7)]
        [InlineData(2, 1, -3, 3)]
        public void Heaven_And_Hell_AreNotEqual(int heaven, int hell, int playerExpected, int computerExpected)
        {
            (int player, int computer) = _rulesManager.ComputePoint((heaven, hell));

            Assert.Equal(playerExpected, player);
            Assert.Equal(computerExpected, computer);
        }

        [Fact]
        public void Heaven_And_Hell_AreNotEqual_With_MutationTest()
        {
            var random = new Random();
            var range = Enumerable.Range(1, 6);
            var heaven = range.ElementAt(random.Next(0,range.Count()-1));

            range = range.Where(x=>x != heaven);
            var hell = range.ElementAt(random.Next(0, range.Count() - 1));

            (int player, int computer) = _rulesManager.ComputePoint((heaven, hell));

            Assert.Equal(-((heaven* heaven) -(hell* hell* hell)), player);
            Assert.Equal((heaven* heaven) -(hell* hell* hell), computer);
        }
    }
}