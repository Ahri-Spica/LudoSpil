using NSubstitute;
using Xunit;
using GameLogic.Engine;
using GameLogic.Action;
using GameLogic.Board.Models;
using System.Collections.Generic;

namespace LudoTest.EngineTests
{
    public class EngineTests
    {
        [Theory]
        [InlineData(PlayerColour.Red, 2, PlayerColour.Green)]
        [InlineData(PlayerColour.Yellow, 6, PlayerColour.Yellow)]
        [InlineData(PlayerColour.Blue, 3, PlayerColour.Red)]
        public void NextPlayer_CorrectSequence(
            PlayerColour current, int dice, PlayerColour expected)
        {
            //---Arrange ---
            var diceMock = Substitute.For<IDice>();
            diceMock.StandardDiceRoll().Returns(dice);

            var TinyBoard = new List<Tile> //TODO probably move to helper function
            {
                new Tile {Id = 0, Type = TileType.Start, owner = current, Next = new Dictionary<TileKey, int> {[TileKey.Default] = 1} },
                new Tile {Id = 1, Type = TileType.Path, Next = new Dictionary<TileKey, int> {[TileKey.Default] = 0} }
            };

            var engine = new GameEngine(TinyBoard, diceMock);
            engine.ForceCurrentPlayer(current);

            //---Act ---
            engine.RollDice(current);
            engine.move(current, 0);

            //--- Assert ---
            Assert.Equal(expected, engine.Snapshot().CurrentPlayer);
        }
    }
}
