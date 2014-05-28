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
            var basicMinimax = new Engine.Algorithms.BasicMinimaxSearch<TicTacToeOptions, TicTacToePlayer,
                TicTacToeMove, TicTacToeState>();
            var bestMove = basicMinimax.Search(CurrentState, GetAvailableMoves, this, -1, true);
            return bestMove;
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
