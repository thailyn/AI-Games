using Checkers.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Players
{
    public class RandomPlayer : CheckersPlayer
    {
        public RandomPlayer(Team team, CheckersOptions options)
        {
            Team = team;
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
        }

        public override CheckersMove GetMove()
        {
            List<CheckersMove> availableMoves = new List<CheckersMove>();
            foreach (var move in CurrentState.GetAvailableMoves(CurrentState))
            {
                availableMoves.Add(move);
            }

            if (availableMoves.Count == 0)
            {
                return null;
            }

            Random rand = new Random();
            int randomValue = rand.Next(availableMoves.Count);

            return availableMoves[randomValue];
        }
    }
}
