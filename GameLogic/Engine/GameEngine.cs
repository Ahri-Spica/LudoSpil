using GameLogic.Action;
using GameLogic.Board.Models;
using GameLogic.Engine.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static GameLogic.Engine.StateHelperPieces;

namespace GameLogic.Engine
{
    /// <summary> Main Game Logic </summary>
    /// 
    public class GameEngine : IGameEngine
    {
        private static readonly IReadOnlyDictionary<TileType, IStepStrategy> _stepStrategies =
            new Dictionary<TileType, IStepStrategy> // TODO refactor this to be neater
            {
                [TileType.Path] = new StepPath(),
                [TileType.HomeEntry] = new StepFunnel(),
                [TileType.HomePath] = new StepPath(), // Add Homepath strategy
                [TileType.Start] = new StepPath(), // Add Strategy for this scenario
                [TileType.Home] = new StepPath(), // Add Home Strategy
                [TileType.Finish] = new StepPath() // add Finish Strategy
            };

        private readonly List<Tile> _board;
        private readonly IDice _dice;
        private readonly GameState _state;

        public GameEngine(List<Tile> board, IDice dice)
        {
            _board = board;
            _dice = dice;
            _state = new GameState();

            SeedPieces();
        }

        public void ForceCurrentPlayer(PlayerColour c) => _state.CurrentPlayer = c; //temp, Get better at testing my guy

        /*------------------------------------------------------------------------*/
        /*  Public API (called by controllers or unit tests)                      */
        /*------------------------------------------------------------------------*/

        public void move(PlayerColour caller, int PieceId)
        {
            IsTurn(caller);

            if (_state.Phase != TurnPhase.AwaitingMove) {
                throw new InvalidOperationException("Sequence Broken, is not move phase");
            }
            if (!_state.LastRoll.HasValue) {
                throw new InvalidOperationException("Sequence Broken, roll dice first");
            }

            int dice = _state.LastRoll.Value;
            _state.LastRoll = null;

            /*--- Work out current tile ---*/

            PiecePos position;
            bool isHome = !_state.PiecePosition.TryGetValue(PieceId, out position);
            Tile current;

            if (isHome) {
                current = FindStartTile(caller);
            } 
            else { 
                current = _board.Single(t => t.Id == position.TileId!.Value);
            }

            /*--- walk dice steps along path ---*/

            Tile target = current;
            for (int step = 0; step < dice; step++)
            {
                target = Step(target, caller);
            }

            /*--- move the piece ---*/

            if (!isHome) { //should probablt happen before step
                current.Pieces.RemoveAll(p => p.Id == PieceId);
            }

            //moves out
            var piece = current.Pieces.FirstOrDefault(p => p.Id == PieceId);
            if (piece is null) 
            {
                piece = new Piece { Id = PieceId, Owner = caller };
            }

            target.Pieces.Add(piece);
            if (target.Type == TileType.Finish) {
                _state.PiecePosition[piece.Id] = new PiecePos(PieceStatus.Finish, null /*TODO maybe a more elegant placement*/);
            }
            else {
                _state.PiecePosition[piece.Id] = new PiecePos(PieceStatus.Board, target.Id);
            }

            if (AllFinish(caller)) 
            {
               // _state.Winners.Add(caller);
            }
            /*--- EOT book keeping ---*/

            _state.Phase = TurnPhase.AwaitingRoll;
            if (dice is not 6)
            {
                _state.CurrentPlayer = NextPlayer(_state.CurrentPlayer);
            }
        }

        public int RollDice(PlayerColour caller)
        {
            IsTurn(caller);
            if (_state.Phase != TurnPhase.AwaitingRoll){
                throw new InvalidOperationException("Sequence Broken, Not Dice Phase");
            }
            if (_state.LastRoll.HasValue) {
                throw new InvalidOperationException("Sequence Broken, already rolled");
            }

            int value = _dice.StandardDiceRoll();
            _state.LastRoll = value;
            _state.Phase = TurnPhase.AwaitingMove;
            return value;
        }

        public GameState Snapshot()
        {
            return _state;
        }

        /*------------------------------------------------------------------------*/
        /*  Internal helpers                                                      */
        /*------------------------------------------------------------------------*/
    
        private Tile Step(Tile current, PlayerColour caller)
        {
            var strategy = _stepStrategies[current.Type];
            int nextId  = strategy.GetNextId(current, caller);
            return _board.Single(t => t.Id == nextId);
        }

        private Tile FindStartTile(PlayerColour caller)
        {
            return _board.Single(t => t.Type == TileType.Start && t.owner == caller);
        }

        private void IsTurn(PlayerColour caller)
        {
            if (caller != _state.CurrentPlayer)
            {
                throw new InvalidOperationException($"Sequence break, its {_state.CurrentPlayer}'s turn");
            }
        }

        private PlayerColour NextPlayer(PlayerColour caller)
        {
            return caller switch
            {
                PlayerColour.Red    => PlayerColour.Green,
                PlayerColour.Green  => PlayerColour.Yellow,
                PlayerColour.Yellow => PlayerColour.Blue,
                _                   => PlayerColour.Red,

            };
        }

        private bool AllFinish(PlayerColour Owner)
        {
            /* return _state.PiecePosition
                 .Where(kv => GetOwnerColour(kv.Key) == colour)
                 .All(kv => kv.Value.Status == PieceStatus.Finish); */
            return false;
        }

        private void SeedPieces()
        {
            foreach (var colour in Enum.GetValues<PlayerColour>()) // Red, Green, Yellow, Blue
            {  
                for (int i = 0; i < 4; i++)                          // the 4 pieces each player has
                {
                    int id = ((int)colour * 10) + i;                 // e.g. 0‑3, 10‑13, 20‑23, 30‑33
                    _state.PiecePosition[id] = new PiecePos(PieceStatus.Home, null);
                }
            }
        }
    }
}
