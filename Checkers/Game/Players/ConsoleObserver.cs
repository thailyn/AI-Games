using Checkers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Players
{
    public class ConsoleObserver : CheckersPlayer
    {
        public ConsoleObserver(CheckersOptions options)
        {
            Team = Game.Team.None;
            Options = options;
        }

        public override void UpdateState(List<CheckersMove> moves)
        {
            foreach (var move in moves)
            {
                if (move == null)
                {
                    continue;
                }

                CurrentState = CurrentState.ApplyMove(move);
            }
            
            if (moves.Any(m => m is Game.Moves.EndTurnMove))
            {
                PrintState(CurrentState);
                System.Console.ReadLine();
            }
        }

        public override CheckersMove GetMove()
        {
            throw new NotImplementedException();
        }
    }
}
