using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;

namespace TicTacToe.Game
{
    public class ConsoleObserver : TicTacToePlayer
    {
        public ConsoleObserver(TicTacToeOptions options)
        {
            Symbol = Game.Symbol.Blank;
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

                PrintState(CurrentState);
                System.Console.ReadLine();
            }
        }

        public override TicTacToeMove GetMove()
        {
            throw new NotImplementedException();
        }
    }
}
