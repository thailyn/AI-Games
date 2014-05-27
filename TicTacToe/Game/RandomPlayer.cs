using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine;

namespace TicTacToe.Game
{
    public class RandomPlayer : TicTacToePlayer
    {
        public RandomPlayer(Symbol symbol, TicTacToeOptions options)
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
            List<TicTacToeMove> availableMoves = GetAvailableMoves(CurrentState).ToList();
            if (availableMoves.Count == 0)
            {
                return null;
            }

            Random rand = new Random();
            int randomValue = rand.Next(availableMoves.Count);

            return availableMoves[randomValue];
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
                        availableMoves.Add(new PlaceMarkMove(i, j, this));
                    }
                }
            }

            return availableMoves;
        }
    }
}
