using Checkers.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Moves
{
    public class EndTurnMove : CheckersMove
    {
        protected EndTurnMove()
        {
            Steps = new List<CheckersMove>();
        }

        public EndTurnMove(CheckersPlayer performingPlayer = null)
        {
            PerformingPlayer = performingPlayer;
        }
    }
}
