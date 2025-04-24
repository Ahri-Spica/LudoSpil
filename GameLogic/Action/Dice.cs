using System.Security.Cryptography;

namespace GameLogic.Action
{
    public class Dice : IDice
    {
        public int StandardDiceRoll()
        {
            return RandomNumberGenerator.GetInt32(1, 7);
        }

    /*public static int Roll(int sides) //more extendable option
    {
        return RandomNumberGenerator.GetInt32(1, sides + 1);
    }

    public static int D6() => Roll(6);
    public static int D20() => Roll(20);
    public static int D100() => Roll(100);*/
    }
}
