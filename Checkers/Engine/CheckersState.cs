using Checkers.Game;
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
            throw new NotImplementedException();
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
