using Checkers.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game
{
    public class HumanConsolePlayer : CheckersPlayer
    {
        public HumanConsolePlayer(Team team, CheckersOptions options)
        {
            Team = team;
            Options = options;

            //CurrentState = new CheckersState(Options);
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

            List<CheckersPlayer> winningPlayers;
            if (CurrentState.IsEndState(out winningPlayers))
            {
                if (winningPlayers.Count == 0 || winningPlayers.Count > 1)
                {
                    Console.WriteLine("The game is over.  It was a draw.");
                }
                else if (winningPlayers[0] == this)
                {
                    Console.WriteLine("You won!");
                }
                else
                {
                    Console.WriteLine("You lost.");
                }

                PrintState(CurrentState);
            }
        }

        public override CheckersMove GetMove()
        {
            throw new NotImplementedException();
        }

        public void PrintCurrentState()
        {
            PrintState(CurrentState);
        }
    }
}
