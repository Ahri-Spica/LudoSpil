using GameLogic.Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Engine.Strategies
{
    public sealed class StepPath : IStepStrategy
    {
        public int GetNextId(Tile current, PlayerColour caller)
        {
            return current.Next[TileKey.Default];
        }
    }

    public sealed class StepFunnel : IStepStrategy
    {
        public int GetNextId(Tile current, PlayerColour caller)
        {
            var key = caller switch
            {
                PlayerColour.Red    => TileKey.Red,
                PlayerColour.Green  => TileKey.Green,
                PlayerColour.Yellow => TileKey.Yellow,
                PlayerColour.Blue   => TileKey.Blue,
                _                   => TileKey.Default      // should never hit
            };

            if (current.Next.TryGetValue(key, out var branch)) {
                return branch;
            } 
            else {
                return current.Next[TileKey.Default];
            }
        }
    }
}
