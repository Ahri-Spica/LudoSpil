using GameLogic.Board.Models;
using GameLogic.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameLogic.Engine.StateHelperPieces;

namespace GameLogic.Engine
{
    /// <summary> All Mutable Data for one running game. </summary>

    public enum TurnPhase { AwaitingRoll, AwaitingMove}

    public class GameState
    {
        public Dictionary<int, PiecePos> PiecePosition { get; } = new(); //Piece Id -> Tile Id
        public PlayerColour CurrentPlayer { get; set; }
        public TurnPhase Phase { get; set; } = TurnPhase.AwaitingRoll;
        public int? LastRoll { get; set; } = null;
    }
}
