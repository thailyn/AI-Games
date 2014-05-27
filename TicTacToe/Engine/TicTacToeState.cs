using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;
using TicTacToe.Game;

namespace TicTacToe.Engine
{
    // TODO: Add Serializable features.
    [Serializable]
    public class TicTacToeState : IState<TicTacToeOptions, TicTacToePlayer, TicTacToeMove, TicTacToeState>
    {
        public List<Mark> Board
        {
            get;
            protected set;
        }

        public TicTacToeOptions Options
        {
            get;
            protected set;
        }

        private TicTacToePlayer _currentPlayer;
        public TicTacToePlayer CurrentPlayer
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

        public TicTacToeState(TicTacToeOptions options)
        {
            Board = new List<Mark>();
            Options = options;
            for (int i = 0; i < Options.NumRows; i++)
            {
                for (int j = 0; j < Options.NumColumns; j++)
                {
                    Board.Add(new Mark(Game.Symbol.Blank, null));
                }
            }

            if (options.Players != null && options.Players.Count > 0)
            {
                CurrentPlayer = options.Players[0];
            }
        }

        public bool IsEndState()
        {
            List<TicTacToePlayer> winningPlayers;
            return IsEndState(out winningPlayers);
        }

        public bool IsEndState(out List<TicTacToePlayer> winningPlayers)
        {
            winningPlayers = new List<TicTacToePlayer>();
            TicTacToePlayer currentPlayer = null;
            int currentStreak = 0;

            // First, check rows.
            for (int i = 0; i < Options.NumRows; i++)
            {
                currentPlayer = null;
                for(int j = 0; j < Options.NumColumns; j++)
                {
                    Mark currentLocation = Board[i * Options.NumColumns + j];
                    if (currentLocation.Owner == null)
                    {
                        currentPlayer = null;
                        currentStreak = 0;
                    }
                    else if (currentPlayer != currentLocation.Owner)
                    {
                        currentPlayer = currentLocation.Owner;
                        currentStreak = 1;
                    }
                    else
                    {
                        currentStreak++;
                    }

                    if (currentStreak >= Options.NumToWin)
                    {
                        winningPlayers.Add(currentPlayer);
                        return true;
                    }
                }
            }
            currentPlayer = null;

            // Next, check columns.
            for (int i = 0; i < Options.NumColumns; i++)
            {
                currentPlayer = null;
                for (int j = 0; j < Options.NumRows; j++)
                {
                    Mark currentLocation = Board[j * Options.NumColumns + i];
                    if (currentLocation.Owner == null)
                    {
                        currentPlayer = null;
                        currentStreak = 0;
                    }
                    else if (currentPlayer != currentLocation.Owner)
                    {
                        currentPlayer = currentLocation.Owner;
                        currentStreak = 1;
                    }
                    else
                    {
                        currentStreak++;
                    }

                    if (currentStreak >= Options.NumToWin)
                    {
                        winningPlayers.Add(currentPlayer);
                        return true;
                    }
                }
            }
            currentPlayer = null;

            // Finally, check diagonals
            for (int i = 0; i < Options.NumColumns && i < Options.NumRows; i++)
            {
                Mark currentLocation = Board[i * Options.NumColumns + i];
                if (currentLocation.Owner == null)
                {
                    currentPlayer = null;
                    currentStreak = 0;
                }
                else if (currentPlayer != currentLocation.Owner)
                {
                    currentPlayer = currentLocation.Owner;
                    currentStreak = 1;
                }
                else
                {
                    currentStreak++;
                }

                if (currentStreak >= Options.NumToWin)
                {
                    winningPlayers.Add(currentPlayer);
                    return true;
                }
            }
            currentPlayer = null;

            // Finally, check diagonals (other direction)
            for (int i = Options.NumColumns - 1; i >= 0; i--)
            {
                Mark currentLocation = Board[(Options.NumRows - i - 1) * Options.NumColumns];
                if (currentLocation.Owner == null)
                {
                    currentPlayer = null;
                    currentStreak = 0;
                }
                else if (currentPlayer != currentLocation.Owner)
                {
                    currentPlayer = currentLocation.Owner;
                    currentStreak = 1;
                }
                else
                {
                    currentStreak++;
                }

                if (currentStreak >= Options.NumToWin)
                {
                    winningPlayers.Add(currentPlayer);
                    return true;
                }
            }

            // Also check if the board is full.  If so, it's a draw
            // (everyone's a winner!).
            if (Board.All(m => m.Owner != null))
            {
                winningPlayers = Board.Select(m => m.Owner).Distinct().ToList();
                return true;
            }

            return false;
        }

        // TODO: Have this method clone the current state, instead of modifying it.
        public TicTacToeState ApplyMove(TicTacToePlayer currentPlayer, TicTacToeMove newMove)
        {
            if (!(newMove is TicTacToeMove))
            {
                throw new InvalidOperationException();
            }

            if (newMove.GetType() == typeof(PlaceMarkMove))
            {
                PlaceMarkMove placeMarkMove = newMove as PlaceMarkMove;
                int newMoveIndex = placeMarkMove.NewMarkRow * Options.NumColumns + placeMarkMove.NewMarkColumn;
                if (Board[newMoveIndex].Owner != null)
                {
                    throw new InvalidOperationException("Can not place a mark on an already-owned location.");
                }

                Board[newMoveIndex] = new Mark(currentPlayer.Symbol, currentPlayer);
                CurrentPlayer = GetPlayerAfterMove(this, newMove);
            }
            else
            {
                throw new NotImplementedException();
            }

            return this;
        }

        protected TicTacToePlayer GetPlayerAfterMove(TicTacToeState startingState, TicTacToeMove move)
        {
            if (move is PlaceMarkMove)
            {
                int currentPlayerIndex = startingState.Options.Players.IndexOf(startingState.CurrentPlayer);
                if (currentPlayerIndex < 0)
                    throw new InvalidOperationException("Invalid state.");

                TicTacToePlayer nextPlayer = startingState.Options.Players[(currentPlayerIndex + 1)
                    % startingState.Options.Players.Count];

                return nextPlayer;
            }

            throw new NotImplementedException();
        }
    }
}
