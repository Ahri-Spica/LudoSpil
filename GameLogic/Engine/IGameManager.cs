using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Engine
{
    public interface IGameManager
    {
        string CreateGame(string boardKey);
        IGameEngine GetGame(string gameId);
    }
}
