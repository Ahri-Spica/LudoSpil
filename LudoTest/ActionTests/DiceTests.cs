using GameLogic.Action;
using Xunit;

namespace LudoTest.ActionTests
{
    public class DiceTests
    {
        [Fact]
        public void StandardDiceRoll_Sides()
        {
            //  ---Arrange ---
            IDice dice = new Dice();
            const int iterations = 500;

            //  ---Act ---
            for (int i = 0; i < iterations; i++)
            {
                int roll = dice.StandardDiceRoll();

                // ---Assert ---
                Assert.InRange(roll, 0, 6);
            }
        }
    }
}
