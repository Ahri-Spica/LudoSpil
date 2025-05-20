using GameLogic.Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Engine
{
    public interface IGameEngine
    {
        int RollDice(PlayerColour caller);
        void move (PlayerColour caller, int PieceId);
        GameState Snapshot();
    }
}
