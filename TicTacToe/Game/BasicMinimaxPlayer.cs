using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;

namespace TicTacToe.Game
{
    public class BasicMinimaxPlayer : TicTacToePlayer
    {
        public BasicMinimaxPlayer(Symbol symbol, TicTacToeOptions options)
        {
            Symbol = symbol;
            Options = options;

            CurrentState = new TicTacToeState(Options);
        }

        public override void UpdateState(List<TicTacToeMove> moves)
        {
            foreach (var move in moves)
            {
                if (move == null)
                {
                    continue;
                }

                CurrentState = CurrentState.ApplyMove(move);
            }
        }

        public override TicTacToeMove GetMove()
        {
            var bestMove = MinimaxSearch(CurrentState, true);
            return bestMove;
        }

        protected TicTacToeMove MinimaxSearch(TicTacToeState state, bool maximize)
        {
            List<TicTacToeMove> availableMoves = GetAvailableMoves(state).ToList();
            int bestMoveValue = int.MinValue;
            TicTacToeMove bestMove = null;

            foreach (var move in availableMoves)
            {
                int moveValue = MinimaxSearchStep(state.ApplyMove(move), false);
                if (moveValue > bestMoveValue)
                {
                    bestMoveValue = moveValue;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        protected int MinimaxSearchStep(TicTacToeState state, bool maximize)
        {
            List<TicTacToePlayer> winningPlayers = null;
            if (state.IsEndState(out winningPlayers))
            {
                if (winningPlayers.Count == 0 || winningPlayers.Count > 1)
                {
                    return 0;
                }

                var winningPlayer = winningPlayers[0];
                if (winningPlayer == this)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            if (maximize)
            {
                int bestValue = int.MinValue;
                List<TicTacToeMove> availableMoves = GetAvailableMoves(state).ToList();
                foreach (var move in availableMoves)
                {
                    TicTacToeState nextState = state.ApplyMove(move);
                    int val = MinimaxSearchStep(nextState, nextState.CurrentPlayer == this);
                    bestValue = val > bestValue ? val : bestValue;
                }

                return bestValue;
            }
            else
            {
                int bestValue = int.MaxValue;
                List<TicTacToeMove> availableMoves = GetAvailableMoves(state).ToList();
                foreach (var move in availableMoves)
                {
                    TicTacToeState nextState = state.ApplyMove(move);
                    int val = MinimaxSearchStep(nextState, nextState.CurrentPlayer == this);
                    bestValue = val < bestValue ? val : bestValue;
                }

                return bestValue;
            }
        }

        protected IEnumerable<TicTacToeMove> GetAvailableMoves(TicTacToeState currentState)
        {
            List<TicTacToeMove> availableMoves = new List<TicTacToeMove>();

            for (int i = 0; i < currentState.Options.NumRows; i++)
            {
                for (int j = 0; j < currentState.Options.NumColumns; j++)
                {
                    int boardIndex = i * currentState.Options.NumColumns + j;

                    if (currentState.Board[boardIndex].Owner == null)
                    {
                        availableMoves.Add(new PlaceMarkMove(i, j, currentState.CurrentPlayer));
                    }
                }
            }

            return availableMoves;
        }
    }
}
