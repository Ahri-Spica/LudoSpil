using GameLogic.Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Engine.Strategies
{
    public interface IStepStrategy
    {
        /// <summary> Return the ID of the tile you should enter after taking ONE step from <paramref name="current"/>.</summary>
        /// 
        int GetNextId(Tile current, PlayerColour caller);
    }
}
