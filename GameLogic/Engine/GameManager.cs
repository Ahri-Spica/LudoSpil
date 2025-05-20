using GameLogic.Action;
using GameLogic.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Engine
{
    public class GameManager : IGameManager
    {
        private readonly IGameBoardRepo _repo;
        private readonly IDice          _dice;
        private readonly Dictionary<string, IGameEngine> _games = new();

        public GameManager(IGameBoardRepo repo, IDice dice)
        {
            _repo = repo;
            _dice = dice;
        }

        public string CreateGame(string boardkey)
        {
            if (!_repo.TryGetBoard(boardkey, out var board))
            {
                throw new ArgumentException("Board Key not found");
            }

            string Id = Guid.NewGuid().ToString("N");
            _games[Id] = new GameEngine(board, _dice);
            return Id;
        }

        public IGameEngine GetGame(string Id)
        {
            return _games[Id];
        }
    }
}
