using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Algorithms
{
    public class BasicMinimaxSearch<T, U, V, W>
        where T : IGameOptions<U, W, T, V>
        where U : IPlayer<W, T, V, U>
        where V : IMove<W, T, U, V>
        where W : IState<T, U, V, W>
    {
        public V Search(W initialState, Func<W, IEnumerable<V>> getAvailableMovesFunc, U searchingPlayer, int depth, bool maximize)
        {
            List<V> availableMoves = getAvailableMovesFunc(initialState).ToList();
            int bestMoveValue = int.MinValue;
            V bestMove = default(V);

            foreach (var move in availableMoves)
            {
                int moveValue = MinimaxSearchStep(initialState.ApplyMove(move), getAvailableMovesFunc, searchingPlayer, false);
                if (moveValue > bestMoveValue)
                {
                    bestMoveValue = moveValue;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        protected int MinimaxSearchStep(W state, Func<W, IEnumerable<V>> getAvailableMovesFunc, U searchingPlayer, bool maximize)
        {
            List<U> winningPlayers = null;
            if (state.IsEndState(out winningPlayers))
            {
                if (winningPlayers.Count == 0 || winningPlayers.Count > 1)
                {
                    return 0;
                }

                var winningPlayer = winningPlayers[0];
                if (searchingPlayer.Equals(winningPlayer))
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
                List<V> availableMoves = getAvailableMovesFunc(state).ToList();
                foreach (var move in availableMoves)
                {
                    W nextState = state.ApplyMove(move);
                    int val = MinimaxSearchStep(nextState, getAvailableMovesFunc,
                        searchingPlayer, searchingPlayer.Equals(nextState.CurrentPlayer));
                    bestValue = val > bestValue ? val : bestValue;
                }

                return bestValue;
            }
            else
            {
                int bestValue = int.MaxValue;
                List<V> availableMoves = getAvailableMovesFunc(state).ToList();
                foreach (var move in availableMoves)
                {
                    W nextState = state.ApplyMove(move);
                    int val = MinimaxSearchStep(nextState, getAvailableMovesFunc,
                        searchingPlayer, searchingPlayer.Equals(nextState.CurrentPlayer));
                    bestValue = val < bestValue ? val : bestValue;
                }

                return bestValue;
            }
        }
    }
}
