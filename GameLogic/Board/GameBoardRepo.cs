using System.Collections.Generic;
using GameLogic.Board.Models;

namespace GameLogic.Board
{
    public class GameBoardRepo : IGameBoardRepo
    {
        private readonly Dictionary<string, List<Tile>> Gameboards = new()
        {
            ["standard_board"] = new List<Tile> {
                
                //TODO figure out the most readable way of doing this
            }
        };

        public bool TryGetBoard(string key, out List<Tile> board)
        {
           return Gameboards.TryGetValue(key, out board);
        }
    }
}
