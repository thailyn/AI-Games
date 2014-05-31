using Checkers.Game;
using Checkers.Game.Moves;
using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Engine
{
    [Serializable]
    public class CheckersState : IState<CheckersOptions, CheckersPlayer, CheckersMove, CheckersState>
    {
        public List<Location> Board
        {
            get;
            protected set;
        }

        public CheckersOptions Options
        {
            get;
            protected set;
        }

        public CheckersState PreviousState
        {
            get;
            protected set;
        }

        public List<CheckersMove> MovesThisTurn
        {
            get;
            protected set;
        }

        private CheckersPlayer _currentPlayer;
        public CheckersPlayer CurrentPlayer
        {
            get
            {
                if (_currentPlayer == null && Options.Players != null && Options.Players.Count > 0)
                {
                    CurrentPlayer = Options.Players[0];
                }

                return _currentPlayer;
            }
            protected set
            {
                if (value != _currentPlayer)
                {
                    _currentPlayer = value;
                }
            }
        }

        public CheckersState(CheckersOptions options)
        {
            Board = new List<Location>();
            MovesThisTurn = new List<CheckersMove>();
            Options = options;
            for (int i = 0; i < Options.NumRows; i++)
            {
                for (int j = 0; j < Options.NumColumns; j++)
                {
                    Board.Add(new Location(i, j, null));
                }
            }

            CheckersPlayer currentPlayer = Options.Players[0];
            Team currentTeam = currentPlayer.Team;
            for (int i = 0; i < Options.InitialRowsOfPieces; i++)
            {
                for (int j = 0; j < Options.NumColumns; j++)
                {
                    int currentIndex = i * Options.NumColumns + j;
                    if ((currentIndex + i) % 2 == 0)
                    {
                        continue;
                    }

                    Board[currentIndex].PlacePiece(new Piece(currentTeam, currentPlayer));
                }
            }

            currentPlayer = Options.Players[1];
            currentTeam = currentPlayer.Team;
            for (int i = Options.NumRows - 1; i > Options.NumRows - Options.InitialRowsOfPieces - 1; i--)
            {
                for (int j = 0; j < Options.NumColumns; j++)
                {
                    int currentIndex = i * Options.NumColumns + j;
                    if ((currentIndex + i) % 2 == 0)
                    {
                        continue;
                    }

                    Board[currentIndex].PlacePiece(new Piece(currentTeam, currentPlayer));
                }
            }

            if (options.Players != null && options.Players.Count > 0)
            {
                CurrentPlayer = options.Players[0];
            }
        }

        public bool IsEndState()
        {
            List<CheckersPlayer> winningPlayers;
            return IsEndState(out winningPlayers);
        }

        public bool IsEndState(out List<CheckersPlayer> winningPlayers)
        {
            winningPlayers = new List<CheckersPlayer>();
            List<Location> currentPlayerLocations = new List<Location>();
            List<Location> otherPlayerLocations = new List<Location>();
            CheckersPlayer otherPlayer = null;

            // Find each players' pieces and determine if one player is
            // out of pieces.
            foreach (var location in Board)
            {
                if (location.IsUnoccupied())
                {
                    continue;
                }

                if (location.Piece.Owner == CurrentPlayer)
                {
                    currentPlayerLocations.Add(location);
                }
                else
                {
                    otherPlayerLocations.Add(location);
                    otherPlayer = otherPlayer ?? location.Piece.Owner;
                }
            }

            if (currentPlayerLocations.Count == 0)
            {
                winningPlayers.Add(otherPlayer);
                return true;
            }

            if (otherPlayerLocations.Count == 0)
            {
                winningPlayers.Add(CurrentPlayer);
                return true;
            }

            // See if the current player has any moves to make.
            foreach (var move in GetAvailableMoves(this))
            {
                return false;
            }

            winningPlayers.Add(otherPlayer);
            return true;
        }

        protected IEnumerable<CheckersMove> GetAvailableMoves(CheckersState state)
        {
            CheckersMove previousMoveThisTurn = null;
            if (state.MovesThisTurn.Count > 0)
            {
                // If the current player already slid a piece, he can not do anything else.
                previousMoveThisTurn = state.MovesThisTurn[state.MovesThisTurn.Count - 1];
                if (previousMoveThisTurn is SlidePieceMove)
                {
                    yield return new EndTurnMove(state.CurrentPlayer);
                    yield break;
                }

                // If the player just jumped, he can always choose to end his turn.
                if (previousMoveThisTurn is JumpPieceMove)
                {
                    yield return new EndTurnMove(state.CurrentPlayer);
                }
            }

            int forwardDirection = 0;
            if (state.CurrentPlayer.Team == Team.Red)
            {
                // Red goes down.
                forwardDirection = 1;
            }
            else
            {
                // Black goes up.
                forwardDirection = -1;
            }

            foreach (var location in state.Board)
            {
                if (location.IsUnoccupied() || location.Piece.Owner != state.CurrentPlayer)
                {
                    continue;
                }

                foreach (var move in GetAvailableMovesForPiece(this, location, forwardDirection, false))
                {
                    yield return move;
                }
            }
        }

        protected IEnumerable<CheckersMove> GetAvailableMovesForPiece(CheckersState state, Location location,
            int forwardDirection, bool onlyCanCapture)
        {
            CheckersPlayer currentPlayer = state.CurrentPlayer;
            Piece piece = location.Piece;

            #region Down left
            if (forwardDirection == 1 || piece.IsKing)
            {
                foreach (var move in GetAvailableMovesForPieceInDirection(state, location, forwardDirection,
                    +1, -1, onlyCanCapture))
                {
                    yield return move;
                }
            }
            #endregion

            #region Down right
            if (forwardDirection == 1 || piece.IsKing)
            {
                foreach (var move in GetAvailableMovesForPieceInDirection(state, location, forwardDirection,
                    +1, +1, onlyCanCapture))
                {
                    yield return move;
                }
            }
            #endregion

            #region Up left
            if (forwardDirection == -1 || piece.IsKing)
            {
                foreach (var move in GetAvailableMovesForPieceInDirection(state, location, forwardDirection,
                    -1, -1, onlyCanCapture))
                {
                    yield return move;
                }
            }
            #endregion

            #region Up right
            if (forwardDirection == -1 || piece.IsKing)
            {
                foreach (var move in GetAvailableMovesForPieceInDirection(state, location, forwardDirection,
                    -1, +1, onlyCanCapture))
                {
                    yield return move;
                }
            }
            #endregion
        }

        public IEnumerable<CheckersMove> GetAvailableMovesForPieceInDirection(CheckersState state, Location location,
            int forwardDirection, int rowDirection, int columnDirection, bool onlyCanCapture)
        {
            CheckersPlayer currentPlayer = state.CurrentPlayer;

            int newRow = location.Row + rowDirection;
            int newColumn = location.Column + columnDirection;
            int newIndex = newRow * state.Options.NumColumns + newColumn;

            if (newRow >= 0 && newRow < state.Options.NumRows && newColumn >= 0 && newColumn < state.Options.NumColumns
                && !onlyCanCapture)
            {
                if (state.Board[newIndex].IsUnoccupied())
                {
                    yield return new SlidePieceMove(location.Row, location.Column, newRow, newColumn, location.Piece);
                }
            }

            int jumpNewRow = newRow + rowDirection;
            int jumpNewColumn = newColumn + columnDirection;
            int jumpNewIndex = jumpNewRow * state.Options.NumColumns + jumpNewColumn;

            if (jumpNewRow >= 0 && jumpNewRow < state.Options.NumRows && jumpNewColumn >= 0 && jumpNewColumn < state.Options.NumColumns)
            {
                if (!state.Board[newIndex].IsUnoccupied() && state.Board[newIndex].Piece.Owner != currentPlayer
                    && !state.Board[newIndex].Piece.IsJumped && state.Board[jumpNewIndex].IsUnoccupied())
                {
                    CheckersMove jumpPieceMove = new JumpPieceMove(location.Row, location.Column, newRow, newColumn,
                        location.Piece, state.Board[newIndex].Piece);
                    yield return jumpPieceMove;

                    var newState = state.ApplyMove(jumpPieceMove);
                    foreach (var move in GetAvailableMovesForPiece(newState,
                        newState.Board[newIndex], forwardDirection, true))
                    {
                        yield return move;
                    }
                }
            }
        }

        public CheckersMove GetAutomaticMove()
        {
            CheckersPlayer currentPlayer = CurrentPlayer;
            Team currentTeam = currentPlayer.Team;
            int goalRow = currentTeam == Team.Red ? Options.NumRows - 1 : 0;

            for (int i = goalRow * Options.NumColumns; i < (goalRow + 1) * Options.NumColumns; i++)
            {
                if (!Board[i].IsUnoccupied() && Board[i].Piece.Owner == currentPlayer
                    && Board[i].Piece.IsKing == false)
                {
                    return new MakeKingMove(Board[i], currentPlayer);
                }
            }

            return null;
        }

        // TODO: Have this method clone the current state, instead of modifying it.
        public CheckersState ApplyMove(CheckersMove newMove)
        {
            throw new NotImplementedException();
        }

        protected CheckersPlayer GetPlayerAfterMove(CheckersState startingState, CheckersMove move)
        {
            throw new NotImplementedException();
        }

        public CheckersState Copy()
        {
            throw new NotImplementedException();
        }
    }
}
