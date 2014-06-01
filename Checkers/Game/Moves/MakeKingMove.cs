using Checkers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Moves
{
    public class MakeKingMove : CheckersMove
    {
        public Location Location
        {
            get;
            protected set;
        }

        protected MakeKingMove()
        {
            Steps = new List<CheckersMove>();
        }

        public MakeKingMove(Location location, CheckersPlayer performingPlayer = null)
            : this()
        {
            Location = location;
            PerformingPlayer = performingPlayer;
        }
    }
}
