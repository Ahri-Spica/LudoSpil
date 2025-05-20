using GameLogic.Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Engine
{
    public class StateHelperPieces
    {
        public enum PieceStatus
        {
            Home,
            Board,
            Finish,
        }

        public record PiecePos(PieceStatus status, int? TileId);

    }
}
