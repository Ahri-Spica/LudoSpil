using System.Collections.Generic;
using GameLogic.Board.Models;

namespace GameLogic.Board
{
    public interface IGameBoardRepo
    {
        bool TryGetBoard(string key, out List<Tile> board);
    }
}
